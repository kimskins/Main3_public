using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace Dukyou3
{
    public partial class Form_imgview : Form
    {
        string row_id = "";
        string File_Path = "";
        string DB_TableName = "";
        Form_308 mom;
        int select_row;
        int picture_column;
        FileControl FC = new FileControl();

        public Form_imgview(string row_id, string file_path, string DB_name)
        {
            InitializeComponent();
            DB_TableName = DB_name;
            this.row_id = row_id;
            this.File_Path = file_path;

        }

        private void Form_imgview_Load(object sender, EventArgs e)
        {
            PictureRefresh();

            Screen srn = Screen.PrimaryScreen;
            int Xb = this.Width;  //좌,우
            int Yb = this.Height;
            this.Location = new Point((srn.Bounds.Width - Xb) / 2, (srn.Bounds.Height - Yb) / 2);  //좌/우,위/아래

            FC.FileControlInit(Config.DB_con1, Config.Ftp_ip1, Config.Ftp_id1, Config.Ftp_pw1);

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
                Ftp.DownLoadFile1(@sfd.FileName, DB_TableName +"\\"+ File_Path);
                MessageBox.Show(sfd.FileName + " 내려받기 완료");
            }
        }

        private void bPictureDel_Click(object sender, EventArgs e)
        {
            FC.OneFile2ManyRowId_Del(DB_TableName, "picture", row_id, "");
            this.DialogResult = DialogResult.OK;
            this.Close();

        }

        private void Form_imgview_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
                this.Close();
        }
    }
}
