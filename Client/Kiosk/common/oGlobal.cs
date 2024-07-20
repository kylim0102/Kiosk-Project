using Azure.Storage.Blobs;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kiosk.common
{
    internal class oGlobal
    {

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
    }
}
