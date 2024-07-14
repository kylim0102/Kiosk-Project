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

            // Category Register
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

            // Category List View
            DataTable data = table.AddGridView();
            category_tbl_list.AutoGenerateColumns = true;
            category_tbl_list.DataSource = data;

            // Category Manage
            List<string> list = table.GetCategory();
            for(int a = 0; a< list.Count; a++)
            {
                category_manage_list.Items.Add(list[a]);
            }
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
            category_tbl_list.Columns["NO"].Width = 150;
            category_tbl_list.Columns["CODE"].Width = 150;
            category_tbl_list.Columns["NAME"].Width = 150;
            category_tbl_list.Columns["DATE"].Width = 150;
        }

        private void category_tbl_list_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            
        }

        private void category_manage_list_SelectedIndexChanged(object sender, EventArgs e)
        {
            string selected = category_manage_list.SelectedItem.ToString();
            List<string> list = table.GetCategoryInfoForName(category_manage_list.SelectedItem.ToString());
            category_manage_idx.Text = list[0].ToString();
            category_manage_code.Text = list[1].ToString();
            category_manage_name.Text = list[2].ToString();
        }

        private void category_manage_modify_Click(object sender, EventArgs e)
        {
            if (category_manage_idx.Text.Equals("") || category_manage_code.Text.Equals("") || category_manage_name.Text.Equals(""))
            {
                MessageBox.Show("수정하려는 카테고리를 선택해주세요!","CATEGORY MANAGE ERROR",MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            else
            {
                bool result = table.CategoryModify(category_manage_idx.Text, category_manage_name.Text);
                category_manage_name.Text = string.Empty;
                category_manage_code.Text = string.Empty;
                category_manage_idx.Text = string.Empty;

                // Category Manage
                category_manage_list.Items.Clear();

                List<string> list = table.GetCategory();
                for (int a = 0; a < list.Count; a++)
                {
                    category_manage_list.Items.Add(list[a]);
                }
            }
        }

        private void category_manage_reset_Click(object sender, EventArgs e)
        {
            // Category Manage
            category_manage_list.Items.Clear();

            List<string> list = table.GetCategory();
            for (int a = 0; a < list.Count; a++)
            {
                category_manage_list.Items.Add(list[a]);
            }
        }

        private void category_manage_delete_Click(object sender, EventArgs e)
        {
            if (category_manage_idx.Text.Equals("") || category_manage_code.Text.Equals("") || category_manage_name.Text.Equals(""))
            {
                MessageBox.Show("삭제하려는 카테고리를 선택해주세요!", "CATEGORY MANAGE ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            else
            {
                DialogResult message = MessageBox.Show("선택하신 카테고리를 삭제하시겠습니까? \n삭제후에는 복구할 수 없습니다.","CATEGORY MANAGER",MessageBoxButtons.OKCancel,MessageBoxIcon.Warning);

                if (message == DialogResult.OK)
                {
                    bool result = table.CategoryDelete(category_manage_idx.Text);
                    category_manage_name.Text = string.Empty;
                    category_manage_code.Text = string.Empty;
                    category_manage_idx.Text = string.Empty;

                    // Category Manage
                    category_manage_list.Items.Clear();

                    List<string> list = table.GetCategory();
                    for (int a = 0; a < list.Count; a++)
                    {
                        category_manage_list.Items.Add(list[a]);
                    }
                }
                else if (message == DialogResult.Cancel)
                {
                    MessageBox.Show("삭제 요청을 취소합니다.","CATEGORY MANAGER",MessageBoxButtons.OK,MessageBoxIcon.Information);
                }
            }
        }
    }
}
