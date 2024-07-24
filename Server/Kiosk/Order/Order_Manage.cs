using Kiosk.pPanel.common;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace Kiosk.Order
{
    public partial class Order_Manage : Form
    {
        private Timer timer;
        private MySqlConnection con = oGlobal.GetConnection();
        private CategoryTable table = new CategoryTable();
        private ItemTable itemTable = new ItemTable();
        private OptionTable optionTable = new OptionTable();
        private OrderTable orderTable = new OrderTable();
        private OrderTable_Option OrderTable_Option = new OrderTable_Option();
        private Pay pay = new Pay();


        public Order_Manage()
        {
            InitializeComponent();

            // Timer 초기화 및 설정
            timer = new Timer();
            timer.Interval = 1000;
            timer.Tick += Timer_Tick;
        }



        #region Order Manage On Load(Order Page 로딩 시 현재시각, 카테고리 별 TabControl Tab 세팅, 제품 옵션 세팅)
        private void Order_Manage_Load(object sender, EventArgs e)
        {
            // form 로드 시 현재 날짜와 시간 설정
            UpdateDateTime();

            // Timer 시작
            timer.Start();

            List<string> categorys = table.GetCategory();
            TabPage tab = null;

            for (int a = 0; a < categorys.Count; a++)
            {
                tab = new TabPage(categorys[a]);
                tab.Text = categorys[a];
                tab.Name = categorys[a] + "_TAB";


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

            for (int a = 0; a < buttons.Count; a++)
            {
                Button btn = buttons[a];

                btn.Click += Button_Click;

                now.Controls.Add(btn);
            }



            // db에 저장되어있는거 들고와서 selected_menu 넣기 
            DataTable data = orderTable.GetAllOrderTable();
            selected_menu.DataSource = data;



            //옵션 내용
            LoadOptionsFromDatabase();

        }
        #endregion


        #region Now Time(현재 시각 이벤트)
        private void Timer_Tick(object sender, EventArgs e)
        {
            // Timer의 Tick 이벤트 발생 시 현재 날짜와 시간 업데이트
            UpdateDateTime();
        }
        private void UpdateDateTime()
        {
            date.Text = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
        }
        #endregion


        #region Order Manage Add DataGridView From Selected item(제품 버튼 클릭 시 해당 제품의 정보가 Datagridview로 추가)
        private void Button_Click(object sender, EventArgs e)
        {
            selected_menu.DataSource = null;

            Button button = sender as Button;
            dynamic tagData = button.Tag;

            string menu_name = tagData.item_name;
            int price = tagData.price;


            List<string> items = orderTable.GetOrderNames();

            if (items.Contains(menu_name) == true)
            {
                orderTable.UpdateItemCount(menu_name, price);
            }
            else
            {
                orderTable.InsertOrder(orderTable.GetMaxItemNumber(menu_name).ToString(), menu_name, 1, price, 0);
            }

            DataTable data = orderTable.GetAllOrderTable();
            selected_menu.DataSource = data;


            // 총 결제 금액 계산
            total_payment();

        }
        #endregion


        #region 옵션을 데이터베이스에서 로드 시키기 및 장바구니에 담기
        private void LoadOptionsFromDatabase()
        {
            try
            {
                // SQL 쿼리 실행하여 옵션 데이터 가져오기
                string sql = "SELECT * FROM optiontable WHERE `on/off` = 'Y'";
                MySqlCommand cmd = new MySqlCommand(sql, con);

                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }

                MySqlDataReader reader = cmd.ExecuteReader();

                // TabPage 이름
                string tabPageName = "option1";
                TabPage tabPage = tabControl1.TabPages[tabPageName]; // tabPageName에 맞는 TabPage 찾기
                int number = 1; // 추가
                int buttonIndex = 1;


                while (reader.Read())
                {
                    // TabPage 내에 있는 버튼 찾기
                    Control[] buttons = tabPage.Controls.Find($"op{buttonIndex}", true);

                    if (buttons.Length > 0 && buttons[0] is Button)
                    {
                        Button btn = (Button)buttons[0];
                        btn.Text = reader.GetString("optionname");

                        string optionValue = reader.GetString("option_value");
                        btn.Tag = optionValue;

                        // 버튼 클릭 이벤트 핸들러 추가
                        btn.Click += (sender, e) =>
                        {
                            string selectedCellValue = GetSelectedCellValue();
                            // 이것도 추가  -- 셀이 선택되지 않았으면 옵션 추가 불가능
                            if (selectedCellValue != null)
                            {
                                //번호 들고오기
                                string num = selectedCellValue;
                                if (num.Contains("-"))
                                {
                                    MessageBox.Show("메뉴를 선택해주세요");
                                    return;
                                }


                                string optionName = btn.Text;
                                int optionPrice = Convert.ToInt32(btn.Tag);


                                //이게 db에 추가하는 부분
                                select_menu(num, optionName, optionPrice, ref number);

                                DataTable data = orderTable.GetAllOrderTable();
                                selected_menu.DataSource = data;
                            }
                            else
                            {
                                MessageBox.Show("셀을 선택해주세요.", "알림", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            }
                        };
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

        #region 번호 행의 특정 셀 값 가져오기 
        private string GetSelectedCellValue()
        {
            if (selected_menu.CurrentCell != null)
            {
                int rowIndex = selected_menu.CurrentCell.RowIndex;
                int columnIndex = 0;

                if (rowIndex >= 0 && columnIndex >= 0)
                {
                    DataGridViewRow row = selected_menu.Rows[rowIndex];
                    DataGridViewCell cell = row.Cells[columnIndex];

                    if (cell != null && cell.Value != null)
                    {
                        return cell.Value.ToString();

                    }
                }
            }
            return null;
        }
        #endregion
        #endregion

        // 추가 -- 옵션 버튼 선택 시  번호에 #-1 로 설정 
        #region Order Manage Selected Options
        private void select_menu(string num, string optionName, int optionPrice, ref int number)
        {


            int cnt = OrderTable_Option.CountOption(num);
            Console.WriteLine(cnt);
            if (cnt < 2)
            {
                //바로꼽아넣는거
                OrderTable_Option.InsertOption(num + "-" + cnt, optionName, 1, optionPrice, 0);
            }
            else
            {

                int checkOPtion = OrderTable_Option.CheckOption(num, optionName);

                if (checkOPtion < 1)
                {
                    // n-n+1 로 집어넣기
                    OrderTable_Option.InsertOption(num + "-" + cnt, optionName, 1, optionPrice, 0);
                }
                else
                {
                    // itemcount 올리기
                    //update 문써서
                    orderTable.UpdateItemCount(optionName, optionPrice);
                }
            }


        }
        #endregion


        #region Order manage Total payment(DataGridView를 통한 총 결제 금액 계산)
        private void total_payment()
        {
            DataGridViewRow row = null;

            int count = selected_menu.Rows.Count;
            List<int> payments = new List<int>();


            for (int a = 0; a < count; a++)
            {
                row = selected_menu.Rows[a];

                if (a < row.Cells.Count && row.Cells[a].Value != null)
                {
                    int menu_pay = Convert.ToInt32(row.Cells["payment"].Value);
                    payments.Add(menu_pay);
                }
            }
            payment.Text = payments.Sum() + "";
        }
        #endregion

        // 추가 
        #region  카드 버튼 클릭시 Order items - db.ordertable 에 저장
        private void button2_Click(object sender, EventArgs e)
        {
            // 주문목록에 상품을 선택하지 않았을 시 예외처리
            if (selected_menu.Rows.Count == 0)
            {
                MessageBox.Show("주문할 항목이 없습니다.", "알림", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return; // 데이터가 없으면 함수 종료
            }
            else
            {
                // update 문 
                pay.UpdateOrderNumber();

                MessageBox.Show("주문이 완료되었습니다.");
                DataTable data = orderTable.GetAllOrderTable();
                selected_menu.DataSource = data;
            }
            payment.Text = "0";
        }
        #endregion


        #region Changed Control Tab(선택된 카테고리가 변경되었을 때 이벤트)
        private void Selected_Index_Changed(object sender, EventArgs e)
        {
            // 현재 선택된 Tab을 TabPage에 저장
            TabPage now = menulist.SelectedTab;

            List<Button> items = itemTable.MakeButtonForItems(now.Text);


            if (items.Count > 0)
            {
                for (int a = 0; a < items.Count; a++)
                {
                    Button btn = items[a];

                    btn.Click += Button_Click;

                    now.Controls.Add(btn);
                }
            }
        }
        #endregion



        #region Order_Manage 에서 상품 삭제

        // datagridview 에서 전체 상품 삭제
        private void button1_Click(object sender, EventArgs e)
        {
            if (selected_menu.Rows.Count == 0)
            {
                MessageBox.Show("삭제할 항목이 없습니다.", "알림", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return; // 데이터가 없으면 함수 종료
            }
            else
            {
                //delete * 문
                pay.deleteOrder();

                MessageBox.Show("전체 상품 삭제가 완료되었습니다");

                DataTable data = orderTable.GetAllOrderTable();
                selected_menu.DataSource = data;
            }
        }
        // datagridview 에서 선택 삭제
        private void button3_Click(object sender, EventArgs e)
        {
            // 선택한 itemNumber
            string num = GetSelectedCellValue();

            if (num.Contains("-") == true)
            {
                pay.delete_SelectedOption(num);

                MessageBox.Show("삭제되었습니다.");

                DataTable data = orderTable.GetAllOrderTable();
                selected_menu.DataSource = data;
            }
            else
            {
                DialogResult resulted = MessageBox.Show("옵션까지 지워집니다.", "삭제", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
                if (resulted == DialogResult.OK)
                {
                    pay.delete_SelectedOption(num);
                    MessageBox.Show("삭제되었습니다.");
                    DataTable data = orderTable.GetAllOrderTable();
                    selected_menu.DataSource = data;
                }
                else
                {
                    return;
                }

            }

        }
        #endregion

        #region Dummy Event
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
        }
        private void groupBox1_Enter(object sender, EventArgs e)
        {
        }
        private void Mysql_tab_Click(object sender, EventArgs e)
        {
        }
        private void op1_Click(object sender, EventArgs e)
        {
        }
        #endregion


    }
}

