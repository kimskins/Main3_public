namespace Dukyou3
{
    partial class Form_606
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form_606));
            this.bAdd = new System.Windows.Forms.Button();
            this.bCopy = new System.Windows.Forms.Button();
            this.bDel = new System.Windows.Forms.Button();
            this.bPanAdd = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.grid1 = new SourceGrid.Grid();
            this.bRefresh = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // bAdd
            // 
            this.bAdd.Location = new System.Drawing.Point(12, 23);
            this.bAdd.Name = "bAdd";
            this.bAdd.Size = new System.Drawing.Size(57, 23);
            this.bAdd.TabIndex = 0;
            this.bAdd.Text = "추가";
            this.bAdd.UseVisualStyleBackColor = true;
            this.bAdd.Click += new System.EventHandler(this.bAdd_Click);
            // 
            // bCopy
            // 
            this.bCopy.Location = new System.Drawing.Point(75, 23);
            this.bCopy.Name = "bCopy";
            this.bCopy.Size = new System.Drawing.Size(57, 23);
            this.bCopy.TabIndex = 0;
            this.bCopy.Text = "복사";
            this.bCopy.UseVisualStyleBackColor = true;
            this.bCopy.Click += new System.EventHandler(this.bCopy_Click);
            // 
            // bDel
            // 
            this.bDel.Location = new System.Drawing.Point(138, 23);
            this.bDel.Name = "bDel";
            this.bDel.Size = new System.Drawing.Size(57, 23);
            this.bDel.TabIndex = 0;
            this.bDel.Text = "삭제";
            this.bDel.UseVisualStyleBackColor = true;
            this.bDel.Click += new System.EventHandler(this.bDel_Click);
            // 
            // bPanAdd
            // 
            this.bPanAdd.Location = new System.Drawing.Point(219, 23);
            this.bPanAdd.Name = "bPanAdd";
            this.bPanAdd.Size = new System.Drawing.Size(78, 23);
            this.bPanAdd.TabIndex = 0;
            this.bPanAdd.Text = "판형추가";
            this.bPanAdd.UseVisualStyleBackColor = true;
            this.bPanAdd.Click += new System.EventHandler(this.bPanAdd_Click);
            // 
            // label5
            // 
            this.label5.BackColor = System.Drawing.Color.AliceBlue;
            this.label5.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label5.Font = new System.Drawing.Font("Gulim", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label5.Location = new System.Drawing.Point(205, -5);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(5, 51);
            this.label5.TabIndex = 347;
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // grid1
            // 
            this.grid1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.grid1.EnableSort = true;
            this.grid1.Location = new System.Drawing.Point(12, 68);
            this.grid1.Name = "grid1";
            this.grid1.OptimizeMode = SourceGrid.CellOptimizeMode.ForRows;
            this.grid1.SelectionMode = SourceGrid.GridSelectionMode.Cell;
            this.grid1.Size = new System.Drawing.Size(784, 357);
            this.grid1.TabIndex = 348;
            this.grid1.TabStop = true;
            this.grid1.ToolTipText = "";
            // 
            // bRefresh
            // 
            this.bRefresh.Location = new System.Drawing.Point(718, 23);
            this.bRefresh.Name = "bRefresh";
            this.bRefresh.Size = new System.Drawing.Size(78, 23);
            this.bRefresh.TabIndex = 0;
            this.bRefresh.Text = "Refresh";
            this.bRefresh.UseVisualStyleBackColor = true;
            this.bRefresh.Click += new System.EventHandler(this.bRefresh_Click);
            // 
            // Form_606
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(808, 437);
            this.Controls.Add(this.grid1);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.bRefresh);
            this.Controls.Add(this.bPanAdd);
            this.Controls.Add(this.bDel);
            this.Controls.Add(this.bCopy);
            this.Controls.Add(this.bAdd);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form_606";
            this.Text = "CTP단가등급";
            this.Load += new System.EventHandler(this.Form_606_Load);
            this.SizeChanged += new System.EventHandler(this.Form_606_SizeChanged);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button bAdd;
        private System.Windows.Forms.Button bCopy;
        private System.Windows.Forms.Button bDel;
        private System.Windows.Forms.Button bPanAdd;
        private System.Windows.Forms.Label label5;
        private SourceGrid.Grid grid1;
        private System.Windows.Forms.Button bRefresh;
    }
}