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
    public partial class Form_post : Form
    {
        SourceGrid.Cells.Controllers.CustomEvents clickEvent1 = new SourceGrid.Cells.Controllers.CustomEvents();

        string[] p_a2 = new string[500];       //
        public string p_no = "";
        //public string addr = "";
        //public string addr_old = "";
        public string addr_gunmool = "";
        public string addr_a = "";
        public string addr_b = "";
        public string addr_c = "";
        public string addr_d = "";
        public string addr_other_new = "";
        public string addr_other_old = "";

        private TextBox textbx = new TextBox();
        private int Xb = 0;
        private int Yb = 0;
        public Form_post()
        {
            InitializeComponent();
        }
        public Form_post(TextBox tb)
        {
            InitializeComponent();
            textbx = tb;
            //
            Xb = textbx.PointToScreen(Location).X-200;  //좌,우
            Yb = textbx.PointToScreen(Location).Y + tb.Height + 6;  //위,아래

        }
        private void Form_post_Load(object sender, EventArgs e)
        {
            this.Location = new Point(Xb, Yb);  //130 = 메뉴+버튼 길이보강
            clickEvent1.Click += new EventHandler(clickEvent_Click1);
         }

        private void button1_Click(object sender, EventArgs e)  //검색
        {
            if (comboBox1.Text.Equals("") || comboBox2.Text.Equals(""))
            {
                MessageBox.Show("'시,도' 또는 '시,군,구' 를 선택하셔야 합니다.");
                return;
            }
            //
            if (textBox1.Text.Equals(""))
            {
                MessageBox.Show("'도로명 등을 입력하셔야 합니다.");
                return;
            }
            //
            grid1.Rows.Clear();
            //중앙셀
            SourceGrid.Cells.Views.Cell center_cell = new SourceGrid.Cells.Views.Cell();
            center_cell.TextAlignment = DevAge.Drawing.ContentAlignment.MiddleCenter;
            //좌측셀
            SourceGrid.Cells.Views.Cell left_cell = new SourceGrid.Cells.Views.Cell();
            left_cell.TextAlignment = DevAge.Drawing.ContentAlignment.MiddleLeft;
            //  
            grid1.BorderStyle = BorderStyle.FixedSingle;
            grid1.ColumnsCount = 11;
            grid1.FixedRows = 1;
            grid1.Rows.Insert(0);
            grid1.Rows[0].Height = 22;
            //
            grid1[0, 0] = new MyHeader("√");
            grid1[0, 1] = new MyHeader("우편번호");
            grid1[0, 2] = new MyHeader("시, 도");
            grid1[0, 3] = new MyHeader("시, 군, 구");
            grid1[0, 4] = new MyHeader("읍, 면");
            grid1[0, 5] = new MyHeader1("도 로 명");
            grid1[0, 6] = new MyHeader1("건물번호");
            grid1[0, 7] = new MyHeader("건 물 명");
            grid1[0, 8] = new MyHeader1("리");
            grid1[0, 9] = new MyHeader("동명(구)");
            grid1[0, 10] = new MyHeader("번지");
            //
            grid1.Columns[0].Width = 30;
            grid1.Columns[1].Width = 60;
            grid1.Columns[2].Width = 100;
            grid1.Columns[3].Width = 90;
            grid1.Columns[4].Width = 100;
            grid1.Columns[5].Width = 130;
            grid1.Columns[6].Width = 50;
            grid1.Columns[7].Width = 160;
            grid1.Columns[8].Width = 90;
            grid1.Columns[9].Width = 94;
            grid1.Columns[10].Width = 70;
            //
            string find1 = comboBox2.Text.Trim();
            string find2 = textBox1.Text.Trim();
            string find3 = "";
            string find4 = "";
            string s1 = "";
            string s2 = "";
            string s3 = "";
            string s4 = "";
            //
            if (comboBox1.Text.Contains("서울특별시"))
            {
                s1 = "post_seoul";
            }
            else if (comboBox1.Text.Contains("인천광역시"))
            {
                s1 = "post_inchun";
            }
            else if (comboBox1.Text.Contains("대전광역시"))
            {
                s1 = "post_daejun";
            }
            else if (comboBox1.Text.Contains("대구광역시"))
            {
                s1 = "post_daegu";
            }
            else if (comboBox1.Text.Contains("광주광역시"))
            {
                s1 = "post_gwangju";
            }
            else if (comboBox1.Text.Contains("울산광역시"))
            {
                s1 = "post_ulsan";
            }
            else if (comboBox1.Text.Contains("부산광역시"))
            {
                s1 = "post_busan";
            }
            else if (comboBox1.Text.Contains("세종특별자치시"))
            {
                s1 = "post_sejong";
            }
            else if (comboBox1.Text.Contains("경기도"))
            {
                s1 = "post_gyeonggi";
            }
            else if (comboBox1.Text.Contains("강원도"))
            {
                s1 = "post_gangweon";
            }
            else if (comboBox1.Text.Contains("충청남도"))
            {
                s1 = "post_chung_s";
            }
            else if (comboBox1.Text.Contains("충청북도"))
            {
                s1 = "post_chung_n";
            }
            else if (comboBox1.Text.Contains("전라남도"))
            {
                s1 = "post_junra_s";
            }
            else if (comboBox1.Text.Contains("전라북도"))
            {
                s1 = "post_junra_n";
            }
            else if (comboBox1.Text.Contains("경상남도"))
            {
                s1 = "post_gyeongsan_s";
            }
            else if (comboBox1.Text.Contains("경상북도"))
            {
                s1 = "post_gyeongsan_n";
            }
            else if (comboBox1.Text.Contains("제주특별자치도"))
            {
                s1 = "post_jeju";
            }
            else
            {
                MessageBox.Show("시, 도를 정확히 입력해주세요");
                comboBox1.Focus();
                return;
            }
            //
            if (radioButton1.Checked == true)
                s2 = " and doro like '%" + find2 + "%'";
            else if (radioButton2.Checked == true)
                s2 = " and gunmool like '%" + find2 + "%'";
            else if (radioButton3.Checked == true)
                s2 = " and c_1 like '%" + find2 + "%'";
            else if (radioButton4.Checked == true)
                s2 = " and c_2 like '%" + find2 + "%'";
            //
            int number;
            if (textBox2.Text.Equals(""))
                s3 = "";
            else
            {
                if (textBox2.Text.Contains("-"))
                {
                    string[] axx = textBox2.Text.Trim().Split(new char[1] { '-' });
                    find3 = axx[0].Trim();
                    find4 = axx[1].Trim();
                    if (Int32.TryParse(find3, out number) && Int32.TryParse(find4, out number))
                    {
                        if (radioButton3.Checked == true || radioButton4.Checked == true)
                            s3 = " and c_4=" + find3 + " and c_6=" + find4;
                        else
                            s3 = " and b_2=" + find3 + " and b_3=" + find4;
                    }
                    else
                    {
                        MessageBox.Show("번지는 공백이 없는 정수타입을 입력해야 합니다.('-' 포함가능)");
                        s3 = "";
                    }
                }
                else
                {
                    find3 = textBox2.Text.Trim();
                    if (Int32.TryParse(find3, out number))
                    {
                        if (radioButton3.Checked == true || radioButton4.Checked == true)
                            s3 = " and c_4=" + find3;
                        else
                            s3 = " and b_2=" + find3;
                    }
                    else
                    {
                        MessageBox.Show("번지는 공백이 없는 정수타입을 입력해야 합니다.('-' 포함가능)");
                        s3 = "";
                    }

                }
            }
            string cQuery = "SELECT * from " + s1 + " where a2='" + find1 + "'" + s2 + s3;
            //
            var DBConn = new MySqlConnection(Config.DB_conp);
            DBConn.Open();
            var cmd = new MySqlCommand(cQuery, DBConn);
            var myRead = cmd.ExecuteReader();
            //
            int m = 1;
            while (myRead.Read())
            {
                grid1.Rows.Insert(m);
                grid1.Rows[m].Height = 24;

                grid1[m, 0] = new SourceGrid.Cells.CheckBox(null, false);
                grid1[m, 0].AddController(clickEvent1);

                grid1[m, 1] = new SourceGrid.Cells.Cell(myRead["post_no"], typeof(string));
                grid1[m, 1].View = center_cell;

                grid1[m, 2] = new SourceGrid.Cells.Cell(myRead["a1"], typeof(string));
                grid1[m, 2].View = left_cell;

                grid1[m, 3] = new SourceGrid.Cells.Cell(myRead["a2"], typeof(string));
                grid1[m, 3].View = left_cell;

                grid1[m, 4] = new SourceGrid.Cells.Cell(myRead["a3"], typeof(string));
                grid1[m, 4].View = left_cell;

                grid1[m, 5] = new SourceGrid.Cells.Cell(myRead["doro"], typeof(string));
                grid1[m, 5].View = left_cell;

                if (myRead["b_3"].ToString() != "0")
                    grid1[m, 6] = new SourceGrid.Cells.Cell(myRead["b_2"] + "-" + myRead["b_3"], typeof(string));
                else
                    grid1[m, 6] = new SourceGrid.Cells.Cell(myRead["b_2"], typeof(string));
                grid1[m, 6].View = left_cell;

                grid1[m, 7] = new SourceGrid.Cells.Cell(myRead["gunmool"], typeof(string));
                grid1[m, 7].View = left_cell;

                grid1[m, 8] = new SourceGrid.Cells.Cell(myRead["c_2"], typeof(string));
                grid1[m, 8].View = left_cell;

                grid1[m, 9] = new SourceGrid.Cells.Cell(myRead["c_1"], typeof(string));
                grid1[m, 9].View = left_cell;

                grid1[m, 10] = new SourceGrid.Cells.Cell(myRead["c_4"] + "-" + myRead["c_6"], typeof(string));
                grid1[m, 10].View = left_cell;

                m++;
            }
            //
            grid1.Selection.FocusFirstCell(true);
            myRead.Close();
            DBConn.Close();
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)
                 button1_Click(null, null);
        }

        private void comboBox1_SelectedValueChanged(object sender, EventArgs e)
        {
            for (int i = 0; i < 500; i++)
            {
                p_a2[i] = "";
            }
            string[] p_a3;
            //
            string cQuery = "";
            if (comboBox1.Text.Contains("서울특별시"))
                cQuery = "SELECT DISTINCT a2 from post_seoul";
            else if (comboBox1.Text.Contains("인천광역시"))
                cQuery = "SELECT DISTINCT a2 from post_inchun";
            else if (comboBox1.Text.Contains("대전광역시"))
                cQuery = "SELECT DISTINCT a2 from post_daejun";
            else if (comboBox1.Text.Contains("대구광역시"))
                cQuery = "SELECT DISTINCT a2 from post_daegu";
            else if (comboBox1.Text.Contains("광주광역시"))
                cQuery = "SELECT DISTINCT a2 from post_gwangju";
            else if (comboBox1.Text.Contains("울산광역시"))
                cQuery = "SELECT DISTINCT a2 from post_ulsan";
            else if (comboBox1.Text.Contains("부산광역시"))
                cQuery = "SELECT DISTINCT a2 from post_busan";
            else if (comboBox1.Text.Contains("세종특별자치시"))
                cQuery = "SELECT DISTINCT a2 from post_sejong";
            else if (comboBox1.Text.Contains("경기도"))
                cQuery = "SELECT DISTINCT a2 from post_gyeonggi";
            else if (comboBox1.Text.Contains("강원도"))
                cQuery = "SELECT DISTINCT a2 from post_gangweon";
            else if (comboBox1.Text.Contains("충청남도"))
                cQuery = "SELECT DISTINCT a2 from post_chung_s";
            else if (comboBox1.Text.Contains("충청북도"))
                cQuery = "SELECT DISTINCT a2 from post_chung_n";
            else if (comboBox1.Text.Contains("전라남도"))
                cQuery = "SELECT DISTINCT a2 from post_junra_s";
            else if (comboBox1.Text.Contains("전라북도"))
                cQuery = "SELECT DISTINCT a2 from post_junra_n";
            else if (comboBox1.Text.Contains("경상남도"))
                cQuery = "SELECT DISTINCT a2 from post_gyeongsan_s";
            else if (comboBox1.Text.Contains("경상북도"))
                cQuery = "SELECT DISTINCT a2 from post_gyeongsan_n";
            else if (comboBox1.Text.Contains("제주특별자치도"))
                cQuery = "SELECT DISTINCT a2 from post_jeju";
            else
                return;
            // 
            var DBConn = new MySqlConnection(Config.DB_conp);
            DBConn.Open();
            var cmd = new MySqlCommand(cQuery, DBConn);
            var myRead = cmd.ExecuteReader();
            int x = 0;
            while (myRead.Read())
            {
                p_a2[x] = myRead["a2"].ToString();
                x++;
            }
            p_a3 = new string[x];
            for (int i = 0; i < x; i++)
            {
                p_a3[i] = p_a2[i];
            }
            comboBox2.Text = "";
            comboBox2.Items.Clear();
            comboBox2.Items.AddRange(p_a3);
            this.comboBox2.Focus();
            myRead.Close();
            DBConn.Close();


        }

        private void clickEvent_Click1(object sender, EventArgs e)  //Grid1에서 클릭시
        {
            int rpos = grid1.Selection.ActivePosition.Row;
            int cpos = grid1.Selection.ActivePosition.Column;
            //
            if (cpos.Equals(0))
            {
                for (int i = 1; i < grid1.RowsCount; i++)
                {
                    if (i == rpos)
                        grid1[i, 0] = new SourceGrid.Cells.CheckBox(null, true);
                    else
                        grid1[i, 0] = new SourceGrid.Cells.CheckBox(null, false);
                    //
                    grid1[i, 0].AddController(clickEvent1);
                }
                grid1.Refresh();
            }
        }

        private void button2_Click(object sender, EventArgs e)   //저장
        {
            bool x_id = false;
            for (int i = 1; i < grid1.RowsCount; i++)
            {
                if (grid1[i, 0].Value.Equals(true))
                {
                    addr_other_new = grid1[i, 6].ToString();
                    addr_other_old = grid1[i, 10].ToString();

                    //addr_control.Convert_other_addr(ref addr_other_old, ref addr_other_new, tbAddrother.Text);
                    //addr_other_new = grid1[i, 6].ToString() + " " + tbAddrother.Text;
                    //addr_other_old = grid1[i, 10].ToString() + " " + tbAddrother.Text;
                    p_no = grid1[i, 1].Value.ToString().Trim();    //우편번호
                    //addr = grid1[i, 2].Value + " ";                 // 시, 도
                    //addr += grid1[i, 3].Value + " ";                // 시, 군, 구
                    //addr += grid1[i, 4].Value + " ";                // 읍, 면
                    //addr += grid1[i, 5].Value + " ";                // 도로명
                    //addr += grid1[i, 7].Value + " ";                // 건물명

                    addr_a = grid1[i, 2].Value.ToString().Trim();  // 시,도
                    addr_b = grid1[i, 3].Value.ToString().Trim();
                    if (grid1[i, 4].Value != null && grid1[i, 4].Value.ToString().Trim() != "")
                        addr_b += " " + grid1[i, 4].Value.ToString().Trim();

                    addr_b = addr_b.Trim();

                    addr_d = grid1[i, 5].Value.ToString().Trim();

                    if (grid1[i, 8].Value != null && grid1[i,8].Value.ToString().Trim() != "")  // '리'가 없으면 '동명(구)'가 addr_c
                        addr_c = grid1[i, 8].Value.ToString().Trim();
                    else
                        addr_c = grid1[i, 9].Value.ToString().Trim();  // '리'가 있으면 '리'가 addr_c

                    if (addr_d != null && addr_d.Trim() !="")
                    {
                        //addr = grid1[i, 2].Value + " ";                 // 시, 도
                        //addr += grid1[i, 3].Value + " ";                // 시, 군, 구
                        //addr += grid1[i, 4].Value + " ";                // 읍, 면
                        //addr += grid1[i, 5].Value + " ";                // 도로명
                        //if (grid1[i, 6].ToString() != null && grid1[i, 6].ToString().Trim() != "")
                        //    addr += grid1[i, 6].ToString();
                    }
                    if (addr_c != null && addr_c.Trim() != "")
                    {
                        //addr_old = grid1[i, 2].Value + " ";                 // 시, 도
                        //addr_old += grid1[i, 3].Value + " ";                // 시, 군, 구
                        //addr_old += grid1[i, 4].Value + " ";                // 읍, 면
                        //addr_old += addr_c + " ";
                        //if (grid1[i, 10].ToString() != null && grid1[i, 10].ToString().Trim() != "")
                        //    addr_old += grid1[i, 10].ToString();
                    }
                    addr_gunmool = grid1[i, 7].ToString();
                    x_id = true;
                    break;
                }
            }
            if (x_id)
            {
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            else
            {
                MessageBox.Show("선택 항목이 없습니다.");
            }
        }

        private void comboBox2_SelectedValueChanged(object sender, EventArgs e)  //
        {
            textBox1.Focus();
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            this.label7.Text = "건물번호";
            textBox1.Focus();
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            this.label7.Text = "건물번호";
            textBox1.Focus();
        }

        private void radioButton3_CheckedChanged(object sender, EventArgs e)
        {
            this.label7.Text = "번  지";
            textBox1.Focus();
        }

        private void radioButton4_CheckedChanged(object sender, EventArgs e)
        {
            this.label7.Text = "번  지";
            textBox1.Focus();
        }

        private void textBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                textBox2.Focus();
        }

        private void textBox2_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                button1_Click(sender, e);
        }

        private void tbAddrother_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                button2_Click(sender, e);
        }
    }
}
