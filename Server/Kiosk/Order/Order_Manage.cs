using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Kiosk.Order
{
    public partial class Order_Manage : Form
    {
        private Timer timer;
        

        public Order_Manage()
        {
            InitializeComponent();

            // Timer 초기화 및 설정
            timer = new Timer();
            timer.Interval = 1000;
            timer.Tick += Timer_Tick;
        }
        
        private void Timer_Tick(object sender, EventArgs e)
        {
            // Timer의 Tick 이벤트 발생 시 현재 날짜와 시간 업데이트
            UpdateDateTime();
        }

        private void UpdateDateTime()
        {
            date.Text = DateTime.Now.ToString("yyyy-mm-dd HH:mm:ss");
        }

        private void tabPage1_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void Order_Manage_Load(object sender, EventArgs e)
        {
            // form 로드 시 현재 날짜와 시간 설정
            UpdateDateTime();

            // Timer 시작
            timer.Start();
        }


        private int menu_price(string menu_name)
        {
            int price = 0;

            if (menu_name.Equals("아메리카노(ICE)"))
            {
                price = 1500;
            }
            else if (menu_name.Equals("카페라떼(ICE)") || menu_name.Equals("카푸치노(ICE)") || menu_name.Equals("카페모카(ICE)"))
            {
                price = 2000;
            }
            else if(menu_name.Equals("마끼아또(ICE)"))
            {
                price = 3000;
            }
            else if(menu_name.Equals("아메리카노(HOT)"))
            {
                price = 1700;
            }
            else if (menu_name.Equals("카페라떼(HOT)") || menu_name.Equals("카푸치노(HOT)") || menu_name.Equals("카페모카(HOT)"))
            {
                price = 2300;
            }
            else if (menu_name.Equals("마끼아또(HOT)"))
            {
                price = 3500;
            }

            return price;
        }

        private void select_menu(string menu_name)
        {
            if(Convert.ToInt32(take_money.Text) < Convert.ToInt32(payment.Text))
            {
                MessageBox.Show("금액이 부족합니다!","Payment Error!",MessageBoxButtons.OK,MessageBoxIcon.Error);
                return;
            }
            else
            {
                DataGridViewRow row = null;

                // DataGridView 목록의 수를 가져옴
                int count = selected_menu.Rows.Count;

                // 메뉴 명에 따라 가격을 초기화
                int price = menu_price(menu_name);


                // DataGridView의 목록 수만큼 for문을 돌려 중복을 확인
                for (int a = 0; a < count; a++)
                {
                    row = selected_menu.Rows[a];

                    if (a < row.Cells.Count && row.Cells[a].Value != null && row.Cells["Menu"].Value.ToString().Equals(menu_name))// Datagridview에 선택한 메뉴가 이미 있다면
                    {
                        int menu_count = Convert.ToInt32(row.Cells["Count"].Value);

                        row.Cells["Count"].Value = menu_count + 1;
                        row.Cells["Price"].Value = price * (menu_count + 1);
                        break;
                    }
                    else if (a < row.Cells.Count && row.Cells[a].Value == null) // DataGridView에 선택한 메뉴가 없다면
                    {
                        selected_menu.Rows.Add(menu_name, 1, price, "");
                    }
                }

                // 총 결제 금액 계산
                total_payment();

                // 거스름돈 계산
                int taked = Convert.ToInt32(take_money.Text); // 받은 금액
                int payed = Convert.ToInt32(payment.Text); // 결제 금액
                change_money.Text = (taked - payed) + "";

            }
            
           
        }

        private void total_payment()
        {
            DataGridViewRow row = null;

            int count = selected_menu.Rows.Count;
            List<int> payments = new List<int>();

   
            for(int a=0; a<count; a++)
            {
                row = selected_menu.Rows[a];

                if (a < row.Cells.Count && row.Cells[a].Value != null)
                {
                    int menu_pay = Convert.ToInt32(row.Cells["Price"].Value);
                    payments.Add(menu_pay);
                }
            }

            if(payments.Count == 0)
            {
                payment.Text = "0";
            }
            else
            {
                int taked = Convert.ToInt32(take_money.Text); // 받은 금액
                int payed = Convert.ToInt32(payment.Text); // 결제 금액

                if(taked>payed)
                {
                    int total = payments.Sum();
                    payment.Text = total + "";
                }
                else
                {
                    MessageBox.Show("ERROR");
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            select_menu(coffee_ice_menu1.Text);
        }

        private void coffee_ice_menu2_Click(object sender, EventArgs e)
        {
            select_menu(coffee_ice_menu2.Text);
        }

        private void coffee_ice_menu3_Click(object sender, EventArgs e)
        {
            select_menu(coffee_ice_menu3.Text);
        }

        private void coffee_ice_menu4_Click(object sender, EventArgs e)
        {
            select_menu(coffee_ice_menu4.Text);
        }

        private void coffee_ice_menu5_Click(object sender, EventArgs e)
        {
            select_menu(coffee_ice_menu5.Text);
        }

        private void coffee_hot_menu1_Click(object sender, EventArgs e)
        {
            select_menu(coffee_hot_menu1.Text);
        }

        private void coffee_hot_menu2_Click(object sender, EventArgs e)
        {
            select_menu(coffee_hot_menu2.Text);
        }

        private void coffee_hot_menu3_Click(object sender, EventArgs e)
        {
            select_menu(coffee_hot_menu3.Text);
        }

        private void coffee_hot_menu4_Click(object sender, EventArgs e)
        {
            select_menu(coffee_hot_menu4.Text);
        }

        private void coffee_hot_menu5_Click(object sender, EventArgs e)
        {
            select_menu(coffee_hot_menu5.Text);
        }
    }
}
