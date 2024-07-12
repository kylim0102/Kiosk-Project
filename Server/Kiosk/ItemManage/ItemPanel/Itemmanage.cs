using Google.Protobuf.WellKnownTypes;
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
    public partial class Itemmanage : UserControl
    {
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
                        listBox1.Items.Add("상품번호 : "+id +" 이름 : " + data + " 가격 : " + price);
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
        }

        private void button1_Click(object sender, EventArgs e)
        {
            #region 상품 사용 on (y)로 바꾸기
            int idx = Convert.ToInt32(listBox1.SelectedItem.ToString().Substring(7,1));
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
    }
    
}
