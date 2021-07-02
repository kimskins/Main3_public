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
    public partial class Form_213b : Form
    {
        SourceGridControl GridHandle = new SourceGridControl();

        string DB_TableName_c_com = "C_choice_company";
        string ab_code = "";
        string ver = "";
        public string machine_row_id = "no data";
        public string customer_row_id = "no data";

        public Form_213b(string ab_code, string ver)
        {
            InitializeComponent();
            this.ab_code = ab_code;
            this.ver = ver;
        }

        private void Form_213b_Load(object sender, EventArgs e)
        {
            Screen srn = Screen.PrimaryScreen;
            int Xb = this.Width;  //좌,우
            int Yb = this.Height; //좌,우
            this.Location = new Point((srn.Bounds.Width - Xb) / 2, (srn.Bounds.Height - Yb) / 2);  //좌/우,위/아래

            GridHandle.SourceGrideInit(grid1, Config.DB_con1);
            Refresh();
        }

        private void Refresh()
        {
            string cQuery = "";

            if (ver == "user")
            {
                cQuery = "select b.sangho sangho, a.row_id as machine_row,b.row_id as cust_row, d.bitem, a.dosu, c.hang, a.machin_name, concat(a.a_model, a.b_model) as ab_code  from  C_hmachin as a ";
                cQuery += " left outer join C_hcustomer b on a.int_id=b.row_id ";
                cQuery += " left outer join hang_manage as c on a.pan_type=c.code1 and c.class='판형' ";
                cQuery += " left outer join C_bmodel as d on a.a_model=d.a_code and a.b_model=d.b_code ";
                cQuery += " where concat(a.a_model, a.b_model) ='" + ab_code + "'";
            }
            else
            {
                cQuery = "select b.bitem sangho,a.row_id as machine_row,b.row_id as cust_row, d.bitem, a.dosu, c.hang, a.machin_name, concat(a.a_model, a.b_model) as ab_code from C_platform_machine as a ";
                cQuery += " left outer join C_bmodel as b on a.int_id=b.row_id ";
                cQuery += " left outer join hang_manage as c on a.pan_type=c.code1 and c.class='판형' ";
                cQuery += " left outer join C_bmodel as d on a.a_model=d.a_code and a.b_model=d.b_code ";
                cQuery += " where concat(a.a_model, a.b_model) ='" + ab_code + "'";
            }


            Grid_View(cQuery);
        }

        private void Grid_View(string Query)
        {
            cell_d cc = new cell_d();
            // 
            grid1.Rows.Clear();
            grid1.BorderStyle = BorderStyle.FixedSingle;
            grid1.SelectionMode = SourceGrid.GridSelectionMode.Cell;
            grid1.ColumnsCount = 10;
            grid1.FixedRows =2;
            grid1.Rows.Insert(0);
            grid1.Rows[0].Height = 24;
            grid1.Rows.Insert(1);
            grid1.Rows[1].Height = 24;

            grid1[0, 0] = new MyHeader1("row_id");
            grid1.Columns[0].Visible = false;
            grid1[0, 0].RowSpan = 2;

            grid1[0, 1] = new MyHeader1("no");
            grid1[0, 1].RowSpan = 2;
            grid1[0, 2] = new MyHeader1("상호");
            grid1[0, 2].RowSpan = 2;
            grid1[0, 3] = new MyHeader1("기계구분");
            grid1[0, 3].ColumnSpan = 4;
            grid1[1, 3] = new MyHeader1("중분류");
            grid1[1, 4] = new MyHeader1("도수");
            grid1[1, 5] = new MyHeader1("절수");
            grid1[1, 6] = new MyHeader1("기계명");
            grid1[0, 7] = new MyHeader1("ab 코드");
            grid1[0, 7].RowSpan = 2;
            grid1[0, 8] = new MyHeader1("machine_row_id");
            grid1.Columns[8].Visible = false;
            grid1[0, 8].RowSpan = 2;
            grid1[0, 9] = new MyHeader1("customer_row_id");
            grid1.Columns[9].Visible = false;
            grid1[0, 9].RowSpan = 2;

            grid1.Columns[1].Width = 40;
            grid1.Columns[2].Width = 150;
            grid1.Columns[3].Width = 100;
            grid1.Columns[4].Width = 50;
            grid1.Columns[5].Width = 60;
            grid1.Columns[6].Width = 100;
            grid1.Columns[7].Width = 50;

            MySqlConnection DBConn;
            DBConn = new MySqlConnection(Config.DB_con1);
            DBConn.Open();

            var cmd = new MySqlCommand(Query, DBConn);
            var myRead = cmd.ExecuteReader();

            int Rows = 2;
            while (myRead.Read())
            {
                grid1.Rows.Insert(Rows);
                grid1.Rows[Rows].Height = 24;

                grid1[Rows, 0] = new SourceGrid.Cells.Cell(myRead["machine_row"], typeof(string));

                grid1[Rows, 1] = new SourceGrid.Cells.Cell((Rows - 1).ToString(), typeof(string));
                grid1[Rows, 1].View = cc.center_cell;
                grid1[Rows, 1].Editor = cc.disable_cell;

                grid1[Rows, 2] = new SourceGrid.Cells.Cell(myRead["sangho"], typeof(string));
                grid1[Rows, 2].View = cc.left_cell;
                grid1[Rows, 2].Editor = cc.disable_cell;

                grid1[Rows, 3] = new SourceGrid.Cells.Cell(myRead["bitem"], typeof(string));
                grid1[Rows, 3].View = cc.left_cell;
                grid1[Rows, 3].Editor = cc.disable_cell;

                grid1[Rows, 4] = new SourceGrid.Cells.Cell(myRead["dosu"], typeof(string));
                grid1[Rows, 4].View = cc.center_cell;
                grid1[Rows, 4].Editor = cc.disable_cell;

                grid1[Rows, 5] = new SourceGrid.Cells.Cell(myRead["hang"], typeof(string));
                grid1[Rows, 5].View = cc.center_cell;
                grid1[Rows, 5].Editor = cc.disable_cell;

                grid1[Rows, 6] = new SourceGrid.Cells.Cell(myRead["machin_name"], typeof(string));
                grid1[Rows, 6].View = cc.center_cell;
                grid1[Rows, 6].Editor = cc.disable_cell;

                grid1[Rows, 7] = new SourceGrid.Cells.Cell(myRead["ab_code"], typeof(string));
                grid1[Rows, 7].View = cc.left_cell;
                grid1[Rows, 7].Editor = cc.disable_cell;

                grid1[Rows, 8] = new SourceGrid.Cells.Cell(myRead["machine_row"], typeof(string));
                grid1[Rows, 8].View = cc.left_cell;
                grid1[Rows, 8].Editor = cc.disable_cell;

                grid1[Rows, 9] = new SourceGrid.Cells.Cell(myRead["cust_row"], typeof(string));
                grid1[Rows, 9].View = cc.left_cell;
                grid1[Rows, 9].Editor = cc.disable_cell;

                Rows++;
            }
            myRead.Close();
            DBConn.Close();

            if (Rows == 2)
            {
                MessageBox.Show("등록되어 있는 기계가 없습니다");
                this.Close();
            }
        }

        private void bClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void grid1_DoubleClick(object sender, EventArgs e)
        {
            string machine_row_id = grid1[grid1.Selection.ActivePosition.Row, 8].ToString().Trim();
            string customer_row_id = grid1[grid1.Selection.ActivePosition.Row, 9].ToString().Trim();

            this.machine_row_id = machine_row_id;
            this.customer_row_id = customer_row_id;

            this.Close();
        }

        private void bNotMachine_Click(object sender, EventArgs e)
        {
            this.machine_row_id = "";
            this.customer_row_id = "";

            this.Close();
        }
    }
}
