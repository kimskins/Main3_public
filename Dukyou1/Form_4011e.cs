using MySql.Data.MySqlClient;
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
    public partial class Form_4011e : Form
    {
        public string permission = "";
        int length = 0;
        int Xb = 0;
        int Yb = 0;
        
        public Form_4011e(string permission, TextBox tb)
        {
            InitializeComponent();
            this.permission = permission;
            length = permission.Length;

            Xb = tb.PointToScreen(Location).X;  //좌,우
            Yb = tb.PointToScreen(Location).Y + tb.Size.Height;  //위,아래
        }

        private void Form_4011e_Load(object sender, EventArgs e)
        {
            this.Location = new Point(Xb, Yb);

            if (permission.Substring(0,1) == "1")
                cbCall.Checked = true;
            else
                cbCall.Checked = false;
        }

        private void bOk_Click(object sender, EventArgs e)
        {
            string call = "0";
            
            if (cbCall.Checked)
                call = "1";

            permission = call + "000000";
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void bCancle_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
