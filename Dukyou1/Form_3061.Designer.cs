namespace Dukyou3
{
    partial class Form_3061
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form_3061));
            this.grid1 = new SourceGrid.Grid();
            this.label5 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.button3 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.button5 = new System.Windows.Forms.Button();
            this.watGroupBox4 = new Dukyou.WATGroupBox();
            this.cbMyunsu2 = new System.Windows.Forms.ComboBox();
            this.cbBal2 = new System.Windows.Forms.ComboBox();
            this.cbJubji2 = new System.Windows.Forms.ComboBox();
            this.watGroupBox2 = new Dukyou.WATGroupBox();
            this.cbBal1 = new System.Windows.Forms.ComboBox();
            this.cbMyunsu1 = new System.Windows.Forms.ComboBox();
            this.cbJubji1 = new System.Windows.Forms.ComboBox();
            this.watGroupBox1 = new Dukyou.WATGroupBox();
            this.tbJubnm = new System.Windows.Forms.TextBox();
            this.watGroupBox3 = new Dukyou.WATGroupBox();
            this.tbJubcode = new System.Windows.Forms.TextBox();
            this.watGroupBox4.SuspendLayout();
            this.watGroupBox2.SuspendLayout();
            this.watGroupBox1.SuspendLayout();
            this.watGroupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // grid1
            // 
            this.grid1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grid1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.grid1.EnableSort = true;
            this.grid1.Location = new System.Drawing.Point(12, 73);
            this.grid1.Name = "grid1";
            this.grid1.OptimizeMode = SourceGrid.CellOptimizeMode.ForRows;
            this.grid1.SelectionMode = SourceGrid.GridSelectionMode.Cell;
            this.grid1.Size = new System.Drawing.Size(1580, 606);
            this.grid1.TabIndex = 0;
            this.grid1.TabStop = true;
            this.grid1.ToolTipText = "";
            this.grid1.MouseClick += new System.Windows.Forms.MouseEventHandler(this.grid1_MouseClick);
            this.grid1.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.grid1_MouseDoubleClick);
            // 
            // label5
            // 
            this.label5.BackColor = System.Drawing.Color.PeachPuff;
            this.label5.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label5.Font = new System.Drawing.Font("Gulim", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label5.Location = new System.Drawing.Point(-462, 36);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(133, 32);
            this.label5.TabIndex = 336;
            this.label5.Text = "운송단가 DB";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(1132, 44);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(53, 23);
            this.button1.TabIndex = 339;
            this.button1.Text = "Clear";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(1073, 34);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(53, 33);
            this.button2.TabIndex = 340;
            this.button2.Text = "검색";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.Color.PeachPuff;
            this.label1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label1.Font = new System.Drawing.Font("Gulim", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label1.Location = new System.Drawing.Point(12, 37);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(152, 32);
            this.label1.TabIndex = 329;
            this.label1.Text = "유형별 접지단가";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(170, 44);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(53, 23);
            this.button3.TabIndex = 341;
            this.button3.Text = "추가";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(229, 44);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(53, 23);
            this.button4.TabIndex = 342;
            this.button4.Text = "복사";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // button5
            // 
            this.button5.Location = new System.Drawing.Point(288, 44);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(53, 23);
            this.button5.TabIndex = 343;
            this.button5.Text = "삭제";
            this.button5.UseVisualStyleBackColor = true;
            this.button5.Click += new System.EventHandler(this.button5_Click);
            // 
            // watGroupBox4
            // 
            this.watGroupBox4.BorderColor = System.Drawing.Color.RoyalBlue;
            this.watGroupBox4.Controls.Add(this.cbMyunsu2);
            this.watGroupBox4.Controls.Add(this.cbBal2);
            this.watGroupBox4.Controls.Add(this.cbJubji2);
            this.watGroupBox4.Location = new System.Drawing.Point(841, 18);
            this.watGroupBox4.Name = "watGroupBox4";
            this.watGroupBox4.Size = new System.Drawing.Size(226, 49);
            this.watGroupBox4.TabIndex = 341;
            this.watGroupBox4.TabStop = false;
            this.watGroupBox4.Text = "2차접지 / 2차면수 / 2차발체수  ";
            // 
            // cbMyunsu2
            // 
            this.cbMyunsu2.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbMyunsu2.FormattingEnabled = true;
            this.cbMyunsu2.Location = new System.Drawing.Point(111, 19);
            this.cbMyunsu2.Name = "cbMyunsu2";
            this.cbMyunsu2.Size = new System.Drawing.Size(50, 20);
            this.cbMyunsu2.TabIndex = 1;
            this.cbMyunsu2.SelectedValueChanged += new System.EventHandler(this.cbMyunsu2_SelectedValueChanged);
            // 
            // cbBal2
            // 
            this.cbBal2.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbBal2.FormattingEnabled = true;
            this.cbBal2.Location = new System.Drawing.Point(166, 19);
            this.cbBal2.Name = "cbBal2";
            this.cbBal2.Size = new System.Drawing.Size(50, 20);
            this.cbBal2.TabIndex = 0;
            this.cbBal2.SelectedValueChanged += new System.EventHandler(this.cbBal2_SelectedValueChanged);
            // 
            // cbJubji2
            // 
            this.cbJubji2.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbJubji2.FormattingEnabled = true;
            this.cbJubji2.Items.AddRange(new object[] {
            "반접지",
            "두루마리",
            "병풍(N접지)",
            "대문접지"});
            this.cbJubji2.Location = new System.Drawing.Point(6, 19);
            this.cbJubji2.Name = "cbJubji2";
            this.cbJubji2.Size = new System.Drawing.Size(99, 20);
            this.cbJubji2.TabIndex = 1;
            this.cbJubji2.SelectedValueChanged += new System.EventHandler(this.cbJubji2_SelectedValueChanged);
            // 
            // watGroupBox2
            // 
            this.watGroupBox2.BorderColor = System.Drawing.Color.RoyalBlue;
            this.watGroupBox2.Controls.Add(this.cbBal1);
            this.watGroupBox2.Controls.Add(this.cbMyunsu1);
            this.watGroupBox2.Controls.Add(this.cbJubji1);
            this.watGroupBox2.Location = new System.Drawing.Point(609, 18);
            this.watGroupBox2.Name = "watGroupBox2";
            this.watGroupBox2.Size = new System.Drawing.Size(226, 49);
            this.watGroupBox2.TabIndex = 341;
            this.watGroupBox2.TabStop = false;
            this.watGroupBox2.Text = "1차접지 / 1차면수 / 1차발체수  ";
            // 
            // cbBal1
            // 
            this.cbBal1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbBal1.FormattingEnabled = true;
            this.cbBal1.Location = new System.Drawing.Point(166, 19);
            this.cbBal1.Name = "cbBal1";
            this.cbBal1.Size = new System.Drawing.Size(50, 20);
            this.cbBal1.TabIndex = 0;
            this.cbBal1.SelectedValueChanged += new System.EventHandler(this.cbBal1_SelectedValueChanged);
            // 
            // cbMyunsu1
            // 
            this.cbMyunsu1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbMyunsu1.FormattingEnabled = true;
            this.cbMyunsu1.Location = new System.Drawing.Point(110, 19);
            this.cbMyunsu1.Name = "cbMyunsu1";
            this.cbMyunsu1.Size = new System.Drawing.Size(50, 20);
            this.cbMyunsu1.TabIndex = 0;
            this.cbMyunsu1.SelectedValueChanged += new System.EventHandler(this.cbMyunsu1_SelectedValueChanged);
            // 
            // cbJubji1
            // 
            this.cbJubji1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbJubji1.FormattingEnabled = true;
            this.cbJubji1.Items.AddRange(new object[] {
            "반접지",
            "두루마리",
            "병풍(N접지)",
            "대문접지"});
            this.cbJubji1.Location = new System.Drawing.Point(6, 19);
            this.cbJubji1.Name = "cbJubji1";
            this.cbJubji1.Size = new System.Drawing.Size(99, 20);
            this.cbJubji1.TabIndex = 0;
            this.cbJubji1.SelectedValueChanged += new System.EventHandler(this.cbJubji1_SelectedValueChanged);
            // 
            // watGroupBox1
            // 
            this.watGroupBox1.BorderColor = System.Drawing.Color.RoyalBlue;
            this.watGroupBox1.Controls.Add(this.tbJubnm);
            this.watGroupBox1.Location = new System.Drawing.Point(478, 18);
            this.watGroupBox1.Name = "watGroupBox1";
            this.watGroupBox1.Size = new System.Drawing.Size(125, 49);
            this.watGroupBox1.TabIndex = 341;
            this.watGroupBox1.TabStop = false;
            this.watGroupBox1.Text = "접지 이름 ";
            // 
            // tbJubnm
            // 
            this.tbJubnm.Location = new System.Drawing.Point(6, 19);
            this.tbJubnm.Name = "tbJubnm";
            this.tbJubnm.Size = new System.Drawing.Size(110, 21);
            this.tbJubnm.TabIndex = 323;
            this.tbJubnm.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // watGroupBox3
            // 
            this.watGroupBox3.BorderColor = System.Drawing.Color.RoyalBlue;
            this.watGroupBox3.Controls.Add(this.tbJubcode);
            this.watGroupBox3.Location = new System.Drawing.Point(367, 18);
            this.watGroupBox3.Name = "watGroupBox3";
            this.watGroupBox3.Size = new System.Drawing.Size(105, 49);
            this.watGroupBox3.TabIndex = 341;
            this.watGroupBox3.TabStop = false;
            this.watGroupBox3.Text = "접지 코드 ";
            // 
            // tbJubcode
            // 
            this.tbJubcode.Location = new System.Drawing.Point(6, 20);
            this.tbJubcode.Name = "tbJubcode";
            this.tbJubcode.Size = new System.Drawing.Size(90, 21);
            this.tbJubcode.TabIndex = 324;
            this.tbJubcode.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // Form_3061
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1604, 720);
            this.Controls.Add(this.watGroupBox4);
            this.Controls.Add(this.watGroupBox2);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.watGroupBox1);
            this.Controls.Add(this.watGroupBox3);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.button5);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.grid1);
            this.Controls.Add(this.label5);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form_3061";
            this.Text = "■ 유형별 접지단가";
            this.Load += new System.EventHandler(this.Form_310_Load);
            this.watGroupBox4.ResumeLayout(false);
            this.watGroupBox2.ResumeLayout(false);
            this.watGroupBox1.ResumeLayout(false);
            this.watGroupBox1.PerformLayout();
            this.watGroupBox3.ResumeLayout(false);
            this.watGroupBox3.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private SourceGrid.Grid grid1;
        private System.Windows.Forms.TextBox tbJubnm;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox cbMyunsu1;
        private System.Windows.Forms.ComboBox cbJubji1;
        private System.Windows.Forms.ComboBox cbMyunsu2;
        private System.Windows.Forms.ComboBox cbJubji2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Button button5;
        private Dukyou.WATGroupBox watGroupBox3;
        private System.Windows.Forms.TextBox tbJubcode;
        private Dukyou.WATGroupBox watGroupBox1;
        private Dukyou.WATGroupBox watGroupBox2;
        private System.Windows.Forms.ComboBox cbBal1;
        private Dukyou.WATGroupBox watGroupBox4;
        private System.Windows.Forms.ComboBox cbBal2;
    }
}