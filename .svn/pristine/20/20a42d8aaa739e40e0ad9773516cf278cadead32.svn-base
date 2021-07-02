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
    public partial class Form_214 : Form
    {
        DataTable sbag = new DataTable();
        sync sy = new sync();
        DataRow[] dr;
        cell_d cc = new cell_d();
        ksgcontrol ks = new ksgcontrol();
        SourceGridControl GridHandle = new SourceGridControl();
        SourceGridControl GridHandle1 = new SourceGridControl();
        int Rows;
        public Form_214()
        {
            InitializeComponent();
        }
        //gubun 1: 풀발이 2: 상단길이
        private void Form_214_Load(object sender, EventArgs e)
        {
            Screen srn = Screen.PrimaryScreen;
            int Xb = this.Width;  //좌,우
            this.Location = new Point((srn.Bounds.Width - Xb) / 2, 1);  //좌/우,위/아래

            SourceGrid.Cells.Controllers.CustomEvents val_c1 = new SourceGrid.Cells.Controllers.CustomEvents();
            val_c1.ValueChanged += new EventHandler(ValueChangedEvent1);
            grid1.Controller.AddController(val_c1);

            SourceGrid.Cells.Controllers.CustomEvents val_c2 = new SourceGrid.Cells.Controllers.CustomEvents();
            val_c2.ValueChanged += new EventHandler(ValueChangedEvent2);
            grid2.Controller.AddController(val_c2);
            ks.ControlInit(Config.DB_con1, null, null, null);
            GridHandle.SourceGrideInit(grid1, Config.DB_con1);
            GridHandle1.SourceGrideInit(grid2, Config.DB_con1);

            sy.dt(Config.DB_con1, sbag, "select * from C_sbag_check_cal order by row_id");
            dr = sbag.Select();
            if(dr.Length !=0)
            {
                tbMinjang.Text = dr[0]["jang_min"].ToString();
                tbMinpok.Text = dr[0]["pok_min"].ToString();
                tbMingo.Text = dr[0]["go_min"].ToString();
                tbBottom.Text = dr[0]["bottom_length"].ToString();
                tbMargin.Text = dr[0]["margin"].ToString();
                tbDombo.Text = dr[0]["dombo"].ToString();
            }
            grid1_view();
            grid2_view();

        }
        private void ValueChangedEvent1(object sender, EventArgs e)  //Grid1에서 볼륨첸지
        {
            string Query = "";
            int pos = grid1.Selection.ActivePosition.Column;
            int row = grid1.Selection.ActivePosition.Row;
            string dat = grid1[row, pos].ToString().Trim();
            string row_no = grid1[row, 0].ToString().Trim(); //row_id 

            if (pos == 3)
            {
                Query = "update C_sbag_check_cal set attaching_exceed = '" + dat + "' where row_id = " + row_no;
                ks.DataUpdate(Query);
            }
            if (pos == 4)
            {
                Query = "update C_sbag_check_cal set attaching_less = '" + dat + "' where row_id = " + row_no;
                ks.DataUpdate(Query);
            }
            if (pos == 5)
            {
                Query = "update C_sbag_check_cal set attaching = '" + dat + "' where row_id = " + row_no;
                ks.DataUpdate(Query);
            }
        }
        private void ValueChangedEvent2(object sender, EventArgs e)  //Grid1에서 볼륨첸지
        {
            string Query = "";
            int pos = grid2.Selection.ActivePosition.Column;
            int row = grid2.Selection.ActivePosition.Row;
            string dat = grid2[row, pos].ToString().Trim();
            string row_no = grid2[row, 0].ToString().Trim(); //row_id 

            if (pos == 3)
            {
                Query = "update C_sbag_check_cal set top_length_exceed = '" + dat + "' where row_id = " + row_no;
                ks.DataUpdate(Query);
            }
            if (pos == 4)
            {
                Query = "update C_sbag_check_cal set top_length_less = '" + dat + "' where row_id = " + row_no;
                ks.DataUpdate(Query);
            }
            if (pos == 5)
            {
                Query = "update C_sbag_check_cal set top_length = '" + dat + "' where row_id = " + row_no;
                ks.DataUpdate(Query);
            }


        }
            
        


        private void grid1_view()
        {
            grid1.Rows.Clear();
            grid1.BorderStyle = BorderStyle.FixedSingle;
            grid1.ColumnsCount = 6;
            grid1.FixedRows = 2;
            grid1.Rows.Insert(0);
            grid1.Rows[0].Height = 24;
            grid1.Rows.Insert(1);
            grid1.Rows[1].Height = 24;

            grid1[0, 0] = new MyHeader1("row_id");
            grid1.Columns[0].Visible = false;
            grid1[0, 1] = new MyHeader1("√");
            grid1[0, 1].RowSpan = 2;
            grid1[0, 2] = new MyHeader1("No");
            grid1[0, 2].RowSpan = 2;

            grid1[0, 3] = new MyHeader1("장 (mm)");
            grid1[0, 3].ColumnSpan = 2;
            grid1[0, 5] = new MyHeader1("풀발이\r\n(mm)");
            grid1[0, 5].RowSpan = 2;

            grid1[1, 3] = new MyHeader1("< 초과");
            grid1[1, 4] = new MyHeader1("이하 ≤");
           

            grid1.Columns[1].Width = 20;
            grid1.Columns[2].Width = 30;
            grid1.Columns[3].Width = 75;
            grid1.Columns[4].Width = 75;
            grid1.Columns[5].Width = 65;
            dr = sbag.Select("gubun = 1");
            int m = 2;
            int max_row = 15;

            for (int i = 0; i < dr.Length; i++)
            {
                grid1.Rows.Insert(m);
                grid1.Rows[m].Height = 20;

                grid1[m, 0] = new SourceGrid.Cells.Cell(dr[i]["row_id"].ToString(), typeof(string));

                grid1[m, 1] = new SourceGrid.Cells.CheckBox(null, false);

                grid1[m, 2] = new SourceGrid.Cells.Cell((i + 1).ToString(), typeof(string));
                grid1[m, 2].Editor = cc.disable_cell;
                grid1[m, 2].View = cc.center_cell;

                grid1[m, 3] = new SourceGrid.Cells.Cell(dr[i]["attaching_exceed"].ToString(), typeof(string));

                grid1[m, 3].View = cc.center_cell;

                grid1[m, 4] = new SourceGrid.Cells.Cell(dr[i]["attaching_less"].ToString(), typeof(string));

                grid1[m, 4].View = cc.center_cell;

                grid1[m, 5] = new SourceGrid.Cells.Cell(dr[i]["attaching"].ToString(), typeof(string));

                grid1[m, 5].View = cc.center_cell;
                m++;
            }
            if (dr.Length < 15)
            {
                for (int x = dr.Length; x < max_row; x++)
                {
                    string Query = "insert into C_sbag_check_cal(jang_min, pok_min, go_min, margin, dombo, bottom_length, gubun) ";
                    Query += "values('" + tbMinjang.Text + "','" + tbMinpok.Text + "','" + tbMingo.Text + "','" + tbMargin.Text + "','" + tbDombo.Text + "','" + tbBottom.Text + "', '1')";
                    string new_row = ks.DataUpdate(Query);

                    grid1.Rows.Insert(m);
                    grid1.Rows[m].Height = 20;

                    grid1[m, 0] = new SourceGrid.Cells.Cell(new_row, typeof(string));

                    grid1[m, 1] = new SourceGrid.Cells.CheckBox(null, false);

                    grid1[m, 2] = new SourceGrid.Cells.Cell((m-1), typeof(string));
                    grid1[m, 2].Editor = cc.disable_cell;
                    grid1[m, 2].View = cc.center_cell;

                    grid1[m, 3] = new SourceGrid.Cells.Cell("", typeof(string));

                    grid1[m, 3].View = cc.center_cell;

                    grid1[m, 4] = new SourceGrid.Cells.Cell("", typeof(string));

                    grid1[m, 4].View = cc.center_cell;

                    grid1[m, 5] = new SourceGrid.Cells.Cell("", typeof(string));

                    grid1[m, 5].View = cc.center_cell;
                    m++;
                }
            }
        }

        private void grid2_view()
        {
            grid2.Rows.Clear();
            grid2.BorderStyle = BorderStyle.FixedSingle;
            grid2.ColumnsCount = 6;
            grid2.FixedRows = 2;
            grid2.Rows.Insert(0);
            grid2.Rows[0].Height = 24;
            grid2.Rows.Insert(1);
            grid2.Rows[1].Height = 24;

            grid2[0, 0] = new MyHeader1("row_id");
            grid2.Columns[0].Visible = false;
            grid2[0, 1] = new MyHeader1("√");
            grid2[0, 1].RowSpan = 2;
            grid2[0, 2] = new MyHeader1("No");
            grid2[0, 2].RowSpan = 2;

            grid2[0, 3] = new MyHeader1("고 (mm)");
            grid2[0, 3].ColumnSpan = 2;
            grid2[0, 5] = new MyHeader1("상단\r\n(mm)");
            grid2[0, 5].RowSpan = 2;

            grid2[1, 3] = new MyHeader1("< 초과");
            grid2[1, 4] = new MyHeader1("이하 ≤");


            grid2.Columns[1].Width = 20;
            grid2.Columns[2].Width = 30;
            grid2.Columns[3].Width = 75;
            grid2.Columns[4].Width = 75;
            grid2.Columns[5].Width = 65;
            dr = sbag.Select("gubun = 2");
            int m = 2;
            int max_row = 15;

            for (int i = 0; i < dr.Length; i++)
            {
                grid2.Rows.Insert(m);
                grid2.Rows[m].Height = 20;

                grid2[m, 0] = new SourceGrid.Cells.Cell(dr[i]["row_id"].ToString(), typeof(string));

                grid2[m, 1] = new SourceGrid.Cells.CheckBox(null, false);

                grid2[m, 2] = new SourceGrid.Cells.Cell((i + 1).ToString(), typeof(string));
                grid2[m, 2].Editor = cc.disable_cell;
                grid2[m, 2].View = cc.center_cell;

                grid2[m, 3] = new SourceGrid.Cells.Cell(dr[i]["top_length_exceed"].ToString(), typeof(string));

                grid2[m, 3].View = cc.center_cell;

                grid2[m, 4] = new SourceGrid.Cells.Cell(dr[i]["top_length_less"].ToString(), typeof(string));

                grid2[m, 4].View = cc.center_cell;

                grid2[m, 5] = new SourceGrid.Cells.Cell(dr[i]["top_length"].ToString(), typeof(string));

                grid2[m, 5].View = cc.center_cell;
                m++;
            }
            if (dr.Length < 15)
            {
                for (int x = dr.Length; x < max_row; x++)
                {
                    string Query = "insert into C_sbag_check_cal(jang_min, pok_min, go_min, margin, dombo, bottom_length, gubun) ";
                    Query += "values('" + tbMinjang.Text + "','" + tbMinpok.Text + "','" + tbMingo.Text + "','" + tbMargin.Text + "','" + tbDombo.Text + "','" + tbBottom.Text + "', '2')";
                    string new_row = ks.DataUpdate(Query);

                    grid2.Rows.Insert(m);
                    grid2.Rows[m].Height = 20;

                    grid2[m, 0] = new SourceGrid.Cells.Cell(new_row, typeof(string));

                    grid2[m, 1] = new SourceGrid.Cells.CheckBox(null, false);

                    grid2[m, 2] = new SourceGrid.Cells.Cell((m - 1), typeof(string));
                    grid2[m, 2].Editor = cc.disable_cell;
                    grid2[m, 2].View = cc.center_cell;

                    grid2[m, 3] = new SourceGrid.Cells.Cell("", typeof(string));

                    grid2[m, 3].View = cc.center_cell;

                    grid2[m, 4] = new SourceGrid.Cells.Cell("", typeof(string));

                    grid2[m, 4].View = cc.center_cell;

                    grid2[m, 5] = new SourceGrid.Cells.Cell("", typeof(string));

                    grid2[m, 5].View = cc.center_cell;
                    m++;
                }
            }
        }

        private void bAttadd_Click(object sender, EventArgs e)
        {
            string Query = "insert into C_sbag_check_cal(jang_min, pok_min, go_min, margin, dombo, bottom_length, gubun) ";
            Query += "values('" + tbMinjang.Text + "','" + tbMinpok.Text + "','" + tbMingo.Text + "','" + tbMargin.Text + "','" + tbDombo.Text + "','" + tbBottom.Text + "', '1')";
            string new_row = ks.DataUpdate(Query);
            
            Rows = grid1.RowsCount;
            grid1.Rows.Insert(Rows);
            grid1.Rows[Rows].Height = 20;

            grid1[Rows, 0] = new SourceGrid.Cells.Cell(new_row, typeof(string));

            grid1[Rows, 1] = new SourceGrid.Cells.CheckBox(null, false);

            grid1[Rows, 2] = new SourceGrid.Cells.Cell((Rows-1), typeof(string));
            grid1[Rows, 2].Editor = cc.disable_cell;
            grid1[Rows, 2].View = cc.center_cell;

            grid1[Rows, 3] = new SourceGrid.Cells.Cell("", typeof(string));

            grid1[Rows, 3].View = cc.center_cell;

            grid1[Rows, 4] = new SourceGrid.Cells.Cell("", typeof(string));

            grid1[Rows, 4].View = cc.center_cell;

            grid1[Rows, 5] = new SourceGrid.Cells.Cell("", typeof(string));

            grid1[Rows, 5].View = cc.center_cell;

            Rows++;
        }

        private void bAttdel_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("삭제하시겠습니까?", "메세지창", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                GridHandle.ChkDataDelete("C_sbag_check_cal", 2, 0, 1);
                for (int i = 2; i < grid1.RowsCount; i++)
                {
                    grid1[i, 2] = new SourceGrid.Cells.Cell((i - 1), typeof(string));
                    grid1[i, 2].Editor = cc.disable_cell;
                    grid1[i, 2].View = cc.center_cell;
                }
            }
        }

        private void bCalsave_Click(object sender, EventArgs e)
        {
            string Query = "update C_sbag_check_cal set jang_min = '" + tbMinjang.Text + "' , pok_min ='" + tbMinpok.Text + "' , go_min = '" + tbMingo.Text + "', margin = '" + tbMargin.Text + "', dombo = '" + tbDombo.Text + "'";
            ks.DataUpdate(Query);
            MessageBox.Show("저장되었습니다.");
        }

        private void bBottomsave_Click(object sender, EventArgs e)
        {
            string Query = "update C_sbag_check_cal set bottom_length = '" + tbBottom.Text + "'";
            ks.DataUpdate(Query);
            MessageBox.Show("저장되었습니다.");
        }

        private void bTopadd_Click(object sender, EventArgs e)
        {
            string Query = "insert into C_sbag_check_cal(jang_min, pok_min, go_min, margin, dombo, bottom_length, gubun) ";
            Query += "values('" + tbMinjang.Text + "','" + tbMinpok.Text + "','" + tbMingo.Text + "','" + tbMargin.Text + "','" + tbDombo.Text + "','" + tbBottom.Text + "', '2')";
            string new_row = ks.DataUpdate(Query);

            Rows = grid2.RowsCount;
            grid2.Rows.Insert(Rows);
            grid2.Rows[Rows].Height = 20;

            grid2[Rows, 0] = new SourceGrid.Cells.Cell(new_row, typeof(string));

            grid2[Rows, 1] = new SourceGrid.Cells.CheckBox(null, false);

            grid2[Rows, 2] = new SourceGrid.Cells.Cell((Rows - 1), typeof(string));
            grid2[Rows, 2].Editor = cc.disable_cell;
            grid2[Rows, 2].View = cc.center_cell;

            grid2[Rows, 3] = new SourceGrid.Cells.Cell("", typeof(string));

            grid2[Rows, 3].View = cc.center_cell;

            grid2[Rows, 4] = new SourceGrid.Cells.Cell("", typeof(string));

            grid2[Rows, 4].View = cc.center_cell;

            grid2[Rows, 5] = new SourceGrid.Cells.Cell("", typeof(string));

            grid2[Rows, 5].View = cc.center_cell;

            Rows++;
        }

        private void bTopdel_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("삭제하시겠습니까?", "메세지창", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                GridHandle1.ChkDataDelete("C_sbag_check_cal", 2, 0, 1);
                for (int i = 2; i < grid2.RowsCount; i++)
                {
                    grid2[i, 2] = new SourceGrid.Cells.Cell((i - 1), typeof(string));
                    grid2[i, 2].Editor = cc.disable_cell;
                    grid2[i, 2].View = cc.center_cell;
                }
            }
        }
    }
}
