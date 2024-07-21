using Kiosk.common;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ProgressBar;

namespace Kiosk.pPanel
{
    public partial class item : Form
    {
        private ItemInsert itemInsert = new ItemInsert();
        public item(string itemName, int itemPrice, string itemContent)
        {
            InitializeComponent();
            this.label1.Text = itemName;
            this.label2.Text = itemPrice.ToString();
            this.label3.Text = itemContent;
        }

        private void item_Load(object sender, EventArgs e)
        {
            tableLayoutPanel1.Controls.Clear();
            tableLayoutPanel1.ColumnStyles.Clear();
            tableLayoutPanel1.RowStyles.Clear();

            List<CheckBox> checkBoxes = itemInsert.checkBox();
            int columnCount = 4; // 한 줄에 보여질 최대 열 수
            int itemCount = checkBoxes.Count;
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
            #region 두개씩 그룹으로 묶었음
            List<CheckBox> group1 = new List<CheckBox>();
            List<CheckBox> group2 = new List<CheckBox>();

            for (int i = 0; i < itemCount; i++)
            {
                if (i < itemCount / 2)
                    group1.Add(checkBoxes[i]);
                else
                    group2.Add(checkBoxes[i]);
            }

            // 그룹 체크 상태 관리
            AddCheckChangedHandler(group1);
            AddCheckChangedHandler(group2);
            #endregion

            for (int i = 0; i < itemCount; i++)
            {
                int x = i % columnCount;
                int y = i / columnCount;

                Panel panel = new Panel();
                CheckBox checkBox = checkBoxes[i];

                panel.Controls.Add(checkBox);

                tableLayoutPanel1.Controls.Add(panel, x, y);


            }
        }
        #region 그룹 안에서는 둘 중에 하나만 체크가 되게
        private void AddCheckChangedHandler(List<CheckBox> group)
        {
            foreach (CheckBox checkBox in group)
            {
                checkBox.CheckedChanged += (s, e) =>
                {
                    if (checkBox.Checked)
                    {
                        foreach (CheckBox otherCheckBox in group)
                        {
                            if (otherCheckBox != checkBox && otherCheckBox.Checked)
                            {
                                otherCheckBox.Checked = false;
                            }
                        }
                    }
                };
            }
        }
        #endregion

        // 취소 버튼 
        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

       
    }
}
/* 
             * ㄹㅇ 루다가 빡세네 
             * List<CheckBox> checkBoxes = itemInsert.checkBox();
             string optionName = null;
             int optionPrice = 0;
             for (int i = 0; i < checkBoxes.Count; i++)
             {
                 CheckBox check = checkBoxes[i];

                 // 체크박스 항목 추가
                 // CheckBox 객체의 Text 속성을 사용하여 항목 추가
                 checkedListBox1.Items.Add(checkBoxes[i].Text);


                 checkedListBox1.ItemCheck += (s, ev) => {
                     // ItemCheckEventArgs의 Index를 사용하여 체크박스의 정보를 가져옴
                     //object aa = checkedListBox1.Items[ev.Index] as CheckBox;
                     var optionData = (dynamic)check.Tag;

                     optionName = optionData.optionName; // 상품 이름
                     optionPrice = optionData.optionPrice; // 상품 가격

                     if (ev.NewValue == CheckState.Checked)
                     {
                         // 체크 되었을 때
                         MessageBox.Show($"체크박스가 선택되었습니다. 가격: {optionPrice}");
                     }
                     else
                     {
                         // 체크 해제 되었을 때
                         MessageBox.Show($"체크박스가 선택 해제되었습니다. 옵션 이름: {optionName}");
                     }
                 };
             }*/
// 체크 박스의 상태가 변경될 때 호출되는 이벤트 핸들러 추가
//checkedListBox1.ItemCheck += checkedListBox1_ItemCheck;



// 체크를 할 시
/*private void checkedListBox1_ItemCheck(object sender, ItemCheckEventArgs e)
{
    // ItemCheckEventArgs의 Index를 사용하여 체크박스의 정보를 가져옴
    var checkBox = checkedListBox1.Items[e.Index] as CheckBox;
    var optionData = (dynamic)checkBox.Tag;

    string optionName = optionData.optionName;
    int optionPrice = optionData.optionPrice;

    if (e.NewValue == CheckState.Checked)
    {
        // 체크 되었을 때
        MessageBox.Show($"체크박스가 선택되었습니다. 가격: {optionPrice}");
    }
    else
    {
        // 체크 해제 되었을 때
        MessageBox.Show($"체크박스가 선택 해제되었습니다. 옵션 이름: {optionName}");
    }
}*/