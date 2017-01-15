namespace SunfrogUploader
{
    partial class SunfrogUploader
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
            this.btnStart = new MetroFramework.Controls.MetroButton();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.lblNameIndex = new MetroFramework.Controls.MetroLabel();
            this.progCurrentName = new MetroFramework.Controls.MetroProgressBar();
            this.lblTotalNames = new MetroFramework.Controls.MetroLabel();
            this.lblCurName = new MetroFramework.Controls.MetroLabel();
            this.metroLabel2 = new MetroFramework.Controls.MetroLabel();
            this.tbNameList = new System.Windows.Forms.TextBox();
            this.lblLogin = new MetroFramework.Controls.MetroLabel();
            this.metroLabel8 = new MetroFramework.Controls.MetroLabel();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.numEnd = new System.Windows.Forms.NumericUpDown();
            this.numStart = new System.Windows.Forms.NumericUpDown();
            this.btnSaveAcc = new MetroFramework.Controls.MetroButton();
            this.tbPass = new System.Windows.Forms.TextBox();
            this.tbContent = new System.Windows.Forms.TextBox();
            this.tbLogo = new System.Windows.Forms.TextBox();
            this.tbVpsName = new System.Windows.Forms.TextBox();
            this.metroLabel5 = new MetroFramework.Controls.MetroLabel();
            this.metroLabel3 = new MetroFramework.Controls.MetroLabel();
            this.metroLabel7 = new MetroFramework.Controls.MetroLabel();
            this.metroLabel4 = new MetroFramework.Controls.MetroLabel();
            this.metroLabel6 = new MetroFramework.Controls.MetroLabel();
            this.metroLabel1 = new MetroFramework.Controls.MetroLabel();
            this.bgWoker = new System.ComponentModel.BackgroundWorker();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.lbError = new System.Windows.Forms.RichTextBox();
            this.chbAutologo = new System.Windows.Forms.CheckBox();
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numEnd)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numStart)).BeginInit();
            this.SuspendLayout();
            // 
            // btnStart
            // 
            this.btnStart.Highlight = true;
            this.btnStart.Location = new System.Drawing.Point(247, 539);
            this.btnStart.Name = "btnStart";
            this.btnStart.Size = new System.Drawing.Size(152, 49);
            this.btnStart.TabIndex = 6;
            this.btnStart.Text = "Start";
            this.btnStart.Click += new System.EventHandler(this.btnStart_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.lblNameIndex);
            this.groupBox2.Controls.Add(this.progCurrentName);
            this.groupBox2.Controls.Add(this.lblTotalNames);
            this.groupBox2.Controls.Add(this.lblCurName);
            this.groupBox2.Controls.Add(this.metroLabel2);
            this.groupBox2.Controls.Add(this.tbNameList);
            this.groupBox2.Controls.Add(this.lblLogin);
            this.groupBox2.Controls.Add(this.metroLabel8);
            this.groupBox2.ForeColor = System.Drawing.Color.Black;
            this.groupBox2.Location = new System.Drawing.Point(27, 224);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(611, 204);
            this.groupBox2.TabIndex = 5;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Upload Status";
            // 
            // lblNameIndex
            // 
            this.lblNameIndex.AutoSize = true;
            this.lblNameIndex.FontWeight = MetroFramework.MetroLabelWeight.Bold;
            this.lblNameIndex.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(128)))));
            this.lblNameIndex.Location = new System.Drawing.Point(262, 96);
            this.lblNameIndex.Name = "lblNameIndex";
            this.lblNameIndex.Size = new System.Drawing.Size(49, 19);
            this.lblNameIndex.TabIndex = 3;
            this.lblNameIndex.Text = "00000";
            // 
            // progCurrentName
            // 
            this.progCurrentName.Location = new System.Drawing.Point(0, 96);
            this.progCurrentName.Name = "progCurrentName";
            this.progCurrentName.Size = new System.Drawing.Size(611, 23);
            this.progCurrentName.TabIndex = 4;
            // 
            // lblTotalNames
            // 
            this.lblTotalNames.AutoSize = true;
            this.lblTotalNames.FontWeight = MetroFramework.MetroLabelWeight.Bold;
            this.lblTotalNames.ForeColor = System.Drawing.Color.Blue;
            this.lblTotalNames.Location = new System.Drawing.Point(103, 49);
            this.lblTotalNames.Name = "lblTotalNames";
            this.lblTotalNames.Size = new System.Drawing.Size(49, 19);
            this.lblTotalNames.TabIndex = 3;
            this.lblTotalNames.Text = "00000";
            // 
            // lblCurName
            // 
            this.lblCurName.AutoSize = true;
            this.lblCurName.Location = new System.Drawing.Point(9, 75);
            this.lblCurName.Name = "lblCurName";
            this.lblCurName.Size = new System.Drawing.Size(61, 19);
            this.lblCurName.TabIndex = 3;
            this.lblCurName.Text = "Adding...";
            // 
            // metroLabel2
            // 
            this.metroLabel2.AutoSize = true;
            this.metroLabel2.Location = new System.Drawing.Point(9, 49);
            this.metroLabel2.Name = "metroLabel2";
            this.metroLabel2.Size = new System.Drawing.Size(88, 19);
            this.metroLabel2.TabIndex = 3;
            this.metroLabel2.Text = "Total Names: ";
            // 
            // tbNameList
            // 
            this.tbNameList.Location = new System.Drawing.Point(91, 19);
            this.tbNameList.Name = "tbNameList";
            this.tbNameList.ReadOnly = true;
            this.tbNameList.Size = new System.Drawing.Size(100, 20);
            this.tbNameList.TabIndex = 4;
            this.tbNameList.Click += new System.EventHandler(this.tbNameList_Click);
            // 
            // lblLogin
            // 
            this.lblLogin.AutoSize = true;
            this.lblLogin.BackColor = System.Drawing.Color.Transparent;
            this.lblLogin.FontWeight = MetroFramework.MetroLabelWeight.Bold;
            this.lblLogin.ForeColor = System.Drawing.Color.Lime;
            this.lblLogin.Location = new System.Drawing.Point(437, 20);
            this.lblLogin.Name = "lblLogin";
            this.lblLogin.Size = new System.Drawing.Size(134, 19);
            this.lblLogin.TabIndex = 3;
            this.lblLogin.Text = "Waiting for login...";
            this.lblLogin.UseStyleColors = true;
            // 
            // metroLabel8
            // 
            this.metroLabel8.AutoSize = true;
            this.metroLabel8.Location = new System.Drawing.Point(6, 20);
            this.metroLabel8.Name = "metroLabel8";
            this.metroLabel8.Size = new System.Drawing.Size(68, 19);
            this.metroLabel8.TabIndex = 3;
            this.metroLabel8.Text = "Logo Path";
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.groupBox1.Controls.Add(this.chbAutologo);
            this.groupBox1.Controls.Add(this.numEnd);
            this.groupBox1.Controls.Add(this.numStart);
            this.groupBox1.Controls.Add(this.btnSaveAcc);
            this.groupBox1.Controls.Add(this.tbPass);
            this.groupBox1.Controls.Add(this.tbContent);
            this.groupBox1.Controls.Add(this.tbLogo);
            this.groupBox1.Controls.Add(this.tbVpsName);
            this.groupBox1.Controls.Add(this.metroLabel5);
            this.groupBox1.Controls.Add(this.metroLabel3);
            this.groupBox1.Controls.Add(this.metroLabel7);
            this.groupBox1.Controls.Add(this.metroLabel4);
            this.groupBox1.Controls.Add(this.metroLabel6);
            this.groupBox1.Controls.Add(this.metroLabel1);
            this.groupBox1.Location = new System.Drawing.Point(27, 67);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(611, 151);
            this.groupBox1.TabIndex = 4;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Vps Info";
            // 
            // numEnd
            // 
            this.numEnd.Location = new System.Drawing.Point(272, 62);
            this.numEnd.Maximum = new decimal(new int[] {
            100000,
            0,
            0,
            0});
            this.numEnd.Name = "numEnd";
            this.numEnd.Size = new System.Drawing.Size(100, 20);
            this.numEnd.TabIndex = 6;
            // 
            // numStart
            // 
            this.numStart.Location = new System.Drawing.Point(91, 61);
            this.numStart.Maximum = new decimal(new int[] {
            32767,
            0,
            0,
            0});
            this.numStart.Name = "numStart";
            this.numStart.Size = new System.Drawing.Size(100, 20);
            this.numStart.TabIndex = 6;
            // 
            // btnSaveAcc
            // 
            this.btnSaveAcc.Location = new System.Drawing.Point(249, 104);
            this.btnSaveAcc.Name = "btnSaveAcc";
            this.btnSaveAcc.Size = new System.Drawing.Size(75, 34);
            this.btnSaveAcc.TabIndex = 5;
            this.btnSaveAcc.Text = "Save";
            this.btnSaveAcc.Click += new System.EventHandler(this.btnSaveAcc_Click);
            // 
            // tbPass
            // 
            this.tbPass.Location = new System.Drawing.Point(272, 25);
            this.tbPass.Name = "tbPass";
            this.tbPass.PasswordChar = '*';
            this.tbPass.Size = new System.Drawing.Size(100, 20);
            this.tbPass.TabIndex = 4;
            // 
            // tbContent
            // 
            this.tbContent.Location = new System.Drawing.Point(471, 63);
            this.tbContent.Name = "tbContent";
            this.tbContent.Size = new System.Drawing.Size(100, 20);
            this.tbContent.TabIndex = 4;
            // 
            // tbLogo
            // 
            this.tbLogo.Location = new System.Drawing.Point(471, 26);
            this.tbLogo.Name = "tbLogo";
            this.tbLogo.Size = new System.Drawing.Size(100, 20);
            this.tbLogo.TabIndex = 4;
            // 
            // tbVpsName
            // 
            this.tbVpsName.Location = new System.Drawing.Point(91, 25);
            this.tbVpsName.Name = "tbVpsName";
            this.tbVpsName.Size = new System.Drawing.Size(100, 20);
            this.tbVpsName.TabIndex = 4;
            // 
            // metroLabel5
            // 
            this.metroLabel5.AutoSize = true;
            this.metroLabel5.Location = new System.Drawing.Point(198, 63);
            this.metroLabel5.Name = "metroLabel5";
            this.metroLabel5.Size = new System.Drawing.Size(22, 19);
            this.metroLabel5.TabIndex = 3;
            this.metroLabel5.Text = "To";
            // 
            // metroLabel3
            // 
            this.metroLabel3.AutoSize = true;
            this.metroLabel3.Location = new System.Drawing.Point(197, 26);
            this.metroLabel3.Name = "metroLabel3";
            this.metroLabel3.Size = new System.Drawing.Size(63, 19);
            this.metroLabel3.TabIndex = 3;
            this.metroLabel3.Text = "Password";
            // 
            // metroLabel7
            // 
            this.metroLabel7.AutoSize = true;
            this.metroLabel7.Location = new System.Drawing.Point(396, 63);
            this.metroLabel7.Name = "metroLabel7";
            this.metroLabel7.Size = new System.Drawing.Size(55, 19);
            this.metroLabel7.TabIndex = 3;
            this.metroLabel7.Text = "Content";
            // 
            // metroLabel4
            // 
            this.metroLabel4.AutoSize = true;
            this.metroLabel4.Location = new System.Drawing.Point(6, 63);
            this.metroLabel4.Name = "metroLabel4";
            this.metroLabel4.Size = new System.Drawing.Size(41, 19);
            this.metroLabel4.TabIndex = 3;
            this.metroLabel4.Text = "From";
            // 
            // metroLabel6
            // 
            this.metroLabel6.AutoSize = true;
            this.metroLabel6.Location = new System.Drawing.Point(396, 25);
            this.metroLabel6.Name = "metroLabel6";
            this.metroLabel6.Size = new System.Drawing.Size(39, 19);
            this.metroLabel6.TabIndex = 3;
            this.metroLabel6.Text = "Logo";
            // 
            // metroLabel1
            // 
            this.metroLabel1.AutoSize = true;
            this.metroLabel1.Location = new System.Drawing.Point(6, 26);
            this.metroLabel1.Name = "metroLabel1";
            this.metroLabel1.Size = new System.Drawing.Size(71, 19);
            this.metroLabel1.TabIndex = 3;
            this.metroLabel1.Text = "Sunfrog ID";
            // 
            // bgWoker
            // 
            this.bgWoker.WorkerReportsProgress = true;
            this.bgWoker.DoWork += new System.ComponentModel.DoWorkEventHandler(this.bgWoker_DoWork);
            this.bgWoker.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.bgWoker_ProgressChanged);
            this.bgWoker.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.bgWoker_RunWorkerCompleted);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            this.openFileDialog1.Filter = "Text|*.txt";
            // 
            // lbError
            // 
            this.lbError.Location = new System.Drawing.Point(27, 435);
            this.lbError.Name = "lbError";
            this.lbError.ReadOnly = true;
            this.lbError.Size = new System.Drawing.Size(611, 96);
            this.lbError.TabIndex = 7;
            this.lbError.Text = "";
            // 
            // chbAutologo
            // 
            this.chbAutologo.AutoSize = true;
            this.chbAutologo.Checked = true;
            this.chbAutologo.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chbAutologo.Location = new System.Drawing.Point(91, 104);
            this.chbAutologo.Name = "chbAutologo";
            this.chbAutologo.Size = new System.Drawing.Size(71, 17);
            this.chbAutologo.TabIndex = 7;
            this.chbAutologo.Text = "Auto logo";
            this.chbAutologo.UseVisualStyleBackColor = true;
            // 
            // SunfrogUploader
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(667, 594);
            this.Controls.Add(this.lbError);
            this.Controls.Add(this.btnStart);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Name = "SunfrogUploader";
            this.Resizable = false;
            this.Text = "Sunfrog Uploader";
            this.Load += new System.EventHandler(this.SunfrogUploader_Load);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numEnd)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numStart)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private MetroFramework.Controls.MetroButton btnStart;
        private System.Windows.Forms.GroupBox groupBox2;
        private MetroFramework.Controls.MetroLabel lblNameIndex;
        private MetroFramework.Controls.MetroProgressBar progCurrentName;
        private MetroFramework.Controls.MetroLabel lblTotalNames;
        private MetroFramework.Controls.MetroLabel lblCurName;
        private MetroFramework.Controls.MetroLabel metroLabel2;
        private System.Windows.Forms.GroupBox groupBox1;
        private MetroFramework.Controls.MetroButton btnSaveAcc;
        private System.Windows.Forms.TextBox tbVpsName;
        private MetroFramework.Controls.MetroLabel lblLogin;
        private MetroFramework.Controls.MetroLabel metroLabel1;
        private System.ComponentModel.BackgroundWorker bgWoker;
        private System.Windows.Forms.TextBox tbPass;
        private MetroFramework.Controls.MetroLabel metroLabel3;
        private System.Windows.Forms.NumericUpDown numEnd;
        private System.Windows.Forms.NumericUpDown numStart;
        private System.Windows.Forms.TextBox tbContent;
        private System.Windows.Forms.TextBox tbLogo;
        private MetroFramework.Controls.MetroLabel metroLabel5;
        private MetroFramework.Controls.MetroLabel metroLabel7;
        private MetroFramework.Controls.MetroLabel metroLabel4;
        private MetroFramework.Controls.MetroLabel metroLabel6;
        private System.Windows.Forms.TextBox tbNameList;
        private MetroFramework.Controls.MetroLabel metroLabel8;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.RichTextBox lbError;
        private System.Windows.Forms.CheckBox chbAutologo;
    }
}

