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
    public partial class Form_308 : Form
    {
        cell_d cc = new cell_d();
        SourceGridControl GridHandle = new SourceGridControl();
        ksgcontrol kc = new ksgcontrol();

        sync sy = new sync();
        DataTable ropeband = new DataTable();
        DataTable cmodel = new DataTable();
        DataTable hcust = new DataTable();
        FileControl FC = new FileControl();
            

        string DB_TableName = "C_ropeband";
        string DB_TableName_cmodel = "C_cmodel";
        string DB_TableName_code = "C_hcust_band_code";
        string DB_TableName_hcust = "C_hcustomer";
        string DB_TableName_file = "C_file_total_manage";

        public Form_308()
        {
            InitializeComponent();
        }


        private void Form_308_Load(object sender, EventArgs e)
        {
            Screen srn = Screen.PrimaryScreen;
            int Xb = this.Width;  //좌,우
            this.Location = new Point((srn.Bounds.Width - Xb) / 2, 1);  //좌/우,위/아래

            GridHandle.SourceGrideInit(grid1, Config.DB_con1);
            kc.ControlInit(Config.DB_con1, "", "", "");
            FC.FileControlInit(Config.DB_con1, Config.Ftp_ip1, Config.Ftp_id1, Config.Ftp_pw1);

            SourceGrid.Cells.Controllers.CustomEvents val_c1 = new SourceGrid.Cells.Controllers.CustomEvents();
            val_c1.ValueChanged += new EventHandler(ValueChangedEvent1);
            grid1.Controller.AddController(val_c1);


            string[] wondan_name = new string[] { };
            string bQuery = "select citem from " + DB_TableName_cmodel + " where a_code = 26 and b_code = 07";
            grid_combobox(wondan_name, bQuery, "citem");

            string[] company = new string[] { };
            bQuery = "select b.sangho from " + DB_TableName_code + " as a ";
            bQuery += "left outer join " + DB_TableName_hcust + " as b on a.hcust_id = b.row_id ";
            grid_combobox(company, bQuery, "sangho");


            combobox_insert();

            string Query = "select a.*, b.citem as item, d.sangho as sangho, e.user_file as file_name from " + DB_TableName + " as a ";
            Query += " left outer join " + DB_TableName_cmodel + " as b on a.code = b.c_code and b.a_code = 26 and b.b_code = 07";
            Query += " left outer join " + DB_TableName_code + " as c on a.company = c.code";
            Query += " left outer join " + DB_TableName_hcust + " as d on c.hcust_id = d.row_id";
            Query += " left outer join " + DB_TableName_file + " as e on a.row_id = e.int_id and e.db_nm = '" + DB_TableName + "' ";
            grid1_view(Query);

            Query = "select row_id, c_code, citem from " + DB_TableName_cmodel + " where a_code = 26 and b_code = 07";
            sy.dt(Config.DB_con1, cmodel, Query);
            Query = "select b.sangho as sangho, b.row_id as row_id, a.code as code from " + DB_TableName_code + " as a ";
            Query += " left outer join " + DB_TableName_hcust + " as b on a.hcust_id = b.row_id";
            sy.dt(Config.DB_con1, hcust, Query);

        }
        
        private void combobox_insert()
        {
            cbCompany.Items.Clear();
            cbWondanKind.Items.Clear();
            string bQuery = "select b.sangho as sangho from " + DB_TableName_code + " as a ";
            bQuery += "left outer join " + DB_TableName_hcust + " as b on a.hcust_id = b.row_id ";

            kc.ComboBoxItemInsert("sangho", cbCompany, bQuery);
            //kc.ComboBoxItemInsert(DB_TableName, "sangho", cbCompany, bQuery);

            bQuery = "select distinct b.citem as item from " + DB_TableName + " as a ";
            bQuery += " left outer join " + DB_TableName_cmodel + " as b on a.code = b.c_code and b.a_code = 26 and b.b_code = 07";
            kc.ComboBoxItemInsert("item", cbWondanKind, bQuery);
        }

        private void ValueChangedEvent1(object sender, EventArgs e)  //Grid1에서 볼륨첸지
        {
            int rows = grid1.Selection.ActivePosition.Row;
            int cpos = grid1.Selection.ActivePosition.Column;
            string row_no = grid1[rows, 0].ToString().Trim();
            string dat = grid1[rows, cpos].ToString().Trim().Replace(",", "");

            string cQuery = "";

            DataRow[] dr;

            if (cpos.Equals(3))  //
            {
                dr = cmodel.Select("citem = '" + dat + "'");
                string dat_temp = "";
                if (dr.Length != 0)
                    dat_temp = dr[0]["c_code"].ToString();
                cQuery = " update " + DB_TableName + " set code ='" + dat_temp + "' where row_id='" + row_no + "'";
            }
            else if (cpos.Equals(4))  //
            {
                dr = hcust.Select("sangho = '" + dat + "'");
                string dat_temp = "";
                if (dr.Length != 0)
                    dat_temp = dr[0]["code"].ToString();
                cQuery = " update " + DB_TableName + " set company ='" + dat_temp + "' where row_id='" + row_no + "'";
            }

            else if (cpos.Equals(5))  //
                cQuery = " update " + DB_TableName + " set wondan_no ='" + dat + "' where row_id='" + row_no + "'";
            else if (cpos.Equals(6))  //
                cQuery = " update " + DB_TableName + " set color ='" + dat + "' where row_id='" + row_no + "'";
            else if (cpos.Equals(7))  // 
                cQuery = " update " + DB_TableName + " set roll ='" + dat + "' where row_id='" + row_no + "'";
            else if (cpos.Equals(8))  //
                cQuery = " update " + DB_TableName + " set price ='" + dat + "' where row_id='" + row_no + "'";
            else if (cpos.Equals(9))  //
                cQuery = " update " + DB_TableName + " set unit ='" + dat + "' where row_id='" + row_no + "'";
            else if (cpos.Equals(10))  //
                cQuery = " update " + DB_TableName + " set comment ='" + dat + "' where row_id='" + row_no + "'";

            //
            if (!cQuery.Equals(""))
            {
                if (GridHandle.DataUpdate(cQuery) == 1)
                    MessageBox.Show("서버에라 발생으로 수정되지 않았습니다.");
                combobox_insert();
            }
        }

        private void grid_combobox(string[] arr_name, string bQuery, string column)
        {
            MySqlConnection DBConn;
            DBConn = new MySqlConnection(Config.DB_con1);
            DBConn.Open();
            arr_name = new string[] { };
            var cmd = new MySqlCommand(bQuery, DBConn);
            var myRead = cmd.ExecuteReader();
            int i = 0;
            string temp = "";
            while (myRead.Read())
            {
                temp += "#" + myRead[column].ToString();
                i++;
            }
            myRead.Close();
            DBConn.Close();
            temp = temp.Substring(1);
            arr_name = temp.Split('#');
            GridHandle.InputComboItem(arr_name);
        }
        private void bAdd_Click(object sender, EventArgs e)
        {
            string Query = "insert into " + DB_TableName + " values()";
            string row_no = kc.DataUpdate(Query);

            int m = grid1.RowsCount;
            grid1.Rows.Insert(m);
            grid1.Rows[m].Height = 20;

            grid1[m, 0] = new SourceGrid.Cells.Cell(row_no, typeof(string));

            grid1[m, 1] = new SourceGrid.Cells.CheckBox(null, false);
            grid1[m, 2] = new SourceGrid.Cells.Cell(m.ToString(), typeof(string));
            grid1[m, 2].View = cc.center_cell;
            grid1[m, 2].Editor = cc.disable_cell;

            grid1[m, 3] = new SourceGrid.Cells.Cell("", typeof(string));
            grid1[m, 3].View = cc.center_cell;
            grid1[m, 3].Editor = GridHandle.CbBox[0];

            grid1[m, 4] = new SourceGrid.Cells.Cell("", typeof(string));
            grid1[m, 4].View = cc.center_cell;
            grid1[m, 4].Editor = GridHandle.CbBox[1];

            grid1[m, 5] = new SourceGrid.Cells.Cell("", typeof(string));
            grid1[m, 5].View = cc.center_cell;

            grid1[m, 6] = new SourceGrid.Cells.Cell("", typeof(string));
            grid1[m, 6].View = cc.center_cell;

            grid1[m, 7] = new SourceGrid.Cells.Cell("", typeof(string));
            grid1[m, 7].View = cc.left_cell;

            grid1[m, 8] = new SourceGrid.Cells.Cell("", typeof(string));
            grid1[m, 8].View = cc.center_cell;

            grid1[m, 9] = new SourceGrid.Cells.Cell("", typeof(string));
            grid1[m, 9].View = cc.center_cell;

            grid1[m, 10] = new SourceGrid.Cells.Cell("", typeof(string));
            grid1[m, 10].View = cc.center_cell;

            grid1[m, 11] = new SourceGrid.Cells.Button("");

            grid1[m, 12] = new SourceGrid.Cells.Cell("", typeof(string));
            grid1[m, 12].View = cc.center_cell;

            grid1[m, 13] = new SourceGrid.Cells.Cell("", typeof(string));
        }

        private void grid1_view(string Query)
        {
            grid1.Rows.Clear();
            grid1.BorderStyle = BorderStyle.FixedSingle;
            grid1.SelectionMode = SourceGrid.GridSelectionMode.Cell;
            grid1.ColumnsCount = 14;
            grid1.FixedRows = 1;
            grid1.FixedColumns = 0;
            grid1.Rows.Insert(0);
            grid1.Rows[0].Height = 24;

            grid1[0, 0] = new MyHeader1("row_id");
            grid1.Columns[0].Visible = false;
            grid1[0, 1] = new MyHeader1("√");
            grid1[0, 2] = new MyHeader1("No");

            grid1[0, 3] = new MyHeader1("종류");

            grid1[0, 4] = new MyHeader1("원단업체");

            grid1[0, 5] = new MyHeader1("원단No");

            grid1[0, 6] = new MyHeader1("색상");

            grid1[0, 7] = new MyHeader1("Roll 길이[mm]");

            grid1[0, 8] = new MyHeader1("단가");

            grid1[0, 9] = new MyHeader1("주문단위[mm]");

            grid1[0, 10] = new MyHeader1("설명");

            grid1[0, 11] = new MyHeader1("보기");

            grid1[0, 12] = new MyHeader1("파일명");
            grid1[0, 13] = new MyHeader1("picture");
            grid1.Columns[13].Visible = false;

            grid1.Columns[1].Width = 20;
            grid1.Columns[2].Width = 30;
            grid1.Columns[3].Width = 120;
            grid1.Columns[4].Width = 120;
            grid1.Columns[5].Width = 120;
            grid1.Columns[6].Width = 150;
            grid1.Columns[7].Width = 90;
            grid1.Columns[8].Width = 120;
            grid1.Columns[9].Width = 120;
            grid1.Columns[10].Width = 200;
            grid1.Columns[11].Width = 35;
            grid1.Columns[12].Width = 120;


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
                grid1[m, 2] = new SourceGrid.Cells.Cell(m.ToString(), typeof(string));
                grid1[m, 2].View = cc.center_cell;
                grid1[m, 2].Editor = cc.disable_cell;

                grid1[m, 3] = new SourceGrid.Cells.Cell(myRead["item"].ToString(), typeof(string));
                grid1[m, 3].View = cc.center_cell;
                grid1[m, 3].Editor = GridHandle.CbBox[0];

                grid1[m, 4] = new SourceGrid.Cells.Cell(myRead["sangho"].ToString(), typeof(string));
                grid1[m, 4].View = cc.center_cell;
                grid1[m, 4].Editor = GridHandle.CbBox[1];

                grid1[m, 5] = new SourceGrid.Cells.Cell(myRead["wondan_no"].ToString(), typeof(string));
                grid1[m, 5].View = cc.center_cell;

                grid1[m, 6] = new SourceGrid.Cells.Cell(myRead["color"].ToString(), typeof(string));
                grid1[m, 6].View = cc.center_cell;

                grid1[m, 7] = new SourceGrid.Cells.Cell(myRead["roll"].ToString(), typeof(string));
                grid1[m, 7].View = cc.center_cell;

                grid1[m, 8] = new SourceGrid.Cells.Cell(myRead["price"].ToString(), typeof(string));
                grid1[m, 8].View = cc.center_cell;

                grid1[m, 9] = new SourceGrid.Cells.Cell(myRead["unit"].ToString(), typeof(string));
                grid1[m, 9].View = cc.center_cell;

                grid1[m, 10] = new SourceGrid.Cells.Cell(myRead["comment"].ToString(), typeof(string));
                grid1[m, 10].View = cc.center_cell;

                grid1[m, 11] = new SourceGrid.Cells.Button("");

                grid1[m, 12] = new SourceGrid.Cells.Cell(myRead["file_name"].ToString(), typeof(string));
                grid1[m, 12].View = cc.center_cell;
                grid1[m, 12].Editor = cc.disable_cell;

                grid1[m, 13] = new SourceGrid.Cells.Cell(myRead["picture"].ToString(), typeof(string));
                m++;
            }
            myRead.Close();
            DBConn.Close();
        }

        private void bCopy_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < grid1.RowsCount; i++)
            {
                if(grid1[i,1].Value.Equals(true))
                    GridHandle.OneDataCopy(DB_TableName, grid1[i, 0].ToString());
            }
        }

        private void bDelete_Click(object sender, EventArgs e)
        {
            GridHandle.ChkDataDelete(DB_TableName, 1, 0, 1);
        }

        private void bManage_Click(object sender, EventArgs e)
        {
            util.IsFormAlreadyOpen(typeof(Form_503));
            Form_503 Frm = new Form_503("2607", bManage);
            Frm.Owner = this;
            Frm.Show();
        }

        private void bPictureDel_Click(object sender, EventArgs e)
        {
            string Query = "";
            string FilePath = "";
            int chk_count = 0;

            for (int i = 0; i < grid1.RowsCount; i++)
            {
                if (grid1[i, 0].Value.Equals(true))
                {
                    chk_count++;
                    break;
                }
            }

            if (chk_count == 0)
            {
                MessageBox.Show("선택된 항목이 없습니다");
                return;
            }

            if (MessageBox.Show("선택한 항목의 사진을 삭제합니까 ?", "사진 삭제", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                Query = "select picture, row_id from " + DB_TableName;
                sy.dt(Config.DB_con1, ropeband, Query);
                DataRow[] dr;
                this.Cursor = System.Windows.Forms.Cursors.WaitCursor;
                for (int i = 0; i < grid1.RowsCount; i++)
                {
                    if (grid1[i, 1].Value.Equals(true))
                    {
                        dr = ropeband.Select("row_id = '" + grid1[i, 0].ToString() + "'");
                        if (dr.Length != 0)
                        {
                            FilePath = dr[0]["picture"].ToString();

                            if (FilePath == "")
                                continue;

                            FC.OneFile2ManyRowId_Del(DB_TableName, "picture", grid1[i, 0].ToString(), "");

                            grid1[i, 12].Value = "";
                        }
                    }
                }
               
                GridHandle.ChkCancel(1);
                this.Cursor = System.Windows.Forms.Cursors.Default;
            }
        }

        private void grid1_MouseClick(object sender, MouseEventArgs e)
        {
            int row = grid1.Selection.ActivePosition.Row;
            int col = grid1.Selection.ActivePosition.Column;

            if (row < 0)
                return;

            string row_no = grid1[row, 0].ToString(); 
            string Query = "select * from " + DB_TableName_file + " where int_id = '" + row_no + "' and db_nm = '" + DB_TableName + "'";
            MySqlConnection DBConn = new MySqlConnection(Config.DB_con1);

            DBConn.Open();
            MySqlDataReader myRead;

            var cmd = new MySqlCommand(Query, DBConn);
            myRead = cmd.ExecuteReader();
            string file_path = "";
            if (myRead.Read())
                file_path = myRead["server_file"].ToString();


            myRead.Close();
            DBConn.Close();

            if (col == 11)
            {
                if (file_path == "")
                {
                    //MessageBox.Show("등록된 사진이 없습니다");
                    //return;
                    FileControl FC = new FileControl();
                    FC.FileControlInit(Config.DB_con1, Config.Ftp_ip1, Config.Ftp_id1, Config.Ftp_pw1);
                    OpenFileDialog ofd = new OpenFileDialog();// File descriptor
                    if (FC.FileOpenDlg(ofd) == 1)
                        return;
                    this.Cursor = System.Windows.Forms.Cursors.WaitCursor;
                    FC.FileReg(ofd, DB_TableName, "picture", row_no, "file");
                    grid1[row, 12].Value = ofd.SafeFileName;
                    this.Cursor = System.Windows.Forms.Cursors.Default;
                }
                else
                {
                    Form_imgview Frm = new Form_imgview(row_no, file_path, DB_TableName);
                    if(Frm.ShowDialog() == DialogResult.OK)
                    {
                        //grid1[row, 12] = new SourceGrid.Cells.Cell("", typeof(string));
                        //grid1[row, 12].View = cc.center_cell;
                        grid1[row, 12].Value = "";
                        
                    }
                }
            }
        }

        private void bClear_Click(object sender, EventArgs e)
        {
            cbCompany.Text = "";
            cbWondanKind.Text = "";
            tbHeight.Text = "";
            tbWondanNo.Text = "";
            tbColor.Text = "";
        }

        private void bSearch_Click(object sender, EventArgs e)
        {
            DataRow[] dr;
            string search_temp = " where a.row_id >0 ";
            if (tbHeight.Text.Trim() != "")
                search_temp += " and a.roll like '%" + tbHeight.Text + "%'";
            if (tbWondanNo.Text.Trim() != "")
                search_temp += " and a.wondan_no like '%" + tbWondanNo.Text + "%'";
            if(cbWondanKind.Text.Trim() != "")
            {
                dr = cmodel.Select("citem = '" + cbWondanKind.Text + "'");
                string dat_temp = "";
                if (dr.Length != 0)
                    search_temp += " and a.code = '" + dr[0]["c_code"].ToString() + "'";
            }
            if(cbCompany.Text.Trim() != "")
            {
                dr = hcust.Select("sangho = '" + cbCompany.Text + "'");
                if (dr.Length != 0)
                    search_temp += " and a.company = '" + dr[0]["code"].ToString() + "'";
            }
            if(tbColor.Text.Trim() != "")
                search_temp += " and a.color like '%" + tbColor.Text + "%'";

            string Query = "select a.*, b.citem as item, d.sangho as sangho, e.user_file as file_name from " + DB_TableName + " as a ";
            Query += " left outer join " + DB_TableName_cmodel + " as b on a.code = b.c_code and b.a_code = 26 and b.b_code = 07";
            Query += " left outer join " + DB_TableName_code + " as c on a.company = c.code";
            Query += " left outer join " + DB_TableName_hcust + " as d on c.hcust_id = d.row_id";
            Query += " left outer join " + DB_TableName_file + " as e on a.row_id = e.int_id and e.db_nm = '" + DB_TableName + "' ";
            Query += search_temp;
           
            grid1_view(Query);
        }
    }
}
