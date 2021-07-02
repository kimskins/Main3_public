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
    public partial class Form_208 : Form
    {
        SourceGrid.Cells.Controllers.CustomEvents clickEvent1 = new SourceGrid.Cells.Controllers.CustomEvents();
        SourceGrid.Cells.Controllers.CustomEvents clickEvent2 = new SourceGrid.Cells.Controllers.CustomEvents();
        string DB_TableName_trans = "C_trans_base";
        string x_mode = "";
        public Form_208()
        {
            InitializeComponent();

        }

        private void Form_trans_Load(object sender, EventArgs e)
        {
            Screen srn = Screen.PrimaryScreen;
            int Xb = this.Width;  //좌,우
            this.Location = new Point((srn.Bounds.Width - Xb) / 2, 1);  //좌/우,위/아래
            //
            button3_Click(null, null);
            clickEvent2.Click += new EventHandler(clickEvent_Click2);
            // 
            grid2.Controller.AddController(new ValueChangedEvent2());

        }

        private void button3_Click(object sender, EventArgs e)  //refresh
        {
            select_a();
        }

        private void select_a()  //검색
        {
            var DBConn = new MySqlConnection(Config.DB_con1);
            DBConn.Open();
            string cQuery = "";
            //decimal(소숫점)
            SourceGrid.Cells.Editors.TextBoxNumeric numericEditor = new SourceGrid.Cells.Editors.TextBoxNumeric(typeof(decimal));
            numericEditor.TypeConverter = new DevAge.ComponentModel.Converter.NumberTypeConverter(typeof(decimal), "F1");
            numericEditor.AllowNull = true;
            //중앙셀
            SourceGrid.Cells.Views.Cell center_cell = new SourceGrid.Cells.Views.Cell();
            center_cell.TextAlignment = DevAge.Drawing.ContentAlignment.MiddleCenter;
            //좌측셀
            SourceGrid.Cells.Views.Cell left_cell = new SourceGrid.Cells.Views.Cell();
            left_cell.TextAlignment = DevAge.Drawing.ContentAlignment.MiddleLeft;
            //숫자형 셀(int) 오른쪽셀
            SourceGrid.Cells.Views.Cell Int_cell = new SourceGrid.Cells.Views.Cell();
            Int_cell.TextAlignment = DevAge.Drawing.ContentAlignment.MiddleRight;
            //
            SourceGrid.Cells.Editors.TextBox Int_Editor = new SourceGrid.Cells.Editors.TextBoxNumeric(typeof(int));
            Int_Editor.TypeConverter = new DevAge.ComponentModel.Converter.NumberTypeConverter(typeof(int), "N0");
            Int_Editor.AllowNull = true;
            //
            grid2.Rows.Clear();
            //
            grid2.BorderStyle = BorderStyle.FixedSingle;
            grid2.ColumnsCount = 19;
            grid2.FixedRows = 2;
            grid2.Rows.Insert(0);
            grid2.Rows[0].Height = 26;
            grid2.Rows.Insert(1);
            grid2.Rows[1].Height = 26;
            //
            grid2[0, 0] = new SourceGrid.Cells.ColumnHeader("row_id");
            grid2[0, 0].RowSpan = 2;
            grid2.Columns[0].Visible = false;
            grid2[0, 1] = new MyHeader("√");
            grid2[0, 1].RowSpan = 2;
            grid2[0, 2] = new MyHeader("No");
            grid2[0, 2].RowSpan = 2;
            grid2[0, 3] = new MyHeader("차 량");
            grid2[0, 3].RowSpan = 2;
            grid2[0, 4] = new MyHeader("AB코드");
            grid2[0, 4].RowSpan = 2;
            grid2.Columns[4].Visible = false;
            grid2[0, 5] = new MyHeader("가로");
            grid2[0, 5].RowSpan = 2;
            grid2[0, 6] = new MyHeader("세로");
            grid2[0, 6].RowSpan = 2;
            grid2[0, 7] = new MyHeader("높이");
            grid2[0, 7].RowSpan = 2;
            grid2[0, 8] = new MyHeader("톤수");
            grid2[0, 8].RowSpan = 2;
            grid2[0, 9] = new MyHeader("가능 파렛트");
            grid2[0, 9].ColumnSpan = 10;
            //
            grid2[1, 9] = new MyHeader1("788*1091");
            grid2[1, 10] = new MyHeader1("545*788");
            grid2[1, 11] = new MyHeader1("636*939");
            grid2[1, 12] = new MyHeader1(" * ");
            grid2[1, 13] = new MyHeader1(" * ");
            grid2[1, 14] = new MyHeader1(" * ");
            grid2[1, 15] = new MyHeader1(" * ");
            grid2[1, 16] = new MyHeader1(" * ");
            grid2[1, 17] = new MyHeader1(" * ");
            grid2[1, 18] = new MyHeader1(" * ");
            //
            grid2.Columns[0].Width = 100;
            grid2.Columns[1].Width = 30;
            grid2.Columns[2].Width = 30;
            grid2.Columns[3].Width = 100;
            grid2.Columns[4].Width = 60;
            grid2.Columns[5].Width = 50;
            grid2.Columns[6].Width = 50;
            grid2.Columns[7].Width = 50;
            grid2.Columns[8].Width = 50;
            grid2.Columns[9].Width = 60;
            grid2.Columns[10].Width = 60;
            grid2.Columns[11].Width = 60;
            grid2.Columns[12].Width = 60;
            grid2.Columns[13].Width = 60;
            grid2.Columns[14].Width = 60;
            grid2.Columns[15].Width = 60;
            grid2.Columns[16].Width = 60;
            grid2.Columns[17].Width = 60;
            grid2.Columns[18].Width = 60;
            //
            cQuery = " select * FROM " + DB_TableName_trans + " order by no2";
            var cmd = new MySqlCommand(cQuery, DBConn);
            var myRead = cmd.ExecuteReader();
            //
            int m = 2;
            while (myRead.Read())
            {
                grid2.Rows.Insert(m);
                grid2.Rows[m].Height = 24;
                grid2[m, 0] = new SourceGrid.Cells.Cell(myRead["row_id"], typeof(string));
                grid2[m, 1] = new SourceGrid.Cells.CheckBox(null, false);
                grid2[m, 2] = new SourceGrid.Cells.Cell(myRead["no2"], typeof(string));
                grid2[m, 2].View = Int_cell;
                grid2[m, 2].Editor = Int_Editor;
                grid2[m, 3] = new SourceGrid.Cells.Cell(myRead["car"], typeof(string));
                grid2[m, 3].View = left_cell;
                grid2[m, 4] = new SourceGrid.Cells.Cell(myRead["ab_code"], typeof(string));
                grid2[m, 4].View = center_cell;
                grid2[m, 5] = new SourceGrid.Cells.Cell(myRead["garo"], typeof(string));
                grid2[m, 5].View = Int_cell;
                grid2[m, 5].Editor = Int_Editor;
                grid2[m, 6] = new SourceGrid.Cells.Cell(myRead["sero"], typeof(string));
                grid2[m, 6].View = Int_cell;
                grid2[m, 6].Editor = Int_Editor;
                grid2[m, 7] = new SourceGrid.Cells.Cell(myRead["height"], typeof(string));
                grid2[m, 7].View = Int_cell;
                grid2[m, 7].Editor = Int_Editor;
                grid2[m, 8] = new SourceGrid.Cells.Cell(myRead["ton"], typeof(string));
                grid2[m, 8].View = Int_cell;
                grid2[m, 8].Editor = numericEditor;
                grid2[m, 9] = new SourceGrid.Cells.Cell(myRead["a_788"], typeof(string));
                grid2[m, 9].View = Int_cell;
                grid2[m, 9].Editor = Int_Editor;
                grid2[m, 10] = new SourceGrid.Cells.Cell(myRead["a_545"], typeof(string));
                grid2[m, 10].View = Int_cell;
                grid2[m, 10].Editor = Int_Editor;
                //  
                grid2[m,11] = new SourceGrid.Cells.Cell(myRead["a_636"], typeof(string));
                grid2[m,11].View = Int_cell;
                grid2[m,11].Editor = Int_Editor;
                //
                grid2[m,12] = new SourceGrid.Cells.Cell("", typeof(string));
                grid2[m,12].View = Int_cell;
                grid2[m,12].Editor = Int_Editor;
                //
                grid2[m,13] = new SourceGrid.Cells.Cell("", typeof(string));
                grid2[m,13].View = Int_cell;
                grid2[m,13].Editor = Int_Editor;
                //
                grid2[m,14] = new SourceGrid.Cells.Cell("", typeof(string));
                grid2[m,14].View = Int_cell;
                grid2[m,14].Editor = Int_Editor;
                //
                grid2[m,15] = new SourceGrid.Cells.Cell("", typeof(string));
                grid2[m,15].View = Int_cell;
                grid2[m,15].Editor = Int_Editor;
                //
                grid2[m,16] = new SourceGrid.Cells.Cell("", typeof(string));
                grid2[m,16].View = Int_cell;
                grid2[m,16].Editor = Int_Editor;
                //
                grid2[m,17] = new SourceGrid.Cells.Cell("", typeof(string));
                grid2[m,17].View = Int_cell;
                grid2[m,17].Editor = Int_Editor;
                //
                grid2[m,18] = new SourceGrid.Cells.Cell("", typeof(string));
                grid2[m,18].View = Int_cell;
                grid2[m,18].Editor = Int_Editor;

                m++;
            }
            myRead.Close();
            //
            grid2.Selection.FocusFirstCell(true);
            //
            DBConn.Close();
        }
        
        private void clickEvent_Click2(object sender, EventArgs e)  //Grid2에서 클릭시
        {

        }

        private void button2_Click(object sender, EventArgs e)  //추가
        {
            var DBConn = new MySqlConnection(Config.DB_con1);
            DBConn.Open();
            string cQuery = "";
            // 
            cQuery = " insert into " + DB_TableName_trans + " (no1,no2) select '0', (select max(no2)+1 from " + DB_TableName_trans + ") ";
            var cmd = new MySqlCommand(cQuery, DBConn);
            if (cmd.ExecuteNonQuery() == 0)
            {
                MessageBox.Show("서버 자료 등록에 실패 했습니다.");
                DBConn.Close();
                return;
            }
            else
                select_a();

            DBConn.Close();
        }

        private void button1_Click(object sender, EventArgs e)  //삭제
        {
            string cQuery = "";
            // 
            string[] sd = new string[grid2.RowsCount];//
            for (int i = 0; i < sd.Length; i++)
                sd[i] = "0";
            //
            int s = 0;
            for (int i = 2; i < grid2.RowsCount; i++)
            {
                if (grid2[i, 1].Value.Equals(true))
                {
                    sd[s] = grid2[i, 0].Value.ToString().Trim();
                    s++;
                }
            }
            //  DB 삭제
            for (int i = 0; i < sd.Length; i++)
            {
                if (sd[i].Equals("0"))
                {
                    break;
                }
                else
                {
                    string row_no = sd[i];
                    cQuery += " delete from " + DB_TableName_trans + " where row_id='" + row_no + "';";
                }
            }
            if (cQuery != "")
            {
                var DBConn = new MySqlConnection(Config.DB_con1);
                DBConn.Open();
                var cmd = new MySqlCommand(cQuery, DBConn);
                if (cmd.ExecuteNonQuery() == 0)
                    MessageBox.Show("서버 자료 수정에 실패 했습니다.");
                else
                    select_a();
                //
                DBConn.Close();
            }
        }


        public class ValueChangedEvent2 : SourceGrid.Cells.Controllers.ControllerBase   //내용 수정grid2
        {
            public override void OnValueChanged(SourceGrid.CellContext sender, EventArgs e)
            {
                string DB_TableName_trans = "C_trans_base";
                base.OnValueChanged(sender, e);

                int ps = sender.Position.Column;
                SourceGrid.Grid grid = (SourceGrid.Grid)sender.Grid;
                string cQuery = "";
                string row_no = grid[grid.Selection.ActivePosition.Row, 0].ToString().Trim();
                string dat = grid[grid.Selection.ActivePosition.Row, grid.Selection.ActivePosition.Column].ToString().Trim();
                //
                if (ps == 2)
                    cQuery = " update " + DB_TableName_trans + " set no2='" + dat + "' where row_id='" + row_no + "'";
                else if (ps == 3)
                    cQuery = " update " + DB_TableName_trans + " set car='" + dat + "' where row_id='" + row_no + "'";
                else if (ps == 4)
                    cQuery = " update " + DB_TableName_trans + " set ab_code='" + dat + "' where row_id='" + row_no + "'";
                else if (ps == 5)
                    cQuery = " update " + DB_TableName_trans + " set garo='" + dat + "' where row_id='" + row_no + "'";
                else if (ps == 6)
                    cQuery = " update " + DB_TableName_trans + " set sero='" + dat + "' where row_id='" + row_no + "'";
                else if (ps == 7)
                    cQuery = " update " + DB_TableName_trans + " set height='" + dat + "' where row_id='" + row_no + "'";
                else if (ps == 8)
                    cQuery = " update " + DB_TableName_trans + " set ton='" + dat + "' where row_id='" + row_no + "'";
                else if (ps == 9)
                    cQuery = " update " + DB_TableName_trans + " set a_788='" + dat + "' where row_id='" + row_no + "'";
                else if (ps == 10)
                    cQuery = " update " + DB_TableName_trans + " set a_545='" + dat + "' where row_id='" + row_no + "'";
                else if (ps == 11)
                    cQuery = " update " + DB_TableName_trans + " set a_636='" + dat + "' where row_id='" + row_no + "'";
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

        private void button3_Click_1(object sender, EventArgs e)
        {
            select_a(); 
        }
    }
}
