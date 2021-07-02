namespace Dukyou3
{
    partial class Form_402b
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form_402b));
            this.tbNotic = new System.Windows.Forms.TextBox();
            this.bCancel = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.chkBest = new System.Windows.Forms.CheckBox();
            this.tbTitle = new System.Windows.Forms.TextBox();
            this.bReply = new System.Windows.Forms.Button();
            this.bModify = new System.Windows.Forms.Button();
            this.bComplete = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.tbDate = new System.Windows.Forms.TextBox();
            this.tbName = new System.Windows.Forms.TextBox();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // tbNotic
            // 
            this.tbNotic.BackColor = System.Drawing.Color.White;
            this.tbNotic.ForeColor = System.Drawing.Color.Black;
            this.tbNotic.Location = new System.Drawing.Point(18, 68);
            this.tbNotic.Multiline = true;
            this.tbNotic.Name = "tbNotic";
            this.tbNotic.ReadOnly = true;
            this.tbNotic.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.tbNotic.Size = new System.Drawing.Size(532, 392);
            this.tbNotic.TabIndex = 3;
            // 
            // bCancel
            // 
            this.bCancel.Location = new System.Drawing.Point(461, 466);
            this.bCancel.Name = "bCancel";
            this.bCancel.Size = new System.Drawing.Size(89, 36);
            this.bCancel.TabIndex = 1;
            this.bCancel.Text = "닫기";
            this.bCancel.UseVisualStyleBackColor = true;
            this.bCancel.Click += new System.EventHandler(this.bCancel_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.chkBest);
            this.groupBox2.Controls.Add(this.tbTitle);
            this.groupBox2.Location = new System.Drawing.Point(12, 12);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(544, 50);
            this.groupBox2.TabIndex = 2;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "제목";
            // 
            // chkBest
            // 
            this.chkBest.AutoSize = true;
            this.chkBest.Location = new System.Drawing.Point(466, 22);
            this.chkBest.Name = "chkBest";
            this.chkBest.Size = new System.Drawing.Size(72, 16);
            this.chkBest.TabIndex = 2;
            this.chkBest.Text = "중요체크";
            this.chkBest.UseVisualStyleBackColor = true;
            // 
            // tbTitle
            // 
            this.tbTitle.BackColor = System.Drawing.Color.White;
            this.tbTitle.Location = new System.Drawing.Point(6, 20);
            this.tbTitle.Name = "tbTitle";
            this.tbTitle.ReadOnly = true;
            this.tbTitle.Size = new System.Drawing.Size(454, 21);
            this.tbTitle.TabIndex = 0;
            // 
            // bReply
            // 
            this.bReply.Location = new System.Drawing.Point(366, 466);
            this.bReply.Name = "bReply";
            this.bReply.Size = new System.Drawing.Size(89, 36);
            this.bReply.TabIndex = 0;
            this.bReply.Text = "답변";
            this.bReply.UseVisualStyleBackColor = true;
            this.bReply.Click += new System.EventHandler(this.bReply_Click);
            // 
            // bModify
            // 
            this.bModify.Location = new System.Drawing.Point(366, 466);
            this.bModify.Name = "bModify";
            this.bModify.Size = new System.Drawing.Size(89, 36);
            this.bModify.TabIndex = 4;
            this.bModify.Text = "수정";
            this.bModify.UseVisualStyleBackColor = true;
            this.bModify.Click += new System.EventHandler(this.bModify_Click);
            // 
            // bComplete
            // 
            this.bComplete.Location = new System.Drawing.Point(366, 466);
            this.bComplete.Name = "bComplete";
            this.bComplete.Size = new System.Drawing.Size(89, 36);
            this.bComplete.TabIndex = 5;
            this.bComplete.Text = "저장";
            this.bComplete.UseVisualStyleBackColor = true;
            this.bComplete.Click += new System.EventHandler(this.bComplete_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(136, 478);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 12);
            this.label2.TabIndex = 8;
            this.label2.Text = "작성시간";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(16, 478);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(41, 12);
            this.label1.TabIndex = 9;
            this.label1.Text = "작성자";
            // 
            // tbDate
            // 
            this.tbDate.BackColor = System.Drawing.Color.White;
            this.tbDate.Location = new System.Drawing.Point(194, 475);
            this.tbDate.Name = "tbDate";
            this.tbDate.ReadOnly = true;
            this.tbDate.Size = new System.Drawing.Size(93, 21);
            this.tbDate.TabIndex = 6;
            // 
            // tbName
            // 
            this.tbName.BackColor = System.Drawing.Color.White;
            this.tbName.Location = new System.Drawing.Point(61, 475);
            this.tbName.Name = "tbName";
            this.tbName.ReadOnly = true;
            this.tbName.Size = new System.Drawing.Size(68, 21);
            this.tbName.TabIndex = 7;
            // 
            // Form_402b
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(564, 505);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.tbDate);
            this.Controls.Add(this.tbName);
            this.Controls.Add(this.bComplete);
            this.Controls.Add(this.bModify);
            this.Controls.Add(this.bReply);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.bCancel);
            this.Controls.Add(this.tbNotic);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.Name = "Form_402b";
            this.ShowIcon = false;
            this.Text = "공지";
            this.Load += new System.EventHandler(this.Form_804b_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Form_402b_KeyDown);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox tbNotic;
        private System.Windows.Forms.Button bCancel;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TextBox tbTitle;
        private System.Windows.Forms.Button bReply;
        private System.Windows.Forms.Button bModify;
        private System.Windows.Forms.CheckBox chkBest;
        private System.Windows.Forms.Button bComplete;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tbDate;
        private System.Windows.Forms.TextBox tbName;
    }
}