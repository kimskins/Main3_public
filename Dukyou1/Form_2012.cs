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
    public partial class Form_2012 : Form
    {
        string DB_TableName_jul = "C_sel_jul";
        string DB_TableName_jul_sub = "C_sel_jul_sub";

        SourceGrid.Cells.Editors.ComboBox cbLefttop;
        SourceGrid.Cells.Editors.ComboBox cbKook;
        SourceGrid.Cells.Editors.ComboBox cbJebon;

        SourceGridControl GridHandle = new SourceGridControl();
        public Form_2012()
        {
            InitializeComponent();
        }

        private void Form_2013_Load(object sender, EventArgs e)
        {
            Screen srn = Screen.PrimaryScreen;
            int Xb = this.Width;  //좌,우
            int Yb = this.Height; //좌,우
            this.Location = new Point((srn.Bounds.Width - Xb) / 2, (srn.Bounds.Height - Yb) / 2);  //좌/우,위/아래

            GridHandle.SourceGrideInit(grid1, Config.DB_con1, Config.Ftp_ip1, Config.Ftp_id1, Config.Ftp_pw1);


            SourceGrid.Cells.Controllers.CustomEvents val_c1 = new SourceGrid.Cells.Controllers.CustomEvents();
            val_c1.ValueChanged += new EventHandler(ValueChangedEvent1);
            grid1.Controller.AddController(val_c1);

            string Query = "select a.*, b.a, b.b, b.c, b.d, b.e, b.f, b.j from " + DB_TableName_jul_sub + " a left outer join " + DB_TableName_jul + " b on a.int_id = b.row_id";
            Query += " order by a.row_id";
            GridView(Query);
        }

        public void GridView(string Query)
        {
            string[] lefttop = new string[2];
            string[] kook = new string[2];
            string[] jebon = new string[2];
            lefttop[0] = "좌";
            lefttop[1] = "상";
            kook[0] = "국";
            kook[1] = "46";
            jebon[0] = "중철";
            jebon[1] = "무선";

            cbLefttop = new SourceGrid.Cells.Editors.ComboBox(typeof(string), lefttop, false);
            cbKook = new SourceGrid.Cells.Editors.ComboBox(typeof(string), kook, false);
            cbJebon = new SourceGrid.Cells.Editors.ComboBox(typeof(string), jebon, false);
            cbLefttop.EditableMode = SourceGrid.EditableMode.Focus | SourceGrid.EditableMode.AnyKey | SourceGrid.EditableMode.SingleClick;
            cbKook.EditableMode = SourceGrid.EditableMode.Focus | SourceGrid.EditableMode.AnyKey | SourceGrid.EditableMode.SingleClick;
            cbJebon.EditableMode = SourceGrid.EditableMode.Focus | SourceGrid.EditableMode.AnyKey | SourceGrid.EditableMode.SingleClick;

            cell_d cc = new cell_d();

            grid1.Rows.Clear();
            grid1.BorderStyle = BorderStyle.FixedSingle;
            grid1.SelectionMode = SourceGrid.GridSelectionMode.Cell;
            grid1.ColumnsCount = 49;
            grid1.FixedRows = 2;
            grid1.Rows.Insert(0);
            grid1.Rows[0].Height = 24;
            grid1.Rows.Insert(1);
            grid1.Rows[1].Height = 24;
            
            grid1[0, 0] = new MyHeader1("row_id");
            grid1[0, 0].RowSpan = 2;
            grid1.Columns[0].Visible = false;

            grid1[0, 1] = new MyHeader1("√");
            grid1[0, 1].RowSpan = 2;

            grid1[0, 2] = new MyHeader1("no");
            grid1[0, 2].RowSpan = 2;

            grid1[0, 3] = new MyHeader1("구분");
            grid1[0, 3].RowSpan = 2;

            grid1[0, 4] = new MyHeader1("code");
            grid1[1, 4] = new MyHeader("-");

            grid1[0, 5] = new MyHeader1("원절수 정보");
            grid1[0, 5].ColumnSpan = 7;
            grid1[1, 5] = new MyHeader1("국46");
            grid1[1, 6] = new MyHeader1("좌상");
            grid1[1, 7] = new MyHeader1("C절수");
            grid1[1, 8] = new MyHeader1("I절수");
            grid1[1, 9] = new MyHeader1("실가");
            grid1[1, 10] = new MyHeader1("실세");
            grid1[1, 11] = new MyHeader1("판");

            grid1[0, 12] = new MyHeader1("유형");
            grid1[1, 12] = new MyHeader("-");

            grid1[0, 13] = new MyHeader1("PAGE");
            grid1[1, 13] = new MyHeader("-");

            grid1[0, 14] = new MyHeader1("대체절수 정보[완전 분개형]");
            grid1[0, 14].ColumnSpan = 8;
            grid1[1, 14] = new MyHeader1("기능No");
            grid1[1, 15] = new MyHeader1("국 46");
            grid1[1, 16] = new MyHeader1("좌상");
            grid1[1, 17] = new MyHeader1("C절수");
            grid1[1, 18] = new MyHeader1("I절수");
            grid1[1, 19] = new MyHeader1("실가");
            grid1[1, 20] = new MyHeader1("실세");
            grid1[1, 21] = new MyHeader1("판");

            grid1[0, 22] = new MyHeader1("접지방법_1");
            grid1[0, 22].RowSpan = 2;

            grid1[0, 23] = new MyHeader1("접지방법_2");
            grid1[0, 23].RowSpan = 2;

            grid1[0, 24] = new MyHeader1("인쇄방법");
            grid1[0, 24].RowSpan = 2;

            grid1[0, 25] = new MyHeader1("대체절수 정보[자동 합대형]");
            grid1[0, 25].ColumnSpan = 9;
            grid1[1, 25] = new MyHeader1("기능No");
            grid1[1, 26] = new MyHeader1("국 46");
            grid1[1, 27] = new MyHeader1("좌상");
            grid1[1, 28] = new MyHeader1("C절수");
            grid1[1, 29] = new MyHeader1("I절수");
            grid1[1, 30] = new MyHeader1("실가");
            grid1[1, 31] = new MyHeader1("실세");
            grid1[1, 32] = new MyHeader1("판");
            grid1[1, 33] = new MyHeader1("추가Pg");

            grid1[0, 34] = new MyHeader1("접지방법_1");
            grid1[0, 34].RowSpan = 2;

            grid1[0, 35] = new MyHeader1("접지방법_2");
            grid1[0, 35].RowSpan = 2;

            grid1[0, 36] = new MyHeader1("인쇄방법");
            grid1[0, 36].RowSpan = 2;

            grid1[0, 37] = new MyHeader1("대체절수 정보[통 합대형]");
            grid1[0, 37].ColumnSpan = 9;
            grid1[1, 37] = new MyHeader1("기능No");
            grid1[1, 38] = new MyHeader1("국 46");
            grid1[1, 39] = new MyHeader1("좌상");
            grid1[1, 40] = new MyHeader1("C절수");
            grid1[1, 41] = new MyHeader1("I절수");
            grid1[1, 42] = new MyHeader1("실가");
            grid1[1, 43] = new MyHeader1("실세");
            grid1[1, 44] = new MyHeader1("판");
            grid1[1, 45] = new MyHeader1("추가Pg");

            grid1[0, 46] = new MyHeader1("접지방법_1");
            grid1[0, 46].RowSpan = 2;

            grid1[0, 47] = new MyHeader1("접지방법_2");
            grid1[0, 47].RowSpan = 2;

            grid1[0, 48] = new MyHeader1("인쇄방법");
            grid1[0, 48].RowSpan = 2;


            grid1.Columns[1].Width = 22;
            grid1.Columns[2].Width = 30;
            grid1.Columns[3].Width = 40;
            grid1.Columns[4].Width = 50;
            grid1.Columns[5].Width = 50;
            grid1.Columns[6].Width = 50;
            grid1.Columns[7].Width = 50;
            grid1.Columns[8].Width = 50;
            grid1.Columns[9].Width = 50;
            grid1.Columns[10].Width = 50;

            grid1.Columns[11].Width = 20;

            grid1.Columns[12].Width = 50;
            grid1.Columns[13].Width = 50;
            grid1.Columns[14].Width = 50;
            grid1.Columns[15].Width = 50;
            grid1.Columns[16].Width = 50;
            grid1.Columns[17].Width = 50;
            grid1.Columns[18].Width = 50;
            grid1.Columns[19].Width = 50;
            grid1.Columns[20].Width = 50;

            grid1.Columns[21].Width = 20;

            grid1.Columns[22].Width = 150;
            grid1.Columns[23].Width = 150;
            grid1.Columns[24].Width = 100;
            grid1.Columns[25].Width = 50;
            grid1.Columns[26].Width = 50;
            grid1.Columns[27].Width = 50;
            grid1.Columns[28].Width = 50;
            grid1.Columns[29].Width = 50;
            grid1.Columns[30].Width = 50;
            grid1.Columns[31].Width = 50;

            grid1.Columns[32].Width = 20;

            grid1.Columns[33].Width = 50;
            grid1.Columns[34].Width = 150;
            grid1.Columns[35].Width = 150;
            grid1.Columns[36].Width = 100;
            grid1.Columns[37].Width = 50;
            grid1.Columns[38].Width = 50;
            grid1.Columns[39].Width = 50;
            grid1.Columns[40].Width = 50;
            grid1.Columns[41].Width = 50;
            grid1.Columns[42].Width = 50;
            grid1.Columns[43].Width = 50;

            grid1.Columns[44].Width = 20;

            grid1.Columns[45].Width = 50;
            grid1.Columns[46].Width = 150;
            grid1.Columns[47].Width = 150;
            grid1.Columns[48].Width = 100;
            

            MySqlConnection DBConn;
            DBConn = new MySqlConnection(Config.DB_con1);
            DBConn.Open();

            var cmd = new MySqlCommand(Query, DBConn);
            var myRead = cmd.ExecuteReader();

            int m = 2;
            while (myRead.Read())
            {
                
                grid1.Rows.Insert(m);
                grid1.Rows[m].Height = 22;

                grid1[m, 0] = new SourceGrid.Cells.Cell(myRead["row_id"], typeof(string));
                grid1[m, 1] = new SourceGrid.Cells.CheckBox(null, false);

                grid1[m, 2] = new SourceGrid.Cells.Cell((m - 1).ToString(), typeof(string));
                grid1[m, 2].View = cc.center_cell;

                grid1[m, 3] = new SourceGrid.Cells.Cell(myRead["gubun"], typeof(string));
                grid1[m, 3].View = cc.center_cellr;

                grid1[m, 4] = new SourceGrid.Cells.Cell(myRead["int_id"], typeof(string));
                grid1[m, 4].View = cc.center_cell;

                grid1[m, 5] = new SourceGrid.Cells.Cell(myRead["a"], typeof(string));
                grid1[m, 5].View = cc.center_cell;
                grid1[m, 5].Editor = cc.disable_cell;

                grid1[m, 6] = new SourceGrid.Cells.Cell(myRead["b"], typeof(string));
                grid1[m, 6].View = cc.center_cell;
                grid1[m, 6].Editor = cc.disable_cell;

                grid1[m, 7] = new SourceGrid.Cells.Cell(myRead["c"], typeof(string));
                grid1[m, 7].View = cc.center_cell;
                grid1[m, 7].Editor = cc.disable_cell;

                grid1[m, 8] = new SourceGrid.Cells.Cell(myRead["d"], typeof(string));
                grid1[m, 8].View = cc.center_cell;
                grid1[m, 8].Editor = cc.disable_cell;

                grid1[m, 9] = new SourceGrid.Cells.Cell(myRead["e"], typeof(string));
                grid1[m, 9].View = cc.center_cell;
                grid1[m, 9].Editor = cc.disable_cell;

                grid1[m, 10] = new SourceGrid.Cells.Cell(myRead["f"], typeof(string));
                grid1[m, 10].View = cc.center_cell;
                grid1[m, 10].Editor = cc.disable_cell;

                grid1[m, 11] = new SourceGrid.Cells.Cell(myRead["j"], typeof(string));
                grid1[m, 11].View = cc.center_cell;
                grid1[m, 11].Editor = cc.disable_cell;

                grid1[m, 12] = new SourceGrid.Cells.Cell(myRead["yuhyung"], typeof(string));
                grid1[m, 12].View = cc.center_cellr;
                grid1[m, 12].Editor = cbJebon;

                grid1[m, 13] = new SourceGrid.Cells.Cell(myRead["page"], typeof(int));
                grid1[m, 13].View = cc.int_cellr;
                grid1[m, 13].Editor = cc.int_editor;

                grid1[m, 14] = new SourceGrid.Cells.Cell(myRead["function_no_1"], typeof(string));
                grid1[m, 14].View = cc.center_cellr;

                grid1[m, 15] = new SourceGrid.Cells.Cell(myRead["kook_1"], typeof(string));
                grid1[m, 15].View = cc.center_cellr;
                grid1[m, 15].Editor = cbKook;

                grid1[m, 16] = new SourceGrid.Cells.Cell(myRead["lefttop_1"], typeof(string));
                grid1[m, 16].View = cc.center_cellr;
                grid1[m, 16].Editor = cbLefttop;

                grid1[m, 17] = new SourceGrid.Cells.Cell(myRead["c_jul_1"], typeof(int));
                grid1[m, 17].View = cc.int_cellr;
                grid1[m, 17].Editor = cc.int_editor;

                grid1[m, 18] = new SourceGrid.Cells.Cell(myRead["i_jul_1"], typeof(int));
                grid1[m, 18].View = cc.int_cellr;
                grid1[m, 18].Editor = cc.int_editor;

                grid1[m, 19] = new SourceGrid.Cells.Cell(myRead["silga_1"], typeof(int));
                grid1[m, 19].View = cc.int_cellr;
                grid1[m, 19].Editor = cc.int_editor;

                grid1[m, 20] = new SourceGrid.Cells.Cell(myRead["silse_1"], typeof(int));
                grid1[m, 20].View = cc.int_cellr;
                grid1[m, 20].Editor = cc.int_editor;

                grid1[m, 21] = new SourceGrid.Cells.Cell(myRead["pan_1"], typeof(string));
                grid1[m, 21].View = cc.center_cellr;

                grid1[m, 22] = new SourceGrid.Cells.Cell(myRead["jubji_a_1"], typeof(string));
                grid1[m, 22].View = cc.center_cellr;

                grid1[m, 23] = new SourceGrid.Cells.Cell(myRead["jubji_b_1"], typeof(string));
                grid1[m, 23].View = cc.center_cellr;

                grid1[m, 24] = new SourceGrid.Cells.Cell(myRead["prn_way_1"], typeof(string));
                grid1[m, 24].View = cc.center_cellr;

                grid1[m, 25] = new SourceGrid.Cells.Cell(myRead["function_no_2"], typeof(string));
                grid1[m, 25].View = cc.center_cellr;

                grid1[m, 26] = new SourceGrid.Cells.Cell(myRead["kook_2"], typeof(string));
                grid1[m, 26].View = cc.center_cellr;
                grid1[m, 26].Editor = cbKook;

                grid1[m, 27] = new SourceGrid.Cells.Cell(myRead["lefttop_2"], typeof(string));
                grid1[m, 27].View = cc.center_cellr;
                grid1[m, 27].Editor = cbLefttop;

                grid1[m, 28] = new SourceGrid.Cells.Cell(myRead["c_jul_2"], typeof(int));
                grid1[m, 28].View = cc.int_cellr;
                grid1[m, 28].Editor = cc.int_editor;

                grid1[m, 29] = new SourceGrid.Cells.Cell(myRead["i_jul_2"], typeof(int));
                grid1[m, 29].View = cc.int_cellr;
                grid1[m, 29].Editor = cc.int_editor;

                grid1[m, 30] = new SourceGrid.Cells.Cell(myRead["silga_2"], typeof(int));
                grid1[m, 30].View = cc.int_cellr;
                grid1[m, 30].Editor = cc.int_editor;

                grid1[m, 31] = new SourceGrid.Cells.Cell(myRead["silse_2"], typeof(int));
                grid1[m, 31].View = cc.int_cellr;
                grid1[m, 31].Editor = cc.int_editor;

                grid1[m, 32] = new SourceGrid.Cells.Cell(myRead["pan_2"], typeof(string));
                grid1[m, 32].View = cc.center_cellr;

                grid1[m, 33] = new SourceGrid.Cells.Cell(myRead["add_pg_2"], typeof(string));
                grid1[m, 33].View = cc.int_cellr;
                grid1[m, 33].Editor = cc.int_editor;

                grid1[m, 34] = new SourceGrid.Cells.Cell(myRead["jubji_a_2"], typeof(string));
                grid1[m, 34].View = cc.center_cellr;

                grid1[m, 35] = new SourceGrid.Cells.Cell(myRead["jubji_b_2"], typeof(string));
                grid1[m, 35].View = cc.center_cellr;

                grid1[m, 36] = new SourceGrid.Cells.Cell(myRead["prn_way_2"], typeof(string));
                grid1[m, 36].View = cc.center_cellr;

                grid1[m, 37] = new SourceGrid.Cells.Cell(myRead["function_no_3"], typeof(string));
                grid1[m, 37].View = cc.center_cellr;

                grid1[m, 38] = new SourceGrid.Cells.Cell(myRead["kook_3"], typeof(string));
                grid1[m, 38].View = cc.center_cellr;
                grid1[m, 38].Editor = cbKook;

                grid1[m, 39] = new SourceGrid.Cells.Cell(myRead["lefttop_3"], typeof(string));
                grid1[m, 39].View = cc.center_cellr;
                grid1[m, 39].Editor = cbLefttop;

                grid1[m, 40] = new SourceGrid.Cells.Cell(myRead["c_jul_3"], typeof(int));
                grid1[m, 40].View = cc.int_cellr;
                grid1[m, 40].Editor = cc.int_editor;

                grid1[m, 41] = new SourceGrid.Cells.Cell(myRead["i_jul_3"], typeof(int));
                grid1[m, 41].View = cc.int_cellr;
                grid1[m, 41].Editor = cc.int_editor;

                grid1[m, 42] = new SourceGrid.Cells.Cell(myRead["silga_3"], typeof(int));
                grid1[m, 42].View = cc.int_cellr;
                grid1[m, 42].Editor = cc.int_editor;

                grid1[m, 43] = new SourceGrid.Cells.Cell(myRead["silse_3"], typeof(int));
                grid1[m, 43].View = cc.int_cellr;
                grid1[m, 43].Editor = cc.int_editor;

                grid1[m, 44] = new SourceGrid.Cells.Cell(myRead["pan_3"], typeof(string));
                grid1[m, 44].View = cc.center_cellr;

                grid1[m, 45] = new SourceGrid.Cells.Cell(myRead["add_pg_3"], typeof(string));
                grid1[m, 45].View = cc.int_cellr;
                grid1[m, 45].Editor = cc.int_editor;

                grid1[m, 46] = new SourceGrid.Cells.Cell(myRead["jubji_a_3"], typeof(string));
                grid1[m, 46].View = cc.center_cellr;

                grid1[m, 47] = new SourceGrid.Cells.Cell(myRead["jubji_b_3"], typeof(string));
                grid1[m, 47].View = cc.center_cellr;

                grid1[m, 48] = new SourceGrid.Cells.Cell(myRead["prn_way_3"], typeof(string));
                grid1[m, 48].View = cc.center_cellr;
                m++;
            }
            myRead.Close();
            DBConn.Close();

        }

        private void bClear_Click(object sender, EventArgs e)
        {
            cbKook_origin.Text = "";
            cbKook_1.Text = "";
            cbKook_2.Text = "";
            cbKook_3.Text = "";

            cbLefttop_origin.Text = "";
            cbLefttop_1.Text = "";
            cbLefttop_2.Text = "";
            cbLefttop_3.Text = "";

            tbCjulsu_origin.Text = "";
            tbCjulsu_1.Text = "";
            tbCjulsu_2.Text = "";
            tbCjulsu_3.Text = "";

            tbIjulsu_origin.Text = "";
            tbIjulsu_1.Text = "";
            tbIjulsu_2.Text = "";
            tbIjulsu_3.Text = "";

            tbSilga_origin.Text = "";
            tbSilga_1.Text = "";
            tbSilga_2.Text = "";
            tbSilga_3.Text = "";

            tbSilse_origin.Text = "";
            tbSilse_1.Text = "";
            tbSilse_2.Text = "";
            tbSilse_3.Text = "";

            tbPage.Text = "";
            cbYuhyung.Text = "";

            chkGubun1.Checked = true;
            chkGubun2.Checked = true;

            tbPage.Refresh();
            cbYuhyung.Refresh();

            cbKook_origin.Refresh();
            cbKook_1.Refresh();
            cbKook_2.Refresh();
            cbKook_3.Refresh();

            cbLefttop_origin.Refresh();
            cbLefttop_1.Refresh();
            cbLefttop_2.Refresh();
            cbLefttop_3.Refresh();

            tbCjulsu_origin.Refresh();
            tbCjulsu_1.Refresh();
            tbCjulsu_2.Refresh();
            tbCjulsu_3.Refresh();

            tbIjulsu_origin.Refresh();
            tbIjulsu_1.Refresh();
            tbIjulsu_2.Refresh();
            tbIjulsu_3.Refresh();

            tbSilga_origin.Refresh();
            tbSilga_1.Refresh();
            tbSilga_2.Refresh();
            tbSilga_3.Refresh();

            tbSilse_origin.Refresh();
            tbSilse_1.Refresh();
            tbSilse_2.Refresh();
            tbSilse_3.Refresh();

            chkGubun1.Refresh();
            chkGubun2.Refresh();
        }

        private void bAdd_Click(object sender, EventArgs e)
        {
            string Query = "insert into " + DB_TableName_jul_sub + " (int_id) values('0')";
            var DBConn = new MySqlConnection(Config.DB_con1);
            DBConn.Open();
            var cmd = new MySqlCommand(Query, DBConn);

            cmd.ExecuteNonQuery();

            Query = "SELECT LAST_INSERT_ID() dd";
            cmd = new MySqlCommand(Query, DBConn);

            var myRead = cmd.ExecuteReader();
            string row_no = "";
            myRead.Read();
            row_no = myRead["dd"].ToString();
            GridNewLine(row_no);
            myRead.Close();
            DBConn.Close();
            

            var position = new SourceGrid.Position(grid1.Rows.Count - 1, 3);
            grid1.Selection.Focus(position, true);
        }

        private void GridNewLine(string row_no)
        {

            int Rows = grid1.RowsCount;
            cell_d cc = new cell_d();

            grid1.Rows.Insert(Rows);
            grid1.Rows[Rows].Height = 22;

            grid1[Rows, 0] = new SourceGrid.Cells.Cell(row_no, typeof(string));
            grid1[Rows, 1] = new SourceGrid.Cells.CheckBox(null, false);

            grid1[Rows, 2] = new SourceGrid.Cells.Cell((Rows-1).ToString(), typeof(string));
            grid1[Rows, 2].View = cc.center_cell;

            grid1[Rows, 3] = new SourceGrid.Cells.Cell("", typeof(string));
            grid1[Rows, 3].View = cc.center_cell;

            grid1[Rows, 4] = new SourceGrid.Cells.Cell("0", typeof(string));
            grid1[Rows, 4].View = cc.center_cell;

            grid1[Rows, 5] = new SourceGrid.Cells.Cell("", typeof(string));
            grid1[Rows, 5].View = cc.center_cell;
            grid1[Rows, 5].Editor = cc.disable_cell;

            grid1[Rows, 6] = new SourceGrid.Cells.Cell("", typeof(string));
            grid1[Rows, 6].View = cc.center_cell;
            grid1[Rows, 6].Editor = cc.disable_cell;

            grid1[Rows, 7] = new SourceGrid.Cells.Cell("", typeof(string));
            grid1[Rows, 7].View = cc.center_cell;
            grid1[Rows, 7].Editor = cc.disable_cell;

            grid1[Rows, 8] = new SourceGrid.Cells.Cell("", typeof(string));
            grid1[Rows, 8].View = cc.center_cell;
            grid1[Rows, 8].Editor = cc.disable_cell;

            grid1[Rows, 9] = new SourceGrid.Cells.Cell("", typeof(string));
            grid1[Rows, 9].View = cc.center_cell;
            grid1[Rows, 9].Editor = cc.disable_cell;

            grid1[Rows, 10] = new SourceGrid.Cells.Cell("", typeof(string));
            grid1[Rows, 10].View = cc.center_cell;
            grid1[Rows, 10].Editor = cc.disable_cell;

            grid1[Rows, 11] = new SourceGrid.Cells.Cell("", typeof(string));
            grid1[Rows, 11].View = cc.center_cell;
            grid1[Rows, 11].Editor = cc.disable_cell;

            grid1[Rows, 12] = new SourceGrid.Cells.Cell("", typeof(string));
            grid1[Rows, 12].View = cc.center_cellr;
            grid1[Rows, 12].Editor = cbJebon;

            grid1[Rows, 13] = new SourceGrid.Cells.Cell(0, typeof(int));
            grid1[Rows, 13].View = cc.int_cellr;
            grid1[Rows, 13].Editor = cc.int_editor;

            grid1[Rows, 14] = new SourceGrid.Cells.Cell("", typeof(string));
            grid1[Rows, 14].View = cc.center_cellr;

            grid1[Rows, 15] = new SourceGrid.Cells.Cell("", typeof(string));
            grid1[Rows, 15].View = cc.center_cellr;
            grid1[Rows, 15].Editor = cbKook;

            grid1[Rows, 16] = new SourceGrid.Cells.Cell("", typeof(string));
            grid1[Rows, 16].View = cc.center_cellr;
            grid1[Rows, 16].Editor = cbLefttop;

            grid1[Rows, 17] = new SourceGrid.Cells.Cell(0, typeof(int));
            grid1[Rows, 17].View = cc.int_cellr;
            grid1[Rows, 17].Editor = cc.int_editor;

            grid1[Rows, 18] = new SourceGrid.Cells.Cell(0, typeof(int));
            grid1[Rows, 18].View = cc.int_cellr;
            grid1[Rows, 18].Editor = cc.int_editor;

            grid1[Rows, 19] = new SourceGrid.Cells.Cell(0, typeof(int));
            grid1[Rows, 19].View = cc.int_cellr;
            grid1[Rows, 19].Editor = cc.int_editor;

            grid1[Rows, 20] = new SourceGrid.Cells.Cell(0, typeof(int));
            grid1[Rows, 20].View = cc.int_cellr;
            grid1[Rows, 20].Editor = cc.int_editor;

            grid1[Rows, 21] = new SourceGrid.Cells.Cell("", typeof(string));
            grid1[Rows, 21].View = cc.center_cellr;

            grid1[Rows, 22] = new SourceGrid.Cells.Cell("", typeof(string));
            grid1[Rows, 22].View = cc.center_cellr;

            grid1[Rows, 23] = new SourceGrid.Cells.Cell("", typeof(string));
            grid1[Rows, 23].View = cc.center_cellr;

            grid1[Rows, 24] = new SourceGrid.Cells.Cell("", typeof(string));
            grid1[Rows, 24].View = cc.center_cellr;

            grid1[Rows, 25] = new SourceGrid.Cells.Cell("", typeof(string));
            grid1[Rows, 25].View = cc.center_cellr;

            grid1[Rows, 26] = new SourceGrid.Cells.Cell("", typeof(string));
            grid1[Rows, 26].View = cc.center_cellr;
            grid1[Rows, 26].Editor = cbKook;

            grid1[Rows, 27] = new SourceGrid.Cells.Cell("", typeof(string));
            grid1[Rows, 27].View = cc.center_cellr;
            grid1[Rows, 27].Editor = cbLefttop;

            grid1[Rows, 28] = new SourceGrid.Cells.Cell(0, typeof(int));
            grid1[Rows, 28].View = cc.int_cellr;
            grid1[Rows, 28].Editor = cc.int_editor;

            grid1[Rows, 29] = new SourceGrid.Cells.Cell(0, typeof(int));
            grid1[Rows, 29].View = cc.int_cellr;
            grid1[Rows, 29].Editor = cc.int_editor;

            grid1[Rows, 30] = new SourceGrid.Cells.Cell(0, typeof(int));
            grid1[Rows, 30].View = cc.int_cellr;
            grid1[Rows, 30].Editor = cc.int_editor;

            grid1[Rows, 31] = new SourceGrid.Cells.Cell(0, typeof(int));
            grid1[Rows, 31].View = cc.int_cellr;
            grid1[Rows, 31].Editor = cc.int_editor;

            grid1[Rows, 32] = new SourceGrid.Cells.Cell("", typeof(string));
            grid1[Rows, 32].View = cc.center_cellr;

            grid1[Rows, 33] = new SourceGrid.Cells.Cell("", typeof(string));
            grid1[Rows, 33].View = cc.int_cellr;
            grid1[Rows, 33].Editor = cc.int_editor;

            grid1[Rows, 34] = new SourceGrid.Cells.Cell("", typeof(string));
            grid1[Rows, 34].View = cc.center_cellr;

            grid1[Rows, 35] = new SourceGrid.Cells.Cell("", typeof(string));
            grid1[Rows, 35].View = cc.center_cellr;

            grid1[Rows, 36] = new SourceGrid.Cells.Cell("", typeof(string));
            grid1[Rows, 36].View = cc.center_cellr;

            grid1[Rows, 37] = new SourceGrid.Cells.Cell("", typeof(string));
            grid1[Rows, 37].View = cc.center_cellr;

            grid1[Rows, 38] = new SourceGrid.Cells.Cell("", typeof(string));
            grid1[Rows, 38].View = cc.center_cellr;
            grid1[Rows, 38].Editor = cbKook;

            grid1[Rows, 39] = new SourceGrid.Cells.Cell("", typeof(string));
            grid1[Rows, 39].View = cc.center_cellr;
            grid1[Rows, 39].Editor = cbLefttop;

            grid1[Rows, 40] = new SourceGrid.Cells.Cell(0, typeof(int));
            grid1[Rows, 40].View = cc.int_cellr;
            grid1[Rows, 40].Editor = cc.int_editor;

            grid1[Rows, 41] = new SourceGrid.Cells.Cell(0, typeof(int));
            grid1[Rows, 41].View = cc.int_cellr;
            grid1[Rows, 41].Editor = cc.int_editor;

            grid1[Rows, 42] = new SourceGrid.Cells.Cell(0, typeof(int));
            grid1[Rows, 42].View = cc.int_cellr;
            grid1[Rows, 42].Editor = cc.int_editor;

            grid1[Rows, 43] = new SourceGrid.Cells.Cell(0, typeof(int));
            grid1[Rows, 43].View = cc.int_cellr;
            grid1[Rows, 43].Editor = cc.int_editor;

            grid1[Rows, 44] = new SourceGrid.Cells.Cell("", typeof(string));
            grid1[Rows, 44].View = cc.center_cellr;

            grid1[Rows, 45] = new SourceGrid.Cells.Cell("", typeof(string));
            grid1[Rows, 45].View = cc.int_cellr;
            grid1[Rows, 45].Editor = cc.int_editor;

            grid1[Rows, 46] = new SourceGrid.Cells.Cell("", typeof(string));
            grid1[Rows, 46].View = cc.center_cellr;

            grid1[Rows, 47] = new SourceGrid.Cells.Cell("", typeof(string));
            grid1[Rows, 47].View = cc.center_cellr;

            grid1[Rows, 48] = new SourceGrid.Cells.Cell("", typeof(string));
            grid1[Rows, 48].View = cc.center_cellr;

  
        }

        void GridNewLine_copy(string Query)
        {

            MySqlConnection DBConn;
            DBConn = new MySqlConnection(Config.DB_con1);
            DBConn.Open();

            var cmd = new MySqlCommand(Query, DBConn);
            var myRead = cmd.ExecuteReader();

            int m = grid1.RowsCount;
            cell_d cc = new cell_d();
            
            while (myRead.Read())
            {
                grid1.Rows.Insert(m);
                grid1.Rows[m].Height = 22;

                grid1[m, 0] = new SourceGrid.Cells.Cell(myRead["row_id"], typeof(string));
                grid1[m, 1] = new SourceGrid.Cells.CheckBox(null, false);

                grid1[m, 2] = new SourceGrid.Cells.Cell((m - 1).ToString(), typeof(string));
                grid1[m, 2].View = cc.center_cell;

                grid1[m, 3] = new SourceGrid.Cells.Cell(myRead["gubun"], typeof(string));
                grid1[m, 3].View = cc.center_cellr;

                grid1[m, 4] = new SourceGrid.Cells.Cell(myRead["int_id"], typeof(string));
                grid1[m, 4].View = cc.center_cell;

                grid1[m, 5] = new SourceGrid.Cells.Cell(myRead["a"], typeof(string));
                grid1[m, 5].View = cc.center_cell;
                grid1[m, 5].Editor = cc.disable_cell;

                grid1[m, 6] = new SourceGrid.Cells.Cell(myRead["b"], typeof(string));
                grid1[m, 6].View = cc.center_cell;
                grid1[m, 6].Editor = cc.disable_cell;

                grid1[m, 7] = new SourceGrid.Cells.Cell(myRead["c"], typeof(string));
                grid1[m, 7].View = cc.center_cell;
                grid1[m, 7].Editor = cc.disable_cell;

                grid1[m, 8] = new SourceGrid.Cells.Cell(myRead["d"], typeof(string));
                grid1[m, 8].View = cc.center_cell;
                grid1[m, 8].Editor = cc.disable_cell;

                grid1[m, 9] = new SourceGrid.Cells.Cell(myRead["e"], typeof(string));
                grid1[m, 9].View = cc.center_cell;
                grid1[m, 9].Editor = cc.disable_cell;

                grid1[m, 10] = new SourceGrid.Cells.Cell(myRead["f"], typeof(string));
                grid1[m, 10].View = cc.center_cell;
                grid1[m, 10].Editor = cc.disable_cell;

                grid1[m, 11] = new SourceGrid.Cells.Cell(myRead["j"], typeof(string));
                grid1[m, 11].View = cc.center_cell;
                grid1[m, 11].Editor = cc.disable_cell;

                grid1[m, 12] = new SourceGrid.Cells.Cell(myRead["yuhyung"], typeof(string));
                grid1[m, 12].View = cc.center_cellr;
                grid1[m, 12].Editor = cbJebon;

                grid1[m, 13] = new SourceGrid.Cells.Cell(myRead["page"], typeof(int));
                grid1[m, 13].View = cc.int_cellr;
                grid1[m, 13].Editor = cc.int_editor;

                grid1[m, 14] = new SourceGrid.Cells.Cell(myRead["function_no_1"], typeof(string));
                grid1[m, 14].View = cc.center_cellr;

                grid1[m, 15] = new SourceGrid.Cells.Cell(myRead["kook_1"], typeof(string));
                grid1[m, 15].View = cc.center_cellr;
                grid1[m, 15].Editor = cbKook;

                grid1[m, 16] = new SourceGrid.Cells.Cell(myRead["lefttop_1"], typeof(string));
                grid1[m, 16].View = cc.center_cellr;
                grid1[m, 16].Editor = cbLefttop;

                grid1[m, 17] = new SourceGrid.Cells.Cell(myRead["c_jul_1"], typeof(int));
                grid1[m, 17].View = cc.int_cellr;
                grid1[m, 17].Editor = cc.int_editor;

                grid1[m, 18] = new SourceGrid.Cells.Cell(myRead["i_jul_1"], typeof(int));
                grid1[m, 18].View = cc.int_cellr;
                grid1[m, 18].Editor = cc.int_editor;

                grid1[m, 19] = new SourceGrid.Cells.Cell(myRead["silga_1"], typeof(int));
                grid1[m, 19].View = cc.int_cellr;
                grid1[m, 19].Editor = cc.int_editor;

                grid1[m, 20] = new SourceGrid.Cells.Cell(myRead["silse_1"], typeof(int));
                grid1[m, 20].View = cc.int_cellr;
                grid1[m, 20].Editor = cc.int_editor;

                grid1[m, 21] = new SourceGrid.Cells.Cell(myRead["pan_1"], typeof(string));
                grid1[m, 21].View = cc.center_cellr;

                grid1[m, 22] = new SourceGrid.Cells.Cell(myRead["jubji_a_1"], typeof(string));
                grid1[m, 22].View = cc.center_cellr;

                grid1[m, 23] = new SourceGrid.Cells.Cell(myRead["jubji_b_1"], typeof(string));
                grid1[m, 23].View = cc.center_cellr;

                grid1[m, 24] = new SourceGrid.Cells.Cell(myRead["prn_way_1"], typeof(string));
                grid1[m, 24].View = cc.center_cellr;

                grid1[m, 25] = new SourceGrid.Cells.Cell(myRead["function_no_2"], typeof(string));
                grid1[m, 25].View = cc.center_cellr;

                grid1[m, 26] = new SourceGrid.Cells.Cell(myRead["kook_2"], typeof(string));
                grid1[m, 26].View = cc.center_cellr;
                grid1[m, 26].Editor = cbKook;

                grid1[m, 27] = new SourceGrid.Cells.Cell(myRead["lefttop_2"], typeof(string));
                grid1[m, 27].View = cc.center_cellr;
                grid1[m, 27].Editor = cbLefttop;

                grid1[m, 28] = new SourceGrid.Cells.Cell(myRead["c_jul_2"], typeof(int));
                grid1[m, 28].View = cc.int_cellr;
                grid1[m, 28].Editor = cc.int_editor;

                grid1[m, 29] = new SourceGrid.Cells.Cell(myRead["i_jul_2"], typeof(int));
                grid1[m, 29].View = cc.int_cellr;
                grid1[m, 29].Editor = cc.int_editor;

                grid1[m, 30] = new SourceGrid.Cells.Cell(myRead["silga_2"], typeof(int));
                grid1[m, 30].View = cc.int_cellr;
                grid1[m, 30].Editor = cc.int_editor;

                grid1[m, 31] = new SourceGrid.Cells.Cell(myRead["silse_2"], typeof(int));
                grid1[m, 31].View = cc.int_cellr;
                grid1[m, 31].Editor = cc.int_editor;

                grid1[m, 32] = new SourceGrid.Cells.Cell(myRead["pan_2"], typeof(string));
                grid1[m, 32].View = cc.center_cellr;

                grid1[m, 33] = new SourceGrid.Cells.Cell(myRead["add_pg_2"], typeof(string));
                grid1[m, 33].View = cc.int_cellr;
                grid1[m, 33].Editor = cc.int_editor;

                grid1[m, 34] = new SourceGrid.Cells.Cell(myRead["jubji_a_2"], typeof(string));
                grid1[m, 34].View = cc.center_cellr;

                grid1[m, 35] = new SourceGrid.Cells.Cell(myRead["jubji_b_2"], typeof(string));
                grid1[m, 35].View = cc.center_cellr;

                grid1[m, 36] = new SourceGrid.Cells.Cell(myRead["prn_way_2"], typeof(string));
                grid1[m, 36].View = cc.center_cellr;

                grid1[m, 37] = new SourceGrid.Cells.Cell(myRead["function_no_3"], typeof(string));
                grid1[m, 37].View = cc.center_cellr;

                grid1[m, 38] = new SourceGrid.Cells.Cell(myRead["kook_3"], typeof(string));
                grid1[m, 38].View = cc.center_cellr;
                grid1[m, 38].Editor = cbKook;

                grid1[m, 39] = new SourceGrid.Cells.Cell(myRead["lefttop_3"], typeof(string));
                grid1[m, 39].View = cc.center_cellr;
                grid1[m, 39].Editor = cbLefttop;

                grid1[m, 40] = new SourceGrid.Cells.Cell(myRead["c_jul_3"], typeof(int));
                grid1[m, 40].View = cc.int_cellr;
                grid1[m, 40].Editor = cc.int_editor;

                grid1[m, 41] = new SourceGrid.Cells.Cell(myRead["i_jul_3"], typeof(int));
                grid1[m, 41].View = cc.int_cellr;
                grid1[m, 41].Editor = cc.int_editor;

                grid1[m, 42] = new SourceGrid.Cells.Cell(myRead["silga_3"], typeof(int));
                grid1[m, 42].View = cc.int_cellr;
                grid1[m, 42].Editor = cc.int_editor;

                grid1[m, 43] = new SourceGrid.Cells.Cell(myRead["silse_3"], typeof(int));
                grid1[m, 43].View = cc.int_cellr;
                grid1[m, 43].Editor = cc.int_editor;

                grid1[m, 44] = new SourceGrid.Cells.Cell(myRead["pan_3"], typeof(string));
                grid1[m, 44].View = cc.center_cellr;

                grid1[m, 45] = new SourceGrid.Cells.Cell(myRead["add_pg_3"], typeof(string));
                grid1[m, 45].View = cc.int_cellr;
                grid1[m, 45].Editor = cc.int_editor;

                grid1[m, 46] = new SourceGrid.Cells.Cell(myRead["jubji_a_3"], typeof(string));
                grid1[m, 46].View = cc.center_cellr;

                grid1[m, 47] = new SourceGrid.Cells.Cell(myRead["jubji_b_3"], typeof(string));
                grid1[m, 47].View = cc.center_cellr;

                grid1[m, 48] = new SourceGrid.Cells.Cell(myRead["prn_way_3"], typeof(string));
                grid1[m, 48].View = cc.center_cellr;

                m++;
            }

            myRead.Close();
            DBConn.Close();
        }

        private void bCopy_Click(object sender, EventArgs e)
        {
            string[] rows = new string[grid1.Rows.Count];
            string[] copy_row_id = new string[grid1.Rows.Count];
            rows = GridHandle.GetChkRowid(2, 1, 0);
            string Query = "";
            string Query_sub = " where a.row_id <0 ";

            for (int i = 0; i < rows.Length; i++)
            {
                if (rows[i] == "0")
                    break;
                Query_sub += " or a.row_id ='" +GridHandle.OneDataCopy(DB_TableName_jul_sub, rows[i])+"'";
                
            }
            Query = "select a.*, b.a, b.b, b.c, b.d, b.e, b.f, b.j from " + DB_TableName_jul_sub + " a left outer join " + DB_TableName_jul + " b on a.int_id = b.row_id";
            Query += Query_sub + " order by row_id";
            GridNewLine_copy(Query);
        }

        private void bDelete_Click(object sender, EventArgs e)
        {
            GridHandle.ChkDataDelete(DB_TableName_jul_sub, 2, 0, 1);
        }

        private void bSearch_Click(object sender, EventArgs e)
        {
            string s1, s2, s3, s4, s5, s6, s7, s8, s9, s10, s11, s12, s13, s14, s15, s16, s17, s18, s19, s20, s21, s22, s23, s24, s25, s26, s27 = "";
            string c1, c2, c3, c4, c5, c6, c7, c8, c9, c10, c11, c12, c13, c14, c15, c16, c17, c18, c19, c20, c21, c22, c23, c24, c25, c26, c27 = "";

            if (cbKook_origin.Text !="" )
            {
                c1 = cbKook_origin.Text.Trim();
                s1 = " and b.a ='" + c1 + "'";
            }
            else
                s1 = "";

            if (cbLefttop_origin.Text !="")
            {
                c2 = cbLefttop_origin.Text.Trim();
                s2 = " and b.b ='" + c2 + "'";
            }
            else
                s2 = "";

            if (tbCjulsu_origin.Text != "")
            {
                c3 = tbCjulsu_origin.Text.Trim();
                s3 = " and b.c ='" + c3 + "'";
            }
            else
                s3 = "";

            if (tbIjulsu_origin.Text != "")
            {
                c4 = tbIjulsu_origin.Text.Trim();
                s4 = " and b.d ='" + c4 + "'";
            }
            else
                s4 = "";

            if (tbSilga_origin.Text != "")
            {
                c5 = tbSilga_origin.Text.Trim();
                s5 = " and b.e ='" + c5 + "'";
            }
            else
                s5 = "";

            if (tbSilse_origin.Text != "")
            {
                c6 = tbSilse_origin.Text.Trim();
                s6 = " and b.f ='" + c6 + "'";
            }
            else
                s6 = "";

            if (tbPage.Text != "")
            {
                c7 = tbPage.Text.Trim();
                s7 = " and a.page ='" + c7 + "'";
            }
            else
                s7 = "";

            if (cbYuhyung.Text != "")
            {
                c8 = cbYuhyung.Text.Trim();
                s8 = " and a.yuhyung ='" + c8 + "'";
            }
            else
                s8 = "";


            if (cbKook_1.Text != "")
            {
                c9 = cbKook_1.Text.Trim();
                s9 = " and a.kook_1 ='" + c9 + "'";
            }
            else
                s9 = "";

            if (cbLefttop_1.Text != "")
            {
                c10 = cbLefttop_1.Text.Trim();
                s10 = " and a.lefttop_1 ='" + c10 + "'";
            }
            else
                s10 = "";

            if (tbCjulsu_1.Text != "")
            {
                c11 = tbCjulsu_1.Text.Trim();
                s11 = " and a.c_jul_1 ='" + c11 + "'";
            }
            else
                s11 = "";

            if (tbIjulsu_1.Text != "")
            {
                c12 = tbIjulsu_1.Text.Trim();
                s12 = " and a.i_jul_1 ='" + c12 + "'";
            }
            else
                s12 = "";

            if (tbSilga_1.Text != "")
            {
                c13 = tbSilga_1.Text.Trim();
                s13 = " and a.silga_1 ='" + c13 + "'";
            }
            else
                s13 = "";

            if (tbSilse_1.Text != "")
            {
                c14 = tbSilse_1.Text.Trim();
                s14 = " and a.silse_1 ='" + c14 + "'";
            }
            else
                s14 = "";

            if (cbKook_2.Text != "")
            {
                c15 = cbKook_2.Text.Trim();
                s15 = " and a.kook_2 ='" + c15 + "'";
            }
            else
                s15 = "";

            if (cbLefttop_2.Text != "")
            {
                c16= cbLefttop_2.Text.Trim();
                s16 = " and a.lefttop_2 ='" + c16 + "'";
            }
            else
                s16 = "";

            if (tbCjulsu_2.Text != "")
            {
                c17 = tbCjulsu_2.Text.Trim();
                s17 = " and a.c_jul_2 ='" + c17 + "'";
            }
            else
                s17 = "";

            if (tbIjulsu_2.Text != "")
            {
                c18 = tbIjulsu_2.Text.Trim();
                s18 = " and a.i_jul_2 ='" + c18 + "'";
            }
            else
                s18 = "";

            if (tbSilga_2.Text != "")
            {
                c19 = tbSilga_2.Text.Trim();
                s19 = " and a.silga_2 ='" + c19 + "'";
            }
            else
                s19 = "";

            if (tbSilse_2.Text != "")
            {
                c20 = tbSilse_2.Text.Trim();
                s20 = " and a.silse_2 ='" + c20 + "'";
            }
            else
                s20 = "";

            if (cbKook_3.Text != "")
            {
                c21 = cbKook_3.Text.Trim();
                s21 = " and a.kook_3 ='" + c21 + "'";
            }
            else
                s21 = "";

            if (cbLefttop_3.Text != "")
            {
                c22 = cbLefttop_3.Text.Trim();
                s22 = " and a.lefttop_3 ='" + c22 + "'";
            }
            else
                s22 = "";

            if (tbCjulsu_3.Text != "")
            {
                c23 = tbCjulsu_3.Text.Trim();
                s23 = " and a.c_jul_3 ='" + c23 + "'";
            }
            else
                s23 = "";

            if (tbIjulsu_3.Text != "")
            {
                c24 = tbIjulsu_3.Text.Trim();
                s24 = " and a.i_jul_3 ='" + c24 + "'";
            }
            else
                s24 = "";

            if (tbSilga_3.Text != "")
            {
                c25 = tbSilga_3.Text.Trim();
                s25 = " and a.silga_3 ='" + c25 + "'";
            }
            else
                s25 = "";

            if (tbSilse_3.Text != "")
            {
                c26 = tbSilse_3.Text.Trim();
                s26 = " and a.silse_3 ='" + c26 + "'";
            }
            else
                s26 = "";
            
            if (chkGubun1.Checked == true)
                s27 += " or a.gubun = '1'";
            if (chkGubun2.Checked == true)
                s27 += " or a.gubun = '2'";
            if (chkGubunA.Checked == true)
                s27 += " or a.gubun = 'A'";
            if (chkGubunB.Checked == true)
                s27 += " or a.gubun = 'B'";
            if (chkGubunC.Checked == true)
                s27 += " or a.gubun = 'C'";
            if (chkGubunD.Checked == true)
                s27 += " or a.gubun = 'D'";
            if (chkGubunE.Checked == true)
                s27 += " or a.gubun = 'E'";
            if (chkGubunF.Checked == true)
                s27 += " or a.gubun = 'F'";
            if (chkGubunG.Checked == true)
                s27 += " or a.gubun = 'G'";
            if(s27 != "")
                s27 = "and " + s27.Substring(3);
            if (chkGubun1.Checked == true && chkGubun2.Checked == true && chkGubunA.Checked == true && chkGubunB.Checked == true && chkGubunC.Checked == true && chkGubunD.Checked == true && chkGubunE.Checked == true && chkGubunF.Checked == true && chkGubunG.Checked == true)
                s27 = "";
            if (chkGubun1.Checked == false && chkGubun2.Checked == false && chkGubunA.Checked == false && chkGubunB.Checked == false && chkGubunC.Checked == false && chkGubunD.Checked == false && chkGubunE.Checked == false && chkGubunF.Checked == false && chkGubunG.Checked == false)
                s27 = " and ( a.gubun is null or a.gubun = '')";

            
            string Query = "select a.*, b.a, b.b, b.c, b.d, b.e, b.f, b.j from " + DB_TableName_jul_sub + " a left outer join " + DB_TableName_jul + " b on a.int_id = b.row_id where a.row_id is not null ";
            Query += s1 + s2 + s3 + s4 + s5 + s6 + s7 + s8 + s9 + s10 + s11 + s12 + s13 + s14 + s15 + s16 + s17 + s18 + s19 + s20 + s21 + s22 + s23 + s24 + s25 + s26+s27+" order by a.row_id";
            
            GridView(Query);

            var position = new SourceGrid.Position(2, 1);
            GridHandle.grid.Selection.Focus(position, true);
        }

        private void insert_info(string row_no, string int_no, int row)
        {
            cell_d cc = new cell_d();
            MySqlConnection DBConn;
            DBConn = new MySqlConnection(Config.DB_con1);
            DBConn.Open();
            string Query = "select b.a, b.b, b.c, b.d, b.e, b.f, b.j from " + DB_TableName_jul_sub + " a left outer join " + DB_TableName_jul + " b on a.int_id = b.row_id";
            Query += " where a.row_id = " + row_no;
            Query += " order by a.row_id";
            var cmd = new MySqlCommand(Query, DBConn);
            var myRead = cmd.ExecuteReader();
            int m = row;
            if (myRead.Read())
            {
                grid1[m, 5] = new SourceGrid.Cells.Cell(myRead["a"], typeof(string));
                grid1[m, 5].View = cc.center_cell;
                grid1[m, 5].Editor = cc.disable_cell;

                grid1[m, 6] = new SourceGrid.Cells.Cell(myRead["b"], typeof(string));
                grid1[m, 6].View = cc.center_cell;
                grid1[m, 6].Editor = cc.disable_cell;

                grid1[m, 7] = new SourceGrid.Cells.Cell(myRead["c"], typeof(string));
                grid1[m, 7].View = cc.center_cell;
                grid1[m, 7].Editor = cc.disable_cell;

                grid1[m, 8] = new SourceGrid.Cells.Cell(myRead["d"], typeof(string));
                grid1[m, 8].View = cc.center_cell;
                grid1[m, 8].Editor = cc.disable_cell;

                grid1[m, 9] = new SourceGrid.Cells.Cell(myRead["e"], typeof(string));
                grid1[m, 9].View = cc.center_cell;
                grid1[m, 9].Editor = cc.disable_cell;

                grid1[m, 10] = new SourceGrid.Cells.Cell(myRead["f"], typeof(string));
                grid1[m, 10].View = cc.center_cell;
                grid1[m, 10].Editor = cc.disable_cell;

                grid1[m, 11] = new SourceGrid.Cells.Cell(myRead["j"], typeof(string));
                grid1[m, 11].View = cc.center_cell;
                grid1[m, 11].Editor = cc.disable_cell;
            }

            grid1.Refresh();
        }
        private void ValueChangedEvent1(object sender, EventArgs e)  //Grid1에서 볼륨첸지
        {
            string row_no = grid1[grid1.Selection.ActivePosition.Row, 0].ToString().Trim();
            int cpos = grid1.Selection.ActivePosition.Column;
            int rpos = grid1.Selection.ActivePosition.Row;
            string dat;
            if (cpos == 3 || cpos == 22 || cpos ==23 || cpos == 24 || cpos == 34 || cpos ==35 || cpos == 36 || cpos == 46 || cpos ==47 || cpos == 48)
                dat = grid1[grid1.Selection.ActivePosition.Row, grid1.Selection.ActivePosition.Column].ToString().Trim();
            else
                dat = grid1[grid1.Selection.ActivePosition.Row, grid1.Selection.ActivePosition.Column].ToString().Trim().Replace(",", "");

            string cQuery = "";
            //
            if (cpos.Equals(3))  //
                cQuery = " update " + DB_TableName_jul_sub + " set gubun='" + dat + "' where row_id='" + row_no + "'";
            else if (cpos.Equals(4))       //
                cQuery = " update " + DB_TableName_jul_sub + " set int_id='" + dat + "' where row_id='" + row_no + "'";
            else if (cpos.Equals(12))       //
                cQuery = " update " + DB_TableName_jul_sub + " set yuhyung='" + dat + "' where row_id='" + row_no + "'";
            else if (cpos.Equals(13))  //
                cQuery = " update " + DB_TableName_jul_sub + " set page='" + dat + "' where row_id='" + row_no + "'";
            else if (cpos.Equals(14))  //
                cQuery = " update " + DB_TableName_jul_sub + " set function_no_1='" + dat + "' where row_id='" + row_no + "'";
            else if (cpos.Equals(15))  //
                cQuery = " update " + DB_TableName_jul_sub + " set kook_1='" + dat + "' where row_id='" + row_no + "'";
            else if (cpos.Equals(16))  //
                cQuery = " update " + DB_TableName_jul_sub + " set lefttop_1='" + dat + "' where row_id='" + row_no + "'";
            else if (cpos.Equals(17))  //
                cQuery = " update " + DB_TableName_jul_sub + " set c_jul_1='" + dat + "' where row_id='" + row_no + "'";
            else if (cpos.Equals(18))  //
                cQuery = " update " + DB_TableName_jul_sub + " set i_jul_1='" + dat + "' where row_id='" + row_no + "'";
            else if (cpos.Equals(19))  //
                cQuery = " update " + DB_TableName_jul_sub + " set silga_1='" + dat + "' where row_id='" + row_no + "'";
            else if (cpos.Equals(20))  //
                cQuery = " update " + DB_TableName_jul_sub + " set silse_1='" + dat + "' where row_id='" + row_no + "'";
            else if (cpos.Equals(21))  //
                cQuery = " update " + DB_TableName_jul_sub + " set pan_1='" + dat + "' where row_id='" + row_no + "'";
            else if (cpos.Equals(22))  //
                cQuery = " update " + DB_TableName_jul_sub + " set jubji_a_1='" + dat + "' where row_id='" + row_no + "'";
            else if (cpos.Equals(23))  //
                cQuery = " update " + DB_TableName_jul_sub + " set jubji_b_1='" + dat + "' where row_id='" + row_no + "'";
            else if (cpos.Equals(24))  //
                cQuery = " update " + DB_TableName_jul_sub + " set prn_way_1='" + dat + "' where row_id='" + row_no + "'";
            else if (cpos.Equals(25))  //
                cQuery = " update " + DB_TableName_jul_sub + " set function_no_2='" + dat + "' where row_id='" + row_no + "'";
            else if (cpos.Equals(26))  //
                cQuery = " update " + DB_TableName_jul_sub + " set kook_2='" + dat + "' where row_id='" + row_no + "'";
            else if (cpos.Equals(27))  //
                cQuery = " update " + DB_TableName_jul_sub + " set lefttop_2='" + dat + "' where row_id='" + row_no + "'";
            else if (cpos.Equals(28))  //
                cQuery = " update " + DB_TableName_jul_sub + " set c_jul_2='" + dat + "' where row_id='" + row_no + "'";
            else if (cpos.Equals(29))  //
                cQuery = " update " + DB_TableName_jul_sub + " set i_jul_2='" + dat + "' where row_id='" + row_no + "'";
            else if (cpos.Equals(30))  //
                cQuery = " update " + DB_TableName_jul_sub + " set silga_2='" + dat + "' where row_id='" + row_no + "'";
            else if (cpos.Equals(31))  //
                cQuery = " update " + DB_TableName_jul_sub + " set silse_2='" + dat + "' where row_id='" + row_no + "'";
            else if (cpos.Equals(32))  //
                cQuery = " update " + DB_TableName_jul_sub + " set pan_2='" + dat + "' where row_id='" + row_no + "'";
            else if (cpos.Equals(33))  //
                cQuery = " update " + DB_TableName_jul_sub + " set add_pg_2='" + dat + "' where row_id='" + row_no + "'";
            else if (cpos.Equals(34))  //
                cQuery = " update " + DB_TableName_jul_sub + " set jubji_a_2='" + dat + "' where row_id='" + row_no + "'";
            else if (cpos.Equals(35))  //
                cQuery = " update " + DB_TableName_jul_sub + " set jubji_b_2='" + dat + "' where row_id='" + row_no + "'";
            else if (cpos.Equals(36))  //
                cQuery = " update " + DB_TableName_jul_sub + " set prn_way_2='" + dat + "' where row_id='" + row_no + "'";
            else if (cpos.Equals(37))  //
                cQuery = " update " + DB_TableName_jul_sub + " set function_no_3='" + dat + "' where row_id='" + row_no + "'";
            else if (cpos.Equals(38))  //
                cQuery = " update " + DB_TableName_jul_sub + " set kook_3='" + dat + "' where row_id='" + row_no + "'";
            else if (cpos.Equals(39))  //
                cQuery = " update " + DB_TableName_jul_sub + " set lefttop_3='" + dat + "' where row_id='" + row_no + "'";
            else if (cpos.Equals(40))  //
                cQuery = " update " + DB_TableName_jul_sub + " set c_jul_3='" + dat + "' where row_id='" + row_no + "'";
            else if (cpos.Equals(41))  //
                cQuery = " update " + DB_TableName_jul_sub + " set i_jul_3='" + dat + "' where row_id='" + row_no + "'";
            else if (cpos.Equals(42))  //
                cQuery = " update " + DB_TableName_jul_sub + " set silga_3='" + dat + "' where row_id='" + row_no + "'";
            else if (cpos.Equals(43))  //
                cQuery = " update " + DB_TableName_jul_sub + " set silse_3='" + dat + "' where row_id='" + row_no + "'";
            else if (cpos.Equals(44))  //
                cQuery = " update " + DB_TableName_jul_sub + " set pan_3='" + dat + "' where row_id='" + row_no + "'";
            else if (cpos.Equals(45))  //
                cQuery = " update " + DB_TableName_jul_sub + " set add_pg_3='" + dat + "' where row_id='" + row_no + "'";
            else if (cpos.Equals(46))  //
                cQuery = " update " + DB_TableName_jul_sub + " set jubji_a_3='" + dat + "' where row_id='" + row_no + "'";
            else if (cpos.Equals(47))  //
                cQuery = " update " + DB_TableName_jul_sub + " set jubji_b_3='" + dat + "' where row_id='" + row_no + "'";
            else if (cpos.Equals(48))  //
                cQuery = " update " + DB_TableName_jul_sub + " set prn_way_3='" + dat + "' where row_id='" + row_no + "'";

            if (!cQuery.Equals(""))
            {
                GridHandle.DataUpdate(cQuery);

                if (cpos.Equals(4))
                    insert_info(row_no, dat, rpos);
            }

        }

        private void Form_2013_ClientSizeChanged(object sender, EventArgs e)
        {
            this.grid1.Size = new System.Drawing.Size(this.Size.Width-44, this.Height-195);
        }

        private void bData2Excel_Click(object sender, EventArgs e)
        {
            Excel_convert Ec = new Excel_convert(grid1, "", "");
            Ec.Convert();
        }

        private void bCheck_Click(object sender, EventArgs e)
        {
            if (grid1[2, 1].Value.Equals(true))
            {
                for (int i = 2; i < grid1.Rows.Count; i++)
                { 
                    grid1[i, 1] = new SourceGrid.Cells.CheckBox(null, false);
                }
            }
            else
            {
                for (int i = 2; i < grid1.Rows.Count; i++)
                {
                    grid1[i, 1] = new SourceGrid.Cells.CheckBox(null, true);
                }
            }

            grid1.Refresh();
        }
    }

}
