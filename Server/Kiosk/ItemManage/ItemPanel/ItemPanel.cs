using Azure.Storage.Blobs.Models;
using Azure.Storage.Blobs;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Kiosk.pPanel.common;
using MySql.Data.MySqlClient;
using Azure;

namespace Kiosk.ItemManage.ItemPanel
{
    public partial class ItemPanel : UserControl
    {
        private StorageConnection storage = new StorageConnection();
        private MySqlConnection mysql = oGlobal.GetConnection();
        private ItemTable item_table = new ItemTable();
        private CategoryTable category_table = new CategoryTable();

        public ItemPanel()
        {
            InitializeComponent();
        }
        
        private void button2_Click_1(object sender, EventArgs e)
        {

        }

        private void button3_Click_1(object sender, EventArgs e)
        {
            // 파일 찾아보기
            file_path.Text = storage.LocalStorageScan();
        }

        private void button4_Click_1(object sender, EventArgs e)
        {

        }

        private void Item_Register_Enter(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            // 리셋 버튼 클릭 시 모든 입력 값을 초기화
            Item_category.SelectedIndex = -1;
            Item_name.Text = string.Empty;
            Item_price.Text = string.Empty;
            Item_content.Text = string.Empty;
            file_path.Text= string.Empty;

            Item_name.Focus();
        }

        private void Register_Click(object sender, EventArgs e)
        {
            if (Item_category.SelectedIndex == -1 || Item_category.Text.Equals("")) // 카테고리
            {
                MessageBox.Show("입력하신 제품의 카테고리를 선택해주세요 !", "ITEM REGISTER ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Item_category.Focus();
                return;
            }
            else if (Item_name.Text.Equals("")) // 제품명
            {
                MessageBox.Show("입력하신 제품의 이름을 입력해주세요 !", "ITEM REGISTER ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Item_name.Focus();
                return;
            }
            else if (Item_price.Text.Equals("")) // 제품 가격
            {
                MessageBox.Show("입력하신 제품의 가격을 입력해주세요 !", "ITEM REGISTER ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Item_price.Focus();
                return;
            }
            else if (Item_content.Text.Equals(""))
            {
                MessageBox.Show("입력하신 제품의 제품 설명을 입력해주세요 !", "ITEM REGISTER ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Item_content.Focus();
                return;
            }
            else
            {
                int result = 0;

                // MySql DB Register
                result = item_table.ItemRegister(Item_name.Text, Convert.ToInt32(Item_price.Text), Item_content.Text, Item_category.Text);

                // Azure Storage Upload Start
                if (file_path.Text.Equals(""))
                {
                    MessageBox.Show("업로드된 제품 사진이 없습니다!", "File Upload Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                bool upload = storage.Upload(file_path.Text);

                // Mysql, Azure 동시 예외처리
                if (result < 0)
                {
                    MessageBox.Show("제품 등록에 실패했습니다! \n관리자에게 문의하세요.", "CODE : MS-ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else if (!upload)
                {
                    MessageBox.Show("제품 등록에 실패했습니다! \n관리자에게 문의하세요.", "CODE : AS-ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    MessageBox.Show("제품 등록에 성공했습니다!", "ITEM REGISTER", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    // 모든 입력 값을 초기화
                    Item_category.SelectedIndex = -1;
                    Item_name.Text = string.Empty;
                    Item_price.Text = string.Empty;
                    Item_content.Text = string.Empty;
                    file_path.Text = string.Empty;

                    Item_name.Focus();
                }
            }
        }

        private void ItemPanel_Load(object sender, EventArgs e)
        {
            #region 제품 등록 부분 카테고리
            List<string> list = category_table.GetCategory();

            for (int i = 0; i < list.Count; i++)
            {
                Item_category.Items.Add(list[i]);
            }
            #endregion


            #region datagridview 리스트 뽑아오기




            #endregion

        }

        private void tabPage2_Click(object sender, EventArgs e)
        {

        }
    }
}