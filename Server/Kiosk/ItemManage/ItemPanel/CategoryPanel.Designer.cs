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
            this.Category_modify = new System.Windows.Forms.TabPage();
            this.category_tbl_list = new System.Windows.Forms.DataGridView();
            this.category_tb_idx = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.category_tb_code = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.category_tb_name = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.category_tb_regdate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.button1 = new System.Windows.Forms.Button();
            this.tabControl1.SuspendLayout();
            this.Category_register.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.Category_list.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.category_tbl_list)).BeginInit();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.Category_register);
            this.tabControl1.Controls.Add(this.Category_list);
            this.tabControl1.Controls.Add(this.Category_modify);
            this.tabControl1.Location = new System.Drawing.Point(3, 4);
            this.tabControl1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(809, 504);
            this.tabControl1.TabIndex = 0;
            // 
            // Category_register
            // 
            this.Category_register.Controls.Add(this.groupBox1);
            this.Category_register.Font = new System.Drawing.Font("굴림", 9F);
            this.Category_register.Location = new System.Drawing.Point(4, 25);
            this.Category_register.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Category_register.Name = "Category_register";
            this.Category_register.Padding = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Category_register.Size = new System.Drawing.Size(801, 475);
            this.Category_register.TabIndex = 0;
            this.Category_register.Text = "등록";
            this.Category_register.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.groupBox2);
            this.groupBox1.Font = new System.Drawing.Font("굴림", 12F);
            this.groupBox1.Location = new System.Drawing.Point(151, 8);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.groupBox1.Size = new System.Drawing.Size(472, 456);
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
            this.groupBox2.Location = new System.Drawing.Point(31, 125);
            this.groupBox2.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.groupBox2.Size = new System.Drawing.Size(411, 259);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            // 
            // Reset
            // 
            this.Reset.Font = new System.Drawing.Font("굴림", 9F);
            this.Reset.Location = new System.Drawing.Point(262, 195);
            this.Reset.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Reset.Name = "Reset";
            this.Reset.Size = new System.Drawing.Size(86, 29);
            this.Reset.TabIndex = 11;
            this.Reset.Text = "리셋";
            this.Reset.UseVisualStyleBackColor = true;
            this.Reset.Click += new System.EventHandler(this.Reset_Click);
            // 
            // Register
            // 
            this.Register.Font = new System.Drawing.Font("굴림", 9F);
            this.Register.Location = new System.Drawing.Point(95, 195);
            this.Register.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Register.Name = "Register";
            this.Register.Size = new System.Drawing.Size(86, 29);
            this.Register.TabIndex = 10;
            this.Register.Text = "등록";
            this.Register.UseVisualStyleBackColor = true;
            this.Register.Click += new System.EventHandler(this.Register_Click);
            // 
            // Category_code
            // 
            this.Category_code.Font = new System.Drawing.Font("굴림", 9F);
            this.Category_code.Location = new System.Drawing.Point(125, 61);
            this.Category_code.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Category_code.Name = "Category_code";
            this.Category_code.ReadOnly = true;
            this.Category_code.Size = new System.Drawing.Size(251, 25);
            this.Category_code.TabIndex = 9;
            // 
            // Category_name
            // 
            this.Category_name.Font = new System.Drawing.Font("굴림", 9F);
            this.Category_name.Location = new System.Drawing.Point(125, 124);
            this.Category_name.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Category_name.Name = "Category_name";
            this.Category_name.Size = new System.Drawing.Size(251, 25);
            this.Category_name.TabIndex = 8;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("굴림", 9F);
            this.label2.Location = new System.Drawing.Point(29, 68);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(67, 15);
            this.label2.TabIndex = 7;
            this.label2.Text = "분류코드";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("굴림", 9F);
            this.label1.Location = new System.Drawing.Point(47, 129);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(52, 15);
            this.label1.TabIndex = 6;
            this.label1.Text = "분류명";
            // 
            // Category_list
            // 
            this.Category_list.Controls.Add(this.button1);
            this.Category_list.Controls.Add(this.category_tbl_list);
            this.Category_list.Location = new System.Drawing.Point(4, 25);
            this.Category_list.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Category_list.Name = "Category_list";
            this.Category_list.Padding = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Category_list.Size = new System.Drawing.Size(801, 475);
            this.Category_list.TabIndex = 1;
            this.Category_list.Text = "목록";
            this.Category_list.UseVisualStyleBackColor = true;
            // 
            // Category_modify
            // 
            this.Category_modify.Location = new System.Drawing.Point(4, 25);
            this.Category_modify.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Category_modify.Name = "Category_modify";
            this.Category_modify.Size = new System.Drawing.Size(801, 475);
            this.Category_modify.TabIndex = 2;
            this.Category_modify.Text = "관리";
            this.Category_modify.UseVisualStyleBackColor = true;
            // 
            // category_tbl_list
            // 
            this.category_tbl_list.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.category_tbl_list.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.category_tb_idx,
            this.category_tb_code,
            this.category_tb_name,
            this.category_tb_regdate});
            this.category_tbl_list.Location = new System.Drawing.Point(6, 7);
            this.category_tbl_list.Name = "category_tbl_list";
            this.category_tbl_list.ReadOnly = true;
            this.category_tbl_list.RowHeadersVisible = false;
            this.category_tbl_list.RowHeadersWidth = 51;
            this.category_tbl_list.RowTemplate.Height = 27;
            this.category_tbl_list.Size = new System.Drawing.Size(792, 461);
            this.category_tbl_list.TabIndex = 0;
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
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(716, 11);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(79, 54);
            this.button1.TabIndex = 1;
            this.button1.Text = "새로고침";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // Category_Manage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tabControl1);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "Category_Manage";
            this.Size = new System.Drawing.Size(816, 511);
            this.Load += new System.EventHandler(this.Category_Manage_Load);
            this.tabControl1.ResumeLayout(false);
            this.Category_register.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.Category_list.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.category_tbl_list)).EndInit();
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
    }
}
