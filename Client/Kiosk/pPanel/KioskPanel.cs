using Kiosk.common;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Kiosk.pPanel
{
    public partial class KioskPanel : UserControl
    {
        pPanel.CartPanel cartPanel = new pPanel.CartPanel();
        public event EventHandler ButtonClicked;

        public KioskPanel()
        {
            InitializeComponent();
            InitializeTableLayoutPanel();
        }

        public void InitializeTableLayoutPanel()
        {
            ItemInsert itemInsert = new ItemInsert();
            List<Button> btnList = itemInsert.CheckItem();

            tableLayoutPanel1.Controls.Clear();
            tableLayoutPanel1.ColumnStyles.Clear();
            tableLayoutPanel1.RowStyles.Clear();

            int columnCount = 4; // 한 줄에 보여질 최대 열 수
            int itemCount = btnList.Count;

            // 필요한 행 수 계산
            int rowCount = (int)Math.Ceiling((double)itemCount / columnCount);

            tableLayoutPanel1.ColumnCount = columnCount;
            tableLayoutPanel1.RowCount = rowCount;

            // 열 스타일 설정
            for (int x = 0; x < columnCount; x++)
            {
                tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100f / columnCount));
            }

            // 행 스타일 설정
            for (int y = 0; y < rowCount; y++)
            {
                tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.AutoSize));
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
                tableLayoutPanel1.Controls.Add(panel, x, y);
            }
        }



    public void button4_Click(object sender, EventArgs e)
        {
            ButtonClicked?.Invoke(this, EventArgs.Empty);
        }

        private void button3_Click(object sender, EventArgs e)
        {

        }
    }
}
