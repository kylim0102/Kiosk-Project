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
        public TemporaryView TemporaryView = new TemporaryView();
        private TemporaryTable table = new TemporaryTable();
        DataTable _cData = new DataTable();
        public event EventHandler ButtonClicked;

        public CartPanel()
        {
            InitializeComponent();
        }

        #region 내가 만든거
        public void LoadData(DataTable dt)
        {
            UpdateUI(dt);
        }

        public void UpdateUI(DataTable dt)
        {
            tableLayoutPanel1.Controls.Clear();
            tableLayoutPanel1.ColumnStyles.Clear();
            tableLayoutPanel1.RowStyles.Clear();

            int columnCount = 5;
            int itemCount = dt.Rows.Count * 5;
            int rowCount = (int)Math.Ceiling((double)itemCount / columnCount);

            tableLayoutPanel1.ColumnCount = columnCount;
            tableLayoutPanel1.RowCount = rowCount;

            tableLayoutPanel1.AutoSize = true; // 테이블 레이아웃 자동 크기 조정
            tableLayoutPanel1.AutoSizeMode = AutoSizeMode.GrowAndShrink;

            // 열 스타일 설정
            for (int x = 0; x < columnCount; x++)
            {
                tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 20f)); // 각 열이 부모 컨트롤의 20%를 차지하도록 설정
            }

            for (int y = 0; y < rowCount; y++)
            {
                tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.AutoSize)); // 각 행의 크기는 자동으로 조정
            }

            for (int i = 0; i < itemCount; i++)
            {
                int x = i % columnCount;
                int y = i / columnCount;

                DataRow row = dt.Rows[i / 5];
                string itemName = null;
                string count = null;
                string name = row["itemName"].ToString();
                string itemNumber = row["itemNumber"].ToString();
                Console.WriteLine(itemNumber);
                if (!name.Equals("샷 추가") && !name.Equals("연하게") && !name.Equals("ICE") && !name.Equals("HOT"))
                {
                    itemName = name;
                    count = row["itemCount"].ToString();
                }

                Panel panel = new Panel();
                panel.Dock = DockStyle.Fill;
                panel.AutoSize = true; // 패널 자동 크기 조정

                if (x == 0)
                {
                    PictureBox pictureBox = new PictureBox();
                    pictureBox.Name = "image";
                    pictureBox.Dock = DockStyle.Fill;
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
                }
                else if (x == 1)
                {
                    Label label = new Label();
                    label.Text = itemName;
                    label.Dock = DockStyle.Fill;
                    label.TextAlign = ContentAlignment.MiddleCenter;
                    label.AutoSize = true; // 레이블 자동 크기 조정
                    panel.Controls.Add(label);
                }
                else if (x == 2)
                {
                    DataTable all = TemporaryTable.GetAllTemporaryDataTable(Convert.ToString(itemNumber));
                    ListBox list = new ListBox();
                    for (int z = 0; z < all.Rows.Count; z++)
                    {
                        DataRow optionRow = all.Rows[z];
                        string option = optionRow["itemName"].ToString();
                        Console.WriteLine(option);
                        if (option.Equals("샷 추가") || option.Equals("연하게") || option.Equals("ICE") || option.Equals("HOT"))
                        {
                            list.Items.Add(option);
                        }
                    }
                    list.Dock = DockStyle.Fill;
                    list.AutoSize = true; // 리스트박스 자동 크기 조정
                    panel.Controls.Add(list);
                }
                else if (x == 3)
                {
                    Label label = new Label();
                    label.Text = count;
                    label.Dock = DockStyle.Fill;
                    label.AutoSize = true; // 레이블 자동 크기 조정
                    panel.Controls.Add(label);
                }
                else if (x == 4)
                {
                    Button btn = new Button();
                    btn.Text = "삭제버튼";
                    btn.Dock = DockStyle.Fill;
                    btn.AutoSize = true; // 버튼 자동 크기 조정
                    panel.Controls.Add(btn);
                    btn.Click += (sender, e) =>
                    {
                        TemporaryTable.Delete(itemNumber);
                        MessageBox.Show("삭제되었습니다.");
                        tableLayoutPanel1.Controls.Clear();
                        DataTable all = TemporaryTable.GetTemporaryDataTable();
                        LoadData(all);
                    };
                }
                tableLayoutPanel1.Controls.Add(panel, x, y);
            }
        }


        private void CartPanel_Load(object sender, EventArgs e)
        {
        }
        #endregion



        private void button3_Click(object sender, EventArgs e)
        {
            ButtonClicked?.Invoke(this, EventArgs.Empty);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            TemporaryView.Show();
        }

    }
}