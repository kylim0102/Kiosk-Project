using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using Kiosk.pPanel.common;

namespace Kiosk
{
    public partial class Form1 : Form
    {
        //pPanel.Chart chart = new pPanel.Chart();
        //Order.Order_Manage order = new Order.Order_Manage();
        pPanel.Chart chart;
        public Form1()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            chart = new pPanel.Chart();
            chart.Show();
        }
        

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            using(Order.Order_Manage order = new Order.Order_Manage())
            {
                order.ShowDialog();
            }
            
        }

        private void button3_Click(object sender, EventArgs e)
        {
            ItemManage.MainPage mainPage = new ItemManage.MainPage();
            mainPage.Show();
        }
    }
}
