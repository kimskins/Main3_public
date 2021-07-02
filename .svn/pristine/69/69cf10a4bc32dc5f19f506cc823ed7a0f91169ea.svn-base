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
    public partial class Form_4013a : Form
    {
        string DB_TableName_Client = "C_client";
        public string row_id = "";

        public Form_4013a()
        {
            InitializeComponent();
        }

        private void Form_4013a_Load(object sender, EventArgs e)
        {
            Screen srn = Screen.PrimaryScreen;
            int Xb = this.Width;  //좌,우
            this.Location = new Point((srn.Bounds.Width - Xb) / 2, 1);  //좌/우,위/아래

        }

        private void Grid_View(string Query)  //Grid1
        {
            cell_d cc = new cell_d();

            grid1.Rows.Clear();
            grid1.BorderStyle = BorderStyle.FixedSingle;
            grid1.SelectionMode = SourceGrid.GridSelectionMode.Row;
            grid1.ColumnsCount = 7;
            grid1.FixedRows = 1;
            grid1.Rows.Insert(0);
            grid1.Rows[0].Height = 24;
            //
            grid1[0, 0] = new MyHeader1("row_id");
            grid1.Columns[0].Visible = false;

            grid1[0, 1] = new MyHeader1("√");

            grid1[0, 2] = new MyHeader1("No");

            grid1[0, 3] = new MyHeader1("업체명");

            grid1[0, 4] = new MyHeader1("대표자");

            grid1[0, 5] = new MyHeader1("전화번호");

            grid1[0, 6] = new MyHeader1("사업자번호");

            //
            grid1.Columns[1].Width = 20;
            grid1.Columns[2].Width = 40;
            grid1.Columns[3].Width = 200;
            grid1.Columns[4].Width = 150;
            grid1.Columns[5].Width = 200;
            grid1.Columns[6].Width = 150;

            //
            int m = 1;

            MySqlConnection DBConn;
            DBConn = new MySqlConnection(Config.DB_con1);
            util.Con_DB_Open(ref DBConn);

            var cmd = new MySqlCommand(Query, DBConn);
            var myRead = cmd.ExecuteReader();

            // 
            while (myRead.Read())
            {
                grid1.Rows.Insert(m);
                grid1.Rows[m].Height = 22;
                //
                grid1[m, 0] = new SourceGrid.Cells.Cell(myRead["row_id"], typeof(string));
                grid1[m, 1] = new SourceGrid.Cells.CheckBox(null, false);

                grid1[m, 2] = new SourceGrid.Cells.Cell((m).ToString(), typeof(int));
                grid1[m, 2].View = cc.center_cell;
                grid1[m, 2].Editor = cc.disable_cell;

                grid1[m, 3] = new SourceGrid.Cells.Cell(myRead["name"], typeof(string));
                grid1[m, 3].View = cc.center_cellb;
                grid1[m, 3].Editor = cc.disable_cell;

                grid1[m, 4] = new SourceGrid.Cells.Cell(myRead["ceo"], typeof(string));
                grid1[m, 4].View = cc.center_cell;
                grid1[m, 4].Editor = cc.disable_cell;

                grid1[m, 5] = new SourceGrid.Cells.Cell(myRead["tel"], typeof(string));
                grid1[m, 5].View = cc.center_cell;
                grid1[m, 5].Editor = cc.disable_cell;

                grid1[m, 6] = new SourceGrid.Cells.Cell(myRead["company_num"], typeof(string));
                grid1[m, 6].View = cc.center_cell;
                grid1[m, 6].Editor = cc.disable_cell;

                m++;
            }
            myRead.Close();
            DBConn.Close();
        }

        private void bSearch_Click(object sender, EventArgs e)
        {
            string cQuery = "select * from " + DB_TableName_Client + " where name like '%" + tbName.Text.Trim() + "%' ";
            Grid_View(cQuery);
        }

        private void grid1_DoubleClick(object sender, EventArgs e)
        {
            int rpos = grid1.Selection.ActivePosition.Row;
            if (rpos < 0)
                return;

            row_id = grid1[rpos, 0].ToString();

            this.Close();
        }
    }
}
