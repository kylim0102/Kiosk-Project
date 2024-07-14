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
using MySqlX.XDevAPI.Relational;
using static System.Net.WebRequestMethods;

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
        private void tabPage2_Click(object sender, EventArgs e)
        {

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
            ItemUpdate itemUpdate = new ItemUpdate();
            DataTable data = itemUpdate.SelectData(mysql);
            dataGridView1.AutoGenerateColumns = true;
            dataGridView1.DataSource = data;

            // CellClick 이벤트 핸들러 등록
            dataGridView1.CellClick += DataGridView1_CellClick;
            #endregion

        }
        private void DataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            #region 내가 선택한 데이터 담기
            if (e.RowIndex >= 0) // 유효한 행이 클릭되었을 때
            {
                DataGridViewRow clickedRow = dataGridView1.Rows[e.RowIndex];
                List<object> cellValue = new List<object>();
                //일단 뽑아와서 담아봐
                for(int i=0; i<clickedRow.Cells.Count; i++) 
                {
                     cellValue.Add(clickedRow.Cells[i].Value);
                }
                if (cellValue != null)
                {
                    textBox1.Text = cellValue[0].ToString();
                    textBox2.Text = cellValue[1].ToString();
                    textBox3.Text = cellValue[2].ToString();
                    textBox4.Text = cellValue[3].ToString();
                    textBox5.Text = cellValue[5].ToString();
                }
                else
                {
                    textBox1.Text = ""; // 값이 null인 경우 처리
                }
            }
            else
            {
                textBox1.Text = ""; // 선택된 행이 없는 경우 처리
            }
            #endregion
        }
        #region 상품 수정 / 삭제

        private void button2_Click(object sender, EventArgs e)
        {
            #region 담은 데이터 삭제
            ItemUpdate itemUpdate = new ItemUpdate();
            int result = 0;
            int idx = Convert.ToInt32(textBox1.Text);

            if (MessageBox.Show("삭제하시겠습니까?", "YesOrNo", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                 result = itemUpdate.ItemDelete(idx);

                if (result > 0)
                {
                    MessageBox.Show("데이터가 성공적으로 삭제되었습니다.");
                    datagridviewReload(); // 초기화 시키고 다시 뽑아오기
                }
                else
                {
                    MessageBox.Show("데이터 삭제에 실패했습니다.");
                }
            }
            #endregion
        }
        private void button1_Click(object sender, EventArgs e)
        {
            #region 담은 데이터 수정
            ItemUpdate itemUpdate = new ItemUpdate();
            int result = 0;

            int idx = Convert.ToInt32(textBox1.Text);
            String itemName = textBox2.Text;
            int price = Convert.ToInt32(textBox3.Text);
            String content = textBox4.Text;
            String category = textBox5.Text;

            if (MessageBox.Show("수정하시겠습니까?", "YesOrNo", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                result = itemUpdate.ItemChange(itemName,price,content,category,idx);

                if (result > 0)
                {
                    MessageBox.Show("데이터가 성공적으로 수정되었습니다.");
                    datagridviewReload(); // 초기화 시키고 다시 뽑아오기
                }
                else
                {
                    MessageBox.Show("데이터 수정에 실패했습니다.");
                }
            }
            #endregion
        }
        #region datagridview 초기화 적용
        private void datagridviewReload()
        {
            ItemUpdate itemUpdate = new ItemUpdate();
            // DataGridView 초기화
            dataGridView1.DataSource = null;
            dataGridView1.Rows.Clear();
            dataGridView1.Columns.Clear();

            DataTable data = itemUpdate.SelectData(mysql);
            dataGridView1.AutoGenerateColumns = true;
            dataGridView1.DataSource = data;

            // CellClick 이벤트 핸들러 등록
            dataGridView1.CellClick += DataGridView1_CellClick;
        }

        #endregion
        #endregion


    }
}