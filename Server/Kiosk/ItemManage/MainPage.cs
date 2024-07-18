using System;
using System.Windows.Forms;



namespace Kiosk.ItemManage
{
    public partial class MainPage : Form
    {
        ItemPanel.ItemPanel item = new ItemPanel.ItemPanel();
        ItemPanel.Category_Manage category = new ItemPanel.Category_Manage();
        ItemPanel.OptionPanel option = new ItemPanel.OptionPanel();
        ItemPanel.Itemmanage itemmanage = new ItemPanel.Itemmanage();
        public MainPage()
        {
            InitializeComponent();
        }

        #region Main Page On Load(메인 페이지 로드 시 이벤트)
        private void MainPage_Load(object sender, EventArgs e)
        {

        }
        #endregion


        // MAIN PANEL AREA
        #region Item Register And Modify And Delete(제품 총괄 패널)
        private void button1_Click(object sender, EventArgs e)
        {
            panel1.Controls.Clear();
            panel1.Controls.Add(item);
        }
        #endregion

        #region Category Register And Modify And Delete(카테고리 총괄 패널)
        private void button2_Click(object sender, EventArgs e)
        {
            panel1.Controls.Clear();
            panel1.Controls.Add(category);

        }
        #endregion

        #region Option Register And Modify And Delete(제품에 대한 옵션 총괄 패널)
        private void button3_Click(object sender, EventArgs e)
        {
            panel1.Controls.Clear();
            panel1.Controls.Add(option);

        }
        #endregion

        #region Storage Upload And Download And Modify And Delete(스토리지 총괄 패널)
        private void button6_Click(object sender, EventArgs e)
        {
            // panel 하나 만들어서 생성
            panel1.Controls.Clear();
            panel1.Controls.Add(itemmanage);
        }
        #endregion
        // MAIN PANEL AREA




        #region Dummy Event
        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
        #endregion
    }
}
