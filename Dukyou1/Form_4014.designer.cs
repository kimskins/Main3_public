namespace Dukyou3
{
    partial class Form_4014
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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form_4014));
            this.grid1 = new SourceGrid.Grid();
            this.grid2 = new SourceGrid.Grid();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.rbJop = new System.Windows.Forms.RadioButton();
            this.rbCust = new System.Windows.Forms.RadioButton();
            this.bMgyoun = new System.Windows.Forms.Button();
            this.bMjoo = new System.Windows.Forms.Button();
            this.bMpan = new System.Windows.Forms.Button();
            this.bPan = new System.Windows.Forms.Button();
            this.bJoo = new System.Windows.Forms.Button();
            this.bGyoun = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.button4 = new System.Windows.Forms.Button();
            this.cbYear = new System.Windows.Forms.ComboBox();
            this.chart1 = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.grid3 = new SourceGrid.Grid();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).BeginInit();
            this.SuspendLayout();
            // 
            // grid1
            // 
            this.grid1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.grid1.CustomSort = true;
            this.grid1.EnableSort = true;
            this.grid1.Font = new System.Drawing.Font("Gulim", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.grid1.Location = new System.Drawing.Point(12, 78);
            this.grid1.Name = "grid1";
            this.grid1.OptimizeMode = SourceGrid.CellOptimizeMode.ForRows;
            this.grid1.SelectionMode = SourceGrid.GridSelectionMode.Cell;
            this.grid1.Size = new System.Drawing.Size(374, 667);
            this.grid1.TabIndex = 1;
            this.grid1.TabStop = true;
            this.grid1.ToolTipText = "";
            this.grid1.MouseClick += new System.Windows.Forms.MouseEventHandler(this.grid1_MouseClick);
            this.grid1.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.grid1_MouseDoubleClick);
            // 
            // grid2
            // 
            this.grid2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.grid2.CustomSort = true;
            this.grid2.EnableSort = true;
            this.grid2.Font = new System.Drawing.Font("Gulim", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.grid2.Location = new System.Drawing.Point(12, 78);
            this.grid2.Name = "grid2";
            this.grid2.OptimizeMode = SourceGrid.CellOptimizeMode.ForRows;
            this.grid2.SelectionMode = SourceGrid.GridSelectionMode.Cell;
            this.grid2.Size = new System.Drawing.Size(374, 667);
            this.grid2.TabIndex = 4;
            this.grid2.TabStop = true;
            this.grid2.ToolTipText = "";
            this.grid2.Visible = false;
            this.grid2.MouseClick += new System.Windows.Forms.MouseEventHandler(this.grid2_MouseClick);
            this.grid2.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.grid2_MouseDoubleClick);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.rbJop);
            this.groupBox1.Controls.Add(this.rbCust);
            this.groupBox1.Controls.Add(this.bMgyoun);
            this.groupBox1.Controls.Add(this.bMjoo);
            this.groupBox1.Controls.Add(this.bMpan);
            this.groupBox1.Controls.Add(this.bPan);
            this.groupBox1.Controls.Add(this.bJoo);
            this.groupBox1.Controls.Add(this.bGyoun);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(1295, 58);
            this.groupBox1.TabIndex = 11;
            this.groupBox1.TabStop = false;
            // 
            // rbJop
            // 
            this.rbJop.AutoSize = true;
            this.rbJop.Location = new System.Drawing.Point(6, 36);
            this.rbJop.Name = "rbJop";
            this.rbJop.Size = new System.Drawing.Size(47, 16);
            this.rbJop.TabIndex = 274;
            this.rbJop.TabStop = true;
            this.rbJop.Text = "업무";
            this.rbJop.UseVisualStyleBackColor = true;
            this.rbJop.CheckedChanged += new System.EventHandler(this.rbJop_CheckedChanged);
            // 
            // rbCust
            // 
            this.rbCust.AutoSize = true;
            this.rbCust.Location = new System.Drawing.Point(6, 14);
            this.rbCust.Name = "rbCust";
            this.rbCust.Size = new System.Drawing.Size(47, 16);
            this.rbCust.TabIndex = 273;
            this.rbCust.TabStop = true;
            this.rbCust.Text = "고객";
            this.rbCust.UseVisualStyleBackColor = true;
            this.rbCust.CheckedChanged += new System.EventHandler(this.rbCust_CheckedChanged);
            // 
            // bMgyoun
            // 
            this.bMgyoun.Location = new System.Drawing.Point(181, 20);
            this.bMgyoun.Name = "bMgyoun";
            this.bMgyoun.Size = new System.Drawing.Size(42, 23);
            this.bMgyoun.TabIndex = 270;
            this.bMgyoun.Text = "견적";
            this.bMgyoun.UseVisualStyleBackColor = true;
            this.bMgyoun.Click += new System.EventHandler(this.bMgyoun_Click);
            // 
            // bMjoo
            // 
            this.bMjoo.Location = new System.Drawing.Point(229, 20);
            this.bMjoo.Name = "bMjoo";
            this.bMjoo.Size = new System.Drawing.Size(42, 23);
            this.bMjoo.TabIndex = 272;
            this.bMjoo.Text = "주문";
            this.bMjoo.UseVisualStyleBackColor = true;
            this.bMjoo.Click += new System.EventHandler(this.bMjoo_Click);
            // 
            // bMpan
            // 
            this.bMpan.Location = new System.Drawing.Point(133, 20);
            this.bMpan.Name = "bMpan";
            this.bMpan.Size = new System.Drawing.Size(42, 23);
            this.bMpan.TabIndex = 271;
            this.bMpan.Text = "판";
            this.bMpan.UseVisualStyleBackColor = true;
            this.bMpan.Click += new System.EventHandler(this.bMpan_Click);
            // 
            // bPan
            // 
            this.bPan.Location = new System.Drawing.Point(407, 20);
            this.bPan.Name = "bPan";
            this.bPan.Size = new System.Drawing.Size(47, 23);
            this.bPan.TabIndex = 267;
            this.bPan.Text = "판";
            this.bPan.UseVisualStyleBackColor = true;
            this.bPan.Click += new System.EventHandler(this.bPan_Click);
            // 
            // bJoo
            // 
            this.bJoo.Location = new System.Drawing.Point(513, 20);
            this.bJoo.Name = "bJoo";
            this.bJoo.Size = new System.Drawing.Size(47, 23);
            this.bJoo.TabIndex = 265;
            this.bJoo.Text = "주문";
            this.bJoo.UseVisualStyleBackColor = true;
            this.bJoo.Click += new System.EventHandler(this.bJoo_Click);
            // 
            // bGyoun
            // 
            this.bGyoun.Location = new System.Drawing.Point(460, 20);
            this.bGyoun.Name = "bGyoun";
            this.bGyoun.Size = new System.Drawing.Size(47, 23);
            this.bGyoun.TabIndex = 13;
            this.bGyoun.Text = "견적";
            this.bGyoun.UseVisualStyleBackColor = true;
            this.bGyoun.Click += new System.EventHandler(this.bGyoun_Click);
            // 
            // label2
            // 
            this.label2.BackColor = System.Drawing.Color.AliceBlue;
            this.label2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label2.Font = new System.Drawing.Font("Gulim", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label2.Location = new System.Drawing.Point(59, 20);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(68, 24);
            this.label2.TabIndex = 264;
            this.label2.Text = "월 별";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label5
            // 
            this.label5.BackColor = System.Drawing.Color.AliceBlue;
            this.label5.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label5.Font = new System.Drawing.Font("Gulim", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label5.Location = new System.Drawing.Point(279, 20);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(122, 24);
            this.label5.TabIndex = 264;
            this.label5.Text = "상위 10개 업체";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(1288, 176);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(75, 23);
            this.button4.TabIndex = 266;
            this.button4.Text = "button4";
            this.button4.UseVisualStyleBackColor = true;
            // 
            // cbYear
            // 
            this.cbYear.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbYear.FormattingEnabled = true;
            this.cbYear.Items.AddRange(new object[] {
            "2010년",
            "2011년",
            "2012년",
            "2013년",
            "2014년",
            "2015년",
            "2016년"});
            this.cbYear.Location = new System.Drawing.Point(392, 99);
            this.cbYear.Name = "cbYear";
            this.cbYear.Size = new System.Drawing.Size(74, 20);
            this.cbYear.TabIndex = 7;
            this.cbYear.SelectedValueChanged += new System.EventHandler(this.cbYear_SelectedValueChanged);
            // 
            // chart1
            // 
            this.chart1.BackColor = System.Drawing.SystemColors.Control;
            chartArea1.AxisX.IsLabelAutoFit = false;
            chartArea1.AxisX.LabelStyle.Font = new System.Drawing.Font("Microsoft Sans Serif", 7F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            chartArea1.Name = "ChartArea1";
            this.chart1.ChartAreas.Add(chartArea1);
            legend1.BackColor = System.Drawing.SystemColors.ButtonFace;
            legend1.Name = "Legend1";
            this.chart1.Legends.Add(legend1);
            this.chart1.Location = new System.Drawing.Point(458, 76);
            this.chart1.Name = "chart1";
            this.chart1.Size = new System.Drawing.Size(961, 669);
            this.chart1.TabIndex = 10;
            this.chart1.Text = "chart1";
            // 
            // grid3
            // 
            this.grid3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.grid3.CustomSort = true;
            this.grid3.EnableSort = true;
            this.grid3.Font = new System.Drawing.Font("Gulim", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.grid3.Location = new System.Drawing.Point(392, 78);
            this.grid3.Name = "grid3";
            this.grid3.OptimizeMode = SourceGrid.CellOptimizeMode.ForRows;
            this.grid3.SelectionMode = SourceGrid.GridSelectionMode.Cell;
            this.grid3.Size = new System.Drawing.Size(594, 667);
            this.grid3.TabIndex = 5;
            this.grid3.TabStop = true;
            this.grid3.ToolTipText = "";
            this.grid3.Visible = false;
            // 
            // Form_4014
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1411, 757);
            this.Controls.Add(this.grid2);
            this.Controls.Add(this.cbYear);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.grid1);
            this.Controls.Add(this.chart1);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.grid3);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form_4014";
            this.Text = "사용자 관리";
            this.Load += new System.EventHandler(this.KJH_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private SourceGrid.Grid grid1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ComboBox cbYear;
        private System.Windows.Forms.DataVisualization.Charting.Chart chart1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button bMgyoun;
        private System.Windows.Forms.Button bPan;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Button bJoo;
        private System.Windows.Forms.Button bGyoun;
        private System.Windows.Forms.Button bMjoo;
        private System.Windows.Forms.Button bMpan;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.RadioButton rbJop;
        private System.Windows.Forms.RadioButton rbCust;
        private SourceGrid.Grid grid2;
        private SourceGrid.Grid grid3;
    }
}