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
    public partial class Form_3072 : Form
    {
        const string flag_id = "1";       //1이면 전체견적. 0이면 %견적
        int gubun_count = 0;                //구분 갯수
        int grade_count = 0;                // 등급 갯수
        const int start_grade_column = 8;   // 등급 전까지 컬럼 갯수
        string DB_TableName_gyeon = "C_detail_gyeon_model";
        string DB_TableName_gubun = "C_detail_gyeon_gubun_manage";
        string DB_TableName_grade = "C_detail_gyeon_grade_manage";
        SourceGridControl GridHandle = new SourceGridControl();
        string customer = "";   
        public Form_3072()
        {
            InitializeComponent();
            Screen srn = Screen.PrimaryScreen;
            int Xb = this.Width;  //좌,우
            int Yb = this.Height; //좌,우
            this.Location = new Point((srn.Bounds.Width - Xb) / 2, ((srn.Bounds.Height - Yb) / 2) - 100);  //좌/우,위/아래
        }
        public Form_3072(string customer)
        {
            InitializeComponent();
            this.customer = customer;
            if (customer != "")
            {
                this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            }
            groupBox1.Visible = false;
            groupBox2.Visible = false;
            groupBox3.Visible = false;
        }

        private void Form_3092_Load(object sender, EventArgs e)
        {
            GridHandle.SourceGrideInit(grid1, Config.DB_con1);

            SourceGrid.Cells.Controllers.CustomEvents val_c1 = new SourceGrid.Cells.Controllers.CustomEvents();
            val_c1.ValueChanged += new EventHandler(ValueChangedEvent1);
            grid1.Controller.AddController(val_c1);

            Grid_View();
        }

        private void Grid_View()
        {
            ksgcontrol kc = new ksgcontrol();
            kc.ControlInit(Config.DB_con1, "", "", "");

            string cQuery = "select a.*, b.* from " + DB_TableName_gyeon + " as a left outer join " + DB_TableName_gubun + " as b";
            cQuery += " on a.gubun_id = b.row_id where a.flag = '" + flag_id + "' order by sales_min, sales_max, a.row_id";
            // 등급 테이블에서 등급 갯수 Get
            string sub_Query = "select count(*) as aa from " + DB_TableName_grade + " where use_config = true and flag_id='" + flag_id + "'";
            var DBConn = new MySqlConnection(Config.DB_con1);
            DBConn.Open();

            var cmd = new MySqlCommand(sub_Query, DBConn);
            var myRead = cmd.ExecuteReader();
            myRead.Read();

            grade_count = Convert.ToInt32(myRead["aa"].ToString());
            myRead.Close();

            // 구분 테이블에서 구분 갯수 Get
            sub_Query = "select count(*) as aa from " + DB_TableName_gubun;

            cmd = new MySqlCommand(sub_Query, DBConn);
            myRead = cmd.ExecuteReader();
            myRead.Read();

            gubun_count = Convert.ToInt32(myRead["aa"].ToString());
            myRead.Close();

            //// grid 사이즈 조절
            //int grid_width = 337 + (grade_count * 70)+20;
            //if (grid_width > 1400)
            //    grid_width = 1400;
            //grid1.Size = new System.Drawing.Size(grid_width, 519);
            //this.Size = new System.Drawing.Size(grid_width+40, this.Height);

            cell_d cc = new cell_d();
            // 
            grid1.Rows.Clear();
            grid1.BorderStyle = BorderStyle.FixedSingle;

            grid1.SelectionMode = SourceGrid.GridSelectionMode.Row;
            grid1.ColumnsCount = grade_count + start_grade_column;
            grid1.FixedRows = 3;
            grid1.FixedColumns = start_grade_column;
            grid1.Rows.Insert(0);
            grid1.Rows[0].Height = 24;
            grid1.Rows.Insert(1);
            grid1.Rows[1].Height = 24;
            //
            grid1[0, 0] = new MyHeader1("row_id");
            grid1.Columns[0].Visible = false;

            grid1[0, 0].RowSpan = 2;

            grid1[0, 1] = new MyHeader1("√");
            grid1[0, 1].RowSpan = 2;

            grid1[0, 2] = new MyHeader1("no");
            grid1[0, 2].RowSpan = 2;

            grid1[0, 3] = new MyHeader1("leader_num");
            grid1[0, 3].RowSpan = 2;
            grid1.Columns[3].Visible = false;

            grid1[0, 4] = new MyHeader1("매출액(구간)");
            grid1[0, 4].ColumnSpan = 2;

            grid1[0, 6] = new MyHeader1("구분");
            grid1[0, 6].RowSpan = 2;

            grid1[0, 7] = new MyHeader1("가산단위");
            grid1[0, 7].RowSpan = 2;

            if (grade_count != 0)
            {
                grid1[0, 8] = new MyHeader1("등급");
                grid1[0, 8].ColumnSpan = grade_count;
            }

            grid1[1, 4] = new MyHeader1("< 최소");
            grid1[1, 5] = new MyHeader1("최대 ≤");


            // 등급 테이블에서 등급명을 가져와 헤더로 뿌림
            sub_Query = "select * from " + DB_TableName_grade + " where use_config = true and flag_id='" + flag_id + "' order by sort_no";

            cmd = new MySqlCommand(sub_Query, DBConn);
            myRead = cmd.ExecuteReader();

            grid1.Rows.Insert(2);
            grid1.Rows[2].Height = 24;
            grid1.Rows[2].Visible = false;
            for (int i = 0; i < grade_count; i++)
            {
                myRead.Read();
                grid1[1, i + start_grade_column] = new MyHeader1(myRead["grade_name"].ToString());
                grid1[2, i + start_grade_column] = new SourceGrid.Cells.Cell(myRead["column_name"].ToString(), typeof(string));
            }
            myRead.Close();
            //
            grid1.Columns[1].Width = 22;
            grid1.Columns[2].Width = 30;
            grid1.Columns[4].Width = 70;
            grid1.Columns[5].Width = 70;
            grid1.Columns[6].Width = 80;
            grid1.Columns[7].Width = 85;
            for (int i = 0; i < grade_count; i++)
            {
                grid1.Columns[i + start_grade_column].Width = 70;
            }

            int m = 3;
            int set_count = 0;         // 1씩 증가하며 구분갯수에 도달시 다시 0으로 변환. 셋트에 몇번째 데이터인지 구분하기 위한 인자값
            int leader_num = 0;         // set의 리더 넘버
            int row_no = 0;             // no에 들어갈 번호
            string column_name = "";   // 컬럼 네임이 n1, n2 로 이어져 나감.

            cmd = new MySqlCommand(cQuery, DBConn);
            myRead = cmd.ExecuteReader();
            // 

            while (myRead.Read())
            {
                grid1.Rows.Insert(m);
                grid1.Rows[m].Height = 22;
                set_count++;
                //
                grid1[m, 0] = new SourceGrid.Cells.Cell(myRead["row_id"], typeof(string));

                if (set_count == gubun_count)
                {
                    grid1[m - gubun_count + 1, 1] = new SourceGrid.Cells.CheckBox(null, false);

                    row_no = ((m - 2) / gubun_count);
                    grid1[m - gubun_count + 1, 2] = new SourceGrid.Cells.Cell((row_no).ToString(), typeof(string));
                    grid1[m - gubun_count + 1, 2].View = cc.center_cell;
                    grid1[m - gubun_count + 1, 2].Editor = cc.disable_cell;

                    grid1[m - gubun_count + 1, 1].RowSpan = gubun_count;
                    grid1[m - gubun_count + 1, 2].RowSpan = gubun_count;
                    set_count = 0;
                }

                if (set_count == 1)
                    leader_num = m;

                grid1[m, 3] = new SourceGrid.Cells.Cell(leader_num.ToString(), typeof(string));

                grid1[m, 4] = new SourceGrid.Cells.Cell(myRead["sales_min"], typeof(string));
                grid1[m, 4].View = cc.int_cell;
                grid1[m, 4].Editor = cc.disable_cell;

                grid1[m, 5] = new SourceGrid.Cells.Cell(myRead["sales_max"], typeof(string));
                grid1[m, 5].View = cc.int_cell;
                grid1[m, 5].Editor = cc.disable_cell;

                grid1[m, 6] = new SourceGrid.Cells.Cell(myRead["gubun"], typeof(string));
                grid1[m, 6].View = cc.center_cell;
                grid1[m, 6].Editor = cc.disable_cell;

                grid1[m, 7] = new SourceGrid.Cells.Cell("[" + myRead["add_unit"] + "]", typeof(string));
                grid1[m, 7].View = cc.center_cell;
                grid1[m, 7].Editor = cc.disable_cell;

                for (int i = 0; i < grade_count; i++)
                {
                    column_name = grid1[2, i + start_grade_column].Value.ToString();
                    grid1[m, i + start_grade_column] = new SourceGrid.Cells.Cell(kc.numGetComma(GridHandle.decimaldel(myRead[column_name].ToString())), typeof(string));
                    grid1[m, i + start_grade_column].View = cc.int_cell;
                    if (customer != "")
                    {
                        grid1[m, i + start_grade_column].Editor = cc.disable_cell;
                    }
                }

                m++;
            }
            myRead.Close();
            DBConn.Close();

        }

        private void bMody_Click(object sender, EventArgs e)
        {
            string cQuery = "";
            int chk_num = 0;
            int leader_num = 0;
            string[] row_id_arr = new string[6];
            cell_d cc = new cell_d();
            for (int i = 3; i < grid1.RowsCount; i = i + gubun_count)
            {
                if (grid1[i, 1].Value.Equals(true))
                {
                    chk_num++;
                    leader_num = Convert.ToInt32(grid1[i, 3].Value.ToString());
                }
            }
            if (chk_num > 1)
            {
                MessageBox.Show("수정시 체크는 하나만 해야합니다");
                return;
            }
            else if (chk_num == 0)
            {
                MessageBox.Show("체크된 항목이 없습니다.");
                return;
            }
            else
            {
                Form_3072c Frm = new Form_3072c(flag_id, DB_TableName_gyeon);
                Frm.ShowDialog();
                if (Frm.bConfirm_chk)   // 확인을 눌러서 닫힌 거라면..
                {
                    for (int i = 0; i < gubun_count; i++)
                    {
                        row_id_arr[i] = grid1[leader_num + i, 0].Value.ToString();
                        grid1[leader_num + i, 4] = new SourceGrid.Cells.Cell(Frm.start_price, typeof(string));
                        grid1[leader_num + i, 4].View = cc.int_cell;
                        grid1[leader_num + i, 4].Editor = cc.disable_cell;
                        grid1[leader_num + i, 5] = new SourceGrid.Cells.Cell(Frm.end_price, typeof(string));
                        grid1[leader_num + i, 5].View = cc.int_cell;
                        grid1[leader_num + i, 5].Editor = cc.disable_cell;
                    }

                    cQuery = "update " + DB_TableName_gyeon + " set sales_min = '" + Frm.start_price + "', sales_max='" + Frm.end_price + "'";
                    cQuery += " where row_id = '" + row_id_arr[0] + "' or row_id = '" + row_id_arr[1] + "' or row_id = '" + row_id_arr[2] + "' or";
                    cQuery += " row_id = '" + row_id_arr[3] + "' or row_id = '" + row_id_arr[4] + "' or row_id = '" + row_id_arr[5] + "'";
                    GridHandle.DataUpdate(cQuery);
                    Grid_View();
                }
            }
        }

        private void bGradeMody_Click(object sender, EventArgs e)
        {
            Form_3072a Frm = new Form_3072a("1"); // 1은 전체견적, 0는 % 견적
            Frm.ShowDialog();
            Grid_View();
        }

        private void bAdd_Click(object sender, EventArgs e)
        {
            Form_3072b Frm = new Form_3072b(gubun_count, flag_id, DB_TableName_gyeon);
            Frm.ShowDialog();
            if (Frm.bConfirm_chk)    // 확인버튼을 누르고 나와야 갱신
                Grid_View();
        }

        private void bDel_Click(object sender, EventArgs e)
        {
            string cQuery = "";
            string sub = "";
            int chk_num = 0;

            string[] row_id_arr = new string[grid1.RowsCount];

            for (int i = 0; i < grid1.RowsCount; i++)
                row_id_arr[i] = "";
            cell_d cc = new cell_d();

            for (int i = 3; i < grid1.RowsCount; i = i + gubun_count)
            {
                if (grid1[i, 1].Value.Equals(true))
                {
                    for (int y = 0; y < gubun_count; y++)
                    {
                        sub += " or row_id = '" + grid1[i + y, 0].Value.ToString() + "'";
                    }
                    chk_num++;
                }
            }

            if (chk_num == 0)
            {
                MessageBox.Show("체크된 항목이 없습니다.");
                return;
            }
            else
            {
                cQuery = "delete from " + DB_TableName_gyeon + " where row_id = 0" + sub;
                GridHandle.DataUpdate(cQuery);
            }
            Grid_View();
        }

        private void ValueChangedEvent1(object sender, EventArgs e)  //Grid1에서 볼륨첸지
        {
            string row_no = grid1[grid1.Selection.ActivePosition.Row, 0].ToString().Trim();
            int cpos = grid1.Selection.ActivePosition.Column;
            int rpos = grid1.Selection.ActivePosition.Row;
            string dat = grid1[grid1.Selection.ActivePosition.Row, grid1.Selection.ActivePosition.Column].ToString().Trim();
            string column_name = "";
            string cQuery = "";

            if (cpos >= start_grade_column && cpos <= start_grade_column + grade_count)
            {
                column_name = grid1[2, cpos].Value.ToString();
                cQuery = " update " + DB_TableName_gyeon + " set " + column_name + "='" + dat + "' where row_id='" + row_no + "'";
            }

            if (!cQuery.Equals(""))
            {
                GridHandle.DataUpdate(cQuery);
            }
            var position = new SourceGrid.Position(rpos, cpos);
            grid1.Selection.Focus(position, true);
        }

        private void bAutoInsert_Click(object sender, EventArgs e)
        {
            int chk_num = 0;
            int[] leader_num = new int[grid1.RowsCount / gubun_count];
            for (int i = 3; i < grid1.RowsCount; i = i + gubun_count)
            {
                if (grid1[i, 1].Value.Equals(true))
                {
                    leader_num[chk_num] = Convert.ToInt32(grid1[i, 3].Value.ToString());
                    chk_num++;
                }
            }
            Form_3072d Frm = new Form_3072d(chk_num, leader_num, gubun_count, grid1);
            Frm.ShowDialog();
            if (Frm.bConfirm_flag)
                Grid_View();
        }



    }
}
