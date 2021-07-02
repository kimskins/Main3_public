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
    public partial class Form_606a : Form
    {
        string DB_TableName_grade = "C_ctp_danga_grade_manage";
        string DB_TableName_danga = "C_ctp_danga_model";
        SourceGridControl GridHandle = new SourceGridControl();

        public Form_606a()
        {
            InitializeComponent();
        }

        private void Form_606a_Load(object sender, EventArgs e)
        {
            Screen srn = Screen.PrimaryScreen;
            int Xb = this.Width;  //좌,우
            int Yb = this.Height; //좌,우
            this.Location = new Point((srn.Bounds.Width - Xb) / 2, ((srn.Bounds.Height - Yb) / 2) - 100);  //좌/우,위/아래

            GridHandle.SourceGrideInit(grid1, Config.DB_con1);

            SourceGrid.Cells.Controllers.CustomEvents val_c1 = new SourceGrid.Cells.Controllers.CustomEvents();
            val_c1.ValueChanged += new EventHandler(ValueChangedEvent1);
            grid1.Controller.AddController(val_c1);

            Grid_View();
        }


        private void Grid_View()
        {
            string cQuery = "select * from " + DB_TableName_grade + " where use_config = true order by sort_no";

            cell_d cc = new cell_d();
            // 
            grid1.Rows.Clear();
            grid1.BorderStyle = BorderStyle.FixedSingle;
            grid1.SelectionMode = SourceGrid.GridSelectionMode.Cell;
            grid1.ColumnsCount = 7;
            grid1.FixedRows = 1;
            grid1.Rows.Insert(0);
            grid1.Rows[0].Height = 24;

            //
            grid1[0, 0] = new MyHeader1("row_id");
            grid1.Columns[0].Visible = false;

            grid1[0, 1] = new MyHeader1("√");

            grid1[0, 2] = new MyHeader1("sort_no");
            grid1.Columns[2].Visible = false;
            grid1[0, 3] = new MyHeader1("no");

            grid1[0, 4] = new MyHeader1("판형");
            grid1[0, 5] = new MyHeader1("판사이즈");

            grid1[0, 6] = new MyHeader1("컬럼명");
            grid1.Columns[6].Visible = false;
            //
            grid1.Columns[1].Width = 22;
            grid1.Columns[3].Width = 30;
            grid1.Columns[4].Width = 100;
            grid1.Columns[5].Width = 100;

            int m = 1;

            var DBConn = new MySqlConnection(Config.DB_con1);
            DBConn.Open();
            var cmd = new MySqlCommand(cQuery, DBConn);
            var myRead = cmd.ExecuteReader();
            // 
            while (myRead.Read())
            {
                grid1.Rows.Insert(m);
                grid1.Rows[m].Height = 22;
                //
                grid1[m, 0] = new SourceGrid.Cells.Cell(myRead["row_id"], typeof(string));
                grid1[m, 1] = new SourceGrid.Cells.CheckBox(null, false);
                grid1[m, 2] = new SourceGrid.Cells.Cell(myRead["sort_no"], typeof(string));
                grid1[m, 3] = new SourceGrid.Cells.Cell((m).ToString(), typeof(string));
                grid1[m, 3].View = cc.center_cell;
                grid1[m, 3].Editor = cc.disable_cell;

                grid1[m, 4] = new SourceGrid.Cells.Cell(myRead["pan_name"], typeof(string));
                grid1[m, 4].View = cc.center_cell;
                grid1[m, 5] = new SourceGrid.Cells.Cell(myRead["pan_size"], typeof(string));
                grid1[m, 5].View = cc.center_cell;
                grid1[m, 6] = new SourceGrid.Cells.Cell(myRead["column_name"], typeof(string));

                m++;
            }
            myRead.Close();
            DBConn.Close();
        }

        private void bAdd_Click(object sender, EventArgs e)
        {

            string cQuery = "select min(row_id), sort_no from " + DB_TableName_grade + "  where use_config = false ";
            string cQuery2 = "";
            var DBConn = new MySqlConnection(Config.DB_con1);
            DBConn.Open();
            var cmd = new MySqlCommand(cQuery, DBConn);
            var myRead = cmd.ExecuteReader();
            string temp = "";
            // sort num은 무조건 1~20 사이에서 움직인다는 전제하에 코딩
            string now_insert_sort_no = "";
            if (myRead.Read())
            {
                now_insert_sort_no = myRead["sort_no"].ToString();
                if (now_insert_sort_no == "")
                {
                    MessageBox.Show("판형은 최대 20개까지만 지원합니다");
                    return;
                }
                temp = now_insert_sort_no;
                myRead.Close();

                cQuery = " select row_id, sort_no from " + DB_TableName_grade + " where sort_no > " + now_insert_sort_no + " and use_config = true  order by sort_no";
                cmd = new MySqlCommand(cQuery, DBConn);
                myRead = cmd.ExecuteReader();
                while (myRead.Read())
                {

                    cQuery2 = "update " + DB_TableName_grade + " set sort_no = '" + temp + "' where row_id = '" + myRead["row_id"].ToString() + "'";
                    GridHandle.DataUpdate(cQuery2);
                    temp = myRead["sort_no"].ToString();
                }
                cQuery = "update " + DB_TableName_grade + " set use_config = true, sort_no = '" + temp + "', pan_name='판형 입력' , pan_size = 'size 입력' ";
                cQuery += " where row_id = (select min(row_id) from (select * from " + DB_TableName_grade + "  where use_config = false ) as bb)";
                GridHandle.DataUpdate(cQuery);

                myRead.Close();
                DBConn.Close();
                Grid_View();
                var position = new SourceGrid.Position(grid1.Rows.Count - 1, 4);
                grid1.Selection.Focus(position, true);
            }
            else
            {
                myRead.Close();
                DBConn.Close();
            }
        }

        private void bDel_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("선택하신 항목을 삭제합니까 ?", "항목 삭제", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                string cQuery = "";
                for (int i = 1; i < grid1.RowsCount; i++)
                {
                    if (grid1[i, 1].Value.Equals(true))
                    {
                        cQuery = "update " + DB_TableName_grade + " set use_config = false where row_id = '" + grid1[i, 0].Value.ToString().Trim() + "'";
                        GridHandle.DataUpdate(cQuery);
                        cQuery = "update " + DB_TableName_danga + " set " + grid1[i, 6].Value.ToString() + "=0";
                        GridHandle.DataUpdate(cQuery);
                    }
                }
                Grid_View();
            }
        }

        private void bUp_Click(object sender, EventArgs e)
        {
            GridHandle.ChkMoveUp(1, 1, 0, 2, "sort_no", 3, DB_TableName_grade);
        }

        private void bDown_Click(object sender, EventArgs e)
        {
            GridHandle.ChkMoveDown(1, 1, 0, 2, "sort_no", 3, DB_TableName_grade);
        }

        private void ValueChangedEvent1(object sender, EventArgs e)  //Grid1에서 볼륨첸지
        {
            string row_no = grid1[grid1.Selection.ActivePosition.Row, 0].ToString().Trim();
            int cpos = grid1.Selection.ActivePosition.Column;
            int rpos = grid1.Selection.ActivePosition.Row;
            string dat = grid1[grid1.Selection.ActivePosition.Row, grid1.Selection.ActivePosition.Column].ToString().Trim().Replace(",", "");
            cell_d cc = new cell_d();
            string cQuery = "";
            //
            if (cpos.Equals(4))       //판명
            {

                cQuery = " update " + DB_TableName_grade + " set pan_name='" + dat + "' where row_id='" + row_no + "'";

            }
            else if (cpos.Equals(5))       //판 size
            {

                cQuery = " update " + DB_TableName_grade + " set pan_size='" + dat + "' where row_id='" + row_no + "'";

            }

            if (!cQuery.Equals(""))
            {
                GridHandle.DataUpdate(cQuery);
            }

        }
    }
}
