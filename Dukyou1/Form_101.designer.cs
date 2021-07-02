namespace Dukyou3
{
    partial class Form_101
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form_101));
            this.bUp = new System.Windows.Forms.Button();
            this.bDown = new System.Windows.Forms.Button();
            this.bAdd = new System.Windows.Forms.Button();
            this.bCopy = new System.Windows.Forms.Button();
            this.bDel = new System.Windows.Forms.Button();
            this.bClear = new System.Windows.Forms.Button();
            this.grid1 = new SourceGrid.Grid();
            this.bSearch = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.watGroupBox2 = new Dukyou.WATGroupBox();
            this.label9 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.tbGagam = new System.Windows.Forms.TextBox();
            this.tbGo = new System.Windows.Forms.TextBox();
            this.tbPok = new System.Windows.Forms.TextBox();
            this.tbJang = new System.Windows.Forms.TextBox();
            this.watGroupBox8 = new Dukyou.WATGroupBox();
            this.tbPan = new System.Windows.Forms.TextBox();
            this.watGroupBox7 = new Dukyou.WATGroupBox();
            this.cbPguk = new System.Windows.Forms.ComboBox();
            this.tbPjulsu = new System.Windows.Forms.TextBox();
            this.watGroupBox3 = new Dukyou.WATGroupBox();
            this.cbPmethod = new System.Windows.Forms.ComboBox();
            this.watGroupBox1 = new Dukyou.WATGroupBox();
            this.cbArea = new System.Windows.Forms.ComboBox();
            this.watGroupBox4 = new Dukyou.WATGroupBox();
            this.cbSangho = new System.Windows.Forms.ComboBox();
            this.button3 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.watGroupBox2.SuspendLayout();
            this.watGroupBox8.SuspendLayout();
            this.watGroupBox7.SuspendLayout();
            this.watGroupBox3.SuspendLayout();
            this.watGroupBox1.SuspendLayout();
            this.watGroupBox4.SuspendLayout();
            this.SuspendLayout();
            // 
            // bUp
            // 
            this.bUp.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.bUp.AutoSize = true;
            this.bUp.Location = new System.Drawing.Point(12, 86);
            this.bUp.Name = "bUp";
            this.bUp.Size = new System.Drawing.Size(31, 330);
            this.bUp.TabIndex = 260;
            this.bUp.Text = "▲";
            this.bUp.UseVisualStyleBackColor = true;
            this.bUp.Click += new System.EventHandler(this.bUp_Click);
            // 
            // bDown
            // 
            this.bDown.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.bDown.AutoSize = true;
            this.bDown.Location = new System.Drawing.Point(12, 416);
            this.bDown.Name = "bDown";
            this.bDown.Size = new System.Drawing.Size(31, 299);
            this.bDown.TabIndex = 259;
            this.bDown.Text = "▼";
            this.bDown.UseVisualStyleBackColor = true;
            this.bDown.Click += new System.EventHandler(this.bDown_Click);
            // 
            // bAdd
            // 
            this.bAdd.Location = new System.Drawing.Point(12, 53);
            this.bAdd.Name = "bAdd";
            this.bAdd.Size = new System.Drawing.Size(60, 26);
            this.bAdd.TabIndex = 327;
            this.bAdd.Text = "추가";
            this.bAdd.UseVisualStyleBackColor = true;
            this.bAdd.Click += new System.EventHandler(this.bAdd_Click);
            // 
            // bCopy
            // 
            this.bCopy.Location = new System.Drawing.Point(78, 53);
            this.bCopy.Name = "bCopy";
            this.bCopy.Size = new System.Drawing.Size(60, 26);
            this.bCopy.TabIndex = 327;
            this.bCopy.Text = "복사";
            this.bCopy.UseVisualStyleBackColor = true;
            this.bCopy.Click += new System.EventHandler(this.bCopy_Click);
            // 
            // bDel
            // 
            this.bDel.Location = new System.Drawing.Point(144, 53);
            this.bDel.Name = "bDel";
            this.bDel.Size = new System.Drawing.Size(60, 26);
            this.bDel.TabIndex = 327;
            this.bDel.Text = "삭제";
            this.bDel.UseVisualStyleBackColor = true;
            this.bDel.Click += new System.EventHandler(this.bDel_Click);
            // 
            // bClear
            // 
            this.bClear.Location = new System.Drawing.Point(1268, 16);
            this.bClear.Name = "bClear";
            this.bClear.Size = new System.Drawing.Size(70, 29);
            this.bClear.TabIndex = 327;
            this.bClear.Text = "Clear";
            this.bClear.UseVisualStyleBackColor = true;
            this.bClear.Click += new System.EventHandler(this.bClear_Click);
            // 
            // grid1
            // 
            this.grid1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grid1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.grid1.EnableSort = true;
            this.grid1.Location = new System.Drawing.Point(49, 86);
            this.grid1.Name = "grid1";
            this.grid1.OptimizeMode = SourceGrid.CellOptimizeMode.ForRows;
            this.grid1.SelectionMode = SourceGrid.GridSelectionMode.Cell;
            this.grid1.Size = new System.Drawing.Size(1449, 629);
            this.grid1.TabIndex = 344;
            this.grid1.TabStop = true;
            this.grid1.ToolTipText = "";
            this.grid1.MouseClick += new System.Windows.Forms.MouseEventHandler(this.grid1_MouseClick);
            this.grid1.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.grid1_MouseDoubleClick);
            // 
            // bSearch
            // 
            this.bSearch.Location = new System.Drawing.Point(1347, 16);
            this.bSearch.Name = "bSearch";
            this.bSearch.Size = new System.Drawing.Size(70, 29);
            this.bSearch.TabIndex = 345;
            this.bSearch.Text = "검색";
            this.bSearch.UseVisualStyleBackColor = true;
            this.bSearch.Click += new System.EventHandler(this.bSearch_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(1426, 16);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(70, 29);
            this.button1.TabIndex = 346;
            this.button1.Text = "엑셀변환";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // watGroupBox2
            // 
            this.watGroupBox2.BorderColor = System.Drawing.Color.RoyalBlue;
            this.watGroupBox2.Controls.Add(this.label9);
            this.watGroupBox2.Controls.Add(this.label13);
            this.watGroupBox2.Controls.Add(this.label12);
            this.watGroupBox2.Controls.Add(this.label11);
            this.watGroupBox2.Controls.Add(this.label10);
            this.watGroupBox2.Controls.Add(this.label8);
            this.watGroupBox2.Controls.Add(this.tbGagam);
            this.watGroupBox2.Controls.Add(this.tbGo);
            this.watGroupBox2.Controls.Add(this.tbPok);
            this.watGroupBox2.Controls.Add(this.tbJang);
            this.watGroupBox2.Location = new System.Drawing.Point(689, 20);
            this.watGroupBox2.Name = "watGroupBox2";
            this.watGroupBox2.Size = new System.Drawing.Size(229, 59);
            this.watGroupBox2.TabIndex = 326;
            this.watGroupBox2.TabStop = false;
            this.watGroupBox2.Text = "쇼핑백 장폭고 ( 단위 mm ) a";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(99, 38);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(13, 12);
            this.label9.TabIndex = 328;
            this.label9.Text = "X";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(174, 16);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(51, 12);
            this.label13.TabIndex = 328;
            this.label13.Text = "가감(+-)";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(127, 16);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(17, 12);
            this.label12.TabIndex = 328;
            this.label12.Text = "고";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(69, 16);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(17, 12);
            this.label11.TabIndex = 328;
            this.label11.Text = "폭";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(16, 17);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(17, 12);
            this.label10.TabIndex = 328;
            this.label10.Text = "장";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(45, 39);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(13, 12);
            this.label8.TabIndex = 328;
            this.label8.Text = "X";
            // 
            // tbGagam
            // 
            this.tbGagam.Location = new System.Drawing.Point(176, 31);
            this.tbGagam.Name = "tbGagam";
            this.tbGagam.Size = new System.Drawing.Size(44, 21);
            this.tbGagam.TabIndex = 327;
            this.tbGagam.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // tbGo
            // 
            this.tbGo.Location = new System.Drawing.Point(118, 31);
            this.tbGo.Name = "tbGo";
            this.tbGo.Size = new System.Drawing.Size(37, 21);
            this.tbGo.TabIndex = 327;
            this.tbGo.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // tbPok
            // 
            this.tbPok.Location = new System.Drawing.Point(60, 31);
            this.tbPok.Name = "tbPok";
            this.tbPok.Size = new System.Drawing.Size(37, 21);
            this.tbPok.TabIndex = 327;
            this.tbPok.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // tbJang
            // 
            this.tbJang.Location = new System.Drawing.Point(6, 32);
            this.tbJang.Name = "tbJang";
            this.tbJang.Size = new System.Drawing.Size(37, 21);
            this.tbJang.TabIndex = 327;
            this.tbJang.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // watGroupBox8
            // 
            this.watGroupBox8.BorderColor = System.Drawing.Color.RoyalBlue;
            this.watGroupBox8.Controls.Add(this.tbPan);
            this.watGroupBox8.Location = new System.Drawing.Point(1169, 20);
            this.watGroupBox8.Name = "watGroupBox8";
            this.watGroupBox8.Size = new System.Drawing.Size(78, 59);
            this.watGroupBox8.TabIndex = 326;
            this.watGroupBox8.TabStop = false;
            this.watGroupBox8.Text = "판걸이 ㅁ";
            // 
            // tbPan
            // 
            this.tbPan.Location = new System.Drawing.Point(6, 24);
            this.tbPan.Name = "tbPan";
            this.tbPan.Size = new System.Drawing.Size(66, 21);
            this.tbPan.TabIndex = 327;
            // 
            // watGroupBox7
            // 
            this.watGroupBox7.BorderColor = System.Drawing.Color.RoyalBlue;
            this.watGroupBox7.Controls.Add(this.cbPguk);
            this.watGroupBox7.Controls.Add(this.tbPjulsu);
            this.watGroupBox7.Location = new System.Drawing.Point(1042, 20);
            this.watGroupBox7.Name = "watGroupBox7";
            this.watGroupBox7.Size = new System.Drawing.Size(121, 59);
            this.watGroupBox7.TabIndex = 326;
            this.watGroupBox7.TabStop = false;
            this.watGroupBox7.Text = "인쇄 절수 ㅁ";
            // 
            // cbPguk
            // 
            this.cbPguk.FormattingEnabled = true;
            this.cbPguk.Items.AddRange(new object[] {
            "국",
            "46"});
            this.cbPguk.Location = new System.Drawing.Point(6, 24);
            this.cbPguk.Name = "cbPguk";
            this.cbPguk.Size = new System.Drawing.Size(57, 20);
            this.cbPguk.TabIndex = 327;
            // 
            // tbPjulsu
            // 
            this.tbPjulsu.Location = new System.Drawing.Point(69, 24);
            this.tbPjulsu.Name = "tbPjulsu";
            this.tbPjulsu.Size = new System.Drawing.Size(42, 21);
            this.tbPjulsu.TabIndex = 327;
            // 
            // watGroupBox3
            // 
            this.watGroupBox3.BorderColor = System.Drawing.Color.RoyalBlue;
            this.watGroupBox3.Controls.Add(this.cbPmethod);
            this.watGroupBox3.Location = new System.Drawing.Point(924, 20);
            this.watGroupBox3.Name = "watGroupBox3";
            this.watGroupBox3.Size = new System.Drawing.Size(112, 59);
            this.watGroupBox3.TabIndex = 326;
            this.watGroupBox3.TabStop = false;
            this.watGroupBox3.Text = "인쇄 방법 ㅁ";
            // 
            // cbPmethod
            // 
            this.cbPmethod.FormattingEnabled = true;
            this.cbPmethod.Items.AddRange(new object[] {
            "통인쇄",
            "1/2쪽인쇄",
            "1쪽인쇄"});
            this.cbPmethod.Location = new System.Drawing.Point(6, 24);
            this.cbPmethod.Name = "cbPmethod";
            this.cbPmethod.Size = new System.Drawing.Size(93, 20);
            this.cbPmethod.TabIndex = 327;
            // 
            // watGroupBox1
            // 
            this.watGroupBox1.BorderColor = System.Drawing.Color.RoyalBlue;
            this.watGroupBox1.Controls.Add(this.cbArea);
            this.watGroupBox1.Location = new System.Drawing.Point(571, 20);
            this.watGroupBox1.Name = "watGroupBox1";
            this.watGroupBox1.Size = new System.Drawing.Size(112, 59);
            this.watGroupBox1.TabIndex = 326;
            this.watGroupBox1.TabStop = false;
            this.watGroupBox1.Text = "지역";
            // 
            // cbArea
            // 
            this.cbArea.FormattingEnabled = true;
            this.cbArea.Location = new System.Drawing.Point(6, 24);
            this.cbArea.Name = "cbArea";
            this.cbArea.Size = new System.Drawing.Size(93, 20);
            this.cbArea.TabIndex = 327;
            // 
            // watGroupBox4
            // 
            this.watGroupBox4.BorderColor = System.Drawing.Color.RoyalBlue;
            this.watGroupBox4.Controls.Add(this.cbSangho);
            this.watGroupBox4.Location = new System.Drawing.Point(455, 20);
            this.watGroupBox4.Name = "watGroupBox4";
            this.watGroupBox4.Size = new System.Drawing.Size(110, 59);
            this.watGroupBox4.TabIndex = 326;
            this.watGroupBox4.TabStop = false;
            this.watGroupBox4.Text = "목형 보유 업체 ㅁ";
            // 
            // cbSangho
            // 
            this.cbSangho.FormattingEnabled = true;
            this.cbSangho.Location = new System.Drawing.Point(6, 23);
            this.cbSangho.Name = "cbSangho";
            this.cbSangho.Size = new System.Drawing.Size(93, 20);
            this.cbSangho.TabIndex = 327;
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(1367, 63);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(60, 21);
            this.button3.TabIndex = 365;
            this.button3.Text = "◀--";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(1436, 62);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(60, 21);
            this.button2.TabIndex = 364;
            this.button2.Text = "--▶";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // Form_101
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1507, 741);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.bSearch);
            this.Controls.Add(this.grid1);
            this.Controls.Add(this.bClear);
            this.Controls.Add(this.bDel);
            this.Controls.Add(this.bCopy);
            this.Controls.Add(this.bAdd);
            this.Controls.Add(this.bUp);
            this.Controls.Add(this.bDown);
            this.Controls.Add(this.watGroupBox2);
            this.Controls.Add(this.watGroupBox8);
            this.Controls.Add(this.watGroupBox7);
            this.Controls.Add(this.watGroupBox3);
            this.Controls.Add(this.watGroupBox1);
            this.Controls.Add(this.watGroupBox4);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form_101";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "■ 보유목형";
            this.Load += new System.EventHandler(this.Form_101_Load);
            this.ClientSizeChanged += new System.EventHandler(this.Form_101_ClientSizeChanged);
            this.watGroupBox2.ResumeLayout(false);
            this.watGroupBox2.PerformLayout();
            this.watGroupBox8.ResumeLayout(false);
            this.watGroupBox8.PerformLayout();
            this.watGroupBox7.ResumeLayout(false);
            this.watGroupBox7.PerformLayout();
            this.watGroupBox3.ResumeLayout(false);
            this.watGroupBox1.ResumeLayout(false);
            this.watGroupBox4.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Dukyou.WATGroupBox watGroupBox4;
        private System.Windows.Forms.ComboBox cbSangho;
        private Dukyou.WATGroupBox watGroupBox1;
        private System.Windows.Forms.ComboBox cbArea;
        private Dukyou.WATGroupBox watGroupBox2;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox tbGagam;
        private System.Windows.Forms.TextBox tbGo;
        private System.Windows.Forms.TextBox tbPok;
        private System.Windows.Forms.TextBox tbJang;
        private Dukyou.WATGroupBox watGroupBox3;
        private System.Windows.Forms.ComboBox cbPmethod;
        private Dukyou.WATGroupBox watGroupBox7;
        private System.Windows.Forms.ComboBox cbPguk;
        private System.Windows.Forms.TextBox tbPjulsu;
        private Dukyou.WATGroupBox watGroupBox8;
        private System.Windows.Forms.TextBox tbPan;
        private System.Windows.Forms.Button bUp;
        private System.Windows.Forms.Button bDown;
        private System.Windows.Forms.Button bAdd;
        private System.Windows.Forms.Button bCopy;
        private System.Windows.Forms.Button bDel;
        private System.Windows.Forms.Button bClear;
        private SourceGrid.Grid grid1;
        private System.Windows.Forms.Button bSearch;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button2;
    }
}