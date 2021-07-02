namespace Dukyou3
{
    partial class Form_207
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form_207));
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label1 = new System.Windows.Forms.Label();
            this.bGeneral = new System.Windows.Forms.Button();
            this.tbGeneral = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.bKoting = new System.Windows.Forms.Button();
            this.tbKoting = new System.Windows.Forms.TextBox();
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox2
            // 
            this.groupBox2.BackColor = System.Drawing.SystemColors.Control;
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Controls.Add(this.bGeneral);
            this.groupBox2.Controls.Add(this.tbGeneral);
            this.groupBox2.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.groupBox2.Location = new System.Drawing.Point(23, 21);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(988, 80);
            this.groupBox2.TabIndex = 0;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "1. 일반 후공정 검사";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 28);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(207, 12);
            this.label1.TabIndex = 2;
            this.label1.Text = "※ 아래코드 포함시 => 무조건 혼각게";
            // 
            // bGeneral
            // 
            this.bGeneral.Location = new System.Drawing.Point(919, 53);
            this.bGeneral.Name = "bGeneral";
            this.bGeneral.Size = new System.Drawing.Size(63, 23);
            this.bGeneral.TabIndex = 1;
            this.bGeneral.Text = "저  장";
            this.bGeneral.UseVisualStyleBackColor = true;
            this.bGeneral.Click += new System.EventHandler(this.bGeneral_Click);
            // 
            // tbGeneral
            // 
            this.tbGeneral.Location = new System.Drawing.Point(6, 53);
            this.tbGeneral.Name = "tbGeneral";
            this.tbGeneral.Size = new System.Drawing.Size(905, 21);
            this.tbGeneral.TabIndex = 0;
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.SystemColors.Control;
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.bKoting);
            this.groupBox1.Controls.Add(this.tbKoting);
            this.groupBox1.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.groupBox1.Location = new System.Drawing.Point(23, 107);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(988, 109);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "2. 코팅 후공정 검사";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(23, 59);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(207, 12);
            this.label4.TabIndex = 2;
            this.label4.Text = "하리돈땡일경우    => 코팅구와이검사";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(23, 43);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(195, 12);
            this.label3.TabIndex = 2;
            this.label3.Text = "구와이돈땡일경우 => 무조건혼각게";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(7, 24);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(109, 12);
            this.label2.TabIndex = 2;
            this.label2.Text = "※ 아래코드 포함시";
            // 
            // bKoting
            // 
            this.bKoting.Location = new System.Drawing.Point(919, 77);
            this.bKoting.Name = "bKoting";
            this.bKoting.Size = new System.Drawing.Size(63, 23);
            this.bKoting.TabIndex = 1;
            this.bKoting.Text = "저  장";
            this.bKoting.UseVisualStyleBackColor = true;
            this.bKoting.Click += new System.EventHandler(this.bKoting_Click);
            // 
            // tbKoting
            // 
            this.tbKoting.Location = new System.Drawing.Point(8, 77);
            this.tbKoting.Name = "tbKoting";
            this.tbKoting.Size = new System.Drawing.Size(905, 21);
            this.tbKoting.TabIndex = 0;
            // 
            // Form_207
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1023, 232);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.groupBox2);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form_207";
            this.Text = "돈땡검사";
            this.Load += new System.EventHandler(this.Form_214_Load);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button bGeneral;
        private System.Windows.Forms.TextBox tbGeneral;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button bKoting;
        private System.Windows.Forms.TextBox tbKoting;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label4;
    }
}