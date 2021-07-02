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
    public partial class Form_301 : Form
    {
        cell_d cc = new cell_d();
        string DB_TableName_price = "C_trans_price";
        public Form_301()
        {
            InitializeComponent();
        }

        private void Form_14_Load(object sender, EventArgs e)
        {
            Screen srn = Screen.PrimaryScreen;
            int Xb = this.Width;  //좌,우
            this.Location = new Point((srn.Bounds.Width - Xb) / 2, 1);  //좌/우,위/아래
            bSearch_Click(null, null);
        }

        private void Grid_View(string cQuery)
        {
            // 
            grid1.Rows.Clear();
            grid1.BorderStyle = BorderStyle.FixedSingle;
            grid1.SelectionMode = SourceGrid.GridSelectionMode.Cell;
            grid1.ColumnsCount = 15;
            grid1.FixedRows = 1;
            grid1.Rows.Insert(0);
            grid1.Rows[0].Height = 26;

            //
            grid1[0, 0] = new MyHeader1("row_id");
            grid1.Columns[0].Visible = false;
            grid1[0, 1] = new MyHeader1("√");
            grid1.Columns[1].Visible = false;
            grid1[0, 2] = new MyHeader1("No");
            grid1[0, 3] = new MyHeader1("날짜");
            grid1[0, 4] = new MyHeader1("배송방법");
            grid1[0, 5] = new MyHeader1("차량");
            grid1[0, 6] = new MyHeader1("출발주소A");
            grid1[0, 7] = new MyHeader1("출발주소B");
            grid1[0, 8] = new MyHeader1("출발주소C");
            grid1[0, 9] = new MyHeader1("출발주소D");
            grid1[0, 10] = new MyHeader1("도착주소A");
            grid1[0, 11] = new MyHeader1("도착주소B");
            grid1[0, 12] = new MyHeader1("도착주소C");
            grid1[0, 13] = new MyHeader1("도착주소D");
            grid1[0, 14] = new MyHeader1("금액");

            //
            grid1.Columns[2].Width = 40;  
            grid1.Columns[3].Width = 100; 
            grid1.Columns[4].Width = 80;  
            grid1.Columns[5].Width = 80; 
            grid1.Columns[6].Width = 100;
            grid1.Columns[7].Width = 100;
            grid1.Columns[8].Width = 100; 
            grid1.Columns[9].Width = 100;  
            grid1.Columns[10].Width = 100; 
            grid1.Columns[11].Width = 100;
            grid1.Columns[12].Width = 100;
            grid1.Columns[13].Width = 100; 
            grid1.Columns[14].Width = 80; 


            var DBConn = new MySqlConnection(Config.DB_con1);
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
                grid1[m, 0] = new SourceGrid.Cells.Cell(myRead["row_id"].ToString(), typeof(string));
                grid1[m, 1] = new SourceGrid.Cells.CheckBox(null, false);
                grid1[m, 2] = new SourceGrid.Cells.Cell((m).ToString(), typeof(string));
                grid1[m, 2].View = cc.center_cell;
                grid1[m, 2].Editor = cc.disable_cell;

                string order_date = Convert.ToDateTime(myRead["write_date"].ToString()).ToString("yyyy-MM-dd");
                grid1[m, 3] = new SourceGrid.Cells.Cell(order_date, typeof(string));

                grid1[m, 4] = new SourceGrid.Cells.Cell(myRead["trans_way"].ToString(), typeof(string));

                grid1[m, 5] = new SourceGrid.Cells.Cell(myRead["car"].ToString(), typeof(string));
                grid1[m, 6] = new SourceGrid.Cells.Cell(myRead["start_addr_a"].ToString(), typeof(string));
                grid1[m, 7] = new SourceGrid.Cells.Cell(myRead["start_addr_b"].ToString(), typeof(string));
                grid1[m, 8] = new SourceGrid.Cells.Cell(myRead["start_addr_c"].ToString(), typeof(string));
                grid1[m, 9] = new SourceGrid.Cells.Cell(myRead["start_addr_d"].ToString(), typeof(string));
                grid1[m, 10] = new SourceGrid.Cells.Cell(myRead["end_addr_a"].ToString(), typeof(string));
                grid1[m, 11] = new SourceGrid.Cells.Cell(myRead["end_addr_b"].ToString(), typeof(string));
                grid1[m, 12] = new SourceGrid.Cells.Cell(myRead["end_addr_c"].ToString(), typeof(string));
                grid1[m, 13] = new SourceGrid.Cells.Cell(myRead["end_addr_d"].ToString(), typeof(string));
                grid1[m, 14] = new SourceGrid.Cells.Cell(myRead["write_date"].ToString(), typeof(string));
                grid1[m, 14] = new SourceGrid.Cells.Cell(myRead["price"].ToString(), typeof(string));

                m++;
            }
            myRead.Close();
            DBConn.Close();
        }

        private void bSearch_Click(object sender, EventArgs e)
        {
            string cQuery = "";
            string s1, s2, s3, s4, s5, s6;

            if (tbStartDate.Text.Trim() != "")
                s1 = " and a.order_date >= '" + tbStartDate.Text.Trim() + "' ";
            else
                s1 = "";

            if (tbEndDate.Text.Trim() != "")
                s2 = " and a.order_date <= '" + tbEndDate.Text.Trim() + "' ";
            else
                s2 = "";

            if (tbTrans_way.Text.Trim() != "")
                s3 = " and trans_way like '%" + tbTrans_way.Text.Trim() + "%' ";
            else
                s3 = "";

            if (tbCar.Text.Trim() != "")
                s4 = " and car like '%" + tbCar.Text.Trim() + "%' ";
            else
                s4 = "";

            if (tbStart.Text.Trim() != "")
                s5 = " and concat(start_addr_a, start_addr_b, start_addr_c, start_addr_d) like '%" + tbStart.Text.Trim() + "%' ";
            else
                s5 = "";

            if (tbEnd.Text.Trim() != "")
                s6 = " and concat(end_addr_a, end_addr_b, end_addr_c, end_addr_d) like '%" + tbEnd.Text.Trim() + "%' ";
            else
                s6 = "";


            cQuery = "select * from " + DB_TableName_price + " where row_id is not null "+s1+s2+s3+s4+s5+s6+" order by write_date desc";
            Grid_View(cQuery);
        }

        private void bStartDate_Click(object sender, EventArgs e)
        {
            Calendar_Form fm = new Calendar_Form(tbStartDate);
            fm.ShowDialog();
        }

        private void bEndDate_Click(object sender, EventArgs e)
        {
            Calendar_Form fm = new Calendar_Form(tbEndDate);
            fm.ShowDialog();
        }

        private void bClear_Click(object sender, EventArgs e)
        {
            tbStartDate.Text = "";
            tbEndDate.Text = "";
            tbTrans_way.Text = "";
            tbCar.Text = "";
            tbStart.Text = "";
            tbEnd.Text = "";

            tbStartDate.Refresh();
            tbEndDate.Refresh();
            tbTrans_way.Refresh();
            tbCar.Refresh();
            tbStart.Refresh();
            tbEnd.Refresh();
        }

        private void Form_301_SizeChanged(object sender, EventArgs e)
        {
            int width = this.Width - 40;
            int height = this.Height - 118;

            this.grid1.Size = new System.Drawing.Size(width, height);
        }

    }
}
