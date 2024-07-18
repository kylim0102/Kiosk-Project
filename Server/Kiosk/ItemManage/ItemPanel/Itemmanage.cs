using Azure.Storage.Blobs.Models;
using Kiosk.pPanel.common;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace Kiosk.ItemManage.ItemPanel
{
    public partial class Itemmanage : UserControl
    {
        StorageConnection storageConnection = new StorageConnection();
        MySqlConnection conn = oGlobal.GetConnection();

        public Itemmanage()
        {
            InitializeComponent();
        }


        #region Item Manage On Load(Tab Control 세팅)
        private void Itemmanage_Load(object sender, EventArgs e)
        {
            #region on/off 가 n 인 것
            try
            {
                string query = "select * from kiosk.itemtable where `on/off` = 'n'"; // 테이블 쿼리
                MySqlCommand cmd = new MySqlCommand(query, conn);

                using (MySqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {

                        int id = reader.GetInt32("idx");  //idx 컬럼의 값 가져오기
                        string data = reader.GetString("itemName"); // name 컬럼의 값 가져오기, 
                        int price = reader.GetInt32("price");
                        //MessageBox.Show($"ID: {id}, name: {data}"); 확인용
                        listBox1.Items.Add("상품번호 : " + id + ",이름 : " + data + ",가격 : " + price);
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"오류 발생: {ex.Message}");
            }

            #endregion
            #region on/off 가 y 인 것
            try
            {
                string query = "select * from kiosk.itemtable where `on/off` = 'y'"; // 테이블 쿼리
                MySqlCommand cmd = new MySqlCommand(query, conn);

                using (MySqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {

                        int id = reader.GetInt32("idx");  //idx 컬럼의 값 가져오기
                        string data = reader.GetString("itemName"); // name 컬럼의 값 가져오기, 
                        int price = reader.GetInt32("price");
                        //MessageBox.Show($"ID: {id}, name: {data}"); 확인용
                        listBox2.Items.Add("상품번호 : " + id + ",이름 : " + data + ",가격 : " + price);
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"오류 발생: {ex.Message}");
            }
            #endregion


            #region 스토리지 연결
            storageConnection.BlobContainerClient(); // 스토리지 연결

            List<BlobItem> items = new List<BlobItem>();

            items = storageConnection.GetBlobs();

            for (int i = 0; i < items.Count; i++)
            {
                listBox3.Items.Add(items[i].Name);
            }
            #endregion
        }
        #endregion


        // TAB1 AREA
        #region Item Manage Using Item(제품 사용 버튼 'on/off' = y)
        private void button1_Click(object sender, EventArgs e)
        {
            //
            string a = listBox1.SelectedItem.ToString().Split(',')[0].Trim();
            int idx = Convert.ToInt32(a.Split(':')[1].Trim());
            //int idx = Convert.ToInt32(listBox1.SelectedItem.ToString().Substring(7, 1));



            if (MessageBox.Show("추가하시겠습니까?", "YesOrNo", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                try
                {
                    string query = "UPDATE kiosk.itemtable SET `on/off` = 'y' WHERE idx = @idx"; // 테이블 쿼리
                    MySqlCommand cmd = new MySqlCommand(query, conn);

                    // 파라미터 추가
                    cmd.Parameters.AddWithValue("@idx", idx);
                    int rowsAffected = cmd.ExecuteNonQuery();

                    if (rowsAffected > 0)
                    {
                        MessageBox.Show("데이터가 성공적으로 삽입되었습니다.");
                        listBox1.Items.Clear();
                        listBox2.Items.Clear();
                        Itemmanage_Load(sender, e); // 다시 로드
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
            }
        }
        #endregion

        #region Item Manage Not Using Item(제품 사용 안함 버튼 'on/off' = n)
        private void button2_Click(object sender, EventArgs e)
        {
            //
            string a = listBox2.SelectedItem.ToString().Split(',')[0].Trim();
            int idx = Convert.ToInt32(a.Split(':')[1].Trim());
            //int idx = Convert.ToInt32(listBox2.SelectedItem.ToString().Substring(7, 1));


            if (MessageBox.Show("제거하시겠습니까?", "YesOrNo", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                try
                {

                    string query = "UPDATE kiosk.itemtable SET `on/off` = 'n' WHERE idx = @idx"; // 테이블 쿼리
                    MySqlCommand cmd = new MySqlCommand(query, conn);

                    // 파라미터 추가
                    cmd.Parameters.AddWithValue("@idx", idx);
                    int rowsAffected = cmd.ExecuteNonQuery();

                    if (rowsAffected > 0)
                    {
                        MessageBox.Show("데이터가 성공적으로 제거되었습니다.");
                        listBox1.Items.Clear();
                        listBox2.Items.Clear();
                        Itemmanage_Load(sender, e); // 다시 로드
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
            }
        }
        #endregion

        // TAB1 AREA


        // TAB2 AREA
        #region Storage Manage Select Blob(List Box에서 원하는 Name 선택 시 TextBox를 채움)
        private void listBox3_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            String name = listBox3.SelectedItem.ToString();
            if (!string.IsNullOrEmpty(name))
            {
                Selected_File.Text = name;
            }
        }
        #endregion

        #region Storage Manage Download File(다운로드할 파일을 저장 할 경로를 찾는 버튼)
        private void button4_Click(object sender, EventArgs e) // 
        {
            Download_Path.Text = storageConnection.SavingFilePath();
        }
        #endregion

        #region Storage manage Download Button Click Event(다운로드 버튼 클릭 시)
        private void button3_Click(object sender, EventArgs e)
        {
            //경로 + 파일명 *****저장되는곳 경로 설정*********
            string url = Download_Path.Text + "\\";

            //다운로드 버튼
            storageConnection.Download(Selected_File.Text, url);
        }
        #endregion

        #region Storage Manage Modify File(수정 시 새로 업로드 할 파일 찾기)
        private void button5_Click_1(object sender, EventArgs e)
        {
            // 파일 찾기
            string scanner = storageConnection.LocalStorageScan();

            Modify_File.Text = scanner;
        }
        #endregion

        #region Storage Manage Modify Button Click(수정 버튼 클릭 시 이벤트)
        private void button6_Click_1(object sender, EventArgs e)
        {
            string select_file = Selected_File.Text;
            string modify_file = Modify_File.Text;

            if (!string.IsNullOrEmpty(select_file) && !string.IsNullOrEmpty(modify_file))
            {
                storageConnection.ModifyBlob(Selected_File.Text, Modify_File.Text);
                listBox3.Items.Clear();

                List<BlobItem> items = new List<BlobItem>();
                items = storageConnection.GetBlobs();
                for (int i = 0; i < items.Count; i++)
                {
                    listBox3.Items.Add(items[i].Name);
                }
            }
            else
            {
                MessageBox.Show("수정하려는 파일을 다시 한번 확인해주세요\n선택: " + select_file + "\n수정: " + modify_file, "AZURE STORAGE ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        #endregion

        #region Storage Manage Delete Button Click(삭제 버튼 클릭 시 이벤트)
        private void button7_Click(object sender, EventArgs e)
        {
            string file = Selected_File.Text;
            if (string.IsNullOrEmpty(file))
            {
                MessageBox.Show("삭제하려는 파일을 선택해주세요!", "AZURE STORAGE ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            else
            {
                DialogResult dialog = MessageBox.Show("삭제 후에는 복구가 불가능합니다.\n정말 삭제하시겠습니까?", "AZURE SOTRAGE MANAGER", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
                if (dialog == DialogResult.OK)
                {
                    storageConnection.DeleteBlob(Selected_File.Text);
                    listBox3.Items.Clear();

                    List<BlobItem> items = new List<BlobItem>();
                    items = storageConnection.GetBlobs();
                    for (int i = 0; i < items.Count; i++)
                    {
                        listBox3.Items.Add(items[i].Name);
                    }
                }
                else
                {
                    MessageBox.Show("삭제를 취소합니다.", "AZURE STORAGE MANAGER", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }
        #endregion
        // TAB2 AREA





        #region Dummy Event
        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            String select = listBox1.SelectedItem.ToString();
            //MessageBox.Show(select.Substring(7,1)); //상품의 idx 값 가져오기
        }

        private void tabPage1_Click(object sender, EventArgs e)
        {

        }

        #endregion
    }
}
