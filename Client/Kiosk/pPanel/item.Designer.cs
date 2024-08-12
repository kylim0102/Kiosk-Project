namespace Kiosk.pPanel
{
    partial class item
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
            this.button1 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.Select_Item_Picture = new System.Windows.Forms.PictureBox();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.OptionIncrease = new System.Windows.Forms.Button();
            this.OptionDecrease = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.Increase = new System.Windows.Forms.Button();
            this.Decrease = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.Select_Item_Picture)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.White;
            this.button1.Font = new System.Drawing.Font("굴림", 13F, System.Drawing.FontStyle.Bold);
            this.button1.Location = new System.Drawing.Point(63, 357);
            this.button1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(132, 39);
            this.button1.TabIndex = 8;
            this.button1.Text = "취 소";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button3
            // 
            this.button3.BackColor = System.Drawing.Color.White;
            this.button3.Font = new System.Drawing.Font("굴림", 13F, System.Drawing.FontStyle.Bold);
            this.button3.Location = new System.Drawing.Point(256, 357);
            this.button3.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(150, 39);
            this.button3.TabIndex = 10;
            this.button3.Text = "장바구니 담기";
            this.button3.UseVisualStyleBackColor = false;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // Select_Item_Picture
            // 
            this.Select_Item_Picture.ErrorImage = null;
            this.Select_Item_Picture.Location = new System.Drawing.Point(24, 10);
            this.Select_Item_Picture.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Select_Item_Picture.Name = "Select_Item_Picture";
            this.Select_Item_Picture.Size = new System.Drawing.Size(217, 231);
            this.Select_Item_Picture.TabIndex = 11;
            this.Select_Item_Picture.TabStop = false;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 18F));
            this.tableLayoutPanel1.Location = new System.Drawing.Point(24, 255);
            this.tableLayoutPanel1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 46F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(430, 46);
            this.tableLayoutPanel1.TabIndex = 12;
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(76, 291);
            this.textBox2.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(28, 21);
            this.textBox2.TabIndex = 19;
            // 
            // OptionIncrease
            // 
            this.OptionIncrease.BackColor = System.Drawing.Color.White;
            this.OptionIncrease.Location = new System.Drawing.Point(110, 291);
            this.OptionIncrease.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.OptionIncrease.Name = "OptionIncrease";
            this.OptionIncrease.Size = new System.Drawing.Size(22, 21);
            this.OptionIncrease.TabIndex = 18;
            this.OptionIncrease.Text = "▲";
            this.OptionIncrease.UseVisualStyleBackColor = false;
            this.OptionIncrease.Click += new System.EventHandler(this.OptionIncrease_Click);
            // 
            // OptionDecrease
            // 
            this.OptionDecrease.BackColor = System.Drawing.Color.White;
            this.OptionDecrease.Location = new System.Drawing.Point(53, 291);
            this.OptionDecrease.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.OptionDecrease.Name = "OptionDecrease";
            this.OptionDecrease.Size = new System.Drawing.Size(18, 21);
            this.OptionDecrease.TabIndex = 17;
            this.OptionDecrease.Text = "▼";
            this.OptionDecrease.UseVisualStyleBackColor = false;
            this.OptionDecrease.Click += new System.EventHandler(this.OptionDecrease_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.textBox1);
            this.groupBox1.Controls.Add(this.Increase);
            this.groupBox1.Controls.Add(this.Decrease);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(254, 2);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(200, 239);
            this.groupBox1.TabIndex = 21;
            this.groupBox1.TabStop = false;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("굴림", 16F, System.Drawing.FontStyle.Bold);
            this.label7.Location = new System.Drawing.Point(6, 104);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(56, 22);
            this.label7.TabIndex = 30;
            this.label7.Text = "수량";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("굴림", 16F, System.Drawing.FontStyle.Bold);
            this.label6.Location = new System.Drawing.Point(6, 152);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(102, 22);
            this.label6.TabIndex = 29;
            this.label6.Text = "제품설명";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("굴림", 16F, System.Drawing.FontStyle.Bold);
            this.label5.Location = new System.Drawing.Point(6, 59);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(56, 22);
            this.label5.TabIndex = 28;
            this.label5.Text = "가격";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("굴림", 16F, System.Drawing.FontStyle.Bold);
            this.label4.Location = new System.Drawing.Point(6, 17);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(79, 22);
            this.label4.TabIndex = 27;
            this.label4.Text = "제품명";
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(94, 105);
            this.textBox1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(28, 21);
            this.textBox1.TabIndex = 26;
            this.textBox1.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // Increase
            // 
            this.Increase.BackColor = System.Drawing.Color.White;
            this.Increase.Location = new System.Drawing.Point(130, 105);
            this.Increase.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Increase.Name = "Increase";
            this.Increase.Size = new System.Drawing.Size(22, 21);
            this.Increase.TabIndex = 25;
            this.Increase.Text = "▲";
            this.Increase.UseVisualStyleBackColor = false;
            this.Increase.Click += new System.EventHandler(this.Increase_Click);
            // 
            // Decrease
            // 
            this.Decrease.BackColor = System.Drawing.Color.White;
            this.Decrease.Location = new System.Drawing.Point(70, 104);
            this.Decrease.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Decrease.Name = "Decrease";
            this.Decrease.Size = new System.Drawing.Size(18, 21);
            this.Decrease.TabIndex = 24;
            this.Decrease.Text = "▼";
            this.Decrease.UseVisualStyleBackColor = false;
            this.Decrease.Click += new System.EventHandler(this.Decrease_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("굴림", 12F);
            this.label3.ForeColor = System.Drawing.Color.Gray;
            this.label3.Location = new System.Drawing.Point(12, 183);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(76, 16);
            this.label3.TabIndex = 23;
            this.label3.Text = "상세 설명";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("굴림", 12F);
            this.label2.ForeColor = System.Drawing.Color.Gray;
            this.label2.Location = new System.Drawing.Point(68, 65);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(39, 16);
            this.label2.TabIndex = 22;
            this.label2.Text = "가격";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("굴림", 12F);
            this.label1.ForeColor = System.Drawing.Color.Gray;
            this.label1.Location = new System.Drawing.Point(91, 23);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(76, 16);
            this.label1.TabIndex = 21;
            this.label1.Text = "상품 이름";
            // 
            // item
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(466, 408);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.OptionIncrease);
            this.Controls.Add(this.OptionDecrease);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Controls.Add(this.Select_Item_Picture);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button1);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "item";
            this.Text = "item";
            this.Load += new System.EventHandler(this.item_Load);
            ((System.ComponentModel.ISupportInitialize)(this.Select_Item_Picture)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.PictureBox Select_Item_Picture;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog1;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.Button OptionIncrease;
        private System.Windows.Forms.Button OptionDecrease;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Button Increase;
        private System.Windows.Forms.Button Decrease;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label7;
    }
}