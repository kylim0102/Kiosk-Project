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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.Select_Item_Picture = new System.Windows.Forms.PictureBox();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
            this.Decrease = new System.Windows.Forms.Button();
            this.Increase = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.OptionIncrease = new System.Windows.Forms.Button();
            this.OptionDecrease = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.Select_Item_Picture)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("굴림", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label1.Location = new System.Drawing.Point(323, 45);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(101, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "상품 이름";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("굴림", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label2.Location = new System.Drawing.Point(323, 102);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(51, 20);
            this.label2.TabIndex = 1;
            this.label2.Text = "가격";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("굴림", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label3.Location = new System.Drawing.Point(323, 168);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(101, 20);
            this.label3.TabIndex = 2;
            this.label3.Text = "상세 설명";
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("굴림", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.button1.Location = new System.Drawing.Point(69, 478);
            this.button1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(151, 49);
            this.button1.TabIndex = 8;
            this.button1.Text = "취소";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button3
            // 
            this.button3.Font = new System.Drawing.Font("굴림", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.button3.Location = new System.Drawing.Point(289, 478);
            this.button3.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(171, 49);
            this.button3.TabIndex = 10;
            this.button3.Text = "장바구니 담기";
            this.button3.UseVisualStyleBackColor = true;
            // 
            // Select_Item_Picture
            // 
            this.Select_Item_Picture.Location = new System.Drawing.Point(27, 12);
            this.Select_Item_Picture.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Select_Item_Picture.Name = "Select_Item_Picture";
            this.Select_Item_Picture.Size = new System.Drawing.Size(248, 289);
            this.Select_Item_Picture.TabIndex = 11;
            this.Select_Item_Picture.TabStop = false;
            this.Select_Item_Picture.Click += new System.EventHandler(this.pictureBox1_Click);
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 21F));
            this.tableLayoutPanel1.Location = new System.Drawing.Point(27, 319);
            this.tableLayoutPanel1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 57F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(458, 57);
            this.tableLayoutPanel1.TabIndex = 12;
            // 
            // Decrease
            // 
            this.Decrease.Location = new System.Drawing.Point(327, 227);
            this.Decrease.Name = "Decrease";
            this.Decrease.Size = new System.Drawing.Size(21, 26);
            this.Decrease.TabIndex = 14;
            this.Decrease.Text = "▼";
            this.Decrease.UseVisualStyleBackColor = true;
            this.Decrease.Click += new System.EventHandler(this.Decrease_Click);
            // 
            // Increase
            // 
            this.Increase.Location = new System.Drawing.Point(460, 227);
            this.Increase.Name = "Increase";
            this.Increase.Size = new System.Drawing.Size(25, 26);
            this.Increase.TabIndex = 15;
            this.Increase.Text = "▲";
            this.Increase.UseVisualStyleBackColor = true;
            this.Increase.Click += new System.EventHandler(this.Increase_Click);
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(354, 227);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(100, 25);
            this.textBox1.TabIndex = 16;
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(214, 398);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(100, 25);
            this.textBox2.TabIndex = 19;
            // 
            // OptionIncrease
            // 
            this.OptionIncrease.Location = new System.Drawing.Point(320, 398);
            this.OptionIncrease.Name = "OptionIncrease";
            this.OptionIncrease.Size = new System.Drawing.Size(25, 26);
            this.OptionIncrease.TabIndex = 18;
            this.OptionIncrease.Text = "▲";
            this.OptionIncrease.UseVisualStyleBackColor = true;
            this.OptionIncrease.Click += new System.EventHandler(this.OptionIncrease_Click);
            // 
            // OptionDecrease
            // 
            this.OptionDecrease.Location = new System.Drawing.Point(187, 398);
            this.OptionDecrease.Name = "OptionDecrease";
            this.OptionDecrease.Size = new System.Drawing.Size(21, 26);
            this.OptionDecrease.TabIndex = 17;
            this.OptionDecrease.Text = "▼";
            this.OptionDecrease.UseVisualStyleBackColor = true;
            this.OptionDecrease.Click += new System.EventHandler(this.OptionDecrease_Click);
            // 
            // item
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(533, 545);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.OptionIncrease);
            this.Controls.Add(this.OptionDecrease);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.Increase);
            this.Controls.Add(this.Decrease);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Controls.Add(this.Select_Item_Picture);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "item";
            this.Text = "item";
            this.Load += new System.EventHandler(this.item_Load);
            ((System.ComponentModel.ISupportInitialize)(this.Select_Item_Picture)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.PictureBox Select_Item_Picture;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog1;
        private System.Windows.Forms.Button Decrease;
        private System.Windows.Forms.Button Increase;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.Button OptionIncrease;
        private System.Windows.Forms.Button OptionDecrease;
    }
}