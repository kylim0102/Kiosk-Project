namespace Kiosk.ItemManage.ItemPanel
{
    partial class OptionPanel
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
            this.Option_name = new System.Windows.Forms.TextBox();
            this.Option_value = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.Category_list = new System.Windows.Forms.TabPage();
            this.button1 = new System.Windows.Forms.Button();
            this.option_list = new System.Windows.Forms.DataGridView();
            this.Option_Idx = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.OptionName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.OptionValue = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Option_Regdate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.optionmodify = new System.Windows.Forms.TabPage();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.option_reset = new System.Windows.Forms.Button();
            this.optionlist = new System.Windows.Forms.ListBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.option_delete = new System.Windows.Forms.Button();
            this.option_modify = new System.Windows.Forms.Button();
            this.option_price = new System.Windows.Forms.TextBox();
            this.option = new System.Windows.Forms.TextBox();
            this.idx = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.tabControl1.SuspendLayout();
            this.Category_register.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.Category_list.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.option_list)).BeginInit();
            this.optionmodify.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.Category_register);
            this.tabControl1.Controls.Add(this.Category_list);
            this.tabControl1.Controls.Add(this.optionmodify);
            this.tabControl1.Location = new System.Drawing.Point(3, 4);
            this.tabControl1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(809, 504);
            this.tabControl1.TabIndex = 1;
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
            this.groupBox2.Controls.Add(this.Option_name);
            this.groupBox2.Controls.Add(this.Option_value);
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
            // Option_name
            // 
            this.Option_name.Font = new System.Drawing.Font("굴림", 9F);
            this.Option_name.Location = new System.Drawing.Point(125, 61);
            this.Option_name.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Option_name.Name = "Option_name";
            this.Option_name.Size = new System.Drawing.Size(251, 25);
            this.Option_name.TabIndex = 9;
            // 
            // Option_value
            // 
            this.Option_value.Font = new System.Drawing.Font("굴림", 9F);
            this.Option_value.Location = new System.Drawing.Point(125, 124);
            this.Option_value.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Option_value.Name = "Option_value";
            this.Option_value.Size = new System.Drawing.Size(251, 25);
            this.Option_value.TabIndex = 8;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("굴림", 9F);
            this.label2.Location = new System.Drawing.Point(47, 65);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(52, 15);
            this.label2.TabIndex = 7;
            this.label2.Text = "옵션명";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("굴림", 9F);
            this.label1.Location = new System.Drawing.Point(47, 129);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(67, 15);
            this.label1.TabIndex = 6;
            this.label1.Text = "옵션가격";
            // 
            // Category_list
            // 
            this.Category_list.Controls.Add(this.button1);
            this.Category_list.Controls.Add(this.option_list);
            this.Category_list.Location = new System.Drawing.Point(4, 25);
            this.Category_list.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Category_list.Name = "Category_list";
            this.Category_list.Padding = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Category_list.Size = new System.Drawing.Size(801, 475);
            this.Category_list.TabIndex = 1;
            this.Category_list.Text = "목록";
            this.Category_list.UseVisualStyleBackColor = true;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(715, 11);
            this.button1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(79, 54);
            this.button1.TabIndex = 1;
            this.button1.Text = "새로고침";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // option_list
            // 
            this.option_list.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.option_list.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Option_Idx,
            this.OptionName,
            this.OptionValue,
            this.Option_Regdate});
            this.option_list.Location = new System.Drawing.Point(6, 8);
            this.option_list.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.option_list.Name = "option_list";
            this.option_list.ReadOnly = true;
            this.option_list.RowHeadersVisible = false;
            this.option_list.RowHeadersWidth = 51;
            this.option_list.RowTemplate.Height = 27;
            this.option_list.Size = new System.Drawing.Size(792, 461);
            this.option_list.TabIndex = 0;
            // 
            // Option_Idx
            // 
            this.Option_Idx.DataPropertyName = "NO";
            this.Option_Idx.HeaderText = "NO";
            this.Option_Idx.MinimumWidth = 6;
            this.Option_Idx.Name = "Option_Idx";
            this.Option_Idx.ReadOnly = true;
            this.Option_Idx.Width = 150;
            // 
            // OptionName
            // 
            this.OptionName.DataPropertyName = "NAME";
            this.OptionName.HeaderText = "NAME";
            this.OptionName.MinimumWidth = 6;
            this.OptionName.Name = "OptionName";
            this.OptionName.ReadOnly = true;
            this.OptionName.Width = 150;
            // 
            // OptionValue
            // 
            this.OptionValue.DataPropertyName = "PRICE";
            this.OptionValue.HeaderText = "PRICE";
            this.OptionValue.MinimumWidth = 6;
            this.OptionValue.Name = "OptionValue";
            this.OptionValue.ReadOnly = true;
            this.OptionValue.Width = 150;
            // 
            // Option_Regdate
            // 
            this.Option_Regdate.DataPropertyName = "DATE";
            this.Option_Regdate.HeaderText = "DATE";
            this.Option_Regdate.MinimumWidth = 6;
            this.Option_Regdate.Name = "Option_Regdate";
            this.Option_Regdate.ReadOnly = true;
            this.Option_Regdate.Width = 150;
            // 
            // optionmodify
            // 
            this.optionmodify.Controls.Add(this.groupBox4);
            this.optionmodify.Controls.Add(this.groupBox3);
            this.optionmodify.Location = new System.Drawing.Point(4, 25);
            this.optionmodify.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.optionmodify.Name = "optionmodify";
            this.optionmodify.Size = new System.Drawing.Size(801, 475);
            this.optionmodify.TabIndex = 2;
            this.optionmodify.Text = "관리";
            this.optionmodify.UseVisualStyleBackColor = true;
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.option_reset);
            this.groupBox4.Controls.Add(this.optionlist);
            this.groupBox4.Location = new System.Drawing.Point(16, 16);
            this.groupBox4.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Padding = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.groupBox4.Size = new System.Drawing.Size(370, 440);
            this.groupBox4.TabIndex = 2;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "정보";
            // 
            // option_reset
            // 
            this.option_reset.Location = new System.Drawing.Point(272, 399);
            this.option_reset.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.option_reset.Name = "option_reset";
            this.option_reset.Size = new System.Drawing.Size(86, 29);
            this.option_reset.TabIndex = 9;
            this.option_reset.Text = "새로고침";
            this.option_reset.UseVisualStyleBackColor = true;
            this.option_reset.Click += new System.EventHandler(this.option_reset_Click);
            // 
            // optionlist
            // 
            this.optionlist.Font = new System.Drawing.Font("굴림", 14F);
            this.optionlist.FormattingEnabled = true;
            this.optionlist.ItemHeight = 23;
            this.optionlist.Location = new System.Drawing.Point(14, 30);
            this.optionlist.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.optionlist.Name = "optionlist";
            this.optionlist.Size = new System.Drawing.Size(343, 349);
            this.optionlist.TabIndex = 1;
            this.optionlist.SelectedIndexChanged += new System.EventHandler(this.optionlist_SelectedIndexChanged);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.option_delete);
            this.groupBox3.Controls.Add(this.option_modify);
            this.groupBox3.Controls.Add(this.option_price);
            this.groupBox3.Controls.Add(this.option);
            this.groupBox3.Controls.Add(this.idx);
            this.groupBox3.Controls.Add(this.label5);
            this.groupBox3.Controls.Add(this.label4);
            this.groupBox3.Controls.Add(this.label3);
            this.groupBox3.Location = new System.Drawing.Point(407, 16);
            this.groupBox3.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Padding = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.groupBox3.Size = new System.Drawing.Size(375, 440);
            this.groupBox3.TabIndex = 1;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "수정/삭제";
            // 
            // option_delete
            // 
            this.option_delete.Location = new System.Drawing.Point(215, 278);
            this.option_delete.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.option_delete.Name = "option_delete";
            this.option_delete.Size = new System.Drawing.Size(86, 29);
            this.option_delete.TabIndex = 7;
            this.option_delete.Text = "삭제";
            this.option_delete.UseVisualStyleBackColor = true;
            this.option_delete.Click += new System.EventHandler(this.option_delete_Click);
            // 
            // option_modify
            // 
            this.option_modify.Location = new System.Drawing.Point(80, 278);
            this.option_modify.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.option_modify.Name = "option_modify";
            this.option_modify.Size = new System.Drawing.Size(86, 29);
            this.option_modify.TabIndex = 6;
            this.option_modify.Text = "수정";
            this.option_modify.UseVisualStyleBackColor = true;
            this.option_modify.Click += new System.EventHandler(this.option_modify_Click);
            // 
            // option_price
            // 
            this.option_price.Location = new System.Drawing.Point(123, 214);
            this.option_price.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.option_price.Name = "option_price";
            this.option_price.Size = new System.Drawing.Size(202, 25);
            this.option_price.TabIndex = 5;
            // 
            // option
            // 
            this.option.Location = new System.Drawing.Point(123, 160);
            this.option.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.option.Name = "option";
            this.option.Size = new System.Drawing.Size(202, 25);
            this.option.TabIndex = 4;
            // 
            // idx
            // 
            this.idx.Location = new System.Drawing.Point(123, 106);
            this.idx.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.idx.Name = "idx";
            this.idx.ReadOnly = true;
            this.idx.Size = new System.Drawing.Size(202, 25);
            this.idx.TabIndex = 3;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(46, 114);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(52, 15);
            this.label5.TabIndex = 2;
            this.label5.Text = "인덱스";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(46, 218);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(37, 15);
            this.label4.TabIndex = 1;
            this.label4.Text = "가격";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(46, 164);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(37, 15);
            this.label3.TabIndex = 0;
            this.label3.Text = "이름";
            // 
            // OptionPanel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tabControl1);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "OptionPanel";
            this.Size = new System.Drawing.Size(816, 511);
            this.Load += new System.EventHandler(this.OptionPanel_Load);
            this.tabControl1.ResumeLayout(false);
            this.Category_register.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.Category_list.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.option_list)).EndInit();
            this.optionmodify.ResumeLayout(false);
            this.groupBox4.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage Category_register;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button Reset;
        private System.Windows.Forms.Button Register;
        private System.Windows.Forms.TextBox Option_name;
        private System.Windows.Forms.TextBox Option_value;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TabPage Category_list;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.DataGridView option_list;
        private System.Windows.Forms.TabPage optionmodify;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.Button option_reset;
        private System.Windows.Forms.ListBox optionlist;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Button option_delete;
        private System.Windows.Forms.Button option_modify;
        private System.Windows.Forms.TextBox option_price;
        private System.Windows.Forms.TextBox option;
        private System.Windows.Forms.TextBox idx;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DataGridViewTextBoxColumn Option_Idx;
        private System.Windows.Forms.DataGridViewTextBoxColumn OptionName;
        private System.Windows.Forms.DataGridViewTextBoxColumn OptionValue;
        private System.Windows.Forms.DataGridViewTextBoxColumn Option_Regdate;
    }
}
