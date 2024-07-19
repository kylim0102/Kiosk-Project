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
        private MySqlConnection mysql = new MySqlConnection();
        private ChartList chartList = new ChartList(); 

        DataTable dtMain = new DataTable();


        public list()
        {
            InitializeComponent();
        }
        // 추가


        #region Chart For List On Load(리스트 버튼 클릭 시 DataGridView에 데이터 추가)
        private void list_Load(object sender, EventArgs e)
        {
            // 
            start_calendar.Click += Start_Calendar_Click;
            end_calendar.Click += End_Calendar_Click;

            string keyword = List_keyword.Text;
            string start_day = start_calendar.Text;
            string end_day = end_calendar.Text;

            // datagridview 에 담기
            DataTable dtMain = chartList.SelectData(mysql, keyword, start_day, end_day);

            dataGridView1.DataSource = dtMain;


            DataTable dt = dataGridView1.DataSource as DataTable;

            if (eDataTableSender != null)
            {
                eDataTableSender(this, dt);
            }
            //AddColumnSums(); // 구한 총합 뷰에 추가
        }
        #endregion

        /*//날짜 별 총합 구하기
        private void AddColumnSums()
        {
            DataRow sumRow = dtMain.NewRow();
            sumRow["제품"] = "총합";

            foreach (DataColumn col in dtMain.Columns)
            {
                if (col.ColumnName != "제품")
                {
                    int sum = 0;
                    foreach (DataRow row in dtMain.Rows)
                    {
                        sum += Convert.ToInt32(row[col]);
                    }
                    sumRow[col.ColumnName] = sum;
                }
            }

            dtMain.Rows.Add(sumRow);
        }*/
        //#endregion

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        #region Search Keyword Button Click Event(키워드 입력 후 검색 버튼 클릭 이벤트)
        private void button1_Click(object sender, EventArgs e)
        { 
            string keyword = string.Empty;
            string start_day = string.Empty;
            string end_day = string.Empty;

            if (List_keyword.Text.Equals("") && start_calendar.Text.Equals("") && end_calendar.Text.Equals(""))
            {
                MessageBox.Show("검색 조건 입력 안함");
            }
            else
            {
                dataGridView1.DataSource = null;

                keyword = List_keyword.Text;
                start_day = start_calendar.Text;
                end_day = end_calendar.Text;

                DataTable dtMain = chartList.SelectData(mysql, keyword, start_day, end_day);

                dataGridView1.DataSource = dtMain;

                List_keyword.Text = string.Empty;
                start_calendar.Text = string.Empty;
                end_calendar.Text = string.Empty;
            }
        }

        private void Start_Calendar_Click(object sender, EventArgs e)
        {
            monthCalendar1.Visible = true;
            monthCalendar2.Visible = false;
        }

        private void End_Calendar_Click(object sender, EventArgs e)
        {
            monthCalendar1.Visible = false;
            monthCalendar2.Visible = true;
        }

        #endregion

        private void start_calendar_TextChanged(object sender, EventArgs e)
        {

        }

        private void monthCalendar1_DateChanged(object sender, DateRangeEventArgs e)
        {
            if(!end_calendar.Text.Equals("") && monthCalendar2.SelectionStart < monthCalendar1.SelectionStart)
            {
                MessageBox.Show("검색 시작일이 더 클 수는 없습니다.", "ITEM MANAGER", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            start_calendar.Text = monthCalendar1.SelectionStart.ToString("yyyy-MM-dd");
            monthCalendar1.Visible = false;

        }

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

        
    }
}
