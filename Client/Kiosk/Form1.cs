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

namespace Kiosk
{
    public partial class Form1 : Form
    {
        pPanel.KioskPanel kioskPanel = new pPanel.KioskPanel();
        pPanel.CartPanel cartPanel = new pPanel.CartPanel();

        public Form1()
        {

            InitializeComponent();
            kioskPanel.ButtonClicked += kioskPanel_ButtonClicked;

        }

        // ↓ 그럼 KioskPanel_Button이 Kiosk → cart로 이동 시키는 버튼? 예얍
        private void kioskPanel_ButtonClicked(object sender, EventArgs e)
        {
            // 버튼 클릭 시 실행될 코드 작성
            MessageBox.Show("버튼이 클릭되었습니다!");
            kioskPanel.Visible = false; // 현재 상품 목록 창은 Un Visible
            cartPanel.Visible = true; // 장바구니 이동
        }

        /*
        ↑↑↑ 위의 버튼 이벤트 핸들러가 이런 느낌 인가요?

        private void Kiosk_To_Cart_Button(object sender, EventArgs e)
        {
            // 버튼 클릭 시 실행될 코드 작성
            MessageBox.Show("장바구니로 이동합니다.");
            kioskPanel.Visible = false; // 현재 상품 목록 창은 Un Visible
            cartPanel.Visible = true; // 장바구니 이동
        }

        private void Cart_To_Kiosk_Button(object sender, EventArgs e)
        {
            // 버튼 클릭 시 실행될 코드
            MessageBox.Show("제품 선택 창으로 이동합니다.");
            kioskPanel.Visible = ture; 
            cartPanel.Visible = false;
        */


        private void Form1_Load(object sender, EventArgs e)
        {
            // Form Load (폼이 로드 될 때 Kiosk 패널과 cart 패널이 추가되고, Visible = false;)
            this.Controls.Add(kioskPanel);
            this.Controls.Add(cartPanel);

            kioskPanel.Visible = false;
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

       
        

    }
}
