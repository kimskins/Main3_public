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
    public partial class Form_2122 : Form
    {
        string DB_TableName_extra = "C_paper_extra_g";
        string ab_code = "";

        SourceGridControl GridHandle = new SourceGridControl();


        public Form_2122(string ab_code)
        {
            InitializeComponent();
            this.ab_code = ab_code;
        }

        private void Form_2112_Load(object sender, EventArgs e)
        {
            Screen srn = Screen.PrimaryScreen;
            int Xb = this.Width;  //좌,우
            int Yb = this.Height; //좌,우
            this.Location = new Point((srn.Bounds.Width - Xb) / 2, (srn.Bounds.Height - Yb) / 2 - 100);  //좌/우,위/아래

            GridHandle.SourceGrideInit(grid1, Config.DB_con1);

            SourceGrid.Cells.Controllers.CustomEvents val_c1 = new SourceGrid.Cells.Controllers.CustomEvents();
            val_c1.ValueChanged += new EventHandler(ValueChangedEvent1);
            grid1.Controller.AddController(val_c1);

            if (ab_code == "0802")
                label1.Visible = true;

            bRefresh_Click(null, null);
        }

        private void GridView(string Query)
        {
            cell_d cc = new cell_d();
            grid1.Rows.Clear();
            grid1.BorderStyle = BorderStyle.FixedSingle;
            grid1.SelectionMode = SourceGrid.GridSelectionMode.Cell;
            grid1.ColumnsCount = 19;
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

            grid1[0, 2] = new MyHeader1("No");
            grid1[0, 2].RowSpan = 2;

            grid1[0, 3] = new MyHeader1("인쇄정매 수량범위");
            grid1[0, 3].ColumnSpan = 2;
            grid1[1, 3] = new MyHeader1("최소");
            grid1[1, 4] = new MyHeader1("최대");

            grid1[0, 5] = new MyHeader1("인쇄여분통수");
            grid1[0, 5].ColumnSpan = 2;
            grid1[1, 5] = new MyHeader1("기본비율");
            grid1[1, 6] = new MyHeader1("기본통수");

            grid1[0, 7] = new MyHeader1("후공정 1포함");
            grid1[0, 7].ColumnSpan = 8;
            grid1[1, 7] = new MyHeader1("8도 이상");
            grid1[1, 8] = new MyHeader1("7도비율");
            grid1[1, 9] = new MyHeader1("6도비율");
            grid1[1, 10] = new MyHeader1("5도비율");
            grid1[1, 11] = new MyHeader1("4도/ 3도");
            grid1[1, 12] = new MyHeader1("2도비율");
            grid1[1, 13] = new MyHeader1("1도비율");
            grid1[1, 14] = new MyHeader1("0도비율");

            grid1[0, 15] = new MyHeader1("인쇄에 따른 여분 증감");
            grid1[0, 15].ColumnSpan = 3;
            grid1[1, 15] = new MyHeader1("감리통수");
            grid1[1, 16] = new MyHeader1("CIP 수량");
            grid1[1, 17] = new MyHeader1("고급인쇄");

            grid1[0, 18] = new MyHeader1("디지털" + "\r\n" + "윤전구분");
            grid1[0, 18].RowSpan = 2;

            if (ab_code != "0802")
                grid1.Columns[18].Visible = false;

            grid1.Columns[1].Width = 22;
            grid1.Columns[2].Width = 50;
            grid1.Columns[3].Width = 70;
            grid1.Columns[4].Width = 70;
            grid1.Columns[5].Width = 70;
            grid1.Columns[6].Width = 70;
            grid1.Columns[7].Width = 70;
            grid1.Columns[8].Width = 70;
            grid1.Columns[9].Width = 70;
            grid1.Columns[10].Width = 70;
            grid1.Columns[11].Width = 70;
            grid1.Columns[12].Width = 70;
            grid1.Columns[13].Width = 70;
            grid1.Columns[14].Width = 70;
            grid1.Columns[15].Width = 70;
            grid1.Columns[16].Width = 70;
            grid1.Columns[17].Width = 70;
            grid1.Columns[18].Width = 60;

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

                grid1[m, 3] = new SourceGrid.Cells.Cell(myRead["volume_range_min"], typeof(int));
                grid1[m, 3].View = cc.int_cellr;
                grid1[m, 3].Editor = cc.int_editor;

                grid1[m, 4] = new SourceGrid.Cells.Cell(myRead["volume_range_max"], typeof(int));
                grid1[m, 4].View = cc.int_cellr;
                grid1[m, 4].Editor = cc.int_editor;

                grid1[m, 5] = new SourceGrid.Cells.Cell(myRead["default_ratio"], typeof(decimal));
                grid1[m, 5].View = cc.int_cellr;

                grid1[m, 6] = new SourceGrid.Cells.Cell(myRead["default_tong"], typeof(int));
                grid1[m, 6].View = cc.int_cellr;
                grid1[m, 6].Editor = cc.int_editor;

                grid1[m, 7] = new SourceGrid.Cells.Cell(myRead["dosu_8"], typeof(decimal));
                grid1[m, 7].View = cc.int_cellr;

                grid1[m, 8] = new SourceGrid.Cells.Cell(myRead["dosu_7"], typeof(decimal));
                grid1[m, 8].View = cc.int_cellr;

                grid1[m, 9] = new SourceGrid.Cells.Cell(myRead["dosu_6"], typeof(decimal));
                grid1[m, 9].View = cc.int_cellr;

                grid1[m, 10] = new SourceGrid.Cells.Cell(myRead["dosu_5"], typeof(decimal));
                grid1[m, 10].View = cc.int_cellr;

                grid1[m, 11] = new SourceGrid.Cells.Cell(myRead["dosu_4"], typeof(decimal));
                grid1[m, 11].View = cc.int_cellr;

                grid1[m, 12] = new SourceGrid.Cells.Cell(myRead["dosu_2"], typeof(decimal));
                grid1[m, 12].View = cc.int_cellr;

                grid1[m, 13] = new SourceGrid.Cells.Cell(myRead["dosu_1"], typeof(decimal));
                grid1[m, 13].View = cc.int_cellr;

                grid1[m, 14] = new SourceGrid.Cells.Cell(myRead["dosu_0"], typeof(decimal));
                grid1[m, 14].View = cc.int_cellr;

                grid1[m, 15] = new SourceGrid.Cells.Cell(myRead["gamri_tong"], typeof(int));
                grid1[m, 15].View = cc.int_cellr;
                grid1[m, 15].Editor = cc.int_editor;

                grid1[m, 16] = new SourceGrid.Cells.Cell(myRead["cip_su"], typeof(int));
                grid1[m, 16].View = cc.int_cellr;
                grid1[m, 16].Editor = cc.int_editor;

                grid1[m, 17] = new SourceGrid.Cells.Cell(myRead["hi_quality"], typeof(int));
                grid1[m, 17].View = cc.int_cellr;
                grid1[m, 17].Editor = cc.int_editor;

                grid1[m, 18] = new SourceGrid.Cells.Cell(myRead["guboon_id"], typeof(int));
                grid1[m, 18].View = cc.center_cellr;
                
                m++;
            }
            myRead.Close();
            DBConn.Close();

        }

        private void bAdd_Click(object sender, EventArgs e)
        {
            string Query = "insert into " + DB_TableName_extra + " (ab_code) values('"+ab_code+"')";
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
            DBConn.Close();
            myRead.Close();

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

            grid1[Rows, 2] = new SourceGrid.Cells.Cell((Rows - 1).ToString(), typeof(string));
            grid1[Rows, 2].View = cc.center_cell;

            grid1[Rows, 3] = new SourceGrid.Cells.Cell(0, typeof(int));
            grid1[Rows, 3].View = cc.int_cellr;
            grid1[Rows, 3].Editor = cc.int_editor;

            grid1[Rows, 4] = new SourceGrid.Cells.Cell(0, typeof(int));
            grid1[Rows, 4].View = cc.int_cellr;
            grid1[Rows, 4].Editor = cc.int_editor;

            grid1[Rows, 5] = new SourceGrid.Cells.Cell(0.000, typeof(decimal));
            grid1[Rows, 5].View = cc.int_cellr;

            grid1[Rows, 6] = new SourceGrid.Cells.Cell(0, typeof(int));
            grid1[Rows, 6].View = cc.int_cellr;
            grid1[Rows, 6].Editor = cc.int_editor;

            grid1[Rows, 7] = new SourceGrid.Cells.Cell(0.00, typeof(decimal));
            grid1[Rows, 7].View = cc.int_cellr;

            grid1[Rows, 8] = new SourceGrid.Cells.Cell(0.00, typeof(decimal));
            grid1[Rows, 8].View = cc.int_cellr;

            grid1[Rows, 9] = new SourceGrid.Cells.Cell(0.00, typeof(decimal));
            grid1[Rows, 9].View = cc.int_cellr;

            grid1[Rows, 10] = new SourceGrid.Cells.Cell(0.00, typeof(decimal));
            grid1[Rows, 10].View = cc.int_cellr;

            grid1[Rows, 11] = new SourceGrid.Cells.Cell(0.00, typeof(decimal));
            grid1[Rows, 11].View = cc.int_cellr;

            grid1[Rows, 12] = new SourceGrid.Cells.Cell(0.00, typeof(decimal));
            grid1[Rows, 12].View = cc.int_cellr;

            grid1[Rows, 13] = new SourceGrid.Cells.Cell(0.00, typeof(decimal));
            grid1[Rows, 13].View = cc.int_cellr;

            grid1[Rows, 14] = new SourceGrid.Cells.Cell(0.00, typeof(decimal));
            grid1[Rows, 14].View = cc.int_cellr;

            grid1[Rows, 15] = new SourceGrid.Cells.Cell(0, typeof(int));
            grid1[Rows, 15].View = cc.int_cellr;
            grid1[Rows, 15].Editor = cc.int_editor;

            grid1[Rows, 16] = new SourceGrid.Cells.Cell(0, typeof(int));
            grid1[Rows, 16].View = cc.int_cellr;
            grid1[Rows, 16].Editor = cc.int_editor;

            grid1[Rows, 17] = new SourceGrid.Cells.Cell(0, typeof(int));
            grid1[Rows, 17].View = cc.int_cellr;
            grid1[Rows, 17].Editor = cc.int_editor;

            grid1[Rows, 18] = new SourceGrid.Cells.Cell(0, typeof(int));
            grid1[Rows, 18].View = cc.center_cellr;
        }

        private void bDelete_Click(object sender, EventArgs e)
        {
            GridHandle.ChkDataDelete(DB_TableName_extra, 2, 0, 1);
        }

        private void bCopy_Click(object sender, EventArgs e)
        {
            string[] rows = new string[grid1.Rows.Count];
            string[] copy_row_id = new string[grid1.Rows.Count];
            rows = GridHandle.GetChkRowid(2, 1, 0);
            string Query = "";
            string Query_sub = " where row_id <0 ";

            for (int i = 0; i < rows.Length; i++)
            {
                if (rows[i] == "0")
                    break;
                Query_sub += " or row_id ='" + GridHandle.OneDataCopy(DB_TableName_extra, rows[i]) + "'";

            }
            Query = "select * from " + DB_TableName_extra;
            Query += Query_sub + " order by row_id";
            GridNewLine_copy(Query);
        }
        private void GridNewLine_copy(string Query)
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

                grid1[m, 3] = new SourceGrid.Cells.Cell(myRead["volume_range_min"], typeof(int));
                grid1[m, 3].View = cc.int_cellr;
                grid1[m, 3].Editor = cc.int_editor;

                grid1[m, 4] = new SourceGrid.Cells.Cell(myRead["volume_range_max"], typeof(int));
                grid1[m, 4].View = cc.int_cellr;
                grid1[m, 4].Editor = cc.int_editor;

                grid1[m, 5] = new SourceGrid.Cells.Cell(myRead["default_ratio"], typeof(decimal));
                grid1[m, 5].View = cc.int_cellr;

                grid1[m, 6] = new SourceGrid.Cells.Cell(myRead["default_tong"], typeof(int));
                grid1[m, 6].View = cc.int_cellr;
                grid1[m, 6].Editor = cc.int_editor;

                grid1[m, 7] = new SourceGrid.Cells.Cell(myRead["dosu_8"], typeof(decimal));
                grid1[m, 7].View = cc.int_cellr;

                grid1[m, 8] = new SourceGrid.Cells.Cell(myRead["dosu_7"], typeof(decimal));
                grid1[m, 8].View = cc.int_cellr;

                grid1[m, 9] = new SourceGrid.Cells.Cell(myRead["dosu_6"], typeof(decimal));
                grid1[m, 9].View = cc.int_cellr;

                grid1[m, 10] = new SourceGrid.Cells.Cell(myRead["dosu_5"], typeof(decimal));
                grid1[m, 10].View = cc.int_cellr;

                grid1[m, 11] = new SourceGrid.Cells.Cell(myRead["dosu_4"], typeof(decimal));
                grid1[m, 11].View = cc.int_cellr;

                grid1[m, 12] = new SourceGrid.Cells.Cell(myRead["dosu_2"], typeof(decimal));
                grid1[m, 12].View = cc.int_cellr;

                grid1[m, 13] = new SourceGrid.Cells.Cell(myRead["dosu_1"], typeof(decimal));
                grid1[m, 13].View = cc.int_cellr;

                grid1[m, 14] = new SourceGrid.Cells.Cell(myRead["dosu_0"], typeof(decimal));
                grid1[m, 14].View = cc.int_cellr;

                grid1[m, 15] = new SourceGrid.Cells.Cell(myRead["gamri_tong"], typeof(int));
                grid1[m, 15].View = cc.int_cellr;
                grid1[m, 15].Editor = cc.int_editor;

                grid1[m, 16] = new SourceGrid.Cells.Cell(myRead["cip_su"], typeof(int));
                grid1[m, 16].View = cc.int_cellr;
                grid1[m, 16].Editor = cc.int_editor;

                grid1[m, 17] = new SourceGrid.Cells.Cell(myRead["hi_quality"], typeof(int));
                grid1[m, 17].View = cc.int_cellr;
                grid1[m, 17].Editor = cc.int_editor;

                grid1[m, 18] = new SourceGrid.Cells.Cell(myRead["guboon_id"], typeof(int));
                grid1[m, 18].View = cc.center_cellr;

                m++;
            }
            myRead.Close();
            DBConn.Close();
        }

        private void ValueChangedEvent1(object sender, EventArgs e)  //Grid1에서 볼륨첸지
        {
            string row_no = grid1[grid1.Selection.ActivePosition.Row, 0].ToString().Trim();
            int cpos = grid1.Selection.ActivePosition.Column;
            int rpos = grid1.Selection.ActivePosition.Row;
            string dat = grid1[grid1.Selection.ActivePosition.Row, grid1.Selection.ActivePosition.Column].ToString().Trim().Replace(",", "");

            string cQuery = "";
            //
            if (cpos.Equals(3))       //
                cQuery = " update " + DB_TableName_extra + " set volume_range_min='" + dat + "' where row_id='" + row_no + "'";
            else if (cpos.Equals(4))       //
                cQuery = " update " + DB_TableName_extra + " set volume_range_max='" + dat + "' where row_id='" + row_no + "'";
            else if (cpos.Equals(5))       //
                cQuery = " update " + DB_TableName_extra + " set default_ratio='" + dat + "' where row_id='" + row_no + "'";
            else if (cpos.Equals(6))       //
                cQuery = " update " + DB_TableName_extra + " set default_tong='" + dat + "' where row_id='" + row_no + "'";
            else if (cpos.Equals(7))       //
                cQuery = " update " + DB_TableName_extra + " set dosu_8='" + dat + "' where row_id='" + row_no + "'";
            else if (cpos.Equals(8))       //
                cQuery = " update " + DB_TableName_extra + " set dosu_7='" + dat + "' where row_id='" + row_no + "'";
            else if (cpos.Equals(9))       //
                cQuery = " update " + DB_TableName_extra + " set dosu_6='" + dat + "' where row_id='" + row_no + "'";
            else if (cpos.Equals(10))       //
                cQuery = " update " + DB_TableName_extra + " set dosu_5='" + dat + "' where row_id='" + row_no + "'";
            else if (cpos.Equals(11))       //
                cQuery = " update " + DB_TableName_extra + " set dosu_4='" + dat + "' where row_id='" + row_no + "'";
            else if (cpos.Equals(12))       //
                cQuery = " update " + DB_TableName_extra + " set dosu_2='" + dat + "' where row_id='" + row_no + "'";
            else if (cpos.Equals(13))       //
                cQuery = " update " + DB_TableName_extra + " set dosu_1='" + dat + "' where row_id='" + row_no + "'";
            else if (cpos.Equals(14))       //
                cQuery = " update " + DB_TableName_extra + " set dosu_0='" + dat + "' where row_id='" + row_no + "'";
            else if (cpos.Equals(15))       //
                cQuery = " update " + DB_TableName_extra + " set gamri_tong='" + dat + "' where row_id='" + row_no + "'";
            else if (cpos.Equals(16))       //
                cQuery = " update " + DB_TableName_extra + " set cip_su='" + dat + "' where row_id='" + row_no + "'";
            else if (cpos.Equals(17))       //
                cQuery = " update " + DB_TableName_extra + " set hi_quality='" + dat + "' where row_id='" + row_no + "'";
            else if (cpos.Equals(18))
            {
                if (ab_code == "0802")
                    cQuery = " update " + DB_TableName_extra + " set guboon_id='" + dat + "' where row_id='" + row_no + "'";
            }

            if (!cQuery.Equals(""))
            {
                GridHandle.DataUpdate(cQuery);
            }

        }

        private void bRefresh_Click(object sender, EventArgs e)
        {
            string Query = "select * from " + DB_TableName_extra + " where ab_code = '"+ab_code+"' order by row_id";
            GridView(Query);
        }

        private void Form_2122_ClientSizeChanged(object sender, EventArgs e)
        {
            this.grid1.Size = new System.Drawing.Size(this.Size.Width - 42, this.Height - 111);
        }


    }
}
