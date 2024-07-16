using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics.Metrics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Google.Protobuf.WellKnownTypes;
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
                    int number = a + 1;
                    selected_menu.Rows.Add(number, menu_name, 1, price, "");
                }
            }

            // 총 결제 금액 계산
            total_payment();

            // 거스름돈 계산
            //int taked = Convert.ToInt32(take_money.Text); // 받은 금액
            int payed = Convert.ToInt32(payment.Text); // 결제 금액
                                                       //change_money.Text = (taked - payed) + "";
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
                                string num = selectedCellValue;
                                string optionName = btn.Text;
                                string optionPrice = btn.Tag.ToString();
                                int rowIndex = selected_menu.CurrentCell.RowIndex;

                                select_menu(num, optionName, optionPrice, ref number, rowIndex);
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
        private void select_menu(string num, string optionName, string optionPrice, ref int number, int rowIndex) // ref, rowIndex  추가 
        {
            // DataGridView에 추가할 행 생성
            DataGridViewRow row = new DataGridViewRow();
            row.CreateCells(selected_menu);

            // 이미 있는지 확인 후 추가 또는 수량 증가
            bool found = false;
            foreach (DataGridViewRow existingRow in selected_menu.Rows)
            {
                //existingRow.Cells["Menu"].Value != null && existingRow.Cells["Menu"].Value.ToString() == optionName  형이 쓰던 조건문
                if (existingRow.Cells["cartNumber"].Value != null && existingRow.Cells["Menu"].Value.ToString() == optionName && existingRow.Cells["cartNumber"].Value.ToString() == num)
                {
                    int count = Convert.ToInt32(existingRow.Cells["Count"].Value);
                    existingRow.Cells["Count"].Value = count + 1;
                    existingRow.Cells["Price"].Value = (count + 1) * Convert.ToInt32(optionPrice);
                    found = true;
                    break;
                }
            }
            if (!found)
            {
                row.Cells[0].Value = num + "-" + number; // 번호 추가   // 교체
                row.Cells[1].Value = optionName;  // 옵션의 이름
                row.Cells[2].Value = 1;           // 초기 수량은 1로 설정
                row.Cells[3].Value = optionPrice; // 옵션의 가격

                //선택 row 에 집어 넣기  일단 보류

                selected_menu.Rows.Insert(rowIndex + 1, row); // 선택한 다음 행에 집어넣기


                //selected_menu.Rows.Add(row);// 데이터그리드뷰에 새로운 행 추가

            }

            // 총 결제 금액 계산
            total_payment();
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
                    int menu_pay = Convert.ToInt32(row.Cells["Price"].Value);
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
                // datagridview를 datatable 로 변환
                DataTable dt = new DataTable();
                foreach (DataGridViewColumn column in selected_menu.Columns)
                {
                    dt.Columns.Add(column.HeaderText, typeof(object));

                }
                foreach (DataGridViewRow row in selected_menu.Rows)
                {
                    if (!row.IsNewRow)
                    {
                        DataRow dataRow = dt.NewRow();
                        foreach (DataGridViewCell cell in row.Cells)
                        {
                            dataRow[cell.ColumnIndex] = cell.Value;
                        }
                        dt.Rows.Add(dataRow);
                    }
                }
                //////////////////////////////////////
                MySqlConnection conn = oGlobal.GetConnection();
                if (conn.State == ConnectionState.Closed)
                {
                    conn.Open(); //db 연결

                }

                try
                {
                    foreach (DataRow row in dt.Rows)
                    {

                        using (MySqlCommand cmd = new MySqlCommand())
                        {
                            cmd.Connection = conn;

                            cmd.CommandText = "INSERT INTO ordertable (itemNumber, itemName, itemCount, payment, regdate) VALUES (@itemNumber, @itemName, @itemCount, @payment, now())";

                            // DBNull 은 만약에 null 값으로 들어왔을시 db에도 null 값을 넣어준다
                            cmd.Parameters.AddWithValue("@itemNumber", row["번호"] ?? DBNull.Value);
                            cmd.Parameters.AddWithValue("@itemName", row["메뉴"] ?? DBNull.Value);
                            cmd.Parameters.AddWithValue("@itemCount", row["수량"] ?? DBNull.Value);
                            cmd.Parameters.AddWithValue("@payment", row["금액"] ?? DBNull.Value);

                            cmd.ExecuteNonQuery();
                        }
                    }
                    // 주문번호 설정 해야됨
                    Counter.IncrementAndGet();
                    int orderNumber = Counter.GetCount();
                    MessageBox.Show("주문이 완료되었습니다. 주문 번호: " + orderNumber, "알림", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    //  초기화
                    selected_menu.Rows.Clear(); // row 클리어 시켜주기
                    selected_menu.Refresh(); // 새로고침
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error: " + ex.Message);
                }
                finally
                {
                    conn.Close(); // 연결 닫기


                }
            }
        }
        #endregion

        //추가
        #region 주문 번호 설정
        public class Counter
        {
            private static int count = 0;

            // 메소드가 호출될 때마다 count 값을 1씩 증가시키고 반환하는 메소드
            public static int IncrementAndGet()
            {
                count++;
                return count;
            }

            // 현재 count 값을 가져오는 메소드
            public static int GetCount()
            {
                return count;
            }
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
    private void button1_Click(object sender, EventArgs e)
    {
    }
    private void op1_Click(object sender, EventArgs e)
    {
    }
    #endregion


    }
}
