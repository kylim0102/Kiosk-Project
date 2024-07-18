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
        #region Form Event
        private void list_Load(object sender, EventArgs e)
        {
            // datagridview 에 담기
            DataSet();

            DataTable dt = dataGridView1.DataSource as DataTable;

            if (eDataTableSender != null)
            {
                eDataTableSender(this, dt);
            }
            //AddColumnSums(); // 구한 총합 뷰에 추가
        }
        #endregion
        // 추가
        #region Function 이다
        private void DataSet()
        {
            DataTable dtMain = new DataTable();
            dtMain = chartList.SelectData(mysql);

            dataGridView1.DataSource = dtMain;

        }
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
        #endregion
    }
}
