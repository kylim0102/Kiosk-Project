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


        public void button4_Click(object sender, EventArgs e)
        {
            DataTable dt = TemporaryTable.GetTemporaryDataTable();
            //DataRow dataRow = null;
            string itemName = null;
            List<string> itemList = new List<string>();
            

            foreach (DataRow row in dt.Rows)
            {
                itemName = row["itemName"].ToString();
                itemList.Add(itemName);
            }

            ButtonClicked?.Invoke(this, EventArgs.Empty);
            
            
            

            // 바탕화면 경로 가져오기
            string desktopPath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);

            // image 폴더 경로
            string imagePath = Path.Combine(desktopPath, "Kiosk_Image");

            List<Image> imageList = new List<Image>();
            Image images = null;

            for(int a=0; a<itemList.Count; a++)
            {
                if (itemList[a].Equals("샷 추가") || itemList[a].Equals("연하게") || itemList[a].Equals("ICE") || itemList[a].Equals("HOT"))
                {
                    images = null;
                    imageList.Add(images);
                }
                else
                {
                    images = Image.FromFile(imagePath + "\\" + itemList[a] + ".jpg");
                }
            }
            //Image item = Image.FromFile(imagePath + "\\" + itemList[0] + ".jpg");



            //cartPanel.Controls.Add(pictureBox);

            int x = 0, y = 0;
            
            foreach(Control control in cartPanel.Controls)
            {
                if(control is TableLayoutPanel)
                {
                    TableLayoutPanel tableLayoutPanel = (TableLayoutPanel)control;
                    if (tableLayoutPanel.Name.Equals("tableLayoutPanel1"))
                    {
                        PictureBox pictureBox = new PictureBox();
                        foreach(Image image in imageList)
                        {
                            pictureBox.Name = "image";
                            pictureBox.SizeMode = PictureBoxSizeMode.StretchImage;
                            pictureBox.Dock = DockStyle.Fill;
                            pictureBox.Image = image;
                        }
                        
                        Panel panel = new Panel();
                        panel.Dock = DockStyle.Fill;
                        panel.Controls.Add(pictureBox);

                        
                        tableLayoutPanel.Controls.Add(panel,x, y);
                    }
                }
                x++;
                y++;
            }
           

        }

        private void button3_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void KioskPanel_Load(object sender, EventArgs e)
        {
            List<string> categorys = ItemInsert.GetCategory();
            TabPage page = null;

            for(int a=0; a<categorys.Count; a++)
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

        private void Selected_Change(object sender, EventArgs e)
        {
            TabPage page = tabControl1.SelectedTab;
            page.Controls.Add(AddFromKioskLayoutPanel(page.Text));
        }

        private void button2_Click(object sender, EventArgs e)
        {
            MessageBox.Show("테이블 생성 확인" + TemporaryTable.CheckTemporary() + "");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            MessageBox.Show("max 확인" + TemporaryTable.GetMaxItemNumber() + "");
        }
    }
}
