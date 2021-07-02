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
    public partial class Form_502c : Form
    {
        public string cut = "";
        public string remain = "";
        public string sock01 = "";
        public string sock13 = "";
        public string sock3 = "";
        public string sock4 = "";
        Button butt = new Button();
        private int Xb = 0;
        private int Yb = 0;

        bool chk_data = false;
        

        public Form_502c(Button bt)
        {
            InitializeComponent();
            butt = bt;
            Xb = butt.PointToScreen(Location).X;  //좌,우
            Yb = butt.PointToScreen(Location).Y - (this.ClientSize.Height + bt.Size.Height + 10);  //위,아래
        }
        public Form_502c(Button bt, string data)
        {
            InitializeComponent();
            butt = bt;
            Xb = butt.PointToScreen(Location).X;  //좌,우
            Yb = butt.PointToScreen(Location).Y - (this.ClientSize.Height + bt.Size.Height + 10);  //위,아래

            string[] temp = data.Split('#');
            for(int i =0; i<temp.Length; i++)
            {
                tbCut.Text = temp[0];
                tbRemain.Text = temp[1];
                tbSock01.Text = temp[2];
                tbSock13.Text = temp[3];
                tbSock3.Text = temp[4];
                textBox1.Text = temp[5];
            }
            chk_data = true;
        }

        private void bApply_Click(object sender, EventArgs e)
        {
            if (tbCut.Text == "" && tbRemain.Text == "" && tbSock01.Text == "" && tbSock13.Text == "" && tbSock3.Text == "" && textBox1.Text == "")
            {
                MessageBox.Show("적용 값이 없습니다.");
                return;
            }
            if (MessageBox.Show("적용하시겠습니까?", "메세지창", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                cut = tbCut.Text;
                remain = tbRemain.Text;
                sock01 = tbSock01.Text;
                sock13 = tbSock13.Text;
                sock3 = tbSock3.Text;
                sock4 = textBox1.Text;

                if (chk_data == true)
                {
                    if (cut == "" || cut.Trim() == "")
                        cut = "0";
                    if (remain == "" || remain.Trim() == "")
                        remain = "0";
                    if (sock01 == "" || sock01.Trim() == "")
                        sock01 = "0";
                    if (sock13 == "" || sock13.Trim() == "")
                        sock13 = "0";
                    if (sock3 == "" || sock3.Trim() == "")
                        sock3 = "0";
                    if (sock4 == "" || sock4.Trim() == "")
                        sock4 = "0";
                }

                this.DialogResult = DialogResult.OK;
                this.Close();
            }
        }

        private void Form_502c_Load(object sender, EventArgs e)
        {
            this.Location = new Point(Xb, Yb);
        }
    }
}
