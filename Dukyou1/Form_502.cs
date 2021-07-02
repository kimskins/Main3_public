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
    public partial class Form_502 : Form
    {
        string DB_TableName_hcustomer = "C_hcustomer";
        string DB_TableName_paper_hcust = "C_paper_hcust_manage";
        string DB_TableName_paper = "C_paper";
        string DB_TableName_hang = "hang_manage";
        string DB_TableName_grade = "C_paper_grade";
        string DB_TableName_each = "C_paper_each";

        string row_id_temp = "90";
        string group_code = "";

        DataTable p_grade = new DataTable();
      
        ksgcontrol ks = new ksgcontrol();
        SourceGridControl GridHandle = new SourceGridControl();
        cell_d cc = new cell_d();
        SourceGrid.Cells.Views.Cell cell_temp;      //우측셀

        //string db_con = Config.DB_con1;

        public Form_502()
        {
            InitializeComponent();
            
            GridHandle.SourceGrideInit(grid1, Config.DB_con1);
            ks.ControlInit(Config.DB_con1, null, null, null);
            cell_temp = new SourceGrid.Cells.Views.Cell();
            cell_temp.TextAlignment = DevAge.Drawing.ContentAlignment.MiddleRight;
            cell_temp.BackColor = Color.FromArgb(254, 207, 208);
        }
       
        private void Form_501_Load(object sender, EventArgs e)
        {
            Screen srn = Screen.PrimaryScreen;
            int Xb = this.Width;  //좌,우
            this.Location = new Point((srn.Bounds.Width - Xb) / 2, 1);  //좌/우,위/아래
            this.KeyPreview = true;
            
            insert_cb();
            SourceGrid.Cells.Controllers.CustomEvents val_c2 = new SourceGrid.Cells.Controllers.CustomEvents();
            val_c2.ValueChanged += new EventHandler(values_Change2);
            grid2.Controller.AddController(val_c2);
            hang_chk();
            grid2_view(Config.DB_con1);
        }
        public void hang_chk()
        {
            sync sy = new sync();
            string Query = "select row_id, hang_code1 from " + DB_TableName_grade + " where client_id = 0 and hcust_id = " + row_id_temp;
            sy.dt(Config.DB_con1, p_grade, Query);

            DataRow[] grade_dr;
             MySqlConnection DBConn;
            DBConn = new MySqlConnection(Config.DB_con1);
            DBConn.Open();
            Query = "select row_id, class, code1 from " + DB_TableName_hang + " where class = '%분류'";
            var cmd = new MySqlCommand(Query, DBConn);
            var myRead = cmd.ExecuteReader();
            while(myRead.Read())
            {
                string code = myRead["code1"].ToString();
                grade_dr = p_grade.Select("hang_code1 = '" + code + "'");

                if(grade_dr.Length == 0)
                {
                    string uQuery = "insert into " + DB_TableName_grade + "(client_id, hcust_id, hang_code1) values(0,'" + row_id_temp + "', '" + code + "')";
                    ks.DataUpdate(uQuery);
                }
            }
            DBConn.Close();
            myRead.Close();
        }

        private void grid1_view(string Query)
        {
            grid1.Rows.Clear();
            grid1.BorderStyle = BorderStyle.FixedSingle;
            grid1.SelectionMode = SourceGrid.GridSelectionMode.Row;
            grid1.ColumnsCount = 23;     // 만약 그리드의 컬럼순서가 바뀌게 되면 503a의 소스도 같이 수정해줘야한다. 엄마의 grid를 가지고 작업을 한다.
            grid1.FixedRows = 2;
            grid1.Rows.Insert(0);
            grid1.Rows[0].Height = 24;
            grid1.Rows.Insert(1);
            grid1.Rows[1].Height = 24;
            //
            grid1[0, 0] = new MyHeader1("row_id");
            grid1.Columns[0].Visible = false;
            grid1[0, 0].RowSpan = 2;

            grid1[0, 1] = new MyHeader1("√");
            grid1[0, 1].RowSpan = 2;

            grid1[0, 2] = new MyHeader1("No");
            grid1[0, 2].RowSpan = 2;

            grid1[0, 3] = new MyHeader1("% 분류");
            grid1[0, 3].RowSpan = 2;

            grid1[0, 4] = new MyHeader1("종이그룹");
            grid1[0, 4].RowSpan = 2;

            grid1[0, 5] = new MyHeader1("size");
            grid1.Columns[5].Visible = false;
            grid1[0, 5].RowSpan = 2;

            grid1[0, 6] = new MyHeader1("무게(g)");
            grid1[0, 6].RowSpan = 2;

            grid1[0, 7] = new MyHeader1("종이명");
            grid1[0, 7].RowSpan = 2;

            grid1[0, 8] = new MyHeader1("색상");
            grid1[0, 8].RowSpan = 2;

            grid1[0, 9] = new MyHeader1("제지사");
            grid1[0, 9].RowSpan = 2;

            grid1[0, 10] = new MyHeader1("공시단가");
            grid1[0, 10].RowSpan = 2;

            grid1[0, 11] = new MyHeader1("사이즈정보");
            grid1[0, 11].RowSpan = 2;

            grid1[0, 12] = new MyHeader1("두께");
            grid1[0, 12].RowSpan = 2;

            grid1[0, 13] = new MyHeader1("제공");
            grid1[0, 13].RowSpan = 2;

            grid1[0, 14] = new MyHeader1("속(장)");
            grid1[0, 14].RowSpan = 2;

            grid1[0, 15] = new MyHeader1("톤수");
            grid1[0, 15].RowSpan = 2;

            //

            grid1[0, 16] = new MyHeader1("0 < 무게 < 1T");
            grid1[0, 16].ColumnSpan = 3;
            grid1[0, 19] = new MyHeader1("1T ≤ 무게 < 3T");
            grid1[0, 20] = new MyHeader1("3T ≤ 무게");
            grid1[0, 21] = new MyHeader1("each_row");
            grid1.Columns[21].Visible = false;
            grid1[0, 21].RowSpan = 2;
            grid1[0, 22] = new MyHeader1("톤당%");
            grid1[0, 22].RowSpan = 2;
            //

            grid1[1, 16] = new MyHeader1("재단");
            grid1[1, 17] = new MyHeader1("자투리");
            grid1[1, 18] = new MyHeader1("속단위");
            grid1[1, 19] = new MyHeader1("속단위");
            grid1[1, 20] = new MyHeader1("속단위");

            //
            grid1.Columns[1].Width = 22;
            grid1.Columns[2].Width = 40;
            grid1.Columns[3].Width = 50;
            grid1.Columns[4].Width = 60;
            grid1.Columns[5].Width = 60;
            grid1.Columns[6].Width = 55;
            grid1.Columns[7].Width = 190;
            grid1.Columns[8].Width = 130;
            grid1.Columns[9].Width = 120;
            grid1.Columns[10].Width = 90;
            grid1.Columns[11].Width = 120;
            grid1.Columns[12].Width = 50;
            grid1.Columns[13].Width = 35;
            grid1.Columns[14].Width = 50;
            grid1.Columns[15].Width = 50;


            grid1.Columns[16].Width = 60;
            grid1.Columns[17].Width = 60;
            grid1.Columns[18].Width = 60;
            grid1.Columns[19].Width = 100;
            grid1.Columns[20].Width = 100;
            grid1.Columns[22].Width = 80;
            //
            MySqlConnection DBConn;

            DBConn = new MySqlConnection(Config.DB_con1);
            DBConn.Open();

            var cmd = new MySqlCommand(Query, DBConn);
            var myRead = cmd.ExecuteReader();

            // 
            int m = 2;
            while (myRead.Read())
            {
                grid1.Rows.Insert(m);
                grid1.Rows[m].Height = 22;
                //
                grid1[m, 0] = new SourceGrid.Cells.Cell(myRead["row_id"], typeof(string));
                grid1[m, 1] = new SourceGrid.Cells.CheckBox(null, false);

                grid1[m, 2] = new SourceGrid.Cells.Cell((m-1).ToString(), typeof(string));
                grid1[m, 2].View = cc.center_cell;
                grid1[m, 2].Editor = cc.disable_cell;

                grid1[m, 3] = new SourceGrid.Cells.Cell(myRead["bunryu"], typeof(string));
                grid1[m, 3].View = cc.center_cell;
                grid1[m, 3].Editor = cc.disable_cell;

                grid1[m, 4] = new SourceGrid.Cells.Cell(myRead["pgroup"], typeof(string));
                grid1[m, 4].View = cc.center_cell;
                grid1[m, 4].Editor = cc.disable_cell;

                grid1[m, 5] = new SourceGrid.Cells.Cell(myRead["paper_size_group"], typeof(string));
                grid1[m, 5].Editor = cc.disable_cell;

                grid1[m, 6] = new SourceGrid.Cells.Cell(myRead["paper_weight"], typeof(string));
                grid1[m, 6].View = cc.int_cell;
                grid1[m, 6].Editor = cc.disable_cell;

                grid1[m, 7] = new SourceGrid.Cells.Cell(myRead["paper_name"], typeof(string));
                grid1[m, 7].View = cc.left_cell;
                grid1[m, 7].Editor = cc.disable_cell;

                grid1[m, 8] = new SourceGrid.Cells.Cell(myRead["paper_color"], typeof(string));
                grid1[m, 8].View = cc.left_cell;
                grid1[m, 8].Editor = cc.disable_cell;

                grid1[m, 9] = new SourceGrid.Cells.Cell(myRead["pmake"], typeof(string));
                grid1[m, 9].View = cc.left_cell;
                grid1[m, 9].Editor = cc.disable_cell;

                grid1[m, 10] = new SourceGrid.Cells.Cell(GridHandle.numgetcoma(myRead["notice_price"].ToString()), typeof(string));
                grid1[m, 10].View = cc.int_cell;
                grid1[m, 10].Editor = cc.disable_cell;

                SourceGrid.Cells.Views.Cell captionModel = new SourceGrid.Cells.Views.Cell();
                captionModel.ImageAlignment = DevAge.Drawing.ContentAlignment.MiddleCenter;

                grid1[m, 11] = new SourceGrid.Cells.Cell("");
                grid1[m, 11].Image = Properties.Resources.search_1;
                grid1[m, 11].View = captionModel;
                grid1[m, 11].Editor = cc.disable_cell;

                grid1[m, 12] = new SourceGrid.Cells.Cell(GridHandle.decimaldel(myRead["paper_thick"].ToString()), typeof(string));
                grid1[m, 12].View = cc.left_cell;
                grid1[m, 12].Editor = cc.disable_cell;
                if(myRead["prove_paper_thick"].ToString() == "True")
                    grid1[m, 13] = new SourceGrid.Cells.Cell("O", typeof(string));
                else
                    grid1[m, 13] = new SourceGrid.Cells.Cell("", typeof(string));
                grid1[m, 13].View = cc.center_cell;
                grid1[m, 13].Editor = cc.disable_cell;

                grid1[m, 14] = new SourceGrid.Cells.Cell(myRead["sock"], typeof(string));
                grid1[m, 14].View = cc.center_cell;
                grid1[m, 14].Editor = cc.disable_cell;

                grid1[m, 15] = new SourceGrid.Cells.Cell(myRead["ton_su"], typeof(string));
                grid1[m, 15].View = cc.center_cell;
                grid1[m, 15].Editor = cc.disable_cell;


                grid1[m, 16] = new SourceGrid.Cells.Cell(myRead["cut_0_1"], typeof(string));
                grid1[m, 16].View = cc.int_cell;
                grid1[m, 16].Editor = cc.disable_cell;

                grid1[m, 17] = new SourceGrid.Cells.Cell(myRead["remain_0_1"], typeof(string));
                grid1[m, 17].View = cc.int_cell;
                grid1[m, 17].Editor = cc.disable_cell;

                grid1[m, 18] = new SourceGrid.Cells.Cell(myRead["sock_0_1"], typeof(string));
                grid1[m, 18].View = cc.int_cell;
                grid1[m, 18].Editor = cc.disable_cell;

                grid1[m, 19] = new SourceGrid.Cells.Cell(myRead["sock_1_3"], typeof(string));
                grid1[m, 19].View = cc.int_cell;
                grid1[m, 19].Editor = cc.disable_cell;

                grid1[m, 20] = new SourceGrid.Cells.Cell(myRead["sock_3_"], typeof(string));
                grid1[m, 20].View = cc.int_cell;
                grid1[m, 20].Editor = cc.disable_cell;

                grid1[m, 21] = new SourceGrid.Cells.Cell(myRead["each_row"], typeof(string));

                grid1[m, 22] = new SourceGrid.Cells.Cell(myRead["sock_4"], typeof(string));
                grid1[m, 22].View = cc.int_cell;
                grid1[m, 22].Editor = cc.disable_cell;

                if (grid1[m, 16].ToString() != "" || grid1[m, 17].ToString() != "" || grid1[m, 18].ToString() != "" || grid1[m, 19].ToString() != "" || 
                    grid1[m, 20].ToString() != "" || grid1[m, 22].ToString() != "")
                {
                    for (int i = 16; i < 23; i++)
                    {
                        grid1[m, i].View = cell_temp;
                    }
                }

                m++;
            }
            myRead.Close();
            DBConn.Close();
        }
       

        private void grid2_view(string db_con)
        {
            grid2.Rows.Clear();
            grid2.BorderStyle = BorderStyle.FixedSingle;
            grid2.SelectionMode = SourceGrid.GridSelectionMode.Row;
            grid2.ColumnsCount = 11;
            grid2.FixedRows = 2;
            grid2.Rows.Insert(0);
            grid2.Rows[0].Height = 22;
            grid2.Rows.Insert(1);
            grid2.Rows[1].Height = 22;

            grid2[0, 0] = new MyHeader1("row_id");
            grid2.Columns[0].Visible = false;
            grid2[0, 1] = new MyHeader1("√");
            grid2[0, 1].RowSpan = 2;
            if (rbCs.Checked)
                grid2.Columns[1].Visible = true;
            else
                grid2.Columns[1].Visible = false;

            grid2[0, 2] = new MyHeader1("No");
            grid2[0, 2].RowSpan = 2;
            
            grid2[0, 3] = new MyHeader1("%분류");
            grid2[0, 3].RowSpan = 2;
            grid2[0, 4] = new MyHeader1("0 < 무게 < 1T");
            grid2[0, 4].ColumnSpan = 3;
            grid2[0, 7] = new MyHeader1("1T≤무게<3T");
            grid2[0, 8] = new MyHeader1("3T≤무게");
            grid2[0, 9] = new MyHeader1("hang_code1");
            grid2.Columns[9].Visible = false;
            grid2[0, 10] = new MyHeader1("톤당%");
            grid2[0, 10].RowSpan = 2;
            //               
            grid2[1, 4] = new MyHeader1("재단");
            grid2[1, 5] = new MyHeader1("자투리");
            grid2[1, 6] = new MyHeader1("속단위");
            grid2[1, 7] = new MyHeader1("속단위");
            grid2[1, 8] = new MyHeader1("속단위");

            grid2.Columns[1].Width = 25;
            grid2.Columns[2].Width = 25;
            grid2.Columns[3].Width = 80;
            grid2.Columns[4].Width = 80;
            grid2.Columns[5].Width = 80;
            grid2.Columns[6].Width = 80;
            grid2.Columns[7].Width = 80;
            grid2.Columns[8].Width = 80;
            grid2.Columns[9].Width = 80;
            grid2.Columns[10].Width = 90;

            MySqlConnection DBConn;
            DBConn = new MySqlConnection(db_con);
            DBConn.Open();

            string Query = "";
            if (rbCs.Checked)
            {
                Query = "select b.no, b.hang as hang, a.* from " + DB_TableName_grade + " as a ";
                Query += "left outer join " + DB_TableName_hang + " as b on a.hang_code1 = b.code1 and b.class = '%분류' ";
                Query += " where a.client_id = 0 and a.hcust_id = " + row_id_temp + " and b.hang !='' order by b.no";
            }
            else
            {
                grid2.Columns[10].Visible = false;
                Query = "select row_id, cut_0_1, remain_0_1, sock_0_1, sock_1_3, concat(bun,'그룹') as hang, sock_3 as sock_3_, bun as hang_code1 from " + DB_TableName_grade;
            }
                
            var cmd = new MySqlCommand(Query, DBConn);
            var myRead = cmd.ExecuteReader();

            int m = 2;
            while (myRead.Read())
            {
                grid2.Rows.Insert(m);
                grid2.Rows[m].Height = 22;

                grid2[m, 0] = new SourceGrid.Cells.Cell(myRead["row_id"].ToString(), typeof(string));
                grid2[m, 1] = new SourceGrid.Cells.CheckBox(null, false);
                grid2[m, 2] = new SourceGrid.Cells.Cell(m - 1, typeof(string));
                grid2[m, 2].Editor = cc.disable_cell;
                grid2[m, 2].View = cc.center_cell;

                grid2[m, 3] = new SourceGrid.Cells.Cell(myRead["hang"].ToString(), typeof(string));
                grid2[m, 3].View = cc.center_cell;
                grid2[m, 3].Editor = cc.disable_cell;

                grid2[m, 4] = new SourceGrid.Cells.Cell(myRead["cut_0_1"].ToString(), typeof(string));
                grid2[m, 4].View = cc.center_cell;

                grid2[m, 5] = new SourceGrid.Cells.Cell(myRead["remain_0_1"].ToString(), typeof(string));
                grid2[m, 5].View = cc.center_cell;

                grid2[m, 6] = new SourceGrid.Cells.Cell(myRead["sock_0_1"].ToString(), typeof(string));
                grid2[m, 6].View = cc.center_cell;

                grid2[m, 7] = new SourceGrid.Cells.Cell(myRead["sock_1_3"].ToString(), typeof(string));
                grid2[m, 7].View = cc.center_cell;

                grid2[m, 8] = new SourceGrid.Cells.Cell(myRead["sock_3_"].ToString(), typeof(string));
                grid2[m, 8].View = cc.center_cell;

                grid2[m, 9] = new SourceGrid.Cells.Cell(myRead["hang_code1"].ToString(), typeof(string));

                if (rbCs.Checked)
                {
                    grid2[m, 10] = new SourceGrid.Cells.Cell(myRead["sock_4"].ToString(), typeof(string));
                    grid2[m, 10].View = cc.center_cell;
                }
                m++;
            }
            myRead.Close();
            DBConn.Close();
        }

        public void memo_update()
        {
            string uQuery = "update " + DB_TableName_hcustomer + " set ji_memo = '" + tbMemo.Text + "' where row_id = " + row_id_temp;
            ks.DataUpdate(uQuery);
        }

        private void Form_501_FormClosed(object sender, FormClosedEventArgs e)
        {
            if(rbCs.Checked)
                memo_update();
        }

        private void values_Change2(object sender, EventArgs e)
        {
            string Query = "";
            int row_position = grid2.Selection.ActivePosition.Row;
            int col_position = grid2.Selection.ActivePosition.Column;
            string data = grid2[row_position, col_position].ToString();
            string row_id = grid2[row_position, 0].ToString();

            if (data == "")
                data = "0";

            if (col_position == 4)
                Query = "update " + DB_TableName_grade + " set cut_0_1 = " + data + " where row_id = " + row_id;
            if (col_position == 5)
                Query = "update " + DB_TableName_grade + " set remain_0_1 = " + data + " where row_id = " + row_id;
            if (col_position == 6)
                Query = "update " + DB_TableName_grade + " set sock_0_1 = " + data + " where row_id = " + row_id;
            if (col_position == 7)
                Query = "update " + DB_TableName_grade + " set sock_1_3 = " + data + " where row_id = " + row_id;
            if (col_position == 8)
            {
                if(rbCs.Checked)
                    Query = "update " + DB_TableName_grade + " set sock_3_ = " + data + " where row_id = " + row_id;
                else
                    Query = "update " + DB_TableName_grade + " set sock_3 = " + data + " where row_id = " + row_id;
            }
            if (col_position == 10)
                Query = "update " + DB_TableName_grade + " set sock_4 = " + data + " where row_id = " + row_id;
            //
            if (Query == "")
                return;
            else
                ks.DataUpdate(Query);

        }
        
        private void insert_cb()
        {
            string cQuery = "";
            cQuery = "select hang from " + DB_TableName_hang +" where class = '종이그룹'";
            ks.ComboBoxItemInsert("hang", cbPgroup, cQuery);
            cQuery = "select hang from " + DB_TableName_hang+" where class = '제지사'";
            ks.ComboBoxItemInsert("hang", cbPmake, cQuery);
            cQuery = "select hang from " + DB_TableName_hang + " where class = '%분류'";
            ks.ComboBoxItemInsert("hang", cbBun, cQuery);
            cQuery = "select paper_name from " + DB_TableName_paper + " where favorite = true order by sort_no ";
            ks.ComboBoxItemInsert("paper_name", cbPname, cQuery);

            MySqlConnection DBConn;
            DBConn = new MySqlConnection(Config.DB_con1);
            util.Con_DB_Open(ref DBConn);

            string Query = "select ji_memo from " + DB_TableName_hcustomer + " where row_id = " + row_id_temp;
            var cmd = new MySqlCommand(Query, DBConn);
            var myRead = cmd.ExecuteReader();

            myRead.Read();

            tbMemo.Text = myRead["ji_memo"].ToString();
            myRead.Close();
            DBConn.Close();
        }

        private void bSearch_Click(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            string bun_temp = "";
            string pgroup = "";
            string pname = "";
            string pcolor = "";
            string pmake = "";
            string sock = "";
            string order = "";
            string weight1 = "";
            string weight2 = "";
            string sp = "";
            if (cbJoint.Checked == true)
                sp = " and g.row_id is null";
            if (cbSpecial.Checked == true)
                sp = " and g.row_id != ''";
            if (cbJoint.Checked == true && cbSpecial.Checked == true)
                sp = "";
            if (cbJoint.Checked == false && cbSpecial.Checked == false)
                sp = "";
            if (cbBun.Text != "")
                bun_temp = " and d.hang = '" + cbBun.Text + "'";
            if (cbPgroup.Text != "")
                pgroup = " and e.hang = '" + cbPgroup.Text + "'";
            if (cbWeight1.Text != "")
                weight1 = " and b.paper_weight >= " + cbWeight1.Text;
            else
                weight1 = "";

            if (cbWeight2.Text != "")
                weight2 = " and b.paper_weight <= " + cbWeight2.Text;
            else
                weight2 = "";
            if (cbPname.Text != "")
                pname = " and b.paper_name like '%" + cbPname.Text + "%'";
            if (tbPcolor.Text != "")
                pcolor = " and b.paper_color like '%" + tbPcolor.Text + "%'";
            if (cbPmake.Text != "")
                pmake = " and f.hang = '" + cbPmake.Text + "'";
            if (cbSock.Text != "")
                sock = " and b.sock = '" + cbSock.Text + "'";

            if (rbBunryu.Checked == true)
                order = " order by bunryu, b.paper_weight, b.row_id";
            else if (rbPgroup.Checked == true)
                order = " order by pgroup, b.paper_weight, b.row_id";
            else if (rbPmake.Checked == true)
                order = " order by pmake, b.paper_weight, b.row_id";
            else
                order = " order by b.paper_name, b.paper_weight, b.row_id";

            string cQuery = "select g.row_id as each_row, a.paper_id as row_id, g.*, b.*,d.hang as bunryu, e.hang as pgroup, f.hang as pmake from " + DB_TableName_paper_hcust + " as a ";
            cQuery += " left outer join " + DB_TableName_paper + " as b on a.paper_id = b.row_id";
            cQuery += " left outer join " + DB_TableName_hang + " as d on b.hang_class_code = d.code1 and d.class = '%분류' ";
            cQuery += " left outer join " + DB_TableName_hang + " as e on b.hang_pgroup_code = e.code1 and e.class = '종이그룹'";
            cQuery += " left outer join " + DB_TableName_hang + " as f on b.hang_pmake_code = f.code1 and f.class = '제지사' ";
            cQuery += " left outer join " + DB_TableName_each + " as g on a.paper_id = g.paper_id and g.client_id = 0 ";
            cQuery += " where a.hcust_id = '" + row_id_temp + "' and b.row_id <> -1 " + sp+ bun_temp + pgroup + pname + pcolor + pmake + weight1 + weight2 + sock;
            cQuery += order;

            grid1_view(cQuery);
            this.Cursor = Cursors.Default;
        }

        private void bClear_Click(object sender, EventArgs e)
        {
            cbBun.Enabled = true;
            tbPcolor.Clear();
            cbBun.Text = "";
            cbPgroup.Text = "";
            cbPmake.Text = "";
            cbPname.Text = "";
            cbWeight1.Text = "";
            cbWeight2.Text = "";
            cbSock.Text = "";
        }

       

        private void grid2_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            int row_position = grid2.Selection.ActivePosition.Row;
            int col_position = grid2.Selection.ActivePosition.Column;
            if (row_position == -1)
                return;
            string data = grid2[row_position, col_position].ToString();
            //string hang = grid2[row_position, 3].ToString();
            string hang = grid2[row_position, 9].ToString();
            if (hang == "")
                return;
            
            if (col_position == 3 && rbCs.Checked == true)
            {
                cbBun.Text = grid2[row_position, 3].ToString();
                cbBun.Enabled = false;
                //hang = hang.Substring(0, 2);
                string cQuery = "select g.row_id as each_row, a.paper_id as row_id, g.*, b.*,d.hang as bunryu, e.hang as pgroup, f.hang as pmake from " + DB_TableName_paper_hcust + " as a ";
                cQuery += " left outer join " + DB_TableName_paper + " as b on a.paper_id = b.row_id";
                cQuery += " left outer join " + DB_TableName_hang + " as d on b.hang_class_code = d.code1 and d.class = '%분류' ";
                cQuery += " left outer join " + DB_TableName_hang + " as e on b.hang_pgroup_code = e.code1 and e.class = '종이그룹'";
                cQuery += " left outer join " + DB_TableName_hang + " as f on b.hang_pmake_code = f.code1 and f.class = '제지사' ";
                cQuery += " left outer join " + DB_TableName_each + " as g on a.paper_id = g.paper_id and g.client_id = 0 ";
                cQuery += " where a.hcust_id = " + row_id_temp + " and b.hang_class_code = '" + hang + "' ";
                cQuery += " order by paper_name, b.paper_weight, b.row_id";
                grid1_view(cQuery);
            }
        }

        private void bSave_Click(object sender, EventArgs e)
        {
            memo_update();
            MessageBox.Show("저장하였습니다.");
        }

        private void grid1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            int row_position = grid1.Selection.ActivePosition.Row;
            int col_position = grid1.Selection.ActivePosition.Column;
            if (row_position == -1)
                return;

            string p_size = grid1[row_position, 5].ToString();

            

            if(col_position == 11)
            {
                var rect = grid1.RangeToRectangle(new SourceGrid.Range(grid1.Selection.ActivePosition, grid1.Selection.ActivePosition));
                Form_502a fm = new Form_502a(p_size, rect.Location.X, rect.Location.Y,grid1);
                fm.ShowDialog();
            }
        }

        DataTable each = new DataTable();
        private void bApply_Click(object sender, EventArgs e)
        {
            if (grid1.RowsCount == 0 || grid1.RowsCount == 2)
            {
                MessageBox.Show("종이를 선택 해 주세요");
                return;
            }

            int chk_count = 0;
            int chk_row = 0;
            string data = "";
            string row_temp = "";

            for (int i = 0; i < grid1.RowsCount; i++)
            {
                if (grid1[i, 1].ToString() == "True")
                {
                    chk_row = i;
                    chk_count++;
                }
            }

            if(chk_count == 0)
            {
                MessageBox.Show("종이를 선택 해 주세요");
                return;
            }
            
            Form_502c fm;
            if(chk_count == 1)
            {
                data = grid1[chk_row, 16].ToString() + "#" + grid1[chk_row, 17].ToString() + "#" + grid1[chk_row, 18].ToString() + "#" + grid1[chk_row, 19].ToString() + "#"
                       + grid1[chk_row, 20].ToString() + "#" + grid1[chk_row, 22].ToString();
                fm = new Form_502c(bApply,data);
            }
            else
                fm = new Form_502c(bApply);
            if (fm.ShowDialog() == DialogResult.OK)
            {
                string Query = "select row_id, client_id, hcust_id, paper_id from " + DB_TableName_each;
                sync sy = new sync();
                sy.dt(Config.DB_con1, each, Query);
                
                DataRow[] dr;
                string each_row_temp = "";
                for (int i = 0; i < grid1.RowsCount; i++)
                {
                    if (grid1[i, 1].ToString() == "True")
                    {
                        dr = each.Select("client_id = 0 and hcust_id = " + row_id_temp + " and paper_id = " + grid1[i, 0].ToString());
                        if (dr.Length == 0)
                        {
                            Query = "insert into " + DB_TableName_each + "(client_id, hcust_id, paper_id, cut_0_1, remain_0_1, sock_0_1, sock_1_3, sock_3_) ";
                            Query += " values(0,'" + row_id_temp + "', '" + grid1[i, 0].ToString() + "', '" + fm.cut + "', '" + fm.remain + "', '" + fm.sock01 + "'";
                            Query += ",'" + fm.sock13 + "','" + fm.sock3 + "','" + fm.sock4 + "')";
                            row_temp = ks.DataUpdate(Query);
                            grid1[i, 21] = new SourceGrid.Cells.Cell(row_temp, typeof(string));
                        }
                        else
                            each_row_temp += " or row_id = " + dr[0]["row_id"].ToString();

                        
                        grid1[i, 1] = new SourceGrid.Cells.CheckBox(null, false);
                        if (fm.cut != "")
                            grid1[i, 16] = new SourceGrid.Cells.Cell(fm.cut, typeof(string));
                        grid1[i, 16].View = cell_temp;
                        grid1[i, 16].Editor = cc.disable_cell;

                        if (fm.remain != "")
                            grid1[i, 17] = new SourceGrid.Cells.Cell(fm.remain, typeof(string));
                        grid1[i, 17].View = cell_temp;
                        grid1[i, 17].Editor = cc.disable_cell;

                        if (fm.sock01 != "")
                            grid1[i, 18] = new SourceGrid.Cells.Cell(fm.sock01, typeof(string));
                        grid1[i, 18].View = cell_temp;
                        grid1[i, 18].Editor = cc.disable_cell;

                        if (fm.sock13 != "")
                            grid1[i, 19] = new SourceGrid.Cells.Cell(fm.sock13, typeof(string));
                        grid1[i, 19].View = cell_temp;
                        grid1[i, 19].Editor = cc.disable_cell;

                        if (fm.sock3 != "")
                            grid1[i, 20] = new SourceGrid.Cells.Cell(fm.sock3, typeof(string));
                        grid1[i, 20].View = cell_temp;
                        grid1[i, 20].Editor = cc.disable_cell;

                        if (fm.sock4 != "")
                            grid1[i, 22] = new SourceGrid.Cells.Cell(fm.sock4, typeof(string));
                        grid1[i, 22].View = cell_temp;
                        grid1[i, 22].Editor = cc.disable_cell;
                    }
                }
                if (each_row_temp != "")
                {
                    string w_temp = "";
                    if (fm.cut != "")
                        w_temp += " cut_0_1 = '" + fm.cut + "' ";
                    if (fm.remain != "")
                        w_temp += ", remain_0_1 = '" + fm.remain + "' ";
                    if (fm.sock01 != "")
                        w_temp += ", sock_0_1 = '" + fm.sock01 + "' ";
                    if (fm.sock13 != "")
                        w_temp += ", sock_1_3 = '" + fm.sock13 + "' ";
                    if (fm.sock3 != "")
                        w_temp += ", sock_3_ = '" + fm.sock3 + "' ";
                    if (fm.sock4 != "")
                        w_temp += ", sock_4 = '" + fm.sock4 + "' ";

                    w_temp = w_temp.Substring(1);
                    Query = "update " + DB_TableName_each + " set " + w_temp + " where row_id = -1 " + each_row_temp;
                    ks.DataUpdate(Query);
                }

                grid1.Refresh();
            }
        }


        private void bDel_Click(object sender, EventArgs e)
        {
            int chk_count = 0;

            for (int i = 0; i < grid1.RowsCount; i++)
            {
                if (grid1[i, 1].ToString() == "True")
                    chk_count++;
            }

            if (chk_count == 0)
            {
                MessageBox.Show("종이를 선택 해 주세요");
                return;
            }

            if (MessageBox.Show("삭제하시겠습니까?", "메세지창", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                string temp = "";
                for (int i = 0; i < grid1.RowsCount; i++)
                {
                    if (grid1[i, 1].ToString() == "True")
                    {
                        if (grid1[i, 21].ToString() != "")
                            temp += " or row_id = " + grid1[i, 21].ToString();

                        grid1[i, 1] = new SourceGrid.Cells.CheckBox(null, false);
                        grid1[i, 16] = new SourceGrid.Cells.Cell("", typeof(string));
                        grid1[i, 16].View = cc.int_cell;
                        grid1[i, 16].Editor = cc.disable_cell;

                        grid1[i, 17] = new SourceGrid.Cells.Cell("", typeof(string));
                        grid1[i, 17].View = cc.int_cell;
                        grid1[i, 17].Editor = cc.disable_cell;

                        grid1[i, 18] = new SourceGrid.Cells.Cell("", typeof(string));
                        grid1[i, 18].View = cc.int_cell;
                        grid1[i, 18].Editor = cc.disable_cell;

                        grid1[i, 19] = new SourceGrid.Cells.Cell("", typeof(string));
                        grid1[i, 19].View = cc.int_cell;
                        grid1[i, 19].Editor = cc.disable_cell;

                        grid1[i, 20] = new SourceGrid.Cells.Cell("", typeof(string));
                        grid1[i, 20].View = cc.int_cell;
                        grid1[i, 20].Editor = cc.disable_cell;

                        grid1[i, 22] = new SourceGrid.Cells.Cell("", typeof(string));
                        grid1[i, 22].View = cc.int_cell;
                        grid1[i, 22].Editor = cc.disable_cell;
                    
                    }
                }

                string Query = "delete from " + DB_TableName_each + " where row_id = -1 " + temp;
                ks.DataUpdate(Query);

                grid1.Refresh();
            }
        }

        private void bMacro_Click(object sender, EventArgs e)
        {
            CopyToMacro(Config.DB_conMacro);
        }
        private void bSang_Click(object sender, EventArgs e)
        {
            CopyToMacro(Config.DB_conMacro_sang);
        }
        private void CopyToMacro(string db_con)
        {
            if (rbCs.Checked)
            {
                ksgcontrol kc_macro = new ksgcontrol();
                kc_macro.ControlInit(db_con, null, null, null);
                MySqlConnection DBConn;
                DBConn = new MySqlConnection(Config.DB_con1);
                util.Con_DB_Open(ref DBConn);

                string check_row = "";
                for (int i = 0; i < grid2.Rows.Count; i++)
                {
                    if (grid2[i, 1].Value.Equals(true))
                    {
                        check_row += " or a.row_id = " + grid2[i, 0].ToString();
                    }
                }

                string Query = "select a.*, b.no as sort, b.hang as hang from " + DB_TableName_grade + " as a ";
                Query += "left outer join " + DB_TableName_hang + " as b on a.hang_code1 = b.code1 and b.class = '%분류' ";
                Query += " where ";
                if (check_row != "")
                    Query += check_row.Substring(3);
                else
                    Query += " a.client_id = 0 and hcust_id = " + row_id_temp + " and hang !='' order by b.no";
                var cmd = new MySqlCommand(Query, DBConn);
                var myRead = cmd.ExecuteReader();


                DataTable p_grade = new DataTable();
                string cQuery = "select * from M_paper_grade";
                dt.make(db_con, p_grade, cQuery);
                DataRow[] p_dr;
                while (myRead.Read())
                {
                    string code = myRead["hang_code1"].ToString();

                    p_dr = p_grade.Select("bun = '" + code + "'");
                    if (p_dr.Length == 0)
                    {
                        cQuery = "insert into M_paper_grade(sort, bun, cut_0_1, remain_0_1, sock_0_1, sock_1_3, sock_3) ";
                        cQuery += " values('" + myRead["sort"].ToString() + "', '" + myRead["hang_code1"].ToString() + "', '" + myRead["cut_0_1"].ToString() + "', '" + myRead["remain_0_1"].ToString() + "', ";
                        cQuery += " '" + myRead["sock_0_1"].ToString() + "', '" + myRead["sock_1_3"].ToString() + "', '" + myRead["sock_3_"].ToString() + "')";
                    }
                    else
                    {
                        //cQuery = "update M_paper_grade set sort = '" + myRead["sort"].ToString() + "', bun = '" + myRead["hang_code1"].ToString() + "', cut_0_1 = '" + myRead["cut_0_1"].ToString() + "', ";
                        //cQuery += " remain_0_1 = '" + myRead["remain_0_1"].ToString() + "', sock_0_1 = '" + myRead["sock_0_1"].ToString() + "', sock_1_3 = '" + myRead["sock_1_3"].ToString() + "', sock_3 = '" + myRead["sock_3_"].ToString() + "'";
                        //cQuery += " where bun = '" + code + "'";
                    }
                    kc_macro.DataUpdate(cQuery);
                }
                myRead.Close();
                DBConn.Close();

                MessageBox.Show("완료 되었습니다");
            }
            else
                MessageBox.Show("CS버전으로 선택하여 전송 하여 주시기 바랍니다.");
        }

        private void rbCs_CheckedChanged(object sender, EventArgs e)
        {
            if (rbCs.Checked)
                Grid_change(Config.DB_con1);
        }

        private void Grid_change(string db_con)
        {
            if (rbCs.Checked)

                DB_TableName_grade = "C_paper_grade";
            else
            {
                grid1.Rows.Clear();
                DB_TableName_grade = "M_paper_grade";
            }
            ks.ControlInit(db_con, null, null, null);
            grid2_view(db_con);
        }

        private void rbMacro_CheckedChanged(object sender, EventArgs e)
        {
            if(rbMacro.Checked)
                Grid_change(Config.DB_conMacro);
        }

        private void rbSang_CheckedChanged(object sender, EventArgs e)
        {
            if(rbSang.Checked)
                Grid_change(Config.DB_conMacro_sang);
        }

       

       
    }
}