using Kiosk.Order;
using Kiosk.pPanel.common;
using MySql.Data.MySqlClient;
using Org.BouncyCastle.Asn1.Mozilla;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.NetworkInformation;
using System.Net.Sockets;
using System.Runtime.Serialization.Formatters.Binary;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Kiosk.pPanel.common
{
    internal class TcpConnection
    {
        private TcpListener listener;
        private TcpClient client;
        private readonly BindingList<TcpClient> clients = new BindingList<TcpClient>();

        //private NetworkStream clientStream;
        //private BinaryFormatter formatter;

        #region GetIPv4Address(현재 네트워크의 IPv4 주소를 가져옴)
        public string GetIPv4Address()
        {
            string ipAddress = string.Empty;

            foreach (NetworkInterface Interface in NetworkInterface.GetAllNetworkInterfaces())
            {
                // 필요한 네트워크 인터페이스 선택 (ex: Ethernet, Wi-Fi 등)
                if (Interface.NetworkInterfaceType == NetworkInterfaceType.Ethernet || Interface.NetworkInterfaceType == NetworkInterfaceType.Wireless80211)
                {
                    foreach (UnicastIPAddressInformation ip in Interface.GetIPProperties().UnicastAddresses)
                    {
                        // IPv4 Address 만 사용
                        if (ip.Address.AddressFamily == System.Net.Sockets.AddressFamily.InterNetwork)
                        {
                            ipAddress = ip.Address.ToString();
                            break;
                        }
                    }
                }
                if (!string.IsNullOrEmpty(ipAddress))
                {
                    break;
                }
            }
            return ipAddress;
        }
        #endregion

        #region TcpServerOn(Tcp/Ip Server 시작, Client 접속 대기)
        public async Task TcpServerOn()
        {
            string IPv4Address = GetIPv4Address();
            listener = new TcpListener(IPAddress.Parse(IPv4Address), 8090);

            Console.WriteLine("Tcp/Ip Server On");
            Console.WriteLine("Server IPv4 Address: " + IPv4Address);

            listener.Start();

            try
            {
                while (true)
                {
                    TcpClient Client = await listener.AcceptTcpClientAsync();
                    Console.WriteLine("Client의 접속을 기다리는 중...");
                    lock (clients)
                    {
                        clients.Add(Client);
                        Console.WriteLine("Client가 접속했습니다. count: "+clients.Count);
                    }
                }
            }
            catch (ObjectDisposedException)
            {
                Console.WriteLine("Listner가 켜지있지 않습니다.");
            }
            catch (Exception ex)
            {
                Console.WriteLine("ERROR: "+ex.ToString());
            }
        }
        #endregion

        #region TcpClientCount(Client의 수를 반환)
        public int GetClientCount()
        {
            return clients.Count;
        }
        #endregion

        #region GetDataFromClient(Client로부터 Data를 수신)
        public DataTable DeserializeDataTable(byte[] data)
        {
            using (var memoryStream = new MemoryStream(data))
            {
                DataTable dataTable = new DataTable();
                dataTable.ReadXml(memoryStream);
                return dataTable;
            }
        }

        public async Task<DataTable> GetDataTableFromClient()
        {
            if (clients.Count <= 0)
            {
                Console.WriteLine("현재 접속된 클라이언트가 없습니다.");
                return null;
            }
            else
            {
                int count = clients.Count;
                client = clients[count-1]; // 첫 번째 클라이언트를 가져옵니다

                try
                {
                    using (var networkStream = client.GetStream())
                    {
                        if (networkStream == null || !client.Client.Connected)
                        {
                            Console.WriteLine("연결이 끊어진 상태입니다.");
                            return null;
                        }

                        byte[] buffer = new byte[4096];
                        int bytesRead = await networkStream.ReadAsync(buffer, 0, buffer.Length);

                        if (bytesRead > 0)
                        {
                            byte[] data = buffer.Take(bytesRead).ToArray();
                            DataTable table = DeserializeDataTable(data);
                            Console.WriteLine($"Received DataTable with {table.Rows.Count} rows.");
                            
                            return table;
                        }
                        else
                        {
                            Console.WriteLine("클라이언트가 데이터를 보내지 않았습니다.");
                            return null;
                        }
                    }
                }
                catch (IOException ioEx)
                {
                    Console.WriteLine("네트워크 오류가 발생했습니다: " + ioEx.Message);
                    await CheckClientConnectionsAsync(client);
                    return null;
                }
                catch (ObjectDisposedException objEx)
                {
                    Console.WriteLine("클라이언트 연결이 이미 종료되었습니다: " + objEx.Message);
                    await CheckClientConnectionsAsync(client);
                    return null;
                }
                catch (InvalidOperationException invOpEx)
                {
                    Console.WriteLine("소켓 작업 중 오류 발생: " + invOpEx.Message);
                    await CheckClientConnectionsAsync(client);
                    return null;
                }
                catch (Exception ex)
                {
                    Console.WriteLine("데이터 수신 중 오류가 발생했습니다: " + ex.Message);
                    throw;
                }
            }
        }
        #endregion

        #region DisConnectionClient(Client와의 연결을 끊음)
        private void RemoveClient(TcpClient clientToRemove)
        {
            lock (clients)
            {
                if (clients.Contains(clientToRemove))
                {
                    clients.Remove(clientToRemove);
                    clientToRemove.Close();
                    Console.WriteLine("클라이언트가 연결 리스트에서 제거되었습니다.");
                }
            }
        }
        public async Task CheckClientConnectionsAsync(TcpClient clientToRemove)
        {
            while (true)
            {
                await Task.Delay(1000); // 1초마다 체크
                lock (clients)
                {
                    foreach (var client in clients.ToList())
                    {
                        try
                        {
                            if (client == null || !client.Connected)
                            {
                                RemoveClient(client);
                            }
                        }
                        catch (SocketException)
                        {
                            // 클라이언트가 이미 연결이 끊어진 경우
                            RemoveClient(client);
                        }
                    }
                }
            }
        }
        #endregion

        #region Dummy Event
        public void Disconnection()
        {
            try
            {
                if (client != null)
                {
                    // 소켓이 연결 상태인지 확인
                    if (client.Client.Connected)
                    {
                        NetworkStream stream = client.GetStream();
                        if (stream != null)
                        {
                            stream.Close();
                            Console.WriteLine("stream 닫았다.");
                        }

                        client.Close();
                        Console.WriteLine("클라이언트 닫았다.");
                    }
                    else
                    {
                        Console.WriteLine("클라이언트 연결이 끊어진 상태입니다.");
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"오류 발생 : {ex.Message}");
            }
        }
        #endregion
    }
}

