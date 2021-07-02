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
    public partial class Form_2017 : Form
    {
        SourceGridControl GridHandle = new SourceGridControl();
        ksgcontrol kc = new ksgcontrol();

        cell_d cc = new cell_d();
        DataTable hang_dt = new DataTable();

        string DB_TableName_hang = "hang_manage";
        string DB_TableName_prn_machine = "C_prn_machine_dat";
        public Form_2017()
        {
            InitializeComponent();
        }

        private void Form_2017_Load(object sender, EventArgs e)
        {
            Screen srn = Screen.PrimaryScreen;
            int Xb = this.Width;  //좌,우
            this.Location = new Point((srn.Bounds.Width - Xb) / 2, 1);  //좌/우,위/아래

            GridHandle.SourceGrideInit(grid1, Config.DB_con1);
            kc.ControlInit(Config.DB_con1, "", "", "");
            
            sync sy = new sync();
            string cQuery = "select * from " + DB_TableName_hang + " where class = '별색색상' or class = '별색인쇄면적'";
            sy.dt(Config.DB_con1, hang_dt, cQuery);

            string[] color = new string[] { };
            cQuery = "select hang from " + DB_TableName_hang + " where class = '별색색상' ";
            grid_combobox(color, cQuery, "hang");

            string[] prn_size = new string[] { };
            cQuery = "select hang from " + DB_TableName_hang + " where class = '별색인쇄면적' ";

            grid_combobox(prn_size, cQuery, "hang");

            SourceGrid.Cells.Controllers.CustomEvents val_c1 = new SourceGrid.Cells.Controllers.CustomEvents();
            val_c1.ValueChanged += new EventHandler(ValueChangedEvent1);
            grid1.Controller.AddController(val_c1);

            grid1_view();
        }
        private void grid1_view()
        {
            grid1.Rows.Clear();
            grid1.BorderStyle = BorderStyle.FixedSingle;

            grid1.SelectionMode = SourceGrid.GridSelectionMode.Cell;
            grid1.ColumnsCount = 7;
            grid1.FixedRows = 2;
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

            grid1[0, 2] = new MyHeader1("No");
            grid1[0, 2].RowSpan = 2;

            grid1[0, 3] = new MyHeader1("색상 및 인쇄면적");
            grid1[0, 3].ColumnSpan = 2;
            grid1[0, 3].RowSpan = 2;

            grid1[0, 5] = new MyHeader1("인쇄기계별 할증율");
            grid1[0, 5].ColumnSpan = 2;

            grid1[1, 5] = new MyHeader1("1/1, 1/0, 2/2, 2/0");
            grid1[1, 6] = new MyHeader1("나머지");


            grid1.Columns[1].Width = 25;
            grid1.Columns[2].Width = 30;
            grid1.Columns[3].Width = 80;
            grid1.Columns[4].Width = 200;
            grid1.Columns[5].Width = 100;
            grid1.Columns[6].Width = 100;

            string cQuery = "select a.*, b.hang as color, c.hang as size from " + DB_TableName_prn_machine + "  as a ";
            cQuery += " left outer join " + DB_TableName_hang + "  as b on a.color_code = b.code1 and b.class = '별색색상' ";
            cQuery += " left outer join " + DB_TableName_hang + "  as c on a.prn_code = c.code1 and c.class = '별색인쇄면적'";

            var DBConn = new MySqlConnection(Config.DB_con1);
            DBConn.Open();

            var cmd = new MySqlCommand(cQuery, DBConn);
            var myRead = cmd.ExecuteReader();


            // 
            int m = 2;

            while (myRead.Read())
            {
                grid1.Rows.Insert(m);
                grid1.Rows[m].Height = 22;
                //
                grid1[m, 0] = new SourceGrid.Cells.Cell(myRead["row_id"], typeof(string));

                grid1[m, 1] = new SourceGrid.Cells.CheckBox(null, false);

                grid1[m, 2] = new SourceGrid.Cells.Cell((m - 1).ToString(), typeof(string));
                grid1[m, 2].View = cc.center_cell;
                grid1[m, 2].Editor = cc.disable_cell;

                grid1[m, 3] = new SourceGrid.Cells.Cell(myRead["color"].ToString(), typeof(string));
                grid1[m, 3].View = cc.center_cell;
                grid1[m, 3].Editor = GridHandle.CbBox[0];

                grid1[m, 4] = new SourceGrid.Cells.Cell(myRead["size"].ToString(), typeof(string));
                grid1[m, 4].View = cc.left_cell;
                grid1[m, 4].Editor = GridHandle.CbBox[1];

                grid1[m, 5] = new SourceGrid.Cells.Cell(myRead["dat"].ToString(), typeof(string));
                grid1[m, 5].View = cc.center_cell;

                grid1[m, 6] = new SourceGrid.Cells.Cell(myRead["rest_dat"].ToString(), typeof(string));
                grid1[m, 6].View = cc.center_cell;
                m++;
            }
            myRead.Close();
            DBConn.Close();
        }
        private void grid_combobox(string[] arr_name, string bQuery, string column)
        {
            MySqlConnection DBConn;
            DBConn = new MySqlConnection(Config.DB_con1);
            DBConn.Open();
            arr_name = new string[] { };
            var cmd = new MySqlCommand(bQuery, DBConn);
            var myRead = cmd.ExecuteReader();
            int i = 0;
            string temp = "";
            while (myRead.Read())
            {
                temp += "#" + myRead[column].ToString();
                i++;
            }
            myRead.Close();
            DBConn.Close();
            temp = temp.Substring(1);
            arr_name = temp.Split('#');
            GridHandle.InputComboItem(arr_name);
        }

        private void ValueChangedEvent1(object sender, EventArgs e)  //Grid1에서 볼륨첸지
        {
            int cpos = grid1.Selection.ActivePosition.Column;
            int rpos = grid1.Selection.ActivePosition.Row;
            string dat = grid1[rpos, cpos].ToString().Trim();
            string cQuery = "";
            string row_no = grid1[rpos, 0].ToString().Trim();

            if (cpos == 3)
            {
                DataRow[] hang_dr = hang_dt.Select("hang = '" + dat + "' and class = '별색색상'");
                if (hang_dr.Length != 0)
                    dat = hang_dr[0]["code1"].ToString();
                else
                {
                    MessageBox.Show("정확한 데이터를 입력 해 주세요");
                    return;
                }
                cQuery = "update " + DB_TableName_prn_machine + " set color_code = '" + dat + "' where row_id = " + row_no;
            }

            if (cpos == 4)
            {
                DataRow[] hang_dr = hang_dt.Select("hang = '" + dat + "' and class = '별색인쇄면적'");
                if (hang_dr.Length != 0)
                    dat = hang_dr[0]["code1"].ToString();
                else
                {
                    MessageBox.Show("정확한 데이터를 입력 해 주세요");
                    return;
                }
                cQuery = "update " + DB_TableName_prn_machine + " set prn_code = '" + dat + "' where row_id = " + row_no;
            }

            if (cpos == 5)
                cQuery = "update " + DB_TableName_prn_machine + " set dat = '" + dat + "' where row_id = " + row_no;
            

            if (cpos == 6)
                cQuery = "update " + DB_TableName_prn_machine + " set rest_dat = '" + dat + "' where row_id = " + row_no;
            
            if (!cQuery.Equals(""))
            {
                GridHandle.DataUpdate(cQuery);
            }
            var position = new SourceGrid.Position(rpos, cpos);
            grid1.Selection.Focus(position, true);
        }

        private void bAdd_Click(object sender, EventArgs e)
        {
            string cQuery = "insert into " + DB_TableName_prn_machine + " values()";
            string row_no = kc.DataUpdate(cQuery);

            int m = grid1.RowsCount;
            grid1.Rows.Insert(m);
            grid1.Rows[m].Height = 22;
            //
            grid1[m, 0] = new SourceGrid.Cells.Cell(row_no, typeof(string));

            grid1[m, 1] = new SourceGrid.Cells.CheckBox(null, false);

            grid1[m, 2] = new SourceGrid.Cells.Cell((m-1).ToString(), typeof(string));
            grid1[m, 2].View = cc.center_cell;
            grid1[m, 2].Editor = cc.disable_cell;

            grid1[m, 3] = new SourceGrid.Cells.Cell("", typeof(string));
            grid1[m, 3].View = cc.center_cell;
            grid1[m, 3].Editor = GridHandle.CbBox[0];

            grid1[m, 4] = new SourceGrid.Cells.Cell("", typeof(string));
            grid1[m, 4].View = cc.left_cell;
            grid1[m, 4].Editor = GridHandle.CbBox[1];

            grid1[m, 5] = new SourceGrid.Cells.Cell("", typeof(string));
            grid1[m, 5].View = cc.center_cell;

            grid1[m, 6] = new SourceGrid.Cells.Cell("", typeof(string));
            grid1[m, 6].View = cc.center_cell;
        }

        private void bDel_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("삭제하시겠습니까?", "메세지창", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                GridHandle.ChkDataDelete(DB_TableName_prn_machine, 2, 0, 1);

                for (int i = 2; i < grid1.RowsCount; i++)
                {
                    grid1[i, 2] = new SourceGrid.Cells.Cell((i - 1), typeof(string));
                    grid1[i, 2].Editor = cc.disable_cell;
                    grid1[i, 2].View = cc.center_cell;
                }
            }
        }
    }


}
