namespace Kiosk.Order
{
    partial class Order_Manage
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle15 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle11 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle12 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle13 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle14 = new System.Windows.Forms.DataGridViewCellStyle();
            this.label1 = new System.Windows.Forms.Label();
            this.date = new System.Windows.Forms.Label();
            this.selected_menu = new System.Windows.Forms.DataGridView();
            this.Menu = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Count = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Price = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Etc = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.menulist = new System.Windows.Forms.TabControl();
            this.menu1 = new System.Windows.Forms.TabPage();
            this.coffee_hot_menu10 = new System.Windows.Forms.Button();
            this.coffee_hot_menu9 = new System.Windows.Forms.Button();
            this.coffee_hot_menu8 = new System.Windows.Forms.Button();
            this.coffee_hot_menu7 = new System.Windows.Forms.Button();
            this.coffee_hot_menu6 = new System.Windows.Forms.Button();
            this.coffee_hot_menu5 = new System.Windows.Forms.Button();
            this.coffee_hot_menu4 = new System.Windows.Forms.Button();
            this.coffee_hot_menu3 = new System.Windows.Forms.Button();
            this.coffee_hot_menu2 = new System.Windows.Forms.Button();
            this.coffee_hot_menu1 = new System.Windows.Forms.Button();
            this.coffee_ice_menu10 = new System.Windows.Forms.Button();
            this.coffee_ice_menu9 = new System.Windows.Forms.Button();
            this.coffee_ice_menu8 = new System.Windows.Forms.Button();
            this.coffee_ice_menu7 = new System.Windows.Forms.Button();
            this.coffee_ice_menu6 = new System.Windows.Forms.Button();
            this.coffee_ice_menu5 = new System.Windows.Forms.Button();
            this.coffee_ice_menu4 = new System.Windows.Forms.Button();
            this.coffee_ice_menu3 = new System.Windows.Forms.Button();
            this.coffee_ice_menu2 = new System.Windows.Forms.Button();
            this.coffee_ice_menu1 = new System.Windows.Forms.Button();
            this.menu2 = new System.Windows.Forms.TabPage();
            this.menu3 = new System.Windows.Forms.TabPage();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.option1 = new System.Windows.Forms.TabPage();
            this.op4 = new System.Windows.Forms.Button();
            this.op3 = new System.Windows.Forms.Button();
            this.op2 = new System.Windows.Forms.Button();
            this.op1 = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.payment = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.Mysql_tab = new System.Windows.Forms.TabPage();
            ((System.ComponentModel.ISupportInitialize)(this.selected_menu)).BeginInit();
            this.menulist.SuspendLayout();
            this.menu1.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.option1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(752, 18);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(61, 12);
            this.label1.TabIndex = 1;
            this.label1.Text = "영업일자 :";
            // 
            // date
            // 
            this.date.AutoSize = true;
            this.date.Location = new System.Drawing.Point(819, 18);
            this.date.Name = "date";
            this.date.Size = new System.Drawing.Size(38, 12);
            this.date.TabIndex = 2;
            this.date.Text = "label2";
            // 
            // selected_menu
            // 
            this.selected_menu.BackgroundColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.selected_menu.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.selected_menu.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Menu,
            this.Count,
            this.Price,
            this.Etc});
            dataGridViewCellStyle15.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle15.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle15.Font = new System.Drawing.Font("굴림", 9F, System.Drawing.FontStyle.Bold);
            dataGridViewCellStyle15.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle15.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle15.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle15.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.selected_menu.DefaultCellStyle = dataGridViewCellStyle15;
            this.selected_menu.GridColor = System.Drawing.SystemColors.ActiveBorder;
            this.selected_menu.Location = new System.Drawing.Point(43, 29);
            this.selected_menu.Name = "selected_menu";
            this.selected_menu.ReadOnly = true;
            this.selected_menu.RowHeadersVisible = false;
            this.selected_menu.RowHeadersWidth = 51;
            this.selected_menu.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.selected_menu.RowTemplate.Height = 23;
            this.selected_menu.Size = new System.Drawing.Size(344, 297);
            this.selected_menu.TabIndex = 0;
            this.selected_menu.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            // 
            // Menu
            // 
            dataGridViewCellStyle11.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.Menu.DefaultCellStyle = dataGridViewCellStyle11;
            this.Menu.HeaderText = "메뉴";
            this.Menu.MinimumWidth = 6;
            this.Menu.Name = "Menu";
            this.Menu.ReadOnly = true;
            this.Menu.Width = 140;
            // 
            // Count
            // 
            dataGridViewCellStyle12.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.Count.DefaultCellStyle = dataGridViewCellStyle12;
            this.Count.HeaderText = "수량";
            this.Count.MinimumWidth = 6;
            this.Count.Name = "Count";
            this.Count.ReadOnly = true;
            this.Count.Width = 60;
            // 
            // Price
            // 
            dataGridViewCellStyle13.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.Price.DefaultCellStyle = dataGridViewCellStyle13;
            this.Price.HeaderText = "금액";
            this.Price.MinimumWidth = 6;
            this.Price.Name = "Price";
            this.Price.ReadOnly = true;
            this.Price.Width = 80;
            // 
            // Etc
            // 
            dataGridViewCellStyle14.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.Etc.DefaultCellStyle = dataGridViewCellStyle14;
            this.Etc.HeaderText = "비고";
            this.Etc.MinimumWidth = 6;
            this.Etc.Name = "Etc";
            this.Etc.ReadOnly = true;
            this.Etc.Width = 60;
            // 
            // menulist
            // 
            this.menulist.Controls.Add(this.menu1);
            this.menulist.Controls.Add(this.menu2);
            this.menulist.Controls.Add(this.menu3);
            this.menulist.Controls.Add(this.Mysql_tab);
            this.menulist.ItemSize = new System.Drawing.Size(100, 25);
            this.menulist.Location = new System.Drawing.Point(464, 29);
            this.menulist.Name = "menulist";
            this.menulist.SelectedIndex = 0;
            this.menulist.Size = new System.Drawing.Size(457, 403);
            this.menulist.SizeMode = System.Windows.Forms.TabSizeMode.FillToRight;
            this.menulist.TabIndex = 1;
            // 
            // menu1
            // 
            this.menu1.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.menu1.Controls.Add(this.coffee_hot_menu10);
            this.menu1.Controls.Add(this.coffee_hot_menu9);
            this.menu1.Controls.Add(this.coffee_hot_menu8);
            this.menu1.Controls.Add(this.coffee_hot_menu7);
            this.menu1.Controls.Add(this.coffee_hot_menu6);
            this.menu1.Controls.Add(this.coffee_hot_menu5);
            this.menu1.Controls.Add(this.coffee_hot_menu4);
            this.menu1.Controls.Add(this.coffee_hot_menu3);
            this.menu1.Controls.Add(this.coffee_hot_menu2);
            this.menu1.Controls.Add(this.coffee_hot_menu1);
            this.menu1.Controls.Add(this.coffee_ice_menu10);
            this.menu1.Controls.Add(this.coffee_ice_menu9);
            this.menu1.Controls.Add(this.coffee_ice_menu8);
            this.menu1.Controls.Add(this.coffee_ice_menu7);
            this.menu1.Controls.Add(this.coffee_ice_menu6);
            this.menu1.Controls.Add(this.coffee_ice_menu5);
            this.menu1.Controls.Add(this.coffee_ice_menu4);
            this.menu1.Controls.Add(this.coffee_ice_menu3);
            this.menu1.Controls.Add(this.coffee_ice_menu2);
            this.menu1.Controls.Add(this.coffee_ice_menu1);
            this.menu1.Location = new System.Drawing.Point(4, 29);
            this.menu1.Name = "menu1";
            this.menu1.Padding = new System.Windows.Forms.Padding(3, 3, 3, 3);
            this.menu1.Size = new System.Drawing.Size(449, 370);
            this.menu1.TabIndex = 3;
            this.menu1.Text = "커피";
            // 
            // coffee_hot_menu10
            // 
            this.coffee_hot_menu10.BackColor = System.Drawing.Color.Sienna;
            this.coffee_hot_menu10.ForeColor = System.Drawing.SystemColors.ControlText;
            this.coffee_hot_menu10.Location = new System.Drawing.Point(368, 289);
            this.coffee_hot_menu10.Name = "coffee_hot_menu10";
            this.coffee_hot_menu10.Size = new System.Drawing.Size(75, 75);
            this.coffee_hot_menu10.TabIndex = 19;
            this.coffee_hot_menu10.UseVisualStyleBackColor = false;
            // 
            // coffee_hot_menu9
            // 
            this.coffee_hot_menu9.BackColor = System.Drawing.Color.Sienna;
            this.coffee_hot_menu9.ForeColor = System.Drawing.SystemColors.ControlText;
            this.coffee_hot_menu9.Location = new System.Drawing.Point(278, 289);
            this.coffee_hot_menu9.Name = "coffee_hot_menu9";
            this.coffee_hot_menu9.Size = new System.Drawing.Size(75, 75);
            this.coffee_hot_menu9.TabIndex = 18;
            this.coffee_hot_menu9.UseVisualStyleBackColor = false;
            // 
            // coffee_hot_menu8
            // 
            this.coffee_hot_menu8.BackColor = System.Drawing.Color.Sienna;
            this.coffee_hot_menu8.ForeColor = System.Drawing.SystemColors.ControlText;
            this.coffee_hot_menu8.Location = new System.Drawing.Point(186, 289);
            this.coffee_hot_menu8.Name = "coffee_hot_menu8";
            this.coffee_hot_menu8.Size = new System.Drawing.Size(75, 75);
            this.coffee_hot_menu8.TabIndex = 17;
            this.coffee_hot_menu8.UseVisualStyleBackColor = false;
            // 
            // coffee_hot_menu7
            // 
            this.coffee_hot_menu7.BackColor = System.Drawing.Color.Sienna;
            this.coffee_hot_menu7.ForeColor = System.Drawing.SystemColors.ControlText;
            this.coffee_hot_menu7.Location = new System.Drawing.Point(97, 289);
            this.coffee_hot_menu7.Name = "coffee_hot_menu7";
            this.coffee_hot_menu7.Size = new System.Drawing.Size(75, 75);
            this.coffee_hot_menu7.TabIndex = 16;
            this.coffee_hot_menu7.UseVisualStyleBackColor = false;
            // 
            // coffee_hot_menu6
            // 
            this.coffee_hot_menu6.BackColor = System.Drawing.Color.Sienna;
            this.coffee_hot_menu6.ForeColor = System.Drawing.SystemColors.ControlText;
            this.coffee_hot_menu6.Location = new System.Drawing.Point(6, 289);
            this.coffee_hot_menu6.Name = "coffee_hot_menu6";
            this.coffee_hot_menu6.Size = new System.Drawing.Size(75, 75);
            this.coffee_hot_menu6.TabIndex = 15;
            this.coffee_hot_menu6.UseVisualStyleBackColor = false;
            // 
            // coffee_hot_menu5
            // 
            this.coffee_hot_menu5.BackColor = System.Drawing.Color.Sienna;
            this.coffee_hot_menu5.ForeColor = System.Drawing.SystemColors.ControlText;
            this.coffee_hot_menu5.Location = new System.Drawing.Point(368, 208);
            this.coffee_hot_menu5.Name = "coffee_hot_menu5";
            this.coffee_hot_menu5.Size = new System.Drawing.Size(75, 75);
            this.coffee_hot_menu5.TabIndex = 14;
            this.coffee_hot_menu5.Text = "마끼아또(HOT)";
            this.coffee_hot_menu5.UseVisualStyleBackColor = false;
            this.coffee_hot_menu5.Click += new System.EventHandler(this.coffee_hot_menu5_Click);
            // 
            // coffee_hot_menu4
            // 
            this.coffee_hot_menu4.BackColor = System.Drawing.Color.Sienna;
            this.coffee_hot_menu4.ForeColor = System.Drawing.SystemColors.ControlText;
            this.coffee_hot_menu4.Location = new System.Drawing.Point(278, 208);
            this.coffee_hot_menu4.Name = "coffee_hot_menu4";
            this.coffee_hot_menu4.Size = new System.Drawing.Size(75, 75);
            this.coffee_hot_menu4.TabIndex = 13;
            this.coffee_hot_menu4.Text = "카페모카(HOT)";
            this.coffee_hot_menu4.UseVisualStyleBackColor = false;
            this.coffee_hot_menu4.Click += new System.EventHandler(this.coffee_hot_menu4_Click);
            // 
            // coffee_hot_menu3
            // 
            this.coffee_hot_menu3.BackColor = System.Drawing.Color.Sienna;
            this.coffee_hot_menu3.ForeColor = System.Drawing.SystemColors.ControlText;
            this.coffee_hot_menu3.Location = new System.Drawing.Point(186, 208);
            this.coffee_hot_menu3.Name = "coffee_hot_menu3";
            this.coffee_hot_menu3.Size = new System.Drawing.Size(75, 75);
            this.coffee_hot_menu3.TabIndex = 12;
            this.coffee_hot_menu3.Text = "카푸치노(HOT)";
            this.coffee_hot_menu3.UseVisualStyleBackColor = false;
            this.coffee_hot_menu3.Click += new System.EventHandler(this.coffee_hot_menu3_Click);
            // 
            // coffee_hot_menu2
            // 
            this.coffee_hot_menu2.BackColor = System.Drawing.Color.Sienna;
            this.coffee_hot_menu2.ForeColor = System.Drawing.SystemColors.ControlText;
            this.coffee_hot_menu2.Location = new System.Drawing.Point(97, 208);
            this.coffee_hot_menu2.Name = "coffee_hot_menu2";
            this.coffee_hot_menu2.Size = new System.Drawing.Size(75, 75);
            this.coffee_hot_menu2.TabIndex = 11;
            this.coffee_hot_menu2.Text = "카페라떼(HOT)";
            this.coffee_hot_menu2.UseVisualStyleBackColor = false;
            this.coffee_hot_menu2.Click += new System.EventHandler(this.coffee_hot_menu2_Click);
            // 
            // coffee_hot_menu1
            // 
            this.coffee_hot_menu1.BackColor = System.Drawing.Color.Sienna;
            this.coffee_hot_menu1.ForeColor = System.Drawing.SystemColors.ControlText;
            this.coffee_hot_menu1.Location = new System.Drawing.Point(6, 208);
            this.coffee_hot_menu1.Name = "coffee_hot_menu1";
            this.coffee_hot_menu1.Size = new System.Drawing.Size(75, 75);
            this.coffee_hot_menu1.TabIndex = 10;
            this.coffee_hot_menu1.Text = "아메리카노(HOT)";
            this.coffee_hot_menu1.UseVisualStyleBackColor = false;
            this.coffee_hot_menu1.Click += new System.EventHandler(this.coffee_hot_menu1_Click);
            // 
            // coffee_ice_menu10
            // 
            this.coffee_ice_menu10.BackColor = System.Drawing.Color.DodgerBlue;
            this.coffee_ice_menu10.ForeColor = System.Drawing.SystemColors.ControlText;
            this.coffee_ice_menu10.Location = new System.Drawing.Point(368, 87);
            this.coffee_ice_menu10.Name = "coffee_ice_menu10";
            this.coffee_ice_menu10.Size = new System.Drawing.Size(75, 75);
            this.coffee_ice_menu10.TabIndex = 9;
            this.coffee_ice_menu10.UseVisualStyleBackColor = false;
            // 
            // coffee_ice_menu9
            // 
            this.coffee_ice_menu9.BackColor = System.Drawing.Color.DodgerBlue;
            this.coffee_ice_menu9.ForeColor = System.Drawing.SystemColors.ControlText;
            this.coffee_ice_menu9.Location = new System.Drawing.Point(278, 87);
            this.coffee_ice_menu9.Name = "coffee_ice_menu9";
            this.coffee_ice_menu9.Size = new System.Drawing.Size(75, 75);
            this.coffee_ice_menu9.TabIndex = 8;
            this.coffee_ice_menu9.UseVisualStyleBackColor = false;
            // 
            // coffee_ice_menu8
            // 
            this.coffee_ice_menu8.BackColor = System.Drawing.Color.DodgerBlue;
            this.coffee_ice_menu8.ForeColor = System.Drawing.SystemColors.ControlText;
            this.coffee_ice_menu8.Location = new System.Drawing.Point(186, 87);
            this.coffee_ice_menu8.Name = "coffee_ice_menu8";
            this.coffee_ice_menu8.Size = new System.Drawing.Size(75, 75);
            this.coffee_ice_menu8.TabIndex = 7;
            this.coffee_ice_menu8.UseVisualStyleBackColor = false;
            // 
            // coffee_ice_menu7
            // 
            this.coffee_ice_menu7.BackColor = System.Drawing.Color.DodgerBlue;
            this.coffee_ice_menu7.ForeColor = System.Drawing.SystemColors.ControlText;
            this.coffee_ice_menu7.Location = new System.Drawing.Point(97, 87);
            this.coffee_ice_menu7.Name = "coffee_ice_menu7";
            this.coffee_ice_menu7.Size = new System.Drawing.Size(75, 75);
            this.coffee_ice_menu7.TabIndex = 6;
            this.coffee_ice_menu7.UseVisualStyleBackColor = false;
            // 
            // coffee_ice_menu6
            // 
            this.coffee_ice_menu6.BackColor = System.Drawing.Color.DodgerBlue;
            this.coffee_ice_menu6.ForeColor = System.Drawing.SystemColors.ControlText;
            this.coffee_ice_menu6.Location = new System.Drawing.Point(6, 87);
            this.coffee_ice_menu6.Name = "coffee_ice_menu6";
            this.coffee_ice_menu6.Size = new System.Drawing.Size(75, 75);
            this.coffee_ice_menu6.TabIndex = 5;
            this.coffee_ice_menu6.UseVisualStyleBackColor = false;
            // 
            // coffee_ice_menu5
            // 
            this.coffee_ice_menu5.BackColor = System.Drawing.Color.DodgerBlue;
            this.coffee_ice_menu5.ForeColor = System.Drawing.SystemColors.ControlText;
            this.coffee_ice_menu5.Location = new System.Drawing.Point(368, 6);
            this.coffee_ice_menu5.Name = "coffee_ice_menu5";
            this.coffee_ice_menu5.Size = new System.Drawing.Size(75, 75);
            this.coffee_ice_menu5.TabIndex = 4;
            this.coffee_ice_menu5.Text = "마끼아또(ICE)";
            this.coffee_ice_menu5.UseVisualStyleBackColor = false;
            this.coffee_ice_menu5.Click += new System.EventHandler(this.coffee_ice_menu5_Click);
            // 
            // coffee_ice_menu4
            // 
            this.coffee_ice_menu4.BackColor = System.Drawing.Color.DodgerBlue;
            this.coffee_ice_menu4.ForeColor = System.Drawing.SystemColors.ControlText;
            this.coffee_ice_menu4.Location = new System.Drawing.Point(278, 6);
            this.coffee_ice_menu4.Name = "coffee_ice_menu4";
            this.coffee_ice_menu4.Size = new System.Drawing.Size(75, 75);
            this.coffee_ice_menu4.TabIndex = 3;
            this.coffee_ice_menu4.Text = "카페모카(ICE)";
            this.coffee_ice_menu4.UseVisualStyleBackColor = false;
            this.coffee_ice_menu4.Click += new System.EventHandler(this.coffee_ice_menu4_Click);
            // 
            // coffee_ice_menu3
            // 
            this.coffee_ice_menu3.BackColor = System.Drawing.Color.DodgerBlue;
            this.coffee_ice_menu3.ForeColor = System.Drawing.SystemColors.ControlText;
            this.coffee_ice_menu3.Location = new System.Drawing.Point(186, 6);
            this.coffee_ice_menu3.Name = "coffee_ice_menu3";
            this.coffee_ice_menu3.Size = new System.Drawing.Size(75, 75);
            this.coffee_ice_menu3.TabIndex = 2;
            this.coffee_ice_menu3.Text = "카푸치노(ICE)";
            this.coffee_ice_menu3.UseVisualStyleBackColor = false;
            this.coffee_ice_menu3.Click += new System.EventHandler(this.coffee_ice_menu3_Click);
            // 
            // coffee_ice_menu2
            // 
            this.coffee_ice_menu2.BackColor = System.Drawing.Color.DodgerBlue;
            this.coffee_ice_menu2.ForeColor = System.Drawing.SystemColors.ControlText;
            this.coffee_ice_menu2.Location = new System.Drawing.Point(97, 6);
            this.coffee_ice_menu2.Name = "coffee_ice_menu2";
            this.coffee_ice_menu2.Size = new System.Drawing.Size(75, 75);
            this.coffee_ice_menu2.TabIndex = 1;
            this.coffee_ice_menu2.Text = "카페라떼(ICE)";
            this.coffee_ice_menu2.UseVisualStyleBackColor = false;
            this.coffee_ice_menu2.Click += new System.EventHandler(this.coffee_ice_menu2_Click);
            // 
            // coffee_ice_menu1
            // 
            this.coffee_ice_menu1.BackColor = System.Drawing.Color.DodgerBlue;
            this.coffee_ice_menu1.ForeColor = System.Drawing.SystemColors.ControlText;
            this.coffee_ice_menu1.Location = new System.Drawing.Point(6, 6);
            this.coffee_ice_menu1.Name = "coffee_ice_menu1";
            this.coffee_ice_menu1.Size = new System.Drawing.Size(75, 75);
            this.coffee_ice_menu1.TabIndex = 0;
            this.coffee_ice_menu1.Text = "아메리카노(ICE)";
            this.coffee_ice_menu1.UseVisualStyleBackColor = false;
            this.coffee_ice_menu1.Click += new System.EventHandler(this.button1_Click);
            // 
            // menu2
            // 
            this.menu2.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.menu2.Location = new System.Drawing.Point(4, 29);
            this.menu2.Name = "menu2";
            this.menu2.Padding = new System.Windows.Forms.Padding(3, 3, 3, 3);
            this.menu2.Size = new System.Drawing.Size(449, 370);
            this.menu2.TabIndex = 1;
            this.menu2.Text = "에이드";
            // 
            // menu3
            // 
            this.menu3.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.menu3.Location = new System.Drawing.Point(4, 29);
            this.menu3.Name = "menu3";
            this.menu3.Padding = new System.Windows.Forms.Padding(3, 3, 3, 3);
            this.menu3.Size = new System.Drawing.Size(449, 370);
            this.menu3.TabIndex = 2;
            this.menu3.Text = "디저트";
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.option1);
            this.tabControl1.Location = new System.Drawing.Point(468, 439);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(453, 127);
            this.tabControl1.TabIndex = 2;
            // 
            // option1
            // 
            this.option1.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.option1.Controls.Add(this.op4);
            this.option1.Controls.Add(this.op3);
            this.option1.Controls.Add(this.op2);
            this.option1.Controls.Add(this.op1);
            this.option1.Location = new System.Drawing.Point(4, 22);
            this.option1.Name = "option1";
            this.option1.Padding = new System.Windows.Forms.Padding(3, 3, 3, 3);
            this.option1.Size = new System.Drawing.Size(445, 101);
            this.option1.TabIndex = 0;
            this.option1.Text = "옵션";
            // 
            // op4
            // 
            this.op4.BackColor = System.Drawing.Color.DarkViolet;
            this.op4.ForeColor = System.Drawing.SystemColors.ControlText;
            this.op4.Location = new System.Drawing.Point(353, 14);
            this.op4.Name = "op4";
            this.op4.Size = new System.Drawing.Size(75, 75);
            this.op4.TabIndex = 14;
            this.op4.UseVisualStyleBackColor = false;
            // 
            // op3
            // 
            this.op3.BackColor = System.Drawing.Color.DarkViolet;
            this.op3.ForeColor = System.Drawing.SystemColors.ControlText;
            this.op3.Location = new System.Drawing.Point(245, 14);
            this.op3.Name = "op3";
            this.op3.Size = new System.Drawing.Size(75, 75);
            this.op3.TabIndex = 13;
            this.op3.UseVisualStyleBackColor = false;
            // 
            // op2
            // 
            this.op2.BackColor = System.Drawing.Color.DarkViolet;
            this.op2.ForeColor = System.Drawing.SystemColors.ControlText;
            this.op2.Location = new System.Drawing.Point(128, 14);
            this.op2.Name = "op2";
            this.op2.Size = new System.Drawing.Size(75, 75);
            this.op2.TabIndex = 12;
            this.op2.Text = "연하게";
            this.op2.UseVisualStyleBackColor = false;
            // 
            // op1
            // 
            this.op1.BackColor = System.Drawing.Color.DarkViolet;
            this.op1.ForeColor = System.Drawing.SystemColors.ControlText;
            this.op1.Location = new System.Drawing.Point(11, 14);
            this.op1.Name = "op1";
            this.op1.Size = new System.Drawing.Size(75, 75);
            this.op1.TabIndex = 11;
            this.op1.Text = "샷추가";
            this.op1.UseVisualStyleBackColor = false;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("굴림", 14F, System.Drawing.FontStyle.Bold);
            this.label2.Location = new System.Drawing.Point(41, 344);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(137, 19);
            this.label2.TabIndex = 3;
            this.label2.Text = "총 결제 금액: ";
            // 
            // payment
            // 
            this.payment.AutoSize = true;
            this.payment.Font = new System.Drawing.Font("굴림", 14F, System.Drawing.FontStyle.Bold);
            this.payment.Location = new System.Drawing.Point(232, 344);
            this.payment.Name = "payment";
            this.payment.Size = new System.Drawing.Size(20, 19);
            this.payment.TabIndex = 9;
            this.payment.Text = "0";
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.LightGray;
            this.button1.Font = new System.Drawing.Font("굴림", 20F, System.Drawing.FontStyle.Bold);
            this.button1.ForeColor = System.Drawing.SystemColors.ControlText;
            this.button1.Location = new System.Drawing.Point(43, 378);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(148, 54);
            this.button1.TabIndex = 12;
            this.button1.Text = "현금";
            this.button1.UseVisualStyleBackColor = false;
            // 
            // button2
            // 
            this.button2.BackColor = System.Drawing.Color.LightGray;
            this.button2.Font = new System.Drawing.Font("굴림", 20F, System.Drawing.FontStyle.Bold);
            this.button2.ForeColor = System.Drawing.SystemColors.ControlText;
            this.button2.Location = new System.Drawing.Point(235, 378);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(151, 54);
            this.button2.TabIndex = 13;
            this.button2.Text = "카드";
            this.button2.UseVisualStyleBackColor = false;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.button2);
            this.groupBox1.Controls.Add(this.button1);
            this.groupBox1.Controls.Add(this.payment);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.tabControl1);
            this.groupBox1.Controls.Add(this.menulist);
            this.groupBox1.Controls.Add(this.selected_menu);
            this.groupBox1.Font = new System.Drawing.Font("굴림", 9F, System.Drawing.FontStyle.Bold);
            this.groupBox1.Location = new System.Drawing.Point(27, 33);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(950, 572);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "주문 관리";
            this.groupBox1.Enter += new System.EventHandler(this.groupBox1_Enter);
            // 
            // Mysql_tab
            // 
            this.Mysql_tab.Location = new System.Drawing.Point(4, 29);
            this.Mysql_tab.Name = "Mysql_tab";
            this.Mysql_tab.Padding = new System.Windows.Forms.Padding(3);
            this.Mysql_tab.Size = new System.Drawing.Size(449, 370);
            this.Mysql_tab.TabIndex = 4;
            this.Mysql_tab.Text = "Mysql";
            this.Mysql_tab.UseVisualStyleBackColor = true;
            // 
            // Order_Manage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.ClientSize = new System.Drawing.Size(1007, 628);
            this.Controls.Add(this.date);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.groupBox1);
            this.Name = "Order_Manage";
            this.Text = "Order_Manage";
            this.Load += new System.EventHandler(this.Order_Manage_Load);
            ((System.ComponentModel.ISupportInitialize)(this.selected_menu)).EndInit();
            this.menulist.ResumeLayout(false);
            this.menu1.ResumeLayout(false);
            this.tabControl1.ResumeLayout(false);
            this.option1.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label date;
        private System.Windows.Forms.DataGridView selected_menu;
        private System.Windows.Forms.DataGridViewTextBoxColumn Menu;
        private System.Windows.Forms.DataGridViewTextBoxColumn Count;
        private System.Windows.Forms.DataGridViewTextBoxColumn Price;
        private System.Windows.Forms.DataGridViewTextBoxColumn Etc;
        private System.Windows.Forms.TabControl menulist;
        private System.Windows.Forms.TabPage menu1;
        private System.Windows.Forms.Button coffee_hot_menu10;
        private System.Windows.Forms.Button coffee_hot_menu9;
        private System.Windows.Forms.Button coffee_hot_menu8;
        private System.Windows.Forms.Button coffee_hot_menu7;
        private System.Windows.Forms.Button coffee_hot_menu6;
        private System.Windows.Forms.Button coffee_hot_menu5;
        private System.Windows.Forms.Button coffee_hot_menu4;
        private System.Windows.Forms.Button coffee_hot_menu3;
        private System.Windows.Forms.Button coffee_hot_menu2;
        private System.Windows.Forms.Button coffee_hot_menu1;
        private System.Windows.Forms.Button coffee_ice_menu10;
        private System.Windows.Forms.Button coffee_ice_menu9;
        private System.Windows.Forms.Button coffee_ice_menu8;
        private System.Windows.Forms.Button coffee_ice_menu7;
        private System.Windows.Forms.Button coffee_ice_menu6;
        private System.Windows.Forms.Button coffee_ice_menu5;
        private System.Windows.Forms.Button coffee_ice_menu4;
        private System.Windows.Forms.Button coffee_ice_menu3;
        private System.Windows.Forms.Button coffee_ice_menu2;
        private System.Windows.Forms.Button coffee_ice_menu1;
        private System.Windows.Forms.TabPage menu2;
        private System.Windows.Forms.TabPage menu3;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage option1;
        private System.Windows.Forms.Button op4;
        private System.Windows.Forms.Button op3;
        private System.Windows.Forms.Button op2;
        private System.Windows.Forms.Button op1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label payment;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TabPage Mysql_tab;
    }
}