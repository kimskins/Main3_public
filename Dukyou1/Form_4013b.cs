using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Dukyou3
{
    public partial class Form_4013b : Form
    {
        int Xb = 0;
        int Yb = 0;
        string DB_TableName_mem = "C_member";
        string int_id = "";
        public string row_id = "";
        public string name = "";
        public Form_4013b(SourceGrid.Grid gd, Point pp, string row_no)
        {
            InitializeComponent();

            Xb = gd.PointToScreen(Location).X + pp.X;  //좌,우
            Yb = gd.PointToScreen(Location).Y + pp.Y;  //위,아래
            int_id = row_no;
        }

        private void Form_4013b_Load(object sender, EventArgs e)
        {
            this.Location = new Point(Xb, Yb);
            grid1_view();
        }

        private void grid1_view()
        {
            cell_d cc = new cell_d();

            grid1.Rows.Clear();
            grid1.BorderStyle = BorderStyle.FixedSingle;
            grid1.SelectionMode = SourceGrid.GridSelectionMode.Cell;
            grid1.ColumnsCount = 2;
            grid1.FixedRows = 1;
            grid1.Rows.Insert(0);
            grid1.Rows[0].Height = 24;
            //
            grid1[0, 0] = new MyHeader1("row_id");
            grid1.Columns[0].Visible = false;

            grid1[0, 1] = new MyHeader1("영업자");


            //
            grid1.Columns[1].Width = 100;
            //
            int m = 1;

            MySqlConnection DBConn;
            DBConn = new MySqlConnection(Config.DB_con1);
            util.Con_DB_Open(ref DBConn);

            string Query = "select row_id, name from " + DB_TableName_mem + " where int_id = " + int_id;
            var cmd = new MySqlCommand(Query, DBConn);
            var myRead = cmd.ExecuteReader();

            // 
            while (myRead.Read())
            {
                grid1.Rows.Insert(m);
                grid1.Rows[m].Height = 22;
                //
                grid1[m, 0] = new SourceGrid.Cells.Cell(myRead["row_id"], typeof(string));
                
                grid1[m, 1] = new SourceGrid.Cells.Cell(myRead["name"], typeof(string));
                grid1[m, 1].View = cc.center_cell;
                grid1[m, 1].Editor = cc.disable_cell;

                m++;
            }
            myRead.Close();
            DBConn.Close();
        }

        private void grid1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            int r_pos = grid1.Selection.ActivePosition.Row;
            int c_pos = grid1.Selection.ActivePosition.Column;
            if (r_pos < 0)
                return;

            if(c_pos == 1)
            {
                row_id = grid1[r_pos, 0].ToString();
                name = grid1[r_pos, 1].ToString();
                this.DialogResult = DialogResult.OK;
                this.Close();
            }

        }

        private void Form_4013b_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
                this.Close();
        }

    }
}
