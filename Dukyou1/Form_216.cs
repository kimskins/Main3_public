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
    public partial class Form_216 : Form
    {
        ksgcontrol kc = new ksgcontrol();
        SourceGridControl GridHandle = new SourceGridControl();
        cell_d cc = new cell_d();
        string DB_TableName_dosu = "C_dosu_dat";
        public Form_216()
        {
            InitializeComponent();
            kc.ControlInit(Config.DB_con1, null, null, null);
            GridHandle.SourceGrideInit(grid1, Config.DB_con1);
        }
        private void Form_216_Load(object sender, EventArgs e)
        {
            Screen srn = Screen.PrimaryScreen;
            int Xb = this.Width;  //좌,우
            this.Location = new Point((srn.Bounds.Width - Xb) / 2, 1);  //좌/우,위/아래

            SourceGrid.Cells.Controllers.CustomEvents val_c1 = new SourceGrid.Cells.Controllers.CustomEvents();
            val_c1.ValueChanged += new EventHandler(ValueChangedEvent1);
            grid1.Controller.AddController(val_c1);

            string cQuery = "select * from " + DB_TableName_dosu;
            grid1_view(cQuery);
            make_cb();
            
        }

        private void make_cb()
        {
            cbGroup.Items.Clear();
            cbTdosu.Items.Clear();
            cbSdosu.Items.Clear();
            cbMdosu.Items.Clear();

            string cQuery = "select distinct g_no from " + DB_TableName_dosu;
            kc.ComboBoxItemInsert("g_no", cbGroup, cQuery);

            cQuery = "select distinct t_dosu from " + DB_TableName_dosu;
            kc.ComboBoxItemInsert("t_dosu", cbTdosu, cQuery);

            cQuery = "select distinct s_dosu from " + DB_TableName_dosu;
            kc.ComboBoxItemInsert("s_dosu", cbSdosu, cQuery);

            cQuery = "select distinct mast_dosu from " + DB_TableName_dosu;
            kc.ComboBoxItemInsert("mast_dosu", cbMdosu, cQuery);
        }
        private void grid1_view(string cQuery)
        {   
            grid1.Rows.Clear();
            grid1.BorderStyle = BorderStyle.FixedSingle;
            grid1.SelectionMode = SourceGrid.GridSelectionMode.Cell;
            grid1.ColumnsCount = 9;
            grid1.FixedRows = 1;
            grid1.Rows.Insert(0);
            grid1.Rows[0].Height = 24;

            grid1[0, 0] = new MyHeader1("row_id");
            grid1.Columns[0].Visible = false;
            grid1[0, 1] = new MyHeader1("√");
            grid1[0, 2] = new MyHeader1("No");
            grid1[0, 3] = new MyHeader1("인쇄방법");
            grid1[0, 4] = new MyHeader1("그룹");
            grid1[0, 5] = new MyHeader1("총도수");
            grid1[0, 6] = new MyHeader1("별색도수");
            grid1[0, 7] = new MyHeader1("지정통수");
            grid1[0, 8] = new MyHeader1("검색용(지정+확장)");
            
            grid1.Columns[1].Width = 25;
            grid1.Columns[2].Width = 35;
            grid1.Columns[3].Width = 80;
            grid1.Columns[4].Width = 80;
            grid1.Columns[5].Width = 80;
            grid1.Columns[6].Width = 80;
            grid1.Columns[7].Width = 80;
            grid1.Columns[8].Width = 200;

            MySqlConnection DBConn;
            DBConn = new MySqlConnection(Config.DB_con1);
            DBConn.Open();

            var cmd = new MySqlCommand(cQuery, DBConn);
            var myRead = cmd.ExecuteReader();

            int m = 1;

            while (myRead.Read())
            {
                grid1.Rows.Insert(m);
                grid1.Rows[m].Height = 22;
                //
                grid1[m, 0] = new SourceGrid.Cells.Cell(myRead["row_id"].ToString(), typeof(string));
                grid1[m, 1] = new SourceGrid.Cells.CheckBox(null, false);

                grid1[m, 2] = new SourceGrid.Cells.Cell((m).ToString(), typeof(string));  //no
                grid1[m, 2].View = cc.center_cell;
                grid1[m, 2].Editor = cc.disable_cell;

                grid1[m, 3] = new SourceGrid.Cells.Cell(myRead["prn"].ToString(), typeof(string));  
                grid1[m, 3].View = cc.center_cell;

                grid1[m, 4] = new SourceGrid.Cells.Cell(myRead["g_no"].ToString(), typeof(string)); 
                grid1[m, 4].View = cc.center_cell;

                grid1[m, 5] = new SourceGrid.Cells.Cell(myRead["t_dosu"].ToString(), typeof(string)); 
                grid1[m, 5].View = cc.center_cell;

                grid1[m, 6] = new SourceGrid.Cells.Cell(myRead["s_dosu"].ToString(), typeof(string)); 
                grid1[m, 6].View = cc.center_cell;

                grid1[m, 7] = new SourceGrid.Cells.Cell(myRead["mast_dosu"].ToString(), typeof(string));
                grid1[m, 7].View = cc.left_cell;

                grid1[m, 8] = new SourceGrid.Cells.Cell(myRead["add_dosu"].ToString(), typeof(string)); 
                grid1[m, 8].View = cc.left_cell;

                m++;
            }
            myRead.Close();
            DBConn.Close();
        }

        private void ValueChangedEvent1(object sender, EventArgs e)
        {
            string Query = "";
            int col = grid1.Selection.ActivePosition.Column;
            int row = grid1.Selection.ActivePosition.Row;
            string dat = grid1[row, col].ToString().Trim();
            string row_no = grid1[row, 0].ToString().Trim(); //row_id 

            if (col == 3)
                Query = "update " + DB_TableName_dosu + " set prn = '" + dat + "' where row_id = " + row_no;
            if (col == 4)
                Query = "update " + DB_TableName_dosu + " set g_no = '" + dat + "' where row_id = " + row_no;
            if (col == 5)
                Query = "update " + DB_TableName_dosu + " set t_dosu = '" + dat + "' where row_id = " + row_no;
            if (col == 6)
                Query = "update " + DB_TableName_dosu + " set s_dosu = '" + dat + "' where row_id = " + row_no;
            if (col == 7)
                Query = "update " + DB_TableName_dosu + " set mast_dosu = '" + dat + "' where row_id = " + row_no;
            if (col == 8)
                Query = "update " + DB_TableName_dosu + " set add_dosu = '" + dat + "' where row_id = " + row_no;

            if (Query != "")
                kc.DataUpdate(Query);
        }

        private void bClear_Click(object sender, EventArgs e)
        {
            tbPrn.Clear();
            tbSdosu.Clear();
            cbGroup.Text = "";
            cbMdosu.Text = "";
            cbSdosu.Text = "";
            cbTdosu.Text = "";
        }

        private void bSearch_Click(object sender, EventArgs e)
        {
            string cQuery = "select * from " + DB_TableName_dosu+" where row_id <> -1 ";

            if (tbPrn.Text.Trim() != "")
                cQuery += " and prn like '%" + tbPrn.Text + "%'";
            if (tbSdosu.Text.Trim() != "")
                cQuery += " and add_dosu like '%" + tbSdosu.Text + "%'";
            if(cbGroup.Text.Trim() != "")
                cQuery += " and g_no = '" + cbGroup.Text + "' ";
            if (cbMdosu.Text.Trim() != "")
                cQuery += " and mast_dosu = '" + cbMdosu.Text + "' ";
            if (cbSdosu.Text.Trim() != "")
                cQuery += " and s_dosu = '" + cbSdosu.Text + "' ";
            if (cbTdosu.Text.Trim() != "")
                cQuery += " and t_dosu = '" + cbTdosu.Text + "' ";

            grid1_view(cQuery);
        }

        private void bAdd_Click(object sender, EventArgs e)
        {
            string Query = "insert into " + DB_TableName_dosu + " values()";
            string row_id = kc.DataUpdate(Query);

            int m = grid1.RowsCount;
            grid1.Rows.Insert(m);
            grid1.Rows[m].Height = 22;
            //
            grid1[m, 0] = new SourceGrid.Cells.Cell(row_id, typeof(string));
            grid1[m, 1] = new SourceGrid.Cells.CheckBox(null, false);

            grid1[m, 2] = new SourceGrid.Cells.Cell((m).ToString(), typeof(string));  //no
            grid1[m, 2].View = cc.center_cell;
            grid1[m, 2].Editor = cc.disable_cell;

            grid1[m, 3] = new SourceGrid.Cells.Cell("", typeof(string));
            grid1[m, 3].View = cc.center_cell;

            grid1[m, 4] = new SourceGrid.Cells.Cell("", typeof(string));
            grid1[m, 4].View = cc.center_cell;

            grid1[m, 5] = new SourceGrid.Cells.Cell("", typeof(string));
            grid1[m, 5].View = cc.center_cell;

            grid1[m, 6] = new SourceGrid.Cells.Cell("", typeof(string));
            grid1[m, 6].View = cc.center_cell;

            grid1[m, 7] = new SourceGrid.Cells.Cell("", typeof(string));
            grid1[m, 7].View = cc.left_cell;

            grid1[m, 8] = new SourceGrid.Cells.Cell("", typeof(string));
            grid1[m, 8].View = cc.left_cell;

            var position = new SourceGrid.Position(grid1.RowsCount - 1, 1);
            grid1.Selection.Focus(position, true);
        }

        private void bDel_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("삭제하시겠습니까?", "메세지창", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                GridHandle.ChkDataDelete(DB_TableName_dosu, 1, 0, 1);
                make_cb();
            }
        }
    } 
}
