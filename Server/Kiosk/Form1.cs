using Kiosk.Order;
using Kiosk.pPanel.common;
using MySqlX.XDevAPI.Relational;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.IO;
using System.Net.Sockets;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Kiosk
{
    public partial class Form1 : Form
    {
        private TcpConnection con = new TcpConnection();
        private pPanel.Chart chart;
        private string desktopPath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
        private GoogleStorage google = new GoogleStorage();

        public Form1()
        {
            InitializeComponent();
            google.GoogleDownloadMainImage();
            BackGroundImageSet();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Form1 form = this;

            groupBox2.BackColor = Color.Transparent;
            groupBox2.Parent = form;
            groupBox1.BackColor = Color.Transparent;
            groupBox1.Parent = form;
        }

        private void BackGroundImageSet()
        {
            Form1 form = this;

            string desktop = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            string imagePath = Path.Combine(desktop, "Kiosk_Image");
            Image image = Image.FromFile(imagePath + "\\" + "카페.jpg"); ;

            form.BackgroundImage = image;
            form.Dock = DockStyle.Fill;
            form.BackgroundImageLayout = ImageLayout.Stretch;
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
