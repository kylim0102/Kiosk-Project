using Google.Protobuf.WellKnownTypes;
using MySqlX.XDevAPI.Relational;
using Org.BouncyCastle.Asn1.Crmf;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics.Eventing.Reader;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Kiosk.Order
{
    /*
     TCP 통신으로 datatable을  받아오면  통신이 끊길 시 datatable이 소멸되기때문에 이 datatable로 만든 그룹박스도 삭제가 된다
     그러므로 통신으로 받아온 datatable을 temporytable에 저장하거나 로컬저장소에 저장을 해서 
     그 저장된 data들을 가지고 그룹박스를 생성하고 띄워야한다.
     음료가 나가게 되면 temporytable을 삭제하는 방 ㅂ ㅓㅂ 으로 가야할것 같다
     
     */

    public partial class OrderList : Form
    {
        DataTable data = new DataTable();
        private TCP_IP tcp = new TCP_IP();

        private void OrderList_Load(object sender, EventArgs e)
        {
            GroupBox clonedGroupBox = CloneGroupBox(groupBox);
            this.Controls.Add(clonedGroupBox);
        }

        public OrderList(DataTable table)
        {
            InitializeComponent();
            //통신으로 받은 datatable을 저장할 table
            TCP_IP.CreateTemporary();

            string itemNumber = null;
            string itemName = null;
            int itemCount = 0;
            int payment = 0;
            foreach (DataRow row in  table.Rows)
            {
                itemNumber = row["itemNumber"].ToString();
                itemName = row["itemName"].ToString();
                itemCount = Convert.ToInt32(row["itemCount"]);
                payment = Convert.ToInt32(row["payment"]);

                TCP_IP.TemporaryTCPInsert(itemNumber, itemName, itemCount, payment);
            }

            data = TCP_IP.SelectTemporary();
            dataGridView1.DataSource = data;
        }
  


        private void button3_Click(object sender, EventArgs e)
        {
            string list1 = string.Join(Environment.NewLine, listBox1.Items.Cast<string>());
            
            MessageBox.Show(list1,groupBox.Text);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            string list2 = string.Join(Environment.NewLine, listBox1.Items.Cast<string>());

            MessageBox.Show(list2, groupBox.Text);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            MessageBox.Show("1번 호출벨을 울립니다.");
            groupBox.Visible = false;
        }

        private void CallButton_Click(object sender, EventArgs e)
        {
            MessageBox.Show("호출벨을 울립니다.");
/*            foreach(Control control in this.Controls)
            {
                if(control is GroupBox groupBox)
                {
                    if(groupBox.Name == "Copy3")
                    {
                        groupBox.Visible = false;
                    }
                }
            }*/
        }

        private void CancleButton_Click(Object sender, EventArgs e)
        {
            MessageBox.Show("주문을 취소합니다.");
        }
        
        private void PrintButton_Click(Object sender, EventArgs e)
        {
            MessageBox.Show("주문을 출력합니다.");
        }
        private Control CloneControl(Control original)
        {
            Control newControl = (Control)Activator.CreateInstance(original.GetType());
            newControl.Location = original.Location;
            newControl.Size = original.Size;
            newControl.Text = original.Text;
            newControl.Enabled = original.Enabled;
            newControl.Visible = original.Visible;
            newControl.Name = original.Name;

            int index = 0;
            int btn_index = 0;

            if(newControl is ListBox listbox)
            {
                listbox.Name = "Clone";
                listbox.Items.Add("------------------------------");
                foreach (DataRow row in data.Rows)
                {
                    string itemNumber = row["itemNumber"].ToString().Trim();
                    if (!itemNumber.Contains("-"))
                    {
                        listbox.Items.Add("제품:" + row["itemName"].ToString());
                    }
                    else
                    {
                        listbox.Items.Add("옵션:" + row["itemName"].ToString());
                    }
                    if ((index+1)% 3 == 0)
                    { 
                        listbox.Items.Add("");
                        listbox.Items.Add("------------------------------");
                    }
                    index++;
                }

            }

            if (newControl is Button button)
            {
                if(button.Name.Equals("Order_cancle"))
                {
                    button.Click += new EventHandler(CancleButton_Click);
                }
                else if(button.Name.Equals("Order_call"))
                {
                    button.Click += new EventHandler(CallButton_Click);
                }
                else if(button.Name.Equals("Order_print"))
                {
                    button.Click += new EventHandler(PrintButton_Click);
                }
            }



            return newControl;
        }

        public GroupBox CloneGroupBox(GroupBox original)
        {
            // 새로운 GroupBox 생성
            GroupBox newgroupBox = new GroupBox();
            int GroupBoxNumber = this.Controls.OfType<GroupBox>().Count();

            // 원본 GroupBox의 속성을 새로운 GroupBox에 복사
            newgroupBox.Text = "Clone GroupBox";
            newgroupBox.Name = "Copy" + GroupBoxNumber;
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

    }
}
