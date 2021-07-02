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
    public partial class Form_2152 : Form
    {
        ksgcontrol ks = new ksgcontrol();
        SourceGridControl GridHandle = new SourceGridControl();
        SourceGridControl GridHandle2 = new SourceGridControl();
        cell_d cc = new cell_d();
        string TableName_bongto_size = "C_bongto_size";
        string gQuery = "";
        string sQuery = "";
        public Form_2152()
        {
            InitializeComponent();
        }
       // DB gubun : 1가로 2 세로
        private void Form_2152_Load(object sender, EventArgs e)
        {
            GridHandle.SourceGrideInit(grid1, Config.DB_con1);
            GridHandle2.SourceGrideInit(grid2, Config.DB_con1);
            ks.ControlInit(Config.DB_con1, null, null, null);

            SourceGrid.Cells.Controllers.CustomEvents val_c1 = new SourceGrid.Cells.Controllers.CustomEvents();
            val_c1.ValueChanged += new EventHandler(ValueChangedEvent1);
            grid1.Controller.AddController(val_c1);

            SourceGrid.Cells.Controllers.CustomEvents val_c2 = new SourceGrid.Cells.Controllers.CustomEvents();
            val_c2.ValueChanged += new EventHandler(ValueChangedEvent2);
            grid2.Controller.AddController(val_c2);


            string[] bongto_type = new string[] { "대중소", "일반형(편지봉투)", "자켓형", "안내형(카드봉투)" };
            GridHandle.InputComboItem(bongto_type);

            string[] bongto_type2 = new string[] { "대중소", "일반형(편지봉투)", "자켓형", "안내형(카드봉투)" };
            GridHandle2.InputComboItem(bongto_type2);
            gQuery = "select * from " + TableName_bongto_size + " where gubun = 1 order by sort";
            grid1_view(gQuery);
            sQuery = "select * from " + TableName_bongto_size + " where gubun = 2 order by sort";
            grid2_view(sQuery);

        }

        private void ValueChangedEvent1(object sender, EventArgs e)
        {
            string Query = "";
            int pos = grid1.Selection.ActivePosition.Column;
            int row = grid1.Selection.ActivePosition.Row;
            string dat = grid1[row, pos].ToString().Trim();
            string row_no = grid1[row, 0].ToString().Trim(); //row_id 

            string type = "";
            if (dat == "대중소")
                type = "A";
            if (dat == "일반형(편지봉투)")
                type = "B";
            if (dat == "자켓형")
                type = "C";
            if (dat == "안내형(카드봉투)")
                type = "D";
            if (pos == 3)
                Query = "update " + TableName_bongto_size + " set bongto_type = '" + type + "' where row_id = " + row_no;
            if (pos == 4)
                Query = "update " + TableName_bongto_size + " set max_min = '" + dat + "' where row_id = " + row_no;
            if (pos == 5)
                Query = "update " + TableName_bongto_size + " set max = '" + dat + "' where row_id = " + row_no;
            if (pos == 6)
                Query = "update " + TableName_bongto_size + " set min = '" + dat + "' where row_id = " + row_no;
            if (pos == 7)
                Query = "update " + TableName_bongto_size + " set attach_1 = '" + dat + "' where row_id = " + row_no;
            if (pos == 8)
                Query = "update " + TableName_bongto_size + " set attach_2 = '" + dat + "' where row_id = " + row_no;
            
            if (Query != "")
                GridHandle.DataUpdate(Query);
        }
        private void ValueChangedEvent2(object sender, EventArgs e)
        {
            string Query = "";
            int pos = grid2.Selection.ActivePosition.Column;
            int row = grid2.Selection.ActivePosition.Row;
            string dat = grid2[row, pos].ToString().Trim();
            string row_no = grid2[row, 0].ToString().Trim(); //row_id 

            string type = "";
            if (dat == "대중소")
                type = "A";
            if (dat == "일반형(편지봉투)")
                type = "B";
            if (dat == "자켓형")
                type = "C";
            if (dat == "안내형(카드봉투)")
                type = "D";
            if (pos == 3)
                Query = "update " + TableName_bongto_size + " set bongto_type = '" + type + "' where row_id = " + row_no;
            if (pos == 4)
                Query = "update " + TableName_bongto_size + " set max_min = '" + dat + "' where row_id = " + row_no;
            if (pos == 5)
                Query = "update " + TableName_bongto_size + " set max = '" + dat + "' where row_id = " + row_no;
            if (pos == 6)
                Query = "update " + TableName_bongto_size + " set min = '" + dat + "' where row_id = " + row_no;
            if (pos == 7)
                Query = "update " + TableName_bongto_size + " set attach_1 = '" + dat + "' where row_id = " + row_no;

            if (Query != "")
                GridHandle.DataUpdate(Query);
        }

        private void grid1_view(string Query)
        {
            grid1.Rows.Clear();
            grid1.BorderStyle = BorderStyle.FixedSingle;
            grid1.ColumnsCount = 10;
            grid1.FixedRows = 1;
            grid1.Rows.Insert(0);
            grid1.Rows[0].Height = 60;

            grid1[0, 0] = new MyHeader1("row_id");
            grid1.Columns[0].Visible = false;
            grid1[0, 1] = new MyHeader1("√");
            grid1.Columns[1].Visible = true;
            grid1[0, 2] = new MyHeader1("No");
            grid1[0, 3] = new MyHeader1("봉투종류");
            grid1[0, 4] = new MyHeader1("최소 [N]\r\n최대 [M]");
            grid1[0, 5] = new MyHeader1("< 가로\r\n[초과]");
            grid1[0, 6] = new MyHeader1("가로 ≤\r\n[이하]");
            grid1[0, 7] = new MyHeader1("대중소 [상]\r\n일반형 [상]\r\n자켓형 [좌]");
            grid1[0, 8] = new MyHeader1("대중소 [하]\r\n일반형 [하]\r\n자켓형 [우]");
            grid1[0, 9] = new MyHeader1("sort");
            grid1.Columns[9].Visible = false;


            grid1.Columns[1].Width = 25;
            grid1.Columns[2].Width = 40;
            grid1.Columns[3].Width = 150;
            grid1.Columns[4].Width = 60;
            grid1.Columns[5].Width = 60;
            grid1.Columns[6].Width = 60;
            grid1.Columns[7].Width = 90;
            grid1.Columns[8].Width = 90;

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
                //
                grid1[m, 0] = new SourceGrid.Cells.Cell(myRead["row_id"], typeof(string));
                grid1[m, 1] = new SourceGrid.Cells.CheckBox(null, false);

                grid1[m, 2] = new SourceGrid.Cells.Cell((m).ToString(), typeof(string));  //no
                grid1[m, 2].View = cc.center_cell;
                grid1[m, 2].Editor = cc.disable_cell;

                string temp = myRead["bongto_type"].ToString();
                if (temp == "A")
                    temp = "대중소";
                if (temp == "B")
                    temp = "일반형(편지봉투)";
                if (temp == "C")
                    temp = "자켓형";
                if (temp == "D")
                    temp = "안내형(카드봉투)";

                grid1[m, 3] = new SourceGrid.Cells.Cell(temp, typeof(string));
                grid1[m, 3].View = cc.center_cell;
                grid1[m, 3].Editor = GridHandle.CbBox[0];

                grid1[m, 4] = new SourceGrid.Cells.Cell(myRead["max_min"].ToString(), typeof(string));
                grid1[m, 4].View = cc.center_cell;

                grid1[m, 5] = new SourceGrid.Cells.Cell(Convert.ToInt32(myRead["max"].ToString()), typeof(int));
                grid1[m, 5].View = cc.int_cell;

                grid1[m, 6] = new SourceGrid.Cells.Cell(Convert.ToInt32(myRead["min"].ToString()), typeof(int));
                grid1[m, 6].View = cc.int_cell;

                grid1[m, 7] = new SourceGrid.Cells.Cell(Convert.ToInt32(myRead["attach_1"].ToString()), typeof(int));
                grid1[m, 7].View = cc.int_cell;

                grid1[m, 8] = new SourceGrid.Cells.Cell(Convert.ToInt32(myRead["attach_2"].ToString()), typeof(int));
                grid1[m, 8].View = cc.int_cell;

                grid1[m, 9] = new SourceGrid.Cells.Cell(myRead["sort"].ToString(), typeof(string));
                m++;
            }
            myRead.Close();
            DBConn.Close();
        }
        private void grid2_view(string Query)
        {
            grid2.Rows.Clear();
            grid2.BorderStyle = BorderStyle.FixedSingle;
            grid2.ColumnsCount = 9;
            grid2.FixedRows = 1;
            grid2.Rows.Insert(0);
            grid2.Rows[0].Height = 60;

            grid2[0, 0] = new MyHeader1("row_id");
            grid2.Columns[0].Visible = false;
            grid2[0, 1] = new MyHeader1("√");
            grid2.Columns[1].Visible = true;
            grid2[0, 2] = new MyHeader1("No");
            grid2[0, 3] = new MyHeader1("봉투종류");
            grid2[0, 4] = new MyHeader1("최소 [N]\r\n최대 [M]");
            grid2[0, 5] = new MyHeader1("< 세로\r\n[초과]");
            grid2[0, 6] = new MyHeader1("세로 ≤\r\n[이하]");
            grid2[0, 7] = new MyHeader1("가산치");
            grid2[0, 8] = new MyHeader1("sort");
            grid2.Columns[8].Visible = false;


            grid2.Columns[1].Width = 25;
            grid2.Columns[2].Width = 40;
            grid2.Columns[3].Width = 150;
            grid2.Columns[4].Width = 60;
            grid2.Columns[5].Width = 60;
            grid2.Columns[6].Width = 60;
            grid2.Columns[7].Width = 90;

            MySqlConnection DBConn;
            DBConn = new MySqlConnection(Config.DB_con1);
            DBConn.Open();

            var cmd = new MySqlCommand(Query, DBConn);
            var myRead = cmd.ExecuteReader();

            int m = 1;

            while (myRead.Read())
            {
                grid2.Rows.Insert(m);
                grid2.Rows[m].Height = 22;
                //
                grid2[m, 0] = new SourceGrid.Cells.Cell(myRead["row_id"], typeof(string));
                grid2[m, 1] = new SourceGrid.Cells.CheckBox(null, false);

                grid2[m, 2] = new SourceGrid.Cells.Cell((m).ToString(), typeof(string));  //no
                grid2[m, 2].View = cc.center_cell;
                grid2[m, 2].Editor = cc.disable_cell;

                string temp = myRead["bongto_type"].ToString();
                if (temp == "A")
                    temp = "대중소";
                if (temp == "B")
                    temp = "일반형(편지봉투)";
                if (temp == "C")
                    temp = "자켓형";
                if (temp == "D")
                    temp = "안내형(카드봉투)";

                grid2[m, 3] = new SourceGrid.Cells.Cell(temp, typeof(string));
                grid2[m, 3].View = cc.center_cell;
                grid2[m, 3].Editor = GridHandle2.CbBox[0];

                grid2[m, 4] = new SourceGrid.Cells.Cell(myRead["max_min"].ToString(), typeof(string));
                grid2[m, 4].View = cc.center_cell;

                grid2[m, 5] = new SourceGrid.Cells.Cell(Convert.ToInt32(myRead["max"].ToString()), typeof(int));
                grid2[m, 5].View = cc.int_cell;

                grid2[m, 6] = new SourceGrid.Cells.Cell(Convert.ToInt32(myRead["min"].ToString()), typeof(int));
                grid2[m, 6].View = cc.int_cell;

                grid2[m, 7] = new SourceGrid.Cells.Cell(Convert.ToInt32(myRead["attach_1"].ToString()), typeof(int));
                grid2[m, 7].View = cc.int_cell;

                grid2[m, 8] = new SourceGrid.Cells.Cell(myRead["sort"].ToString(), typeof(string));
                m++;
            }
            myRead.Close();
            DBConn.Close();
        }

        private void bAdd_Click(object sender, EventArgs e)
        {
            MySqlConnection DBConn;
            DBConn = new MySqlConnection(Config.DB_con1);
            DBConn.Open();
            string Query = "select max(sort) from " + TableName_bongto_size;
            var cmd = new MySqlCommand(Query, DBConn);
            var myRead = cmd.ExecuteReader();
            myRead.Read();
            string sort_temp = myRead["max(sort)"].ToString();
            myRead.Close();
            DBConn.Close();
            if (sort_temp == "")
                sort_temp = "0";
            int max_sort = (Convert.ToInt32(sort_temp) + 1);

            Query = "insert into " + TableName_bongto_size + "(row_id,sort,gubun) values('', " + max_sort + ",1)";
            string add_row_id = ks.DataUpdate(Query);

            int m = grid1.RowsCount;
            grid1.Rows.Insert(m);
            grid1.Rows[m].Height = 22;

            grid1[m, 0] = new SourceGrid.Cells.Cell(add_row_id, typeof(string));
            grid1[m, 1] = new SourceGrid.Cells.CheckBox(null, false);

            grid1[m, 2] = new SourceGrid.Cells.Cell((m).ToString(), typeof(string));  //no
            grid1[m, 2].View = cc.center_cell;
            grid1[m, 2].Editor = cc.disable_cell;

            grid1[m, 3] = new SourceGrid.Cells.Cell("", typeof(string));
            grid1[m, 3].View = cc.center_cell;
            grid1[m, 3].Editor = GridHandle.CbBox[0];

            grid1[m, 4] = new SourceGrid.Cells.Cell("", typeof(string));
            grid1[m, 4].View = cc.center_cell;

            grid1[m, 5] = new SourceGrid.Cells.Cell("", typeof(int));
            grid1[m, 5].View = cc.int_cell;

            grid1[m, 6] = new SourceGrid.Cells.Cell("", typeof(int));
            grid1[m, 6].View = cc.int_cell;

            grid1[m, 7] = new SourceGrid.Cells.Cell("", typeof(int));
            grid1[m, 7].View = cc.int_cell;

            grid1[m, 8] = new SourceGrid.Cells.Cell("", typeof(int));
            grid1[m, 8].View = cc.int_cell;

            grid1[m, 9] = new SourceGrid.Cells.Cell(sort_temp, typeof(string));
            
            var position = new SourceGrid.Position(grid1.RowsCount - 1, 1);
            grid1.Selection.Focus(position, true);
        }

        private void bAdd2_Click(object sender, EventArgs e)
        {
            MySqlConnection DBConn;
            DBConn = new MySqlConnection(Config.DB_con1);
            DBConn.Open();
            string Query = "select max(sort) from " + TableName_bongto_size;
            var cmd = new MySqlCommand(Query, DBConn);
            var myRead = cmd.ExecuteReader();
            myRead.Read();
            string sort_temp = myRead["max(sort)"].ToString();
            myRead.Close();
            DBConn.Close();
            if (sort_temp == "")
                sort_temp = "0";
            int max_sort = (Convert.ToInt32(sort_temp) + 1);

            Query = "insert into " + TableName_bongto_size + "(row_id,sort,gubun) values('', " + max_sort + ",2)";
            string add_row_id = ks.DataUpdate(Query);

            int m = grid2.RowsCount;
            grid2.Rows.Insert(m);
            grid2.Rows[m].Height = 22;

            grid2[m, 0] = new SourceGrid.Cells.Cell(add_row_id, typeof(string));
            grid2[m, 1] = new SourceGrid.Cells.CheckBox(null, false);

            grid2[m, 2] = new SourceGrid.Cells.Cell((m).ToString(), typeof(string));  //no
            grid2[m, 2].View = cc.center_cell;
            grid2[m, 2].Editor = cc.disable_cell;

            grid2[m, 3] = new SourceGrid.Cells.Cell("", typeof(string));
            grid2[m, 3].View = cc.center_cell;
            grid2[m, 3].Editor = GridHandle.CbBox[0];

            grid2[m, 4] = new SourceGrid.Cells.Cell("", typeof(string));
            grid2[m, 4].View = cc.center_cell;

            grid2[m, 5] = new SourceGrid.Cells.Cell("", typeof(int));
            grid2[m, 5].View = cc.int_cell;

            grid2[m, 6] = new SourceGrid.Cells.Cell("", typeof(int));
            grid2[m, 6].View = cc.int_cell;

            grid2[m, 7] = new SourceGrid.Cells.Cell("", typeof(int));
            grid2[m, 7].View = cc.int_cell;

            grid2[m, 8] = new SourceGrid.Cells.Cell(sort_temp, typeof(string));

            var position = new SourceGrid.Position(grid2.RowsCount - 1, 1);
            grid2.Selection.Focus(position, true);
        }

        private void bDel_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("삭제하시겠습니까?", "메세지창", MessageBoxButtons.YesNo) == DialogResult.Yes)
                GridHandle.ChkDataDelete(TableName_bongto_size, 1, 0, 1);
        }

        private void bDel2_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("삭제하시겠습니까?", "메세지창", MessageBoxButtons.YesNo) == DialogResult.Yes)
                GridHandle2.ChkDataDelete(TableName_bongto_size, 1, 0, 1);
        }

        private void bCopy_Click(object sender, EventArgs e)
        {
            int m = grid1.RowsCount;

            for (int i = 0; i < grid1.RowsCount; i++)
            {
                if (grid1[i, 1].ToString() == "True")
                {
                    string row_id = GridHandle.OneDataCopy(TableName_bongto_size, grid1[i, 0].ToString());
                    MySqlConnection DBConn1;
                    DBConn1 = new MySqlConnection(Config.DB_con1);
                    DBConn1.Open();
                    string Query = "select max(sort) from " + TableName_bongto_size;
                    var cmd1 = new MySqlCommand(Query, DBConn1);
                    var myRead1 = cmd1.ExecuteReader();
                    myRead1.Read();
                    string sort_temp = myRead1["max(sort)"].ToString();
                    myRead1.Close();
                    DBConn1.Close();
                    int max_sort = (Convert.ToInt32(sort_temp) + 1);

                    Query = "update " + TableName_bongto_size + " set sort = " + max_sort + " where row_id = " + row_id;
                    ks.DataUpdate(Query);

                    MySqlConnection DBConn;
                    DBConn = new MySqlConnection(Config.DB_con1);
                    DBConn.Open();


                    Query = "select * from " + TableName_bongto_size + " where row_id = '" + row_id + "'";


                    var cmd = new MySqlCommand(Query, DBConn);
                    var myRead = cmd.ExecuteReader();
                    myRead.Read();
                    grid1.Rows.Insert(m);
                    grid1.Rows[m].Height = 22;
                    //
                    grid1[m, 0] = new SourceGrid.Cells.Cell(myRead["row_id"], typeof(string));
                    grid1[m, 1] = new SourceGrid.Cells.CheckBox(null, false);

                    grid1[m, 2] = new SourceGrid.Cells.Cell((m).ToString(), typeof(string));  //no
                    grid1[m, 2].View = cc.center_cell;
                    grid1[m, 2].Editor = cc.disable_cell;

                    string temp = myRead["bongto_type"].ToString();
                    if (temp == "A")
                        temp = "대중소";
                    if (temp == "B")
                        temp = "일반형(편지봉투)";
                    if (temp == "C")
                        temp = "자켓형";
                    if (temp == "D")
                        temp = "안내형(카드봉투)";

                    grid1[m, 3] = new SourceGrid.Cells.Cell(temp, typeof(string));
                    grid1[m, 3].View = cc.center_cell;
                    grid1[m, 3].Editor = GridHandle.CbBox[0];

                    grid1[m, 4] = new SourceGrid.Cells.Cell(myRead["max_min"].ToString(), typeof(string));
                    grid1[m, 4].View = cc.center_cell;

                    grid1[m, 5] = new SourceGrid.Cells.Cell(Convert.ToInt32(myRead["max"].ToString()), typeof(int));
                    grid1[m, 5].View = cc.int_cell;

                    grid1[m, 6] = new SourceGrid.Cells.Cell(Convert.ToInt32(myRead["min"].ToString()), typeof(int));
                    grid1[m, 6].View = cc.int_cell;

                    grid1[m, 7] = new SourceGrid.Cells.Cell(Convert.ToInt32(myRead["attach_1"].ToString()), typeof(int));
                    grid1[m, 7].View = cc.int_cell;

                    grid1[m, 8] = new SourceGrid.Cells.Cell(Convert.ToInt32(myRead["attach_2"].ToString()), typeof(int));
                    grid1[m, 8].View = cc.int_cell;

                    grid1[m, 9] = new SourceGrid.Cells.Cell(myRead["sort"].ToString(), typeof(string));
                    m++;
                    myRead.Close();
                    DBConn.Close();
                    grid1.Refresh();

                }
            }
        }

        private void bCapy2_Click(object sender, EventArgs e)
        {
            int m = grid2.RowsCount;

            for (int i = 0; i < grid2.RowsCount; i++)
            {
                if (grid2[i, 1].ToString() == "True")
                {
                    string row_id = GridHandle.OneDataCopy(TableName_bongto_size, grid2[i, 0].ToString());
                    MySqlConnection DBConn1;
                    DBConn1 = new MySqlConnection(Config.DB_con1);
                    DBConn1.Open();
                    string Query = "select max(sort) from " + TableName_bongto_size;
                    var cmd1 = new MySqlCommand(Query, DBConn1);
                    var myRead1 = cmd1.ExecuteReader();
                    myRead1.Read();
                    string sort_temp = myRead1["max(sort)"].ToString();
                    myRead1.Close();
                    DBConn1.Close();
                    int max_sort = (Convert.ToInt32(sort_temp) + 1);

                    Query = "update " + TableName_bongto_size + " set sort = " + max_sort + " where row_id = " + row_id;
                    ks.DataUpdate(Query);

                    MySqlConnection DBConn;
                    DBConn = new MySqlConnection(Config.DB_con1);
                    DBConn.Open();


                    Query = "select * from " + TableName_bongto_size + " where row_id = '" + row_id + "'";


                    var cmd = new MySqlCommand(Query, DBConn);
                    var myRead = cmd.ExecuteReader();
                    myRead.Read();
                    grid2.Rows.Insert(m);
                    grid2.Rows[m].Height = 22;
                    //
                    grid2[m, 0] = new SourceGrid.Cells.Cell(myRead["row_id"], typeof(string));
                    grid2[m, 1] = new SourceGrid.Cells.CheckBox(null, false);

                    grid2[m, 2] = new SourceGrid.Cells.Cell((m).ToString(), typeof(string));  //no
                    grid2[m, 2].View = cc.center_cell;
                    grid2[m, 2].Editor = cc.disable_cell;

                    string temp = myRead["bongto_type"].ToString();
                    if (temp == "A")
                        temp = "대중소";
                    if (temp == "B")
                        temp = "일반형(편지봉투)";
                    if (temp == "C")
                        temp = "자켓형";
                    if (temp == "D")
                        temp = "안내형(카드봉투)";

                    grid2[m, 3] = new SourceGrid.Cells.Cell(temp, typeof(string));
                    grid2[m, 3].View = cc.center_cell;
                    grid2[m, 3].Editor = GridHandle.CbBox[0];

                    grid2[m, 4] = new SourceGrid.Cells.Cell(myRead["max_min"].ToString(), typeof(string));
                    grid2[m, 4].View = cc.center_cell;

                    grid2[m, 5] = new SourceGrid.Cells.Cell(Convert.ToInt32(myRead["max"].ToString()), typeof(int));
                    grid2[m, 5].View = cc.int_cell;

                    grid2[m, 6] = new SourceGrid.Cells.Cell(Convert.ToInt32(myRead["min"].ToString()), typeof(int));
                    grid2[m, 6].View = cc.int_cell;

                    grid2[m, 7] = new SourceGrid.Cells.Cell(Convert.ToInt32(myRead["attach_1"].ToString()), typeof(int));
                    grid2[m, 7].View = cc.int_cell;

                    grid2[m, 8] = new SourceGrid.Cells.Cell(myRead["sort"].ToString(), typeof(string));
                    m++;
                    myRead.Close();
                    DBConn.Close();
                    grid2.Refresh();

                }
            }
        }

        private void bSearch_Click(object sender, EventArgs e)
        {
            string search_temp = "";
            if (chSize.Checked == true)
            {
                search_temp += " and (bongto_type = 'A'";
                if (chLetter.Checked == true)
                    search_temp += " or bongto_type = 'B'";
                if (chJaket.Checked == true)
                    search_temp += " or bongto_type = 'C'";
                if (chCard.Checked == true)
                    search_temp += " or bongto_type = 'D'";
                search_temp += ")";
            }

            if (chSize.Checked == false && chLetter.Checked == true)
            {
                search_temp += " and (bongto_type = 'B'";
                if (chJaket.Checked == true)
                    search_temp += " or bongto_type = 'C'";
                if (chCard.Checked == true)
                    search_temp += " or bongto_type = 'D'";
                search_temp += ")";
            }
            if (chSize.Checked == false && chLetter.Checked == false && chJaket.Checked == true)
            {
                search_temp += " and (bongto_type = 'C'";
                if (chCard.Checked == true)
                    search_temp += " or bongto_type = 'D'";
                search_temp += ")";
            }
            if (chSize.Checked == false && chLetter.Checked == false && chJaket.Checked == false && chCard.Checked == true)
                search_temp += " and bongto_type = 'D'";



            gQuery = "select * from " + TableName_bongto_size + " where gubun =1 " + search_temp+" order by sort";
            grid1_view(gQuery);
        }

        private void bSearch2_Click(object sender, EventArgs e)
        {
            string search_temp = "";
            if (chSize2.Checked == true)
            {
                search_temp += " and (bongto_type = 'A'";
                if (chLetter2.Checked == true)
                    search_temp += " or bongto_type = 'B'";
                if (chJaket2.Checked == true)
                    search_temp += " or bongto_type = 'C'";
                if (chCard2.Checked == true)
                    search_temp += " or bongto_type = 'D'";
                search_temp += ")";
            }

            if (chSize2.Checked == false && chLetter2.Checked == true)
            {
                search_temp += " and (bongto_type = 'B'";
                if (chJaket2.Checked == true)
                    search_temp += " or bongto_type = 'C'";
                if (chCard2.Checked == true)
                    search_temp += " or bongto_type = 'D'";
                search_temp += ")";
            }
            if (chSize2.Checked == false && chLetter2.Checked == false && chJaket2.Checked == true)
            {
                search_temp += " and (bongto_type = 'C'";
                if (chCard2.Checked == true)
                    search_temp += " or bongto_type = 'D'";
                search_temp += ")";
            }
            if (chSize2.Checked == false && chLetter2.Checked == false && chJaket2.Checked == false && chCard2.Checked == true)
                search_temp += " and bongto_type = 'D'";

            gQuery = "select * from " + TableName_bongto_size + " where gubun = 2 " + search_temp+" order by sort";
            grid2_view(gQuery);
        }

        private void bUp_Click(object sender, EventArgs e)
        {
            GridHandle.ChkMoveUp(1, 1, 0, 9, "sort", 2, TableName_bongto_size);
        }

        private void bDown_Click(object sender, EventArgs e)
        {
            GridHandle.ChkMoveDown(1, 1, 0, 9, "sort", 2, TableName_bongto_size);
        }

        private void bUp2_Click(object sender, EventArgs e)
        {
            GridHandle2.ChkMoveUp(1, 1, 0, 8, "sort", 2, TableName_bongto_size);
        }

        private void bDown2_Click(object sender, EventArgs e)
        {
            GridHandle2.ChkMoveDown(1, 1, 0, 8, "sort", 2, TableName_bongto_size);
        }

    }
}
