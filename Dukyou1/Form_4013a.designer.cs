namespace Dukyou3
{
    partial class Form_4013a
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form_4013a));
            this.bSearch = new System.Windows.Forms.Button();
            this.tbName = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.grid1 = new SourceGrid.Grid();
            this.SuspendLayout();
            // 
            // bSearch
            // 
            this.bSearch.Location = new System.Drawing.Point(263, 12);
            this.bSearch.Name = "bSearch";
            this.bSearch.Size = new System.Drawing.Size(75, 23);
            this.bSearch.TabIndex = 1;
            this.bSearch.Text = "찾  기";
            this.bSearch.UseVisualStyleBackColor = true;
            this.bSearch.Click += new System.EventHandler(this.bSearch_Click);
            // 
            // tbName
            // 
            this.tbName.Location = new System.Drawing.Point(103, 12);
            this.tbName.Name = "tbName";
            this.tbName.Size = new System.Drawing.Size(154, 21);
            this.tbName.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(59, 18);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(41, 12);
            this.label1.TabIndex = 2;
            this.label1.Text = "업체명";
            // 
            // grid1
            // 
            this.grid1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.grid1.EnableSort = true;
            this.grid1.Location = new System.Drawing.Point(12, 51);
            this.grid1.Name = "grid1";
            this.grid1.OptimizeMode = SourceGrid.CellOptimizeMode.ForRows;
            this.grid1.SelectionMode = SourceGrid.GridSelectionMode.Cell;
            this.grid1.Size = new System.Drawing.Size(541, 306);
            this.grid1.TabIndex = 2;
            this.grid1.TabStop = true;
            this.grid1.ToolTipText = "";
            this.grid1.DoubleClick += new System.EventHandler(this.grid1_DoubleClick);
            // 
            // Form_4013a
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(568, 364);
            this.Controls.Add(this.grid1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.tbName);
            this.Controls.Add(this.bSearch);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form_4013a";
            this.Text = "업체 선택";
            this.Load += new System.EventHandler(this.Form_4013a_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button bSearch;
        private System.Windows.Forms.TextBox tbName;
        private System.Windows.Forms.Label label1;
        private SourceGrid.Grid grid1;
    }
}