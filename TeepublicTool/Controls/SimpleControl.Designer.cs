namespace TeepublicTool.Controls
{
    partial class SimpleControl
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.tbColor = new System.Windows.Forms.TextBox();
            this.btnChooseColor = new System.Windows.Forms.Button();
            this.trackBarPercent = new System.Windows.Forms.TrackBar();
            this.label2 = new System.Windows.Forms.Label();
            this.lblPercent = new System.Windows.Forms.Label();
            this.colorDialog1 = new System.Windows.Forms.ColorDialog();
            this.lblName = new System.Windows.Forms.Label();
            this.chbSetDefault = new System.Windows.Forms.CheckBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.groupApparel = new System.Windows.Forms.GroupBox();
            this.cbbHoodie = new System.Windows.Forms.ComboBox();
            this.cbbCrewneck = new System.Windows.Forms.ComboBox();
            this.cbbBaseballTee = new System.Windows.Forms.ComboBox();
            this.cbbKids = new System.Windows.Forms.ComboBox();
            this.cbbLongSleeve = new System.Windows.Forms.ComboBox();
            this.cbbTank = new System.Windows.Forms.ComboBox();
            this.cbbTshirt = new System.Windows.Forms.ComboBox();
            this.groupPrint = new System.Windows.Forms.GroupBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.rad3vs4 = new System.Windows.Forms.RadioButton();
            this.rad4vs5 = new System.Windows.Forms.RadioButton();
            this.rad9vs16 = new System.Windows.Forms.RadioButton();
            this.rad2vs3 = new System.Windows.Forms.RadioButton();
            this.rad5vs6 = new System.Windows.Forms.RadioButton();
            this.rad1vs1 = new System.Windows.Forms.RadioButton();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.radLanscape = new System.Windows.Forms.RadioButton();
            this.radPortrait = new System.Windows.Forms.RadioButton();
            this.chbFullbleedPrint = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarPercent)).BeginInit();
            this.groupApparel.SuspendLayout();
            this.groupPrint.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 43);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(31, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Color";
            // 
            // tbColor
            // 
            this.tbColor.Location = new System.Drawing.Point(69, 40);
            this.tbColor.Name = "tbColor";
            this.tbColor.ReadOnly = true;
            this.tbColor.Size = new System.Drawing.Size(115, 20);
            this.tbColor.TabIndex = 1;
            // 
            // btnChooseColor
            // 
            this.btnChooseColor.Location = new System.Drawing.Point(196, 38);
            this.btnChooseColor.Name = "btnChooseColor";
            this.btnChooseColor.Size = new System.Drawing.Size(96, 23);
            this.btnChooseColor.TabIndex = 2;
            this.btnChooseColor.Text = "Choose Color";
            this.btnChooseColor.UseVisualStyleBackColor = true;
            this.btnChooseColor.Click += new System.EventHandler(this.btnChooseColor_Click);
            // 
            // trackBarPercent
            // 
            this.trackBarPercent.Location = new System.Drawing.Point(3, 110);
            this.trackBarPercent.Maximum = 200;
            this.trackBarPercent.Name = "trackBarPercent";
            this.trackBarPercent.Size = new System.Drawing.Size(289, 45);
            this.trackBarPercent.TabIndex = 3;
            this.trackBarPercent.Value = 100;
            this.trackBarPercent.ValueChanged += new System.EventHandler(this.trackBarPercent_ValueChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(13, 80);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(67, 13);
            this.label2.TabIndex = 0;
            this.label2.Text = "Size Percent";
            // 
            // lblPercent
            // 
            this.lblPercent.AutoSize = true;
            this.lblPercent.Location = new System.Drawing.Point(66, 158);
            this.lblPercent.Name = "lblPercent";
            this.lblPercent.Size = new System.Drawing.Size(16, 13);
            this.lblPercent.TabIndex = 0;
            this.lblPercent.Text = "...";
            // 
            // colorDialog1
            // 
            this.colorDialog1.FullOpen = true;
            // 
            // lblName
            // 
            this.lblName.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblName.Location = new System.Drawing.Point(44, 6);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(173, 24);
            this.lblName.TabIndex = 0;
            this.lblName.Text = "...";
            this.lblName.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // chbSetDefault
            // 
            this.chbSetDefault.AutoSize = true;
            this.chbSetDefault.Checked = true;
            this.chbSetDefault.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chbSetDefault.Location = new System.Drawing.Point(16, 205);
            this.chbSetDefault.Name = "chbSetDefault";
            this.chbSetDefault.Size = new System.Drawing.Size(114, 17);
            this.chbSetDefault.TabIndex = 4;
            this.chbSetDefault.Text = "Use default setting";
            this.chbSetDefault.UseVisualStyleBackColor = true;
            this.chbSetDefault.CheckedChanged += new System.EventHandler(this.chbSetDefault_CheckedChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(13, 24);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(33, 13);
            this.label3.TabIndex = 0;
            this.label3.Text = "Tshirt";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(13, 53);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(32, 13);
            this.label4.TabIndex = 0;
            this.label4.Text = "Tank";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(13, 82);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(67, 13);
            this.label5.TabIndex = 0;
            this.label5.Text = "Long Sleeve";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(13, 111);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(65, 13);
            this.label6.TabIndex = 0;
            this.label6.Text = "Baseball tee";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(13, 140);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(27, 13);
            this.label7.TabIndex = 0;
            this.label7.Text = "Kids";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(13, 169);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(55, 13);
            this.label8.TabIndex = 0;
            this.label8.Text = "Crewneck";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(13, 198);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(41, 13);
            this.label9.TabIndex = 0;
            this.label9.Text = "Hoodie";
            // 
            // groupApparel
            // 
            this.groupApparel.Controls.Add(this.cbbHoodie);
            this.groupApparel.Controls.Add(this.cbbCrewneck);
            this.groupApparel.Controls.Add(this.cbbBaseballTee);
            this.groupApparel.Controls.Add(this.cbbKids);
            this.groupApparel.Controls.Add(this.cbbLongSleeve);
            this.groupApparel.Controls.Add(this.cbbTank);
            this.groupApparel.Controls.Add(this.cbbTshirt);
            this.groupApparel.Controls.Add(this.label3);
            this.groupApparel.Controls.Add(this.label6);
            this.groupApparel.Controls.Add(this.label4);
            this.groupApparel.Controls.Add(this.label7);
            this.groupApparel.Controls.Add(this.label5);
            this.groupApparel.Controls.Add(this.label8);
            this.groupApparel.Controls.Add(this.label9);
            this.groupApparel.Enabled = false;
            this.groupApparel.Location = new System.Drawing.Point(298, 6);
            this.groupApparel.Name = "groupApparel";
            this.groupApparel.Size = new System.Drawing.Size(303, 230);
            this.groupApparel.TabIndex = 5;
            this.groupApparel.TabStop = false;
            this.groupApparel.Text = "Apparel Type";
            // 
            // cbbHoodie
            // 
            this.cbbHoodie.FormattingEnabled = true;
            this.cbbHoodie.Items.AddRange(new object[] {
            "Black",
            "Red",
            "Navy",
            "Royal Blue",
            "Vintage Heather",
            "Charcoal Heather"});
            this.cbbHoodie.Location = new System.Drawing.Point(104, 195);
            this.cbbHoodie.Name = "cbbHoodie";
            this.cbbHoodie.Size = new System.Drawing.Size(80, 21);
            this.cbbHoodie.TabIndex = 2;
            // 
            // cbbCrewneck
            // 
            this.cbbCrewneck.FormattingEnabled = true;
            this.cbbCrewneck.Items.AddRange(new object[] {
            "Black",
            "White",
            "Pomegranate",
            "Dark Green",
            "Navy",
            "Royal Blue",
            "Heather",
            "Charcoal Heather"});
            this.cbbCrewneck.Location = new System.Drawing.Point(104, 166);
            this.cbbCrewneck.Name = "cbbCrewneck";
            this.cbbCrewneck.Size = new System.Drawing.Size(80, 21);
            this.cbbCrewneck.TabIndex = 2;
            // 
            // cbbBaseballTee
            // 
            this.cbbBaseballTee.FormattingEnabled = true;
            this.cbbBaseballTee.Items.AddRange(new object[] {
            "Black/White",
            "White/Black",
            "White/Royal",
            "White/Red",
            "White/Kelly",
            "White/Navy"});
            this.cbbBaseballTee.Location = new System.Drawing.Point(104, 108);
            this.cbbBaseballTee.Name = "cbbBaseballTee";
            this.cbbBaseballTee.Size = new System.Drawing.Size(80, 21);
            this.cbbBaseballTee.TabIndex = 2;
            // 
            // cbbKids
            // 
            this.cbbKids.FormattingEnabled = true;
            this.cbbKids.Items.AddRange(new object[] {
            "Black",
            "White",
            "Cardinal",
            "Maroon",
            "Red",
            "Soft Pink",
            "Orange",
            "Tennessee Orange",
            "Yellow",
            "Moss",
            "Dark Green",
            "Kelly",
            "Navy",
            "Royal Blue",
            "Coastal Blue",
            "Purple",
            "Heather"});
            this.cbbKids.Location = new System.Drawing.Point(104, 137);
            this.cbbKids.Name = "cbbKids";
            this.cbbKids.Size = new System.Drawing.Size(80, 21);
            this.cbbKids.TabIndex = 2;
            // 
            // cbbLongSleeve
            // 
            this.cbbLongSleeve.FormattingEnabled = true;
            this.cbbLongSleeve.Items.AddRange(new object[] {
            "Black",
            "White",
            "Cardinal",
            "Maroon",
            "Red",
            "Orange",
            "Gold",
            "Dark Green",
            "Navy",
            "Royal Blue",
            "Light Blue",
            "Purple",
            "Heather"});
            this.cbbLongSleeve.Location = new System.Drawing.Point(104, 79);
            this.cbbLongSleeve.Name = "cbbLongSleeve";
            this.cbbLongSleeve.Size = new System.Drawing.Size(80, 21);
            this.cbbLongSleeve.TabIndex = 2;
            // 
            // cbbTank
            // 
            this.cbbTank.FormattingEnabled = true;
            this.cbbTank.Items.AddRange(new object[] {
            "Black",
            "White",
            "Red",
            "Kelly",
            "Leaf",
            "Kelly",
            "Navy",
            "Royal Blue",
            "Heather"});
            this.cbbTank.Location = new System.Drawing.Point(104, 50);
            this.cbbTank.Name = "cbbTank";
            this.cbbTank.Size = new System.Drawing.Size(80, 21);
            this.cbbTank.TabIndex = 2;
            // 
            // cbbTshirt
            // 
            this.cbbTshirt.FormattingEnabled = true;
            this.cbbTshirt.Items.AddRange(new object[] {
            "Black",
            "White",
            "Asphalt",
            "Maroon",
            "Red",
            "Hot Pink",
            "Browse",
            "Yellow",
            "Creme",
            "Kelly",
            "Navy",
            "Royal Blue",
            "Teal",
            "Light Blue",
            "Purple",
            "Heather"});
            this.cbbTshirt.Location = new System.Drawing.Point(104, 21);
            this.cbbTshirt.Name = "cbbTshirt";
            this.cbbTshirt.Size = new System.Drawing.Size(80, 21);
            this.cbbTshirt.TabIndex = 2;
            // 
            // groupPrint
            // 
            this.groupPrint.Controls.Add(this.groupBox3);
            this.groupPrint.Controls.Add(this.groupBox1);
            this.groupPrint.Controls.Add(this.chbFullbleedPrint);
            this.groupPrint.Enabled = false;
            this.groupPrint.Location = new System.Drawing.Point(298, 242);
            this.groupPrint.Name = "groupPrint";
            this.groupPrint.Size = new System.Drawing.Size(303, 212);
            this.groupPrint.TabIndex = 6;
            this.groupPrint.TabStop = false;
            this.groupPrint.Text = "Prints type";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.rad3vs4);
            this.groupBox3.Controls.Add(this.rad4vs5);
            this.groupBox3.Controls.Add(this.rad9vs16);
            this.groupBox3.Controls.Add(this.rad2vs3);
            this.groupBox3.Controls.Add(this.rad5vs6);
            this.groupBox3.Controls.Add(this.rad1vs1);
            this.groupBox3.Location = new System.Drawing.Point(13, 126);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(245, 71);
            this.groupBox3.TabIndex = 5;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Orientation";
            // 
            // rad3vs4
            // 
            this.rad3vs4.AutoSize = true;
            this.rad3vs4.Location = new System.Drawing.Point(178, 20);
            this.rad3vs4.Name = "rad3vs4";
            this.rad3vs4.Size = new System.Drawing.Size(40, 17);
            this.rad3vs4.TabIndex = 0;
            this.rad3vs4.Text = "3:4";
            this.rad3vs4.UseVisualStyleBackColor = true;
            this.rad3vs4.CheckedChanged += new System.EventHandler(this.rad1vs1_CheckedChanged);
            // 
            // rad4vs5
            // 
            this.rad4vs5.AutoSize = true;
            this.rad4vs5.Location = new System.Drawing.Point(120, 20);
            this.rad4vs5.Name = "rad4vs5";
            this.rad4vs5.Size = new System.Drawing.Size(40, 17);
            this.rad4vs5.TabIndex = 0;
            this.rad4vs5.Text = "4:5";
            this.rad4vs5.UseVisualStyleBackColor = true;
            this.rad4vs5.CheckedChanged += new System.EventHandler(this.rad1vs1_CheckedChanged);
            // 
            // rad9vs16
            // 
            this.rad9vs16.AutoSize = true;
            this.rad9vs16.Location = new System.Drawing.Point(65, 43);
            this.rad9vs16.Name = "rad9vs16";
            this.rad9vs16.Size = new System.Drawing.Size(46, 17);
            this.rad9vs16.TabIndex = 0;
            this.rad9vs16.Text = "9:16";
            this.rad9vs16.UseVisualStyleBackColor = true;
            this.rad9vs16.CheckedChanged += new System.EventHandler(this.rad1vs1_CheckedChanged);
            // 
            // rad2vs3
            // 
            this.rad2vs3.AutoSize = true;
            this.rad2vs3.Location = new System.Drawing.Point(7, 43);
            this.rad2vs3.Name = "rad2vs3";
            this.rad2vs3.Size = new System.Drawing.Size(40, 17);
            this.rad2vs3.TabIndex = 0;
            this.rad2vs3.Text = "2:3";
            this.rad2vs3.UseVisualStyleBackColor = true;
            this.rad2vs3.CheckedChanged += new System.EventHandler(this.rad1vs1_CheckedChanged);
            // 
            // rad5vs6
            // 
            this.rad5vs6.AutoSize = true;
            this.rad5vs6.Location = new System.Drawing.Point(65, 20);
            this.rad5vs6.Name = "rad5vs6";
            this.rad5vs6.Size = new System.Drawing.Size(40, 17);
            this.rad5vs6.TabIndex = 0;
            this.rad5vs6.Text = "5:6";
            this.rad5vs6.UseVisualStyleBackColor = true;
            this.rad5vs6.CheckedChanged += new System.EventHandler(this.rad1vs1_CheckedChanged);
            // 
            // rad1vs1
            // 
            this.rad1vs1.AutoSize = true;
            this.rad1vs1.Checked = true;
            this.rad1vs1.Location = new System.Drawing.Point(7, 20);
            this.rad1vs1.Name = "rad1vs1";
            this.rad1vs1.Size = new System.Drawing.Size(40, 17);
            this.rad1vs1.TabIndex = 0;
            this.rad1vs1.TabStop = true;
            this.rad1vs1.Text = "1:1";
            this.rad1vs1.UseVisualStyleBackColor = true;
            this.rad1vs1.CheckedChanged += new System.EventHandler(this.rad1vs1_CheckedChanged);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.radLanscape);
            this.groupBox1.Controls.Add(this.radPortrait);
            this.groupBox1.Location = new System.Drawing.Point(13, 51);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(155, 69);
            this.groupBox1.TabIndex = 5;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Orientation";
            // 
            // radLanscape
            // 
            this.radLanscape.AutoSize = true;
            this.radLanscape.Location = new System.Drawing.Point(7, 43);
            this.radLanscape.Name = "radLanscape";
            this.radLanscape.Size = new System.Drawing.Size(78, 17);
            this.radLanscape.TabIndex = 1;
            this.radLanscape.Text = "Landscape";
            this.radLanscape.UseVisualStyleBackColor = true;
            this.radLanscape.CheckedChanged += new System.EventHandler(this.radLanscape_CheckedChanged);
            // 
            // radPortrait
            // 
            this.radPortrait.AutoSize = true;
            this.radPortrait.Checked = true;
            this.radPortrait.Location = new System.Drawing.Point(7, 20);
            this.radPortrait.Name = "radPortrait";
            this.radPortrait.Size = new System.Drawing.Size(58, 17);
            this.radPortrait.TabIndex = 0;
            this.radPortrait.TabStop = true;
            this.radPortrait.Text = "Portrait";
            this.radPortrait.UseVisualStyleBackColor = true;
            this.radPortrait.CheckedChanged += new System.EventHandler(this.radLanscape_CheckedChanged);
            // 
            // chbFullbleedPrint
            // 
            this.chbFullbleedPrint.AutoSize = true;
            this.chbFullbleedPrint.Location = new System.Drawing.Point(13, 28);
            this.chbFullbleedPrint.Name = "chbFullbleedPrint";
            this.chbFullbleedPrint.Size = new System.Drawing.Size(95, 17);
            this.chbFullbleedPrint.TabIndex = 4;
            this.chbFullbleedPrint.Text = "Full-bleed Print";
            this.chbFullbleedPrint.UseVisualStyleBackColor = true;
            this.chbFullbleedPrint.CheckedChanged += new System.EventHandler(this.chbSetDefault_CheckedChanged);
            // 
            // SimpleControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Controls.Add(this.chbSetDefault);
            this.Controls.Add(this.groupPrint);
            this.Controls.Add(this.groupApparel);
            this.Controls.Add(this.trackBarPercent);
            this.Controls.Add(this.btnChooseColor);
            this.Controls.Add(this.tbColor);
            this.Controls.Add(this.lblPercent);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.lblName);
            this.Controls.Add(this.label1);
            this.Name = "SimpleControl";
            this.Size = new System.Drawing.Size(602, 458);
            this.Load += new System.EventHandler(this.SimpleControl_Load);
            ((System.ComponentModel.ISupportInitialize)(this.trackBarPercent)).EndInit();
            this.groupApparel.ResumeLayout(false);
            this.groupApparel.PerformLayout();
            this.groupPrint.ResumeLayout(false);
            this.groupPrint.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tbColor;
        private System.Windows.Forms.Button btnChooseColor;
        private System.Windows.Forms.TrackBar trackBarPercent;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lblPercent;
        private System.Windows.Forms.ColorDialog colorDialog1;
        private System.Windows.Forms.Label lblName;
        private System.Windows.Forms.CheckBox chbSetDefault;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.GroupBox groupApparel;
        private System.Windows.Forms.GroupBox groupPrint;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton radLanscape;
        private System.Windows.Forms.RadioButton radPortrait;
        private System.Windows.Forms.CheckBox chbFullbleedPrint;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.RadioButton rad3vs4;
        private System.Windows.Forms.RadioButton rad4vs5;
        private System.Windows.Forms.RadioButton rad9vs16;
        private System.Windows.Forms.RadioButton rad2vs3;
        private System.Windows.Forms.RadioButton rad5vs6;
        private System.Windows.Forms.RadioButton rad1vs1;
        private System.Windows.Forms.ComboBox cbbHoodie;
        private System.Windows.Forms.ComboBox cbbCrewneck;
        private System.Windows.Forms.ComboBox cbbBaseballTee;
        private System.Windows.Forms.ComboBox cbbKids;
        private System.Windows.Forms.ComboBox cbbLongSleeve;
        private System.Windows.Forms.ComboBox cbbTank;
        private System.Windows.Forms.ComboBox cbbTshirt;
    }
}
