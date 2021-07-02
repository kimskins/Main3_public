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
    public partial class Form_client_info : Form
    {
        string DB_TableName_client = "C_client";
        string DB_TableName_mem = "C_member";
        string row_no = "";
        public Form_client_info(string row_id)
        {
            InitializeComponent();
            row_no = row_id;

        }

        private void Form_client_info_Load(object sender, EventArgs e)
        {
            Screen srn = Screen.PrimaryScreen;
            int Xb = this.Width;  //좌,우
            int Yb = this.Height;
            this.Location = new Point((srn.Bounds.Width - Xb) / 2, (srn.Bounds.Height - Yb) / 2);  //좌/우,위/아래

            MySqlConnection DBConn;
            DBConn = new MySqlConnection(Config.DB_con1);
            util.Con_DB_Open(ref DBConn);
            string Query = "select * from " + DB_TableName_client + " where row_id = " + row_no;
            var cmd = new MySqlCommand(Query, DBConn);
            var myRead = cmd.ExecuteReader();
            myRead.Read();

            tbHpage.Text = myRead["homepage"].ToString();
            tbEmail.Text = myRead["e_mail"].ToString();
            tbSangho.Text = myRead["name"].ToString();
            tbNum.Text = myRead["company_num"].ToString();
            tbInday.Text = myRead["bithday"].ToString();
            tbCaddr.Text = myRead["addr_head"].ToString();
            tbCaddrother.Text = myRead["addr_tail"].ToString();
            tbMast.Text = myRead["ceo"].ToString();
            tbHp.Text = myRead["hp"].ToString();
            tbTel.Text = myRead["tel"].ToString();
            tbFax.Text = myRead["fax"].ToString();
            tbYubtae.Text = myRead["biztype"].ToString();
            tbJong.Text = myRead["jongmok"].ToString();

            grid1_view();

        }

        private void grid1_view()
        {
            cell_d cc = new cell_d();
            grid1.Rows.Clear();
            grid1.BorderStyle = BorderStyle.FixedSingle;
            grid1.ColumnsCount = 11;
            grid1.FixedRows = 1;
            grid1.Rows.Insert(0);
            grid1.Rows[0].Height = 24;


            grid1[0, 0] = new MyHeader1("row_id");
            grid1.Columns[0].Visible = false;
            grid1[0, 1] = new MyHeader1("√");

            grid1[0, 2] = new MyHeader1("No");

            grid1[0, 3] = new MyHeader1("업무담당");
            grid1.Columns[3].Visible = false;
            grid1[0, 4] = new MyHeader1("세금담당");
            grid1[0, 5] = new MyHeader1("부서");
            grid1[0, 6] = new MyHeader1("직책");
            grid1[0, 7] = new MyHeader1("성함");
            grid1[0, 8] = new MyHeader1("핸드폰");
            grid1[0, 9] = new MyHeader1("TEL");
            grid1[0, 10] = new MyHeader1("E-mail");

            grid1.Columns[1].Width = 22;
            grid1.Columns[2].Width = 28;
            grid1.Columns[3].Width = 80;
            grid1.Columns[4].Width = 80;
            grid1.Columns[5].Width = 100;
            grid1.Columns[6].Width = 60;
            grid1.Columns[7].Width = 70;
            grid1.Columns[8].Width = 120;
            grid1.Columns[9].Width = 100;
            grid1.Columns[10].Width = 200;


            MySqlConnection DBConn;
            DBConn = new MySqlConnection(Config.DB_con1);
            util.Con_DB_Open(ref DBConn);
            string Query = "select * from " + DB_TableName_mem + " where int_id = " + row_no;
            var cmd = new MySqlCommand(Query, DBConn);
            var myRead = cmd.ExecuteReader();

            int m = 1;
            while (myRead.Read())
            {
                grid1.Rows.Insert(m);
                grid1.Rows[m].Height = 22;

                grid1[m, 0] = new SourceGrid.Cells.Cell(myRead["row_id"].ToString(), typeof(string));
                grid1[m, 0].View = cc.center_cell;
                grid1[m, 1] = new SourceGrid.Cells.CheckBox(null, false);

                grid1[m, 2] = new SourceGrid.Cells.Cell((m).ToString(), typeof(string));
                grid1[m, 2].View = cc.center_cell;
                grid1[m, 2].Editor = cc.disable_cell;

                grid1[m, 3] = new SourceGrid.Cells.Cell("", typeof(string));
                grid1[m, 3].Editor = cc.disable_cell;

                if(myRead["account"].ToString() == "True")
                    grid1[m, 4] = new SourceGrid.Cells.Cell("O", typeof(string));
                else
                    grid1[m, 4] = new SourceGrid.Cells.Cell("", typeof(string));

                grid1[m, 4].View = cc.center_cell;
                grid1[m, 4].Editor = cc.disable_cell;

                grid1[m, 5] = new SourceGrid.Cells.Cell(myRead["department"].ToString(), typeof(string));
                grid1[m, 5].Editor = cc.disable_cell;

                grid1[m, 6] = new SourceGrid.Cells.Cell(myRead["position"].ToString(), typeof(string));
                grid1[m, 6].Editor = cc.disable_cell;

                grid1[m, 7] = new SourceGrid.Cells.Cell(myRead["name"].ToString(), typeof(string));
                grid1[m, 7].Editor = cc.disable_cell;

                grid1[m, 8] = new SourceGrid.Cells.Cell(myRead["phone1"].ToString(), typeof(string));
                grid1[m, 8].Editor = cc.disable_cell;

                grid1[m, 9] = new SourceGrid.Cells.Cell(myRead["phone2"].ToString(), typeof(string));
                grid1[m, 9].Editor = cc.disable_cell;

                grid1[m, 10] = new SourceGrid.Cells.Cell(myRead["e_mail"].ToString(), typeof(string));
                grid1[m, 10].Editor = cc.disable_cell;
                m++;
            }
            myRead.Close();
            DBConn.Close();
        }

        private void bSms_Click(object sender, EventArgs e)
        {
            int count = 0;
            string[] arr_ph;
            string[] arr_name;
            string[] arr_c_id;
            for (int i = 0; i < grid1.RowsCount; i++)
            {
                if (grid1[i, 1].ToString() == "True" && grid1[i, 8].ToString() != null && grid1[i, 8].ToString().Trim() != "")
                {
                    count++;
                }
            }
            arr_ph = new string[count];
            arr_name = new string[count];
            arr_c_id = new string[count];
            int m = 0;
            for (int i = 0; i < grid1.RowsCount; i++)
            {
                if (grid1[i, 1].ToString() == "True" && grid1[i, 8].ToString() != null && grid1[i, 8].ToString().Trim() != "")
                {
                    arr_ph[m] = grid1[i, 8].ToString();
                    arr_name[m] = grid1[i, 7].ToString();
                    arr_c_id[m] = row_no;
                    m++;
                }
            }

            MySqlConnection DBConn;
            DBConn = new MySqlConnection(Config.DB_con1);
            util.Con_DB_Open(ref DBConn);
            string Query = "select tel from " + DB_TableName_client + " where row_id = '294'";
            var cmd = new MySqlCommand(Query, DBConn);
            var myRead = cmd.ExecuteReader();
            myRead.Read();

            Form_sms_send sm = new Form_sms_send(arr_c_id, arr_ph, arr_name, count, myRead["tel"].ToString());
            sm.Show();
            myRead.Close();
            DBConn.Close();
        }

        private void bMail_Click(object sender, EventArgs e)
        {
           
        }
    }
}
