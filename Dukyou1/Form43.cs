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
    public partial class Form43 : Form
    {
        private DataTable g_dt2 = new DataTable(); //
        public string citem="";
        string[] axx;
        public string[] bxx = new string[8];
        CheckBox[] chk_Box = new CheckBox[8];
        private DataTable a_dt = new DataTable();  //main 자료 테이블
        private DataTable b_dt = new DataTable();  //main 자료 테이블

        public Form43(string[] yup)
        {
            InitializeComponent();
            axx = yup;
        }

        private void Form43_Load(object sender, EventArgs e)
        {
            this.label1.Text = "등록업종" + "\r\n" + "(삭제시" + "\r\n"+"체크요)";
            //
            chk_Box[0] = this.checkBox1;
            chk_Box[1] = this.checkBox2;
            chk_Box[2] = this.checkBox3;
            chk_Box[3] = this.checkBox4;
            chk_Box[4] = this.checkBox5;
            chk_Box[5] = this.checkBox6;
            chk_Box[6] = this.checkBox7;
            chk_Box[7] = this.checkBox8;
            bxx[0] = "0";
            bxx[1] = "0";
            bxx[2] = "0";
            bxx[3] = "0";
            bxx[4] = "0";
            bxx[5] = "0";
            bxx[6] = "0";
            bxx[7] = "0";
            //
            var DBConn = new MySqlConnection(Config.DB_con1);
            DBConn.Open();
            string cQuery = " select count(*) from C_amodel";
            var cmd = new MySqlCommand(cQuery, DBConn);
            var myRead = cmd.ExecuteReader();
            int k = 0;
            if (myRead.Read())
                k = Convert.ToInt32(myRead[0]);
            myRead.Close();
            dataGridView1.Rows.Add(k);
            //
            cQuery = " select * FROM C_amodel";
            cQuery += " order by s_no";
            cmd = new MySqlCommand(cQuery, DBConn);
            myRead = cmd.ExecuteReader();
            int m = 0;
            while (myRead.Read())
            {
                dataGridView1.Rows[m].Cells[0].Value = myRead["a_code"].ToString();
                dataGridView1.Rows[m].Cells[1].Value = myRead["s_no"].ToString();
                dataGridView1.Rows[m].Cells[2].Value = myRead["aitem"].ToString();
                m++;
            }
            myRead.Close();
            //
            g_dt2.Columns.Add("a_code"); //0
            g_dt2.Columns.Add("b_code"); //1
            g_dt2.Columns.Add("bitem");  //2
            g_dt2.Columns.Add("tap");    //3
            g_dt2.Columns.Add("row_id"); //6
            g_dt2.Columns.Add("chk");    //7
            //
            cQuery = " select * FROM C_bmodel order by BINARY(bItem)";
            cmd = new MySqlCommand(cQuery, DBConn);
            myRead = cmd.ExecuteReader();
            while (myRead.Read())
            {
                g_dt2.Rows.Add(new string[] { myRead["a_code"].ToString(),myRead["b_code"].ToString(),myRead["bitem"].ToString(),myRead["tap"].ToString()
                ,myRead["row_id"].ToString(),"0"});
            }
            myRead.Close();
            // 
            a_dt.Columns.Add("a_code", typeof(string));  //
            a_dt.Columns.Add("aitem", typeof(string));   //
            cQuery = "select a_code,aitem from C_amodel ";
            cmd = new MySqlCommand(cQuery, DBConn);
            myRead = cmd.ExecuteReader();
            while (myRead.Read())
            {
                a_dt.Rows.Add(new string[] { myRead["a_code"].ToString(), myRead["aitem"].ToString() });
            }
            myRead.Close();
            //
            b_dt.Columns.Add("a_code", typeof(string));  //
            b_dt.Columns.Add("b_code", typeof(string));  //
            b_dt.Columns.Add("bitem", typeof(string));   //
            b_dt.Columns.Add("tap", typeof(string));   //
            cQuery = "select a_code,b_code,bitem,tap from C_bmodel ";
            cmd = new MySqlCommand(cQuery, DBConn);
            myRead = cmd.ExecuteReader();
            while (myRead.Read())
            {
                b_dt.Rows.Add(new string[] { myRead["a_code"].ToString(), myRead["b_code"].ToString(), myRead["bitem"].ToString(), myRead["tap"].ToString() });
            }
            myRead.Close();
            DBConn.Close();
            //
            if (axx.Length != 0)
            {
                for (int i = 0; i < axx.Length; i++)
                {
                    if (!axx[i].Equals(""))
                    {
                        chk_Box[i].Visible = true;
                        chk_Box[i].Text = c_change(axx[i].ToString());
                    }
                }
            }
            //
            dataGridView2.Rows.Add(1);
            // 
            dataGridView2.Rows[dataGridView2.CurrentCell.RowIndex].Selected = false;
        }

        private string c_change(string mm)  //업종분해
        {
            string xx = "";
            string xno = "";
            string xno1 = "";
            //
            xno = mm.Substring(0, 2);
            xno1 = mm.Substring(2, 2);
            for (int s = 0; s < b_dt.Rows.Count; s++)
            {
                if (b_dt.Rows[s][0].ToString().Trim().Equals(xno) && b_dt.Rows[s][1].ToString().Trim().Equals(xno1))
                {
                    xx += b_dt.Rows[s][3].ToString().Trim(); //탭이름으로 교체
                    break;
                }
            }
            return xx;
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)  //Grid1에서 마우스 클릭
        {
            dataGridView2.Rows.Clear();
            string item1 = dataGridView1.Rows[dataGridView1.CurrentRow.Index].Cells[0].Value.ToString().Trim();  //a_code
            bool b_id = false;
            for (int i = 0; i < g_dt2.Rows.Count; i++)
            {
                if (g_dt2.Rows[i][0].ToString().Trim().Equals(item1))  //a_code
                {
                    if (g_dt2.Rows[i][5].ToString().Trim().Equals("1"))
                        b_id = true;
                    else
                        b_id = false;
                    //   
                    dataGridView2.Rows.Add(g_dt2.Rows[i][0].ToString().Trim(), g_dt2.Rows[i][1].ToString().Trim(), b_id, g_dt2.Rows[i][2].ToString().Trim()
                    ,g_dt2.Rows[i][3].ToString().Trim(),g_dt2.Rows[i][4].ToString().Trim());
                }

            }
            dataGridView2.Rows[dataGridView2.CurrentCell.RowIndex].Selected = false;
        }

        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e) //Grid1에서 글자 마우스 클릭
        {
            if (e.ColumnIndex == 2)
            {
                if (dataGridView2.Rows[dataGridView2.CurrentRow.Index].Cells[2].Value.Equals(true))
                    dataGridView2.Rows[dataGridView2.CurrentRow.Index].Cells[2].Value = false;
                else
                    dataGridView2.Rows[dataGridView2.CurrentRow.Index].Cells[2].Value = true;
                //
                chk_button();
            }
        }

        private void chk_button()  //Grid2에서 체크버튼클릭시
        {
            string x_id = "0";
            string x_no = dataGridView2.Rows[dataGridView2.CurrentRow.Index].Cells[5].Value.ToString().Trim(); //row_id
            if (dataGridView2.Rows[dataGridView2.CurrentRow.Index].Cells[2].Value.Equals(true))  //체크버튼
                x_id = "1";
            else
                x_id = "2";
            //
            for (int i = 0; i < g_dt2.Rows.Count; i++)
            {
                if (g_dt2.Rows[i][4].ToString().Trim().Equals(x_no))
                {
                    g_dt2.Rows[i][5] = x_id;
                    break;
                }

            }
            chk_view();
        }

        private void chk_view()  //저장
        {
            string mm = "";
            string[] xtap = new string[10];
            for (int i = 0; i < xtap.Length; i++)
            {
                xtap[i]="";
            }
            string xnam = "";
            int xno = 0;
            bool x_id = false;
            //
            for (int i = 0; i < g_dt2.Rows.Count; i++)
            {
                if (g_dt2.Rows[i][5].ToString().Trim().Equals("1"))  //체크버튼
                {
                    x_id = true;
                    xnam = g_dt2.Rows[i][3].ToString().Trim();  //탭이름
                    if(xnam.Equals(""))
                    {
                        x_id = false;
                    }
                    else
                    {
                        for (int x = 0; x < xtap.Length; x++)
                        {
                            if (xtap[x].Equals(xnam))
                            {
                                x_id = false;
                                break;
                            }
                        }
                    }
                    if (x_id == true)
                    {
                        mm += g_dt2.Rows[i][0].ToString().Trim() + g_dt2.Rows[i][1].ToString().Trim() + "/";
                        xtap[xno] = xnam;
                        xno++;
                    }
                }
            }
            textBox1.Text = mm;
        }

        private void button2_Click(object sender, EventArgs e)  //저장
        {
            citem = textBox1.Text;
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)  //검색1
        {
            if (!textBox2.Text.Equals(""))
            {
                string mm = textBox2.Text.Trim();
                for (int i = 0; i < dataGridView1.RowCount; i++)
                {
                    if (dataGridView1.Rows[i].Cells[2].Value.ToString().Contains(mm))
                    {
                        dataGridView1.CurrentCell = dataGridView1.Rows[i].Cells[2];//크스옮기기
                        break;
                    }
                }
            }

        }

        private void button5_Click(object sender, EventArgs e)  //검색2
        {
            string mm = textBox3.Text.Trim();
            dataGridView2.Rows.Clear();
            string item1 = dataGridView1.Rows[dataGridView1.CurrentRow.Index].Cells[0].Value.ToString().Trim();  //a_code
            bool b_id = false;
            if (mm.Equals(""))
            {
                for (int i = 0; i < g_dt2.Rows.Count; i++)
                {
                    if (g_dt2.Rows[i][5].ToString().Trim().Equals("1"))
                        b_id = true;
                    else
                        b_id = false;
                    //   
                    dataGridView2.Rows.Add(g_dt2.Rows[i][0].ToString().Trim(), g_dt2.Rows[i][1].ToString().Trim(), b_id, g_dt2.Rows[i][2].ToString().Trim()
                                            , g_dt2.Rows[i][3].ToString().Trim(), g_dt2.Rows[i][4].ToString());
                }
            }
            else
            {
                for (int i = 0; i < g_dt2.Rows.Count; i++)
                {
                    if (g_dt2.Rows[i][2].ToString().Trim().Contains(mm))
                    {
                        if (g_dt2.Rows[i][5].ToString().Trim().Equals("1"))
                            b_id = true;
                        else
                            b_id = false;
                        //   
                        dataGridView2.Rows.Add(g_dt2.Rows[i][0].ToString().Trim(), g_dt2.Rows[i][1].ToString().Trim(), b_id, g_dt2.Rows[i][2].ToString().Trim()
                                              , g_dt2.Rows[i][3].ToString().Trim(), g_dt2.Rows[i][4].ToString());
                    }

                }
            }
            dataGridView2.Rows[dataGridView2.CurrentCell.RowIndex].Selected = false;
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked == true)
                bxx[0] = "1";
            else
                bxx[0] = "0";
        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox2.Checked == true)
                bxx[1] = "1";
            else
                bxx[1] = "0";
        }

        private void checkBox3_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox3.Checked == true)
                bxx[2] = "1";
            else
                bxx[2] = "0";
        }

        private void checkBox4_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox4.Checked == true)
                bxx[3] = "1";
            else
                bxx[3] = "0";
        }

        private void checkBox5_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox5.Checked == true)
                bxx[4] = "1";
            else
                bxx[4] = "0";
        }

        private void checkBox6_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox6.Checked == true)
                bxx[5] = "1";
            else
                bxx[5] = "0";
        }

        private void checkBox7_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox7.Checked == true)
                bxx[6] = "1";
            else
                bxx[6] = "0";
        }

        private void checkBox8_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox8.Checked == true)
                bxx[7] = "1";
            else
                bxx[7] = "0";
        }
    }
}
