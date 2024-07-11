using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using Kiosk.pPanel.common;

namespace Kiosk
{
    public partial class Form1 : Form
    {
        //pPanel.Chart chart = new pPanel.Chart();
        //Order.Order_Manage order = new Order.Order_Manage();
        pPanel.Chart chart;
        public Form1()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            chart = new pPanel.Chart();
            chart.Show();
        }
            

            /*
                chart.Show();
                →  코드 실행 후 차트 패널을 열었다가 닫고 다시 열게 되면
                    'System.ObjectDisposedException: '삭제된 개체에 액세스할 수 없습니다.' 오류 발생함

                상단에서 해주는 초기화가 버튼 클릭 시마다 필요함.

                ex1)
                pPanel.Chart chart = new nPanel.Chart();
                chart.Show();

                ex2)
                using(pPanel.Chart chart = new nPanel.Chart())
                {
                    chart.ShowDialog();
                }

                ※ ShowDialog()와 Show()의 차이점
                
                    1) ShowDialog()의 경우 모달 대화상자로 열림
                        모달 : 모달 폼이 열려있는 동안에는 사용자가 다른 폼을 사용할 수 없음.
                               모달이 닫힐 때까지 제어가 해당 폼에 머물게 됨
                        DialogResult 반환 : 폼이 닫힐 때 DialogResult를 반환하여, 사용자가 폼을 어떻게 닫았는지(Ok, Cancle 등)을 알 수 있음.

                    2) Show()의 경우 비 모달 대화상자로 열림
                        ShowDialog()와 반대 개념
                               
             */
        

        private void Form1_Load(object sender, EventArgs e)
        {
             /* // DB 연결 확인
            MySqlConnection conn = oGlobal.GetConnection();

            try
            {
                string query = "SELECT * FROM test WHERE idx = 1"; // 테이블 쿼리
                MySqlCommand cmd = new MySqlCommand(query, conn);

                using (MySqlDataReader reader = cmd.ExecuteReader())
                {
                    if (reader.Read())
                    {
                       
                        int id = reader.GetInt32("idx"); // idx 컬럼의 값 가져오기
                        string data = reader.GetString("name"); // name 컬럼의 값 가져오기, 
                        MessageBox.Show($"ID: {id}, name: {data}");      
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"오류 발생: {ex.Message}");
            }
            finally
            {
                conn.Close();
            }
            */
        }

        private void button1_Click(object sender, EventArgs e)
        {
            using(Order.Order_Manage order = new Order.Order_Manage())
            {
                order.ShowDialog();
            }
            
        }

        private void button3_Click(object sender, EventArgs e)
        {
            ItemManage.MainPage mainPage = new ItemManage.MainPage();
            mainPage.Show();
        }
    }
}
