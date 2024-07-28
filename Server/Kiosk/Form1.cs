using Kiosk.Order;
using Kiosk.pPanel.common;
using MySqlX.XDevAPI.Relational;
using System;
using System.Data;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Kiosk
{
    public partial class Form1 : Form
    {
        private TcpConnection con = new TcpConnection();
        private pPanel.Chart chart;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            /*await con.TcpServerOn();

            Console.WriteLine("접속 상태 체크"+con.GetWaitingConnection());

            if(con.GetWaitingConnection())
            {
                waitingCon.Text = "접속 대기중...";
            }
            else
            {
                waitingCon.Text = "연결 끊김";
            }
           

            await ShowClientConnectedMessageAsync();*/
        }
        private void ShowDataTableForm(DataTable dataTable)
        {
            OrderList orderList = new OrderList(dataTable);
            orderList.Show();
        }


        #region Main Controller
        #region Show Chart(차트 창 보기)
        private void button2_Click(object sender, EventArgs e)
        {
            chart = new pPanel.Chart();
            chart.Show();
        }
        #endregion

        #region Show Order(오더 창 보기)
        private void button1_Click(object sender, EventArgs e)
        {
            using (Order.Order_Manage order = new Order.Order_Manage())
            {
                order.ShowDialog();
            }

        }
        #endregion

        #region Show OrderList(주문 목록 창 보기)
        private async void button4_Click(object sender, EventArgs e)
        {
            if (con != null) // connection 된 상태면
            {
                DataTable dt = await con.GetDataTableFromClient();
                if (dt != null)
                {
                    Console.WriteLine($"Received DataTable with {dt.Rows.Count} rows.");
                    using (Order.OrderList order = new Order.OrderList(dt))
                    {
                        order.ShowDialog();
                    }
                }
            }
        }
        #endregion

        #region Show ItemManage(제품관리 창 보기)
        private void button3_Click(object sender, EventArgs e)
        {
            ItemManage.MainPage mainPage = new ItemManage.MainPage();
            mainPage.Show();
        }

        #endregion

        #endregion

        private async void button5_Click(object sender, EventArgs e)
        {
            int clients = await con.GetClientsCount();
            MessageBox.Show("접속한 클라이언트 수: "+clients,"TCP/IP SERVER MANAGER",MessageBoxButtons.OK,MessageBoxIcon.Information);
            
            
        }

        private async Task ShowClientConnectedMessageAsync()
        {
            if (InvokeRequired)
            {
                await Task.Run(() => Invoke(new Action(async () => await ShowClientConnectedMessageAsync())));
            }
            else
            {
                MessageBox.Show("클라이언트가 접속했습니다.", "TCP/IP SERVER MANAGER", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
    }
}
