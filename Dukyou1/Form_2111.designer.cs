namespace Dukyou3
{
    partial class Form_2111
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form_2111));
            this.grid2 = new SourceGrid.Grid();
            this.grid1 = new SourceGrid.Grid();
            this.button1 = new System.Windows.Forms.Button();
            this.radioButton1 = new System.Windows.Forms.RadioButton();
            this.radioButton2 = new System.Windows.Forms.RadioButton();
            this.radioButton3 = new System.Windows.Forms.RadioButton();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.bAdd46 = new System.Windows.Forms.Button();
            this.bAddKook = new System.Windows.Forms.Button();
            this.bDel = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // grid2
            // 
            this.grid2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.grid2.EnableSort = true;
            this.grid2.Location = new System.Drawing.Point(257, 120);
            this.grid2.Name = "grid2";
            this.grid2.OptimizeMode = SourceGrid.CellOptimizeMode.ForRows;
            this.grid2.SelectionMode = SourceGrid.GridSelectionMode.Cell;
            this.grid2.Size = new System.Drawing.Size(245, 297);
            this.grid2.TabIndex = 6;
            this.grid2.TabStop = true;
            this.grid2.ToolTipText = "";
            // 
            // grid1
            // 
            this.grid1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.grid1.EnableSort = true;
            this.grid1.Location = new System.Drawing.Point(12, 120);
            this.grid1.Name = "grid1";
            this.grid1.OptimizeMode = SourceGrid.CellOptimizeMode.ForRows;
            this.grid1.SelectionMode = SourceGrid.GridSelectionMode.Cell;
            this.grid1.Size = new System.Drawing.Size(245, 297);
            this.grid1.TabIndex = 5;
            this.grid1.TabStop = true;
            this.grid1.ToolTipText = "";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(402, 23);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(60, 32);
            this.button1.TabIndex = 7;
            this.button1.Text = "검 색";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // radioButton1
            // 
            this.radioButton1.AutoSize = true;
            this.radioButton1.Location = new System.Drawing.Point(14, 6);
            this.radioButton1.Name = "radioButton1";
            this.radioButton1.Size = new System.Drawing.Size(83, 16);
            this.radioButton1.TabIndex = 8;
            this.radioButton1.TabStop = true;
            this.radioButton1.Text = "도큐싸이즈";
            this.radioButton1.UseVisualStyleBackColor = true;
            this.radioButton1.Click += new System.EventHandler(this.radioButton1_Click);
            // 
            // radioButton2
            // 
            this.radioButton2.AutoSize = true;
            this.radioButton2.Location = new System.Drawing.Point(103, 6);
            this.radioButton2.Name = "radioButton2";
            this.radioButton2.Size = new System.Drawing.Size(83, 16);
            this.radioButton2.TabIndex = 9;
            this.radioButton2.TabStop = true;
            this.radioButton2.Text = "인쇄싸이즈";
            this.radioButton2.UseVisualStyleBackColor = true;
            this.radioButton2.Click += new System.EventHandler(this.radioButton2_Click);
            // 
            // radioButton3
            // 
            this.radioButton3.AutoSize = true;
            this.radioButton3.Location = new System.Drawing.Point(192, 6);
            this.radioButton3.Name = "radioButton3";
            this.radioButton3.Size = new System.Drawing.Size(83, 16);
            this.radioButton3.TabIndex = 10;
            this.radioButton3.TabStop = true;
            this.radioButton3.Text = "종이싸이즈";
            this.radioButton3.UseVisualStyleBackColor = true;
            this.radioButton3.Click += new System.EventHandler(this.radioButton3_Click);
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.radioButton1);
            this.panel1.Controls.Add(this.radioButton3);
            this.panel1.Controls.Add(this.radioButton2);
            this.panel1.Location = new System.Drawing.Point(63, 27);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(288, 29);
            this.panel1.TabIndex = 11;
            // 
            // label1
            // 
            this.label1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label1.Location = new System.Drawing.Point(12, 27);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(51, 29);
            this.label1.TabIndex = 12;
            this.label1.Text = "구 분";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // bAdd46
            // 
            this.bAdd46.Location = new System.Drawing.Point(12, 91);
            this.bAdd46.Name = "bAdd46";
            this.bAdd46.Size = new System.Drawing.Size(75, 23);
            this.bAdd46.TabIndex = 13;
            this.bAdd46.Text = "46판 추가";
            this.bAdd46.UseVisualStyleBackColor = true;
            this.bAdd46.Click += new System.EventHandler(this.bAdd46_Click);
            // 
            // bAddKook
            // 
            this.bAddKook.Location = new System.Drawing.Point(93, 91);
            this.bAddKook.Name = "bAddKook";
            this.bAddKook.Size = new System.Drawing.Size(75, 23);
            this.bAddKook.TabIndex = 13;
            this.bAddKook.Text = "국판 추가";
            this.bAddKook.UseVisualStyleBackColor = true;
            this.bAddKook.Click += new System.EventHandler(this.bAddKook_Click);
            // 
            // bDel
            // 
            this.bDel.Location = new System.Drawing.Point(175, 91);
            this.bDel.Name = "bDel";
            this.bDel.Size = new System.Drawing.Size(75, 23);
            this.bDel.TabIndex = 13;
            this.bDel.Text = "선택 삭제";
            this.bDel.UseVisualStyleBackColor = true;
            this.bDel.Click += new System.EventHandler(this.bDel_Click);
            // 
            // Form_2111
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(536, 434);
            this.Controls.Add(this.bDel);
            this.Controls.Add(this.bAddKook);
            this.Controls.Add(this.bAdd46);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.grid2);
            this.Controls.Add(this.grid1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form_2111";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "■ 싸이즈 수정";
            this.Load += new System.EventHandler(this.Form_211_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private SourceGrid.Grid grid2;
        private SourceGrid.Grid grid1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.RadioButton radioButton1;
        private System.Windows.Forms.RadioButton radioButton2;
        private System.Windows.Forms.RadioButton radioButton3;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button bAdd46;
        private System.Windows.Forms.Button bAddKook;
        private System.Windows.Forms.Button bDel;
    }
}