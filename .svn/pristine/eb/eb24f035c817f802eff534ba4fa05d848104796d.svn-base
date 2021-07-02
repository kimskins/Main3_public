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
    public partial class Form_machins : Form
    {
        int xsn = 0;         //폼번호
        string x_id = "";    //1수정가능,2수정불가
        string m_id = "";    //기계구분번호
        string c_id = "0";    //회사번호
        //
        string a_code = "";     //a코드
        string b_code = "";     //b코드
        string c_code = "";     //c코드
        DataTable prn_dt = new DataTable();  //프린트방식코드번호

        SourceGrid.Cells.Editors.ComboBox cb_pantype;  // grid에 있는 판형에 들어갈 콤보박스

        public Form_machins(string cc, string ss, string sd, string md)  //회사번호,버튼활성화,폼번호,기계번호
        {
            InitializeComponent();
            a_code = md.Substring(0, 2);  //대분류 코드번호
            x_id = ss;      //버튼 활성화 구분
            m_id = md;      //기계구분번호
            c_id = cc;      //회사번호
            xsn = Convert.ToInt32(sd);  //폼번호

            MessageBox.Show(sd);

        }

        public Form_machins( string dd,string ff)  //대분류 번호, 폼번호
        {
            InitializeComponent();
            a_code = dd;  //대분류 코드번호
            x_id = "1";   //항목수정 가능
            xsn = Convert.ToInt32(ff);    //폼번호
        }

        private void Form_machins_Load(object sender, EventArgs e)
        {
            if (c_id == "0")
            {
                Screen srn = Screen.PrimaryScreen;
                int Xb = this.Width;  //좌,우
                this.Location = new Point((srn.Bounds.Width - Xb) / 2, 1);  //좌/우,위/아래
            }

            Config.tem_c = xsn.ToString() ;
            //
            if (x_id == "1")
            {
                this.button1.Enabled = false;
                //
                this.button2.Enabled = true;
                this.button3.Enabled = true;
                this.button4.Enabled = true;
                this.bCopy.Enabled = true;
            }
            else
            {
                this.button1.Enabled = true;
                //
                this.button2.Enabled = false;
                this.button3.Enabled = false;
                this.button4.Enabled = false;
                this.bCopy.Enabled = false;
            }
            grid1.Controller.AddController(new ValueChangedEvent());
            //
            if (xsn == 2)
                label11.Text = "■ 제본 기계정보";
            else if (xsn == 3)
                label11.Text = "■ 코팅 기계정보";
            else if (xsn == 4)
                label11.Text = "■ 접지 기계정보";
            else if (xsn == 5)
                label11.Text = "■ 기타 기계정보";
            // 인쇄방식 데이타 테이블 만글기
            var DBConn = new MySqlConnection(Config.DB_con1); //공동서버
            DBConn.Open();
            string cQuery = " select b_code,bitem from C_bmodel where a_code='08' order by b_code";  //
            MySqlDataAdapter returnVal = new MySqlDataAdapter(cQuery, DBConn);
            returnVal.Fill(prn_dt);
            returnVal.Dispose();
            DBConn.Close();
            //
            grid1.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(grid1_DoubleClick);
            //  
            button4_Click(null, null);
        }

        private void button4_Click(object sender, EventArgs e)  //검색
        {
            cell_d cc = new cell_d();

            string[] pantype = new string[1];

            pantype = Get_pantype_combo();
            cb_pantype = new SourceGrid.Cells.Editors.ComboBox(typeof(string), pantype, false);
            cb_pantype.EditableMode = SourceGrid.EditableMode.Focus | SourceGrid.EditableMode.AnyKey | SourceGrid.EditableMode.SingleClick;
            //
            grid1.Rows.Clear();
            //  
            grid1.BorderStyle = BorderStyle.FixedSingle;
            if (xsn == 2)
                grid1.ColumnsCount = 24;
            else if (xsn == 3)
                grid1.ColumnsCount = 20;
            else if (xsn == 4)
                grid1.ColumnsCount = 21;
            else if (xsn == 5)
                grid1.ColumnsCount = 26;
            //  
            grid1.FixedRows = 2;
            grid1.Rows.Insert(0);
            grid1.Rows[0].Height = 26;
            grid1.Rows.Insert(1);
            grid1.Rows[1].Height = 26;

            #region 제본기계
            if (xsn == 2)                //제본기계
            {
                grid1[0, 0] = new SourceGrid.Cells.ColumnHeader("row_id");
                grid1[0, 0].RowSpan = 2;
                grid1.Columns[0].Visible = false;

                grid1[0, 1] = new MyHeader1("√");
                grid1[0, 1].RowSpan = 2;

                grid1[0, 2] = new MyHeader1("No");
                grid1[0, 2].RowSpan = 2;

                grid1[0, 3] = new MyHeader1("업종1");
                grid1[0, 3].RowSpan = 2;

                grid1[0, 4] = new MyHeader1("업종2");
                grid1[0, 4].RowSpan = 2;

                grid1[0, 5] = new MyHeader1("제본옵션");
                grid1[0, 5].ColumnSpan = 2;
                grid1[1, 5] = new MyHeader1("제본조건");
                grid1[1, 6] = new MyHeader1("code");

                grid1[0, 7] = new MyHeader1("기계이름");
                grid1[0, 7].RowSpan = 2;

                grid1[0, 8] = new MyHeader1("인쇄방식");
                grid1[0, 8].RowSpan = 2;

                grid1[0, 9] = new MyHeader1("기  종"); 
                grid1[0, 9].RowSpan = 2;

                grid1[0, 10] = new MyHeader1("년식");
                grid1[0, 10].RowSpan = 2;

                grid1[0, 11] = new MyHeader1("기계등급");
                grid1[0, 11].RowSpan = 2;

                grid1[0, 12] = new MyHeader1("표지 최소");
                grid1[0, 12].ColumnSpan = 2;

                grid1[0, 14] = new MyHeader1("표지 최대");
                grid1[0, 14].ColumnSpan = 2;

                grid1[0, 16] = new MyHeader1("최소 책싸이즈");
                grid1[0, 16].ColumnSpan = 2;

                grid1[0, 18] = new MyHeader1("최대 책싸이즈");
                grid1[0, 18].ColumnSpan = 2;

                grid1[0, 20] = new MyHeader1("책두께(세네카)");
                grid1[0, 20].ColumnSpan = 2;

                grid1[0, 22] = new MyHeader1("콤마수");
                grid1[0, 22].RowSpan = 2;

                grid1[0, 23] = new MyHeader1("단가폼");
                grid1[0, 23].RowSpan = 2;
                // grid1.Rows.Insert(1);

                grid1[1, 12] = new MyHeader1("가로");
                grid1[1, 13] = new MyHeader1("세로");
                grid1[1, 14] = new MyHeader("가로");
                grid1[1, 15] = new MyHeader("세로");
                grid1[1, 16] = new MyHeader("가로");
                grid1[1, 17] = new MyHeader("세로");
                grid1[1, 18] = new MyHeader("가로");
                grid1[1, 19] = new MyHeader("세로");
                grid1[1, 20] = new MyHeader("최대");
                grid1[1, 21] = new MyHeader("최소");
                //
                grid1.Columns[0].Width = 100;
                grid1.Columns[1].Width = 30;
                grid1.Columns[2].Width = 30;
                grid1.Columns[3].Width = 50;  //업종-1
                grid1.Columns[4].Width = 90;  //업종-2
                grid1.Columns[5].Width = 80;  //제본조건
                grid1.Columns[6].Width = 40;  //제본코드
                grid1.Columns[7].Width = 150;  //기계이름
                grid1.Columns[8].Width = 80;  //인쇄방식
                grid1.Columns[9].Width =130;  //기종 
                grid1.Columns[10].Width = 50;  //년식
                grid1.Columns[11].Width = 70;  //기계등급
                grid1.Columns[12].Width = 50;  //표지최소
                grid1.Columns[13].Width = 50;  //
                grid1.Columns[14].Width = 50; //표지최대
                grid1.Columns[15].Width = 50; //
                grid1.Columns[16].Width = 50; //최소책싸이즈
                grid1.Columns[17].Width = 50; //
                grid1.Columns[18].Width = 50; //최대책싸이즈
                grid1.Columns[19].Width = 50; //
                grid1.Columns[20].Width = 50; //책두께(세네카)
                grid1.Columns[21].Width = 50; //
                grid1.Columns[22].Width = 50; //콤마수
                grid1.Columns[23].Width = 50; //단가폼
            }
            #endregion

            #region 코팅기계
            else if (xsn == 3)         //코팅
            {
                grid1[0, 0] = new SourceGrid.Cells.ColumnHeader("row_id");
                grid1[0, 0].RowSpan = 2;
                grid1.Columns[0].Visible = false;

                grid1[0, 1] = new MyHeader1("√");
                grid1[0, 1].RowSpan = 2;

                grid1[0, 2] = new MyHeader1("No");
                grid1[0, 2].RowSpan = 2;

                grid1[0, 3] = new MyHeader1("업종1");
                grid1[0, 3].RowSpan = 2;

                grid1[0, 4] = new MyHeader1("업종2");
                grid1[0, 4].RowSpan = 2;

                grid1[0, 5] = new MyHeader1("업종3");
                grid1[0, 5].RowSpan = 2;
                grid1.Columns[5].Visible = false;

                grid1[0, 6] = new MyHeader1("기계이름");
                grid1[0, 6].RowSpan = 2;

                grid1[0, 7] = new MyHeader1("판형");
                grid1[0, 7].RowSpan = 2;

                grid1[0, 8] = new MyHeader1("기  종");
                grid1[0, 8].RowSpan = 2;

                grid1[0, 9] = new MyHeader1("년식");
                grid1[0, 9].RowSpan = 2;

                grid1[0, 10] = new MyHeader1("기계등급");
                grid1[0, 10].RowSpan = 2;

                grid1[0,11] = new MyHeader1("수량");
                grid1[0,11].RowSpan = 2;

                grid1[0, 12] = new MyHeader1("종이G");
                grid1[0, 12].RowSpan = 2;

                grid1[0, 13] = new MyHeader1("종이무게");
                grid1[0, 13].ColumnSpan = 2;

                grid1[0, 15] = new MyHeader1("종이 최대싸이즈");
                grid1[0, 15].ColumnSpan = 2;

                grid1[0, 17] = new MyHeader1("종이 최소싸이즈");
                grid1[0, 17].ColumnSpan = 2;

                grid1[0, 19] = new MyHeader1("단가폼");
                grid1[0, 19].RowSpan = 2;
                // grid1.Rows.Insert(1);
                grid1[1, 13] = new MyHeader("최소");
                grid1[1, 14] = new MyHeader("최대");
                grid1[1, 15] = new MyHeader("가로");
                grid1[1, 16] = new MyHeader("세로");
                grid1[1, 17] = new MyHeader("가로");
                grid1[1, 18] = new MyHeader("세로");

                
                //
                grid1.Columns[0].Width = 100;
                grid1.Columns[1].Width = 30;
                grid1.Columns[2].Width = 30;  //no
                grid1.Columns[3].Width = 70;  //업종-1
                grid1.Columns[4].Width = 80;  //업종-2
                grid1.Columns[5].Width = 100; //업종-3
                grid1.Columns[6].Width = 150;  //기계이름
                grid1.Columns[7].Width = 60;  //판형
                grid1.Columns[8].Width = 120; //기종 
                grid1.Columns[9].Width = 40;  //년식
                grid1.Columns[10].Width = 70;  //기계등급
                grid1.Columns[11].Width = 40; //수량
                grid1.Columns[12].Width = 60; //종이G
                grid1.Columns[13].Width = 60; //종이무게
                grid1.Columns[14].Width = 60; //
                grid1.Columns[15].Width = 60; //종이최대싸이즈
                grid1.Columns[16].Width = 60; //
                grid1.Columns[17].Width = 60; //종이최소싸이즈
                grid1.Columns[18].Width = 60; //
                grid1.Columns[19].Width = 50; //단가폼
            }
            #endregion

            #region 접지기계
            else if (xsn == 4)      //접지
            {
                grid1[0, 0] = new SourceGrid.Cells.ColumnHeader("row_id");
                grid1[0, 0].RowSpan = 2;
                grid1.Columns[0].Visible = false;

                grid1[0, 1] = new MyHeader1("√");
                grid1[0, 1].RowSpan = 2;

                grid1[0, 2] = new MyHeader1("No");
                grid1[0, 2].RowSpan = 2;

                grid1[0, 3] = new MyHeader1("업종1");
                grid1[0, 3].RowSpan = 2;

                grid1[0, 4] = new MyHeader1("업종2");
                grid1[0, 4].RowSpan = 2;

                grid1[0, 5] = new MyHeader1("기계이름");
                grid1[0, 5].RowSpan = 2;

                grid1[0, 6] = new MyHeader1("판형");
                grid1[0, 6].RowSpan = 2;
                
                grid1[0, 7] = new MyHeader1("기  종");
                grid1[0, 7].RowSpan = 2;

                grid1[0, 8] = new MyHeader1("년식");
                grid1[0, 8].RowSpan = 2;

                grid1[0, 9] = new MyHeader1("기계등급");
                grid1[0, 9].RowSpan = 2;

                grid1[0, 10] = new MyHeader1("수량");
                grid1[0, 10].RowSpan = 2;

                grid1[0, 11] = new MyHeader1("종이구와이");
                grid1[0, 11].ColumnSpan = 2;

                grid1[0, 13] = new MyHeader1("종이최대싸이즈");
                grid1[0, 13].ColumnSpan = 2;

                grid1[0, 15] = new MyHeader1("종이최소싸이즈");
                grid1[0, 15].ColumnSpan = 2;

                grid1[0, 17] = new MyHeader1("발   체");
                grid1[0, 17].ColumnSpan = 2;

                grid1[0, 19] = new MyHeader1("최소접지간격");
                grid1[0, 19].RowSpan = 2;

                grid1[0, 20] = new MyHeader1("단가폼");
                grid1[0, 20].RowSpan = 2;

                // grid1.Rows.Insert(1);
                grid1[1, 11] = new MyHeader("최소");
                grid1[1, 12] = new MyHeader("최대");
                grid1[1, 13] = new MyHeader("구와이");
                grid1[1, 14] = new MyHeader("하리");
                grid1[1, 15] = new MyHeader("구와이");
                grid1[1, 16] = new MyHeader("하리");
                grid1[1, 17] = new MyHeader("1차");
                grid1[1, 18] = new MyHeader("2차");
                //
                grid1.Columns[0].Width = 100;
                grid1.Columns[1].Width = 30;
                grid1.Columns[2].Width = 30;
                grid1.Columns[3].Width = 60;  //업종-1
                grid1.Columns[4].Width = 70;  //업종-2
                grid1.Columns[5].Width = 150; //기계이름
                grid1.Columns[6].Width = 60;  //판형 
                grid1.Columns[7].Width = 50;  //기종
                grid1.Columns[8].Width = 50;  //년식
                grid1.Columns[9].Width = 70;  //기계등급
                grid1.Columns[10].Width = 50;  //수량
                
                grid1.Columns[11].Width = 50; //종이구와이1
                grid1.Columns[12].Width = 50; //종이구와이2
                grid1.Columns[13].Width = 50; //종이최대싸이즈1
                grid1.Columns[14].Width = 50; //종이최대싸이즈2
                grid1.Columns[15].Width = 50; //종이최소싸이즈1
                grid1.Columns[16].Width = 50;//종이최소싸이즈2
                grid1.Columns[17].Width = 50; //발체1
                grid1.Columns[18].Width = 50; //발체2
                grid1.Columns[19].Width = 80; //최소접지간격
                grid1.Columns[20].Width = 60; //단가폼
            }
            #endregion

            #region 기타기계
            else if (xsn == 5)       //기타
            {
                grid1[0, 0] = new SourceGrid.Cells.ColumnHeader("row_id");
                grid1[0, 0].RowSpan = 2;
                grid1.Columns[0].Visible = false;

                grid1[0, 1] = new MyHeader1("√");
                grid1[0, 1].RowSpan = 2;

                grid1[0, 2] = new MyHeader1("No");
                grid1[0, 2].RowSpan = 2;

                grid1[0, 3] = new MyHeader1("업종1");
                grid1[0, 3].RowSpan = 2;

                grid1[0, 4] = new MyHeader1("업종2");
                grid1[0, 4].RowSpan = 2;

                grid1[0, 5] = new MyHeader1("업종3");
                grid1[0, 5].RowSpan = 2;

                grid1[0, 6] = new MyHeader1("기계이름");
                grid1[0, 6].RowSpan = 2;

                grid1[0, 7] = new MyHeader1("판형 [A]");
                grid1[0, 7].RowSpan = 2;

                grid1[0, 8] = new MyHeader1("기종");
                grid1[0, 8].RowSpan = 2;

                grid1[0, 9] = new MyHeader1("연식");
                grid1[0, 9].RowSpan = 2;

                grid1[0,10] = new MyHeader1("수량");
                grid1[0,10].RowSpan = 2;

                grid1[0, 11] = new MyHeader1("종이\r\n\r\n구와이 [B]");
                grid1[0,11].RowSpan = 2;
 
                grid1[0, 12] = new MyHeader1("종이무게 [C]");
                grid1[0, 12].ColumnSpan = 2;

                grid1[0, 14] = new MyHeader1("종이 최대싸이즈");
                grid1[0, 14].ColumnSpan = 2;

                grid1[0, 16] = new MyHeader1("종이 최소싸이즈");
                grid1[0, 16].ColumnSpan = 2;

                grid1[0, 18] = new MyHeader1("최대\r\n\r\n접착면 [F]");
                grid1[0, 18].RowSpan = 2;

                grid1[0, 19] = new MyHeader1("최대싸이즈");
                grid1[0, 19].ColumnSpan = 3;

                grid1[0, 22] = new MyHeader1("최소싸이즈");
                grid1[0, 22].ColumnSpan = 3;

                grid1[0, 25] = new MyHeader1("단가폼");
                grid1[0, 25].RowSpan = 2;
                // grid1.Rows.Insert(1);
                grid1[1, 12] = new MyHeader("최소");
                grid1[1, 13] = new MyHeader("최대");
                grid1[1, 14] = new MyHeader("가로[D]");
                grid1[1, 15] = new MyHeader("세로[E]");
                grid1[1, 16] = new MyHeader("가로[D]");
                grid1[1, 17] = new MyHeader("세로[E]");
                grid1[1, 19] = new MyHeader("장[G]");
                grid1[1, 20] = new MyHeader("폭[H]");
                grid1[1, 21] = new MyHeader("고[I]");
                grid1[1, 22] = new MyHeader("장[G]");
                grid1[1, 23] = new MyHeader("폭[H]");
                grid1[1, 24] = new MyHeader("고[I]");
                //
                grid1.Columns[0].Width = 100;
                grid1.Columns[1].Width = 30;
                grid1.Columns[2].Width = 30;
                grid1.Columns[3].Width = 50;  //업종-1
                grid1.Columns[4].Width = 60;  //업종-2
                grid1.Columns[5].Width = 80;  //업종-3
                grid1.Columns[6].Width = 150;  //기계이름
                grid1.Columns[7].Width = 60;  //판형 
                grid1.Columns[8].Width = 40;  //기종
                grid1.Columns[9].Width = 40;  //연식
                grid1.Columns[10].Width = 40; //수량
                grid1.Columns[11].Width = 70; //종이구와이
                grid1.Columns[12].Width = 50; //종이무게(최소)
                grid1.Columns[13].Width = 50; //종이무게(최대)
                grid1.Columns[14].Width = 60; //종이최대싸이즈(가로)
                grid1.Columns[15].Width = 60; //종이최대싸이즈(세로)
                grid1.Columns[16].Width = 60; //종이최소싸이즈(가로)
                grid1.Columns[17].Width = 60; //종이최소싸이즈(세로)
                grid1.Columns[18].Width = 70; //최대접착면
                grid1.Columns[19].Width = 36; //최대싸이즈(장)
                grid1.Columns[20].Width = 36; //최대싸이즈(폭)
                grid1.Columns[21].Width = 36; //최대싸이즈(고)
                grid1.Columns[22].Width = 36; //최소싸이즈(장)
                grid1.Columns[23].Width = 36; //최소싸이즈(폭)
                grid1.Columns[24].Width = 36; //최소싸이즈(고)
                grid1.Columns[25].Width = 50; //단가폼
            }
            #endregion

            var DBConn = new MySqlConnection(Config.DB_con1);
            DBConn.Open();
            string cQuery = "";
            if (xsn == 2)
                cQuery = " select a.jebon_code,f.hang as j_hang, a.*, b.aitem d1,c.bitem d2,d.citem d3, e.hang as pan_hang FROM C_pmachine a ";
            else
                cQuery = " select a.*,b.aitem d1,c.bitem d2,d.citem d3, e.hang as pan_hang FROM C_pmachine a";
            cQuery += " Left Outer Join C_amodel b ON b.a_code=a.a_model"; 
            cQuery += " Left Outer Join C_bmodel c ON c.a_code=a.a_model and c.b_code=a.b_model";
            cQuery += " Left Outer Join C_cmodel d ON d.a_code=a.a_model and d.b_code=a.b_model and d.c_code=a.c_model";
            cQuery += " Left Outer Join hang_manage e ON a.pan_type = e.code1  and e.class = '판형'";
            if (xsn == 2)
                cQuery += "  Left outer join hang_manage f on a.jebon_code=f.code1 and f.class = '제본옵션' ";

            if (xsn == 5)
                cQuery += " where a.form_id='5'"; 
            else
                cQuery += " where a.a_model='" + a_code + "'";
            // 
            if (textBox1.Text != "")
            {
                if(radioButton1.Checked == true)
                    cQuery += " and b.aitem like '%" + textBox1.Text + "%'";
                else if (radioButton2.Checked == true)
                    cQuery += " and c.bitem like '%" + textBox1.Text + "%'";
                else if (radioButton3.Checked == true)
                    cQuery += " and d.citem like '%" + textBox1.Text + "%'";
            }
            // 
            var cmd = new MySqlCommand(cQuery, DBConn);
            var myRead = cmd.ExecuteReader();
            int m = 2;
            DataRow[] dr ;
            string temp = "";
            while (myRead.Read())
            {
                if (xsn == 2)      //제본기계
                {
                    grid1.Rows.Insert(m);
                    grid1.Rows[m].Height = 24;
                    grid1[m, 0] = new SourceGrid.Cells.Cell(myRead["row_id"], typeof(string));
                    grid1[m, 1] = new SourceGrid.Cells.CheckBox(null, false);            //"√"
                    grid1[m, 2] = new SourceGrid.Cells.Cell(myRead["no"], typeof(string));//No
                    grid1[m, 2].Editor = cc.disable_cell;
                    grid1[m, 2].View = cc.center_cell;
                    grid1[m, 3] = new SourceGrid.Cells.Cell(myRead["d1"], typeof(string));//"업종1"
                    grid1[m, 3].Editor = cc.disable_cell;
                    grid1[m, 3].View = cc.left_cell;
                    grid1[m, 4] = new SourceGrid.Cells.Cell(myRead["d2"], typeof(string));//"업종2"
                    grid1[m, 4].Editor = cc.disable_cell;
                    grid1[m, 4].View = cc.left_cell;
                    grid1[m, 5] = new SourceGrid.Cells.Cell(myRead["j_hang"], typeof(string));//제본조건
                    grid1[m, 5].Editor = cc.disable_cell;
                    grid1[m, 5].View = cc.center_cell;
                    grid1[m, 6] = new SourceGrid.Cells.Cell(myRead["jebon_code"], typeof(string));//제본코드
                    grid1[m, 6].View = cc.center_cell;
                    grid1[m, 7] = new SourceGrid.Cells.Cell(myRead["machin_name"], typeof(string));//"기계이름"
                    //
                    temp = myRead["print_type"].ToString().Trim() ;
                    dr = prn_dt.Select("b_code='" + temp + "'");
                    if (dr.Length != 0)
                        grid1[m, 8] = new SourceGrid.Cells.Cell(dr[0]["bitem"].ToString(), typeof(string));  //"인쇄방식"
                    else
                        grid1[m, 8] = new SourceGrid.Cells.Cell(" ", typeof(string));  //"인쇄방식"
                    //
                    grid1[m, 8].View = cc.center_cellb;
                    grid1[m, 8].Editor = cc.disable_cell;
                    grid1[m, 9] = new SourceGrid.Cells.Cell(myRead["machin_model"], typeof(string));//"기  종"
                    grid1[m, 10] = new SourceGrid.Cells.Cell(myRead["year_type"], typeof(string));//"년식"
                    grid1[m, 10].View = cc.center_cell;
                    grid1[m, 11] = new SourceGrid.Cells.Cell(myRead["machine_grade"], typeof(string));//"기계등급"
                    grid1[m, 11].View = cc.center_cell;                
                    grid1[m, 12] = new SourceGrid.Cells.Cell(myRead["c_garo_min"], typeof(string));//"표지 최소(가로)"
                    grid1[m, 12].View = cc.int_cell;
                    grid1[m, 13] = new SourceGrid.Cells.Cell(myRead["c_sero_min"], typeof(string));//"표지 최소(세로)"
                    grid1[m, 13].View = cc.int_cell;
                    grid1[m, 14] = new SourceGrid.Cells.Cell(myRead["c_garo_max"], typeof(string));//"표지 최대(가로)"
                    grid1[m, 14].View = cc.int_cell;
                    grid1[m, 15] = new SourceGrid.Cells.Cell(myRead["c_sero_max"], typeof(string));//"표지 최대(세로)"
                    grid1[m, 15].View = cc.int_cell;
                    grid1[m, 16] = new SourceGrid.Cells.Cell(myRead["d_garo_min"], typeof(string));//"최소 책싸이즈(가로)"
                    grid1[m, 16].View = cc.int_cell;
                    grid1[m, 17] = new SourceGrid.Cells.Cell(myRead["d_sero_min"], typeof(string));//"최소 책싸이즈(세로)"
                    grid1[m, 17].View = cc.int_cell;
                    grid1[m, 18] = new SourceGrid.Cells.Cell(myRead["d_garo_max"], typeof(string));//"최대 책싸이즈(가로)"
                    grid1[m, 18].View = cc.int_cell;
                    grid1[m, 19] = new SourceGrid.Cells.Cell(myRead["d_sero_max"], typeof(string));//"최대 책싸이즈(세로)"
                    grid1[m, 19].View = cc.int_cell;
                    grid1[m, 20] = new SourceGrid.Cells.Cell(myRead["seneca_max"], typeof(string));//"책두께(세네카)(최대)
                    grid1[m, 20].View = cc.int_cell;
                    grid1[m, 21] = new SourceGrid.Cells.Cell(myRead["seneca_min"], typeof(string));//"책두께(세네카)(최소)
                    grid1[m, 21].View = cc.int_cell;
                    grid1[m, 22] = new SourceGrid.Cells.Cell(myRead["koma_su"], typeof(string)); //"콤마수";
                    grid1[m, 22].View = cc.int_cell;
                    grid1[m, 23] = new SourceGrid.Cells.Cell(myRead["danga_form"], typeof(string));//"단가폼";
                    grid1[m, 23].View = cc.center_cellb;
                    //
                    if (x_id == "2")
                    {
                        grid1[m, 2].Editor = cc.disable_cell;
                        grid1[m, 3].Editor = cc.disable_cell;
                        grid1[m, 4].Editor = cc.disable_cell;
                        grid1[m, 7].Editor = cc.disable_cell;
                        grid1[m, 8].Editor = cc.disable_cell;
                        grid1[m, 9].Editor = cc.disable_cell;
                        grid1[m, 10].Editor = cc.disable_cell;
                        grid1[m, 11].Editor = cc.disable_cell;
                        grid1[m, 12].Editor = cc.disable_cell;
                        grid1[m, 13].Editor = cc.disable_cell;
                        grid1[m, 14].Editor = cc.disable_cell;
                        grid1[m, 15].Editor = cc.disable_cell;
                        grid1[m, 16].Editor = cc.disable_cell;
                        grid1[m, 17].Editor = cc.disable_cell;
                        grid1[m, 18].Editor = cc.disable_cell;
                        grid1[m, 19].Editor = cc.disable_cell;
                        grid1[m, 20].Editor = cc.disable_cell;
                        grid1[m, 21].Editor = cc.disable_cell;
                        grid1[m, 22].Editor = cc.disable_cell;
                        grid1[m, 23].Editor = cc.disable_cell;
                    }
                }
                else if (xsn == 3)      //코팅기계
                {
                    grid1.Rows.Insert(m);
                    grid1.Rows[m].Height = 24;
                    grid1[m, 0] = new SourceGrid.Cells.Cell(myRead["row_id"], typeof(string));
                    grid1[m, 1] = new SourceGrid.Cells.CheckBox(null, false);               //√
                    grid1[m, 2] = new SourceGrid.Cells.Cell(myRead["no"], typeof(string));   //no
                    grid1[m, 2].Editor = cc.disable_cell;
                    grid1[m, 2].View = cc.center_cell;                                              
                    grid1[m, 3] = new SourceGrid.Cells.Cell(myRead["d1"], typeof(string));   //업종1 
                    grid1[m, 3].Editor = cc.disable_cell;
                    grid1[m, 4] = new SourceGrid.Cells.Cell(myRead["d2"], typeof(string));   //업종2
                    grid1[m, 4].Editor = cc.disable_cell;
                    grid1[m, 5] = new SourceGrid.Cells.Cell(myRead["d3"], typeof(string));   //업종3
                    grid1[m, 5].Editor = cc.disable_cell;
                    grid1[m, 6] = new SourceGrid.Cells.Cell(myRead["machin_name"], typeof(string));  //기계이름 
                    grid1[m, 7] = new SourceGrid.Cells.Cell(myRead["pan_hang"], typeof(string));     //판형
                    grid1[m, 7].Editor = cb_pantype;
                    grid1[m, 8] = new SourceGrid.Cells.Cell(myRead["machin_model"], typeof(string)); //기종
                    grid1[m, 9] = new SourceGrid.Cells.Cell(myRead["year_type"], typeof(string));    //년식 
                    grid1[m, 9].View = cc.center_cell;
                    grid1[m, 10] = new SourceGrid.Cells.Cell(myRead["machine_grade"], typeof(string));//"기계등급"
                    grid1[m, 10].View = cc.center_cell;                
                    grid1[m, 11] = new SourceGrid.Cells.Cell(myRead["machin_su"], typeof(string));  //수량;
                    grid1[m, 11].View = cc.center_cell;                                              
                    grid1[m, 12] = new SourceGrid.Cells.Cell(myRead["paper_guy"], typeof(string));  //종이G
                    grid1[m, 12].View = cc.center_cell;                                             
                    grid1[m, 13] = new SourceGrid.Cells.Cell(myRead["p_weight_min"], typeof(string));  //종이무게(최소) 
                    grid1[m, 13].View = cc.int_cell;
                    grid1[m, 14] = new SourceGrid.Cells.Cell(myRead["p_weight_max"], typeof(string));  //종이무게(최대)
                    grid1[m, 14].View = cc.int_cell;                                            
                    grid1[m, 15] = new SourceGrid.Cells.Cell(myRead["p_garo_max"], typeof(string));  //종이 최대싸이즈(가로)
                    grid1[m, 15].View = cc.int_cell;
                    grid1[m, 16] = new SourceGrid.Cells.Cell(myRead["p_sero_max"], typeof(string));  //종이 최대싸이즈(세로) 
                    grid1[m, 16].View = cc.int_cell;
                    grid1[m, 17] = new SourceGrid.Cells.Cell(myRead["p_garo_min"], typeof(string));  //종이 최소싸이즈(가로)
                    grid1[m, 17].View = cc.int_cell;
                    grid1[m, 18] = new SourceGrid.Cells.Cell(myRead["p_sero_min"], typeof(string));  //종이 최소싸이즈(세로)
                    grid1[m, 18].View = cc.int_cell;                                            
                    grid1[m, 19] = new SourceGrid.Cells.Cell(myRead["danga_form"], typeof(string)); //단가폼
                    grid1[m, 19].View = cc.center_cellb;
//
                    if (x_id == "2")                                                          
                    {                                                                        
                        grid1[m, 2].Editor = cc.disable_cell;
                        grid1[m, 3].Editor = cc.disable_cell;                                    
                        grid1[m, 4].Editor = cc.disable_cell;                                   
                        grid1[m, 5].Editor = cc.disable_cell;
                        grid1[m, 6].Editor = cc.disable_cell;                                    
                        grid1[m, 7].Editor = cc.disable_cell;                                   
                        grid1[m, 8].Editor = cc.disable_cell;
                        grid1[m, 9].Editor = cc.disable_cell;                                    
                        grid1[m, 10].Editor = cc.disable_cell;                                  
                        grid1[m, 11].Editor = cc.disable_cell;
                        grid1[m, 12].Editor = cc.disable_cell;                                   
                        grid1[m, 13].Editor = cc.disable_cell;
                        grid1[m, 14].Editor = cc.disable_cell;
                        grid1[m, 15].Editor = cc.disable_cell;
                        grid1[m, 16].Editor = cc.disable_cell;
                        grid1[m, 17].Editor = cc.disable_cell;
                        grid1[m, 18].Editor = cc.disable_cell;
                        grid1[m, 19].Editor = cc.disable_cell;
                    }
                }
                else if (xsn == 4)          //접지기계
                {
                    grid1.Rows.Insert(m);
                    grid1.Rows[m].Height = 24;
                    grid1[m, 0] = new SourceGrid.Cells.Cell(myRead["row_id"], typeof(string));
                    grid1[m, 1] = new SourceGrid.Cells.CheckBox(null, false);              //√
                    grid1[m, 2] = new SourceGrid.Cells.Cell(myRead["no"], typeof(string));  //no
                    grid1[m, 2].Editor = cc.disable_cell;
                    grid1[m, 2].View = cc.center_cell;
                    grid1[m, 3] = new SourceGrid.Cells.Cell(myRead["d1"], typeof(string));  //업종1
                    grid1[m, 3].Editor = cc.disable_cell;
                    grid1[m, 4] = new SourceGrid.Cells.Cell(myRead["d2"], typeof(string));  //업종2  
                    grid1[m, 4].Editor = cc.disable_cell;
                    grid1[m, 5] = new SourceGrid.Cells.Cell(myRead["machin_name"], typeof(string));  //기계이름
                    grid1[m, 6] = new SourceGrid.Cells.Cell(myRead["pan_hang"], typeof(string));  //판형
                    grid1[m, 6].Editor = cb_pantype;
                    grid1[m, 7] = new SourceGrid.Cells.Cell(myRead["machin_model"], typeof(string));  //기종
                    grid1[m, 7].View = cc.center_cell;
                    grid1[m, 8] = new SourceGrid.Cells.Cell(myRead["year_type"], typeof(string));  //년식              
                    grid1[m, 8].View = cc.int_cell;

                    grid1[m, 8] = new SourceGrid.Cells.Cell(myRead["year_type"], typeof(string));  //기계등급              
                    grid1[m, 8].View = cc.int_cell;
                    grid1[m, 9] = new SourceGrid.Cells.Cell(myRead["machine_grade"], typeof(string));//"기계등급"
                    grid1[m, 9].View = cc.center_cell;        

                    grid1[m, 10] = new SourceGrid.Cells.Cell(myRead["machin_su"], typeof(string));  //수량
                    grid1[m, 10].View = cc.int_cell;                                                        
                    grid1[m, 11] = new SourceGrid.Cells.Cell(myRead["p_weight_min"], typeof(string));  //종이무게(최소)
                    grid1[m, 11].View = cc.int_cell;
                    grid1[m, 12] = new SourceGrid.Cells.Cell(myRead["p_weight_max"], typeof(string));  //종이무게(최대) 
                    grid1[m, 12].View = cc.int_cell;                                             
                    grid1[m, 13] = new SourceGrid.Cells.Cell(myRead["p_garo_max"], typeof(string));  //종이최대싸이즈(구와이)
                    grid1[m, 13].View = cc.int_cell;                                                       
                    grid1[m, 14] = new SourceGrid.Cells.Cell(myRead["p_sero_max"], typeof(string));  //종이최대싸이즈(하리)
                    grid1[m, 14].View = cc.int_cell;
                    grid1[m, 15] = new SourceGrid.Cells.Cell(myRead["p_garo_min"], typeof(string));  //종이최소싸이즈(구와이)
                    grid1[m, 15].View = cc.int_cell;
                    grid1[m, 16] = new SourceGrid.Cells.Cell(myRead["p_garo_min"], typeof(string));  //종이최소싸이즈(하리)
                    grid1[m, 16].View = cc.int_cell;
                    grid1[m, 17] = new SourceGrid.Cells.Cell(myRead["balche_1"], typeof(string)); //발체1
                    grid1[m, 18] = new SourceGrid.Cells.Cell(myRead["balche_2"], typeof(string)); //발체2
                    grid1[m, 19] = new SourceGrid.Cells.Cell(myRead["jubji_min_gap"], typeof(string)); //최소접지간격
                    grid1[m, 20] = new SourceGrid.Cells.Cell(myRead["danga_form"], typeof(string)); //단가폼
                    grid1[m, 20].View = cc.center_cellb;
                    //                                                                                  
                    if (x_id == "2")                                                                    
                    {                                                                                   
                        grid1[m, 2].Editor = cc.disable_cell;
                        grid1[m, 3].Editor = cc.disable_cell;
                        grid1[m, 4].Editor = cc.disable_cell;
                        grid1[m, 5].Editor = cc.disable_cell;
                        grid1[m, 6].Editor = cc.disable_cell;
                        grid1[m, 7].Editor = cc.disable_cell;
                        grid1[m, 8].Editor = cc.disable_cell;
                        grid1[m, 9].Editor = cc.disable_cell;
                        grid1[m, 10].Editor = cc.disable_cell;
                        grid1[m, 11].Editor = cc.disable_cell;
                        grid1[m, 12].Editor = cc.disable_cell;
                        grid1[m, 13].Editor = cc.disable_cell;
                        grid1[m, 14].Editor = cc.disable_cell;
                        grid1[m, 15].Editor = cc.disable_cell;
                        grid1[m, 16].Editor = cc.disable_cell;
                        grid1[m, 17].Editor = cc.disable_cell;
                        grid1[m, 18].Editor = cc.disable_cell;
                        grid1[m, 19].Editor = cc.disable_cell;
                        grid1[m, 20].Editor = cc.disable_cell;
                    }
                }
                //
                else if (xsn == 5)            //기타기계
                {
                    grid1.Rows.Insert(m);
                    grid1.Rows[m].Height = 24;
                    grid1[m, 0] = new SourceGrid.Cells.Cell(myRead["row_id"], typeof(string));
                    grid1[m, 1] = new SourceGrid.Cells.CheckBox(null, false);
                    grid1[m, 2] = new SourceGrid.Cells.Cell(myRead["no"], typeof(string));
                    grid1[m, 2].Editor = cc.disable_cell;
                    grid1[m, 2].View = cc.center_cell;
                    grid1[m, 3] = new SourceGrid.Cells.Cell(myRead["d1"], typeof(string)); //업종-1
                    grid1[m, 3].Editor = cc.disable_cell;
                    grid1[m, 4] = new SourceGrid.Cells.Cell(myRead["d2"], typeof(string)); //업종-2
                    grid1[m, 4].Editor = cc.disable_cell;
                    grid1[m, 5] = new SourceGrid.Cells.Cell(myRead["d3"], typeof(string)); //업종-3
                    grid1[m, 5].Editor = cc.disable_cell;
                    grid1[m, 6] = new SourceGrid.Cells.Cell(myRead["machin_name"], typeof(string)); //기계이름
                    grid1[m, 7] = new SourceGrid.Cells.Cell(myRead["pan_hang"], typeof(string));  //판형
                    grid1[m, 7].Editor = cb_pantype;
                    grid1[m, 7].View = cc.center_cell;
                    grid1[m, 8] = new SourceGrid.Cells.Cell(myRead["machin_model"], typeof(string));  //기종
                    grid1[m, 8].View = cc.center_cell;
                    grid1[m, 9] = new SourceGrid.Cells.Cell(myRead["year_type"], typeof(string));  //연식
                    grid1[m, 9].View = cc.center_cell;
                    grid1[m, 10] = new SourceGrid.Cells.Cell(myRead["machin_su"], typeof(string));  //수량
                    grid1[m, 10].View = cc.int_cell;
                    grid1[m, 11] = new SourceGrid.Cells.Cell(myRead["paper_guy"], typeof(string));  //종이구와이
                    grid1[m, 11].View = cc.int_cell;
                    grid1[m, 12] = new SourceGrid.Cells.Cell(myRead["p_weight_min"], typeof(string));  //종이무게(최소)
                    grid1[m, 12].View = cc.int_cell;
                    grid1[m, 13] = new SourceGrid.Cells.Cell(myRead["p_weight_max"], typeof(string));  //종이무게(최대)
                    grid1[m, 13].View = cc.int_cell;
                    grid1[m, 14] = new SourceGrid.Cells.Cell(myRead["p_garo_max"], typeof(string));  //종이최대싸이즈(가로)
                    grid1[m, 14].View = cc.int_cell;
                    grid1[m, 15] = new SourceGrid.Cells.Cell(myRead["p_sero_max"], typeof(string));  //종이최대싸이즈(세로)
                    grid1[m, 15].View = cc.int_cell;

                    grid1[m, 16] = new SourceGrid.Cells.Cell(myRead["p_garo_min"], typeof(string));  //종이최소싸이즈(가로)
                    grid1[m, 16].View = cc.int_cell;
                    grid1[m, 17] = new SourceGrid.Cells.Cell(myRead["p_sero_min"], typeof(string));  //종이최소싸이즈(세로)
                    grid1[m, 17].View = cc.int_cell;

                    grid1[m, 18] = new SourceGrid.Cells.Cell(myRead["bond_max"], typeof(string));  //초대접착면

                    grid1[m, 19] = new SourceGrid.Cells.Cell(myRead["jang_max"], typeof(string));  //최대싸이즈(장)
                    grid1[m, 19].View = cc.int_cell;
                    grid1[m, 20] = new SourceGrid.Cells.Cell(myRead["pok_max"], typeof(string));  //최대싸이즈(폭)
                    grid1[m, 20].View = cc.int_cell;
                    grid1[m, 21] = new SourceGrid.Cells.Cell(myRead["go_max"], typeof(string));  //최대싸이즈(고)
                    grid1[m, 21].View = cc.int_cell;

                    grid1[m, 22] = new SourceGrid.Cells.Cell(myRead["jang_min"], typeof(string));  //최소싸이즈(장)
                    grid1[m, 22].View = cc.int_cell;
                    grid1[m, 23] = new SourceGrid.Cells.Cell(myRead["pok_min"], typeof(string));  //최소싸이즈(폭)
                    grid1[m, 23].View = cc.int_cell;
                    grid1[m, 24] = new SourceGrid.Cells.Cell(myRead["go_min"], typeof(string));  //최소싸이즈(고)
                    grid1[m, 24].View = cc.int_cell;

                    grid1[m, 25] = new SourceGrid.Cells.Cell(myRead["danga_form"], typeof(string));  //단가폼
                    grid1[m, 25].View = cc.center_cellb;
                    //
                    if (x_id == "2")
                    {
                        grid1[m, 2].Editor = cc.disable_cell;
                        grid1[m, 3].Editor = cc.disable_cell;
                        grid1[m, 4].Editor = cc.disable_cell;
                        grid1[m, 5].Editor = cc.disable_cell;
                        grid1[m, 6].Editor = cc.disable_cell;
                        grid1[m, 7].Editor = cc.disable_cell;
                        grid1[m, 8].Editor = cc.disable_cell;
                        grid1[m, 9].Editor = cc.disable_cell;
                        grid1[m, 10].Editor = cc.disable_cell;
                        grid1[m, 11].Editor = cc.disable_cell;
                        grid1[m, 12].Editor = cc.disable_cell;
                        grid1[m, 13].Editor = cc.disable_cell;
                        grid1[m, 14].Editor = cc.disable_cell;
                        grid1[m, 15].Editor = cc.disable_cell;
                        grid1[m, 16].Editor = cc.disable_cell;
                        grid1[m, 17].Editor = cc.disable_cell;
                        grid1[m, 18].Editor = cc.disable_cell;
                        grid1[m, 19].Editor = cc.disable_cell;
                        grid1[m, 20].Editor = cc.disable_cell;
                        grid1[m, 21].Editor = cc.disable_cell;
                        grid1[m, 22].Editor = cc.disable_cell;
                        grid1[m, 23].Editor = cc.disable_cell;
                        grid1[m, 24].Editor = cc.disable_cell;
                        grid1[m, 25].Editor = cc.disable_cell;
                    }
                }
                m++;
            }
            myRead.Close();
            DBConn.Close();
            grid1.Focus();
        }
        //
        public class ValueChangedEvent : SourceGrid.Cells.Controllers.ControllerBase   //내용 수정
        {
            public override void OnValueChanged(SourceGrid.CellContext sender, EventArgs e)
            {

                base.OnValueChanged(sender, e);
                int ps = sender.Position.Column;
                SourceGrid.Grid grid = (SourceGrid.Grid)sender.Grid;
                string cQuery = "";
                string row_no = grid[grid.Selection.ActivePosition.Row, 0].ToString().Trim();
                string dat = grid[grid.Selection.ActivePosition.Row, grid.Selection.ActivePosition.Column].ToString().Trim().Replace(",","");
                //
                if (Config.tem_c == "2")
                {
                    if (ps == 6)
                    {
                        try
                        {
                            var DBConn1 = new MySqlConnection(Config.DB_con1);
                            DBConn1.Open();
                            cQuery = "select hang as result from hang_manage where code1 = '" + dat + "' and class='제본옵션'";
                            var cmd1 = new MySqlCommand(cQuery, DBConn1);
                            var myRead1 = cmd1.ExecuteReader();
                            string hang = "";
                            if (myRead1.Read())
                                hang = myRead1["result"].ToString();

                            myRead1.Close();
                            DBConn1.Close();
                            grid[grid.Selection.ActivePosition.Row, 5] = new SourceGrid.Cells.Cell(hang, typeof(string));
                            grid.Refresh();
                            cQuery = " update C_pmachine set jebon_code ='" + dat + "' where row_id='" + row_no + "'";
                        }
                        catch
                        {
                            MessageBox.Show("숫자로만 입력해주세요. 저장되지 않았습니다");
                            return;
                        }
                    }
                    else if (ps == 7)
                        cQuery = " update C_pmachine set machin_name='" + dat + "' where row_id='" + row_no + "'";
                    //else if (ps == 6)
                    //cQuery = " update C_pmachine set print_type='" + dat + "' where row_id='" + row_no + "'";
                    else if (ps == 9)
                        cQuery = " update C_pmachine set machin_model='" + dat + "' where row_id='" + row_no + "'";
                    else if (ps == 10)
                        cQuery = " update C_pmachine set year_type='" + dat + "' where row_id='" + row_no + "'";
                    else if (ps == 11)
                        cQuery = " update C_pmachine set machine_grade='" + dat + "' where row_id='" + row_no + "'";
                    else if (ps == 12)
                        cQuery = " update C_pmachine set c_garo_min='" + dat + "' where row_id='" + row_no + "'";
                    else if (ps == 13)
                        cQuery = " update C_pmachine set c_sero_min='" + dat + "' where row_id='" + row_no + "'";
                    else if (ps == 14)
                        cQuery = " update C_pmachine set c_garo_max='" + dat + "' where row_id='" + row_no + "'";
                    else if (ps == 15)
                        cQuery = " update C_pmachine set c_sero_max='" + dat + "' where row_id='" + row_no + "'";
                    else if (ps == 16)
                        cQuery = " update C_pmachine set d_garo_min='" + dat + "' where row_id='" + row_no + "'";
                    else if (ps == 17)
                        cQuery = " update C_pmachine set d_sero_min='" + dat + "' where row_id='" + row_no + "'";
                    else if (ps == 18)
                        cQuery = " update C_pmachine set d_garo_max='" + dat + "' where row_id='" + row_no + "'";
                    else if (ps == 19)
                        cQuery = " update C_pmachine set d_sero_max='" + dat + "' where row_id='" + row_no + "'";
                    else if (ps == 20)
                        cQuery = " update C_pmachine set seneca_max='" + dat + "' where row_id='" + row_no + "'";
                    else if (ps == 21)
                        cQuery = " update C_pmachine set seneca_min='" + dat + "' where row_id='" + row_no + "'";
                    else if (ps == 22)
                        cQuery = " update C_pmachine set koma_su='" + dat + "' where row_id='" + row_no + "'";
                    else if (ps == 23)
                        cQuery = " update C_pmachine set danga_form='" + dat + "' where row_id='" + row_no + "'";
                    else
                        return;
                }
                else if (Config.tem_c == "3")
                {
                    if (ps == 6)
                        cQuery = " update C_pmachine set machin_name='" + dat + "' where row_id='" + row_no + "'";
                    else if (ps == 7)
                    {

                        cQuery = "select * from hang_manage where hang = '" + dat + "' and class = '판형'";

                        var DBConn1 = new MySqlConnection(Config.DB_con1);
                        DBConn1.Open();
                        var cmd1 = new MySqlCommand(cQuery, DBConn1);
                        var myRead1 = cmd1.ExecuteReader();

                        if (myRead1.Read())
                            dat = myRead1["code1"].ToString().Trim();
                        else
                        {
                            MessageBox.Show("등록되지 않은 판형입니다. 수정에 실패하였습니다");
                            myRead1.Close();
                            DBConn1.Close();
                            return;
                        }

                        myRead1.Close();
                        DBConn1.Close();
                        cQuery = " update C_pmachine set pan_type='" + dat + "' where row_id='" + row_no + "'";
                    }
                    else if (ps == 8)
                        cQuery = " update C_pmachine set machin_model='" + dat + "' where row_id='" + row_no + "'";
                    else if (ps == 9)
                        cQuery = " update C_pmachine set year_type='" + dat + "' where row_id='" + row_no + "'";
                    else if (ps == 10)
                        cQuery = " update C_pmachine set machine_grade='" + dat + "' where row_id='" + row_no + "'";
                    else if (ps == 11)
                        cQuery = " update C_pmachine set machin_su='" + dat + "' where row_id='" + row_no + "'";
                    else if (ps == 12)
                        cQuery = " update C_pmachine set paper_guy='" + dat + "', paper_guy_result=" + dat + " where row_id='" + row_no + "'";
                    else if (ps == 13)
                        cQuery = " update C_pmachine set p_weight_min='" + dat + "' where row_id='" + row_no + "'";
                    else if (ps == 14)
                        cQuery = " update C_pmachine set p_weight_max='" + dat + "' where row_id='" + row_no + "'";
                    else if (ps == 15)
                        cQuery = " update C_pmachine set P_garo_max='" + dat + "' where row_id='" + row_no + "'";
                    else if (ps == 16)
                        cQuery = " update C_pmachine set p_sero_max='" + dat + "' where row_id='" + row_no + "'";
                    else if (ps == 17)
                        cQuery = " update C_pmachine set p_garo_min='" + dat + "' where row_id='" + row_no + "'";
                    else if (ps == 18)
                        cQuery = " update C_pmachine set p_sero_min='" + dat + "' where row_id='" + row_no + "'";
                    else if (ps == 19)
                        cQuery = " update C_pmachine set danga_form='" + dat + "' where row_id='" + row_no + "'";
                    else
                        return;
                }
                else if (Config.tem_c == "4")//접지
                {
                    if (ps == 5)
                        cQuery = " update C_pmachine set machin_name='" + dat + "' where row_id='" + row_no + "'";
                    else if (ps == 6)
                    {

                        cQuery = "select * from hang_manage where hang = '" + dat + "' and class = '판형'";

                        var DBConn1 = new MySqlConnection(Config.DB_con1);
                        DBConn1.Open();
                        var cmd1 = new MySqlCommand(cQuery, DBConn1);
                        var myRead1 = cmd1.ExecuteReader();

                        if (myRead1.Read())
                            dat = myRead1["code1"].ToString().Trim();
                        else
                        {
                            MessageBox.Show("등록되지 않은 판형입니다. 수정에 실패하였습니다");
                            myRead1.Close();
                            DBConn1.Close();
                            return;
                        }

                        myRead1.Close();
                        DBConn1.Close();
                        cQuery = " update C_pmachine set pan_type='" + dat + "' where row_id='" + row_no + "'";
                    }
                    else if (ps == 7)
                        cQuery = " update C_pmachine set machin_model='" + dat + "' where row_id='" + row_no + "'";
                    else if (ps == 8)
                        cQuery = " update C_pmachine set year_type='" + dat + "' where row_id='" + row_no + "'";
                    else if (ps == 9)
                        cQuery = " update C_pmachine set machine_grade='" + dat + "' where row_id='" + row_no + "'";

                    else if (ps == 10)
                        cQuery = " update C_pmachine set machin_su='" + dat + "' where row_id='" + row_no + "'";
                    else if (ps == 11)
                        cQuery = " update C_pmachine set p_weight_min='" + dat + "' where row_id='" + row_no + "'";
                    else if (ps == 12)
                        cQuery = " update C_pmachine set p_weight_max='" + dat + "' where row_id='" + row_no + "'";
                    else if (ps == 13)
                        cQuery = " update C_pmachine set p_garo_max='" + dat + "' where row_id='" + row_no + "'";
                    else if (ps == 14)
                        cQuery = " update C_pmachine set p_sero_max='" + dat + "' where row_id='" + row_no + "'";
                    else if (ps == 15)
                        cQuery = " update C_pmachine set p_garo_min='" + dat + "' where row_id='" + row_no + "'";
                    else if (ps == 16)
                        cQuery = " update C_pmachine set p_sero_min='" + dat + "' where row_id='" + row_no + "'";
                    else if (ps == 17)
                        cQuery = " update C_pmachine set balche_1='" + dat + "' where row_id='" + row_no + "'";
                    else if (ps == 18)
                        cQuery = " update C_pmachine set balche_2='" + dat + "' where row_id='" + row_no + "'";
                    else if (ps == 19)
                        cQuery = " update C_pmachine set jubji_min_gap='" + dat + "' where row_id='" + row_no + "'";
                    else if (ps == 20)
                        cQuery = " update C_pmachine set danga_form='" + dat + "' where row_id='" + row_no + "'";
                    else
                        return;
                }
                else if (Config.tem_c == "5")
                {
                    if (ps == 6)
                        cQuery = " update C_pmachine set machin_name='" + dat + "' where row_id='" + row_no + "'";
                    else if (ps == 7)
                    {

                        cQuery = "select * from hang_manage where hang = '" + dat + "' and class = '판형'";

                        var DBConn1 = new MySqlConnection(Config.DB_con1);
                        DBConn1.Open();
                        var cmd1 = new MySqlCommand(cQuery, DBConn1);
                        var myRead1 = cmd1.ExecuteReader();

                        if (myRead1.Read())
                            dat = myRead1["code1"].ToString().Trim();
                        else
                        {
                            MessageBox.Show("등록되지 않은 판형입니다. 수정에 실패하였습니다");
                            myRead1.Close();
                            DBConn1.Close();
                            return;
                        }

                        myRead1.Close();
                        DBConn1.Close();
                        cQuery = " update C_pmachine set pan_type='" + dat + "' where row_id='" + row_no + "'";
                    }
                    else if (ps == 8)
                        cQuery = " update C_pmachine set machin_model='" + dat + "' where row_id='" + row_no + "'";
                    else if (ps == 9)
                        cQuery = " update C_pmachine set year_type='" + dat + "' where row_id='" + row_no + "'";
                    else if (ps == 10)
                        cQuery = " update C_pmachine set machin_su='" + dat + "' where row_id='" + row_no + "'";
                    else if (ps == 11)
                        cQuery = " update C_pmachine set paper_guy='" + dat + "', paper_guy_result=" + dat + " where row_id='" + row_no + "'";
                    else if (ps == 12)
                        cQuery = " update C_pmachine set p_weight_min='" + dat + "' where row_id='" + row_no + "'";
                    else if (ps == 13)
                        cQuery = " update C_pmachine set p_weight_max='" + dat + "' where row_id='" + row_no + "'";
                    else if (ps == 14)
                        cQuery = " update C_pmachine set p_garo_max='" + dat + "' where row_id='" + row_no + "'";
                    else if (ps == 15)
                        cQuery = " update C_pmachine set p_sero_max='" + dat + "' where row_id='" + row_no + "'";
                    else if (ps == 16)
                        cQuery = " update C_pmachine set p_garo_min='" + dat + "' where row_id='" + row_no + "'";
                    else if (ps == 17)
                        cQuery = " update C_pmachine set p_sero_min='" + dat + "' where row_id='" + row_no + "'";
                    else if (ps == 18)
                        cQuery = " update C_pmachine set bond_max='" + dat + "' where row_id='" + row_no + "'";
                    else if (ps == 19)
                        cQuery = " update C_pmachine set jang_max='" + dat + "' where row_id='" + row_no + "'";
                    else if (ps == 20)
                        cQuery = " update C_pmachine set pok_max='" + dat + "' where row_id='" + row_no + "'";
                    else if (ps == 21)
                        cQuery = " update C_pmachine set go_max='" + dat + "' where row_id='" + row_no + "'";
                    else if (ps == 22)
                        cQuery = " update C_pmachine set jang_min='" + dat + "' where row_id='" + row_no + "'";
                    else if (ps == 23)
                        cQuery = " update C_pmachine set pok_min='" + dat + "' where row_id='" + row_no + "'";
                    else if (ps == 24)
                        cQuery = " update C_pmachine set go_min='" + dat + "' where row_id='" + row_no + "'";
                    else if (ps == 25)
                        cQuery = " update C_pmachine set danga_form='" + dat + "' where row_id='" + row_no + "'";
                    else
                        return;
                }
                //
                var DBConn = new MySqlConnection(Config.DB_con1);
                DBConn.Open();
                var cmd = new MySqlCommand(cQuery, DBConn);
                if (cmd.ExecuteNonQuery() == 0)
                    MessageBox.Show("서버 자료 수정에 실패 했습니다.");
                DBConn.Close();
            }
        }

        private void button2_Click(object sender, EventArgs e)  //추가
        {
            string[] ss = new string[4];
            ss[0] = a_code;
            ss[1] = "";  //b_code
            ss[2] = "";  //c_code
            ss[3] = xsn.ToString(); 
            Form_model frm = new Form_model(button2, ss);
            if (frm.ShowDialog() == DialogResult.OK)
            {
                button4_Click(null, null);
            }
        }
        //
        private void button3_Click(object sender, EventArgs e)  //삭제
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
                        string cQuery = " delete from C_pmachine where row_id='" + row_no + "'";
                        var cmd = new MySqlCommand(cQuery, DBConn);
                        if (cmd.ExecuteNonQuery() == 0)
                        {
                            MessageBox.Show("서버 자료 삭제에 실패 했습니다.");
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

        private void button1_Click(object sender, EventArgs e)  //기계등록
        {
            int insert = 0;
            if (c_id != "0")  //업체번호가 '0'아니라면
            {
                var DBConn = new MySqlConnection(Config.DB_con1);
                DBConn.Open();
                string cQuery = "";
                string field_1 = "";
                string field_2 = "";
                string row_no = "";
                //
                cQuery = "SELECT `COLUMN_NAME` FROM `INFORMATION_SCHEMA`.`COLUMNS` WHERE `TABLE_SCHEMA`='" + Config.DB_name + "' AND `TABLE_NAME`='C_pmachine'";
                var cmd = new MySqlCommand(cQuery, DBConn);
                var myRead = cmd.ExecuteReader();
                string temp = "";
                string f_id = xsn.ToString();  //폼번호
                while (myRead.Read())
                {
                    if (myRead["column_name"].ToString() != "row_id")
                    {
                        temp = myRead["column_name"].ToString().Trim();
                        //
                        field_1 += temp + ",";
                        //
                        if (temp == "int_id")
                            field_2 += "'" + c_id + "',";
                        else if (temp == "form_id")
                            field_2 += "'" + f_id + "',";
                        else
                            field_2 += temp + ",";
                    }
                }
                //       
                myRead.Close();
                field_1 = field_1.Substring(0, field_1.Length - 1);
                field_2 = field_2.Substring(0, field_2.Length - 1);
                // 
                for (int i = 2; i < grid1.RowsCount; i++)
                {
                    if (grid1[i, 1].Value.Equals(true))
                    {
                        row_no = grid1[i, 0].Value.ToString();
                        //               
                        cQuery = "insert into C_hmachin(" + field_1 + ")  select " + field_2 + " from C_pmachine where row_id='" + row_no + "'";
                        var cmd1 = new MySqlCommand(cQuery, DBConn);
                        if (cmd1.ExecuteNonQuery() == 0)
                        {
                            MessageBox.Show("DB 서버 오류 입니다.");
                            break;
                        }
                        insert++;
                    }
                }
                MessageBox.Show("총" + insert.ToString().Trim() + "항목 등록 하였습니다.");
                this.DialogResult = DialogResult.OK;
                this.Close();
                DBConn.Close();
            }
            else
                MessageBox.Show("등록 가능한 상태가 아닙니다.");
            //       
     

        }

        private void grid1_DoubleClick(object sender, EventArgs e)  //수정 -->신규/수정,주문번호,주문/견적,form_id
        {
            int c_pos = grid1.Selection.ActivePosition.Column;
            //          
            if (xsn == 2 && c_pos == 8)
            {
                var contextMenu = new ContextMenuStrip();
                for (int i = 0; i < prn_dt.Rows.Count; i++ )
                    contextMenu.Items.Add(prn_dt.Rows[i][1].ToString() );
                var rect = grid1.RangeToRectangle(new SourceGrid.Range(grid1.Selection.ActivePosition));
                Point pp = new Point(rect.Location.X, rect.Location.Y + rect.Height);
                rect.Location = pp;
                contextMenu.Show(grid1, rect.Location);
                contextMenu.ItemClicked += new ToolStripItemClickedEventHandler(menu_ItemClicked); //추가
            }
        }

        private void menu_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            if (!string.IsNullOrEmpty(e.ClickedItem.Text))
            {
                cell_d cc = new cell_d();
                //
                string row_no = grid1[grid1.Selection.ActivePosition.Row, 0].Value.ToString(); //row_id
                string dat = e.ClickedItem.Text; //인쇄명
                string code = "";  //인쇄코드번호
                //
                DataRow[] dr = prn_dt.Select("bitem='" + dat + "'");
                if (dr.Length != 0)
                {
                    code = dr[0]["b_code"].ToString().Trim();
                    var DBConn = new MySqlConnection(Config.DB_con1);
                    DBConn.Open();
                    string cQuery =" update C_pmachine set print_type='" + code + "' where row_id='" + row_no + "'";
                    var cmd = new MySqlCommand(cQuery, DBConn);
                    if (cmd.ExecuteNonQuery() == 0)
                        MessageBox.Show("서버 자료 수정에 실패 했습니다.");
                    DBConn.Close();
                    grid1[grid1.Selection.ActivePosition.Row, 8] = new SourceGrid.Cells.Cell(dat, typeof(string));  //
                    grid1[grid1.Selection.ActivePosition.Row, 8].View = cc.center_cellb;
                    //
                    grid1.Focus();
                    grid1.Refresh();
                }
            }
        }
        private string[] Get_pantype_combo()
        {
            string cQuery = "select distinct hang from hang_manage where class='판형'";


            var DBConn = new MySqlConnection(Config.DB_con1);
            DBConn.Open();
            var cmd1 = new MySqlCommand(cQuery, DBConn);
            var myRead1 = cmd1.ExecuteReader();
            string[] item = new string[15];

            for (int i = 0; i < 15; i++)
                item[i] = "0";

            int y = 0;
            while (myRead1.Read())
            {
                item[y] = myRead1["hang"].ToString().Trim();
                y++;
            }

            string[] result = new string[y];

            for (int i = 0; i < y; i++)
            {
                result[i] = item[i];
            }

            DBConn.Close();
            myRead1.Close();

            return result;
        }

        private void bCopy_Click(object sender, EventArgs e)
        {
            SourceGridControl GridHandle = new SourceGridControl();
            GridHandle.SourceGrideInit(grid1, Config.DB_con1);

            string[] rows = new string[grid1.Rows.Count];
            string[] copy_row_id = new string[grid1.Rows.Count];
            rows = GridHandle.GetChkRowid(2, 1, 0);
            string cQuery = "";
            string Query_sub = "and ( a.row_id < 0 ";

            for (int i = 0; i < rows.Length; i++)
            {
                if (rows[i] == "0")
                    break;
                Query_sub += " or a.row_id ='" + GridHandle.OneDataCopy("C_pmachine", rows[i]) + "'";

            }
            if (xsn == 2)
                cQuery = " select a.jebon_code,f.hang as j_hang, a.*, b.aitem d1,c.bitem d2,d.citem d3, e.hang as pan_hang FROM C_pmachine a ";
            else
                cQuery = " select a.*,b.aitem d1,c.bitem d2,d.citem d3, e.hang as pan_hang FROM C_pmachine a";
            cQuery += " Left Outer Join C_amodel b ON b.a_code=a.a_model";
            cQuery += " Left Outer Join C_bmodel c ON c.a_code=a.a_model and c.b_code=a.b_model";
            cQuery += " Left Outer Join C_cmodel d ON d.a_code=a.a_model and d.b_code=a.b_model and d.c_code=a.c_model";
            cQuery += " Left Outer Join hang_manage e ON a.pan_type = e.code1  and e.class = '판형'";
            if (xsn == 2)
                cQuery += "  Left outer join hang_manage f on a.jebon_code=f.code1 and f.class = '제본옵션' ";

            if (xsn == 5)
                cQuery += " where a.form_id='5'";
            else
                cQuery += " where a.a_model='" + a_code + "'";

            cQuery += Query_sub+" )";
            
            GridNewLine_copy(cQuery);

            GridHandle.ChkCancel(1);

        }

        void GridNewLine_copy(string Query)
        {

            MySqlConnection DBConn;
            DBConn = new MySqlConnection(Config.DB_con1);
            DBConn.Open();
            string temp = "";
            DataRow[] dr;

            var cmd = new MySqlCommand(Query, DBConn);
            var myRead = cmd.ExecuteReader();

            int m = grid1.RowsCount;
            cell_d cc = new cell_d();

            while (myRead.Read())
            {
                if (xsn == 2)
                {
                    grid1.Rows.Insert(m);
                    grid1.Rows[m].Height = 22;

                    grid1[m, 0] = new SourceGrid.Cells.Cell(myRead["row_id"], typeof(string));
                    grid1[m, 1] = new SourceGrid.Cells.CheckBox(null, false);            //"√"
                    grid1[m, 2] = new SourceGrid.Cells.Cell(myRead["no"], typeof(string));//No
                    grid1[m, 2].Editor = cc.disable_cell;
                    grid1[m, 2].View = cc.center_cell;
                    grid1[m, 3] = new SourceGrid.Cells.Cell(myRead["d1"], typeof(string));//"업종1"
                    grid1[m, 3].Editor = cc.disable_cell;
                    grid1[m, 3].View = cc.left_cell;
                    grid1[m, 4] = new SourceGrid.Cells.Cell(myRead["d2"], typeof(string));//"업종2"
                    grid1[m, 4].Editor = cc.disable_cell;
                    grid1[m, 4].View = cc.left_cell;
                    grid1[m, 5] = new SourceGrid.Cells.Cell(myRead["j_hang"], typeof(string));//제본조건
                    grid1[m, 5].Editor = cc.disable_cell;
                    grid1[m, 5].View = cc.center_cell;
                    grid1[m, 6] = new SourceGrid.Cells.Cell(myRead["jebon_code"], typeof(string));//제본코드
                    grid1[m, 6].View = cc.center_cell;
                    grid1[m, 7] = new SourceGrid.Cells.Cell(myRead["machin_name"], typeof(string));//"기계이름"
                    //
                    temp = myRead["print_type"].ToString().Trim();
                    dr = prn_dt.Select("b_code='" + temp + "'");
                    if (dr.Length != 0)
                        grid1[m, 8] = new SourceGrid.Cells.Cell(dr[0]["bitem"].ToString(), typeof(string));  //"인쇄방식"
                    else
                        grid1[m, 8] = new SourceGrid.Cells.Cell(" ", typeof(string));  //"인쇄방식"
                    //
                    grid1[m, 8].View = cc.center_cellb;
                    grid1[m, 8].Editor = cc.disable_cell;
                    grid1[m, 9] = new SourceGrid.Cells.Cell(myRead["machin_model"], typeof(string));//"기  종"
                    grid1[m, 10] = new SourceGrid.Cells.Cell(myRead["year_type"], typeof(string));//"년식"
                    grid1[m, 10].View = cc.center_cell;
                    grid1[m, 11] = new SourceGrid.Cells.Cell(myRead["machine_grade"], typeof(string));//"년식"
                    grid1[m, 11].View = cc.center_cell;
                    grid1[m, 12] = new SourceGrid.Cells.Cell(myRead["c_garo_min"], typeof(string));//"표지 최소(가로)"
                    grid1[m, 12].View = cc.int_cell;
                    grid1[m, 13] = new SourceGrid.Cells.Cell(myRead["c_sero_min"], typeof(string));//"표지 최소(세로)"
                    grid1[m, 13].View = cc.int_cell;
                    grid1[m, 14] = new SourceGrid.Cells.Cell(myRead["c_garo_max"], typeof(string));//"표지 최대(가로)"
                    grid1[m, 14].View = cc.int_cell;
                    grid1[m, 15] = new SourceGrid.Cells.Cell(myRead["c_sero_max"], typeof(string));//"표지 최대(세로)"
                    grid1[m, 15].View = cc.int_cell;
                    grid1[m, 16] = new SourceGrid.Cells.Cell(myRead["d_garo_min"], typeof(string));//"최소 책싸이즈(가로)"
                    grid1[m, 16].View = cc.int_cell;
                    grid1[m, 17] = new SourceGrid.Cells.Cell(myRead["d_sero_min"], typeof(string));//"최소 책싸이즈(세로)"
                    grid1[m, 17].View = cc.int_cell;
                    grid1[m, 18] = new SourceGrid.Cells.Cell(myRead["d_garo_max"], typeof(string));//"최대 책싸이즈(가로)"
                    grid1[m, 18].View = cc.int_cell;
                    grid1[m, 19] = new SourceGrid.Cells.Cell(myRead["d_sero_max"], typeof(string));//"최대 책싸이즈(세로)"
                    grid1[m, 19].View = cc.int_cell;
                    grid1[m, 20] = new SourceGrid.Cells.Cell(myRead["seneca_max"], typeof(string));//"책두께(세네카)(최대)
                    grid1[m, 20].View = cc.int_cell;
                    grid1[m, 21] = new SourceGrid.Cells.Cell(myRead["seneca_min"], typeof(string));//"책두께(세네카)(최소)
                    grid1[m, 21].View = cc.int_cell;
                    grid1[m, 22] = new SourceGrid.Cells.Cell(myRead["koma_su"], typeof(string)); //"콤마수";
                    grid1[m, 22].View = cc.int_cell;
                    grid1[m, 23] = new SourceGrid.Cells.Cell(myRead["danga_form"], typeof(string));//"단가폼";
                    grid1[m, 23].View = cc.center_cellb;
                    //
                    if (x_id == "2")
                    {
                        grid1[m, 2].Editor = cc.disable_cell;
                        grid1[m, 3].Editor = cc.disable_cell;
                        grid1[m, 4].Editor = cc.disable_cell;
                        grid1[m, 7].Editor = cc.disable_cell;
                        grid1[m, 8].Editor = cc.disable_cell;
                        grid1[m, 9].Editor = cc.disable_cell;
                        grid1[m, 10].Editor = cc.disable_cell;
                        grid1[m, 11].Editor = cc.disable_cell;
                        grid1[m, 12].Editor = cc.disable_cell;
                        grid1[m, 13].Editor = cc.disable_cell;
                        grid1[m, 14].Editor = cc.disable_cell;
                        grid1[m, 15].Editor = cc.disable_cell;
                        grid1[m, 16].Editor = cc.disable_cell;
                        grid1[m, 17].Editor = cc.disable_cell;
                        grid1[m, 18].Editor = cc.disable_cell;
                        grid1[m, 19].Editor = cc.disable_cell;
                        grid1[m, 20].Editor = cc.disable_cell;
                        grid1[m, 21].Editor = cc.disable_cell;
                        grid1[m, 22].Editor = cc.disable_cell;
                        grid1[m, 23].Editor = cc.disable_cell;
                    }
                }
                else if (xsn == 3)      //코팅기계
                {
                    grid1.Rows.Insert(m);
                    grid1.Rows[m].Height = 24;
                    grid1[m, 0] = new SourceGrid.Cells.Cell(myRead["row_id"], typeof(string));
                    grid1[m, 1] = new SourceGrid.Cells.CheckBox(null, false);               //√
                    grid1[m, 2] = new SourceGrid.Cells.Cell(myRead["no"], typeof(string));   //no
                    grid1[m, 2].Editor = cc.disable_cell;
                    grid1[m, 2].View = cc.center_cell;                                              
                    grid1[m, 3] = new SourceGrid.Cells.Cell(myRead["d1"], typeof(string));   //업종1 
                    grid1[m, 3].Editor = cc.disable_cell;
                    grid1[m, 4] = new SourceGrid.Cells.Cell(myRead["d2"], typeof(string));   //업종2
                    grid1[m, 4].Editor = cc.disable_cell;
                    grid1[m, 5] = new SourceGrid.Cells.Cell(myRead["d3"], typeof(string));   //업종3
                    grid1[m, 5].Editor = cc.disable_cell;
                    grid1[m, 6] = new SourceGrid.Cells.Cell(myRead["machin_name"], typeof(string));  //기계이름 
                    grid1[m, 7] = new SourceGrid.Cells.Cell(myRead["pan_hang"], typeof(string));     //판형
                    grid1[m, 7].Editor = cb_pantype;
                    grid1[m, 8] = new SourceGrid.Cells.Cell(myRead["machin_model"], typeof(string)); //기종
                    grid1[m, 9] = new SourceGrid.Cells.Cell(myRead["year_type"], typeof(string));    //년식 
                    grid1[m, 9].View = cc.center_cell;
                    grid1[m, 11] = new SourceGrid.Cells.Cell(myRead["machin_su"], typeof(string));  //수량;
                    grid1[m, 11].View = cc.center_cell;                                              
                    grid1[m, 12] = new SourceGrid.Cells.Cell(myRead["paper_guy"], typeof(string));  //종이G
                    grid1[m, 12].View = cc.center_cell;                                             
                    grid1[m, 13] = new SourceGrid.Cells.Cell(myRead["p_weight_min"], typeof(string));  //종이무게(최소) 
                    grid1[m, 13].View = cc.int_cell;
                    grid1[m, 14] = new SourceGrid.Cells.Cell(myRead["p_weight_max"], typeof(string));  //종이무게(최대)
                    grid1[m, 14].View = cc.int_cell;                                            
                    grid1[m, 15] = new SourceGrid.Cells.Cell(myRead["p_garo_max"], typeof(string));  //종이 최대싸이즈(가로)
                    grid1[m, 15].View = cc.int_cell;
                    grid1[m, 16] = new SourceGrid.Cells.Cell(myRead["p_sero_max"], typeof(string));  //종이 최대싸이즈(세로) 
                    grid1[m, 16].View = cc.int_cell;
                    grid1[m, 17] = new SourceGrid.Cells.Cell(myRead["p_garo_min"], typeof(string));  //종이 최소싸이즈(가로)
                    grid1[m, 17].View = cc.int_cell;
                    grid1[m, 18] = new SourceGrid.Cells.Cell(myRead["p_sero_min"], typeof(string));  //종이 최소싸이즈(세로)
                    grid1[m, 18].View = cc.int_cell;                                            
                    grid1[m, 19] = new SourceGrid.Cells.Cell(myRead["danga_form"], typeof(string)); //단가폼
                    grid1[m, 19].View = cc.center_cellb;
//
                    if (x_id == "2")                                                          
                    {                                                                        
                        grid1[m, 2].Editor = cc.disable_cell;
                        grid1[m, 3].Editor = cc.disable_cell;                                    
                        grid1[m, 4].Editor = cc.disable_cell;                                   
                        grid1[m, 5].Editor = cc.disable_cell;
                        grid1[m, 6].Editor = cc.disable_cell;                                    
                        grid1[m, 7].Editor = cc.disable_cell;                                   
                        grid1[m, 8].Editor = cc.disable_cell;
                        grid1[m, 9].Editor = cc.disable_cell;                                    
                        grid1[m, 10].Editor = cc.disable_cell;                                  
                        grid1[m, 11].Editor = cc.disable_cell;
                        grid1[m, 12].Editor = cc.disable_cell;                                   
                        grid1[m, 13].Editor = cc.disable_cell;
                        grid1[m, 14].Editor = cc.disable_cell;
                        grid1[m, 15].Editor = cc.disable_cell;
                        grid1[m, 16].Editor = cc.disable_cell;
                        grid1[m, 17].Editor = cc.disable_cell;
                        grid1[m, 18].Editor = cc.disable_cell;
                        grid1[m, 19].Editor = cc.disable_cell;
                    }
                }
                else if (xsn == 4)          //접지기계
                {
                    grid1.Rows.Insert(m);
                    grid1.Rows[m].Height = 24;
                    grid1[m, 0] = new SourceGrid.Cells.Cell(myRead["row_id"], typeof(string));
                    grid1[m, 1] = new SourceGrid.Cells.CheckBox(null, false);              //√
                    grid1[m, 2] = new SourceGrid.Cells.Cell(myRead["no"], typeof(string));  //no
                    grid1[m, 2].Editor = cc.disable_cell;
                    grid1[m, 2].View = cc.center_cell;
                    grid1[m, 3] = new SourceGrid.Cells.Cell(myRead["d1"], typeof(string));  //업종1
                    grid1[m, 3].Editor = cc.disable_cell;
                    grid1[m, 4] = new SourceGrid.Cells.Cell(myRead["d2"], typeof(string));  //업종2  
                    grid1[m, 4].Editor = cc.disable_cell;
                    grid1[m, 5] = new SourceGrid.Cells.Cell(myRead["machin_name"], typeof(string));  //기계이름
                    grid1[m, 6] = new SourceGrid.Cells.Cell(myRead["pan_hang"], typeof(string));  //판형
                    grid1[m, 6].Editor = cb_pantype;
                    grid1[m, 7] = new SourceGrid.Cells.Cell(myRead["machin_model"], typeof(string));  //기종
                    grid1[m, 7].View = cc.center_cell;
                    grid1[m, 8] = new SourceGrid.Cells.Cell(myRead["year_type"], typeof(string));  //년식              
                    grid1[m, 8].View = cc.int_cell;
                    grid1[m, 9] = new SourceGrid.Cells.Cell(myRead["machin_su"], typeof(string));  //수량
                    grid1[m, 9].View = cc.int_cell;                                                        
                    grid1[m, 10] = new SourceGrid.Cells.Cell(myRead["p_weight_min"], typeof(string));  //종이무게(최소)
                    grid1[m, 10].View = cc.int_cell;
                    grid1[m, 11] = new SourceGrid.Cells.Cell(myRead["p_weight_max"], typeof(string));  //종이무게(최대) 
                    grid1[m, 11].View = cc.int_cell;                                             
                    grid1[m, 12] = new SourceGrid.Cells.Cell(myRead["p_garo_max"], typeof(string));  //종이최대싸이즈(구와이)
                    grid1[m, 12].View = cc.int_cell;                                                       
                    grid1[m, 13] = new SourceGrid.Cells.Cell(myRead["p_sero_max"], typeof(string));  //종이최대싸이즈(하리)
                    grid1[m, 13].View = cc.int_cell;
                    grid1[m, 14] = new SourceGrid.Cells.Cell(myRead["p_garo_min"], typeof(string));  //종이최소싸이즈(구와이)
                    grid1[m, 14].View = cc.int_cell;
                    grid1[m, 15] = new SourceGrid.Cells.Cell(myRead["p_garo_min"], typeof(string));  //종이최소싸이즈(하리)
                    grid1[m, 15].View = cc.int_cell;
                    grid1[m, 16] = new SourceGrid.Cells.Cell(myRead["balche_1"], typeof(string)); //발체1
                    grid1[m, 17] = new SourceGrid.Cells.Cell(myRead["balche_2"], typeof(string)); //발체2
                    grid1[m, 18] = new SourceGrid.Cells.Cell(myRead["jubji_min_gap"], typeof(string)); //최소접지간격
                    grid1[m, 19] = new SourceGrid.Cells.Cell(myRead["danga_form"], typeof(string)); //단가폼
                    grid1[m, 19].View = cc.center_cellb;
                    //                                                                                  
                    if (x_id == "2")                                                                    
                    {                                                                                   
                        grid1[m, 2].Editor = cc.disable_cell;
                        grid1[m, 3].Editor = cc.disable_cell;
                        grid1[m, 4].Editor = cc.disable_cell;
                        grid1[m, 5].Editor = cc.disable_cell;
                        grid1[m, 6].Editor = cc.disable_cell;
                        grid1[m, 7].Editor = cc.disable_cell;
                        grid1[m, 8].Editor = cc.disable_cell;
                        grid1[m, 9].Editor = cc.disable_cell;
                        grid1[m, 10].Editor = cc.disable_cell;
                        grid1[m, 11].Editor = cc.disable_cell;
                        grid1[m, 12].Editor = cc.disable_cell;
                        grid1[m, 13].Editor = cc.disable_cell;
                        grid1[m, 14].Editor = cc.disable_cell;
                        grid1[m, 15].Editor = cc.disable_cell;
                        grid1[m, 16].Editor = cc.disable_cell;
                        grid1[m, 17].Editor = cc.disable_cell;
                        grid1[m, 18].Editor = cc.disable_cell;
                        grid1[m, 19].Editor = cc.disable_cell;
                    }
                }
                //
                else if (xsn == 5)            //기타기계
                {
                    grid1.Rows.Insert(m);
                    grid1.Rows[m].Height = 24;
                    grid1[m, 0] = new SourceGrid.Cells.Cell(myRead["row_id"], typeof(string));
                    grid1[m, 1] = new SourceGrid.Cells.CheckBox(null, false);
                    grid1[m, 2] = new SourceGrid.Cells.Cell(myRead["no"], typeof(string));
                    grid1[m, 2].Editor = cc.disable_cell;
                    grid1[m, 2].View = cc.center_cell;
                    grid1[m, 3] = new SourceGrid.Cells.Cell(myRead["d1"], typeof(string)); //업종-1
                    grid1[m, 3].Editor = cc.disable_cell;
                    grid1[m, 4] = new SourceGrid.Cells.Cell(myRead["d2"], typeof(string)); //업종-2
                    grid1[m, 4].Editor = cc.disable_cell;
                    grid1[m, 5] = new SourceGrid.Cells.Cell(myRead["d3"], typeof(string)); //업종-3
                    grid1[m, 5].Editor = cc.disable_cell;
                    grid1[m, 6] = new SourceGrid.Cells.Cell(myRead["machin_name"], typeof(string)); //기계이름
                    grid1[m, 7] = new SourceGrid.Cells.Cell(myRead["pan_hang"], typeof(string));  //판형
                    grid1[m, 7].Editor = cb_pantype;
                    grid1[m, 7].View = cc.center_cell;
                    grid1[m, 8] = new SourceGrid.Cells.Cell(myRead["machin_model"], typeof(string));  //기종
                    grid1[m, 8].View = cc.center_cell;
                    grid1[m, 9] = new SourceGrid.Cells.Cell(myRead["year_type"], typeof(string));  //연식
                    grid1[m, 9].View = cc.center_cell;
                    grid1[m, 10] = new SourceGrid.Cells.Cell(myRead["machin_su"], typeof(string));  //수량
                    grid1[m, 10].View = cc.int_cell;
                    grid1[m, 11] = new SourceGrid.Cells.Cell(myRead["paper_guy"], typeof(string));  //종이구와이
                    grid1[m, 11].View = cc.int_cell;
                    grid1[m, 12] = new SourceGrid.Cells.Cell(myRead["p_weight_min"], typeof(string));  //종이무게(최소)
                    grid1[m, 12].View = cc.int_cell;
                    grid1[m, 13] = new SourceGrid.Cells.Cell(myRead["p_weight_max"], typeof(string));  //종이무게(최대)
                    grid1[m, 13].View = cc.int_cell;
                    grid1[m, 14] = new SourceGrid.Cells.Cell(myRead["p_garo_max"], typeof(string));  //종이최대싸이즈(가로)
                    grid1[m, 14].View = cc.int_cell;
                    grid1[m, 15] = new SourceGrid.Cells.Cell(myRead["p_sero_max"], typeof(string));  //종이최대싸이즈(세로)
                    grid1[m, 15].View = cc.int_cell;

                    grid1[m, 16] = new SourceGrid.Cells.Cell(myRead["p_garo_min"], typeof(string));  //종이최소싸이즈(가로)
                    grid1[m, 16].View = cc.int_cell;
                    grid1[m, 17] = new SourceGrid.Cells.Cell(myRead["p_sero_min"], typeof(string));  //종이최소싸이즈(세로)
                    grid1[m, 17].View = cc.int_cell;

                    grid1[m, 18] = new SourceGrid.Cells.Cell(myRead["bond_max"], typeof(string));  //초대접착면

                    grid1[m, 19] = new SourceGrid.Cells.Cell(myRead["jang_max"], typeof(string));  //최대싸이즈(장)
                    grid1[m, 19].View = cc.int_cell;
                    grid1[m, 20] = new SourceGrid.Cells.Cell(myRead["pok_max"], typeof(string));  //최대싸이즈(폭)
                    grid1[m, 20].View = cc.int_cell;
                    grid1[m, 21] = new SourceGrid.Cells.Cell(myRead["go_max"], typeof(string));  //최대싸이즈(고)
                    grid1[m, 21].View = cc.int_cell;

                    grid1[m, 22] = new SourceGrid.Cells.Cell(myRead["jang_min"], typeof(string));  //최소싸이즈(장)
                    grid1[m, 22].View = cc.int_cell;
                    grid1[m, 23] = new SourceGrid.Cells.Cell(myRead["pok_min"], typeof(string));  //최소싸이즈(폭)
                    grid1[m, 23].View = cc.int_cell;
                    grid1[m, 24] = new SourceGrid.Cells.Cell(myRead["go_min"], typeof(string));  //최소싸이즈(고)
                    grid1[m, 24].View = cc.int_cell;

                    grid1[m, 25] = new SourceGrid.Cells.Cell(myRead["danga_form"], typeof(string));  //단가폼
                    grid1[m, 25].View = cc.center_cellb;
                    //
                    if (x_id == "2")
                    {
                        grid1[m, 2].Editor = cc.disable_cell;
                        grid1[m, 3].Editor = cc.disable_cell;
                        grid1[m, 4].Editor = cc.disable_cell;
                        grid1[m, 5].Editor = cc.disable_cell;
                        grid1[m, 6].Editor = cc.disable_cell;
                        grid1[m, 7].Editor = cc.disable_cell;
                        grid1[m, 8].Editor = cc.disable_cell;
                        grid1[m, 9].Editor = cc.disable_cell;
                        grid1[m, 10].Editor = cc.disable_cell;
                        grid1[m, 11].Editor = cc.disable_cell;
                        grid1[m, 12].Editor = cc.disable_cell;
                        grid1[m, 13].Editor = cc.disable_cell;
                        grid1[m, 14].Editor = cc.disable_cell;
                        grid1[m, 15].Editor = cc.disable_cell;
                        grid1[m, 16].Editor = cc.disable_cell;
                        grid1[m, 17].Editor = cc.disable_cell;
                        grid1[m, 18].Editor = cc.disable_cell;
                        grid1[m, 19].Editor = cc.disable_cell;
                        grid1[m, 20].Editor = cc.disable_cell;
                        grid1[m, 21].Editor = cc.disable_cell;
                        grid1[m, 22].Editor = cc.disable_cell;
                        grid1[m, 23].Editor = cc.disable_cell;
                        grid1[m, 24].Editor = cc.disable_cell;
                        grid1[m, 25].Editor = cc.disable_cell;
                    }
                }
                m++;
            }

            myRead.Close();
            DBConn.Close();

            var position = new SourceGrid.Position(grid1.Rows.Count - 1, 1);
            grid1.Selection.Focus(position, true);
        }

        private void Form_machins_SizeChanged(object sender, EventArgs e)
        {
            this.grid1.Size = new System.Drawing.Size(this.Size.Width - 42, this.Height - 123);
        }

    }
}


