using Kiosk.pPanel.common;
using System;
using System.Data;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace Kiosk.pPanel
{
    public partial class ChartTable : UserControl
    {
        //public event delChartTypeSender eChartTypeSender;
        private ChartData _cData = new ChartData();

        public ChartTable()
        {
            InitializeComponent();
        }

        public void SetData(ChartData cData)
        {
            _cData = cData;
            ChartDataLoad(_cData);
        }

        private void ChartDataLoad(ChartData cData)
        {
            chart1.Series.Clear();
            DataTable dt = cData.ChartMain;
            Series series = new Series();
            series.ChartType = SeriesChartType.Column;
            if (dt != null)
            {
                foreach (DataRow dataRow in dt.Rows)
                {
                    series.Points.AddXY(dataRow["itemName"], dataRow["itemCount"]);
                }
                    chart1.Series.Add(series);
            }
            else
            {
                MessageBox.Show("list 를 먼저 확인해주세요.");
            }
        }
        private void ChartTable_Load(object sender, EventArgs e)
        {
            
        }
    }
}
