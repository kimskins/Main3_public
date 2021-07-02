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
    public partial class Form_model : Form
    {
        public string[] code = new string[7];
        private int Xb = 0;
        private int Yb = 0;
        private int inset_su = 0;
        private Button btn = new Button();
        DataTable a_dt = new DataTable();
        DataTable b_dt = new DataTable();
        DataTable c_dt = new DataTable();
        DataTable pan_dt = new DataTable();

        string pan_type_code = "";

        public Form_model(Button bt,string[] cc)
        {
            InitializeComponent();
            //
            code[0] = cc[0];  //a_code
            code[1] = "";     //aitem
            code[2] = cc[1];  //b_code
            code[3] = "";     //bitem
            code[4] = cc[2];  //c_code
            code[5] = "";     //citem
            code[6] = cc[3];  //폼번호
            // 
            btn = bt;
            Xb = btn.PointToScreen(Location).X - this.Width + btn.Width;  //좌,우
            Yb = btn.PointToScreen(Location).Y + btn.Height;  //위,아래
        }

        private void Form_model_Load(object sender, EventArgs e)
        {
            label4.Text = "0";
            this.Location = new Point(Xb, Yb);
            //
            var DBCons = new MySqlConnection(Config.DB_con1);
            DBCons.Open();
            //
            string cQuery = " select a_code,aitem from C_amodel ";
            MySqlDataAdapter returnVal = new MySqlDataAdapter(cQuery, DBCons);
            returnVal.Fill(a_dt);
            returnVal.Dispose();
            DBCons.Close();
            //
            if (code[6] == "1" || code[6] == "2" || code[6] == "3"  || code[6] == "4" )
            {
                label3.Visible = false;
                c_model.Visible = false;
                button3.Visible = false;
                //
                //a_model.Enabled = false;
                button1.Enabled = false;
                //
                DataRow[] dr = a_dt.Select("a_code='" + code[0] + "'");
                code[1] = dr[0]["aitem"].ToString().Trim();  //


                a_model.Text = code[1];

                if (code[6] == "2")
                {
                    label6.Visible = false;
                    tbPanhyung.Visible = false;
                    button4.Visible = false;
                }
            }
            /*
            else if (code[6] == "3")  //코팅
            {
                a_model.Enabled = false;
                button1.Enabled = false;
                //
                DataRow[] dr = a_dt.Select("a_code='" + code[0] + "'");
                code[1] = dr[0]["aitem"].ToString().Trim();  //
                a_model.Text = code[1];
            }
            */ 
        }

        private void button1_Click(object sender, EventArgs e)    //대분류 검색
        {
            Listview_no fm = new Listview_no(a_model, 1);
            fm.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            DataGridView dgv1 = fm.dataGridView1;
            //
            fm.Size = new Size(94, 300); //좌우,위,아래
            dgv1.DataSource = a_dt;

            dgv1.Columns[0].Width = 30;
            dgv1.Columns[0].Visible = false;
            dgv1.Columns[0] .DefaultCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dgv1.Columns[1].Width = 110;

            dgv1.ColumnHeadersVisible = false;
            //
            fm.Size = new Size(130, 200); //좌우(모든 width 더하기 10),위,아래(row*23+10)
            if (fm.ShowDialog() == DialogResult.OK)
            {
                code[1] = a_model.Text;     //aitem
                DataRow[] dr = a_dt.Select("aitem='" + code[1] + "'");
                code[0] = dr[0]["a_code"].ToString().Trim();  //
                //
                code[2] = "";  //b_code
                code[3] = "";  //bitem
                code[4] = "";  //c_code
                code[5] = "";  //citem
                //
                b_model.Text = "";
                c_model.Text = "";
            }
        }

        private void button2_Click(object sender, EventArgs e)  //중분류 검색
        {
            if (b_dt.Rows.Count == 0)    //대분류 검색하는 테이블
            {
                var DBCons = new MySqlConnection(Config.DB_con1);
                DBCons.Open();
                //
                string cQuery = " select b_code,bitem,a_code from C_bmodel";
                MySqlDataAdapter returnVal = new MySqlDataAdapter(cQuery, DBCons);
                returnVal.Fill(b_dt);
                returnVal.Dispose();
                DBCons.Close();
            }
            //
            if (code[0] != "")
            {
                DataRow[] dr = b_dt.Select("a_code='" + code[0] + "'");
                DataTable x_dt = dr.CopyToDataTable();

                Listview_no fm = new Listview_no(b_model, 1);
                fm.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
                DataGridView dgv1 = fm.dataGridView1;
                //
                //
                fm.Size = new Size(94, 300); //좌우,위,아래
                dgv1.DataSource = x_dt;
                dgv1.Columns[0].Width = 30;
                dgv1.Columns[0].Visible = false;
                dgv1.Columns[0].DefaultCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
                dgv1.Columns[1].Width = 110;

                dgv1.ColumnHeadersVisible = false;
                //
                fm.Size = new Size(130, 200); //좌우(모든 width 더하기 10),위,아래(row*23+10)
                if (fm.ShowDialog() == DialogResult.OK)
                {
                    code[3] = b_model.Text;     //bitem
                    DataRow[] dr1 = x_dt.Select("bitem='" + code[3] + "'");
                    code[2] = dr1[0]["b_code"].ToString().Trim();  //
                    //
                    code[4] = "";  //c_code
                    code[5] = "";  //citem
                    //
                    c_model.Text = "";
                }
            }
            else
                MessageBox.Show("업종-1 항목이 없습니다.");
        }

        private void button3_Click(object sender, EventArgs e)  //소분류 검색
        {
            if (c_dt.Rows.Count == 0)    //대분류 검색하는 테이블
            {
                var DBCons = new MySqlConnection(Config.DB_con1);
                DBCons.Open();
                //
                string cQuery = " select c_code,citem,a_code,b_code from C_cmodel";
                MySqlDataAdapter returnVal = new MySqlDataAdapter(cQuery, DBCons);
                returnVal.Fill(c_dt);
                returnVal.Dispose();
                DBCons.Close();
            }
            //
            if (code[2] != "")
            {
                DataRow[] dr = c_dt.Select("a_code='" + code[0] + "' and b_code='" + code[2] + "'");
                DataTable x_dt = dr.CopyToDataTable();

                Listview_no fm = new Listview_no(c_model, 1);
                fm.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
                DataGridView dgv1 = fm.dataGridView1;
                //
                //
                fm.Size = new Size(130, 300); //좌우,위,아래
                dgv1.DataSource = x_dt;
                dgv1.Columns[0].Width = 30;
                dgv1.Columns[0].Visible = false;
                dgv1.Columns[0].DefaultCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
                dgv1.Columns[1].Width = 110;

                dgv1.ColumnHeadersVisible = false;
                //
                fm.Size = new Size(110, 200);    //좌우(모든 width 더하기 10),위,아래(row*23+10)
                if (fm.ShowDialog() == DialogResult.OK)
                {
                    code[5] = c_model.Text;     //citem
                    DataRow[] dr1 = x_dt.Select("citem='" + code[5] + "'");
                    code[4] = dr1[0]["c_code"].ToString().Trim();  //
                }
            }
            else
                MessageBox.Show("업종-2 항목이 없습니다.");
        }

        private void button4_Click(object sender, EventArgs e)
        {
            pan_dt.Clear();
            var DBCons = new MySqlConnection(Config.DB_con1);
            DBCons.Open();
            //
            string cQuery = "select distinct hang, code1 from hang_manage where class='판형'";
            MySqlDataAdapter returnVal = new MySqlDataAdapter(cQuery, DBCons);
            returnVal.Fill(pan_dt);
            returnVal.Dispose();
            DBCons.Close();

            Listview_no fm = new Listview_no(tbPanhyung, 0);
            fm.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            DataGridView dgv1 = fm.dataGridView1;
            //
            //
            fm.Size = new Size(130, 300); //좌우,위,아래
            dgv1.DataSource = pan_dt;
            dgv1.Columns[0].Width = 110;
            
            dgv1.Columns[0].DefaultCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dgv1.Columns[1].Width = 110;
            dgv1.Columns[1].Visible = false;

            dgv1.ColumnHeadersVisible = false;
            //
            fm.Size = new Size(110, 200);    //좌우(모든 width 더하기 10),위,아래(row*23+10)
            if (fm.ShowDialog() == DialogResult.OK)
            {

                DataRow[] dr1 = pan_dt.Select("hang='" + tbPanhyung.Text + "'");
                pan_type_code = dr1[0]["code1"].ToString().Trim();  //
            }

        }

        private void button5_Click(object sender, EventArgs e)        //항목추가
        {
            var DBConn = new MySqlConnection(Config.DB_con1);
            DBConn.Open();
            string cQuery = "";
            
            //
            if (code[6] == "1" || code[6] == "2" || code[6] == "3" || code[6] == "4")
            {
                if (tbPanhyung.Text.Trim() == "" && (code[6] == "1" || code[6] == "3" || code[6] == "4"))
                {
                    MessageBox.Show("판형을 선택하지 않았습니다");
                    DBConn.Close();
                    return;
                }

                if (code[3] != "")  //선택항목
                {
                    if (code[6] == "2")
                    {
                        cQuery = " insert into C_pmachine (a_model,b_model,c_model,form_id) values('" + code[0] + "','" + code[2] + "','" + code[4] + "'";
                        cQuery += ",'" + code[6] + "')";
                    }
                    else
                    {
                        cQuery = " insert into C_pmachine (a_model,b_model,c_model,form_id, pan_type) values('" + code[0] + "','" + code[2] + "','" + code[4] + "'";
                        cQuery += ",'" + code[6] + "', '" + pan_type_code + "')";
                    }
                    
                    var cmd = new MySqlCommand(cQuery, DBConn);
                    //
                    if (cmd.ExecuteNonQuery() == 0)
                    {
                        MessageBox.Show("서버 자료 등록에 실패 했습니다.");
                        DBConn.Close();
                        return;
                    }
                    else
                    {
                        inset_su++;
                        label4.Text = inset_su.ToString();
                    }
                }
                else
                    MessageBox.Show("업종-2 항목이 없습니다.");
            }
            else
            {
                if (code[1] != "" && code[3] != "")
                {
                    if (tbPanhyung.Text.Trim() == "")  // 선택했다가 text를 삭제했을때 code도 함께 삭제 하기 위해서..
                        pan_type_code = "";

                    cQuery = " insert into C_pmachine (a_model,b_model,c_model,form_id, pan_type) values('" + code[0] + "','" + code[2] + "','" + code[4] + "'";
                    cQuery += ",'" + code[6] + "', '" + pan_type_code + "')";
                    //
                    var cmd = new MySqlCommand(cQuery, DBConn);
                    //
                    if (cmd.ExecuteNonQuery() == 0)
                    {
                        MessageBox.Show("서버 자료 등록에 실패 했습니다.");
                        DBConn.Close();
                        return;
                    }
                    else
                    {
                        inset_su++;
                        label4.Text = inset_su.ToString();
                    }
                }
                else
                    MessageBox.Show("업종-1, 업종-2 항목을 입력해 주세요.");
            }
            DBConn.Close();
        }

        private void Form_model_Deactivate(object sender, EventArgs e)  //빠져나갈때
        {
            if(inset_su != 0)
                this.DialogResult = DialogResult.OK;
        }


    }
}
