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
    public partial class Form_4011b : Form
    {
        cell_d cc = new cell_d();
        string DB_TableName_Client = "C_client";
        string DB_TableName_Member = "C_member";
        string client_row_id = "";
        Form_4011 mom;

        SourceGridControl MemberGridHandle = new SourceGridControl();
        
        public Form_4011b(string row_id, Form_4011 mom)
        {
            InitializeComponent();
            client_row_id = row_id;
            this.mom = mom;
        }

        private void Form_4011b_Load(object sender, EventArgs e)
        {
            MemberGridHandle.SourceGrideInit(MemberGrid, Config.DB_con1, Config.Ftp_ip1, Config.Ftp_id1, Config.Ftp_pw1);

            string Query = "select * from " + DB_TableName_Client + " where row_id = '" + client_row_id + "'";
            var DBConn = new MySqlConnection(Config.DB_con1);
            DBConn.Open();
            var cmd = new MySqlCommand(Query, DBConn);

            var myRead = cmd.ExecuteReader();

            if (myRead.Read())
            {
                tbHomePage.Text = myRead["homepage"].ToString();
                tbHomePage.Refresh();

                tbEmail.Text = myRead["e_mail"].ToString();
                tbEmail.Refresh();

                tbName.Text = myRead["name"].ToString();
                tbName.Refresh();

                tbCEO.Text = myRead["ceo"].ToString();
                tbCEO.Refresh();

                tbHP.Text = myRead["hp"].ToString();
                tbHP.Refresh();

                tbTel.Text = myRead["tel"].ToString();
                tbTel.Refresh();

                tbUptae.Text = myRead["biztype"].ToString();
                tbUptae.Refresh();

                tbJongMok.Text = myRead["jongmok"].ToString();
                tbJongMok.Refresh();

                tbFax.Text = myRead["fax"].ToString();
                tbFax.Refresh();

                tbComNum.Text = myRead["company_num"].ToString();
                tbComNum.Refresh();

                tbBirth.Text = myRead["bithday"].ToString();
                tbBirth.Refresh();

                tbAddress.Text = myRead["addr_total"].ToString();
                tbAddress.Refresh();

                GetMemGrid();
            }
            myRead.Close();
            DBConn.Close();

        }

        public void GetMemGrid()
        {
            string Query = "select * from " + DB_TableName_Member + " where int_id = '" + client_row_id + "' and open_member = true";
            int Rows = 0;
            bool Check = false;

            MemberGrid.Rows.Clear();

            MemberGrid.BorderStyle = BorderStyle.FixedSingle;
            MemberGrid.ColumnsCount = 10;
            MemberGrid.FixedRows = 1;

            MemberGrid.Rows.Insert(0);

            MemberGrid.Rows[0].Height = 26;

            MemberGrid[Rows, 0] = new MyHeader1("row_id");
            MemberGrid.Columns[0].Visible = false;

            MemberGrid[Rows, 1] = new MyHeader1("No");

            MemberGrid[Rows, 2] = new MyHeader1("담");

            MemberGrid[Rows, 3] = new MyHeader1("세");

            MemberGrid[Rows, 4] = new MyHeader1("직책");

            MemberGrid[Rows, 5] = new MyHeader1("성함");

            MemberGrid[Rows, 6] = new MyHeader1("부서");
            MemberGrid[Rows, 7] = new MyHeader1("TEL1");
            MemberGrid[Rows, 8] = new MyHeader1("TEL2");
            MemberGrid[Rows, 9] = new MyHeader1("E-Mail");
            Rows++;

            var DBConn = new MySqlConnection(Config.DB_con1);
            DBConn.Open();
            var cmd = new MySqlCommand(Query, DBConn);

            var myRead = cmd.ExecuteReader();

            MemberGrid.Columns[1].Width = 30;
            MemberGrid.Columns[2].Width = 20;
            MemberGrid.Columns[3].Width = 20;
            MemberGrid.Columns[4].Width = 50;
            MemberGrid.Columns[5].Width = 70;
            MemberGrid.Columns[6].Width = 70;
            MemberGrid.Columns[7].Width = 70;
            MemberGrid.Columns[8].Width = 70;
            MemberGrid.Columns[9].Width = 90;

            while (myRead.Read())
            {
                MemberGrid.Rows.Insert(Rows);
                MemberGrid.Rows[Rows].Height = 24;

                MemberGrid[Rows, 0] = new SourceGrid.Cells.Cell(myRead["row_id"], typeof(string));

                MemberGrid[Rows, 1] = new SourceGrid.Cells.Cell(Rows.ToString(), typeof(string));
                MemberGrid[Rows, 1].View = cc.int_cell;
                MemberGrid[Rows, 1].Editor = cc.disable_cell;

                if (myRead["work_charge"].ToString() == "True")
                    Check = true;
                else
                    Check = false;

                MemberGrid[Rows, 2] = new SourceGrid.Cells.CheckBox(null, Check);

                if (myRead["tax_charge"].ToString() == "True")
                    Check = true;
                else
                    Check = false;

                MemberGrid[Rows, 3] = new SourceGrid.Cells.CheckBox(null, Check);

                MemberGrid[Rows, 4] = new SourceGrid.Cells.Cell(myRead["position"], typeof(string));
                MemberGrid[Rows, 4].View = cc.center_cell;
                MemberGrid[Rows, 4].Editor = cc.disable_cell;

                MemberGrid[Rows, 5] = new SourceGrid.Cells.Cell(myRead["name"], typeof(string));
                MemberGrid[Rows, 5].View = cc.center_cell;
                MemberGrid[Rows, 5].Editor = cc.disable_cell;

                MemberGrid[Rows, 6] = new SourceGrid.Cells.Cell(myRead["department"], typeof(string));
                MemberGrid[Rows, 6].View = cc.center_cell;
                MemberGrid[Rows, 6].Editor = cc.disable_cell;

                MemberGrid[Rows, 7] = new SourceGrid.Cells.Cell(myRead["phone1"], typeof(string));
                MemberGrid[Rows, 7].View = cc.center_cell;
                MemberGrid[Rows, 7].Editor = cc.disable_cell;

                MemberGrid[Rows, 8] = new SourceGrid.Cells.Cell(myRead["phone2"], typeof(string));
                MemberGrid[Rows, 8].View = cc.center_cell;
                MemberGrid[Rows, 8].Editor = cc.disable_cell;

                MemberGrid[Rows, 9] = new SourceGrid.Cells.Cell(myRead["e_mail"], typeof(string));
                MemberGrid[Rows, 9].View = cc.center_cell;
                MemberGrid[Rows, 9].Editor = cc.disable_cell;
                Rows++;
            }

            myRead.Close();
            DBConn.Close();
        }

        private void MemberGrid_Click(object sender, EventArgs e)
        {
            int column = MemberGrid.Selection.ActivePosition.Column;
            int Rows = MemberGrid.Selection.ActivePosition.Row;

            if (Rows < 0)
                return;

            string Query = "";
            string row_no = "";
            row_no = MemberGrid[Rows, 0].ToString().Trim();

            if (column == 2)
            {
                if (MemberGrid[Rows, 2].ToString() == "True")
                    Query = "update " + DB_TableName_Member + " set work_charge=false where row_id = '" + row_no + "'";
                else
                    Query = "update " + DB_TableName_Member + " set work_charge=true where row_id = '" + row_no + "'";
                MemberGridHandle.DataUpdate(Query);
            }
            else if (column == 3)
            {
                if (MemberGrid[Rows, 3].ToString() == "True")
                    Query = "update " + DB_TableName_Member + " set tax_charge=false where row_id = '" + row_no + "'";
                else
                    Query = "update " + DB_TableName_Member + " set tax_charge=true where row_id = '" + row_no + "'";
                MemberGridHandle.DataUpdate(Query);
            } 
        }

        private void Form_4011b_FormClosing(object sender, FormClosingEventArgs e)
        {
            
        }
    }
}
