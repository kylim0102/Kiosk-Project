using Kiosk.common;
using Mysqlx.Prepare;
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

        #region 페이지 만들기 위한 설정
        private int currentPage = 0;
        private int itemsInPage = 4; // 한 페이지에 보여줄 아이템 수
        #endregion

        #region 카테고리에 해당하는 아이템들을 동적으로 로드 + 페이지
        private void LoadItemsForCurrentPage()
        {
            TabPage page = tabControl1.SelectedTab;
            page.Controls.Clear();
            List<Button> btnList = GetButtonsForCategory(page.Text);

            int totalItems = btnList.Count;
            int totalPages = (int)Math.Ceiling((double)totalItems / itemsInPage);

            TableLayoutPanel table = new TableLayoutPanel();
            table.Dock = DockStyle.Fill;
            int columnCount = 4;
            int startItemIndex = currentPage * itemsInPage;
            int endItemIndex = Math.Min(startItemIndex + itemsInPage, totalItems);

            int rowCount = (int)Math.Ceiling((double)(endItemIndex - startItemIndex) / columnCount);
            table.ColumnCount = columnCount;
            table.RowCount = rowCount;

            for (int x = 0; x < columnCount; x++)
            {
                table.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100f / columnCount));
            }

            for (int y = 0; y < rowCount; y++)
            {
                table.RowStyles.Add(new RowStyle(SizeType.AutoSize));
            }

            for (int i = startItemIndex; i < endItemIndex; i++)
            {
                int x = (i - startItemIndex) % columnCount;
                int y = (i - startItemIndex) / columnCount;

                Panel panel = new Panel
                {
                    BorderStyle = BorderStyle.FixedSingle
                };

                Button button = btnList[i];
                button.Dock = DockStyle.Fill;

                panel.Controls.Add(button);
                table.Controls.Add(panel, x, y);

                button.Click += (sender, e) =>
                {
                    var itemData = (dynamic)button.Tag;

                    string itemName = itemData.itemName;
                    int itemPrice = itemData.price;
                    string itemContent = itemData.content;
                    int itemCnt = 1;
                    int optionCnt = 1;

                    item itemForm = new item(itemName, itemPrice, itemContent, itemCnt, optionCnt);
                    itemForm.Show();
                };
            }

            page.Controls.Add(table);

            if (currentPage == 0)
            {
                PrevPage.Visible = false;
                NextPage.Visible = totalPages > 1;
            }
            else if (currentPage == totalPages - 1)
            {
                PrevPage.Visible = true;
                NextPage.Visible = false;
            }
            else
            {
                PrevPage.Visible = true;
                NextPage.Visible = true;
            }
        }
        #endregion

        #region 카테고리별 아이템 가져오기
        public List<Button> GetButtonsForCategory(string category)
        {
            ItemInsert itemInsert = new ItemInsert();
            return itemInsert.CheckItem(category);
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

            if (tabControl1.TabPages.Count > 0)
            {
                tabControl1.SelectedTab = tabControl1.TabPages[0];
            }

            tabControl1.SelectedIndexChanged += new EventHandler(Selected_Change);
            Selected_Change(tabControl1, EventArgs.Empty);

            TemporaryTable.CreateTemporary();
        }
        #endregion

        #region ChangedTabPage(TabControl에서 선택된 Tab이 바뀔 때 이벤트)
        private void Selected_Change(object sender, EventArgs e)
        {
            currentPage = 0;
            LoadItemsForCurrentPage();
        }
        #endregion

        #region 페이지 이동 버튼 이벤트
        private void PrevPage_Click(object sender, EventArgs e)
        {
            if (currentPage > 0)
            {
                currentPage--;
                LoadItemsForCurrentPage();
            }
        }

        private void NextPage_Click(object sender, EventArgs e)
        {
            TabPage page = tabControl1.SelectedTab;
            List<Button> btnList = GetButtonsForCategory(page.Text);
            int totalItems = btnList.Count;
            int totalPages = (int)Math.Ceiling((double)totalItems / itemsInPage);

            if (currentPage < totalPages - 1)
            {
                currentPage++;
                LoadItemsForCurrentPage();
            }
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
