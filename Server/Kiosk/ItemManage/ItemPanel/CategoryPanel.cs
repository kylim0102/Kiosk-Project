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

<<<<<<< HEAD
        private void textBox1_TextChanged(object sender, EventArgs e)
        {
           
=======
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
>>>>>>> fa99af22c0efeef6f33690cc7c3c5d2931df18c2
        }
    }
}
