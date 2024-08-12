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
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // Cart_btn
            // 
            this.Cart_btn.BackColor = System.Drawing.Color.White;
            this.Cart_btn.Font = new System.Drawing.Font("굴림", 16F, System.Drawing.FontStyle.Bold);
            this.Cart_btn.Location = new System.Drawing.Point(376, 583);
            this.Cart_btn.Name = "Cart_btn";
            this.Cart_btn.Size = new System.Drawing.Size(164, 54);
            this.Cart_btn.TabIndex = 43;
            this.Cart_btn.Text = "장바구니 (0)";
            this.Cart_btn.UseVisualStyleBackColor = false;
            this.Cart_btn.Click += new System.EventHandler(this.button4_Click);
            // 
            // button3
            // 
            this.button3.BackColor = System.Drawing.Color.White;
            this.button3.Font = new System.Drawing.Font("굴림", 16F, System.Drawing.FontStyle.Bold);
            this.button3.Location = new System.Drawing.Point(179, 583);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(164, 54);
            this.button3.TabIndex = 42;
            this.button3.Text = "결 제";
            this.button3.UseVisualStyleBackColor = false;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.tabControl1);
            this.panel2.Controls.Add(this.PrevPage);
            this.panel2.Controls.Add(this.NextPage);
            this.panel2.Location = new System.Drawing.Point(-1, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(731, 532);
            this.panel2.TabIndex = 46;
            // 
            // NextPage
            // 
            this.NextPage.BackColor = System.Drawing.Color.White;
            this.NextPage.Location = new System.Drawing.Point(377, 469);
            this.NextPage.Name = "NextPage";
            this.NextPage.Size = new System.Drawing.Size(91, 40);
            this.NextPage.TabIndex = 41;
            this.NextPage.Text = "▶";
            this.NextPage.UseVisualStyleBackColor = false;
            this.NextPage.Click += new System.EventHandler(this.NextPage_Click);
            // 
            // tabControl1
            // 
            this.tabControl1.Location = new System.Drawing.Point(70, 41);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(585, 409);
            this.tabControl1.TabIndex = 39;
            this.tabControl1.SelectedIndexChanged += new System.EventHandler(this.Selected_Change);
            // 
            // PrevPage
            // 
            this.PrevPage.BackColor = System.Drawing.Color.White;
            this.PrevPage.Location = new System.Drawing.Point(253, 469);
            this.PrevPage.Name = "PrevPage";
            this.PrevPage.Size = new System.Drawing.Size(91, 40);
            this.PrevPage.TabIndex = 40;
            this.PrevPage.Text = "◀";
            this.PrevPage.UseVisualStyleBackColor = false;
            this.PrevPage.Click += new System.EventHandler(this.PrevPage_Click);
            // 
            // KioskPanel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.Cart_btn);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.panel2);
            this.Name = "KioskPanel";
            this.Size = new System.Drawing.Size(730, 676);
            this.Load += new System.EventHandler(this.KioskPanel_Load);
            this.panel2.ResumeLayout(false);
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
