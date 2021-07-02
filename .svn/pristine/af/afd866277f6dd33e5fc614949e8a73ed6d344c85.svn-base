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
    public partial class Form_604a : Form
    {
        int X;
        int Y;
        public Form_604a(int X, int Y, string PrnCom, string Tel, string Memo)
        {
            InitializeComponent();

            this.X = X;
            this.Y = Y;
            lbPrnCom.Text = PrnCom;
            lbTel.Text = Tel;
            tbMemo.Text = Memo;
        }

        private void Form_604a_Load(object sender, EventArgs e)
        {
            this.Location = new Point(X - this.Width, Y);  //좌/우,위/아래
        }
    }
}
