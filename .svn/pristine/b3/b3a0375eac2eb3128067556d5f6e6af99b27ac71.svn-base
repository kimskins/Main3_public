using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;


namespace Dukyou3
{
    public partial class Form_paper : Form
    {
        string[] dt;
        public Form_paper(string[] ss)
        {
            InitializeComponent();
            dt = ss;
        }

        private void Form_paper_Load(object sender, EventArgs e)
        {
            DirectoryInfo dat = new DirectoryInfo(@"c:\temp");
            if (dat.Exists == false)       //디렉토리 없을시 생성
                dat.Create();
            //
            if (!string.IsNullOrEmpty(dt[0]))
            {
                OhFTP Ftp = new OhFTP(Config.Ftp_ip1, Config.Ftp_id1, Config.Ftp_pw1);
                Ftp.DownLoadFile(@"c:\temp\", dt[0], "");
                pictureBox1.Image = System.Drawing.Bitmap.FromFile(@"c:\temp\"+dt[0]);
            }
            richTextBox1.Text = dt[1];
        }

        private void Form_paper_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (pictureBox1.Image != null)
            {
                pictureBox1.Image.Dispose();
                FileInfo file = new FileInfo(@"c:\temp\" + dt[0]);
                if (file.Exists)
                    file.Delete();
            }
        }
    }
}
