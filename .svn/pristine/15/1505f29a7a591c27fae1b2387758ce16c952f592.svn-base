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
    public partial class Form_3062 : Form
    {
        SourceGridControl GridHandle = new SourceGridControl();
        ksgcontrol ks = new ksgcontrol();
        cell_d cc = new cell_d();
        string DB_TableName = "C_extra_charge";
        public Form_3062()
        {
            InitializeComponent();
            GridHandle.SourceGrideInit(grid1, Config.DB_con1);
            ks.ControlInit(Config.DB_con1, null, null, null);
            grid1_view();
        }

        private void Form_3062_ClientSizeChanged(object sender, EventArgs e)
        {
            this.bUp.Size = new System.Drawing.Size(31, (grid1.Size.Height / 2));
            this.bUp.Location = new System.Drawing.Point(grid1.Location.X - 37, grid1.Location.Y);

            int temp = bUp.Size.Height + bUp.Location.Y;
            this.bDown.Location = new System.Drawing.Point(grid1.Location.X - 37, bUp.Size.Height + bUp.Location.Y);
            this.bDown.Size = new System.Drawing.Size(31, (grid1.Size.Height / 2));
        }

        private void grid1_view()
        {
            grid1.Rows.Clear();
            grid1.BorderStyle = BorderStyle.FixedSingle;
            grid1.ColumnsCount = 11;
            grid1.FixedRows = 1;
            grid1.Rows.Insert(0);
            grid1.Rows[0].Height = 24;
            grid1.Rows.Insert(1);
            grid1.Rows[1].Height = 24;

            grid1[0, 0] = new MyHeader1("row_id");
            grid1.Columns[0].Visible = false;
            grid1[0, 1] = new MyHeader1("√");
            grid1[0, 1].RowSpan = 2;
            grid1[0, 2] = new MyHeader1("No");
            grid1[0, 2].RowSpan = 2;
            grid1[0, 3] = new MyHeader1("무게");
            grid1[0, 3].ColumnSpan = 2;
            grid1[0, 5] = new MyHeader1("부수");
            grid1[0, 5].ColumnSpan = 2;

            grid1[0, 7] = new MyHeader1("할증률 [ x ]");
            grid1[0, 7].RowSpan = 2;
            grid1[0, 8] = new MyHeader1("오시 [ + ]");
            grid1[0, 8].RowSpan = 2;
            grid1.Columns[8].Visible = false;
            grid1[0, 9] = new MyHeader1("기본금액");
            grid1[0, 9].RowSpan = 2;
            grid1[0, 10] = new MyHeader1("sort");
            grid1[0, 10].RowSpan = 2;
            grid1.Columns[10].Visible = false;

            grid1[1, 3] = new MyHeader1("이상");
            grid1[1, 4] = new MyHeader1("미만");
            grid1[1, 5] = new MyHeader1("이상");
            grid1[1, 6] = new MyHeader1("미만");
            

            grid1.Columns[1].Width = 25;
            grid1.Columns[2].Width = 40;
            grid1.Columns[3].Width = 100;
            grid1.Columns[4].Width = 100;
            grid1.Columns[5].Width = 100;
            grid1.Columns[6].Width = 100;
            grid1.Columns[7].Width = 100;
            grid1.Columns[8].Width = 100;
            grid1.Columns[9].Width = 100;

            MySqlConnection DBConn;
            DBConn = new MySqlConnection(Config.DB_con1);
            DBConn.Open();

            string cQuery = "select * from " + DB_TableName;

            var cmd = new MySqlCommand(cQuery, DBConn);
            var myRead = cmd.ExecuteReader();

            int m = 2;
            while(myRead.Read())
            {
                grid1.Rows.Insert(m);
                grid1.Rows[m].Height = 22;
                //
                grid1[m, 0] = new SourceGrid.Cells.Cell(myRead["row_id"], typeof(string));
                grid1[m, 1] = new SourceGrid.Cells.CheckBox(null, false);

                grid1[m, 2] = new SourceGrid.Cells.Cell((m-1).ToString(), typeof(string));  //no
                grid1[m, 2].View = cc.center_cell;
                grid1[m, 2].Editor = cc.disable_cell;

                grid1[m, 3] = new SourceGrid.Cells.Cell(myRead["weight_more"], typeof(string));
                grid1[m, 3].View = cc.int_cell;

                grid1[m, 4] = new SourceGrid.Cells.Cell(myRead["weight_under"], typeof(string));
                grid1[m, 4].View = cc.int_cell;

                grid1[m, 5] = new SourceGrid.Cells.Cell(myRead["boosu_more"], typeof(string));
                grid1[m, 5].View = cc.int_cell;

                grid1[m, 6] = new SourceGrid.Cells.Cell(myRead["boosu_under"], typeof(string));
                grid1[m, 6].View = cc.int_cell;

                grid1[m, 7] = new SourceGrid.Cells.Cell(myRead["charge"], typeof(string));
                grid1[m, 7].View = cc.int_cell;

                grid1[m, 8] = new SourceGrid.Cells.Cell(myRead["osi"], typeof(string));
                grid1[m, 8].View = cc.int_cell;

                grid1[m, 9] = new SourceGrid.Cells.Cell(myRead["price"], typeof(string));
                grid1[m, 9].View = cc.int_cell;

                grid1[m, 10] = new SourceGrid.Cells.Cell(myRead["sort"], typeof(string));
                grid1[m, 10].View = cc.int_cell;

                m++;
            }
            myRead.Close();
            DBConn.Close();
        }

        private void Form_3062_Load(object sender, EventArgs e)
        {
            Screen srn = Screen.PrimaryScreen;
            int Xb = this.Width;  //좌,우
            this.Location = new Point((srn.Bounds.Width - Xb) / 2, 1);  //좌/우,위/아래

            SourceGrid.Cells.Controllers.CustomEvents val_c1 = new SourceGrid.Cells.Controllers.CustomEvents();
            val_c1.ValueChanged += new EventHandler(ValueChangedEvent1);
            grid1.Controller.AddController(val_c1);

        }

        private void ValueChangedEvent1(object sender, EventArgs e)
        {
            string Query = "";
            int pos = grid1.Selection.ActivePosition.Column;
            int row = grid1.Selection.ActivePosition.Row;
            string dat = grid1[row, pos].ToString().Trim();
            string row_no = grid1[row, 0].ToString().Trim(); //row_id 

            if (pos == 3)
                Query = "update " + DB_TableName + " set weight_more = '" + dat + "' where row_id = " + row_no;
            if(pos == 4)
                Query = "update " + DB_TableName + " set weight_under = '" + dat + "' where row_id = " + row_no;
            if(pos == 5)
                Query = "update " + DB_TableName + " set boosu_more = '" + dat + "' where row_id = " + row_no;
            if(pos == 6)
                Query = "update " + DB_TableName + " set boosu_under = '" + dat + "' where row_id = " + row_no;
            if (pos == 7)
                Query = "update " + DB_TableName + " set charge = '" + dat + "' where row_id = " + row_no;
            if (pos == 8)
                Query = "update " + DB_TableName + " set osi = '" + dat + "' where row_id = " + row_no;
            if (pos == 9)
                Query = "update " + DB_TableName + " set price = '" + dat + "' where row_id = " + row_no;


            if (Query != "")
                ks.DataUpdate(Query);

        }

        private void bUp_Click(object sender, EventArgs e)
        {
            GridHandle.ChkMoveUp(2, 1, 0, 10, "sort", 2, DB_TableName);
        }

        private void bDown_Click(object sender, EventArgs e)
        {
            GridHandle.ChkMoveDown(2, 1, 0, 10, "sort", 2, DB_TableName);
        }

        private void bAdd_Click(object sender, EventArgs e)
        {
            MySqlConnection DBConn;
            DBConn = new MySqlConnection(Config.DB_con1);
            DBConn.Open();
            string Query = "select max(sort) from " + DB_TableName;
            var cmd = new MySqlCommand(Query, DBConn);
            var myRead = cmd.ExecuteReader();
            myRead.Read();
            string sort_temp = myRead["max(sort)"].ToString();
            myRead.Close();
            DBConn.Close();
            int max_sort = 0;
            if(sort_temp != "")
                max_sort = (Convert.ToInt32(sort_temp) + 1);

            Query = "insert into " + DB_TableName + "(row_id,sort) values('', " + max_sort + ")";
            string add_row_id = ks.DataUpdate(Query);

            int m = grid1.RowsCount;
            grid1.Rows.Insert(m);
            grid1.Rows[m].Height = 22;

            grid1[m, 0] = new SourceGrid.Cells.Cell(add_row_id, typeof(string));
            grid1[m, 1] = new SourceGrid.Cells.CheckBox(null, false);

            grid1[m, 2] = new SourceGrid.Cells.Cell((m-1).ToString(), typeof(string));  //no
            grid1[m, 2].View = cc.center_cell;
            grid1[m, 2].Editor = cc.disable_cell;

            grid1[m, 3] = new SourceGrid.Cells.Cell("", typeof(string));
            grid1[m, 3].View = cc.int_cell;

            grid1[m, 4] = new SourceGrid.Cells.Cell("", typeof(string));
            grid1[m, 4].View = cc.int_cell;

            grid1[m, 5] = new SourceGrid.Cells.Cell("", typeof(string));
            grid1[m, 5].View = cc.int_cell;

            grid1[m, 6] = new SourceGrid.Cells.Cell("", typeof(string));
            grid1[m, 6].View = cc.int_cell;

            grid1[m, 7] = new SourceGrid.Cells.Cell("", typeof(string));
            grid1[m, 7].View = cc.int_cell;

            grid1[m, 8] = new SourceGrid.Cells.Cell("", typeof(string));
            grid1[m, 8].View = cc.int_cell;

            grid1[m, 9] = new SourceGrid.Cells.Cell("", typeof(string));
            grid1[m, 9].View = cc.int_cell;

            grid1[m, 10] = new SourceGrid.Cells.Cell(max_sort, typeof(string));
            grid1[m, 10].View = cc.int_cell;
            var position = new SourceGrid.Position(grid1.RowsCount - 1, 1);
            grid1.Selection.Focus(position, true);
        }

        private void bCopy_Click(object sender, EventArgs e)
        {
            int m = grid1.RowsCount;

            for (int i = 0; i < grid1.RowsCount; i++)
            {
                if (grid1[i, 1].ToString() == "True")
                {
                    string row_id = GridHandle.OneDataCopy(DB_TableName, grid1[i, 0].ToString());
                    MySqlConnection DBConn1;
                    DBConn1 = new MySqlConnection(Config.DB_con1);
                    DBConn1.Open();
                    string Query = "select max(sort) from " + DB_TableName;
                    var cmd1 = new MySqlCommand(Query, DBConn1);
                    var myRead1 = cmd1.ExecuteReader();
                    myRead1.Read();
                    string sort_temp = myRead1["max(sort)"].ToString();
                    myRead1.Close();
                    DBConn1.Close();
                    int max_sort = (Convert.ToInt32(sort_temp) + 1);

                    Query = "update " + DB_TableName + " set sort = " + max_sort + " where row_id = " + row_id;
                    ks.DataUpdate(Query);

                    MySqlConnection DBConn;
                    DBConn = new MySqlConnection(Config.DB_con1);
                    DBConn.Open();
                    Query = "select * from " + DB_TableName;
                    var cmd = new MySqlCommand(Query, DBConn);
                    var myRead = cmd.ExecuteReader();
                    myRead.Read();
                    grid1.Rows.Insert(m);
                    grid1.Rows[m].Height = 22;
                    //
                    grid1[m, 0] = new SourceGrid.Cells.Cell(row_id, typeof(string));

                    grid1[m, 1] = new SourceGrid.Cells.CheckBox(null, false);

                    grid1[m, 2] = new SourceGrid.Cells.Cell((m-1).ToString(), typeof(string));  //no
                    grid1[m, 2].View = cc.center_cell;
                    grid1[m, 2].Editor = cc.disable_cell;

                    grid1[m, 3] = new SourceGrid.Cells.Cell(myRead["weight_more"], typeof(string));
                    grid1[m, 3].View = cc.int_cell;

                    grid1[m, 4] = new SourceGrid.Cells.Cell(myRead["weight_under"], typeof(string));
                    grid1[m, 4].View = cc.int_cell;

                    grid1[m, 5] = new SourceGrid.Cells.Cell(myRead["boosu_more"], typeof(string));
                    grid1[m, 5].View = cc.int_cell;

                    grid1[m, 6] = new SourceGrid.Cells.Cell(myRead["boosu_under"], typeof(string));
                    grid1[m, 6].View = cc.int_cell;

                    grid1[m, 7] = new SourceGrid.Cells.Cell(myRead["charge"], typeof(string));
                    grid1[m, 7].View = cc.int_cell;

                    grid1[m, 8] = new SourceGrid.Cells.Cell(myRead["osi"], typeof(string));
                    grid1[m, 8].View = cc.int_cell;

                    grid1[m, 9] = new SourceGrid.Cells.Cell(myRead["price"], typeof(string));
                    grid1[m, 9].View = cc.int_cell;

                    grid1[m, 10] = new SourceGrid.Cells.Cell(myRead["sort"], typeof(string));
                    grid1[m, 10].View = cc.int_cell;
                    m++;
                    myRead.Close();
                    DBConn.Close();
                    grid1.Refresh();
                }
            }
            var position = new SourceGrid.Position(m - 1, 1);
            grid1.Selection.Focus(position, true);
        }

        private void bDel_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("삭제하시겠습니까?", "메세지창", MessageBoxButtons.YesNo) == DialogResult.Yes)
                GridHandle.ChkDataDelete(DB_TableName, 2, 0, 1);
        }
    }
}
