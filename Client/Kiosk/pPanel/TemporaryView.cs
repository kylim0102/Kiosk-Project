using Kiosk.common;
using MySqlX.XDevAPI;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static Kiosk.common.TCP_IP;
using System.Net;

namespace Kiosk.pPanel
{
    public partial class TemporaryView : Form
    {
        private static TemporaryTable TemporaryTable = new TemporaryTable();
        private Order order = new Order();
        private TCP_Client tCP_Client = new TCP_Client();
        private TcpClient client;
        private NetworkStream stream;

        public TemporaryView()
        {
            InitializeComponent();
        }

        #region TemporaryView_Load(TemporaryView가 Load될 때 Temporary Table 데이터를 DataGridView로 보여주고, DB의 OrderTable에 저장)
        private  void TemporaryViewcs_Load(object sender, EventArgs e)
        {
            


            dataGridView1.DataSource = TemporaryTable.all();

            string itemNumber = null;
            string itemName = null;
            int itemCount = 0;
            int payment = 0;
            int orderNumber = order.MaxOrderNumberFromDate();

            DataTable dt = TemporaryTable.all();

            for(int i = 0; i < dt.Rows.Count; i++)
            {
                DataRow row = dt.Rows[i];
                itemNumber = row["itemNumber"].ToString();
                itemName = row["itemName"].ToString();
                itemCount = Convert.ToInt32(row["itemCount"]);
                payment = Convert.ToInt32(row["payment"]);

                order.insertItem(itemNumber, itemName, itemCount, payment, orderNumber);
            }

            MessageBox.Show("주문이 완료되었습니다");
        }
        #endregion

        private async void button2_Click(object sender, EventArgs e)
        {
            MessageBox.Show("클릭됬다!");  // 버튼 클릭 시 진입 확인용 메시지 박스

            try
            {
                client = new TcpClient();
                await client.ConnectAsync(IPAddress.Parse("192.168.78.235"), 8090);
                stream = client.GetStream();
                
                MessageBox.Show("커넥션 실행");  // 연결이 성공적으로 이루어진 경우 메시지 박스
            }
            catch (Exception ex)
            {
                // 예외 처리
                MessageBox.Show($"Connection error: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
