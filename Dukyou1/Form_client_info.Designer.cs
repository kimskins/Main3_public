namespace Dukyou3
{
    partial class Form_client_info
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form_client_info));
            this.bMail = new System.Windows.Forms.Button();
            this.bSms = new System.Windows.Forms.Button();
            this.grid1 = new SourceGrid.Grid();
            this.panel1 = new System.Windows.Forms.Panel();
            this.tbSangho = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label20 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.tbFax = new System.Windows.Forms.TextBox();
            this.tbTel = new System.Windows.Forms.TextBox();
            this.tbHp = new System.Windows.Forms.TextBox();
            this.tbInday = new System.Windows.Forms.TextBox();
            this.tbJong = new System.Windows.Forms.TextBox();
            this.tbCaddrother = new System.Windows.Forms.TextBox();
            this.tbCaddr = new System.Windows.Forms.TextBox();
            this.tbMast = new System.Windows.Forms.TextBox();
            this.tbNum = new System.Windows.Forms.TextBox();
            this.tbYubtae = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label19 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.tbEmail = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.bHpage = new System.Windows.Forms.Button();
            this.tbHpage = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // bMail
            // 
            this.bMail.Location = new System.Drawing.Point(184, 202);
            this.bMail.Name = "bMail";
            this.bMail.Size = new System.Drawing.Size(75, 23);
            this.bMail.TabIndex = 225;
            this.bMail.Text = "메일전송";
            this.bMail.UseVisualStyleBackColor = true;
            this.bMail.Click += new System.EventHandler(this.bMail_Click);
            // 
            // bSms
            // 
            this.bSms.Location = new System.Drawing.Point(103, 202);
            this.bSms.Name = "bSms";
            this.bSms.Size = new System.Drawing.Size(75, 23);
            this.bSms.TabIndex = 226;
            this.bSms.Text = "문자전송";
            this.bSms.UseVisualStyleBackColor = true;
            this.bSms.Click += new System.EventHandler(this.bSms_Click);
            // 
            // grid1
            // 
            this.grid1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.grid1.EnableSort = true;
            this.grid1.Location = new System.Drawing.Point(7, 228);
            this.grid1.Name = "grid1";
            this.grid1.OptimizeMode = SourceGrid.CellOptimizeMode.ForRows;
            this.grid1.SelectionMode = SourceGrid.GridSelectionMode.Cell;
            this.grid1.Size = new System.Drawing.Size(794, 308);
            this.grid1.TabIndex = 224;
            this.grid1.TabStop = true;
            this.grid1.ToolTipText = "";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.WhiteSmoke;
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.tbSangho);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.label20);
            this.panel1.Controls.Add(this.label14);
            this.panel1.Controls.Add(this.label8);
            this.panel1.Controls.Add(this.label10);
            this.panel1.Controls.Add(this.tbFax);
            this.panel1.Controls.Add(this.tbTel);
            this.panel1.Controls.Add(this.tbHp);
            this.panel1.Controls.Add(this.tbInday);
            this.panel1.Controls.Add(this.tbJong);
            this.panel1.Controls.Add(this.tbCaddrother);
            this.panel1.Controls.Add(this.tbCaddr);
            this.panel1.Controls.Add(this.tbMast);
            this.panel1.Controls.Add(this.tbNum);
            this.panel1.Controls.Add(this.tbYubtae);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.label19);
            this.panel1.Controls.Add(this.label9);
            this.panel1.Controls.Add(this.label11);
            this.panel1.Location = new System.Drawing.Point(7, 42);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(794, 150);
            this.panel1.TabIndex = 223;
            // 
            // tbSangho
            // 
            this.tbSangho.BackColor = System.Drawing.Color.White;
            this.tbSangho.ForeColor = System.Drawing.SystemColors.WindowText;
            this.tbSangho.Location = new System.Drawing.Point(82, 12);
            this.tbSangho.Name = "tbSangho";
            this.tbSangho.ReadOnly = true;
            this.tbSangho.Size = new System.Drawing.Size(149, 21);
            this.tbSangho.TabIndex = 158;
            // 
            // label5
            // 
            this.label5.BackColor = System.Drawing.Color.WhiteSmoke;
            this.label5.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label5.Location = new System.Drawing.Point(9, 12);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(71, 21);
            this.label5.TabIndex = 157;
            this.label5.Text = "상   호";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label20
            // 
            this.label20.BackColor = System.Drawing.Color.WhiteSmoke;
            this.label20.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label20.Location = new System.Drawing.Point(9, 120);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(71, 21);
            this.label20.TabIndex = 184;
            this.label20.Text = "대        표";
            this.label20.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label14
            // 
            this.label14.BackColor = System.Drawing.Color.WhiteSmoke;
            this.label14.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label14.Location = new System.Drawing.Point(9, 93);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(71, 21);
            this.label14.TabIndex = 184;
            this.label14.Text = "사업장주소";
            this.label14.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label8
            // 
            this.label8.BackColor = System.Drawing.Color.WhiteSmoke;
            this.label8.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label8.Location = new System.Drawing.Point(9, 66);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(71, 21);
            this.label8.TabIndex = 184;
            this.label8.Text = "등 록 번 호";
            this.label8.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label10
            // 
            this.label10.BackColor = System.Drawing.Color.WhiteSmoke;
            this.label10.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label10.Location = new System.Drawing.Point(9, 39);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(71, 21);
            this.label10.TabIndex = 184;
            this.label10.Text = "업   태";
            this.label10.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // tbFax
            // 
            this.tbFax.BackColor = System.Drawing.Color.White;
            this.tbFax.ForeColor = System.Drawing.SystemColors.WindowText;
            this.tbFax.Location = new System.Drawing.Point(672, 120);
            this.tbFax.Name = "tbFax";
            this.tbFax.ReadOnly = true;
            this.tbFax.Size = new System.Drawing.Size(117, 21);
            this.tbFax.TabIndex = 183;
            // 
            // tbTel
            // 
            this.tbTel.BackColor = System.Drawing.Color.White;
            this.tbTel.ForeColor = System.Drawing.SystemColors.WindowText;
            this.tbTel.Location = new System.Drawing.Point(487, 120);
            this.tbTel.Name = "tbTel";
            this.tbTel.ReadOnly = true;
            this.tbTel.Size = new System.Drawing.Size(117, 21);
            this.tbTel.TabIndex = 183;
            // 
            // tbHp
            // 
            this.tbHp.BackColor = System.Drawing.Color.White;
            this.tbHp.ForeColor = System.Drawing.SystemColors.WindowText;
            this.tbHp.Location = new System.Drawing.Point(282, 120);
            this.tbHp.Name = "tbHp";
            this.tbHp.ReadOnly = true;
            this.tbHp.Size = new System.Drawing.Size(137, 21);
            this.tbHp.TabIndex = 183;
            // 
            // tbInday
            // 
            this.tbInday.BackColor = System.Drawing.Color.White;
            this.tbInday.ForeColor = System.Drawing.SystemColors.WindowText;
            this.tbInday.Location = new System.Drawing.Point(309, 66);
            this.tbInday.Name = "tbInday";
            this.tbInday.ReadOnly = true;
            this.tbInday.Size = new System.Drawing.Size(118, 21);
            this.tbInday.TabIndex = 183;
            // 
            // tbJong
            // 
            this.tbJong.BackColor = System.Drawing.Color.White;
            this.tbJong.ForeColor = System.Drawing.SystemColors.WindowText;
            this.tbJong.Location = new System.Drawing.Point(309, 39);
            this.tbJong.Name = "tbJong";
            this.tbJong.ReadOnly = true;
            this.tbJong.Size = new System.Drawing.Size(263, 21);
            this.tbJong.TabIndex = 183;
            // 
            // tbCaddrother
            // 
            this.tbCaddrother.BackColor = System.Drawing.Color.White;
            this.tbCaddrother.ForeColor = System.Drawing.SystemColors.WindowText;
            this.tbCaddrother.Location = new System.Drawing.Point(472, 93);
            this.tbCaddrother.Name = "tbCaddrother";
            this.tbCaddrother.ReadOnly = true;
            this.tbCaddrother.Size = new System.Drawing.Size(317, 21);
            this.tbCaddrother.TabIndex = 183;
            // 
            // tbCaddr
            // 
            this.tbCaddr.BackColor = System.Drawing.Color.White;
            this.tbCaddr.ForeColor = System.Drawing.SystemColors.WindowText;
            this.tbCaddr.Location = new System.Drawing.Point(82, 93);
            this.tbCaddr.Name = "tbCaddr";
            this.tbCaddr.ReadOnly = true;
            this.tbCaddr.Size = new System.Drawing.Size(384, 21);
            this.tbCaddr.TabIndex = 183;
            // 
            // tbMast
            // 
            this.tbMast.BackColor = System.Drawing.Color.White;
            this.tbMast.ForeColor = System.Drawing.SystemColors.WindowText;
            this.tbMast.Location = new System.Drawing.Point(82, 120);
            this.tbMast.Name = "tbMast";
            this.tbMast.ReadOnly = true;
            this.tbMast.Size = new System.Drawing.Size(149, 21);
            this.tbMast.TabIndex = 183;
            // 
            // tbNum
            // 
            this.tbNum.BackColor = System.Drawing.Color.White;
            this.tbNum.ForeColor = System.Drawing.SystemColors.WindowText;
            this.tbNum.Location = new System.Drawing.Point(82, 66);
            this.tbNum.Name = "tbNum";
            this.tbNum.ReadOnly = true;
            this.tbNum.Size = new System.Drawing.Size(149, 21);
            this.tbNum.TabIndex = 183;
            // 
            // tbYubtae
            // 
            this.tbYubtae.BackColor = System.Drawing.Color.White;
            this.tbYubtae.ForeColor = System.Drawing.SystemColors.WindowText;
            this.tbYubtae.Location = new System.Drawing.Point(82, 39);
            this.tbYubtae.Name = "tbYubtae";
            this.tbYubtae.ReadOnly = true;
            this.tbYubtae.Size = new System.Drawing.Size(149, 21);
            this.tbYubtae.TabIndex = 183;
            // 
            // label2
            // 
            this.label2.BackColor = System.Drawing.Color.WhiteSmoke;
            this.label2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label2.Location = new System.Drawing.Point(612, 120);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(56, 20);
            this.label2.TabIndex = 186;
            this.label2.Text = "FAX";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.Color.WhiteSmoke;
            this.label1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label1.Location = new System.Drawing.Point(425, 120);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(56, 20);
            this.label1.TabIndex = 186;
            this.label1.Text = "TEL";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label19
            // 
            this.label19.BackColor = System.Drawing.Color.WhiteSmoke;
            this.label19.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label19.Location = new System.Drawing.Point(235, 121);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(44, 20);
            this.label19.TabIndex = 186;
            this.label19.Text = "HP";
            this.label19.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label9
            // 
            this.label9.BackColor = System.Drawing.Color.WhiteSmoke;
            this.label9.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label9.Location = new System.Drawing.Point(237, 67);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(71, 20);
            this.label9.TabIndex = 186;
            this.label9.Text = "설 립 일";
            this.label9.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label11
            // 
            this.label11.BackColor = System.Drawing.Color.WhiteSmoke;
            this.label11.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label11.Location = new System.Drawing.Point(237, 40);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(71, 20);
            this.label11.TabIndex = 186;
            this.label11.Text = "종   목";
            this.label11.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // tbEmail
            // 
            this.tbEmail.BackColor = System.Drawing.Color.White;
            this.tbEmail.ForeColor = System.Drawing.SystemColors.WindowText;
            this.tbEmail.Location = new System.Drawing.Point(486, 14);
            this.tbEmail.Name = "tbEmail";
            this.tbEmail.ReadOnly = true;
            this.tbEmail.Size = new System.Drawing.Size(149, 21);
            this.tbEmail.TabIndex = 222;
            // 
            // label4
            // 
            this.label4.BackColor = System.Drawing.Color.WhiteSmoke;
            this.label4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label4.Location = new System.Drawing.Point(413, 13);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(71, 22);
            this.label4.TabIndex = 221;
            this.label4.Text = "E-mail";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // bHpage
            // 
            this.bHpage.ForeColor = System.Drawing.SystemColors.ControlText;
            this.bHpage.Location = new System.Drawing.Point(103, 12);
            this.bHpage.Name = "bHpage";
            this.bHpage.Size = new System.Drawing.Size(79, 23);
            this.bHpage.TabIndex = 220;
            this.bHpage.Text = "홈페이지";
            this.bHpage.UseVisualStyleBackColor = true;
            // 
            // tbHpage
            // 
            this.tbHpage.BackColor = System.Drawing.Color.White;
            this.tbHpage.Font = new System.Drawing.Font("Gulim", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.tbHpage.ForeColor = System.Drawing.SystemColors.WindowText;
            this.tbHpage.Location = new System.Drawing.Point(184, 13);
            this.tbHpage.Name = "tbHpage";
            this.tbHpage.ReadOnly = true;
            this.tbHpage.Size = new System.Drawing.Size(223, 22);
            this.tbHpage.TabIndex = 219;
            // 
            // label3
            // 
            this.label3.BackColor = System.Drawing.Color.Azure;
            this.label3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label3.Font = new System.Drawing.Font("Gulim", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label3.Location = new System.Drawing.Point(7, 195);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(90, 30);
            this.label3.TabIndex = 217;
            this.label3.Text = "직원";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label15
            // 
            this.label15.BackColor = System.Drawing.Color.Azure;
            this.label15.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label15.Font = new System.Drawing.Font("Gulim", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label15.Location = new System.Drawing.Point(7, 9);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(90, 30);
            this.label15.TabIndex = 218;
            this.label15.Text = "사업자 정보";
            this.label15.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // Form_client_info
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(828, 548);
            this.Controls.Add(this.bMail);
            this.Controls.Add(this.bSms);
            this.Controls.Add(this.grid1);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.tbEmail);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.bHpage);
            this.Controls.Add(this.tbHpage);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label15);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form_client_info";
            this.Text = "고객 세부 자료";
            this.Load += new System.EventHandler(this.Form_client_info_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button bMail;
        private System.Windows.Forms.Button bSms;
        private SourceGrid.Grid grid1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TextBox tbSangho;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox tbFax;
        private System.Windows.Forms.TextBox tbTel;
        private System.Windows.Forms.TextBox tbHp;
        private System.Windows.Forms.TextBox tbInday;
        private System.Windows.Forms.TextBox tbJong;
        private System.Windows.Forms.TextBox tbCaddrother;
        private System.Windows.Forms.TextBox tbCaddr;
        private System.Windows.Forms.TextBox tbMast;
        private System.Windows.Forms.TextBox tbNum;
        private System.Windows.Forms.TextBox tbYubtae;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox tbEmail;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button bHpage;
        private System.Windows.Forms.TextBox tbHpage;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label15;
    }
}