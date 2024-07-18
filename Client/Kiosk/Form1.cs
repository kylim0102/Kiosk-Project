using Kiosk.pPanel;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
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
        private void kioskPanel_ButtonClicked(object sender, EventArgs e)
        {
            // 버튼 클릭 시 실행될 코드 작성
            MessageBox.Show("버튼이 클릭되었습니다!");
            kioskPanel.Visible = false;
            cartPanel.Visible = true;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            this.Controls.Add(kioskPanel);
            this.Controls.Add(cartPanel);

            kioskPanel.Visible = false;
            cartPanel.Visible = false;
        }
            
        private void button1_Click(object sender, EventArgs e)
        {
            panel1.Visible = false;
            kioskPanel.Visible = true;
            cartPanel.Visible = false;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            panel1.Visible = false;
            kioskPanel.Visible = true;
            cartPanel.Visible = false;
        }

       
        

    }
}
