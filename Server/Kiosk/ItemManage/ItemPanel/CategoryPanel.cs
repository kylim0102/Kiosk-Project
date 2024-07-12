using Kiosk.pPanel.common;
using MySql.Data.MySqlClient;
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
        private MySqlConnection mysql = oGlobal.GetConnection();
        private string sql = null;

        public Category_Manage()
        {
            InitializeComponent();
        }

        // 데이터베이스가 비어있는지 여부 확인
        private int null_check()
        {
            int result = 0;
            sql = "select count(*) as count from categorytable";
            MySqlCommand cmd = new MySqlCommand(sql, mysql);
            
            using(MySqlDataReader reader = cmd.ExecuteReader())
            {
                reader.Read();

                result = reader.GetInt32("count");
            }
            return result;
        }

        private void Category_Manage_Load(object sender, EventArgs e)
        {
            try
            {
                // 데이터베이스가 비어 있다면 카테고리 코드를 10으로 등록
                if (null_check() == 0)
                {
                    Category_code.Text = "10";
                }
                // 비어있지 않다면 현재 카테고리 코드의 최댓값에서 +10을 하여 등록
                else 
                {
                    sql = "select max(cg_code) as max from categorytable";

                    MySqlCommand cmd = new MySqlCommand(sql, mysql);

                    using (MySqlDataReader reader = cmd.ExecuteReader())
                    {
                        reader.Read();
                        int max_code = reader.GetInt32("max") + 10;

                        Category_code.Text = max_code.ToString();
                    }
                }
            }
            catch(MySqlException ex)
            {
                MessageBox.Show(ex.Message, "MYSQL ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Reset_Click(object sender, EventArgs e)
        {
            Category_name.Text = String.Empty;
            Category_name.Focus();
        }

        private void Register_Click(object sender, EventArgs e)
        {
            try
            {
                string now = DateTime.Now.ToString("yyyy-MM-dd");
                sql = "insert into categorytable(cg_code, cg_name, regdate) values(@cg_code, @cg_name, regdate)";
                MySqlCommand cmd = new MySqlCommand(sql, mysql);

                cmd.Parameters.AddWithValue("@cg_code",Category_code.Text);
                cmd.Parameters.AddWithValue("@cg_name",Category_name.Text);
                cmd.Parameters.AddWithValue("@regdate", now);

                int result = cmd.ExecuteNonQuery();
                if (result < 0)
                {
                    MessageBox.Show("카테고리 등록에 실패했습니다! \n관리자에게 문의하세요.", "CODE : MS-ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    MessageBox.Show("카테고리 등록에 성공했습니다!", "CATEGORY REGISTER", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Category_name.Text = string.Empty;
                }
            }
            catch (MySqlException ex)
            {
                MessageBox.Show(ex.Message, "MYSQL ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
