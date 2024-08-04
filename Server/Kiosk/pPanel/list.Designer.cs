namespace Kiosk.pPanel
{
    partial class list
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
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.List_keyword = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.List_Total = new System.Windows.Forms.Label();
            this.List_count = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.start_calendar = new System.Windows.Forms.TextBox();
            this.monthCalendar1 = new System.Windows.Forms.MonthCalendar();
            this.label5 = new System.Windows.Forms.Label();
            this.end_calendar = new System.Windows.Forms.TextBox();
            this.monthCalendar2 = new System.Windows.Forms.MonthCalendar();
            this.label1 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.Refresh_list = new System.Windows.Forms.Button();
            this.label8 = new System.Windows.Forms.Label();
            this.List_max = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // label2
            // 
            this.label2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label2.Location = new System.Drawing.Point(22, 54);
            this.label2.MaximumSize = new System.Drawing.Size(0, 2);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(0, 2);
            this.label2.TabIndex = 2;
            // 
            // label3
            // 
            this.label3.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label3.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label3.Location = new System.Drawing.Point(0, 42);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(952, 2);
            this.label3.TabIndex = 3;
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.AllowUserToResizeColumns = false;
            this.dataGridView1.AllowUserToResizeRows = false;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(8, 48);
            this.dataGridView1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersVisible = false;
            this.dataGridView1.RowHeadersWidth = 51;
            this.dataGridView1.RowTemplate.Height = 27;
            this.dataGridView1.Size = new System.Drawing.Size(461, 434);
            this.dataGridView1.TabIndex = 4;
            // 
            // List_keyword
            // 
            this.List_keyword.Location = new System.Drawing.Point(298, 10);
            this.List_keyword.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.List_keyword.Name = "List_keyword";
            this.List_keyword.Size = new System.Drawing.Size(132, 25);
            this.List_keyword.TabIndex = 5;
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.Transparent;
            this.button1.Location = new System.Drawing.Point(435, 9);
            this.button1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(33, 29);
            this.button1.TabIndex = 6;
            this.button1.Text = "🔍";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("굴림", 12F, System.Drawing.FontStyle.Bold);
            this.label4.Location = new System.Drawing.Point(537, 90);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(104, 20);
            this.label4.TabIndex = 7;
            this.label4.Text = "총 매출  :";
            // 
            // List_Total
            // 
            this.List_Total.AutoSize = true;
            this.List_Total.Font = new System.Drawing.Font("굴림", 12F);
            this.List_Total.Location = new System.Drawing.Point(681, 90);
            this.List_Total.Name = "List_Total";
            this.List_Total.Size = new System.Drawing.Size(20, 20);
            this.List_Total.TabIndex = 8;
            this.List_Total.Text = "0";
            // 
            // List_count
            // 
            this.List_count.AutoSize = true;
            this.List_count.Font = new System.Drawing.Font("굴림", 12F);
            this.List_count.Location = new System.Drawing.Point(681, 148);
            this.List_count.Name = "List_count";
            this.List_count.Size = new System.Drawing.Size(20, 20);
            this.List_count.TabIndex = 10;
            this.List_count.Text = "0";
            this.List_count.Click += new System.EventHandler(this.label6_Click);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("굴림", 12F, System.Drawing.FontStyle.Bold);
            this.label7.Location = new System.Drawing.Point(537, 148);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(125, 20);
            this.label7.TabIndex = 9;
            this.label7.Text = "총 판매량  :";
            this.label7.Click += new System.EventHandler(this.label7_Click);
            // 
            // start_calendar
            // 
            this.start_calendar.BackColor = System.Drawing.Color.White;
            this.start_calendar.Location = new System.Drawing.Point(45, 9);
            this.start_calendar.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.start_calendar.Name = "start_calendar";
            this.start_calendar.ReadOnly = true;
            this.start_calendar.Size = new System.Drawing.Size(89, 25);
            this.start_calendar.TabIndex = 13;
            this.start_calendar.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.start_calendar.TextChanged += new System.EventHandler(this.start_calendar_TextChanged);
            // 
            // monthCalendar1
            // 
            this.monthCalendar1.Location = new System.Drawing.Point(45, 41);
            this.monthCalendar1.Margin = new System.Windows.Forms.Padding(10, 11, 10, 11);
            this.monthCalendar1.Name = "monthCalendar1";
            this.monthCalendar1.TabIndex = 14;
            this.monthCalendar1.Visible = false;
            this.monthCalendar1.DateChanged += new System.Windows.Forms.DateRangeEventHandler(this.monthCalendar1_DateChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(134, 15);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(15, 15);
            this.label5.TabIndex = 15;
            this.label5.Text = "-";
            // 
            // end_calendar
            // 
            this.end_calendar.BackColor = System.Drawing.Color.White;
            this.end_calendar.Location = new System.Drawing.Point(145, 10);
            this.end_calendar.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.end_calendar.Name = "end_calendar";
            this.end_calendar.ReadOnly = true;
            this.end_calendar.Size = new System.Drawing.Size(89, 25);
            this.end_calendar.TabIndex = 16;
            this.end_calendar.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // monthCalendar2
            // 
            this.monthCalendar2.Location = new System.Drawing.Point(155, 42);
            this.monthCalendar2.Margin = new System.Windows.Forms.Padding(10, 11, 10, 11);
            this.monthCalendar2.Name = "monthCalendar2";
            this.monthCalendar2.TabIndex = 17;
            this.monthCalendar2.Visible = false;
            this.monthCalendar2.DateChanged += new System.Windows.Forms.DateRangeEventHandler(this.monthCalendar2_DateChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(10, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(37, 15);
            this.label1.TabIndex = 18;
            this.label1.Text = "날짜";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(251, 16);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(52, 15);
            this.label6.TabIndex = 19;
            this.label6.Text = "키워드";
            // 
            // Refresh_list
            // 
            this.Refresh_list.Location = new System.Drawing.Point(486, 9);
            this.Refresh_list.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Refresh_list.Name = "Refresh_list";
            this.Refresh_list.Size = new System.Drawing.Size(71, 29);
            this.Refresh_list.TabIndex = 20;
            this.Refresh_list.Text = "새로고침";
            this.Refresh_list.UseVisualStyleBackColor = true;
            this.Refresh_list.Click += new System.EventHandler(this.Refresh_list_Click);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("굴림", 12F, System.Drawing.FontStyle.Bold);
            this.label8.Location = new System.Drawing.Point(537, 202);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(146, 20);
            this.label8.TabIndex = 21;
            this.label8.Text = "총 주문 건수 :";
            // 
            // List_max
            // 
            this.List_max.AutoSize = true;
            this.List_max.Font = new System.Drawing.Font("굴림", 12F);
            this.List_max.Location = new System.Drawing.Point(706, 202);
            this.List_max.Name = "List_max";
            this.List_max.Size = new System.Drawing.Size(20, 20);
            this.List_max.TabIndex = 22;
            this.List_max.Text = "0";
            // 
            // list
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.List_max);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.Refresh_list);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.monthCalendar2);
            this.Controls.Add(this.end_calendar);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.monthCalendar1);
            this.Controls.Add(this.start_calendar);
            this.Controls.Add(this.List_count);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.List_Total);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.List_keyword);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "list";
            this.Size = new System.Drawing.Size(952, 485);
            this.Load += new System.EventHandler(this.list_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.TextBox List_keyword;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label List_Total;
        private System.Windows.Forms.Label List_count;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox start_calendar;
        private System.Windows.Forms.MonthCalendar monthCalendar1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox end_calendar;
        private System.Windows.Forms.MonthCalendar monthCalendar2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button Refresh_list;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label List_max;
    }
}
