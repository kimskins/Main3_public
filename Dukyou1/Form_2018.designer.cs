namespace Dukyou3
{
    partial class Form_2018
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form_2018));
            this.tbJubji1 = new System.Windows.Forms.TextBox();
            this.bSave = new System.Windows.Forms.Button();
            this.tbJubji2 = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // tbJubji1
            // 
            this.tbJubji1.Location = new System.Drawing.Point(12, 24);
            this.tbJubji1.Name = "tbJubji1";
            this.tbJubji1.Size = new System.Drawing.Size(100, 21);
            this.tbJubji1.TabIndex = 0;
            // 
            // bSave
            // 
            this.bSave.Location = new System.Drawing.Point(134, 69);
            this.bSave.Name = "bSave";
            this.bSave.Size = new System.Drawing.Size(75, 23);
            this.bSave.TabIndex = 1;
            this.bSave.Text = "저장";
            this.bSave.UseVisualStyleBackColor = true;
            this.bSave.Click += new System.EventHandler(this.bSave_Click);
            // 
            // tbJubji2
            // 
            this.tbJubji2.Location = new System.Drawing.Point(12, 69);
            this.tbJubji2.Name = "tbJubji2";
            this.tbJubji2.Size = new System.Drawing.Size(100, 21);
            this.tbJubji2.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(69, 12);
            this.label1.TabIndex = 3;
            this.label1.Text = "쓰나기 없음";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 54);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(69, 12);
            this.label2.TabIndex = 3;
            this.label2.Text = "쓰나기 있음";
            // 
            // Form_2018
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(221, 104);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.tbJubji2);
            this.Controls.Add(this.bSave);
            this.Controls.Add(this.tbJubji1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form_2018";
            this.Text = "접지설정";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox tbJubji1;
        private System.Windows.Forms.Button bSave;
        private System.Windows.Forms.TextBox tbJubji2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
    }
}