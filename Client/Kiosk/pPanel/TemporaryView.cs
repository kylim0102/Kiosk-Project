using Kiosk.common;
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
    public partial class TemporaryView : Form
    {
        
        private static TemporaryTable TemporaryTable = new TemporaryTable();
        Order order = new Order();
        
        public TemporaryView()
        {
            InitializeComponent();
        }

        private void TemporaryViewcs_Load(object sender, EventArgs e)
        {
            dataGridView1.DataSource = TemporaryTable.all();

            string itemNumber = null;
            string itemName = null;
            int itemCount = 0;
            int payment = 0;
            int orderNumber = order.MaxOrderNumberFromDate();

            DataTable dt = TemporaryTable.all();

            for(int i = 0; i < dt.Rows.Count; i++)
            {
                DataRow row = dt.Rows[i];
                itemNumber = row["itemNumber"].ToString();
                itemName = row["itemName"].ToString();
                itemCount = Convert.ToInt32(row["itemCount"]);
                payment = Convert.ToInt32(row["payment"]);

                order.insertItem(itemNumber, itemName, itemCount, payment, orderNumber);
            }

            MessageBox.Show("주문이 완료되었습니다");
        }
    }
}
