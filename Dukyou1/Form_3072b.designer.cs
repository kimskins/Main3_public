namespace Dukyou3
{
    partial class Form_3072b
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form_3072b));
            this.bConfirm = new System.Windows.Forms.Button();
            this.tbPrice_unit = new System.Windows.Forms.TextBox();
            this.tbEndPrice = new System.Windows.Forms.TextBox();
            this.tbStartPrice = new System.Windows.Forms.TextBox();
            this.chkPriceUnit = new System.Windows.Forms.CheckBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // bConfirm
            // 
            this.bConfirm.Location = new System.Drawing.Point(140, 150);
            this.bConfirm.Name = "bConfirm";
            this.bConfirm.Size = new System.Drawing.Size(75, 23);
            this.bConfirm.TabIndex = 284;
            this.bConfirm.Text = "추가";
            this.bConfirm.UseVisualStyleBackColor = true;
            this.bConfirm.Click += new System.EventHandler(this.bConfirm_Click);
            // 
            // tbPrice_unit
            // 
            this.tbPrice_unit.Location = new System.Drawing.Point(115, 100);
            this.tbPrice_unit.Name = "tbPrice_unit";
            this.tbPrice_unit.Size = new System.Drawing.Size(100, 21);
            this.tbPrice_unit.TabIndex = 283;
            // 
            // tbEndPrice
            // 
            this.tbEndPrice.Location = new System.Drawing.Point(115, 65);
            this.tbEndPrice.Name = "tbEndPrice";
            this.tbEndPrice.Size = new System.Drawing.Size(100, 21);
            this.tbEndPrice.TabIndex = 281;
            // 
            // tbStartPrice
            // 
            this.tbStartPrice.Location = new System.Drawing.Point(115, 30);
            this.tbStartPrice.Name = "tbStartPrice";
            this.tbStartPrice.Size = new System.Drawing.Size(100, 21);
            this.tbStartPrice.TabIndex = 280;
            // 
            // chkPriceUnit
            // 
            this.chkPriceUnit.AutoSize = true;
            this.chkPriceUnit.Location = new System.Drawing.Point(12, 104);
            this.chkPriceUnit.Name = "chkPriceUnit";
            this.chkPriceUnit.Size = new System.Drawing.Size(15, 14);
            this.chkPriceUnit.TabIndex = 282;
            this.chkPriceUnit.UseVisualStyleBackColor = true;
            this.chkPriceUnit.CheckedChanged += new System.EventHandler(this.chkPriceUnit_CheckedChanged);
            // 
            // label2
            // 
            this.label2.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label2.Location = new System.Drawing.Point(33, 100);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(63, 22);
            this.label2.TabIndex = 285;
            this.label2.Text = "금액 단위";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label1.Location = new System.Drawing.Point(12, 65);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(84, 22);
            this.label1.TabIndex = 286;
            this.label1.Text = "종료 금액";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label3
            // 
            this.label3.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label3.Location = new System.Drawing.Point(12, 29);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(84, 22);
            this.label3.TabIndex = 287;
            this.label3.Text = "시작 금액";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // Form_3072b
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(232, 190);
            this.Controls.Add(this.bConfirm);
            this.Controls.Add(this.tbPrice_unit);
            this.Controls.Add(this.tbEndPrice);
            this.Controls.Add(this.tbStartPrice);
            this.Controls.Add(this.chkPriceUnit);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label3);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form_3072b";
            this.Text = "추가";
            this.Load += new System.EventHandler(this.Form_3092b_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button bConfirm;
        private System.Windows.Forms.TextBox tbPrice_unit;
        private System.Windows.Forms.TextBox tbEndPrice;
        private System.Windows.Forms.TextBox tbStartPrice;
        private System.Windows.Forms.CheckBox chkPriceUnit;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
    }
}