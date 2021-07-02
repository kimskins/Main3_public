namespace Dukyou3
{
    partial class Form_404a
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form_404a));
            this.bComplete = new System.Windows.Forms.Button();
            this.grid1 = new SourceGrid.Grid();
            this.tbName = new System.Windows.Forms.TextBox();
            this.bSearch = new System.Windows.Forms.Button();
            this.bNotcompany = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // bComplete
            // 
            this.bComplete.Location = new System.Drawing.Point(351, 231);
            this.bComplete.Name = "bComplete";
            this.bComplete.Size = new System.Drawing.Size(75, 23);
            this.bComplete.TabIndex = 1;
            this.bComplete.Text = "확인";
            this.bComplete.UseVisualStyleBackColor = true;
            this.bComplete.Click += new System.EventHandler(this.bComplete_Click);
            // 
            // grid1
            // 
            this.grid1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.grid1.EnableSort = true;
            this.grid1.Location = new System.Drawing.Point(12, 45);
            this.grid1.Name = "grid1";
            this.grid1.OptimizeMode = SourceGrid.CellOptimizeMode.ForRows;
            this.grid1.SelectionMode = SourceGrid.GridSelectionMode.Cell;
            this.grid1.Size = new System.Drawing.Size(414, 180);
            this.grid1.TabIndex = 396;
            this.grid1.TabStop = true;
            this.grid1.ToolTipText = "";
            this.grid1.MouseClick += new System.Windows.Forms.MouseEventHandler(this.grid1_MouseClick);
            // 
            // tbName
            // 
            this.tbName.Location = new System.Drawing.Point(12, 12);
            this.tbName.Name = "tbName";
            this.tbName.Size = new System.Drawing.Size(105, 21);
            this.tbName.TabIndex = 397;
            this.tbName.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tbName_KeyDown);
            // 
            // bSearch
            // 
            this.bSearch.Location = new System.Drawing.Point(123, 10);
            this.bSearch.Name = "bSearch";
            this.bSearch.Size = new System.Drawing.Size(75, 23);
            this.bSearch.TabIndex = 398;
            this.bSearch.Text = "검색";
            this.bSearch.UseVisualStyleBackColor = true;
            this.bSearch.Click += new System.EventHandler(this.bSearch_Click);
            // 
            // bNotcompany
            // 
            this.bNotcompany.Location = new System.Drawing.Point(204, 10);
            this.bNotcompany.Name = "bNotcompany";
            this.bNotcompany.Size = new System.Drawing.Size(75, 23);
            this.bNotcompany.TabIndex = 399;
            this.bNotcompany.Text = "미등록업체";
            this.bNotcompany.UseVisualStyleBackColor = true;
            this.bNotcompany.Click += new System.EventHandler(this.bNotcompany_Click);
            // 
            // Form_404a
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(438, 264);
            this.Controls.Add(this.bNotcompany);
            this.Controls.Add(this.bSearch);
            this.Controls.Add(this.tbName);
            this.Controls.Add(this.grid1);
            this.Controls.Add(this.bComplete);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form_404a";
            this.Text = "업체선택";
            this.Load += new System.EventHandler(this.Form_404a_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button bComplete;
        private SourceGrid.Grid grid1;
        private System.Windows.Forms.TextBox tbName;
        private System.Windows.Forms.Button bSearch;
        private System.Windows.Forms.Button bNotcompany;

    }
}