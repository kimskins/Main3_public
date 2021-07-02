namespace Dukyou3
{
    partial class Form_405
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form_405));
            this.grid1 = new SourceGrid.Grid();
            this.bSearch = new System.Windows.Forms.Button();
            this.bBadCancle = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // grid1
            // 
            this.grid1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.grid1.EnableSort = true;
            this.grid1.Location = new System.Drawing.Point(12, 96);
            this.grid1.Name = "grid1";
            this.grid1.OptimizeMode = SourceGrid.CellOptimizeMode.ForRows;
            this.grid1.SelectionMode = SourceGrid.GridSelectionMode.Cell;
            this.grid1.Size = new System.Drawing.Size(742, 273);
            this.grid1.TabIndex = 356;
            this.grid1.TabStop = true;
            this.grid1.ToolTipText = "";
            // 
            // bSearch
            // 
            this.bSearch.Location = new System.Drawing.Point(12, 22);
            this.bSearch.Name = "bSearch";
            this.bSearch.Size = new System.Drawing.Size(75, 30);
            this.bSearch.TabIndex = 360;
            this.bSearch.Text = "불량등록";
            this.bSearch.UseVisualStyleBackColor = true;
            this.bSearch.Click += new System.EventHandler(this.bSearch_Click);
            // 
            // bBadCancle
            // 
            this.bBadCancle.Location = new System.Drawing.Point(108, 22);
            this.bBadCancle.Name = "bBadCancle";
            this.bBadCancle.Size = new System.Drawing.Size(75, 30);
            this.bBadCancle.TabIndex = 360;
            this.bBadCancle.Text = "해제";
            this.bBadCancle.UseVisualStyleBackColor = true;
            this.bBadCancle.Click += new System.EventHandler(this.bBadCancle_Click);
            // 
            // Form_405
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(766, 381);
            this.Controls.Add(this.bBadCancle);
            this.Controls.Add(this.bSearch);
            this.Controls.Add(this.grid1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form_405";
            this.Text = "불량유져 등록";
            this.Load += new System.EventHandler(this.Form_405_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private SourceGrid.Grid grid1;
        private System.Windows.Forms.Button bSearch;
        private System.Windows.Forms.Button bBadCancle;
    }
}