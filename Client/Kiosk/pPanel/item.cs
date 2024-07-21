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
    public partial class item : Form
    {
        private ItemInsert itemInsert = new ItemInsert();
        public item(string itemName, int itemPrice, string itemContent)
        {
            InitializeComponent();
            this.label1.Text = itemName;
            this.label2.Text = itemPrice.ToString();
            this.label3.Text = itemContent;
        }

        private void item_Load(object sender, EventArgs e)
        {
            List<CheckBox> checkBoxes = itemInsert.checkBox();
            for(int i=0; i< checkBoxes.Count; i++)
            {
                checkedListBox1.Items.Add(checkBoxes[i].Text.ToString());
            }
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
