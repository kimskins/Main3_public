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
    public partial class Form_douzone_code : Form
    {
        SourceGrid.Cells.Controllers.CustomEvents ClickEvent1 = new SourceGrid.Cells.Controllers.CustomEvents();
        SourceGrid.Cells.Controllers.CustomEvents ClickEvent2 = new SourceGrid.Cells.Controllers.CustomEvents();
        SourceGrid.Cells.Controllers.CustomEvents DoubleClick1 = new SourceGrid.Cells.Controllers.CustomEvents();
        SourceGrid.Cells.Controllers.CustomEvents DoubleClick2 = new SourceGrid.Cells.Controllers.CustomEvents();
        SourceGrid.Cells.Controllers.CustomEvents ValueChangedEvent1 = new SourceGrid.Cells.Controllers.CustomEvents();
        SourceGrid.Cells.Controllers.CustomEvents ValueChangedEvent2 = new SourceGrid.Cells.Controllers.CustomEvents();
        SourceGrid.Cells.Controllers.CustomEvents ValueChangedEvent3 = new SourceGrid.Cells.Controllers.CustomEvents();
        string a_code = "";
        string b_code = "";
        string c_code = "";
        // 
        public Form_douzone_code()
        {
            InitializeComponent();
        }

        private void Form_douzone_code_Load(object sender, EventArgs e)
        {
            Screen srn = Screen.PrimaryScreen;
            int Xb = this.Width;  //좌,우
            this.Location = new Point((srn.Bounds.Width - Xb) / 2, 1);  //좌/우,위/아래
            //
            
            make_grid1();
        }

        private void make_grid1()
        {
            grid1.Rows.Clear();

            cell_d cc = new cell_d();
            //
            cEventHelper.RemoveAllEventHandlers(ClickEvent1);
            cEventHelper.RemoveAllEventHandlers(DoubleClick1);
            cEventHelper.RemoveAllEventHandlers(ValueChangedEvent1);
            //
            grid1.BorderStyle = BorderStyle.FixedSingle;
            grid1.SelectionMode = SourceGrid.GridSelectionMode.Cell;
            grid1.ColumnsCount = 5;
            grid1.FixedRows = 1;
            grid1.Rows.Insert(0);
            grid1.Rows[0].Height = 26;
            grid1.HScrollBar.Visible = false;
            grid1.Selection.FocusStyle = grid1.Selection.FocusStyle | SourceGrid.FocusStyle.RemoveSelectionOnLeave;
            //
            grid1[0, 0] = new MyHeader1("row_id");
            grid1.Columns[0].Visible = false;
            grid1[0, 1] = new MyHeader1("√");
            grid1[0, 2] = new MyHeader1("No");
            grid1[0, 3] = new MyHeader1("a_code");
            grid1[0, 4] = new MyHeader1("a_계정과목");
            //
            grid1.Columns[0].Width = 100;   //row_id
            grid1.Columns[1].Width = 30;    // √
            grid1.Columns[2].Width = 30;    // No
            grid1.Columns[3].Width = 50;    //
            grid1.Columns[4].Width = 140;   //
            //
            int m = 1;

            string cQuery = "SELECT * from f_agroup order by a_code";
            var DBConn = new MySqlConnection(Config.DB_con1);
            DBConn.Open();
            DataTable k_table = new DataTable();
            var returnVal1 = new MySqlDataAdapter(cQuery, DBConn);
            returnVal1.Fill(k_table);
            returnVal1.Dispose();
            for (int n = 0; n < k_table.Rows.Count; n++)
            {
                grid1.Rows.Insert(m);
                grid1.Rows[m].Height = 22;
                //
                grid1[m, 0] = new SourceGrid.Cells.Cell(k_table.Rows[n]["row_id"].ToString(), typeof(string));     //row_id

                grid1[m, 1] = new SourceGrid.Cells.CheckBox(null, false);              // √
                grid1[m, 1].AddController(ClickEvent1);

                grid1[m, 2] = new SourceGrid.Cells.Cell(m.ToString(), typeof(string)); // No;
                grid1[m, 2].View = cc.center_cell;
                grid1[m, 2].Editor = cc.disable_cell;

                grid1[m, 3] = new SourceGrid.Cells.Cell(k_table.Rows[n]["a_code"].ToString(), typeof(string)); // a_code;
                grid1[m, 3].View = cc.center_cell;
                grid1[m, 3].Editor = cc.disable_cell;

                grid1[m, 4] = new SourceGrid.Cells.Cell(k_table.Rows[n]["a_item"].ToString(), typeof(string)); //aitem
                grid1[m, 4].View = cc.left_cellr;
                grid1[m, 4].AddController(ValueChangedEvent1);
                grid1[m, 4].AddController(DoubleClick1);

                m++;
            }
            a_code = "";
            b_code = "";
            c_code = "";
            make_grid2(false);
            make_grid3(false, null);
            ClickEvent1.Click += new EventHandler(Clicked1);
            DoubleClick1.DoubleClick += new EventHandler(DoubleClicked1);
            ValueChangedEvent1.ValueChanged += new EventHandler(ValueChanged1);
        }

        private void make_grid2(bool v_id)
        {
            grid2.Rows.Clear();

            cell_d cc = new cell_d();
            //
            cEventHelper.RemoveAllEventHandlers(ClickEvent2);
            cEventHelper.RemoveAllEventHandlers(DoubleClick2);
            cEventHelper.RemoveAllEventHandlers(ValueChangedEvent2);
            //
            grid2.BorderStyle = BorderStyle.FixedSingle;
            grid2.SelectionMode = SourceGrid.GridSelectionMode.Cell;
            grid2.ColumnsCount = 6;
            grid2.FixedRows = 1;
            grid2.Rows.Insert(0);
            grid2.Rows[0].Height = 26;
            grid2.HScrollBar.Visible = false;
            grid2.Selection.FocusStyle = grid2.Selection.FocusStyle | SourceGrid.FocusStyle.RemoveSelectionOnLeave;
            //
            grid2[0, 0] = new MyHeader1("row_id");
            grid2.Columns[0].Visible = false;
            grid2[0, 1] = new MyHeader1("√");
            grid2[0, 2] = new MyHeader1("No");
            grid2[0, 3] = new MyHeader1("a_code");
            grid2[0, 4] = new MyHeader1("b_code");
            grid2[0, 5] = new MyHeader1("b_계정과목");
            //
            grid2.Columns[0].Width = 100;   //row_id
            grid2.Columns[1].Width = 30;    // √
            grid2.Columns[2].Width = 30;    // √
            grid2.Columns[3].Width = 50;    //
            grid2.Columns[4].Width = 50;    //
            grid2.Columns[5].Width = 150;   //
            //
            if (v_id)
            {
                int m = 1;
                string cQuery = "SELECT * from f_bgroup where a_code='" + a_code + "' order by a_code,b_code";
                var DBConn = new MySqlConnection(Config.DB_con1);
                DBConn.Open();
                DataTable k_table = new DataTable();
                var returnVal1 = new MySqlDataAdapter(cQuery, DBConn);
                returnVal1.Fill(k_table);
                returnVal1.Dispose();
                for (int n = 0; n < k_table.Rows.Count; n++)
                {
                    grid2.Rows.Insert(m);
                    grid2.Rows[m].Height = 22;
                    //
                    grid2[m, 0] = new SourceGrid.Cells.Cell(k_table.Rows[n]["row_id"].ToString(), typeof(string));     //row_id

                    grid2[m, 1] = new SourceGrid.Cells.CheckBox(null, false);              // √
                    grid2[m, 1].AddController(ClickEvent2);

                    grid2[m, 2] = new SourceGrid.Cells.Cell(m.ToString(), typeof(string)); // No;
                    grid2[m, 2].View = cc.center_cell;
                    grid2[m, 2].Editor = cc.disable_cell;

                    grid2[m, 3] = new SourceGrid.Cells.Cell(k_table.Rows[n]["a_code"].ToString(), typeof(string)); // a_code;
                    grid2[m, 3].View = cc.center_cell;
                    grid2[m, 3].Editor = cc.disable_cell;

                    grid2[m, 4] = new SourceGrid.Cells.Cell(k_table.Rows[n]["b_code"].ToString(), typeof(string)); // b_code;
                    grid2[m, 4].View = cc.center_cell;
                    grid2[m, 4].Editor = cc.disable_cell;

                    grid2[m, 5] = new SourceGrid.Cells.Cell(k_table.Rows[n]["b_item"].ToString(), typeof(string)); //bitem
                    grid2[m, 5].View = cc.left_cellr;
                    grid2[m, 5].AddController(ValueChangedEvent2);
                    grid2[m, 5].AddController(DoubleClick2);

                    m++;
                }
                b_code = "";
                c_code = "";
                make_grid3(false, null);
                //
                ClickEvent2.Click += new EventHandler(Clicked2);
                DoubleClick2.DoubleClick += new EventHandler(DoubleClicked2);
                ValueChangedEvent2.ValueChanged += new EventHandler(ValueChanged2);
            }
        }

        private void make_grid3(bool v_id, DataTable k_table)
        {
            grid3.Rows.Clear();

            cell_d cc = new cell_d();
            //
            cEventHelper.RemoveAllEventHandlers(ValueChangedEvent3);
            //
            grid3.BorderStyle = BorderStyle.FixedSingle;
            grid3.SelectionMode = SourceGrid.GridSelectionMode.Cell;
            grid3.ColumnsCount = 8;
            grid3.FixedRows = 1;
            grid3.Rows.Insert(0);
            grid3.Rows[0].Height = 26;
            grid3.HScrollBar.Visible = false;
            grid3.Selection.FocusStyle = grid3.Selection.FocusStyle | SourceGrid.FocusStyle.RemoveSelectionOnLeave;
            //
            grid3[0, 0] = new MyHeader1("row_id");
            grid3.Columns[0].Visible = false;
            grid3[0, 1] = new MyHeader1("√");
            grid3[0, 2] = new MyHeader1("No");
            grid3[0, 3] = new MyHeader1("a_code");
            grid3[0, 4] = new MyHeader1("b_code");
            grid3[0, 5] = new MyHeader1("c_code");
            grid3[0, 6] = new MyHeader1("douzone_code");
            grid3[0, 7] = new MyHeader1("c_계정과목");
            //
            grid3.Columns[0].Width = 100;   //row_id
            grid3.Columns[1].Width = 30;    // √
            grid3.Columns[2].Width = 40;    // no
            grid3.Columns[3].Width = 50;    // a
            grid3.Columns[4].Width = 50;    // b
            grid3.Columns[5].Width = 50;    // c
            grid3.Columns[6].Width = 100;   // douzone
            grid3.Columns[7].Width = 150;   // ctiem
            //
            if (v_id)
            {
                int m = 1;
                for (int n = 0; n < k_table.Rows.Count; n++)
                {
                    grid3.Rows.Insert(m);
                    grid3.Rows[m].Height = 22;
                    //
                    grid3[m, 0] = new SourceGrid.Cells.Cell(k_table.Rows[n]["row_id"].ToString(), typeof(string));     //row_id

                    grid3[m, 1] = new SourceGrid.Cells.CheckBox(null, false);              // √

                    grid3[m, 2] = new SourceGrid.Cells.Cell(m.ToString(), typeof(string)); // No;
                    grid3[m, 2].View = cc.center_cell;
                    grid3[m, 2].Editor = cc.disable_cell;

                    grid3[m, 3] = new SourceGrid.Cells.Cell(k_table.Rows[n]["a_code"].ToString(), typeof(string)); // a_code;
                    grid3[m, 3].View = cc.center_cell;
                    grid3[m, 3].Editor = cc.disable_cell;

                    grid3[m, 4] = new SourceGrid.Cells.Cell(k_table.Rows[n]["b_code"].ToString(), typeof(string)); // b_code;
                    grid3[m, 4].View = cc.center_cell;
                    grid3[m, 4].Editor = cc.disable_cell;

                    grid3[m, 5] = new SourceGrid.Cells.Cell(k_table.Rows[n]["c_code"].ToString(), typeof(string)); // a_code;
                    grid3[m, 5].View = cc.center_cell;
                    grid3[m, 5].Editor = cc.disable_cell;

                    grid3[m, 6] = new SourceGrid.Cells.Cell(k_table.Rows[n]["douzone_code"].ToString(), typeof(string)); //aitem
                    grid3[m, 6].View = cc.left_cellr;
                    //grid3[m, 6].Editor = cc.disable_cell;
                    grid3[m, 6].AddController(ValueChangedEvent3);

                    grid3[m, 7] = new SourceGrid.Cells.Cell(k_table.Rows[n]["c_item"].ToString(), typeof(string)); //aitem
                    grid3[m, 7].View = cc.left_cellr;
                    grid3[m, 7].AddController(ValueChangedEvent3);

                    m++;
                }
                c_code = "";
                ValueChangedEvent3.ValueChanged += new EventHandler(ValueChanged3);
            }
        }

        //private void make_grid3(string item)
        //{
        //    grid3.Rows.Clear();
        //    cell_d cc = new cell_d();
        //    //
        //    cEventHelper.RemoveAllEventHandlers(ValueChangedEvent3);
        //    //
        //    grid3.BorderStyle = BorderStyle.FixedSingle;
        //    grid3.SelectionMode = SourceGrid.GridSelectionMode.Cell;
        //    grid3.ColumnsCount = 8;
        //    grid3.FixedRows = 1;
        //    grid3.Rows.Insert(0);
        //    grid3.Rows[0].Height = 26;
        //    grid3.HScrollBar.Visible = false;
        //    grid3.Selection.FocusStyle = grid3.Selection.FocusStyle | SourceGrid.FocusStyle.RemoveSelectionOnLeave;
        //    //
        //    grid3[0, 0] = new MyHeader1("row_id");
        //    grid3.Columns[0].Visible = false;
        //    grid3[0, 1] = new MyHeader1("√");
        //    grid3[0, 2] = new MyHeader1("No");
        //    grid3[0, 3] = new MyHeader1("a_code");
        //    grid3[0, 4] = new MyHeader1("b_code");
        //    grid3[0, 5] = new MyHeader1("c_code");
        //    grid3[0, 6] = new MyHeader1("douzone_code");
        //    grid3[0, 7] = new MyHeader1("c_계정과목");
        //    //
        //    grid3.Columns[0].Width = 100;   //row_id
        //    grid3.Columns[1].Width = 30;    // √
        //    grid3.Columns[2].Width = 40;    // no
        //    grid3.Columns[3].Width = 50;    // a
        //    grid3.Columns[4].Width = 50;    // b
        //    grid3.Columns[5].Width = 50;    // c
        //    grid3.Columns[6].Width = 100;   // douzone
        //    grid3.Columns[7].Width = 150;   // ctiem
        //    //
        //    int m = 1;
        //    string cQuery = "SELECT * from f_cgroup where c_item like '%" + item + "%' order by a_code,b_code,c_code";
        //    var DBConn = new MySqlConnection(Config.DB_con1);
        //    DBConn.Open();
        //    DataTable k_table = new DataTable();
        //    var returnVal1 = new MySqlDataAdapter(cQuery, DBConn);
        //    returnVal1.Fill(k_table);
        //    returnVal1.Dispose();
        //    for (int n = 0; n < k_table.Rows.Count; n++)
        //    {
        //        grid3.Rows.Insert(m);
        //        grid3.Rows[m].Height = 22;
        //        //
        //        grid3[m, 0] = new SourceGrid.Cells.Cell(k_table.Rows[n]["row_id"].ToString(), typeof(string));     //row_id

        //        grid3[m, 1] = new SourceGrid.Cells.CheckBox(null, false);              // √

        //        grid3[m, 2] = new SourceGrid.Cells.Cell(m.ToString(), typeof(string)); // No;
        //        grid3[m, 2].View = cc.center_cell;
        //        grid3[m, 2].Editor = cc.disable_cell;

        //        grid3[m, 3] = new SourceGrid.Cells.Cell(k_table.Rows[n]["a_code"].ToString(), typeof(string)); // a_code;
        //        grid3[m, 3].View = cc.center_cell;
        //        grid3[m, 3].Editor = cc.disable_cell;

        //        grid3[m, 4] = new SourceGrid.Cells.Cell(k_table.Rows[n]["b_code"].ToString(), typeof(string)); // b_code;
        //        grid3[m, 4].View = cc.center_cell;
        //        grid3[m, 4].Editor = cc.disable_cell;

        //        grid3[m, 5] = new SourceGrid.Cells.Cell(k_table.Rows[n]["c_code"].ToString(), typeof(string)); // a_code;
        //        grid3[m, 5].View = cc.center_cellr;
        //        grid3[m, 5].AddController(ValueChangedEvent3);

        //        grid3[m, 6] = new SourceGrid.Cells.Cell(k_table.Rows[n]["douzone_code"].ToString(), typeof(string)); // douzone_code
        //        grid3[m, 6].View = cc.center_cellr;
        //        grid3[m, 6].AddController(ValueChangedEvent3);

        //        grid3[m, 7] = new SourceGrid.Cells.Cell(k_table.Rows[n]["c_item"].ToString(), typeof(string)); // citem
        //        grid3[m, 7].View = cc.left_cellr;
        //        grid3[m, 7].AddController(ValueChangedEvent3);

        //        m++;
        //    }
        //    c_code = "";
        //    ValueChangedEvent3.ValueChanged += new EventHandler(ValueChanged3);
        //}
        
        private void ValueChanged1(object sender, EventArgs e)  //Grid1에서 볼륨첸지
        {
            string cQuery = "";
            int pos = grid1.Selection.ActivePosition.Column;
            int row = grid1.Selection.ActivePosition.Row;
            string dat = grid1[row, pos].ToString().Trim();
            string row_no = grid1[row, 0].ToString().Trim(); //row_id 
            //
            if (pos == 3)
                return;
            //    cQuery = " update f_agroup set a_code='" + dat + "' where row_id='" + row_no + "'";
            else if (pos == 4)
                cQuery = " update f_agroup set a_item='" + dat + "' where row_id='" + row_no + "'";
            else
                cQuery = "";
            //
            if (cQuery != "")
            {
                var DBConn = new MySqlConnection(Config.DB_con1);
                DBConn.Open();
                string act_id = command_mod(cQuery, ref DBConn);
                if (act_id != "1")
                    MessageBox.Show("DB 서버 오류 입니다.");
            }
        }

        private void ValueChanged2(object sender, EventArgs e)  //Grid2에서 볼륨첸지
        {
            string cQuery = "";
            int pos = grid2.Selection.ActivePosition.Column;
            int row = grid2.Selection.ActivePosition.Row;
            string dat = grid2[row, pos].ToString().Trim();
            string row_no = grid2[row, 0].ToString().Trim(); //row_id 
            //
            if (pos == 4)
                return;
            //    cQuery = " update f_bgroup set b_code='" + dat + "' where row_id='" + row_no + "'";
            else if (pos == 5)
                cQuery = " update f_bgroup set b_item='" + dat + "' where row_id='" + row_no + "'";
            else
                cQuery = "";
            //
            if (cQuery != "")
            {
                var DBConn = new MySqlConnection(Config.DB_con1);
                DBConn.Open();
                string act_id = command_mod(cQuery, ref DBConn);
                if (act_id != "1")
                    MessageBox.Show("DB 서버 오류 입니다.");
            }
        }

        private void ValueChanged3(object sender, EventArgs e)  //Grid3에서 볼륨첸지
        {
            string cQuery = "";
            int pos = grid3.Selection.ActivePosition.Column;
            int row = grid3.Selection.ActivePosition.Row;
            string dat = grid3[row, pos].ToString().Trim();
            string row_no = grid3[row, 0].ToString().Trim(); //row_id 
            //
            if (pos == 5)
                return;
            //    cQuery = " update f_cgroup set c_code='" + dat + "' where row_id='" + row_no + "'";
            else if (pos == 6)
                cQuery = " update f_cgroup set douzone_code='" + dat + "' where row_id='" + row_no + "'";
            else if (pos == 7)
                cQuery = " update f_cgroup set c_item='" + dat + "' where row_id='" + row_no + "'";
            else
                cQuery = "";
            //
            if (cQuery != "")
            {
                //asdfasdfasdf
                var DBConn = new MySqlConnection(Config.DB_con1);
                DBConn.Open();
                string act_id = command_mod(cQuery, ref DBConn);
                if (act_id != "1")
                    MessageBox.Show("DB 서버 오류 입니다.");
            }
        }
        
        private void Clicked1(object sender, EventArgs e)  //Grid1에서 클릭 이벤트
        {
            int pos = grid1.Selection.ActivePosition.Column;
            int row = grid1.Selection.ActivePosition.Row;
            if (Convert.ToBoolean(grid1[row, 1].ToString()))
            {
                a_code = grid1[row, 3].ToString().Trim();
                make_grid2(true);
            }
            else
            {
                a_code = "";
                b_code = "";
                c_code = "";
                make_grid2(false);
                make_grid3(false, null);
            }
            //  
            for (int n = 1; n < grid1.RowsCount; n++)
            {
                if ( n != row)
                {
                    grid1[n, 1].Value = false;
                }
            }
        }

        private void Clicked2(object sender, EventArgs e)  //Grid2에서 클릭 이벤트
        {
            int pos = grid2.Selection.ActivePosition.Column;
            int row = grid2.Selection.ActivePosition.Row;
            if (Convert.ToBoolean(grid2[row, 1].ToString()))
            {
                a_code = grid2[row, 3].ToString().Trim();
                b_code = grid2[row, 4].ToString().Trim();
                string cQuery = "SELECT * from f_cgroup where a_code='" + a_code + "' and b_code='" + b_code + "' order by a_code,b_code,c_code";

                var DBConn = new MySqlConnection(Config.DB_con1);
                DBConn.Open();
                DataTable k_table = new DataTable();
                var returnVal1 = new MySqlDataAdapter(cQuery, DBConn);
                returnVal1.Fill(k_table);
                returnVal1.Dispose();
                make_grid3(true, k_table);
            }
            else
            {
                b_code = "";
                c_code = "";
                make_grid3(false, null);
            }
            //  
            for (int n = 1; n < grid2.RowsCount; n++)
            {
                if (n != row)
                {
                    grid2[n, 1].Value = false;
                }
            }
        }

        private void DoubleClicked1(object sender, EventArgs e)  //Grid1에서 더블클릭 이벤트
        {
            int row = grid1.Selection.ActivePosition.Row;
            grid1[row, 1].Value = true;
            a_code = grid1[row, 3].ToString().Trim();
            make_grid2(true);
            for (int n = 1; n < grid1.RowsCount; n++)
            {
                if (n != row)
                {
                    grid1[n, 1].Value = false;
                }
            }
        }

        private void DoubleClicked2(object sender, EventArgs e)  //Grid2에서 더블클릭 이벤트
        {
            int row = grid2.Selection.ActivePosition.Row;
            grid2[row, 1].Value = true;
            a_code = grid2[row, 3].ToString().Trim();
            b_code = grid2[row, 4].ToString().Trim();
            string cQuery = "SELECT * from f_cgroup where a_code='" + a_code + "' and b_code='" + b_code + "' order by a_code,b_code,c_code";

            var DBConn = new MySqlConnection(Config.DB_con1);
            DBConn.Open();
            DataTable k_table = new DataTable();
            var returnVal1 = new MySqlDataAdapter(cQuery, DBConn);
            returnVal1.Fill(k_table);
            returnVal1.Dispose();
            make_grid3(true, k_table);
            for (int n = 1; n < grid2.RowsCount; n++)
            {
                if (n != row)
                {
                    grid2[n, 1].Value = false;
                }
            }
        }


        private void cuteButton2_Click(object sender, EventArgs e)  //a항목 추가
        {
            string temp = grid1[grid1.RowsCount - 1, 3].ToString();  //a_code
            string temp1 = "";
            if (temp.Substring(0,1) == "0")
            {
                if (temp.Substring(1, 1) == "9")
                    temp1 = "10";
                else
                    temp1 = "0" + (Convert.ToInt32(temp) + 1).ToString();
            }
            else
                temp1 = (Convert.ToInt32(temp) + 1).ToString(); 
            //

            string cQuery = " insert f_agroup(a_code) values('" + temp1 + "')";
            var DBConn = new MySqlConnection(Config.DB_con1);
            DBConn.Open();
            string last_id = command_reg(cQuery, ref DBConn);
            if (last_id == "false")
                MessageBox.Show("DB 서버 오류 입니다.");
            else
                make_grid1();
        }

        private void cuteButton3_Click(object sender, EventArgs e)  //b항목 추가
        {
            if (a_code == "")
            {
                MessageBox.Show("먼저 a_code 항목을 선택해 주십시요.");
                return;
            }
            //
            string temp = "";  //b_code
            string temp1 = "";
            //
            if (grid2.RowsCount == 1)
            {
                temp1 = "01";
            }
            else
            {
                temp = grid2[grid2.RowsCount - 1, 4].ToString();  //b_code
                if (temp.Substring(0, 1) == "0")
                {
                    if (temp.Substring(1, 1) == "9")
                        temp1 = "10";
                    else
                        temp1 = "0" + (Convert.ToInt32(temp) + 1).ToString();
                }
                else
                    temp1 = (Convert.ToInt32(temp) + 1).ToString();
            }
            //

            string cQuery = " insert f_bgroup(a_code,b_code) values('" + a_code + "','" + temp1 + "')";
            var DBConn = new MySqlConnection(Config.DB_con1);
            DBConn.Open();
            string last_id = command_reg(cQuery, ref DBConn);
            if (last_id == "false")
                MessageBox.Show("DB 서버 오류 입니다.");
            else
                make_grid2(true);
        }

        private void cuteButton5_Click(object sender, EventArgs e) //c항목 추가
        {
            if (a_code == "")
            {
                MessageBox.Show("먼저 a_code 항목을 선택해 주십시요.");
                return;
            }
            //
            if (b_code == "")
            {
                MessageBox.Show("먼저 b_code 항목을 선택해 주십시요.");
                return;
            }
            //
            string temp = "";  //c_code
            string temp1 = "";
            //
            if (grid3.RowsCount == 1)
            {
                temp1 = "01";
            }
            else
            {
                temp = grid3[grid3.RowsCount - 1, 5].ToString();  //c_code
                if (temp.Substring(0, 1) == "0")
                {
                    if (temp.Substring(1, 1) == "9")
                        temp1 = "10";
                    else
                        temp1 = "0" + (Convert.ToInt32(temp) + 1).ToString();
                }
                else
                    temp1 = (Convert.ToInt32(temp) + 1).ToString();
            }
            //

            string cQuery = " insert f_cgroup(a_code,b_code,c_code) values('" + a_code + "','" + b_code + "','" + temp1 + "')";
            var DBConn = new MySqlConnection(Config.DB_con1);
            DBConn.Open();
            string last_id = command_reg(cQuery, ref DBConn);
            if (last_id == "false")
                MessageBox.Show("DB 서버 오류 입니다.");
            else
            {
                cQuery = "SELECT * from f_cgroup where a_code='" + a_code + "' and b_code='" + b_code + "' order by a_code,b_code,c_code";
                
                DataTable k_table = new DataTable();
                var returnVal1 = new MySqlDataAdapter(cQuery, DBConn);
                returnVal1.Fill(k_table);
                returnVal1.Dispose();

                make_grid3(true, k_table);
            }
        }

        private void cuteButton1_Click(object sender, EventArgs e)
        {
            for (int n = 1; n < grid1.RowsCount; n++)
            {
                if (Convert.ToBoolean(grid1[n, 1].ToString()))
                {
                    if (MessageBox.Show("선택한 항목을 삭제합니까 ?", "항목삭제", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                    {
                        string row_no = grid1[n, 0].ToString();
                        string cQuery = " delete from f_agroup where row_id='" + row_no + "'";
                        var DBConn = new MySqlConnection(Config.DB_con1);
                        DBConn.Open();
                        string act_id = command_mod(cQuery, ref DBConn);
                        if (act_id != "1")
                            MessageBox.Show("DB 서버 오류 입니다.");
                    }
                    make_grid1();
                    break;
                }
            }
        }

        private void cuteButton4_Click(object sender, EventArgs e)
        {
            for (int n = 1; n < grid2.RowsCount; n++)
            {
                if (Convert.ToBoolean(grid2[n, 1].ToString()))
                {
                    if (MessageBox.Show("선택한 항목을 삭제합니까 ?", "항목삭제", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                    {
                        string row_no = grid2[n, 0].ToString();
                        string cQuery = " delete from f_bgroup where row_id='" + row_no + "'";
                        var DBConn = new MySqlConnection(Config.DB_con1);
                        DBConn.Open();
                        string act_id = command_mod(cQuery, ref DBConn);
                        if (act_id != "1")
                            MessageBox.Show("DB 서버 오류 입니다.");
                    }
                    make_grid2(true);
                    break;
                }
            }

        }

        private void cuteButton6_Click(object sender, EventArgs e)
        {
            for (int n = 1; n < grid3.RowsCount; n++)
            {
                if (Convert.ToBoolean(grid3[n, 1].ToString()))
                {
                    if (MessageBox.Show("선택한 항목을 삭제합니까 ?", "항목삭제", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                    {
                        string row_no = grid3[n, 0].ToString();
                        string cQuery = " delete from f_cgroup where row_id='" + row_no + "'";
                        var DBConn = new MySqlConnection(Config.DB_con1);
                        DBConn.Open();
                        string act_id = command_mod(cQuery, ref DBConn);
                        if (act_id != "1")
                            MessageBox.Show("DB 서버 오류 입니다.");
                        else
                        {
                            cQuery = "SELECT * from f_cgroup where a_code='" + a_code + "' and b_code='" + b_code + "' order by a_code,b_code,c_code";

                            DataTable k_table = new DataTable();
                            var returnVal1 = new MySqlDataAdapter(cQuery, DBConn);
                            returnVal1.Fill(k_table);
                            returnVal1.Dispose();
                            make_grid3(true, k_table);
                        }
                    }

                   
                    break;
                }
            }

        }

        private void cuteButton8_Click(object sender, EventArgs e)  //소분류검색
        {
            string cQuery = "SELECT * from f_cgroup where c_item like '%" + textBox2.Text.Trim() + "%' order by a_code,b_code,c_code";
            var DBConn = new MySqlConnection(Config.DB_con1);
            DBConn.Open();
            DataTable k_table = new DataTable();
            var returnVal1 = new MySqlDataAdapter(cQuery, DBConn);
            returnVal1.Fill(k_table);
            returnVal1.Dispose();

            make_grid3(true, k_table);
        }

        private void cuteButton7_Click(object sender, EventArgs e)
        {

        }

        public string command_reg(string query, ref MySqlConnection DB_Conn)
        {
            try
            {
                var cmd = new MySqlCommand(query, DB_Conn);
                int result = cmd.ExecuteNonQuery();
                if (result < 0)
                    return "-1";

                string cQuery = "SELECT LAST_INSERT_ID() dd";
                cmd = new MySqlCommand(cQuery, DB_Conn);
                var myRead = cmd.ExecuteReader();
                string insertId = "";
                while (myRead.Read())
                    insertId = myRead["dd"].ToString();
                myRead.Close();
                return insertId;
            }
            catch
            {
                return "false";
            }
           
        }

        public string command_mod(string query, ref MySqlConnection DB_Conn)
        {
            if (query == "")
                return "";
            //
            string act_id = "";
            var cmd = new MySqlCommand(query, DB_Conn);
            int result = cmd.ExecuteNonQuery();
            if (result < 0)
                act_id = "-1";
            else
                act_id = "1";
            return act_id.ToString();
        }

    }
}
