using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Kiosk.ItemManage.ItemPanel
{
    public partial class Category_Manage : UserControl
    {
        
        public Category_Manage()
        {
            InitializeComponent();
        }

        public static class category_name
        {
            public static string category
            {
                get;
                set; 
            }

        }


        private void Category_Manage_Load(object sender, EventArgs e)
        {

        }

        private void categorys_TextChanged(object sender, EventArgs e)
        {
            category_name.category = categorys.Text;
        }
    }
}
