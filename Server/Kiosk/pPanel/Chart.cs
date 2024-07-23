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
            
        }

        private void List_eDataTableSender(object oSender, DataTable dt)
        {
            cData.ChartMain = dt;
            chart.SetData(cData);
        }
       
        #endregion

        #region Chart List Button Click Event(차트 리스트 버튼 클릭 시 데이터 조회 통계 분석)
        // 리스트 부분
        private void button1_Click(object sender, EventArgs e)
        {
            panel1.Controls.Clear();
            panel1.Controls.Add(list);
        }
        //차트 부분
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
