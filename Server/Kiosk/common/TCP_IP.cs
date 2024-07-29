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

        private NetworkStream clientStream;
        private BinaryFormatter formatter;

        public string GetIPv4Address()
        {
            string ipAddress = "";

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

        public async Task TcpServerOn()
        {
            string IPv4Address = GetIPv4Address();
            listener = new TcpListener(IPAddress.Parse(IPv4Address), 8090);

            Console.WriteLine("Tcp/Ip Server On");
            Console.WriteLine("Server IPv4 Address: " + IPv4Address);

            listener.Start();

            Console.WriteLine("Client의 접속을 기다리는 중...");

            while (true)
            {
                TcpClient Client = await listener.AcceptTcpClientAsync();
                clients.Add(Client);
            }
        }

        public async Task<int> GetClientsCount()
        {
            return await Task.Run(() => clients.Count);
        }

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
            DataTable table = null;
            if (clients.Count <= 0)
            {
                throw new InvalidOperationException("현재 접속된 클라이언트가 없습니다.");
            }
            else
            {
                client = clients[0];
                try
                {
                    using (var networkStream = client.GetStream())
                    {
                        byte[] buffer = new byte[4096];
                        int bytesRead = await networkStream.ReadAsync(buffer, 0, buffer.Length);
                        if (bytesRead > 0)
                        {
                            byte[] data = buffer.Take(bytesRead).ToArray();
                            table = DeserializeDataTable(data);
                            // Process the DataTable
                            Console.WriteLine($"Received DataTable with {table.Rows.Count} rows.");

                        }
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("데이터 수신 중 오류가 발생했습니다: " + ex.Message);
                    throw;
                }
            }
            return table;
            //return await Task.Run(() => table);
        }

        public bool GetWaitingConnection()
        {
            if (listener != null)
            {
                return true;
            }
            else
            {
                return false;
            }
        }


    }
}

