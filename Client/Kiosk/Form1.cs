using Kiosk.pPanel;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Configuration;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using Kiosk.common;
using System.Net.Sockets;
using System.Net;

namespace Kiosk
{
    public partial class Form1 : Form
    {
        pPanel.KioskPanel kioskPanel = new pPanel.KioskPanel();
        pPanel.CartPanel cartPanel;
        private StorageConnection storage = new StorageConnection();
        GoogleConnection google = new GoogleConnection();

        public Form1()
        {
            InitializeComponent();
            cartPanel = new pPanel.CartPanel(kioskPanel);
            kioskPanel.ButtonClicked += kioskPanel_ButtonClicked;
            cartPanel.ButtonClicked += Cart_To_TemporaryView;
        }

        #region KioskPanel To CartPanel Button Event(제품 목록 → 장바구니)
        private void kioskPanel_ButtonClicked(object sender, EventArgs e)
        {
            // 버튼 클릭 시 실행될 코드 작성
            MessageBox.Show("버튼이 클릭되었습니다!");

            DataTable data = TemporaryTable.GetTemporaryDataTable();    //추가
            // cartPanel에 데이터 로드
            cartPanel.LoadData(data);                                   //추가

            kioskPanel.Visible = false; // 현재 상품 목록 창은 Un Visible
            cartPanel.Visible = true; // 장바구니 이동
        }
        #endregion

        #region Form_Load Event(폼이 로드될 때 키오스크, 장바구니 패널 Visible - False, 제품 사진 다운로드)
        private void Form1_Load(object sender, EventArgs e)
        {
            // Form Load (폼이 로드 될 때 Kiosk 패널과 cart 패널이 추가되고, Visible = false;)
            this.Controls.Add(kioskPanel);
            this.Controls.Add(cartPanel);

            kioskPanel.Visible = false;
            cartPanel.Visible = false;

            // 폼이 로드 될 때 바탕화면에 image 폴더 생성

            // 바탕화면 경로 가져오기
            string desktopPath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            
            // image 폴더 경로
            string imagePath = Path.Combine(desktopPath,"Kiosk_Image");

            if(!Directory.Exists(imagePath))
            {
                Console.WriteLine("바탕화면에 이미지 폴더가 생성되었습니다.");
                Directory.CreateDirectory(imagePath);
                Console.WriteLine("스토리지에서 이미지 파일을 가져옵니다.");
                //storage.AllFileDownload(imagePath + "\\");

                List<string> items = google.GoogleAllDownload();
                foreach(string download in items)
                {
                    google.GoogleDownload(imagePath+"\\", download);
                }
            }
            else
            {
                Console.WriteLine("폴더가 이미 존재합니다.");
                List<string> items = google.GoogleAllDownload();
                foreach (string download in items)
                {
                    google.GoogleDownload(imagePath + "\\", download);
                }
            }

            
        }
        #endregion

        #region CartPanel To KioskPanel Button Event(장바구니 → 제품 목록)
        private void Cart_To_TemporaryView(object sender, EventArgs e)
        {
            TemporaryView temporaryView = new TemporaryView(this);
            temporaryView.Show();
            cartPanel.Visible = false;
        }
        #endregion

        #region ShowMainPanel 메서드 (TemporaryView에서 호출할 메서드)
        public void ShowMainPanel()
        {
            kioskPanel.Visible = false;
            cartPanel.Visible = false;
            panel1.Visible = true; // 메인 패널을 보여줍니다.
        }
        #endregion

        #region Dine In Button Event(매장 버튼 클릭 이벤트)
        private void button1_Click(object sender, EventArgs e)
        {
            // 상품 선택 창
            panel1.Visible = false;
            kioskPanel.Visible = true;
            cartPanel.Visible = false;
        }
        #endregion

        #region Take Out Button Event(포장 버튼 클릭 이벤트)
        private void button2_Click(object sender, EventArgs e)
        {
            panel1.Visible = false;
            kioskPanel.Visible = true;
            cartPanel.Visible = false;
        }
        #endregion

        #region Dummy Event
        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
        #endregion

    }
}
