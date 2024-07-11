using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Kiosk.ItemManage.ItemPanel;
using Kiosk.pPanel.common;
using MySql.Data.MySqlClient;

namespace Kiosk.ItemManage
{
    public partial class MainPage : Form
    {
        ItemPanel.ItemPanel item = new ItemPanel.ItemPanel();
        ItemPanel.Category_Manage category = new ItemPanel.Category_Manage();
        ItemPanel.OptionPanel option = new ItemPanel.OptionPanel();

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

        private void button4_Click(object sender, EventArgs e)
        {
            Category_Manage categorys = new ItemPanel.Category_Manage();
            String names = Category_Manage.category_name.category;



            //string names = (categorys.Controls["categorys"] as TextBox).Text;

            try
            {
                using (MySqlConnection mySql = oGlobal.GetConnection())
                {
                    mySql.Open();
                    string sql = "insert into test values (@id, @name)";
                    MySqlCommand cmd = new MySqlCommand(sql, mySql);

                    cmd.Parameters.AddWithValue("@id", 55);
                    cmd.Parameters.AddWithValue("name", names);

                    //cmd.ExecuteNonQuery();
                    MessageBox.Show(names, "Success",MessageBoxButtons.OK,MessageBoxIcon.Information);
                }
            }
            catch(MySqlException) 
            {
                MessageBox.Show("입력 실패! ","ERROR",MessageBoxButtons.OK,MessageBoxIcon.Error); 
            }


        }

        private void button5_Click(object sender, EventArgs e)
        {
            MessageBox.Show("수정되었습니다.");
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
