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
    public partial class Form_501c : Form
    {
        SourceGrid.Cells.Controllers.CustomEvents ValueChangeEvent1 = new SourceGrid.Cells.Controllers.CustomEvents();//
        SourceGridControl GridHandle = new SourceGridControl();
        SourceGrid.Grid tempGrid = new SourceGrid.Grid();

        string DB_TableName_paper = "C_paper_size_code";

        public string package_sgroup = "";
        Boolean Chk_sgroup_1 = false;
        Boolean Chk_sgroup_2 = false;
        TextBox mom_tb;
        string guboon = "";
        int x;
        int y;

        private List<string> codeList; //체크한 코드들을 담을 리스트

        public Form_501c(TextBox tb, int x, int y, string guboon)
        {
            codeList = new List<string>();
            InitializeComponent();
            this.mom_tb = tb;
            this.x = x;
            this.y = y;
            this.guboon = guboon;
        }

        private void Form_502c_Load(object sender, EventArgs e)
        {
            Screen srn = Screen.PrimaryScreen;
            int Xb = this.Width;  //좌,우
            int Yb = this.Height; //좌,우
            this.Location = new Point(x, y);  //좌/우,위/아래

            GridHandle.SourceGrideInit(grid1, Config.DB_con1);

            textBox1.Text = "";
            textBox2.Text = "";
            Grid_View();

            TempGrid_Setting();
        }

        private void Grid_View()
        {
            string width = "";
            string height = "";

            if (textBox1.Text.Trim() != "" && textBox2.Text.Trim() != "")
            {
                width = $" and ((width = '{textBox1.Text}' and height = '{textBox2.Text}') or (height = '{textBox1.Text}' and width = '{textBox2.Text}'))";
            }
            else if (textBox1.Text.Trim() != "")
            {
                width = $" and (width = '{textBox1.Text}' or height = '{textBox1.Text}')";
            }
            else if (textBox2.Text.Trim() != "")
            {
                height = $" and (height = '{textBox2.Text}' or width = '{textBox2.Text}')";
            }

            string cQuery = $"select * from { DB_TableName_paper } where prn_guboon='{ guboon }'{width}{height} order by grain DESC ,sort_no";
            cell_d cc = new cell_d();
            // 
            grid1.Rows.Clear();
            grid1.BorderStyle = BorderStyle.FixedSingle;
            grid1.SelectionMode = SourceGrid.GridSelectionMode.Cell;
            grid1.ColumnsCount = 16;
            grid1.FixedRows = 1;
            grid1.Rows.Insert(0);
            grid1.Rows[0].Height = 24;
            //
            grid1[0, 0] = new MyHeader1("row_id");
            grid1.Columns[0].Visible = false;

            grid1[0, 1] = new MyHeader1("√");
            grid1[0, 2] = new MyHeader1("No");
            grid1[0, 3] = new MyHeader1("코드");
            grid1[0, 4] = new MyHeader1("판형");
            grid1[0, 4].ColumnSpan = 2;
            grid1[0, 6] = new MyHeader1("결");
            grid1[0, 7] = new MyHeader1("사이즈");

            grid1[0, 8] = new MyHeader1("row_id");
            grid1.Columns[8].Visible = false;

            grid1[0, 9] = new MyHeader1("√");
            grid1[0, 10] = new MyHeader1("No");
            grid1[0, 11] = new MyHeader1("코드");
            grid1[0, 12] = new MyHeader1("판형");
            grid1[0, 12].ColumnSpan = 2;
            grid1[0, 14] = new MyHeader1("결");
            grid1[0, 15] = new MyHeader1("사이즈");
            //
            grid1.Columns[1].Width = 22;
            grid1.Columns[2].Width = 30;
            grid1.Columns[3].Width = 40;
            grid1.Columns[4].Width = 40;
            grid1.Columns[5].Width = 40;
            grid1.Columns[6].Width = 40;
            grid1.Columns[7].Width = 100;

            grid1.Columns[9].Width = 22;
            grid1.Columns[10].Width = 30;
            grid1.Columns[11].Width = 40;
            grid1.Columns[12].Width = 40;
            grid1.Columns[13].Width = 40;
            grid1.Columns[14].Width = 40;
            grid1.Columns[15].Width = 100;
            //
            MySqlConnection DBConn;

            DBConn = new MySqlConnection(Config.DB_con1);
            DBConn.Open();

            var cmd = new MySqlCommand(cQuery, DBConn);
            var myRead = cmd.ExecuteReader();

            // 
            int m = 1;
            int column = 0;
            string grain = "";
            int count = codeList.Count;

            while (myRead.Read())
            {
                if (grain != "" && grain != myRead["grain"].ToString())
                {
                    m = 1;
                    column = 8;
                }

                if (column == 0)
                {
                    grid1.Rows.Insert(m);
                    grid1.Rows[m].Height = 22;
                }
                //
                grid1[m, column + 0] = new SourceGrid.Cells.Cell(myRead["row_id"], typeof(string));

                if (count != 0)
                {
                    bool pass = false;

                    for (int i = 0; i < codeList.Count; i++)
                    {
                        if(codeList[i] == myRead["base_paper_code"].ToString())
                        {
                            grid1[m, column + 1] = new SourceGrid.Cells.CheckBox(null, true);
                            grid1[m, column + 1].AddController(ValueChangeEvent1);
                            count--;
                            pass = true;
                            break;
                        }
                    }

                    if(!pass)
                    {
                        grid1[m, column + 1] = new SourceGrid.Cells.CheckBox(null, false);
                        grid1[m, column + 1].AddController(ValueChangeEvent1);
                    }
                }
                else
                {
                    if (mom_tb.Text.IndexOf(myRead["base_paper_code"].ToString()) >= 0)
                    {
                        codeList.Add(myRead["base_paper_code"].ToString());
                        grid1[m, column + 1] = new SourceGrid.Cells.CheckBox(null, true);
                        grid1[m, column + 1].AddController(ValueChangeEvent1);
                    }
                    else
                    {
                        grid1[m, column + 1] = new SourceGrid.Cells.CheckBox(null, false);
                        grid1[m, column + 1].AddController(ValueChangeEvent1);
                    }
                }

                grid1[m, column + 2] = new SourceGrid.Cells.Cell(m.ToString(), typeof(string));
                grid1[m, column + 2].View = cc.center_cell;
                grid1[m, column + 2].Editor = cc.disable_cell;

                grid1[m, column + 3] = new SourceGrid.Cells.Cell(myRead["base_paper_code"], typeof(string));
                grid1[m, column + 3].View = cc.center_cell;
                grid1[m, column + 3].Editor = cc.disable_cell;

                grid1[m, column + 4] = new SourceGrid.Cells.Cell(myRead["kook"], typeof(string));
                grid1[m, column + 4].View = cc.center_cell;

                grid1[m, column + 5] = new SourceGrid.Cells.Cell(myRead["jul"], typeof(string));
                grid1[m, column + 5].View = cc.center_cell;

                grid1[m, column + 6] = new SourceGrid.Cells.Cell(myRead["grain"], typeof(string));
                grid1[m, column + 6].View = cc.center_cell;

                grid1[m, column + 7] = new SourceGrid.Cells.Cell(myRead["width"].ToString() + "*" + myRead["height"].ToString(), typeof(string));
                grid1[m, column + 7].View = cc.center_cell;

                grain = myRead["grain"].ToString();
                m++;
            }
            myRead.Close();
            DBConn.Close();
            ValueChangeEvent1.ValueChanged += ValueChangedEvent1;
        }

        private void TempGrid_Setting()
        {
            tempGrid.ColumnsCount = 2;

            for(int i = 0; i < grid1.RowsCount -1; i++)
            {
                tempGrid.Rows.Insert(i);
                for(int j = 0; j < 2; j++)
                {
                    tempGrid[i, j] = new SourceGrid.Cells.Cell(grid1[i + 1, (j * 8) + 3].Value.ToString(), typeof(string));
                }
            }    
        }

        private void ValueChangedEvent1(object sender, EventArgs e)
        {
            int cpos = grid1.Selection.ActivePosition.Column;
            int rpos = grid1.Selection.ActivePosition.Row;

            if(grid1[rpos, cpos].Value.Equals(true))
            {
                string str = grid1[rpos, cpos + 2].Value.ToString();
                codeList.Add(grid1[rpos, cpos + 2].Value.ToString());
            }

            if(grid1[rpos, cpos].Value.Equals(false))
            {
                string str = grid1[rpos, cpos + 2].Value.ToString();
                codeList.Remove(grid1[rpos, cpos + 2].Value.ToString());
            }
        }

        private void bConfirm_Click(object sender, EventArgs e)
        {
            //for(int i = 0; i < codeList.Count; i++)
            //{
            //    for(int j = 0; j< grid1.RowsCount; j++)
            //    {
            //        if(grid1[i,3].Value.ToString() == codeList[i])
            //        {
            //            package_sgroup += codeList[i];
            //            continue;
            //        }

            //        if (grid1[i, 11] != null)
            //        {
            //            if (grid1[i, 11].Value.ToString() == codeList[i])
            //            {
            //                package_sgroup += codeList[i];
            //            }
            //        }
            //    }
            //}
            int count = codeList.Count;

            for (int i = 0; i < tempGrid.RowsCount; i++)
            {
                if (count != 0)
                {
                    for (int j = 0; j < codeList.Count; j++)
                    {
                        if (tempGrid[i, 0].Value.ToString() == codeList[j])
                        {
                            package_sgroup += codeList[j];
                            count--;
                            break;
                        }
                    }

                    for (int j = 0; j < codeList.Count; j++)
                    {
                        if (tempGrid[i, 1].Value.ToString() == codeList[j])
                        {
                            package_sgroup += codeList[j];
                            count--;
                            break;
                        }
                    }
                }
            }

            //for (int i = 0; i < codeList.Count; i++)
            //{
            //    package_sgroup += codeList[i];
            //}

            mom_tb.Text = package_sgroup;
            mom_tb.Refresh();
            this.Close();
        }

        private void grid1_DoubleClick(object sender, EventArgs e)
        {
            

        }

        private void grid1_MouseClick(object sender, MouseEventArgs e)
        {
            Rect ChkArea1 = new Rect();
            ChkArea1.Top = 0;
            ChkArea1.Left = 0;

            ChkArea1.Bottom = GridHandle.grid.Rows[0].Height;
            ChkArea1.Right = 22;

            Rect ChkArea2 = new Rect();
            ChkArea2.Top = 0;
            ChkArea2.Left = grid1.Columns[1].Width + grid1.Columns[2].Width + grid1.Columns[3].Width + grid1.Columns[4].Width + grid1.Columns[5].Width;
            ChkArea2.Left += grid1.Columns[6].Width + grid1.Columns[7].Width;

            ChkArea2.Bottom = GridHandle.grid.Rows[0].Height;
            ChkArea2.Right = ChkArea2.Left + 22;

            int m_x = e.X;
            int m_y = e.Y;

            if (m_x > ChkArea1.Left && m_x < ChkArea1.Right && m_y > ChkArea1.Top && m_y < ChkArea1.Bottom)  // chk 컬럼 클릭
            {
                if (Chk_sgroup_1 == false)
                {
                    Chk_sgroup_1 = true;
                    GridHandle.ChkCheckAll(1);
                }
                else
                {
                    Chk_sgroup_1 = false;
                    GridHandle.ChkCancel(1);
                }
            }
            else if (m_x > ChkArea2.Left && m_x < ChkArea2.Right && m_y > ChkArea2.Top && m_y < ChkArea2.Bottom)  // chk 컬럼 클릭
            {
                if (Chk_sgroup_2 == false)
                {
                    Chk_sgroup_2 = true;
                    GridHandle.ChkCheckAll(9);
                }
                else
                {
                    Chk_sgroup_2 = false;
                    GridHandle.ChkCancel(9);
                }
            }
        }

        private void grid1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            int rpos = grid1.Selection.ActivePosition.Row;
            int cpos = grid1.Selection.ActivePosition.Column;

            if (e.Y < grid1.Rows[0].Height)
                return;

            if (rpos < 0)
                return;

            if (cpos >= 0 && cpos <= 7)
                package_sgroup = grid1[rpos, 3].ToString();
            else if (cpos >= 8 && cpos <= 15)
                package_sgroup = grid1[rpos, 11].ToString();

            mom_tb.Text = package_sgroup;
            mom_tb.Refresh();
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Grid_View();
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsDigit(e.KeyChar) || e.KeyChar == Convert.ToChar(Keys.Back)))
                e.Handled = true;
        }

        private void textBox2_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsDigit(e.KeyChar) || e.KeyChar == Convert.ToChar(Keys.Back)))
                e.Handled = true;
        }
    }
}
