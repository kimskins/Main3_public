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
    public partial class Form_4012 : Form
    {
        cell_d cc = new cell_d();
        ksgcontrol KC = new ksgcontrol();
        string cQuery;
        Form myForm;

        int Now_Rows = 0;
        
        string DB_TableName_hcust = "C_hcustomer";
        int row_id_position = 0; // grid 기준으로 row_id 위치
        int first_data_row = 1;  // grid 기준으로 첫번째 data가 기록되는 행
        int chk_position = 1;    // grid 기준으로 check box의 위치

        SourceGridControl GridHandle = new SourceGridControl();
        public Form_4012()
        {
            InitializeComponent();
        }

        private void Form_4011_Load(object sender, EventArgs e)
        {
            ksgcontrol kk = new ksgcontrol();
            string Mac = kk.GetMacAddr();

            Screen srn = Screen.PrimaryScreen;
            int Xb = this.Width;  //좌,우
            this.Location = new Point((srn.Bounds.Width - Xb) / 2, 1);  //좌/우,위/아래

            GridHandle.SourceGrideInit(grid1, Config.DB_con1, Config.Ftp_ip1, Config.Ftp_id1, Config.Ftp_pw1);
            KC.ControlInit(Config.DB_con1, Config.Ftp_ip1, Config.Ftp_id1, Config.Ftp_pw1);

            cQuery = "select * from C_hcustomer";
      
            Grid_View(cQuery);
        }

        public void Grid_View(string Query)
        {
            int Rows = 0;
            string Erp_Use = "";

            grid1.Rows.Clear();

            grid1.BorderStyle = BorderStyle.FixedSingle;
            grid1.ColumnsCount = 7;
            grid1.FixedRows = 1;

            grid1.Rows.Insert(0);

            grid1.Rows[0].Height = 26;

            grid1[Rows, 0] = new MyHeader1("row_id");
            grid1.Columns[0].Visible = false;

            grid1[Rows, 1] = new MyHeader1("No");

            grid1[Rows, 2] = new MyHeader1("상호");

            grid1[Rows, 3] = new MyHeader1("사업자번호");

            grid1[Rows, 4] = new MyHeader1("회사ID");

            grid1[Rows, 5] = new MyHeader1("사용버젼");

            grid1[Rows, 6] = new MyHeader1("사용여부");

            Rows++;
            
            var DBConn = new MySqlConnection(Config.DB_con1);
            DBConn.Open();
            var cmd = new MySqlCommand(Query, DBConn);

            var myRead = cmd.ExecuteReader();

            grid1.Columns[1].Width = 30;
            grid1.Columns[2].Width = 117;
            grid1.Columns[3].Width = 100;
            grid1.Columns[4].Width = 80;
            grid1.Columns[5].Width = 90;
            grid1.Columns[6].Width = 70;

            while (myRead.Read())
            {
                grid1.Rows.Insert(Rows);
                grid1.Rows[Rows].Height = 24;

                grid1[Rows, 0] = new SourceGrid.Cells.Cell(myRead["row_id"], typeof(string));

                if (Rows == 1)
                {
                    PanelControl(grid1[Rows, 0].ToString());
                    var position = new SourceGrid.Position(1, 1);
                    Now_Rows = 1;
                    grid1.Selection.Focus(position, true);
                }

                grid1[Rows, 1] = new SourceGrid.Cells.Cell(Rows.ToString(), typeof(string));
                grid1[Rows, 1].View = cc.int_cell;
                grid1[Rows, 1].Editor = cc.disable_cell;

                grid1[Rows, 2] = new SourceGrid.Cells.Cell(myRead["sangho"], typeof(string));
                grid1[Rows, 2].View = cc.center_cell;
                grid1[Rows, 2].Editor = cc.disable_cell;

                grid1[Rows, 3] = new SourceGrid.Cells.Cell(myRead["enter_no"], typeof(string));
                grid1[Rows, 3].View = cc.center_cell;
                grid1[Rows, 3].Editor = cc.disable_cell;

                grid1[Rows, 4] = new SourceGrid.Cells.Cell(myRead["id"], typeof(string));
                grid1[Rows, 4].View = cc.center_cell;
                grid1[Rows, 4].Editor = cc.disable_cell;

                string gubun = myRead["gubun"].ToString();
                string gubun_temp = "";

                if (gubun == "1")
                    gubun_temp = "이모션CTP";
                if (gubun == "2")
                    gubun_temp = "일반협력업체";
                if (gubun == "3")
                    gubun_temp = "지류업체";
                if (gubun == "4")
                    gubun_temp = "운송업체";
                if (gubun == "5")
                    gubun_temp = "외주CTP";

                grid1[Rows, 5] = new SourceGrid.Cells.Cell(gubun_temp, typeof(string));
                grid1[Rows, 5].View = cc.center_cell;
                grid1[Rows, 5].Editor = cc.disable_cell;

                string use = myRead["use_erp"].ToString();
                string use_temp = "";
                if (use == "True")
                    use_temp = "사용";
                else
                    use_temp = "미사용";
                grid1[Rows, 6] = new SourceGrid.Cells.Cell(use_temp, typeof(string));
                grid1[Rows, 6].View = cc.center_cell;
                grid1[Rows, 6].Editor = cc.disable_cell;

                Rows++;
            }

            myRead.Close();
            DBConn.Close();
        }

        public void PanelControl(string client_row_id)
        {
            int Rows = grid1.Selection.ActivePosition.Row;
            if (Rows < 0)
                Rows = 1;

            if (myForm != null)
            {
                this.pView.Controls.Remove(myForm);
                myForm.Close();
                myForm = null;
            }
            //
            if (rbManage.Checked == true)
            {
                myForm = new Form_4012a(client_row_id, this, Rows);
                //               
                if (myForm != null)
                {
                    myForm.TopLevel = false;
                    myForm.AutoScroll = true;
                    this.pView.Controls.Add(myForm);
                    this.pView.BorderStyle = System.Windows.Forms.BorderStyle.None;
                    myForm.Show();
                }
            }
            else if (rbDefault.Checked == true)
            {
                myForm = new Form_4012b(client_row_id, this);
                //               
                if (myForm != null)
                {
                    myForm.TopLevel = false;
                    myForm.AutoScroll = true;
                    this.pView.Controls.Add(myForm);
                    this.pView.BorderStyle = System.Windows.Forms.BorderStyle.None;
                    myForm.Show();
                }
            }


        }

        private void bClear_Click(object sender, EventArgs e)
        {
            tbName.Text = "";
            tbName.Refresh();

            tbComNum.Text = "";
            tbComNum.Refresh();

            tbComId.Text = "";
            tbComId.Refresh();

            
            chkUse.Checked = false;
            chkNotUse.Checked = false;

        }

        private void grid1_MouseClick(object sender, MouseEventArgs e)
        {
            int column = grid1.Selection.ActivePosition.Column;
            int Rows = grid1.Selection.ActivePosition.Row;
            Now_Rows = Rows;

            if (Rows < 0)
                return;

            string row_no = "";
            row_no = grid1[Rows, 0].ToString().Trim();

            PanelControl(row_no);

        }

        public void GridLineRefresh(int Rows)
        {
            int now_row = Rows;

            string row_no = grid1[now_row, 0].ToString().Trim();
            string Query = "select * from " + DB_TableName_hcust + " where row_id = " + row_no;
            var DBConn = new MySqlConnection(Config.DB_con1);
            DBConn.Open();
            var cmd = new MySqlCommand(Query, DBConn);
            var myRead = cmd.ExecuteReader();

            myRead.Read();

            grid1[now_row, 0] = new SourceGrid.Cells.Cell(myRead["row_id"], typeof(string));

            grid1[now_row, 1] = new SourceGrid.Cells.Cell(Rows.ToString(), typeof(string));
            grid1[now_row, 1].View = cc.int_cell;
            grid1[now_row, 1].Editor = cc.disable_cell;

            grid1[Rows, 2] = new SourceGrid.Cells.Cell(myRead["sangho"], typeof(string));
            grid1[Rows, 2].View = cc.center_cell;
            grid1[Rows, 2].Editor = cc.disable_cell;

            grid1[Rows, 3] = new SourceGrid.Cells.Cell(myRead["enter_no"], typeof(string));
            grid1[Rows, 3].View = cc.center_cell;
            grid1[Rows, 3].Editor = cc.disable_cell;

            grid1[Rows, 4] = new SourceGrid.Cells.Cell(myRead["id"], typeof(string));
            grid1[Rows, 4].View = cc.center_cell;
            grid1[Rows, 4].Editor = cc.disable_cell;

            string gubun = myRead["gubun"].ToString();
            string gubun_temp = "";

            if (gubun == "1")
                gubun_temp = "이모션CTP";
            if (gubun == "2")
                gubun_temp = "일반협력업체";
            if (gubun == "3")
                gubun_temp = "지류업체";
            if (gubun == "4")
                gubun_temp = "운송업체";
            if (gubun == "5")
                gubun_temp = "외주CTP";

            grid1[Rows, 5] = new SourceGrid.Cells.Cell(gubun_temp, typeof(string));
            grid1[Rows, 5].View = cc.center_cell;
            grid1[Rows, 5].Editor = cc.disable_cell;

            string use = myRead["use_erp"].ToString();
            string use_temp = "";
            if (use == "True")
                use_temp = "사용";
            else
                use_temp = "미사용";
            grid1[Rows, 6] = new SourceGrid.Cells.Cell(use_temp, typeof(string));
            grid1[Rows, 6].View = cc.center_cell;
            grid1[Rows, 6].Editor = cc.disable_cell;


            grid1.Refresh();

            DBConn.Close();
            myRead.Close();
        }

        private void bSearch_Click(object sender, EventArgs e)
        {
            string sangho_temp = "";
            string enter_no_temp = "";
            string id_temp = "";
            string use_temp = "";

            string Name = tbName.Text;
            string ComNum = tbComNum.Text;
            string ID = tbComId.Text;

            if (Name != "")
                sangho_temp = "and sangho = '" + Name + "'";
            else
                sangho_temp = "";

            if (ComNum != "")
                enter_no_temp = "and enter_no='" + ComNum + "'";
            else
                enter_no_temp = "";

            if (ID != "")
                id_temp = "and id = '" + ID + "'";
            else
                id_temp = "";



            if (chkUse.Checked == true)
                use_temp = "and use_erp = true";
            if (chkUse.Checked == false)
                use_temp = "and use_erp = false";
            if (chkUse.Checked == true && chkUse.Checked == false)
                use_temp = "";

            string Query = "select * from " + DB_TableName_hcust + " where row_id is not null " + sangho_temp + enter_no_temp + id_temp + use_temp;
            Query += " order by sangho";

            Grid_View(Query);
        }

        private void rbDefault_CheckedChanged(object sender, EventArgs e)
        {
            string row_no = "";

            if (grid1[Now_Rows, 0] != null)
                row_no = grid1[Now_Rows, 0].ToString();

            PanelControl(row_no);
        }

        private void Form_4011_FormClosing(object sender, FormClosingEventArgs e)
        {
        }

    }
}
