namespace Dukyou3
{
    partial class Form_2122
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form_2122));
            this.bRefresh = new System.Windows.Forms.Button();
            this.bDelete = new System.Windows.Forms.Button();
            this.bCopy = new System.Windows.Forms.Button();
            this.bAdd = new System.Windows.Forms.Button();
            this.grid1 = new SourceGrid.Grid();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // bRefresh
            // 
            this.bRefresh.Location = new System.Drawing.Point(1128, 14);
            this.bRefresh.Name = "bRefresh";
            this.bRefresh.Size = new System.Drawing.Size(83, 43);
            this.bRefresh.TabIndex = 350;
            this.bRefresh.Text = "Refresh";
            this.bRefresh.UseVisualStyleBackColor = true;
            this.bRefresh.Click += new System.EventHandler(this.bRefresh_Click);
            // 
            // bDelete
            // 
            this.bDelete.Location = new System.Drawing.Point(130, 32);
            this.bDelete.Name = "bDelete";
            this.bDelete.Size = new System.Drawing.Size(53, 23);
            this.bDelete.TabIndex = 349;
            this.bDelete.Text = "삭제";
            this.bDelete.UseVisualStyleBackColor = true;
            this.bDelete.Click += new System.EventHandler(this.bDelete_Click);
            // 
            // bCopy
            // 
            this.bCopy.Location = new System.Drawing.Point(71, 32);
            this.bCopy.Name = "bCopy";
            this.bCopy.Size = new System.Drawing.Size(53, 23);
            this.bCopy.TabIndex = 348;
            this.bCopy.Text = "복사";
            this.bCopy.UseVisualStyleBackColor = true;
            this.bCopy.Click += new System.EventHandler(this.bCopy_Click);
            // 
            // bAdd
            // 
            this.bAdd.Location = new System.Drawing.Point(12, 32);
            this.bAdd.Name = "bAdd";
            this.bAdd.Size = new System.Drawing.Size(53, 23);
            this.bAdd.TabIndex = 347;
            this.bAdd.Text = "추가";
            this.bAdd.UseVisualStyleBackColor = true;
            this.bAdd.Click += new System.EventHandler(this.bAdd_Click);
            // 
            // grid1
            // 
            this.grid1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.grid1.EnableSort = true;
            this.grid1.Location = new System.Drawing.Point(12, 61);
            this.grid1.Name = "grid1";
            this.grid1.OptimizeMode = SourceGrid.CellOptimizeMode.ForRows;
            this.grid1.SelectionMode = SourceGrid.GridSelectionMode.Cell;
            this.grid1.Size = new System.Drawing.Size(1199, 439);
            this.grid1.TabIndex = 346;
            this.grid1.TabStop = true;
            this.grid1.ToolTipText = "";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Gulim", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label1.ForeColor = System.Drawing.Color.OrangeRed;
            this.label1.Location = new System.Drawing.Point(797, 39);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(298, 13);
            this.label1.TabIndex = 351;
            this.label1.Text = "※ 디지털윤전 구분  :  디지털 = 1,  디지털윤전 = 2";
            this.label1.Visible = false;
            // 
            // Form_2122
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1228, 512);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.bRefresh);
            this.Controls.Add(this.bDelete);
            this.Controls.Add(this.bCopy);
            this.Controls.Add(this.bAdd);
            this.Controls.Add(this.grid1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form_2122";
            this.Text = "종이여분";
            this.Load += new System.EventHandler(this.Form_2112_Load);
            this.ClientSizeChanged += new System.EventHandler(this.Form_2122_ClientSizeChanged);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button bRefresh;
        private System.Windows.Forms.Button bDelete;
        private System.Windows.Forms.Button bCopy;
        private System.Windows.Forms.Button bAdd;
        private SourceGrid.Grid grid1;
        private System.Windows.Forms.Label label1;
    }
}