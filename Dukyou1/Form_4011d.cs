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
    public partial class Form_4011d : Form
    {
        cell_d cc = new cell_d();
        string DB_TableName_mac = "C_mac_address";
        SourceGridControl GridHandle = new SourceGridControl();

        private int Xb = 0;
        private int Yb = 0;
        public Form_4011d(Button bt)
        {
            InitializeComponent();
            Xb = bt.PointToScreen(Location).X;  //좌,우
            Yb = bt.PointToScreen(Location).Y + bt.Size.Height;  //위,아래
            GridHandle.SourceGrideInit(grid1, Config.DB_con1);
            string cQuery = "select * from " + DB_TableName_mac + " where com_id = 0 and mem_id = 0";
            grid1_view(cQuery);
        }

        private void grid1_view(string Query)
        {
            int m = 0;

            grid1.Rows.Clear();

            grid1.BorderStyle = BorderStyle.FixedSingle;
            grid1.ColumnsCount = 7;
            grid1.FixedRows = 1;

            grid1.Rows.Insert(0);

            grid1.Rows[0].Height = 26;

            grid1[m, 0] = new MyHeader1("row_id");
            grid1.Columns[0].Visible = false;

            grid1[m, 1] = new MyHeader1("√");

            grid1[m, 2] = new MyHeader1("No");
            grid1[m, 3] = new MyHeader1("mac_별칭");
            grid1.Columns[3].Visible = false;
            grid1[m, 4] = new MyHeader1("접속현황");
            grid1.Columns[4].Visible = false;
            grid1[m, 5] = new MyHeader1("허용여부");

            grid1[m, 6] = new MyHeader1("맥주소");
            

            m++;

            var DBConn = new MySqlConnection(Config.DB_con1);
            DBConn.Open();
            var cmd = new MySqlCommand(Query, DBConn);

            var myRead = cmd.ExecuteReader();

            grid1.Columns[1].Width = 20;
            grid1.Columns[2].Width = 25;
            grid1.Columns[3].Width = 120;
            grid1.Columns[4].Width = 85;
            grid1.Columns[5].Width = 65;
            grid1.Columns[6].Width = 100;

            while (myRead.Read())
            {
                grid1.Rows.Insert(m);
                grid1.Rows[m].Height = 24;

                grid1[m, 0] = new SourceGrid.Cells.Cell(myRead["row_id"], typeof(string));

                grid1[m, 1] = new SourceGrid.Cells.CheckBox(null, false);

                grid1[m, 2] = new SourceGrid.Cells.Cell(m.ToString(), typeof(string));
                grid1[m, 2].View = cc.int_cell;
                grid1[m, 2].Editor = cc.disable_cell;

                grid1[m, 3] = new SourceGrid.Cells.Cell(myRead["mac_alias"], typeof(string));
                grid1[m, 3].View = cc.center_cell;
                grid1[m, 3].Editor = cc.disable_cell;

                if (myRead["n_use"].ToString() == "True")
                    grid1[m, 4] = new SourceGrid.Cells.Cell("사용", typeof(string));
                else
                    grid1[m, 4] = new SourceGrid.Cells.Cell("미사용", typeof(string));

                grid1[m, 4].View = cc.center_cell;
                grid1[m, 4].Editor = cc.disable_cell;

                if (myRead["permit_chk"].ToString() == "True")
                    grid1[m, 5] = new SourceGrid.Cells.Cell("O", typeof(string));
                else
                    grid1[m, 5] = new SourceGrid.Cells.Cell("X", typeof(string));

                grid1[m, 5].View = cc.center_cell;
                grid1[m, 5].Editor = cc.disable_cell;

                grid1[m, 6] = new SourceGrid.Cells.Cell(myRead["mac_address"].ToString(), typeof(string));
                grid1[m, 6].View = cc.center_cell;
                grid1[m, 6].Editor = cc.disable_cell;
                m++;
            }

            myRead.Close();
            DBConn.Close();
        }

        private void bPermit_Click(object sender, EventArgs e)
        {
            string Query = "";

            for (int i = 1; i < grid1.RowsCount; i++)
            {
                if (grid1[i, 1].Value.Equals(true))
                {
                    Query = "update " + DB_TableName_mac + " set permit_chk = 1 where mac_address = '" + grid1[i, 6].ToString() + "'";
                    GridHandle.DataUpdate(Query);

                    for (int m = 1; m < grid1.RowsCount; m++)
                    {
                        if (grid1[m, 6].ToString() == grid1[i, 6].ToString())
                        {
                            grid1[m, 1] = new SourceGrid.Cells.CheckBox(null, false);

                            grid1[m, 5] = new SourceGrid.Cells.Cell("O", typeof(string));

                            grid1[m, 5].View = cc.center_cell;
                            grid1[m, 5].Editor = cc.disable_cell;
                        }
                    }
                }
                grid1.Refresh();
            }

            MessageBox.Show("허용되었습니다");
        }

        private void bDel_Click(object sender, EventArgs e)
        {
            string Query = "";

            for (int i = 1; i < grid1.RowsCount; i++)
            {
                if (grid1[i, 1].Value.Equals(true))
                {
                    Query = "update " + DB_TableName_mac + " set permit_chk = 0 where mac_address = '" + grid1[i, 6].ToString() + "'";
                    GridHandle.DataUpdate(Query);

                    for (int m = 1; m < grid1.RowsCount; m++)
                    {
                        if (grid1[m, 6].ToString() == grid1[i, 6].ToString())
                        {
                            grid1[m, 1] = new SourceGrid.Cells.CheckBox(null, false);

                            grid1[m, 5] = new SourceGrid.Cells.Cell("X", typeof(string));

                            grid1[m, 5].View = cc.center_cell;
                            grid1[m, 5].Editor = cc.disable_cell;
                        }
                    }
                }
            }
            grid1.Refresh();

            MessageBox.Show("불허 처리 되었습니다");
        }

        private void rbPermit_CheckedChanged(object sender, EventArgs e)
        {
            string Query = "select * from " + DB_TableName_mac + " where permit_chk = 1 and com_id = 0 and mem_id = 0";
            grid1_view(Query);
        }

        private void rbDel_CheckedChanged(object sender, EventArgs e)
        {
            string Query = "select * from " + DB_TableName_mac + " where permit_chk = 0 and com_id = 0 and mem_id = 0";
            grid1_view(Query);
        }

        private void rbAll_CheckedChanged(object sender, EventArgs e)
        {
            string Query = "select * from " + DB_TableName_mac + " where com_id = 0 and mem_id = 0";
            grid1_view(Query);
        }

        private void Form_4011d_Load(object sender, EventArgs e)
        {
            this.Location = new Point(Xb, Yb);
        }
    }
}
