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
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.file_scan = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.file_path = new System.Windows.Forms.TextBox();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.label5 = new System.Windows.Forms.Label();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.Item_Register.SuspendLayout();
            this.SuspendLayout();
            // 
            // Item_Register
            // 
            this.Item_Register.Controls.Add(this.comboBox1);
            this.Item_Register.Controls.Add(this.label5);
            this.Item_Register.Controls.Add(this.file_path);
            this.Item_Register.Controls.Add(this.file_scan);
            this.Item_Register.Controls.Add(this.label4);
            this.Item_Register.Controls.Add(this.textBox3);
            this.Item_Register.Controls.Add(this.textBox2);
            this.Item_Register.Controls.Add(this.textBox1);
            this.Item_Register.Controls.Add(this.label3);
            this.Item_Register.Controls.Add(this.label2);
            this.Item_Register.Controls.Add(this.label1);
            this.Item_Register.Location = new System.Drawing.Point(121, 3);
            this.Item_Register.Name = "Item_Register";
            this.Item_Register.Size = new System.Drawing.Size(490, 353);
            this.Item_Register.TabIndex = 20;
            this.Item_Register.TabStop = false;
            this.Item_Register.Text = "Item_Register";
            this.Item_Register.Enter += new System.EventHandler(this.Item_Register_Enter);
            // 
            // textBox3
            // 
            this.textBox3.Location = new System.Drawing.Point(101, 195);
            this.textBox3.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.textBox3.Multiline = true;
            this.textBox3.Name = "textBox3";
            this.textBox3.Size = new System.Drawing.Size(367, 65);
            this.textBox3.TabIndex = 11;
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(101, 132);
            this.textBox2.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(367, 21);
            this.textBox2.TabIndex = 10;
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(101, 77);
            this.textBox1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(367, 21);
            this.textBox1.TabIndex = 9;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(29, 195);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(53, 12);
            this.label3.TabIndex = 8;
            this.label3.Text = "제품설명";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(29, 135);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 12);
            this.label2.TabIndex = 7;
            this.label2.Text = "제품가격";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(29, 80);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(41, 12);
            this.label1.TabIndex = 6;
            this.label1.Text = "제품명";
            // 
            // file_scan
            // 
            this.file_scan.Location = new System.Drawing.Point(383, 293);
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
            this.label4.Location = new System.Drawing.Point(29, 296);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(57, 12);
            this.label4.TabIndex = 12;
            this.label4.Text = "제품 사진";
            // 
            // file_path
            // 
            this.file_path.Location = new System.Drawing.Point(101, 293);
            this.file_path.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.file_path.Name = "file_path";
            this.file_path.Size = new System.Drawing.Size(274, 21);
            this.file_path.TabIndex = 29;
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(29, 37);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(53, 12);
            this.label5.TabIndex = 30;
            this.label5.Text = "카테고리";
            // 
            // comboBox1
            // 
            this.comboBox1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Items.AddRange(new object[] {
            "COFFEE",
            "NON COFFEE",
            "ADE",
            "TEA"});
            this.comboBox1.Location = new System.Drawing.Point(101, 28);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(367, 20);
            this.comboBox1.TabIndex = 31;
            // 
            // ItemPanel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.Item_Register);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "ItemPanel";
            this.Size = new System.Drawing.Size(714, 364);
            this.Item_Register.ResumeLayout(false);
            this.Item_Register.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.GroupBox Item_Register;
        private System.Windows.Forms.TextBox textBox3;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button file_scan;
        private System.Windows.Forms.TextBox file_path;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Label label5;
    }
}
