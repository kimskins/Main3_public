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
    public partial class Form_memo_d : Form
    {
        public string mtext1 = "";
        public string mtext2 = "";
        string int_no = "";

        public Form_memo_d(string mm1,string mm2, string mm3)
        {
            InitializeComponent();
            mtext1 = richTextBox1.Text = mm2;
            mtext2 = richTextBox2.Text = mm3;
            int_no = mm1;                //항목별 연결번호
        }

        private void Form_memo_d_Load(object sender, EventArgs e)
        {
            select_2();
        }

        private void button1_Click(object sender, EventArgs e)  //저장
        {
            string cQuery = "";
            //
            var DBConn = new MySqlConnection(Config.DB_con1);
            DBConn.Open();
            //
            cQuery = " update C_dtable set memo1='" + richTextBox1.Text.Trim() + "' where row_id='" + int_no + "'";
            //
            var cmd = new MySqlCommand(cQuery, DBConn);
            if (cmd.ExecuteNonQuery() == 0)
                MessageBox.Show("DB 서버 오류 입니다.");
            else
                MessageBox.Show("메모 저장 하였습니다.");
            //
            mtext1 = richTextBox1.Text.Trim();
            DBConn.Close();
            //DBConn.Close();
            //this.DialogResult = DialogResult.OK;
        }

        private void select_2()
        {
            cell_d cc = new cell_d();
            //
            SourceGrid.Cells.Controllers.CustomEvents val_c2 = new SourceGrid.Cells.Controllers.CustomEvents();
            val_c2.ValueChanged += new EventHandler(ValueChangedEvent2);
            //
            SourceGrid.Cells.Controllers.CustomEvents doubleClickEvent2 = new SourceGrid.Cells.Controllers.CustomEvents();
            doubleClickEvent2.DoubleClick += new EventHandler(doubleClicked2);
            //  
            grid2.Rows.Clear();
            grid2.BorderStyle = BorderStyle.FixedSingle;
            grid2.SelectionMode = SourceGrid.GridSelectionMode.Cell;
            grid2.ColumnsCount = 5;
            grid2.FixedRows = 1;
            grid2.Rows.Insert(0);
            grid2.Rows[0].Height = 26;
            //
            grid2[0, 0] = new MyHeader1("row_id");
            grid2.Columns[0].Visible = false;
            grid2[0, 1] = new MyHeader1("√");
            grid2[0, 2] = new MyHeader1("No");
            grid2[0, 3] = new MyHeader1("항     목");
            grid2[0, 4] = new MyHeader1("공           식");
            //
            grid2.Columns[0].Width = 100; //row_id
            grid2.Columns[1].Width = 22;  //√
            grid2.Columns[2].Width = 30;  //No
            grid2.Columns[3].Width = 90; //항목
            grid2.Columns[4].Width = 436; //공식
            //
            var DBConn = new MySqlConnection(Config.DB_con1);
            DBConn.Open();
            string cQuery = "select * FROM C_dtable_cal where int_id='" + int_no + "'";
            var cmd = new MySqlCommand(cQuery, DBConn);
            var myRead = cmd.ExecuteReader();
            // 
            int m = 1;
            while (myRead.Read())
            {
                grid2.Rows.Insert(m);
                grid2.Rows[m].Height = 22;
                //
                grid2[m, 0] = new SourceGrid.Cells.Cell(myRead["row_id"], typeof(string));
                grid2[m, 1] = new SourceGrid.Cells.CheckBox(null, false);
                grid2[m, 2] = new SourceGrid.Cells.Cell((m).ToString(), typeof(string));
                grid2[m, 2].View = cc.center_cell;
                grid2[m, 2].Editor = cc.disable_cell;

                grid2[m, 3] = new SourceGrid.Cells.Cell(myRead["hang_mok"].ToString(), typeof(string));
                grid2[m, 3].View = cc.center_cellb;
                grid2[m, 3].Editor = cc.disable_cell;
                grid2[m, 3].AddController(doubleClickEvent2);
 
                grid2[m, 4] = new SourceGrid.Cells.Cell(myRead["calculat_str"].ToString(), typeof(string));
                grid2[m, 4].View = cc.left_cell;
                grid2[m, 4].AddController(val_c2);
                m++;
            }
            myRead.Close();
            DBConn.Close();
        }

        private void ValueChangedEvent2(object sender, EventArgs e)  //Grid2에서 볼륨첸지
        {
            var DBConn = new MySqlConnection(Config.DB_con1);
            DBConn.Open();
            string cQuery = "";
            int pos = grid2.Selection.ActivePosition.Column;
            int row = grid2.Selection.ActivePosition.Row;
            string dat = grid2[row, pos].ToString().Trim();
            string row_no = grid2[row, 0].ToString().Trim(); //row_id
            //
            if (pos == 4)
                cQuery = " update C_dtable_cal set calculat_str='" + dat + "' where row_id='" + row_no + "'";

            else
                return;
            //
            if (cQuery != "")
            {
                var cmd = new MySqlCommand(cQuery, DBConn);
                if (cmd.ExecuteNonQuery() == 0)
                {
                    MessageBox.Show("DB 서버 오류 입니다.");
                    DBConn.Close();
                    return;
                }
            }
            DBConn.Close();
        }

        private void insert_2_Click(object sender, EventArgs e)  //추가
        {
            var DBConn = new MySqlConnection(Config.DB_con1);
            DBConn.Open();
            string cQuery = "insert into C_dtable_cal (int_id) ";
            cQuery += " values('" + int_no + "')";
            var cmd = new MySqlCommand(cQuery, DBConn);
            if (cmd.ExecuteNonQuery() == 0)
            {
                MessageBox.Show("DB 서버 오류 입니다.");
                DBConn.Close();
                return;
            }
            else
                select_2();
            // 
            DBConn.Close();
        }

        private void copy_2_Click(object sender, EventArgs e)  //복사
        {
            var DBConn = new MySqlConnection(Config.DB_con1);
            DBConn.Open();
            //
            if (MessageBox.Show("선택하신 항목을 복사합니까 ?", "항목 복사", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                for (int i = 0; i < grid2.RowsCount; i++)
                {
                    if (grid2[i, 1].Value.Equals(true))
                    {
                        string row_no = grid2[i, 0].Value.ToString().Trim();        //row_id
                        string cQuery = "insert into C_dtable_cal (int_id,hang_mok,calculat_str) ";
                        cQuery += " select int_id,hang_mok,calculat_str from C_dtable_cal where row_id='" + row_no + "'";
                        var cmd = new MySqlCommand(cQuery, DBConn);
                        if (cmd.ExecuteNonQuery() == 0)
                        {
                            MessageBox.Show("DB 서버 오류 입니다.");
                            DBConn.Close();
                            return;
                        }
                    }
                }
                DBConn.Close();
                select_2();
            }
        }

        private void delete_2_Click(object sender, EventArgs e)  //삭제
        {
            var DBConn = new MySqlConnection(Config.DB_con1);
            DBConn.Open();
            //
            if (MessageBox.Show("선택하신 항목을 삭제합니까 ?", "항목 삭제", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                string[] sd = new string[grid2.RowsCount];//
                for (int i = 0; i < sd.Length; i++)  //배열
                    sd[i] = "0";
                //
                int s = 0;
                for (int i = 0; i < grid2.RowsCount; i++)
                {
                    if (grid2[i, 1].Value.Equals(true))
                    {
                        sd[s] = grid2[i, 0].Value.ToString().Trim();           //row_id
                        s++;
                    }
                }
                //
                for (int i = 0; i < sd.Length; i++)  //배열
                {
                    if (sd[i].Equals("0"))
                        break;
                    else
                    {
                        string row_no = sd[i];
                        string cQuery = " delete from C_dtable_cal where row_id='" + row_no + "'";
                        var cmd = new MySqlCommand(cQuery, DBConn);
                        if (cmd.ExecuteNonQuery() == 0)
                        {
                            MessageBox.Show("서버 자료 삭제에 실패 했습니다.");
                            break;
                        }
                    }
                }
                //
                for (int i = 0; i < sd.Length; i++)
                {
                    if (sd[i].Equals("0"))
                        break;
                    else
                    {
                        for (s = 0; s < grid2.RowsCount; s++)
                        {
                            if (grid2[i, 0].Value.Equals(sd[i]))
                            {
                                grid2.Rows.Remove(s);
                            }
                        }
                    }
                }
                DBConn.Close();
                select_2();
            }
        }

        private void doubleClicked2(object sender, EventArgs e)  //Grid2에서 더블클릭시
        {
            int cpos = grid2.Selection.ActivePosition.Column;
            if (cpos.Equals(3))
            {
                var contextMenu = new ContextMenuStrip();
                contextMenu.Items.Add("기본단가".ToString());
                contextMenu.Items.Add("p단가".ToString());
                contextMenu.Items.Add("단가".ToString());
                contextMenu.Items.Add("기본금액".ToString());
                contextMenu.Items.Add("금액".ToString());
                contextMenu.Items.Add("기초금액".ToString());
                contextMenu.Items.Add("수량".ToString());
                contextMenu.Items.Add("적요".ToString());
                contextMenu.Items.Add("품목통수".ToString());
                contextMenu.Items.Add("부수".ToString());
                contextMenu.Items.Add("세팅단가".ToString());

                var rect = grid2.RangeToRectangle(new SourceGrid.Range(grid2.Selection.ActivePosition));
                Point pp = new Point(rect.Location.X, rect.Location.Y + rect.Height);
                rect.Location = pp;
                contextMenu.Show(grid2, rect.Location);
                contextMenu.ItemClicked += new ToolStripItemClickedEventHandler(menu_ItemClicked); //추가
            }
        }

        private void menu_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            if (!string.IsNullOrEmpty(e.ClickedItem.Text))
            {
                cell_d cc = new cell_d();
                SourceGrid.Cells.Controllers.CustomEvents doubleClickEvent2 = new SourceGrid.Cells.Controllers.CustomEvents();
                doubleClickEvent2.DoubleClick += new EventHandler(doubleClicked2);
                //
                string row_no = grid2[grid2.Selection.ActivePosition.Row, 0].Value.ToString(); //row_id
                string dat = e.ClickedItem.Text; //인쇄명
                //
                var DBConn = new MySqlConnection(Config.DB_con1);
                DBConn.Open();
                string cQuery = " update C_dtable_cal set hang_mok='" + dat + "' where row_id='" + row_no + "'";
                var cmd = new MySqlCommand(cQuery, DBConn);
                if (cmd.ExecuteNonQuery() == 0)
                    MessageBox.Show("서버 자료 수정에 실패 했습니다.");
                DBConn.Close();
                grid2[grid2.Selection.ActivePosition.Row, 3] = new SourceGrid.Cells.Cell(dat, typeof(string));  //
                grid2[grid2.Selection.ActivePosition.Row, 3].View = cc.center_cellb;
                grid2[grid2.Selection.ActivePosition.Row, 3].Editor = cc.disable_cell;
                grid2[grid2.Selection.ActivePosition.Row, 3].AddController(doubleClickEvent2);
                //
                grid2.Focus();
                grid2.Refresh();
                DBConn.Close();
            }
        }

        private void bSaveHang_Click(object sender, EventArgs e)
        {
            string cQuery = "";
            //
            var DBConn = new MySqlConnection(Config.DB_con1);
            DBConn.Open();
            //
            cQuery = " update C_dtable set memo2='" + richTextBox2.Text.Trim() + "' where row_id='" + int_no + "'";
            //
            var cmd = new MySqlCommand(cQuery, DBConn);
            if (cmd.ExecuteNonQuery() == 0)
                MessageBox.Show("DB 서버 오류 입니다.");
            else
                MessageBox.Show("메모 저장 하였습니다.");
            //
            mtext2 = richTextBox2.Text.Trim();
            DBConn.Close();
            //this.DialogResult = DialogResult.OK;
        }

    }
}
