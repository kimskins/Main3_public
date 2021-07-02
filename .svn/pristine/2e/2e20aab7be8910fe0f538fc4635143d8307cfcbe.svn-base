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
    public partial class Form_2115a : Form
    {
        SourceGridControl GridHandle = new SourceGridControl();

        string DB_TableName_bmodel = "C_bmodel";
        public Form_2115a()
        {
            InitializeComponent();
        }

        private void Form_2115a_Load(object sender, EventArgs e)
        {
            Screen srn = Screen.PrimaryScreen;
            int Xb = this.Width;  //좌,우
            int Yb = this.Height; //좌,우
            this.Location = new Point((srn.Bounds.Width - Xb) / 2, (srn.Bounds.Height - Yb) / 2);  //좌/우,위/아래

            GridHandle.SourceGrideInit(grid1, Config.DB_con1, Config.Ftp_ip1, Config.Ftp_id1, Config.Ftp_pw1);

            string cQuery = "select row_id, concat(a_code, b_code) as ab_code, bitem from " + DB_TableName_bmodel + " where a_code = '16' order by b_code";
            Grid_View(cQuery);
        }

        private void Grid_View(string cQuery)
        {
            cell_d cc = new cell_d();
            // 
            grid1.Rows.Clear();
            grid1.BorderStyle = BorderStyle.FixedSingle;
            grid1.SelectionMode = SourceGrid.GridSelectionMode.Cell;
            grid1.ColumnsCount = 5;
            grid1.FixedRows = 1;
            grid1.Rows.Insert(0);
            grid1.Rows[0].Height = 24;
            //
            grid1[0, 0] = new MyHeader1("row_id");
            grid1.Columns[0].Visible = false;

            grid1[0, 1] = new MyHeader1("√");

            grid1[0, 2] = new MyHeader1("No");

            grid1[0, 3] = new MyHeader1("ab_code");

            grid1[0, 4] = new MyHeader1("중분류");

            //
            grid1.Columns[1].Width = 22;
            grid1.Columns[2].Width = 22;
            grid1.Columns[3].Width = 60;
            grid1.Columns[4].Width = 120;
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
                grid1[m, 1] = new SourceGrid.Cells.CheckBox(null, false);

                grid1[m, 2] = new SourceGrid.Cells.Cell(m.ToString(), typeof(string));
                grid1[m, 2].View = cc.center_cell;
                grid1[m, 2].Editor = cc.disable_cell;

                grid1[m, 3] = new SourceGrid.Cells.Cell(myRead["ab_code"], typeof(string));
                grid1[m, 3].View = cc.center_cell;
                grid1[m, 3].Editor = cc.disable_cell;

                grid1[m, 4] = new SourceGrid.Cells.Cell(myRead["bitem"], typeof(string));
                grid1[m, 4].View = cc.center_cell;
                grid1[m, 4].Editor = cc.disable_cell;

                m++;
            }
            myRead.Close();
            DBConn.Close();
        }

        private void bComplete_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
        }

        private void bClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
