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
    public partial class Form_pet : Form
    {
        ksgcontrol kc = new ksgcontrol();
        SourceGridControl GridHandle = new SourceGridControl();
        cell_d cc = new cell_d();

        string DB_TableName_pet = "C_pet";
        public Form_pet()
        {
            InitializeComponent();

        }

        private void Form_pet_Load(object sender, EventArgs e)
        {
            Screen srn = Screen.PrimaryScreen;
            int Xb = this.Width;  //좌,우
            this.Location = new Point((srn.Bounds.Width - Xb) / 2, 1);  //좌/우,위/아래

            kc.ControlInit(Config.DB_con1, "", "", "");
            GridHandle.SourceGrideInit(grid1, Config.DB_con1);

            SourceGrid.Cells.Controllers.CustomEvents val_c1 = new SourceGrid.Cells.Controllers.CustomEvents();
            val_c1.ValueChanged += new EventHandler(ValueChangedEvent1);
            grid1.Controller.AddController(val_c1);

            string cQuery = "select * from " + DB_TableName_pet;

            kc.ComboBoxItemInsert("name", cbWondan, cQuery);
            kc.ComboBoxItemInsert("unit", cbUnit, cQuery);
            
            grid1_view(cQuery);
        }

        private void grid1_view(string cQuery)
        {
            grid1.Rows.Clear();
            grid1.BorderStyle = BorderStyle.FixedSingle;
            grid1.SelectionMode = SourceGrid.GridSelectionMode.Cell;
            grid1.ColumnsCount = 10;
            grid1.FixedRows = 0;
            grid1.Rows.Insert(0);
            grid1.Rows[0].Height = 24;

            grid1[0, 0] = new MyHeader1("row_id");
            grid1.Columns[0].Visible = false;
            grid1[0, 1] = new MyHeader1("√");
            grid1[0, 2] = new MyHeader1("No");
            grid1[0, 3] = new MyHeader1("두께[T]");
            grid1[0, 4] = new MyHeader1("원단명");
            grid1[0, 5] = new MyHeader1("특성");
            grid1[0, 6] = new MyHeader1("제조사");
            grid1[0, 7] = new MyHeader1("단가[㎡]");
            grid1[0, 8] = new MyHeader1("비중");
            grid1[0, 9] = new MyHeader1("설명");

            grid1.Columns[1].Width = 25;
            grid1.Columns[2].Width = 30;
            grid1.Columns[3].Width = 100;
            grid1.Columns[4].Width = 150;
            grid1.Columns[5].Width = 100;
            grid1.Columns[6].Width = 100;
            grid1.Columns[7].Width = 100;
            grid1.Columns[8].Width = 100;
            grid1.Columns[9].Width = 300;

            MySqlConnection DBConn;
            DBConn = new MySqlConnection(Config.DB_con1);
            util.Con_DB_Open(ref DBConn);

            var cmd = new MySqlCommand(cQuery, DBConn);
            var myRead = cmd.ExecuteReader();

            int m = 1;
            while (myRead.Read())
            {
                grid1.Rows.Insert(m);
                grid1.Rows[m].Height = 20;

                grid1[m, 0] = new SourceGrid.Cells.Cell(myRead["row_id"].ToString(), typeof(string));
                grid1[m, 0].View = cc.center_cell;

                grid1[m, 1] = new SourceGrid.Cells.CheckBox(null, false);

                grid1[m, 2] = new SourceGrid.Cells.Cell((m).ToString(), typeof(string));
                grid1[m, 2].View = cc.center_cell;
                grid1[m, 2].Editor = cc.disable_cell;

                grid1[m, 3] = new SourceGrid.Cells.Cell(myRead["thick"].ToString(), typeof(string));
                grid1[m, 3].View = cc.center_cell;

                grid1[m, 4] = new SourceGrid.Cells.Cell(myRead["name"].ToString(), typeof(string));
                grid1[m, 4].View = cc.center_cell;

                grid1[m, 5] = new SourceGrid.Cells.Cell(myRead["unit"].ToString(), typeof(string));
                grid1[m, 5].View = cc.center_cell;

                grid1[m, 6] = new SourceGrid.Cells.Cell(myRead["company"].ToString(), typeof(string));
                grid1[m, 6].View = cc.center_cell;

                grid1[m, 7] = new SourceGrid.Cells.Cell(myRead["danga"].ToString(), typeof(string));
                grid1[m, 7].View = cc.center_cell;

                grid1[m, 8] = new SourceGrid.Cells.Cell(myRead["spec"].ToString(), typeof(string));
                grid1[m, 8].View = cc.center_cell;

                grid1[m, 9] = new SourceGrid.Cells.Cell(myRead["memo"].ToString(), typeof(string));
                m++;
            }
            myRead.Close();
            DBConn.Close();
        }

        private void ValueChangedEvent1(object sender, EventArgs e)  //Grid1에서 볼륨첸지
        {
            int row = grid1.Selection.ActivePosition.Row;
            int col = grid1.Selection.ActivePosition.Column;
            string cQuery = "";
            if (row == -1)
                return;

            string row_id = grid1[row, 0].ToString();
            string dat = grid1[row,col].ToString();
           
            if (col == 3)   //두께
                cQuery = "update " + DB_TableName_pet + " set thick = '" + dat + "' where row_id = " + row_id;
            if (col == 4)   //원단명
                cQuery = "update " + DB_TableName_pet + " set name = '" + dat + "' where row_id = " + row_id;
            if (col == 5)   //특성
                cQuery = "update " + DB_TableName_pet + " set unit = '" + dat + "' where row_id = " + row_id;
            if (col == 6)   //제조사
                cQuery = "update " + DB_TableName_pet + " set company = '" + dat + "' where row_id = " + row_id;
            if (col == 7)       //단가
                cQuery = "update " + DB_TableName_pet + " set danga = '" + dat + "' where row_id = " + row_id;
            if (col == 8)   //비중
                cQuery = "update " + DB_TableName_pet + " set spec = '" + dat + "' where row_id = " + row_id;
            if (col == 9)   //설명
                cQuery = "update " + DB_TableName_pet + " set memo = '" + dat + "' where row_id = " + row_id;


            if (cQuery != "")
                GridHandle.DataUpdate(cQuery);
        }

        private void bSearch_Click(object sender, EventArgs e)
        {
            string search_where = " where row_id != -1 ";

            if (cbThick1.Text.Trim() != "")
                search_where += " and thick >= " + cbThick1.Text;
            if (cbThick2.Text.Trim() != "")
                search_where += " and thick <= " + cbThick2.Text;
            if (cbWondan.Text.Trim() != "")
                search_where += " and name = '" + cbWondan.Text + "'";
            if (cbUnit.Text.Trim() != "")
                search_where += " and unit = '" + cbUnit.Text + "'";
            if (cbCompany.Text.Trim() != "")
                search_where += " and company like '%" + cbCompany.Text + "%'";

            string cQuery = "select * from " + DB_TableName_pet + search_where;
            grid1_view(cQuery);
        }

        private void bAdd_Click(object sender, EventArgs e)
        {
            string cQuery = "insert into " + DB_TableName_pet + "() values()";
            string row_id = kc.DataUpdate(cQuery);

            int m = grid1.RowsCount;

            grid1.Rows.Insert(m);
            grid1.Rows[m].Height = 20;

            grid1[m, 0] = new SourceGrid.Cells.Cell(row_id, typeof(string));
            grid1[m, 0].View = cc.center_cell;

            grid1[m, 1] = new SourceGrid.Cells.CheckBox(null, false);

            grid1[m, 2] = new SourceGrid.Cells.Cell((m).ToString(), typeof(string));
            grid1[m, 2].View = cc.center_cell;
            grid1[m, 2].Editor = cc.disable_cell;

            grid1[m, 3] = new SourceGrid.Cells.Cell("0", typeof(string));
            grid1[m, 3].View = cc.center_cell;

            grid1[m, 4] = new SourceGrid.Cells.Cell("", typeof(string));
            grid1[m, 4].View = cc.center_cell;

            grid1[m, 5] = new SourceGrid.Cells.Cell("", typeof(string));
            grid1[m, 5].View = cc.center_cell;

            grid1[m, 6] = new SourceGrid.Cells.Cell("", typeof(string));
            grid1[m, 6].View = cc.center_cell;

            grid1[m, 7] = new SourceGrid.Cells.Cell("0", typeof(string));
            grid1[m, 7].View = cc.center_cell;

            grid1[m, 8] = new SourceGrid.Cells.Cell("0", typeof(string));
            grid1[m, 8].View = cc.center_cell;

            grid1[m, 9] = new SourceGrid.Cells.Cell("", typeof(string));
            grid1[m, 9].View = cc.center_cell;
        }

        private void bDel_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("삭제하시겠습니까?", "메세지창", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                GridHandle.ChkDataDelete(DB_TableName_pet, 1, 0, 1);
                for (int i = 1; i < grid1.RowsCount; i++)
                {
                    grid1[i, 2].Value = i.ToString();

                }
            }
        }

        private void bCopy_Click(object sender, EventArgs e)
        {
            int pos = 0;
            for (int i = 0; i < grid1.RowsCount; i++)
            {
                if (grid1[i, 1].Value.Equals(true))
                {
                    GridHandle.OneDataCopy(DB_TableName_pet, grid1[i, 0].ToString());
                    pos = i;
                }
            }
            string cQuery = "select * from " + DB_TableName_pet;
            grid1_view(cQuery);

            var position = new SourceGrid.Position(pos, 0);
            grid1.Selection.Focus(position, true);
        }

    }
}

