using Kiosk.Order;
using Kiosk.pPanel.common;
using MySqlX.XDevAPI.Relational;
using System;
using System.Collections.Generic;
using System.Data;
using System.Net.Sockets;
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


        private async void Form1_Load(object sender, EventArgs e)
        {
            
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

            using (Order.OrderList order = new Order.OrderList())
            {
                order.ShowDialog();
            }

/*            if (con != null) // connection 된 상태면
            {
                DataTable dt = await con.GetDataTableFromClient();
                if (dt != null)
                {
                    Console.WriteLine($"Received DataTable with {dt.Rows.Count} rows.");
                    using (Order.OrderList order = new Order.OrderList(dt))
                    {
                        order.ShowDialog();
                    }
                    //con.Disconnection();
                }
                else
                {
                    DataTable dataTable = new DataTable();
                    using (Order.OrderList order = new Order.OrderList(dataTable))
                    {
                        order.ShowDialog();
                    }
                }
            }*/
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

    }
}
