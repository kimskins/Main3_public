namespace Dukyou3
{
    partial class Form_sms_send
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form_sms_send));
            this.tbSmsText = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.tbSender = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.grid1 = new SourceGrid.Grid();
            this.bSend = new System.Windows.Forms.Button();
            this.bAdd = new System.Windows.Forms.Button();
            this.bMms = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.bSearch = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // tbSmsText
            // 
            this.tbSmsText.Location = new System.Drawing.Point(14, 67);
            this.tbSmsText.Multiline = true;
            this.tbSmsText.Name = "tbSmsText";
            this.tbSmsText.Size = new System.Drawing.Size(230, 152);
            this.tbSmsText.TabIndex = 1;
            this.tbSmsText.MouseClick += new System.Windows.Forms.MouseEventHandler(this.tbSmsText_MouseClick);
            this.tbSmsText.TextChanged += new System.EventHandler(this.tbSmsText_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 26);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(77, 12);
            this.label1.TabIndex = 1;
            this.label1.Text = "보내는 사람 :";
            // 
            // tbSender
            // 
            this.tbSender.Location = new System.Drawing.Point(95, 23);
            this.tbSender.Name = "tbSender";
            this.tbSender.Size = new System.Drawing.Size(147, 21);
            this.tbSender.TabIndex = 0;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(14, 233);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(65, 12);
            this.label2.TabIndex = 1;
            this.label2.Text = "받는 사람 :";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label3.Location = new System.Drawing.Point(204, 52);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(39, 12);
            this.label3.TabIndex = 3;
            this.label3.Text = "(0/90)";
            // 
            // grid1
            // 
            this.grid1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.grid1.EnableSort = true;
            this.grid1.Location = new System.Drawing.Point(16, 248);
            this.grid1.Name = "grid1";
            this.grid1.OptimizeMode = SourceGrid.CellOptimizeMode.ForRows;
            this.grid1.SelectionMode = SourceGrid.GridSelectionMode.Cell;
            this.grid1.Size = new System.Drawing.Size(227, 282);
            this.grid1.TabIndex = 3;
            this.grid1.TabStop = true;
            this.grid1.ToolTipText = "";
            // 
            // bSend
            // 
            this.bSend.Location = new System.Drawing.Point(160, 563);
            this.bSend.Name = "bSend";
            this.bSend.Size = new System.Drawing.Size(82, 29);
            this.bSend.TabIndex = 3;
            this.bSend.Text = "보내기";
            this.bSend.UseVisualStyleBackColor = true;
            this.bSend.Click += new System.EventHandler(this.bSend_Click);
            // 
            // bAdd
            // 
            this.bAdd.Location = new System.Drawing.Point(191, 225);
            this.bAdd.Name = "bAdd";
            this.bAdd.Size = new System.Drawing.Size(51, 20);
            this.bAdd.TabIndex = 2;
            this.bAdd.Text = "추가";
            this.bAdd.UseVisualStyleBackColor = true;
            this.bAdd.Click += new System.EventHandler(this.bAdd_Click);
            // 
            // bMms
            // 
            this.bMms.Location = new System.Drawing.Point(160, 563);
            this.bMms.Name = "bMms";
            this.bMms.Size = new System.Drawing.Size(82, 29);
            this.bMms.TabIndex = 5;
            this.bMms.Text = "MMS전송";
            this.bMms.UseVisualStyleBackColor = true;
            this.bMms.Visible = false;
            this.bMms.Click += new System.EventHandler(this.bMms_Click);
            // 
            // textBox1
            // 
            this.textBox1.BackColor = System.Drawing.Color.White;
            this.textBox1.Location = new System.Drawing.Point(16, 537);
            this.textBox1.Name = "textBox1";
            this.textBox1.ReadOnly = true;
            this.textBox1.Size = new System.Drawing.Size(138, 21);
            this.textBox1.TabIndex = 4;
            // 
            // bSearch
            // 
            this.bSearch.Location = new System.Drawing.Point(160, 536);
            this.bSearch.Name = "bSearch";
            this.bSearch.Size = new System.Drawing.Size(82, 21);
            this.bSearch.TabIndex = 6;
            this.bSearch.Text = "찾기";
            this.bSearch.UseVisualStyleBackColor = true;
            this.bSearch.Click += new System.EventHandler(this.bSearch_Click);
            // 
            // Form_sms_send
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(254, 604);
            this.Controls.Add(this.bSearch);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.bMms);
            this.Controls.Add(this.bAdd);
            this.Controls.Add(this.bSend);
            this.Controls.Add(this.grid1);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.tbSender);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.tbSmsText);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.Name = "Form_sms_send";
            this.Text = "문자 보내기";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Form_sms_send_FormClosed);
            this.Load += new System.EventHandler(this.Form_sms_send_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Form_sms_send_KeyDown);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox tbSmsText;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tbSender;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private SourceGrid.Grid grid1;
        private System.Windows.Forms.Button bSend;
        private System.Windows.Forms.Button bAdd;
        private System.Windows.Forms.Button bMms;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Button bSearch;
    }
}