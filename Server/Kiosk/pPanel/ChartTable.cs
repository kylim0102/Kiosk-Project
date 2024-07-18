using Kiosk.pPanel.common;
using System;
using System.Data;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace Kiosk.pPanel
{
    public partial class ChartTable : UserControl
    {
        public event delChartTypeSender eChartTypeSender;
        private ChartData _cData = new ChartData();

        public ChartTable()
        {
            InitializeComponent();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

            SeriesChartType cType = (SeriesChartType)Enum.Parse(typeof(SeriesChartType), chartType.SelectedItem.ToString());

            _cData.ChartType = cType;
            ChartDataLoad(_cData);
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
            if (dt != null && dt.Rows.Count > 0)
            {
                foreach (DataRow oRow in dt.Rows)
                {
                    Series series = chart1.Series.Add(oRow["제품"].ToString());
                    series.ChartType = cData.ChartType;

                    series.Points.AddXY(enWeek.Mon.ToString(), oRow[enWeek_Han.월.ToString()]);
                    series.Points.AddXY(enWeek.Tue.ToString(), oRow[enWeek_Han.화.ToString()]);
                    series.Points.AddXY(enWeek.Wen.ToString(), oRow[enWeek_Han.수.ToString()]);
                    series.Points.AddXY(enWeek.Thu.ToString(), oRow[enWeek_Han.목.ToString()]);
                    series.Points.AddXY(enWeek.Fri.ToString(), oRow[enWeek_Han.금.ToString()]);
                    series.Points.AddXY(enWeek.Sat.ToString(), oRow[enWeek_Han.토.ToString()]);
                    series.Points.AddXY(enWeek.Sun.ToString(), oRow[enWeek_Han.일.ToString()]);
                }
            }
        }

        private void ChartTable_Load(object sender, EventArgs e)
        {
            foreach (SeriesChartType oType in Enum.GetValues(typeof(SeriesChartType)))
            {
                chartType.Items.Add(oType.ToString());
            }
            chartType.SelectedIndex = 0;
        }
    }
}

