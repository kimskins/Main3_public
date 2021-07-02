namespace Dukyou3
{
    partial class Form_3071d
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form_3071d));
            this.panel1 = new System.Windows.Forms.Panel();
            this.label7 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.bAutoInput = new System.Windows.Forms.Button();
            this.rbGrade = new System.Windows.Forms.RadioButton();
            this.rbGugan = new System.Windows.Forms.RadioButton();
            this.tbAdd = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.label7);
            this.panel1.Location = new System.Drawing.Point(12, 147);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(260, 108);
            this.panel1.TabIndex = 313;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(5, 13);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(38, 12);
            this.label7.TabIndex = 287;
            this.label7.Text = "label7";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(152, 25);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(52, 12);
            this.label2.TabIndex = 315;
            this.label2.Text = "(↓ 적용)";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(23, 25);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(55, 12);
            this.label1.TabIndex = 314;
            this.label1.Text = "(→ 적용)";
            // 
            // bAutoInput
            // 
            this.bAutoInput.Location = new System.Drawing.Point(186, 103);
            this.bAutoInput.Name = "bAutoInput";
            this.bAutoInput.Size = new System.Drawing.Size(86, 38);
            this.bAutoInput.TabIndex = 309;
            this.bAutoInput.Text = "자동입력";
            this.bAutoInput.UseVisualStyleBackColor = true;
            this.bAutoInput.Click += new System.EventHandler(this.bAutoInput_Click);
            // 
            // rbGrade
            // 
            this.rbGrade.AutoSize = true;
            this.rbGrade.Checked = true;
            this.rbGrade.Location = new System.Drawing.Point(12, 6);
            this.rbGrade.Name = "rbGrade";
            this.rbGrade.Size = new System.Drawing.Size(59, 16);
            this.rbGrade.TabIndex = 311;
            this.rbGrade.TabStop = true;
            this.rbGrade.Text = "등급별";
            this.rbGrade.UseVisualStyleBackColor = true;
            this.rbGrade.CheckedChanged += new System.EventHandler(this.rbGrade_CheckedChanged);
            // 
            // rbGugan
            // 
            this.rbGugan.AutoSize = true;
            this.rbGugan.Location = new System.Drawing.Point(139, 6);
            this.rbGugan.Name = "rbGugan";
            this.rbGugan.Size = new System.Drawing.Size(59, 16);
            this.rbGugan.TabIndex = 312;
            this.rbGugan.Text = "구간별";
            this.rbGugan.UseVisualStyleBackColor = true;
            // 
            // tbAdd
            // 
            this.tbAdd.Location = new System.Drawing.Point(139, 65);
            this.tbAdd.Name = "tbAdd";
            this.tbAdd.Size = new System.Drawing.Size(133, 21);
            this.tbAdd.TabIndex = 308;
            this.tbAdd.Text = "0";
            this.tbAdd.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.tbAdd.Click += new System.EventHandler(this.tbAdd_Click);
            // 
            // label3
            // 
            this.label3.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label3.Location = new System.Drawing.Point(12, 63);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(89, 22);
            this.label3.TabIndex = 310;
            this.label3.Text = "[가산%]";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // Form_3071d
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 267);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.bAutoInput);
            this.Controls.Add(this.rbGrade);
            this.Controls.Add(this.rbGugan);
            this.Controls.Add(this.tbAdd);
            this.Controls.Add(this.label3);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form_3071d";
            this.Text = "자동입력";
            this.Load += new System.EventHandler(this.Form_309d_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button bAutoInput;
        private System.Windows.Forms.RadioButton rbGrade;
        private System.Windows.Forms.RadioButton rbGugan;
        private System.Windows.Forms.TextBox tbAdd;
        private System.Windows.Forms.Label label3;
    }
}