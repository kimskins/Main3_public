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
    public partial class Form_304a : Form
    {
        string row_id = "";
        string File_Path = "";
        string DB_TableName = "C_coverwondan";
        Form_304 mom;
        int select_row;
        int picture_column;

        public Form_304a(string row_id, string file_path, int select_row, Form_304 mom, int picture_column)
        {
            InitializeComponent();

            this.row_id = row_id;
            this.File_Path = file_path;
            this.mom = mom;
            this.select_row = select_row;
            this.picture_column = picture_column;

        }

        private void Form_504a_Load(object sender, EventArgs e)
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
                Ftp.DownLoadFile1(@sfd.FileName, DB_TableName +"\\"+ File_Path);
                MessageBox.Show(sfd.FileName + " 내려받기 완료");
            }
        }

        private void bPictureDel_Click(object sender, EventArgs e)
        {
            //FileControl FC = new FileControl();
            //FC.FileControlInit(Config.DB_con1, Config.Ftp_ip1, Config.Ftp_id1, Config.Ftp_pw1);

            //string Query = "update "+DB_TableName+" set picture = '' where row_id = '"+row_id+"'";
            //FC.DataUpdate(Query);

            //Query = "select * from " + DB_TableName + " where picture='" + File_Path + "'";
            //var DBConn = new MySqlConnection(Config.DB_con1);
            //DBConn.Open();
            //var cmd = new MySqlCommand(Query, DBConn);
            //var myRead = cmd.ExecuteReader();


            //// Grid에서는 1번째 Row 지만 View_dt 에서는 0번째 Row 이다. 그래서 -1
            //// picture 컬럼이 아닌 picture 유무 컬럼을 변경해야하기 때문에 -1
            //mom.GridHandle.View_dt.Rows[select_row-1][picture_column-1] = "";  

            //if (myRead.Read())
            //{
            //    this.Close();  //다른 항목에서 그림을 참조하고 있으면 DB에서만 지우고 끝
            //}
            //else
            //{
            //    FC.FileDel(File_Path);// 다른 항목에서 그림을 참조하고 있지 않으면 File서버에서 삭제후 끝
            //    this.Close();
            //}

            mom.Del_Picture(select_row-1, row_id, File_Path);  // select row는 Grid 기준에서 받은 값이가. Grid 기준 시작은 1, DataTable 기준은 0 이기 때문에 -1 로 넘겨준다
           
            this.Close();

        }

        private void Form_304a_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
                this.Close();
        }
    }
}
