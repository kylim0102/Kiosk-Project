using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Kiosk.pPanel.common;
using MySql.Data.MySqlClient;

namespace Kiosk.ItemManage.ItemPanel
{
    public partial class OptionPanel : UserControl
    {
        public OptionPanel()
        {
            InitializeComponent();
        }


        public void OptionPanel_Load(object sender, EventArgs e)
        {

        }

        public void textBox1_TextChanged(object sender, EventArgs e)
        {
            SharedData.Option = textBox1.Text;
        }
        public static class SharedData
        {
            public static string Option { get; set; }
        }



    }
}
