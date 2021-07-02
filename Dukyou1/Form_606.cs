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
    public partial class Form_606 : Form
    {
        string DB_TableName_grade = "C_ctp_danga_grade_manage";
        string DB_TableName_danga = "C_ctp_danga_model";
        SourceGridControl GridHandle = new SourceGridControl();
        const int start_grade_column = 4;   // 등급 전까지 컬럼 갯수
        int grade_count = 0;

        public Form_606()
        {
            InitializeComponent();
            
        }

        private void Form_606_Load(object sender, EventArgs e)
        {
            Screen srn = Screen.PrimaryScreen;
            int Xb = this.Width;  //좌,우
            int Yb = this.Height; //좌,우
            this.Location = new Point((srn.Bounds.Width - Xb) / 2, ((srn.Bounds.Height - Yb) / 2)-100);  //좌/우,위/아래

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

            string cQuery = "select * from " + DB_TableName_danga;
            cQuery += " order by substring(grade_name,2,1), substring(grade_name,1,1)";
            // 등급 테이블에서 등급 갯수 Get
            string sub_Query = "select count(*) as aa from " + DB_TableName_grade + " where use_config = true";
            var DBConn = new MySqlConnection(Config.DB_con1);
            DBConn.Open();

            var cmd = new MySqlCommand(sub_Query, DBConn);
            var myRead = cmd.ExecuteReader();
            myRead.Read();

            grade_count = Convert.ToInt32(myRead["aa"].ToString());
            myRead.Close();

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


            grid1[0, 3] = new MyHeader1("등급명");
            grid1[0, 3].RowSpan = 2;


            // 등급 테이블에서 등급명을 가져와 헤더로 뿌림
            sub_Query = "select * from " + DB_TableName_grade + " where use_config = true order by sort_no";

            cmd = new MySqlCommand(sub_Query, DBConn);
            myRead = cmd.ExecuteReader();

            grid1.Rows.Insert(2);
            grid1.Rows[2].Height = 24;
            grid1.Rows[2].Visible = false;
            for (int i = 0; i < grade_count; i++)
            {
                myRead.Read();
                grid1[0, i + start_grade_column] = new MyHeader1(myRead["pan_name"].ToString());
                grid1[1, i + start_grade_column] = new MyHeader1(myRead["pan_size"].ToString());
                grid1[2, i + start_grade_column] = new SourceGrid.Cells.Cell(myRead["column_name"].ToString(), typeof(string));
            }
            myRead.Close();
            //
            grid1.Columns[1].Width = 22;
            grid1.Columns[2].Width = 30;
            grid1.Columns[3].Width = 70;

            for (int i = 0; i < grade_count; i++)
            {
                grid1.Columns[i + start_grade_column].Width = 70;
            }

            int m = 3;
            string column_name = "";   // 컬럼 네임이 n1, n2 로 이어져 나감.

            cmd = new MySqlCommand(cQuery, DBConn);
            myRead = cmd.ExecuteReader();
            // 

            while (myRead.Read())
            {
                grid1.Rows.Insert(m);
                grid1.Rows[m].Height = 22;
                //
                grid1[m, 0] = new SourceGrid.Cells.Cell(myRead["row_id"], typeof(string));

                grid1[m, 1] = new SourceGrid.Cells.CheckBox(null, false);

                grid1[m, 2] = new SourceGrid.Cells.Cell((m - 2).ToString(), typeof(string));
                grid1[m, 2].View = cc.center_cell;
                grid1[m, 2].Editor = cc.disable_cell;

                grid1[m, 3] = new SourceGrid.Cells.Cell(myRead["grade_name"], typeof(string));
                grid1[m, 3].View = cc.center_cellr;
  

                for (int i = 0; i < grade_count; i++)
                {
                    column_name = grid1[2, i + start_grade_column].Value.ToString();
                    grid1[m, i + start_grade_column] = new SourceGrid.Cells.Cell(kc.numGetComma(GridHandle.decimaldel(myRead[column_name].ToString())), typeof(string));
                    grid1[m, i + start_grade_column].View = cc.int_cellr;
                }

                m++;
            }
            myRead.Close();
            DBConn.Close();
        }

        private void bDel_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("선택하신 항목을 삭제합니까 ?", "항목 삭제", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                GridHandle.ChkDataDelete(DB_TableName_danga, 3, 0, 1);
                Grid_View();
            }
        }

        private void bPanAdd_Click(object sender, EventArgs e)
        {
            Form_606a Frm = new Form_606a();
            Frm.ShowDialog();
            Grid_View();
        }

        private void bAdd_Click(object sender, EventArgs e)
        {
            string input_grade = Get_Last_code();
            string cQuery = "insert into " + DB_TableName_danga + " (grade_name) values('" + input_grade + "')";
            GridHandle.DataUpdate(cQuery);

            Grid_View();
            int rpos = grid1.RowsCount-1;
            var position = new SourceGrid.Position(rpos, 4);
            grid1.Selection.Focus(position, true);
        }

        private string Get_Last_code()
        {
            string cQuery = "select substring(max(grade_name),1,1) as a, substring(max(grade_name),2,1) as b from " + DB_TableName_danga;
            cQuery += " where substring(grade_name,2,1) = (select max(substring(grade_name,2,1)) from " + DB_TableName_danga + ")";

            var DBConn = new MySqlConnection(Config.DB_con1);
            DBConn.Open();

            var cmd = new MySqlCommand(cQuery, DBConn);
            var myRead = cmd.ExecuteReader();
            string grade_a = "";
            string grade_b = "";
            if (myRead.Read())
            {
                grade_a = myRead["a"].ToString();
                grade_b = myRead["b"].ToString();
            }
            myRead.Close();
            DBConn.Close();

            if (grade_a + grade_b == "")
            {
                return "A0";
            }

            if (grade_a == "Z")
            {
                grade_a = "A";
                try
                {
                    grade_b = (Convert.ToInt32(grade_b) + 1).ToString();
                }
                catch
                {
                    return "error";
                }
            }
            else
                grade_a = Convert.ToChar(Convert.ToUInt16(Convert.ToChar(grade_a.Substring(0, 1))) + 1).ToString();



            return grade_a + grade_b;
        }

        private void ValueChangedEvent1(object sender, EventArgs e)  //Grid1에서 볼륨첸지
        {
            
            string row_no = grid1[grid1.Selection.ActivePosition.Row, 0].ToString().Trim();
            int cpos = grid1.Selection.ActivePosition.Column;
            int rpos = grid1.Selection.ActivePosition.Row;
            if (cpos < 2)
                return;

            string dat = grid1[grid1.Selection.ActivePosition.Row, grid1.Selection.ActivePosition.Column].ToString().Trim();
            string column_name = "";
            string cQuery = "";
            string input_grade = Get_Last_code();
            if (cpos >= start_grade_column && cpos <= start_grade_column + grade_count)
            {
                column_name = grid1[2, cpos].Value.ToString();
                cQuery = " update " + DB_TableName_danga + " set " + column_name + "='" + dat + "' where row_id='" + row_no + "'";
            }
            else if (cpos == 3)
            {
                cQuery = "update " + DB_TableName_danga + " set grade_name = '" + dat + "' where row_id = '" + row_no + "'";
            }

            if (!cQuery.Equals(""))
            {
                GridHandle.DataUpdate(cQuery);
            }
            var position = new SourceGrid.Position(rpos, cpos);
            grid1.Selection.Focus(position, true);
        }

        private void bCopy_Click(object sender, EventArgs e)
        {
            ksgcontrol kc = new ksgcontrol();
            kc.ControlInit(Config.DB_con1, "", "", "");

            string cQuery = "";
            string row_no = "";
            string input_id = "";
            

            for (int i = 3; i < grid1.RowsCount; i++)
            {
                if (grid1[i, 1].Value.Equals(true))
                {
                    row_no = grid1[i, 0].Value.ToString();
                    cQuery = " insert into " + DB_TableName_danga + " (grade_name, n1,n2,n3,n4,n5,n6,n7,n8,n9,n10,n11,n12,n13,n14,n15,n16,n17,n18,n19,n20)";
                    cQuery += " select '" + Get_Last_code() +"', n1,n2,n3,n4,n5,n6,n7,n8,n9,n10,n11,n12,n13,n14,n15,n16,n17,n18,n19,n20 ";
                    cQuery += " from " + DB_TableName_danga + " where row_id='" + row_no + "'";

                    input_id = kc.DataUpdate(cQuery);
                }
            }

            Grid_View();
            int rpos = grid1.RowsCount - 1;
            var position = new SourceGrid.Position(rpos, 4);
            grid1.Selection.Focus(position, true);
        }

        private void bRefresh_Click(object sender, EventArgs e)
        {
            Grid_View();
        }

        private void Form_606_SizeChanged(object sender, EventArgs e)
        {
            this.grid1.Size = new System.Drawing.Size(this.Size.Width - 40, this.Height - 118);
        }

    }
}
