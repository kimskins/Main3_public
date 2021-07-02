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
    public partial class Form_data_file : Form
    {

        SourceGrid.Cells.Controllers.CustomEvents ValueChangedEvent1 = new SourceGrid.Cells.Controllers.CustomEvents();
        SourceGrid.Cells.Controllers.CustomEvents ClickEvent1 = new SourceGrid.Cells.Controllers.CustomEvents();

        string DB_L_jumoon2 = "L_jumoon2";                         //접수파일
        string DB_L_customer = "L_customer";
        string DB_C_dealer_jumoon2 = "C_dealer_jumoon2";           //딜러주문파일
        string DB_C_img_total_manage = "C_img_total_manage";       //image 파일관리
        string DB_C_img_confirm_manage = "C_img_confirm_manage";   //confirm link 파일
        string DB_C_client = "C_client";
        int row_int = 0;
        public Form_data_file()
        {
            InitializeComponent();
        }

        private void Form_data_file_Load(object sender, EventArgs e)
        {
            Screen srn = Screen.PrimaryScreen;
            int Xb = this.Width;  //좌,우
            this.Location = new Point((srn.Bounds.Width - Xb) / 2, 1);  //좌/우,위/아래
            //
            auto_delete();
            make_grid1();
        }

        private void auto_delete()  //자동 삭제일 해당파일 삭제
        {
            string cQuery = "";
            var DBConn_C = new MySqlConnection(Config.DB_con1);
            util.Con_DB_Open(ref DBConn_C);
            DataTable temp = new DataTable();
            cQuery = " select row_id from " + DB_C_img_total_manage;
            cQuery += " where save_id='0' and auto_delete_day<=curdate() and f_option='won_file' and auto_delete_day<>'0000-00-00' and auto_delete_day is not null";
            //
            MySqlDataAdapter returnVal = new MySqlDataAdapter(cQuery, DBConn_C);
            returnVal.Fill(temp);
            returnVal.Dispose();
            if (temp.Rows.Count == 0)
            {
                DBConn_C.Close();
                return;
            }
            //
            string row_no = "";
            for (int i = 0; i < temp.Rows.Count; i++)
            {
                row_no = temp.Rows[i]["row_id"].ToString();
                cQuery = " delete from " + DB_C_img_total_manage + " where row_id='" + row_no + "' or won_row_id='" + row_no + "';";
                cQuery += " delete from " + DB_C_img_confirm_manage + " where int_id='" + row_no + "'";
                //                        
                var cmd = new MySqlCommand(cQuery, DBConn_C);
                cmd.ExecuteNonQuery();
            }
            DBConn_C.Close();
        }

        public void make_grid1()  // 
        {
            cell_d cc = new cell_d();
            DevAge.Drawing.BorderLine border_l = new DevAge.Drawing.BorderLine(Color.FromArgb(93, 93, 93), 1);
            DevAge.Drawing.BorderLine border_r = new DevAge.Drawing.BorderLine(Color.FromArgb(210, 210, 210), 0);
            DevAge.Drawing.BorderLine top = new DevAge.Drawing.BorderLine(Color.FromArgb(210, 210, 210), 0);
            DevAge.Drawing.BorderLine bottom = new DevAge.Drawing.BorderLine(Color.FromArgb(210, 210, 210), 1);
            DevAge.Drawing.RectangleBorder border1 = new DevAge.Drawing.RectangleBorder(top, bottom, border_r, border_l);
            //cEventHelper.RemoveAllEventHandlers(ValueChangedEvent1);
            //cEventHelper.RemoveAllEventHandlers(ClickEvent1);
            //  
            SourceGrid.Cells.Views.Cell mmm = new SourceGrid.Cells.Views.Cell();// cc.center_cell;
            mmm.Border = border1;
            mmm.TextAlignment = DevAge.Drawing.ContentAlignment.MiddleCenter;
            //
            SourceGrid.Cells.Views.Cell mmm_l = new SourceGrid.Cells.Views.Cell();// cc.Left_cell;
            mmm_l.Border = border1;
            mmm_l.TextAlignment = DevAge.Drawing.ContentAlignment.MiddleLeft;
            //
            SourceGrid.Cells.Views.Cell viewImage = new SourceGrid.Cells.Views.Cell();
            viewImage.BackColor = Color.FromArgb(240, 248, 255);
            viewImage.ImageAlignment = DevAge.Drawing.ContentAlignment.MiddleCenter;
            // 
            grid1.Rows.Clear();
            grid1.BorderStyle = BorderStyle.FixedSingle;
            grid1.SelectionMode = SourceGrid.GridSelectionMode.Cell;
            grid1.ColumnsCount = 29;
            grid1.FixedRows = 1;
            grid1.Rows.Insert(0);
            grid1.Rows[0].Height = 32;
            grid1.Selection.FocusStyle = grid1.Selection.FocusStyle | SourceGrid.FocusStyle.RemoveSelectionOnLeave;
            //
            grid1[0, 0] = new MyHeader1("row_id");
            grid1.Columns[0].Visible = false;
            grid1[0, 1] = new MyHeader1("√");
            grid1[0, 2] = new MyHeader1("No");
            //
            grid1[0, 3] = new MyHeader1("접수일");
            grid1[0, 4] = new MyHeader1("거래처명");
            grid1[0, 5] = new MyHeader1("제 작 명");
            grid1[0, 6] = new MyHeader1("사이즈");
            grid1[0, 7] = new MyHeader1("상,좌");
            grid1[0, 8] = new MyHeader1("판형");
            grid1[0, 9] = new MyHeader1("절수");
            //
            grid1[0, 10] = new MyHeader3("항 목(메모)");
            grid1[0, 11] = new MyHeader1("원본파일");
            grid1[0, 12] = new MyHeader1("등록일");
            grid1[0, 13] = new MyHeader3("작성자");
            grid1[0, 14] = new MyHeader1("PDF변환파일");
            grid1[0, 15] = new MyHeader1("등록일");
            grid1[0, 16] = new MyHeader1("작성자");
            grid1[0, 17] = new MyHeader3("컨펌" + "\r\n" + "요청");
            grid1[0, 18] = new MyHeader1("PDF" + "\r\n" + "컨펌");
            grid1[0, 19] = new MyHeader1("컨펌시간");
            grid1[0, 20] = new MyHeader3("컨펌" + "\r\n" + "승인자");
            grid1[0, 21] = new MyHeader1("자동삭제예정일");
            grid1[0, 22] = new MyHeader1("int_id");
            grid1.Columns[22].Visible = false;
            grid1[0, 23] = new MyHeader1("db_nm");
            grid1.Columns[23].Visible = false;
            //
            grid1[0, 24] = new MyHeader1("won_row_id");
            grid1.Columns[24].Visible = false;
            grid1[0, 25] = new MyHeader1("w_server_file");
            grid1.Columns[25].Visible = false;
            grid1[0, 26] = new MyHeader1("p_server_file");
            grid1.Columns[26].Visible = false;
            grid1[0, 27] = new MyHeader1("brow_id");
            grid1.Columns[27].Visible = false;
            grid1[0, 28] = new MyHeader1("영구" + "\r\n" + "보관");
            //
            grid1.Columns[0].Width = 100;   //row_id
            grid1.Columns[1].Width = 22;    //√
            grid1.Columns[2].Width = 35;    //No
            grid1.Columns[3].Width = 86;    //접수일
            grid1.Columns[4].Width = 100;    //거래처명
            grid1.Columns[5].Width = 100;    //제작명
            grid1.Columns[6].Width = 60;    //사이즈
            grid1.Columns[7].Width = 40;    //상,좌
            grid1.Columns[8].Width = 40;    //판형
            grid1.Columns[9].Width = 40;    //절수
            //
            grid1.Columns[10].Width = 100;   //항목(메모)
            grid1.Columns[11].Width = 148;   //원본파일
            grid1.Columns[12].Width = 86;    //등록일
            grid1.Columns[13].Width = 60;    //작성자
            grid1.Columns[14].Width = 148;   //PDF변환파일
            grid1.Columns[15].Width = 86;    //등록일
            grid1.Columns[16].Width = 60;    //작성자
            grid1.Columns[17].Width = 50;   //PDF컨펌(o,x)
            grid1.Columns[18].Width = 50;   //PDF컨펌(o,x)
            grid1.Columns[19].Width = 90;   //컨펌시간
            grid1.Columns[20].Width = 60;   //컨펌승인자
            grid1.Columns[21].Width = 100;   //자동삭제예정일
            grid1.Columns[22].Width = 100;   //int_id
            grid1.Columns[23].Width = 100;   //db_nm
            grid1.Columns[24].Width = 100;   //won_row_id
            grid1.Columns[25].Width = 100;   //w_server_file
            grid1.Columns[26].Width = 100;   //p_server_file
            grid1.Columns[27].Width = 100;   //brow_id
            grid1.Columns[28].Width = 40;    //save_id
            //
            var DBCons = new MySqlConnection(Config.DB_con1);
            util.Con_DB_Open(ref DBCons);
            var DBConn = new MySqlConnection(Config.DB_con2);
            util.Con_DB_Open(ref DBConn);
            string cQuery = "";
            //
            string[] s = new string[4];
            s[0] = "";
            s[1] = "";
            s[2] = "";
            s[3] = "";
            if (!string.IsNullOrEmpty(tbIn_day1.Text))
                s[0] = " and a.jubsu_day>='" + tbIn_day1.Text + "'";
            if (!string.IsNullOrEmpty(tbIn_day2.Text))
                s[1] = " and a.jubsu_day<='" + tbIn_day2.Text + "'";
            //
            cQuery = " select a.row_id,a.server_file,a.user_file,a.f_option,a.comment,a.update_time,a.auto_delete_day";
            cQuery += ",a.won_row_id,a.edit_name,a.won_row_id,a.db_nm,a.int_id,a.jubsu_day,a.save_id";
            cQuery += ",b.row_id as b_row_id,b.req_confirm,b.confirm,b.confirm_time,b.confirm_name,b.row_id as brow_id";
            cQuery += ",c.item,c.c_size,c.c_left,c.c_kook,c.c_julsu,d.name from " + DB_C_img_total_manage + " as a";
            cQuery += " left outer join " + DB_C_img_confirm_manage + " as b on a.row_id = b.int_id ";
            cQuery += " left outer join " + DB_C_dealer_jumoon2 + " as c on a.int_id = c.row_id and a.db_nm='C_dealer_jumoon2'";
            cQuery += " left outer join " + DB_C_client + " as d on a.client_id = d.row_id";
            cQuery += " where a.row_id>0 " + s[0] + s[1];
            cQuery += " order by a.int_id,a.db_nm";
            //
            DataTable temp1 = new DataTable();
            DataTable temp2 = new DataTable();
            DataTable l_jumoon2 = new DataTable();
            MySqlDataAdapter returnVal = new MySqlDataAdapter(cQuery, DBCons);
            returnVal.Fill(temp1);
            returnVal.Dispose();
            //
            temp2 = temp1.Copy();
            //
            if (!string.IsNullOrEmpty(tbIn_day1.Text))
                s[2] = " and a.in_day>='" + tbIn_day1.Text + "'";
            if (!string.IsNullOrEmpty(tbIn_day2.Text))
                s[3] = " and a.in_day<='" + tbIn_day2.Text + "'";
            //
            cQuery = " select a.row_id,a.item,a.c_size,a.c_left,a.c_kook,a.c_julsu,b.name from " + DB_L_jumoon2 + " as a";
            cQuery += " left outer join " + DB_L_customer + " as b on a.int_id = b.row_id ";
            cQuery += " where a.row_id>0 " + s[2] + s[3];
            //
            MySqlDataAdapter returnVal1 = new MySqlDataAdapter(cQuery, DBConn);
            returnVal1.Fill(l_jumoon2);
            returnVal1.Dispose();
            DBCons.Close();
            DBConn.Close();
            //
            int m = 1;
            DataRow[] dr;
            string int_cc = "";
            int same_row = 1;

            for (int i = 0; i < temp1.Rows.Count; i++)
            {
                if (temp1.Rows[i]["f_option"].ToString() == "won_file")
                {
                    grid1.Rows.Insert(m);
                    grid1.Rows[m].Height = 22;
                    //
                    grid1[m, 0] = new SourceGrid.Cells.Cell(temp1.Rows[i]["row_id"].ToString(), typeof(string));            //row_id
                
                    grid1[m, 1] = new SourceGrid.Cells.CheckBox(null, false);               // √
                    grid1[m, 1].AddController(ClickEvent1);

                    grid1[m, 2] = new SourceGrid.Cells.Cell(m.ToString(), typeof(string));  // No;
                    grid1[m, 2].View = cc.center_cell;

                    if (temp1.Rows[i]["int_id"].ToString() == int_cc)
                    {
                        grid1[m - same_row, 3].RowSpan = same_row + 1;
                        grid1[m - same_row, 4].RowSpan = same_row + 1;
                        grid1[m - same_row, 5].RowSpan = same_row + 1;
                        grid1[m - same_row, 6].RowSpan = same_row + 1;
                        grid1[m - same_row, 7].RowSpan = same_row + 1;
                        grid1[m - same_row, 8].RowSpan = same_row + 1;
                        grid1[m - same_row, 9].RowSpan = same_row + 1;
                        same_row++;
                    }
                    else
                    {
                        grid1[m, 3] = new SourceGrid.Cells.Cell(temp1.Rows[i]["jubsu_day"].ToString(), typeof(string));      //
                        grid1[m, 3].View = cc.center_cell;
                        grid1[m, 3].Editor = cc.disable_cell;
                        //
                        int_cc = temp1.Rows[i]["int_id"].ToString();
                        same_row = 1;
                        //
                        if (temp1.Rows[i]["db_nm"].ToString() == "L_jumoon2")
                        {
                            dr = l_jumoon2.Select("row_id='" + temp1.Rows[i]["int_id"].ToString() + "'");
                            if (dr.Length != 0)
                            {
                                grid1[m, 4] = new SourceGrid.Cells.Cell(dr[0]["name"].ToString(), typeof(string));      //
                                grid1[m, 5] = new SourceGrid.Cells.Cell(dr[0]["item"].ToString(), typeof(string));      //
                                grid1[m, 6] = new SourceGrid.Cells.Cell(dr[0]["c_size"].ToString(), typeof(string));      //
                                grid1[m, 7] = new SourceGrid.Cells.Cell(dr[0]["c_left"].ToString(), typeof(string));      //
                                grid1[m, 8] = new SourceGrid.Cells.Cell(dr[0]["c_kook"].ToString(), typeof(string));      //
                                grid1[m, 9] = new SourceGrid.Cells.Cell(dr[0]["c_julsu"].ToString(), typeof(string));      //
                            }
                            else
                            {
                                grid1[m, 4] = new SourceGrid.Cells.Cell("", typeof(string));      //
                                grid1[m, 5] = new SourceGrid.Cells.Cell("", typeof(string));      //
                                grid1[m, 6] = new SourceGrid.Cells.Cell("", typeof(string));      //
                                grid1[m, 7] = new SourceGrid.Cells.Cell("", typeof(string));      //
                                grid1[m, 8] = new SourceGrid.Cells.Cell("", typeof(string));      //
                                grid1[m, 9] = new SourceGrid.Cells.Cell("", typeof(string));      //
                            }
                        }
                        else
                        {
                            grid1[m, 4] = new SourceGrid.Cells.Cell(temp1.Rows[i]["name"].ToString(), typeof(string));      //
                            grid1[m, 5] = new SourceGrid.Cells.Cell(temp1.Rows[i]["item"].ToString(), typeof(string));      //
                            grid1[m, 6] = new SourceGrid.Cells.Cell(temp1.Rows[i]["c_size"].ToString(), typeof(string));      //
                            grid1[m, 7] = new SourceGrid.Cells.Cell(temp1.Rows[i]["c_left"].ToString(), typeof(string));      //
                            grid1[m, 8] = new SourceGrid.Cells.Cell(temp1.Rows[i]["c_kook"].ToString(), typeof(string));      //
                            grid1[m, 9] = new SourceGrid.Cells.Cell(temp1.Rows[i]["c_julsu"].ToString(), typeof(string));      //
                        }
                        grid1[m, 4].View = cc.left_cell;
                        grid1[m, 4].Editor = cc.disable_cell;

                        grid1[m, 5].View = cc.left_cell;
                        grid1[m, 5].Editor = cc.disable_cell;

                        grid1[m, 6].View = cc.center_cell;
                        grid1[m, 6].Editor = cc.disable_cell;

                        grid1[m, 7].View = cc.center_cell;
                        grid1[m, 7].Editor = cc.disable_cell;

                        grid1[m, 8].View = cc.center_cell;
                        grid1[m, 8].Editor = cc.disable_cell;

                        grid1[m, 9].View = cc.center_cell;
                        grid1[m, 9].Editor = cc.disable_cell;
                        //  
                    }

                    grid1[m, 10] = new SourceGrid.Cells.Cell(temp1.Rows[i]["comment"].ToString(), typeof(string));      //
                    grid1[m, 10].View = mmm_l;
                    grid1[m, 10].Editor = cc.disable_cell;

                    grid1[m, 11] = new SourceGrid.Cells.Cell(temp1.Rows[i]["user_file"].ToString(), typeof(string));      //
                    grid1[m, 11].View = cc.left_cell;
                    grid1[m, 11].Editor = cc.disable_cell;

                    grid1[m, 12] = new SourceGrid.Cells.Cell(temp1.Rows[i]["update_time"].ToString().Substring(0,10), typeof(string));      //
                    grid1[m, 12].View = cc.center_cell;
                    grid1[m, 12].Editor = cc.disable_cell;

                    grid1[m, 13] = new SourceGrid.Cells.Cell(temp1.Rows[i]["edit_name"].ToString(), typeof(string));      //
                    grid1[m, 13].View = mmm;
                    grid1[m, 13].Editor = cc.disable_cell;

                    dr = temp2.Select("won_row_id='" + temp1.Rows[i]["row_id"].ToString() + "'");
                    if (dr.Length != 0)
                    { 
                        grid1[m, 14] = new SourceGrid.Cells.Cell(dr[0]["user_file"].ToString(), typeof(string));      //
                        grid1[m, 15] = new SourceGrid.Cells.Cell(dr[0]["update_time"].ToString().Substring(0, 10), typeof(string));      //
                        grid1[m, 16] = new SourceGrid.Cells.Cell(dr[0]["edit_name"].ToString(), typeof(string));      //
                        grid1[m, 26] = new SourceGrid.Cells.Cell(dr[0]["server_file"].ToString(), typeof(string));      //
                    }
                    else
                    {
                        grid1[m, 14] = new SourceGrid.Cells.Cell("", typeof(string));      //
                        grid1[m, 15] = new SourceGrid.Cells.Cell("", typeof(string));      //
                        grid1[m, 16] = new SourceGrid.Cells.Cell("", typeof(string));      //
                        grid1[m, 26] = new SourceGrid.Cells.Cell("", typeof(string));      //
                    }

                    grid1[m, 14].View = cc.left_cell;
                    grid1[m, 14].Editor = cc.disable_cell;

                    grid1[m, 15].View = cc.center_cell;
                    grid1[m, 15].Editor = cc.disable_cell;

                    grid1[m, 16].View = cc.center_cell;
                    grid1[m, 16].Editor = cc.disable_cell;

                    if (!string.IsNullOrEmpty(temp1.Rows[i]["req_confirm"].ToString()))  //
                    {
                        if (Convert.ToBoolean(temp1.Rows[i]["req_confirm"].ToString()) == true)
                            grid1[m, 17] = new SourceGrid.Cells.Cell("○", typeof(string));      //
                        else
                            grid1[m, 17] = new SourceGrid.Cells.Cell("×", typeof(string));      //
                    }
                    else
                        grid1[m, 17] = new SourceGrid.Cells.Cell("×", typeof(string));      //
                    // 
                    grid1[m, 17].View = mmm;
                    grid1[m, 17].Editor = cc.disable_cell;

                    if (!string.IsNullOrEmpty(temp1.Rows[i]["confirm"].ToString()))  //
                    {
                        if (Convert.ToBoolean(temp1.Rows[i]["confirm"].ToString()) == true)
                            grid1[m, 18] = new SourceGrid.Cells.Cell("○", typeof(string));      //
                        else
                            grid1[m, 18] = new SourceGrid.Cells.Cell("×", typeof(string));      //
                    }
                    else
                        grid1[m, 18] = new SourceGrid.Cells.Cell("×", typeof(string));      //
                    // 
                    grid1[m, 18].View = cc.center_cell;
                    grid1[m, 18].Editor = cc.disable_cell;

                    string c_time = c_time = temp1.Rows[i]["confirm_time"].ToString().Trim();
                    //
                    if (string.IsNullOrEmpty(c_time))  //
                        grid1[m, 19] = new SourceGrid.Cells.Cell("", typeof(string));      //
                    else
                        grid1[m, 19] = new SourceGrid.Cells.Cell(c_time.Substring(5,11), typeof(string));      //
                    // 
                    grid1[m, 19].View = cc.center_cell;
                    grid1[m, 19].Editor = cc.disable_cell;

                    grid1[m, 20] = new SourceGrid.Cells.Cell(temp1.Rows[i]["confirm_name"].ToString(), typeof(string));      //
                    grid1[m, 20].View = mmm;
                    grid1[m, 20].Editor = cc.disable_cell;

                    if (temp1.Rows[i]["save_id"].ToString() == "True")
                        grid1[m, 21] = new SourceGrid.Cells.Cell("", typeof(string));      //
                    else
                        grid1[m, 21] = new SourceGrid.Cells.Cell(temp1.Rows[i]["auto_delete_day"].ToString(), typeof(string));      //
                    grid1[m, 21].View = cc.center_cell;
                    grid1[m, 21].Editor = cc.disable_cell;

                    grid1[m, 22] = new SourceGrid.Cells.Cell(temp1.Rows[i]["int_id"].ToString(), typeof(string));      //
                    grid1[m, 23] = new SourceGrid.Cells.Cell(temp1.Rows[i]["db_nm"].ToString(), typeof(string));      //

                    grid1[m, 24] = new SourceGrid.Cells.Cell(temp1.Rows[i]["won_row_id"].ToString(), typeof(string));      //
                    grid1[m, 25] = new SourceGrid.Cells.Cell(temp1.Rows[i]["server_file"].ToString(), typeof(string));      //
                    //grid1[m, 26] = 위에서 선언
                    grid1[m, 27] = new SourceGrid.Cells.Cell(temp1.Rows[i]["brow_id"].ToString(), typeof(string));      //
                    //
                    grid1[m, 28] = new SourceGrid.Cells.CheckBox(null, Convert.ToBoolean(temp1.Rows[i]["save_id"].ToString()));      // √
                    grid1[m, 28].AddController(ClickEvent1);

                    m++;
                }
            }
            //=======================================
            string comp = tbCompany_name.Text;
            string item = tbItem.Text;
            //
            for (int i = 1; i < grid1.Rows.Count; i++)
            {
                if (!string.IsNullOrEmpty(comp))
                {
                    if (!grid1[i, 4].ToString().Contains(comp))
                    {
                        grid1.Rows[i].Visible = false;
                        continue;
                    }
                }
                if (!string.IsNullOrEmpty(item))
                {
                    if (!grid1[i, 5].ToString().Contains(item))
                    {
                        grid1.Rows[i].Visible = false;
                        continue;
                    }
                }
            }
            //
            ValueChangedEvent1.ValueChanged += new EventHandler(ValueChanged1);
            ClickEvent1.MouseUp += new MouseEventHandler(MouseClickd1);
            //
        }

        public void ValueChanged1(object sender, EventArgs e)      //grid1에서 볼륨첸지
        {
        }

        private void MouseClickd1(object sender, MouseEventArgs e)  //Grid1에서 마우스좌클릭 이벤트
        {
            string cQuery = "";
            int pos = grid1.Selection.ActivePosition.Column;
            int row = grid1.Selection.ActivePosition.Row;
            string dat1 = "";
            string row_no = grid1[row, 0].ToString().Trim(); //row_id
            //
            var DBConn_C = new MySqlConnection(Config.DB_con1);
            util.Con_DB_Open(ref DBConn_C);
            //
            if (grid1[row, pos].ToString() == "True")
                dat1 = "1";
            else
                dat1 = "0";
            if (pos == 28)       //
            {
                if (dat1 == "1")
                {
                    cQuery = " update " + DB_C_img_total_manage + " set save_id='" + dat1 + "',auto_delete_day='0000-00-00'";
                    cQuery += " where row_id='" + row_no + "'";
                }
                else
                {
                    cQuery = " update " + DB_C_img_total_manage + " set save_id='" + dat1 + "' where row_id='" + row_no + "'";
                }
                var cmd = new MySqlCommand(cQuery, DBConn_C);
                cmd.ExecuteNonQuery();
                DBConn_C.Clone();
            }
        }

        private void button11_Click(object sender, EventArgs e)  //날짜1
        {
            Calendar_Form fm = new Calendar_Form(tbIn_day1);
            fm.ShowDialog();
        }

        private void button12_Click(object sender, EventArgs e)  //날짜2
        {
            Calendar_Form fm = new Calendar_Form(tbIn_day2);
            fm.ShowDialog();
        }

        private void button2_Click(object sender, EventArgs e)  //원본파일 다운받기
        {
            string ip_addr = "http://pera.co.kr/upload/";// 20160624/o_1alvs45ck1dmom6r4sf16iprjcc.jpg";
            string dir_name = "";
            int i_su = checked_item();
            if (i_su == 0 || i_su > 1)
                MessageBox.Show("다운받을 항목 1개를 선택해 주십시요.");
            else if (string.IsNullOrEmpty(grid1[row_int, 11].ToString()))
                MessageBox.Show("다운받을 원본파일이 없습니다.");
            else
            {
                if (folderBrowserDialog1.ShowDialog() == DialogResult.OK)
                {
                    dir_name = folderBrowserDialog1.SelectedPath.ToString();
                    dir_name += @"\";
                    dir_name += grid1[row_int, 11].ToString();
                    //
                    ip_addr += grid1[row_int, 12].ToString().Substring(0, 4);
                    ip_addr += grid1[row_int, 12].ToString().Substring(5, 2);
                    ip_addr += grid1[row_int, 12].ToString().Substring(8, 2);
                    ip_addr += "/";
                    ip_addr += grid1[row_int, 25].ToString();
                    //
                    Web_FTP Frm = new Web_FTP(ip_addr, dir_name); // 파일다운  //addr=접속주소 / name=파일다운(위치+파일명)
                    Frm.ShowDialog();
                }
            }
        }

        private int checked_item()  //
        {
            int x_su = 0;
            for (int i = 1; i < grid1.Rows.Count; i++)
            {
                if (Convert.ToBoolean(grid1[i, 1].ToString()) == true)
                {
                    row_int = i;
                    x_su++;
                }
            }
            return x_su;
        }

        private void button3_Click(object sender, EventArgs e)  //pdf 파일다운로드
        {
            string ip_addr = "http://pera.co.kr/upload/";// 20160624/o_1alvs45ck1dmom6r4sf16iprjcc.jpg";
            string dir_name = "";
            int i_su = checked_item();
            if (i_su == 0 || i_su > 1)
                MessageBox.Show("다운받을 항목 1개를 선택해 주십시요.");
            else if (string.IsNullOrEmpty(grid1[row_int, 14].ToString()))
                MessageBox.Show("다운받을 PDF파일이 없습니다.");
            else
            {
                if (folderBrowserDialog1.ShowDialog() == DialogResult.OK)
                {
                    dir_name = folderBrowserDialog1.SelectedPath.ToString();
                    dir_name += @"\";
                    dir_name += grid1[row_int, 14].ToString();
                    //
                    ip_addr += grid1[row_int, 15].ToString().Substring(0, 4);
                    ip_addr += grid1[row_int, 15].ToString().Substring(5, 2);
                    ip_addr += grid1[row_int, 15].ToString().Substring(8, 2);
                    ip_addr += "/";
                    ip_addr += grid1[row_int, 26].ToString();
                    //
                    Web_FTP Frm = new Web_FTP(ip_addr, dir_name); // 파일다운  //addr=접속주소 / name=파일다운(위치+파일명)
                    Frm.ShowDialog();
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)  //파일삭제
        {
            int i_su = checked_item();
            if (i_su == 0)
            {
                MessageBox.Show("삭제대상 항목이 없습니다.");
                return;
            }
            if (MessageBox.Show("선택한 항목을 삭제합니까? (삭제시에는 PDF파일도 함께 삭제됩니다.)", "원본파일 삭제", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                string cQuery = "";
                var DBConn_C = new MySqlConnection(Config.DB_con1);
                string row_no = "";
                //
                for (int i = 1; i < grid1.Rows.Count; i++)
                {
                    util.Con_DB_Open(ref DBConn_C);
                    if (Convert.ToBoolean(grid1[i, 1].ToString()) == true)
                    {
                        row_no = grid1[i, 0].ToString();
                        cQuery = " delete from " + DB_C_img_total_manage + " where row_id='" + row_no + "';";
                        cQuery += " delete from " + DB_C_img_total_manage + " where won_row_id='" + row_no + "';";
                        cQuery += " delete from " + DB_C_img_confirm_manage + " where int_id='" + row_no + "';";
                        //                        
                        var cmd = new MySqlCommand(cQuery, DBConn_C);
                        cmd.ExecuteNonQuery();
                    }
                }
                DBConn_C.Close();
                make_grid1();
            }
        }

        private void button4_Click(object sender, EventArgs e)  //검색
        {
            make_grid1();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            tbCompany_name.Text = "";
            tbItem.Text = "";
            tbIn_day1.Text = "";
            tbIn_day2.Text = "";

        }

        private void button6_Click(object sender, EventArgs e)
        {
            int i_su = checked_item();
            if (i_su == 0)
            {
                MessageBox.Show("대상 항목이 없습니다.");
                return;
            }
            //
            textBox1.Text = "";
            Calendar_Form fm = new Calendar_Form(textBox1);
            fm.ShowDialog();
            //
            if (textBox1.Text == "")
                return;
            //
            string cQuery = "";
            string row_su = "";
            //
            var DBConn_C = new MySqlConnection(Config.DB_con1);
            util.Con_DB_Open(ref DBConn_C);

            for (int i = 1; i < grid1.Rows.Count; i++)
            {
                if (Convert.ToBoolean(grid1[i, 1].ToString()) == true && grid1[i, 28].ToString() == "False")
                {
                    row_su = grid1[i, 0].ToString();
                    cQuery = " update " + DB_C_img_total_manage;  //
                    cQuery += "  set auto_delete_day='" + textBox1.Text + "' where row_id='" + row_su + "'";
                    var cmd1 = new MySqlCommand(cQuery, DBConn_C);
                    cmd1.ExecuteNonQuery();
                    grid1[i, 21].Value = textBox1.Text;
                }
            }

        }
    }

    public class MyHeader3 : SourceGrid.Cells.ColumnHeader  //
    {
        public MyHeader3(object value)
            : base(value)
        {
            DevAge.Drawing.BorderLine border_l = new DevAge.Drawing.BorderLine(Color.FromArgb(93, 93, 93), 1);
            DevAge.Drawing.BorderLine border_r = new DevAge.Drawing.BorderLine(Color.FromArgb(220, 220, 220), 0);
            DevAge.Drawing.BorderLine top = new DevAge.Drawing.BorderLine(Color.FromArgb(220, 220, 220), 1);
            DevAge.Drawing.BorderLine bottom = new DevAge.Drawing.BorderLine(Color.FromArgb(220, 220, 220), 1);
            DevAge.Drawing.RectangleBorder border1 = new DevAge.Drawing.RectangleBorder(top, bottom, border_r, border_l);
            //Header Row
            SourceGrid.Cells.Views.ColumnHeader view = new SourceGrid.Cells.Views.ColumnHeader();
            view.Font = new Font(FontFamily.GenericSansSerif, 8, FontStyle.Regular);
            view.Border = border1;
            view.TextAlignment = DevAge.Drawing.ContentAlignment.MiddleCenter;
            View = view;
            AutomaticSortEnabled = false;
        }
    }

}
