namespace Dukyou3
{
    partial class Form_pet
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form_pet));
            this.grid1 = new SourceGrid.Grid();
            this.bSearch = new System.Windows.Forms.Button();
            this.bClear = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.bAdd = new System.Windows.Forms.Button();
            this.bDel = new System.Windows.Forms.Button();
            this.bCopy = new System.Windows.Forms.Button();
            this.watGroupBox4 = new Dukyou.WATGroupBox();
            this.cbCompany = new System.Windows.Forms.TextBox();
            this.watGroupBox3 = new Dukyou.WATGroupBox();
            this.cbUnit = new System.Windows.Forms.ComboBox();
            this.watGroupBox2 = new Dukyou.WATGroupBox();
            this.cbWondan = new System.Windows.Forms.ComboBox();
            this.watGroupBox1 = new Dukyou.WATGroupBox();
            this.label1 = new System.Windows.Forms.Label();
            this.cbThick2 = new System.Windows.Forms.ComboBox();
            this.cbThick1 = new System.Windows.Forms.ComboBox();
            this.watGroupBox4.SuspendLayout();
            this.watGroupBox3.SuspendLayout();
            this.watGroupBox2.SuspendLayout();
            this.watGroupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // grid1
            // 
            this.grid1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.grid1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.grid1.EnableSort = true;
            this.grid1.Location = new System.Drawing.Point(18, 162);
            this.grid1.Name = "grid1";
            this.grid1.OptimizeMode = SourceGrid.CellOptimizeMode.ForRows;
            this.grid1.SelectionMode = SourceGrid.GridSelectionMode.Cell;
            this.grid1.Size = new System.Drawing.Size(1029, 362);
            this.grid1.TabIndex = 397;
            this.grid1.TabStop = true;
            this.grid1.ToolTipText = "";
            // 
            // bSearch
            // 
            this.bSearch.Location = new System.Drawing.Point(625, 31);
            this.bSearch.Name = "bSearch";
            this.bSearch.Size = new System.Drawing.Size(75, 31);
            this.bSearch.TabIndex = 0;
            this.bSearch.Text = "검색";
            this.bSearch.UseVisualStyleBackColor = true;
            this.bSearch.Click += new System.EventHandler(this.bSearch_Click);
            // 
            // bClear
            // 
            this.bClear.Location = new System.Drawing.Point(700, 39);
            this.bClear.Name = "bClear";
            this.bClear.Size = new System.Drawing.Size(75, 23);
            this.bClear.TabIndex = 0;
            this.bClear.Text = "Clear";
            this.bClear.UseVisualStyleBackColor = true;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.ForeColor = System.Drawing.Color.Red;
            this.label2.Location = new System.Drawing.Point(10, 77);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(193, 12);
            this.label2.TabIndex = 1;
            this.label2.Text = "※ PET 원단은 주문형 발주입니다.\r\n";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.ForeColor = System.Drawing.Color.Red;
            this.label3.Location = new System.Drawing.Point(25, 94);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(445, 12);
            this.label3.TabIndex = 1;
            this.label3.Text = "자동계산되어지는 사이즈는 후공정과 인쇄물의 특성에 따라 맞지않을수 있습니다.";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.ForeColor = System.Drawing.Color.Red;
            this.label4.Location = new System.Drawing.Point(26, 111);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(189, 12);
            this.label4.TabIndex = 1;
            this.label4.Text = "하리판을 열어 확인후 진행하세요.";
            // 
            // bAdd
            // 
            this.bAdd.Location = new System.Drawing.Point(18, 133);
            this.bAdd.Name = "bAdd";
            this.bAdd.Size = new System.Drawing.Size(75, 23);
            this.bAdd.TabIndex = 0;
            this.bAdd.Text = "추가";
            this.bAdd.UseVisualStyleBackColor = true;
            this.bAdd.Click += new System.EventHandler(this.bAdd_Click);
            // 
            // bDel
            // 
            this.bDel.Location = new System.Drawing.Point(183, 133);
            this.bDel.Name = "bDel";
            this.bDel.Size = new System.Drawing.Size(75, 23);
            this.bDel.TabIndex = 0;
            this.bDel.Text = "삭제";
            this.bDel.UseVisualStyleBackColor = true;
            this.bDel.Click += new System.EventHandler(this.bDel_Click);
            // 
            // bCopy
            // 
            this.bCopy.Location = new System.Drawing.Point(99, 133);
            this.bCopy.Name = "bCopy";
            this.bCopy.Size = new System.Drawing.Size(75, 23);
            this.bCopy.TabIndex = 0;
            this.bCopy.Text = "복사";
            this.bCopy.UseVisualStyleBackColor = true;
            this.bCopy.Click += new System.EventHandler(this.bCopy_Click);
            // 
            // watGroupBox4
            // 
            this.watGroupBox4.BorderColor = System.Drawing.Color.Black;
            this.watGroupBox4.Controls.Add(this.cbCompany);
            this.watGroupBox4.Location = new System.Drawing.Point(470, 12);
            this.watGroupBox4.Name = "watGroupBox4";
            this.watGroupBox4.Size = new System.Drawing.Size(149, 50);
            this.watGroupBox4.TabIndex = 398;
            this.watGroupBox4.TabStop = false;
            this.watGroupBox4.Text = "제조사 ";
            // 
            // cbCompany
            // 
            this.cbCompany.Location = new System.Drawing.Point(6, 19);
            this.cbCompany.Name = "cbCompany";
            this.cbCompany.Size = new System.Drawing.Size(135, 21);
            this.cbCompany.TabIndex = 0;
            // 
            // watGroupBox3
            // 
            this.watGroupBox3.BorderColor = System.Drawing.Color.Black;
            this.watGroupBox3.Controls.Add(this.cbUnit);
            this.watGroupBox3.Location = new System.Drawing.Point(346, 12);
            this.watGroupBox3.Name = "watGroupBox3";
            this.watGroupBox3.Size = new System.Drawing.Size(118, 50);
            this.watGroupBox3.TabIndex = 398;
            this.watGroupBox3.TabStop = false;
            this.watGroupBox3.Text = "특성 ";
            // 
            // cbUnit
            // 
            this.cbUnit.FormattingEnabled = true;
            this.cbUnit.Location = new System.Drawing.Point(6, 20);
            this.cbUnit.Name = "cbUnit";
            this.cbUnit.Size = new System.Drawing.Size(104, 20);
            this.cbUnit.TabIndex = 0;
            // 
            // watGroupBox2
            // 
            this.watGroupBox2.BorderColor = System.Drawing.Color.Black;
            this.watGroupBox2.Controls.Add(this.cbWondan);
            this.watGroupBox2.Location = new System.Drawing.Point(177, 12);
            this.watGroupBox2.Name = "watGroupBox2";
            this.watGroupBox2.Size = new System.Drawing.Size(163, 50);
            this.watGroupBox2.TabIndex = 398;
            this.watGroupBox2.TabStop = false;
            this.watGroupBox2.Text = "원단명 ";
            // 
            // cbWondan
            // 
            this.cbWondan.FormattingEnabled = true;
            this.cbWondan.Location = new System.Drawing.Point(6, 20);
            this.cbWondan.Name = "cbWondan";
            this.cbWondan.Size = new System.Drawing.Size(147, 20);
            this.cbWondan.TabIndex = 0;
            // 
            // watGroupBox1
            // 
            this.watGroupBox1.BorderColor = System.Drawing.Color.Black;
            this.watGroupBox1.Controls.Add(this.label1);
            this.watGroupBox1.Controls.Add(this.cbThick2);
            this.watGroupBox1.Controls.Add(this.cbThick1);
            this.watGroupBox1.Location = new System.Drawing.Point(18, 12);
            this.watGroupBox1.Name = "watGroupBox1";
            this.watGroupBox1.Size = new System.Drawing.Size(153, 50);
            this.watGroupBox1.TabIndex = 398;
            this.watGroupBox1.TabStop = false;
            this.watGroupBox1.Text = "두께 ";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(67, 23);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(14, 12);
            this.label1.TabIndex = 1;
            this.label1.Text = "~";
            // 
            // cbThick2
            // 
            this.cbThick2.FormattingEnabled = true;
            this.cbThick2.Items.AddRange(new object[] {
            "0.1",
            "0.15",
            "0.2",
            "0.25",
            "0.3",
            "0.35",
            "0.4",
            "0.45",
            "0.5"});
            this.cbThick2.Location = new System.Drawing.Point(87, 20);
            this.cbThick2.Name = "cbThick2";
            this.cbThick2.Size = new System.Drawing.Size(55, 20);
            this.cbThick2.TabIndex = 0;
            // 
            // cbThick1
            // 
            this.cbThick1.FormattingEnabled = true;
            this.cbThick1.Items.AddRange(new object[] {
            "0.1",
            "0.15",
            "0.2",
            "0.25",
            "0.3",
            "0.35",
            "0.4",
            "0.45",
            "0.5"});
            this.cbThick1.Location = new System.Drawing.Point(6, 20);
            this.cbThick1.Name = "cbThick1";
            this.cbThick1.Size = new System.Drawing.Size(55, 20);
            this.cbThick1.TabIndex = 0;
            // 
            // Form_pet
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1051, 536);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.bCopy);
            this.Controls.Add(this.bDel);
            this.Controls.Add(this.bAdd);
            this.Controls.Add(this.bClear);
            this.Controls.Add(this.bSearch);
            this.Controls.Add(this.watGroupBox4);
            this.Controls.Add(this.watGroupBox3);
            this.Controls.Add(this.watGroupBox2);
            this.Controls.Add(this.watGroupBox1);
            this.Controls.Add(this.grid1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form_pet";
            this.Text = "PET";
            this.Load += new System.EventHandler(this.Form_pet_Load);
            this.watGroupBox4.ResumeLayout(false);
            this.watGroupBox4.PerformLayout();
            this.watGroupBox3.ResumeLayout(false);
            this.watGroupBox2.ResumeLayout(false);
            this.watGroupBox1.ResumeLayout(false);
            this.watGroupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private SourceGrid.Grid grid1;
        private Dukyou.WATGroupBox watGroupBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cbThick2;
        private System.Windows.Forms.ComboBox cbThick1;
        private Dukyou.WATGroupBox watGroupBox2;
        private System.Windows.Forms.ComboBox cbWondan;
        private Dukyou.WATGroupBox watGroupBox3;
        private System.Windows.Forms.ComboBox cbUnit;
        private Dukyou.WATGroupBox watGroupBox4;
        private System.Windows.Forms.TextBox cbCompany;
        private System.Windows.Forms.Button bSearch;
        private System.Windows.Forms.Button bClear;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button bAdd;
        private System.Windows.Forms.Button bDel;
        private System.Windows.Forms.Button bCopy;
    }
}