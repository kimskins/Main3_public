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
    public partial class Form_402a : Form
    {//공지사항 insert
        Notice NoticeControl = new Notice();
        ksgcontrol Ksgcontrol = new ksgcontrol();
        string DB_TableName_Notice = "C_notice_board";
        string DB_TableName_Qna = "C_qna";
        string replycount_temp = "";    //답변갯수
        string row_id_temp = "";
        string cli_row_temp = "";
        int sort_no_temp;

        public Form_402a(string btclick_data, int sort_no, string row_id)
        {
            InitializeComponent();
            Ksgcontrol.ControlInit(Config.DB_con1, null, null, null);
            sort_no_temp = sort_no;
            row_id_temp = row_id;
            this.KeyPreview = true;
            if (btclick_data == "notice")
            {
                chkBest.Visible = true;
                bComplete.Visible = true;
            }
            else if (btclick_data == "faq")
                bCompletefaq.Visible = true;

            else if (btclick_data == "reply")
            {
                bCompletereply.Visible = true;
                this.tbTitle.Size = new System.Drawing.Size(532, 21);
                MySqlConnection DBConn;
                DBConn = new MySqlConnection(Config.DB_con1);
                DBConn.Open();
                string sQuery = "select * from " + DB_TableName_Qna + " where row_id = " + row_id;
                var cmd = new MySqlCommand(sQuery, DBConn);
                var myRead = cmd.ExecuteReader();
                myRead.Read();
                string title_temp = myRead["title"].ToString().Trim();
                string notice_temp = myRead["title"].ToString().Trim();
                replycount_temp = myRead["replycount"].ToString().Trim();
                cli_row_temp = myRead["cli_row"].ToString().Trim();
                tbTitle.Text = title_temp;
                tbNote.Text = notice_temp;
                myRead.Close();
                DBConn.Close();
            }
        }
       
        public int Sort_no_Increase(string db_name)
        {
            string Query = "select max(sort_no) from " + db_name;
            MySqlConnection DBConn;
            DBConn = new MySqlConnection(Config.DB_con1);
            DBConn.Open();
            var cmd = new MySqlCommand(Query, DBConn);
            var myRead = cmd.ExecuteReader();

            myRead.Read();
            int Sort_no;

            string max_sort_no = myRead["max(sort_no)"].ToString();
            if (max_sort_no == "")
                Sort_no = 0;
            else
                Sort_no = Convert.ToInt32(max_sort_no) + 1;

            myRead.Close();
            DBConn.Close();
            return Sort_no;
        }

        private void bCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void bComplete_Click(object sender, EventArgs e)
        {
            if (tbTitle.Text == "" || tbTitle.Text.Trim() == "")
            {
                MessageBox.Show("제목을 입력하세요");
                return;
            }
            else if (tbNote.Text == "" || tbNote.Text.Trim() == "")
            {
                MessageBox.Show("내용을 입력하세요");
                return;
            }

            int Sort_no_temp = Sort_no_Increase(DB_TableName_Notice);
            int Point_no_temp = NoticeControl.Point_no_increase(DB_TableName_Notice);
            string iQuery = "";
            
            if (chkBest.Checked == true)
            {
                if (Point_no_temp == 0)
                    Point_no_temp = Point_no_temp + 1;

                iQuery = "insert into " + DB_TableName_Notice + "(title, notice, date_time, important, sort_no, point_no, popup) values('" + tbTitle.Text.Trim() + "', '" + tbNote.Text.Trim() + "', now(), 1, " + Sort_no_temp + "," + Point_no_temp + ",' ')";
                Ksgcontrol.DataUpdate(iQuery);
            }
            else
            {
                iQuery = "insert into " + DB_TableName_Notice + "(title, notice, date_time, important, sort_no, popup) values('" + tbTitle.Text.Trim() + "', '" + tbNote.Text.Trim() + "', now(), 0, " + Sort_no_temp + ",' ')";
                Ksgcontrol.DataUpdate(iQuery);
            }
            this.Close();
        }

        private void bCompletefaq_Click(object sender, EventArgs e)
        {
            if (tbTitle.Text == "" || tbTitle.Text.Trim() == "")
            {
                MessageBox.Show("제목을 입력하세요");
                return;
            }
            else if (tbNote.Text == "" || tbNote.Text.Trim() == "")
            {
                MessageBox.Show("내용을 입력하세요");
                return;
            }

            int Sort_no_temp = Sort_no_Increase(DB_TableName_Qna);
            string Query = "insert into " + DB_TableName_Qna + "(title, notice, date_time, sort_no, username) values('" + tbTitle.Text.Trim() + "', '" + tbNote.Text.Trim() + "', now(), " + Sort_no_temp + ", '관리자')";
            Ksgcontrol.DataUpdate(Query);

            this.Close();
        }

        private void bCompletereply_Click(object sender, EventArgs e)
        {
            if (tbTitle.Text.Trim() == "" || tbTitle.Text.Trim() == "")
            {
                MessageBox.Show("제목을 입력하세요");
                return;
            }
            else if (tbNote.Text == "" || tbNote.Text.Trim() == "")
            {
                MessageBox.Show("내용을 입력하세요");
                return;
            }
            int p_m = NoticeControl.Point_no_increase(DB_TableName_Qna + " where sort_no = " + sort_no_temp);
            string Query = "";
            int replycount_in = Convert.ToInt32(replycount_temp) + 1;
            Query = "update " + DB_TableName_Qna + " set replycount = " + replycount_in + " where row_id = " + row_id_temp;
            Ksgcontrol.DataUpdate(Query);
            Query = "insert into " + DB_TableName_Qna + "(cli_row, username, title, notice, date_time, sort_no, point_no, company) values(" + cli_row_temp + ",'관리자',' ┗ " + tbTitle.Text + "','" + tbNote.Text + "',now()," + sort_no_temp + "," + p_m + ",'관리자')";
            Ksgcontrol.DataUpdate(Query);
            this.Close();
        }

        private void Form_402a_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
                this.Close();
        }
    }
}