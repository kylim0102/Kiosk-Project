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
            this.groupBox.Location = new System.Drawing.Point(34, 51);
            this.groupBox.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.groupBox.Name = "groupBox";
            this.groupBox.Padding = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.groupBox.Size = new System.Drawing.Size(253, 292);
            this.groupBox.TabIndex = 0;
            this.groupBox.TabStop = false;
            this.groupBox.Text = "No1. Order";
            // 
            // Order_print
            // 
            this.Order_print.Location = new System.Drawing.Point(7, 254);
            this.Order_print.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Order_print.Name = "Order_print";
            this.Order_print.Size = new System.Drawing.Size(239, 29);
            this.Order_print.TabIndex = 5;
            this.Order_print.Text = "출력";
            this.Order_print.UseVisualStyleBackColor = true;
            // 
            // Order_call
            // 
            this.Order_call.Location = new System.Drawing.Point(128, 218);
            this.Order_call.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Order_call.Name = "Order_call";
            this.Order_call.Size = new System.Drawing.Size(118, 29);
            this.Order_call.TabIndex = 4;
            this.Order_call.Text = "호출";
            this.Order_call.UseVisualStyleBackColor = true;
            // 
            // Order_cancle
            // 
            this.Order_cancle.Location = new System.Drawing.Point(7, 218);
            this.Order_cancle.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Order_cancle.Name = "Order_cancle";
            this.Order_cancle.Size = new System.Drawing.Size(114, 29);
            this.Order_cancle.TabIndex = 3;
            this.Order_cancle.Text = "취소";
            this.Order_cancle.UseVisualStyleBackColor = true;
            // 
            // listBox1
            // 
            this.listBox1.FormattingEnabled = true;
            this.listBox1.ItemHeight = 15;
            this.listBox1.Location = new System.Drawing.Point(7, 25);
            this.listBox1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(238, 184);
            this.listBox1.TabIndex = 2;
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.AllowUserToResizeColumns = false;
            this.dataGridView1.AllowUserToResizeRows = false;
            this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView1.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(34, 364);
            this.dataGridView1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersVisible = false;
            this.dataGridView1.RowHeadersWidth = 51;
            this.dataGridView1.RowTemplate.Height = 23;
            this.dataGridView1.Size = new System.Drawing.Size(552, 342);
            this.dataGridView1.TabIndex = 6;
            // 
            // button5
            // 
            this.button5.Location = new System.Drawing.Point(203, 8);
            this.button5.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(91, 29);
            this.button5.TabIndex = 10;
            this.button5.Text = "새로고침";
            this.button5.UseVisualStyleBackColor = true;
            this.button5.Click += new System.EventHandler(this.button5_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("굴림", 12F);
            this.label1.Location = new System.Drawing.Point(14, 11);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(103, 20);
            this.label1.TabIndex = 9;
            this.label1.Text = "통신상태: ";
            // 
            // waitingCon
            // 
            this.waitingCon.AutoSize = true;
            this.waitingCon.Font = new System.Drawing.Font("굴림", 12F);
            this.waitingCon.Location = new System.Drawing.Point(106, 12);
            this.waitingCon.Name = "waitingCon";
            this.waitingCon.Size = new System.Drawing.Size(59, 20);
            this.waitingCon.TabIndex = 11;
            this.waitingCon.Text = "Wait..";
            this.waitingCon.TextChanged += new System.EventHandler(this.ClientCount);
            // 
            // OrderList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1192, 721);
            this.Controls.Add(this.waitingCon);
            this.Controls.Add(this.button5);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.groupBox);
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
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