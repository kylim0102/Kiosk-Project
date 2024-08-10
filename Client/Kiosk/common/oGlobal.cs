using Azure.Storage.Blobs;
using Azure.Storage.Blobs.Models;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Google.Cloud.Storage.V1;
using Google.Apis.Auth.OAuth2;

namespace Kiosk.common
{
    #region oGlobal
    internal class oGlobal
    {
        public string Welcome_oGlobal()
        {
            return "Welcome To The oGlobal";
        }
    }
    #endregion

    #region Azure Storage
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

        #region Azure Storage All File Download Service(Azure 스토리지에서 모든 파일을 다운로드 함)
        public void AllFileDownload(string dowloadFilepath)
        {
            try
            {
                List<BlobItem> blobItems = GetBlobs();

                var containerClient = BlobContainerClient();
                for (int a = 0; a < blobItems.Count; a++)
                {
                    BlobClient blobClient = containerClient.GetBlobClient(blobItems[a].Name);
                    Console.WriteLine("다운로드를 시작합니다.");
                    BlobDownloadInfo download = blobClient.Download();

                    using(FileStream fs = File.OpenWrite(dowloadFilepath + blobItems[a].Name))
                    {
                        download.Content.CopyTo(fs);
                        Console.WriteLine(a+"번째 파일 다운로드 성공");
                        fs.Close();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Azure Storage 모든 목록 다운로드 중 문제가 발생했습니다.\n" + ex.Message, "Azure Storage Manager", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        #endregion
    }
    #endregion

    #region Google Storage
    internal class GoogleConnection
    {
        private string bucketName = "kiosk-project";
        private string desktopPath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
        
        //private string jsonkey = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "..", "..", "Key", "kiosk-project.json");
        private StorageClient GetGoogleClient()
        {
            string key = Path.Combine(desktopPath,"Key","kiosk-project-key.json");

            // JSON 파일에서 인증 정보를 로드
            GoogleCredential credential;
            using (var stream = new FileStream(key, FileMode.Open, FileAccess.Read))
            {
                credential = GoogleCredential.FromStream(stream);
            }

            // Google Cloud Storage Client 생성
            StorageClient client = StorageClient.Create(credential);

            return client;
        }


        public void GoogleDownload(string filepath, string filename)
        {
            using (var fileStream = File.OpenWrite(filepath + filename))
            {
                Console.WriteLine($"파일을 다운로드 합니다. 파일명: {filename}");
                // 파일 다운로드
                GetGoogleClient().DownloadObject(bucketName, filename, fileStream);
            }
        }

        public List<string> GoogleAllDownload()
        {
            List<string> items = new List<string>();
            StorageClient client = GetGoogleClient();


            foreach (var obj in client.ListObjects(bucketName))
            {
                items.Add(obj.Name);
            }

            return items;
        }

    }

    #endregion
}
