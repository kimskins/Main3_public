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
    public partial class Form_2115 : Form
    {
        SourceGridControl GridHandle = new SourceGridControl();

        string DB_TableName_prn_proper = "C_prn_properties";
        public Form_2115()
        {
            InitializeComponent();
        }

        private void Form_2115_Load(object sender, EventArgs e)
        {
            Screen srn = Screen.PrimaryScreen;
            int Xb = this.Width;  //좌,우
            int Yb = this.Height; //좌,우
            this.Location = new Point((srn.Bounds.Width - Xb) / 2, (srn.Bounds.Height - Yb) / 2);  //좌/우,위/아래

            GridHandle.SourceGrideInit(grid1, Config.DB_con1, Config.Ftp_ip1, Config.Ftp_id1, Config.Ftp_pw1);


            SourceGrid.Cells.Controllers.CustomEvents val_c1 = new SourceGrid.Cells.Controllers.CustomEvents();
            val_c1.ValueChanged += new EventHandler(ValueChangedEvent1);
            grid1.Controller.AddController(val_c1);

            
            Grid_View();
        }

        private void Grid_View()
        {
            string cQuery = "select a.*, b.bitem from " + DB_TableName_prn_proper + " as a";
            cQuery += " Left Outer Join C_bmodel as b on a.ab_code = concat(b.a_code, b.b_code) where b.a_code = '16' ";
            cQuery += " order by row_id";
            cell_d cc = new cell_d();
            // 
            grid1.Rows.Clear();
            grid1.BorderStyle = BorderStyle.FixedSingle;
            grid1.SelectionMode = SourceGrid.GridSelectionMode.Cell;
            grid1.ColumnsCount = 9;
            grid1.FixedRows = 2;
            grid1.Rows.Insert(0);
            grid1.Rows[0].Height = 24;
            grid1.Rows.Insert(1);
            grid1.Rows[1].Height = 24;
            //
            grid1[0, 0] = new MyHeader1("row_id");
            grid1.Columns[0].Visible = false;

            grid1[0, 1] = new MyHeader1("√");
            grid1[0, 1].RowSpan = 2;

            grid1[0, 2] = new MyHeader1("No");
            grid1[0, 2].RowSpan = 2;

            grid1[0, 3] = new MyHeader1("제본방식");
            grid1[0, 3].RowSpan = 2;

            grid1[0, 4] = new MyHeader1("최대사이즈");
            grid1[0, 4].ColumnSpan = 2;

            grid1[0, 6] = new MyHeader1("최소사이즈");
            grid1[0, 6].ColumnSpan = 2;

            grid1[0, 8] = new MyHeader1("최소재단\r\n사이즈");
            grid1[0, 8].RowSpan = 2;

            grid1[1, 4] = new MyHeader1("너비");
            grid1[1, 5] = new MyHeader1("도지");
            grid1[1, 6] = new MyHeader1("너비");
            grid1[1, 7] = new MyHeader1("도지");
            

            //
            grid1.Columns[1].Width = 22;
            grid1.Columns[2].Width = 30;
            grid1.Columns[3].Width = 150;
            grid1.Columns[4].Width = 80;
            grid1.Columns[5].Width = 80;
            grid1.Columns[6].Width = 80;
            grid1.Columns[7].Width = 80;
            grid1.Columns[8].Width = 90;
                        //
            MySqlConnection DBConn;

            DBConn = new MySqlConnection(Config.DB_con1);
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

                grid1[m, 2] = new SourceGrid.Cells.Cell((m-1).ToString(), typeof(string));
                grid1[m, 2].View = cc.center_cell;
                grid1[m, 2].Editor = cc.disable_cell;

                grid1[m, 3] = new SourceGrid.Cells.Cell(myRead["bitem"], typeof(string));
                grid1[m, 3].View = cc.left_cell;
                grid1[m, 3].Editor = cc.disable_cell;

                grid1[m, 4] = new SourceGrid.Cells.Cell(myRead["max_width"], typeof(string));
                grid1[m, 4].View = cc.center_cell;

                grid1[m, 5] = new SourceGrid.Cells.Cell(myRead["max_doji"], typeof(string));
                grid1[m, 5].View = cc.center_cell;

                grid1[m, 6] = new SourceGrid.Cells.Cell(myRead["min_width"], typeof(string));
                grid1[m, 6].View = cc.center_cell;

                grid1[m, 7] = new SourceGrid.Cells.Cell(myRead["min_doji"], typeof(string));
                grid1[m, 7].View = cc.center_cell;

                grid1[m, 8] = new SourceGrid.Cells.Cell(myRead["minimum_cut_size"], typeof(string));
                grid1[m, 8].View = cc.center_cell;

                m++;
            }
            myRead.Close();
            DBConn.Close();
        }

        private void ValueChangedEvent1(object sender, EventArgs e)  //Grid1에서 볼륨첸지
        {
            int cpos = grid1.Selection.ActivePosition.Column;
            int rpos = grid1.Selection.ActivePosition.Row;

            if (rpos < 0)
                return;

            string cQuery = "";
            string row_no = grid1[rpos, 0].ToString().Trim();
            string dat = grid1[rpos, cpos].ToString().Trim();
            //
            //
            if (cpos.Equals(4))       //
                cQuery = " update " + DB_TableName_prn_proper + " set max_width='" + dat + "' where row_id='" + row_no + "'";
            else if (cpos.Equals(5))       //
                cQuery = " update " + DB_TableName_prn_proper + " set max_doji='" + dat + "' where row_id='" + row_no + "'";
            else if (cpos.Equals(6))       //
                cQuery = " update " + DB_TableName_prn_proper + " set min_width='" + dat + "' where row_id='" + row_no + "'";
            else if (cpos.Equals(7))       //
                cQuery = " update " + DB_TableName_prn_proper + " set min_doji='" + dat + "' where row_id='" + row_no + "'";
            else if (cpos.Equals(8))       //
                cQuery = " update " + DB_TableName_prn_proper + " set minimum_cut_size='" + dat + "' where row_id='" + row_no + "'";
            
            //
            if (!cQuery.Equals(""))
            {
                if (GridHandle.DataUpdate(cQuery) == 1)
                {
                    MessageBox.Show("서버에라 발생으로 수정되지 않았습니다.");
                }
            }
        }

        private void bAdd_Click(object sender, EventArgs e)
        {
            string cQuery = "";
            Form_2115a Frm = new Form_2115a();
            if (Frm.ShowDialog() == DialogResult.OK)
            {
                for (int i = 1; i < Frm.grid1.RowsCount; i++)
                {
                    if (Frm.grid1[i, 1].Value.Equals(true))
                    {
                        cQuery = "insert into " + DB_TableName_prn_proper + " (ab_code) values('" + Frm.grid1[i, 3].ToString() + "')";
                        GridHandle.DataUpdate(cQuery);
                    }
                }
                MessageBox.Show("추가하였습니다. 고객에게 반영되기 위해서는 개발자에게 문의하여야 합니다. DB_ver 조절");
                // 추가는 C_prn_properties에 한것이고 고객이 L_prn_properties로 복사해 가야 한다. 그래서 DB_ver에서 추가된 필드만 복사해가도록 조치해야함
            }
            Grid_View();
            
        }

        private void bDel_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("선택하신 항목을 삭제합니까 ?", "항목 삭제", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                GridHandle.ChkDataDelete(DB_TableName_prn_proper, 2, 0, 1);
            }
        }
    }
}
