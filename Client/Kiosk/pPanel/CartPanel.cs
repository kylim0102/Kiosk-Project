using Kiosk.common;
using Org.BouncyCastle.Pqc.Crypto.Lms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics.Eventing.Reader;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Kiosk.pPanel
{
    public partial class CartPanel : UserControl
    {
        //public TemporaryView TemporaryView = new TemporaryView();
        private TemporaryTable table = new TemporaryTable();
        //DataTable _cData = new DataTable();
        public event EventHandler ButtonClicked;
        private KioskPanel kioskPanel;

        public CartPanel(KioskPanel kioskPanel)
        {
            InitializeComponent();
            this.kioskPanel = kioskPanel;
        }

        #region CreateCartPenalFromTemporaryTable(TemporaryTable의 데이터를 CartPenal에서 동적으로 UI를 구현)
        public void LoadData(DataTable dt)
        {
            UpdateUI(dt);
        }

        public void UpdateUI(DataTable dt)
        {
            #region TableLayOutPanel_CleanUp(TableLayOutPanel 모든 내용 비우기)
            tableLayoutPanel1.Controls.Clear();
            tableLayoutPanel1.ColumnStyles.Clear();
            tableLayoutPanel1.RowStyles.Clear();
            #endregion

            #region TableLayOutPanel_DesignSetting(TableLayOutPanel 디자인 및 행, 열 세팅)
            int columnCount = 5;
            int itemCount = dt.Rows.Count * 5;
            int rowCount = (int)Math.Ceiling((double)itemCount / columnCount);

            tableLayoutPanel1.ColumnCount = columnCount;
            tableLayoutPanel1.RowCount = rowCount;

            //tableLayoutPanel1.AutoSize = true; // 테이블 레이아웃 자동 크기 조정
            //tableLayoutPanel1.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            #endregion

            #region TableLayOutPanel_Column And Row_Style Setting(TableLayOutPanel 행, 열 스타일 지정)
            for (int x = 0; x < columnCount; x++)
            {
                tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100f /columnCount)); // 각 열이 부모 컨트롤의 20%를 차지하도록 설정
            }

            for (int y = 0; y < rowCount; y++)
            {
                tableLayoutPanel1.RowStyles.Add(new ColumnStyle(SizeType.Percent, 100f / columnCount)); // 각 행의 크기는 자동으로 조정
            }
            #endregion

            decimal totalprice = 0;

            // panel을 세팅하고 세팅한 panel을 tablelayoutpanel에 담는 과정을 장바구니에 담은 제품 수만큼 반복
            for (int i = 0; i < itemCount; i++)
            {
                int x = i % columnCount;
                int y = i / columnCount;

                DataRow row = dt.Rows[i / 5];
                string itemName = null;
                string count = null;
                string name = row["itemName"].ToString();
                string itemNumber = row["itemNumber"].ToString();
                decimal itemPrice = Convert.ToDecimal(row["payment"]); // 상품의 가격을 데이터 테이블에서 가져옴
                int cnt = Convert.ToInt32(row["itemCount"]);

                if (!name.Equals("샷 추가") && !name.Equals("연하게") && !name.Equals("ICE") && !name.Equals("HOT"))
                {
                    itemName = name;
                    count = row["itemCount"].ToString();
                }

                totalprice += (itemPrice * cnt) / 5;

                Panel panel = new Panel();
                panel.Dock = DockStyle.None;
                //panel.AutoSize = true; // 패널 자동 크기 조정

                if (x == 0)
                {
                    #region Panel First Column To Picture(Panel의 첫번째 칸에는 제품 사진)
                    PictureBox pictureBox = new PictureBox();
                    pictureBox.Name = "image";
                    pictureBox.Dock = DockStyle.None;
                    pictureBox.Size = new Size(150, 90);
                    pictureBox.SizeMode = PictureBoxSizeMode.StretchImage;

                    string desktopPath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
                    string imagePath = Path.Combine(desktopPath, "Kiosk_Image");
                    string fullImagePath = Path.Combine(imagePath, itemName + ".jpg");

                    if (File.Exists(fullImagePath))
                    {
                        Image item = Image.FromFile(fullImagePath);
                        pictureBox.Image = item;
                    }

                    panel.Controls.Add(pictureBox);
                    #endregion
                }
                else if (x == 1)
                {
                    #region Panel Second Column To ItemName(Panel의 두번째 칸에는 제품 명)
                    Label label = new Label();
                    label.Text = itemName;
                    label.Dock = DockStyle.None;
                    label.TextAlign = ContentAlignment.MiddleCenter;
                    //label.AutoSize = true; // 레이블 자동 크기 조정
                    panel.Controls.Add(label);
                    #endregion
                }
                else if (x == 2)
                {
                    #region Panel Third Column To Options(Panel의 세번째 칸에는 제품에 대한 옵션을 ListBox형태로)
                    DataTable all = TemporaryTable.GetAllTemporaryDataTable(Convert.ToString(itemNumber));
                    ListBox list = new ListBox();
                    for (int z = 0; z < all.Rows.Count; z++)
                    {
                        DataRow optionRow = all.Rows[z];
                        string option = optionRow["itemName"].ToString();
                        
                        if (option.Equals("샷 추가") || option.Equals("연하게") || option.Equals("ICE") || option.Equals("HOT"))
                        {
                            list.Items.Add(option);
                        }
                    }
                    list.Dock = DockStyle.None;
                    //list.AutoSize = true; // 리스트박스 자동 크기 조정
                    panel.Controls.Add(list);
                    #endregion
                }
                else if (x == 3)
                {
                    #region Panel fourth To ItemCount(Panel의 네번째 칸에는 제품의 수량)
                    Label label = new Label();
                    label.Text = count;
                    label.Dock = DockStyle.None;
                    //label.AutoSize = true; // 레이블 자동 크기 조정
                    panel.Controls.Add(label);
                    #endregion
                }
                else if (x == 4)
                {
                    #region Panel fifth To DeleteButton(Panel의 마지막 칸에는 해당 제품을 장바구니에서 제거 버튼)
                    Button btn = new Button();
                    btn.Text = "삭제버튼";
                    btn.Dock = DockStyle.None;
                    //btn.AutoSize = true; // 버튼 자동 크기 조정
                    panel.Controls.Add(btn);
                    btn.Click += (sender, e) =>
                    {
                        TemporaryTable.Delete(itemNumber);
                        MessageBox.Show("삭제되었습니다.");
                        tableLayoutPanel1.Controls.Clear();
                        DataTable all = TemporaryTable.GetTemporaryDataTable();
                        LoadData(all);
                    };
                    #endregion
                }

                // Setting을 마친 panel을 tablelayoutpanel에 넣기
                tableLayoutPanel1.Controls.Add(panel, x, y);
            }
            label5.Text = $"{totalprice:C}";
        }

        #endregion

        private void button3_Click(object sender, EventArgs e)
        {
            this.Visible = false;
            kioskPanel.Visible = true;
        }

        #region OrderButton Event(결제하기 버튼 이벤트)
        private void button2_Click(object sender, EventArgs e)
        {
            ButtonClicked?.Invoke(this, EventArgs.Empty);
        }
        #endregion

        #region Dummy Event
        private void CartPanel_Load(object sender, EventArgs e)
        {
        }
        #endregion
    }
}