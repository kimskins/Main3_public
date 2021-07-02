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
    public partial class Form_2114 : Form
    {
        SourceGridControl GridHandle = new SourceGridControl();
        string DB_TableName_blackbox = "C_blackbox_size";
        public Form_2114()
        {
            InitializeComponent();
        }

        private void Form_2014_Load(object sender, EventArgs e)
        {
            GridHandle.SourceGrideInit(grid1, Config.DB_con1);
            Screen srn = Screen.PrimaryScreen;
            int Xb = this.Width;  //좌,우
            int Yb = this.Height; // 상, 하
            this.Location = new Point((srn.Bounds.Width - Xb) / 2, (srn.Bounds.Height - Yb) / 2);  //좌/우,위/아래

            string[] item1 = new string[] { "횡목", "종목"};
            GridHandle.InputComboItem(item1);

            SourceGrid.Cells.Controllers.CustomEvents val_c1 = new SourceGrid.Cells.Controllers.CustomEvents();
            val_c1.ValueChanged += new EventHandler(ValueChangedEvent1);
            grid1.Controller.AddController(val_c1);
            Grid_View();
        }

        private void Grid_View()
        {
            string cQuery = "select * from " + DB_TableName_blackbox+" order by row_id";
            cell_d cc = new cell_d();
            // 
            grid1.Rows.Clear();
            grid1.BorderStyle = BorderStyle.FixedSingle;
            grid1.SelectionMode = SourceGrid.GridSelectionMode.Cell;
            grid1.ColumnsCount = 13;
            grid1.FixedRows = 2;
            grid1.Rows.Insert(0);
            grid1.Rows[0].Height = 24;
            grid1.Rows.Insert(1);
            grid1.Rows[1].Height = 24;
            //
            grid1[0, 0] = new MyHeader1("row_id");
            grid1.Columns[0].Visible = false;

            grid1[0, 1] = new MyHeader1("No");
            grid1[0, 1].RowSpan = 2;

            grid1[0, 2] = new MyHeader1("인쇄코드");
            grid1[0, 2].RowSpan = 2;

            grid1[0, 3] = new MyHeader1("다찌");
            grid1[0, 3].RowSpan = 2;

            grid1[0, 4] = new MyHeader1("결");
            grid1[0, 4].RowSpan = 2;

            grid1[0, 5] = new MyHeader1("양면[B] 계산");
            grid1[0, 5].ColumnSpan = 2;
            grid1[0, 7] = new MyHeader1("일반[C] 계산");
            grid1[0, 7].ColumnSpan = 4;
            grid1[0, 11] = new MyHeader1("풀[E] 계산");
            grid1[0, 11].ColumnSpan = 2;

            grid1[1, 5] = new MyHeader1("앞수*");
            grid1[1, 6] = new MyHeader1("뒷수*");
            grid1[1, 7] = new MyHeader1("앞수*");
            grid1[1, 8] = new MyHeader1("앞수-");
            grid1[1, 9] = new MyHeader1("뒷수*");
            grid1[1, 10] = new MyHeader1("뒷수-");
            grid1[1, 11] = new MyHeader1("앞수-");
            grid1[1, 12] = new MyHeader1("뒷수-");

            //
            grid1.Columns[1].Width = 30;
            grid1.Columns[2].Width = 80;
            grid1.Columns[3].Width = 40;
            grid1.Columns[4].Width = 60;
            grid1.Columns[5].Width = 50;
            grid1.Columns[6].Width = 50;
            grid1.Columns[7].Width = 50;
            grid1.Columns[8].Width = 50;
            grid1.Columns[9].Width = 50;
            grid1.Columns[10].Width = 50;
            grid1.Columns[11].Width = 50;
            grid1.Columns[12].Width = 50;

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

                grid1[m, 1] = new SourceGrid.Cells.Cell((m-1).ToString(), typeof(string));
                grid1[m, 1].View = cc.center_cell;
                grid1[m, 1].Editor = cc.disable_cell;

                grid1[m, 2] = new SourceGrid.Cells.Cell(myRead["prn_code"], typeof(string));
                grid1[m, 2].View = cc.center_cell;

                grid1[m, 3] = new SourceGrid.Cells.Cell(myRead["dotji"], typeof(string));
                grid1[m, 3].View = cc.center_cell;

                grid1[m, 4] = new SourceGrid.Cells.Cell(myRead["grain"], typeof(string));
                grid1[m, 4].View = cc.center_cell;
                grid1[m, 4].Editor = GridHandle.CbBox[0];

                grid1[m, 5] = new SourceGrid.Cells.Cell(myRead["B_width"], typeof(string));
                grid1[m, 5].View = cc.center_cell;
                
                grid1[m, 6] = new SourceGrid.Cells.Cell(myRead["B_height"], typeof(string));
                grid1[m, 6].View = cc.center_cell;

                grid1[m, 7] = new SourceGrid.Cells.Cell(myRead["C_width_1"], typeof(string));
                grid1[m, 7].View = cc.center_cell;

                grid1[m, 8] = new SourceGrid.Cells.Cell(myRead["C_width_2"], typeof(string));
                grid1[m, 8].View = cc.center_cell;

                grid1[m, 9] = new SourceGrid.Cells.Cell(myRead["C_height_1"], typeof(string));
                grid1[m, 9].View = cc.center_cell;

                grid1[m, 10] = new SourceGrid.Cells.Cell(myRead["C_height_2"], typeof(string));
                grid1[m, 10].View = cc.center_cell;

                grid1[m, 11] = new SourceGrid.Cells.Cell(myRead["E_width"], typeof(string));
                grid1[m, 11].View = cc.center_cell;

                grid1[m, 12] = new SourceGrid.Cells.Cell(myRead["E_height"], typeof(string));
                grid1[m, 12].View = cc.center_cell;
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
            if (cpos.Equals(2))       //
                cQuery = " update " + DB_TableName_blackbox + " set prn_code='" + dat + "' where row_id='" + row_no + "'";
            else if (cpos.Equals(3))  //
                cQuery = " update " + DB_TableName_blackbox + " set dotji='" + dat + "' where row_id='" + row_no + "'";
            else if (cpos.Equals(4))  //
                cQuery = " update " + DB_TableName_blackbox + " set grain='" + dat + "' where row_id='" + row_no + "'";
            else if (cpos.Equals(5))  //
                cQuery = " update " + DB_TableName_blackbox + " set B_width='" + dat + "' where row_id='" + row_no + "'";
            else if (cpos.Equals(6))  //
                cQuery = " update " + DB_TableName_blackbox + " set B_height='" + dat + "' where row_id='" + row_no + "'";
            else if (cpos.Equals(7))  //
                cQuery = " update " + DB_TableName_blackbox + " set C_width_1='" + dat + "' where row_id='" + row_no + "'";
            else if (cpos.Equals(8))  //
                cQuery = " update " + DB_TableName_blackbox + " set C_width_2='" + dat + "' where row_id='" + row_no + "'";
            else if (cpos.Equals(9))  //
                cQuery = " update " + DB_TableName_blackbox + " set C_height_1='" + dat + "' where row_id='" + row_no + "'";
            else if (cpos.Equals(10))  //
                cQuery = " update " + DB_TableName_blackbox + " set C_height_2='" + dat + "' where row_id='" + row_no + "'";
            else if (cpos.Equals(11))  //
                cQuery = " update " + DB_TableName_blackbox + " set E_width='" + dat + "' where row_id='" + row_no + "'";
            else if (cpos.Equals(12))  //
                cQuery = " update " + DB_TableName_blackbox + " set E_height='" + dat + "' where row_id='" + row_no + "'";
            //
            if (!cQuery.Equals(""))
            {
                if (GridHandle.DataUpdate(cQuery) == 1)
                {
                    MessageBox.Show("서버에라 발생으로 수정되지 않았습니다.");
                }
            }
        }

        private void bRefresh_Click(object sender, EventArgs e)
        {
            Grid_View();
        }
    }
}
