using Google.Protobuf.WellKnownTypes;
using Kiosk.pPanel.common;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
<<<<<<< HEAD
using static Kiosk.ItemManage.ItemPanel.OptionPanel;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
=======
using Kiosk.ItemManage.ItemPanel;
using Kiosk.pPanel.common;
using MySql.Data.MySqlClient;
>>>>>>> fa99af22c0efeef6f33690cc7c3c5d2931df18c2

namespace Kiosk.ItemManage
{
    public partial class MainPage : Form
    {
        ItemPanel.ItemPanel item = new ItemPanel.ItemPanel();
        ItemPanel.Category_Manage category = new ItemPanel.Category_Manage();
        ItemPanel.OptionPanel option = new ItemPanel.OptionPanel();
        ItemPanel.Itemmanage itemmanage = new ItemPanel.Itemmanage();
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
<<<<<<< HEAD

            /*MySqlConnection conn = oGlobal.GetConnection();
            conn.Open();
            int idx = 98;
            string option = SharedData.Option;
            
            try
            {

                string query = "INSERT INTO test (idx, name) VALUES (@idx, @option)"; // 테이블 쿼리
                MySqlCommand cmd = new MySqlCommand(query, conn);

                // 파라미터 추가
                cmd.Parameters.AddWithValue("@idx", idx);
                cmd.Parameters.AddWithValue("@option", option);

                int rowsAffected = cmd.ExecuteNonQuery();

                if (rowsAffected > 0)
                {
                    MessageBox.Show("데이터가 성공적으로 삽입되었습니다.");
                }
                else
                {
                    MessageBox.Show("데이터 삽입에 실패했습니다.");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"오류 발생: {ex.Message}");
            }
            finally
            {
                conn.Close();
            }*/
=======
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


>>>>>>> fa99af22c0efeef6f33690cc7c3c5d2931df18c2
        }

        private void button5_Click(object sender, EventArgs e)
        {
            
        }

        private void MainPage_Load(object sender, EventArgs e)
        {

        }

        private void button6_Click(object sender, EventArgs e)
        {
            // panel 하나 만들어서 생성
            panel1.Controls.Clear();
            panel1.Controls.Add(itemmanage);
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
