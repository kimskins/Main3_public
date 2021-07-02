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
    public partial class Form_2111 : Form
    {
        string act_id = "1";  //검색조건(래디오 버튼에 따라 선택됨) 
        string DB_TableName = "C_size_type";
        public Form_2111()
        {
            InitializeComponent();
        }

        private void Form_211_Load(object sender, EventArgs e)
        {
            Screen srn = Screen.PrimaryScreen;
            int Xb = this.Width;  //좌,우
            this.Location = new Point((srn.Bounds.Width - Xb) / 2, 1);  //좌/우,위/아래
            radioButton1.Checked = true;
            select1();
            select2();
        }

        private void radioButton1_Click(object sender, EventArgs e)  //도큐싸이즈 선택
        {
            act_id = "1";
            select1();
            select2();
        }

        private void radioButton2_Click(object sender, EventArgs e)  //인쇄싸이즈 선택
        {
            act_id = "2";
            select1();
            select2();
        }

        private void radioButton3_Click(object sender, EventArgs e)  //종이싸이즈 선택
        {
            act_id = "3";
            select1();
            select2();
        }

        private void select1()  //그리드 검색
        {
            cell_d cc = new cell_d();
            SourceGrid.Cells.Controllers.CustomEvents valueChanged1 = new SourceGrid.Cells.Controllers.CustomEvents();
            valueChanged1.ValueChanged += new EventHandler(ValueChanged1);
            grid1.Controller.AddController(valueChanged1);
            //           
            grid1.Rows.Clear();
            grid1.ColumnsCount = 6;
            grid1.VScrollBar.Visible = true;

            grid1.FixedRows = 1;
            grid1.Rows.Insert(0);
            grid1.Rows[0].Height = 28;
            //
            grid1[0, 0] = new MyHeader1("√");
            grid1[0, 1] = new MyHeader1("판형");
            grid1[0, 2] = new MyHeader1("절수");
            grid1[0, 3] = new MyHeader1("크기(mm)");
            grid1[0, 4] = new MyHeader1("참  고");
            grid1[0, 5] = new MyHeader1("Row");
            grid1.Columns[5].Visible = false;
            //
            grid1.Columns[0].Width = 22;
            grid1.Columns[1].Width = 34;
            grid1.Columns[2].Width = 34;
            grid1.Columns[3].Width = 66;
            grid1.Columns[4].Width = 66;
            grid1.Columns[5].Width = 100;
            //

            //
            var DBConn = new MySqlConnection(Config.DB_con1);
            DBConn.Open();
            //
            string cQuery = "select * FROM " + DB_TableName + " where mast_id='" + act_id + "' and pan_type='46'";
            cQuery += " order by julsu";
            var cmd = new MySqlCommand(cQuery, DBConn);
            var myRead = cmd.ExecuteReader();
            int m = 1;
            while (myRead.Read())
            {
                grid1.Rows.Insert(m);
                grid1.Rows[m].Height = 22;
                //
                grid1[m, 0] = new SourceGrid.Cells.CheckBox(null, false);
                grid1[m, 1] = new SourceGrid.Cells.Cell(myRead["pan_type"].ToString(), typeof(string));    //판형
                grid1[m, 1].View = cc.center_cell;
                grid1[m, 2] = new SourceGrid.Cells.Cell(myRead["julsu"].ToString(), typeof(string));       //절수
                grid1[m, 2].View = cc.center_cell;
                grid1[m, 3] = new SourceGrid.Cells.Cell(myRead["size"].ToString(), typeof(string));        //싸이즈
                grid1[m, 3].View = cc.center_cell;
                grid1[m, 4] = new SourceGrid.Cells.Cell(myRead["remark"].ToString(), typeof(string));      //참고
                grid1[m, 4].View = cc.left_cell;
                grid1[m, 5] = new SourceGrid.Cells.Cell(myRead["row_id"].ToString(), typeof(string));      //row_id

                m++;
            }
            myRead.Close();
            DBConn.Close();
        }

        private void select2()  //그리드 검색
        {
            cell_d cc = new cell_d();

            SourceGrid.Cells.Controllers.CustomEvents valueChanged2 = new SourceGrid.Cells.Controllers.CustomEvents();
            valueChanged2.ValueChanged += new EventHandler(ValueChanged2);
            grid2.Controller.AddController(valueChanged2);
           
            grid2.Rows.Clear();
            grid2.ColumnsCount = 6;
            grid2.VScrollBar.Visible = true;

            grid2.FixedRows = 1;
            grid2.Rows.Insert(0);
            grid2.Rows[0].Height = 28;
            //
            grid2[0, 0] = new MyHeader1("√");
            grid2[0, 1] = new MyHeader1("판형");
            grid2[0, 2] = new MyHeader1("절수");
            grid2[0, 3] = new MyHeader1("크기(mm)");
            grid2[0, 4] = new MyHeader1("참  고");
            grid2[0, 5] = new MyHeader1("Row");
            grid2.Columns[5].Visible = false;
            //
            grid2.Columns[0].Width = 22;
            grid2.Columns[1].Width = 34;
            grid2.Columns[2].Width = 34;
            grid2.Columns[3].Width = 66;
            grid2.Columns[4].Width = 66;
            grid2.Columns[5].Width = 100;
            //
            var DBConn = new MySqlConnection(Config.DB_con1);
            DBConn.Open();
            //
            string cQuery = "select * FROM " + DB_TableName + " where mast_id='" + act_id + "' and pan_type='국'";
            cQuery += " order by julsu";
            var cmd = new MySqlCommand(cQuery, DBConn);
            var myRead = cmd.ExecuteReader();
            int m = 1;
            while (myRead.Read())
            {

                grid2.Rows.Insert(m);
                grid2.Rows[m].Height = 22;
                //
                grid2[m, 0] = new SourceGrid.Cells.CheckBox(null, false);
                grid2[m, 1] = new SourceGrid.Cells.Cell(myRead["pan_type"].ToString(), typeof(string));    //판형
                grid2[m, 1].View = cc.center_cell;
                grid2[m, 2] = new SourceGrid.Cells.Cell(myRead["julsu"].ToString(), typeof(string));       //절수
                grid2[m, 2].View = cc.center_cell;
                grid2[m, 3] = new SourceGrid.Cells.Cell(myRead["size"].ToString(), typeof(string));        //싸이즈
                grid2[m, 3].View = cc.center_cell;
                grid2[m, 4] = new SourceGrid.Cells.Cell(myRead["remark"].ToString(), typeof(string));      //참고
                grid2[m, 4].View = cc.left_cell;
                grid2[m, 5] = new SourceGrid.Cells.Cell(myRead["row_id"].ToString(), typeof(string));      //row_id
                m++;
            }
            myRead.Close();
            DBConn.Close();
        }

        private void ValueChanged1(object sender, EventArgs e)  //수정
        {
            int colp = grid1.Selection.ActivePosition.Column;  //컬럼위치
            string cQuery = "";
            string row_no = grid1[grid1.Selection.ActivePosition.Row, 5].ToString().Trim();
            string dat = grid1[grid1.Selection.ActivePosition.Row, grid1.Selection.ActivePosition.Column].ToString().Trim();
            //
            if (colp == 1)
                cQuery = " update " + DB_TableName + " set pan_type='" + dat + "' where row_id='" + row_no + "'";
            else if (colp == 2)
                cQuery = " update " + DB_TableName + " set julsu='" + dat + "' where row_id='" + row_no + "'";
            else if (colp == 3)
                cQuery = " update " + DB_TableName + " set size='" + dat + "' where row_id='" + row_no + "'";
            else if (colp == 4)
                cQuery = " update " + DB_TableName + " set remark='" + dat + "' where row_id='" + row_no + "'";
            else
                return;
            // 
            var DBConn = new MySqlConnection(Config.DB_con1);
            DBConn.Open();
            var cmd = new MySqlCommand(cQuery, DBConn);
            if (cmd.ExecuteNonQuery() == 0)
                MessageBox.Show("서버 자료 수정에 실패 했습니다.");
            DBConn.Close();
        }


        private void ValueChanged2(object sender, EventArgs e)  //수정
        {
            int colp = grid2.Selection.ActivePosition.Column;  //컬럼위치
            string cQuery = "";
            string row_no = grid2[grid2.Selection.ActivePosition.Row, 5].ToString().Trim();
            string dat = grid2[grid2.Selection.ActivePosition.Row, grid2.Selection.ActivePosition.Column].ToString().Trim();
            //
            if (colp == 1)
                cQuery = " update " + DB_TableName + " set pan_type='" + dat + "' where row_id='" + row_no + "'";
            else if (colp == 2)
                cQuery = " update " + DB_TableName + " set julsu='" + dat + "' where row_id='" + row_no + "'";
            else if (colp == 3)
                cQuery = " update " + DB_TableName + " set size='" + dat + "' where row_id='" + row_no + "'";
            else if (colp == 4)
                cQuery = " update " + DB_TableName + " set remark='" + dat + "' where row_id='" + row_no + "'";
            else
                return;
            //
            var DBConn = new MySqlConnection(Config.DB_con1);
            DBConn.Open();
            var cmd = new MySqlCommand(cQuery, DBConn);
            if (cmd.ExecuteNonQuery() == 0)
                MessageBox.Show("서버 자료 수정에 실패 했습니다.");
            DBConn.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            select1();
            select2();
        }

        private void bAdd46_Click(object sender, EventArgs e)
        {
            ksgcontrol kc = new ksgcontrol();
            kc.ControlInit(Config.DB_con1, "", "", "");

            string cQuery = "insert into " + DB_TableName + " (mast_id, pan_type) values('" + act_id + "', '46')";
            kc.DataUpdate(cQuery);
            select1();

        }

        private void bAddKook_Click(object sender, EventArgs e)
        {
            ksgcontrol kc = new ksgcontrol();
            kc.ControlInit(Config.DB_con1, "", "", "");

            string cQuery = "insert into " + DB_TableName + " (mast_id, pan_type) values('" + act_id + "', '국')";
            kc.DataUpdate(cQuery);
            select2();
        }

        private void bDel_Click(object sender, EventArgs e)
        {
            ksgcontrol kc = new ksgcontrol();
            kc.ControlInit(Config.DB_con1, "", "", "");
            string cQuery = "";
            for (int i = 1; i < grid1.RowsCount; i++)
            {
                if (grid1[i, 0].Value.Equals(true))
                {
                    cQuery = "delete from " + DB_TableName + " where row_id='" + grid1[i, 5].ToString().Trim()+"'";
                    kc.DataUpdate(cQuery);
                }
            }
            for (int i = 1; i < grid2.RowsCount; i++)
            {
                if (grid2[i, 0].Value.Equals(true))
                {
                    cQuery = "delete from " + DB_TableName + " where row_id='" + grid2[i, 5].ToString().Trim()+"'";
                    kc.DataUpdate(cQuery);
                }
            }
            select1();
            select2();
        }
    }
}
