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
    public partial class Form_402b : Form
    {//공지사항팝업
        int sort;
        string row_id_temp = "";
        string chkgrid = "";
        string DB_TableName = "";
        Notice NoticeControl = new Notice();
        ksgcontrol Ksgcontrol = new ksgcontrol();

        public Form_402b(string ro_id, string btclick_data, string table_name)
        {
            InitializeComponent();
            Ksgcontrol.ControlInit(Config.DB_con1, null, null, null);
            DB_TableName = table_name;
            row_id_temp = ro_id;
            chkgrid = btclick_data;
            bReply.Visible = false;
            MySqlConnection DBConn;
            DBConn = new MySqlConnection(Config.DB_con1);
            DBConn.Open();
            string sQuery = "select * from " + DB_TableName + " where row_id = " + ro_id;
            var cmd = new MySqlCommand(sQuery, DBConn);
            var myRead = cmd.ExecuteReader();
            myRead.Read();

            if (btclick_data == "notice")
            {
                string notice_temp = myRead["notice"].ToString().Trim();
                string title_temp = myRead["title"].ToString();
                string temp = myRead["important"].ToString().Trim();
                bool important_temp = Convert.ToBoolean(temp);
                string date_temp = myRead["date_time"].ToString().Trim();

                tbName.Text = "관리자";
                tbDate.Text = date_temp;
                tbTitle.Text = title_temp;
                tbNotic.Text = notice_temp;

                if (important_temp == true)
                    chkBest.Checked = true;
                else
                    chkBest.Checked = false; 
            }
            else if (btclick_data == "qna")
            {
                bModify.Visible = false;
                bComplete.Visible = false;
                bReply.Visible = true;
                this.Text = "Q&A";
                this.tbTitle.Size = new System.Drawing.Size(532, 21);
                
                string notice_temp = myRead["notice"].ToString().Trim();
                string title_temp = myRead["title"].ToString();
                string sort_temp = myRead["sort_no"].ToString().Trim();
                string point_temp = myRead["point_no"].ToString().Trim();
                string hit_temp = myRead["hits"].ToString().Trim();
                string date_temp = myRead["date_time"].ToString().Trim();
                string name_temp = myRead["username"].ToString().Trim();

                if (point_temp != "0")
                    bReply.Visible = false;

                sort = Convert.ToInt32(sort_temp);

                tbTitle.Text = title_temp;
                tbNotic.Text = notice_temp;
                tbDate.Text = date_temp;
                tbName.Text = name_temp;

                if (tbName.Text == "관리자")
                {
                    bModify.Visible = true;
                    bComplete.Visible = true;
                }
            }

            else if(btclick_data == "faq")
            {
                this.Text = "FAQ";
                this.tbTitle.Size = new System.Drawing.Size(532, 21);
                string notice_temp = myRead["notice"].ToString().Trim();
                string title_temp = myRead["title"].ToString();
                string sort_temp = myRead["sort_no"].ToString().Trim();
                string point_temp = myRead["point_no"].ToString().Trim();
                string user_temp = myRead["username"].ToString().Trim();
                string date_temp = myRead["date_time"].ToString().Trim();
                if (point_temp != "0")
                    bReply.Visible = false;

                sort = Convert.ToInt32(sort_temp);

                tbDate.Text = date_temp;
                tbName.Text = user_temp;
                tbTitle.Text = title_temp;
                tbNotic.Text = notice_temp;
            }
            myRead.Close();
            DBConn.Close();
        }

        private void bCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Form_804b_Load(object sender, EventArgs e)
        {
            this.Location = new Point(277,10);  //좌/우,위/아래
            chkBest.Visible = false;
            bComplete.Visible = false;
            this.KeyPreview = true;
        }

        private void bReply_Click(object sender, EventArgs e)
        {
            Form_402a fm = new Form_402a("reply", sort, row_id_temp);
            fm.ShowDialog();
            this.Close();
        }

        private void bModify_Click(object sender, EventArgs e)
        {
            tbNotic.ReadOnly = false;
            tbTitle.ReadOnly = false;
            bComplete.Visible = true;
            bModify.Visible = false;
            if (chkgrid == "notice")
                chkBest.Visible = true;
            else if (chkgrid == "faq")
            {
                this.tbTitle.Size = new System.Drawing.Size(532, 21);
                chkBest.Visible = false;
            }
        }

        private void bComplete_Click(object sender, EventArgs e)
        {
            if (chkgrid == "notice")
            {
                string Query = "";
                if (chkBest.Checked == true)
                {
                    int point = NoticeControl.Point_no_increase(DB_TableName);
                    Query = "update " + DB_TableName + " set date_time = now(), title = '" + tbTitle.Text + "', notice = '" + tbNotic.Text.Trim() + "', important = true, point_no = " + point + " where row_id = " + row_id_temp;
                }
                else
                    Query = "update " + DB_TableName + " set date_time = now(), title = '" + tbTitle.Text + "', notice = '" + tbNotic.Text.Trim() + "', important = false, point_no = 0, popup = ' ' where row_id = " + row_id_temp;

                Ksgcontrol.DataUpdate(Query);
            }
            else if (chkgrid == "faq" || chkgrid == "qna")
            {
                string Query = "update " + DB_TableName + " set date_time = now(), title = '" + tbTitle.Text + "', notice = '" + tbNotic.Text.Trim() + "' where row_id = " + row_id_temp;
                Ksgcontrol.DataUpdate(Query);
            }
            this.Close();
        }

        private void Form_402b_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
                this.Close();
        }
    }
}
