namespace Dukyou3
{
    partial class Form_305a
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form_305a));
            this.bPictureDel = new System.Windows.Forms.Button();
            this.bPictureDown = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // bPictureDel
            // 
            this.bPictureDel.Location = new System.Drawing.Point(109, 636);
            this.bPictureDel.Name = "bPictureDel";
            this.bPictureDel.Size = new System.Drawing.Size(75, 23);
            this.bPictureDel.TabIndex = 393;
            this.bPictureDel.Text = "그림삭제";
            this.bPictureDel.UseVisualStyleBackColor = true;
            this.bPictureDel.Click += new System.EventHandler(this.bPictureDel_Click);
            // 
            // bPictureDown
            // 
            this.bPictureDown.Location = new System.Drawing.Point(12, 636);
            this.bPictureDown.Name = "bPictureDown";
            this.bPictureDown.Size = new System.Drawing.Size(75, 23);
            this.bPictureDown.TabIndex = 392;
            this.bPictureDown.Text = "내려받기";
            this.bPictureDown.UseVisualStyleBackColor = true;
            this.bPictureDown.Click += new System.EventHandler(this.bPictureDown_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureBox1.Location = new System.Drawing.Point(12, 16);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(914, 604);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 391;
            this.pictureBox1.TabStop = false;
            // 
            // Form_305a
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(938, 674);
            this.Controls.Add(this.bPictureDel);
            this.Controls.Add(this.bPictureDown);
            this.Controls.Add(this.pictureBox1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form_305a";
            this.Text = "그림보기";
            this.Load += new System.EventHandler(this.Form_505a_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button bPictureDel;
        private System.Windows.Forms.Button bPictureDown;
        private System.Windows.Forms.PictureBox pictureBox1;
    }
}