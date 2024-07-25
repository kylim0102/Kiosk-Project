using Kiosk.pPanel.common;
using System;
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
            con.TcpServerOn();

            if(con.GetWaitingConnection())
            {
                waitingCon.Text = "접속 대기중";
            }
            else
            {
                waitingCon.Text = "연결 끊김";
            }
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
