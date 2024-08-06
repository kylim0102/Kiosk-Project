namespace Kiosk.pPanel
{
    partial class ChartTable
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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.label1 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.chart1 = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.Chart_name = new System.Windows.Forms.Label();
            this.Chart_count = new System.Windows.Forms.Label();
            this.Chart_payment = new System.Windows.Forms.Label();
            this.Chart_percent = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("굴림", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.Location = new System.Drawing.Point(13, 12);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(87, 28);
            this.label1.TabIndex = 1;
            this.label1.Text = "Chart";
            // 
            // label3
            // 
            this.label3.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label3.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label3.Location = new System.Drawing.Point(0, 47);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(952, 3);
            this.label3.TabIndex = 4;
            // 
            // chart1
            // 
            chartArea1.Name = "ChartArea1";
            this.chart1.ChartAreas.Add(chartArea1);
            legend1.Name = "Legend1";
            this.chart1.Legends.Add(legend1);
            this.chart1.Location = new System.Drawing.Point(3, 53);
            this.chart1.Name = "chart1";
            series1.ChartArea = "ChartArea1";
            series1.Legend = "Legend1";
            series1.Name = "Series1";
            this.chart1.Series.Add(series1);
            this.chart1.Size = new System.Drawing.Size(475, 416);
            this.chart1.TabIndex = 5;
            this.chart1.Text = "chart1";
            this.chart1.Click += new System.EventHandler(this.chart1_Click);
            this.chart1.MouseClick += new System.Windows.Forms.MouseEventHandler(this.test);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.Chart_percent);
            this.groupBox1.Controls.Add(this.Chart_payment);
            this.groupBox1.Controls.Add(this.Chart_count);
            this.groupBox1.Controls.Add(this.Chart_name);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Location = new System.Drawing.Point(484, 53);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(465, 429);
            this.groupBox1.TabIndex = 6;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Chart Info";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("굴림", 14F);
            this.label2.Location = new System.Drawing.Point(86, 107);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(82, 24);
            this.label2.TabIndex = 0;
            this.label2.Text = "제품명";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("굴림", 14F);
            this.label4.Location = new System.Drawing.Point(86, 160);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(138, 24);
            this.label4.TabIndex = 1;
            this.label4.Text = "총 판매수량";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("굴림", 14F);
            this.label5.Location = new System.Drawing.Point(86, 215);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(114, 24);
            this.label5.TabIndex = 2;
            this.label5.Text = "총 판매액";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("굴림", 14F);
            this.label6.Location = new System.Drawing.Point(86, 274);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(114, 24);
            this.label6.TabIndex = 3;
            this.label6.Text = "판매 비율";
            // 
            // Chart_name
            // 
            this.Chart_name.AutoSize = true;
            this.Chart_name.Font = new System.Drawing.Font("굴림", 14F);
            this.Chart_name.Location = new System.Drawing.Point(273, 107);
            this.Chart_name.Name = "Chart_name";
            this.Chart_name.Size = new System.Drawing.Size(82, 24);
            this.Chart_name.TabIndex = 4;
            this.Chart_name.Text = "제품명";
            // 
            // Chart_count
            // 
            this.Chart_count.AutoSize = true;
            this.Chart_count.Font = new System.Drawing.Font("굴림", 14F);
            this.Chart_count.Location = new System.Drawing.Point(273, 160);
            this.Chart_count.Name = "Chart_count";
            this.Chart_count.Size = new System.Drawing.Size(58, 24);
            this.Chart_count.TabIndex = 5;
            this.Chart_count.Text = "수량";
            // 
            // Chart_payment
            // 
            this.Chart_payment.AutoSize = true;
            this.Chart_payment.Font = new System.Drawing.Font("굴림", 14F);
            this.Chart_payment.Location = new System.Drawing.Point(273, 215);
            this.Chart_payment.Name = "Chart_payment";
            this.Chart_payment.Size = new System.Drawing.Size(58, 24);
            this.Chart_payment.TabIndex = 6;
            this.Chart_payment.Text = "가격";
            // 
            // Chart_percent
            // 
            this.Chart_percent.AutoSize = true;
            this.Chart_percent.Font = new System.Drawing.Font("굴림", 14F);
            this.Chart_percent.Location = new System.Drawing.Point(273, 274);
            this.Chart_percent.Name = "Chart_percent";
            this.Chart_percent.Size = new System.Drawing.Size(114, 24);
            this.Chart_percent.TabIndex = 7;
            this.Chart_percent.Text = "판매 비율";
            // 
            // ChartTable
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.chart1);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label1);
            this.Name = "ChartTable";
            this.Size = new System.Drawing.Size(952, 485);
            this.Load += new System.EventHandler(this.ChartTable_Load);
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DataVisualization.Charting.Chart chart1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label Chart_percent;
        private System.Windows.Forms.Label Chart_payment;
        private System.Windows.Forms.Label Chart_count;
        private System.Windows.Forms.Label Chart_name;
    }
}
