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

namespace Kiosk.ItemManage.ItemPanel
{
    public partial class ItemPanel : UserControl
    {
        private StorageConnection storage = new StorageConnection();
        private MySqlConnection mysql = oGlobal.GetConnection();
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


            var fileContent = string.Empty;
            var filePath = string.Empty;

            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.InitialDirectory = "c:\\";
                openFileDialog.Filter = "txt files (*.txt)|*.txt|All files (*.*)|*.*";
                openFileDialog.FilterIndex = 2;
                openFileDialog.RestoreDirectory = true;

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    //Get the path of specified file
                    filePath = openFileDialog.FileName;
                    file_path.Text = filePath;

                    //Read the contents of the file into a stream
                    var fileStream = openFileDialog.OpenFile();

                    using (StreamReader reader = new StreamReader(fileStream))
                    {
                        fileContent = reader.ReadToEnd();
                    }
                }
            }

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
                if (mysql.State == ConnectionState.Closed)
                {
                    mysql.Open();
                }

                try
                {
                    // MySql DB Register Start
                    string now = DateTime.Now.ToString("yyyy-MM-dd");
                    string sql = "insert into itemtable(itemName, price, content, regdate, category) values(@itemName, @price, @content, @regdate, @category)";

                    MySqlCommand cmd = new MySqlCommand(sql, mysql);

                    cmd.Parameters.AddWithValue("@itemName",Item_name.Text);
                    cmd.Parameters.AddWithValue("@price", Convert.ToInt32(Item_price.Text));
                    cmd.Parameters.AddWithValue("@content", Item_content.Text);
                    cmd.Parameters.AddWithValue("@regdate", now);
                    cmd.Parameters.AddWithValue("@category", Item_category.Text);

                    int result = cmd.ExecuteNonQuery();
                    // MySql DB Register End

                    // Azure Storage Upload Start
                    bool upload = storage.Upload(file_path.Text);
                    if(file_path.Text.Equals(""))
                    {
                        MessageBox.Show("업로드된 제품 사진이 없습니다!","File Upload Error",MessageBoxButtons.OK,MessageBoxIcon.Error);
                        return;
                    }
                    // Azure Storage Upload End

                    // Mysql, Azure 동시 예외처리
                    if(result<0)
                    {
                        MessageBox.Show("제품 등록에 실패했습니다! \n관리자에게 문의하세요.","CODE : MS-ERROR",MessageBoxButtons.OK,MessageBoxIcon.Error);
                    }
                    else if(!upload)
                    {
                        MessageBox.Show("제품 등록에 실패했습니다! \n관리자에게 문의하세요.", "CODE : AS-ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    else
                    {
                        MessageBox.Show("제품 등록에 성공했습니다!","ITEM REGISTER",MessageBoxButtons.OK,MessageBoxIcon.Information);
                        // 모든 입력 값을 초기화
                        Item_category.SelectedIndex = -1;
                        Item_name.Text = string.Empty;
                        Item_price.Text = string.Empty;
                        Item_content.Text = string.Empty;
                        file_path.Text = string.Empty;

                        Item_name.Focus();
                    }

                }
                catch
                (MySqlException ex)
                {
                    MessageBox.Show(ex.Message,"MySql ERROR !",MessageBoxButtons.OK,MessageBoxIcon.Error);
                }
            }
        }

        private void ItemPanel_Load(object sender, EventArgs e)
        {
            List<string> list = GetCategory();

            for (int i = 0; i < list.Count; i++)
            {
                Item_category.Items.Add(list[i]);
            }
        }

        private List<string> GetCategory()
        {
            List<string> category_names = new List<string>();

            try
            {
                string sql = "select cg_name from categorytable";
                MySqlCommand cmd = new MySqlCommand(sql, mysql);

                MySqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    category_names.Add(reader.GetString("cg_name"));
                }
            }
            catch(MySqlException ex)
            {
                MessageBox.Show(ex.Message,"MYSQL ERROR",MessageBoxButtons.OK,MessageBoxIcon.Error);
            }

            return category_names;
        }
    }
}