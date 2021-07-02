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
    public partial class Form_502a : Form
    {
        string chk_item_group = "";
        string code_w = " where row_id <> -1 ";
        string DB_Tablename = "C_paper_size_code";
        SourceGrid.Grid grid;
        int g_hight = 0;
        private int Xb = 0;
        private int Yb = 0;
        public Form_502a(string temp, int x, int y, SourceGrid.Grid gd)
        {
            InitializeComponent();
            grid = gd;
            g_hight = grid.Rows.GetHeight(1);
            //
            Xb = grid.PointToScreen(Location).X + x;            //좌,우
            Yb = grid.PointToScreen(Location).Y + y + g_hight;  //위,아래

            
            chk_item_group = temp;


        }
        private void Form_501a_Load(object sender, EventArgs e)
        {
            if ((Yb + this.Height) > Screen.PrimaryScreen.Bounds.Height)
                Yb = Yb - this.Height - g_hight;
            //
            this.Location = new Point(Xb, Yb);

            //Screen srn = Screen.PrimaryScreen;
            //int Xb = this.Width;  //좌,우
            //int Yb = this.Height; //좌,우
            //this.Location = new Point((srn.Bounds.Width - Xb) / 2, (srn.Bounds.Height - Yb) / 2);  //좌/우,위/아래


            for (int y = 0; y <= chk_item_group.Length - 1; y++)
            {
                string code = chk_item_group.Substring(y, 1);
                if (y == 0)
                    code_w += " and base_paper_code = '" + code + "'";
                else
                    code_w += " or base_paper_code = '" + code + "'";
            }

            string Query = "select concat(paper_alias,'(',size_alias,')',grain) as hang, row_id from " + DB_Tablename;
            Query += code_w;
            Query += " order by sort_no";
            grid1_view(Query);
        }

        private void grid1_view(string cQuery)
        {
            cell_d cc = new cell_d();
            // 		cQuery	"select concat(paper_alias,'(',size_alias,')',grain) as hang, base_paper_code as code1, row_id, grain from C_paper_size_code order by sort_no"	string

            grid1.Rows.Clear();
            grid1.BorderStyle = BorderStyle.FixedSingle;
            grid1.SelectionMode = SourceGrid.GridSelectionMode.Cell;
            grid1.ColumnsCount = 4;
            grid1.FixedRows = 1;
            grid1.Rows.Insert(0);
            grid1.Rows[0].Height = 24;
            //
            grid1[0, 0] = new MyHeader1("row_id");
            grid1.Columns[0].Visible = false;

            grid1[0, 1] = new MyHeader1("code");
            grid1.Columns[1].Visible = false;
            grid1[0, 2] = new MyHeader1("No");
            grid1[0, 3] = new MyHeader1("항목");


            //
            grid1.Columns[1].Width = 22;
            grid1.Columns[2].Width = 30;
            grid1.Columns[3].Width = 150;

            //
            MySqlConnection DBConn;

            DBConn = new MySqlConnection(Config.DB_con1);
            DBConn.Open();

            var cmd = new MySqlCommand(cQuery, DBConn);
            var myRead = cmd.ExecuteReader();
            // 
            int m = 1;
            while (myRead.Read())
            {
                grid1.Rows.Insert(m);
                grid1.Rows[m].Height = 22;
                //
                grid1[m, 0] = new SourceGrid.Cells.Cell(myRead["row_id"], typeof(string));

                grid1[m, 1] = new SourceGrid.Cells.Cell("", typeof(string));

                grid1[m, 2] = new SourceGrid.Cells.Cell(m.ToString(), typeof(string));
                grid1[m, 2].View = cc.center_cell;
                grid1[m, 2].Editor = cc.disable_cell;

                grid1[m, 3] = new SourceGrid.Cells.Cell(myRead["hang"], typeof(string));
                grid1[m, 3].View = cc.center_cell;
                grid1[m, 3].Editor = cc.disable_cell;


                m++;
            }
           
            myRead.Close();
            DBConn.Close();
        }

        private void Form_501a_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
                this.Close();
        }
    }
}
