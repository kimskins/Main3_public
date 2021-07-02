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
    public partial class Form_501d : Form
    {
        SourceGridControl GridHandle = new SourceGridControl();
        cell_d cc = new cell_d();
        string DB_TableName_hang = "hang_manage";

        public string package_group = "";
        public string manage_row_id = "";
        public string manage_sangho = "";
        TextBox mom_tb;
        string key_word;
        string cQuery = "";
        int x;
        int y;

        public Form_501d(TextBox tb, string key_word, string cQuery, int x, int y )
        {
            InitializeComponent();
            mom_tb = tb;
            this.key_word = key_word;
            this.cQuery = cQuery;
            this.x = x;
            this.y = y;
        }

        private void Form_502d_Load(object sender, EventArgs e)
        {
            Screen srn = Screen.PrimaryScreen;
            int Xb = this.Width;  //좌,우
            int Yb = this.Height; //좌,우
            //this.Location = new Point((srn.Bounds.Width - Xb) / 2, (srn.Bounds.Height - Yb) / 2 - 100);  //좌/우,위/아래
            this.Location = new Point(x,y);  //좌/우,위/아래
            GridHandle.SourceGrideInit(grid1, Config.DB_con1);
            if (key_word == "manage")
                grid_manage();

            else
            {
                Grid_View();
                bDel.Visible = false;
            }
        }
        private void grid_manage()
        {
            grid1.Rows.Clear();
            grid1.BorderStyle = BorderStyle.FixedSingle;
            grid1.SelectionMode = SourceGrid.GridSelectionMode.Cell;
            grid1.ColumnsCount = 4;
            grid1.FixedRows = 1;
            grid1.Rows.Insert(0);
            grid1.Rows[0].Height = 24;
            //
            grid1[0, 0] = new MyHeader1("row_id");
            grid1.Columns[0].Visible = false;

            grid1[0, 1] = new MyHeader1("√");
            grid1[0, 2] = new MyHeader1("No");
            grid1[0, 3] = new MyHeader1("상호");

            grid1.Columns[1].Width = 22;
            grid1.Columns[2].Width = 30;
            grid1.Columns[3].Width = 240;

            //
            MySqlConnection DBConn;

            DBConn = new MySqlConnection(Config.DB_con1);
            DBConn.Open();

            var cmd = new MySqlCommand(cQuery, DBConn);
            var myRead = cmd.ExecuteReader();

            // 
            int m = 1;
            while (myRead.Read())
            {
                grid1.Rows.Insert(m);
                grid1.Rows[m].Height = 22;
                //
                grid1[m, 0] = new SourceGrid.Cells.Cell(myRead["row_id"], typeof(string));
                grid1[m, 1] = new SourceGrid.Cells.CheckBox(null, false);

                grid1[m, 2] = new SourceGrid.Cells.Cell(m.ToString(), typeof(string));
                grid1[m, 2].View = cc.center_cell;
                grid1[m, 2].Editor = cc.disable_cell;

                grid1[m, 3] = new SourceGrid.Cells.Cell(myRead["sangho"], typeof(string));
                grid1[m, 3].View = cc.center_cell;
                grid1[m, 3].Editor = cc.disable_cell;


                m++;
            }
            myRead.Close();
            DBConn.Close();
        }
        private void Grid_View()
        {
            // 
            grid1.Rows.Clear();
            grid1.BorderStyle = BorderStyle.FixedSingle;
            grid1.SelectionMode = SourceGrid.GridSelectionMode.Cell;
            grid1.ColumnsCount = 5;
            grid1.FixedRows = 1;
            grid1.Rows.Insert(0);
            grid1.Rows[0].Height = 24;
            //
            grid1[0, 0] = new MyHeader1("row_id");
            grid1.Columns[0].Visible = false;

            grid1[0, 1] = new MyHeader1("√");
            grid1[0, 2] = new MyHeader1("No");
            grid1[0, 3] = new MyHeader1("코드");
            grid1[0, 4] = new MyHeader1(key_word);

            grid1.Columns[1].Width = 22;
            grid1.Columns[2].Width = 30;
            grid1.Columns[3].Width = 40;
            grid1.Columns[4].Width = 200;
            
            //
            MySqlConnection DBConn;

            DBConn = new MySqlConnection(Config.DB_con1);
            DBConn.Open();

            var cmd = new MySqlCommand(cQuery, DBConn);
            var myRead = cmd.ExecuteReader();

            // 
            int m = 1;
            while (myRead.Read())
            {
                grid1.Rows.Insert(m);
                grid1.Rows[m].Height = 22;
                //
                grid1[m, 0] = new SourceGrid.Cells.Cell(myRead["row_id"], typeof(string));
                if (mom_tb.Text.IndexOf(myRead["code1"].ToString()) >= 0)
                    grid1[m, 1] = new SourceGrid.Cells.CheckBox(null, true);
                else
                    grid1[m, 1] = new SourceGrid.Cells.CheckBox(null, false);

                grid1[m, 2] = new SourceGrid.Cells.Cell(m.ToString(), typeof(string));
                grid1[m, 2].View = cc.center_cell;
                grid1[m, 2].Editor = cc.disable_cell;

                grid1[m, 3] = new SourceGrid.Cells.Cell(myRead["code1"], typeof(string));
                grid1[m, 3].View = cc.center_cell;
                grid1[m, 3].Editor = cc.disable_cell;

                grid1[m, 4] = new SourceGrid.Cells.Cell(myRead["hang"], typeof(string));
                grid1[m, 4].View = cc.center_cell;

                m++;
            }
            myRead.Close();
            DBConn.Close();
        }

        private void bConfirm_Click(object sender, EventArgs e)
        {
            if (key_word == "manage")
            {
                if (MessageBox.Show("적용 하시겠습니까?", "메세지창", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    for (int i = 1; i < grid1.RowsCount; i++)
                    {
                        if (grid1[i, 1].Value.Equals(true))
                        {
                            manage_row_id = grid1[i, 0].ToString();
                            manage_sangho = grid1[i, 3].ToString();
                            this.DialogResult = DialogResult.OK;
                            break;
                        }
                    }
                }
            }
            else
            {
                string gubun = "";
                if (key_word == "지업사")
                    gubun = "#";
                for (int i = 1; i < grid1.RowsCount; i++)
                {
                    if (grid1[i, 1].Value.Equals(true))
                    {
                        package_group += gubun + grid1[i, 3].ToString();
                    }
                }

                if (key_word == "지업사" && package_group.Length > 0)
                    package_group = package_group.Substring(1);     // 지업사일경우 맨 앞에 오는 #을 빼기위해 수행

                mom_tb.Text = package_group;
                mom_tb.Refresh();
            }
            this.Close();
        }

        private void grid1_DoubleClick(object sender, EventArgs e)
        {
            int rpos = grid1.Selection.ActivePosition.Row;
            int cpos = grid1.Selection.ActivePosition.Column;

            if (rpos < 0)
                return;
            if (key_word != "manage")
            {
                package_group = grid1[rpos, 3].ToString();

                mom_tb.Text = package_group;
                mom_tb.Refresh();
                this.Close();
            }
        }

        private void grid1_MouseClick(object sender, MouseEventArgs e)
        {
            int row = grid1.Selection.ActivePosition.Row;
            if (row == -1)
                return;

            if(key_word == "manage")
                GridHandle.OnlyOneChk(1, row, 1);
        }

        private void bDel_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("제거 하시겠습니까?", "메세지창", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                manage_row_id = "-1";
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
        }
    }
}
