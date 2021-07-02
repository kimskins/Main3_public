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
    public partial class Form_206 : Form
    {
        SourceGridControl GridHandle = new SourceGridControl();

        public Form_206()
        {
            InitializeComponent();
        }

        private void Form_mhang_Load(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();

            Screen srn = Screen.PrimaryScreen;
            int Xb = this.Width;  //좌,우
            this.Location = new Point((srn.Bounds.Width - Xb) / 2, 1);  //좌/우,위/아래
            //
            ksgcontrol KC = new ksgcontrol();
            KC.ControlInit(Config.DB_con1,"","","");

            KC.ComboBoxItemInsert("C_jebon_prn", "a2", comboBox1);
            string Query = "select distinct b.hang as hang from C_jebon_prn as a inner join hang_manage as b where a.a5 = b.code1";
            KC.ComboBoxItemInsert("hang", comboBox2, Query);

            grid1.Controller.AddController(new ValueChangedEvent());
        }

        private void button4_Click(object sender, EventArgs e)  //검색
        {
            cell_d cc = new cell_d();
            grid1.Rows.Clear();
            grid1.Refresh();
            //중앙셀
            SourceGrid.Cells.Views.Cell center_cell = new SourceGrid.Cells.Views.Cell();
            center_cell.TextAlignment = DevAge.Drawing.ContentAlignment.MiddleCenter;
            //오른쪽셀
            SourceGrid.Cells.Views.Cell left_cell = new SourceGrid.Cells.Views.Cell();
            left_cell.TextAlignment = DevAge.Drawing.ContentAlignment.MiddleLeft;
            //숫자형 셀(int) 좌측셀
            SourceGrid.Cells.Views.Cell Int_cell = new SourceGrid.Cells.Views.Cell();
            Int_cell.TextAlignment = DevAge.Drawing.ContentAlignment.MiddleRight;
            //
            SourceGrid.Cells.Editors.TextBox Int_Editor = new SourceGrid.Cells.Editors.TextBox(typeof(int));
            DevAge.ComponentModel.Converter.NumberTypeConverter int_fomat = new DevAge.ComponentModel.Converter.NumberTypeConverter(typeof(int));
            int_fomat.Format = "###,###,###";
            Int_Editor.TypeConverter = int_fomat;
            //  
            grid1.BorderStyle = BorderStyle.FixedSingle;
            grid1.ColumnsCount = 41;
            grid1.FixedRows = 2;
            grid1.Rows.Insert(0);
            grid1.Rows[0].Height = 26;
            grid1.Rows.Insert(1);
            grid1.Rows[1].Height = 26;
            //
            grid1[0, 0] = new SourceGrid.Cells.ColumnHeader("row_id");
            grid1[0, 0].RowSpan = 2;
            grid1.Columns[0].Visible = false;

            grid1[0, 1] = new MyHeader1("√");
            grid1[0, 1].RowSpan = 2;

            grid1[0, 2] = new MyHeader1("코 드");
            grid1[0, 2].RowSpan = 2;
            
            grid1[0, 3] = new MyHeader1("제 본");
            grid1[0, 3].ColumnSpan = 3;
            
            grid1[0, 6] = new MyHeader1("항  목");
            grid1[0, 6].ColumnSpan = 2;

            grid1[0, 8] = new MyHeader1("항  목  변  경");
            grid1[0, 8].ColumnSpan = 6;

            grid1[0, 14] = new MyHeader1("인 쇄");
            grid1[0, 14].ColumnSpan = 3;

            grid1[0, 17] = new MyHeader1("인쇄메뉴");
            grid1[0, 17].RowSpan = 2;

            grid1[0, 18] = new MyHeader1("도큐Size");
            grid1[0, 18].RowSpan = 2;
            //여기까지는 정상

            grid1[0, 19] = new MyHeader1("기본도수");
            grid1[0, 19].RowSpan = 2;

            grid1[0, 20] = new MyHeader1("하리꼬미");
            grid1[0, 20].RowSpan = 2;

            grid1[0, 21] = new MyHeader1("도지간격");
            grid1[0, 21].RowSpan = 2;

            grid1[0, 22] = new MyHeader1("페이지");
            grid1[0, 22].RowSpan = 2;

            grid1[0, 23] = new MyHeader1("접지");
            grid1[0, 23].RowSpan = 2;

            //
            grid1[0, 24] = new MyHeader1("XX");
            grid1[0, 24].RowSpan = 2;

            grid1[0, 25] = new MyHeader1("종이\r\n검색");
            grid1[0, 25].RowSpan = 2;

            grid1[0, 26] = new MyHeader1("P배수");
            grid1[0, 26].RowSpan = 2;

            grid1[0, 27] = new MyHeader1("도큐\r\n변경");
            grid1[0, 27].RowSpan = 2;

            grid1[0, 28] = new MyHeader1("삭제\r\n가능");
            grid1[0, 28].RowSpan = 2;

            grid1[0, 29] = new MyHeader1("닷지\r\n고정");
            grid1[0, 29].RowSpan = 2;

            grid1[0, 30] = new MyHeader1("닷지\r\n[0mm]");
            grid1[0, 30].RowSpan = 2;


            grid1[0, 31] = new MyHeader1("후공정추가_1");
            grid1[0, 31].RowSpan = 2;

            grid1[0, 32] = new MyHeader1("후공정추가_2");
            grid1[0, 32].RowSpan = 2;

            grid1[0, 33] = new MyHeader1("후공정추가_3");
            grid1[0, 33].RowSpan = 2;

            grid1[0, 34] = new MyHeader1("후공정추가_4");
            grid1[0, 34].RowSpan = 2;

            grid1[0, 35] = new MyHeader1("후공정추가_5");
            grid1[0, 35].RowSpan = 2;

            grid1[0, 36] = new MyHeader1("후공정추가_6");
            grid1[0, 36].RowSpan = 2;

            grid1[0, 37] = new MyHeader1("DB\r\n[X]");
            grid1[0, 37].RowSpan = 2;

            grid1[0, 38] = new MyHeader1("항목\r\n[X]");
            grid1[0, 38].RowSpan = 2;

            grid1[0, 39] = new MyHeader1("하리\r\n[X]");
            grid1[0, 39].RowSpan = 2;

            grid1[0, 40] = new MyHeader1("I-Sz\r\n[X]");
            grid1[0, 40].RowSpan = 2;
            
            //
            grid1[1, 3] = new MyHeader("방식");
            grid1[1, 4] = new MyHeader("코드");
            grid1[1, 5] = new MyHeader("옵션");
            grid1[1, 6] = new MyHeader("항목");
            grid1[1, 7] = new MyHeader("코드");

            grid1[1, 8] = new MyHeader("1선택");
            grid1[1, 9] = new MyHeader("2선택");
            grid1[1, 10] = new MyHeader("3선택");
            grid1[1, 11] = new MyHeader("4선택");
            grid1[1, 12] = new MyHeader("5선택");
            grid1[1, 13] = new MyHeader("6선택");
            grid1[1, 14] = new MyHeader("방법");
            grid1[1, 15] = new MyHeader("Code");
            grid1[1, 16] = new MyHeader("초기화");
            //            
            grid1.Columns[0].Width = 100;
            grid1.Columns[1].Width = 30;
            grid1.Columns[2].Width = 50;
            grid1.Columns[3].Width = 70;  //
            grid1.Columns[4].Width = 40;  //
            grid1.Columns[5].Width = 160;
            grid1.Columns[6].Width = 80;
            grid1.Columns[7].Width = 40;
            grid1.Columns[8].Width = 86;
            grid1.Columns[9].Width = 86;
            grid1.Columns[10].Width = 56; //
            grid1.Columns[11].Width = 56;
            grid1.Columns[12].Width = 56;
            grid1.Columns[13].Width = 56;

            grid1.Columns[14].Width = 100;
            grid1.Columns[15].Width = 52;
            grid1.Columns[16].Width = 61;
            grid1.Columns[17].Width = 160;
            grid1.Columns[18].Width = 60;
            grid1.Columns[19].Width = 60;
            grid1.Columns[20].Width = 60;
            grid1.Columns[21].Width = 60;
            grid1.Columns[22].Width = 60;
            grid1.Columns[23].Width = 60;
            grid1.Columns[24].Width = 38;
            grid1.Columns[25].Width = 38;
            grid1.Columns[26].Width = 50;
            grid1.Columns[27].Width = 38;
            grid1.Columns[28].Width = 38;
            grid1.Columns[29].Width = 40;
            grid1.Columns[30].Width = 45;
            grid1.Columns[31].Width = 100;
            grid1.Columns[32].Width = 100;
            grid1.Columns[33].Width = 100;
            grid1.Columns[34].Width = 100;
            grid1.Columns[35].Width = 100;
            grid1.Columns[36].Width = 100;
            grid1.Columns[37].Width = 38;
            grid1.Columns[38].Width = 38;
            grid1.Columns[39].Width = 38;
            grid1.Columns[40].Width = 38;
            //
            string xtem1 = "";
            string xtem2 = "";
            string xtem3 = "";
            string xtem4 = "";

            string s1, s2, s3, s4, s5, s6, s7, s8, s9, s10, s11, s12, s13, s14, s15, s16 = "";
            string c1, c2, c3, c4, c5, c6, c7, c8, c9, c10, c11, c12, c13, c14, c15, c16 = "";
            //
            if (comboBox1.Text != "")
            {
                c1 = comboBox1.Text.Trim();
                s1 = " and a.a2 ='" + c1 + "'";
            }
            else
                s1 = "";
            //
            if (textBox4.Text != "")
            {
                c2 = textBox4.Text.Trim();
                s2 = " and a.a2s='" + c2 + "'";
            }
            else
                s2 = "";
            //
            //
            if (textBox6.Text != "")
            {
                c3 = textBox6.Text.Trim();
                s3 = " and a.a1 ='" + c3 + "'";
            }
            else
                s3 = "";
            //
            //
            if (textBox7.Text != "")
            {
                c4 = textBox7.Text.Trim();

                s4 = " and a.a3 ='" + c4 + "'";

                //if (c4.Length == 1)
                //    s4 = " and substr(a.a3,1,1) ='" + c4 + "'";
                //else
                //    s4 = " and substr(a.a3,1,2) ='" + c4 + "'";
            }
            else
                s4 = "";
            //
            if (comboBox2.Text != "")
            {
                c5 = comboBox2.Text.Trim();
                s5 = " and b.hang ='" + c5 + "'";
            }
            else
                s5 = "";
            //
            if (textBox9.Text != "")
            {
                c6= textBox9.Text.Trim();
                s6 = " and a.a5='" + c6 + "'";
            }
            else
                s6= "";
            //
            //
            if (textBox10.Text != "")
            {
                c7= textBox10.Text.Trim();
                s7 = " and a.a11s='" + c7 + "'";
            }
            else
                s7= "";
            //
            //
            if (textBox12.Text != "")
            {
                c8= textBox12.Text.Trim();
                s8 = " and a.a11='" + c8 + "'";
            }
            else
                s8= "";
            //
            //
            if (textBox11.Text != "")
            {
                c9= textBox11.Text.Trim();
                s9 = " and a.a12='" + c9 + "'";
            }
            else
                s9= "";
            //
            //
            if (textBox21.Text != "")
            {
                c10= textBox21.Text.Trim();
                s10 = " and a.a15='" + c10 + "'";
            }
            else
                s10= "";
            //
            //
            if (textBox20.Text != "")
            {
                c11= textBox20.Text.Trim();
                s11 = " and a.a18='" + c11 + "'";
            }
            else
                s11= "";
            //
            //
            if (textBox19.Text != "")
            {
                c12= textBox19.Text.Trim();
                s12 = " and a.a20a='" + c12 + "'";
            }
            else
                s12= "";
            //
            //
            if (textBox18.Text != "")
            {
                c13= textBox18.Text.Trim();
                s13 = " and a.a20b='" + c13 + "'";
            }
            else
                s13= "";
            //
            //
            if (textBox17.Text != "")
            {
                c14= textBox17.Text.Trim();
                s14 = " and a.a20c='" + c14 + "'";
            }
            else
                s14= "";
            //
            //
            if (textBox16.Text != "")
            {
                c15= textBox16.Text.Trim();
                s15 = " and a.a20d='" + c15 + "'";
            }
            else
                s15= "";
            //
            //
            if (textBox15.Text != "")
            {
                c16= textBox15.Text.Trim();
                s16 = " and a.a20='" + c16 + "'";
            }
            else
                s16= "";
            //
            //
            var DBConn = new MySqlConnection(Config.DB_con1);
            DBConn.Open();

            string cQuery = "";
            cQuery = "select concat(a3,'.',c.hang) as merge_a3, a.*, b.hang as a4 from (select a.*, b.bitem as a11s from (select a.*, b.bitem as a2s FROM C_jebon_prn as a left outer join";
            cQuery += " C_bmodel as b on b.a_code='16' and a.a2=b.b_code) as a left outer join C_bmodel as b on b.a_code='08'";
            cQuery += " and a.a11=b.b_code ) as a left outer join (select * from hang_manage where class = '항목') as b on a.a5=b.code1 ";
            cQuery += " left outer join hang_manage as c on a.a3=c.code1 and c.class='제본옵션' ";
            cQuery += " where a.row_id > 0 "+s1 + s2 + s3 + s4 + s5 + s6 + s7 + s8 + s9 + s10 + s11 + s12 + s13 + s14 + s15 + s16;
            var cmd = new MySqlCommand(cQuery, DBConn);
            var myRead = cmd.ExecuteReader();
            //
            int m = 2;
            int x = 0;
            while (myRead.Read())
            {
                grid1.Rows.Insert(m);
                grid1.Rows[m].Height = 24;
                grid1[m, 0] = new SourceGrid.Cells.Cell(myRead["row_id"], typeof(string));

                grid1[m, 1] = new SourceGrid.Cells.CheckBox(null, false);
                
                grid1[m, 2] = new SourceGrid.Cells.Cell(myRead["a1"], typeof(string));
                grid1[m, 2].View = center_cell;

                grid1[m, 3] = new SourceGrid.Cells.Cell(myRead["a2s"], typeof(string));
                grid1[m, 3].View = center_cell;
                grid1[m, 3].Editor = cc.disable_cell;

                grid1[m, 4] = new SourceGrid.Cells.Cell(myRead["a2"], typeof(string));
                grid1[m, 4].View = center_cell;

                grid1[m, 5] = new SourceGrid.Cells.Cell(myRead["merge_a3"], typeof(string));
                grid1[m, 5].View = left_cell;

                grid1[m, 6] = new SourceGrid.Cells.Cell(myRead["a4"], typeof(string));
                grid1[m, 6].View = left_cell;

                grid1[m, 7] = new SourceGrid.Cells.Cell(myRead["a5"], typeof(string));
                grid1[m, 7].View = left_cell;
                //grid1[m, 7].Editor = cc.disable_cell;

                grid1[m, 8] = new SourceGrid.Cells.Cell(myRead["a6"], typeof(string));
                grid1[m, 8].View = left_cell;

                grid1[m, 9] = new SourceGrid.Cells.Cell(myRead["a7"], typeof(string));
                grid1[m, 9].View = left_cell;

                grid1[m, 10] = new SourceGrid.Cells.Cell(myRead["a8"], typeof(string));
                grid1[m, 10].View = left_cell;

                grid1[m, 11] = new SourceGrid.Cells.Cell(myRead["a9"], typeof(string));
                grid1[m, 11].View = left_cell;

                grid1[m, 12] = new SourceGrid.Cells.Cell(myRead["a10"], typeof(string));
                grid1[m, 12].View = left_cell;

                grid1[m, 13] = new SourceGrid.Cells.Cell(myRead["a10_a"], typeof(string));
                grid1[m, 13].View = left_cell;

                grid1[m, 14] = new SourceGrid.Cells.Cell(myRead["a11s"], typeof(string));
                grid1[m, 14].View = left_cell;
                grid1[m, 14].Editor = cc.disable_cell;

                grid1[m, 15] = new SourceGrid.Cells.Cell(myRead["a11"], typeof(string));
                grid1[m, 15].View = center_cell;
                grid1[m, 16] = new SourceGrid.Cells.Cell(myRead["a12"], typeof(string));
                grid1[m, 16].View = left_cell;
                grid1[m, 17] = new SourceGrid.Cells.Cell(myRead["a14"], typeof(string));
                grid1[m, 17].View = left_cell;
                grid1[m, 18] = new SourceGrid.Cells.Cell(myRead["a15"], typeof(string));
                grid1[m, 18].View = left_cell;
                grid1[m, 19] = new SourceGrid.Cells.Cell(myRead["a17"], typeof(string));
                grid1[m, 19].View = left_cell;
                grid1[m, 20] = new SourceGrid.Cells.Cell(myRead["a18"], typeof(string));
                grid1[m, 20].View = left_cell;
                grid1[m, 21] = new SourceGrid.Cells.Cell(myRead["a16"], typeof(string));
                grid1[m, 21].View = center_cell;
                grid1[m, 22] = new SourceGrid.Cells.Cell(myRead["a19"], typeof(string));
                grid1[m, 22].View = left_cell;
                grid1[m, 23] = new SourceGrid.Cells.Cell(myRead["a20"], typeof(string));
                grid1[m, 23].View = left_cell;
                grid1[m, 24] = new SourceGrid.Cells.Cell(myRead["a21"], typeof(string));
                grid1[m, 24].View = center_cell;
                grid1[m, 25] = new SourceGrid.Cells.Cell(myRead["a26"], typeof(string));
                grid1[m, 25].View = center_cell;
                grid1[m, 26] = new SourceGrid.Cells.Cell(myRead["a29"], typeof(string));
                grid1[m, 26].View = center_cell;
                grid1[m, 27] = new SourceGrid.Cells.Cell(myRead["a27"], typeof(string));
                grid1[m, 27].View = center_cell;
                grid1[m, 28] = new SourceGrid.Cells.Cell(myRead["a30"], typeof(string));
                grid1[m, 28].View = center_cell;
                grid1[m, 29] = new SourceGrid.Cells.Cell(myRead["a36"], typeof(string));
                grid1[m, 29].View = center_cell;

                grid1[m, 30] = new SourceGrid.Cells.Cell(myRead["a28"], typeof(string));
                grid1[m, 30].View = center_cell;
                
                grid1[m, 31] = new SourceGrid.Cells.Cell(myRead["a31"], typeof(string));
                grid1[m, 31].View = center_cell;
                grid1[m, 32] = new SourceGrid.Cells.Cell(myRead["a32"], typeof(string));
                grid1[m, 32].View = center_cell;
                grid1[m, 33] = new SourceGrid.Cells.Cell(myRead["a33"], typeof(string));
                grid1[m, 33].View = center_cell;
                grid1[m, 34] = new SourceGrid.Cells.Cell(myRead["a34"], typeof(string));
                grid1[m, 34].View = center_cell;
                grid1[m, 35] = new SourceGrid.Cells.Cell(myRead["a35"], typeof(string));
                grid1[m, 35].View = center_cell;
                grid1[m, 36] = new SourceGrid.Cells.Cell(myRead["a36_a"], typeof(string));
                grid1[m, 36].View = center_cell;
                //
                grid1[m, 37] = new SourceGrid.Cells.Cell(myRead["a22"], typeof(string));
                grid1[m, 37].View = center_cell;
                grid1[m, 38] = new SourceGrid.Cells.Cell(myRead["a23"], typeof(string));
                grid1[m, 38].View = center_cell;
                grid1[m, 39] = new SourceGrid.Cells.Cell(myRead["a24"], typeof(string));
                grid1[m, 39].View = left_cell;
                grid1[m, 40] = new SourceGrid.Cells.Cell(myRead["a25"], typeof(string));
                grid1[m, 40].View = center_cell;
                
                m++;
            }
            myRead.Close();
            DBConn.Close();
        }

        private void button2_Click(object sender, EventArgs e)  //추가
        {

            var DBConn = new MySqlConnection(Config.DB_con1);
            DBConn.Open();
            string cQuery = "";
            cQuery = " insert into C_jebon_prn (a2) values('" + comboBox1.Text.Trim()+ "')";
            var cmd = new MySqlCommand(cQuery, DBConn);
            //
            if (cmd.ExecuteNonQuery() == 0)
            {
                MessageBox.Show("서버 자료 등록에 실패 했습니다.");
                DBConn.Close();
                return;
            }
            cQuery = "SELECT LAST_INSERT_ID() dd";
            cmd = new MySqlCommand(cQuery, DBConn);

            var myRead = cmd.ExecuteReader();
            string row_no = "";
            while (myRead.Read())
                row_no = myRead["dd"].ToString();

            DBConn.Close();
            myRead.Close();

            if (grid1.RowsCount != 0)
            {
                GridNewLine(row_no);

                var position = new SourceGrid.Position(grid1.Rows.Count - 1, 3);
                grid1.Selection.Focus(position, true);
            }
            else
            {
                button4_Click(null, null);
                var position = new SourceGrid.Position(grid1.Rows.Count - 1, 3);
                grid1.Selection.Focus(position, true);
            }
        }

        void GridNewLine(string row_no)
        {
            int Rows = grid1.RowsCount;
            cell_d cc = new cell_d();
            grid1.Rows.Insert(Rows);
            grid1.Rows[Rows].Height = 24;

            grid1[Rows, 0] = new SourceGrid.Cells.Cell(row_no, typeof(string));

            grid1[Rows, 1] = new SourceGrid.Cells.CheckBox(null, false);

            grid1[Rows, 2] = new SourceGrid.Cells.Cell("", typeof(string));
            grid1[Rows, 2].View = cc.center_cell;

            grid1[Rows, 3] = new SourceGrid.Cells.Cell("", typeof(string));
            grid1[Rows, 3].View = cc.center_cell;
            grid1[Rows, 3].Editor = cc.disable_cell;

            grid1[Rows, 4] = new SourceGrid.Cells.Cell("", typeof(string));
            grid1[Rows, 4].View = cc.center_cell;

            grid1[Rows, 5] = new SourceGrid.Cells.Cell("", typeof(string));
            grid1[Rows, 5].View = cc.left_cell;

            grid1[Rows, 6] = new SourceGrid.Cells.Cell("", typeof(string));
            grid1[Rows, 6].View = cc.left_cell;

            grid1[Rows, 7] = new SourceGrid.Cells.Cell("", typeof(string));
            grid1[Rows, 7].View = cc.left_cell;
            grid1[Rows, 7].Editor = cc.disable_cell;

            grid1[Rows, 8] = new SourceGrid.Cells.Cell("", typeof(string));
            grid1[Rows, 8].View = cc.left_cell;

            grid1[Rows, 9] = new SourceGrid.Cells.Cell("", typeof(string));
            grid1[Rows, 9].View = cc.left_cell;

            grid1[Rows, 10] = new SourceGrid.Cells.Cell("", typeof(string));
            grid1[Rows, 10].View = cc.left_cell;

            grid1[Rows, 11] = new SourceGrid.Cells.Cell("", typeof(string));
            grid1[Rows, 11].View = cc.left_cell;

            grid1[Rows, 12] = new SourceGrid.Cells.Cell("", typeof(string));
            grid1[Rows, 12].View = cc.left_cell;

            grid1[Rows, 13] = new SourceGrid.Cells.Cell("", typeof(string));
            grid1[Rows, 13].View = cc.center_cell;
            grid1[Rows, 13].Editor = cc.disable_cell;

            grid1[Rows, 14] = new SourceGrid.Cells.Cell("", typeof(string));
            grid1[Rows, 14].View = cc.center_cell;
            grid1[Rows, 15] = new SourceGrid.Cells.Cell("", typeof(string));
            grid1[Rows, 15].View = cc.left_cell;
            grid1[Rows, 16] = new SourceGrid.Cells.Cell("", typeof(string));
            grid1[Rows, 16].View = cc.left_cell;
            grid1[Rows, 17] = new SourceGrid.Cells.Cell("", typeof(string));
            grid1[Rows, 17].View = cc.left_cell;
            grid1[Rows, 18] = new SourceGrid.Cells.Cell("", typeof(string));
            grid1[Rows, 18].View = cc.left_cell;
            grid1[Rows, 19] = new SourceGrid.Cells.Cell("", typeof(string));
            grid1[Rows, 19].View = cc.left_cell;
            grid1[Rows, 20] = new SourceGrid.Cells.Cell("", typeof(string));
            grid1[Rows, 20].View = cc.left_cell;
            grid1[Rows, 21] = new SourceGrid.Cells.Cell("", typeof(string));
            grid1[Rows, 21].View = cc.left_cell;
            grid1[Rows, 22] = new SourceGrid.Cells.Cell("", typeof(string));
            grid1[Rows, 22].View = cc.left_cell;
            grid1[Rows, 23] = new SourceGrid.Cells.Cell("", typeof(string));
            grid1[Rows, 23].View = cc.left_cell;

            grid1[Rows, 24] = new SourceGrid.Cells.Cell("", typeof(string));
            grid1[Rows, 24].View = cc.center_cell;
            grid1[Rows, 25] = new SourceGrid.Cells.Cell("", typeof(string));
            grid1[Rows, 25].View = cc.center_cell;
            grid1[Rows, 26] = new SourceGrid.Cells.Cell("", typeof(string));
            grid1[Rows, 26].View = cc.center_cell;
            grid1[Rows, 27] = new SourceGrid.Cells.Cell("", typeof(string));
            grid1[Rows, 27].View = cc.center_cell;
            grid1[Rows, 28] = new SourceGrid.Cells.Cell("", typeof(string));
            grid1[Rows, 28].View = cc.center_cell;

            grid1[Rows, 29] = new SourceGrid.Cells.Cell("", typeof(string));
            grid1[Rows, 29].View = cc.left_cell;

            grid1[Rows, 30] = new SourceGrid.Cells.Cell("", typeof(string));
            grid1[Rows, 30].View = cc.center_cell;
            grid1[Rows, 31] = new SourceGrid.Cells.Cell("", typeof(string));
            grid1[Rows, 31].View = cc.center_cell;
            grid1[Rows, 32] = new SourceGrid.Cells.Cell("", typeof(string));
            grid1[Rows, 32].View = cc.center_cell;
            grid1[Rows, 33] = new SourceGrid.Cells.Cell("", typeof(string));
            grid1[Rows, 33].View = cc.center_cell;
            grid1[Rows, 34] = new SourceGrid.Cells.Cell("", typeof(string));
            grid1[Rows, 34].View = cc.center_cell;
            grid1[Rows, 35] = new SourceGrid.Cells.Cell("", typeof(string));
            grid1[Rows, 35].View = cc.center_cell;
            grid1[Rows, 36] = new SourceGrid.Cells.Cell("", typeof(string));
            grid1[Rows, 36].View = cc.left_cell;
            grid1[Rows, 37] = new SourceGrid.Cells.Cell("", typeof(string));
            grid1[Rows, 37].View = cc.left_cell;
            grid1[Rows, 38] = new SourceGrid.Cells.Cell("", typeof(string));
            grid1[Rows, 38].View = cc.left_cell;
            grid1[Rows, 39] = new SourceGrid.Cells.Cell("", typeof(string));
            grid1[Rows, 39].View = cc.center_cell;
            
        }

        private void button1_Click(object sender, EventArgs e)  //삭제
        {
            if (MessageBox.Show("선택하신 항목을 삭제합니까 ?", "항목 삭제", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                string[] sd = new string[grid1.RowsCount];//
                for (int i = 0; i < sd.Length; i++)
                    sd[i] = "0";
                //
                int s = 2;
                for (int i = 2; i < grid1.RowsCount; i++)
                {
                    if (grid1[i, 1].Value.Equals(true))
                    {
                        sd[s] = grid1[i, 0].Value.ToString().Trim();
                        s++;
                    }
                }
                //  DB 삭제
                var DBConn = new MySqlConnection(Config.DB_con1);
                DBConn.Open();
                //
                for (int i = 2; i < sd.Length; i++)
                {

                    if (sd[i].Equals("0"))
                        break;
                    else
                    {
                        string row_no = sd[i];
                        string cQuery = " delete from C_jebon_prn where row_id='" + row_no + "'";
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
                for (int i = 2; i < sd.Length; i++)
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

        public class ValueChangedEvent : SourceGrid.Cells.Controllers.ControllerBase   //내용 수정
        {
            public override void OnValueChanged(SourceGrid.CellContext sender, EventArgs e)
            {
                base.OnValueChanged(sender, e);
                cell_d cc = new cell_d();

                int ps = sender.Position.Column;
                SourceGrid.Grid grid = (SourceGrid.Grid)sender.Grid;
                string cQuery = "";
                string row_no = grid[grid.Selection.ActivePosition.Row, 0].ToString().Trim();
                string dat = "";
                if (sender.Value == null)
                    dat = "";
                else
                    dat = sender.Value.ToString().Trim();
                //
                if (ps == 2)
                    cQuery = " update C_jebon_prn set a1 ='" + dat + "' where row_id='" + row_no + "'";
                else if (ps == 3)
                {
                 //   cQuery = " update C_jebon_prn set a2s ='" + dat + "' where row_id='" + row_no + "'";
                    return;
                }
                else if (ps == 4)
                    cQuery = " update C_jebon_prn set a2 ='" + dat + "' where row_id='" + row_no + "'";
                else if (ps == 5)
                {
                    
                    try
                    {
                        var DBConn1 = new MySqlConnection(Config.DB_con1);
                        DBConn1.Open();
                        cQuery = "select concat(" + dat + ",'.',hang) as result from hang_manage where code1 = '" + dat + "' and class='제본옵션'";
                        var cmd1 = new MySqlCommand(cQuery, DBConn1);
                        var myRead1 = cmd1.ExecuteReader();
                        string hang = "";
                        if (myRead1.Read())
                            hang = myRead1["result"].ToString();

                        myRead1.Close();
                        DBConn1.Close();
                        grid[grid.Selection.ActivePosition.Row, 5] = new SourceGrid.Cells.Cell(hang, typeof(string));
                        grid.Refresh();
                        cQuery = " update C_jebon_prn set a3 ='" + dat + "' where row_id='" + row_no + "'";
                    }
                    catch 
                    {
                        MessageBox.Show("숫자로만 입력해주세요. 저장되지 않았습니다");
                        return;
                    }

                    
                }
                else if (ps == 6)
                    cQuery = " update C_jebon_prn set a4 ='" + dat + "' where row_id='" + row_no + "'";
                else if (ps == 7)
                {
                    cQuery = " update C_jebon_prn set a5 ='" + dat + "' where row_id='" + row_no + "'";
                    //return;
                }
                else if (ps == 8)
                    cQuery = " update C_jebon_prn set a6 ='" + dat + "' where row_id='" + row_no + "'";
                else if (ps == 9)
                    cQuery = " update C_jebon_prn set a7 ='" + dat + "' where row_id='" + row_no + "'";
                else if (ps == 10)
                    cQuery = " update C_jebon_prn set a8 ='" + dat + "' where row_id='" + row_no + "'";
                else if (ps == 11)
                    cQuery = " update C_jebon_prn set a9 ='" + dat + "' where row_id='" + row_no + "'";
                else if (ps == 12)
                    cQuery = " update C_jebon_prn set a10 ='" + dat + "' where row_id='" + row_no + "'";
                else if (ps == 13)
                    cQuery = " update C_jebon_prn set a10_a ='" + dat + "' where row_id='" + row_no + "'";

                else if (ps == 14)
                {
                    //   cQuery = " update C_jebon_prn set a11s ='" + dat + "' where row_id='" + row_no + "'";
                    return;
                }
                else if (ps == 15)
                    cQuery = " update C_jebon_prn set a11 ='" + dat + "' where row_id='" + row_no + "'";
                else if (ps == 16)
                    cQuery = " update C_jebon_prn set a12 ='" + dat + "' where row_id='" + row_no + "'";
                else if (ps == 17)
                    cQuery = " update C_jebon_prn set a14 ='" + dat + "' where row_id='" + row_no + "'";
                else if (ps == 18)
                    cQuery = " update C_jebon_prn set a15 ='" + dat + "' where row_id='" + row_no + "'";
                else if (ps == 19)
                    cQuery = " update C_jebon_prn set a17 ='" + dat + "' where row_id='" + row_no + "'";
                else if (ps == 20)
                    cQuery = " update C_jebon_prn set a18 ='" + dat + "' where row_id='" + row_no + "'";
                else if (ps == 21)
                    cQuery = " update C_jebon_prn set a16 ='" + dat + "' where row_id='" + row_no + "'";
                else if (ps == 22)
                    cQuery = " update C_jebon_prn set a19 ='" + dat + "' where row_id='" + row_no + "'";
                else if (ps == 23)
                    cQuery = " update C_jebon_prn set a20='" + dat + "' where row_id='" + row_no + "'";
                else if (ps == 24)
                    cQuery = " update C_jebon_prn set a21 ='" + dat + "' where row_id='" + row_no + "'";



                else if (ps == 25)
                    cQuery = " update C_jebon_prn set a26 ='" + dat + "' where row_id='" + row_no + "'";
                else if (ps == 26)
                    cQuery = " update C_jebon_prn set a29 ='" + dat + "' where row_id='" + row_no + "'";
                else if (ps == 27)
                    cQuery = " update C_jebon_prn set a27 ='" + dat + "' where row_id='" + row_no + "'";
                else if (ps == 28)
                    cQuery = " update C_jebon_prn set a30 ='" + dat + "' where row_id='" + row_no + "'";
                else if (ps == 29)
                    cQuery = " update C_jebon_prn set a36 ='" + dat + "' where row_id='" + row_no + "'";

                else if (ps == 30)
                    cQuery = " update C_jebon_prn set a28 ='" + dat + "' where row_id='" + row_no + "'";
                else if (ps == 31)
                    cQuery = " update C_jebon_prn set a31 ='" + dat + "' where row_id='" + row_no + "'";
                else if (ps == 32)
                    cQuery = " update C_jebon_prn set a32 ='" + dat + "' where row_id='" + row_no + "'";
                else if (ps == 33)
                    cQuery = " update C_jebon_prn set a33 ='" + dat + "' where row_id='" + row_no + "'";
                else if (ps == 34)
                    cQuery = " update C_jebon_prn set a34 ='" + dat + "' where row_id='" + row_no + "'";
                else if (ps == 35)
                    cQuery = " update C_jebon_prn set a35 ='" + dat + "' where row_id='" + row_no + "'";
                else if (ps == 36)
                    cQuery = " update C_jebon_prn set a36_a ='" + dat + "' where row_id='" + row_no + "'";
                //    
                else if (ps == 37)
                    cQuery = " update C_jebon_prn set a22 ='" + dat + "' where row_id='" + row_no + "'";
                else if (ps == 38)
                    cQuery = " update C_jebon_prn set a23 ='" + dat + "' where row_id='" + row_no + "'";
                else if (ps == 39)
                    cQuery = " update C_jebon_prn set a24 ='" + dat + "' where row_id='" + row_no + "'";
                else if (ps == 40)
                    cQuery = " update C_jebon_prn set a25 ='" + dat + "' where row_id='" + row_no + "'";
                
                else
                    return;

                var DBConn = new MySqlConnection(Config.DB_con1);
                DBConn.Open();
                var cmd = new MySqlCommand(cQuery, DBConn);
                if (cmd.ExecuteNonQuery() == 0)
                    MessageBox.Show("서버 자료 수정에 실패 했습니다.");
                DBConn.Close();
            }
        }

        private void grid1_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button != MouseButtons.Right)
                return;
            else
                MessageBox.Show(grid1.Columns[grid1.Selection.ActivePosition.Column].Width.ToString());
        }

        private void button3_Click(object sender, EventArgs e)  //clear
        {
            comboBox1.Text = "";
            comboBox2.Text = "";
            textBox4.Text = "";
            textBox6.Text = "";
            textBox7.Text = "";
            textBox9.Text = "";
            textBox10.Text = "";
            textBox12.Text = "";
            textBox11.Text = "";
            textBox21.Text = "";
            textBox20.Text = "";
            textBox19.Text = "";
            textBox18.Text = "";
            textBox17.Text = "";
            textBox16.Text = "";
            textBox15.Text = "";
        }
  
        private void button5_Click(object sender, EventArgs e)  //항목복사
        {
            if (MessageBox.Show("선택하신 항목을 복사합니까 ?", "항목 복사", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
               // MessageBox.Show("동일한 코드번호가 중복 저장될 수 없기 때문에, 한번에 1항목만 복사 가능하며, 복사후에는 반드시 코드번호를 수정해 주십시요.");
                //
                string TA_name = "C_jebon_prn";
                MySqlConnection DBConn;
                DBConn = new MySqlConnection(Config.DB_con1);
                DBConn.Open();
                //
                string _row_id = "";
                bool last_id = false;
                string cQuery = "";
                string field_1 = "";
                string field_2 = "";
                int count = 0;
                //
                //20190529 강한별 수정
                cQuery = "SELECT `COLUMN_NAME` FROM `INFORMATION_SCHEMA`.`COLUMNS` WHERE `TABLE_SCHEMA`='" + Config.DB_name + "' AND `TABLE_NAME`='" + TA_name + "'";
                var cmd1 = new MySqlCommand(cQuery, DBConn);
                var myRead1 = cmd1.ExecuteReader();
                //
                while (myRead1.Read())
                {
                    if (myRead1["column_name"].ToString() != "row_id")
                    {
                        field_1 += myRead1["column_name"].ToString().Trim() + ",";
                        if (myRead1["column_name"].ToString() != "a1")
                            field_2 += myRead1["column_name"].ToString().Trim() + ",";
                        else
                            field_2 += "null ,"; 
                    }
                    //
                }
                myRead1.Close();
                field_1 = field_1.Substring(0, field_1.Length - 1);
                field_2 = field_2.Substring(0, field_2.Length - 1);
                //
                for (int i = 2; i < grid1.RowsCount; i++)
                {
                    if (grid1[i, 1].Value.Equals(true))
                    {
                        try
                        {
                            _row_id = grid1[i, 0].ToString();  //row_id
                            //
                            if (count == 0)
                            {
                                cQuery = "insert into C_jebon_prn(" + field_1 + ")  select " + field_2 + " from " + TA_name + " where row_id='" + _row_id + "';";
                                count++;
                            }
                            else
                            {
                                cQuery += "insert into C_jebon_prn(" + field_1 + ")  select " + field_2 + " from " + TA_name + " where row_id='" + _row_id + "';"; 
                            }
                            /*
                            var cmd = new MySqlCommand(cQuery, DBConn);
                            if (cmd.ExecuteNonQuery() == 0)
                                MessageBox.Show("DB 에라발생1");
                            else
                                last_id = true;
                            //
                             */
                            //break;
                        }
                        catch
                        {
                        }
                    }
                }
               //if (last_id == true)
                if (cQuery != "")
                {
                    var cmd = new MySqlCommand(cQuery, DBConn);
                    if (cmd.ExecuteNonQuery() == 0){ MessageBox.Show("DB 에라발생1"); }
                    else
                    {
                        MessageBox.Show("복사하였습니다");
                        count = 0;
                        button4_Click(null, null);
                    }
                }
                DBConn.Close();
            }
        }
    }
}

