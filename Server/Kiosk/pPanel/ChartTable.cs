using Kiosk.pPanel.common;
using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace Kiosk.pPanel
{
    public partial class ChartTable : UserControl
    {
        //public event delChartTypeSender eChartTypeSender;
        private ChartData _cData = new ChartData();
        string time = null;

        public ChartTable()
        {
            InitializeComponent();
        }

        public void SetData(ChartData cData)
        {
            _cData = cData;
            ChartDataLoad(_cData);
        }
        #region List To Chart(List에 있는 내용을 Chart로 전송하여 구현)
        private void ChartDataLoad(ChartData cData)
        {
            chart1.Series.Clear();
            DataTable dt = cData.ChartMain;
            Series series = new Series();
            series.ChartType = SeriesChartType.Pie;

            int total = 0;
            if (dt != null)
            {
                // Calculate the total count
                foreach (DataRow row in dt.Rows)
                {
                    total += Convert.ToInt32(row["itemCount"]);
                }

                // Add data points and calculate percentages
                foreach (DataRow dataRow in dt.Rows)
                {
                    string itemName = dataRow["itemName"].ToString();
                    int itemCount = Convert.ToInt32(dataRow["itemCount"]);
                    double percent = (double)itemCount / total * 100;

                    DataPoint dp = new DataPoint();
                    dp.SetValueXY(itemName, itemCount);

                    // 퍼센트를 원형 내부에 표시
                    dp.Label = $"{percent:F2}%";

                    // 범례에 아이템 이름 표시
                    dp.LegendText = itemName;

                    series.Points.Add(dp);
                }

                chart1.Series.Add(series);
            }
            else
            {
                MessageBox.Show("list 를 먼저 확인해주세요.");
            }
        }
        #endregion

        #region dummy
        private void ChartTable_Load(object sender, EventArgs e)
        {
            
        }

        private void chart1_Click(object sender, EventArgs e)
        {

        }
        #endregion
    }
}
