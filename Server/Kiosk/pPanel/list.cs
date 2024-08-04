using Kiosk.pPanel.common;
using MySql.Data.MySqlClient;
using MySqlX.XDevAPI;
using System;
using System.Data;
using System.Windows.Forms;

namespace Kiosk.pPanel
{
    public partial class list : UserControl
    {
        public event delDataTableSender eDataTableSender;
        //public event delCalendarSender eCalendarSender;
        private MySqlConnection mysql = new MySqlConnection();
        private ChartList chartList = new ChartList(); 

        DataTable dtMain = new DataTable();


        public list()
        {
            InitializeComponent();
        }
      


        #region Chart For List On Load(리스트 버튼 클릭 시 DataGridView에 데이터 추가)
        private void list_Load(object sender, EventArgs e)
        {
            
            start_calendar.Click += Start_Calendar_Click;
            end_calendar.Click += End_Calendar_Click;

            string keyword = List_keyword.Text;
            string start_day = start_calendar.Text;
            string end_day = end_calendar.Text;

            // datagridview 에 담기
            DataTable dtMain = chartList.SelectData(mysql, keyword, start_day, end_day);

            dataGridView1.DataSource = dtMain;
            List_max.Text = chartList.GetAllOrderTableMaxOrderNumber().ToString() + " 건";

            DataTable dt = dataGridView1.DataSource as DataTable;

            if (eDataTableSender != null)
            {
                eDataTableSender(this, dt);
            }
            AddColumnSums(); // 구한 총합 뷰에 추가
        }
        #endregion

        #region Search Keyword Button Click Event(키워드 입력 후 검색 버튼 클릭 이벤트)
        private void button1_Click(object sender, EventArgs e)
        { 
            string keyword = string.Empty;
            string start_day = string.Empty;
            string end_day = string.Empty;

            if (List_keyword.Text.Equals("") && start_calendar.Text.Equals("") && end_calendar.Text.Equals(""))
            {
                MessageBox.Show("입력된 검색 조건이 없습니다.\n다시 확인해주세요.","ITEM MANAGER",MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            else
            {
                dataGridView1.DataSource = null;

                keyword = List_keyword.Text;
                start_day = start_calendar.Text;
                end_day = end_calendar.Text;

                DataTable dtMain = chartList.SelectData(mysql, keyword, start_day, end_day);

                dataGridView1.DataSource = dtMain;

                eDataTableSender(sender, dtMain);

                List_keyword.Text = string.Empty;
                start_calendar.Text = string.Empty;
                end_calendar.Text = string.Empty;
            }
            AddColumnSums();

        }
        #endregion
        

        #region Start Calendar Event(검색 시작일 관련 이벤트)
        #region Start Calendar TextBox Setting(선택한 검색 시작일을 TextBox에 세팅하는 이벤트)
        private void monthCalendar1_DateChanged(object sender, DateRangeEventArgs e)
        {
            if(!end_calendar.Text.Equals("") && monthCalendar2.SelectionStart < monthCalendar1.SelectionStart)
            {
                MessageBox.Show("검색 시작일이 더 클 수는 없습니다.", "ITEM MANAGER", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            start_calendar.Text = monthCalendar1.SelectionStart.ToString("yyyy-MM-dd");
            monthCalendar1.Visible = false;
            //eCalendarSender += Selection_day;

        }
        /*private void Selection_day()
        {
            DateTime dateTime = monthCalendar1.SelectionStart;
          
        }*/
        #endregion

        #region Turn Off End Calendar(검색 시작일 클릭 시 검색 종료일의 캘린더가 꺼짐)
        private void Start_Calendar_Click(object sender, EventArgs e)
        {
            monthCalendar1.Visible = true;
            monthCalendar2.Visible = false;
        }
        #endregion
        #endregion

        #region End Calendar Event(검색 종료일 관련 이벤트)
        #region End Calendar TextBox Setting(선택한 검색 종료일을 TextBox에 세팅하는 이벤트)
        private void monthCalendar2_DateChanged(object sender, DateRangeEventArgs e)
        {
            if(!start_calendar.Text.Equals("") && monthCalendar2.SelectionStart < monthCalendar1.SelectionStart)
            {
                MessageBox.Show("검색 시작일이 더 클 수는 없습니다.", "ITEM MANAGER", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            end_calendar.Text = monthCalendar2.SelectionEnd.ToString("yyyy-MM-dd");
            monthCalendar2.Visible = false;
        }
        #endregion

        #region Turn Off Start Calendar(검색 종료일 클릭 시 검색 시작일의 캘린더가 꺼짐)
        private void End_Calendar_Click(object sender, EventArgs e)
        {
            monthCalendar1.Visible = false;
            monthCalendar2.Visible = true;
        }
        #endregion
        #endregion


        #region Dummy Event
        private void label7_Click(object sender, EventArgs e)
        {

        }
        private void label6_Click(object sender, EventArgs e)
        {

        }
        private void start_calendar_TextChanged(object sender, EventArgs e)
        {

        }

        private void Refresh_list_Click(object sender, EventArgs e)
        {
            string keyword = List_keyword.Text;
            string start_day = start_calendar.Text;
            string end_day = end_calendar.Text;

            DataTable dtMain = chartList.SelectData(mysql, keyword, start_day, end_day);

            dataGridView1.DataSource = dtMain;
            eDataTableSender(sender, dtMain);
            AddColumnSums();
        }
        #endregion

        #region 총 매출 , 주문 한 상품의 수
        // 총 매출
        private void AddColumnSums()
        {
            int total = 0;
            int count = 0;
            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                if (row.Cells[2].Value != null && row.Cells[1].Value != null)
                {
                    total += Convert.ToInt32(row.Cells[2].Value);
                    count += Convert.ToInt32(row.Cells[1].Value);
                }
            }
            List_Total.Text = total.ToString("C") + " 원";
            List_count.Text = count.ToString() + " 잔";
        }

        #endregion


    }
}
