namespace Dukyou3
{
    partial class Form_size_view
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
            this.grid1 = new SourceGrid.Grid();
            this.button1 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.grid2 = new SourceGrid.Grid();
            this.SuspendLayout();
            // 
            // grid1
            // 
            this.grid1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.grid1.EnableSort = true;
            this.grid1.Location = new System.Drawing.Point(8, 52);
            this.grid1.Name = "grid1";
            this.grid1.OptimizeMode = SourceGrid.CellOptimizeMode.ForRows;
            this.grid1.SelectionMode = SourceGrid.GridSelectionMode.Cell;
            this.grid1.Size = new System.Drawing.Size(240, 297);
            this.grid1.TabIndex = 0;
            this.grid1.TabStop = true;
            this.grid1.ToolTipText = "";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(429, 24);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(60, 25);
            this.button1.TabIndex = 5;
            this.button1.Text = "선 택";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.Color.Azure;
            this.label1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label1.Location = new System.Drawing.Point(9, 23);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(97, 26);
            this.label1.TabIndex = 6;
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // grid2
            // 
            this.grid2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.grid2.EnableSort = true;
            this.grid2.Location = new System.Drawing.Point(249, 52);
            this.grid2.Name = "grid2";
            this.grid2.OptimizeMode = SourceGrid.CellOptimizeMode.ForRows;
            this.grid2.SelectionMode = SourceGrid.GridSelectionMode.Cell;
            this.grid2.Size = new System.Drawing.Size(240, 297);
            this.grid2.TabIndex = 4;
            this.grid2.TabStop = true;
            this.grid2.ToolTipText = "";
            // 
            // Form_size_view
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(497, 359);
            this.Controls.Add(this.grid2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.grid1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "Form_size_view";
            this.Text = "■ 싸이즈 선택";
            this.Load += new System.EventHandler(this.Form_size_view_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private SourceGrid.Grid grid1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label1;
        private SourceGrid.Grid grid2;
    }
}