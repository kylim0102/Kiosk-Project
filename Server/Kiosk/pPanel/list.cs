using System;
using System.Data;
using System.Windows.Forms;
using Kiosk.pPanel.common;

namespace Kiosk.pPanel
{
    public partial class list : UserControl
    {
        public event delDataTableSender eDataTableSender;
       
        DataTable dtMain = new DataTable();

        public list()
        {
            InitializeComponent();
        }

        #region Form Event
        private void list_Load(object sender, EventArgs e)
        {
            DataSet();
            
            DataTable dt = dataGridView1.DataSource as DataTable;

            if (eDataTableSender != null)
            {
                eDataTableSender(this, dt);
            }
            AddColumnSums(); // 구한 총합 뷰에 추가
        }
        #endregion

        #region Function 이다
        private void DataSet()
        {
            dtMain = new DataTable();

            DataColumn colProduction = new DataColumn("제품", typeof(string));
            DataColumn colMon = new DataColumn("월", typeof(int));
            DataColumn colTue = new DataColumn("화", typeof(int));
            DataColumn colWen = new DataColumn("수", typeof(int));
            DataColumn colThu = new DataColumn("목", typeof(int));
            DataColumn colFri = new DataColumn("금", typeof(int));
            DataColumn colSat = new DataColumn("토", typeof(int));
            DataColumn colSun = new DataColumn("일", typeof(int));
            DataColumn colTotal = new DataColumn("총합", typeof(int));

            dtMain.Columns.Add(colProduction);
            dtMain.Columns.Add(colMon);
            dtMain.Columns.Add(colTue);
            dtMain.Columns.Add(colWen);
            dtMain.Columns.Add(colThu);
            dtMain.Columns.Add(colFri);
            dtMain.Columns.Add(colSat);
            dtMain.Columns.Add(colSun);
            dtMain.Columns.Add(colTotal);

            Random rd = new Random();

            dtMain.Rows.Add(RowAdd(dtMain, "아메리카노", rd));
            dtMain.Rows.Add(RowAdd(dtMain, "카페 라떼", rd));
            dtMain.Rows.Add(RowAdd(dtMain, "카페 모카", rd));
            dtMain.Rows.Add(RowAdd(dtMain, "복숭아 아이스티", rd));
           

            dataGridView1.DataSource = dtMain;

            
        }

        private DataRow RowAdd(DataTable dt, string strProduction, Random rd)
        {
            DataRow row = dt.NewRow();
            int total = 0;
            row["제품"] = strProduction;
            foreach (enWeek_Han oDay in Enum.GetValues(typeof(enWeek_Han)))
            {
                int value = rd.Next(30, 200);
                row[oDay.ToString()] =value;
                total += value;
            }
            row["총합"] = total;
            return row;
        }
        //날짜 별 총합 구하기
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
        }
        #endregion
    }
}
