using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using Azure.Storage.Blobs;
using Azure.Storage.Blobs.Models;
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
        // Azure Storage Connection
        public BlobContainerClient BlobContainerClient()
        {
            // Azure Sotrage 연결 문자열
            string connectionString1 = "DefaultEndpointsProtocol=https;";
            string connectionString2 = "AccountName=kioskproject;";
            string connectionString3 = "AccountKey=7WdD4X1zax7SKV5ouf+svEtku2v7buHUWt/BeNNsY0mS4kETH/UyZP4WpaNbi7LpxPRoobEUezWY+AStK0dOGA==;";
            string connectionString4 = "EndpointSuffix=core.windows.net";


            // Azure Storage 이름
            string containerName = "kiosk";
            string connectionString = connectionString1 + connectionString2 + connectionString3 + connectionString4;

            //Azure Storage 연결
            BlobContainerClient containerClient = new BlobContainerClient(connectionString, containerName);

            return containerClient;
        }

        // Azure Storage List Show
        public List<BlobItem> GetBlobs()
        {
            // 컨테이너 클라이언트 생성
            var containerClient = BlobContainerClient();

            int size = containerClient.GetBlobs().Count();
            List<BlobItem> items = containerClient.GetBlobs().ToList();

            return items;
        }

        // Azure Storage File Upload
        // 업로드 성공 시 true 반환, 실패 시 false 반환
        public bool Upload(string filepath)
        {
            string blobName = Path.GetFileName(filepath);

            // 컨테이너 클라이언트 생성
            var containerClient = BlobContainerClient();
            BlobClient blobClient = containerClient.GetBlobClient(blobName);


            try
            {
                // 파일 스트림을 열어 Blob에 업로드
                FileStream fileStream = File.OpenRead(filepath);
                blobClient.Upload(fileStream, true);
                fileStream.Close();
                MessageBox.Show("선택한 파일이 Storage로 업로드되었습니다.", "Success Upload !", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                MessageBox.Show("파일 업로드에 실패했습니다.", "Fail Upload", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        public async Task Download(string blobName, string downloadFilepath)
        {
            /*
                blobName : Storage에서 다운로드하고자 하는 파일 명 
            */

            // Storage 연결
            var containerClient = BlobContainerClient();
            BlobClient blobClient = containerClient.GetBlobClient(blobName);

            bool exists = await blobClient.ExistsAsync();

            if (!exists) // 다운로드 하려는 파일이 Storage에 없는 경우
            {
                MessageBox.Show("Storage에 해당 파일이 존재하지 않습니다.", "Download ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            else
            {
                MessageBox.Show("다운로드를 시작합니다.", "Download", MessageBoxButtons.OK, MessageBoxIcon.Information);
                // Blob의 내용을 다운로드하여 BlobDownloadInfo 객체에 저장
                BlobDownloadInfo download = await blobClient.DownloadAsync();

                // 로컬 Storage에 저장
                using (FileStream fs = File.OpenWrite(downloadFilepath))
                {
                    await download.Content.CopyToAsync(fs);
                    MessageBox.Show("다운로드 성공", "Download Success !", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    fs.Close();
                }
            }
        }

        public string LocalStorageScan()
        {
            var fileContent = string.Empty;
            var filePath = string.Empty;

            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.InitialDirectory = "c:\\";
                openFileDialog.Filter = "txt files (*.txt)|*.txt|All files (*.*)|*.*";
                openFileDialog.FilterIndex = 2;
                openFileDialog.RestoreDirectory = true;

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    //Get the path of specified file
                    filePath = openFileDialog.FileName;
                    

                    //Read the contents of the file into a stream
                    var fileStream = openFileDialog.OpenFile();

                    using (StreamReader reader = new StreamReader(fileStream))
                    {
                        fileContent = reader.ReadToEnd();
                    }
                }
            }

            return filePath;
        }
    }

    // UserControl에서 Main으로 DataTable 값을 전달 하기 위한 Delegate 정의    
    public delegate void delDataTableSender(object oSender, DataTable dt);     
    // UserControl에서 Main으로 ChartType 값을 전달 하기 위한 Delegate 정의  
    public delegate void delChartTypeSender(object oSender, SeriesChartType ct);
    public delegate void delTextSender(object oSender, string text);

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
