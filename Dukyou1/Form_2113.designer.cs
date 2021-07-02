namespace Dukyou3
{
    partial class Form_2113
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form_2113));
            this.bRefresh = new System.Windows.Forms.Button();
            this.grid1 = new SourceGrid.Grid();
            this.bDel = new System.Windows.Forms.Button();
            this.bAdd = new System.Windows.Forms.Button();
            this.bUp = new System.Windows.Forms.Button();
            this.bDown = new System.Windows.Forms.Button();
            this.groupBox6 = new System.Windows.Forms.GroupBox();
            this.chkIndigo = new System.Windows.Forms.CheckBox();
            this.chkDigi = new System.Windows.Forms.CheckBox();
            this.chkNone = new System.Windows.Forms.CheckBox();
            this.chkMasta = new System.Windows.Forms.CheckBox();
            this.chkYun = new System.Windows.Forms.CheckBox();
            this.chkOffUV = new System.Windows.Forms.CheckBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.chkA4 = new System.Windows.Forms.CheckBox();
            this.chkPool = new System.Windows.Forms.CheckBox();
            this.chkNormal = new System.Windows.Forms.CheckBox();
            this.chkGuiYun = new System.Windows.Forms.CheckBox();
            this.Chk2Side = new System.Windows.Forms.CheckBox();
            this.chkJaemul = new System.Windows.Forms.CheckBox();
            this.bClear = new System.Windows.Forms.Button();
            this.bSearch = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.chkHari_b = new System.Windows.Forms.CheckBox();
            this.chkHari_d = new System.Windows.Forms.CheckBox();
            this.chkHari_c = new System.Windows.Forms.CheckBox();
            this.chkHari_a = new System.Windows.Forms.CheckBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.chkHang_p = new System.Windows.Forms.CheckBox();
            this.chkHang_s = new System.Windows.Forms.CheckBox();
            this.chkHang_a = new System.Windows.Forms.CheckBox();
            this.groupBox6.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // bRefresh
            // 
            this.bRefresh.Location = new System.Drawing.Point(13, 144);
            this.bRefresh.Name = "bRefresh";
            this.bRefresh.Size = new System.Drawing.Size(75, 23);
            this.bRefresh.TabIndex = 17;
            this.bRefresh.Text = "Refresh";
            this.bRefresh.UseVisualStyleBackColor = true;
            this.bRefresh.Click += new System.EventHandler(this.bRefresh_Click);
            // 
            // grid1
            // 
            this.grid1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.grid1.EnableSort = true;
            this.grid1.Location = new System.Drawing.Point(50, 173);
            this.grid1.Name = "grid1";
            this.grid1.OptimizeMode = SourceGrid.CellOptimizeMode.ForRows;
            this.grid1.SelectionMode = SourceGrid.GridSelectionMode.Cell;
            this.grid1.Size = new System.Drawing.Size(1132, 410);
            this.grid1.TabIndex = 16;
            this.grid1.TabStop = true;
            this.grid1.ToolTipText = "";
            // 
            // bDel
            // 
            this.bDel.Location = new System.Drawing.Point(1132, 144);
            this.bDel.Name = "bDel";
            this.bDel.Size = new System.Drawing.Size(50, 23);
            this.bDel.TabIndex = 15;
            this.bDel.Text = "삭제";
            this.bDel.UseVisualStyleBackColor = true;
            this.bDel.Click += new System.EventHandler(this.bDel_Click);
            // 
            // bAdd
            // 
            this.bAdd.Location = new System.Drawing.Point(1076, 144);
            this.bAdd.Name = "bAdd";
            this.bAdd.Size = new System.Drawing.Size(50, 23);
            this.bAdd.TabIndex = 14;
            this.bAdd.Text = "추가";
            this.bAdd.UseVisualStyleBackColor = true;
            this.bAdd.Click += new System.EventHandler(this.bAdd_Click);
            // 
            // bUp
            // 
            this.bUp.Location = new System.Drawing.Point(13, 173);
            this.bUp.Name = "bUp";
            this.bUp.Size = new System.Drawing.Size(31, 202);
            this.bUp.TabIndex = 12;
            this.bUp.Text = "▲";
            this.bUp.UseVisualStyleBackColor = true;
            this.bUp.Click += new System.EventHandler(this.bUp_Click);
            // 
            // bDown
            // 
            this.bDown.Location = new System.Drawing.Point(13, 381);
            this.bDown.Name = "bDown";
            this.bDown.Size = new System.Drawing.Size(31, 202);
            this.bDown.TabIndex = 13;
            this.bDown.Text = "▼";
            this.bDown.UseVisualStyleBackColor = true;
            this.bDown.Click += new System.EventHandler(this.bDown_Click);
            // 
            // groupBox6
            // 
            this.groupBox6.BackColor = System.Drawing.SystemColors.Control;
            this.groupBox6.Controls.Add(this.chkIndigo);
            this.groupBox6.Controls.Add(this.chkDigi);
            this.groupBox6.Controls.Add(this.chkNone);
            this.groupBox6.Controls.Add(this.chkMasta);
            this.groupBox6.Controls.Add(this.chkYun);
            this.groupBox6.Controls.Add(this.chkOffUV);
            this.groupBox6.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.groupBox6.Location = new System.Drawing.Point(599, 24);
            this.groupBox6.Name = "groupBox6";
            this.groupBox6.Size = new System.Drawing.Size(266, 106);
            this.groupBox6.TabIndex = 369;
            this.groupBox6.TabStop = false;
            this.groupBox6.Text = "인쇄코드";
            // 
            // chkIndigo
            // 
            this.chkIndigo.AutoSize = true;
            this.chkIndigo.Location = new System.Drawing.Point(169, 73);
            this.chkIndigo.Name = "chkIndigo";
            this.chkIndigo.Size = new System.Drawing.Size(88, 16);
            this.chkIndigo.TabIndex = 0;
            this.chkIndigo.Text = "인디고 [03]";
            this.chkIndigo.UseVisualStyleBackColor = true;
            this.chkIndigo.CheckedChanged += new System.EventHandler(this.chkIndigo_CheckedChanged);
            // 
            // chkDigi
            // 
            this.chkDigi.AutoSize = true;
            this.chkDigi.Location = new System.Drawing.Point(169, 51);
            this.chkDigi.Name = "chkDigi";
            this.chkDigi.Size = new System.Drawing.Size(88, 16);
            this.chkDigi.TabIndex = 0;
            this.chkDigi.Text = "디지탈 [02]";
            this.chkDigi.UseVisualStyleBackColor = true;
            this.chkDigi.CheckedChanged += new System.EventHandler(this.chkDigi_CheckedChanged);
            // 
            // chkNone
            // 
            this.chkNone.AutoSize = true;
            this.chkNone.Location = new System.Drawing.Point(16, 73);
            this.chkNone.Name = "chkNone";
            this.chkNone.Size = new System.Drawing.Size(100, 16);
            this.chkNone.TabIndex = 0;
            this.chkNone.Text = "인쇄없음 [09]";
            this.chkNone.UseVisualStyleBackColor = true;
            this.chkNone.CheckedChanged += new System.EventHandler(this.chkNone_CheckedChanged);
            // 
            // chkMasta
            // 
            this.chkMasta.AutoSize = true;
            this.chkMasta.Location = new System.Drawing.Point(169, 29);
            this.chkMasta.Name = "chkMasta";
            this.chkMasta.Size = new System.Drawing.Size(88, 16);
            this.chkMasta.TabIndex = 0;
            this.chkMasta.Text = "마스타 [01]";
            this.chkMasta.UseVisualStyleBackColor = true;
            this.chkMasta.CheckedChanged += new System.EventHandler(this.chkMasta_CheckedChanged);
            // 
            // chkYun
            // 
            this.chkYun.AutoSize = true;
            this.chkYun.Location = new System.Drawing.Point(16, 51);
            this.chkYun.Name = "chkYun";
            this.chkYun.Size = new System.Drawing.Size(76, 16);
            this.chkYun.TabIndex = 0;
            this.chkYun.Text = "윤전 [05]";
            this.chkYun.UseVisualStyleBackColor = true;
            this.chkYun.CheckedChanged += new System.EventHandler(this.chkYun_CheckedChanged);
            // 
            // chkOffUV
            // 
            this.chkOffUV.AutoSize = true;
            this.chkOffUV.Location = new System.Drawing.Point(16, 29);
            this.chkOffUV.Name = "chkOffUV";
            this.chkOffUV.Size = new System.Drawing.Size(126, 16);
            this.chkOffUV.TabIndex = 0;
            this.chkOffUV.Text = "옵셋 && UV [04/06]";
            this.chkOffUV.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.SystemColors.Control;
            this.groupBox1.Controls.Add(this.chkA4);
            this.groupBox1.Controls.Add(this.chkPool);
            this.groupBox1.Controls.Add(this.chkNormal);
            this.groupBox1.Controls.Add(this.chkGuiYun);
            this.groupBox1.Controls.Add(this.Chk2Side);
            this.groupBox1.Controls.Add(this.chkJaemul);
            this.groupBox1.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.groupBox1.Location = new System.Drawing.Point(888, 24);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(210, 106);
            this.groupBox1.TabIndex = 369;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "구와이 코드";
            // 
            // chkA4
            // 
            this.chkA4.AutoSize = true;
            this.chkA4.Location = new System.Drawing.Point(125, 73);
            this.chkA4.Name = "chkA4";
            this.chkA4.Size = new System.Drawing.Size(73, 16);
            this.chkA4.TabIndex = 0;
            this.chkA4.Text = "A4    [F]";
            this.chkA4.UseVisualStyleBackColor = true;
            this.chkA4.CheckedChanged += new System.EventHandler(this.chkA4_CheckedChanged);
            // 
            // chkPool
            // 
            this.chkPool.AutoSize = true;
            this.chkPool.Location = new System.Drawing.Point(125, 51);
            this.chkPool.Name = "chkPool";
            this.chkPool.Size = new System.Drawing.Size(72, 16);
            this.chkPool.TabIndex = 0;
            this.chkPool.Text = "풀    [E]";
            this.chkPool.UseVisualStyleBackColor = true;
            this.chkPool.CheckedChanged += new System.EventHandler(this.chkPool_CheckedChanged);
            // 
            // chkNormal
            // 
            this.chkNormal.AutoSize = true;
            this.chkNormal.Location = new System.Drawing.Point(16, 73);
            this.chkNormal.Name = "chkNormal";
            this.chkNormal.Size = new System.Drawing.Size(73, 16);
            this.chkNormal.TabIndex = 0;
            this.chkNormal.Text = "일반 [C]";
            this.chkNormal.UseVisualStyleBackColor = true;
            this.chkNormal.CheckedChanged += new System.EventHandler(this.chkNormal_CheckedChanged);
            // 
            // chkGuiYun
            // 
            this.chkGuiYun.AutoSize = true;
            this.chkGuiYun.Location = new System.Drawing.Point(125, 29);
            this.chkGuiYun.Name = "chkGuiYun";
            this.chkGuiYun.Size = new System.Drawing.Size(72, 16);
            this.chkGuiYun.TabIndex = 0;
            this.chkGuiYun.Text = "윤전 [D]";
            this.chkGuiYun.UseVisualStyleBackColor = true;
            this.chkGuiYun.CheckedChanged += new System.EventHandler(this.chkGuiYun_CheckedChanged);
            // 
            // Chk2Side
            // 
            this.Chk2Side.AutoSize = true;
            this.Chk2Side.Location = new System.Drawing.Point(16, 51);
            this.Chk2Side.Name = "Chk2Side";
            this.Chk2Side.Size = new System.Drawing.Size(72, 16);
            this.Chk2Side.TabIndex = 0;
            this.Chk2Side.Text = "양면 [B]";
            this.Chk2Side.UseVisualStyleBackColor = true;
            this.Chk2Side.CheckedChanged += new System.EventHandler(this.Chk2Side_CheckedChanged);
            // 
            // chkJaemul
            // 
            this.chkJaemul.AutoSize = true;
            this.chkJaemul.Location = new System.Drawing.Point(16, 29);
            this.chkJaemul.Name = "chkJaemul";
            this.chkJaemul.Size = new System.Drawing.Size(72, 16);
            this.chkJaemul.TabIndex = 0;
            this.chkJaemul.Text = "재물 [A]";
            this.chkJaemul.UseVisualStyleBackColor = true;
            this.chkJaemul.CheckedChanged += new System.EventHandler(this.chkJaemul_CheckedChanged);
            // 
            // bClear
            // 
            this.bClear.Location = new System.Drawing.Point(1104, 49);
            this.bClear.Name = "bClear";
            this.bClear.Size = new System.Drawing.Size(75, 23);
            this.bClear.TabIndex = 370;
            this.bClear.Text = "Clear";
            this.bClear.UseVisualStyleBackColor = true;
            this.bClear.Click += new System.EventHandler(this.bClear_Click);
            // 
            // bSearch
            // 
            this.bSearch.Location = new System.Drawing.Point(1104, 78);
            this.bSearch.Name = "bSearch";
            this.bSearch.Size = new System.Drawing.Size(75, 52);
            this.bSearch.TabIndex = 370;
            this.bSearch.Text = "검  색";
            this.bSearch.UseVisualStyleBackColor = true;
            this.bSearch.Click += new System.EventHandler(this.bSearch_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.BackColor = System.Drawing.SystemColors.Control;
            this.groupBox2.Controls.Add(this.chkHari_b);
            this.groupBox2.Controls.Add(this.chkHari_d);
            this.groupBox2.Controls.Add(this.chkHari_c);
            this.groupBox2.Controls.Add(this.chkHari_a);
            this.groupBox2.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.groupBox2.Location = new System.Drawing.Point(216, 24);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(364, 106);
            this.groupBox2.TabIndex = 369;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "하리모형";
            // 
            // chkHari_b
            // 
            this.chkHari_b.AutoSize = true;
            this.chkHari_b.Location = new System.Drawing.Point(6, 71);
            this.chkHari_b.Name = "chkHari_b";
            this.chkHari_b.Size = new System.Drawing.Size(129, 16);
            this.chkHari_b.TabIndex = 0;
            this.chkHari_b.Text = "낱장형 3방닷찌 [b]";
            this.chkHari_b.UseVisualStyleBackColor = true;
            // 
            // chkHari_d
            // 
            this.chkHari_d.AutoSize = true;
            this.chkHari_d.Location = new System.Drawing.Point(151, 71);
            this.chkHari_d.Name = "chkHari_d";
            this.chkHari_d.Size = new System.Drawing.Size(203, 16);
            this.chkHari_d.TabIndex = 0;
            this.chkHari_d.Text = "낱장형 4방닷찌 + 추가수불가 [d]";
            this.chkHari_d.UseVisualStyleBackColor = true;
            // 
            // chkHari_c
            // 
            this.chkHari_c.AutoSize = true;
            this.chkHari_c.Location = new System.Drawing.Point(151, 33);
            this.chkHari_c.Name = "chkHari_c";
            this.chkHari_c.Size = new System.Drawing.Size(203, 16);
            this.chkHari_c.TabIndex = 0;
            this.chkHari_c.Text = "낱장형 4방닷찌 + 추가수가능 [c]";
            this.chkHari_c.UseVisualStyleBackColor = true;
            // 
            // chkHari_a
            // 
            this.chkHari_a.AutoSize = true;
            this.chkHari_a.Location = new System.Drawing.Point(6, 33);
            this.chkHari_a.Name = "chkHari_a";
            this.chkHari_a.Size = new System.Drawing.Size(109, 16);
            this.chkHari_a.TabIndex = 0;
            this.chkHari_a.Text = "접지(DB)형 [a]";
            this.chkHari_a.UseVisualStyleBackColor = true;
            // 
            // groupBox3
            // 
            this.groupBox3.BackColor = System.Drawing.SystemColors.Control;
            this.groupBox3.Controls.Add(this.chkHang_p);
            this.groupBox3.Controls.Add(this.chkHang_s);
            this.groupBox3.Controls.Add(this.chkHang_a);
            this.groupBox3.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.groupBox3.Location = new System.Drawing.Point(79, 24);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(120, 106);
            this.groupBox3.TabIndex = 369;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "항목";
            // 
            // chkHang_p
            // 
            this.chkHang_p.AutoSize = true;
            this.chkHang_p.Location = new System.Drawing.Point(15, 76);
            this.chkHang_p.Name = "chkHang_p";
            this.chkHang_p.Size = new System.Drawing.Size(71, 16);
            this.chkHang_p.TabIndex = 371;
            this.chkHang_p.Text = "PET [p]";
            this.chkHang_p.UseVisualStyleBackColor = true;
            // 
            // chkHang_s
            // 
            this.chkHang_s.AutoSize = true;
            this.chkHang_s.Location = new System.Drawing.Point(15, 53);
            this.chkHang_s.Name = "chkHang_s";
            this.chkHang_s.Size = new System.Drawing.Size(83, 16);
            this.chkHang_s.TabIndex = 371;
            this.chkHang_s.Text = "스티커 [s]";
            this.chkHang_s.UseVisualStyleBackColor = true;
            // 
            // chkHang_a
            // 
            this.chkHang_a.AutoSize = true;
            this.chkHang_a.Location = new System.Drawing.Point(15, 29);
            this.chkHang_a.Name = "chkHang_a";
            this.chkHang_a.Size = new System.Drawing.Size(71, 16);
            this.chkHang_a.TabIndex = 371;
            this.chkHang_a.Text = "일반 [a]";
            this.chkHang_a.UseVisualStyleBackColor = true;
            // 
            // Form_2113
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1191, 595);
            this.Controls.Add(this.bSearch);
            this.Controls.Add(this.bClear);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox6);
            this.Controls.Add(this.bRefresh);
            this.Controls.Add(this.grid1);
            this.Controls.Add(this.bDel);
            this.Controls.Add(this.bAdd);
            this.Controls.Add(this.bUp);
            this.Controls.Add(this.bDown);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form_2113";
            this.Text = "인쇄 사이즈";
            this.Load += new System.EventHandler(this.Form_2113_Load);
            this.SizeChanged += new System.EventHandler(this.Form_2113_SizeChanged);
            this.groupBox6.ResumeLayout(false);
            this.groupBox6.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button bRefresh;
        private SourceGrid.Grid grid1;
        private System.Windows.Forms.Button bDel;
        private System.Windows.Forms.Button bAdd;
        private System.Windows.Forms.Button bUp;
        private System.Windows.Forms.Button bDown;
        private System.Windows.Forms.GroupBox groupBox6;
        private System.Windows.Forms.CheckBox chkNone;
        private System.Windows.Forms.CheckBox chkYun;
        private System.Windows.Forms.CheckBox chkOffUV;
        private System.Windows.Forms.CheckBox chkIndigo;
        private System.Windows.Forms.CheckBox chkDigi;
        private System.Windows.Forms.CheckBox chkMasta;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.CheckBox chkA4;
        private System.Windows.Forms.CheckBox chkPool;
        private System.Windows.Forms.CheckBox chkNormal;
        private System.Windows.Forms.CheckBox chkGuiYun;
        private System.Windows.Forms.CheckBox Chk2Side;
        private System.Windows.Forms.CheckBox chkJaemul;
        private System.Windows.Forms.Button bClear;
        private System.Windows.Forms.Button bSearch;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.CheckBox chkHari_b;
        private System.Windows.Forms.CheckBox chkHari_c;
        private System.Windows.Forms.CheckBox chkHari_a;
        private System.Windows.Forms.CheckBox chkHari_d;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.CheckBox chkHang_p;
        private System.Windows.Forms.CheckBox chkHang_s;
        private System.Windows.Forms.CheckBox chkHang_a;
    }
}