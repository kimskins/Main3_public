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
    public partial class Form_402 : Form
    {
        SourceGridControl GridHandle1 = new SourceGridControl();
        SourceGridControl GridHandle2 = new SourceGridControl();
        SourceGridControl GridHandle3 = new SourceGridControl();
        ksgcontrol Ksgcontrol = new ksgcontrol();
        string DB_TableName_Notice = "C_notice_board";
        string DB_TableName_Qna = "C_qna";

        public Form_402()
        {
            InitializeComponent();
            GridHandle1.SourceGrideInit(grid1, Config.DB_con1);
            GridHandle2.SourceGrideInit(grid2, Config.DB_con1);
            GridHandle3.SourceGrideInit(grid3, Config.DB_con1);
            Ksgcontrol.ControlInit(Config.DB_con1, null, null, null);
            string mQuery = "";
            mQuery = "select * from " + DB_TableName_Notice + " order by point_no desc, sort_no desc"; 
            //point_no 중요공지사항 위로
            grid1_view(mQuery, important_count());
            mQuery = "select * from " + DB_TableName_Qna + " where username = '관리자' and point_no = 0 order by sort_no desc";
            grid2_view(mQuery);
            mQuery = "select * from " + DB_TableName_Qna + " where company !='' order by sort_no desc, point_no";
            grid3_view(mQuery);
            date_g();
            if (grid1.RowsCount == 1)
            {
                string Query = "alter table " + DB_TableName_Notice + " auto_increment = 1";  //데이터가 없을때 row_id초기화
                Ksgcontrol.DataUpdate(Query);
            }
            else if (grid2.RowsCount == 1 && grid3.RowsCount == 1)
            {
                string Query = "alter table " + DB_TableName_Qna + " auto_increment = 1";
                Ksgcontrol.DataUpdate(Query);
            }
        }

        //공지사항 그리드
        public void grid1_view(string Query, int important_no)
        {
            cell_d cc = new cell_d();
            grid1.Rows.Clear();
            grid1.BorderStyle = BorderStyle.FixedSingle;
            grid1.SelectionMode = SourceGrid.GridSelectionMode.Row;
            grid1.ColumnsCount = 9;
            grid1.FixedRows = 0;
            grid1.Rows.Insert(0);
            grid1.Rows[0].Height = 24;

            grid1[0, 0] = new MyHeader1("row_id");
            grid1.Columns[0].Visible = false;
            grid1[0, 1] = new MyHeader1("√");
            grid1.Columns[1].Visible = true;
            grid1[0, 2] = new MyHeader1("no");
            
            grid1[0, 3] = new MyHeader1("제목");
            grid1[0, 4] = new MyHeader1("작성자");
            grid1[0, 5] = new MyHeader1("작성/수정 시간");
            grid1[0, 6] = new MyHeader1("important");
            grid1.Columns[6].Visible = false;
            grid1[0, 7] = new MyHeader1("sort_no");
            grid1.Columns[7].Visible = false;
            grid1[0, 8] = new MyHeader1("point_no");
            grid1.Columns[8].Visible = false;

            grid1.Columns[1].Width = 20;
            grid1.Columns[2].Width = 40;            
            grid1.Columns[3].Width = 380;
            grid1.Columns[4].Width = 86;
            grid1.Columns[5].Width = 110;

            MySqlConnection DBConn;
            DBConn = new MySqlConnection(Config.DB_con1);
            DBConn.Open();
            
            var cmd = new MySqlCommand(Query, DBConn);
            var myRead = cmd.ExecuteReader();
         
            int m = 1;
            while (myRead.Read())
            {
                grid1.Rows.Insert(m);
                grid1.Rows[m].Height = 20;

                grid1[m, 0] = new SourceGrid.Cells.Cell(myRead["row_id"].ToString(), typeof(string));
                grid1[m, 0].View = cc.center_cell;
                grid1[m, 1] = new SourceGrid.Cells.CheckBox(null, false);
                grid1[m, 2] = new SourceGrid.Cells.Cell((m).ToString(), typeof(string));
                grid1[m, 2].View = cc.center_cell;
                grid1[m, 2].Editor = cc.disable_cell;
                
                grid1[m, 3] = new SourceGrid.Cells.Cell(myRead["title"].ToString(), typeof(string));
                grid1[m, 3].Editor = cc.disable_cell;
                grid1[m, 3].View = cc.left_cell;
                grid1[m, 4] = new SourceGrid.Cells.Cell("관리자", typeof(string));
                grid1[m, 4].Editor = cc.disable_cell;
                grid1[m, 4].View = cc.center_cell;
                grid1[m, 5] = new SourceGrid.Cells.Cell(myRead["date_time"].ToString(), typeof(string));
                grid1[m, 5].Editor = cc.disable_cell;
                grid1[m, 5].View = cc.center_cell;
                string temp = myRead["important"].ToString();
                bool important_temp = Convert.ToBoolean(temp);
                    
                grid1[m, 6] = new SourceGrid.Cells.Cell(temp, typeof(string));
                if (important_temp == true)
                { 
                    grid1[m, 2].View = cc.center_cell_bold;
                    grid1[m, 3].View = cc.left_cell_bold;
                    grid1[m, 4].View = cc.center_cell_bold;
                    grid1[m, 5].View = cc.center_cell_bold;
                }
                grid1[m, 7] = new SourceGrid.Cells.Cell(myRead["sort_no"].ToString(), typeof(string));
                grid1[m, 8] = new SourceGrid.Cells.Cell(myRead["point_no"].ToString(), typeof(string));

                m++;
            }
            myRead.Close();
            DBConn.Close();
            grid1.Selection.EnableMultiSelection = false;
        }

        private void bWrite_Click(object sender, EventArgs e)
        {
            Form_402a fm = new Form_402a("notice", 0, null);
            fm.ShowDialog();
            string mQuery = "select * from " + DB_TableName_Notice + " order by point_no desc, sort_no desc";
            grid1_view(mQuery, important_count());
        }

        private void bDelete_Click_1(object sender, EventArgs e)
        {
            if (MessageBox.Show("삭제하시겠습니까?", "메세지창", MessageBoxButtons.YesNo) == DialogResult.Yes)
                GridHandle1.ChkDataDelete(DB_TableName_Notice, 1, 0, 1);
        }

        private void Form_804_Load(object sender, EventArgs e)
        {
            Screen srn = Screen.PrimaryScreen;
            int Xb = this.Width;  //좌,우
            this.Location = new Point((srn.Bounds.Width - Xb) / 2, 1);  //좌/우,위/아래
            int index = cbSearch.FindString("제목");
            cbSearch.SelectedIndex = index;
            cbFaQ.SelectedIndex = index;
        }

        public void bSearch_Click(object sender, EventArgs e)
        {
            string chtext = cbSearch.Text;
            string Query = "";
            if(chtext == "내용")
                Query = "select * from " + DB_TableName_Notice + " where notice like '%" + tbSearch.Text.Trim() + "%' order by point_no desc, sort_no desc";

            else if(chtext == "제목")
                Query = "select * from " + DB_TableName_Notice + " where title like '%" + tbSearch.Text.Trim() + "%' order by point_no desc, sort_no desc";

            if(tbSearch.Text.Trim() == "")
            {
                string mQuery = "select * from " + DB_TableName_Notice + " order by point_no desc, sort_no desc";
                grid1_view(mQuery, important_count());
                return;
            }
            grid1_view(Query, important_count());
        }

        private void Search(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                bSearch_Click(sender, e);
        }

        private void bClear_Click(object sender, EventArgs e)
        {
            tbSearch.Clear();
            string mQuery = "select * from " + DB_TableName_Notice + " order by point_no desc, sort_no desc";
            grid1_view(mQuery, important_count());
        }

        public void grid2_view(string Query)
        {
            cell_d cc = new cell_d();
            grid2.Rows.Clear();
            grid2.BorderStyle = BorderStyle.FixedSingle;
            grid2.SelectionMode = SourceGrid.GridSelectionMode.Row;
            grid2.ColumnsCount = 5;
            grid2.FixedRows = 1;
            grid2.Rows.Insert(0);
            grid2.Rows[0].Height = 24;

            grid2[0, 0] = new MyHeader1("번호");
            grid2.Columns[0].Visible = false;

            grid2[0, 1] = new MyHeader1("√");
            grid2.Columns[1].Visible = true;
            
            grid2[0, 2] = new MyHeader1("no");
            grid2.Columns[2].Visible = true;

            grid2[0, 3] = new MyHeader1("제목");
            grid2[0, 4] = new MyHeader1("작성시간");

            grid2.Columns[1].Width = 20;
            grid2.Columns[2].Width = 30;
            grid2.Columns[3].Width = 450;
            grid2.Columns[4].Width = 113;

            MySqlConnection DBConn;
            DBConn = new MySqlConnection(Config.DB_con1);
            DBConn.Open();
            var cmd = new MySqlCommand(Query, DBConn);
            var myRead = cmd.ExecuteReader();

            int m = 1;
            while (myRead.Read())
            {
                grid2.Rows.Insert(m);
                grid2.Rows[m].Height = 20;


                grid2[m, 0] = new SourceGrid.Cells.Cell(myRead["row_id"].ToString(), typeof(string));
                grid2[m, 0].View = cc.center_cell;
                grid2[m, 1] = new SourceGrid.Cells.CheckBox(null, false);                
                grid2[m, 2] = new SourceGrid.Cells.Cell((m).ToString(), typeof(string));
                grid2[m, 2].View = cc.center_cell;
                grid2[m, 2].Editor = cc.disable_cell;

                grid2[m, 3] = new SourceGrid.Cells.Cell(myRead["title"].ToString(), typeof(string));
                grid2[m, 3].Editor = cc.disable_cell;

                grid2[m, 4] = new SourceGrid.Cells.Cell(myRead["date_time"].ToString(), typeof(string));
                grid2[m, 4].Editor = cc.disable_cell;
                grid2[m, 4].View = cc.center_cell;
                m++;
            }
            myRead.Close();
            DBConn.Close();
            grid2.Selection.EnableMultiSelection = false;
        }

        public void grid3_view(string Query)
        {
            cell_d cc = new cell_d();
            grid3.Rows.Clear();
            grid3.BorderStyle = BorderStyle.FixedSingle;
            grid3.SelectionMode = SourceGrid.GridSelectionMode.Row;
            grid3.ColumnsCount = 10;
            grid3.FixedRows = 1;
            grid3.Rows.Insert(0);
            grid3.Rows[0].Height = 24;

            grid3[0, 0] = new MyHeader1("row_id");
            grid3.Columns[0].Visible = false;
            grid3[0, 1] = new MyHeader1("√");
            grid3.Columns[1].Visible = true;            
            grid3[0, 2] = new MyHeader1("no");
            grid3.Columns[2].Visible = true;

            grid3[0, 3] = new MyHeader1("제목");
            grid3[0, 4] = new MyHeader1("작성자");
            grid3[0, 5] = new MyHeader1("회사");
            grid3[0, 6] = new MyHeader1("작성시간");
            grid3[0, 7] = new MyHeader1("sort_no");
            grid3.Columns[7].Visible = false;
            grid3[0, 8] = new MyHeader1("point_no");
            grid3.Columns[8].Visible = false;
            grid3[0, 9] = new MyHeader1("replycount");
            grid3.Columns[9].Visible = false;

            grid3.Columns[1].Width = 20;
            grid3.Columns[2].Width = 30;
            grid3.Columns[3].Width = 250;
            grid3.Columns[4].Width = 84;
            grid3.Columns[5].Width = 121;
            grid3.Columns[6].Width = 108;

            MySqlConnection DBConn;
            DBConn = new MySqlConnection(Config.DB_con1);
            DBConn.Open();
            var cmd = new MySqlCommand(Query, DBConn);
            var myRead = cmd.ExecuteReader();

            int m = 1;
            while (myRead.Read())
            {
                grid3.Rows.Insert(m);
                grid3.Rows[m].Height = 20;

                grid3[m, 0] = new SourceGrid.Cells.Cell(myRead["row_id"].ToString(), typeof(string));
                grid3[m, 0].View = cc.center_cell;
                grid3[m, 1] = new SourceGrid.Cells.CheckBox(null, false);               

                grid3[m, 2] = new SourceGrid.Cells.Cell((m).ToString(), typeof(string));
                grid3[m, 2].View = cc.center_cell;
                grid3[m, 2].Editor = cc.disable_cell;

                grid3[m, 3] = new SourceGrid.Cells.Cell(myRead["title"].ToString(), typeof(string));
                grid3[m, 3].Editor = cc.disable_cell;

                grid3[m, 4] = new SourceGrid.Cells.Cell(myRead["username"].ToString(), typeof(string));
                grid3[m, 4].Editor = cc.disable_cell;
                grid3[m, 4].View = cc.center_cell;

                grid3[m, 5] = new SourceGrid.Cells.Cell(myRead["company"].ToString(), typeof(string));
                grid3[m, 5].Editor = cc.disable_cell;
                grid3[m, 5].View = cc.center_cell;

                grid3[m, 6] = new SourceGrid.Cells.Cell(myRead["date_time"].ToString(), typeof(string));
                grid3[m, 6].Editor = cc.disable_cell;
                grid3[m, 6].View = cc.center_cell;

                grid3[m, 7] = new SourceGrid.Cells.Cell(myRead["sort_no"].ToString(), typeof(string));
                grid3[m, 8] = new SourceGrid.Cells.Cell(myRead["point_no"].ToString(), typeof(string));
                grid3[m, 9] = new SourceGrid.Cells.Cell(myRead["replycount"].ToString(), typeof(string));
                
                m++;
            }
            myRead.Close();
            DBConn.Close();
            grid3.Selection.EnableMultiSelection = false;
        }
        public void date_g() //중요 공지사항 노출 시간
        {
            DateTime nowdate = DateTime.Now;
            for (int i = 1; i < grid1.RowsCount; i++)
            {
                string date = grid1[i, 5].ToString();
                string ro_id = grid1[i, 0].ToString();
                DateTime date_convert = Convert.ToDateTime(date);
                TimeSpan date_diff = nowdate - date_convert;
                int dy = date_diff.Days;

                if(dy >=7) //7일 후에 중요 표시 해제
                {
                    string Query = "update " + DB_TableName_Notice + " set important = false where row_id = " + ro_id;
                    Ksgcontrol.DataUpdate(Query);
                }
            }
            string mQuery = "select * from " + DB_TableName_Notice + " order by point_no desc, sort_no desc";
            grid1_view(mQuery, important_count());
        }

        private void bQnaDelete_Click(object sender, EventArgs e)
        {
            string Query = "";
            if (MessageBox.Show("삭제하시겠습니까?", "메세지창", MessageBoxButtons.YesNo) == DialogResult.Yes)
            for(int i=1; i<grid3.RowsCount; i++)
            {
                if (grid3[i, 1].ToString() == "True" && grid3[i,9].ToString() == "0")   //답변삭제
                {
                    string sort_temp = grid3[i, 7].ToString();
                    string point_temp = grid3[i, 8].ToString();
                    Query = "delete from " + DB_TableName_Qna + " where sort_no = " + sort_temp + " and point_no =" + point_temp;
                    Ksgcontrol.DataUpdate(Query);

                        Query = "update " + DB_TableName_Qna + " set replycount = replycount-1 where sort_no = " + sort_temp + " and point_no =0";
                    Ksgcontrol.DataUpdate(Query);                   
                }
                else if(grid3[i, 1].ToString() == "True" && grid3[i,9].ToString() != "0")
                {
                    
                    Query = "delete from " + DB_TableName_Qna + " where sort_no = " + grid3[i, 7].ToString().Trim();
                    Ksgcontrol.DataUpdate(Query);
                }
            }

            string mQuery = "";

            mQuery = "select * from " + DB_TableName_Qna + " where company !='' order by sort_no desc, point_no";
            grid3_view(mQuery);
        }

        public int important_count() //important count
        {
            string Query = "select count(important) from " + DB_TableName_Notice + " where important = true";
            MySqlConnection DBConn;
            DBConn = new MySqlConnection(Config.DB_con1);
            DBConn.Open();
            var cmd = new MySqlCommand(Query, DBConn);
            var myRead = cmd.ExecuteReader();

            myRead.Read();

            int important_count;
            string important_temp = myRead["count(important)"].ToString();
            if (important_temp == "")
                important_count = 0;
            else
                important_count = Convert.ToInt32(important_temp) + 1;

            myRead.Close();
            DBConn.Close();
            return important_count;
        }

        private void bSearchFaq_Click(object sender, EventArgs e)
        {
            string chtext = cbFaQ.Text.Trim();
            string Query = "";
            if (chtext == "내용")
                Query = "select * from " + DB_TableName_Qna + " where notice like '%" + tbFaQ.Text.Trim() + "%' and username = '관리자' and point_no = 0 order by sort_no desc";

            else if (chtext == "제목")
                Query = "select * from " + DB_TableName_Qna + " where title like '%" + tbFaQ.Text.Trim() + "%' and username = '관리자' and point_no = 0 order by sort_no desc";

            if (tbFaQ.Text.Trim() == "")
            {
                string mQuery = "select * from " + DB_TableName_Qna + " where username = '관리자' and point_no = 0 order by sort_no desc";
                grid2_view(mQuery);
                return;
            }
            grid2_view(Query);
        }

        private void bClearFaQ_Click(object sender, EventArgs e)
        {
            tbFaQ.Clear();
            string mQuery = "select * from " + DB_TableName_Qna + " where username = '관리자' and point_no = 0 order by sort_no desc";
            grid2_view(mQuery);
        }

        private void tbFaQ_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                bSearchFaq_Click(sender, e);
        }

        private void bDeleteFaQ_Click(object sender, EventArgs e)
        {
            if (grid2.RowsCount == 1)
            {
                MessageBox.Show("삭제할 데이터가 없습니다.");
                return;
            }

            if (MessageBox.Show("삭제하시겠습니까?", "메세지창", MessageBoxButtons.YesNo) == DialogResult.Yes)
                GridHandle2.ChkDataDelete(DB_TableName_Qna, 1, 0, 1);

            string mQuery = "";
            mQuery = "select * from " + DB_TableName_Notice + " order by point_no desc, sort_no desc";
            grid1_view(mQuery, important_count());
            mQuery = "select * from " + DB_TableName_Qna + " where username = '관리자' and point_no = 0 order by sort_no desc";
            grid2_view(mQuery);
            mQuery = "select * from " + DB_TableName_Qna + " where company !='' order by sort_no desc, point_no";
            grid3_view(mQuery);
        }

        private void bSearchQna_Click(object sender, EventArgs e)
        {
            string Query = "";
            string cli_row_temp = "";

            MySqlConnection DBConn;
            DBConn = new MySqlConnection(Config.DB_con1);
            DBConn.Open();

            if (tbQna.Text.Trim() == "")
            {
                string mQuery = "select * from " + DB_TableName_Qna + " where company !='' order by sort_no desc, point_no";
                grid3_view(mQuery);
                return;
            }

            Query = "select cli_row from " + DB_TableName_Qna + " where username like '%" + tbQna.Text.Trim() + "%'";
            var cmd = new MySqlCommand(Query, DBConn);
            var myRead = cmd.ExecuteReader();
            myRead.Read();
            if (myRead.Read() == false) //
            {
                MessageBox.Show("검색 결과가 없습니다");
                string mQuery = "select * from " + DB_TableName_Qna + " where company !='' order by sort_no desc, point_no";
                grid3_view(mQuery);
                myRead.Close();
                DBConn.Close();
                return;
            }
            cli_row_temp = myRead["cli_row"].ToString().Trim();
            myRead.Close();
            DBConn.Close();
            Query = "select * from " + DB_TableName_Qna + " where cli_row = " + cli_row_temp + " or username like '%" + tbQna.Text.Trim() + "%' and company !='' order by sort_no desc, point_no";
            grid3_view(Query);
        }

        private void bClearQna_Click(object sender, EventArgs e)
        {
            tbFaQ.Clear();
            string mQuery = "select * from " + DB_TableName_Qna + " where company !='' order by sort_no desc, point_no";
            grid3_view(mQuery);
        }

        private void bWriteFaQ_Click(object sender, EventArgs e)
        {
            Form_402a fm = new Form_402a("faq", 0, null);
            fm.ShowDialog();
            string mQuery = "";
            mQuery = "select * from " + DB_TableName_Qna + " where username = '관리자' and point_no = 0 order by sort_no desc";
            grid2_view(mQuery);
        }

        private void grid2_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            grid2.Focus();
            if (GridHandle1.grid_area(sender, e) == false)
                return;
            if (grid2.Selection.ActivePosition.Row == -1)
                return;
            string r_id = grid2[grid2.Selection.ActivePosition.Row, 0].ToString();

            Form_402b noticeLoad = new Form_402b(r_id, "faq", DB_TableName_Qna);
            noticeLoad.ShowDialog();
            string mQuery = "";
            mQuery = "select * from " + DB_TableName_Qna + " where username = '관리자' and point_no = 0 order by sort_no desc";
            grid2_view(mQuery);
        }

        private void tbQna_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                bSearchQna_Click(sender, e);
        }

        private void bNoReply_Click(object sender, EventArgs e)
        {
            string mQuery = "select * from " + DB_TableName_Qna + " where company !='' and replycount = 0 and point_no = 0 order by sort_no desc, point_no";
            grid3_view(mQuery);
        }

        private void grid1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            grid1.Focus();
            if (GridHandle1.grid_area(sender, e) == false)
                return;
            if (grid1.Selection.ActivePosition.Row == -1)
                return;

            string r_id = grid1[grid1.Selection.ActivePosition.Row, 0].ToString();
            Form_402b noticeLoad = new Form_402b(r_id, "notice", DB_TableName_Notice);
            noticeLoad.ShowDialog();
            string mQuery = "";
            
            if (tbSearch.Text.Trim() == "")
                mQuery = "select * from " + DB_TableName_Notice + " order by point_no desc, sort_no desc";
            else
            {
                if (cbSearch.Text.Trim() == "내용")
                    mQuery = "select * from " + DB_TableName_Notice + " where notice like '%" + tbSearch.Text.Trim() + "%' order by point_no desc, sort_no desc";

                else if (cbSearch.Text.Trim() == "제목")
                    mQuery = "select * from " + DB_TableName_Notice + " where title like '%" + tbSearch.Text.Trim() + "%' order by point_no desc, sort_no desc";
            }
            grid1_view(mQuery, important_count());
        }

        private void grid3_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            grid3.Focus();
            if (GridHandle1.grid_area(sender, e) == false)
                return;
            if (grid3.Selection.ActivePosition.Row == -1)
                return;

            string r_id = grid3[grid3.Selection.ActivePosition.Row, 0].ToString();
            string s_no = grid3[grid3.Selection.ActivePosition.Row, 7].ToString();
            string p_no = grid3[grid3.Selection.ActivePosition.Row, 8].ToString();

            string Query = "";
            if (p_no == "0")
            {
                Query = "update " + DB_TableName_Qna + " set hits = hits+1 where row_id = " + r_id;
                Ksgcontrol.DataUpdate(Query);

                Form_402b noticeLoad = new Form_402b(r_id, "qna", DB_TableName_Qna);
                noticeLoad.ShowDialog();
            }
            else
            {
                Form_402b noticeLoad = new Form_402b(r_id, "qna", DB_TableName_Qna);
                noticeLoad.ShowDialog();
            }
            string mQuery = "select * from " + DB_TableName_Qna + " where company !='' order by sort_no desc, point_no";
            grid3_view(mQuery);
        }

        private void grid1_MouseDown(object sender, MouseEventArgs e)
        {
            var position = new SourceGrid.Position(-1, 0);
            grid2.Selection.Focus(position, true);
            grid3.Selection.Focus(position, true);
        }

        private void grid2_MouseDown(object sender, MouseEventArgs e)
        {
            var position = new SourceGrid.Position(-1, 0);
            grid1.Selection.Focus(position, true);
            grid3.Selection.Focus(position, true);
        }

        private void grid3_MouseDown(object sender, MouseEventArgs e)
        {
            var position = new SourceGrid.Position(-1, 0);
            grid2.Selection.Focus(position, true);
            grid1.Selection.Focus(position, true);
        }
    }
}