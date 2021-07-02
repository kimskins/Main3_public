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
    public partial class Form_305a : Form
    {
        string row_id = "";
        string File_Path = "";
        string DB_TableName = "C_bakwondan";
        Form_305 mom;
        int select_row;
        int picture_column;
        public Form_305a(string row_id, string file_path, int select_row, Form_305 mom, int picture_column)
        {
            InitializeComponent();


            this.row_id = row_id;
            this.File_Path = file_path;
            this.mom = mom;
            this.select_row = select_row;
            this.picture_column = picture_column;
        }

        private void Form_505a_Load(object sender, EventArgs e)
        {
            PictureRefresh();

            Screen srn = Screen.PrimaryScreen;
            int Xb = this.Width;  //좌,우
            int Yb = this.Height;
            this.Location = new Point((srn.Bounds.Width - Xb) / 2, (srn.Bounds.Height - Yb) / 2);  //좌/우,위/아래
        }

        public void PictureRefresh()
        {

            if (File_Path != "")
            {
                OhFTP Ftp = new OhFTP(Config.Ftp_ip1, Config.Ftp_id1, Config.Ftp_pw1);
                Ftp.DownLoadFile(@"c:\temp\", File_Path, DB_TableName);

                pictureBox1.ImageLocation = @"c:\temp\" + File_Path;

            }
            else
            {
                pictureBox1.Image = null;
            }
            pictureBox1.Refresh();
        }

        private void bPictureDown_Click(object sender, EventArgs e)
        {
            SaveFileDialog sfd = new SaveFileDialog();
            sfd.Title = "Save File";
            sfd.FileName = File_Path;
            sfd.Filter = "ALL File(*.*)|*.*";
            sfd.InitialDirectory = "C:\\";
            sfd.RestoreDirectory = true;

            if (sfd.ShowDialog() == DialogResult.OK)
            {
                OhFTP Ftp = new OhFTP(Config.Ftp_ip1, Config.Ftp_id1, Config.Ftp_pw1);
                Ftp.DownLoadFile1(@sfd.FileName, DB_TableName + "\\" + File_Path);
                MessageBox.Show(sfd.FileName + " 내려받기 완료");
            }
        }

        private void bPictureDel_Click(object sender, EventArgs e)
        {

            mom.Del_Picture(select_row - 1, row_id);  // select row는 Grid 기준에서 받은 값이가. Grid 기준 시작은 1, DataTable 기준은 0 이기 때문에 -1 로 넘겨준다
            this.Close();
        }
    }
}
