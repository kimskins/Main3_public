namespace Dukyou3
{
    partial class Form_3072
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form_3072));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.bDel = new System.Windows.Forms.Button();
            this.bMody = new System.Windows.Forms.Button();
            this.bAdd = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.bGradeMody = new System.Windows.Forms.Button();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.bAutoInsert = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.grid1 = new SourceGrid.Grid();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.bDel);
            this.groupBox1.Controls.Add(this.bMody);
            this.groupBox1.Controls.Add(this.bAdd);
            this.groupBox1.Location = new System.Drawing.Point(12, 25);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(170, 49);
            this.groupBox1.TabIndex = 311;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "매출액(구간)";
            // 
            // bDel
            // 
            this.bDel.Location = new System.Drawing.Point(114, 22);
            this.bDel.Name = "bDel";
            this.bDel.Size = new System.Drawing.Size(42, 23);
            this.bDel.TabIndex = 305;
            this.bDel.Text = "삭제";
            this.bDel.UseVisualStyleBackColor = true;
            this.bDel.Click += new System.EventHandler(this.bDel_Click);
            // 
            // bMody
            // 
            this.bMody.Location = new System.Drawing.Point(63, 22);
            this.bMody.Name = "bMody";
            this.bMody.Size = new System.Drawing.Size(42, 23);
            this.bMody.TabIndex = 305;
            this.bMody.Text = "수정";
            this.bMody.UseVisualStyleBackColor = true;
            this.bMody.Click += new System.EventHandler(this.bMody_Click);
            // 
            // bAdd
            // 
            this.bAdd.Location = new System.Drawing.Point(11, 22);
            this.bAdd.Name = "bAdd";
            this.bAdd.Size = new System.Drawing.Size(42, 23);
            this.bAdd.TabIndex = 305;
            this.bAdd.Text = "추가";
            this.bAdd.UseVisualStyleBackColor = true;
            this.bAdd.Click += new System.EventHandler(this.bAdd_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.bGradeMody);
            this.groupBox2.Location = new System.Drawing.Point(199, 25);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(83, 49);
            this.groupBox2.TabIndex = 312;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "등급(구간)";
            // 
            // bGradeMody
            // 
            this.bGradeMody.Location = new System.Drawing.Point(10, 22);
            this.bGradeMody.Name = "bGradeMody";
            this.bGradeMody.Size = new System.Drawing.Size(62, 23);
            this.bGradeMody.TabIndex = 305;
            this.bGradeMody.Text = "수정";
            this.bGradeMody.UseVisualStyleBackColor = true;
            this.bGradeMody.Click += new System.EventHandler(this.bGradeMody_Click);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.bAutoInsert);
            this.groupBox3.Location = new System.Drawing.Point(299, 25);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(94, 49);
            this.groupBox3.TabIndex = 313;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "단가";
            // 
            // bAutoInsert
            // 
            this.bAutoInsert.Location = new System.Drawing.Point(15, 22);
            this.bAutoInsert.Name = "bAutoInsert";
            this.bAutoInsert.Size = new System.Drawing.Size(62, 23);
            this.bAutoInsert.TabIndex = 305;
            this.bAutoInsert.Text = "자동입력";
            this.bAutoInsert.UseVisualStyleBackColor = true;
            this.bAutoInsert.Click += new System.EventHandler(this.bAutoInsert_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(758, 74);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(227, 12);
            this.label1.TabIndex = 315;
            this.label1.Text = "* 매출액 구간이 겹치지 않게 주의하세요 ";
            // 
            // grid1
            // 
            this.grid1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grid1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.grid1.EnableSort = true;
            this.grid1.Location = new System.Drawing.Point(12, 89);
            this.grid1.Name = "grid1";
            this.grid1.OptimizeMode = SourceGrid.CellOptimizeMode.ForRows;
            this.grid1.SelectionMode = SourceGrid.GridSelectionMode.Cell;
            this.grid1.Size = new System.Drawing.Size(973, 520);
            this.grid1.TabIndex = 314;
            this.grid1.TabStop = true;
            this.grid1.ToolTipText = "";
            // 
            // Form_3072
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(997, 630);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.grid1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form_3072";
            this.Text = "세부견적 단가관리";
            this.Load += new System.EventHandler(this.Form_3092_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button bDel;
        private System.Windows.Forms.Button bMody;
        private System.Windows.Forms.Button bAdd;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button bGradeMody;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Button bAutoInsert;
        private System.Windows.Forms.Label label1;
        private SourceGrid.Grid grid1;
    }
}