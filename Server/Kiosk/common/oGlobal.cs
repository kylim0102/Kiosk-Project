using Azure.Storage.Blobs;
using Azure.Storage.Blobs.Models;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace Kiosk.pPanel.common
{
    internal class oGlobal
    {
        public static MySqlConnection DBconnection;

        #region 전역 데이터베이스 연결
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
        #region Azure Storage Connection And Get Controller(Azure 스토리지에 접속 후 스토리지 컨트롤러를 반환)
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
        #endregion



        #region Get Azure Storage All Blobs(Azure 스토리지에 있는 모든 목록을 반환)
        public List<BlobItem> GetBlobs()
        {
            // 컨테이너 클라이언트 생성
            var containerClient = BlobContainerClient();

            int size = containerClient.GetBlobs().Count();
            List<BlobItem> items = containerClient.GetBlobs().ToList();

            return items;
        }
        #endregion

        #region Get Local Storage Folder Path Scanner(Local 스토리지에서 선택한 폴더의 경로를 반환)
        public string SavingFilePath() // 폴더 경로 탐색기
        {
            string FolderPath = string.Empty;
            using (FolderBrowserDialog dialog = new FolderBrowserDialog())
            {
                dialog.Description = "Select a folder";
                dialog.RootFolder = Environment.SpecialFolder.MyComputer;

                DialogResult result = dialog.ShowDialog();

                if (result == DialogResult.OK && !string.IsNullOrWhiteSpace(dialog.SelectedPath))
                {
                    FolderPath = dialog.SelectedPath;
                }

            }
            return FolderPath;
        }
        #endregion

        #region Azure Storage File Download Service(Azure 스토리지에서 선택한 파일 다운로드)
        public void Download(string blobName, string downloadFilepath)
        {
            //blobName : Storage에서 다운로드하고자 하는 파일 명 
            // Storage 연결
            var containerClient = BlobContainerClient();
            BlobClient blobClient = containerClient.GetBlobClient(blobName);

            bool exists = blobClient.Exists();

            if (!exists) // 다운로드 하려는 파일이 Storage에 없는 경우
            {
                MessageBox.Show("Storage에 해당 파일이 존재하지 않습니다.", "Download ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            else
            {
                MessageBox.Show("다운로드를 시작합니다.", "Download", MessageBoxButtons.OK, MessageBoxIcon.Information);
                // Blob의 내용을 다운로드하여 BlobDownloadInfo 객체에 저장
                BlobDownloadInfo download = blobClient.Download();


                // 로컬 Storage에 저장
                using (FileStream fs = File.OpenWrite(downloadFilepath + blobName))
                {
                    download.Content.CopyTo(fs);
                    MessageBox.Show("다운로드 성공", "Download Success !", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    fs.Close();
                }
            }
        }
        #endregion



        #region Get Local Storage File Path Scanner(Local 스토리지에서 선택한 파일의 경로와 파일명을 반환)
        public string LocalStorageScan() // 파일 경로 탐색기
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
        #endregion

        #region Azure Storage File Upload Service(Local 스토리지에서 선택한 파일을 Azure 스토리지로 업로드)
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
        #endregion



        #region Azure Storage Delete Blob(Azure 스토리지에서 선택한 파일 삭제)
        public void DeleteBlob(string blobName)
        {
            bool result = false;

            var ContainerClient = BlobContainerClient();

            BlobClient client = ContainerClient.GetBlobClient(blobName);

            result = client.DeleteIfExists();

            if (result)
            {
                MessageBox.Show("삭제되었습니다.", "AZURE STORAGE MANAGER", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("삭제 중 문제가 발생했습니다..", "AZURE STORAGE MANAGER", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        #endregion

        #region Azure Storage Modify Blob(Azure 스토리지에서 선택한 파일을 다른 파일로 수정, 선택한 파일 삭제 후 새로 업로드)
        public void ModifyBlob(string delete_blob, string upload_blob)
        {
            bool delete_result = false;
            bool upload_result = false;

            try
            {
                // 선택한 파일을 삭제
                var delete_client = BlobContainerClient();
                BlobClient client = delete_client.GetBlobClient(delete_blob);
                delete_result = client.DeleteIfExists();
            }
            catch (Exception delete)
            {
                MessageBox.Show("파일 삭제에 실패했습니다.\n" + delete.Message, "AZURE STORAGE ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            string blobName = null;
            try
            {
                // 검색한 파일 업로드
                blobName = Path.GetFileName(upload_blob);

                // 컨테이너 클라이언트 생성
                var upload_client = BlobContainerClient();
                BlobClient blobClient = upload_client.GetBlobClient(blobName);
                // 파일 스트림을 열어 Blob에 업로드
                FileStream fileStream = File.OpenRead(upload_blob);
                blobClient.Upload(fileStream, true);
                fileStream.Close();

                upload_result = true;

            }
            catch (Exception upload)
            {
                MessageBox.Show("파일 업로드에 실패했습니다.\n" + upload.Message, "AZURE STORAGE ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                upload_result = false;
            }

            if (delete_result && upload_result)
            {
                MessageBox.Show("입력한 파일을 수정했습니다.\n수정 전: " + delete_blob + "\n수정 후: " + blobName);
            }
        }
        #endregion
    }

    // UserControl에서 Main으로 DataTable 값을 전달 하기 위한 Delegate 정의    
    public delegate void delDataTableSender(object oSender, DataTable dt);
    // UserControl에서 Main으로 ChartType 값을 전달 하기 위한 Delegate 정의  
    public delegate void delChartTypeSender(object oSender, SeriesChartType ct);
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
