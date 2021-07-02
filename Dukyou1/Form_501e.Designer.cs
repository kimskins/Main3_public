
namespace Dukyou3
{
    partial class Form_501e
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form_501e));
            this.grid1 = new SourceGrid.Grid();
            this.button1 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // grid1
            // 
            this.grid1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.grid1.EnableSort = true;
            this.grid1.Location = new System.Drawing.Point(12, 50);
            this.grid1.Name = "grid1";
            this.grid1.OptimizeMode = SourceGrid.CellOptimizeMode.ForRows;
            this.grid1.SelectionMode = SourceGrid.GridSelectionMode.Cell;
            this.grid1.Size = new System.Drawing.Size(180, 217);
            this.grid1.TabIndex = 11;
            this.grid1.TabStop = true;
            this.grid1.ToolTipText = "";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(117, 21);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 12;
            this.button1.Text = "확인";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // Form_501e
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(204, 279);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.grid1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form_501e";
            this.Text = "선택";
            this.Load += new System.EventHandler(this.Form_501e_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private SourceGrid.Grid grid1;
        private System.Windows.Forms.Button button1;
    }
}