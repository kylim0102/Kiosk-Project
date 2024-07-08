using Kiosk.pPanel.common;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace Kiosk.pPanel
{
    public partial class Chart : Form
    {
        pPanel.list list = new pPanel.list();
        pPanel.ChartTable chart = new pPanel.ChartTable();

        

        ChartData cData = new ChartData();
        public Chart()
        {
            InitializeComponent();

            list.eDataTableSender += List_eDataTableSender;
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
        private void Chart_Load(object sender, EventArgs e)
        {

        }

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
    }
}
