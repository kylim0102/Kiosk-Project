﻿using Kiosk.pPanel.common;
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
                    dp.Label = $"{itemName} ({percent:F2}%)"; 
                    series.Points.Add(dp);
                }

                chart1.Series.Add(series);
            }
            else
            {
                MessageBox.Show("list 를 먼저 확인해주세요.");
            }
        }
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
