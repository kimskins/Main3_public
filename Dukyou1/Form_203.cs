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
    public partial class Form_203 : Form
    {
        private DataTable g_dt2 = new DataTable(); //
        private DataTable g_dt3 = new DataTable(); //
        // 
        public Form_203()
        {
            InitializeComponent();
        }

        private void Form42_Load(object sender, EventArgs e)
        {
            Screen srn = Screen.PrimaryScreen;
            int Xb = this.Width;  //좌,우
            this.Location = new Point((srn.Bounds.Width - Xb) / 2, 1);  //좌/우,위/아래
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
                dataGridView1.Rows[m].Cells[0].Value = myRead["row_id"].ToString();
                dataGridView1.Rows[m].Cells[1].Value = false;
                dataGridView1.Rows[m].Cells[2].Value = for_sort_no(myRead["s_no"].ToString());
                dataGridView1.Rows[m].Cells[3].Value = myRead["gongjung"].ToString();
                dataGridView1.Rows[m].Cells[4].Value = myRead["a_code"].ToString();
                dataGridView1.Rows[m].Cells[5].Value = myRead["aitem"].ToString();
                dataGridView1.Rows[m].Cells[6].Value = myRead["company_code"].ToString();
                m++;
            }
            myRead.Close();
            DBConn.Close();
            //
            g_dt2_mk();
            g_dt3_mk();
            // 
            dataGridView1.CellValueChanged += new DataGridViewCellEventHandler(dataGridView1_CellValueChanged);
            dataGridView2.CellValueChanged += new DataGridViewCellEventHandler(dataGridView2_CellValueChanged);
            dataGridView3.CellValueChanged += new DataGridViewCellEventHandler(dataGridView3_CellValueChanged);
        }

        private void button1_Click(object sender, EventArgs e)  //Grid1 검색
        {
            if (!textBox2.Text.Equals(""))
            {
                string mm = textBox2.Text.Trim();
                for (int i = 0; i < dataGridView1.RowCount; i++)
                {
                    if (dataGridView1.Rows[i].Cells[5].Value.ToString().Contains(mm))
                    {
                        dataGridView1.CurrentCell = dataGridView1.Rows[i].Cells[2];   //크스옮기기
                        break;
                    }
                }
            }
            if (dataGridView2.RowCount != 0)
                dataGridView2.Rows[dataGridView2.CurrentCell.RowIndex].Selected = false;
        }

        private void button5_Click(object sender, EventArgs e)  //Grid2에서 검색
        {
            string mm = textBox3.Text.Trim();
            dataGridView2.Rows.Clear();
            if (mm.Equals(""))
            {
                for (int i = 0; i < g_dt2.Rows.Count; i++)
                {
                    dataGridView2.Rows.Add(g_dt2.Rows[i]["row_id"].ToString().Trim(), false, g_dt2.Rows[i]["a_code"].ToString().Trim(), g_dt2.Rows[i]["b_code"].ToString().Trim()
                    , g_dt2.Rows[i]["bitem"].ToString().Trim(), g_dt2.Rows[i]["per"].ToString().Trim(), g_dt2.Rows[i]["no"].ToString().Trim(), g_dt2.Rows[i]["gongjung"].ToString().Trim()
                    , g_dt2.Rows[i]["m_id"].ToString().Trim(), g_dt2.Rows[i]["tap"].ToString().Trim()
                    , g_dt2.Rows[i]["gong_n"].ToString().Trim(), g_dt2.Rows[i]["gong_s"].ToString().Trim(), i.ToString());


                }
            }
            else
            {
                for (int i = 0; i < g_dt2.Rows.Count; i++)
                {
                    if (g_dt2.Rows[i]["bitem"].ToString().Trim().Contains(mm))
                    {
                        dataGridView2.Rows.Add(g_dt2.Rows[i]["row_id"].ToString().Trim(), false, g_dt2.Rows[i]["a_code"].ToString().Trim(), g_dt2.Rows[i]["b_code"].ToString().Trim()
                        , g_dt2.Rows[i]["bitem"].ToString().Trim(), g_dt2.Rows[i]["per"].ToString().Trim(), g_dt2.Rows[i]["no"].ToString().Trim()
                        , g_dt2.Rows[i]["m_id"].ToString().Trim(), g_dt2.Rows[i]["tap"].ToString().Trim()
                        , g_dt2.Rows[i]["gong_n"].ToString().Trim(), g_dt2.Rows[i]["gong_s"].ToString().Trim(), i.ToString());
                    }
                }
            }
            dataGridView1.Rows[dataGridView1.CurrentCell.RowIndex].Selected = false;
            if (dataGridView2.RowCount != 0)
                dataGridView2.Rows[dataGridView2.CurrentCell.RowIndex].Selected = false;

            dataGridView3.Rows.Clear();
        }

        private void dataGridView1_CellValueChanged(object sender, DataGridViewCellEventArgs e)   //그리드1 수정
        {
            dataGridView1.CellValueChanged -= new DataGridViewCellEventHandler(dataGridView1_CellValueChanged);
            string cQuery = "";
            string dat = "";
            if (dataGridView1.CurrentCell.Value != null)
                dat = dataGridView1.CurrentCell.Value.ToString().Trim();
            //
            string row_no = dataGridView1.Rows[dataGridView1.CurrentRow.Index].Cells[0].Value.ToString().Trim();
            //
            if (e.ColumnIndex.Equals(2))
                cQuery = " update C_amodel set s_no='" + dat + "' where row_id='" + row_no + "'";
            else if (e.ColumnIndex.Equals(3))
                cQuery = " update C_amodel set gongjung='" + dat + "' where row_id='" + row_no + "'";
            else if (e.ColumnIndex.Equals(4))
                cQuery = " update C_amodel set a_code='" + dat + "' where row_id='" + row_no + "'";
            else if (e.ColumnIndex.Equals(5))
                cQuery = " update C_amodel set aitem='" + dat + "' where row_id='" + row_no + "'";
            else if (e.ColumnIndex.Equals(6))
                cQuery = " update C_amodel set company_code='" + dat + "' where row_id='" + row_no + "'";
            else
                return;
            var DBConn = new MySqlConnection(Config.DB_con1);
            DBConn.Open();
            var cmd = new MySqlCommand(cQuery, DBConn);
            if (cmd.ExecuteNonQuery() == 0)
                MessageBox.Show("서버 자료 수정에 실패 했습니다.");
            
            dataGridView1.CellValueChanged += new DataGridViewCellEventHandler(dataGridView1_CellValueChanged);
            DBConn.Close();
        }

        private void dataGridView2_CellValueChanged(object sender, DataGridViewCellEventArgs e)   //그리드2 수정
        {
            dataGridView2.CellValueChanged -= new DataGridViewCellEventHandler(dataGridView2_CellValueChanged);
            string cQuery = "";
            string dat = "";
            if(dataGridView2.CurrentCell.Value != null)
                dat = dataGridView2.CurrentCell.Value.ToString().Trim();
            int dtno = Convert.ToInt32(dataGridView2.Rows[dataGridView2.CurrentRow.Index].Cells[14].Value.ToString());
            string row_no = dataGridView2.Rows[dataGridView2.CurrentRow.Index].Cells[0].Value.ToString().Trim();
            if(e.ColumnIndex.Equals(3))
                cQuery = " update C_bmodel set b_code='" + dat + "' where row_id='" + row_no + "'";
            else if (e.ColumnIndex.Equals(4))
                cQuery = " update C_bmodel set bitem='" + dat + "' where row_id='" + row_no + "'";
            else if (e.ColumnIndex.Equals(5))
                cQuery = " update C_bmodel set per='" + dat + "' where row_id='" + row_no + "'";
            else if (e.ColumnIndex.Equals(6))
                cQuery = " update C_bmodel set no='" + dat + "' where row_id='" + row_no + "'";
            else if (e.ColumnIndex.Equals(7))
                cQuery = " update C_bmodel set gongjung='" + dat + "' where row_id='" + row_no + "'";
            else if (e.ColumnIndex.Equals(8))
                cQuery = " update C_bmodel set m_id='" + dat + "' where row_id='" + row_no + "'";
            else if (e.ColumnIndex.Equals(9))
                cQuery = " update C_bmodel set tap='" + dat + "' where row_id='" + row_no + "'";
            else if (e.ColumnIndex.Equals(10))
                cQuery = " update C_bmodel set gong_n='" + dat + "' where row_id='" + row_no + "'";
            else if (e.ColumnIndex.Equals(11))
                cQuery = " update C_bmodel set gong_s='" + dat + "' where row_id='" + row_no + "'";
            else if (e.ColumnIndex.Equals(12))
                cQuery = " update C_bmodel set gong_t='" + dat + "' where row_id='" + row_no + "'";
            else if (e.ColumnIndex.Equals(13))
                cQuery = " update C_bmodel set sub_m='" + dat + "' where row_id='" + row_no + "'";
            else if (e.ColumnIndex.Equals(15))
                cQuery = " update C_bmodel set go='" + dat + "' where row_id='" + row_no + "'";
            else if (e.ColumnIndex.Equals(16))
                cQuery = " update C_bmodel set hsearch_code='" + dat + "' where row_id='" + row_no + "'";
            else if (e.ColumnIndex.Equals(17))
                cQuery = " update C_bmodel set view_code='" + dat + "' where row_id='" + row_no + "'";
            else if (e.ColumnIndex.Equals(18))
            {
                if (dat == "0" || dat == "1" || dat == "2")
                    cQuery = " update C_bmodel set julsu_id='" + dat + "' where row_id='" + row_no + "'";
                else
                {
                    MessageBox.Show("숫자 '0,1,2' 만 입력해 주십시요.");
                    dataGridView2.CellValueChanged += new DataGridViewCellEventHandler(dataGridView2_CellValueChanged);
                    return;
                }
            }
            else
            {
                dataGridView2.CellValueChanged += new DataGridViewCellEventHandler(dataGridView2_CellValueChanged);
                return;
            }
            var DBConn = new MySqlConnection(Config.DB_con1);
            DBConn.Open();
            var cmd = new MySqlCommand(cQuery, DBConn);
            if (cmd.ExecuteNonQuery() == 0)
                MessageBox.Show("서버 자료 수정에 실패 했습니다.");
            else
            {
                if (e.ColumnIndex==16)
                    g_dt2.Rows[dtno][e.ColumnIndex - 2] = dat;
                else if (e.ColumnIndex == 17)
                    g_dt2.Rows[dtno][e.ColumnIndex - 2] = dat;
                else if (e.ColumnIndex == 18)
                    g_dt2.Rows[dtno][e.ColumnIndex - 2] = dat;
                else
                    g_dt2.Rows[dtno][e.ColumnIndex-1] = dat;
                //
            }
            dataGridView2.CellValueChanged += new DataGridViewCellEventHandler(dataGridView2_CellValueChanged);
            DBConn.Close();
        }

        private void dataGridView3_CellValueChanged(object sender, DataGridViewCellEventArgs e)   //그리드3 수정
        {
            dataGridView3.CellValueChanged -= new DataGridViewCellEventHandler(dataGridView3_CellValueChanged);
            string cQuery = "";
            int dtno = Convert.ToInt32(dataGridView3.Rows[dataGridView3.CurrentRow.Index].Cells[15].Value.ToString());
            int c_no = 0;
            string dat = "";
            if (dataGridView3.CurrentCell.Value != null)
                dat = dataGridView3.CurrentCell.Value.ToString().Trim();
            string row_no = dataGridView3.Rows[dataGridView3.CurrentRow.Index].Cells[0].Value.ToString().Trim();
            // 
            if (e.ColumnIndex.Equals(4))
            {
                c_no = 3;
                cQuery = " update C_cmodel set c_code='" + dat + "' where row_id='" + row_no + "'";
            }
            else if (e.ColumnIndex.Equals(5))
            {
                c_no = 8;
                cQuery = " update C_cmodel set eng='" + dat + "' where row_id='" + row_no + "'";
            }
            else if (e.ColumnIndex.Equals(6))
            {
                c_no = 4;
                cQuery = " update C_cmodel set citem='" + dat + "' where row_id='" + row_no + "'";
            }
            else if (e.ColumnIndex.Equals(7))
            {
                c_no = 5;
                cQuery = " update C_cmodel set yubun='" + dat + "' where row_id='" + row_no + "'";
            }
            else if (e.ColumnIndex.Equals(8))
            {
                c_no = 6;
                cQuery = " update C_cmodel set act='" + dat + "' where row_id='" + row_no + "'";
            }
            //else if (e.ColumnIndex.Equals(9))  //버튼이라 주석처리. 필요없음
            //{
            //    c_no = 7;
            //    cQuery = " update C_cmodel set x_code='" + dat + "' where row_id='" + row_no + "'";
            //}
            else if (e.ColumnIndex.Equals(10))
            {
                c_no = 9;
                cQuery = " update C_cmodel set weight='" + dat + "' where row_id='" + row_no + "'";
            }
            else if (e.ColumnIndex.Equals(11))
            {
                c_no = 10;
                cQuery = " update C_cmodel set depth='" + dat + "' where row_id='" + row_no + "'";
            }
            else if (e.ColumnIndex.Equals(12))
            {
                c_no = 11;
                cQuery = " update C_cmodel set jubji='" + dat + "' where row_id='" + row_no + "'";
            }
            else if (e.ColumnIndex.Equals(16))
            {
                c_no = 13;
                cQuery = " update C_cmodel set go='" + dat + "' where row_id='" + row_no + "'";
            }
            else if (e.ColumnIndex.Equals(17))
            {
                c_no = 14;
                cQuery = " update C_cmodel set no='" + dat + "' where row_id='" + row_no + "'";
            }
            else if (e.ColumnIndex.Equals(18))
            {
                c_no = 15;
                cQuery = " update C_cmodel set gongjung='" + dat + "' where row_id='" + row_no + "'";
            }
            else if (e.ColumnIndex.Equals(19))
            {
                c_no = 16;
                cQuery = " update C_cmodel set g_group='" + dat + "' where row_id='" + row_no + "'";
            }
            else if (e.ColumnIndex.Equals(20))
            {
                c_no = 17;
                cQuery = " update C_cmodel set add_item='" + dat + "' where row_id='" + row_no + "'";
            }
            else if (e.ColumnIndex.Equals(21))
            {
                c_no = 18;
                cQuery = " update C_cmodel set ban='" + dat + "' where row_id='" + row_no + "'";
            }
            else if (e.ColumnIndex.Equals(22))
            {
                c_no = 19;
                if (dat.ToString() == "True")
                    cQuery = " update C_cmodel set attach_id='1' where row_id='" + row_no + "'";
                else
                    cQuery = " update C_cmodel set attach_id='0' where row_id='" + row_no + "'";
            }
            else if (e.ColumnIndex.Equals(23))
            {
                c_no = 20;
                cQuery = " update C_cmodel set c_tap='" + dat + "' where row_id='" + row_no + "'";
            }
            else if (e.ColumnIndex.Equals(24))
            {
                c_no = 21;
                cQuery = " update C_cmodel set yoyul='" + dat + "' where row_id='" + row_no + "'";
            }
            else if (e.ColumnIndex.Equals(25))
            {
                c_no = 22;
                cQuery = " update C_cmodel set julsa='" + dat + "' where row_id='" + row_no + "'";
            }
            else if (e.ColumnIndex.Equals(26))
            {
                c_no = 23;
                cQuery = " update C_cmodel set hap_code='" + dat + "' where row_id='" + row_no + "'";
            }
            else if (e.ColumnIndex.Equals(27))
            {
                c_no = 24;
                cQuery = " update C_cmodel set hap_item='" + dat + "' where row_id='" + row_no + "'";
            }
            else if (e.ColumnIndex.Equals(28))
            {
                c_no = 25;
                cQuery = " update C_cmodel set hap_unit='" + dat + "' where row_id='" + row_no + "'";
            }
            else if (e.ColumnIndex.Equals(29))
            {
                c_no = 26;
                cQuery = " update C_cmodel set douzone_code='" + dat + "' where row_id='" + row_no + "'";
            }
            else
                return;
            var DBConn = new MySqlConnection(Config.DB_con1);
            DBConn.Open();
            var cmd = new MySqlCommand(cQuery, DBConn);
            if (cmd.ExecuteNonQuery() == 0)
                MessageBox.Show("서버 자료 수정에 실패 했습니다.");
            else
                g_dt3.Rows[dtno][c_no] = dat;

            dataGridView3.CellValueChanged += new DataGridViewCellEventHandler(dataGridView3_CellValueChanged);
            DBConn.Close();

        }

        private void button8_Click(object sender, EventArgs e)  //그리드1 삭제
        {
            dataGridView1.CellValueChanged -= new DataGridViewCellEventHandler(dataGridView1_CellValueChanged);
            string[] sd = new string[dataGridView1.RowCount];//
            for (int i = 0; i < sd.Length; i++)
            {
                sd[i] = "0";
            }
            //
            int s = 0;
            for (int i = 0; i < dataGridView1.RowCount; i++)
            {
                if (dataGridView1.Rows[i].Cells[1].Value.Equals(true))
                {
                    sd[s] = dataGridView1.Rows[i].Cells[0].Value.ToString().Trim();
                    s++;
                }
            }
            //
            for (int i = 0; i < sd.Length; i++)
            {
                if (sd[i].Equals("0"))
                    break;
                else
                {
                    string row_no = sd[i];
                    string cQuery = " delete from C_amodel where row_id='" + row_no + "'";
                    var DBConn = new MySqlConnection(Config.DB_con1);
                    DBConn.Open();
                    var cmd = new MySqlCommand(cQuery, DBConn);
                    if (cmd.ExecuteNonQuery() == 0)
                    {
                        MessageBox.Show("서버 자료 삭제에 실패 했습니다.");
                        DBConn.Close();
                        break;
                    }
                    DBConn.Close();
                }
            }
            //
            for (int i = 0; i < sd.Length; i++)
            {
                if (sd[i].Equals("0"))
                    break;
                else
                {
                    for (s = 0; s < dataGridView1.RowCount; s++)
                    {
                        if (dataGridView1.Rows[s].Cells[0].Value.ToString().Trim().Equals(sd[i]))
                            dataGridView1.Rows.Remove(dataGridView1.Rows[s]);
                    }
                }
            }
            dataGridView1.CellValueChanged += new DataGridViewCellEventHandler(dataGridView1_CellValueChanged);
        }

        private void button7_Click(object sender, EventArgs e)  //그리드1 추가
        {
            dataGridView1.CellValueChanged -= new DataGridViewCellEventHandler(dataGridView1_CellValueChanged);
            //
            string ac = dataGridView1.Rows[dataGridView1.CurrentCell.RowIndex].Cells[4].Value.ToString().Trim();
            string cQuery = "";
            cQuery = " insert into C_amodel(s_no,a_code) select max(s_no)+1,'00' from C_amodel";
            var DBConn = new MySqlConnection(Config.DB_con1);
            DBConn.Open();
            var cmd = new MySqlCommand(cQuery, DBConn);
            if (cmd.ExecuteNonQuery() == 0)
            {
                MessageBox.Show("서버 자료 등록에 실패 했습니다.");
                DBConn.Close();
                return;
            }
            else
            {
                dataGridView1.Rows.Clear();
                cQuery = " select count(*) from C_amodel";
                cmd = new MySqlCommand(cQuery, DBConn);
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
                    dataGridView1.Rows[m].Cells[0].Value = myRead["row_id"].ToString();
                    dataGridView1.Rows[m].Cells[1].Value = false;
                    dataGridView1.Rows[m].Cells[2].Value = myRead["s_no"].ToString();
                    dataGridView1.Rows[m].Cells[3].Value = myRead["gongjung"].ToString();
                    dataGridView1.Rows[m].Cells[4].Value = myRead["a_code"].ToString();
                    dataGridView1.Rows[m].Cells[5].Value = myRead["aitem"].ToString();
                    dataGridView1.Rows[m].Cells[6].Value = myRead["company_code"].ToString();
                    m++;
                }
                myRead.Close();
                DBConn.Close();
                dataGridView1.CurrentCell = dataGridView1.Rows[m-1].Cells[2];//크스옮기기
                dataGridView1.Focus();
            }
            dataGridView1.CellValueChanged += new DataGridViewCellEventHandler(dataGridView1_CellValueChanged);
        }

        private void button6_Click(object sender, EventArgs e)  //그리드2 삭제
        {
            if (!dataGridView2.RowCount.Equals(0))
            {
                dataGridView2.CellValueChanged -= new DataGridViewCellEventHandler(dataGridView2_CellValueChanged);
                bool x_id = false;
                string r_no = "";
                string cQuery = "";
                var DBConn = new MySqlConnection(Config.DB_con1);
                DBConn.Open();
                for (int i = 0; i < dataGridView2.RowCount; i++)
                {
                    if (dataGridView2.Rows[i].Cells[1].Value.Equals(true))
                    {
                        x_id = true;
                        r_no = dataGridView2.Rows[i].Cells[0].Value.ToString().Trim();
                        cQuery = " delete from C_bmodel where row_id='" + r_no + "'";
                        var cmd = new MySqlCommand(cQuery, DBConn);
                        if (cmd.ExecuteNonQuery() == 0)
                        {
                            MessageBox.Show("서버 자료 샥제에 실패 했습니다.");
                            DBConn.Close();
                            return;
                        }
                    }
                }
                //                  
                if (x_id)
                {
                    g_dt2_mk();
                    dgv2_mk();
                }
                dataGridView2.CellValueChanged += new DataGridViewCellEventHandler(dataGridView2_CellValueChanged);
                DBConn.Close();
            }
        }

        private void button2_Click(object sender, EventArgs e)  //그리드2 추가
        {
            dataGridView2.CellValueChanged -= new DataGridViewCellEventHandler(dataGridView2_CellValueChanged);
            //
            string ac = dataGridView1.Rows[dataGridView1.CurrentCell.RowIndex].Cells[4].Value.ToString().Trim();
            string cQuery = "";
            cQuery = " insert into C_bmodel(a_code) values('" + ac + "')";
            var DBConn = new MySqlConnection(Config.DB_con1);
            DBConn.Open();
            var cmd = new MySqlCommand(cQuery, DBConn);
            if (cmd.ExecuteNonQuery() == 0)
            {
                MessageBox.Show("서버 자료 등록에 실패 했습니다.");
                DBConn.Close();
                return;
            }
            else
            {
                g_dt2_mk();
                dgv2_mk();
            }
            DBConn.Close();
            dataGridView2.CellValueChanged += new DataGridViewCellEventHandler(dataGridView2_CellValueChanged);
        }

        private void button4_Click(object sender, EventArgs e)  //그리드3 삭제
        {
            if (!dataGridView3.RowCount.Equals(0))
            {
                dataGridView3.CellValueChanged -= new DataGridViewCellEventHandler(dataGridView3_CellValueChanged);
                bool x_id = false;
                string r_no = "";
                string cQuery = "";
                var DBConn = new MySqlConnection(Config.DB_con1);
                DBConn.Open();
                for (int i = 0; i < dataGridView3.RowCount; i++)
                {
                    if (dataGridView3.Rows[i].Cells[1].Value.Equals(true))
                    {
                        x_id = true;
                        r_no = dataGridView3.Rows[i].Cells[0].Value.ToString().Trim();
                        cQuery = " delete from C_cmodel where row_id='"+ r_no + "'";
                        var cmd = new MySqlCommand(cQuery, DBConn);
                        if (cmd.ExecuteNonQuery() == 0)
                        {
                            MessageBox.Show("서버 자료 샥제에 실패 했습니다.");
                            DBConn.Close();
                            return;
                        }
                    }
                }
                //                  
                if (x_id)
                {
                    g_dt3_mk();
                    dgv3_mk();
                }
                DBConn.Close();
                dataGridView3.CellValueChanged += new DataGridViewCellEventHandler(dataGridView3_CellValueChanged);
            }
        }

        private void button3_Click(object sender, EventArgs e)  //그리드3 추가
        {
            if (!dataGridView2.RowCount.Equals(0))
            {
                dataGridView3.CellValueChanged -= new DataGridViewCellEventHandler(dataGridView3_CellValueChanged);
                //
                string ac = dataGridView2.Rows[dataGridView2.CurrentCell.RowIndex].Cells[2].Value.ToString().Trim();
                string bc = dataGridView2.Rows[dataGridView2.CurrentCell.RowIndex].Cells[3].Value.ToString().Trim();
                string cQuery = "";
                cQuery = " insert into C_cmodel(a_code,b_code) values('" + ac + "','" + bc + "')";
                var DBConn = new MySqlConnection(Config.DB_con1);
                DBConn.Open();
                var cmd = new MySqlCommand(cQuery, DBConn);
                if (cmd.ExecuteNonQuery() == 0)
                {
                    MessageBox.Show("서버 자료 등록에 실패 했습니다.");
                    DBConn.Close();
                    return;
                }
                else
                {
                    g_dt3_mk();
                    dgv3_mk();
                }
                DBConn.Close();
                dataGridView3.CellValueChanged += new DataGridViewCellEventHandler(dataGridView3_CellValueChanged);
            }
            else
            {
                MessageBox.Show("중분류 항목을 선택해 주세요");
            }
        }

        private void dataGridView1_MouseClick(object sender, MouseEventArgs e)  //그리드1에서 마우스 클릭
        {
            if (dataGridView1.CurrentCell.ColumnIndex.Equals(5))
            {
                dgv2_mk();
            }
        }
        
        private void dataGridView2_MouseClick(object sender, MouseEventArgs e)  //그리드2에서 마우스 클릭
        {
            if (dataGridView2.CurrentCell == null)
                return;
            if (dataGridView2.CurrentCell.ColumnIndex.Equals(4))
            {
                dgv3_mk();
            }
        }

        private void dataGridView3_MouseClick(object sender, MouseEventArgs e)  //그리드3에서 마우스 클릭시
        {
            if (dataGridView3.CurrentCell == null)
                return;

            dataGridView3.CellValueChanged -= new DataGridViewCellEventHandler(dataGridView3_CellValueChanged);
            string row_no = dataGridView3.Rows[dataGridView3.CurrentCell.RowIndex].Cells[0].Value.ToString();
            OhFTP Ftp = new OhFTP(Config.Ftp_ip1, Config.Ftp_id1, Config.Ftp_pw1);
            var DBConn = new MySqlConnection(Config.DB_con1);
            DBConn.Open(); 
            //
            if (dataGridView3.CurrentCell.ColumnIndex.Equals(9))
            {
                int mdt = 0;
                if (!dataGridView3.Rows[dataGridView3.CurrentCell.RowIndex].Cells[9].Value.Equals(""))
                    mdt = Convert.ToInt32(dataGridView3.Rows[dataGridView3.CurrentCell.RowIndex].Cells[9].Value.ToString());
                //
                Form_204 Frm = new Form_204(mdt);
                if (Frm.ShowDialog() == DialogResult.OK)
                {
                    string dat = Frm.xcc;
                    string cQuery = " update C_cmodel set x_code='" + dat + "' where row_id='" + row_no + "'";
                    var cmd = new MySqlCommand(cQuery, DBConn);
                    if (cmd.ExecuteNonQuery() == 0)
                    {
                        MessageBox.Show("서버 자료 등록에 실패 했습니다.");
                        DBConn.Close();
                        return;
                    }
                    else
                    {
                        MessageBox.Show("수정 되었습니다.");
                        dataGridView3.Rows[dataGridView3.CurrentCell.RowIndex].Cells[9].Value = Frm.normal_code;
                        g_dt3_mk();
                        //int dtno = Convert.ToInt32(dataGridView3.Rows[dataGridView3.CurrentCell.RowIndex].Cells[16].Value.ToString()); //여기에서 애라발생
                        //g_dt3.Rows[dtno][7] = Frm.normal_code;
                    }
                }
            }
            else if(dataGridView3.CurrentCell.ColumnIndex.Equals(13))
            {
                string grim = dataGridView3.Rows[dataGridView3.CurrentCell.RowIndex].Cells[14].Value.ToString().Trim();
                if (grim.Equals(""))
                {
                    OpenFileDialog ofd = new OpenFileDialog();//파일열기
                    ofd.DefaultExt = "*.*"; //기본 확장자 설정
                    ofd.Filter = "ALL File(*.*)|*.*";
                    ofd.FilterIndex = 1; //기본으로 선택되는 파일 유형 설정 2로하면 모든파일이 선택됨
                    ofd.Multiselect = false;// true;
                    ofd.InitialDirectory = "C:\\";
                    ofd.RestoreDirectory = true;
                    //
                    if (ofd.ShowDialog() == DialogResult.OK)
                    {
                        string ff1 = ofd.FileName;
                        string ff2 = row_no + "-gong.";
                        ff2 += ofd.FileName.Substring(ofd.FileName.LastIndexOf(".") + 1, ofd.FileName.Length - ofd.FileName.LastIndexOf(".") - 1);
                        Ftp.UpLoadFile(ff1, ff2, "C_cmodel");
                        //
                        string cQuery = " update C_cmodel set file='" + ff2 + "' where row_id='" + row_no + "'";
                        var cmd = new MySqlCommand(cQuery, DBConn);
                        if (cmd.ExecuteNonQuery() == 0)
                            MessageBox.Show("서버 등록에 실패 했습니다.");
                        DBConn.Close();
                        dataGridView3.Rows[dataGridView3.CurrentCell.RowIndex].Cells[14].Value = ff2;
                        dataGridView3.Rows[dataGridView3.CurrentCell.RowIndex].Cells[13].Value = "**";
                    }
                }
                else                         //그림파일 보기
                {
                    Ftp.ViewLoadFile(grim, "C_cmodel");  //서버에 있는 파일보기
                }

            }
            DBConn.Close();
            dataGridView3.CellValueChanged += new DataGridViewCellEventHandler(dataGridView3_CellValueChanged);
        }

        private void g_dt2_mk()  //테이블2 만들기
        {
            var DBConn = new MySqlConnection(Config.DB_con1);
            DBConn.Open();
            g_dt2.Rows.Clear();
            if (g_dt2.Columns.Count == 0)
            {
                g_dt2.Columns.Add("row_id", typeof(string));
                g_dt2.Columns.Add("a_code", typeof(string));
                g_dt2.Columns.Add("b_code", typeof(string));
                g_dt2.Columns.Add("bitem", typeof(string));
                g_dt2.Columns.Add("per", typeof(string));
                g_dt2.Columns.Add("no", typeof(string));
                g_dt2.Columns.Add("gongjung", typeof(string));
                g_dt2.Columns.Add("m_id", typeof(string));
                g_dt2.Columns.Add("tap", typeof(string));
                g_dt2.Columns.Add("gong_n", typeof(string));
                g_dt2.Columns.Add("gong_s", typeof(string));
                g_dt2.Columns.Add("gong_t", typeof(string));
                g_dt2.Columns.Add("sub_m", typeof(string));
                g_dt2.Columns.Add("go", typeof(string));
                g_dt2.Columns.Add("hsearch_code", typeof(string));
                g_dt2.Columns.Add("view_code", typeof(string));
                g_dt2.Columns.Add("julsu_id", typeof(string));
            }
            //
            string cQuery = " select * FROM C_bmodel order by a_code,b_code";
            var cmd = new MySqlCommand(cQuery, DBConn);
            var myRead = cmd.ExecuteReader();
            while (myRead.Read())
            {
                g_dt2.Rows.Add(new object[] { myRead["row_id"].ToString(),myRead["a_code"].ToString(),myRead["b_code"].ToString()
                ,myRead["bitem"].ToString(),myRead["per"].ToString(), for_sort_no(myRead["no"].ToString()),myRead["gongjung"].ToString(), myRead["m_id"].ToString()
                ,myRead["tap"].ToString(),myRead["gong_n"].ToString(),myRead["gong_s"].ToString(),myRead["gong_t"].ToString()
                ,myRead["sub_m"].ToString(),myRead["go"].ToString(),myRead["hsearch_code"].ToString(),myRead["view_code"].ToString(),myRead["julsu_id"].ToString()});
            }
            myRead.Close();
            DBConn.Close();
        }

        private string for_sort_no(string no)
        {
            string result = no;
            if (no.Length < 2)
            {
                result = "0" + no;
            }
            return result;
        }

        private void g_dt3_mk()  //테이블3 만들기
        {
            var DBConn = new MySqlConnection(Config.DB_con1);
            DBConn.Open();
            g_dt3.Rows.Clear();
            if (g_dt3.Columns.Count == 0)
            {
                g_dt3.Columns.Add("row_id", typeof(string));  //0
                g_dt3.Columns.Add("a_code", typeof(string));
                g_dt3.Columns.Add("b_code", typeof(string));
                g_dt3.Columns.Add("c_code", typeof(string));
                g_dt3.Columns.Add("citem", typeof(string));
                g_dt3.Columns.Add("yubun", typeof(string));
                g_dt3.Columns.Add("act", typeof(string));
                g_dt3.Columns.Add("x_code", typeof(string));
                g_dt3.Columns.Add("eng", typeof(string));
                g_dt3.Columns.Add("weight", typeof(string));
                g_dt3.Columns.Add("depth", typeof(string));
                g_dt3.Columns.Add("jubji", typeof(string));
                g_dt3.Columns.Add("file", typeof(string));
                g_dt3.Columns.Add("go", typeof(string));
                g_dt3.Columns.Add("no", typeof(string));
                g_dt3.Columns.Add("gongjung", typeof(string));
                g_dt3.Columns.Add("g_group", typeof(string));
                g_dt3.Columns.Add("add_item", typeof(string));
                g_dt3.Columns.Add("ban", typeof(string));
                g_dt3.Columns.Add("attach_id", typeof(string));  //19
                g_dt3.Columns.Add("c_tap", typeof(string));      //20
                g_dt3.Columns.Add("yoyul", typeof(string));      //21
                g_dt3.Columns.Add("julsa", typeof(string));      //22
                g_dt3.Columns.Add("hap_code", typeof(string));   //23
                g_dt3.Columns.Add("hap_item", typeof(string));   //24
                g_dt3.Columns.Add("hap_unit", typeof(string));   //25
                g_dt3.Columns.Add("douzone_code", typeof(string));   //26
            }
            //
            string cQuery = " select a.*, b.code_id FROM C_cmodel as a Left Outer join C_dtable as b on a.x_code=b.row_id";
            var cmd = new MySqlCommand(cQuery, DBConn);
            var myRead = cmd.ExecuteReader();
            while (myRead.Read())
            {
                g_dt3.Rows.Add(new string[] { myRead["row_id"].ToString(),myRead["a_code"].ToString(),myRead["b_code"].ToString(),myRead["c_code"].ToString()
                ,myRead["citem"].ToString(),myRead["yubun"].ToString(),myRead["act"].ToString(),myRead["code_id"].ToString()
                ,myRead["eng"].ToString(),myRead["weight"].ToString(),myRead["depth"].ToString(),myRead["jubji"].ToString(),myRead["file"].ToString()
                ,myRead["go"].ToString(),for_sort_no(myRead["no"].ToString()),myRead["gongjung"].ToString(), myRead["g_group"].ToString()
                ,myRead["add_item"].ToString(), myRead["ban"].ToString(), myRead["attach_id"].ToString(), myRead["c_tap"].ToString(), myRead["yoyul"].ToString()
                ,myRead["julsa"].ToString(),myRead["hap_code"].ToString(),myRead["hap_item"].ToString(),myRead["hap_unit"].ToString(),myRead["douzone_code"].ToString()});
            }
            myRead.Close();
            DBConn.Close();
        }

        private void dgv2_mk()  //그리드2 만들기
        {
            dataGridView2.Rows.Clear();
            string item1 = dataGridView1.Rows[dataGridView1.CurrentRow.Index].Cells[4].Value.ToString().Trim();  //a_code
            for (int i = 0; i < g_dt2.Rows.Count; i++)
            {
                if (g_dt2.Rows[i]["a_code"].ToString().Trim().Equals(item1))
                {
                    dataGridView2.Rows.Add(g_dt2.Rows[i]["row_id"].ToString().Trim(), false, g_dt2.Rows[i]["a_code"].ToString().Trim(), g_dt2.Rows[i]["b_code"].ToString().Trim()
                    , g_dt2.Rows[i]["bitem"].ToString().Trim(), g_dt2.Rows[i]["per"].ToString().Trim(), g_dt2.Rows[i]["no"].ToString().Trim(), g_dt2.Rows[i]["gongjung"].ToString().Trim()
                    , g_dt2.Rows[i]["m_id"].ToString().Trim(), g_dt2.Rows[i]["tap"].ToString().Trim()
                    , g_dt2.Rows[i]["gong_n"].ToString().Trim(), g_dt2.Rows[i]["gong_s"].ToString().Trim()
                    , g_dt2.Rows[i]["gong_t"].ToString().Trim(), g_dt2.Rows[i]["sub_m"].ToString().Trim(),i.ToString(),g_dt2.Rows[i]["go"].ToString()
                    , g_dt2.Rows[i]["hsearch_code"].ToString(), g_dt2.Rows[i]["view_code"].ToString(), g_dt2.Rows[i]["julsu_id"].ToString());
                }
            }
            if (dataGridView2.RowCount != 0)
            {
                dataGridView2.Rows[dataGridView2.CurrentCell.RowIndex].Selected = false;
                dataGridView3.Rows.Clear();
            }
        }

        private void dgv3_mk()  //그리드3 만들기
        {
            dataGridView3.Rows.Clear();
            string item1 = dataGridView2.Rows[dataGridView2.CurrentRow.Index].Cells[2].Value.ToString().Trim();  //a_code
            string item2 = dataGridView2.Rows[dataGridView2.CurrentRow.Index].Cells[3].Value.ToString().Trim();  //b_code
            string xnam = "";
            for (int i = 0; i < g_dt3.Rows.Count; i++)
            {
                if (g_dt3.Rows[i]["a_code"].ToString().Trim().Equals(item1) && g_dt3.Rows[i]["b_code"].ToString().Trim().Equals(item2))
                {
                    if (g_dt3.Rows[i]["file"].ToString().Equals(""))
                        xnam = "";
                    else
                        xnam = "**";
                    //
                    dataGridView3.Rows.Add(g_dt3.Rows[i]["row_id"].ToString().Trim(), false, g_dt3.Rows[i]["a_code"].ToString().Trim(), g_dt3.Rows[i]["b_code"].ToString().Trim()
                    , g_dt3.Rows[i]["c_code"].ToString().Trim(), g_dt3.Rows[i]["eng"].ToString().Trim(), g_dt3.Rows[i]["citem"].ToString().Trim()
                    , g_dt3.Rows[i]["yubun"].ToString().Trim(), g_dt3.Rows[i]["act"].ToString().Trim(), g_dt3.Rows[i]["x_code"].ToString().Trim()
                    , g_dt3.Rows[i]["weight"].ToString().Trim(), g_dt3.Rows[i]["depth"].ToString().Trim()
                    , g_dt3.Rows[i]["jubji"].ToString().Trim(),xnam,g_dt3.Rows[i]["file"].ToString().Trim(),i.ToString(),g_dt3.Rows[i]["go"].ToString()
                    , g_dt3.Rows[i]["no"].ToString(), g_dt3.Rows[i]["gongjung"].ToString(), g_dt3.Rows[i]["g_group"].ToString(), g_dt3.Rows[i]["add_item"].ToString()
                    , g_dt3.Rows[i]["ban"].ToString(), Convert.ToBoolean(g_dt3.Rows[i]["attach_id"].ToString()),g_dt3.Rows[i]["c_tap"].ToString(),g_dt3.Rows[i]["yoyul"].ToString()
                    , g_dt3.Rows[i]["julsa"].ToString(), g_dt3.Rows[i]["hap_code"].ToString(), g_dt3.Rows[i]["hap_item"].ToString(), g_dt3.Rows[i]["hap_unit"].ToString(), g_dt3.Rows[i]["douzone_code"].ToString());
                }
            }
            if (dataGridView3.RowCount != 0)
                dataGridView3.Rows[dataGridView3.CurrentCell.RowIndex].Selected = false;
        }

        private void button9_Click(object sender, EventArgs e) //영문코드보기 
        {
            dataGridView3.Rows.Clear();
            string xnam = "";
            for (int i = 0; i < g_dt3.Rows.Count; i++)
            {
                if (!g_dt3.Rows[i]["eng"].ToString().Equals(""))
                {
                    if (g_dt3.Rows[i]["file"].ToString().Equals(""))
                        xnam = "";
                    else
                        xnam = "**";
                    //
                    dataGridView3.Rows.Add(g_dt3.Rows[i]["row_id"].ToString().Trim(), false, g_dt3.Rows[i]["a_code"].ToString().Trim(), g_dt3.Rows[i]["b_code"].ToString().Trim()
                    , g_dt3.Rows[i]["c_code"].ToString().Trim(), g_dt3.Rows[i]["eng"].ToString().Trim(), g_dt3.Rows[i]["citem"].ToString().Trim()
                    , g_dt3.Rows[i]["yubun"].ToString().Trim(), g_dt3.Rows[i]["act"].ToString().Trim(), g_dt3.Rows[i]["x_code"].ToString().Trim()
                    , g_dt3.Rows[i]["weight"].ToString().Trim(), g_dt3.Rows[i]["depth"].ToString().Trim()
                    , g_dt3.Rows[i]["jubji"].ToString().Trim(), xnam, g_dt3.Rows[i]["file"].ToString().Trim(), i.ToString(), g_dt3.Rows[i]["go"].ToString()
                    , g_dt3.Rows[i]["no"].ToString().Trim(), g_dt3.Rows[i]["gongjung"].ToString().Trim(), g_dt3.Rows[i]["g_group"].ToString().Trim(), g_dt3.Rows[i]["add_item"].ToString().Trim(), g_dt3.Rows[i]["ban"].ToString());
                }
            }
            if (dataGridView2.RowCount != 0)
                dataGridView2.Rows[dataGridView2.CurrentCell.RowIndex].Selected = false;

        }

        private void dataGridView1_Leave(object sender, EventArgs e)
        {
            dataGridView1.Rows[dataGridView1.CurrentCell.RowIndex].Selected = false;

        }

        private void dataGridView2_Leave(object sender, EventArgs e)
        {
            if (dataGridView2.CurrentCell == null)
                return;
            dataGridView2.Rows[dataGridView2.CurrentCell.RowIndex].Selected = false;

        }

        private void dataGridView3_Leave(object sender, EventArgs e)
        {
            if (dataGridView3.CurrentCell == null) 
                return;
            dataGridView3.Rows[dataGridView3.CurrentCell.RowIndex].Selected = false;

        }

        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button10_Click(object sender, EventArgs e)  //all-refresh
        {
            dataGridView1.CellValueChanged -= new DataGridViewCellEventHandler(dataGridView1_CellValueChanged);
            dataGridView2.CellValueChanged -= new DataGridViewCellEventHandler(dataGridView2_CellValueChanged);
            dataGridView3.CellValueChanged -= new DataGridViewCellEventHandler(dataGridView3_CellValueChanged);
            //             
            dataGridView1.Rows.Clear();
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
            cQuery = " select * FROM C_amodel order by s_no";
            cmd = new MySqlCommand(cQuery, DBConn);
            myRead = cmd.ExecuteReader();
            int m = 0;
            while (myRead.Read())
            {
                dataGridView1.Rows[m].Cells[0].Value = myRead["row_id"].ToString();
                dataGridView1.Rows[m].Cells[1].Value = false;
                dataGridView1.Rows[m].Cells[2].Value = myRead["s_no"].ToString();
                dataGridView1.Rows[m].Cells[3].Value = myRead["gongjung"].ToString();
                dataGridView1.Rows[m].Cells[4].Value = myRead["a_code"].ToString();
                dataGridView1.Rows[m].Cells[5].Value = myRead["aitem"].ToString();
                dataGridView1.Rows[m].Cells[6].Value = myRead["company_code"].ToString();
                m++;
            }
            myRead.Close();
            DBConn.Close();
            //
            g_dt2_mk();
            g_dt3_mk();
            //
            dataGridView2.Rows.Clear();
            dataGridView3.Rows.Clear();
            //
            dataGridView1.CellValueChanged += new DataGridViewCellEventHandler(dataGridView1_CellValueChanged);
            dataGridView2.CellValueChanged += new DataGridViewCellEventHandler(dataGridView2_CellValueChanged);
            dataGridView3.CellValueChanged += new DataGridViewCellEventHandler(dataGridView3_CellValueChanged);
        }

        private void Form_203_ClientSizeChanged(object sender, EventArgs e)
        {
            //splitContainer1.Size = new Size(this.Size.Width - 247, this.Size.Height - 162);
            //splitContainer1.Refresh();

            //dataGridView1.Size = new Size(dataGridView1.Width, this.Size.Height - 162);
            //dataGridView1.Refresh();
        }

        private void button11_Click(object sender, EventArgs e)
        {
            if (button11.Text == "업체코드")
            {
                button11.Text = "닫기";
                this.richTextBox1.Size = new System.Drawing.Size(180, 340);
                richTextBox1.Visible = true;
                //
                if (richTextBox1.Text == "")
                {
                    var DBConn = new MySqlConnection(Config.DB_con3);
                    DBConn.Open();
                    string cQuery = " select company_name, company_code from company_list order by db_1";
                    var cmd = new MySqlCommand(cQuery, DBConn);
                    var myRead = cmd.ExecuteReader();
                    string ttt = "\r\n";
                    while (myRead.Read())
                        ttt += "　" + myRead["company_name"].ToString() + "　=　" + myRead["company_code"].ToString() + "\r\n";
                    //
                    richTextBox1.Text = ttt;
                    myRead.Close();
                }
            }
            else
            {
                button11.Text = "업체코드";
                this.richTextBox1.Size = new System.Drawing.Size(180, 12);
                richTextBox1.Visible = false;

            }
        }
        // 
    }

}
