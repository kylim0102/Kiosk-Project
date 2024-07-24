using Kiosk.common;
using System;
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
    public partial class CartPanel : UserControl
    {
        public TemporaryView TemporaryView = new TemporaryView();
        private static TemporaryTable temporaryTable = new TemporaryTable();


        public CartPanel()
        {
            InitializeComponent();
        }

        private void CartPanel_Load(object sender, EventArgs e)
        {
            tableLayoutPanel1.Controls.Clear();
            tableLayoutPanel1.ColumnStyles.Clear();
            tableLayoutPanel1.RowStyles.Clear();

            int columnCount = 5;
            int itemCount = 1;
            int rowCount = (int)Math.Ceiling((double)itemCount / columnCount);

            tableLayoutPanel1.ColumnCount = columnCount;
            tableLayoutPanel1.RowCount = rowCount;

            DataTable dt = TemporaryTable.GetTemporaryDataTable();
            //DataRow dataRow = null;
            string itemName = null;

            foreach (DataRow row in dt.Rows)
            {
                itemName = row["itemName"].ToString();
            }


            // 열 스타일 설정
            for (int x = 0; x < columnCount; x++)
            {
                tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100f / columnCount));
            }

            for (int y = 0; y < rowCount; y++)
            {
                tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.AutoSize));
            }

            for (int i = 0; i < itemCount; i++)
            {
                int x = i % columnCount;
                int y = i / columnCount;

                Panel panel = new Panel();

                if (i == 0)
                {
                    /*PictureBox pictureBox = new PictureBox();
                    pictureBox.Name = "image";

                    // 바탕화면 경로 가져오기
                    string desktopPath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);

                    // image 폴더 경로
                    string imagePath = Path.Combine(desktopPath, "Kiosk_Image");
                    //Image item = Image.FromFile(imagePath + "\\" + itemName + ".jpg");

                    pictureBox.SizeMode = PictureBoxSizeMode.StretchImage;

                    pictureBox.Dock = DockStyle.Fill;

                    //pictureBox.Image = item;

                    panel.Controls.Add(pictureBox);*/
                    //this.tableLayoutPanel1.Controls.Add(panel);
                }
                else if (i == 1)
                {
                    //상품 이름
                    //itemName
                    

                }
                else if (i == 2)
                {
                    //상품 가격
                }
                else if (i == 3)
                {
                    //수량 변경
                }
                else
                {
                    //취소 버튼
                }
                tableLayoutPanel1.Controls.Add(panel, x, y);

            }
        }

        private void button3_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            TemporaryView.Show();
        }

    }
}
