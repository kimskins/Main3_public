namespace Dukyou3
{
    partial class Form_604b
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form_604b));
            this.grid1 = new SourceGrid.Grid();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.tbPrnCom = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.tbDosu = new System.Windows.Forms.TextBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.cbPanType = new System.Windows.Forms.ComboBox();
            this.bClear = new System.Windows.Forms.Button();
            this.bSearch = new System.Windows.Forms.Button();
            this.bSave = new System.Windows.Forms.Button();
            this.groupBox4.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // grid1
            // 
            this.grid1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.grid1.EnableSort = true;
            this.grid1.Location = new System.Drawing.Point(12, 85);
            this.grid1.Name = "grid1";
            this.grid1.OptimizeMode = SourceGrid.CellOptimizeMode.ForRows;
            this.grid1.SelectionMode = SourceGrid.GridSelectionMode.Cell;
            this.grid1.Size = new System.Drawing.Size(944, 203);
            this.grid1.TabIndex = 5;
            this.grid1.TabStop = true;
            this.grid1.ToolTipText = "";
            this.grid1.Click += new System.EventHandler(this.grid1_Click);
            // 
            // groupBox4
            // 
            this.groupBox4.BackColor = System.Drawing.SystemColors.Control;
            this.groupBox4.Controls.Add(this.tbPrnCom);
            this.groupBox4.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.groupBox4.Location = new System.Drawing.Point(400, 12);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(179, 42);
            this.groupBox4.TabIndex = 0;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "인쇄업체명";
            // 
            // tbPrnCom
            // 
            this.tbPrnCom.Location = new System.Drawing.Point(5, 17);
            this.tbPrnCom.Name = "tbPrnCom";
            this.tbPrnCom.Size = new System.Drawing.Size(168, 21);
            this.tbPrnCom.TabIndex = 0;
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.SystemColors.Control;
            this.groupBox1.Controls.Add(this.tbDosu);
            this.groupBox1.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.groupBox1.Location = new System.Drawing.Point(597, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(79, 42);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "도수";
            // 
            // tbDosu
            // 
            this.tbDosu.Location = new System.Drawing.Point(8, 17);
            this.tbDosu.Name = "tbDosu";
            this.tbDosu.Size = new System.Drawing.Size(65, 21);
            this.tbDosu.TabIndex = 0;
            // 
            // groupBox2
            // 
            this.groupBox2.BackColor = System.Drawing.SystemColors.Control;
            this.groupBox2.Controls.Add(this.cbPanType);
            this.groupBox2.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.groupBox2.Location = new System.Drawing.Point(693, 12);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(114, 42);
            this.groupBox2.TabIndex = 2;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "판형";
            // 
            // cbPanType
            // 
            this.cbPanType.FormattingEnabled = true;
            this.cbPanType.Location = new System.Drawing.Point(6, 18);
            this.cbPanType.Name = "cbPanType";
            this.cbPanType.Size = new System.Drawing.Size(102, 20);
            this.cbPanType.TabIndex = 1;
            // 
            // bClear
            // 
            this.bClear.Location = new System.Drawing.Point(830, 31);
            this.bClear.Name = "bClear";
            this.bClear.Size = new System.Drawing.Size(50, 23);
            this.bClear.TabIndex = 4;
            this.bClear.Text = "clear";
            this.bClear.UseVisualStyleBackColor = true;
            this.bClear.Click += new System.EventHandler(this.bClear_Click);
            // 
            // bSearch
            // 
            this.bSearch.Location = new System.Drawing.Point(886, 12);
            this.bSearch.Name = "bSearch";
            this.bSearch.Size = new System.Drawing.Size(70, 42);
            this.bSearch.TabIndex = 3;
            this.bSearch.Text = "검색";
            this.bSearch.UseVisualStyleBackColor = true;
            this.bSearch.Click += new System.EventHandler(this.bSearch_Click);
            // 
            // bSave
            // 
            this.bSave.Location = new System.Drawing.Point(12, 56);
            this.bSave.Name = "bSave";
            this.bSave.Size = new System.Drawing.Size(50, 23);
            this.bSave.TabIndex = 6;
            this.bSave.Text = "저장";
            this.bSave.UseVisualStyleBackColor = true;
            this.bSave.Click += new System.EventHandler(this.bSave_Click);
            // 
            // Form_604b
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(970, 300);
            this.Controls.Add(this.bSearch);
            this.Controls.Add(this.bSave);
            this.Controls.Add(this.bClear);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.grid1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form_604b";
            this.Text = "공장지정";
            this.Load += new System.EventHandler(this.Form_604b_Load);
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private SourceGrid.Grid grid1;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.TextBox tbPrnCom;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox tbDosu;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.ComboBox cbPanType;
        private System.Windows.Forms.Button bClear;
        private System.Windows.Forms.Button bSearch;
        private System.Windows.Forms.Button bSave;
    }
}