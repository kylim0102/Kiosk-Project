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

        private void Form1_Load(object sender, EventArgs e)
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
            Order.Order_Manage order = new Order.Order_Manage();

            order.Show();
            

        }
        #endregion

        #region Show OrderList(주문 목록 창 보기)
        private async void button4_Click(object sender, EventArgs e)
        {

            Order.OrderList order = new Order.OrderList();

            order.Show();
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
