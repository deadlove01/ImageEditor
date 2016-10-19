namespace AutoUpload
{
    partial class MainForm
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
            this.metroTabControl1 = new MetroFramework.Controls.MetroTabControl();
            this.News = new MetroFramework.Controls.MetroTabPage();
            this.Viralstyle = new MetroFramework.Controls.MetroTabPage();
            this.newsTbNews = new MetroFramework.Controls.MetroTextBox();
            this.metroButton1 = new MetroFramework.Controls.MetroButton();
            this.metroTabControl1.SuspendLayout();
            this.News.SuspendLayout();
            this.Viralstyle.SuspendLayout();
            this.SuspendLayout();
            // 
            // metroTabControl1
            // 
            this.metroTabControl1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.metroTabControl1.Controls.Add(this.News);
            this.metroTabControl1.Controls.Add(this.Viralstyle);
            this.metroTabControl1.Location = new System.Drawing.Point(6, 63);
            this.metroTabControl1.Name = "metroTabControl1";
            this.metroTabControl1.SelectedIndex = 1;
            this.metroTabControl1.Size = new System.Drawing.Size(716, 350);
            this.metroTabControl1.TabIndex = 0;
            this.metroTabControl1.UseSelectable = true;
            // 
            // News
            // 
            this.News.Controls.Add(this.newsTbNews);
            this.News.HorizontalScrollbarBarColor = true;
            this.News.HorizontalScrollbarHighlightOnWheel = false;
            this.News.HorizontalScrollbarSize = 10;
            this.News.Location = new System.Drawing.Point(4, 38);
            this.News.Name = "News";
            this.News.Size = new System.Drawing.Size(708, 308);
            this.News.TabIndex = 0;
            this.News.Text = "News";
            this.News.VerticalScrollbarBarColor = true;
            this.News.VerticalScrollbarHighlightOnWheel = false;
            this.News.VerticalScrollbarSize = 10;
            // 
            // Viralstyle
            // 
            this.Viralstyle.Controls.Add(this.metroButton1);
            this.Viralstyle.HorizontalScrollbarBarColor = true;
            this.Viralstyle.HorizontalScrollbarHighlightOnWheel = false;
            this.Viralstyle.HorizontalScrollbarSize = 10;
            this.Viralstyle.Location = new System.Drawing.Point(4, 38);
            this.Viralstyle.Name = "Viralstyle";
            this.Viralstyle.Size = new System.Drawing.Size(708, 308);
            this.Viralstyle.TabIndex = 1;
            this.Viralstyle.Text = "ViralStyle";
            this.Viralstyle.VerticalScrollbarBarColor = true;
            this.Viralstyle.VerticalScrollbarHighlightOnWheel = false;
            this.Viralstyle.VerticalScrollbarSize = 10;
            // 
            // newsTbNews
            // 
            this.newsTbNews.BackColor = System.Drawing.SystemColors.ButtonFace;
            // 
            // 
            // 
            this.newsTbNews.CustomButton.Image = null;
            this.newsTbNews.CustomButton.Location = new System.Drawing.Point(402, 2);
            this.newsTbNews.CustomButton.Name = "";
            this.newsTbNews.CustomButton.Size = new System.Drawing.Size(303, 303);
            this.newsTbNews.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.newsTbNews.CustomButton.TabIndex = 1;
            this.newsTbNews.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.newsTbNews.CustomButton.UseSelectable = true;
            this.newsTbNews.CustomButton.Visible = false;
            this.newsTbNews.Dock = System.Windows.Forms.DockStyle.Fill;
            this.newsTbNews.Lines = new string[] {
        "this is text"};
            this.newsTbNews.Location = new System.Drawing.Point(0, 0);
            this.newsTbNews.MaxLength = 32767;
            this.newsTbNews.Multiline = true;
            this.newsTbNews.Name = "newsTbNews";
            this.newsTbNews.PasswordChar = '\0';
            this.newsTbNews.ReadOnly = true;
            this.newsTbNews.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.newsTbNews.SelectedText = "";
            this.newsTbNews.SelectionLength = 0;
            this.newsTbNews.SelectionStart = 0;
            this.newsTbNews.ShortcutsEnabled = true;
            this.newsTbNews.Size = new System.Drawing.Size(708, 308);
            this.newsTbNews.TabIndex = 2;
            this.newsTbNews.Text = "this is text";
            this.newsTbNews.UseCustomBackColor = true;
            this.newsTbNews.UseSelectable = true;
            this.newsTbNews.UseStyleColors = true;
            this.newsTbNews.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.newsTbNews.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            // 
            // metroButton1
            // 
            this.metroButton1.Location = new System.Drawing.Point(274, 158);
            this.metroButton1.Name = "metroButton1";
            this.metroButton1.Size = new System.Drawing.Size(75, 23);
            this.metroButton1.TabIndex = 2;
            this.metroButton1.Text = "metroButton1";
            this.metroButton1.UseSelectable = true;
            this.metroButton1.Click += new System.EventHandler(this.metroButton1_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(728, 493);
            this.Controls.Add(this.metroTabControl1);
            this.Name = "MainForm";
            this.Text = "Auto Upload";
            this.metroTabControl1.ResumeLayout(false);
            this.News.ResumeLayout(false);
            this.Viralstyle.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private MetroFramework.Controls.MetroTabControl metroTabControl1;
        private MetroFramework.Controls.MetroTabPage News;
        private MetroFramework.Controls.MetroTabPage Viralstyle;
        private MetroFramework.Controls.MetroTextBox newsTbNews;
        private MetroFramework.Controls.MetroButton metroButton1;
    }
}

