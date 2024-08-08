namespace Kiosk.Order
{
    partial class OrderList
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
            this.groupBox = new System.Windows.Forms.GroupBox();
            this.Order_print = new System.Windows.Forms.Button();
            this.Order_call = new System.Windows.Forms.Button();
            this.Order_cancle = new System.Windows.Forms.Button();
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.button5 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.waitingCon = new System.Windows.Forms.Label();
            this.groupBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox
            // 
            this.groupBox.Controls.Add(this.Order_print);
            this.groupBox.Controls.Add(this.Order_call);
            this.groupBox.Controls.Add(this.Order_cancle);
            this.groupBox.Controls.Add(this.listBox1);
            this.groupBox.Location = new System.Drawing.Point(30, 41);
            this.groupBox.Name = "groupBox";
            this.groupBox.Size = new System.Drawing.Size(221, 234);
            this.groupBox.TabIndex = 0;
            this.groupBox.TabStop = false;
            this.groupBox.Text = "No1. Order";
            // 
            // Order_print
            // 
            this.Order_print.Location = new System.Drawing.Point(6, 203);
            this.Order_print.Name = "Order_print";
            this.Order_print.Size = new System.Drawing.Size(209, 23);
            this.Order_print.TabIndex = 5;
            this.Order_print.Text = "출력";
            this.Order_print.UseVisualStyleBackColor = true;
            this.Order_print.Click += new System.EventHandler(this.button3_Click);
            // 
            // Order_call
            // 
            this.Order_call.Location = new System.Drawing.Point(112, 174);
            this.Order_call.Name = "Order_call";
            this.Order_call.Size = new System.Drawing.Size(103, 23);
            this.Order_call.TabIndex = 4;
            this.Order_call.Text = "호출";
            this.Order_call.UseVisualStyleBackColor = true;
            this.Order_call.Click += new System.EventHandler(this.button2_Click);
            // 
            // Order_cancle
            // 
            this.Order_cancle.Location = new System.Drawing.Point(6, 174);
            this.Order_cancle.Name = "Order_cancle";
            this.Order_cancle.Size = new System.Drawing.Size(100, 23);
            this.Order_cancle.TabIndex = 3;
            this.Order_cancle.Text = "취소";
            this.Order_cancle.UseVisualStyleBackColor = true;
            // 
            // listBox1
            // 
            this.listBox1.FormattingEnabled = true;
            this.listBox1.ItemHeight = 12;
            this.listBox1.Items.AddRange(new object[] {
            "------------------------------",
            "제품: 아메리카노(1)",
            "옵션: 샷추가(2)",
            "옵션: ICE",
            "",
            "------------------------------",
            "제품: 아메리카노(2)",
            "옵션: ICE",
            "",
            "------------------------------",
            "제품: 레몬에이드(1)",
            "옵션: 연하게",
            "옵션: ICE",
            "",
            "------------------------------"});
            this.listBox1.Location = new System.Drawing.Point(6, 20);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(209, 148);
            this.listBox1.TabIndex = 2;
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.AllowUserToResizeColumns = false;
            this.dataGridView1.AllowUserToResizeRows = false;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(30, 291);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowTemplate.Height = 23;
            this.dataGridView1.Size = new System.Drawing.Size(483, 274);
            this.dataGridView1.TabIndex = 6;
            // 
            // button5
            // 
            this.button5.Location = new System.Drawing.Point(178, 6);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(80, 23);
            this.button5.TabIndex = 10;
            this.button5.Text = "새로고침";
            this.button5.UseVisualStyleBackColor = true;
            this.button5.Click += new System.EventHandler(this.button5_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("굴림", 12F);
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(81, 16);
            this.label1.TabIndex = 9;
            this.label1.Text = "통신상태: ";
            // 
            // waitingCon
            // 
            this.waitingCon.AutoSize = true;
            this.waitingCon.Font = new System.Drawing.Font("굴림", 12F);
            this.waitingCon.Location = new System.Drawing.Point(93, 10);
            this.waitingCon.Name = "waitingCon";
            this.waitingCon.Size = new System.Drawing.Size(48, 16);
            this.waitingCon.TabIndex = 11;
            this.waitingCon.Text = "Wait..";
            this.waitingCon.TextChanged += new System.EventHandler(this.test);
            // 
            // OrderList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1043, 577);
            this.Controls.Add(this.waitingCon);
            this.Controls.Add(this.button5);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.groupBox);
            this.Name = "OrderList";
            this.Text = "OrderList";
            this.Load += new System.EventHandler(this.OrderList_Load);
            this.groupBox.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox;
        private System.Windows.Forms.Button Order_call;
        private System.Windows.Forms.Button Order_cancle;
        private System.Windows.Forms.ListBox listBox1;
        private System.Windows.Forms.Button Order_print;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label waitingCon;
    }
}