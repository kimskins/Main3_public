namespace Dukyou3
{
    partial class Form_301
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form_301));
            this.grid1 = new SourceGrid.Grid();
            this.bSearch = new System.Windows.Forms.Button();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.tbTrans_way = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.tbStart = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.tbEnd = new System.Windows.Forms.TextBox();
            this.bClear = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label8 = new System.Windows.Forms.Label();
            this.tbStartDate = new System.Windows.Forms.TextBox();
            this.tbEndDate = new System.Windows.Forms.TextBox();
            this.bStartDate = new System.Windows.Forms.Button();
            this.bEndDate = new System.Windows.Forms.Button();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.tbCar = new System.Windows.Forms.TextBox();
            this.groupBox5.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.SuspendLayout();
            // 
            // grid1
            // 
            this.grid1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.grid1.EnableSort = true;
            this.grid1.Location = new System.Drawing.Point(12, 66);
            this.grid1.Name = "grid1";
            this.grid1.OptimizeMode = SourceGrid.CellOptimizeMode.ForRows;
            this.grid1.SelectionMode = SourceGrid.GridSelectionMode.Cell;
            this.grid1.Size = new System.Drawing.Size(1230, 595);
            this.grid1.TabIndex = 7;
            this.grid1.TabStop = true;
            this.grid1.ToolTipText = "";
            // 
            // bSearch
            // 
            this.bSearch.ForeColor = System.Drawing.Color.Black;
            this.bSearch.Location = new System.Drawing.Point(1156, 26);
            this.bSearch.Name = "bSearch";
            this.bSearch.Size = new System.Drawing.Size(86, 34);
            this.bSearch.TabIndex = 5;
            this.bSearch.Text = "검색";
            this.bSearch.UseVisualStyleBackColor = true;
            this.bSearch.Click += new System.EventHandler(this.bSearch_Click);
            // 
            // groupBox5
            // 
            this.groupBox5.BackColor = System.Drawing.SystemColors.Control;
            this.groupBox5.Controls.Add(this.tbTrans_way);
            this.groupBox5.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.groupBox5.Location = new System.Drawing.Point(544, 21);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(89, 42);
            this.groupBox5.TabIndex = 1;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "운송방법";
            // 
            // tbTrans_way
            // 
            this.tbTrans_way.Location = new System.Drawing.Point(6, 16);
            this.tbTrans_way.Name = "tbTrans_way";
            this.tbTrans_way.Size = new System.Drawing.Size(77, 21);
            this.tbTrans_way.TabIndex = 2;
            this.tbTrans_way.TabStop = false;
            this.tbTrans_way.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.SystemColors.Control;
            this.groupBox1.Controls.Add(this.tbStart);
            this.groupBox1.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.groupBox1.Location = new System.Drawing.Point(755, 19);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(158, 42);
            this.groupBox1.TabIndex = 3;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "출발지";
            // 
            // tbStart
            // 
            this.tbStart.Location = new System.Drawing.Point(6, 15);
            this.tbStart.Name = "tbStart";
            this.tbStart.Size = new System.Drawing.Size(139, 21);
            this.tbStart.TabIndex = 318;
            // 
            // label5
            // 
            this.label5.BackColor = System.Drawing.Color.PeachPuff;
            this.label5.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label5.Font = new System.Drawing.Font("Gulim", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label5.Location = new System.Drawing.Point(13, 30);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(133, 32);
            this.label5.TabIndex = 328;
            this.label5.Text = "운송단가 DB";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // groupBox3
            // 
            this.groupBox3.BackColor = System.Drawing.SystemColors.Control;
            this.groupBox3.Controls.Add(this.tbEnd);
            this.groupBox3.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.groupBox3.Location = new System.Drawing.Point(925, 19);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(161, 42);
            this.groupBox3.TabIndex = 4;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "도착지";
            // 
            // tbEnd
            // 
            this.tbEnd.Location = new System.Drawing.Point(6, 15);
            this.tbEnd.Name = "tbEnd";
            this.tbEnd.Size = new System.Drawing.Size(146, 21);
            this.tbEnd.TabIndex = 320;
            // 
            // bClear
            // 
            this.bClear.ForeColor = System.Drawing.Color.Black;
            this.bClear.Location = new System.Drawing.Point(1103, 39);
            this.bClear.Name = "bClear";
            this.bClear.Size = new System.Drawing.Size(47, 21);
            this.bClear.TabIndex = 6;
            this.bClear.Text = "Clear";
            this.bClear.UseVisualStyleBackColor = true;
            this.bClear.Click += new System.EventHandler(this.bClear_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.BackColor = System.Drawing.SystemColors.Control;
            this.groupBox2.Controls.Add(this.label8);
            this.groupBox2.Controls.Add(this.tbStartDate);
            this.groupBox2.Controls.Add(this.tbEndDate);
            this.groupBox2.Controls.Add(this.bStartDate);
            this.groupBox2.Controls.Add(this.bEndDate);
            this.groupBox2.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.groupBox2.Location = new System.Drawing.Point(313, 21);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(211, 41);
            this.groupBox2.TabIndex = 0;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "기간";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(98, 19);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(17, 12);
            this.label8.TabIndex = 320;
            this.label8.Text = "∼";
            // 
            // tbStartDate
            // 
            this.tbStartDate.Location = new System.Drawing.Point(8, 15);
            this.tbStartDate.Name = "tbStartDate";
            this.tbStartDate.Size = new System.Drawing.Size(69, 21);
            this.tbStartDate.TabIndex = 0;
            this.tbStartDate.TabStop = false;
            this.tbStartDate.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // tbEndDate
            // 
            this.tbEndDate.Location = new System.Drawing.Point(117, 15);
            this.tbEndDate.Name = "tbEndDate";
            this.tbEndDate.Size = new System.Drawing.Size(69, 21);
            this.tbEndDate.TabIndex = 2;
            this.tbEndDate.TabStop = false;
            this.tbEndDate.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // bStartDate
            // 
            this.bStartDate.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.bStartDate.Font = new System.Drawing.Font("Gulim", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.bStartDate.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.bStartDate.Location = new System.Drawing.Point(77, 15);
            this.bStartDate.Name = "bStartDate";
            this.bStartDate.Size = new System.Drawing.Size(17, 20);
            this.bStartDate.TabIndex = 1;
            this.bStartDate.Text = "▼";
            this.bStartDate.UseVisualStyleBackColor = true;
            this.bStartDate.Click += new System.EventHandler(this.bStartDate_Click);
            // 
            // bEndDate
            // 
            this.bEndDate.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.bEndDate.Font = new System.Drawing.Font("Gulim", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.bEndDate.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.bEndDate.Location = new System.Drawing.Point(186, 15);
            this.bEndDate.Name = "bEndDate";
            this.bEndDate.Size = new System.Drawing.Size(17, 20);
            this.bEndDate.TabIndex = 3;
            this.bEndDate.Text = "▼";
            this.bEndDate.UseVisualStyleBackColor = true;
            this.bEndDate.Click += new System.EventHandler(this.bEndDate_Click);
            // 
            // groupBox4
            // 
            this.groupBox4.BackColor = System.Drawing.SystemColors.Control;
            this.groupBox4.Controls.Add(this.tbCar);
            this.groupBox4.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.groupBox4.Location = new System.Drawing.Point(649, 21);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(89, 42);
            this.groupBox4.TabIndex = 2;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "차량";
            // 
            // tbCar
            // 
            this.tbCar.Location = new System.Drawing.Point(6, 16);
            this.tbCar.Name = "tbCar";
            this.tbCar.Size = new System.Drawing.Size(77, 21);
            this.tbCar.TabIndex = 2;
            this.tbCar.TabStop = false;
            this.tbCar.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // Form_301
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1254, 675);
            this.Controls.Add(this.bClear);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.bSearch);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.groupBox5);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.grid1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form_301";
            this.Text = "■ 운송단가 DB";
            this.Load += new System.EventHandler(this.Form_14_Load);
            this.SizeChanged += new System.EventHandler(this.Form_301_SizeChanged);
            this.groupBox5.ResumeLayout(false);
            this.groupBox5.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private SourceGrid.Grid grid1;
        private System.Windows.Forms.Button bSearch;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox tbStart;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Button bClear;
        private System.Windows.Forms.TextBox tbEnd;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox tbStartDate;
        private System.Windows.Forms.TextBox tbEndDate;
        private System.Windows.Forms.Button bStartDate;
        private System.Windows.Forms.Button bEndDate;
        private System.Windows.Forms.TextBox tbTrans_way;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.TextBox tbCar;
    }
}