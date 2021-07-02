namespace Dukyou3
{
    partial class Form_208
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form_208));
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.grid2 = new SourceGrid.Grid();
            this.button3 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(960, 19);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(74, 28);
            this.button1.TabIndex = 201;
            this.button1.Text = "삭 제";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(1047, 19);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(74, 28);
            this.button2.TabIndex = 202;
            this.button2.Text = "추 가";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // grid2
            // 
            this.grid2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grid2.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.grid2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.grid2.EnableSort = true;
            this.grid2.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.grid2.Location = new System.Drawing.Point(24, 51);
            this.grid2.Name = "grid2";
            this.grid2.OptimizeMode = SourceGrid.CellOptimizeMode.ForRows;
            this.grid2.SelectionMode = SourceGrid.GridSelectionMode.Cell;
            this.grid2.Size = new System.Drawing.Size(1098, 557);
            this.grid2.TabIndex = 205;
            this.grid2.TabStop = true;
            this.grid2.ToolTipText = "";
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(873, 19);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(74, 28);
            this.button3.TabIndex = 206;
            this.button3.Text = "Refresh";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click_1);
            // 
            // Form_208
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1145, 647);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.grid2);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form_208";
            this.Text = " ■ 배송방법 / 차량 등록 ";
            this.Load += new System.EventHandler(this.Form_trans_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private SourceGrid.Grid grid2;
        private System.Windows.Forms.Button button3;

    }
}