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
    public partial class Form_2121 : Form
    {
        string DB_TableName_extra = "C_paper_extra_h";
        string DB_TableName_hang = "hang_manage";

        public Form_2121()
        {
            InitializeComponent();
        }

        private void Form_2112_Load(object sender, EventArgs e)
        {
            Screen srn = Screen.PrimaryScreen;
            int Xb = this.Width;  //좌,우
            int Yb = this.Height; //좌,우
            this.Location = new Point((srn.Bounds.Width - Xb) / 2, (srn.Bounds.Height - Yb) / 2-100);  //좌/우,위/아래

            SourceGrid.Cells.Controllers.CustomEvents val_c1 = new SourceGrid.Cells.Controllers.CustomEvents();
            val_c1.ValueChanged += new EventHandler(ValueChangedEvent1);
            grid1.Controller.AddController(val_c1);

            string Query = "select * from " + DB_TableName_extra + " a left outer join " + DB_TableName_hang + " b on a.code = b.code1 and b.class='항목' ";
            GridView(Query);
        }

        private void GridView(string Query)
        {
            cell_d cc = new cell_d();

            grid1.Rows.Clear();
            grid1.BorderStyle = BorderStyle.FixedSingle;
            grid1.SelectionMode = SourceGrid.GridSelectionMode.Cell;
            grid1.ColumnsCount = 9;
            grid1.FixedRows = 1;
            grid1.Rows.Insert(0);
            grid1.Rows[0].Height = 24;

            grid1[0, 0] = new MyHeader1("row_id");
            grid1.Columns[0].Visible = false;

            grid1[0, 1] = new MyHeader1("항목");
            grid1[0, 2] = new MyHeader1("옵셋인쇄");
            grid1[0, 3] = new MyHeader1("UV");
            grid1[0, 4] = new MyHeader1("윤전");
            grid1[0, 5] = new MyHeader1("디지털");
            grid1[0, 6] = new MyHeader1("인디고");
            grid1[0, 7] = new MyHeader1("마스터");
            grid1[0, 8] = new MyHeader1("인쇄0/0");

            grid1.Columns[1].Width = 120;
            grid1.Columns[2].Width = 80;
            grid1.Columns[3].Width = 80;
            grid1.Columns[4].Width = 80;
            grid1.Columns[5].Width = 80;
            grid1.Columns[6].Width = 80;
            grid1.Columns[7].Width = 80;
            grid1.Columns[8].Width = 80;

            MySqlConnection DBConn;
            DBConn = new MySqlConnection(Config.DB_con1);
            DBConn.Open();

            var cmd = new MySqlCommand(Query, DBConn);
            var myRead = cmd.ExecuteReader();

            int m = 1;
            while (myRead.Read())
            {
                grid1.Rows.Insert(m);
                grid1.Rows[m].Height = 22;
                grid1[m, 0] = new SourceGrid.Cells.Cell(myRead["row_id"], typeof(string));

                grid1[m, 1] = new SourceGrid.Cells.Cell(myRead["hang"], typeof(string));
                grid1[m, 1].View = cc.center_cellr;

                grid1[m, 2] = new SourceGrid.Cells.Cell(myRead["offset"], typeof(decimal));
                grid1[m, 2].View = cc.int_cellr;
                //grid1[m, 2].Editor = cc.decimal_editor;

                grid1[m, 3] = new SourceGrid.Cells.Cell(myRead["uv"], typeof(decimal));
                grid1[m, 3].View = cc.int_cellr;
                //grid1[m, 3].Editor = cc.decimal_editor;

                grid1[m, 4] = new SourceGrid.Cells.Cell(myRead["yunjun"], typeof(decimal));
                grid1[m, 4].View = cc.int_cellr;
                //grid1[m, 4].Editor = cc.decimal_editor;

                grid1[m, 5] = new SourceGrid.Cells.Cell(myRead["digital"], typeof(decimal));
                grid1[m, 5].View = cc.int_cellr;
                //grid1[m, 5].Editor = cc.decimal_editor;

                grid1[m, 6] = new SourceGrid.Cells.Cell(myRead["indigo"], typeof(decimal));
                grid1[m, 6].View = cc.int_cellr;
                //grid1[m, 6].Editor = cc.decimal_editor;

                grid1[m, 7] = new SourceGrid.Cells.Cell(myRead["master"], typeof(decimal));
                grid1[m, 7].View = cc.int_cellr;
                //grid1[m, 7].Editor = cc.decimal_editor;

                grid1[m, 8] = new SourceGrid.Cells.Cell(myRead["print_zero"], typeof(decimal));
                grid1[m, 8].View = cc.int_cellr;

                m++;               
                
            }
            myRead.Close();
            DBConn.Close();
        }

        private void ValueChangedEvent1(object sender, EventArgs e)  //Grid1에서 볼륨첸지
        {
            SourceGridControl GridHandle = new SourceGridControl();
            GridHandle.SourceGrideInit(grid1, Config.DB_con1);
            string row_no = grid1[grid1.Selection.ActivePosition.Row, 0].ToString().Trim();
            int cpos = grid1.Selection.ActivePosition.Column;
            int rpos = grid1.Selection.ActivePosition.Row;
            string dat;
            
            dat = grid1[grid1.Selection.ActivePosition.Row, grid1.Selection.ActivePosition.Column].ToString().Trim().Replace(",", "");

            string cQuery = "";
            //
            if (cpos.Equals(1))       //
                cQuery = " update " + DB_TableName_extra + " set code='" + dat + "' where row_id='" + row_no + "'";
            else if (cpos.Equals(2))       //
                cQuery = " update " + DB_TableName_extra + " set offset='" + dat + "' where row_id='" + row_no + "'";
            else if (cpos.Equals(3))       //
                cQuery = " update " + DB_TableName_extra + " set uv='" + dat + "' where row_id='" + row_no + "'";
            else if (cpos.Equals(4))  //
                cQuery = " update " + DB_TableName_extra + " set yunjun='" + dat + "' where row_id='" + row_no + "'";
            else if (cpos.Equals(5))  //
                cQuery = " update " + DB_TableName_extra + " set digital='" + dat + "' where row_id='" + row_no + "'";
            else if (cpos.Equals(6))  //
                cQuery = " update " + DB_TableName_extra + " set indigo='" + dat + "' where row_id='" + row_no + "'";
            else if (cpos.Equals(7))  //
                cQuery = " update " + DB_TableName_extra + " set master='" + dat + "' where row_id='" + row_no + "'";
            else if (cpos.Equals(8))  //
                cQuery = " update " + DB_TableName_extra + " set print_zero='" + dat + "' where row_id='" + row_no + "'";
            
            if (!cQuery.Equals(""))
            {
                GridHandle.DataUpdate(cQuery);
            }
            
        }

        private void bRefresh_Click(object sender, EventArgs e)
        {
            string Query = "select * from " + DB_TableName_extra + " a left outer join " + DB_TableName_hang + " b on a.code = b.code1 and b.class='항목' ";
            GridView(Query);
        }

        private void button1_Click(object sender, EventArgs e)  //항목추가
        {
            SourceGridControl GridHandle = new SourceGridControl();
            GridHandle.SourceGrideInit(grid1, Config.DB_con1);
            string cQuery = " INSERT INTO C_paper_extra_h(code) VALUES(' ')";
            GridHandle.DataUpdate(cQuery);
            bRefresh_Click(null, null);
        }
    }
}
