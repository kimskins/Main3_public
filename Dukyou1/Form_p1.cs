using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using SourceGrid;

namespace Dukyou3
{
    public partial class Form_p1 : Form
    {
        SourceGrid.Cells.Views.Cell center_cell;  //중앙셀
        SourceGrid.Cells.Views.Cell center_cellr; //중앙셀
        SourceGrid.Cells.Views.Cell center_cellb; //중앙셀
        SourceGrid.Cells.Views.Cell left_cell;    //좌측셀
        SourceGrid.Cells.Views.Cell left_cellr;   //좌측셀
        SourceGrid.Cells.Views.Cell left_cellb;   //좌측셀
        SourceGrid.Cells.Views.Cell int_cell;     //우측셀
        SourceGrid.Cells.Editors.TextBox disable_cell; //수정불가

        SourceGrid.Cells.Controllers.CustomEvents val_c3;


        public Form_p1()
        {
            center_cell = new SourceGrid.Cells.Views.Cell();
            center_cell.TextAlignment = DevAge.Drawing.ContentAlignment.MiddleCenter;
            center_cellr = new SourceGrid.Cells.Views.Cell();
            center_cellr.TextAlignment = DevAge.Drawing.ContentAlignment.MiddleCenter;
            center_cellr.BackColor = Color.FromArgb(255, 250, 250);
            center_cellb = new SourceGrid.Cells.Views.Cell();
            center_cellb.TextAlignment = DevAge.Drawing.ContentAlignment.MiddleCenter;
            center_cellb.BackColor = Color.FromArgb(240, 248, 255);
            //
            left_cell = new SourceGrid.Cells.Views.Cell();
            left_cell.TextAlignment = DevAge.Drawing.ContentAlignment.MiddleLeft;
            left_cellr = new SourceGrid.Cells.Views.Cell();
            left_cellr.TextAlignment = DevAge.Drawing.ContentAlignment.MiddleLeft;
            left_cellr.BackColor = Color.FromArgb(255, 250, 250);
            left_cellb = new SourceGrid.Cells.Views.Cell();
            left_cellb.TextAlignment = DevAge.Drawing.ContentAlignment.MiddleLeft;
            left_cellb.BackColor = Color.FromArgb(240, 248, 255);
            //
            int_cell = new SourceGrid.Cells.Views.Cell();
            int_cell.TextAlignment = DevAge.Drawing.ContentAlignment.MiddleRight;
            //
            disable_cell = new SourceGrid.Cells.Editors.TextBox(typeof(string));  //수정불가
            disable_cell.EnableEdit = false;
            //
            InitializeComponent();
        }

        private void Form_p1_Load(object sender, EventArgs e)
        {
            Screen srn = Screen.PrimaryScreen;
            int Xb = this.Width;  //좌,우
            this.Location = new Point((srn.Bounds.Width - Xb) / 2, 1);  //좌/우,위/아래
            //
            select_1();
            select_2("");
            select_3("");
        }

        private void select_1()  //Grid1
        {
            SourceGrid.Cells.Controllers.CustomEvents clickEventd1 = new SourceGrid.Cells.Controllers.CustomEvents();
            clickEventd1.DoubleClick += new EventHandler(clickEvent_Clickd1);
            // 
            grid1.Rows.Clear();
            grid1.BorderStyle = BorderStyle.FixedSingle;
            grid1.SelectionMode = SourceGrid.GridSelectionMode.Cell;
            grid1.ColumnsCount = 4;
            grid1.FixedRows = 1;
            grid1.Rows.Insert(0);
            grid1.Rows[0].Height = 30;
            //
            grid1[0, 0] = new MyHeader1("row_id");
            grid1.Columns[0].Visible = false;
            grid1[0, 1] = new MyHeader1("No");
            grid1[0, 2] = new MyHeader1("대  분  류");
            grid1[0, 3] = new MyHeader1("a_code");
            grid1.Columns[3].Visible = false;
            //
            grid1.Columns[0].Width = 100;
            grid1.Columns[1].Width = 30;
            grid1.Columns[2].Width = 120;
            grid1.Columns[3].Width = 120;
            //
            var DBConn = new MySqlConnection(Config.DB_con1);
            DBConn.Open();
            string cQuery = " select * FROM C_amodel order by s_no";
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
                grid1[m, 1] = new SourceGrid.Cells.Cell(m.ToString(), typeof(string));
                grid1[m, 1].View = center_cell;
                grid1[m, 1].Editor = disable_cell;
                grid1[m, 2] = new SourceGrid.Cells.Cell(myRead["aitem"].ToString(), typeof(string));
                grid1[m, 2].View = left_cellb;
                grid1[m, 2].Editor = disable_cell;
                grid1[m, 2].AddController(clickEventd1);
                grid1[m, 3] = new SourceGrid.Cells.Cell(myRead["a_code"].ToString(), typeof(string));
                m++;
            }
            myRead.Close();
            DBConn.Close();
        }

        private void select_2(string ss)  //Grid2
        {
            SourceGrid.Cells.Controllers.CustomEvents clickEventd2 = new SourceGrid.Cells.Controllers.CustomEvents();
            clickEventd2.DoubleClick += new EventHandler(clickEvent_Clickd2);
            // 
            grid2.Rows.Clear();
            grid2.BorderStyle = BorderStyle.FixedSingle;
            grid2.SelectionMode = SourceGrid.GridSelectionMode.Cell;
            grid2.ColumnsCount = 5;
            grid2.FixedRows = 1;
            grid2.Rows.Insert(0);
            grid2.Rows[0].Height = 30;
            //
            grid2[0, 0] = new MyHeader1("row_id");
            grid2.Columns[0].Visible = false;
            grid2[0, 1] = new MyHeader1("No");
            grid2[0, 2] = new MyHeader1("중  분  류");
            grid2[0, 3] = new MyHeader1("소분류");
            grid2[0, 4] = new MyHeader1("b_code");
            grid2.Columns[4].Visible = false;
            //
            grid2.Columns[0].Width = 100;
            grid2.Columns[1].Width = 30;
            grid2.Columns[2].Width = 120;
            grid2.Columns[3].Width = 50;
            grid2.Columns[4].Width = 100;
            //
            var DBConn = new MySqlConnection(Config.DB_con1);
            DBConn.Open();
            string cQuery = "";
            if (ss == "")
            {
                grid2.Rows.Insert(1);
                grid2.Rows[1].Height = 22;
                //
                grid2[1, 0] = new SourceGrid.Cells.Cell("", typeof(string));
                grid2[1, 1] = new SourceGrid.Cells.Cell("", typeof(string));
                grid2[1, 1].Editor = disable_cell;
                grid2[1, 2] = new SourceGrid.Cells.Cell("", typeof(string));
                grid2[1, 2].Editor = disable_cell;
                grid2[1, 3] = new SourceGrid.Cells.Cell("...", typeof(string));
                grid2[1, 3].Editor = disable_cell;
                grid2[1, 4] = new SourceGrid.Cells.Cell("", typeof(string));
            }
            else
            {
                cQuery = " select * FROM C_bmodel where a_code='" + ss + "' order by  b_code";
                //
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
                    grid2[m, 1] = new SourceGrid.Cells.Cell(m.ToString(), typeof(string));
                    grid2[m, 1].View = center_cell;
                    grid2[m, 1].Editor = disable_cell;
                    grid2[m, 2] = new SourceGrid.Cells.Cell(myRead["bitem"].ToString(), typeof(string));
                    grid2[m, 2].View = left_cellb;
                    grid2[m, 2].Editor = disable_cell;
                    grid2[m, 2].AddController(clickEventd2);
                    grid2[m, 3] = new SourceGrid.Cells.Cell("...", typeof(string));
                    grid2[m, 3].View = center_cellb;
                    grid2[m, 3].Editor = disable_cell;
                    grid2[m, 3].AddController(clickEventd2);
                    grid2[m, 4] = new SourceGrid.Cells.Cell(myRead["a_code"].ToString() + myRead["b_code"].ToString(), typeof(string));
                    m++;
                }
                myRead.Close();
            }
            DBConn.Close();
        }

        private void select_3(string ss)  //Grid3
        {
            val_c3 = new SourceGrid.Cells.Controllers.CustomEvents();
            SourceGrid.Cells.Controllers.CustomEvents clickEvent3 = new SourceGrid.Cells.Controllers.CustomEvents();
            SourceGrid.Cells.Controllers.CustomEvents clickEventd3 = new SourceGrid.Cells.Controllers.CustomEvents();
            val_c3.ValueChanged += new EventHandler(ValueChangedEvent3);
            clickEvent3.Click += new EventHandler(clickEvent_Click3);
            clickEventd3.DoubleClick += new EventHandler(clickEvent_Clickd3);
            grid3.Controller.AddController(val_c3);

            SourceGrid.Cells.Controllers.CustomEvents clickEventd1 = new SourceGrid.Cells.Controllers.CustomEvents();
            clickEventd1.DoubleClick += new EventHandler(clickEvent_Clickd1);
            // 
            grid3.Rows.Clear();
            grid3.BorderStyle = BorderStyle.FixedSingle;
            grid3.SelectionMode = SourceGrid.GridSelectionMode.Cell;
            grid3.ColumnsCount = 10;
            grid3.FixedRows = 1;
            grid3.Rows.Insert(0);
            grid3.Rows[0].Height = 30;
            //
            grid3[0, 0] = new MyHeader1("row_id");
            grid3.Columns[0].Visible = false;
            grid3[0, 1] = new MyHeader1("업 체 명");
            grid3[0, 2] = new MyHeader1("정보");
            grid3[0, 3] = new MyHeader1("기 계 정 보");
            grid3[0, 4] = new MyHeader1("유형");
            grid3[0, 5] = new MyHeader1("단가");
            grid3[0, 6] = new MyHeader1("작성일");
            grid3[0, 7] = new MyHeader1("√");
            grid3[0, 8] = new MyHeader1("승인일");
            grid3[0, 9] = new MyHeader1("int_id");
            grid3.Columns[9].Visible = false;
            //
            grid3.Columns[0].Width = 100;
            grid3.Columns[1].Width = 120;
            grid3.Columns[2].Width = 40;
            grid3.Columns[3].Width = 100;
            grid3.Columns[4].Width = 40;
            grid3.Columns[5].Width = 60;
            grid3.Columns[6].Width = 90;
            grid3.Columns[7].Width = 22;
            grid3.Columns[8].Width = 90;
            grid3.Columns[9].Width = 100;
            //
            if (ss == "")
            {
                grid3.Rows.Insert(1);
                grid3.Rows[1].Height = 22;
                //
                grid3[1, 0] = new SourceGrid.Cells.Cell("", typeof(string));
                grid3[1, 1] = new SourceGrid.Cells.Cell("", typeof(string));
                grid3[1, 1].Editor = disable_cell;
                grid3[1, 2] = new SourceGrid.Cells.Cell("", typeof(string));
                grid3[1, 2].Editor = disable_cell;
                grid3[1, 3] = new SourceGrid.Cells.Cell("", typeof(string));
                grid3[1, 3].Editor = disable_cell;
                grid3[1, 4] = new SourceGrid.Cells.Cell("", typeof(string));
                grid3[1, 4].Editor = disable_cell;
                grid3[1, 5] = new SourceGrid.Cells.Cell("", typeof(string));
                grid3[1, 5].Editor = disable_cell;
                grid3[1, 6] = new SourceGrid.Cells.Cell("", typeof(string));
                grid3[1, 6].Editor = disable_cell;
                grid3[1, 7] = new SourceGrid.Cells.Cell("", typeof(string));
                grid3[1, 7].Editor = disable_cell;
                grid3[1, 8] = new SourceGrid.Cells.Cell("", typeof(string));
                grid3[1, 8].Editor = disable_cell;
                grid3[1, 9] = new SourceGrid.Cells.Cell("", typeof(string));
            }
            else
            {
                var DBConn = new MySqlConnection(Config.DB_con1);
                DBConn.Open();
                string cQuery = " select row_id,int_id,g,d,f,e,danga,con_day1,con_day2,";
                cQuery += " (select sangho from C_hcustomer where row_id=a.int_id) as d1 from C_hmachin a ";
                cQuery += " where a.code_no = '" + ss + "'";
                var cmd = new MySqlCommand(cQuery, DBConn);
                var myRead = cmd.ExecuteReader();
                // 
                int m = 1;
                while (myRead.Read())
                {
                    grid3.Rows.Insert(m);
                    grid3.Rows[m].Height = 22;
                    //
                    grid3[m, 0] = new SourceGrid.Cells.Cell(myRead["row_id"], typeof(string));
                    grid3[m, 1] = new SourceGrid.Cells.Cell(myRead["d1"].ToString(), typeof(string));
                    grid3[m, 1].View = left_cell;
                    grid3[m, 1].Editor = disable_cell;

                    grid3[m, 2] = new SourceGrid.Cells.Cell("...", typeof(string));
                    grid3[m, 2].View = center_cellb;
                    grid3[m, 2].Editor = disable_cell;
                    grid3[m, 2].AddController(clickEventd3);

                    grid3[m, 3] = new SourceGrid.Cells.Cell(myRead["d"].ToString().Trim() + myRead["f"].ToString().Trim() + myRead["g"].ToString().Trim(),typeof(string)); //기계정보
                    grid3[m, 3].View = left_cell;
                    grid3[m, 3].Editor = disable_cell;

                    grid3[m, 4] = new SourceGrid.Cells.Cell(myRead["e"].ToString(), typeof(string));  //유형
                    grid3[m, 4].View = center_cell;
                    grid3[m, 4].Editor = disable_cell;

                    grid3[m, 5] = new SourceGrid.Cells.Cell(myRead["danga"].ToString(), typeof(string));
                    grid3[m, 5].View = center_cellb;
                    grid3[m, 5].AddController(clickEventd3);
 
                    grid3[m, 6] = new SourceGrid.Cells.Cell(myRead["con_day1"].ToString(), typeof(string));
                    grid3[m, 6].View = center_cell;

                    grid3[m, 7] = new SourceGrid.Cells.CheckBox(null, false);
                    grid3[m, 7].Editor = disable_cell;

                    grid3[m, 8] = new SourceGrid.Cells.Cell(myRead["con_day2"].ToString(), typeof(string));
                    grid3[m, 8].View = center_cell;

                    grid3[m, 9] = new SourceGrid.Cells.Cell(myRead["int_id"].ToString(), typeof(string));
                    m++;
                }
                myRead.Close();
                DBConn.Close();
            }
        }

        private void clickEvent_Clickd1(object sender, EventArgs e)  //Grid1에서 더블클릭시
        {
            string row_no = grid1[grid1.Selection.ActivePosition.Row, 0].ToString().Trim();
            int cpos = grid1.Selection.ActivePosition.Column;
            int rpos = grid1.Selection.ActivePosition.Row;
            string code = grid1[grid1.Selection.ActivePosition.Row, 3].ToString().Trim(); //a_code
            if (cpos == 2)
            {
                select_2(code);

            }
        }

        private void clickEvent_Clickd2(object sender, EventArgs e)  //Grid2에서 더블클릭시
        {
            string row_no = grid2[grid2.Selection.ActivePosition.Row, 0].ToString().Trim();
            int cpos = grid2.Selection.ActivePosition.Column;
            int rpos = grid2.Selection.ActivePosition.Row;
            string code = grid2[grid2.Selection.ActivePosition.Row, 4].ToString().Trim(); //code
            if (cpos == 2)
            {
                select_3(code);
            }
            else if (cpos == 3)
            {
                string a_co = code.Substring(0, 2);
                string b_co = code.Substring(2, 2);

                grid2.Selection.Focus(grid2.Selection.ActivePosition, true);
                grid2.Selection.SelectCell(grid2.Selection.ActivePosition, true);
                var rect = grid2.RangeToRectangle(new Range(grid2.Selection.ActivePosition, grid2.Selection.ActivePosition));

                DataTable a_dt1 = new DataTable();         //제본 테이블
                var DBConn = new MySqlConnection(Config.DB_con1);
                DBConn.Open();
                string cQuery = " select citem FROM C_cmodel where a_code='"+a_co+"' and b_code='"+b_co+"'";
                MySqlDataAdapter returnVal = new MySqlDataAdapter(cQuery, DBConn);
                returnVal.Fill(a_dt1);
                returnVal.Dispose();
                DBConn.Close();
                //
                Listview_no fm = new Listview_no(rect.Location.X, rect.Location.Y, 0, grid2); //박스,클릭하는 위치 칼럼
                fm.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
                DataGridView dgv1 = fm.dataGridView1;
                //
                dgv1.DataSource = a_dt1;
                dgv1.ColumnHeadersVisible = false;
                //
                dgv1.Columns[0].Width = 116;
                dgv1.Columns[0].DefaultCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
                //fm.Size = new Size(48, 660); //좌우,위,아래
                fm.Size = new Size(116, a_dt1.Rows.Count * 23 + 3); //좌우(모든 width 더하기 10),위,아래(row*23+10)
                fm.ShowDialog();
                /*
                var contextMenu = new ContextMenuStrip();
                var DBConn = new MySqlConnection(Config.DB_con1);
                DBConn.Open();
                string cQuery = " select citem FROM C_cmodel where a_code='"+a_co+"' and b_code='"+b_co+"'";
                var cmd = new MySqlCommand(cQuery, DBConn);
                var myRead = cmd.ExecuteReader();
                while (myRead.Read())
                {
                    contextMenu.Items.Add(new ToolStripMenuItem(myRead["citem"].ToString()));
                }
                myRead.Close();
                DBConn.Close();
                //contextMenu.Items.Add(new ToolStripSeparator());
                //contextMenu.Items[2].Select();
                contextMenu.Show(grid2, rect.Location);
                */ 
            }
        }

        private void ValueChangedEvent3(object sender, EventArgs e)  //Grid3에서 볼륨첸지
        {
            val_c3.ValueChanged -= new EventHandler(ValueChangedEvent3);
            //
            string row_no = grid3[grid3.Selection.ActivePosition.Row, 0].ToString().Trim();
            int cpos = grid3.Selection.ActivePosition.Column;
            string dat = grid3[grid3.Selection.ActivePosition.Row, grid3.Selection.ActivePosition.Column].ToString().Trim();
            //
            var DBConn = new MySqlConnection(Config.DB_con1);
            DBConn.Open();
            //
            string cQuery = "";
            //
            if (cpos.Equals(5))       //
                cQuery = " update C_hmachin set danga='" + dat + "' where row_id='" + row_no + "'";
            else if (cpos.Equals(6))  //
                cQuery = " update C_hmachin set con_day1='" + dat + "' where row_id='" + row_no + "'";
            else if (cpos.Equals(8))  //
            {
                cQuery = " update C_hmachin set con_day2='" + dat + "' where row_id='" + row_no + "'";
            }
            //
            if (!cQuery.Equals(""))
            {
                var cmd = new MySqlCommand(cQuery, DBConn);
                if (cmd.ExecuteNonQuery() == 0)
                {
                    MessageBox.Show("서버에라 발생으로 수정되지 않았습니다.");
                }
            }
            val_c3.ValueChanged += new EventHandler(ValueChangedEvent3);
            DBConn.Close();
        }

        private void clickEvent_Click3(object sender, EventArgs e)  //Grid3에서 원클릭시
        {

        }

        private void clickEvent_Clickd3(object sender, EventArgs e)  //Grid3에서 더블클릭시
        {
            string formToCall = grid3[grid3.Selection.ActivePosition.Row, 5].ToString().Trim();  //폼번호
            string crow_id = grid3[grid3.Selection.ActivePosition.Row, 9].ToString().Trim();     //기계소요 회사번호(row_id)
            string row_no = grid3[grid3.Selection.ActivePosition.Row, 0].ToString().Trim();
            int cpos = grid3.Selection.ActivePosition.Column;
            int rpos = grid3.Selection.ActivePosition.Row;
            if (cpos == 2)   //업체정보보기
            {
                Form_103a frm = new Form_103a(false,crow_id);
                if (frm.ShowDialog() == DialogResult.OK)
                {


                }
            }
            else if (cpos == 5)
            {
                if (!string.IsNullOrEmpty(formToCall))
                {
                    var type = Type.GetType("Dukyou3." + formToCall);
                    var myform = Activator.CreateInstance(type, row_no) as Form;
                    //               
                    if (myform != null)
                    {
                        myform.ShowDialog();
                    }
                }
            }
            grid1.Select();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            string formToCall = textBox3.Text.Trim();

            if (!string.IsNullOrEmpty(formToCall))
            {
                var type = Type.GetType("Dukyou3." + formToCall);
                var myform = Activator.CreateInstance(type) as Form;
                //               
                if (myform != null)
                {
                    myform.ShowDialog();
                }
            }
        }

        private void button3_Click(object sender, EventArgs e)  //폼보기
        {
            DataTable a_dt1 = new DataTable();         //제본 테이블
            var DBConn = new MySqlConnection(Config.DB_con1);
            DBConn.Open();
            string cQuery = " select form_no FROM C_form_dat where f_id='1'";
            MySqlDataAdapter returnVal = new MySqlDataAdapter(cQuery, DBConn);
            returnVal.Fill(a_dt1);
            returnVal.Dispose();
            DBConn.Close();
            //
            Listview_no fm = new Listview_no(this.textBox3, 0); //박스,클릭하는 위치 칼럼
            fm.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            DataGridView dgv1 = fm.dataGridView1;
            //
            dgv1.DataSource = a_dt1;
            dgv1.ColumnHeadersVisible = false;
            //
            dgv1.Columns[0].Width = 66;
            dgv1.Columns[0].DefaultCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            //fm.Size = new Size(48, 660); //좌우,위,아래
            fm.Size = new Size(66, a_dt1.Rows.Count * 23 + 3); //좌우(모든 width 더하기 10),위,아래(row*23+10)
            fm.ShowDialog();
        }

    }
}
