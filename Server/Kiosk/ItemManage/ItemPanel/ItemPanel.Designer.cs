namespace Kiosk.ItemManage.ItemPanel
{
    partial class ItemPanel
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
            this.Item_Register = new System.Windows.Forms.GroupBox();
            this.Reset = new System.Windows.Forms.Button();
            this.Register = new System.Windows.Forms.Button();
            this.Item_category = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.file_path = new System.Windows.Forms.TextBox();
            this.file_scan = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.Item_content = new System.Windows.Forms.TextBox();
            this.Item_price = new System.Windows.Forms.TextBox();
            this.Item_name = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.Item_Register.SuspendLayout();
            this.SuspendLayout();
            // 
            // Item_Register
            // 
            this.Item_Register.Controls.Add(this.Reset);
            this.Item_Register.Controls.Add(this.Register);
            this.Item_Register.Controls.Add(this.Item_category);
            this.Item_Register.Controls.Add(this.label5);
            this.Item_Register.Controls.Add(this.file_path);
            this.Item_Register.Controls.Add(this.file_scan);
            this.Item_Register.Controls.Add(this.label4);
            this.Item_Register.Controls.Add(this.Item_content);
            this.Item_Register.Controls.Add(this.Item_price);
            this.Item_Register.Controls.Add(this.Item_name);
            this.Item_Register.Controls.Add(this.label3);
            this.Item_Register.Controls.Add(this.label2);
            this.Item_Register.Controls.Add(this.label1);
            this.Item_Register.Location = new System.Drawing.Point(121, 3);
            this.Item_Register.Name = "Item_Register";
            this.Item_Register.Size = new System.Drawing.Size(490, 403);
            this.Item_Register.TabIndex = 20;
            this.Item_Register.TabStop = false;
            this.Item_Register.Text = "Item_Register";
            this.Item_Register.Enter += new System.EventHandler(this.Item_Register_Enter);
            // 
            // Reset
            // 
            this.Reset.Location = new System.Drawing.Point(267, 357);
            this.Reset.Name = "Reset";
            this.Reset.Size = new System.Drawing.Size(75, 23);
            this.Reset.TabIndex = 35;
            this.Reset.Text = "리셋";
            this.Reset.UseVisualStyleBackColor = true;
            this.Reset.Click += new System.EventHandler(this.button4_Click);
            // 
            // Register
            // 
            this.Register.Location = new System.Drawing.Point(151, 357);
            this.Register.Name = "Register";
            this.Register.Size = new System.Drawing.Size(75, 23);
            this.Register.TabIndex = 34;
            this.Register.Text = "등록";
            this.Register.UseVisualStyleBackColor = true;
            this.Register.Click += new System.EventHandler(this.Register_Click);
            // 
            // Item_category
            // 
            this.Item_category.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.Item_category.FormattingEnabled = true;
            this.Item_category.Location = new System.Drawing.Point(101, 39);
            this.Item_category.Name = "Item_category";
            this.Item_category.Size = new System.Drawing.Size(367, 20);
            this.Item_category.TabIndex = 31;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(29, 42);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(53, 12);
            this.label5.TabIndex = 30;
            this.label5.Text = "카테고리";
            // 
            // file_path
            // 
            this.file_path.Location = new System.Drawing.Point(101, 310);
            this.file_path.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.file_path.Name = "file_path";
            this.file_path.ReadOnly = true;
            this.file_path.Size = new System.Drawing.Size(274, 21);
            this.file_path.TabIndex = 29;
            // 
            // file_scan
            // 
            this.file_scan.Location = new System.Drawing.Point(383, 310);
            this.file_scan.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.file_scan.Name = "file_scan";
            this.file_scan.Size = new System.Drawing.Size(85, 23);
            this.file_scan.TabIndex = 27;
            this.file_scan.Text = "찾아보기";
            this.file_scan.UseVisualStyleBackColor = true;
            this.file_scan.Click += new System.EventHandler(this.button3_Click_1);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(29, 313);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(57, 12);
            this.label4.TabIndex = 12;
            this.label4.Text = "제품 사진";
            // 
            // Item_content
            // 
            this.Item_content.Location = new System.Drawing.Point(101, 212);
            this.Item_content.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Item_content.Multiline = true;
            this.Item_content.Name = "Item_content";
            this.Item_content.Size = new System.Drawing.Size(367, 65);
            this.Item_content.TabIndex = 11;
            // 
            // Item_price
            // 
            this.Item_price.Location = new System.Drawing.Point(101, 149);
            this.Item_price.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Item_price.Name = "Item_price";
            this.Item_price.Size = new System.Drawing.Size(367, 21);
            this.Item_price.TabIndex = 10;
            // 
            // Item_name
            // 
            this.Item_name.Location = new System.Drawing.Point(101, 88);
            this.Item_name.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Item_name.Name = "Item_name";
            this.Item_name.Size = new System.Drawing.Size(367, 21);
            this.Item_name.TabIndex = 9;
            this.Item_name.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(29, 212);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(53, 12);
            this.label3.TabIndex = 8;
            this.label3.Text = "제품설명";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(29, 152);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 12);
            this.label2.TabIndex = 7;
            this.label2.Text = "제품가격";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(29, 91);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(41, 12);
            this.label1.TabIndex = 6;
            this.label1.Text = "제품명";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // ItemPanel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.Item_Register);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "ItemPanel";
            this.Size = new System.Drawing.Size(714, 409);
            this.Load += new System.EventHandler(this.ItemPanel_Load);
            this.Item_Register.ResumeLayout(false);
            this.Item_Register.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.GroupBox Item_Register;
        private System.Windows.Forms.TextBox Item_content;
        private System.Windows.Forms.TextBox Item_price;
        private System.Windows.Forms.TextBox Item_name;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button file_scan;
        private System.Windows.Forms.TextBox file_path;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button Reset;
        private System.Windows.Forms.Button Register;
        public System.Windows.Forms.ComboBox Item_category;
    }
}
