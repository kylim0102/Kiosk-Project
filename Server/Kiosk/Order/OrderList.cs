using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Kiosk.Order
{
    public partial class OrderList : Form
    {
        public OrderList()
        {
            InitializeComponent();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            string list1 = string.Join(Environment.NewLine, listBox1.Items.Cast<string>());
            
            MessageBox.Show(list1,groupBox1.Text);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            string list2 = string.Join(Environment.NewLine, listBox2.Items.Cast<string>());

            MessageBox.Show(list2, groupBox2.Text);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            MessageBox.Show("1번 호출벨을 울립니다.");
            groupBox1.Visible = false;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            MessageBox.Show("2번 호출벨을 울립니다.");
            groupBox2.Visible = false;
        }
    }
}
