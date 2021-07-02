namespace Dukyou3
{
    partial class Form_3072c
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form_3072c));
            this.bConfirm = new System.Windows.Forms.Button();
            this.tbEndPrice = new System.Windows.Forms.TextBox();
            this.tbStartPrice = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // bConfirm
            // 
            this.bConfirm.Location = new System.Drawing.Point(140, 95);
            this.bConfirm.Name = "bConfirm";
            this.bConfirm.Size = new System.Drawing.Size(75, 23);
            this.bConfirm.TabIndex = 286;
            this.bConfirm.Text = "확인";
            this.bConfirm.UseVisualStyleBackColor = true;
            this.bConfirm.Click += new System.EventHandler(this.bConfirm_Click);
            // 
            // tbEndPrice
            // 
            this.tbEndPrice.Location = new System.Drawing.Point(115, 56);
            this.tbEndPrice.Name = "tbEndPrice";
            this.tbEndPrice.Size = new System.Drawing.Size(100, 21);
            this.tbEndPrice.TabIndex = 285;
            // 
            // tbStartPrice
            // 
            this.tbStartPrice.Location = new System.Drawing.Point(115, 21);
            this.tbStartPrice.Name = "tbStartPrice";
            this.tbStartPrice.Size = new System.Drawing.Size(100, 21);
            this.tbStartPrice.TabIndex = 284;
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label1.Location = new System.Drawing.Point(12, 56);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(84, 22);
            this.label1.TabIndex = 288;
            this.label1.Text = "종료 금액";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label3
            // 
            this.label3.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label3.Location = new System.Drawing.Point(12, 20);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(84, 22);
            this.label3.TabIndex = 287;
            this.label3.Text = "시작 금액";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // Form_3072c
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(229, 131);
            this.Controls.Add(this.bConfirm);
            this.Controls.Add(this.tbEndPrice);
            this.Controls.Add(this.tbStartPrice);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label3);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form_3072c";
            this.Text = "구간 수정";
            this.Load += new System.EventHandler(this.Form_3092c_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button bConfirm;
        private System.Windows.Forms.TextBox tbEndPrice;
        private System.Windows.Forms.TextBox tbStartPrice;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
    }
}