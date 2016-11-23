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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.metroTabControl1 = new MetroFramework.Controls.MetroTabControl();
            this.News = new MetroFramework.Controls.MetroTabPage();
            this.newsTbNews = new MetroFramework.Controls.MetroTextBox();
            this.Viralstyle = new MetroFramework.Controls.MetroTabPage();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.metroLabel8 = new MetroFramework.Controls.MetroLabel();
            this.btnUpload = new MetroFramework.Controls.MetroButton();
            this.metroLabel5 = new MetroFramework.Controls.MetroLabel();
            this.tbTemplateName = new MetroFramework.Controls.MetroTextBox();
            this.btnLoadTemplate = new MetroFramework.Controls.MetroButton();
            this.flowLayoutMokcup = new System.Windows.Forms.FlowLayoutPanel();
            this.metroLabel2 = new MetroFramework.Controls.MetroLabel();
            this.tbDescription = new MetroFramework.Controls.MetroTextBox();
            this.tbTags = new MetroFramework.Controls.MetroTextBox();
            this.metroLabel4 = new MetroFramework.Controls.MetroLabel();
            this.tbCampUrl = new MetroFramework.Controls.MetroTextBox();
            this.metroLabel3 = new MetroFramework.Controls.MetroLabel();
            this.tbTitle = new MetroFramework.Controls.MetroTextBox();
            this.metroLabel1 = new MetroFramework.Controls.MetroLabel();
            this.metroPanel1 = new MetroFramework.Controls.MetroPanel();
            this.numGoal = new System.Windows.Forms.NumericUpDown();
            this.chbShowBack = new MetroFramework.Controls.MetroCheckBox();
            this.chbShowGoal = new MetroFramework.Controls.MetroCheckBox();
            this.chbPageTimer = new MetroFramework.Controls.MetroCheckBox();
            this.chbHideMarketPlace = new MetroFramework.Controls.MetroCheckBox();
            this.chbAutoExtend = new MetroFramework.Controls.MetroCheckBox();
            this.chbAutoRelaunch = new MetroFramework.Controls.MetroCheckBox();
            this.btnSaveTemplate = new MetroFramework.Controls.MetroButton();
            this.metroLabel7 = new MetroFramework.Controls.MetroLabel();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.panel1 = new System.Windows.Forms.Panel();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.opChbShowMockup = new System.Windows.Forms.CheckBox();
            this.opBtnSave = new MetroFramework.Controls.MetroButton();
            this.viralMockupImageList = new System.Windows.Forms.ImageList(this.components);
            this.bgWorker = new System.ComponentModel.BackgroundWorker();
            this.btnLoadLogo = new MetroFramework.Controls.MetroButton();
            this.listViewLogo = new System.Windows.Forms.ListBox();
            this.mockup1 = new AutoUpload.Controls.Mockup();
            this.mockupControl1 = new AutoUpload.Controls.MockupControl();
            this.listLogs = new System.Windows.Forms.ListBox();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.tsProgress = new System.Windows.Forms.ToolStripProgressBar();
            this.tsLblProgress = new System.Windows.Forms.ToolStripLabel();
            this.opTbEmail = new MetroFramework.Controls.MetroTextBox();
            this.metroLabel6 = new MetroFramework.Controls.MetroLabel();
            this.metroLabel9 = new MetroFramework.Controls.MetroLabel();
            this.opTbPass = new MetroFramework.Controls.MetroTextBox();
            this.metroTabControl1.SuspendLayout();
            this.News.SuspendLayout();
            this.Viralstyle.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.flowLayoutMokcup.SuspendLayout();
            this.metroPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numGoal)).BeginInit();
            this.tabPage1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // metroTabControl1
            // 
            this.metroTabControl1.Controls.Add(this.News);
            this.metroTabControl1.Controls.Add(this.Viralstyle);
            this.metroTabControl1.Controls.Add(this.tabPage1);
            this.metroTabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.metroTabControl1.Location = new System.Drawing.Point(20, 60);
            this.metroTabControl1.Name = "metroTabControl1";
            this.metroTabControl1.SelectedIndex = 2;
            this.metroTabControl1.Size = new System.Drawing.Size(776, 628);
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
            this.News.Size = new System.Drawing.Size(768, 571);
            this.News.TabIndex = 0;
            this.News.Text = "News";
            this.News.VerticalScrollbarBarColor = true;
            this.News.VerticalScrollbarHighlightOnWheel = false;
            this.News.VerticalScrollbarSize = 10;
            // 
            // newsTbNews
            // 
            this.newsTbNews.BackColor = System.Drawing.SystemColors.ButtonFace;
            // 
            // 
            // 
            this.newsTbNews.CustomButton.Image = null;
            this.newsTbNews.CustomButton.Location = new System.Drawing.Point(198, 1);
            this.newsTbNews.CustomButton.Name = "";
            this.newsTbNews.CustomButton.Size = new System.Drawing.Size(569, 569);
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
            this.newsTbNews.Size = new System.Drawing.Size(768, 571);
            this.newsTbNews.TabIndex = 2;
            this.newsTbNews.Text = "this is text";
            this.newsTbNews.UseCustomBackColor = true;
            this.newsTbNews.UseSelectable = true;
            this.newsTbNews.UseStyleColors = true;
            this.newsTbNews.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.newsTbNews.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            // 
            // Viralstyle
            // 
            this.Viralstyle.Controls.Add(this.groupBox3);
            this.Viralstyle.Controls.Add(this.flowLayoutMokcup);
            this.Viralstyle.Controls.Add(this.metroLabel2);
            this.Viralstyle.Controls.Add(this.metroLabel1);
            this.Viralstyle.Controls.Add(this.metroPanel1);
            this.Viralstyle.HorizontalScrollbarBarColor = true;
            this.Viralstyle.HorizontalScrollbarHighlightOnWheel = false;
            this.Viralstyle.HorizontalScrollbarSize = 10;
            this.Viralstyle.Location = new System.Drawing.Point(4, 38);
            this.Viralstyle.Name = "Viralstyle";
            this.Viralstyle.Size = new System.Drawing.Size(768, 586);
            this.Viralstyle.TabIndex = 1;
            this.Viralstyle.Text = "ViralStyle";
            this.Viralstyle.VerticalScrollbarBarColor = true;
            this.Viralstyle.VerticalScrollbarHighlightOnWheel = false;
            this.Viralstyle.VerticalScrollbarSize = 10;
            // 
            // groupBox3
            // 
            this.groupBox3.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox3.Controls.Add(this.listLogs);
            this.groupBox3.Controls.Add(this.listViewLogo);
            this.groupBox3.Controls.Add(this.metroLabel8);
            this.groupBox3.Controls.Add(this.btnLoadLogo);
            this.groupBox3.Controls.Add(this.btnUpload);
            this.groupBox3.Location = new System.Drawing.Point(504, 3);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(279, 559);
            this.groupBox3.TabIndex = 10;
            this.groupBox3.TabStop = false;
            // 
            // metroLabel8
            // 
            this.metroLabel8.AutoSize = true;
            this.metroLabel8.Location = new System.Drawing.Point(73, 16);
            this.metroLabel8.Name = "metroLabel8";
            this.metroLabel8.Size = new System.Drawing.Size(99, 19);
            this.metroLabel8.TabIndex = 5;
            this.metroLabel8.Text = "Danh sach logo";
            // 
            // btnUpload
            // 
            this.btnUpload.FontSize = MetroFramework.MetroButtonSize.Medium;
            this.btnUpload.Location = new System.Drawing.Point(73, 496);
            this.btnUpload.Name = "btnUpload";
            this.btnUpload.Size = new System.Drawing.Size(113, 53);
            this.btnUpload.TabIndex = 4;
            this.btnUpload.Text = "Start Upload";
            this.btnUpload.UseCustomForeColor = true;
            this.btnUpload.UseSelectable = true;
            this.btnUpload.UseStyleColors = true;
            this.btnUpload.Click += new System.EventHandler(this.btnUpload_Click);
            // 
            // metroLabel5
            // 
            this.metroLabel5.AutoSize = true;
            this.metroLabel5.Location = new System.Drawing.Point(10, 200);
            this.metroLabel5.Name = "metroLabel5";
            this.metroLabel5.Size = new System.Drawing.Size(102, 19);
            this.metroLabel5.TabIndex = 5;
            this.metroLabel5.Text = "Template Name";
            // 
            // tbTemplateName
            // 
            // 
            // 
            // 
            this.tbTemplateName.CustomButton.Image = null;
            this.tbTemplateName.CustomButton.Location = new System.Drawing.Point(183, 1);
            this.tbTemplateName.CustomButton.Name = "";
            this.tbTemplateName.CustomButton.Size = new System.Drawing.Size(21, 21);
            this.tbTemplateName.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.tbTemplateName.CustomButton.TabIndex = 1;
            this.tbTemplateName.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.tbTemplateName.CustomButton.UseSelectable = true;
            this.tbTemplateName.CustomButton.Visible = false;
            this.tbTemplateName.Lines = new string[0];
            this.tbTemplateName.Location = new System.Drawing.Point(121, 200);
            this.tbTemplateName.MaxLength = 32767;
            this.tbTemplateName.Name = "tbTemplateName";
            this.tbTemplateName.PasswordChar = '\0';
            this.tbTemplateName.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.tbTemplateName.SelectedText = "";
            this.tbTemplateName.SelectionLength = 0;
            this.tbTemplateName.SelectionStart = 0;
            this.tbTemplateName.ShortcutsEnabled = true;
            this.tbTemplateName.Size = new System.Drawing.Size(205, 23);
            this.tbTemplateName.TabIndex = 6;
            this.tbTemplateName.UseSelectable = true;
            this.tbTemplateName.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.tbTemplateName.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            // 
            // btnLoadTemplate
            // 
            this.btnLoadTemplate.Location = new System.Drawing.Point(229, 229);
            this.btnLoadTemplate.Name = "btnLoadTemplate";
            this.btnLoadTemplate.Size = new System.Drawing.Size(97, 36);
            this.btnLoadTemplate.TabIndex = 4;
            this.btnLoadTemplate.Text = "Load Template";
            this.btnLoadTemplate.UseSelectable = true;
            this.btnLoadTemplate.Click += new System.EventHandler(this.btnLoadTemplate_Click);
            // 
            // flowLayoutMokcup
            // 
            this.flowLayoutMokcup.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.flowLayoutMokcup.AutoScroll = true;
            this.flowLayoutMokcup.Controls.Add(this.mockup1);
            this.flowLayoutMokcup.Location = new System.Drawing.Point(3, 315);
            this.flowLayoutMokcup.Name = "flowLayoutMokcup";
            this.flowLayoutMokcup.Size = new System.Drawing.Size(494, 247);
            this.flowLayoutMokcup.TabIndex = 8;
            this.flowLayoutMokcup.WrapContents = false;
            // 
            // metroLabel2
            // 
            this.metroLabel2.AutoSize = true;
            this.metroLabel2.Location = new System.Drawing.Point(13, 58);
            this.metroLabel2.Name = "metroLabel2";
            this.metroLabel2.Size = new System.Drawing.Size(74, 19);
            this.metroLabel2.TabIndex = 5;
            this.metroLabel2.Text = "Description";
            // 
            // tbDescription
            // 
            // 
            // 
            // 
            this.tbDescription.CustomButton.Image = null;
            this.tbDescription.CustomButton.Location = new System.Drawing.Point(145, 1);
            this.tbDescription.CustomButton.Name = "";
            this.tbDescription.CustomButton.Size = new System.Drawing.Size(59, 59);
            this.tbDescription.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.tbDescription.CustomButton.TabIndex = 1;
            this.tbDescription.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.tbDescription.CustomButton.UseSelectable = true;
            this.tbDescription.CustomButton.Visible = false;
            this.tbDescription.Lines = new string[0];
            this.tbDescription.Location = new System.Drawing.Point(121, 55);
            this.tbDescription.MaxLength = 32767;
            this.tbDescription.Multiline = true;
            this.tbDescription.Name = "tbDescription";
            this.tbDescription.PasswordChar = '\0';
            this.tbDescription.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.tbDescription.SelectedText = "";
            this.tbDescription.SelectionLength = 0;
            this.tbDescription.SelectionStart = 0;
            this.tbDescription.ShortcutsEnabled = true;
            this.tbDescription.Size = new System.Drawing.Size(205, 61);
            this.tbDescription.TabIndex = 6;
            this.tbDescription.UseSelectable = true;
            this.tbDescription.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.tbDescription.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            // 
            // tbTags
            // 
            // 
            // 
            // 
            this.tbTags.CustomButton.Image = null;
            this.tbTags.CustomButton.Location = new System.Drawing.Point(183, 1);
            this.tbTags.CustomButton.Name = "";
            this.tbTags.CustomButton.Size = new System.Drawing.Size(21, 21);
            this.tbTags.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.tbTags.CustomButton.TabIndex = 1;
            this.tbTags.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.tbTags.CustomButton.UseSelectable = true;
            this.tbTags.CustomButton.Visible = false;
            this.tbTags.Lines = new string[0];
            this.tbTags.Location = new System.Drawing.Point(121, 167);
            this.tbTags.MaxLength = 32767;
            this.tbTags.Name = "tbTags";
            this.tbTags.PasswordChar = '\0';
            this.tbTags.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.tbTags.SelectedText = "";
            this.tbTags.SelectionLength = 0;
            this.tbTags.SelectionStart = 0;
            this.tbTags.ShortcutsEnabled = true;
            this.tbTags.Size = new System.Drawing.Size(205, 23);
            this.tbTags.TabIndex = 6;
            this.tbTags.UseSelectable = true;
            this.tbTags.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.tbTags.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            // 
            // metroLabel4
            // 
            this.metroLabel4.AutoSize = true;
            this.metroLabel4.Location = new System.Drawing.Point(10, 167);
            this.metroLabel4.Name = "metroLabel4";
            this.metroLabel4.Size = new System.Drawing.Size(34, 19);
            this.metroLabel4.TabIndex = 5;
            this.metroLabel4.Text = "Tags";
            // 
            // tbCampUrl
            // 
            // 
            // 
            // 
            this.tbCampUrl.CustomButton.Image = null;
            this.tbCampUrl.CustomButton.Location = new System.Drawing.Point(183, 1);
            this.tbCampUrl.CustomButton.Name = "";
            this.tbCampUrl.CustomButton.Size = new System.Drawing.Size(21, 21);
            this.tbCampUrl.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.tbCampUrl.CustomButton.TabIndex = 1;
            this.tbCampUrl.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.tbCampUrl.CustomButton.UseSelectable = true;
            this.tbCampUrl.CustomButton.Visible = false;
            this.tbCampUrl.Lines = new string[0];
            this.tbCampUrl.Location = new System.Drawing.Point(121, 132);
            this.tbCampUrl.MaxLength = 32767;
            this.tbCampUrl.Name = "tbCampUrl";
            this.tbCampUrl.PasswordChar = '\0';
            this.tbCampUrl.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.tbCampUrl.SelectedText = "";
            this.tbCampUrl.SelectionLength = 0;
            this.tbCampUrl.SelectionStart = 0;
            this.tbCampUrl.ShortcutsEnabled = true;
            this.tbCampUrl.Size = new System.Drawing.Size(205, 23);
            this.tbCampUrl.TabIndex = 6;
            this.tbCampUrl.UseSelectable = true;
            this.tbCampUrl.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.tbCampUrl.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            // 
            // metroLabel3
            // 
            this.metroLabel3.AutoSize = true;
            this.metroLabel3.Location = new System.Drawing.Point(10, 136);
            this.metroLabel3.Name = "metroLabel3";
            this.metroLabel3.Size = new System.Drawing.Size(66, 19);
            this.metroLabel3.TabIndex = 5;
            this.metroLabel3.Text = "Camp Url";
            // 
            // tbTitle
            // 
            // 
            // 
            // 
            this.tbTitle.CustomButton.Image = null;
            this.tbTitle.CustomButton.Location = new System.Drawing.Point(183, 1);
            this.tbTitle.CustomButton.Name = "";
            this.tbTitle.CustomButton.Size = new System.Drawing.Size(21, 21);
            this.tbTitle.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.tbTitle.CustomButton.TabIndex = 1;
            this.tbTitle.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.tbTitle.CustomButton.UseSelectable = true;
            this.tbTitle.CustomButton.Visible = false;
            this.tbTitle.Lines = new string[0];
            this.tbTitle.Location = new System.Drawing.Point(121, 15);
            this.tbTitle.MaxLength = 32767;
            this.tbTitle.Name = "tbTitle";
            this.tbTitle.PasswordChar = '\0';
            this.tbTitle.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.tbTitle.SelectedText = "";
            this.tbTitle.SelectionLength = 0;
            this.tbTitle.SelectionStart = 0;
            this.tbTitle.ShortcutsEnabled = true;
            this.tbTitle.Size = new System.Drawing.Size(205, 23);
            this.tbTitle.TabIndex = 6;
            this.tbTitle.UseSelectable = true;
            this.tbTitle.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.tbTitle.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            // 
            // metroLabel1
            // 
            this.metroLabel1.AutoSize = true;
            this.metroLabel1.Location = new System.Drawing.Point(13, 18);
            this.metroLabel1.Name = "metroLabel1";
            this.metroLabel1.Size = new System.Drawing.Size(33, 19);
            this.metroLabel1.TabIndex = 5;
            this.metroLabel1.Text = "Title";
            // 
            // metroPanel1
            // 
            this.metroPanel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.metroPanel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.metroPanel1.Controls.Add(this.btnLoadTemplate);
            this.metroPanel1.Controls.Add(this.metroLabel5);
            this.metroPanel1.Controls.Add(this.tbTemplateName);
            this.metroPanel1.Controls.Add(this.metroLabel4);
            this.metroPanel1.Controls.Add(this.tbDescription);
            this.metroPanel1.Controls.Add(this.metroLabel3);
            this.metroPanel1.Controls.Add(this.tbTags);
            this.metroPanel1.Controls.Add(this.numGoal);
            this.metroPanel1.Controls.Add(this.chbShowBack);
            this.metroPanel1.Controls.Add(this.tbCampUrl);
            this.metroPanel1.Controls.Add(this.chbShowGoal);
            this.metroPanel1.Controls.Add(this.chbPageTimer);
            this.metroPanel1.Controls.Add(this.tbTitle);
            this.metroPanel1.Controls.Add(this.chbHideMarketPlace);
            this.metroPanel1.Controls.Add(this.chbAutoExtend);
            this.metroPanel1.Controls.Add(this.chbAutoRelaunch);
            this.metroPanel1.Controls.Add(this.btnSaveTemplate);
            this.metroPanel1.Controls.Add(this.metroLabel7);
            this.metroPanel1.HorizontalScrollbarBarColor = true;
            this.metroPanel1.HorizontalScrollbarHighlightOnWheel = false;
            this.metroPanel1.HorizontalScrollbarSize = 10;
            this.metroPanel1.Location = new System.Drawing.Point(3, 3);
            this.metroPanel1.Name = "metroPanel1";
            this.metroPanel1.Size = new System.Drawing.Size(494, 306);
            this.metroPanel1.TabIndex = 7;
            this.metroPanel1.UseCustomBackColor = true;
            this.metroPanel1.VerticalScrollbarBarColor = true;
            this.metroPanel1.VerticalScrollbarHighlightOnWheel = false;
            this.metroPanel1.VerticalScrollbarSize = 10;
            // 
            // numGoal
            // 
            this.numGoal.Location = new System.Drawing.Point(398, 14);
            this.numGoal.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.numGoal.Name = "numGoal";
            this.numGoal.Size = new System.Drawing.Size(71, 20);
            this.numGoal.TabIndex = 6;
            this.numGoal.Value = new decimal(new int[] {
            50,
            0,
            0,
            0});
            // 
            // chbShowBack
            // 
            this.chbShowBack.AutoSize = true;
            this.chbShowBack.Location = new System.Drawing.Point(346, 153);
            this.chbShowBack.Name = "chbShowBack";
            this.chbShowBack.Size = new System.Drawing.Size(121, 15);
            this.chbShowBack.TabIndex = 5;
            this.chbShowBack.Text = "Show Back Default";
            this.chbShowBack.UseSelectable = true;
            // 
            // chbShowGoal
            // 
            this.chbShowGoal.AutoSize = true;
            this.chbShowGoal.Location = new System.Drawing.Point(346, 132);
            this.chbShowGoal.Name = "chbShowGoal";
            this.chbShowGoal.Size = new System.Drawing.Size(137, 15);
            this.chbShowGoal.TabIndex = 5;
            this.chbShowGoal.Text = "Campaign Show Goal";
            this.chbShowGoal.UseSelectable = true;
            // 
            // chbPageTimer
            // 
            this.chbPageTimer.AutoSize = true;
            this.chbPageTimer.Location = new System.Drawing.Point(346, 106);
            this.chbPageTimer.Name = "chbPageTimer";
            this.chbPageTimer.Size = new System.Drawing.Size(141, 15);
            this.chbPageTimer.TabIndex = 5;
            this.chbPageTimer.Text = "Campaign Page Timer";
            this.chbPageTimer.UseSelectable = true;
            // 
            // chbHideMarketPlace
            // 
            this.chbHideMarketPlace.AutoSize = true;
            this.chbHideMarketPlace.Location = new System.Drawing.Point(346, 85);
            this.chbHideMarketPlace.Name = "chbHideMarketPlace";
            this.chbHideMarketPlace.Size = new System.Drawing.Size(119, 15);
            this.chbHideMarketPlace.TabIndex = 5;
            this.chbHideMarketPlace.Text = "Hide Market Place";
            this.chbHideMarketPlace.UseSelectable = true;
            // 
            // chbAutoExtend
            // 
            this.chbAutoExtend.AutoSize = true;
            this.chbAutoExtend.Location = new System.Drawing.Point(346, 64);
            this.chbAutoExtend.Name = "chbAutoExtend";
            this.chbAutoExtend.Size = new System.Drawing.Size(145, 15);
            this.chbAutoExtend.TabIndex = 5;
            this.chbAutoExtend.Text = "Campaign Auto Extend";
            this.chbAutoExtend.UseSelectable = true;
            // 
            // chbAutoRelaunch
            // 
            this.chbAutoRelaunch.AutoSize = true;
            this.chbAutoRelaunch.Location = new System.Drawing.Point(346, 43);
            this.chbAutoRelaunch.Name = "chbAutoRelaunch";
            this.chbAutoRelaunch.Size = new System.Drawing.Size(101, 15);
            this.chbAutoRelaunch.TabIndex = 5;
            this.chbAutoRelaunch.Text = "Auto Relaunch";
            this.chbAutoRelaunch.UseSelectable = true;
            // 
            // btnSaveTemplate
            // 
            this.btnSaveTemplate.Location = new System.Drawing.Point(121, 229);
            this.btnSaveTemplate.Name = "btnSaveTemplate";
            this.btnSaveTemplate.Size = new System.Drawing.Size(92, 36);
            this.btnSaveTemplate.TabIndex = 4;
            this.btnSaveTemplate.Text = "Save Template";
            this.btnSaveTemplate.UseSelectable = true;
            this.btnSaveTemplate.Click += new System.EventHandler(this.metroButton1_Click);
            // 
            // metroLabel7
            // 
            this.metroLabel7.AutoSize = true;
            this.metroLabel7.Location = new System.Drawing.Point(346, 15);
            this.metroLabel7.Name = "metroLabel7";
            this.metroLabel7.Size = new System.Drawing.Size(36, 19);
            this.metroLabel7.TabIndex = 5;
            this.metroLabel7.Text = "Goal";
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.panel1);
            this.tabPage1.Location = new System.Drawing.Point(4, 38);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Size = new System.Drawing.Size(768, 586);
            this.tabPage1.TabIndex = 2;
            this.tabPage1.Text = "Options";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.panel1.Controls.Add(this.groupBox2);
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(783, 568);
            this.panel1.TabIndex = 0;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.opTbPass);
            this.groupBox2.Controls.Add(this.metroLabel9);
            this.groupBox2.Controls.Add(this.opTbEmail);
            this.groupBox2.Controls.Add(this.metroLabel6);
            this.groupBox2.Controls.Add(this.opChbShowMockup);
            this.groupBox2.Controls.Add(this.opBtnSave);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox2.Location = new System.Drawing.Point(0, 0);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(783, 568);
            this.groupBox2.TabIndex = 10;
            this.groupBox2.TabStop = false;
            // 
            // opChbShowMockup
            // 
            this.opChbShowMockup.AutoSize = true;
            this.opChbShowMockup.Location = new System.Drawing.Point(192, 130);
            this.opChbShowMockup.Name = "opChbShowMockup";
            this.opChbShowMockup.Size = new System.Drawing.Size(141, 17);
            this.opChbShowMockup.TabIndex = 5;
            this.opChbShowMockup.Text = "Show ViralStyle Mockup";
            this.opChbShowMockup.UseVisualStyleBackColor = true;
            // 
            // opBtnSave
            // 
            this.opBtnSave.Location = new System.Drawing.Point(192, 163);
            this.opBtnSave.Name = "opBtnSave";
            this.opBtnSave.Size = new System.Drawing.Size(102, 53);
            this.opBtnSave.TabIndex = 4;
            this.opBtnSave.Text = "Save";
            this.opBtnSave.UseSelectable = true;
            this.opBtnSave.Click += new System.EventHandler(this.opBtnSave_Click);
            // 
            // viralMockupImageList
            // 
            this.viralMockupImageList.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("viralMockupImageList.ImageStream")));
            this.viralMockupImageList.TransparentColor = System.Drawing.Color.Transparent;
            this.viralMockupImageList.Images.SetKeyName(0, "2c7c6682-2c53-bf34-b12d-156cd334c434.png");
            this.viralMockupImageList.Images.SetKeyName(1, "3a1cf383-5ab3-3e74-65a8-a90d972ec91c.png");
            this.viralMockupImageList.Images.SetKeyName(2, "3fc71870-7d1e-37f4-c56d-c9384458f6ae.png");
            this.viralMockupImageList.Images.SetKeyName(3, "3fe3a8c4-8bc1-f954-5dab-0a2646575da9.png");
            this.viralMockupImageList.Images.SetKeyName(4, "5d22e2d0-37ac-ed04-e1d9-8a5cf9aa324e.png");
            this.viralMockupImageList.Images.SetKeyName(5, "6c084b2d-7218-1104-49ad-fa51ad7f71fd.png");
            this.viralMockupImageList.Images.SetKeyName(6, "7f5953fd-e64e-05f4-056b-0ebe5b1e9fb3.png");
            this.viralMockupImageList.Images.SetKeyName(7, "8e87de49-49ab-1784-65ef-8f0ed62c843c.png");
            this.viralMockupImageList.Images.SetKeyName(8, "8e0649bb-10a4-46e4-5501-b7c296c6138e.png");
            this.viralMockupImageList.Images.SetKeyName(9, "17FFE833-46AC-4E5A-866D-4DA31BD61C79_medium_back.png");
            this.viralMockupImageList.Images.SetKeyName(10, "17FFE833-46AC-4E5A-866D-4DA31BD61C79_medium_front.png");
            this.viralMockupImageList.Images.SetKeyName(11, "34e8aa1f-81c7-5dd4-5d0f-bf1b4aabaffe.png");
            this.viralMockupImageList.Images.SetKeyName(12, "56c06fc0-ca00-3154-a958-af788e96de20.png");
            this.viralMockupImageList.Images.SetKeyName(13, "0075c2bb-cd4e-53f4-299d-666576fc61b0.png");
            this.viralMockupImageList.Images.SetKeyName(14, "77d34579-7fea-3b44-4188-b528afa9e26e.png");
            this.viralMockupImageList.Images.SetKeyName(15, "78cae46c-1ad5-3954-91a1-20a6dcad0757.png");
            this.viralMockupImageList.Images.SetKeyName(16, "81e4c7b0-043e-8d64-ad21-fb44b3eaff8a.png");
            this.viralMockupImageList.Images.SetKeyName(17, "182B619C-DA3D-417D-8FC5-22BCFCDFEA7A.png");
            this.viralMockupImageList.Images.SetKeyName(18, "258CB06B-AEB2-4612-A382-1CCB2EFA1D34.png");
            this.viralMockupImageList.Images.SetKeyName(19, "357ba7d0-996c-f2e4-6526-c05484de236d.png");
            this.viralMockupImageList.Images.SetKeyName(20, "677ed8b8-2aae-4224-b9e4-212cc00df69c.png");
            this.viralMockupImageList.Images.SetKeyName(21, "743c3cb9-b94f-dd94-7d85-35ad58af7b99.png");
            this.viralMockupImageList.Images.SetKeyName(22, "0852f2d8-82ec-56c4-3151-31b2e79ce31f.png");
            this.viralMockupImageList.Images.SetKeyName(23, "910c587e-2556-9b94-6185-d20537b2a437.png");
            this.viralMockupImageList.Images.SetKeyName(24, "947fa7a2-8aec-4ca4-7d04-62b2ac4014ad.png");
            this.viralMockupImageList.Images.SetKeyName(25, "959c73cb-257e-0014-31a3-0c1fdc184993.png");
            this.viralMockupImageList.Images.SetKeyName(26, "963e89aa-0164-b8c4-c5e5-faa151a56a1e.png");
            this.viralMockupImageList.Images.SetKeyName(27, "2016_05_09_hoodie_back.png");
            this.viralMockupImageList.Images.SetKeyName(28, "2016_05_09_shirt_back.png");
            this.viralMockupImageList.Images.SetKeyName(29, "2016_05_12_hoodie_front.png");
            this.viralMockupImageList.Images.SetKeyName(30, "2016_05_12_shirt_front.png");
            this.viralMockupImageList.Images.SetKeyName(31, "2016_05_15_dogtag.png");
            this.viralMockupImageList.Images.SetKeyName(32, "8936e22b-4a6b-2c54-15a3-074e0b990909.png");
            this.viralMockupImageList.Images.SetKeyName(33, "8761149f-a9eb-a014-818f-a6fa2b108c19.png");
            this.viralMockupImageList.Images.SetKeyName(34, "59380263-8a3b-4e84-f52a-16c32a1f0a13.png");
            this.viralMockupImageList.Images.SetKeyName(35, "a8d3b415-7c09-f6f4-39d9-d599d68073f5.png");
            this.viralMockupImageList.Images.SetKeyName(36, "b9d2944a-73f5-34d4-21fe-5811128f372e.png");
            this.viralMockupImageList.Images.SetKeyName(37, "b150c710-6597-4484-99d5-39b3f3338795.png");
            this.viralMockupImageList.Images.SetKeyName(38, "b702e3eb-b44c-5684-9d76-94c326fe0691.png");
            this.viralMockupImageList.Images.SetKeyName(39, "b730f829-6fb6-ac14-5d56-6a60e0bcdad9.png");
            this.viralMockupImageList.Images.SetKeyName(40, "bd0bb620-a1bb-a964-650e-645670bf9b28.png");
            this.viralMockupImageList.Images.SetKeyName(41, "bd5bf852-3f58-fd04-6542-c571670cbd84.png");
            this.viralMockupImageList.Images.SetKeyName(42, "bd09c9fc-76ad-6544-015f-f174638ceb7a.png");
            this.viralMockupImageList.Images.SetKeyName(43, "bdcd3c19-de3e-5db4-3df9-e070bda24b4b.png");
            this.viralMockupImageList.Images.SetKeyName(44, "ccab1f3e-91a1-2dc4-f193-f3161d5900cd.png");
            this.viralMockupImageList.Images.SetKeyName(45, "CoolDri-Tee-Back.png");
            this.viralMockupImageList.Images.SetKeyName(46, "CoolDri-Tee-Front.png");
            this.viralMockupImageList.Images.SetKeyName(47, "curve_hat.png");
            this.viralMockupImageList.Images.SetKeyName(48, "d4e142a5-046b-edd4-3db6-2a9634ba8ce9.png");
            this.viralMockupImageList.Images.SetKeyName(49, "d8af9748-e821-2934-1d61-da8683e6945b.png");
            this.viralMockupImageList.Images.SetKeyName(50, "d8ed3f17-ded7-1374-6572-2a8331462213.png");
            this.viralMockupImageList.Images.SetKeyName(51, "e51db61e-a90d-ac44-5d49-d95aff373588.png");
            this.viralMockupImageList.Images.SetKeyName(52, "ec92e151-444e-cbe4-7505-34c7e9cdd2af.png");
            this.viralMockupImageList.Images.SetKeyName(53, "ef6a7d4c-d996-6094-95ff-ae0192ce2a8d.png");
            this.viralMockupImageList.Images.SetKeyName(54, "f1b7eeac-d917-0cf4-7df9-0f18bbe765fa.png");
            this.viralMockupImageList.Images.SetKeyName(55, "f2b1799f-8099-4b34-f59d-86cf15c6d885.png");
            this.viralMockupImageList.Images.SetKeyName(56, "f2ff641d-43db-3c64-8568-8a8bb54a7d26.png");
            this.viralMockupImageList.Images.SetKeyName(57, "f8c0d96d-7575-7604-1549-db8c366a0004.png");
            this.viralMockupImageList.Images.SetKeyName(58, "f279bfff-6ce5-c2c4-99f3-e9db759a20b8.png");
            this.viralMockupImageList.Images.SetKeyName(59, "f0813a1c-7010-0364-1d2b-477ed1c2b5f4.png");
            this.viralMockupImageList.Images.SetKeyName(60, "f7141ac0-178c-6304-c1a4-403d5ac0483e.png");
            this.viralMockupImageList.Images.SetKeyName(61, "ff1a0f8d-32ad-1dd4-81c8-08e68a6ab225.png");
            this.viralMockupImageList.Images.SetKeyName(62, "ladies_muscle_large_back.png");
            this.viralMockupImageList.Images.SetKeyName(63, "ladies_muscle_large_front.png");
            this.viralMockupImageList.Images.SetKeyName(64, "new_clock.png");
            this.viralMockupImageList.Images.SetKeyName(65, "PerformanceLadiesTee-Back.png");
            this.viralMockupImageList.Images.SetKeyName(66, "PerformanceLadiesTee-Front.png");
            this.viralMockupImageList.Images.SetKeyName(67, "Racerback-Back.png");
            this.viralMockupImageList.Images.SetKeyName(68, "Racerback-Front.png");
            // 
            // bgWorker
            // 
            this.bgWorker.WorkerReportsProgress = true;
            this.bgWorker.DoWork += new System.ComponentModel.DoWorkEventHandler(this.bgWorker_DoWork);
            this.bgWorker.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.bgWorker_ProgressChanged);
            this.bgWorker.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.bgWorker_RunWorkerCompleted);
            // 
            // btnLoadLogo
            // 
            this.btnLoadLogo.Location = new System.Drawing.Point(84, 263);
            this.btnLoadLogo.Name = "btnLoadLogo";
            this.btnLoadLogo.Size = new System.Drawing.Size(102, 36);
            this.btnLoadLogo.TabIndex = 4;
            this.btnLoadLogo.Text = "Load Logos";
            this.btnLoadLogo.UseSelectable = true;
            this.btnLoadLogo.Click += new System.EventHandler(this.btnLoadLogo_Click);
            // 
            // listViewLogo
            // 
            this.listViewLogo.FormattingEnabled = true;
            this.listViewLogo.Location = new System.Drawing.Point(19, 43);
            this.listViewLogo.Name = "listViewLogo";
            this.listViewLogo.Size = new System.Drawing.Size(221, 199);
            this.listViewLogo.TabIndex = 6;
            // 
            // mockup1
            // 
            this.mockup1.Colors = null;
            this.mockup1.Location = new System.Drawing.Point(3, 3);
            this.mockup1.Name = "mockup1";
            this.mockup1.Size = new System.Drawing.Size(210, 220);
            this.mockup1.TabIndex = 0;
            this.mockup1.UseSelectable = true;
            // 
            // mockupControl1
            // 
            this.mockupControl1.Location = new System.Drawing.Point(0, 0);
            this.mockupControl1.Name = "mockupControl1";
            this.mockupControl1.Size = new System.Drawing.Size(150, 150);
            this.mockupControl1.TabIndex = 0;
            // 
            // listLogs
            // 
            this.listLogs.FormattingEnabled = true;
            this.listLogs.Location = new System.Drawing.Point(19, 312);
            this.listLogs.Name = "listLogs";
            this.listLogs.Size = new System.Drawing.Size(221, 173);
            this.listLogs.TabIndex = 6;
            // 
            // toolStrip1
            // 
            this.toolStrip1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsProgress,
            this.tsLblProgress});
            this.toolStrip1.Location = new System.Drawing.Point(20, 663);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(776, 25);
            this.toolStrip1.TabIndex = 1;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // tsProgress
            // 
            this.tsProgress.Name = "tsProgress";
            this.tsProgress.Size = new System.Drawing.Size(300, 22);
            // 
            // tsLblProgress
            // 
            this.tsLblProgress.Name = "tsLblProgress";
            this.tsLblProgress.Size = new System.Drawing.Size(16, 22);
            this.tsLblProgress.Text = "...";
            // 
            // opTbEmail
            // 
            // 
            // 
            // 
            this.opTbEmail.CustomButton.Image = null;
            this.opTbEmail.CustomButton.Location = new System.Drawing.Point(183, 1);
            this.opTbEmail.CustomButton.Name = "";
            this.opTbEmail.CustomButton.Size = new System.Drawing.Size(21, 21);
            this.opTbEmail.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.opTbEmail.CustomButton.TabIndex = 1;
            this.opTbEmail.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.opTbEmail.CustomButton.UseSelectable = true;
            this.opTbEmail.CustomButton.Visible = false;
            this.opTbEmail.Lines = new string[0];
            this.opTbEmail.Location = new System.Drawing.Point(192, 37);
            this.opTbEmail.MaxLength = 32767;
            this.opTbEmail.Name = "opTbEmail";
            this.opTbEmail.PasswordChar = '\0';
            this.opTbEmail.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.opTbEmail.SelectedText = "";
            this.opTbEmail.SelectionLength = 0;
            this.opTbEmail.SelectionStart = 0;
            this.opTbEmail.ShortcutsEnabled = true;
            this.opTbEmail.Size = new System.Drawing.Size(205, 23);
            this.opTbEmail.TabIndex = 8;
            this.opTbEmail.UseSelectable = true;
            this.opTbEmail.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.opTbEmail.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            // 
            // metroLabel6
            // 
            this.metroLabel6.AutoSize = true;
            this.metroLabel6.Location = new System.Drawing.Point(51, 41);
            this.metroLabel6.Name = "metroLabel6";
            this.metroLabel6.Size = new System.Drawing.Size(98, 19);
            this.metroLabel6.TabIndex = 7;
            this.metroLabel6.Text = "ViralStyle Email";
            // 
            // metroLabel9
            // 
            this.metroLabel9.AutoSize = true;
            this.metroLabel9.Location = new System.Drawing.Point(51, 85);
            this.metroLabel9.Name = "metroLabel9";
            this.metroLabel9.Size = new System.Drawing.Size(120, 19);
            this.metroLabel9.TabIndex = 7;
            this.metroLabel9.Text = "ViralStyle Password";
            // 
            // opTbPass
            // 
            // 
            // 
            // 
            this.opTbPass.CustomButton.Image = null;
            this.opTbPass.CustomButton.Location = new System.Drawing.Point(183, 1);
            this.opTbPass.CustomButton.Name = "";
            this.opTbPass.CustomButton.Size = new System.Drawing.Size(21, 21);
            this.opTbPass.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.opTbPass.CustomButton.TabIndex = 1;
            this.opTbPass.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.opTbPass.CustomButton.UseSelectable = true;
            this.opTbPass.CustomButton.Visible = false;
            this.opTbPass.Lines = new string[0];
            this.opTbPass.Location = new System.Drawing.Point(192, 81);
            this.opTbPass.MaxLength = 32767;
            this.opTbPass.Name = "opTbPass";
            this.opTbPass.PasswordChar = '●';
            this.opTbPass.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.opTbPass.SelectedText = "";
            this.opTbPass.SelectionLength = 0;
            this.opTbPass.SelectionStart = 0;
            this.opTbPass.ShortcutsEnabled = true;
            this.opTbPass.Size = new System.Drawing.Size(205, 23);
            this.opTbPass.TabIndex = 8;
            this.opTbPass.UseSelectable = true;
            this.opTbPass.UseSystemPasswordChar = true;
            this.opTbPass.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.opTbPass.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(816, 708);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.metroTabControl1);
            this.Name = "MainForm";
            this.Text = "Auto Upload";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.metroTabControl1.ResumeLayout(false);
            this.News.ResumeLayout(false);
            this.Viralstyle.ResumeLayout(false);
            this.Viralstyle.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.flowLayoutMokcup.ResumeLayout(false);
            this.metroPanel1.ResumeLayout(false);
            this.metroPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numGoal)).EndInit();
            this.tabPage1.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private MetroFramework.Controls.MetroTabControl metroTabControl1;
        private MetroFramework.Controls.MetroTabPage News;
        private MetroFramework.Controls.MetroTabPage Viralstyle;
        private MetroFramework.Controls.MetroTextBox newsTbNews;
        private System.Windows.Forms.ImageList viralMockupImageList;
        private MetroFramework.Controls.MetroLabel metroLabel2;
        private MetroFramework.Controls.MetroTextBox tbDescription;
        private MetroFramework.Controls.MetroTextBox tbTitle;
        private MetroFramework.Controls.MetroLabel metroLabel1;
        private MetroFramework.Controls.MetroTextBox tbTags;
        private MetroFramework.Controls.MetroLabel metroLabel4;
        private MetroFramework.Controls.MetroTextBox tbCampUrl;
        private MetroFramework.Controls.MetroLabel metroLabel3;
        private MetroFramework.Controls.MetroButton btnSaveTemplate;
        private MetroFramework.Controls.MetroPanel metroPanel1;
        private MetroFramework.Controls.MetroCheckBox chbAutoRelaunch;
        private MetroFramework.Controls.MetroCheckBox chbShowGoal;
        private MetroFramework.Controls.MetroCheckBox chbPageTimer;
        private MetroFramework.Controls.MetroCheckBox chbHideMarketPlace;
        private MetroFramework.Controls.MetroCheckBox chbAutoExtend;
        private System.Windows.Forms.TabPage tabPage1;
        private Controls.MockupControl mockupControl1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutMokcup;
        private Controls.Mockup mockup1;
        private System.ComponentModel.BackgroundWorker bgWorker;
        private MetroFramework.Controls.MetroLabel metroLabel5;
        private MetroFramework.Controls.MetroTextBox tbTemplateName;
        private MetroFramework.Controls.MetroButton btnLoadTemplate;
        private System.Windows.Forms.GroupBox groupBox2;
        private MetroFramework.Controls.MetroButton opBtnSave;
        private System.Windows.Forms.CheckBox opChbShowMockup;
        private System.Windows.Forms.NumericUpDown numGoal;
        private MetroFramework.Controls.MetroLabel metroLabel7;
        private MetroFramework.Controls.MetroCheckBox chbShowBack;
        private System.Windows.Forms.GroupBox groupBox3;
        private MetroFramework.Controls.MetroLabel metroLabel8;
        private MetroFramework.Controls.MetroButton btnUpload;
        private MetroFramework.Controls.MetroButton btnLoadLogo;
        private System.Windows.Forms.ListBox listViewLogo;
        private System.Windows.Forms.ListBox listLogs;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripProgressBar tsProgress;
        private System.Windows.Forms.ToolStripLabel tsLblProgress;
        private MetroFramework.Controls.MetroTextBox opTbEmail;
        private MetroFramework.Controls.MetroLabel metroLabel6;
        private MetroFramework.Controls.MetroTextBox opTbPass;
        private MetroFramework.Controls.MetroLabel metroLabel9;
    }
}

