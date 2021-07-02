namespace Dukyou3
{
    partial class Form_213b
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form_213b));
            this.bNotMachine = new System.Windows.Forms.Button();
            this.grid1 = new SourceGrid.Grid();
            this.bClose = new System.Windows.Forms.Button();
            this.label15 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // bNotMachine
            // 
            this.bNotMachine.Location = new System.Drawing.Point(368, 28);
            this.bNotMachine.Name = "bNotMachine";
            this.bNotMachine.Size = new System.Drawing.Size(104, 47);
            this.bNotMachine.TabIndex = 0;
            this.bNotMachine.Text = "기계없음";
            this.bNotMachine.UseVisualStyleBackColor = true;
            this.bNotMachine.Click += new System.EventHandler(this.bNotMachine_Click);
            // 
            // grid1
            // 
            this.grid1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.grid1.EnableSort = true;
            this.grid1.Location = new System.Drawing.Point(12, 81);
            this.grid1.Name = "grid1";
            this.grid1.OptimizeMode = SourceGrid.CellOptimizeMode.ForRows;
            this.grid1.SelectionMode = SourceGrid.GridSelectionMode.Cell;
            this.grid1.Size = new System.Drawing.Size(570, 424);
            this.grid1.TabIndex = 13;
            this.grid1.TabStop = true;
            this.grid1.ToolTipText = "";
            this.grid1.DoubleClick += new System.EventHandler(this.grid1_DoubleClick);
            // 
            // bClose
            // 
            this.bClose.Location = new System.Drawing.Point(478, 28);
            this.bClose.Name = "bClose";
            this.bClose.Size = new System.Drawing.Size(104, 47);
            this.bClose.TabIndex = 0;
            this.bClose.Text = "닫기";
            this.bClose.UseVisualStyleBackColor = true;
            this.bClose.Click += new System.EventHandler(this.bClose_Click);
            // 
            // label15
            // 
            this.label15.BackColor = System.Drawing.Color.Azure;
            this.label15.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label15.Font = new System.Drawing.Font("Gulim", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label15.Location = new System.Drawing.Point(12, 35);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(160, 32);
            this.label15.TabIndex = 114;
            this.label15.Text = "   ■ 사용자 기계 선택";
            this.label15.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // Form_213b
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(597, 517);
            this.Controls.Add(this.label15);
            this.Controls.Add(this.grid1);
            this.Controls.Add(this.bClose);
            this.Controls.Add(this.bNotMachine);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form_213b";
            this.Text = "사용자 기계 선택";
            this.Load += new System.EventHandler(this.Form_213b_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button bNotMachine;
        private SourceGrid.Grid grid1;
        private System.Windows.Forms.Button bClose;
        private System.Windows.Forms.Label label15;
    }
}