namespace TeepublicTool
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.tsProgress = new System.Windows.Forms.ToolStripProgressBar();
            this.tsLblProgress = new System.Windows.Forms.ToolStripLabel();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.tsLblFailed = new System.Windows.Forms.ToolStripLabel();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.btnUpdate = new System.Windows.Forms.Button();
            this.tbPass = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.tbEmails = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnStartUpload = new System.Windows.Forms.Button();
            this.btnLoadLogo = new System.Windows.Forms.Button();
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.label1 = new System.Windows.Forms.Label();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.flowLayout = new System.Windows.Forms.FlowLayoutPanel();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.btnLoadTemplate = new System.Windows.Forms.Button();
            this.btnSaveTemplate = new System.Windows.Forms.Button();
            this.tbTitle = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.tbDescription = new System.Windows.Forms.RichTextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.tbTags = new System.Windows.Forms.RichTextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.tbMainTag = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.chbListProductTypes = new System.Windows.Forms.CheckedListBox();
            this.label6 = new System.Windows.Forms.Label();
            this.bgWorker = new System.ComponentModel.BackgroundWorker();
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(715, 498);
            this.tabControl1.TabIndex = 0;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.toolStrip1);
            this.tabPage1.Controls.Add(this.groupBox2);
            this.tabPage1.Controls.Add(this.groupBox1);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(707, 472);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Upload";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // toolStrip1
            // 
            this.toolStrip1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsProgress,
            this.tsLblProgress,
            this.toolStripSeparator1,
            this.tsLblFailed});
            this.toolStrip1.Location = new System.Drawing.Point(3, 444);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(701, 25);
            this.toolStrip1.TabIndex = 4;
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
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // tsLblFailed
            // 
            this.tsLblFailed.ForeColor = System.Drawing.Color.Red;
            this.tsLblFailed.Name = "tsLblFailed";
            this.tsLblFailed.Size = new System.Drawing.Size(16, 22);
            this.tsLblFailed.Text = "...";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.richTextBox1);
            this.groupBox2.Controls.Add(this.btnUpdate);
            this.groupBox2.Controls.Add(this.tbPass);
            this.groupBox2.Controls.Add(this.label8);
            this.groupBox2.Controls.Add(this.tbEmails);
            this.groupBox2.Controls.Add(this.label7);
            this.groupBox2.Location = new System.Drawing.Point(215, 2);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(483, 440);
            this.groupBox2.TabIndex = 3;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Template";
            // 
            // btnUpdate
            // 
            this.btnUpdate.Location = new System.Drawing.Point(126, 106);
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.Size = new System.Drawing.Size(75, 23);
            this.btnUpdate.TabIndex = 2;
            this.btnUpdate.Text = "Update";
            this.btnUpdate.UseVisualStyleBackColor = true;
            this.btnUpdate.Click += new System.EventHandler(this.btnUpdate_Click);
            // 
            // tbPass
            // 
            this.tbPass.Location = new System.Drawing.Point(126, 57);
            this.tbPass.Name = "tbPass";
            this.tbPass.Size = new System.Drawing.Size(180, 20);
            this.tbPass.TabIndex = 1;
            this.tbPass.UseSystemPasswordChar = true;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(47, 60);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(53, 13);
            this.label8.TabIndex = 0;
            this.label8.Text = "Password";
            // 
            // tbEmails
            // 
            this.tbEmails.Location = new System.Drawing.Point(126, 17);
            this.tbEmails.Name = "tbEmails";
            this.tbEmails.Size = new System.Drawing.Size(180, 20);
            this.tbEmails.TabIndex = 1;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(47, 20);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(32, 13);
            this.label7.TabIndex = 0;
            this.label7.Text = "Email";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnStartUpload);
            this.groupBox1.Controls.Add(this.btnLoadLogo);
            this.groupBox1.Controls.Add(this.listBox1);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(7, 2);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(201, 440);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            // 
            // btnStartUpload
            // 
            this.btnStartUpload.Location = new System.Drawing.Point(48, 290);
            this.btnStartUpload.Name = "btnStartUpload";
            this.btnStartUpload.Size = new System.Drawing.Size(87, 32);
            this.btnStartUpload.TabIndex = 2;
            this.btnStartUpload.Text = "Start Upload";
            this.btnStartUpload.UseVisualStyleBackColor = true;
            this.btnStartUpload.Click += new System.EventHandler(this.btnStartUpload_Click);
            // 
            // btnLoadLogo
            // 
            this.btnLoadLogo.Location = new System.Drawing.Point(48, 237);
            this.btnLoadLogo.Name = "btnLoadLogo";
            this.btnLoadLogo.Size = new System.Drawing.Size(87, 32);
            this.btnLoadLogo.TabIndex = 2;
            this.btnLoadLogo.Text = "Load logo";
            this.btnLoadLogo.UseVisualStyleBackColor = true;
            this.btnLoadLogo.Click += new System.EventHandler(this.btnLoadLogo_Click);
            // 
            // listBox1
            // 
            this.listBox1.FormattingEnabled = true;
            this.listBox1.Location = new System.Drawing.Point(15, 32);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(168, 199);
            this.listBox1.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(53, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(82, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Danh sach logo";
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.groupBox4);
            this.tabPage2.Controls.Add(this.groupBox3);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(707, 472);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Template Editor";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // groupBox4
            // 
            this.groupBox4.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox4.Controls.Add(this.flowLayout);
            this.groupBox4.Location = new System.Drawing.Point(230, 7);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(471, 435);
            this.groupBox4.TabIndex = 1;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Config";
            // 
            // flowLayout
            // 
            this.flowLayout.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.flowLayout.AutoScroll = true;
            this.flowLayout.Location = new System.Drawing.Point(21, 41);
            this.flowLayout.Name = "flowLayout";
            this.flowLayout.Size = new System.Drawing.Size(427, 373);
            this.flowLayout.TabIndex = 0;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.btnLoadTemplate);
            this.groupBox3.Controls.Add(this.btnSaveTemplate);
            this.groupBox3.Controls.Add(this.tbTitle);
            this.groupBox3.Controls.Add(this.label2);
            this.groupBox3.Controls.Add(this.tbDescription);
            this.groupBox3.Controls.Add(this.label5);
            this.groupBox3.Controls.Add(this.tbTags);
            this.groupBox3.Controls.Add(this.label4);
            this.groupBox3.Controls.Add(this.tbMainTag);
            this.groupBox3.Controls.Add(this.label3);
            this.groupBox3.Controls.Add(this.chbListProductTypes);
            this.groupBox3.Controls.Add(this.label6);
            this.groupBox3.Location = new System.Drawing.Point(8, 6);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(215, 436);
            this.groupBox3.TabIndex = 0;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Products";
            // 
            // btnLoadTemplate
            // 
            this.btnLoadTemplate.Location = new System.Drawing.Point(122, 398);
            this.btnLoadTemplate.Name = "btnLoadTemplate";
            this.btnLoadTemplate.Size = new System.Drawing.Size(87, 32);
            this.btnLoadTemplate.TabIndex = 6;
            this.btnLoadTemplate.Text = "Load Template";
            this.btnLoadTemplate.UseVisualStyleBackColor = true;
            this.btnLoadTemplate.Click += new System.EventHandler(this.btnLoadTemplate_Click);
            // 
            // btnSaveTemplate
            // 
            this.btnSaveTemplate.Location = new System.Drawing.Point(19, 398);
            this.btnSaveTemplate.Name = "btnSaveTemplate";
            this.btnSaveTemplate.Size = new System.Drawing.Size(87, 32);
            this.btnSaveTemplate.TabIndex = 5;
            this.btnSaveTemplate.Text = "Save Template";
            this.btnSaveTemplate.UseVisualStyleBackColor = true;
            this.btnSaveTemplate.Click += new System.EventHandler(this.btnSaveTemplate_Click);
            // 
            // tbTitle
            // 
            this.tbTitle.Location = new System.Drawing.Point(17, 212);
            this.tbTitle.Name = "tbTitle";
            this.tbTitle.Size = new System.Drawing.Size(190, 20);
            this.tbTitle.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(23, 196);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(27, 13);
            this.label2.TabIndex = 12;
            this.label2.Text = "Title";
            // 
            // tbDescription
            // 
            this.tbDescription.Location = new System.Drawing.Point(17, 352);
            this.tbDescription.Name = "tbDescription";
            this.tbDescription.Size = new System.Drawing.Size(190, 43);
            this.tbDescription.TabIndex = 4;
            this.tbDescription.Text = "";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(23, 336);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(108, 13);
            this.label5.TabIndex = 9;
            this.label5.Text = "Description (Optional)";
            // 
            // tbTags
            // 
            this.tbTags.Location = new System.Drawing.Point(17, 292);
            this.tbTags.Name = "tbTags";
            this.tbTags.Size = new System.Drawing.Size(190, 41);
            this.tbTags.TabIndex = 4;
            this.tbTags.Text = "";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(23, 276);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(79, 13);
            this.label4.TabIndex = 7;
            this.label4.Text = "Tags (Optional)";
            // 
            // tbMainTag
            // 
            this.tbMainTag.Location = new System.Drawing.Point(17, 251);
            this.tbMainTag.Name = "tbMainTag";
            this.tbMainTag.Size = new System.Drawing.Size(190, 20);
            this.tbMainTag.TabIndex = 3;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(23, 235);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(52, 13);
            this.label3.TabIndex = 6;
            this.label3.Text = "Main Tag";
            // 
            // chbListProductTypes
            // 
            this.chbListProductTypes.CheckOnClick = true;
            this.chbListProductTypes.FormattingEnabled = true;
            this.chbListProductTypes.Items.AddRange(new object[] {
            "APPAREL",
            "PRINT",
            "CASE",
            "NOTEBOOK",
            "MUG"});
            this.chbListProductTypes.Location = new System.Drawing.Point(17, 42);
            this.chbListProductTypes.Name = "chbListProductTypes";
            this.chbListProductTypes.Size = new System.Drawing.Size(179, 139);
            this.chbListProductTypes.TabIndex = 1;
            this.chbListProductTypes.SelectedIndexChanged += new System.EventHandler(this.chbListProductTypes_SelectedIndexChanged);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(14, 26);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(76, 13);
            this.label6.TabIndex = 1;
            this.label6.Text = "Product Types";
            // 
            // bgWorker
            // 
            this.bgWorker.WorkerReportsProgress = true;
            this.bgWorker.DoWork += new System.ComponentModel.DoWorkEventHandler(this.bgWorker_DoWork);
            this.bgWorker.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.bgWorker_ProgressChanged);
            this.bgWorker.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.bgWorker_RunWorkerCompleted);
            // 
            // richTextBox1
            // 
            this.richTextBox1.Location = new System.Drawing.Point(50, 159);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.ReadOnly = true;
            this.richTextBox1.Size = new System.Drawing.Size(412, 205);
            this.richTextBox1.TabIndex = 3;
            this.richTextBox1.Text = resources.GetString("richTextBox1.Text");
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(715, 498);
            this.Controls.Add(this.tabControl1);
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Teepublic";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.groupBox4.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnLoadLogo;
        private System.Windows.Forms.ListBox listBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.CheckedListBox chbListProductTypes;
        private System.Windows.Forms.FlowLayoutPanel flowLayout;
        private System.Windows.Forms.Button btnStartUpload;
        private System.Windows.Forms.TextBox tbMainTag;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.RichTextBox tbDescription;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.RichTextBox tbTags;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox tbTitle;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnLoadTemplate;
        private System.Windows.Forms.Button btnSaveTemplate;
        private System.ComponentModel.BackgroundWorker bgWorker;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripProgressBar tsProgress;
        private System.Windows.Forms.ToolStripLabel tsLblProgress;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripLabel tsLblFailed;
        private System.Windows.Forms.TextBox tbPass;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox tbEmails;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button btnUpdate;
        private System.Windows.Forms.RichTextBox richTextBox1;
    }
}