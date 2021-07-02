namespace Dukyou3
{
    partial class Form_4011d
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form_4011d));
            this.grid1 = new SourceGrid.Grid();
            this.bPermit = new System.Windows.Forms.Button();
            this.bDel = new System.Windows.Forms.Button();
            this.rbAll = new System.Windows.Forms.RadioButton();
            this.rbDel = new System.Windows.Forms.RadioButton();
            this.rbPermit = new System.Windows.Forms.RadioButton();
            this.watGroupBox2 = new Dukyou.WATGroupBox();
            this.radioButton1 = new System.Windows.Forms.RadioButton();
            this.radioButton2 = new System.Windows.Forms.RadioButton();
            this.radioButton3 = new System.Windows.Forms.RadioButton();
            this.watGroupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // grid1
            // 
            this.grid1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.grid1.EnableSort = true;
            this.grid1.Location = new System.Drawing.Point(12, 76);
            this.grid1.Name = "grid1";
            this.grid1.OptimizeMode = SourceGrid.CellOptimizeMode.ForRows;
            this.grid1.SelectionMode = SourceGrid.GridSelectionMode.Cell;
            this.grid1.Size = new System.Drawing.Size(214, 338);
            this.grid1.TabIndex = 288;
            this.grid1.TabStop = true;
            this.grid1.ToolTipText = "";
            // 
            // bPermit
            // 
            this.bPermit.Location = new System.Drawing.Point(12, 47);
            this.bPermit.Name = "bPermit";
            this.bPermit.Size = new System.Drawing.Size(91, 23);
            this.bPermit.TabIndex = 289;
            this.bPermit.Text = "허용";
            this.bPermit.UseVisualStyleBackColor = true;
            this.bPermit.Click += new System.EventHandler(this.bPermit_Click);
            // 
            // bDel
            // 
            this.bDel.Location = new System.Drawing.Point(135, 47);
            this.bDel.Name = "bDel";
            this.bDel.Size = new System.Drawing.Size(91, 23);
            this.bDel.TabIndex = 289;
            this.bDel.Text = "불허";
            this.bDel.UseVisualStyleBackColor = true;
            this.bDel.Click += new System.EventHandler(this.bDel_Click);
            // 
            // rbAll
            // 
            this.rbAll.AutoSize = true;
            this.rbAll.Location = new System.Drawing.Point(130, 6);
            this.rbAll.Name = "rbAll";
            this.rbAll.Size = new System.Drawing.Size(71, 16);
            this.rbAll.TabIndex = 368;
            this.rbAll.TabStop = true;
            this.rbAll.Text = "전체보기";
            this.rbAll.UseVisualStyleBackColor = true;
            // 
            // rbDel
            // 
            this.rbDel.AutoSize = true;
            this.rbDel.Location = new System.Drawing.Point(70, 6);
            this.rbDel.Name = "rbDel";
            this.rbDel.Size = new System.Drawing.Size(47, 16);
            this.rbDel.TabIndex = 368;
            this.rbDel.TabStop = true;
            this.rbDel.Text = "불허";
            this.rbDel.UseVisualStyleBackColor = true;
            // 
            // rbPermit
            // 
            this.rbPermit.AutoSize = true;
            this.rbPermit.Location = new System.Drawing.Point(6, 6);
            this.rbPermit.Name = "rbPermit";
            this.rbPermit.Size = new System.Drawing.Size(47, 16);
            this.rbPermit.TabIndex = 368;
            this.rbPermit.TabStop = true;
            this.rbPermit.Text = "허용";
            this.rbPermit.UseVisualStyleBackColor = true;
            this.rbPermit.CheckedChanged += new System.EventHandler(this.rbPermit_CheckedChanged);
            // 
            // watGroupBox2
            // 
            this.watGroupBox2.BorderColor = System.Drawing.Color.RoyalBlue;
            this.watGroupBox2.Controls.Add(this.radioButton1);
            this.watGroupBox2.Controls.Add(this.radioButton2);
            this.watGroupBox2.Controls.Add(this.radioButton3);
            this.watGroupBox2.Location = new System.Drawing.Point(12, 12);
            this.watGroupBox2.Name = "watGroupBox2";
            this.watGroupBox2.Size = new System.Drawing.Size(214, 29);
            this.watGroupBox2.TabIndex = 368;
            this.watGroupBox2.TabStop = false;
            // 
            // radioButton1
            // 
            this.radioButton1.AutoSize = true;
            this.radioButton1.Location = new System.Drawing.Point(112, 6);
            this.radioButton1.Name = "radioButton1";
            this.radioButton1.Size = new System.Drawing.Size(71, 16);
            this.radioButton1.TabIndex = 368;
            this.radioButton1.TabStop = true;
            this.radioButton1.Text = "전체보기";
            this.radioButton1.UseVisualStyleBackColor = true;
            this.radioButton1.CheckedChanged += new System.EventHandler(this.rbAll_CheckedChanged);
            // 
            // radioButton2
            // 
            this.radioButton2.AutoSize = true;
            this.radioButton2.Location = new System.Drawing.Point(59, 6);
            this.radioButton2.Name = "radioButton2";
            this.radioButton2.Size = new System.Drawing.Size(47, 16);
            this.radioButton2.TabIndex = 368;
            this.radioButton2.TabStop = true;
            this.radioButton2.Text = "불허";
            this.radioButton2.UseVisualStyleBackColor = true;
            this.radioButton2.CheckedChanged += new System.EventHandler(this.rbDel_CheckedChanged);
            // 
            // radioButton3
            // 
            this.radioButton3.AutoSize = true;
            this.radioButton3.Location = new System.Drawing.Point(6, 6);
            this.radioButton3.Name = "radioButton3";
            this.radioButton3.Size = new System.Drawing.Size(47, 16);
            this.radioButton3.TabIndex = 368;
            this.radioButton3.TabStop = true;
            this.radioButton3.Text = "허용";
            this.radioButton3.UseVisualStyleBackColor = true;
            this.radioButton3.CheckedChanged += new System.EventHandler(this.rbPermit_CheckedChanged);
            // 
            // Form_4011d
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(238, 425);
            this.Controls.Add(this.watGroupBox2);
            this.Controls.Add(this.bDel);
            this.Controls.Add(this.bPermit);
            this.Controls.Add(this.grid1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form_4011d";
            this.Text = "미등록 사용자";
            this.Load += new System.EventHandler(this.Form_4011d_Load);
            this.watGroupBox2.ResumeLayout(false);
            this.watGroupBox2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        public SourceGrid.Grid grid1;
        private System.Windows.Forms.Button bPermit;
        private System.Windows.Forms.Button bDel;
        private System.Windows.Forms.RadioButton rbAll;
        private System.Windows.Forms.RadioButton rbDel;
        private System.Windows.Forms.RadioButton rbPermit;
        private Dukyou.WATGroupBox watGroupBox2;
        private System.Windows.Forms.RadioButton radioButton1;
        private System.Windows.Forms.RadioButton radioButton2;
        private System.Windows.Forms.RadioButton radioButton3;
    }
}