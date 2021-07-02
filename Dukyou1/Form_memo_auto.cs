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
    public partial class Form_memo_auto : Form
    {
        private TextBox tx = new TextBox();
        private int Xb = 0;
        private int Yb = 0;
        public string[] dat ;

        public Form_memo_auto(string[] ss)
        {
            InitializeComponent();
            dat = ss;
            Screen srn = Screen.PrimaryScreen;
            Xb = (srn.Bounds.Width - this.Width)/2;  
            Yb = (srn.Bounds.Height - this.Height)/2; 
        }

        public Form_memo_auto(TextBox tt, string[] ss)
        {
            InitializeComponent();
            tx = tt;
            dat = ss;
            Xb = tx.PointToScreen(Location).X;  //좌,우
            Yb = tx.PointToScreen(Location).Y + tx.Height;  //위,아래
        }

        private void Form_memo_auto_Load(object sender, EventArgs e)
        {
            this.Location = new Point(Xb, Yb);
            richTextBox1.Text = dat[0];  //메모
            textBox3.Text = dat[1];     //처리
            textBox1.Text = dat[2];      //사고자 
            textBox2.Text = dat[3];      //공장
        }

        private void button1_Click(object sender, EventArgs e)
        {
            dat[0] = richTextBox1.Text;  //메모
            dat[1] = textBox3.Text;     //처리
            dat[2] = textBox1.Text;      //사고자 
            dat[3] = textBox2.Text;      //공장
            //
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

    }
}
