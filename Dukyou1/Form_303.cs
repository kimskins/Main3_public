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
    public partial class Form_303 : Form
    {
        cell_d cc = new cell_d();
        string cQuery;

        string DB_TableName_wondan = "C_wondan";
        string DB_TableName_hang = "hang_manage";

        SourceGridControl GridHandle = new SourceGridControl();
        ksgcontrol kc = new ksgcontrol();

        DataTable hang_dt = new DataTable();
        SourceGrid.Cells.Editors.ComboBox[] g_box = new SourceGrid.Cells.Editors.ComboBox[1];

        public Form_303()
        {
            InitializeComponent();
        }

        private void Form_503_Load(object sender, EventArgs e)
        {
            Screen srn = Screen.PrimaryScreen;
            int Xb = this.Width;  //좌,우
            this.Location = new Point((srn.Bounds.Width - Xb) / 2, 1);  //좌/우,위/아래

            SourceGrid.Cells.Controllers.CustomEvents val_c1 = new SourceGrid.Cells.Controllers.CustomEvents();
            val_c1.ValueChanged += new EventHandler(ValueChangedEvent1);
            grid1.Controller.AddController(val_c1);

            GridHandle.SourceGrideInit(grid1, Config.DB_con1);
            kc.ControlInit(Config.DB_con1, null, null, null);
            //string[] attach_item = "";
            //GridHandle.InputComboItem(attach_item);
           // string current = (string)comboBox.SelectedItem;
            
            cQuery = "select distinct b.hang as h_hang from " + DB_TableName_wondan + " as a ";
            cQuery += " left outer join " + DB_TableName_hang + " as b on a.high_group = b.code1 and b.class = '스티커대분류'";
            kc.ComboBoxItemInsert("h_hang", cbHighGroup, cQuery);

            cQuery = "select distinct c.hang as m_hang from " + DB_TableName_wondan + " as a ";
            cQuery += " left outer join " + DB_TableName_hang + " as c on a.middle_group = c.code1 and c.class = '스티커중분류'";
            kc.ComboBoxItemInsert("m_hang", cbMiddleGroup, cQuery);

            kc.ComboBoxItemInsert(DB_TableName_wondan, "wname", cbWname);
            kc.ComboBoxItemInsert(DB_TableName_wondan, "jejo_company", cbJejocom);

            grid_cb_make();
            cQuery = "select a.*,b.hang as h_hang, c.hang as m_hang from " + DB_TableName_wondan + " as a ";
            cQuery += " left outer join " + DB_TableName_hang + " as b on a.high_group = b.code1 and b.class = '스티커대분류'"; 
            cQuery += " left outer join " + DB_TableName_hang + " as c on a.middle_group = c.code1 and c.class = '스티커중분류'";

            Grid_View(cQuery);
        }
        private void grid_cb_make()
        {
            sync sy = new sync();
            cQuery = "select * from " + DB_TableName_hang + " where class = '스티커대분류' or class = '스티커중분류' ";
            sy.dt(Config.DB_con1, hang_dt, cQuery);

            DataRow[] hang_dr = hang_dt.Select("class = '스티커대분류'");
            string[] h_group;
            if (hang_dr.Length != 0)
            {
                h_group = new string[hang_dr.Length];

                for (int i = 0; i < hang_dr.Length; i++)
                {
                    h_group[i] = hang_dr[i]["hang"].ToString();
                }

                GridHandle.InputComboItem(h_group);
            }
        }
        private void ValueChangedEvent1(object sender, EventArgs e)
        {
            string Query = "";
            int pos = grid1.Selection.ActivePosition.Column;
            int row = grid1.Selection.ActivePosition.Row;
            string dat = grid1[row, pos].ToString().Trim();
            string row_no = grid1[row, 0].ToString().Trim(); //row_id 

            if (pos == 3)
            {
                DataRow[] hang_dr = hang_dt.Select("class = '스티커대분류' and hang = '" + dat + "'");
                if (hang_dr.Length != 0)
                {
                    Query = "update " + DB_TableName_wondan + " set high_group = '" + hang_dr[0]["code1"].ToString() + "' where row_id = " + row_no;

                    int m = row;
                    string m_group = grid1[row, pos].ToString();
                    bool m_group_chk = false;
                    DataRow[] hang_dr_2 = hang_dt.Select("class = '스티커중분류' and code2 = '" + hang_dr[0]["code1"].ToString() + "'");
                    string[] h_group;
                    if (hang_dr_2.Length != 0)
                    {
                        h_group = new string[hang_dr_2.Length];

                        for (int i = 0; i < hang_dr_2.Length; i++)
                        {
                            h_group[i] = hang_dr_2[i]["hang"].ToString();
                            if (h_group[i] == m_group)
                                m_group_chk = true;
                        }
                        if (m_group_chk == false)
                        {
                            grid1[m, 4] = new SourceGrid.Cells.Cell("", typeof(string));
                            grid1[m, 4].View = cc.center_cell;
                            Query += "; update " + DB_TableName_wondan + " set middle_group = '' where row_id = " + row_no;
                        }
                        g_box[0] = new SourceGrid.Cells.Editors.ComboBox(typeof(string), h_group, false);
                        g_box[0].EditableMode = SourceGrid.EditableMode.Focus | SourceGrid.EditableMode.AnyKey | SourceGrid.EditableMode.SingleClick;
                        grid1[m, 4].Editor = g_box[0];

                        
                    }
                    grid1.Refresh();
                    var position = new SourceGrid.Position(row, 4);
                    grid1.Selection.Focus(position, true);

                }
            }
            if (pos == 4)
            {
                 DataRow[] hang_dr = hang_dt.Select("class = '스티커중분류' and hang = '" + dat + "'");
                 if (hang_dr.Length != 0)
                 {
                     Query = "update " + DB_TableName_wondan + " set middle_group = '" + hang_dr[0]["code1"].ToString() + "' where row_id = " + row_no;
                 }
            }



            if (pos == 5)
                Query = "update " + DB_TableName_wondan + " set weight = '" + dat + "' where row_id = " + row_no;
            if (pos == 6)
                Query = "update " + DB_TableName_wondan + " set unit = '" + dat + "' where row_id = " + row_no;
            if (pos == 7)
                Query = "update " + DB_TableName_wondan + " set wname = '" + dat + "' where row_id = " + row_no;
            if (pos == 8)
                Query = "update " + DB_TableName_wondan + " set bigo = '" + dat + "' where row_id = " + row_no;
            if (pos == 9)
                Query = "update " + DB_TableName_wondan + " set bk_paper = '" + dat + "' where row_id = " + row_no;
            if (pos == 10)
                Query = "update " + DB_TableName_wondan + " set width = '" + dat + "' where row_id = " + row_no;
            if (pos == 11)
                Query = "update " + DB_TableName_wondan + " set price = '" + dat + "' where row_id = " + row_no;
            if (pos == 12)
                Query = "update " + DB_TableName_wondan + " set thick = '" + dat + "' where row_id = " + row_no;

            if (pos == 13)  //roll길이
            {
                Query = "update " + DB_TableName_wondan + " set roll_lenght = '" + dat.Replace(",", "") + "' where row_id = " + row_no;
                grid1[row, 13] = new SourceGrid.Cells.Cell(GridHandle.numgetcoma(dat.Replace(",", "")), typeof(string));
                grid1[row, 13].View = cc.int_cell;
            }
            if (pos == 14)//주문단위
            {
                Query = "update " + DB_TableName_wondan + " set unit_mm = '" + dat.Replace(",", "") + "' where row_id = " + row_no;
                grid1[row, 14] = new SourceGrid.Cells.Cell(GridHandle.numgetcoma(dat.Replace(",", "")), typeof(string));
                grid1[row, 14].View = cc.int_cell;
            }


            if (pos == 15)
                Query = "update " + DB_TableName_wondan + " set jejo_company = '" + dat + "' where row_id = " + row_no;
            if (pos == 16)
                Query = "update " + DB_TableName_wondan + " set opset = " + dat.ToLower() + " where row_id = " + row_no;
            if (pos == 17)
                Query = "update " + DB_TableName_wondan + " set uv = " + dat.ToLower() + " where row_id = " + row_no;
            if (pos == 18)
                Query = "update " + DB_TableName_wondan + " set roteri = " + dat.ToLower() + " where row_id = " + row_no;
            if (pos == 19)
                Query = "update " + DB_TableName_wondan + " set siring = " + dat.ToLower() + " where row_id = " + row_no;
            if (pos == 20)
                Query = "update " + DB_TableName_wondan + " set silk = " + dat.ToLower() + " where row_id = " + row_no;
            if (pos == 21)
                Query = "update " + DB_TableName_wondan + " set roll = " + dat.ToLower() + " where row_id = " + row_no;
            if (pos == 22)
                Query = "update " + DB_TableName_wondan + " set jang = " + dat.ToLower() + " where row_id = " + row_no;

            if (Query != "")
                GridHandle.DataUpdate(Query);

        }
        void Grid_View(string Query)
        {
            grid1.Rows.Clear();
            grid1.BorderStyle = BorderStyle.FixedSingle;
            grid1.SelectionMode = SourceGrid.GridSelectionMode.Cell;
            grid1.ColumnsCount = 24;
            grid1.FixedRows = 2;
            grid1.FixedColumns = 0;
            grid1.Rows.Insert(0);
            grid1.Rows[0].Height = 24;
            grid1.Rows.Insert(1);
            grid1.Rows[1].Height = 24;

            grid1[0, 0] = new MyHeader1("row_id");
            grid1[0, 0].RowSpan = 2;
            grid1.Columns[0].Visible = false;
            grid1[0, 1] = new MyHeader1("√");
            grid1[0, 1].RowSpan = 2;
            grid1[0, 2] = new MyHeader1("No");
            grid1[0, 2].RowSpan = 2;

            grid1[0, 3] = new MyHeader1("대분류");
            grid1[0, 3].RowSpan = 2;

            grid1[0, 4] = new MyHeader1("중분류");
            grid1[0, 4].RowSpan = 2;

            grid1[0, 5] = new MyHeader1("무게/두께");
            grid1[0, 5].RowSpan = 2;

            grid1[0, 6] = new MyHeader1("단위");
            grid1[0, 6].RowSpan = 2;

            grid1[0, 7] = new MyHeader1("원단명");
            grid1[0, 7].RowSpan = 2;

            grid1[0, 8] = new MyHeader1("특성/접착력");
            grid1[0, 8].RowSpan = 2;

            grid1[0, 9] = new MyHeader1("후지");
            grid1[0, 9].RowSpan = 2;

            grid1[0, 10] = new MyHeader1("원단폭\n[mm]");
            grid1[0, 10].RowSpan = 2;

            grid1[0, 11] = new MyHeader1("단가\n[m]");
            grid1[0, 11].RowSpan = 2;

            grid1[0, 12] = new MyHeader1("두께\n[mm]");
            grid1[0, 12].RowSpan = 2;

            grid1[0, 13] = new MyHeader1("Roll 길이\n[mm]");
            grid1[0, 13].RowSpan = 2;
            grid1[0, 14] = new MyHeader1("주문 단위\n[mm]");
            grid1[0, 14].RowSpan = 2;

            grid1[0, 15] = new MyHeader1("제조사");
            grid1[0, 15].RowSpan = 2;

            grid1[0, 16] = new MyHeader1("인쇄방법");
            grid1[0, 16].ColumnSpan = 5;

            grid1[0, 21] = new MyHeader1("주문형태");
            grid1[0, 21].ColumnSpan = 2;

            grid1[1, 16] = new MyHeader1("옵셋");
            grid1[1, 17] = new MyHeader1("UV");
            grid1[1, 18] = new MyHeader1("로터리");
            grid1[1, 19] = new MyHeader1("씨링");
            grid1[1, 20] = new MyHeader1("실크");

            grid1[1, 21] = new MyHeader1("롤[Roll]");
            grid1[1, 22] = new MyHeader1("장[Sheet]");

            grid1[0, 23] = new MyHeader1("설명");
            grid1[0, 23].RowSpan = 2;

            grid1.Columns[1].Width = 20;
            grid1.Columns[2].Width = 30;
            grid1.Columns[3].Width = 80;
            grid1.Columns[4].Width = 80;
            grid1.Columns[5].Width = 100;
            grid1.Columns[6].Width = 40;
            grid1.Columns[7].Width = 200;
            grid1.Columns[8].Width = 110;
            grid1.Columns[9].Width = 170;
            grid1.Columns[10].Width = 70;
            grid1.Columns[11].Width = 100;
            grid1.Columns[12].Width = 100;

            grid1.Columns[13].Width = 80;
            grid1.Columns[14].Width = 100;

            grid1.Columns[15].Width = 100;
            grid1.Columns[16].Width = 70;
            grid1.Columns[17].Width = 70;
            grid1.Columns[18].Width = 70;
            grid1.Columns[19].Width = 70;
            grid1.Columns[20].Width = 70;
            grid1.Columns[21].Width = 70;
            grid1.Columns[22].Width = 70;
            grid1.Columns[23].Width = 300;


            MySqlConnection DBConn;
            DBConn = new MySqlConnection(Config.DB_con1);
            DBConn.Open();

            var cmd = new MySqlCommand(Query, DBConn);
            var myRead = cmd.ExecuteReader();

            int m = 2;
            while (myRead.Read())
            {
                grid1.Rows.Insert(m);
                grid1.Rows[m].Height = 20;

                grid1[m, 0] = new SourceGrid.Cells.Cell(myRead["row_id"].ToString(), typeof(string));
                
                grid1[m, 1] = new SourceGrid.Cells.CheckBox(null, false);
                grid1[m, 2] = new SourceGrid.Cells.Cell((m-1).ToString(), typeof(string));
                grid1[m, 2].View = cc.center_cell;
                grid1[m, 2].Editor = cc.disable_cell;

                grid1[m, 3] = new SourceGrid.Cells.Cell(myRead["h_hang"].ToString(), typeof(string));
                grid1[m, 3].View = cc.center_cell;
                grid1[m, 3].Editor = GridHandle.CbBox[0];

                grid1[m, 4] = new SourceGrid.Cells.Cell(myRead["m_hang"].ToString(), typeof(string));
                grid1[m, 4].View = cc.center_cell;

                DataRow[] hang_dr = hang_dt.Select("class = '스티커중분류' and code2 = '" + myRead["high_group"].ToString() + "'");
                string[] h_group;
                if (hang_dr.Length != 0)
                {
                    h_group = new string[hang_dr.Length];

                    for (int i = 0; i < hang_dr.Length; i++)
                    {
                        h_group[i] = hang_dr[i]["hang"].ToString();
                    }
                    g_box[0] = new SourceGrid.Cells.Editors.ComboBox(typeof(string), h_group, false);
                    g_box[0].EditableMode = SourceGrid.EditableMode.Focus | SourceGrid.EditableMode.AnyKey | SourceGrid.EditableMode.SingleClick;
                    grid1[m, 4].Editor = g_box[0];
                }
                if (myRead["weight"].ToString().Contains(".000"))
                    grid1[m, 5] = new SourceGrid.Cells.Cell(Convert.ToInt32(myRead["weight"]).ToString(), typeof(string));
                else
                    grid1[m, 5] = new SourceGrid.Cells.Cell(myRead["weight"].ToString(), typeof(string));

                
                grid1[m, 5].View = cc.center_cell;

                grid1[m, 6] = new SourceGrid.Cells.Cell(myRead["unit"].ToString(), typeof(string));
                grid1[m, 6].View = cc.center_cell;

                grid1[m, 7] = new SourceGrid.Cells.Cell(myRead["wname"].ToString(), typeof(string));
                grid1[m, 7].View = cc.left_cell;

                grid1[m, 8] = new SourceGrid.Cells.Cell(myRead["bigo"].ToString(), typeof(string));
                grid1[m, 8].View = cc.center_cell;

                grid1[m, 9] = new SourceGrid.Cells.Cell(myRead["bk_paper"].ToString(), typeof(string));
                grid1[m, 9].View = cc.center_cell;

                grid1[m, 10] = new SourceGrid.Cells.Cell(myRead["width"].ToString(), typeof(string));
                grid1[m, 10].View = cc.center_cell;

                grid1[m, 11] = new SourceGrid.Cells.Cell(myRead["price"].ToString(), typeof(string));
                grid1[m, 11].View = cc.center_cell;

                grid1[m, 12] = new SourceGrid.Cells.Cell(myRead["thick"].ToString(), typeof(string));
                grid1[m, 12].View = cc.center_cell;

                grid1[m, 13] = new SourceGrid.Cells.Cell(GridHandle.numgetcoma(myRead["roll_lenght"].ToString()), typeof(string));
                grid1[m, 13].View = cc.int_cell;

                grid1[m, 14] = new SourceGrid.Cells.Cell(GridHandle.numgetcoma(myRead["unit_mm"].ToString()), typeof(string));
                grid1[m, 14].View = cc.int_cell;

                grid1[m, 15] = new SourceGrid.Cells.Cell(myRead["jejo_company"].ToString(), typeof(string));
                grid1[m, 15].View = cc.center_cell;


                if (myRead["opset"].ToString() == "True")
                    grid1[m, 16] = new SourceGrid.Cells.CheckBox(null, true);
                else
                    grid1[m, 16] = new SourceGrid.Cells.CheckBox(null, false);

                if (myRead["uv"].ToString() == "True")
                    grid1[m, 17] = new SourceGrid.Cells.CheckBox(null, true);
                else
                    grid1[m, 17] = new SourceGrid.Cells.CheckBox(null, false);

                if (myRead["roteri"].ToString() == "True")
                    grid1[m, 18] = new SourceGrid.Cells.CheckBox(null, true);
                else
                    grid1[m, 18] = new SourceGrid.Cells.CheckBox(null, false);

                if (myRead["siring"].ToString() == "True")
                    grid1[m, 19] = new SourceGrid.Cells.CheckBox(null, true);
                else
                    grid1[m, 19] = new SourceGrid.Cells.CheckBox(null, false);

                if (myRead["silk"].ToString() == "True")
                    grid1[m, 20] = new SourceGrid.Cells.CheckBox(null, true);
                else
                    grid1[m, 20] = new SourceGrid.Cells.CheckBox(null, false);

                if (myRead["roll"].ToString() == "True")
                    grid1[m, 21] = new SourceGrid.Cells.CheckBox(null, true);
                else
                    grid1[m, 21] = new SourceGrid.Cells.CheckBox(null, false);

                if (myRead["jang"].ToString() == "True")
                    grid1[m, 22] = new SourceGrid.Cells.CheckBox(null, true);
                else
                    grid1[m, 22] = new SourceGrid.Cells.CheckBox(null, false);

                grid1[m, 23] = new SourceGrid.Cells.Cell(myRead["memo"].ToString(), typeof(string));
                m++;
            }
            myRead.Close();
            DBConn.Close();
        }


        private void bSearch_Click(object sender, EventArgs e)  // 검색버튼 클릭
        {
            string search_temp = " where a.row_id is not null ";

            if (cbHighGroup.Text.Trim() != "")
                search_temp += " and b.hang = '" + cbHighGroup.Text.Trim() + "' ";
            if (cbMiddleGroup.Text.Trim() != "")
                search_temp += " and c.hang = '" + cbMiddleGroup.Text.Trim() + "' ";
            if (tbWeight.Text.Trim() != "")
                search_temp += " and weight = '" + tbWeight.Text.Trim() + "' ";


            if (cbWname.Text.Trim() != "")
                search_temp += " and wname = '" + cbWname.Text.Trim() + "' ";
            if (tbBigo.Text.Trim() != "")
                search_temp += " and bigo = '" + tbBigo.Text.Trim() + "' ";
            if (tbBk_Paper.Text.Trim() != "")
                search_temp += " and bk_paper = '" + tbBk_Paper.Text.Trim() + "' ";
            if (cbJejocom.Text.Trim() != "")
                search_temp += " and jejo_company = '" + cbJejocom.Text.Trim() + "' ";

            cQuery = "select a.*,b.hang as h_hang, c.hang as m_hang from " + DB_TableName_wondan + " as a ";
            cQuery += " left outer join " + DB_TableName_hang + " as b on a.high_group = b.code1 and b.class = '스티커대분류'";
            cQuery += " left outer join " + DB_TableName_hang + " as c on a.middle_group = c.code1 and c.class = '스티커중분류'";
            cQuery += search_temp;

            Grid_View(cQuery);

        }

      
        private void bClear_Click(object sender, EventArgs e)
        {
            tbWeight.Clear();
            tbBigo.Clear();
            tbBk_Paper.Clear();

            cbWname.Text = "";
            cbWname.Update();
            cbJejocom.Text = "";
            cbJejocom.Update();
            cbHighGroup.Text = "";
            cbHighGroup.Update();
            cbMiddleGroup.Text = "";
            cbMiddleGroup.Update();
        }

        private void bAdd_Click(object sender, EventArgs e)
        {
            cQuery = "insert into " + DB_TableName_wondan + " values()";
            string row_no = kc.DataUpdate(cQuery);

            int m = grid1.RowsCount;
            grid1.Rows.Insert(m);
            grid1.Rows[m].Height = 20;

            grid1[m, 0] = new SourceGrid.Cells.Cell(row_no, typeof(string));

            grid1[m, 1] = new SourceGrid.Cells.CheckBox(null, false);
            grid1[m, 2] = new SourceGrid.Cells.Cell((m).ToString(), typeof(string));
            grid1[m, 2].View = cc.center_cell;
            grid1[m, 2].Editor = cc.disable_cell;

            grid1[m, 3] = new SourceGrid.Cells.Cell("", typeof(string));
            grid1[m, 3].View = cc.center_cell;
            grid1[m, 3].Editor = GridHandle.CbBox[0];

            grid1[m, 4] = new SourceGrid.Cells.Cell("", typeof(string));
            grid1[m, 4].View = cc.center_cell;

            grid1[m, 5] = new SourceGrid.Cells.Cell("", typeof(string));
            grid1[m, 5].View = cc.center_cell;

            grid1[m, 6] = new SourceGrid.Cells.Cell("", typeof(string));
            grid1[m, 6].View = cc.center_cell;

            grid1[m, 7] = new SourceGrid.Cells.Cell("", typeof(string));
            grid1[m, 7].View = cc.left_cell;

            grid1[m, 8] = new SourceGrid.Cells.Cell("", typeof(string));
            grid1[m, 8].View = cc.center_cell;

            grid1[m, 9] = new SourceGrid.Cells.Cell("", typeof(string));
            grid1[m, 9].View = cc.center_cell;

            grid1[m, 10] = new SourceGrid.Cells.Cell("", typeof(string));
            grid1[m, 10].View = cc.center_cell;

            grid1[m, 11] = new SourceGrid.Cells.Cell("", typeof(string));
            grid1[m, 11].View = cc.center_cell;

            grid1[m, 12] = new SourceGrid.Cells.Cell("", typeof(string));
            grid1[m, 12].View = cc.center_cell;

            grid1[m, 13] = new SourceGrid.Cells.Cell("", typeof(string));
            grid1[m, 13].View = cc.center_cell;

            grid1[m, 14] = new SourceGrid.Cells.CheckBox(null, false);

            grid1[m, 15] = new SourceGrid.Cells.CheckBox(null, false);

            grid1[m, 16] = new SourceGrid.Cells.CheckBox(null, false);

            grid1[m, 17] = new SourceGrid.Cells.CheckBox(null, false);

            grid1[m, 18] = new SourceGrid.Cells.CheckBox(null, false);

            grid1[m, 19] = new SourceGrid.Cells.CheckBox(null, false);

            grid1[m, 20] = new SourceGrid.Cells.CheckBox(null, false);
            grid1[m, 21] = new SourceGrid.Cells.CheckBox(null, false);
            grid1[m, 22] = new SourceGrid.Cells.CheckBox(null, false);
            grid1[m, 23] = new SourceGrid.Cells.Cell("", typeof(string));

            grid1.Refresh();

            var position = new SourceGrid.Position(grid1.RowsCount - 1, 2);
            grid1.Selection.Focus(position, true);

        }

        private void bDelete_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("삭제하시겠습니까?", "메세지창", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                GridHandle.ChkDataDelete(DB_TableName_wondan, 2, 0, 1);
            }
        }

        private void bCopy_Click(object sender, EventArgs e)
        {
            bool copy_chk = false;
            for (int i = 0; i < grid1.RowsCount; i++)
            {
                if (grid1[i, 1].Value.Equals(true))
                {
                    GridHandle.OneDataCopy(DB_TableName_wondan, grid1[i, 0].ToString());
                    copy_chk = true;
                }
            }

            if(copy_chk == false)
            {
                MessageBox.Show("복사할 자료를 선택해 주세요.");
                return;
            }
            else
            {
                cQuery = "select a.*,b.hang as h_hang, c.hang as m_hang from " + DB_TableName_wondan + " as a ";
                cQuery += " left outer join " + DB_TableName_hang + " as b on a.high_group = b.code1 and b.class = '스티커대분류'";
                cQuery += " left outer join " + DB_TableName_hang + " as c on a.middle_group = c.code1 and c.class = '스티커중분류'";

                Grid_View(cQuery);
                var position = new SourceGrid.Position(grid1.RowsCount - 1, 2);
                grid1.Selection.Focus(position, true);
            }
        }

    }
}
