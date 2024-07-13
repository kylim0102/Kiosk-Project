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
        private CategoryTable table = new CategoryTable();
        private string sql = null;

        public Category_Manage()
        {
            InitializeComponent();
        }

        private void Category_Manage_Load(object sender, EventArgs e)
        {
            // 데이터베이스가 비어 있다면 카테고리 코드를 10으로 등록
            if (table.CategoryTableCount() == 0)
            {
                Category_code.Text = "10";
            }
            // 비어있지 않다면 현재 카테고리 코드의 최댓값에서 +10을 하여 등록
            else 
            {
                Category_code.Text = table.CategoryMaxCode().ToString();
            }
            DataTable data = table.AddGridView();
            category_tbl_list.AutoGenerateColumns = true;
            category_tbl_list.DataSource = data;
        }

        private void Reset_Click(object sender, EventArgs e)
        {
            Category_name.Text = String.Empty;
            Category_name.Focus();
        }

        private void Register_Click(object sender, EventArgs e)
        {
            int result = table.CategoryRegister(Category_code.Text, Category_name.Text);
            Category_name.Text = string.Empty;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            category_tbl_list.DataSource = null;

            DataTable data = table.AddGridView();
            category_tbl_list.AutoGenerateColumns = true;
            category_tbl_list.DataSource = data;
        }
    }
}
