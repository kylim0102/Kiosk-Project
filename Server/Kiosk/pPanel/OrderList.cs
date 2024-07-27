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
    }
}
