using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Kiosk.ItemManage
{
    public partial class MainPage : Form
    {
        itemPanel.itemPanel1 item = new itemPanel.itemPanel1();
        itemPanel.CategoryPanel category = new itemPanel.CategoryPanel();
        itemPanel.OptionPanel option = new itemPanel.OptionPanel();
        public MainPage()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            panel1.Controls.Clear();
            panel1.Controls.Add(item);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            panel1.Controls.Clear();
            panel1.Controls.Add(category);
          
        }

        private void button3_Click(object sender, EventArgs e)
        {
            panel1.Controls.Clear();
            panel1.Controls.Add(option);
           
        }

        private void button6_Click(object sender, EventArgs e)
        {
            MessageBox.Show("등록되었습니다.");
        }

        private void button5_Click(object sender, EventArgs e)
        {
            MessageBox.Show("수정되었습니다.");
        }
    }
}
