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
    public partial class Form_404a : Form
    {
        string DB_TableName_form_manager = "C_file_total_manage";
        string DB_TableName_client = "C_client";
        string DB_TableName_cf_manage = "C_cf_manage";
        string DB_TableName = "";
        ksgcontrol ks = new ksgcontrol();
        Button butt = new Button();
        int Xb, Yb;
        string row_id = "";
       
        public Form_404a(Button bt)
        {
            InitializeComponent();
            ks.ControlInit(Config.DB_con1,null,null,null);
            butt = bt;
            
            //
            Xb = butt.PointToScreen(Location).X;  //좌,우
            Yb = butt.PointToScreen(Location).Y;// +bt.Height + 6;  //위,아래
        }
        public Form_404a(int x, int y,string row_no, string Query, string tablename)
        {
            row_id = row_no;
            DB_TableName = tablename;
            InitializeComponent();
            ks.ControlInit(Config.DB_con1, null, null, null);
            this.grid1.Location = new System.Drawing.Point(12, 12);
            Xb = x + 200;  //좌,우
            Yb = y + 280;  //위,아래
            bSearch.Visible = false;
            tbName.Visible = false;
            bNotcompany.Visible = false;
            grid1_view2(Query);
        }

        private void grid1_view2(string cQuery)
        {
            cell_d cc = new cell_d();
            grid1.Rows.Clear();
            grid1.BorderStyle = BorderStyle.FixedSingle;
            grid1.SelectionMode = SourceGrid.GridSelectionMode.Row;
            grid1.ColumnsCount = 5;
            grid1.FixedRows = 0;
            grid1.Rows.Insert(0);
            grid1.Rows[0].Height = 24;

            grid1[0, 0] = new MyHeader1("row_id");
            grid1.Columns[0].Visible = false;
            grid1[0, 1] = new MyHeader1("√");
            grid1[0, 2] = new MyHeader1("no");
            grid1.Columns[2].Visible = false;
            grid1[0, 3] = new MyHeader1("상호");
            grid1[0, 4] = new MyHeader1("지역");

            grid1.Columns[1].Width = 20;
            grid1.Columns[3].Width = 280;
            grid1.Columns[4].Width = 112;

            MySqlConnection DBConn;
            DBConn = new MySqlConnection(Config.DB_con1);
            DBConn.Open();

           
            var cmd = new MySqlCommand(cQuery, DBConn);
            var myRead = cmd.ExecuteReader();

            int m = 1;
            while (myRead.Read())
            {
                grid1.Rows.Insert(m);
                grid1.Rows[m].Height = 20;

                grid1[m, 0] = new SourceGrid.Cells.Cell(myRead["row_id"].ToString(), typeof(string));

                grid1[m, 1] = new SourceGrid.Cells.CheckBox(null, false);
                grid1[m, 2] = new SourceGrid.Cells.Cell((m).ToString(), typeof(string));
                grid1[m, 2].Editor = cc.disable_cell;
                grid1[m, 2].View = cc.center_cell;

                grid1[m, 3] = new SourceGrid.Cells.Cell(myRead["sangho"].ToString(), typeof(string));
                grid1[m, 3].Editor = cc.disable_cell;

                grid1[m, 4] = new SourceGrid.Cells.Cell(myRead["area"].ToString(), typeof(string));
                grid1[m, 4].Editor = cc.disable_cell;
                m++;
            }
            myRead.Close();
            DBConn.Close();
        }

        public void grid1_view(string Query)
        {
            cell_d cc = new cell_d();
            grid1.Rows.Clear();
            grid1.BorderStyle = BorderStyle.FixedSingle;
            grid1.SelectionMode = SourceGrid.GridSelectionMode.Row;
            grid1.ColumnsCount = 5;
            grid1.FixedRows = 0;
            grid1.Rows.Insert(0);
            grid1.Rows[0].Height = 24;

            grid1[0, 0] = new MyHeader1("row_id");
            grid1.Columns[0].Visible = false;
            grid1[0, 1] = new MyHeader1("√");
            grid1[0, 2] = new MyHeader1("no");
            grid1.Columns[2].Visible = false;
            grid1[0, 3] = new MyHeader1("상호");
            grid1[0, 4] = new MyHeader1("대표");
            
            grid1.Columns[1].Width = 20;
            grid1.Columns[3].Width = 280;
            grid1.Columns[4].Width = 112;

            MySqlConnection DBConn;
            DBConn = new MySqlConnection(Config.DB_con1);
            DBConn.Open();
            
            var cmd = new MySqlCommand(Query, DBConn);
            var myRead = cmd.ExecuteReader();

            int m = 1;
            while (myRead.Read())
            {
                grid1.Rows.Insert(m);
                grid1.Rows[m].Height = 20;

                grid1[m, 0] = new SourceGrid.Cells.Cell(myRead["row_id"].ToString(), typeof(string));

                grid1[m, 1] = new SourceGrid.Cells.CheckBox(null, false);
                grid1[m, 2] = new SourceGrid.Cells.Cell((m).ToString(), typeof(string));
                grid1[m, 2].Editor = cc.disable_cell;
                grid1[m, 2].View = cc.center_cell;

                grid1[m, 3] = new SourceGrid.Cells.Cell(myRead["name"].ToString(), typeof(string));
                grid1[m, 3].Editor = cc.disable_cell;

                grid1[m, 4] = new SourceGrid.Cells.Cell(myRead["ceo"].ToString(), typeof(string));
                grid1[m, 4].Editor = cc.disable_cell;
                m++;
            }
            myRead.Close();
            DBConn.Close();
        }

        private void bSearch_Click(object sender, EventArgs e)
        {
            string Query = "select row_id,name,ceo from " + DB_TableName_client + " where name like '%" + tbName.Text.Trim() + "%'";
            grid1_view(Query);
        }

        private void bComplete_Click(object sender, EventArgs e)
        {
            string Query = "";
            if (row_id =="")
            {
                for (int i = 0; i < grid1.RowsCount; i++)
                {
                    if (grid1[i, 1].ToString() == "True")
                    {
                        Query = "insert into " + DB_TableName_cf_manage + "(client_id) values(" + grid1[i, 0].ToString() + ")";
                        ks.DataUpdate(Query);
                    }
                }
            }
            else
            {
                for (int i = 0; i < grid1.RowsCount; i++)
                {
                    if (grid1[i, 1].ToString() == "True")
                    {
                        Query = "update "+DB_TableName+" set hcust_id = " + grid1[i, 0].ToString() + " where row_id = " + row_id;
                        ks.DataUpdate(Query);
                    }
                }
            }
            this.Close();
        }

        private void bNotcompany_Click(object sender, EventArgs e)
        {
            string Query = "";
            Query = "insert into " + DB_TableName_cf_manage + "(client_id) values(0)";
            ks.DataUpdate(Query);            
            this.Close();
        }

        private void tbName_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode.Equals(Keys.Enter))
                bComplete_Click(sender, e);
        }

        private void Form_404a_Load(object sender, EventArgs e)
        {
            this.Location = new Point(Xb, Yb);
        }

        private void grid1_MouseClick(object sender, MouseEventArgs e)
        {
            int rpos = grid1.Selection.ActivePosition.Row;
            int cpos = grid1.Selection.ActivePosition.Column;
            //
            if (cpos.Equals(0))
            {
                for (int i = 1; i < grid1.RowsCount; i++)
                {
                    if (i == rpos)
                        grid1[i, 0] = new SourceGrid.Cells.CheckBox(null, true);
                    else
                        grid1[i, 0] = new SourceGrid.Cells.CheckBox(null, false);
                    //
                }
                grid1.Refresh();
            }
        }
           
    }
}

