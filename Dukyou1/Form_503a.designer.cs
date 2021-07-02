namespace Dukyou3
{
    partial class Form_503a
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form_503a));
            this.grid1 = new SourceGrid.Grid();
            this.bAdd = new System.Windows.Forms.Button();
            this.tbSearch = new System.Windows.Forms.TextBox();
            this.bSearch = new System.Windows.Forms.Button();
            this.rbNo = new System.Windows.Forms.RadioButton();
            this.rbYes = new System.Windows.Forms.RadioButton();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.bClear = new System.Windows.Forms.Button();
            this.rbAll = new System.Windows.Forms.RadioButton();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // grid1
            // 
            this.grid1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.grid1.CustomSort = true;
            this.grid1.EnableSort = true;
            this.grid1.Font = new System.Drawing.Font("Gulim", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.grid1.Location = new System.Drawing.Point(12, 83);
            this.grid1.Name = "grid1";
            this.grid1.OptimizeMode = SourceGrid.CellOptimizeMode.ForRows;
            this.grid1.SelectionMode = SourceGrid.GridSelectionMode.Cell;
            this.grid1.Size = new System.Drawing.Size(621, 417);
            this.grid1.TabIndex = 2;
            this.grid1.TabStop = true;
            this.grid1.ToolTipText = "";
            // 
            // bAdd
            // 
            this.bAdd.Location = new System.Drawing.Point(12, 48);
            this.bAdd.Name = "bAdd";
            this.bAdd.Size = new System.Drawing.Size(111, 29);
            this.bAdd.TabIndex = 3;
            this.bAdd.Text = "등록";
            this.bAdd.UseVisualStyleBackColor = true;
            this.bAdd.Click += new System.EventHandler(this.bAdd_Click);
            // 
            // tbSearch
            // 
            this.tbSearch.Location = new System.Drawing.Point(6, 40);
            this.tbSearch.Name = "tbSearch";
            this.tbSearch.Size = new System.Drawing.Size(167, 21);
            this.tbSearch.TabIndex = 4;
            // 
            // bSearch
            // 
            this.bSearch.Location = new System.Drawing.Point(179, 39);
            this.bSearch.Name = "bSearch";
            this.bSearch.Size = new System.Drawing.Size(84, 21);
            this.bSearch.TabIndex = 5;
            this.bSearch.Text = "검색";
            this.bSearch.UseVisualStyleBackColor = true;
            this.bSearch.Click += new System.EventHandler(this.bSearch_Click);
            // 
            // rbNo
            // 
            this.rbNo.AutoSize = true;
            this.rbNo.Location = new System.Drawing.Point(112, 17);
            this.rbNo.Name = "rbNo";
            this.rbNo.Size = new System.Drawing.Size(59, 16);
            this.rbNo.TabIndex = 6;
            this.rbNo.TabStop = true;
            this.rbNo.Text = "미등록";
            this.rbNo.UseVisualStyleBackColor = true;
            // 
            // rbYes
            // 
            this.rbYes.AutoSize = true;
            this.rbYes.Location = new System.Drawing.Point(59, 17);
            this.rbYes.Name = "rbYes";
            this.rbYes.Size = new System.Drawing.Size(47, 16);
            this.rbYes.TabIndex = 7;
            this.rbYes.TabStop = true;
            this.rbYes.Text = "등록";
            this.rbYes.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.bClear);
            this.groupBox1.Controls.Add(this.tbSearch);
            this.groupBox1.Controls.Add(this.rbYes);
            this.groupBox1.Controls.Add(this.rbAll);
            this.groupBox1.Controls.Add(this.rbNo);
            this.groupBox1.Controls.Add(this.bSearch);
            this.groupBox1.Location = new System.Drawing.Point(361, 9);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(272, 68);
            this.groupBox1.TabIndex = 8;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "상호검색";
            // 
            // bClear
            // 
            this.bClear.Location = new System.Drawing.Point(179, 15);
            this.bClear.Name = "bClear";
            this.bClear.Size = new System.Drawing.Size(84, 21);
            this.bClear.TabIndex = 8;
            this.bClear.Text = "clear";
            this.bClear.UseVisualStyleBackColor = true;
            this.bClear.Click += new System.EventHandler(this.bClear_Click);
            // 
            // rbAll
            // 
            this.rbAll.AutoSize = true;
            this.rbAll.Location = new System.Drawing.Point(6, 17);
            this.rbAll.Name = "rbAll";
            this.rbAll.Size = new System.Drawing.Size(47, 16);
            this.rbAll.TabIndex = 6;
            this.rbAll.TabStop = true;
            this.rbAll.Text = "전체";
            this.rbAll.UseVisualStyleBackColor = true;
            // 
            // Form_503a
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(638, 510);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.bAdd);
            this.Controls.Add(this.grid1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form_503a";
            this.Load += new System.EventHandler(this.Form_502a_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private SourceGrid.Grid grid1;
        private System.Windows.Forms.Button bAdd;
        private System.Windows.Forms.TextBox tbSearch;
        private System.Windows.Forms.Button bSearch;
        private System.Windows.Forms.RadioButton rbNo;
        private System.Windows.Forms.RadioButton rbYes;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button bClear;
        private System.Windows.Forms.RadioButton rbAll;
    }
}