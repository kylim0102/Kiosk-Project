using Kiosk.pPanel.common;
using System;
using System.Data;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace Kiosk.pPanel
{
    public partial class Chart : Form
    {
        pPanel.list list = new pPanel.list();
        pPanel.ChartTable chart = new pPanel.ChartTable();
        ChartData cData = new ChartData();



        #region 리스트, 차트 폼 보여주기
        public Chart()
        {
            InitializeComponent();

            //list 데이터 받아오기
            list.eDataTableSender += List_eDataTableSender;
            //chart 데이터 받아옥;
            chart.eChartTypeSender += Chart_eChartTypeSender;
        }

        private void List_eDataTableSender(object oSender, DataTable dt)
        {
            cData.ChartMain = dt;
            chart.SetData(cData);
        }
        private void Chart_eChartTypeSender(object sender, SeriesChartType cType)
        {
            cData.ChartType = cType;
            chart.SetData(cData);
        }
        #endregion

        #region Chart List Button Click Event(차트 리스트 버튼 클릭 시 더미데이터 삽입 및 통계 분석)
        private void button1_Click(object sender, EventArgs e)
        {
            panel1.Controls.Clear();
            panel1.Controls.Add(list);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            panel1.Controls.Clear();
            panel1.Controls.Add(chart);
            chart.SetData(cData);
        }
        #endregion


        #region Dummy Event
        private void Chart_Load(object sender, EventArgs e)
        {

        }
        #endregion
    }
}
