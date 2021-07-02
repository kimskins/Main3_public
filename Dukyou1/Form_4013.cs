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
    public partial class Form_4013 : Form
    {
        SourceGridControl GridHandle = new SourceGridControl();
        cell_d cc = new cell_d();

        string DB_TableName_Dealer = "C_dealer_manage";
        string DB_TableName_Client = "C_client";
        string DB_TableName_Gyeon = "C_dealer_gyeon";
        string DB_TableName_mem = "C_member";

        public Form_4013()
        {
            InitializeComponent();
        }

        private void Form_4013_Load(object sender, EventArgs e)
        {
            Screen srn = Screen.PrimaryScreen;
            int Xb = this.Width;  //좌,우
            this.Location = new Point((srn.Bounds.Width - Xb) / 2, 1);  //좌/우,위/아래

            GridHandle.SourceGrideInit(grid1, Config.DB_con1, Config.Ftp_ip1, Config.Ftp_id1, Config.Ftp_pw1);
           

            string cQuery = "select a.row_id, a.parents_id as parents_row, a.dealer_id as dealer_row, c.name as parents_name, c.id as parents_id, b.name as dealer_name, b.id as dealer_id from " + DB_TableName_Dealer + " as a  ";
            cQuery += " left outer join " + DB_TableName_Client + " as b on a.dealer_id = b.row_id ";
            cQuery += " left outer join " + DB_TableName_Client + " as c on a.parents_id = c.row_id ";
            Grid_View(cQuery);
        }


        private void Grid_View(string Query)  //Grid1
        {
            grid1.Rows.Clear();
            grid1.BorderStyle = BorderStyle.FixedSingle;
            grid1.SelectionMode = SourceGrid.GridSelectionMode.Cell;
            grid1.ColumnsCount = 10;
            grid1.FixedRows = 1;
            grid1.Rows.Insert(0);
            grid1.Rows[0].Height = 24;
            //
            grid1[0, 0] = new MyHeader1("row_id");
            grid1.Columns[0].Visible = false;

            grid1[0, 1] = new MyHeader1("√");

            grid1[0, 2] = new MyHeader1("No");

            grid1[0, 3] = new MyHeader1("메인업체");

            grid1[0, 4] = new MyHeader1("메인회사ID");

            grid1[0, 5] = new MyHeader1("딜러업체");

            grid1[0, 6] = new MyHeader1("딜러회사ID");

            grid1[0, 7] = new MyHeader1("parents_id");
            grid1.Columns[7].Visible = false;
            grid1[0, 8] = new MyHeader1("dealer_id");
            grid1.Columns[8].Visible = false;
            

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

                grid1[m, 3] = new SourceGrid.Cells.Cell(myRead["parents_name"], typeof(string));
                grid1[m, 3].View = cc.center_cellb;
                grid1[m, 3].Editor = cc.disable_cell;

                grid1[m, 4] = new SourceGrid.Cells.Cell(myRead["parents_id"], typeof(string));
                grid1[m, 4].View = cc.center_cell;
                grid1[m, 4].Editor = cc.disable_cell;

                grid1[m, 5] = new SourceGrid.Cells.Cell(myRead["dealer_name"], typeof(string));
                grid1[m, 5].View = cc.center_cellb;
                grid1[m, 5].Editor = cc.disable_cell;

                grid1[m, 6] = new SourceGrid.Cells.Cell(myRead["dealer_id"], typeof(string));
                grid1[m, 6].View = cc.center_cell;
                grid1[m, 6].Editor = cc.disable_cell;

                grid1[m, 7] = new SourceGrid.Cells.Cell(myRead["parents_row"], typeof(string));

                grid1[m, 8] = new SourceGrid.Cells.Cell(myRead["dealer_row"], typeof(string));


                m++;
            }
            myRead.Close();
            DBConn.Close();
        }

        private void Refresh_Grid()
        {
            string cQuery = "select a.row_id, a.parents_id as parents_row, a.dealer_id as dealer_row, c.name as parents_name, c.id as parents_id, b.name as dealer_name, b.id as dealer_id from " + DB_TableName_Dealer + " as a  ";
            cQuery += " left outer join " + DB_TableName_Client + " as b on a.dealer_id = b.row_id ";
            cQuery += " left outer join " + DB_TableName_Client + " as c on a.parents_id = c.row_id ";
            Grid_View(cQuery);
        }
        private void bAdd_Click(object sender, EventArgs e)
        {
            string cQuery = "insert into " + DB_TableName_Dealer + " (dealer_id) values('0')";
            GridHandle.DataUpdate(cQuery);
            Refresh_Grid();
        }

        private void bDelete_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("삭제하시겠습니까?", "메세지창", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                for (int i = 0; i < grid1.RowsCount; i++)
                {
                    if (grid1[i, 1].Value.Equals(true))
                    {
                        string Query = "delete from " + DB_TableName_Gyeon + " where client_id = " + grid1[i, 7].ToString() + " and cust_id = " + grid1[i, 8].ToString();
                        GridHandle.DataUpdate(Query);
                    }
                }

                GridHandle.ChkDataDelete(DB_TableName_Dealer, 1, 0, 1);
            }
        }

        private void grid1_DoubleClick(object sender, EventArgs e)
        {
            int r_pos = grid1.Selection.ActivePosition.Row;
            int c_pos = grid1.Selection.ActivePosition.Column;
            if (r_pos < 0)
                return;

            string row_id = grid1[r_pos, 0].ToString();

            string company_id = "";
            if (c_pos == 3)  // 메인업체
            {
                Form_4013a frm = new Form_4013a();
                frm.ShowDialog();
                company_id = frm.row_id;
                
            }
            else if (c_pos == 5)  // 딜러업체
            {
                Form_4013a frm = new Form_4013a();
                frm.ShowDialog();
                company_id = frm.row_id;
                if (company_id != "")
                {
                    if (!chk_double_dealer(company_id))
                    {

                        MessageBox.Show("이미 등록되어 있는 딜러업체입니다.");
                        return;
                    }
                }
            }
            

            if (company_id != "")
            {
                string cQuery = "";
                if (c_pos == 3)
                    cQuery += "update " + DB_TableName_Dealer + " set parents_id = '" + company_id + "' where row_id = '" + row_id + "'";
                   
                else if (c_pos == 5)
                    cQuery += "update " + DB_TableName_Dealer + " set dealer_id = '" + company_id + "' where row_id = '" + row_id + "'";
                    
                GridHandle.DataUpdate(cQuery);

                Refresh_Grid();

                for (int i = 0; i < grid1.RowsCount; i++)
                {
                    if(grid1[i,0].ToString() == row_id)
                        def_danga_set(grid1[i, 7].ToString(), grid1[i, 8].ToString());
                }

            }
        }
        private void def_danga_set(string parents_id, string dealer_id)
        {
            if (parents_id == "0" || dealer_id == "0")
                return;
            string field = "";
            string copy_value = "";

            string cQuery = "SELECT `COLUMN_NAME` FROM `INFORMATION_SCHEMA`.`COLUMNS` WHERE `TABLE_SCHEMA`='" + Config.DB_name + "' AND `TABLE_NAME`='" + DB_TableName_Gyeon + "'";
            MySqlConnection DBConn;
            DBConn = new MySqlConnection(Config.DB_con1);
            util.Con_DB_Open(ref DBConn);

            var cmd1 = new MySqlCommand(cQuery, DBConn);
            var myRead1 = cmd1.ExecuteReader();
            while (myRead1.Read())
            {
                if (myRead1["column_name"].ToString() != "row_id" && myRead1["column_name"].ToString() != "cust_id")
                    field += myRead1["column_name"].ToString().Trim() + ",";
            }
            //       
            myRead1.Close();

            field = field.Substring(0, field.Length - 1);

            string[] temp = field.Split(',');
            cQuery = "select " + field + " from " + DB_TableName_Gyeon + " where cust_id = -1 and client_id = '" + parents_id + "'";
            cmd1 = new MySqlCommand(cQuery, DBConn);
            myRead1 = cmd1.ExecuteReader();

            while(myRead1.Read())
            {
                cQuery = "insert into " + DB_TableName_Gyeon + "(" + field + ", cust_id) values(";
                string val = "";
                for (int i = 0; i < temp.Length; i++)
                {
                    val += ", '" + myRead1[temp[i]].ToString() + "' ";
                }
                cQuery = cQuery + val.Substring(1) + ", '" + dealer_id + "')";
                GridHandle.DataUpdate(cQuery);
            }
            myRead1.Close();
            DBConn.Close();
        }
        // 이미 딜러회사로 등록되어있는지 확인 여부 검사
        // input : 딜러회사 row_id(C_client)
        // output : 문제 없으면 true, 이미 등록되어있으면 false 를 return
        private bool chk_double_dealer(string dealer_id)
        {
            string cQuery = "select row_id from " + DB_TableName_Dealer + " where dealer_id = '" + dealer_id + "'";

            MySqlConnection DBConn;
            DBConn = new MySqlConnection(Config.DB_con1);
            util.Con_DB_Open(ref DBConn);

            var cmd = new MySqlCommand(cQuery, DBConn);
            var myRead = cmd.ExecuteReader();

            if (myRead.Read())
            {
                myRead.Close();
                DBConn.Close();
                return false;
            }

            myRead.Close();
            DBConn.Close();
            return true;
        }

    }
}
