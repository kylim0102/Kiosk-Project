namespace Kiosk.ItemManage.ItemPanel
{
    partial class Category_Manage
    {
        /// <summary> 
        /// 필수 디자이너 변수입니다.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// 사용 중인 모든 리소스를 정리합니다.
        /// </summary>
        /// <param name="disposing">관리되는 리소스를 삭제해야 하면 true이고, 그렇지 않으면 false입니다.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region 구성 요소 디자이너에서 생성한 코드

        /// <summary> 
        /// 디자이너 지원에 필요한 메서드입니다. 
        /// 이 메서드의 내용을 코드 편집기로 수정하지 마세요.
        /// </summary>
        private void InitializeComponent()
        {
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.Category_register = new System.Windows.Forms.TabPage();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.Reset = new System.Windows.Forms.Button();
            this.Register = new System.Windows.Forms.Button();
            this.Category_code = new System.Windows.Forms.TextBox();
            this.Category_name = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.Category_list = new System.Windows.Forms.TabPage();
            this.button1 = new System.Windows.Forms.Button();
            this.category_tbl_list = new System.Windows.Forms.DataGridView();
            this.category_tb_idx = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.category_tb_code = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.category_tb_name = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.category_tb_regdate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Category_modify = new System.Windows.Forms.TabPage();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.category_manage_idx = new System.Windows.Forms.TextBox();
            this.category_manage_code = new System.Windows.Forms.TextBox();
            this.category_manage_name = new System.Windows.Forms.TextBox();
            this.category_manage_modify = new System.Windows.Forms.Button();
            this.category_manage_delete = new System.Windows.Forms.Button();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.category_manage_list = new System.Windows.Forms.ListBox();
            this.category_manage_reset = new System.Windows.Forms.Button();
            this.tabControl1.SuspendLayout();
            this.Category_register.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.Category_list.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.category_tbl_list)).BeginInit();
            this.Category_modify.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.Category_register);
            this.tabControl1.Controls.Add(this.Category_list);
            this.tabControl1.Controls.Add(this.Category_modify);
            this.tabControl1.Location = new System.Drawing.Point(3, 3);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(708, 403);
            this.tabControl1.TabIndex = 0;
            // 
            // Category_register
            // 
            this.Category_register.Controls.Add(this.groupBox1);
            this.Category_register.Font = new System.Drawing.Font("굴림", 9F);
            this.Category_register.Location = new System.Drawing.Point(4, 22);
            this.Category_register.Name = "Category_register";
            this.Category_register.Padding = new System.Windows.Forms.Padding(3, 3, 3, 3);
            this.Category_register.Size = new System.Drawing.Size(700, 377);
            this.Category_register.TabIndex = 0;
            this.Category_register.Text = "등록";
            this.Category_register.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.groupBox2);
            this.groupBox1.Font = new System.Drawing.Font("굴림", 12F);
            this.groupBox1.Location = new System.Drawing.Point(132, 6);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(413, 365);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Register";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.Reset);
            this.groupBox2.Controls.Add(this.Register);
            this.groupBox2.Controls.Add(this.Category_code);
            this.groupBox2.Controls.Add(this.Category_name);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.ForeColor = System.Drawing.SystemColors.ControlText;
            this.groupBox2.Location = new System.Drawing.Point(27, 100);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(360, 207);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            // 
            // Reset
            // 
            this.Reset.Font = new System.Drawing.Font("굴림", 9F);
            this.Reset.Location = new System.Drawing.Point(229, 156);
            this.Reset.Name = "Reset";
            this.Reset.Size = new System.Drawing.Size(75, 23);
            this.Reset.TabIndex = 11;
            this.Reset.Text = "리셋";
            this.Reset.UseVisualStyleBackColor = true;
            this.Reset.Click += new System.EventHandler(this.Reset_Click);
            // 
            // Register
            // 
            this.Register.Font = new System.Drawing.Font("굴림", 9F);
            this.Register.Location = new System.Drawing.Point(83, 156);
            this.Register.Name = "Register";
            this.Register.Size = new System.Drawing.Size(75, 23);
            this.Register.TabIndex = 10;
            this.Register.Text = "등록";
            this.Register.UseVisualStyleBackColor = true;
            this.Register.Click += new System.EventHandler(this.Register_Click);
            // 
            // Category_code
            // 
            this.Category_code.Font = new System.Drawing.Font("굴림", 9F);
            this.Category_code.Location = new System.Drawing.Point(109, 49);
            this.Category_code.Name = "Category_code";
            this.Category_code.ReadOnly = true;
            this.Category_code.Size = new System.Drawing.Size(220, 21);
            this.Category_code.TabIndex = 9;
            // 
            // Category_name
            // 
            this.Category_name.Font = new System.Drawing.Font("굴림", 9F);
            this.Category_name.Location = new System.Drawing.Point(109, 99);
            this.Category_name.Name = "Category_name";
            this.Category_name.Size = new System.Drawing.Size(220, 21);
            this.Category_name.TabIndex = 8;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("굴림", 9F);
            this.label2.Location = new System.Drawing.Point(25, 54);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 12);
            this.label2.TabIndex = 7;
            this.label2.Text = "분류코드";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("굴림", 9F);
            this.label1.Location = new System.Drawing.Point(41, 103);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(41, 12);
            this.label1.TabIndex = 6;
            this.label1.Text = "분류명";
            // 
            // Category_list
            // 
            this.Category_list.Controls.Add(this.button1);
            this.Category_list.Controls.Add(this.category_tbl_list);
            this.Category_list.Location = new System.Drawing.Point(4, 22);
            this.Category_list.Name = "Category_list";
            this.Category_list.Padding = new System.Windows.Forms.Padding(3, 3, 3, 3);
            this.Category_list.Size = new System.Drawing.Size(700, 377);
            this.Category_list.TabIndex = 1;
            this.Category_list.Text = "목록";
            this.Category_list.UseVisualStyleBackColor = true;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(626, 9);
            this.button1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(69, 43);
            this.button1.TabIndex = 1;
            this.button1.Text = "새로고침";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // category_tbl_list
            // 
            this.category_tbl_list.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.category_tbl_list.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.category_tb_idx,
            this.category_tb_code,
            this.category_tb_name,
            this.category_tb_regdate});
            this.category_tbl_list.Location = new System.Drawing.Point(5, 6);
            this.category_tbl_list.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.category_tbl_list.Name = "category_tbl_list";
            this.category_tbl_list.ReadOnly = true;
            this.category_tbl_list.RowHeadersVisible = false;
            this.category_tbl_list.RowHeadersWidth = 51;
            this.category_tbl_list.RowTemplate.Height = 27;
            this.category_tbl_list.Size = new System.Drawing.Size(693, 369);
            this.category_tbl_list.TabIndex = 0;
            this.category_tbl_list.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.category_tbl_list_CellContentClick);
            // 
            // category_tb_idx
            // 
            this.category_tb_idx.DataPropertyName = "NO";
            this.category_tb_idx.HeaderText = "NO";
            this.category_tb_idx.MinimumWidth = 6;
            this.category_tb_idx.Name = "category_tb_idx";
            this.category_tb_idx.ReadOnly = true;
            this.category_tb_idx.Width = 150;
            // 
            // category_tb_code
            // 
            this.category_tb_code.DataPropertyName = "CODE";
            this.category_tb_code.HeaderText = "CODE";
            this.category_tb_code.MinimumWidth = 6;
            this.category_tb_code.Name = "category_tb_code";
            this.category_tb_code.ReadOnly = true;
            this.category_tb_code.Width = 150;
            // 
            // category_tb_name
            // 
            this.category_tb_name.DataPropertyName = "NAME";
            this.category_tb_name.HeaderText = "NAME";
            this.category_tb_name.MinimumWidth = 6;
            this.category_tb_name.Name = "category_tb_name";
            this.category_tb_name.ReadOnly = true;
            this.category_tb_name.Width = 150;
            // 
            // category_tb_regdate
            // 
            this.category_tb_regdate.DataPropertyName = "DATE";
            this.category_tb_regdate.HeaderText = "DATE";
            this.category_tb_regdate.MinimumWidth = 6;
            this.category_tb_regdate.Name = "category_tb_regdate";
            this.category_tb_regdate.ReadOnly = true;
            this.category_tb_regdate.Width = 150;
            // 
            // Category_modify
            // 
            this.Category_modify.Controls.Add(this.groupBox4);
            this.Category_modify.Controls.Add(this.groupBox3);
            this.Category_modify.Location = new System.Drawing.Point(4, 22);
            this.Category_modify.Name = "Category_modify";
            this.Category_modify.Size = new System.Drawing.Size(700, 377);
            this.Category_modify.TabIndex = 2;
            this.Category_modify.Text = "관리";
            this.Category_modify.UseVisualStyleBackColor = true;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.category_manage_delete);
            this.groupBox3.Controls.Add(this.category_manage_modify);
            this.groupBox3.Controls.Add(this.category_manage_name);
            this.groupBox3.Controls.Add(this.category_manage_code);
            this.groupBox3.Controls.Add(this.category_manage_idx);
            this.groupBox3.Controls.Add(this.label5);
            this.groupBox3.Controls.Add(this.label4);
            this.groupBox3.Controls.Add(this.label3);
            this.groupBox3.Location = new System.Drawing.Point(356, 13);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(328, 352);
            this.groupBox3.TabIndex = 1;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "수정/삭제";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(40, 131);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(29, 12);
            this.label3.TabIndex = 0;
            this.label3.Text = "코드";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(40, 174);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(29, 12);
            this.label4.TabIndex = 1;
            this.label4.Text = "이름";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(40, 91);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(41, 12);
            this.label5.TabIndex = 2;
            this.label5.Text = "인덱스";
            // 
            // category_manage_idx
            // 
            this.category_manage_idx.Location = new System.Drawing.Point(108, 85);
            this.category_manage_idx.Name = "category_manage_idx";
            this.category_manage_idx.ReadOnly = true;
            this.category_manage_idx.Size = new System.Drawing.Size(177, 21);
            this.category_manage_idx.TabIndex = 3;
            // 
            // category_manage_code
            // 
            this.category_manage_code.Location = new System.Drawing.Point(108, 128);
            this.category_manage_code.Name = "category_manage_code";
            this.category_manage_code.ReadOnly = true;
            this.category_manage_code.Size = new System.Drawing.Size(177, 21);
            this.category_manage_code.TabIndex = 4;
            // 
            // category_manage_name
            // 
            this.category_manage_name.Location = new System.Drawing.Point(108, 171);
            this.category_manage_name.Name = "category_manage_name";
            this.category_manage_name.Size = new System.Drawing.Size(177, 21);
            this.category_manage_name.TabIndex = 5;
            // 
            // category_manage_modify
            // 
            this.category_manage_modify.Location = new System.Drawing.Point(70, 222);
            this.category_manage_modify.Name = "category_manage_modify";
            this.category_manage_modify.Size = new System.Drawing.Size(75, 23);
            this.category_manage_modify.TabIndex = 6;
            this.category_manage_modify.Text = "수정";
            this.category_manage_modify.UseVisualStyleBackColor = true;
            this.category_manage_modify.Click += new System.EventHandler(this.category_manage_modify_Click);
            // 
            // category_manage_delete
            // 
            this.category_manage_delete.Location = new System.Drawing.Point(188, 222);
            this.category_manage_delete.Name = "category_manage_delete";
            this.category_manage_delete.Size = new System.Drawing.Size(75, 23);
            this.category_manage_delete.TabIndex = 7;
            this.category_manage_delete.Text = "삭제";
            this.category_manage_delete.UseVisualStyleBackColor = true;
            this.category_manage_delete.Click += new System.EventHandler(this.category_manage_delete_Click);
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.category_manage_reset);
            this.groupBox4.Controls.Add(this.category_manage_list);
            this.groupBox4.Location = new System.Drawing.Point(14, 13);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(324, 352);
            this.groupBox4.TabIndex = 2;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "정보";
            // 
            // category_manage_list
            // 
            this.category_manage_list.Font = new System.Drawing.Font("굴림", 14F);
            this.category_manage_list.FormattingEnabled = true;
            this.category_manage_list.ItemHeight = 19;
            this.category_manage_list.Location = new System.Drawing.Point(12, 24);
            this.category_manage_list.Name = "category_manage_list";
            this.category_manage_list.Size = new System.Drawing.Size(301, 289);
            this.category_manage_list.TabIndex = 1;
            this.category_manage_list.SelectedIndexChanged += new System.EventHandler(this.category_manage_list_SelectedIndexChanged);
            // 
            // category_manage_reset
            // 
            this.category_manage_reset.Location = new System.Drawing.Point(238, 319);
            this.category_manage_reset.Name = "category_manage_reset";
            this.category_manage_reset.Size = new System.Drawing.Size(75, 23);
            this.category_manage_reset.TabIndex = 9;
            this.category_manage_reset.Text = "새로고침";
            this.category_manage_reset.UseVisualStyleBackColor = true;
            this.category_manage_reset.Click += new System.EventHandler(this.category_manage_reset_Click);
            // 
            // Category_Manage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tabControl1);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "Category_Manage";
            this.Size = new System.Drawing.Size(714, 409);
            this.Load += new System.EventHandler(this.Category_Manage_Load);
            this.tabControl1.ResumeLayout(false);
            this.Category_register.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.Category_list.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.category_tbl_list)).EndInit();
            this.Category_modify.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage Category_register;
        private System.Windows.Forms.TabPage Category_list;
        private System.Windows.Forms.TabPage Category_modify;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button Reset;
        private System.Windows.Forms.Button Register;
        private System.Windows.Forms.TextBox Category_code;
        private System.Windows.Forms.TextBox Category_name;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView category_tbl_list;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.DataGridViewTextBoxColumn category_tb_idx;
        private System.Windows.Forms.DataGridViewTextBoxColumn category_tb_code;
        private System.Windows.Forms.DataGridViewTextBoxColumn category_tb_name;
        private System.Windows.Forms.DataGridViewTextBoxColumn category_tb_regdate;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.TextBox category_manage_name;
        private System.Windows.Forms.TextBox category_manage_code;
        private System.Windows.Forms.TextBox category_manage_idx;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.ListBox category_manage_list;
        private System.Windows.Forms.Button category_manage_delete;
        private System.Windows.Forms.Button category_manage_modify;
        private System.Windows.Forms.Button category_manage_reset;
    }
}
