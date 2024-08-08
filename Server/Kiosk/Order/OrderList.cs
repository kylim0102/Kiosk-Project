using Google.Protobuf.WellKnownTypes;
using Kiosk.pPanel.common;
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
    public partial class OrderList : Form
    {
        DataTable data = new DataTable();
        private TcpConnection con = new TcpConnection();
        private System.Windows.Forms.Timer timer;

        private async void OrderList_Load(object sender, EventArgs e)
        {

            // Timer 설정(Timer를 통해 Client의 수를 비동기적으로 초기화)
            timer = new System.Windows.Forms.Timer();
            timer.Interval = 1000;
            timer.Tick += Timer_Tick;
            timer.Start();

            // Form이 로드될 때 Tcp/Ip Server On
            await con.TcpServerOn();

        }

        #region CatchFromClientData(DataTable 수신)
        private void CatchFromClientData(DataTable table)
        {
            /*
                수신 과정
                Client(DataTable) 송신 → Server(DataTable) 수신 → TemporaryTable 생성 → DataAdapter로 가져와서 DataGridView에 삽입
                → TemporaryTable Data 포맷 → Client(DataTable) 송신 → 반복
            */

            //통신으로 받은 datatable을 저장할 table
            TCP_IP.CreateTemporary();

            if (table == null)
            {
                Console.WriteLine("Data 없음");
            }
            else
            {
                Console.WriteLine($"Received DataTable with {table.Rows.Count} rows.");
                string itemNumber = null;
                string itemName = null;
                int itemCount = 0;
                int payment = 0;
                foreach (DataRow row in table.Rows)
                {
                    itemNumber = row["itemNumber"].ToString();
                    itemName = row["itemName"].ToString();
                    itemCount = Convert.ToInt32(row["itemCount"]);
                    payment = Convert.ToInt32(row["payment"]);

                    TCP_IP.TemporaryTCPInsert(itemNumber, itemName, itemCount, payment);
                }

                // DataGridView의 DataSource를 UI스레드에서 설정
                if(InvokeRequired)
                {
                    BeginInvoke(new Action(() =>
                    {
                        dataGridView1.DataSource = null;

                        data = TCP_IP.SelectTemporary();
                        dataGridView1.DataSource = data;
                        Console.WriteLine("InvokeRequired");

                        GroupBox clonedGroupBox = CloneGroupBox(groupBox);
                        this.Controls.Add(clonedGroupBox);
                    }));
                }
                else
                {
                    dataGridView1.DataSource = null;

                    data = TCP_IP.SelectTemporary();
                    dataGridView1.DataSource = data;
                    Console.WriteLine("Non InvokeRequired / datarow: "+data.Rows.Count);
                    if(data.Rows.Count>1)
                    {
                        GroupBox clonedGroupBox = CloneGroupBox(groupBox);
                        this.Controls.Add(clonedGroupBox);
                    }
                    Console.WriteLine("그룹박스 갯수: "+this.Controls.OfType<GroupBox>().Count());
                }
            }


            // Temporary Table 비우기
            TCP_IP.DeleteTemporary();
        }
        #endregion

        #region Client Count Update(클라이언트가 접속 시 비동기적으로 수를 UI에 업데이트)
        private void Timer_Tick(object sender, EventArgs e)
        {
            // 클라이언트 수를 비동기적으로 가져와 업데이트
            UpdateClientCount();
        }

        private void UpdateClientCount()
        {
            if(InvokeRequired)
            {
                BeginInvoke(new MethodInvoker(UpdateClientCount));
                return;
            }

            int clientCount = con.GetClientCount();
            waitingCon.Text = clientCount.ToString();
        }
        #endregion

        #region OrderList(Tcp/Ip로 DataTable을 받은 후 Temporary Table에 저장하고 DataGridView로 표시)
        public OrderList()
        {
            InitializeComponent();
        }
        #endregion

        #region Button Event(OrderList에서 각종 버튼의 예시 이벤트)
        // 출력 버튼 클릭 이벤트
        private void button3_Click(object sender, EventArgs e)
        {
            string list1 = string.Join(Environment.NewLine, listBox1.Items.Cast<string>());
            
            MessageBox.Show(list1,groupBox.Text);
        }
        // 호출 버튼 클릭 이벤트
        private void button2_Click(object sender, EventArgs e)
        {
            MessageBox.Show("1번 호출벨을 울립니다.");
            groupBox.Visible = false;
        }
        #endregion

        #region GroupBox in Button(그룹박스 안에 버튼 클릭 이벤트)
        private void CallButton_Click(object sender, EventArgs e)
        {
            MessageBox.Show("호출벨을 울립니다.");
            Button button = sender as Button;

            GroupBox groupBox = button.Parent as GroupBox;

            this.Controls.Remove(groupBox);
            
        }

        private void CancleButton_Click(Object sender, EventArgs e)
        {
            MessageBox.Show("주문을 취소합니다.");
        }
        
        private void PrintButton_Click(Object sender, EventArgs e)
        {
            MessageBox.Show("주문을 출력합니다.");
        }
        #endregion

        private DataTable GetDataGridViewForDataTable(DataGridView data)
        {
            if (data.DataSource is DataTable dataTable)
            {
                return dataTable;
            }
            else
            {
                throw new InvalidOperationException("DataGridView's DataSource is not a DataTable.");
            }
        }

        #region CloneControl(그룹박스 안에 있는 컨트롤 복사)
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

            data = GetDataGridViewForDataTable(dataGridView1);
            
            if(newControl is ListBox listbox)
            {
                listbox.Name = "Clone";
                listbox.Items.Add("------------------------------");
                foreach (DataRow row in data.Rows)
                {
                    string itemNumber = row["itemNumber"].ToString().Trim();
                    if (!itemNumber.Contains("-"))
                    {
                        //listbox.Items.Add("제품:" + row["itemName"].ToString());
                        listbox.Items.Add($"제품: {row["itemName"].ToString()}({row["itemCount"].ToString()})");
                    }
                    else
                    {
                        //listbox.Items.Add("옵션:" + row["itemName"].ToString());
                        if(row["itemName"].Equals("ICE") || row["itemName"].Equals("HOT"))
                        {
                            listbox.Items.Add($"옵션2: {row["itemName"].ToString()}");
                        }
                        else
                        {
                            listbox.Items.Add($"옵션1: {row["itemName"].ToString()}({row["itemCount"].ToString()})");
                        }
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
        #endregion

        #region CloneGroupBox(그릅박스를 복사)
        public GroupBox CloneGroupBox(GroupBox original)
        {
            // 새로운 GroupBox 생성
            GroupBox newgroupBox = new GroupBox();
            int GroupBoxNumber = this.Controls.OfType<GroupBox>().Count();

            // 원본 GroupBox의 속성을 새로운 GroupBox에 복사
            newgroupBox.Text = "Clone GroupBox";
            newgroupBox.Name = "Copy" + GroupBoxNumber;
            newgroupBox.Size = original.Size;

            newgroupBox.Location = new Point((original.Location.X + original.Width)*GroupBoxNumber+40, original.Location.Y);

            // 원본 groupBox의 컨트롤들을 복사
            foreach (Control control in original.Controls)
            {
                Control newControl = CloneControl(control);
                newControl.Parent = newgroupBox;

                newControl.Location = new Point(control.Location.X, control.Location.Y);
            }

            return newgroupBox;
        }
        #endregion

        // Server Tcp/Ip Connection Button
        private void button5_Click(object sender, EventArgs e)
        {
            Console.WriteLine("test");
        }

        private async void test(object sender, EventArgs e)
        {
            DataTable table = await con.GetDataTableFromClient();
            if (table == null)
            {
                DataTable Blank = new DataTable();
                CatchFromClientData(Blank);
            }
            else
            {
                CatchFromClientData(table);
            }
        }
    }
}
