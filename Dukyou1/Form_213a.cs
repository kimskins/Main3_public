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
    public partial class Form_213a : Form
    {
        SourceGridControl GridHandle_A = new SourceGridControl();
        SourceGridControl GridHandle_B = new SourceGridControl();

        string DB_TableName_c_com = "C_choice_company";

        public string ab_code = "";
        public Form_213a()
        {
            InitializeComponent();
        }

        private void Form_213a_Load(object sender, EventArgs e)
        {
            Screen srn = Screen.PrimaryScreen;
            int Xb = this.Width;  //좌,우
            int Yb = this.Height; //좌,우
            this.Location = new Point((srn.Bounds.Width - Xb) / 2, (srn.Bounds.Height - Yb) / 2);  //좌/우,위/아래

            GridHandle_A.SourceGrideInit(grid1, Config.DB_con1);
            GridHandle_B.SourceGrideInit(grid2, Config.DB_con1);
            Refresh1();
        }

        private void Refresh1()
        {
            string cQuery = "select * from C_amodel order by s_no";
            Grid1_View(cQuery);
        }

        private void Refresh2(string a_code)
        {
            string cQuery = "select * from C_bmodel where a_code = '" + a_code + "' order by a_code, b_code";
            Grid2_View(cQuery);
        }

        private void Grid1_View(string Query)
        {
            cell_d cc = new cell_d();
            // 
            grid1.Rows.Clear();
            grid1.BorderStyle = BorderStyle.FixedSingle;
            grid1.SelectionMode = SourceGrid.GridSelectionMode.Cell;
            grid1.ColumnsCount = 4;
            grid1.FixedRows = 1;
            grid1.Rows.Insert(0);
            grid1.Rows[0].Height = 24;

            grid1[0, 0] = new MyHeader1("row_id");
            grid1.Columns[0].Visible = false;

            grid1[0, 1] = new MyHeader1("no");
            grid1[0, 2] = new MyHeader1("A");
            grid1[0, 3] = new MyHeader1("대분류");


            grid1.Columns[1].Width = 40;
            grid1.Columns[2].Width = 40;
            grid1.Columns[3].Width = 150;



            MySqlConnection DBConn;
            DBConn = new MySqlConnection(Config.DB_con1);
            DBConn.Open();

            var cmd = new MySqlCommand(Query, DBConn);
            var myRead = cmd.ExecuteReader();

            int Rows = 1;
            while (myRead.Read())
            {
                grid1.Rows.Insert(Rows);
                grid1.Rows[Rows].Height = 24;

                grid1[Rows, 0] = new SourceGrid.Cells.Cell(myRead["row_id"], typeof(string));

                grid1[Rows, 1] = new SourceGrid.Cells.Cell((Rows ).ToString(), typeof(string));
                grid1[Rows, 1].View = cc.center_cell;
                grid1[Rows, 1].Editor = cc.disable_cell;

                grid1[Rows, 2] = new SourceGrid.Cells.Cell(myRead["a_code"], typeof(string));
                grid1[Rows, 2].View = cc.center_cell;
                grid1[Rows, 2].Editor = cc.disable_cell;

                grid1[Rows, 3] = new SourceGrid.Cells.Cell(myRead["aitem"], typeof(string));
                grid1[Rows, 3].View = cc.center_cell;
                grid1[Rows, 3].Editor = cc.disable_cell;


                Rows++;
            }
            myRead.Close();
            DBConn.Close();
        }

        private void Grid2_View(string Query)
        {
            cell_d cc = new cell_d();
            // 
            grid2.Rows.Clear();
            grid2.BorderStyle = BorderStyle.FixedSingle;
            grid2.SelectionMode = SourceGrid.GridSelectionMode.Cell;
            grid2.ColumnsCount = 5;
            grid2.FixedRows = 1;
            grid2.Rows.Insert(0);
            grid2.Rows[0].Height = 24;

            grid2[0, 0] = new MyHeader1("row_id");
            grid2.Columns[0].Visible = false;

            grid2[0, 1] = new MyHeader1("no");
            grid2[0, 2] = new MyHeader1("A");
            grid2[0, 3] = new MyHeader1("B");
            grid2[0, 4] = new MyHeader1("중분류");


            grid2.Columns[1].Width = 40;
            grid2.Columns[2].Width = 40;
            grid2.Columns[3].Width = 40;
            grid2.Columns[4].Width = 150;


            MySqlConnection DBConn;
            DBConn = new MySqlConnection(Config.DB_con1);
            DBConn.Open();

            var cmd = new MySqlCommand(Query, DBConn);
            var myRead = cmd.ExecuteReader();

            int Rows = 1;
            while (myRead.Read())
            {
                grid2.Rows.Insert(Rows);
                grid2.Rows[Rows].Height = 24;

                grid2[Rows, 0] = new SourceGrid.Cells.Cell(myRead["row_id"], typeof(string));

                grid2[Rows, 1] = new SourceGrid.Cells.Cell((Rows).ToString(), typeof(string));
                grid2[Rows, 1].View = cc.center_cell;
                grid2[Rows, 1].Editor = cc.disable_cell;

                grid2[Rows, 2] = new SourceGrid.Cells.Cell(myRead["a_code"], typeof(string));
                grid2[Rows, 2].View = cc.center_cell;
                grid2[Rows, 2].Editor = cc.disable_cell;

                grid2[Rows, 3] = new SourceGrid.Cells.Cell(myRead["b_code"], typeof(string));
                grid2[Rows, 3].View = cc.center_cell;
                grid2[Rows, 3].Editor = cc.disable_cell;

                grid2[Rows, 4] = new SourceGrid.Cells.Cell(myRead["bitem"], typeof(string));
                grid2[Rows, 4].View = cc.center_cell;
                grid2[Rows, 4].Editor = cc.disable_cell;


                Rows++;
            }
            myRead.Close();
            DBConn.Close();
        }

        private void grid1_Click(object sender, EventArgs e)
        {
            string a_code = grid1[grid1.Selection.ActivePosition.Row, 2].ToString().Trim();
            Refresh2(a_code);
        }

        private void grid2_DoubleClick(object sender, EventArgs e)
        {
            string a_code = grid2[grid2.Selection.ActivePosition.Row, 2].ToString().Trim();
            string b_code = grid2[grid2.Selection.ActivePosition.Row, 3].ToString().Trim();
            string ab_code = a_code + b_code;

            string Query = "select * from " + DB_TableName_c_com + " where ab_code='" + ab_code + "'";

            MySqlConnection DBConn;
            DBConn = new MySqlConnection(Config.DB_con1);
            DBConn.Open();

            var cmd = new MySqlCommand(Query, DBConn);
            var myRead = cmd.ExecuteReader();

            if (myRead.Read())
            {
                MessageBox.Show("이미 등록된 AB코드가 존재합니다.");
                myRead.Close();
                DBConn.Close();
                return;
            }
            else
            {
                this.ab_code = ab_code;
                myRead.Close();
                DBConn.Close();
                this.Close();
            }
        }

        private void bClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

    }
}
