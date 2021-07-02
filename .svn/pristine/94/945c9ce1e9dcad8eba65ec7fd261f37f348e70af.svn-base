using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using System.Diagnostics;
using System.IO;


namespace Dukyou3
{
    public partial class Form_3061 : Form
    {
        SourceGrid.Cells.Controllers.CustomEvents valueChangedEvent = new SourceGrid.Cells.Controllers.CustomEvents();
        string DB_TableName = "C_jubji_price";
        string DB_TableName_file = "C_file_total_manage";

        FileControl FC = new FileControl();
        ksgcontrol ks = new ksgcontrol();
        cell_d cc = new cell_d();
        
        //SourceGrid.Cells.Controllers.CustomEvents clickEvent = new SourceGrid.Cells.Controllers.CustomEvents();
        //SourceGrid.Cells.Controllers.CustomEvents doubleClickEvent = new SourceGrid.Cells.Controllers.CustomEvents();
        //
        public Form_3061()
        {
            InitializeComponent();
        }

        private void Form_310_Load(object sender, EventArgs e)
        {
            Screen srn = Screen.PrimaryScreen;
            int Xb = this.Width;  //좌,우
            this.Location = new Point((srn.Bounds.Width - Xb) / 2, 1);  //좌/우,위/아래

            FC.FileControlInit(Config.DB_con1, Config.Ftp_ip1, Config.Ftp_id1, Config.Ftp_pw1);
            ks.ControlInit(Config.DB_con1, null, null, null);
            //
            valueChangedEvent.ValueChanged += new EventHandler(valueChanged);
            //clickEvent.Click += new EventHandler(clicked);
            //doubleClickEvent.DoubleClick += new EventHandler(doubleClicked);
            // 
            select_1();
        }
     
        private void insert_combobox()
        {
        }

        private void valueChanged(object sender, EventArgs e)  //Grid1에서 내용수정시
        {
            var DBConn = new MySqlConnection(Config.DB_con1);
            DBConn.Open();
            string cQuery = "";
            int pos = grid1.Selection.ActivePosition.Column;
            int row = grid1.Selection.ActivePosition.Row;
            string dat = grid1[row,pos].ToString().Trim();
            string row_no = grid1[row,0].ToString().Trim(); //row_id
            //
            if (pos == 3)
                cQuery = " update C_jubji_price set j_code='" + dat + "' where row_id='" + row_no + "'";
            else if (pos == 4)
                cQuery = " update C_jubji_price set j_name='" + dat + "' where row_id='" + row_no + "'";
            else if (pos == 7)
                cQuery = " update C_jubji_price set std_code='" + dat + "' where row_id='" + row_no + "'";
            else if (pos == 8)
                cQuery = " update C_jubji_price set f_code='" + dat + "' where row_id='" + row_no + "'";
            else if (pos == 9)
                cQuery = " update C_jubji_price set f_jubjimodel='" + dat + "' where row_id='" + row_no + "'";
            else if (pos == 10)
                cQuery = " update C_jubji_price set f_myunsu='" + dat + "' where row_id='" + row_no + "'";
            else if (pos == 11)
                cQuery = " update C_jubji_price set f_balche='" + dat + "' where row_id='" + row_no + "'";
            else if (pos == 12)
                cQuery = " update C_jubji_price set s_code='" + dat + "' where row_id='" + row_no + "'";
            else if (pos == 13)
                cQuery = " update C_jubji_price set s_jubjimodel='" + dat + "' where row_id='" + row_no + "'";
            else if (pos == 14)
                cQuery = " update C_jubji_price set s_myunsu='" + dat + "' where row_id='" + row_no + "'";
            else if (pos == 15)
                cQuery = " update C_jubji_price set s_balche='" + dat + "' where row_id='" + row_no + "'";

            else if (pos == 16)
                cQuery = " update C_jubji_price set price_1='" + dat + "' where row_id='" + row_no + "'";
            else if (pos == 17)
                cQuery = " update C_jubji_price set price_2='" + dat + "' where row_id='" + row_no + "'";
            else if (pos == 18)
                cQuery = " update C_jubji_price set price_3='" + dat + "' where row_id='" + row_no + "'";
            else if (pos == 19)
                cQuery = " update C_jubji_price set price_4='" + dat + "' where row_id='" + row_no + "'";
            else if (pos == 20)
                cQuery = " update C_jubji_price set price_5='" + dat + "' where row_id='" + row_no + "'";
            else if (pos == 21)
                cQuery = " update C_jubji_price set price_6='" + dat + "' where row_id='" + row_no + "'";
            else if (pos == 22)
                cQuery = " update C_jubji_price set price_7='" + dat + "' where row_id='" + row_no + "'";
            else if (pos == 23)
                cQuery = " update C_jubji_price set price_8='" + dat + "' where row_id='" + row_no + "'";
            else if (pos == 24)
                cQuery = " update C_jubji_price set price_9='" + dat + "' where row_id='" + row_no + "'";
            else if (pos == 25)
                cQuery = " update C_jubji_price set price_10='" + dat + "' where row_id='" + row_no + "'";
            else if (pos == 26)
                cQuery = " update C_jubji_price set price_11='" + dat + "' where row_id='" + row_no + "'";

            else if (pos == 27)
                cQuery = " update C_jubji_price set price2_1='" + dat + "' where row_id='" + row_no + "'";
            else if (pos == 28)
                cQuery = " update C_jubji_price set price2_2='" + dat + "' where row_id='" + row_no + "'";
            else if (pos == 29)
                cQuery = " update C_jubji_price set price2_3='" + dat + "' where row_id='" + row_no + "'";
            else if (pos == 30)
                cQuery = " update C_jubji_price set price2_4='" + dat + "' where row_id='" + row_no + "'";
            else if (pos == 31)
                cQuery = " update C_jubji_price set price2_5='" + dat + "' where row_id='" + row_no + "'";
            else if (pos == 32)
                cQuery = " update C_jubji_price set price2_6='" + dat + "' where row_id='" + row_no + "'";
            else if (pos == 33)
                cQuery = " update C_jubji_price set price2_7='" + dat + "' where row_id='" + row_no + "'";
            else if (pos == 34)
                cQuery = " update C_jubji_price set price2_8='" + dat + "' where row_id='" + row_no + "'";
            else if (pos == 35)
                cQuery = " update C_jubji_price set price2_9='" + dat + "' where row_id='" + row_no + "'";
            else if (pos == 36)
                cQuery = " update C_jubji_price set price2_10='" + dat + "' where row_id='" + row_no + "'";
            else if (pos == 37)
                cQuery = " update C_jubji_price set price2_11='" + dat + "' where row_id='" + row_no + "'";
            else if (pos == 38)
                cQuery = " update C_jubji_price set set_danga='" + dat + "' where row_id='" + row_no + "'";
            else if (pos == 40)
                cQuery = " update C_jubji_price set osi='" + dat + "' where row_id='" + row_no + "'";
            else if (pos == 41)
                cQuery = " update C_jubji_price set basis_danga='" + dat + "' where row_id='" + row_no + "'";
            else
            {
                DBConn.Close();
                return;
            }
            //
            if (cQuery != "")
            {
                var cmd = new MySqlCommand(cQuery, DBConn);
                if (cmd.ExecuteNonQuery() == 0)
                {
                    MessageBox.Show("DB 서버 오류 입니다.");
                    DBConn.Close();
                    return;
                }
            }
            DBConn.Close();
        }

        private void clicked(object sender, EventArgs e)       //Grid1에서 클릭시
        {
            int column = grid1.Selection.ActivePosition.Column;
            MessageBox.Show(column.ToString());
        }

        private void doubleClicked(object sender, EventArgs e)  //Grid1에서 더블클릭시
        {
            int column = grid1.Selection.ActivePosition.Column;
            MessageBox.Show(column.ToString());
        }


        private void button2_Click(object sender, EventArgs e)  //검색
        {
            select_1();
        }

        private void select_1()
        {
            SourceGrid.Cells.Views.ColumnHeader left_cell;     //좌측셀

            left_cell = new SourceGrid.Cells.Views.ColumnHeader();
            left_cell.TextAlignment = DevAge.Drawing.ContentAlignment.MiddleLeft;

            // 
            grid1.Controller.AddController(valueChangedEvent);
            string s1,s2,s3,s4,s5 ,s6,s7,s8;
            //
            grid1.Rows.Clear();
            grid1.BorderStyle = BorderStyle.FixedSingle;
            grid1.SelectionMode = SourceGrid.GridSelectionMode.Cell;
            grid1.ColumnsCount = 42;
            grid1.FixedRows = 2;
            grid1.FixedColumns = 16;
            grid1.Rows.Insert(0);
            grid1.Rows[0].Height = 26;
            grid1.Rows.Insert(1);
            grid1.Rows[1].Height = 38;
            //
            grid1[0, 0] = new MyHeader1("row_id");
            grid1[0, 0].RowSpan = 2;
            grid1.Columns[0].Visible = false;
            grid1[0, 1] = new MyHeader1("√");
            grid1[0, 1].RowSpan = 2;
            grid1[0, 2] = new MyHeader1("No");
            grid1[0, 2].RowSpan = 2;
            grid1[0, 3] = new MyHeader1("접지"+ "\r\n" +"코드");
            grid1[0, 3].RowSpan = 2;
            grid1[0, 4] = new MyHeader1("접지 이름");
            grid1[0, 4].RowSpan = 2;
            grid1[0, 5] = new MyHeader1("그림" + "\r\n" + "파일");
            grid1[0, 5].RowSpan = 2;
            grid1[0, 5].ColumnSpan = 2;
            //두개 컬럼으로 나눠서 표시
            grid1[0, 7] = new MyHeader1("지정" + "\r\n" + "코드");
            grid1[0, 7].RowSpan = 2;
            grid1[0, 8] = new MyHeader1("1차" + "\r\n" + "코드");
            grid1[0, 8].RowSpan = 2;
            grid1[0, 9] = new MyHeader1("1차접지방법");
            grid1[0, 9].RowSpan = 2;
            grid1[0, 10] = new MyHeader1("1차" + "\r\n" + "면수");
            grid1[0, 10].RowSpan = 2;
            grid1[0, 11] = new MyHeader1("1차" + "\r\n" + "발체");
            grid1[0, 11].RowSpan = 2;
            grid1[0, 12] = new MyHeader1("2차" + "\r\n" + "코드");
            grid1[0, 12].RowSpan = 2;
            grid1[0, 13] = new MyHeader1("2차접지방법");
            grid1[0, 13].RowSpan = 2;
            grid1[0, 14] = new MyHeader1("2차" + "\r\n" + "면수");
            grid1[0, 14].RowSpan = 2;
            grid1[0, 15] = new MyHeader1("2차" + "\r\n" + "발체");
            grid1[0, 15].RowSpan = 2;
            grid1[0, 16] = new MyHeader1("1차발체 최소 <  길이  ≤ 최대");
            grid1[0, 16].ColumnSpan = 11;
            grid1[0, 27] = new MyHeader1("2차발체 최소 <  길이  ≤ 최대");
            grid1[0, 27].ColumnSpan = 11;
            grid1[0, 38] = new MyHeader1("세팅 [ + ]");
            grid1[0, 38].RowSpan = 2;
            grid1[0, 39] = new MyHeader1("server_file");
            grid1.Columns[39].Visible = false;

            grid1[0, 40] = new MyHeader1("오시단가");
            grid1[0, 40].RowSpan = 2;
            grid1[0, 41] = new MyHeader1("기본단가");
            grid1[0, 41].RowSpan = 2;
            //
            grid1[1, 16] = new MyHeader1("60\r\n~100");
            grid1[1, 16].View = left_cell;
            grid1[1, 17] = new MyHeader1("100\r\n~200");
            grid1[1, 17].View = left_cell;
            grid1[1, 18] = new MyHeader1("200\r\n~300");
            grid1[1, 18].View = left_cell;
            grid1[1, 19] = new MyHeader1("300\r\n~400");
            grid1[1, 19].View = left_cell;
            grid1[1, 20] = new MyHeader1("400\r\n~500");
            grid1[1, 20].View = left_cell;
            grid1[1, 21] = new MyHeader1("500\r\n~600");
            grid1[1, 21].View = left_cell;
            grid1[1, 22] = new MyHeader1("600\r\n~700");
            grid1[1, 22].View = left_cell;
            grid1[1, 23] = new MyHeader1("700\r\n~800");
            grid1[1, 23].View = left_cell;
            grid1[1, 24] = new MyHeader1("800\r\n~900");
            grid1[1, 24].View = left_cell;
            grid1[1, 25] = new MyHeader1("900\r\n~1000");
            grid1[1, 25].View = left_cell;
            grid1[1, 26] = new MyHeader1("1000\r\n~1100");
            grid1[1, 26].View = left_cell;
            //
            grid1[1, 27] = new MyHeader1("60\r\n~100");
            grid1[1, 27].View = left_cell;
            grid1[1, 28] = new MyHeader1("100\r\n~200");
            grid1[1, 28].View = left_cell;
            grid1[1, 29] = new MyHeader1("200\r\n~300");
            grid1[1, 29].View = left_cell;
            grid1[1, 30] = new MyHeader1("300\r\n~400");
            grid1[1, 30].View = left_cell;
            grid1[1, 31] = new MyHeader1("400\r\n~500");
            grid1[1, 31].View = left_cell;
            grid1[1, 32] = new MyHeader1("500\r\n~600");
            grid1[1, 32].View = left_cell;
            grid1[1, 33] = new MyHeader1("600\r\n~700");
            grid1[1, 33].View = left_cell;
            grid1[1, 34] = new MyHeader1("700\r\n~800");
            grid1[1, 34].View = left_cell;
            grid1[1, 35] = new MyHeader1("800\r\n~900");
            grid1[1, 35].View = left_cell;
            grid1[1, 36] = new MyHeader1("900\r\n~1000");
            grid1[1, 36].View = left_cell;
            grid1[1, 37] = new MyHeader1("1000\r\n~1100");
            grid1[1, 37].View = left_cell;

            //
            grid1.Columns[0].Width = 100; //row_id
            grid1.Columns[1].Width = 22;  //√
            grid1.Columns[2].Width = 30;  //No
            grid1.Columns[3].Width = 46;  //접지코드
            grid1.Columns[4].Width = 200;  //접지이름
            grid1.Columns[5].Width = 120;  //그림파일 name
            grid1.Columns[6].Width = 20;  //그림파일 button
            grid1.Columns[7].Width = 40;  //지정코드
            grid1.Columns[8].Width = 40;  //1차코드
            grid1.Columns[9].Width = 120;  //1차접지방법
            grid1.Columns[10].Width = 40;  //1차면수
            grid1.Columns[11].Width = 40; //1차발체
            grid1.Columns[12].Width = 40; //2차코드
            grid1.Columns[13].Width = 120; //2차접지방법
            grid1.Columns[14].Width = 40; //2차면수
            grid1.Columns[15].Width = 40; //2차발체

            grid1.Columns[16].Width = 50; //1차 발체 1번가격 //최소 < 길이 ≤ 최대
            grid1.Columns[17].Width = 50; //2번가격
            grid1.Columns[18].Width = 50; //3번가격
            grid1.Columns[19].Width = 50; //4번가격
            grid1.Columns[20].Width = 50; //5번가격
            grid1.Columns[21].Width = 50; //6번가격
            grid1.Columns[22].Width = 50; //7번가격
            grid1.Columns[23].Width = 50; //8번가격
            grid1.Columns[24].Width = 50; //9번가격
            grid1.Columns[25].Width = 50; //10번가격
            grid1.Columns[26].Width = 50; //11번가격

            grid1.Columns[27].Width = 50; //2차 발체 1번가격 //최소 < 길이 ≤ 최대
            grid1.Columns[28].Width = 50; //2번가격
            grid1.Columns[29].Width = 50; //3번가격
            grid1.Columns[30].Width = 50; //4번가격
            grid1.Columns[31].Width = 50; //5번가격
            grid1.Columns[32].Width = 50; //6번가격
            grid1.Columns[33].Width = 50; //7번가격
            grid1.Columns[34].Width = 50; //8번가격
            grid1.Columns[35].Width = 50; //9번가격
            grid1.Columns[36].Width = 50; //10번가격
            grid1.Columns[37].Width = 50; //11번가격

            grid1.Columns[38].Width = 80;
            grid1.Columns[40].Width = 80; //오시
            grid1.Columns[41].Width = 80; //오시
            //
            if (tbJubnm.Text == "")
                s1="";
            else
                s1 = " and j_name like '%" + tbJubnm.Text.Trim() + "%'";
            //
            if (cbJubji1.Text == "")
                s2="";
            else
                s2 = " and f_jubjimodel like '%" + cbJubji1.Text.Trim() + "%'";
            //
            if (cbMyunsu1.Text == "")
                s3="";
            else
                s3 = " and f_myunsu ='" + cbMyunsu1.Text.Trim() + "'";
            //
            if (cbJubji2.Text == "")
                s4="";
            else
                s4 = " and s_jubjimodel like '%" + cbJubji2.Text.Trim() + "%'";
            //
            if (cbMyunsu2.Text == "")
                s5="";
            else
                s5 = " and s_myunsu ='" + cbMyunsu2.Text.Trim() + "'";
            //
            if (tbJubcode.Text == "")
                s6 = "";
            else
                s6 = " and j_code like '%" + tbJubcode.Text.Trim() + "%'";
            //
            if (cbBal1.Text == "")
                s7 = "";
            else
                s7 = " and f_balche like '%" + cbBal1.Text.Trim() + "%'";
            //
            if (cbBal2.Text == "")
                s8 = "";
            else
                s8 = " and s_balche like '%" + cbBal2.Text.Trim() + "%'";

            //
            var DBConn = new MySqlConnection(Config.DB_con1);
            DBConn.Open();
            string cQuery = "select a.*,b.server_file, b.user_file FROM "+DB_TableName+" as a ";
            cQuery += "left outer join "+DB_TableName_file+" as b on a.row_id = b.int_id and b.db_nm = '"+DB_TableName+"' ";
            cQuery += "where a.row_id > 0 "+s1+s2+s3+s4+s5+s6+s7+s8 ;
            cQuery += " order by a.j_code";
            var cmd = new MySqlCommand(cQuery, DBConn);
            var myRead = cmd.ExecuteReader();
            // 
            int m = 2;
            while (myRead.Read())
            {
                grid1.Rows.Insert(m);
                grid1.Rows[m].Height = 22;
                //
                grid1[m, 0] = new SourceGrid.Cells.Cell(myRead["row_id"], typeof(string));
                grid1[m, 1] = new SourceGrid.Cells.CheckBox(null, false);
                grid1[m, 2] = new SourceGrid.Cells.Cell((m-1).ToString(), typeof(string));
                grid1[m, 2].View = cc.center_cell;
                grid1[m, 2].Editor = cc.disable_cell;

                grid1[m, 3] = new SourceGrid.Cells.Cell(myRead["j_code"].ToString(), typeof(string));
                grid1[m, 3].View = cc.center_cell;

                grid1[m, 4] = new SourceGrid.Cells.Cell(myRead["j_name"].ToString(), typeof(string));
                grid1[m, 4].View = cc.left_cell;

                grid1[m, 5] = new SourceGrid.Cells.Cell(myRead["user_file"].ToString(), typeof(string));
                grid1[m, 5].View = cc.center_cellb;
                grid1[m, 5].Editor = cc.disable_cell;

                string temp = myRead["sub_file"].ToString();
                if(temp == "False")
                    grid1[m, 6] = new SourceGrid.Cells.Button("");
                else
                    grid1[m, 6] = new SourceGrid.Cells.Button("*");

                grid1[m, 7] = new SourceGrid.Cells.Cell(myRead["std_code"].ToString(), typeof(string));
                grid1[m, 7].View = cc.center_cell;

                grid1[m, 8] = new SourceGrid.Cells.Cell(myRead["f_code"].ToString(), typeof(string));
                grid1[m, 8].View = cc.center_cell;

                grid1[m, 9] = new SourceGrid.Cells.Cell(myRead["f_jubjimodel"].ToString(), typeof(string));
                grid1[m, 9].View = cc.left_cell;

                grid1[m, 10] = new SourceGrid.Cells.Cell(myRead["f_myunsu"].ToString(), typeof(string));
                grid1[m, 10].View = cc.center_cell;

                grid1[m, 11] = new SourceGrid.Cells.Cell(myRead["f_balche"].ToString(), typeof(string));
                grid1[m, 11].View = cc.center_cell;


                grid1[m, 12] = new SourceGrid.Cells.Cell(myRead["s_code"].ToString(), typeof(string));
                grid1[m, 12].View = cc.center_cell;

                grid1[m, 13] = new SourceGrid.Cells.Cell(myRead["s_jubjimodel"].ToString(), typeof(string));
                grid1[m, 13].View = cc.left_cell;

                grid1[m, 14] = new SourceGrid.Cells.Cell(myRead["s_myunsu"].ToString(), typeof(string));
                grid1[m, 14].View = cc.center_cell;

                grid1[m, 15] = new SourceGrid.Cells.Cell(myRead["s_balche"].ToString(), typeof(string));
                grid1[m, 15].View = cc.center_cell;

                grid1[m, 16] = new SourceGrid.Cells.Cell(myRead["price_1"].ToString(), typeof(int));
                grid1[m, 16].View = cc.center_cell;

                grid1[m, 17] = new SourceGrid.Cells.Cell(myRead["price_2"].ToString(), typeof(int));
                grid1[m, 17].View = cc.center_cell;

                grid1[m, 18] = new SourceGrid.Cells.Cell(myRead["price_3"].ToString(), typeof(int));
                grid1[m, 18].View = cc.center_cell;

                grid1[m, 19] = new SourceGrid.Cells.Cell(myRead["price_4"].ToString(), typeof(int));
                grid1[m, 19].View = cc.center_cell;

                grid1[m, 20] = new SourceGrid.Cells.Cell(myRead["price_5"].ToString(), typeof(int));
                grid1[m, 20].View = cc.center_cell;

                grid1[m, 21] = new SourceGrid.Cells.Cell(myRead["price_6"].ToString(), typeof(int));
                grid1[m, 21].View = cc.center_cell;

                grid1[m, 22] = new SourceGrid.Cells.Cell(myRead["price_7"].ToString(), typeof(int));
                grid1[m, 22].View = cc.center_cell;

                grid1[m, 23] = new SourceGrid.Cells.Cell(myRead["price_8"].ToString(), typeof(int));
                grid1[m, 23].View = cc.center_cell;

                grid1[m, 24] = new SourceGrid.Cells.Cell(myRead["price_9"].ToString(), typeof(int));
                grid1[m, 24].View = cc.center_cell;

                grid1[m, 25] = new SourceGrid.Cells.Cell(myRead["price_10"].ToString(), typeof(int));
                grid1[m, 25].View = cc.center_cell;

                grid1[m, 26] = new SourceGrid.Cells.Cell(myRead["price_11"].ToString(), typeof(int));
                grid1[m, 26].View = cc.center_cell;

                ///

                grid1[m, 27] = new SourceGrid.Cells.Cell(myRead["price2_1"].ToString(), typeof(int));
                grid1[m, 27].View = cc.center_cell;

                grid1[m, 28] = new SourceGrid.Cells.Cell(myRead["price2_2"].ToString(), typeof(int));
                grid1[m, 28].View = cc.center_cell;

                grid1[m, 29] = new SourceGrid.Cells.Cell(myRead["price2_3"].ToString(), typeof(int));
                grid1[m, 29].View = cc.center_cell;

                grid1[m, 30] = new SourceGrid.Cells.Cell(myRead["price2_4"].ToString(), typeof(int));
                grid1[m, 30].View = cc.center_cell;

                grid1[m, 31] = new SourceGrid.Cells.Cell(myRead["price2_5"].ToString(), typeof(int));
                grid1[m, 31].View = cc.center_cell;

                grid1[m, 32] = new SourceGrid.Cells.Cell(myRead["price2_6"].ToString(), typeof(int));
                grid1[m, 32].View = cc.center_cell;

                grid1[m, 33] = new SourceGrid.Cells.Cell(myRead["price2_7"].ToString(), typeof(int));
                grid1[m, 33].View = cc.center_cell;

                grid1[m, 34] = new SourceGrid.Cells.Cell(myRead["price2_8"].ToString(), typeof(int));
                grid1[m, 34].View = cc.center_cell;

                grid1[m, 35] = new SourceGrid.Cells.Cell(myRead["price2_9"].ToString(), typeof(int));
                grid1[m, 35].View = cc.center_cell;

                grid1[m, 36] = new SourceGrid.Cells.Cell(myRead["price2_10"].ToString(), typeof(int));
                grid1[m, 36].View = cc.center_cell;

                grid1[m, 37] = new SourceGrid.Cells.Cell(myRead["price2_11"].ToString(), typeof(int));
                grid1[m, 37].View = cc.center_cell;

                grid1[m, 38] = new SourceGrid.Cells.Cell(myRead["set_danga"].ToString(), typeof(int));
                grid1[m, 38].View = cc.center_cell;

                grid1[m, 39] = new SourceGrid.Cells.Cell(myRead["server_file"].ToString(), typeof(int));

                grid1[m, 40] = new SourceGrid.Cells.Cell(myRead["osi"].ToString(), typeof(string));
                grid1[m, 40].View = cc.center_cell;

                grid1[m, 41] = new SourceGrid.Cells.Cell(myRead["basis_danga"].ToString(), typeof(string));
                grid1[m, 41].View = cc.center_cell;
                m++;
            }
            myRead.Close();
            DBConn.Close();
        }

        private void button1_Click(object sender, EventArgs e)   //클리어
        {
            tbJubnm.Text = "";
            tbJubcode.Text = "";
            cbJubji1.SelectedIndex = -1;
            cbMyunsu1.SelectedIndex = -1;
            cbBal1.SelectedIndex = -1;
            cbBal2.SelectedIndex = -1;
            cbJubji2.SelectedIndex = -1;
            cbMyunsu2.SelectedIndex = -1;
        }

        private void button3_Click(object sender, EventArgs e)  //추가
        {
            var DBConn = new MySqlConnection(Config.DB_con1);
            DBConn.Open();
            string cQuery = "";
            cQuery = " insert into C_jubji_price (j_code) Value('')";
            var cmd = new MySqlCommand(cQuery, DBConn);
            //
            if (cmd.ExecuteNonQuery() == 0)
            {
                MessageBox.Show("서버 자료 등록에 실패 했습니다.");
                DBConn.Close();
                return;
            }
            else
                select_1();

            DBConn.Close();
        }

        private void button4_Click(object sender, EventArgs e)  //복사
        {
            var DBConn = new MySqlConnection(Config.DB_con1);
            DBConn.Open();
            string cQuery = "";
            string row_n = "";
            string field = "";
            //   
            cQuery = "SELECT `COLUMN_NAME` FROM `INFORMATION_SCHEMA`.`COLUMNS` WHERE `TABLE_SCHEMA`='" + Config.DB_name + "' AND `TABLE_NAME`='C_jubji_price'";
            var cmd = new MySqlCommand(cQuery, DBConn);
            var myRead = cmd.ExecuteReader();
            while (myRead.Read())
            {
                if (myRead["column_name"].ToString() != "row_id")
                    field += myRead["column_name"].ToString().Trim() + ",";
            }
            myRead.Close();
            field = field.Substring(0, field.Length - 1);
            //            
            for (int i = 2; i < grid1.Rows.Count; i++)
            {
                if (grid1[i, 1].Value.Equals(true))
                {
                    row_n = grid1[i, 0].Value.ToString(); //row_id
                    cQuery = "insert into C_jubji_price(" + field + ")  select " + field + " from C_jubji_price where row_id='" + row_n + "'";
                    cmd = new MySqlCommand(cQuery, DBConn);
                    //
                    if (cmd.ExecuteNonQuery() == 0)
                    {
                        MessageBox.Show("서버 자료 등록에 실패 했습니다.");
                        break;
                    }
                }
            }
            DBConn.Close();
            select_1();
        }

        private void button5_Click(object sender, EventArgs e)  //삭제
        {
            if (MessageBox.Show("선택하신 항목을 삭제합니까 ?", "항목 삭제", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                string[] sd = new string[grid1.RowsCount];//
                for (int i = 0; i < sd.Length; i++)
                    sd[i] = "0";
                //
                int s = 0;
                for (int i = 2; i < grid1.RowsCount; i++)
                    if (grid1[i, 1].Value.Equals(true))
                    {
                        sd[s] = grid1[i, 0].Value.ToString().Trim();
                        s++;
                    }

                //  DB 삭제
                var DBConn = new MySqlConnection(Config.DB_con1);
                DBConn.Open();
                //
                for (int i = 0; i < sd.Length; i++)
                {
                    if (sd[i].Equals("0"))
                        break;
                    else
                    {
                        string row_no = sd[i];
                        string cQuery = " delete from C_jubji_price where row_id='" + row_no + "'";
                        var cmd = new MySqlCommand(cQuery, DBConn);
                        if (cmd.ExecuteNonQuery() == 0)
                        {
                            MessageBox.Show("서버 자료 삭제에 실패 했습니다.");
                            DBConn.Close();
                            break;
                        }
                    }
                }
                DBConn.Close();
                //  그리드 삭제
                for (int i = 0; i < sd.Length; i++)
                {
                    if (sd[i].Equals("0"))
                        break;
                    else
                    {
                        for (s = 2; s < grid1.RowsCount; s++)
                        {
                            if (grid1[s, 0].Value.ToString().Equals(sd[i]))
                            {
                                grid1.Rows.Remove(s);
                            }
                        }
                    }
                }
                if (grid1.RowsCount > 1)
                {
                    grid1.Selection.FocusFirstCell(true);
                }
            }
        }

        private void grid1_MouseClick(object sender, MouseEventArgs e)
        {
            int pos = grid1.Selection.ActivePosition.Column;
            int row = grid1.Selection.ActivePosition.Row;
            string Query = "";
            if (row == -1)
                return;
            string row_no = grid1[row, 0].ToString().Trim(); //row_id 
            string FilePath = DB_TableName + "\\" + grid1[row, 39].ToString().Trim();  //39번이 server_file 명.
            string User_FileNm = grid1[row, 5].ToString().Trim();  //16번이 사용자가 보는file 명.
            if (User_FileNm != "")
            {
                if (pos == 6)
                {
                    if (MessageBox.Show("기존 파일을 삭제하고 다시 올리시겠습니까?", "메세지창", MessageBoxButtons.YesNo) == DialogResult.Yes)
                    {
                        OpenFileDialog ofd = new OpenFileDialog();// File descriptor
                        if (FC.FileOpenDlg(ofd) == 1)
                            return;
                        string file_path = ofd.FileName;

                        FileInfo file_name = new FileInfo(file_path);

                        string File_Table = DB_TableName.Substring(0, 1) + "_file_total_manage";

                        Query = "select * from " + File_Table + " where db_nm='" + DB_TableName + "' and int_id = " + row_no;

                        var DBConn = new MySqlConnection(Config.DB_con1);
                        DBConn.Open();
                        var cmd = new MySqlCommand(Query, DBConn);

                        var myRead = cmd.ExecuteReader();

                        myRead.Read();
                        FC.FileDel(myRead["server_file"].ToString(), DB_TableName);
                        myRead.Close();
                        DBConn.Close();

                        Query = "delete from " + File_Table + " where db_nm='" + DB_TableName + "' and int_id = " + row_no;
                        ks.DataUpdate(Query);

                        string server_file_name = FC.FileReg(ofd, DB_TableName, "sub_file", row_no, "mok");

                        grid1[row, 5] = new SourceGrid.Cells.Cell(file_name.Name, typeof(string));
                        grid1[row, 5].View = cc.center_cellb;
                        grid1[row, 5].Editor = cc.disable_cell;

                        grid1[row, 6] = new SourceGrid.Cells.Button("*");
                        grid1[row, 39] = new SourceGrid.Cells.Cell(server_file_name, typeof(string));
                        grid1.Refresh();
                    }
                }
            }
            else
            {
                if (pos == 6)
                {
                    OpenFileDialog ofd = new OpenFileDialog();// File descriptor
                    if (FC.FileOpenDlg(ofd) == 1)
                        return;
                    string file_path = ofd.FileName;

                    FileInfo file_name = new FileInfo(file_path);

                    string server_file_name = FC.FileReg(ofd, DB_TableName, "sub_file", row_no, "jubji");

                    grid1[row, 5] = new SourceGrid.Cells.Cell(file_name.Name, typeof(string));
                    grid1[row, 5].View = cc.center_cellb;
                    grid1[row, 5].Editor = cc.disable_cell;

                    grid1[row, 6] = new SourceGrid.Cells.Button("*");
                    grid1[row, 39] = new SourceGrid.Cells.Cell(server_file_name, typeof(string));
                    grid1.Refresh();
                }
            }
        }

        private void grid1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            int pos = grid1.Selection.ActivePosition.Column;
            int row = grid1.Selection.ActivePosition.Row;
            string Query = "";
            if (row == -1)
                return;
            string row_no = grid1[row, 0].ToString().Trim(); //row_id 
            string FilePath = DB_TableName + "\\" + grid1[row, 39].ToString().Trim();  //39번이 server_file 명.
            string User_FileNm = grid1[row, 5].ToString().Trim();  //16번이 사용자가 보는file 명.

            if (pos == 5)
            {
                SaveFileDialog sfd = new SaveFileDialog();
                sfd.Title = "Save File";
                sfd.FileName = User_FileNm;
                sfd.Filter = "ALL File(*.*)|*.*";
                sfd.InitialDirectory = "C:\\";
                sfd.RestoreDirectory = true;

                //if (sfd.ShowDialog() == DialogResult.OK)
                //{
                OhFTP Ftp = new OhFTP(Config.Ftp_ip2, Config.Ftp_id2, Config.Ftp_pw2);
                Ftp.DownLoadFile1(@sfd.FileName, FilePath);
                Process.Start(sfd.FileName);
                //}
            }
        }

        private void cbJubji1_SelectedValueChanged(object sender, EventArgs e)
        {
            string temp = "";
            if (cbJubji1.Text == "반접지")
            {
                cbMyunsu1.Items.Clear();
                for (int i = 2; i <= 7; i++)
                {
                    if(i%2 == 0)
                        this.cbMyunsu1.Items.Add(i);
                }
                
                cbBal1.Items.Clear();
                for (int i = 1; i <= 3; i++)
                    this.cbBal1.Items.Add(i);
            }

            if (cbJubji1.Text == "두루마리")
            {
                cbMyunsu1.Items.Clear();
                for (int i = 3; i <= 4; i++)
                    this.cbMyunsu1.Items.Add(i);

                cbBal1.Items.Clear();
                for (int i = 2; i <= 3; i++)
                    this.cbBal1.Items.Add(i);
                
            }

            if (cbJubji1.Text == "병풍(N접지)")
            {
                cbMyunsu1.Items.Clear();
                for (int i = 3; i <= 7; i++)
                    this.cbMyunsu1.Items.Add(i);
                cbBal1.Items.Clear();
                for (int i = 2; i <= 6; i++)
                    this.cbBal1.Items.Add(i);
            }

            if (cbJubji1.Text == "대문접지")
            {
                cbMyunsu1.Items.Clear();
                for (int i = 4; i <= 5; i++)
                    this.cbMyunsu1.Items.Add(i);

                cbBal1.Items.Clear();
                for (int i = 3; i <= 4; i++)
                    this.cbBal1.Items.Add(i);
            }
        }

        private void cbJubji2_SelectedValueChanged(object sender, EventArgs e)
        {
            if (cbJubji2.Text == "반접지")
            {
                cbMyunsu2.Items.Clear();
                for (int i = 2; i <= 4; i++)
                {
                    if(i%2 == 0)
                        this.cbMyunsu2.Items.Add(i);
                }

                cbBal2.Items.Clear();
                for (int i = 1; i <= 2; i++)
                    this.cbBal2.Items.Add(i);
            }

            if (cbJubji2.Text == "두루마리")
            {
                cbMyunsu2.Items.Clear();
                this.cbMyunsu2.Items.Add(3);

                cbBal2.Items.Clear();
                this.cbBal2.Items.Add(2);
            }

            if (cbJubji2.Text == "병풍(N접지)")
            {
                cbMyunsu2.Items.Clear();
                for (int i = 3; i <= 5; i++)
                    this.cbMyunsu2.Items.Add(i);

                cbBal2.Items.Clear();
                for (int i = 2; i <= 4; i++)
                    this.cbBal2.Items.Add(i);
            }

            if (cbJubji2.Text == "대문접지")
            {
                cbMyunsu2.Items.Clear();
                for (int i = 4; i <= 5; i++)
                    this.cbMyunsu2.Items.Add(i);

                cbBal2.Items.Clear();
                for (int i = 3; i <= 4; i++)
                    this.cbBal2.Items.Add(i);
            }
        }

        private void cbMyunsu1_SelectedValueChanged(object sender, EventArgs e)
        {
            int temp;
            if (cbJubji1.Text == "반접지")
            {
                if (cbMyunsu1.Text != "")
                {
                    temp = Convert.ToInt32(cbMyunsu1.Text) / 2;
                    cbBal1.Text = temp.ToString();
                }
            }

            else
            {
                if (cbMyunsu1.Text != "")
                {
                    temp = Convert.ToInt32(cbMyunsu1.Text) - 1;
                    cbBal1.Text = temp.ToString();
                }
            }
                
        }

        private void cbBal1_SelectedValueChanged(object sender, EventArgs e)
        {
            int temp;
            if (cbJubji1.Text == "반접지")
            {
                if (cbBal1.Text != "")
                {
                    temp = Convert.ToInt32(cbBal1.Text) * 2;
                    cbMyunsu1.Text = temp.ToString();
                }
            }

            else
            {
                if (cbBal1.Text != "")
                {
                    temp = Convert.ToInt32(cbBal1.Text) + 1;
                    cbMyunsu1.Text = temp.ToString();
                }
            }
        }

        private void cbMyunsu2_SelectedValueChanged(object sender, EventArgs e)
        {
            int temp;
            if (cbJubji2.Text == "반접지")
            {
                if (cbMyunsu2.Text != "")
                {
                    temp = Convert.ToInt32(cbMyunsu2.Text) / 2;
                    cbBal2.Text = temp.ToString();
                }
            }

            else
            {
                if (cbMyunsu2.Text != "")
                {
                    temp = Convert.ToInt32(cbMyunsu2.Text) - 1;
                    cbBal2.Text = temp.ToString();
                }
            }
        }

        private void cbBal2_SelectedValueChanged(object sender, EventArgs e)
        {
            int temp;
            if (cbJubji2.Text == "반접지")
            {
                if (cbBal2.Text != "")
                {
                    temp = Convert.ToInt32(cbBal2.Text) * 2;
                    cbMyunsu2.Text = temp.ToString();
                }
            }

            else
            {
                if (cbBal2.Text != "")
                {
                    temp = Convert.ToInt32(cbBal2.Text) + 1;
                    cbMyunsu2.Text = temp.ToString();
                }
            }
        }
    }
}
