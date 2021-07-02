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
    public partial class Form_qurey : Form
    {
        public string[] dat = new string[7];
        string int_no = "";


        public Form_qurey(string[] ss)
        {
            InitializeComponent();
            dat = ss;
            //
            textBox1.Text = ss[0]; //단가폼
            textBox2.Text = ss[1]; //변수명
            textBox3.Text = ss[2]; //변수갯수
            textBox4.Text = ss[3]; //쿼리메모
            textBox5.Text = ss[4]; //쿼리문
            int_no = ss[5];        //int_id
        }

        private void button1_Click(object sender, EventArgs e) //저장
        {
            dat[0] = textBox1.Text.Trim();
            dat[1] = textBox2.Text.Trim();
            dat[2] = textBox3.Text.Trim();
            dat[3] = textBox4.Text.Trim();
            dat[4] = textBox5.Text.Trim();
            this.DialogResult = DialogResult.OK;
            this.Close();
        }
    }
}
