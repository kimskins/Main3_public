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
    public partial class Form_502b : Form
    {
        cell_d cc = new cell_d();
        // 
        SourceGridControl GridHandle = new SourceGridControl();
        string DB_TableName_hcustomer = "C_hcustomer";
        string DB_TablaName_hcust_jiup_code = "C_hcust_jiup_code";
        private TextBox bt = new TextBox();
        Button but = new Button();
        private int Xb = 0;
        private int Yb = 0;
        public string temp = "";
        public string row_id = "";
        SourceGrid.Grid grid;

        public string[] code = new string[0];

        public Form_502b(TextBox tt)
        {
            InitializeComponent();
            GridHandle.SourceGrideInit(grid1, null);
            bt = tt;
            bSelect.Visible = false;
            this.grid1.Location = new System.Drawing.Point(6, 8);
            this.grid1.Size = new System.Drawing.Size(303, 235);
            this.ClientSize = new System.Drawing.Size(315, 250);
            //
            Xb = bt.PointToScreen(Location).X;  //좌,우
            Yb = bt.PointToScreen(Location).Y + bt.Height + 6;  //위,아래
            gird1_view();
            grid1.Selection.EnableMultiSelection = false;

        }
        public Form_502b(SourceGrid.Grid gd, Button bt)
        {
            InitializeComponent();
            grid = gd;
            but = bt;
            Xb = but.PointToScreen(Location).X;  //좌,우
            Yb = but.PointToScreen(Location).Y + but.Height + 6;  //위,아래
            

            GridHandle.SourceGrideInit(grid1,Config.DB_con1);
            gird1_view_2();
        }
        private void Form_501b_Load(object sender, EventArgs e)
        {
            this.Location = new Point(Xb, Yb);
        }

        public void gird1_view_2()
        {
            grid1.Rows.Clear();
            grid1.BorderStyle = BorderStyle.FixedSingle;
            grid1.SelectionMode = SourceGrid.GridSelectionMode.Row;
            grid1.ColumnsCount = 5;
            grid1.FixedRows = 1;
            grid1.Rows.Insert(0);
            grid1.Rows[0].Height = 20;
            grid1[0, 0] = new MyHeader1("row_id");
            grid1.Columns[0].Visible = false;
            grid1[0, 1] = new MyHeader1("√");
            grid1[0, 2] = new MyHeader1("No");
            grid1[0, 3] = new MyHeader1("업체명");
            grid1[0, 4] = new MyHeader1("업체코드");
            grid1.Columns[4].Visible = false;


            grid1.Columns[1].Width = 25;
            grid1.Columns[2].Width = 30;
            grid1.Columns[3].Width = 200;
            grid1.Columns[4].Width = 70;

            string temp = "";

            for(int i = 1; i<grid.RowsCount; i++)
            {
                temp += " and code1 <> '" + grid[i, 7].ToString() + "'";
            }

            MySqlConnection DBConn;
            DBConn = new MySqlConnection(Config.DB_con1);
            DBConn.Open();
            string Query = "select * from hang_manage where class = '제지사' " + temp;
            var cmd = new MySqlCommand(Query, DBConn);
            var myRead = cmd.ExecuteReader();

            int m = 1;
            while (myRead.Read())
            {
                grid1.Rows.Insert(m);
                grid1.Rows[m].Height = 20;

                grid1[m, 0] = new SourceGrid.Cells.Cell(myRead["row_id"].ToString(), typeof(string));
                grid1[m, 1] = new SourceGrid.Cells.CheckBox(null, false);

                grid1[m, 2] = new SourceGrid.Cells.Cell(m, typeof(string));
                grid1[m, 2].View = cc.center_cell;
                grid1[m, 2].Editor = cc.disable_cell;
                grid1[m, 3] = new SourceGrid.Cells.Cell(myRead["hang"].ToString(), typeof(string));
                grid1[m, 3].Editor = cc.disable_cell;
                grid1[m, 4] = new SourceGrid.Cells.Cell(myRead["code1"].ToString(), typeof(string));
                m++;
            }

            myRead.Close();
            DBConn.Close();
        }

        public void gird1_view()
        {
            grid1.Rows.Clear();
            grid1.BorderStyle = BorderStyle.FixedSingle;
            grid1.SelectionMode = SourceGrid.GridSelectionMode.Row;
            grid1.ColumnsCount = 4;
            grid1.FixedRows = 1;
            grid1.Rows.Insert(0);
            grid1.Rows[0].Height = 20;
            grid1[0, 0] = new MyHeader1("row_id");
            grid1.Columns[0].Visible = false;
            grid1[0, 1] = new MyHeader1("No");
            grid1[0, 2] = new MyHeader1("업체명");
            grid1[0, 3] = new MyHeader1("업체코드");

            grid1.Columns[1].Width = 30;
            grid1.Columns[2].Width = 200;
            grid1.Columns[3].Width = 70;

            MySqlConnection DBConn;
            DBConn = new MySqlConnection(Config.DB_con1);
            DBConn.Open();
            string Query = "select b.row_id as row_id, a.code, a.hcust_id, b.sangho from " + DB_TablaName_hcust_jiup_code + " as a ";
            Query += "left outer join " + DB_TableName_hcustomer + " as b on a.hcust_id = b.row_id order by substring(code,2,1), substring(code,1,1)";
            var cmd = new MySqlCommand(Query, DBConn);
            var myRead = cmd.ExecuteReader();

            int m = 1;
            while (myRead.Read())
            {
                grid1.Rows.Insert(m);
                grid1.Rows[m].Height = 20;

                grid1[m, 0] = new SourceGrid.Cells.Cell(myRead["row_id"].ToString(), typeof(string));
                grid1[m, 1] = new SourceGrid.Cells.Cell(m, typeof(string));
                grid1[m, 1].View = cc.center_cell;
                grid1[m, 1].Editor = cc.disable_cell;
                grid1[m, 2] = new SourceGrid.Cells.Cell(myRead["sangho"].ToString(), typeof(string));
                grid1[m, 2].Editor = cc.disable_cell;
                grid1[m, 3] = new SourceGrid.Cells.Cell(myRead["code"].ToString(), typeof(string));
                grid1[m, 3].View = cc.center_cell;
                grid1[m, 3].Editor = cc.disable_cell;
                m++;
            }

            myRead.Close();
            DBConn.Close();
        }


        private void grid1_MouseClick(object sender, MouseEventArgs e)
        {
            
        }

        private void bSelect_Click(object sender, EventArgs e)
        {
            for (int i = 1; i < grid1.RowsCount; i++)
            {
                if (grid1[i, 1].ToString() == "True")
                {
                    Array.Resize<String>(ref code, code.Length + 1);
                    code[code.Length - 1] = grid1[i, 4].ToString();
                }
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
        }

        private void grid1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            int row = grid1.Selection.ActivePosition.Row;
            int col = grid1.Selection.ActivePosition.Column;

            if (row == -1)
                return;

            if (col == 3)
            {
                Array.Resize<String>(ref code, code.Length + 1);
                code[code.Length - 1] = grid1[row, 4].ToString();

                this.DialogResult = DialogResult.OK;
                this.Close();
            }
        }
    }
}
