using Azure.Storage.Blobs;
using Azure.Storage.Blobs.Models;
using Google.Protobuf.WellKnownTypes;
using Kiosk.pPanel.common;
using MySql.Data.MySqlClient;
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

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            String select = listBox1.SelectedItem.ToString();
            //MessageBox.Show(select.Substring(7,1)); //상품의 idx 값 가져오기
        }

        private void tabPage1_Click(object sender, EventArgs e)
        {

        }

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
                        listBox1.Items.Add("상품번호 : " + id + " 이름 : " + data + " 가격 : " + price);
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
                        listBox2.Items.Add("상품번호 : " + id + " 이름 : " + data + " 가격 : " + price);
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



        private void button1_Click(object sender, EventArgs e)
        {
            #region 상품 사용 on (y)로 바꾸기
            int idx = Convert.ToInt32(listBox1.SelectedItem.ToString().Substring(7, 1));
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
            #endregion
        }

        private void button2_Click(object sender, EventArgs e)
        {
            #region 상품 사용 off (n) 로 바꾸기
            int idx = Convert.ToInt32(listBox2.SelectedItem.ToString().Substring(7, 1));
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
            #endregion
        }

        private async void button3_Click_1(object sender, EventArgs e) // 파일 선택 후 다운로드 버튼 클릭 시 Event
        {
            //경로 + 파일명 *****저장되는곳 경로 설정*********
            string url = Download_Path.Text+"\\";

            //다운로드 버튼
            await storageConnection.Download(Selected_File.Text, url);
        }

        private void button4_Click_1(object sender, EventArgs e) // 다운로드할 파일을 저장 할 경로를 찾는 버튼
        {
            Download_Path.Text = storageConnection.SavingFilePath();
        }


        private void listBox3_SelectedIndexChanged_1(object sender, EventArgs e) // Storage List Box에서 원하는 Name 선택 시 TextBox를 채움
        {                  
            String name = listBox3.SelectedItem.ToString();
            Selected_File.Text = name;
        }
    }
}
