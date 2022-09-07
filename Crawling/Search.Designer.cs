
namespace Crawling
{
    partial class Form1
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

        #region Windows Form 디자이너에서 생성한 코드

        /// <summary>
        /// 디자이너 지원에 필요한 메서드입니다. 
        /// 이 메서드의 내용을 코드 편집기로 수정하지 마세요.
        /// </summary>
        private void InitializeComponent()
        {
            this.TxtKeyword = new System.Windows.Forms.TextBox();
            this.BtnKeyword = new System.Windows.Forms.Button();
            this.BtnDBRefresh = new System.Windows.Forms.Button();
            this.LbSearchList = new System.Windows.Forms.ListBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.LbTitles = new System.Windows.Forms.ListBox();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // TxtKeyword
            // 
            this.TxtKeyword.Location = new System.Drawing.Point(13, 13);
            this.TxtKeyword.Name = "TxtKeyword";
            this.TxtKeyword.Size = new System.Drawing.Size(434, 21);
            this.TxtKeyword.TabIndex = 0;
            this.TxtKeyword.KeyUp += new System.Windows.Forms.KeyEventHandler(this.TxtKeyword_KeyUp);
            // 
            // BtnKeyword
            // 
            this.BtnKeyword.Location = new System.Drawing.Point(459, 11);
            this.BtnKeyword.Name = "BtnKeyword";
            this.BtnKeyword.Size = new System.Drawing.Size(75, 23);
            this.BtnKeyword.TabIndex = 1;
            this.BtnKeyword.Text = "키워드";
            this.BtnKeyword.UseVisualStyleBackColor = true;
            this.BtnKeyword.Click += new System.EventHandler(this.BtnKeyword_Click);
            // 
            // BtnDBRefresh
            // 
            this.BtnDBRefresh.Location = new System.Drawing.Point(6, 258);
            this.BtnDBRefresh.Name = "BtnDBRefresh";
            this.BtnDBRefresh.Size = new System.Drawing.Size(163, 23);
            this.BtnDBRefresh.TabIndex = 2;
            this.BtnDBRefresh.Text = "DB갱신";
            this.BtnDBRefresh.UseVisualStyleBackColor = true;
            this.BtnDBRefresh.Click += new System.EventHandler(this.BtnDBRefresh_Click);
            // 
            // LbSearchList
            // 
            this.LbSearchList.FormattingEnabled = true;
            this.LbSearchList.ItemHeight = 12;
            this.LbSearchList.Location = new System.Drawing.Point(6, 20);
            this.LbSearchList.Name = "LbSearchList";
            this.LbSearchList.Size = new System.Drawing.Size(163, 232);
            this.LbSearchList.TabIndex = 3;
            this.LbSearchList.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.LbSearchList_MouseDoubleClick);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.LbSearchList);
            this.groupBox1.Controls.Add(this.BtnDBRefresh);
            this.groupBox1.Location = new System.Drawing.Point(13, 42);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(180, 297);
            this.groupBox1.TabIndex = 4;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "검색한 키워드";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.LbTitles);
            this.groupBox2.Location = new System.Drawing.Point(199, 42);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(335, 297);
            this.groupBox2.TabIndex = 5;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "선택한 키워드 검색 내용";
            // 
            // LbTitles
            // 
            this.LbTitles.FormattingEnabled = true;
            this.LbTitles.ItemHeight = 12;
            this.LbTitles.Location = new System.Drawing.Point(6, 20);
            this.LbTitles.Name = "LbTitles";
            this.LbTitles.Size = new System.Drawing.Size(323, 268);
            this.LbTitles.TabIndex = 4;
            this.LbTitles.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.LbTitles_MouseDoubleClick);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(542, 349);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.BtnKeyword);
            this.Controls.Add(this.TxtKeyword);
            this.Name = "Form1";
            this.Text = "Search";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox TxtKeyword;
        private System.Windows.Forms.Button BtnKeyword;
        private System.Windows.Forms.Button BtnDBRefresh;
        private System.Windows.Forms.ListBox LbSearchList;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.ListBox LbTitles;
    }
}

