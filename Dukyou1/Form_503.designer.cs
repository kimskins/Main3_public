namespace Dukyou3
{
    partial class Form_503
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form_503));
            this.grid1 = new SourceGrid.Grid();
            this.bAdd = new System.Windows.Forms.Button();
            this.bClear = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // grid1
            // 
            this.grid1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.grid1.CustomSort = true;
            this.grid1.EnableSort = true;
            this.grid1.Font = new System.Drawing.Font("Gulim", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.grid1.Location = new System.Drawing.Point(4, 36);
            this.grid1.Name = "grid1";
            this.grid1.OptimizeMode = SourceGrid.CellOptimizeMode.ForRows;
            this.grid1.SelectionMode = SourceGrid.GridSelectionMode.Cell;
            this.grid1.Size = new System.Drawing.Size(303, 235);
            this.grid1.TabIndex = 1;
            this.grid1.TabStop = true;
            this.grid1.ToolTipText = "";
            // 
            // bAdd
            // 
            this.bAdd.Location = new System.Drawing.Point(4, 3);
            this.bAdd.Name = "bAdd";
            this.bAdd.Size = new System.Drawing.Size(87, 27);
            this.bAdd.TabIndex = 2;
            this.bAdd.Text = "추가";
            this.bAdd.UseVisualStyleBackColor = true;
            this.bAdd.Click += new System.EventHandler(this.bAdd_Click);
            // 
            // bClear
            // 
            this.bClear.Location = new System.Drawing.Point(97, 3);
            this.bClear.Name = "bClear";
            this.bClear.Size = new System.Drawing.Size(87, 27);
            this.bClear.TabIndex = 2;
            this.bClear.Text = "새로고침";
            this.bClear.UseVisualStyleBackColor = true;
            this.bClear.Click += new System.EventHandler(this.bClear_Click);
            // 
            // Form_503
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(311, 273);
            this.Controls.Add(this.bClear);
            this.Controls.Add(this.bAdd);
            this.Controls.Add(this.grid1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form_503";
            this.Text = "■ 업체 코드관리";
            this.Load += new System.EventHandler(this.Form_502_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private SourceGrid.Grid grid1;
        private System.Windows.Forms.Button bAdd;
        private System.Windows.Forms.Button bClear;

    }
}