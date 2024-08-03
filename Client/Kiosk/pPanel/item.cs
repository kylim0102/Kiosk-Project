using Kiosk.common;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ProgressBar;

namespace Kiosk.pPanel
{
    public partial class item : Form
    {
        private ItemInsert itemInsert = new ItemInsert();
        private static TemporaryTable TemporaryTable = new TemporaryTable();
        private string option_name1 = null;
        private int option_price1 = 0;
        private string option_name2 = null;
        private int option_price2 = 0;
        private KioskPanel main_form;

        public item(string itemName, int itemPrice, string itemContent, int itemCnt, int optionQuantity, KioskPanel kiosk)
        {
            InitializeComponent();
            this.label1.Text = itemName;
            this.label2.Text = itemPrice.ToString();
            this.label3.Text = itemContent;
            this.textBox1.Text = itemCnt.ToString();
            this.textBox2.Text = optionQuantity.ToString();
            main_form = kiosk;
        }

        private void OpenNewForm()
        {

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

            //group1 체크를 이용하여 활성화 관리
            AddGroup1CheckChangedHandler(group1);

            // 체크박스 값 출력
            #endregion

            for (int i = 0; i < itemCount; i++)
            {
                int x = i % columnCount;
                int y = i / columnCount;

                Panel panel = new Panel();
                CheckBox checkBox = checkBoxes[i];
                checkBox.Name = "checkBox" + i;
                checkBox.CheckedChanged += CheckBox_CheckedChanged;

                panel.Controls.Add(checkBox);

                tableLayoutPanel1.Controls.Add(panel, x, y);

                
            }

            try
            {
                // 바탕화면 경로 가져오기
                string desktopPath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);

                // image 폴더 경로
                string imagePath = Path.Combine(desktopPath, "Kiosk_Image");

                Select_Item_Picture.Image = Image.FromFile(imagePath+"\\"+label1.Text+".jpg");
                Select_Item_Picture.SizeMode = PictureBoxSizeMode.StretchImage;
            }
            catch(Exception ex)
            {
                Console.WriteLine("이미지를 찾을 수 없습니다.\n"+ex.Message);
            }

            // 초기 상태에서 텍스트박스와 증감 버튼 숨기기
            textBox2.Visible = false;
            OptionIncrease.Visible = false;
            OptionDecrease.Visible = false;
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

        private void CheckBox_CheckedChanged(object sender, EventArgs e)
        {
            CheckBox checkbox = sender as CheckBox;
            dynamic tag = checkbox.Tag;
            string optionName = tag.optionName;
            int optionPrice = tag.optionPrice;

            if(optionName.Equals("연하게") || optionName.Equals("샷 추가"))
            {
                option_name1 = optionName;
                option_price1 = optionPrice;
            }
            else if(optionName.Equals(option_name1))
            {
                option_name1 = null;
                option_price1 = 0;
            }
            else if(optionName.Equals("ICE") || optionName.Equals("HOT"))
            {
                option_name2 = optionName;
                option_price2 = optionPrice;
            }
            else if(optionName.Equals(option_name2))
            {
                option_name2 = null;
                option_price2 = 0;
            }


            MessageBox.Show("option_name1: "+option_name1+"\noption_name2: "+ option_name2 + "\noption_price1: "+option_price1+"\noption_price2: "+option_price2);
        }
        #endregion

        #region 그룹1을 이용하여 버튼 및 textbox 활성화/비활성화
        private void AddGroup1CheckChangedHandler(List<CheckBox> group1)
        {
            foreach (CheckBox checkBox in group1)
            {
                checkBox.CheckedChanged += (s, e) =>
                {
                    if (checkBox.Checked)
                    {
                        textBox2.Visible = true;
                        OptionIncrease.Visible = true;
                        OptionDecrease.Visible = true;
                    }
                    else
                    {
                        textBox2.Visible = false;
                        OptionIncrease.Visible = false;
                        OptionDecrease.Visible = false;
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

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }


        #region 버튼을 이용한 상품 수량 증감
        //상품 수량 증가
        private void Increase_Click(object sender, EventArgs e)
        {
            int cnt = int.Parse(textBox1.Text);
            cnt++;
            textBox1.Text = cnt.ToString();
        }

        //상품 수량 감소 
        private void Decrease_Click(object sender, EventArgs e)
        {
            int cnt = int.Parse(textBox1.Text);
            if (cnt > 1)
            {
                cnt--;
                textBox1.Text = cnt.ToString();
            } else
            {
                MessageBox.Show("최소 수량은 1개입니다.");
            }
        }
        #endregion

        #region 버튼을 이용한 옵션 수량 증감
        //옵션 수량 증가
        private void OptionIncrease_Click(object sender, EventArgs e)
        {
            int optioncnt = int.Parse(textBox2.Text);
            optioncnt++;
            textBox2.Text = optioncnt.ToString();
        }

        //옵션 수량 감소 
        private void OptionDecrease_Click(object sender, EventArgs e)
        {
            int optioncnt = int.Parse(textBox2.Text);
            if (optioncnt > 1)
            {
                optioncnt--;
                textBox2.Text = optioncnt.ToString();
            }
            else
            {
                MessageBox.Show("최소 수량은 1개입니다.");
            }
        }
        #endregion

        private void button3_Click(object sender, EventArgs e)
        {
            // 선택한 제품 Insert string itemNumber, string itemName, int itemCount, int payment, int orderNumber
            string itemName = label1.Text;
            int price = Convert.ToInt32(label2.Text);
            int itemNumber = 0;
            int itemCount = Convert.ToInt32(textBox1.Text);
            int optionNumber = 0;

            if(TemporaryTable.CheckTemporary() == 0)
            {
                itemNumber = 1;
                //제품등록
                TemporaryTable.InsertTemporary(itemNumber.ToString(),itemName,itemCount,price,0);
                //옵션등록
                if(!option_name1.Equals(""))
                {
                    TemporaryTable.InsertTemporary(itemNumber+"-"+(TemporaryTable.GetItemOptionNumber(itemNumber)+1), option_name1, Convert.ToInt32(textBox2.Text), option_price1, 0);
                }

                if(!option_name2.Equals(""))
                {
                    TemporaryTable.InsertTemporary(itemNumber + "-" + (TemporaryTable.GetItemOptionNumber(itemNumber)+1), option_name2, 1, option_price2, 0);
                }
            }
            else
            {
                itemNumber = TemporaryTable.GetMaxItemNumber() + 1;
                //제품등록
                TemporaryTable.InsertTemporary(itemNumber.ToString(),itemName, itemCount, price, 0);
                if (!option_name1.Equals(""))
                {
                    TemporaryTable.InsertTemporary(itemNumber + "-" + (TemporaryTable.GetItemOptionNumber(itemNumber) + 1), option_name1, Convert.ToInt32(textBox2.Text), option_price1, 0);
                }

                if (!option_name2.Equals(""))
                {
                    TemporaryTable.InsertTemporary(itemNumber + "-" + (TemporaryTable.GetItemOptionNumber(itemNumber) + 1), option_name2, 1, option_price2, 0);
                }
            }

            // Kiosk Panel을 itemForm으로 참조 전달, foreach를 통해 장바구니 버튼 탐색 후 Temporory table count 세팅
            int cart_count = TemporaryTable.GetOnlyItemCount();

            foreach (Control control in main_form.Controls)
            {
                if (control is Button)
                {
                    Button cart = (Button)control;
                    if (cart.Name.Equals("Cart_btn"))
                    {
                        cart.Text = "장바구니 (" + cart_count + ")";
                    }
                }
            }
            
            this.Close();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}