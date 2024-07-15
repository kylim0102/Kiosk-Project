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

        private void option_modify_Click(object sender, EventArgs e)
        {
            if (idx.Text.Equals("") || option.Text.Equals("") || option_price.Text.Equals(""))
            {
                MessageBox.Show("수정하려는 카테고리를 선택해주세요!", "CATEGORY MANAGE ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            else
            {
                bool result = table.OptionModify(idx.Text, option_price.Text);
                option_price.Text = string.Empty;
                option.Text = string.Empty;
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

        private void option_reset_Click(object sender, EventArgs e)
        {

        }
    }
}