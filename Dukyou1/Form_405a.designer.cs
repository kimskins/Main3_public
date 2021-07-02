namespace Dukyou3
{
    partial class Form_405a
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form_405a));
            this.grid1 = new SourceGrid.Grid();
            this.tbId = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.tbCompany = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.tbMember = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.tbMac = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.bSearch = new System.Windows.Forms.Button();
            this.bRegist = new System.Windows.Forms.Button();
            this.bClear = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // grid1
            // 
            this.grid1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.grid1.EnableSort = true;
            this.grid1.Location = new System.Drawing.Point(12, 92);
            this.grid1.Name = "grid1";
            this.grid1.OptimizeMode = SourceGrid.CellOptimizeMode.ForRows;
            this.grid1.SelectionMode = SourceGrid.GridSelectionMode.Cell;
            this.grid1.Size = new System.Drawing.Size(742, 352);
            this.grid1.TabIndex = 7;
            this.grid1.TabStop = true;
            this.grid1.ToolTipText = "";
            // 
            // tbId
            // 
            this.tbId.Location = new System.Drawing.Point(56, 19);
            this.tbId.Name = "tbId";
            this.tbId.Size = new System.Drawing.Size(122, 21);
            this.tbId.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(26, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(24, 12);
            this.label1.TabIndex = 359;
            this.label1.Text = "ID :";
            // 
            // tbCompany
            // 
            this.tbCompany.Location = new System.Drawing.Point(248, 19);
            this.tbCompany.Name = "tbCompany";
            this.tbCompany.Size = new System.Drawing.Size(122, 21);
            this.tbCompany.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(193, 22);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(49, 12);
            this.label2.TabIndex = 359;
            this.label2.Text = "회사명 :";
            // 
            // tbMember
            // 
            this.tbMember.Location = new System.Drawing.Point(438, 19);
            this.tbMember.Name = "tbMember";
            this.tbMember.Size = new System.Drawing.Size(122, 21);
            this.tbMember.TabIndex = 2;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(383, 22);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(49, 12);
            this.label3.TabIndex = 359;
            this.label3.Text = "직원명 :";
            // 
            // tbMac
            // 
            this.tbMac.Location = new System.Drawing.Point(56, 58);
            this.tbMac.Name = "tbMac";
            this.tbMac.Size = new System.Drawing.Size(186, 21);
            this.tbMac.TabIndex = 3;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 61);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(38, 12);
            this.label4.TabIndex = 359;
            this.label4.Text = "Mac :";
            // 
            // bSearch
            // 
            this.bSearch.Location = new System.Drawing.Point(566, 19);
            this.bSearch.Name = "bSearch";
            this.bSearch.Size = new System.Drawing.Size(58, 36);
            this.bSearch.TabIndex = 4;
            this.bSearch.Text = "검색";
            this.bSearch.UseVisualStyleBackColor = true;
            this.bSearch.Click += new System.EventHandler(this.bSearch_Click);
            // 
            // bRegist
            // 
            this.bRegist.Location = new System.Drawing.Point(696, 19);
            this.bRegist.Name = "bRegist";
            this.bRegist.Size = new System.Drawing.Size(58, 60);
            this.bRegist.TabIndex = 6;
            this.bRegist.Text = "등록";
            this.bRegist.UseVisualStyleBackColor = true;
            this.bRegist.Click += new System.EventHandler(this.bRegist_Click);
            // 
            // bClear
            // 
            this.bClear.Location = new System.Drawing.Point(566, 61);
            this.bClear.Name = "bClear";
            this.bClear.Size = new System.Drawing.Size(58, 23);
            this.bClear.TabIndex = 5;
            this.bClear.Text = "Clear";
            this.bClear.UseVisualStyleBackColor = true;
            this.bClear.Click += new System.EventHandler(this.bClear_Click);
            // 
            // Form_405a
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(767, 456);
            this.Controls.Add(this.bClear);
            this.Controls.Add(this.bRegist);
            this.Controls.Add(this.bSearch);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.tbMac);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.tbMember);
            this.Controls.Add(this.tbCompany);
            this.Controls.Add(this.tbId);
            this.Controls.Add(this.grid1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form_405a";
            this.Text = "찾아보기";
            this.Load += new System.EventHandler(this.Form_405a_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private SourceGrid.Grid grid1;
        private System.Windows.Forms.TextBox tbId;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tbCompany;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox tbMember;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox tbMac;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button bSearch;
        private System.Windows.Forms.Button bRegist;
        private System.Windows.Forms.Button bClear;
    }
}