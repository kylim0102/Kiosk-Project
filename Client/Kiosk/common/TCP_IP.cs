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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using System.Data;

namespace Kiosk.common
{
    internal class TCP_IP
    {
        internal class TCP_Client
        {
            private TcpClient client;
            private NetworkStream stream;

            private async Task HandelClient(DataTable table)
            {
                byte[] data = SerializeDataTable(table);
                await stream.WriteAsync(data, 0, data.Length);
            }

            #region SerializeDataTable(DataTable을 역직렬화)
            public byte[] SerializeDataTable(DataTable table)
            {
                if (table == null)
                {
                    throw new ArgumentNullException(nameof(table), "DataTable cannot be null");
                }

                using (var memoryStream = new MemoryStream())
                {
                    try
                    {
                        table.WriteXml(memoryStream, XmlWriteMode.WriteSchema);
                        return memoryStream.ToArray();
                    }
                    catch (InvalidOperationException ex)
                    {
                        // 예외 처리 및 로깅
                        Console.WriteLine($"예외 발생: {ex.Message}");
                        throw; // 예외를 다시 던져 호출자에게 전달
                    }
                }
            }
            #endregion

            #region TcpConnection(Server와 TCP/IP 통신 연결)
            public async Task<bool> Connection(DataTable table)
            {
                bool connection = false;

                try
                {
                    client = new TcpClient();
                    await client.ConnectAsync(IPAddress.Parse("192.168.35.64"), 8090);
                    stream = client.GetStream();
                    _ = HandelClient(table);

                    connection = true;
                }
                catch (Exception ex)
                {
                    // 예외 처리
                    connection = false;

                    MessageBox.Show($"Connection error: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

                return connection;
            }
            #endregion
        }
    }
}
