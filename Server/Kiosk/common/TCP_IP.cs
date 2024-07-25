using Kiosk.pPanel.common;
using MySql.Data.MySqlClient;
using Org.BouncyCastle.Asn1.Mozilla;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Net;
using System.Net.NetworkInformation;
using System.Net.Sockets;
using System.Windows.Forms;

namespace Kiosk.pPanel.common
{
    internal class TcpConnection
    {
        private TcpListener listener;
        private readonly BindingList<TcpClient> clients = new BindingList<TcpClient>(); 

        public string GetIPv4Address()
        {
            string ipAddress = "";

            foreach (NetworkInterface Interface in NetworkInterface.GetAllNetworkInterfaces())
            {
                // 필요한 네트워크 인터페이스 선택 (ex: Ethernet, Wi-Fi 등)
                if(Interface.NetworkInterfaceType == NetworkInterfaceType.Ethernet || Interface.NetworkInterfaceType == NetworkInterfaceType.Wireless80211)
                {
                    foreach(UnicastIPAddressInformation ip in Interface.GetIPProperties().UnicastAddresses)
                    {
                        // IPv4 Address 만 사용
                        if(ip.Address.AddressFamily == System.Net.Sockets.AddressFamily.InterNetwork)
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

        public async void TcpServerOn()
        {
            string IPv4Address = GetIPv4Address();
            listener = new TcpListener(IPAddress.Parse(IPv4Address), 8090);
            listener.Start();

            while (true)
            {
                TcpClient Client = await listener.AcceptTcpClientAsync();
                clients.Add(Client);
            }
        }

        public bool GetWaitingConnection()
        {
            if(listener != null)
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

