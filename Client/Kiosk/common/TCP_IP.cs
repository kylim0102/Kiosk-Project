using MySqlX.XDevAPI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Net;

namespace Kiosk.common
{
    internal class TCP_IP
    {
        internal class TCP_Client
        {
            private TcpClient client;
            private NetworkStream stream;
            private async Task HandelClient(TcpClient client)
            {
                NetworkStream stream = client.GetStream();
                byte[] buffer = new byte[1024];

                int read;
                while ((read = await stream.ReadAsync(buffer, 0, buffer.Length)) > 0)
                {
                    string message = Encoding.UTF8.GetString(buffer, 0, read);

                    MessageBox.Show(message, "Server", MessageBoxButtons.OK, MessageBoxIcon.Information);

                }
            }

            public async Task Connection()
            {
                try
                {
                    client = new TcpClient();
                    await client.ConnectAsync(IPAddress.Parse("192.168.78.235"), 8090);
                    stream = client.GetStream();
                }
                catch (Exception ex)
                {
                    // 예외 처리
                    MessageBox.Show($"Connection error: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
    }
}
