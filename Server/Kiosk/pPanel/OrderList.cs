using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Kiosk.pPanel
{
    public partial class OrderList : UserControl
    {
        private OrderListSQL sql = new OrderListSQL();
        public OrderList()
        {
            InitializeComponent();
        }

        private void OrderList_Load(object sender, EventArgs e)
        {
            ListBox list = sql.GetAllOrderTable();

            foreach (var item in list.Items)
            {
                listBox1.Items.Add(item);
            }
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            Item SelectedItem = listBox1.SelectedItem as Item;

            if (SelectedItem != null)
            {
                // 선택된 아이템의 Tag 속성에 접근합니다
                object tag = SelectedItem.Tag;
                ListBox list = sql.GetSelectItems(tag.ToString());
                listBox2.Items.Clear();

                foreach (var Item in list.Items)
                {
                    
                    listBox2.Items.Add(Item);
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("결제 취소후에는 복구할 수 없습니다.\n취소하시겠습니까?", "PAYMENT MANAGER", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
            if(result == DialogResult.OK)
            {
                if(listBox2.Items.Count<1)
                {
                    MessageBox.Show("결제를 취소할 항목이 없습니다.\n다시 확인해주세요.","PAYMENT MANAGE",MessageBoxButtons.OK,MessageBoxIcon.Error);
                    return;
                }
                else
                {
                    sql.DeleteOrderItem(listBox2.Items[0].ToString());

                    listBox1.Items.Clear();
                    ListBox list = sql.GetAllOrderTable();

                    foreach (var item in list.Items)
                    {
                        listBox1.Items.Add(item);
                    }

                    listBox2.Items.Clear();
                }
            }
            else
            {
                MessageBox.Show("결제 확인으로 돌아갑니다.","PAYMENT MANAGER",MessageBoxButtons.OK,MessageBoxIcon.Information);
                return;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            listBox1.Items.Clear();
            ListBox list = sql.GetAllOrderTable();

            foreach (var item in list.Items)
            {
                listBox1.Items.Add(item);
            }

            listBox2.Items.Clear();
        }
    }
}
