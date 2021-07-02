using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Dukyou3
{
    public partial class Form_memo : Form
    {
        public string mtext = "";
        public string jtext = "";
        public string ntext = "";

        public string expression1 = "";
        public string expression2 = ""; 

        bool s_id = false;

        public Form_memo(string mm)
        {
            InitializeComponent();
            richTextBox1.Text = mm;
            label1.Visible = false;
            textBox1.Visible = false;
            this.Height = 252;
        }

        public Form_memo(string mm, string ss, string dd,string exp1,string exp2)
        {
            InitializeComponent();
            richTextBox1.Text = mm;
            textBox1.Text = ss;
            textBox2.Text = dd;
            textBox3.Text = exp1;
            textBox4.Text = exp2;

            s_id = true;
            this.Height = 309;
        }

        private void Form_memo_Load(object sender, EventArgs e)
        {
            this.richTextBox1.SelectionStart = this.Text.Length;
        }

        private void button1_Click_1(object sender, EventArgs e)  //저장
        {
            mtext = richTextBox1.Text.Trim();
            if (s_id == true)
            {
                jtext = textBox1.Text.Trim();
                ntext = textBox2.Text.Trim();
                expression1 = textBox3.Text;
                expression2 = textBox4.Text;
            }
            this.DialogResult = DialogResult.OK;
            this.Close();

        }

    }
}
