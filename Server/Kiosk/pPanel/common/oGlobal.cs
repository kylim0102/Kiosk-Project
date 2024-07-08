using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms.DataVisualization.Charting;

namespace Kiosk.pPanel.common
{
    internal class oGlobal
    {
    }

    // UserControl에서 Main으로 DataTable 값을 전달 하기 위한 Delegate 정의    
    public delegate void delDataTableSender(object oSender, DataTable dt);     
    // UserControl에서 Main으로 ChartType 값을 전달 하기 위한 Delegate 정의  
    public delegate void delChartTypeSender(object oSender, SeriesChartType ct);

    public class ChartData
    {
        DataTable _ChartMain;
        SeriesChartType _ChartType = SeriesChartType.Area;
        public DataTable ChartMain { get => _ChartMain; set => _ChartMain = value; }
        public SeriesChartType ChartType { get => _ChartType; set => _ChartType = value; }
    }
    public enum enWeek { Mon, Tue, Wen, Thu, Fri, Sat, Sun }
    public enum enWeek_Han { 월, 화, 수, 목, 금, 토, 일 }


}
