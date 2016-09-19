namespace CafepressUploader
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
            this.metroPanel1 = new MetroFramework.Controls.MetroPanel();
            this.lblLoginStatus = new MetroFramework.Controls.MetroLabel();
            this.btnLogin = new MetroFramework.Controls.MetroButton();
            this.bgWorker = new System.ComponentModel.BackgroundWorker();
            this.metroPanel2 = new MetroFramework.Controls.MetroPanel();
            this.listBoxLogo = new System.Windows.Forms.ListBox();
            this.metroLabel1 = new MetroFramework.Controls.MetroLabel();
            this.btnBrowse = new MetroFramework.Controls.MetroButton();
            this.btnClear = new MetroFramework.Controls.MetroButton();
            this.metroPanel3 = new MetroFramework.Controls.MetroPanel();
            this.cbbTemplates = new MetroFramework.Controls.MetroComboBox();
            this.btnSaveTemplate = new MetroFramework.Controls.MetroButton();
            this.tbAbout = new MetroFramework.Controls.MetroTextBox();
            this.metroLabel5 = new MetroFramework.Controls.MetroLabel();
            this.tbTags = new MetroFramework.Controls.MetroTextBox();
            this.metroLabel4 = new MetroFramework.Controls.MetroLabel();
            this.tbName = new MetroFramework.Controls.MetroTextBox();
            this.metroLabel3 = new MetroFramework.Controls.MetroLabel();
            this.metroLabel6 = new MetroFramework.Controls.MetroLabel();
            this.metroLabel2 = new MetroFramework.Controls.MetroLabel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnUpload = new MetroFramework.Controls.MetroButton();
            this.tbLogs = new MetroFramework.Controls.MetroTextBox();
            this.metroLabel7 = new MetroFramework.Controls.MetroLabel();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.tsProgressBar = new System.Windows.Forms.ToolStripProgressBar();
            this.tsLblProgess = new System.Windows.Forms.ToolStripLabel();
            this.tbTemplateName = new MetroFramework.Controls.MetroTextBox();
            this.metroPanel1.SuspendLayout();
            this.metroPanel2.SuspendLayout();
            this.metroPanel3.SuspendLayout();
            this.panel1.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // metroPanel1
            // 
            this.metroPanel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.metroPanel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.metroPanel1.Controls.Add(this.lblLoginStatus);
            this.metroPanel1.Controls.Add(this.btnLogin);
            this.metroPanel1.HorizontalScrollbarBarColor = true;
            this.metroPanel1.HorizontalScrollbarHighlightOnWheel = false;
            this.metroPanel1.HorizontalScrollbarSize = 10;
            this.metroPanel1.Location = new System.Drawing.Point(6, 63);
            this.metroPanel1.Name = "metroPanel1";
            this.metroPanel1.Size = new System.Drawing.Size(244, 207);
            this.metroPanel1.TabIndex = 0;
            this.metroPanel1.VerticalScrollbarBarColor = true;
            this.metroPanel1.VerticalScrollbarHighlightOnWheel = false;
            this.metroPanel1.VerticalScrollbarSize = 10;
            // 
            // lblLoginStatus
            // 
            this.lblLoginStatus.AutoSize = true;
            this.lblLoginStatus.ForeColor = System.Drawing.Color.DarkOrange;
            this.lblLoginStatus.Location = new System.Drawing.Point(18, 72);
            this.lblLoginStatus.Name = "lblLoginStatus";
            this.lblLoginStatus.Size = new System.Drawing.Size(18, 19);
            this.lblLoginStatus.TabIndex = 2;
            this.lblLoginStatus.Text = "...";
            this.lblLoginStatus.UseCustomForeColor = true;
            // 
            // btnLogin
            // 
            this.btnLogin.FontSize = MetroFramework.MetroButtonSize.Tall;
            this.btnLogin.Location = new System.Drawing.Point(18, 13);
            this.btnLogin.Name = "btnLogin";
            this.btnLogin.Size = new System.Drawing.Size(200, 44);
            this.btnLogin.TabIndex = 1;
            this.btnLogin.Text = "Login";
            this.btnLogin.UseSelectable = true;
            this.btnLogin.Click += new System.EventHandler(this.btnLogin_Click);
            // 
            // bgWorker
            // 
            this.bgWorker.DoWork += new System.ComponentModel.DoWorkEventHandler(this.bgWorker_DoWork);
            this.bgWorker.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.bgWorker_ProgressChanged);
            this.bgWorker.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.bgWorker_RunWorkerCompleted);
            // 
            // metroPanel2
            // 
            this.metroPanel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.metroPanel2.Controls.Add(this.listBoxLogo);
            this.metroPanel2.Controls.Add(this.metroLabel1);
            this.metroPanel2.Controls.Add(this.btnBrowse);
            this.metroPanel2.Controls.Add(this.btnClear);
            this.metroPanel2.HorizontalScrollbarBarColor = true;
            this.metroPanel2.HorizontalScrollbarHighlightOnWheel = false;
            this.metroPanel2.HorizontalScrollbarSize = 10;
            this.metroPanel2.Location = new System.Drawing.Point(6, 172);
            this.metroPanel2.Name = "metroPanel2";
            this.metroPanel2.Size = new System.Drawing.Size(244, 280);
            this.metroPanel2.TabIndex = 1;
            this.metroPanel2.VerticalScrollbarBarColor = true;
            this.metroPanel2.VerticalScrollbarHighlightOnWheel = false;
            this.metroPanel2.VerticalScrollbarSize = 10;
            // 
            // listBoxLogo
            // 
            this.listBoxLogo.FormattingEnabled = true;
            this.listBoxLogo.Location = new System.Drawing.Point(20, 44);
            this.listBoxLogo.Name = "listBoxLogo";
            this.listBoxLogo.Size = new System.Drawing.Size(198, 186);
            this.listBoxLogo.TabIndex = 6;
            // 
            // metroLabel1
            // 
            this.metroLabel1.AutoSize = true;
            this.metroLabel1.FontSize = MetroFramework.MetroLabelSize.Tall;
            this.metroLabel1.FontWeight = MetroFramework.MetroLabelWeight.Bold;
            this.metroLabel1.Location = new System.Drawing.Point(65, 14);
            this.metroLabel1.Name = "metroLabel1";
            this.metroLabel1.Size = new System.Drawing.Size(104, 25);
            this.metroLabel1.TabIndex = 2;
            this.metroLabel1.Text = "List Design";
            this.metroLabel1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnBrowse
            // 
            this.btnBrowse.FontSize = MetroFramework.MetroButtonSize.Medium;
            this.btnBrowse.FontWeight = MetroFramework.MetroButtonWeight.Regular;
            this.btnBrowse.Location = new System.Drawing.Point(128, 240);
            this.btnBrowse.Name = "btnBrowse";
            this.btnBrowse.Size = new System.Drawing.Size(90, 35);
            this.btnBrowse.TabIndex = 5;
            this.btnBrowse.Text = "Browse";
            this.btnBrowse.UseSelectable = true;
            this.btnBrowse.Click += new System.EventHandler(this.btnBrowse_Click);
            // 
            // btnClear
            // 
            this.btnClear.FontSize = MetroFramework.MetroButtonSize.Medium;
            this.btnClear.FontWeight = MetroFramework.MetroButtonWeight.Regular;
            this.btnClear.Location = new System.Drawing.Point(18, 240);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(90, 35);
            this.btnClear.Style = MetroFramework.MetroColorStyle.Blue;
            this.btnClear.TabIndex = 5;
            this.btnClear.Text = "Clear";
            this.btnClear.UseSelectable = true;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // metroPanel3
            // 
            this.metroPanel3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.metroPanel3.Controls.Add(this.tbTemplateName);
            this.metroPanel3.Controls.Add(this.cbbTemplates);
            this.metroPanel3.Controls.Add(this.btnSaveTemplate);
            this.metroPanel3.Controls.Add(this.tbAbout);
            this.metroPanel3.Controls.Add(this.metroLabel5);
            this.metroPanel3.Controls.Add(this.tbTags);
            this.metroPanel3.Controls.Add(this.metroLabel4);
            this.metroPanel3.Controls.Add(this.tbName);
            this.metroPanel3.Controls.Add(this.metroLabel3);
            this.metroPanel3.Controls.Add(this.metroLabel6);
            this.metroPanel3.Controls.Add(this.metroLabel2);
            this.metroPanel3.HorizontalScrollbarBarColor = true;
            this.metroPanel3.HorizontalScrollbarHighlightOnWheel = false;
            this.metroPanel3.HorizontalScrollbarSize = 10;
            this.metroPanel3.Location = new System.Drawing.Point(256, 63);
            this.metroPanel3.Name = "metroPanel3";
            this.metroPanel3.Size = new System.Drawing.Size(244, 585);
            this.metroPanel3.TabIndex = 2;
            this.metroPanel3.VerticalScrollbarBarColor = true;
            this.metroPanel3.VerticalScrollbarHighlightOnWheel = false;
            this.metroPanel3.VerticalScrollbarSize = 10;
            // 
            // cbbTemplates
            // 
            this.cbbTemplates.FormattingEnabled = true;
            this.cbbTemplates.ItemHeight = 23;
            this.cbbTemplates.Location = new System.Drawing.Point(16, 488);
            this.cbbTemplates.Name = "cbbTemplates";
            this.cbbTemplates.Size = new System.Drawing.Size(209, 29);
            this.cbbTemplates.TabIndex = 6;
            this.cbbTemplates.UseSelectable = true;
            // 
            // btnSaveTemplate
            // 
            this.btnSaveTemplate.FontSize = MetroFramework.MetroButtonSize.Medium;
            this.btnSaveTemplate.FontWeight = MetroFramework.MetroButtonWeight.Regular;
            this.btnSaveTemplate.Location = new System.Drawing.Point(119, 434);
            this.btnSaveTemplate.Name = "btnSaveTemplate";
            this.btnSaveTemplate.Size = new System.Drawing.Size(106, 39);
            this.btnSaveTemplate.TabIndex = 5;
            this.btnSaveTemplate.Text = "Save Template";
            this.btnSaveTemplate.UseSelectable = true;
            this.btnSaveTemplate.Click += new System.EventHandler(this.btnSaveTemplate_Click);
            // 
            // tbAbout
            // 
            // 
            // 
            // 
            this.tbAbout.CustomButton.Image = null;
            this.tbAbout.CustomButton.Location = new System.Drawing.Point(127, 2);
            this.tbAbout.CustomButton.Name = "";
            this.tbAbout.CustomButton.Size = new System.Drawing.Size(79, 79);
            this.tbAbout.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.tbAbout.CustomButton.TabIndex = 1;
            this.tbAbout.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.tbAbout.CustomButton.UseSelectable = true;
            this.tbAbout.CustomButton.Visible = false;
            this.tbAbout.Lines = new string[] {
        "{0}"};
            this.tbAbout.Location = new System.Drawing.Point(16, 291);
            this.tbAbout.MaxLength = 32767;
            this.tbAbout.Multiline = true;
            this.tbAbout.Name = "tbAbout";
            this.tbAbout.PasswordChar = '\0';
            this.tbAbout.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.tbAbout.SelectedText = "";
            this.tbAbout.SelectionLength = 0;
            this.tbAbout.SelectionStart = 0;
            this.tbAbout.ShortcutsEnabled = true;
            this.tbAbout.Size = new System.Drawing.Size(209, 84);
            this.tbAbout.TabIndex = 4;
            this.tbAbout.Text = "{0}";
            this.tbAbout.UseSelectable = true;
            this.tbAbout.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.tbAbout.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            // 
            // metroLabel5
            // 
            this.metroLabel5.AutoSize = true;
            this.metroLabel5.FontWeight = MetroFramework.MetroLabelWeight.Regular;
            this.metroLabel5.Location = new System.Drawing.Point(16, 267);
            this.metroLabel5.Name = "metroLabel5";
            this.metroLabel5.Size = new System.Drawing.Size(47, 19);
            this.metroLabel5.TabIndex = 3;
            this.metroLabel5.Text = "About";
            // 
            // tbTags
            // 
            // 
            // 
            // 
            this.tbTags.CustomButton.Image = null;
            this.tbTags.CustomButton.Location = new System.Drawing.Point(127, 2);
            this.tbTags.CustomButton.Name = "";
            this.tbTags.CustomButton.Size = new System.Drawing.Size(79, 79);
            this.tbTags.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.tbTags.CustomButton.TabIndex = 1;
            this.tbTags.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.tbTags.CustomButton.UseSelectable = true;
            this.tbTags.CustomButton.Visible = false;
            this.tbTags.Lines = new string[] {
        "{0}"};
            this.tbTags.Location = new System.Drawing.Point(16, 153);
            this.tbTags.MaxLength = 32767;
            this.tbTags.Multiline = true;
            this.tbTags.Name = "tbTags";
            this.tbTags.PasswordChar = '\0';
            this.tbTags.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.tbTags.SelectedText = "";
            this.tbTags.SelectionLength = 0;
            this.tbTags.SelectionStart = 0;
            this.tbTags.ShortcutsEnabled = true;
            this.tbTags.Size = new System.Drawing.Size(209, 84);
            this.tbTags.TabIndex = 4;
            this.tbTags.Text = "{0}";
            this.tbTags.UseSelectable = true;
            this.tbTags.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.tbTags.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            // 
            // metroLabel4
            // 
            this.metroLabel4.AutoSize = true;
            this.metroLabel4.FontWeight = MetroFramework.MetroLabelWeight.Regular;
            this.metroLabel4.Location = new System.Drawing.Point(16, 129);
            this.metroLabel4.Name = "metroLabel4";
            this.metroLabel4.Size = new System.Drawing.Size(35, 19);
            this.metroLabel4.TabIndex = 3;
            this.metroLabel4.Text = "Tags";
            // 
            // tbName
            // 
            // 
            // 
            // 
            this.tbName.CustomButton.Image = null;
            this.tbName.CustomButton.Location = new System.Drawing.Point(187, 1);
            this.tbName.CustomButton.Name = "";
            this.tbName.CustomButton.Size = new System.Drawing.Size(21, 21);
            this.tbName.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.tbName.CustomButton.TabIndex = 1;
            this.tbName.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.tbName.CustomButton.UseSelectable = true;
            this.tbName.CustomButton.Visible = false;
            this.tbName.Lines = new string[] {
        "{0}"};
            this.tbName.Location = new System.Drawing.Point(16, 80);
            this.tbName.MaxLength = 32767;
            this.tbName.Name = "tbName";
            this.tbName.PasswordChar = '\0';
            this.tbName.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.tbName.SelectedText = "";
            this.tbName.SelectionLength = 0;
            this.tbName.SelectionStart = 0;
            this.tbName.ShortcutsEnabled = true;
            this.tbName.Size = new System.Drawing.Size(209, 23);
            this.tbName.TabIndex = 4;
            this.tbName.Text = "{0}";
            this.tbName.UseSelectable = true;
            this.tbName.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.tbName.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            // 
            // metroLabel3
            // 
            this.metroLabel3.AutoSize = true;
            this.metroLabel3.FontWeight = MetroFramework.MetroLabelWeight.Regular;
            this.metroLabel3.Location = new System.Drawing.Point(16, 56);
            this.metroLabel3.Name = "metroLabel3";
            this.metroLabel3.Size = new System.Drawing.Size(45, 19);
            this.metroLabel3.TabIndex = 3;
            this.metroLabel3.Text = "Name";
            // 
            // metroLabel6
            // 
            this.metroLabel6.AutoSize = true;
            this.metroLabel6.FontSize = MetroFramework.MetroLabelSize.Tall;
            this.metroLabel6.FontWeight = MetroFramework.MetroLabelWeight.Bold;
            this.metroLabel6.Location = new System.Drawing.Point(16, 406);
            this.metroLabel6.Name = "metroLabel6";
            this.metroLabel6.Size = new System.Drawing.Size(204, 25);
            this.metroLabel6.TabIndex = 2;
            this.metroLabel6.Text = "Save, Import Template";
            this.metroLabel6.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // metroLabel2
            // 
            this.metroLabel2.AutoSize = true;
            this.metroLabel2.FontSize = MetroFramework.MetroLabelSize.Tall;
            this.metroLabel2.FontWeight = MetroFramework.MetroLabelWeight.Bold;
            this.metroLabel2.Location = new System.Drawing.Point(49, 14);
            this.metroLabel2.Name = "metroLabel2";
            this.metroLabel2.Size = new System.Drawing.Size(144, 25);
            this.metroLabel2.TabIndex = 2;
            this.metroLabel2.Text = "Design Settings";
            this.metroLabel2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.btnUpload);
            this.panel1.Controls.Add(this.tbLogs);
            this.panel1.Controls.Add(this.metroLabel7);
            this.panel1.Location = new System.Drawing.Point(6, 458);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(244, 190);
            this.panel1.TabIndex = 3;
            // 
            // btnUpload
            // 
            this.btnUpload.BackColor = System.Drawing.Color.Aquamarine;
            this.btnUpload.FontSize = MetroFramework.MetroButtonSize.Medium;
            this.btnUpload.Location = new System.Drawing.Point(20, 12);
            this.btnUpload.Name = "btnUpload";
            this.btnUpload.Size = new System.Drawing.Size(202, 38);
            this.btnUpload.TabIndex = 5;
            this.btnUpload.Text = "Start Upload";
            this.btnUpload.UseCustomBackColor = true;
            this.btnUpload.UseSelectable = true;
            this.btnUpload.Click += new System.EventHandler(this.btnUpload_Click);
            // 
            // tbLogs
            // 
            // 
            // 
            // 
            this.tbLogs.CustomButton.Image = null;
            this.tbLogs.CustomButton.Location = new System.Drawing.Point(111, 1);
            this.tbLogs.CustomButton.Name = "";
            this.tbLogs.CustomButton.Size = new System.Drawing.Size(97, 97);
            this.tbLogs.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.tbLogs.CustomButton.TabIndex = 1;
            this.tbLogs.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.tbLogs.CustomButton.UseSelectable = true;
            this.tbLogs.CustomButton.Visible = false;
            this.tbLogs.Lines = new string[0];
            this.tbLogs.Location = new System.Drawing.Point(20, 83);
            this.tbLogs.MaxLength = 32767;
            this.tbLogs.Multiline = true;
            this.tbLogs.Name = "tbLogs";
            this.tbLogs.PasswordChar = '\0';
            this.tbLogs.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.tbLogs.SelectedText = "";
            this.tbLogs.SelectionLength = 0;
            this.tbLogs.SelectionStart = 0;
            this.tbLogs.ShortcutsEnabled = true;
            this.tbLogs.Size = new System.Drawing.Size(209, 99);
            this.tbLogs.TabIndex = 4;
            this.tbLogs.UseSelectable = true;
            this.tbLogs.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.tbLogs.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            // 
            // metroLabel7
            // 
            this.metroLabel7.AutoSize = true;
            this.metroLabel7.FontWeight = MetroFramework.MetroLabelWeight.Regular;
            this.metroLabel7.Location = new System.Drawing.Point(20, 61);
            this.metroLabel7.Name = "metroLabel7";
            this.metroLabel7.Size = new System.Drawing.Size(38, 19);
            this.metroLabel7.TabIndex = 3;
            this.metroLabel7.Text = "Logs";
            // 
            // toolStrip1
            // 
            this.toolStrip1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsProgressBar,
            this.tsLblProgess});
            this.toolStrip1.Location = new System.Drawing.Point(20, 658);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(903, 25);
            this.toolStrip1.TabIndex = 4;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // tsProgressBar
            // 
            this.tsProgressBar.Name = "tsProgressBar";
            this.tsProgressBar.Size = new System.Drawing.Size(200, 22);
            // 
            // tsLblProgess
            // 
            this.tsLblProgess.Name = "tsLblProgess";
            this.tsLblProgess.Size = new System.Drawing.Size(16, 22);
            this.tsLblProgess.Text = "...";
            // 
            // tbTemplateName
            // 
            // 
            // 
            // 
            this.tbTemplateName.CustomButton.Image = null;
            this.tbTemplateName.CustomButton.Location = new System.Drawing.Point(57, 1);
            this.tbTemplateName.CustomButton.Name = "";
            this.tbTemplateName.CustomButton.Size = new System.Drawing.Size(39, 39);
            this.tbTemplateName.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.tbTemplateName.CustomButton.TabIndex = 1;
            this.tbTemplateName.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.tbTemplateName.CustomButton.UseSelectable = true;
            this.tbTemplateName.CustomButton.Visible = false;
            this.tbTemplateName.Lines = new string[] {
        "template_name"};
            this.tbTemplateName.Location = new System.Drawing.Point(16, 432);
            this.tbTemplateName.MaxLength = 32767;
            this.tbTemplateName.Name = "tbTemplateName";
            this.tbTemplateName.PasswordChar = '\0';
            this.tbTemplateName.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.tbTemplateName.SelectedText = "";
            this.tbTemplateName.SelectionLength = 0;
            this.tbTemplateName.SelectionStart = 0;
            this.tbTemplateName.ShortcutsEnabled = true;
            this.tbTemplateName.Size = new System.Drawing.Size(97, 41);
            this.tbTemplateName.TabIndex = 5;
            this.tbTemplateName.Text = "template_name";
            this.tbTemplateName.UseSelectable = true;
            this.tbTemplateName.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.tbTemplateName.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(943, 703);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.metroPanel3);
            this.Controls.Add(this.metroPanel2);
            this.Controls.Add(this.metroPanel1);
            this.Name = "MainForm";
            this.Text = "Cafepress Uploader";
            this.metroPanel1.ResumeLayout(false);
            this.metroPanel1.PerformLayout();
            this.metroPanel2.ResumeLayout(false);
            this.metroPanel2.PerformLayout();
            this.metroPanel3.ResumeLayout(false);
            this.metroPanel3.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private MetroFramework.Controls.MetroPanel metroPanel1;
        private MetroFramework.Controls.MetroButton btnLogin;
        private System.ComponentModel.BackgroundWorker bgWorker;
        private MetroFramework.Controls.MetroLabel lblLoginStatus;
        private MetroFramework.Controls.MetroPanel metroPanel2;
        private MetroFramework.Controls.MetroLabel metroLabel1;
        private MetroFramework.Controls.MetroPanel metroPanel3;
        private MetroFramework.Controls.MetroTextBox tbTags;
        private MetroFramework.Controls.MetroLabel metroLabel4;
        private MetroFramework.Controls.MetroTextBox tbName;
        private MetroFramework.Controls.MetroLabel metroLabel3;
        private MetroFramework.Controls.MetroLabel metroLabel2;
        private MetroFramework.Controls.MetroTextBox tbAbout;
        private MetroFramework.Controls.MetroLabel metroLabel5;
        private MetroFramework.Controls.MetroButton btnSaveTemplate;
        private MetroFramework.Controls.MetroLabel metroLabel6;
        private MetroFramework.Controls.MetroComboBox cbbTemplates;
        private System.Windows.Forms.Panel panel1;
        private MetroFramework.Controls.MetroButton btnUpload;
        private MetroFramework.Controls.MetroTextBox tbLogs;
        private MetroFramework.Controls.MetroLabel metroLabel7;
        private MetroFramework.Controls.MetroButton btnBrowse;
        private MetroFramework.Controls.MetroButton btnClear;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripProgressBar tsProgressBar;
        private System.Windows.Forms.ToolStripLabel tsLblProgess;
        private System.Windows.Forms.ListBox listBoxLogo;
        private MetroFramework.Controls.MetroTextBox tbTemplateName;
    }
}

