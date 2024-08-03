namespace Kiosk.pPanel
{
    partial class KioskPanel
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
            this.Cart_btn = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.NextPage = new System.Windows.Forms.Button();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.PrevPage = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // Cart_btn
            // 
            this.Cart_btn.Location = new System.Drawing.Point(389, 740);
            this.Cart_btn.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Cart_btn.Name = "Cart_btn";
            this.Cart_btn.Size = new System.Drawing.Size(187, 68);
            this.Cart_btn.TabIndex = 43;
            this.Cart_btn.Text = "장바구니 (0)";
            this.Cart_btn.UseVisualStyleBackColor = true;
            this.Cart_btn.Click += new System.EventHandler(this.button4_Click);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(163, 740);
            this.button3.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(187, 68);
            this.button3.TabIndex = 42;
            this.button3.Text = "결제";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // panel2
            // 
            this.panel2.Location = new System.Drawing.Point(-1, 0);
            this.panel2.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(757, 665);
            this.panel2.TabIndex = 46;
            // 
            // NextPage
            // 
            this.NextPage.Location = new System.Drawing.Point(389, 596);
            this.NextPage.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.NextPage.Name = "NextPage";
            this.NextPage.Size = new System.Drawing.Size(104, 50);
            this.NextPage.TabIndex = 41;
            this.NextPage.Text = "▶";
            this.NextPage.UseVisualStyleBackColor = true;
            this.NextPage.Click += new System.EventHandler(this.NextPage_Click);
            // 
            // tabControl1
            // 
            this.tabControl1.Location = new System.Drawing.Point(38, 61);
            this.tabControl1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(669, 511);
            this.tabControl1.TabIndex = 39;
            this.tabControl1.SelectedIndexChanged += new System.EventHandler(this.Selected_Change);
            // 
            // PrevPage
            // 
            this.PrevPage.Location = new System.Drawing.Point(247, 596);
            this.PrevPage.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.PrevPage.Name = "PrevPage";
            this.PrevPage.Size = new System.Drawing.Size(104, 50);
            this.PrevPage.TabIndex = 40;
            this.PrevPage.Text = "◀";
            this.PrevPage.UseVisualStyleBackColor = true;
            this.PrevPage.Click += new System.EventHandler(this.PrevPage_Click);
            // 
            // KioskPanel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.Cart_btn);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.NextPage);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.PrevPage);
            this.Controls.Add(this.panel2);
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "KioskPanel";
            this.Size = new System.Drawing.Size(754, 848);
            this.Load += new System.EventHandler(this.KioskPanel_Load);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button Cart_btn;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button NextPage;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.Button PrevPage;
    }
}
