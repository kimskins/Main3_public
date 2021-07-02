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
    public partial class Form_205 : Form
    {
        public Form_205()
        {
            InitializeComponent();
        }

        private void Form_shang_Load(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();

            Screen srn = Screen.PrimaryScreen;
            int Xb = this.Width;  //좌,우
            this.Location = new Point((srn.Bounds.Width - Xb) / 2, 1);  //좌/우,위/아래
            //
            var DBConn = new MySqlConnection(Config.DB_con1);
            DBConn.Open();
            //string cQuery = " select a,b,c FROM C_bungae_d";

            ksgcontrol KC = new ksgcontrol();
            KC.ControlInit(Config.DB_con1, "","","");

            string cQuery = "select distinct a from (select a.*, b.bitem as b from (select a.*, b.bitem as a from C_bungae_d as a left outer join C_bmodel";
            cQuery += " as  b on b.a_code='16' and a.a_1=b.b_code) as a left outer join C_bmodel as b on b.a_code='08' and a.b_1=b.b_code) as result";

            KC.ComboBoxItemInsert("a", comboBox1, cQuery);

            cQuery = "select distinct b from (select a.*, b.bitem as b from (select a.*, b.bitem as a from C_bungae_d as a left outer join C_bmodel";
            cQuery += " as  b on b.a_code='16' and a.a_1=b.b_code) as a left outer join C_bmodel as b on b.a_code='08' and a.b_1=b.b_code) as result";
            KC.ComboBoxItemInsert("b", comboBox2, cQuery);

            cQuery = "select distinct hang from hang_manage where class='제본옵션'";
            KC.ComboBoxItemInsert("hang", comboBox3, cQuery);
            

            grid1.Controller.AddController(new ValueChangedEvent());
            DBConn.Close();
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
            grid1.ColumnsCount = 24;
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

            grid1[0, 2] = new MyHeader1("제    본");
            grid1[0, 2].ColumnSpan = 2;

            grid1[0, 4] = new MyHeader1("인    쇄");
            grid1[0, 4].ColumnSpan = 2;

            grid1[0, 6] = new MyHeader1("제본옵션");
            grid1[0, 6].ColumnSpan = 2;

            grid1[0, 8] = new MyHeader1("옵션조건");

            grid1[0, 9] = new MyHeader1("분개장 디폴트-1");
            grid1[0, 9].ColumnSpan = 3;

            grid1[0, 12] = new MyHeader1("1차 제 본");
            grid1[0, 12].ColumnSpan = 6;

            grid1[0, 18] = new MyHeader1("2차 제 본");
            grid1[0, 18].ColumnSpan = 3;

            grid1[0, 21] = new MyHeader1("참고 사항");
            grid1[0, 21].RowSpan = 2;

            grid1[0, 22] = new MyHeader1("후공정 통합");
            grid1[0, 22].RowSpan = 2;

            grid1[0, 23] = new MyHeader1("비   고");
            grid1[0, 23].RowSpan = 2;
            //
            grid1[1, 2] = new MyHeader1("제본방식");
            grid1[1, 3] = new MyHeader1("Code");
            grid1[1, 4] = new MyHeader1("인쇄방식");
            grid1[1, 5] = new MyHeader1("Code");
            grid1[1, 6] = new MyHeader1("제본조건");
            grid1[1, 7] = new MyHeader1("Code");
            grid1[1, 8] = new MyHeader("표지/삼각대");

            grid1[1,  9] = new MyHeader("기 본 [ 부수미만 ]");
            grid1[1, 10] = new MyHeader("기 본 [ 부수이상 ]");
            grid1[1, 11] = new MyHeader("추 가");
            
            grid1[1, 12] = new MyHeader("M1");
            grid1[1, 13] = new MyHeader("M2");
            grid1[1, 14] = new MyHeader("M3");
            grid1[1, 15] = new MyHeader("M4");
            grid1[1, 16] = new MyHeader("M5");
            grid1[1, 17] = new MyHeader("M6");
            grid1[1, 18] = new MyHeader("N1");
            grid1[1, 19] = new MyHeader("N2");
            grid1[1, 20] = new MyHeader("N3");
            //            
            grid1.Columns[0].Width = 100;
            grid1.Columns[1].Width = 30;
            grid1.Columns[2].Width = 80;
            grid1.Columns[3].Width = 40;
            grid1.Columns[4].Width = 80;  //
            grid1.Columns[5].Width = 40;
            grid1.Columns[6].Width = 110;  //
            grid1.Columns[7].Width = 40;
            grid1.Columns[8].Width = 76;
            grid1.Columns[9].Width = 160;
            grid1.Columns[10].Width = 160;
            grid1.Columns[11].Width = 100;
            grid1.Columns[12].Width = 50;
            grid1.Columns[13].Width = 50; //
            grid1.Columns[14].Width = 50; //
            grid1.Columns[15].Width = 50; //
            grid1.Columns[16].Width = 50; //
            grid1.Columns[17].Width = 50; //
            grid1.Columns[18].Width = 50; //
            grid1.Columns[19].Width = 50; //
            grid1.Columns[20].Width = 50; //
            grid1.Columns[21].Width =200; //
            grid1.Columns[22].Width = 200; //
            grid1.Columns[23].Width = 200; //
            //
            string s1, s2, s3, s4 = "";
            string c1, c2, c3, c4 = "";
            //
            if (comboBox1.Text != "")
            {
                c1 = comboBox1.Text.Trim();
                s1 = " and a ='" + c1 + "'";
            }
            else
                s1 = "";
            //
            if (comboBox2.Text != "")
            {
                c2 = comboBox2.Text.Trim();
                s2 = " and result.b ='" + c2 + "'";
            }
            else
                s2 = "";
            //
            if (comboBox3.Text != "")
            {
                c3 = comboBox3.Text.Trim();
                s3 = " and c.hang ='" + c3 + "'";
            }
            else
                s3 = "";
            //
            if (textBox1.Text != "")
            {
                c4 = textBox1.Text.Trim();
                s4 = " and result.d ='" + c4 + "'";
            }
            else
                s4 = "";
            //
            var DBConn = new MySqlConnection(Config.DB_con1);
            DBConn.Open();
            string cQuery = "select * from (select a.*, b.bitem as b from (select a.*, b.bitem as a from C_bungae_d as a left outer join C_bmodel";
            cQuery += " as  b on b.a_code='16' and a.a_1=b.b_code) as a left outer join C_bmodel as b on b.a_code='08' and a.b_1=b.b_code) as result";
            cQuery += " left outer join hang_manage as c on result.c_1 = c.code1 and c.class = '제본옵션'";
            cQuery += " where result.row_id > 0 " + s1 + s2 + s3 + s4;
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

                grid1[m, 2] = new SourceGrid.Cells.Cell(myRead["a"], typeof(string));
                grid1[m, 2].View = left_cell;
                grid1[m, 2].Editor = cc.disable_cell;

                grid1[m, 3] = new SourceGrid.Cells.Cell(myRead["a_1"], typeof(string));
                grid1[m, 3].View = center_cell;

                grid1[m, 4] = new SourceGrid.Cells.Cell(myRead["b"], typeof(string));
                grid1[m, 4].View = left_cell;
                grid1[m, 4].Editor = cc.disable_cell;

                grid1[m, 5] = new SourceGrid.Cells.Cell(myRead["b_1"], typeof(string));
                grid1[m, 5].View = center_cell;

                grid1[m, 6] = new SourceGrid.Cells.Cell(myRead["hang"], typeof(string));
                grid1[m, 6].View = left_cell;
                grid1[m, 6].Editor = cc.disable_cell;

                grid1[m, 7] = new SourceGrid.Cells.Cell(myRead["c_1"], typeof(string));
                grid1[m, 7].View = center_cell;

                grid1[m, 8] = new SourceGrid.Cells.Cell(myRead["d"], typeof(string));
                grid1[m, 8].View = center_cell;

                grid1[m, 9] = new SourceGrid.Cells.Cell(myRead["e"], typeof(string));
                grid1[m, 9].View = left_cell;

                grid1[m, 10] = new SourceGrid.Cells.Cell(myRead["e_add"], typeof(string));
                grid1[m, 10].View = left_cell;

                grid1[m, 11] = new SourceGrid.Cells.Cell(myRead["g"], typeof(string));
                grid1[m, 11].View = left_cell;

                grid1[m, 12] = new SourceGrid.Cells.Cell(myRead["m1"], typeof(string));
                grid1[m, 12].View = Int_cell;

                grid1[m, 13] = new SourceGrid.Cells.Cell(myRead["m2"], typeof(string));
                grid1[m, 13].View = Int_cell;

                grid1[m, 14] = new SourceGrid.Cells.Cell(myRead["m3"], typeof(string));
                grid1[m, 14].View = Int_cell;

                grid1[m, 15] = new SourceGrid.Cells.Cell(myRead["m4"], typeof(string));
                grid1[m, 15].View = Int_cell;

                grid1[m, 16] = new SourceGrid.Cells.Cell(myRead["m5"], typeof(string));
                grid1[m, 16].View = Int_cell;

                grid1[m, 17] = new SourceGrid.Cells.Cell(myRead["m6"], typeof(string));
                grid1[m, 17].View = Int_cell;

                grid1[m, 18] = new SourceGrid.Cells.Cell(myRead["n1"], typeof(string));
                grid1[m, 18].View = Int_cell;

                grid1[m, 19] = new SourceGrid.Cells.Cell(myRead["n2"], typeof(string));
                grid1[m, 19].View = Int_cell;

                grid1[m, 20] = new SourceGrid.Cells.Cell(myRead["n3"], typeof(string));
                grid1[m, 20].View = Int_cell;

                grid1[m, 21] = new SourceGrid.Cells.Cell(myRead["bigo"], typeof(string));
                grid1[m, 21].View = left_cell;

                grid1[m, 22] = new SourceGrid.Cells.Cell(myRead["kong_sub"], typeof(string));
                grid1[m, 22].View = left_cell;

                grid1[m, 23] = new SourceGrid.Cells.Cell(myRead["remark"], typeof(string));
                grid1[m, 23].View = left_cell;

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
            cQuery = " insert into C_bungae_d(a_1) values('')";
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
            grid1[Rows, 2].View = cc.left_cell;
            grid1[Rows, 2].Editor = cc.disable_cell;

            grid1[Rows, 3] = new SourceGrid.Cells.Cell("", typeof(string));
            grid1[Rows, 3].View = cc.center_cell;

            grid1[Rows, 4] = new SourceGrid.Cells.Cell("", typeof(string));
            grid1[Rows, 4].View = cc.left_cell;
            grid1[Rows, 4].Editor = cc.disable_cell;

            grid1[Rows, 5] = new SourceGrid.Cells.Cell("", typeof(string));
            grid1[Rows, 5].View = cc.center_cell;

            grid1[Rows, 6] = new SourceGrid.Cells.Cell("", typeof(string));
            grid1[Rows, 6].View = cc.center_cell;

            grid1[Rows, 7] = new SourceGrid.Cells.Cell("", typeof(string));
            grid1[Rows, 7].View = cc.center_cell;

            grid1[Rows, 8] = new SourceGrid.Cells.Cell("", typeof(string));
            grid1[Rows, 8].View = cc.center_cell;

            grid1[Rows, 9] = new SourceGrid.Cells.Cell("", typeof(string));
            grid1[Rows, 9].View = cc.left_cell;

            grid1[Rows, 10] = new SourceGrid.Cells.Cell("", typeof(string));
            grid1[Rows, 10].View = cc.left_cell;

            grid1[Rows, 11] = new SourceGrid.Cells.Cell("", typeof(string));
            grid1[Rows, 11].View = cc.left_cell;

            grid1[Rows, 12] = new SourceGrid.Cells.Cell("", typeof(string));
            grid1[Rows, 12].View = cc.int_cell;

            grid1[Rows, 13] = new SourceGrid.Cells.Cell("", typeof(string));
            grid1[Rows, 13].View = cc.left_cell;

            grid1[Rows, 14] = new SourceGrid.Cells.Cell("", typeof(string));
            grid1[Rows, 14].View = cc.int_cell;

            grid1[Rows, 15] = new SourceGrid.Cells.Cell("", typeof(string));
            grid1[Rows, 15].View = cc.int_cell;

            grid1[Rows, 16] = new SourceGrid.Cells.Cell("", typeof(string));
            grid1[Rows, 16].View = cc.int_cell;

            grid1[Rows, 17] = new SourceGrid.Cells.Cell("", typeof(string));
            grid1[Rows, 17].View = cc.int_cell;

            grid1[Rows, 18] = new SourceGrid.Cells.Cell("", typeof(string));
            grid1[Rows, 18].View = cc.int_cell;

            grid1[Rows, 19] = new SourceGrid.Cells.Cell("", typeof(string));
            grid1[Rows, 19].View = cc.int_cell;

            grid1[Rows, 20] = new SourceGrid.Cells.Cell("", typeof(string));
            grid1[Rows, 20].View = cc.int_cell;

            grid1[Rows, 21] = new SourceGrid.Cells.Cell("", typeof(string));
            grid1[Rows, 21].View = cc.int_cell;

            grid1[Rows, 22] = new SourceGrid.Cells.Cell("", typeof(string));
            grid1[Rows, 22].View = cc.int_cell;

            grid1[Rows, 23] = new SourceGrid.Cells.Cell("", typeof(string));
            grid1[Rows, 23].View = cc.int_cell;

        }

        private void button1_Click(object sender, EventArgs e) //삭제
        {
            if (MessageBox.Show("선택하신 항목을 삭제합니까 ?", "항목 삭제", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                string[] sd = new string[grid1.RowsCount];//
                for (int i = 0; i < sd.Length; i++)
                    sd[i] = "0";
                //
                int s = 2;
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
                for (int i = 2; i < sd.Length; i++)
                {

                    if (sd[i].Equals("0"))
                        break;
                    else
                    {
                        string row_no = sd[i];
                        string cQuery = " delete from C_bungae_d where row_id='" + row_no + "'";
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
                {
                 //   cQuery = " update C_bungae_d set a ='" + dat + "' where row_id='" + row_no + "'";
                    return;
                }
                else if (ps == 3)
                    cQuery = " update C_bungae_d set a_1 ='" + dat + "' where row_id='" + row_no + "'";
                else if (ps == 4)
                {
                    //   cQuery = " update C_bungae_d set b ='" + dat + "' where row_id='" + row_no + "'";
                    return;
                }
                else if (ps == 5)
                    cQuery = " update C_bungae_d set b_1 ='" + dat + "' where row_id='" + row_no + "'";
                //else if (ps == 6)
                //    cQuery = " update C_bungae_d set c ='" + dat + "' where row_id='" + row_no + "'";
                else if (ps == 7)
                {
                    var DBConn = new MySqlConnection(Config.DB_con1);
                    DBConn.Open();
                    cQuery = "select * from hang_manage where code1 = '"+dat+"' and class='제본옵션'";
                    var cmd = new MySqlCommand(cQuery, DBConn);
                    var myRead = cmd.ExecuteReader();
                    string hang = "";
                    if(myRead.Read())
                        hang = myRead["hang"].ToString();

                    myRead.Close();
                    DBConn.Close();
                    grid[grid.Selection.ActivePosition.Row, 6] = new SourceGrid.Cells.Cell(hang, typeof(string));
                    grid[grid.Selection.ActivePosition.Row, 6].View = cc.center_cell;
                    grid.Refresh();

                    cQuery = " update C_bungae_d set c_1 ='" + dat + "' where row_id='" + row_no + "'";

                }
                else if (ps == 8)
                    cQuery = " update C_bungae_d set d ='" + dat + "' where row_id='" + row_no + "'";
                else if (ps == 9)
                    cQuery = " update C_bungae_d set e ='" + dat + "' where row_id='" + row_no + "'";

                else if (ps == 10)
                    cQuery = " update C_bungae_d set e_add ='" + dat + "' where row_id='" + row_no + "'";

                else if (ps == 11)
                    cQuery = " update C_bungae_d set g ='" + dat + "' where row_id='" + row_no + "'";
                else if (ps == 12)
                    cQuery = " update C_bungae_d set m1 ='" + dat + "' where row_id='" + row_no + "'";
                else if (ps == 13)
                    cQuery = " update C_bungae_d set m2 ='" + dat + "' where row_id='" + row_no + "'";
                else if (ps == 14)
                    cQuery = " update C_bungae_d set m3 ='" + dat + "' where row_id='" + row_no + "'";
                else if (ps == 15)
                    cQuery = " update C_bungae_d set m4 ='" + dat + "' where row_id='" + row_no + "'";
                else if (ps == 16)
                    cQuery = " update C_bungae_d set m5 ='" + dat + "' where row_id='" + row_no + "'";
                else if (ps == 17)
                    cQuery = " update C_bungae_d set m6 ='" + dat + "' where row_id='" + row_no + "'";
                else if (ps == 18)
                    cQuery = " update C_bungae_d set n1 ='" + dat + "' where row_id='" + row_no + "'";
                else if (ps == 19)
                    cQuery = " update C_bungae_d set n2 ='" + dat + "' where row_id='" + row_no + "'";
                else if (ps == 20)
                    cQuery = " update C_bungae_d set n3 ='" + dat + "' where row_id='" + row_no + "'";
                else if (ps == 21)
                    cQuery = " update C_bungae_d set bigo ='" + dat + "' where row_id='" + row_no + "'";
                else if (ps == 22)
                    cQuery = " update C_bungae_d set kong_sub ='" + dat + "' where row_id='" + row_no + "'";
                else if (ps == 23)
                    cQuery = " update C_bungae_d set remark ='" + dat + "' where row_id='" + row_no + "'";
                else
                    return;

                var DBConn1 = new MySqlConnection(Config.DB_con1);
                DBConn1.Open();
                var cmd1 = new MySqlCommand(cQuery, DBConn1);
                if (cmd1.ExecuteNonQuery() == 0)
                    MessageBox.Show("서버 자료 수정에 실패 했습니다.");
                DBConn1.Close();
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)  //Clear
        {
            comboBox1.Text = "";
            comboBox2.Text = "";
            comboBox3.Text = "";
            textBox1.Text = "";
        }

        private void button5_Click(object sender, EventArgs e)  //항목복사
        {
            if (MessageBox.Show("선택하신 항목을 복사합니까 ?", "항목 복사", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                string TA_name = "C_bungae_d";
                MySqlConnection DBConn;
                DBConn = new MySqlConnection(Config.DB_con1);
                DBConn.Open();
                //
                string _row_id = "";
                string cQuery = "";
                string field_1 = "";
                string field_2 = "";
                //
                cQuery = "SELECT `COLUMN_NAME` FROM `INFORMATION_SCHEMA`.`COLUMNS` WHERE `TABLE_SCHEMA`='" + Config.DB_name + "' AND `TABLE_NAME`='" + TA_name + "'";
                var cmd1 = new MySqlCommand(cQuery, DBConn);
                var myRead1 = cmd1.ExecuteReader();
                //
                while (myRead1.Read())
                {
                    if (myRead1["column_name"].ToString() != "row_id")
                    {
                        field_1 += myRead1["column_name"].ToString().Trim() + ",";
                        //
                        if (myRead1["column_name"].ToString() == "remark")
                            field_2 += "'복사',";
                        else
                            field_2 += myRead1["column_name"].ToString().Trim() + ",";
                    }
                    //
                }
                myRead1.Close();
                field_1 = field_1.Substring(0, field_1.Length - 1);
                field_2 = field_2.Substring(0, field_2.Length - 1);
                //
                cQuery = "";
                for (int i = 2; i < grid1.RowsCount; i++)
                {
                    if (grid1[i, 1].Value.Equals(true))
                    {
                        try
                        {
                            _row_id = grid1[i, 0].ToString();  //row_id
                            cQuery += "insert into C_bungae_d(" + field_1 + ")  select " + field_2 + " from " + TA_name + " where row_id='" + _row_id + "';";
                        }
                        catch
                        {
                        }
                    }
                }
                if (cQuery != "")
                {
                    var cmd = new MySqlCommand(cQuery, DBConn);
                    if (cmd.ExecuteNonQuery() == 0) { MessageBox.Show("DB 에라발생1"); }
                    else
                    {
                        MessageBox.Show("복사하였습니다");
                        button4_Click(null, null);
                    }
                }
                DBConn.Close();
            }
        }
    }
}
