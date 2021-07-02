namespace Dukyou3
{
    partial class Form_606a
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form_606a));
            this.bUp = new System.Windows.Forms.Button();
            this.bDown = new System.Windows.Forms.Button();
            this.bDel = new System.Windows.Forms.Button();
            this.bAdd = new System.Windows.Forms.Button();
            this.grid1 = new SourceGrid.Grid();
            this.SuspendLayout();
            // 
            // bUp
            // 
            this.bUp.Location = new System.Drawing.Point(16, 43);
            this.bUp.Name = "bUp";
            this.bUp.Size = new System.Drawing.Size(31, 164);
            this.bUp.TabIndex = 318;
            this.bUp.Text = "▲";
            this.bUp.UseVisualStyleBackColor = true;
            this.bUp.Click += new System.EventHandler(this.bUp_Click);
            // 
            // bDown
            // 
            this.bDown.Location = new System.Drawing.Point(16, 208);
            this.bDown.Name = "bDown";
            this.bDown.Size = new System.Drawing.Size(31, 164);
            this.bDown.TabIndex = 319;
            this.bDown.Text = "▼";
            this.bDown.UseVisualStyleBackColor = true;
            this.bDown.Click += new System.EventHandler(this.bDown_Click);
            // 
            // bDel
            // 
            this.bDel.Location = new System.Drawing.Point(80, 14);
            this.bDel.Name = "bDel";
            this.bDel.Size = new System.Drawing.Size(59, 23);
            this.bDel.TabIndex = 316;
            this.bDel.Text = "삭제";
            this.bDel.UseVisualStyleBackColor = true;
            this.bDel.Click += new System.EventHandler(this.bDel_Click);
            // 
            // bAdd
            // 
            this.bAdd.Location = new System.Drawing.Point(15, 14);
            this.bAdd.Name = "bAdd";
            this.bAdd.Size = new System.Drawing.Size(59, 23);
            this.bAdd.TabIndex = 317;
            this.bAdd.Text = "추가";
            this.bAdd.UseVisualStyleBackColor = true;
            this.bAdd.Click += new System.EventHandler(this.bAdd_Click);
            // 
            // grid1
            // 
            this.grid1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.grid1.EnableSort = true;
            this.grid1.Location = new System.Drawing.Point(53, 43);
            this.grid1.Name = "grid1";
            this.grid1.OptimizeMode = SourceGrid.CellOptimizeMode.ForRows;
            this.grid1.SelectionMode = SourceGrid.GridSelectionMode.Cell;
            this.grid1.Size = new System.Drawing.Size(272, 329);
            this.grid1.TabIndex = 315;
            this.grid1.TabStop = true;
            this.grid1.ToolTipText = "";
            // 
            // Form_606a
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(341, 386);
            this.Controls.Add(this.bUp);
            this.Controls.Add(this.bDown);
            this.Controls.Add(this.bDel);
            this.Controls.Add(this.bAdd);
            this.Controls.Add(this.grid1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form_606a";
            this.Text = "판형관리";
            this.Load += new System.EventHandler(this.Form_606a_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button bUp;
        private System.Windows.Forms.Button bDown;
        private System.Windows.Forms.Button bDel;
        private System.Windows.Forms.Button bAdd;
        private SourceGrid.Grid grid1;
    }
}