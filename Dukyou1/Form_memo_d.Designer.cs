namespace Dukyou3
{
    partial class Form_memo_d
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form_memo_d));
            this.bSaveMemo = new System.Windows.Forms.Button();
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.grid2 = new SourceGrid.Grid();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.delete_2 = new System.Windows.Forms.Button();
            this.copy_2 = new System.Windows.Forms.Button();
            this.insert_2 = new System.Windows.Forms.Button();
            this.bSaveHang = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.richTextBox2 = new System.Windows.Forms.RichTextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // bSaveMemo
            // 
            this.bSaveMemo.Location = new System.Drawing.Point(547, 207);
            this.bSaveMemo.Name = "bSaveMemo";
            this.bSaveMemo.Size = new System.Drawing.Size(58, 25);
            this.bSaveMemo.TabIndex = 146;
            this.bSaveMemo.Text = "저 장";
            this.bSaveMemo.UseVisualStyleBackColor = true;
            this.bSaveMemo.Click += new System.EventHandler(this.button1_Click);
            // 
            // richTextBox1
            // 
            this.richTextBox1.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.richTextBox1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.richTextBox1.ImeMode = System.Windows.Forms.ImeMode.Hangul;
            this.richTextBox1.Location = new System.Drawing.Point(10, 12);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.Vertical;
            this.richTextBox1.Size = new System.Drawing.Size(569, 94);
            this.richTextBox1.TabIndex = 143;
            this.richTextBox1.Text = "";
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.Color.AliceBlue;
            this.label1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label1.Font = new System.Drawing.Font("Gulim", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label1.Location = new System.Drawing.Point(10, 208);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(67, 26);
            this.label1.TabIndex = 148;
            this.label1.Text = "계산메모";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.richTextBox1);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Location = new System.Drawing.Point(9, 238);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(596, 121);
            this.panel1.TabIndex = 150;
            // 
            // label2
            // 
            this.label2.BackColor = System.Drawing.Color.AliceBlue;
            this.label2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label2.Font = new System.Drawing.Font("Gulim", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label2.Location = new System.Drawing.Point(2, -31);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(67, 26);
            this.label2.TabIndex = 148;
            this.label2.Text = "Memo";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // grid2
            // 
            this.grid2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.grid2.EnableSort = true;
            this.grid2.Location = new System.Drawing.Point(10, 434);
            this.grid2.Name = "grid2";
            this.grid2.OptimizeMode = SourceGrid.CellOptimizeMode.ForRows;
            this.grid2.SelectionMode = SourceGrid.GridSelectionMode.Cell;
            this.grid2.Size = new System.Drawing.Size(598, 139);
            this.grid2.TabIndex = 153;
            this.grid2.TabStop = true;
            this.grid2.ToolTipText = "";
            // 
            // label3
            // 
            this.label3.BackColor = System.Drawing.Color.AliceBlue;
            this.label3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label3.Font = new System.Drawing.Font("Gulim", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label3.Location = new System.Drawing.Point(10, 404);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(111, 26);
            this.label3.TabIndex = 152;
            this.label3.Text = "단가 연산공식";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label4
            // 
            this.label4.BackColor = System.Drawing.Color.DodgerBlue;
            this.label4.Location = new System.Drawing.Point(4, 188);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(613, 3);
            this.label4.TabIndex = 154;
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label5
            // 
            this.label5.BackColor = System.Drawing.Color.DodgerBlue;
            this.label5.Location = new System.Drawing.Point(3, 385);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(613, 3);
            this.label5.TabIndex = 155;
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // delete_2
            // 
            this.delete_2.Location = new System.Drawing.Point(566, 407);
            this.delete_2.Name = "delete_2";
            this.delete_2.Size = new System.Drawing.Size(43, 22);
            this.delete_2.TabIndex = 161;
            this.delete_2.Text = "삭제";
            this.delete_2.UseVisualStyleBackColor = true;
            this.delete_2.Click += new System.EventHandler(this.delete_2_Click);
            // 
            // copy_2
            // 
            this.copy_2.Location = new System.Drawing.Point(517, 407);
            this.copy_2.Name = "copy_2";
            this.copy_2.Size = new System.Drawing.Size(43, 22);
            this.copy_2.TabIndex = 160;
            this.copy_2.Text = "복사";
            this.copy_2.UseVisualStyleBackColor = true;
            this.copy_2.Click += new System.EventHandler(this.copy_2_Click);
            // 
            // insert_2
            // 
            this.insert_2.Location = new System.Drawing.Point(468, 407);
            this.insert_2.Name = "insert_2";
            this.insert_2.Size = new System.Drawing.Size(43, 22);
            this.insert_2.TabIndex = 159;
            this.insert_2.Text = "추가";
            this.insert_2.UseVisualStyleBackColor = true;
            this.insert_2.Click += new System.EventHandler(this.insert_2_Click);
            // 
            // bSaveHang
            // 
            this.bSaveHang.Location = new System.Drawing.Point(547, 12);
            this.bSaveHang.Name = "bSaveHang";
            this.bSaveHang.Size = new System.Drawing.Size(58, 25);
            this.bSaveHang.TabIndex = 146;
            this.bSaveHang.Text = "저 장";
            this.bSaveHang.UseVisualStyleBackColor = true;
            this.bSaveHang.Click += new System.EventHandler(this.bSaveHang_Click);
            // 
            // label6
            // 
            this.label6.BackColor = System.Drawing.Color.AliceBlue;
            this.label6.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label6.Font = new System.Drawing.Font("Gulim", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label6.Location = new System.Drawing.Point(10, 13);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(67, 26);
            this.label6.TabIndex = 148;
            this.label6.Text = "항목메모";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel2.Controls.Add(this.richTextBox2);
            this.panel2.Controls.Add(this.label7);
            this.panel2.Location = new System.Drawing.Point(9, 48);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(596, 121);
            this.panel2.TabIndex = 162;
            // 
            // richTextBox2
            // 
            this.richTextBox2.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.richTextBox2.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.richTextBox2.ImeMode = System.Windows.Forms.ImeMode.Hangul;
            this.richTextBox2.Location = new System.Drawing.Point(10, 12);
            this.richTextBox2.Name = "richTextBox2";
            this.richTextBox2.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.Vertical;
            this.richTextBox2.Size = new System.Drawing.Size(569, 94);
            this.richTextBox2.TabIndex = 143;
            this.richTextBox2.Text = "";
            // 
            // label7
            // 
            this.label7.BackColor = System.Drawing.Color.AliceBlue;
            this.label7.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label7.Font = new System.Drawing.Font("Gulim", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label7.Location = new System.Drawing.Point(2, -31);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(67, 26);
            this.label7.TabIndex = 148;
            this.label7.Text = "Memo";
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // Form_memo_d
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(625, 608);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.delete_2);
            this.Controls.Add(this.copy_2);
            this.Controls.Add(this.insert_2);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.grid2);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.bSaveHang);
            this.Controls.Add(this.bSaveMemo);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form_memo_d";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "■ 메모 / 퀘리문 정의";
            this.Load += new System.EventHandler(this.Form_memo_d_Load);
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button bSaveMemo;
        private System.Windows.Forms.RichTextBox richTextBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel1;
        private SourceGrid.Grid grid2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button delete_2;
        private System.Windows.Forms.Button copy_2;
        private System.Windows.Forms.Button insert_2;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button bSaveHang;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.RichTextBox richTextBox2;
        private System.Windows.Forms.Label label7;
    }
}