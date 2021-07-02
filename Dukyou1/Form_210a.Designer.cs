namespace Dukyou3
{
    partial class Form_210a
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form_210a));
            this.cbClass = new System.Windows.Forms.ComboBox();
            this.tbCode = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.bConfirm = new System.Windows.Forms.Button();
            this.bCancle = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // cbClass
            // 
            this.cbClass.FormattingEnabled = true;
            this.cbClass.Location = new System.Drawing.Point(77, 30);
            this.cbClass.Name = "cbClass";
            this.cbClass.Size = new System.Drawing.Size(121, 20);
            this.cbClass.TabIndex = 0;
            // 
            // tbCode
            // 
            this.tbCode.Location = new System.Drawing.Point(77, 77);
            this.tbCode.Name = "tbCode";
            this.tbCode.Size = new System.Drawing.Size(100, 21);
            this.tbCode.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(33, 33);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(37, 12);
            this.label1.TabIndex = 2;
            this.label1.Text = "분류 :";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(33, 80);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(37, 12);
            this.label2.TabIndex = 3;
            this.label2.Text = "코드 :";
            // 
            // bConfirm
            // 
            this.bConfirm.Location = new System.Drawing.Point(274, 125);
            this.bConfirm.Name = "bConfirm";
            this.bConfirm.Size = new System.Drawing.Size(81, 48);
            this.bConfirm.TabIndex = 4;
            this.bConfirm.Text = "확인";
            this.bConfirm.UseVisualStyleBackColor = true;
            this.bConfirm.Click += new System.EventHandler(this.bConfirm_Click);
            // 
            // bCancle
            // 
            this.bCancle.Location = new System.Drawing.Point(177, 125);
            this.bCancle.Name = "bCancle";
            this.bCancle.Size = new System.Drawing.Size(81, 48);
            this.bCancle.TabIndex = 5;
            this.bCancle.Text = "취소";
            this.bCancle.UseVisualStyleBackColor = true;
            this.bCancle.Click += new System.EventHandler(this.bCancle_Click);
            // 
            // Form_210a
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(367, 192);
            this.Controls.Add(this.bCancle);
            this.Controls.Add(this.bConfirm);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.tbCode);
            this.Controls.Add(this.cbClass);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form_210a";
            this.Text = "코드추가";
            this.Load += new System.EventHandler(this.Form_201a_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox cbClass;
        private System.Windows.Forms.TextBox tbCode;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button bConfirm;
        private System.Windows.Forms.Button bCancle;
    }
}