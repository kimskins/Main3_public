using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using System.Drawing.Printing;
using System.Drawing.Drawing2D;

namespace Dukyou3
{
    public partial class Form_302 : Form
    {

        public Form_302()
        {
            InitializeComponent();
        }
         
        private void Form_dat2_Load(object sender, EventArgs e)
        {
            List<string> citem1 = new List<string>{ };
            Screen srn = Screen.PrimaryScreen;
            int Xb = this.Width;  //좌,우
            this.Location = new Point((srn.Bounds.Width - Xb) / 2, 1);  //좌/우,위/아래
            //
            string cQuery = "select distinct(sangho) as a from C_boxs as a left outer join C_hcustomer as b on a.hcust_id = b.row_id";
            var DBConn = new MySqlConnection(Config.DB_con1);
            DBConn.Open();
            var cmd = new MySqlCommand(cQuery, DBConn);
            var myRead = cmd.ExecuteReader();
            while (myRead.Read())
            {
                citem1.Add(myRead["a"].ToString());
            }
            myRead.Close();
            // 각 콤보박스에 데이타를 초기화
            int ct = citem1.Count();
            string[] dat1 = new string[ct];
            for (int n = 0; n < ct; n++)
            {
                dat1[n] = citem1[n];
            }
            comboBox1.Items.AddRange(dat1);
            string[] dat2 = { "DW", "SW", "B골", "E골" };
            comboBox2.Items.AddRange(dat2);
            //            
            dataGridView1.CellValueChanged += new DataGridViewCellEventHandler(c_edit); //여기가 중요
            select_m();
            DBConn.Close();
        }
        //----------------------------------------------------------------------------------
        private void select_m()        //검색
        {
            dataGridView1.CellValueChanged -= new DataGridViewCellEventHandler(c_edit); //여기가 중요
            //
            string s1, s2 = "";
            string c1, c2 = "";

            if (comboBox1.Text != "")
            {
                c1 = comboBox1.Text.Trim();
                s1 = " and b.sangho ='" + c1 + "'";
            }
            else
                s1 = "";
            //
            if (comboBox2.Text != "")
            {
                c2 = comboBox2.Text.Trim();
                s2 = " and b ='" + c2 + "'";
            }
            else
                s2 = "";
            //
            dataGridView1.Rows.Clear();

            string cQuery = "select count(*) from C_boxs as a left outer join C_hcustomer as b on a.hcust_id = b.row_id";
            cQuery += " where a.row_id is not null " + s1 + s2;
            var DBConn = new MySqlConnection(Config.DB_con1);
            DBConn.Open();
            var cmd = new MySqlCommand(cQuery, DBConn);
            var myRead = cmd.ExecuteReader();
            //
            int k = 0;
            if (myRead.Read())
                k = Convert.ToInt32(myRead[0]);
            //
            myRead.Close();

            if (k == 0)
                k = 1;
            dataGridView1.Rows.Add(k);
            //
            cQuery = " select a.*, b.sangho as a from C_boxs as a left outer join C_hcustomer as b on a.hcust_id = b.row_id";
            cQuery += " where a.row_id is not null " + s1 + s2;
            cQuery += " order by c";
            cmd = new MySqlCommand(cQuery, DBConn);
            myRead = cmd.ExecuteReader();

            int m = 0;
            while (myRead.Read())
            {
                dataGridView1.Rows[m].Cells[0].Value = myRead["row_id"];
                dataGridView1.Rows[m].Cells[1].Value = false;
                dataGridView1.Rows[m].Cells[2].Value = (m + 1).ToString();
                dataGridView1.Rows[m].Cells[3].Value = myRead["a"];
                dataGridView1.Rows[m].Cells[4].Value = myRead["g"];
                dataGridView1.Rows[m].Cells[5].Value = myRead["b"];
                dataGridView1.Rows[m].Cells[6].Value = myRead["c"];
                dataGridView1.Rows[m].Cells[7].Value = myRead["d"];
                dataGridView1.Rows[m].Cells[8].Value = myRead["e"];
                dataGridView1.Rows[m].Cells[9].Value = myRead["f"];
                dataGridView1.Rows[m].Cells[10].Value = myRead["weight"];
                m++;
            }
            myRead.Close();
            DBConn.Close();
            dataGridView1.CellValueChanged += new DataGridViewCellEventHandler(c_edit); //여기가 중요
        }
        //----------------------------------------------------------------------------------
        private void c_edit(object sender, DataGridViewCellEventArgs e)        //수정
        {
            string cQuery = "";
            string dat = dataGridView1.CurrentCell.Value.ToString().Trim();
            string row_no = dataGridView1.Rows[dataGridView1.CurrentRow.Index].Cells[0].Value.ToString().Trim();
            //
            if (e.ColumnIndex.Equals(3))
                cQuery = " update C_boxs set a='" + dat + "' where row_id='" + row_no + "'";
            else if (e.ColumnIndex.Equals(4))
                cQuery = " update C_boxs set g='" + dat + "' where row_id='" + row_no + "'";
            else if (e.ColumnIndex.Equals(5))
                cQuery = " update C_boxs set b='" + dat + "' where row_id='" + row_no + "'";
            else if (e.ColumnIndex.Equals(6))
                cQuery = " update C_boxs set c='" + dat + "' where row_id='" + row_no + "'";
            else if (e.ColumnIndex.Equals(7))
                cQuery = " update C_boxs set d='" + dat + "' where row_id='" + row_no + "'";
            else if (e.ColumnIndex.Equals(8))
                cQuery = " update C_boxs set e='" + dat + "' where row_id='" + row_no + "'";
            else if (e.ColumnIndex.Equals(9))
                cQuery = " update C_boxs set f='" + dat + "' where row_id='" + row_no + "'";
            else if (e.ColumnIndex.Equals(10))
                cQuery = " update C_boxs set weight='" + dat + "' where row_id='" + row_no + "'";
            else
                return;
            var DBConn = new MySqlConnection(Config.DB_con1);
            DBConn.Open();
            var cmd = new MySqlCommand(cQuery, DBConn);
            if (cmd.ExecuteNonQuery() == 0)
                MessageBox.Show("서버 자료 수정에 실패 했습니다.");

            DBConn.Close();
        }

        private void button2_Click(object sender, EventArgs e)      //추가
        {
            dataGridView1.CellValueChanged -= new DataGridViewCellEventHandler(c_edit); //수정이벤트 해제
            string cQuery = "";
            cQuery = " insert into C_boxs (a,b,c,d,e,f) values('','','','','','')";
            var DBConn = new MySqlConnection(Config.DB_con1);
            DBConn.Open();
            var cmd = new MySqlCommand(cQuery, DBConn);
            int m = 0;
            if (cmd.ExecuteNonQuery() == 0)
            {
                MessageBox.Show("서버 자료 등록에 실패 했습니다.");
                DBConn.Close();
                return;
            }
            else
            {
                cQuery = " select * from C_boxs where row_id=(SELECT LAST_INSERT_ID())";
                cmd = new MySqlCommand(cQuery, DBConn);
                var myRead = cmd.ExecuteReader();
                dataGridView1.Rows.Add(1);
                m = dataGridView1.RowCount - 1;
                myRead.Read();
                //
                dataGridView1.Rows[m].Cells[0].Value = myRead["row_id"];
                dataGridView1.Rows[m].Cells[1].Value = false;
                dataGridView1.Rows[m].Cells[2].Value = "*";
                dataGridView1.Rows[m].Cells[3].Value = myRead["a"];
                dataGridView1.Rows[m].Cells[4].Value = myRead["g"];
                dataGridView1.Rows[m].Cells[5].Value = myRead["b"];
                dataGridView1.Rows[m].Cells[6].Value = myRead["c"];
                dataGridView1.Rows[m].Cells[7].Value = myRead["d"];
                dataGridView1.Rows[m].Cells[8].Value = myRead["e"];
                dataGridView1.Rows[m].Cells[9].Value = myRead["f"];
                dataGridView1.Rows[m].Cells[10].Value = myRead["weight"];
            }
            dataGridView1.CurrentCell = dataGridView1.Rows[m].Cells[2];//크스옮기기
            dataGridView1.CellValueChanged += new DataGridViewCellEventHandler(c_edit); //수정이벤트 등록
            DBConn.Close();
        }

        private void button1_Click(object sender, EventArgs e)     //삭제
        {
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
                    string cQuery = " delete from C_boxs where row_id='" + row_no + "'";
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
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Excel_convert Ec = new Excel_convert(dataGridView1);
            Ec.Convert();

        }

        private void label15_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)  //검색
        {
            select_m();
        }
 
    }
}

