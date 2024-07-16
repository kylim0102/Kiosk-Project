using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Kiosk.pPanel.common;
using MySql.Data.MySqlClient;
using MySqlX.XDevAPI;

namespace Kiosk.Order
{
    public partial class Order_Manage : Form
    {
        private Timer timer;
        private MySqlConnection con = oGlobal.GetConnection();
        private CategoryTable table = new CategoryTable();
        private ItemTable itemTable = new ItemTable();
        private OptionTable optionTable = new OptionTable();
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

        private void Button_Click(object sender, EventArgs e)
        {
            Button button = sender as Button;
            dynamic tagData = button.Tag;

            string menu_name = tagData.item_name;
            int price = tagData.price;

            int count = selected_menu.Rows.Count;


            DataGridViewRow row = null;
            // 메뉴 명에 따라 가격을 초기화
            

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
            //int taked = Convert.ToInt32(take_money.Text); // 받은 금액
            int payed = Convert.ToInt32(payment.Text); // 결제 금액
                                                       //change_money.Text = (taked - payed) + "";
        }

        private void Order_Manage_Load(object sender, EventArgs e)
        {
            // form 로드 시 현재 날짜와 시간 설정
            UpdateDateTime();

            // Timer 시작
            timer.Start();

            List<string> categorys = table.GetCategory();
            TabPage tab = null;

            for(int a=0; a<categorys.Count; a++)
            {
                tab = new TabPage(categorys[a]);
                tab.Text = categorys[a];
                tab.Name = categorys[a]+"_TAB";
                

                /*
                  menulist => UI에서 TabControl Name
                  for문이 돌면서 category를 꺼내고 꺼낸 카테고리를 TabPage를 통해 TabControl에 Tab 추가
                  
                */
                menulist.TabPages.Add(tab);
            }

            /*
                테스트 용으로 MySql 탭에 모든 Item을 넣어둠.
                후에 코드 정리할 때 삭제하면 되는 부분
            */

            TabPage now = menulist.TabPages[0];
            List<Button> buttons = itemTable.GetAllItems();

            for(int a=0; a<buttons.Count; a++)
            {
                Button btn = buttons[a];

                btn.Click += Button_Click;

                now.Controls.Add(btn);
            }

            //옵션 내용
            LoadOptionsFromDatabase();

        }
        private void LoadOptionsFromDatabase()
        {
            try
            {
                // SQL 쿼리 실행하여 옵션 데이터 가져오기
                string sql = "SELECT optionname FROM optiontable WHERE on/off = 'Y'";
                MySqlCommand cmd = new MySqlCommand(sql, con);

                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }

                MySqlDataReader reader = cmd.ExecuteReader();

                // TabPage 이름
                string tabPageName = "option1";
                TabPage tabPage = tabControl1.TabPages[tabPageName]; // tabPageName에 맞는 TabPage 찾기

                int buttonIndex = 1;

                while (reader.Read())
                {
                    // TabPage 내에 있는 버튼 찾기
                    Control[] buttons = tabPage.Controls.Find($"op{buttonIndex}", true);

                    if (buttons.Length > 0 && buttons[0] is Button)
                    {
                        Button btn = (Button)buttons[0];
                        btn.Text = reader.GetString("optionname");
                        buttonIndex++;
                    }
                }

                reader.Close();
            }
            catch (MySqlException ex)
            {
                MessageBox.Show(ex.Message, "MYSQL ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                con.Close();
            }
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
            //int taked = Convert.ToInt32(take_money.Text); // 받은 금액
            int payed = Convert.ToInt32(payment.Text); // 결제 금액
            //change_money.Text = (taked - payed) + "";
           
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
            payment.Text = payments.Sum()+"";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            List<Button> test = itemTable.MakeButtonForItems("10");
            TabControl tab = menulist;

            TabPage tabPage = menulist.TabPages[1];
            TabPage tabPage1 = menulist.SelectedTab;
            MessageBox.Show(tabPage1.Name);
        }


        /*
            TabControl에서 Tab의 인덱스가 바꼈을 때
            즉, 현재 탭에서 다른 탭을 선택했을 때 이벤트
        */
        private void Selected_Index_Changed(object sender, EventArgs e)
        {
            // 현재 선택된 Tab을 TabPage에 저장
            TabPage now = menulist.SelectedTab;

            List<Button> items = itemTable.MakeButtonForItems(now.Text);


            if (items.Count > 0)
            {
                for(int a=0; a<items.Count; a++)
                {
                    Button btn = items[a];

                    btn.Click += Button_Click;

                    now.Controls.Add(btn);
                }
            }
        }
        private void Mysql_tab_Click(object sender, EventArgs e)
        {

        }
    }
}
