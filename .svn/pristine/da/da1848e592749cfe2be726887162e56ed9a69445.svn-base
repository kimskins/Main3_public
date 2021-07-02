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
    public partial class Form_604b : Form
    {
        string DB_TableName_hmachine = "C_hmachin";
        string DB_TableName_hcust = "C_hcustomer";

        public string choice_machine_id = "";

        SourceGridControl GridHandle = new SourceGridControl();
        public Form_604b()
        {
            InitializeComponent();
        }

        private void Form_604b_Load(object sender, EventArgs e)
        {
            Screen srn = Screen.PrimaryScreen;
            int Xb = this.Width;  //좌,우
            int Yb = this.Height; //좌,우
            this.Location = new Point((srn.Bounds.Width - Xb) / 2, (srn.Bounds.Height - Yb) / 2);  //좌/우,위/아래
            ksgcontrol kc = new ksgcontrol();
            kc.ControlInit(Config.DB_con1, "", "", "");

            string cQuery = "";

            GridHandle.SourceGrideInit(grid1, Config.DB_con1);

            cQuery = " select a.row_id, b.sangho, b.ctel, b.c_addr, a.dosu, a.pan_size, a.machin_guy, a.confirm from " + DB_TableName_hmachine + " as a ";
            cQuery += " Left outer join " + DB_TableName_hcust + " as b on a.int_id = b.row_id ";
            cQuery += " where a_model = '08' and (b_model = '04' or b_model = '05' or b_model = '06') ";
            cQuery += " and a.deal_state = true order by a.int_id";
            kc.ComboBoxItemInsert("pan_size", cbPanType, cQuery);
            Grid_View(cQuery);
        }

        private void Grid_View(string cQuery)
        {
            cell_d cc = new cell_d();

            grid1.Rows.Clear();
            grid1.BorderStyle = BorderStyle.FixedSingle;
            grid1.SelectionMode = SourceGrid.GridSelectionMode.Cell;
            grid1.ColumnsCount = 10;
            grid1.FixedRows = 1;
            grid1.Rows.Insert(0);
            grid1.Rows[0].Height = 24;

            grid1[0, 0] = new MyHeader1("row_id");
            grid1[0, 1] = new MyHeader1("√");
            grid1[0, 2] = new MyHeader1("No");
            grid1[0, 3] = new MyHeader1("인쇄업체명");
            grid1[0, 4] = new MyHeader1("전화번호");
            grid1[0, 5] = new MyHeader1("도수");
            grid1[0, 6] = new MyHeader1("판형");
            grid1[0, 7] = new MyHeader1("기계구와이");
            grid1[0, 8] = new MyHeader1("주소");
            grid1[0, 9] = new MyHeader1("검증");

            grid1.Columns[0].Visible = false;

            grid1.Columns[1].Width = 22;
            grid1.Columns[2].Width = 40;
            grid1.Columns[3].Width = 120;
            grid1.Columns[4].Width = 110;
            grid1.Columns[5].Width = 50;
            grid1.Columns[6].Width = 80;
            grid1.Columns[7].Width = 80;
            grid1.Columns[8].Width = 362;
            grid1.Columns[9].Width = 60;

            int m = 1;
            string confirm = "";
            var DBConn = new MySqlConnection(Config.DB_con1);
            DBConn.Open();

            var cmd = new MySqlCommand(cQuery, DBConn);
            var myRead = cmd.ExecuteReader();

            while (myRead.Read())
            {
                grid1.Rows.Insert(m);
                grid1.Rows[m].Height = 22;

                grid1[m, 0] = new SourceGrid.Cells.Cell(myRead["row_id"], typeof(string));
                grid1[m, 1] = new SourceGrid.Cells.CheckBox(null, false);
                
                grid1[m, 2] = new SourceGrid.Cells.Cell(m.ToString(), typeof(string));
                grid1[m, 2].View = cc.center_cell;
                grid1[m, 2].Editor = cc.disable_cell;

                grid1[m, 3] = new SourceGrid.Cells.Cell(myRead["sangho"], typeof(string));
                grid1[m, 3].View = cc.center_cell;
                grid1[m, 3].Editor = cc.disable_cell;

                grid1[m, 4] = new SourceGrid.Cells.Cell(myRead["ctel"], typeof(string));
                grid1[m, 4].View = cc.center_cell;
                grid1[m, 4].Editor = cc.disable_cell;

                grid1[m, 5] = new SourceGrid.Cells.Cell(myRead["dosu"], typeof(string));
                grid1[m, 5].View = cc.center_cell;
                grid1[m, 5].Editor = cc.disable_cell;

                grid1[m, 6] = new SourceGrid.Cells.Cell(myRead["pan_size"], typeof(string));
                grid1[m, 6].View = cc.center_cell;
                grid1[m, 6].Editor = cc.disable_cell;

                grid1[m, 7] = new SourceGrid.Cells.Cell(myRead["machin_guy"], typeof(string));
                grid1[m, 7].View = cc.center_cell;
                grid1[m, 7].Editor = cc.disable_cell;

                grid1[m, 8] = new SourceGrid.Cells.Cell(myRead["c_addr"], typeof(string));
                grid1[m, 8].View = cc.left_cell;
                grid1[m, 8].Editor = cc.disable_cell;

                if (myRead["confirm"].ToString() == "False" || myRead["confirm"].ToString() == "false")
                    confirm = "미검증";
                else
                    confirm = "검증";
                grid1[m, 9] = new SourceGrid.Cells.Cell(confirm, typeof(string));
                grid1[m, 9].View = cc.center_cell;
                grid1[m, 9].Editor = cc.disable_cell;

                m++;
            }
            myRead.Close();
            DBConn.Close();
        }

        private void bClear_Click(object sender, EventArgs e)
        {
            tbPrnCom.Text = "";
            tbDosu.Text = "";
            cbPanType.Text = "";

            tbPrnCom.Refresh();
            tbDosu.Refresh();
            cbPanType.Refresh();
        }

        private void bSearch_Click(object sender, EventArgs e)
        {
            string s1, s2, s3;

            if (!string.IsNullOrEmpty(tbPrnCom.Text))  //상호
            {
                s1 = " and b.sangho like '%" + tbPrnCom.Text + "%' ";
            }
            else
                s1 = "";

            if (!string.IsNullOrEmpty(tbPrnCom.Text))  //도수
            {
                s2 = " and a.dosu like '%" + tbDosu.Text + "%' ";
            }
            else
                s2 = "";

            if (!string.IsNullOrEmpty(cbPanType.Text))  //판형
            {
                s3 = " and a.pan_size = '" + cbPanType.Text + "' ";
            }
            else
                s3 = "";
            
            string cQuery = "";
            cQuery = " select a.row_id, b.sangho, b.ctel, b.c_addr, a.dosu, a.pan_size, a.machin_guy, a.confirm from " + DB_TableName_hmachine + " as a ";
            cQuery += " Left outer join " + DB_TableName_hcust + " as b on a.int_id = b.row_id ";
            cQuery += " where a_model = '08' and (b_model = '04' or b_model = '05' or b_model = '06') " + s1+s2+s3;
            cQuery += " and a.deal_state = true order by a.int_id";
            
            Grid_View(cQuery);
        }

        private void grid1_Click(object sender, EventArgs e)
        {
            GridHandle.OnlyOneChk(1, grid1.Selection.ActivePosition.Row, 1);
        }

        private void bSave_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < grid1.RowsCount ; i++)
            {
                if (grid1[i, 1].Value.Equals(true))
                {
                    choice_machine_id = grid1[i, 0].ToString();
                    break;
                }
            }
            this.Close();
        }
    }
}
