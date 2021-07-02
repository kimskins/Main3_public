namespace Dukyou3
{
    partial class Form_404
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form_404));
            this.bPictureDel = new System.Windows.Forms.Button();
            this.grid1 = new SourceGrid.Grid();
            this.bAdd = new System.Windows.Forms.Button();
            this.bDel = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // bPictureDel
            // 
            this.bPictureDel.Location = new System.Drawing.Point(56, 12);
            this.bPictureDel.Name = "bPictureDel";
            this.bPictureDel.Size = new System.Drawing.Size(77, 23);
            this.bPictureDel.TabIndex = 398;
            this.bPictureDel.Text = "사진삭제";
            this.bPictureDel.UseVisualStyleBackColor = true;
            this.bPictureDel.Click += new System.EventHandler(this.bPictureDel_Click);
            // 
            // grid1
            // 
            this.grid1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.grid1.EnableSort = true;
            this.grid1.Location = new System.Drawing.Point(9, 41);
            this.grid1.Name = "grid1";
            this.grid1.OptimizeMode = SourceGrid.CellOptimizeMode.ForRows;
            this.grid1.SelectionMode = SourceGrid.GridSelectionMode.Cell;
            this.grid1.Size = new System.Drawing.Size(649, 350);
            this.grid1.TabIndex = 395;
            this.grid1.TabStop = true;
            this.grid1.ToolTipText = "";
            this.grid1.Click += new System.EventHandler(this.grid1_Click);
            // 
            // bAdd
            // 
            this.bAdd.Location = new System.Drawing.Point(9, 12);
            this.bAdd.Name = "bAdd";
            this.bAdd.Size = new System.Drawing.Size(41, 23);
            this.bAdd.TabIndex = 396;
            this.bAdd.Text = "추가";
            this.bAdd.UseVisualStyleBackColor = true;
            this.bAdd.Click += new System.EventHandler(this.bAdd_Click);
            // 
            // bDel
            // 
            this.bDel.Location = new System.Drawing.Point(139, 12);
            this.bDel.Name = "bDel";
            this.bDel.Size = new System.Drawing.Size(41, 23);
            this.bDel.TabIndex = 396;
            this.bDel.Text = "삭제";
            this.bDel.UseVisualStyleBackColor = true;
            this.bDel.Click += new System.EventHandler(this.bDel_Click);
            // 
            // Form_404
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(670, 399);
            this.Controls.Add(this.bPictureDel);
            this.Controls.Add(this.grid1);
            this.Controls.Add(this.bDel);
            this.Controls.Add(this.bAdd);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form_404";
            this.Text = "광고설정";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button bPictureDel;
        private SourceGrid.Grid grid1;
        private System.Windows.Forms.Button bAdd;
        private System.Windows.Forms.Button bDel;
    }
}