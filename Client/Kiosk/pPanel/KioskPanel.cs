using Kiosk.common;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Kiosk.pPanel
{
    public partial class KioskPanel : UserControl
    {
        pPanel.CartPanel cartPanel = new pPanel.CartPanel();
        private ItemInsert ItemInsert = new ItemInsert();
        public event EventHandler ButtonClicked;
        private static TemporaryTable TemporaryTable = new TemporaryTable();

        public KioskPanel()
        {
            InitializeComponent();
        }

        #region 키오스크 버튼 동적 생성 및 DB 담기
        public TableLayoutPanel AddFromKioskLayoutPanel(string category)
        {
            TableLayoutPanel table = new TableLayoutPanel();
            table.Dock = DockStyle.Fill;
            


            ItemInsert itemInsert = new ItemInsert();
            List<Button> btnList = itemInsert.CheckItem(category);

            table.Controls.Clear();
            table.ColumnStyles.Clear();
            table.RowStyles.Clear();

            int columnCount = 4; // 한 줄에 보여질 최대 열 수
            int itemCount = btnList.Count;

            // 필요한 행 수 계산
            int rowCount = (int)Math.Ceiling((double)itemCount / columnCount);

            table.ColumnCount = columnCount;
            table.RowCount = rowCount;

            // 열 스타일 설정
            for (int x = 0; x < columnCount; x++)
            {
                table.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100f / columnCount));
            }

            // 행 스타일 설정
            for (int y = 0; y < rowCount; y++)
            {
                table.RowStyles.Add(new RowStyle(SizeType.AutoSize));
            }

            // 버튼 추가 및 클릭 이벤트 핸들러 등록
            for (int index = 0; index < itemCount; index++)
            {
                int x = index % columnCount;
                int y = index / columnCount;

                Panel panel = new Panel
                {
                    BorderStyle = BorderStyle.FixedSingle
                };

                Button button = btnList[index];
                button.Dock = DockStyle.Fill;

                panel.Controls.Add(button);
                table.Controls.Add(panel, x, y);

                // 버튼 클릭 이벤트 핸들러 추가
                button.Click += (sender, e) =>
                {
                    var itemData = (dynamic)button.Tag;
                    
                    string itemName = itemData.itemName; // 상품 이름
                    int itemPrice = itemData.price; // 상품 가격
                    string itemContent = itemData.content; // 상품 상세설명
                    int itemCnt = 1;
                    int optionCnt = 1;

                    item itemForm = new item(itemName, itemPrice, itemContent, itemCnt, optionCnt);
                    itemForm.Show();

                };
                
            }

            return table;
        }
        #endregion

        #region KioskPanel_OnLoad(Kiosk 패널이 Load될 때 이벤트)
        private void KioskPanel_Load(object sender, EventArgs e)
        {
            List<string> categorys = ItemInsert.GetCategory();
            TabPage page = null;

            for (int a = 0; a < categorys.Count; a++)
            {
                page = new TabPage();
                page.Name = categorys[a];
                page.Text = categorys[a];

                tabControl1.TabPages.Add(page);
            }

            TabControl now = tabControl1;
            now.TabPages[0].Controls.Add(AddFromKioskLayoutPanel(now.SelectedTab.Text));

            TemporaryTable.CreateTemporary();
        }
        #endregion

        #region ChangedTabPage(TabControl에서 선택된 Tab이 바뀔 때 이벤트)
        private void Selected_Change(object sender, EventArgs e)
        {
            TabPage page = tabControl1.SelectedTab;
            page.Controls.Add(AddFromKioskLayoutPanel(page.Text));
        }
        #endregion




        #region Dummy Event
        private void button1_Click(object sender, EventArgs e)
        {

        }
        private void button2_Click(object sender, EventArgs e)
        {

        }
        public void button4_Click(object sender, EventArgs e)
        {
            ButtonClicked?.Invoke(this, EventArgs.Empty);
        }
        private void button3_Click(object sender, EventArgs e)
        {

        }
        #endregion
    }
}
