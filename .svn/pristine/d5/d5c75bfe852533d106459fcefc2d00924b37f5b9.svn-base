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
    public partial class Form_202 : Form
    {
        private DataTable p_dt = new DataTable();  //main 자료 테이블

        public Form_202()
        {
            InitializeComponent();
        }

        private void Form_boxp_Load(object sender, EventArgs e)
        {
            Screen srn = Screen.PrimaryScreen;
            int Xb = this.Width;  //좌,우
            this.Location = new Point((srn.Bounds.Width - Xb) / 2, 1);  //좌/우,위/아래

            p_dt.Columns.Add("no1", typeof(int));     //구분수0
            p_dt.Columns.Add("no2", typeof(string));  //항목1
            p_dt.Columns.Add("a1", typeof(int));      //a1 2
            p_dt.Columns.Add("a2", typeof(int));      //a2 3
            p_dt.Columns.Add("a3", typeof(int));      //a3 4
            p_dt.Columns.Add("a4", typeof(int));      //a4 5
            p_dt.Columns.Add("a5", typeof(int));      //a5 6
            p_dt.Columns.Add("a6", typeof(int));      //a6 7
            p_dt.Columns.Add("DW", typeof(int));      //DW 8
            p_dt.Columns.Add("SW", typeof(int));      //SW 9
            p_dt.Columns.Add("A_gol", typeof(int));      //A_gol 10
            p_dt.Columns.Add("B_gol", typeof(int));      //B_gol 11
            //
            button2_Click(null, null);
        }

        private void button1_Click(object sender, EventArgs e)  //저장
        {
            var DBConn = new MySqlConnection(Config.DB_con1);
            DBConn.Open();
            string cQuery="";
            //
            cQuery = " update C_boxp set a1='" + textBox1.Text + "',a2='" + textBox2.Text + "',a3='" + textBox3.Text + "'";
            cQuery += ",a4='" + textBox4.Text + "',a5='" + textBox5.Text + "' where row_id='1'";
            var cmd = new MySqlCommand(cQuery, DBConn);
            cmd.ExecuteNonQuery();
            //
            cQuery = " update C_boxp set a1='" + textBox6.Text + "',a2='" + textBox7.Text + "',a3='" + textBox8.Text + "'";
            cQuery += ",a4='" + textBox9.Text + "',a5='" + textBox10.Text + "' where row_id='2'";
            cmd = new MySqlCommand(cQuery, DBConn);
            cmd.ExecuteNonQuery();
            //
            cQuery = " update C_boxp set a1='" + textBox11.Text + "',a2='" + textBox12.Text + "',a3='" + textBox13.Text + "'";
            cQuery += ",a4='" + textBox14.Text + "',a5='" + textBox15.Text + "' where row_id='3'";
            cmd = new MySqlCommand(cQuery, DBConn);
            cmd.ExecuteNonQuery();
            //
            cQuery = " update C_boxp set a1='" + textBox16.Text + "',a2='" + textBox17.Text + "',a3='" + textBox18.Text + "'";
            cQuery += ",a4='" + textBox19.Text + "',a5='" + textBox20.Text + "' where row_id='4'";
            cmd = new MySqlCommand(cQuery, DBConn);
            cmd.ExecuteNonQuery();
            //
            cQuery = " update C_boxp set a1='" + textBox21.Text + "',a2='" + textBox22.Text + "',a3='" + textBox23.Text + "'";
            cQuery += ",a4='" + textBox24.Text + "',a5='" + textBox25.Text + "' where row_id='5'";
            cmd = new MySqlCommand(cQuery, DBConn);
            cmd.ExecuteNonQuery();
            //
            cQuery = " update C_boxp set a1='" + textBox26.Text + "',a2='" + textBox27.Text + "',a3='" + textBox28.Text + "'";
            cQuery += ",a4='" + textBox29.Text + "',a5='" + textBox30.Text + "' where row_id='6'";
            cmd = new MySqlCommand(cQuery, DBConn);
            cmd.ExecuteNonQuery();

            cQuery = " update C_boxp set DW='" + tbDW.Text + "',SW='" + tbSW.Text + "',A_gol='" + tbA_gol.Text + "'";
            cQuery += ",B_gol='" + tbB_gol.Text + "' ";
            cmd = new MySqlCommand(cQuery, DBConn);
            cmd.ExecuteNonQuery();
            //
            DBConn.Close();
            MessageBox.Show("저장 하였습니다.");
        }

        private void button2_Click(object sender, EventArgs e) //검색
        {
            p_dt.Rows.Clear();
            var DBConn = new MySqlConnection(Config.DB_con1);
            DBConn.Open();
            //
            string cQuery = " select * FROM C_boxp";
            var cmd = new MySqlCommand(cQuery, DBConn);
            var myRead = cmd.ExecuteReader();
            while (myRead.Read())
            {
                p_dt.Rows.Add(new Object[] {Convert.ToInt32(myRead["no1"].ToString()),myRead["no2"].ToString(),Convert.ToInt32(myRead["a1"].ToString())
                        ,Convert.ToInt32(myRead["a2"].ToString()),Convert.ToInt32(myRead["a3"].ToString()),Convert.ToInt32(myRead["a4"].ToString())
                        ,Convert.ToInt32(myRead["a5"].ToString()),Convert.ToInt32(myRead["a6"].ToString()), Convert.ToInt32(myRead["DW"].ToString())
                        ,Convert.ToInt32(myRead["SW"].ToString()),Convert.ToInt32(myRead["A_gol"].ToString()),Convert.ToInt32(myRead["B_gol"].ToString())});
            }
            myRead.Close();
            DBConn.Close();
            //
            textBox1.Text = p_dt.Rows[0][2].ToString();
            textBox2.Text = p_dt.Rows[0][3].ToString();
            textBox3.Text = p_dt.Rows[0][4].ToString();
            textBox4.Text = p_dt.Rows[0][5].ToString();
            textBox5.Text = p_dt.Rows[0][6].ToString();
            //
            textBox6.Text = p_dt.Rows[1][2].ToString();
            textBox7.Text = p_dt.Rows[1][3].ToString();
            textBox8.Text = p_dt.Rows[1][4].ToString();
            textBox9.Text = p_dt.Rows[1][5].ToString();
            textBox10.Text = p_dt.Rows[1][6].ToString();
            //
            textBox11.Text = p_dt.Rows[2][2].ToString();
            textBox12.Text = p_dt.Rows[2][3].ToString();
            textBox13.Text = p_dt.Rows[2][4].ToString();
            textBox14.Text = p_dt.Rows[2][5].ToString();
            textBox15.Text = p_dt.Rows[2][6].ToString();
            //
            textBox16.Text = p_dt.Rows[3][2].ToString();
            textBox17.Text = p_dt.Rows[3][3].ToString();
            textBox18.Text = p_dt.Rows[3][4].ToString();
            textBox19.Text = p_dt.Rows[3][5].ToString();
            textBox20.Text = p_dt.Rows[3][6].ToString();
            //
            textBox21.Text = p_dt.Rows[4][2].ToString();
            textBox22.Text = p_dt.Rows[4][3].ToString();
            textBox23.Text = p_dt.Rows[4][4].ToString();
            textBox24.Text = p_dt.Rows[4][5].ToString();
            textBox25.Text = p_dt.Rows[4][6].ToString();
            //
            textBox26.Text = p_dt.Rows[5][2].ToString();
            textBox27.Text = p_dt.Rows[5][3].ToString();
            textBox28.Text = p_dt.Rows[5][4].ToString();
            textBox29.Text = p_dt.Rows[5][5].ToString();
            textBox30.Text = p_dt.Rows[5][6].ToString();

            tbDW.Text = p_dt.Rows[0][8].ToString();
            tbSW.Text = p_dt.Rows[0][9].ToString();
            tbA_gol.Text = p_dt.Rows[0][10].ToString();
            tbB_gol.Text = p_dt.Rows[0][11].ToString();
            //
            textBox1.Focus();
            textBox1.Select(0,0);
        }
    }
}
