using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms.DataVisualization.Charting;
using Azure.Storage.Blobs;
using MySql.Data.MySqlClient;

namespace Kiosk.pPanel.common
{
    internal class oGlobal
    {
       #region 전역 데이터베이스 연결
        public static MySqlConnection DBconnection;

        public static void DB_Connection()
        {
            if (DBconnection == null)
            {
                MySqlConnectionStringBuilder connStringBuilder = new MySqlConnectionStringBuilder
                {
                    Server = "kiosk.mysql.database.azure.com",
                    Port = 3306,
                    Database = "kiosk",
                    UserID = "youngjin",
                    Password = "admin123456789;"
                };

                DBconnection = new MySqlConnection(connStringBuilder.ConnectionString);
                DBconnection.Open();
            }
            #endregion
        }
        #region oGlobal.GetConnection(); 을 쓰면 db 연결
        public static MySqlConnection GetConnection()
        {
            if (DBconnection == null)
            {
                DB_Connection();
            }

            return DBconnection;
        }
        #endregion
    }


    internal class StorageConnection
    {
        // Azure Storage 연결 문자열 초기화
        private string connectionString = null;
        // Azure Storage Name
        private string contanerName = null;

        public static BlobClient GetBlobClient()
        {
            return null;
        }
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
