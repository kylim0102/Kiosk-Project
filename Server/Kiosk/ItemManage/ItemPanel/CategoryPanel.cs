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


        #region Category On Load(Tab Control 세팅)
        private void Category_Manage_Load(object sender, EventArgs e)
        {
            // TAB1 Category Register
            if (table.CategoryTableCount() == 0)
            {
                // 데이터베이스가 비어 있다면 카테고리 코드를 10으로 등록
                Category_code.Text = "10";
            }
            else 
            {
                // 비어있지 않다면 현재 카테고리 코드의 최댓값에서 +10을 하여 등록
                Category_code.Text = table.CategoryMaxCode().ToString();
            }

            // TAB2 Category List View
            DataTable data = table.AddGridView();
            category_tbl_list.AutoGenerateColumns = true;
            category_tbl_list.DataSource = data;

            // TAB3 Category Manage
            List<string> list = table.GetCategory();
            for(int a = 0; a< list.Count; a++)
            {
                category_manage_list.Items.Add(list[a]);
            }
        }
        #endregion


        // TAB1 AREA
        #region Category Register Reset Button(카테고리 INSERT 다시쓰기)
        private void Reset_Click(object sender, EventArgs e)
        {
            Category_name.Text = String.Empty;
            Category_name.Focus();
        }
        #endregion

        #region Category Register Saving DB(카테고리 INSERT EVENT)
        private void Register_Click(object sender, EventArgs e)
        {
            int result = table.CategoryRegister(Category_code.Text, Category_name.Text);
            Category_name.Text = string.Empty;
        }
        #endregion
        // TAB1 AREA


        // TAB2 AREA
        #region Category List Refresh Button(카테고리 리스트 새로고침)
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
        #endregion
        // TAB2 AREA


        // TAB3 AREA
        #region Category Manage(카테고리 이름 선택 시 관련 정보 세팅)
        private void category_manage_list_SelectedIndexChanged(object sender, EventArgs e)
        {
            string selected = category_manage_list.SelectedItem.ToString();
            List<string> list = table.GetCategoryInfoForName(category_manage_list.SelectedItem.ToString());
            category_manage_idx.Text = list[0].ToString();
            category_manage_code.Text = list[1].ToString();
            category_manage_name.Text = list[2].ToString();
        }
        #endregion

        #region Category Manage Modify Button Event(수정 버튼 클릭 시)
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
        #endregion

        #region Category Manage(카테고리 수정이나 삭제 후 새로고침 버튼 / 리스트 비우고 다시 추가)
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
        #endregion

        #region Category Manage(카테고리 삭제 버튼 클릭 시 Event)
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
        #endregion
        // TAB3 AREA


        #region Dummy Event
        private void category_tbl_list_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
        #endregion
    }
}
