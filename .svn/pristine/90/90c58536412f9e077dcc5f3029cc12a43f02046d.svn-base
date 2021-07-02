using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using System.Text.RegularExpressions;

namespace Dukyou3
{
    public partial class Form_503a : Form
    {
        cell_d cc = new cell_d();
        string DB_TableName_hcustomer = "C_hcustomer";
        string DB_TablaName_hcust_code = "C_hcust_jiup_code";
        ksgcontrol ks = new ksgcontrol();
        SourceGrid.Grid grid;
        string ab_code = "";

        private Button butt = new Button();
        private int Xb = 0;
        private int Yb = 0;

        public Form_503a(SourceGrid.Grid gride, Button bt, string abcode, string code_db)
        {
            InitializeComponent();
            butt = bt;
            Xb = butt.PointToScreen(Location).X;  //좌,우
            Yb = butt.PointToScreen(Location).Y + bt.Height + 6;  //위,아래
            DB_TablaName_hcust_code = code_db;
            grid = gride;
            ab_code = abcode;
            ks.ControlInit(Config.DB_con1, null, null, null);
            string Query = "";
            
                Query = "select a.row_id as row_id, a.*, b.code from " + DB_TableName_hcustomer + " as a ";
                Query += "left outer join " + DB_TablaName_hcust_code + " as b on a.row_id = b.hcust_id ";
                Query += "where a.yubjong like '%" + ab_code + "%'";
            
            grid1_view(Query);
            rbAll.Checked = true;
        }

        private void Form_502a_Load(object sender, EventArgs e)
        {
            this.Location = new Point(Xb, Yb);
        }

        public void grid1_view(string Query)
        {
            grid1.Rows.Clear();
            grid1.BorderStyle = BorderStyle.FixedSingle;
            grid1.SelectionMode = SourceGrid.GridSelectionMode.Row;
            grid1.ColumnsCount = 8;
            grid1.FixedRows = 0;
            grid1.Rows.Insert(0);
            grid1.Rows[0].Height = 24;

            grid1[0, 0] = new MyHeader1("row_id");
            grid1.Columns[0].Visible = false;
            grid1[0, 1] = new MyHeader1("√");
            grid1[0, 2] = new MyHeader1("No");
            grid1[0, 3] = new MyHeader1("상태");
            grid1[0, 4] = new MyHeader1("업체이름");
            grid1[0, 5] = new MyHeader1("대표");
            grid1[0, 6] = new MyHeader1("주소");
            grid1[0, 7] = new MyHeader1("code");
            grid1.Columns[7].Visible = false;

            grid1.Columns[1].Width = 22;
            grid1.Columns[2].Width = 30;
            grid1.Columns[3].Width = 60;
            grid1.Columns[4].Width = 200;
            grid1.Columns[5].Width = 70;
            grid1.Columns[6].Width = 234;

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
                    grid1[m, 2].View = cc.center_cell;
                    grid1[m, 2].Editor = cc.disable_cell;

                    string temp = "미등록";
                    for (int i = 0; i < grid.RowsCount; i++)
                    {
                        if (grid1[m, 0].ToString() == grid[i, 5].ToString())
                        {
                            temp = "등록";
                            grid1[m, 1] = new SourceGrid.Cells.CheckBox(null, true);
                            grid1[m, 1].Editor = cc.disable_cell;
                        }
                    }
                    grid1[m, 3] = new SourceGrid.Cells.Cell(temp, typeof(string));
                    grid1[m, 3].Editor = cc.disable_cell;
                    grid1[m, 3].View = cc.left_cell_bold;


                    grid1[m, 4] = new SourceGrid.Cells.Cell(myRead["sangho"].ToString(), typeof(string));
                    grid1[m, 4].Editor = cc.disable_cell;

                    grid1[m, 5] = new SourceGrid.Cells.Cell(myRead["mast"].ToString(), typeof(string));
                    grid1[m, 5].View = cc.center_cell;
                    grid1[m, 5].Editor = cc.disable_cell;

                    grid1[m, 6] = new SourceGrid.Cells.Cell(myRead["c_addr"].ToString(), typeof(string));
                    grid1[m, 6].Editor = cc.disable_cell;

                    grid1[m, 7] = new SourceGrid.Cells.Cell(myRead["code"].ToString(), typeof(string));
                    m++;
            }
            myRead.Close();
            DBConn.Close();
        }

        private void bAdd_Click(object sender, EventArgs e)
        {

            string tem = grid[grid.RowsCount-1, 4].ToString();
            string alpa = "AA0";
            int grid_row = 0;
            int num = 0;

            string strTmp = "";   //숫자만 추출
            if (grid.RowsCount == 1)
            {
               strTmp = "0";
               grid_row = 1;
            }
            else
               strTmp = Regex.Replace(tem, @"\D", "");   //숫자만 추출
            //
            if (strTmp == "")
               num = 1;
            else
               num = Convert.ToInt32(strTmp);   //추출한 숫자를 int형으로 형 변화
           
           int data1 = Convert.ToUInt16(Convert.ToChar(tem.Substring(0, 1)));    //form_503그리드 코드 추출 아스키 코드로 변환
           int data2 = Convert.ToUInt16(Convert.ToChar(tem.Substring(1, 1)));
           if (data2 == 90)  //아스키 코드 90 = 대문자Z 65 = 대문자A
           {
               if (num == 9)
               {
                   data1 = data1 + 1;
                   alpa = Convert.ToChar(data1).ToString() + "A";
                   num = 0;
               }
               else
               {
                   alpa = Convert.ToChar(data1).ToString() + "A";
                   num = num + 1;
               }
           }
           else
           {
               data2 = data2 + 1;
               alpa = Convert.ToChar(data1).ToString() + Convert.ToChar(data2).ToString();
           }

           string Query = "";
           for (int i = 0; i < grid1.RowsCount; i++)
           {
               if (grid1[i, 1].ToString() == "True" && grid1[i, 3].ToString() == "미등록")
               {
                   if (grid_row == 1)
                   {
                       alpa = "AA";
                       num = 0;
                       data1 = 65;
                       data2 = 65;
                       grid_row++;
                   }
                   Query = "insert into " + DB_TablaName_hcust_code + "(hcust_id, code) values('" + grid1[i, 0].ToString() + "','" + alpa + num + "')";
                   ks.DataUpdate(Query);
                   if (data2 == 90)  //아스키 코드 90 = 대문자Z 65 = 대문자A
                   {
                       if (num == 9)
                       {
                           data1 = data1 + 1;
                           alpa = Convert.ToChar(data1).ToString() + "A";
                           num = 0;
                       }
                       else
                       {
                           alpa = Convert.ToChar(data1).ToString() + "A";
                           num = num + 1;
                       }
                   }
                   else
                   {
                       data2 = data2 + 1;
                       alpa = Convert.ToChar(data1).ToString() + Convert.ToChar(data2).ToString();
                   }
               }
           }
           this.Close();
        }

        private void bSearch_Click(object sender, EventArgs e)
        {
            string Query = "";
            string search = "";
            if (tbSearch.Text != "")
                search = " a.sangho = '" + tbSearch.Text + "' and ";
            if (rbNo.Checked == true)
            {
                Query = "select a.row_id as row_id, a.*, b.code from " + DB_TableName_hcustomer + " as a ";
                Query += "left outer join " + DB_TablaName_hcust_code + " as b on a.row_id = b.hcust_id ";
                Query += "where " + search + " a.yubjong like '%" + ab_code + "%' and b.code is null";
                grid1_view(Query);
            }
            else if (rbYes.Checked == true) 
            {
                Query = "select a.row_id as row_id, a.*, b.code from " + DB_TableName_hcustomer + " as a ";
                Query += "left outer join " + DB_TablaName_hcust_code + " as b on a.row_id = b.hcust_id ";
                Query += "where " + search + " a.yubjong like '%" + ab_code + "%' and b.code is not null";
                grid1_view(Query);
            }
            else if (rbAll.Checked == true)
            {
                Query = "select a.row_id as row_id, a.*, b.code from " + DB_TableName_hcustomer + " as a ";
                Query += "left outer join " + DB_TablaName_hcust_code + " as b on a.row_id = b.hcust_id ";
                Query += "where " + search + " a.yubjong like '%" + ab_code + "%'";
                grid1_view(Query);
            }
        }

        private void bClear_Click(object sender, EventArgs e)
        {
            tbSearch.Clear();
            string Query = "select a.row_id as row_id, a.*, b.code from " + DB_TableName_hcustomer + " as a ";
            Query += "left outer join " + DB_TablaName_hcust_code + " as b on a.row_id = b.hcust_id ";
            Query += "where a.yubjong like '%" + ab_code + "%'";
            grid1_view(Query);
            rbAll.Checked = true;
        }
    }
}
