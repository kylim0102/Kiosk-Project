using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Kiosk.Order
{
    public partial class OrderList : Form
    {
        public OrderList()
        {
            InitializeComponent();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            string list1 = string.Join(Environment.NewLine, listBox1.Items.Cast<string>());
            
            MessageBox.Show(list1,groupBox1.Text);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            string list2 = string.Join(Environment.NewLine, listBox2.Items.Cast<string>());

            MessageBox.Show(list2, groupBox2.Text);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            MessageBox.Show("1번 호출벨을 울립니다.");
            groupBox1.Visible = false;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            MessageBox.Show("2번 호출벨을 울립니다.");
            groupBox2.Visible = false;
        }
        
        private Control CloneControl(Control original)
        {
            Control newControl = (Control)Activator.CreateInstance(original.GetType());
            newControl.Location = original.Location;
            newControl.Size = original.Size;
            newControl.Text = original.Text;
            newControl.Enabled = original.Enabled;
            newControl.Visible = original.Visible;

            if(newControl is ListBox listbox)
            {
                listbox.Name = "Clone";

                listbox.Items.Add("------------------------------");
                listbox.Items.Add("Clone Info First");
                listbox.Items.Add("Clone Info Second");
                listbox.Items.Add("Clone Info Third");
                listbox.Items.Add("");
                listbox.Items.Add("------------------------------");
            }

            if(newControl is Button button)
            {
                button.Click += new EventHandler(button4_Click);
            }



            return newControl;
        }

        private void Button_Click(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        public GroupBox CloneGroupBox(GroupBox original)
        {
            // 새로운 GroupBox 생성
            GroupBox newgroupBox = new GroupBox();

            // 원본 GroupBox의 속성을 새로운 GroupBox에 복사
            newgroupBox.Text = "Clone GroupBox";
            newgroupBox.Size = original.Size;

            newgroupBox.Location = new Point(original.Location.X + original.Width + 40, original.Location.Y);

            // 원본 groupBox의 컨트롤들을 복사
            foreach (Control control in original.Controls)
            {
                Control newControl = CloneControl(control);
                newControl.Parent = newgroupBox;

                newControl.Location = new Point(control.Location.X, control.Location.Y);
            }

            return newgroupBox;
        }

        private void OrderList_Load(object sender, EventArgs e)
        {
            this.Controls.Add(CloneGroupBox(groupBox2));
        }
    }
}
