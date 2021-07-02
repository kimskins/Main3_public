namespace Dukyou3
{
    partial class Form_210
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form_210));
            this.grid1 = new SourceGrid.Grid();
            this.cbClass = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.bSearch = new System.Windows.Forms.Button();
            this.bDelete = new System.Windows.Forms.Button();
            this.bAdd = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // grid1
            // 
            this.grid1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grid1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.grid1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.grid1.EnableSort = true;
            this.grid1.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.grid1.Location = new System.Drawing.Point(12, 49);
            this.grid1.Name = "grid1";
            this.grid1.OptimizeMode = SourceGrid.CellOptimizeMode.ForRows;
            this.grid1.SelectionMode = SourceGrid.GridSelectionMode.Cell;
            this.grid1.Size = new System.Drawing.Size(1478, 696);
            this.grid1.TabIndex = 206;
            this.grid1.TabStop = true;
            this.grid1.ToolTipText = "";
            // 
            // cbClass
            // 
            this.cbClass.FormattingEnabled = true;
            this.cbClass.Location = new System.Drawing.Point(1157, 18);
            this.cbClass.Name = "cbClass";
            this.cbClass.Size = new System.Drawing.Size(121, 20);
            this.cbClass.TabIndex = 207;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(1114, 21);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(37, 12);
            this.label1.TabIndex = 208;
            this.label1.Text = "분류 :";
            // 
            // bSearch
            // 
            this.bSearch.Location = new System.Drawing.Point(1295, 12);
            this.bSearch.Name = "bSearch";
            this.bSearch.Size = new System.Drawing.Size(90, 31);
            this.bSearch.TabIndex = 209;
            this.bSearch.Text = "검      색";
            this.bSearch.UseVisualStyleBackColor = true;
            this.bSearch.Click += new System.EventHandler(this.bSearch_Click);
            // 
            // bDelete
            // 
            this.bDelete.Location = new System.Drawing.Point(80, 18);
            this.bDelete.Name = "bDelete";
            this.bDelete.Size = new System.Drawing.Size(62, 21);
            this.bDelete.TabIndex = 210;
            this.bDelete.Text = "삭제";
            this.bDelete.UseVisualStyleBackColor = true;
            this.bDelete.Click += new System.EventHandler(this.bDelete_Click);
            // 
            // bAdd
            // 
            this.bAdd.Location = new System.Drawing.Point(12, 18);
            this.bAdd.Name = "bAdd";
            this.bAdd.Size = new System.Drawing.Size(62, 21);
            this.bAdd.TabIndex = 211;
            this.bAdd.Text = "추가";
            this.bAdd.UseVisualStyleBackColor = true;
            this.bAdd.Click += new System.EventHandler(this.bAdd_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(1400, 12);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(90, 31);
            this.button1.TabIndex = 212;
            this.button1.Text = "전체보기";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // Form_210
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1502, 757);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.bAdd);
            this.Controls.Add(this.bDelete);
            this.Controls.Add(this.bSearch);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cbClass);
            this.Controls.Add(this.grid1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form_210";
            this.Text = "코드관리";
            this.Load += new System.EventHandler(this.Form_210_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private SourceGrid.Grid grid1;
        private System.Windows.Forms.ComboBox cbClass;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button bSearch;
        private System.Windows.Forms.Button bDelete;
        private System.Windows.Forms.Button bAdd;
        private System.Windows.Forms.Button button1;
    }
}