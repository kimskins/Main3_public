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
    public partial class Form_404 : Form
    {
        string DB_TableName_form_manager = "C_file_total_manage";
        string DB_TableName_client = "C_client";
        string DB_TableName_cf_manage = "C_cf_manage";
        SourceGridControl GridHandle = new SourceGridControl();
        public Form_404()
        {
            InitializeComponent();
            grid1_view();
            GridHandle.SourceGrideInit(grid1, Config.DB_con1);

            SourceGrid.Cells.Controllers.CustomEvents val_c1 = new SourceGrid.Cells.Controllers.CustomEvents();
            val_c1.ValueChanged += new EventHandler(values_Change);
            grid1.Controller.AddController(val_c1);
            row_clear();
        }

        private void row_clear()
        {
            if (grid1.RowsCount == 1)
            {
                string mQuery = "alter table " + DB_TableName_cf_manage + " auto_increment = 1";  //데이터가 없을때 row_id초기화
                GridHandle.DataUpdate(mQuery);
            }
        }

        public void grid1_view()
        {
            cell_d cc = new cell_d();
            SourceGrid.Cells.Views.Button dd;
            dd = new SourceGrid.Cells.Views.Button();
            dd.TextAlignment = DevAge.Drawing.ContentAlignment.MiddleCenter;

            grid1.Rows.Clear();
            grid1.BorderStyle = BorderStyle.FixedSingle;
            grid1.SelectionMode = SourceGrid.GridSelectionMode.Cell;
            grid1.ColumnsCount = 11;
            grid1.FixedRows = 0;
            grid1.Rows.Insert(0);
            grid1.Rows[0].Height = 24;

            grid1[0, 0] = new MyHeader1("No");  //row_id
            grid1.Columns[0].Visible = true;
            grid1[0, 1] = new MyHeader1("√");
            grid1.Columns[1].Visible = true;
            grid1[0, 2] = new MyHeader1("no");
            grid1.Columns[2].Visible = false;
            grid1[0, 3] = new MyHeader1("상호");
            grid1[0, 4] = new MyHeader1("사진등록");
            grid1[0, 5] = new MyHeader1("server_file");
            grid1.Columns[5].Visible = false;
            grid1[0, 6] = new MyHeader1("user_file");
            grid1.Columns[6].Visible = false;
            grid1[0, 7] = new MyHeader1("client_id");
            grid1.Columns[7].Visible = false;
            grid1[0, 8] = new MyHeader1("picture");
            grid1.Columns[8].Visible = false;
            grid1[0, 9] = new MyHeader1("그룹");
            grid1.Columns[9].Visible = true;
            grid1[0, 10] = new MyHeader1("메모");
            grid1.Columns[10].Visible = true;

            grid1.Columns[0].Width = 30;
            grid1.Columns[1].Width = 20;            
            grid1.Columns[3].Width = 280;
            grid1.Columns[4].Width = 68;
            grid1.Columns[9].Width = 70;
            grid1.Columns[10].Width = 179;

            MySqlConnection DBConn;
            DBConn = new MySqlConnection(Config.DB_con1);
            DBConn.Open();
            string Query = "select a.*,a.client_id, b.name,b.row_id,c.* from " + DB_TableName_cf_manage + " a Left Outer Join "
                + DB_TableName_client + " b ON a.client_id = b.row_id Left Outer Join "
                + DB_TableName_form_manager + " c ON a.row_id = c.int_id and c.db_nm = '" + DB_TableName_cf_manage + "' order by a.row_id"; 
            var cmd = new MySqlCommand(Query, DBConn);
            var myRead = cmd.ExecuteReader();

            int m = 1;
            while (myRead.Read())
            {
                grid1.Rows.Insert(m);
                grid1.Rows[m].Height = 25;

                grid1[m, 0] = new SourceGrid.Cells.Cell(myRead["row_id"].ToString(), typeof(string));
                
                grid1[m, 1] = new SourceGrid.Cells.CheckBox(null, false);
                grid1[m, 2] = new SourceGrid.Cells.Cell((m).ToString(), typeof(string));
                grid1[m, 0].Editor = cc.disable_cell;
                grid1[m, 0].View = cc.center_cell;

                grid1[m, 3] = new SourceGrid.Cells.Cell(myRead["name"].ToString(), typeof(string));
                
                    grid1[m, 3].Editor = cc.disable_cell;

                bool temp = Convert.ToBoolean(myRead["picture"]);
                
                if (temp != false)
                    grid1[m, 4] = new SourceGrid.Cells.Button("보기");
                else
                    grid1[m, 4] = new SourceGrid.Cells.Button("찾아보기");

                grid1[m, 4].View = dd;
                grid1[m, 5] = new SourceGrid.Cells.Cell(myRead["server_file"].ToString(), typeof(string));
                
                grid1[m, 6] = new SourceGrid.Cells.Cell(myRead["user_file"].ToString(), typeof(string));
                grid1[m, 7] = new SourceGrid.Cells.Cell(myRead["client_id"].ToString(), typeof(string));
                grid1[m, 8] = new SourceGrid.Cells.Cell(myRead["picture"].ToString(), typeof(string));
                grid1[m, 9] = new SourceGrid.Cells.Cell(myRead["group_id"].ToString(), typeof(string));
                grid1[m, 9].View = cc.center_cell;
                grid1[m, 10] = new SourceGrid.Cells.Cell(myRead["cf_memo"].ToString(), typeof(string));
                m++;
            }
            myRead.Close();
            DBConn.Close();
        }

        private void bAdd_Click(object sender, EventArgs e)
        {
            int acount = grid1.RowsCount;

            Form_404a fm = new Form_404a(bAdd);
            fm.ShowDialog();
            row_clear();
            grid1_view();
            if (acount < grid1.RowsCount)
            {
                int row = grid1.RowsCount - 1;
                var position = new SourceGrid.Position(row, 0);
                grid1.Selection.Focus(position, true);
            }
        }

        private void grid1_Click(object sender, EventArgs e)
        {
            int col = grid1.Selection.ActivePosition.Column;
            int row = grid1.Selection.ActivePosition.Row;

            if (col == 4)
            {
                if (col < 0)
                    col = 1;
                if (grid1[row, 4].ToString() == "보기")
                {
                    MessageBox.Show("이미지가 등록되어 있습니다");
                }
                else
                {
                    string row_no = grid1[row, 0].ToString().Trim();
                    FileControl FC = new FileControl();
                    FC.FileControlInit(Config.DB_con1, Config.Ftp_ip1, Config.Ftp_id1, Config.Ftp_pw1);

                    OpenFileDialog ofd = new OpenFileDialog();// File descriptor
                    if (FC.FileOpenDlg(ofd) == 1)
                        return;

                    string File = FC.FileReg(ofd, DB_TableName_cf_manage, "picture", row_no, "");

                    grid1[row, 4] = new SourceGrid.Cells.Button("보기");
                    MySqlConnection DBConn;
                    DBConn = new MySqlConnection(Config.DB_con1);
                    DBConn.Open();
                    string Query = "select row_id,server_file,user_file from " + DB_TableName_form_manager + " where int_id = " + row_no;

                    var cmd = new MySqlCommand(Query, DBConn);
                    var myRead = cmd.ExecuteReader();

                    myRead.Read();
                    string row_temp = myRead["row_id"].ToString();
                    grid1[row, 5] = new SourceGrid.Cells.Cell(myRead["server_file"].ToString(), typeof(string));
                    grid1[row, 6] = new SourceGrid.Cells.Cell(myRead["user_file"].ToString(), typeof(string));
                    myRead.Close();
                    DBConn.Close();

                    string mQuery = "update " + DB_TableName_form_manager + " set client_id = 294 where row_id = " + row_temp;
                    GridHandle.DataUpdate(mQuery);
                    row_clear();
                    grid1_view();
                   // int row_count = grid1.RowsCount - 1;
                    var position = new SourceGrid.Position(row, 0);
                    grid1.Selection.Focus(position, true);
                }
            }    
        }

        private void bPictureDel_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("삭제하시겠습니까?", "메세지창", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                Picture_Del();
                row_clear();
                grid1_view();
            }
        }

        public void Picture_Del()
        {
            string row_no = "";

            for (int i = 0; i < grid1.RowsCount; i++)
            {
                if (grid1[i, 1].ToString() == "True" && grid1[i, 8].ToString() == "1")
                {
                    row_no = grid1[i, 0].ToString().Trim();
                    FileControl FC = new FileControl();
                    FC.FileControlInit(Config.DB_con1, Config.Ftp_ip1, Config.Ftp_id1, Config.Ftp_pw1);

                    FC.FileDel(DB_TableName_cf_manage, "picture", row_no, "");

                    grid1[i, 4] = new SourceGrid.Cells.Button("");
                    grid1[i, 5] = new SourceGrid.Cells.Cell("", typeof(string));
                    grid1[i, 6] = new SourceGrid.Cells.Cell("", typeof(string));
                }
            }
        }

        private void values_Change(object sender, EventArgs e)
        {
            int col = grid1.Selection.ActivePosition.Column;
            if (col == 10)  //메모
            {
                string data = grid1[grid1.Selection.ActivePosition.Row, 10].ToString();
                string row_id = grid1[grid1.Selection.ActivePosition.Row, 0].ToString();
                int row_Position = grid1.Selection.ActivePosition.Row;

                string iQuery = "update " + DB_TableName_cf_manage + " set cf_memo = '" + data + "' where row_id = " + row_id;
                GridHandle.DataUpdate(iQuery);
                row_clear();
                grid1_view();

                var position = new SourceGrid.Position(row_Position, 10);
                grid1.Selection.Focus(position, true);
            }

            else if (col == 9)  //그룹
            {
                string data = grid1[grid1.Selection.ActivePosition.Row, 9].ToString();
                string row_id = grid1[grid1.Selection.ActivePosition.Row, 0].ToString();
                int row_Position = grid1.Selection.ActivePosition.Row;

                string iQuery = "update " + DB_TableName_cf_manage + " set group_id = '" + data + "' where row_id = " + row_id;
                GridHandle.DataUpdate(iQuery);
                row_clear();
                grid1_view();

                var position = new SourceGrid.Position(row_Position, 9);
                grid1.Selection.Focus(position, true);
            }
        }

        private void bDel_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("삭제하시겠습니까?", "메세지창", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                Picture_Del();
                GridHandle.ChkDataDelete(DB_TableName_cf_manage, 1, 0, 1);
                row_clear();
                grid1_view();
            }
        }
    }
}
