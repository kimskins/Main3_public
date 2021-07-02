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
    public partial class Form_103 : Form
    {//gittest2
        SourceGrid.Cells.Controllers.CustomEvents clickEvent = new SourceGrid.Cells.Controllers.CustomEvents();
        private DataTable a_dt = new DataTable();  //C_amodel 자료 테이블
        private DataTable b_dt = new DataTable();  //C_bmodel 자료 테이블
        private Form newForm;      //별표폼
        private TextBox textBox9;  //별표 등록 텍스트 박스
        cell_d cc = new cell_d();
        //
        public Form_103()
        {
            InitializeComponent();
        }

        private void Form4_Load(object sender, EventArgs e)
        {
            var DBConn = new MySqlConnection(Config.DB_con1);
            DBConn.Open();
            string cQuery="";
            //
            a_dt.Columns.Add("a_code", typeof(string));  //
            a_dt.Columns.Add("aitem", typeof(string));   //
            cQuery = "select a_code,aitem from C_amodel order by s_no";
            var cmd = new MySqlCommand(cQuery, DBConn);
            var myRead = cmd.ExecuteReader();
            while (myRead.Read())
            {
                a_dt.Rows.Add(new string[] { myRead["a_code"].ToString(), myRead["aitem"].ToString()});
            }
            myRead.Close();
            //
            b_dt.Columns.Add("a_code", typeof(string));  //
            b_dt.Columns.Add("b_code", typeof(string));  //
            b_dt.Columns.Add("tap", typeof(string));   //
            cQuery = "select a_code,b_code,tap from C_bmodel ";
            cmd = new MySqlCommand(cQuery, DBConn);
            myRead = cmd.ExecuteReader();
            while (myRead.Read())
            {
                b_dt.Rows.Add(new string[] { myRead["a_code"].ToString(), myRead["b_code"].ToString(), myRead["tap"].ToString() });
            }
            myRead.Close();
            //
            string[] combo1 = new string[a_dt.Rows.Count];
            for (int i = 0; i < a_dt.Rows.Count; i++)
            {
                combo1[i] = a_dt.Rows[i][1].ToString().Trim();
            }
            comboBox3.Items.AddRange(combo1);
            //
            DBConn.Close();
            //
            Screen srn = Screen.PrimaryScreen;
            int Xb = this.Width;  //좌,우
            this.Location = new Point((srn.Bounds.Width - Xb) / 2, 1);  //좌/우,위/아래
            //
            clickEvent.Click += new EventHandler(clickEvent_Click);
            //
            button3_Click(null, null);
        }

        private void button6_Click(object sender, EventArgs e)
        {
            Form_103a Frm = new Form_103a(true, "0");
            Frm.ShowDialog();
            button3_Click(null, null);
        }

        private void button3_Click(object sender, EventArgs e)  //검색
        {
            string s1 = "";
            string s2 = "";
            string s3 = "";
            //
            if (!textBox1.Text.Equals(""))
            {
                string xx = textBox1.Text.Trim();
                s1 = " and sangho like '%" + xx + "%'";
            }
            //
            if (!comboBox2.Text.Equals(""))
            {
                string ss = comboBox2.Text.Trim();
                s2 = " and area like '%" + ss + "%'";
            }
            //
            if (!comboBox3.Text.Equals(""))
            {
                if (!comboBox4.Text.Equals(""))
                {
                    string name = comboBox4.Text.Trim();
                    for (int i = 0; i < b_dt.Rows.Count; i++)
                    {
                        if (b_dt.Rows[i][2].ToString().Equals(name))
                        {
                            string xx = b_dt.Rows[i][0].ToString().Trim() + b_dt.Rows[i][1].ToString().Trim();
                            s3 = " and yubjong like '%" + xx + "%'";
                            break;
                        }
                    }
                }
                else
                {
                    MessageBox.Show("업종 1,2 를 채워주세요.");
                    return;
                }
            }
            //
            grid1.Rows.Clear();
            //
            SourceGrid.Cells.Views.Cell Mycell = new SourceGrid.Cells.Views.Cell();
            Mycell.TextAlignment = DevAge.Drawing.ContentAlignment.MiddleCenter;
            //
            SourceGrid.Cells.Views.Cell Intcell = new SourceGrid.Cells.Views.Cell();
            Intcell.TextAlignment = DevAge.Drawing.ContentAlignment.MiddleRight;
            //
            SourceGrid.Cells.Editors.TextBox Int_Editor = new SourceGrid.Cells.Editors.TextBox(typeof(int));
            DevAge.ComponentModel.Converter.NumberTypeConverter FormatCustom = new DevAge.ComponentModel.Converter.NumberTypeConverter(typeof(int));
            FormatCustom.Format = "###,###,###";
            Int_Editor.TypeConverter = FormatCustom;
            //
            SourceGrid.Cells.Editors.TextBox disable_cell = new SourceGrid.Cells.Editors.TextBox(typeof(string));  //수정불가
            disable_cell.EnableEdit = false;
            //
            grid1.BorderStyle = BorderStyle.FixedSingle;
            grid1.ColumnsCount = 19;
            grid1.FixedRows = 1;

            grid1.Rows.Insert(0);
            grid1.Rows[0].Height = 30;
            grid1[0, 0] = new SourceGrid.Cells.ColumnHeader("row_id");
            grid1.Columns[0].Visible = false;
            grid1[0, 1] = new MyHeader("√");
            grid1[0, 2] = new MyHeader("No");
            grid1[0, 3] = new MyHeader("L-in");
            grid1[0, 4] = new MyHeader("상     호");
            grid1[0, 5] = new MyHeader("지  역");
            grid1[0, 6] = new MyHeader("대  표");
            grid1[0, 7] = new MyHeader("사업자번호");
            grid1[0, 8] = new MyHeader("전 화");
            grid1[0, 9] = new MyHeader("업    종");
            grid1[0, 10] = new MyHeader("등록일");
            grid1[0, 11] = new MyHeader("홈 피");
            grid1[0, 12] = new MyHeader("광 고");
            grid1[0, 13] = new MyHeader(".");
            grid1[0, 14] = new MyHeader("homp_ip");
            grid1.Columns[14].Visible = false;
            grid1[0, 15] = new MyHeader("rank");
            grid1.Columns[15].Visible = false;
            grid1[0,16] = new MyHeader("플랫폼");

            grid1[0, 17] = new MyHeader("사무실주소");
            grid1[0, 18] = new MyHeader("공장주소");

            //
            var DBConn = new MySqlConnection(Config.DB_con1);
            DBConn.Open();
            string cQuery = " select * FROM C_hcustomer";
            cQuery += " where row_id is not null " + s1 + s2 + s3;
            cQuery += " order by en_day";
            var cmd = new MySqlCommand(cQuery, DBConn);
            var myRead = cmd.ExecuteReader();
            int m = 1;
            string yu = "";
            while (myRead.Read())
            {
                grid1.Rows.Insert(m);
                grid1.Rows[m].Height = 24;
                yu = c_change( myRead["yubjong"].ToString() );
                grid1[m, 0] = new SourceGrid.Cells.Cell(myRead["row_id"], typeof(string));
                grid1[m, 1] = new SourceGrid.Cells.CheckBox(null, false);
                grid1[m, 2] = new SourceGrid.Cells.Cell(m, typeof(string));
                grid1[m, 2].View = Mycell;
                grid1[m, 2].Editor = disable_cell;
                grid1[m, 3] = new SourceGrid.Cells.Button("");
                grid1[m, 3].AddController(clickEvent);
                grid1[m, 3].Editor = disable_cell;
                grid1[m, 4] = new SourceGrid.Cells.Cell(myRead["sangho"], typeof(string));
                grid1[m, 4].Editor = disable_cell;
                grid1[m, 5] = new SourceGrid.Cells.Cell(myRead["area"], typeof(string));
                grid1[m, 5].Editor = disable_cell;
                grid1[m, 6] = new SourceGrid.Cells.Cell(myRead["mast"], typeof(string));
                grid1[m, 6].Editor = disable_cell;
                grid1[m, 7] = new SourceGrid.Cells.Cell(myRead["enter_no"], typeof(string));
                grid1[m, 7].Editor = disable_cell;
                grid1[m, 8] = new SourceGrid.Cells.Cell(myRead["ctel"], typeof(string));
                grid1[m, 8].Editor = disable_cell;
                grid1[m, 9] = new SourceGrid.Cells.Cell(yu, typeof(string));
                grid1[m, 9].Editor = disable_cell;
                grid1[m, 10] = new SourceGrid.Cells.Cell(myRead["en_day"], typeof(string));
                grid1[m, 10].View = Mycell;
                grid1[m, 10].Editor = disable_cell;
                grid1[m, 11] = new SourceGrid.Cells.Button("");
                if (myRead["homp_ip"].Equals(""))
                    grid1[m, 11] = new SourceGrid.Cells.Cell(" ", typeof(string));
                else
                    grid1[m, 11] = new SourceGrid.Cells.Button("");
                //
                grid1[m, 11].View.TextAlignment = DevAge.Drawing.ContentAlignment.MiddleCenter;
                grid1[m, 11].AddController(clickEvent);
                grid1[m, 11].Editor = cc.disable_cell;
                grid1[m, 12] = new SourceGrid.Cells.Button("");
                grid1[m, 12].AddController(clickEvent);
                grid1[m, 13] = new SourceGrid.Cells.Button("");
                grid1[m, 13].AddController(clickEvent);
                grid1[m, 14] = new SourceGrid.Cells.Cell(myRead["homp_ip"], typeof(string));
                grid1[m, 15] = new SourceGrid.Cells.Cell(myRead["rank"], typeof(string));
                
                if(myRead["platform"].Equals(true))
                    grid1[m, 16] = new SourceGrid.Cells.CheckBox(null, true);
                else
                    grid1[m, 16] = new SourceGrid.Cells.CheckBox(null, false);

                if (myRead["c_addr_a"].ToString() != "")
                    grid1[m, 17] = new SourceGrid.Cells.Cell("O", typeof(string));
                else
                    grid1[m, 17] = new SourceGrid.Cells.Cell("X", typeof(string));

                if (myRead["m_addr_a"].ToString() != "")
                    grid1[m, 18] = new SourceGrid.Cells.Cell("O", typeof(string));
                else
                    grid1[m, 18] = new SourceGrid.Cells.Cell("X", typeof(string));

                m++;
            }
            //
            grid1.Columns[0].Width = 100;
            grid1.Columns[1].Width = 30;
            grid1.Columns[2].Width = 30;
            grid1.Columns[3].Width = 30;
            grid1.Columns[4].Width = 130;
            grid1.Columns[5].Width = 80;
            grid1.Columns[6].Width = 80;
            grid1.Columns[7].Width = 100;
            grid1.Columns[8].Width = 100;
            grid1.Columns[9].Width = 300;
            grid1.Columns[10].Width = 84;
            grid1.Columns[11].Width = 40;
            grid1.Columns[12].Width = 40;
            grid1.Columns[13].Width = 20;
            grid1.Columns[14].Width = 100;
            grid1.Columns[15].Width = 40;
            grid1.Columns[16].Width = 45;

            grid1.Columns[17].Width = 100;
            grid1.Columns[18].Width = 100;
            //
            myRead.Close();
            DBConn.Close();
            grid1.Focus();
        }

        private string c_change(string mm)  //업종분해
        {
            string xx = "";
            string[] axx = mm.Split(new char[1] { '/' });
            string xno = "";
            string xno1= "";
            //
            for (int i = 0; i < axx.Length-1 ; i++)   //
            {
                xno = axx[i].Substring(0, 2);
                xno1= axx[i].Substring(2, 2);
                for (int s = 0; s < b_dt.Rows.Count; s++)
                {
                    if (b_dt.Rows[s][0].ToString().Trim().Equals(xno) && b_dt.Rows[s][1].ToString().Trim().Equals(xno1))
                    {
                        xx += b_dt.Rows[s][2].ToString().Trim() + "/";
                        break;
                    }
                }
            }
            return xx;
        }
        
        private void clickEvent_Click(object sender, EventArgs e)  //Grid1에서 클릭시
        {
            int column = grid1.Selection.ActivePosition.Column;
            //            
            if (column == 3)   //세부내용 보기
            {
                string row_no = grid1[grid1.Selection.ActivePosition.Row, 0].ToString().Trim();
                Form_103a Frm = new Form_103a(false, row_no);
                Frm.ShowDialog();
                button3_Click(null, null);
            }
            else if (column == 11)   //홈피보기
            {
                if (grid1[grid1.Selection.ActivePosition.Row, column].ToString() != " ")
                {
                    string h_ip = grid1[grid1.Selection.ActivePosition.Row, 14].ToString().Trim();
                    if (!h_ip.Equals(""))
                    {
                        System.Diagnostics.Process.Start("IExplore", h_ip);
                        //Webform Frm = new Webform(h_ip, "2");
                        //Frm.Show();
                    }
                    else
                        MessageBox.Show("주소가 없습니다");
                }
            }
            else if (column == 12)   //광고보기
            {
                string h_ip = System.IO.Directory.GetCurrentDirectory().ToString() + "\\Documents\\SourceGrid_EN.html";
                Webform Frm = new Webform(h_ip, "3");
                Frm.Show();
            }
            else if (column == 13)  //별표등록
            {
                newForm = new Form();
                newForm.ClientSize = new System.Drawing.Size(198, 152);
                newForm.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
                newForm.Text = "● 별표 등록";
                newForm.ResumeLayout(false);
                newForm.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
                //
                textBox9 = new TextBox();  //main 자료 테이블
                textBox9.Location = new System.Drawing.Point(100, 50);  //좌,우/위.아래
                textBox9.Name = "textBox11";
                textBox9.Size = new System.Drawing.Size(60, 13);       //좌,우/위.아래
                textBox9.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
                textBox9.Text = grid1[grid1.Selection.ActivePosition.Row, 15].ToString().Trim();
                newForm.Controls.Add(textBox9);
                //
                Label label1 = new Label();
                label1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
                label1.Location = new System.Drawing.Point(32, 50);
                label1.Size = new System.Drawing.Size(65, 20);
                label1.TabIndex = 89;
                label1.Text = "별표숫자";
                label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
                newForm.Controls.Add(label1);
                //
                Button button10 = new Button();
                button10.ForeColor = System.Drawing.SystemColors.ControlText;
                button10.Location = new System.Drawing.Point(94, 100);
                button10.Size = new System.Drawing.Size(66, 23);
                button10.Text = "저 장";
                button10.UseVisualStyleBackColor = true;
                button10.Click += new System.EventHandler(button10_Click);
                newForm.Controls.Add(button10);
                // 
                newForm.ShowDialog();
            }
        }

        private void button10_Click(object sender, EventArgs e)  //별표등록
        {
            string rno = textBox9.Text.Trim();
            var DBConn = new MySqlConnection(Config.DB_con1);
            DBConn.Open();
            string row_no = grid1[grid1.Selection.ActivePosition.Row, 0].ToString().Trim();
            string cQuery = " update C_hcustomer set rank='" + rno + "' where row_id='" + row_no + "'";
            var cmd = new MySqlCommand(cQuery, DBConn);
            if (cmd.ExecuteNonQuery() == 0)
                MessageBox.Show("서버 자료 수정에 실패 했습니다.");
            else
            {
                MessageBox.Show("저장 하였습니다.");
                grid1[grid1.Selection.ActivePosition.Row, 15].Value = textBox9.Text;
            }
            //
            DBConn.Close();
            newForm.Close();
        }

        private void button7_Click(object sender, EventArgs e)  //항목삭제
        {
            if (MessageBox.Show("선택하신 항목을 삭제합니까 ?", "항목 삭제", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                string[] sd = new string[grid1.RowsCount];//
                for (int i = 0; i < sd.Length; i++)
                    sd[i] = "0";
                //
                int s = 1;
                for (int i = 1; i < grid1.RowsCount; i++)
                {
                    if (grid1[i, 1].Value.Equals(true))
                    {
                        sd[s] = grid1[i, 0].Value.ToString().Trim();
                        s++;
                    }
                }

                //  DB 삭제
                var DBConn = new MySqlConnection(Config.DB_con1);
                DBConn.Open();
                //
                string row_no = "";
                string cQuery = "";
                var cmd = new MySqlCommand(cQuery, DBConn); ;
                for (int i = 1; i < sd.Length; i++)
                {
                    if (sd[i].Equals("0"))
                        break;
                    else
                    {
                        row_no = sd[i];
                        cQuery = " delete from C_hcustomer where row_id='" + row_no + "'";
                        cmd = new MySqlCommand(cQuery, DBConn);
                        if (cmd.ExecuteNonQuery() == 0)
                        {
                            MessageBox.Show("서버 자료 삭제에 실패 했습니다.");
                            break;
                        }
                        // 
                        cQuery = " delete from C_hman where int_id='" + row_no + "'";
                        cmd = new MySqlCommand(cQuery, DBConn);
                        cmd.ExecuteNonQuery();
                        //
                        cQuery = " delete from C_hmachin where int_id='" + row_no + "'";
                        cmd = new MySqlCommand(cQuery, DBConn);
                        cmd.ExecuteNonQuery();
                    }
                }
                DBConn.Close();
                //  그리드 삭제
                for (int i = 1; i < sd.Length; i++)
                {
                    if (sd[i].Equals("0"))
                        break;
                    else
                    {
                        for (s = 2; s < grid1.RowsCount; s++)
                        {
                            if (grid1[s, 0].Value.ToString().Equals(sd[i]))
                            {
                                grid1.Rows.Remove(s);
                            }
                        }
                    }
                }
                if (grid1.RowsCount > 1)
                {
                    grid1.Selection.FocusFirstCell(true);
                }
            }
        }

        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {
            string code = "";
            string item = comboBox3.Text.Trim();
            // 
            for (int i = 0; i < a_dt.Rows.Count; i++)
            {
                if (a_dt.Rows[i][1].ToString().Equals(item))
                {
                    code = a_dt.Rows[i][0].ToString().Trim();
                    break;
                }
            }
            //
            DataRow[] dr = b_dt.Select("a_code = '" + code + "'");
            //
            string[] combo = new string[dr.Count()];
            int xx=0;
            for (int i = 0; i < b_dt.Rows.Count; i++)
            {
                if (b_dt.Rows[i][0].ToString().Equals(code))
                {
                    combo[xx] = b_dt.Rows[i][2].ToString().Trim();
                    xx++;
                }
            } 
            comboBox4.Items.Clear();
            comboBox4.Items.AddRange(combo);
            this.comboBox4.Text = "";
            this.comboBox4.Focus();
        }

        private void button4_Click(object sender, EventArgs e)  //clear
        {
            comboBox3.Text = "";
            comboBox4.Text = "";
            comboBox4.Items.Clear();
            //
            textBox1.Text = "";
            comboBox2.Text = "";
        }

        private void grid1_Click(object sender, EventArgs e)
        {
            int column = grid1.Selection.ActivePosition.Column;
            int Rows = grid1.Selection.ActivePosition.Row;
            SourceGridControl GridHandle = new SourceGridControl();

            GridHandle.SourceGrideInit(grid1, Config.DB_con1);

            if (Rows < 0)
                return;

            string Query = "";
            string row_no = "";
            row_no = grid1[Rows, 0].ToString().Trim();

            if (column == 16)
            {
                if (grid1[Rows, 16].ToString() == "True")
                    Query = "update  C_hcustomer set platform=false where row_id = '" + row_no + "'";
                else
                    Query = "update  C_hcustomer  set platform=true where row_id = '" + row_no + "'";

                GridHandle.DataUpdate(Query);
            }


        }

    }
}
