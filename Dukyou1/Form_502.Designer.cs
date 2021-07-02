namespace Dukyou3
{
    partial class Form_502
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form_502));
            this.grid1 = new SourceGrid.Grid();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.cbBun = new System.Windows.Forms.ComboBox();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.cbPgroup = new System.Windows.Forms.ComboBox();
            this.groupBox6 = new System.Windows.Forms.GroupBox();
            this.cbPname = new System.Windows.Forms.ComboBox();
            this.groupBox7 = new System.Windows.Forms.GroupBox();
            this.tbPcolor = new System.Windows.Forms.TextBox();
            this.groupBox8 = new System.Windows.Forms.GroupBox();
            this.cbPmake = new System.Windows.Forms.ComboBox();
            this.bClear = new System.Windows.Forms.Button();
            this.bSearch = new System.Windows.Forms.Button();
            this.label9 = new System.Windows.Forms.Label();
            this.grid2 = new SourceGrid.Grid();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.cbWeight2 = new System.Windows.Forms.ComboBox();
            this.cbWeight1 = new System.Windows.Forms.ComboBox();
            this.label12 = new System.Windows.Forms.Label();
            this.groupBox11 = new System.Windows.Forms.GroupBox();
            this.rbPgroup = new System.Windows.Forms.RadioButton();
            this.rbPname = new System.Windows.Forms.RadioButton();
            this.rbPmake = new System.Windows.Forms.RadioButton();
            this.rbBunryu = new System.Windows.Forms.RadioButton();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.cbSock = new System.Windows.Forms.ComboBox();
            this.bApply = new System.Windows.Forms.Button();
            this.bDel = new System.Windows.Forms.Button();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.cbSpecial = new System.Windows.Forms.CheckBox();
            this.cbJoint = new System.Windows.Forms.CheckBox();
            this.bMacro = new System.Windows.Forms.Button();
            this.bSang = new System.Windows.Forms.Button();
            this.watGroupBox1 = new Dukyou.WATGroupBox();
            this.rbSang = new System.Windows.Forms.RadioButton();
            this.rbMacro = new System.Windows.Forms.RadioButton();
            this.rbCs = new System.Windows.Forms.RadioButton();
            this.watGroupBox8 = new Dukyou.WATGroupBox();
            this.tbMemo = new System.Windows.Forms.TextBox();
            this.bSave = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.groupBox6.SuspendLayout();
            this.groupBox7.SuspendLayout();
            this.groupBox8.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox11.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox5.SuspendLayout();
            this.watGroupBox1.SuspendLayout();
            this.watGroupBox8.SuspendLayout();
            this.SuspendLayout();
            // 
            // grid1
            // 
            this.grid1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grid1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.grid1.EnableSort = true;
            this.grid1.Location = new System.Drawing.Point(9, 352);
            this.grid1.Name = "grid1";
            this.grid1.OptimizeMode = SourceGrid.CellOptimizeMode.ForRows;
            this.grid1.SelectionMode = SourceGrid.GridSelectionMode.Cell;
            this.grid1.Size = new System.Drawing.Size(1469, 390);
            this.grid1.TabIndex = 16;
            this.grid1.TabStop = true;
            this.grid1.ToolTipText = "";
            this.grid1.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.grid1_MouseDoubleClick);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.cbBun);
            this.groupBox1.Location = new System.Drawing.Point(483, 291);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(101, 53);
            this.groupBox1.TabIndex = 6;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "% 분류";
            // 
            // cbBun
            // 
            this.cbBun.FormattingEnabled = true;
            this.cbBun.Location = new System.Drawing.Point(6, 20);
            this.cbBun.Name = "cbBun";
            this.cbBun.Size = new System.Drawing.Size(89, 20);
            this.cbBun.TabIndex = 0;
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.cbPgroup);
            this.groupBox4.Location = new System.Drawing.Point(590, 291);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(77, 53);
            this.groupBox4.TabIndex = 7;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "종이그룹";
            // 
            // cbPgroup
            // 
            this.cbPgroup.FormattingEnabled = true;
            this.cbPgroup.Location = new System.Drawing.Point(6, 21);
            this.cbPgroup.Name = "cbPgroup";
            this.cbPgroup.Size = new System.Drawing.Size(64, 20);
            this.cbPgroup.TabIndex = 0;
            // 
            // groupBox6
            // 
            this.groupBox6.Controls.Add(this.cbPname);
            this.groupBox6.Location = new System.Drawing.Point(804, 291);
            this.groupBox6.Name = "groupBox6";
            this.groupBox6.Size = new System.Drawing.Size(101, 53);
            this.groupBox6.TabIndex = 9;
            this.groupBox6.TabStop = false;
            this.groupBox6.Text = "종이명";
            // 
            // cbPname
            // 
            this.cbPname.FormattingEnabled = true;
            this.cbPname.Location = new System.Drawing.Point(6, 21);
            this.cbPname.Name = "cbPname";
            this.cbPname.Size = new System.Drawing.Size(89, 20);
            this.cbPname.TabIndex = 0;
            // 
            // groupBox7
            // 
            this.groupBox7.Controls.Add(this.tbPcolor);
            this.groupBox7.Location = new System.Drawing.Point(911, 291);
            this.groupBox7.Name = "groupBox7";
            this.groupBox7.Size = new System.Drawing.Size(80, 53);
            this.groupBox7.TabIndex = 10;
            this.groupBox7.TabStop = false;
            this.groupBox7.Text = "색상";
            // 
            // tbPcolor
            // 
            this.tbPcolor.Location = new System.Drawing.Point(6, 20);
            this.tbPcolor.Name = "tbPcolor";
            this.tbPcolor.Size = new System.Drawing.Size(68, 21);
            this.tbPcolor.TabIndex = 0;
            // 
            // groupBox8
            // 
            this.groupBox8.Controls.Add(this.cbPmake);
            this.groupBox8.Location = new System.Drawing.Point(997, 291);
            this.groupBox8.Name = "groupBox8";
            this.groupBox8.Size = new System.Drawing.Size(101, 53);
            this.groupBox8.TabIndex = 11;
            this.groupBox8.TabStop = false;
            this.groupBox8.Text = "제지회사";
            // 
            // cbPmake
            // 
            this.cbPmake.FormattingEnabled = true;
            this.cbPmake.Location = new System.Drawing.Point(6, 21);
            this.cbPmake.Name = "cbPmake";
            this.cbPmake.Size = new System.Drawing.Size(89, 20);
            this.cbPmake.TabIndex = 0;
            // 
            // bClear
            // 
            this.bClear.Location = new System.Drawing.Point(1430, 321);
            this.bClear.Name = "bClear";
            this.bClear.Size = new System.Drawing.Size(51, 23);
            this.bClear.TabIndex = 15;
            this.bClear.Text = "clear";
            this.bClear.UseVisualStyleBackColor = true;
            this.bClear.Click += new System.EventHandler(this.bClear_Click);
            // 
            // bSearch
            // 
            this.bSearch.Location = new System.Drawing.Point(1354, 313);
            this.bSearch.Name = "bSearch";
            this.bSearch.Size = new System.Drawing.Size(70, 33);
            this.bSearch.TabIndex = 14;
            this.bSearch.Text = "검색";
            this.bSearch.UseVisualStyleBackColor = true;
            this.bSearch.Click += new System.EventHandler(this.bSearch_Click);
            // 
            // label9
            // 
            this.label9.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
            this.label9.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label9.Font = new System.Drawing.Font("Gulim", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label9.Location = new System.Drawing.Point(12, 9);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(205, 28);
            this.label9.TabIndex = 0;
            this.label9.Text = "기본 할인율 설정";
            this.label9.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // grid2
            // 
            this.grid2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.grid2.EnableSort = true;
            this.grid2.Location = new System.Drawing.Point(467, 45);
            this.grid2.Name = "grid2";
            this.grid2.OptimizeMode = SourceGrid.CellOptimizeMode.ForRows;
            this.grid2.SelectionMode = SourceGrid.GridSelectionMode.Cell;
            this.grid2.Size = new System.Drawing.Size(645, 240);
            this.grid2.TabIndex = 2;
            this.grid2.TabStop = true;
            this.grid2.ToolTipText = "";
            this.grid2.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.grid2_MouseDoubleClick);
            // 
            // groupBox2
            // 
            this.groupBox2.BackColor = System.Drawing.SystemColors.Control;
            this.groupBox2.Controls.Add(this.cbWeight2);
            this.groupBox2.Controls.Add(this.cbWeight1);
            this.groupBox2.Controls.Add(this.label12);
            this.groupBox2.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.groupBox2.Location = new System.Drawing.Point(673, 291);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(125, 53);
            this.groupBox2.TabIndex = 8;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "무게";
            // 
            // cbWeight2
            // 
            this.cbWeight2.FormattingEnabled = true;
            this.cbWeight2.Items.AddRange(new object[] {
            "70",
            "80",
            "90",
            "100",
            "120",
            "150",
            "180",
            "200",
            "220",
            "250",
            "260",
            "300",
            "350",
            "400",
            "450",
            "500",
            "550"});
            this.cbWeight2.Location = new System.Drawing.Point(68, 20);
            this.cbWeight2.Name = "cbWeight2";
            this.cbWeight2.Size = new System.Drawing.Size(50, 20);
            this.cbWeight2.TabIndex = 1;
            // 
            // cbWeight1
            // 
            this.cbWeight1.FormattingEnabled = true;
            this.cbWeight1.Items.AddRange(new object[] {
            "70",
            "80",
            "90",
            "100",
            "120",
            "150",
            "180",
            "200",
            "220",
            "250",
            "260",
            "300",
            "350",
            "400",
            "450",
            "500",
            "550"});
            this.cbWeight1.Location = new System.Drawing.Point(4, 20);
            this.cbWeight1.Name = "cbWeight1";
            this.cbWeight1.Size = new System.Drawing.Size(50, 20);
            this.cbWeight1.TabIndex = 0;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(54, 26);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(14, 12);
            this.label12.TabIndex = 2;
            this.label12.Text = "~";
            // 
            // groupBox11
            // 
            this.groupBox11.BackColor = System.Drawing.SystemColors.Control;
            this.groupBox11.Controls.Add(this.rbPgroup);
            this.groupBox11.Controls.Add(this.rbPname);
            this.groupBox11.Controls.Add(this.rbPmake);
            this.groupBox11.Controls.Add(this.rbBunryu);
            this.groupBox11.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.groupBox11.Location = new System.Drawing.Point(1191, 291);
            this.groupBox11.Name = "groupBox11";
            this.groupBox11.Size = new System.Drawing.Size(157, 53);
            this.groupBox11.TabIndex = 13;
            this.groupBox11.TabStop = false;
            this.groupBox11.Text = "정렬방식";
            // 
            // rbPgroup
            // 
            this.rbPgroup.AutoSize = true;
            this.rbPgroup.Location = new System.Drawing.Point(6, 29);
            this.rbPgroup.Name = "rbPgroup";
            this.rbPgroup.Size = new System.Drawing.Size(71, 16);
            this.rbPgroup.TabIndex = 2;
            this.rbPgroup.TabStop = true;
            this.rbPgroup.Text = "종이그룹";
            this.rbPgroup.UseVisualStyleBackColor = true;
            // 
            // rbPname
            // 
            this.rbPname.AutoSize = true;
            this.rbPname.Checked = true;
            this.rbPname.Location = new System.Drawing.Point(6, 13);
            this.rbPname.Name = "rbPname";
            this.rbPname.Size = new System.Drawing.Size(59, 16);
            this.rbPname.TabIndex = 0;
            this.rbPname.TabStop = true;
            this.rbPname.Text = "종이명";
            this.rbPname.UseVisualStyleBackColor = true;
            // 
            // rbPmake
            // 
            this.rbPmake.AutoSize = true;
            this.rbPmake.Location = new System.Drawing.Point(83, 29);
            this.rbPmake.Name = "rbPmake";
            this.rbPmake.Size = new System.Drawing.Size(71, 16);
            this.rbPmake.TabIndex = 3;
            this.rbPmake.TabStop = true;
            this.rbPmake.Text = "제지회사";
            this.rbPmake.UseVisualStyleBackColor = true;
            // 
            // rbBunryu
            // 
            this.rbBunryu.AutoSize = true;
            this.rbBunryu.Location = new System.Drawing.Point(83, 13);
            this.rbBunryu.Name = "rbBunryu";
            this.rbBunryu.Size = new System.Drawing.Size(57, 16);
            this.rbBunryu.TabIndex = 1;
            this.rbBunryu.TabStop = true;
            this.rbBunryu.Text = "%분류";
            this.rbBunryu.UseVisualStyleBackColor = true;
            // 
            // groupBox3
            // 
            this.groupBox3.BackColor = System.Drawing.SystemColors.Control;
            this.groupBox3.Controls.Add(this.cbSock);
            this.groupBox3.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.groupBox3.Location = new System.Drawing.Point(1104, 291);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(79, 53);
            this.groupBox3.TabIndex = 12;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "속(장)";
            // 
            // cbSock
            // 
            this.cbSock.FormattingEnabled = true;
            this.cbSock.Items.AddRange(new object[] {
            "125",
            "250",
            "500"});
            this.cbSock.Location = new System.Drawing.Point(6, 22);
            this.cbSock.Name = "cbSock";
            this.cbSock.Size = new System.Drawing.Size(67, 20);
            this.cbSock.TabIndex = 0;
            // 
            // bApply
            // 
            this.bApply.Location = new System.Drawing.Point(12, 321);
            this.bApply.Name = "bApply";
            this.bApply.Size = new System.Drawing.Size(112, 23);
            this.bApply.TabIndex = 3;
            this.bApply.Text = "별도 할인율 적용";
            this.bApply.UseVisualStyleBackColor = true;
            this.bApply.Click += new System.EventHandler(this.bApply_Click);
            // 
            // bDel
            // 
            this.bDel.Location = new System.Drawing.Point(130, 321);
            this.bDel.Name = "bDel";
            this.bDel.Size = new System.Drawing.Size(84, 23);
            this.bDel.TabIndex = 4;
            this.bDel.Text = "할인율 삭제";
            this.bDel.UseVisualStyleBackColor = true;
            this.bDel.Click += new System.EventHandler(this.bDel_Click);
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.cbSpecial);
            this.groupBox5.Controls.Add(this.cbJoint);
            this.groupBox5.Location = new System.Drawing.Point(325, 291);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(158, 53);
            this.groupBox5.TabIndex = 5;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "검색 조건";
            // 
            // cbSpecial
            // 
            this.cbSpecial.AutoSize = true;
            this.cbSpecial.Location = new System.Drawing.Point(84, 21);
            this.cbSpecial.Name = "cbSpecial";
            this.cbSpecial.Size = new System.Drawing.Size(72, 16);
            this.cbSpecial.TabIndex = 1;
            this.cbSpecial.Text = "별도적용";
            this.cbSpecial.UseVisualStyleBackColor = true;
            // 
            // cbJoint
            // 
            this.cbJoint.AutoSize = true;
            this.cbJoint.Location = new System.Drawing.Point(6, 21);
            this.cbJoint.Name = "cbJoint";
            this.cbJoint.Size = new System.Drawing.Size(72, 16);
            this.cbJoint.TabIndex = 0;
            this.cbJoint.Text = "공동적용";
            this.cbJoint.UseVisualStyleBackColor = true;
            // 
            // bMacro
            // 
            this.bMacro.Location = new System.Drawing.Point(1120, 262);
            this.bMacro.Name = "bMacro";
            this.bMacro.Size = new System.Drawing.Size(101, 23);
            this.bMacro.TabIndex = 17;
            this.bMacro.Text = "메크로 DB전송";
            this.bMacro.UseVisualStyleBackColor = true;
            this.bMacro.Click += new System.EventHandler(this.bMacro_Click);
            // 
            // bSang
            // 
            this.bSang.Location = new System.Drawing.Point(1120, 233);
            this.bSang.Name = "bSang";
            this.bSang.Size = new System.Drawing.Size(101, 23);
            this.bSang.TabIndex = 17;
            this.bSang.Text = "상가책 DB전송";
            this.bSang.UseVisualStyleBackColor = true;
            this.bSang.Click += new System.EventHandler(this.bSang_Click);
            // 
            // watGroupBox1
            // 
            this.watGroupBox1.BorderColor = System.Drawing.Color.Black;
            this.watGroupBox1.Controls.Add(this.rbSang);
            this.watGroupBox1.Controls.Add(this.rbMacro);
            this.watGroupBox1.Controls.Add(this.rbCs);
            this.watGroupBox1.Location = new System.Drawing.Point(467, 2);
            this.watGroupBox1.Name = "watGroupBox1";
            this.watGroupBox1.Size = new System.Drawing.Size(183, 41);
            this.watGroupBox1.TabIndex = 1;
            this.watGroupBox1.TabStop = false;
            // 
            // rbSang
            // 
            this.rbSang.AutoSize = true;
            this.rbSang.Location = new System.Drawing.Point(117, 15);
            this.rbSang.Name = "rbSang";
            this.rbSang.Size = new System.Drawing.Size(59, 16);
            this.rbSang.TabIndex = 18;
            this.rbSang.Text = "상가책";
            this.rbSang.UseVisualStyleBackColor = true;
            this.rbSang.CheckedChanged += new System.EventHandler(this.rbSang_CheckedChanged);
            // 
            // rbMacro
            // 
            this.rbMacro.AutoSize = true;
            this.rbMacro.Location = new System.Drawing.Point(52, 15);
            this.rbMacro.Name = "rbMacro";
            this.rbMacro.Size = new System.Drawing.Size(59, 16);
            this.rbMacro.TabIndex = 18;
            this.rbMacro.Text = "메크로";
            this.rbMacro.UseVisualStyleBackColor = true;
            this.rbMacro.CheckedChanged += new System.EventHandler(this.rbMacro_CheckedChanged);
            // 
            // rbCs
            // 
            this.rbCs.AutoSize = true;
            this.rbCs.Checked = true;
            this.rbCs.Location = new System.Drawing.Point(6, 15);
            this.rbCs.Name = "rbCs";
            this.rbCs.Size = new System.Drawing.Size(40, 16);
            this.rbCs.TabIndex = 18;
            this.rbCs.TabStop = true;
            this.rbCs.Text = "CS";
            this.rbCs.UseVisualStyleBackColor = true;
            this.rbCs.CheckedChanged += new System.EventHandler(this.rbCs_CheckedChanged);
            // 
            // watGroupBox8
            // 
            this.watGroupBox8.BorderColor = System.Drawing.Color.Black;
            this.watGroupBox8.Controls.Add(this.tbMemo);
            this.watGroupBox8.Controls.Add(this.bSave);
            this.watGroupBox8.Location = new System.Drawing.Point(12, 40);
            this.watGroupBox8.Name = "watGroupBox8";
            this.watGroupBox8.Size = new System.Drawing.Size(443, 245);
            this.watGroupBox8.TabIndex = 1;
            this.watGroupBox8.TabStop = false;
            this.watGroupBox8.Text = "메모 ";
            // 
            // tbMemo
            // 
            this.tbMemo.Location = new System.Drawing.Point(6, 20);
            this.tbMemo.Multiline = true;
            this.tbMemo.Name = "tbMemo";
            this.tbMemo.Size = new System.Drawing.Size(431, 190);
            this.tbMemo.TabIndex = 0;
            // 
            // bSave
            // 
            this.bSave.Location = new System.Drawing.Point(362, 216);
            this.bSave.Name = "bSave";
            this.bSave.Size = new System.Drawing.Size(75, 23);
            this.bSave.TabIndex = 1;
            this.bSave.Text = "저장";
            this.bSave.UseVisualStyleBackColor = true;
            this.bSave.Click += new System.EventHandler(this.bSave_Click);
            // 
            // Form_502
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1490, 762);
            this.Controls.Add(this.bSang);
            this.Controls.Add(this.bMacro);
            this.Controls.Add(this.watGroupBox1);
            this.Controls.Add(this.bDel);
            this.Controls.Add(this.bApply);
            this.Controls.Add(this.watGroupBox8);
            this.Controls.Add(this.groupBox11);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.grid2);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.bSearch);
            this.Controls.Add(this.bClear);
            this.Controls.Add(this.groupBox8);
            this.Controls.Add(this.groupBox6);
            this.Controls.Add(this.groupBox7);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.groupBox5);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.grid1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form_502";
            this.Text = "기본 할인율";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Form_501_FormClosed);
            this.Load += new System.EventHandler(this.Form_501_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox4.ResumeLayout(false);
            this.groupBox6.ResumeLayout(false);
            this.groupBox7.ResumeLayout(false);
            this.groupBox7.PerformLayout();
            this.groupBox8.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox11.ResumeLayout(false);
            this.groupBox11.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox5.ResumeLayout(false);
            this.groupBox5.PerformLayout();
            this.watGroupBox1.ResumeLayout(false);
            this.watGroupBox1.PerformLayout();
            this.watGroupBox8.ResumeLayout(false);
            this.watGroupBox8.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private SourceGrid.Grid grid1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.ComboBox cbPgroup;
        private System.Windows.Forms.GroupBox groupBox6;
        private System.Windows.Forms.ComboBox cbPname;
        private System.Windows.Forms.GroupBox groupBox7;
        private System.Windows.Forms.TextBox tbPcolor;
        private System.Windows.Forms.GroupBox groupBox8;
        private System.Windows.Forms.ComboBox cbPmake;
        private System.Windows.Forms.Button bClear;
        private System.Windows.Forms.Button bSearch;
        private System.Windows.Forms.TextBox tbMemo;
        private System.Windows.Forms.Button bSave;
        private System.Windows.Forms.ComboBox cbBun;
        private System.Windows.Forms.Label label9;
        private SourceGrid.Grid grid2;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.ComboBox cbWeight2;
        private System.Windows.Forms.ComboBox cbWeight1;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.GroupBox groupBox11;
        private System.Windows.Forms.RadioButton rbPgroup;
        private System.Windows.Forms.RadioButton rbPmake;
        private System.Windows.Forms.RadioButton rbBunryu;
        private System.Windows.Forms.RadioButton rbPname;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.ComboBox cbSock;
        private Dukyou.WATGroupBox watGroupBox8;
        private System.Windows.Forms.Button bApply;
        private System.Windows.Forms.Button bDel;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.CheckBox cbSpecial;
        private System.Windows.Forms.CheckBox cbJoint;
        private System.Windows.Forms.Button bMacro;
        private System.Windows.Forms.Button bSang;
        private Dukyou.WATGroupBox watGroupBox1;
        private System.Windows.Forms.RadioButton rbSang;
        private System.Windows.Forms.RadioButton rbMacro;
        private System.Windows.Forms.RadioButton rbCs;
    }
}