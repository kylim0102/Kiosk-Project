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

namespace Kiosk
{
    public partial class Form1 : Form
    {
        pPanel.KioskPanel kioskPanel = new pPanel.KioskPanel();
        pPanel.CartPanel cartPanel = new pPanel.CartPanel();
        private StorageConnection storage = new StorageConnection();

        public Form1()
        {

            InitializeComponent();
            kioskPanel.ButtonClicked += kioskPanel_ButtonClicked;
            cartPanel.ButtonClicked += Cart_To_Kiosk_Button;

        }

        // ↓ 그럼 KioskPanel_Button이 Kiosk → cart로 이동 시키는 버튼? 예얍
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
                Directory.CreateDirectory(imagePath);
                Console.WriteLine("바탕화면에 이미지 폴더가 생성되었습니다.");
            }
            else
            {
                Console.WriteLine("폴더가 이미 존재합니다.");
            }

            storage.AllFileDownload(imagePath+"\\");
        }

        private void Cart_To_Kiosk_Button(object sender, EventArgs e)
        {
            MessageBox.Show("제품창으로 넘어갑니다.");
            kioskPanel.Visible = true;
            cartPanel.Visible = false;
        }
            
        private void button1_Click(object sender, EventArgs e)
        {
            // Kiosk 패널 Visible, cart 패널 Unvisible, panel1(첫 버튼 2개 화면?)
            // 상품 선택 창
            panel1.Visible = false;
            kioskPanel.Visible = true;
            cartPanel.Visible = false;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            // button1_click 이벤트와 차이가 없어보임
            panel1.Visible = false;
            kioskPanel.Visible = true;
            cartPanel.Visible = false;


        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
