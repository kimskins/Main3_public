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
    public partial class Form_503 : Form
    {
        cell_d cc = new cell_d();
        string abcode = "";
        string DB_TablaName_hcust_jiup_code = "C_hcust_jiup_code";
        string DB_TableName_hcust_wondan_code = "C_hcust_wondan_code";
        string DB_TableName_hcust_band_code = "C_hcust_band_code";
        string DB_TableName_hcustomer = "C_hcustomer";
        

        private Button butt = new Button();
        private int Xb = 0;
        private int Yb = 0;
        bool screen_chk = true;

        
        public Form_503(string ab_code, Button bt)
        {
            InitializeComponent();
            abcode = ab_code;
            grid1_view();

            if(bt != null)
            {
                screen_chk = false;
                butt = bt;
                Xb = butt.PointToScreen(Location).X;  //좌,우
                Yb = butt.PointToScreen(Location).Y + bt.Height + 6;  //위,아래
            }
            
        }
        public void grid1_view()
        {
            grid1.Rows.Clear();
            grid1.BorderStyle = BorderStyle.FixedSingle;
            grid1.SelectionMode = SourceGrid.GridSelectionMode.Row;
            grid1.ColumnsCount = 6;
            grid1.FixedRows = 0;
            grid1.Rows.Insert(0);
            grid1.Rows[0].Height = 24;

            grid1[0, 0] = new MyHeader1("row_id");
            grid1.Columns[0].Visible = false;
            grid1[0, 1] = new MyHeader1("√");
            grid1.Columns[1].Visible = false;
            grid1[0, 2] = new MyHeader1("No");
            grid1[0, 3] = new MyHeader1("업체이름");
            grid1[0, 4] = new MyHeader1("코드");
            grid1[0, 5] = new MyHeader1("hcust_id");
            grid1.Columns[5].Visible = false;

            grid1.Columns[2].Width = 30;            
            grid1.Columns[3].Width = 200;
            grid1.Columns[4].Width = 70;

            MySqlConnection DBConn;
            DBConn = new MySqlConnection(Config.DB_con1);
            DBConn.Open();
            string Query = "";
            if (abcode == "4001")
            {
                Query = "select a.row_id as row_id, a.code, a.hcust_id, b.sangho from " + DB_TablaName_hcust_jiup_code + " as a ";
                Query += "left outer join " + DB_TableName_hcustomer + " as b on a.hcust_id = b.row_id order by substring(code,3,1), substring(code,2,1), substring(code,1,1)";
            }
            if(abcode == "5002")
            {
                Query = "select a.row_id as row_id, a.code, a.hcust_id, b.sangho from " + DB_TableName_hcust_wondan_code + " as a ";
                Query += "left outer join " + DB_TableName_hcustomer + " as b on a.hcust_id = b.row_id order by substring(code,3,1), substring(code,2,1), substring(code,1,1)";
            }
            if(abcode == "2607")
            {
                Query = "select a.row_id, a.code, a.hcust_id, b.sangho from " + DB_TableName_hcust_band_code + " as a ";
                Query += " left outer join " + DB_TableName_hcustomer + " as b on a.hcust_id = b.row_id";
            }
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

                grid1[m, 3] = new SourceGrid.Cells.Cell(myRead["sangho"].ToString(), typeof(string));
                grid1[m, 3].Editor = cc.disable_cell;

                grid1[m, 4] = new SourceGrid.Cells.Cell(myRead["code"].ToString(), typeof(string));
                grid1[m, 4].View = cc.center_cell;
                grid1[m, 4].Editor = cc.disable_cell;

                grid1[m, 5] = new SourceGrid.Cells.Cell(myRead["hcust_id"].ToString(), typeof(string));
                m++;
            }
            myRead.Close();
            DBConn.Close();
        }

        private void bAdd_Click(object sender, EventArgs e)
        {
            string db_name = "";
            if (abcode == "4001")
                db_name = DB_TablaName_hcust_jiup_code;
            if (abcode == "5002")
                db_name = DB_TableName_hcust_wondan_code;
            if (abcode == "2607")
                db_name = DB_TableName_hcust_band_code;
            Form_503a fm = new Form_503a(grid1, bAdd, abcode, db_name);
            fm.ShowDialog();
            grid1_view();
        }

        private void Form_502_Load(object sender, EventArgs e)
        {
            if (screen_chk == true)
            {
                Screen srn = Screen.PrimaryScreen;
                int Xb1 = this.Width;  //좌,우
                this.Location = new Point((srn.Bounds.Width - Xb1) / 2, 1);  //좌/우,위/아래
            }
            else
                this.Location = new Point(Xb, Yb);


        }

        private void bClear_Click(object sender, EventArgs e)
        {
            grid1_view();
        }
    }
}
