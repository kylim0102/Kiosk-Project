using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Kiosk.pPanel.common;
using MySql.Data.MySqlClient;

namespace Kiosk.ItemManage.ItemPanel
{
    public partial class OptionPanel : UserControl
    {
        private MySqlConnection mysql = oGlobal.GetConnection();
        private OptionTable table = new OptionTable();
        private string sql = null;

        public OptionPanel()
        {
            InitializeComponent();
        }

        public void OptionPanel_Load(object sender, EventArgs e)
        {
            // Option List View
            DataTable data = table.AddGridView();
            option_list.AutoGenerateColumns = true;
            option_list.DataSource = data;

            // Option Manage
            List<string> list = table.GetOption();
            for (int a = 0; a < list.Count; a++)
            {
                optionlist.Items.Add(list[a]);
            }

            #region 옵션 on/off가 n일때 로드
            List<string> optionlistwithn = table.GetOptionsWithN();

            // 리스트박스 초기화
            listBox1.Items.Clear();

            // 리스트박스에 데이터 추가
            for (int i = 0; i < optionlistwithn.Count; i++)
            {
                listBox1.Items.Add(optionlistwithn[i]);
            }
            #endregion

            #region 옵션 on/off가 y일때 로드
            List<string> optionlistwithy = table.GetOptionsWithY();

            // 리스트박스 초기화
            listBox2.Items.Clear();

            // 리스트박스에 데이터 추가
            for (int i = 0; i < optionlistwithy.Count; i++)
            {
                listBox2.Items.Add(optionlistwithy[i]);
            }
            #endregion

        }


        private void Register_Click(object sender, EventArgs e)
        {
            // Option_value에서 텍스트를 가져와서 int로 변환
            if (int.TryParse(Option_value.Text, out int option_value))
            {
                // 변환된 값으로 table.OptionRegister 메서드 호출
                int option_result = table.OptionRegister(Option_name.Text, option_value);

                // 처리 후에는 TextBox 내용 지우기
                Option_name.Text = string.Empty;
                Option_value.Text = string.Empty;
            }
        }

        private void Reset_Click(object sender, EventArgs e)
        {
            Option_name.Text = string.Empty;
            Option_value.Text = string.Empty;
            Option_name.Focus();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            option_list.DataSource = null;

            DataTable data = table.AddGridView();
            option_list.AutoGenerateColumns = true;
            option_list.DataSource = data;

            option_list.Columns["NO"].Width = 150;
            option_list.Columns["NAME"].Width = 150;
            option_list.Columns["PRICE"].Width = 150;
            option_list.Columns["DATE"].Width = 150;
        }

        private void optionlist_SelectedIndexChanged(object sender, EventArgs e)
        {
            string selected = optionlist.SelectedItem.ToString();
            List<string> list = table.GetOptionForName(optionlist.SelectedItem.ToString());
            idx.Text = list[0].ToString();
            option.Text = list[1].ToString();
            option_price.Text = list[2].ToString();
        }

        private void option_reset_Click(object sender, EventArgs e)
        {
            optionlist.Items.Clear();

            List<string> list = table.GetOption();
            for (int a = 0; a < list.Count; a++)
            {
                optionlist.Items.Add(list[a]);
            }
        }

        private void option_modify_Click(object sender, EventArgs e)
        {
            if (idx.Text.Equals("") || option.Text.Equals("") || option_price.Text.Equals(""))
            {
                MessageBox.Show("수정하려는 옵션을 선택해주세요!", "OPTION MANAGE ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            else
            {
                bool result = table.OptionModify(idx.Text, option.Text, option_price.Text);
                option.Text = string.Empty;
                option_price.Text = string.Empty;
                idx.Text = string.Empty;

                // Category Manage
                optionlist.Items.Clear();

                List<string> list = table.GetOption();
                for (int a = 0; a < list.Count; a++)
                {
                    optionlist.Items.Add(list[a]);
                }
            }
        }

        private void option_delete_Click(object sender, EventArgs e)
        {
            if (idx.Text.Equals("") || option_price.Text.Equals("") || option.Text.Equals(""))
            {
                MessageBox.Show("삭제하려는 옵션을 선택해주세요!", "OPTION MANAGE ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            else
            {
                DialogResult message = MessageBox.Show("선택하신 옵션을 삭제하시겠습니까? \n삭제후에는 복구할 수 없습니다.", "OPTION MANAGER", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);

                if (message == DialogResult.OK)
                {
                    bool result = table.OptionDelete(idx.Text);
                    option.Text = string.Empty;
                    option_price.Text = string.Empty;
                    idx.Text = string.Empty;

                    // Category Manage
                    optionlist.Items.Clear();

                    List<string> list = table.GetOption();
                    for (int a = 0; a < list.Count; a++)
                    {
                        optionlist.Items.Add(list[a]);
                    }
                }
                else if (message == DialogResult.Cancel)
                {
                    MessageBox.Show("삭제 요청을 취소합니다.", "OPTION MANAGER", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }


        #region 추가버튼 누르면 옵션 listbox2로 이동
        private void button3_Click(object sender, EventArgs e)
        {
            // 리스트박스1에서 선택된 항목 가져오기
            List<string> selectedItems = new List<string>();
            for (int i = 0; i < listBox1.SelectedItems.Count; i++)
            {
                selectedItems.Add(listBox1.SelectedItems[i].ToString());
            }

            // 선택된 항목이 없을 경우 처리
            if (selectedItems.Count == 0)
            {
                MessageBox.Show("선택된 옵션이 없습니다.", "알림", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            // 추가할껀지 재확인
            if (MessageBox.Show("추가하시겠습니까?", "YesOrNo", MessageBoxButtons.YesNo) == DialogResult.Yes) { 
                // 선택된 항목을 리스트박스2로 추가하고 리스트박스1에서 제거
                for (int i = 0; i < selectedItems.Count; i++)
                {
                    string selectedItem = selectedItems[i];

                    // 리스트박스2에 추가
                    listBox2.Items.Add(selectedItem);

                    // 리스트박스1에서 제거
                    listBox1.Items.Remove(selectedItem);

                    // 데이터베이스 업데이트 - optionname에서 idx 추출
                    int idx = int.Parse(selectedItem.Split(',')[0].Trim());

                    table.UpdateOption(idx);
                }
            }
        }
        #endregion

        #region 제거버튼 누르면 옵션 listbox1로 이동
        private void button2_Click(object sender, EventArgs e)
        {
            // 리스트박스2에서 선택된 항목 가져오기
            List<string> selectedItems = new List<string>();
            for (int i = 0; i < listBox2.SelectedItems.Count; i++)
            {
                selectedItems.Add(listBox2.SelectedItems[i].ToString());
            }

            // 선택된 항목이 없을 경우 처리
            if (selectedItems.Count == 0)
            {
                MessageBox.Show("선택된 옵션이 없습니다.", "알림", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            //제거 재확인
            if (MessageBox.Show("제거하시겠습니까?", "YesOrNo", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                // 선택된 항목을 리스트박스2로 추가하고 리스트박스1에서 제거
                for (int i = 0; i < selectedItems.Count; i++)
                {
                    string selectedItem = selectedItems[i];

                    // 리스트박스1에 추가
                    listBox1.Items.Add(selectedItem);

                    // 리스트박스2에서 제거
                    listBox2.Items.Remove(selectedItem);

                    // 데이터베이스 업데이트 - optionname에서 idx 추출
                    int idx = int.Parse(selectedItem.Split(',')[0].Trim());
                    table.RemoveOption(idx);
                }
            }
        }
        #endregion
    }
}