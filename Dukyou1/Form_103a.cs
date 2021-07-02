using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using System.IO;
using System.Net.Sockets;
using System.Net;
using System.Diagnostics;

namespace Dukyou3
{
    public partial class Form_103a : Form
    {
        Form6 frt0;
        Form6 frt1;
        Form6 frt2;
        Form6 frt3;
        Form6 frt4;
        Form6 frt5;
        Form6 frt6;
        Form6 frt7;
        Form6 frt8;
        Form6 frt9;

        string DB_TableName_file = "C_file_total_manage";
        string DB_TableName_cust = "C_hcustomer";
        string[,] form = new string[10,2];
        // 
        bool ent_id = false;  //수정모드
        string m_no = "";     //회사번호
        string yu_jong="";    //업종고유번호
        private DataTable a_dt = new DataTable();  //C_amodel 자료 테이블
        private DataTable b_dt = new DataTable();  //C_bmodel 자료 테이블
        string[] axx = new string[8];
        string[] pxx = new string[8];

        bool Com_num = false;   // 저장승인. 사업자등록번호 이상유무. true면 저장.
        string First_ent_no = "";

        string c_addr_a;
        string c_addr_b;
        string c_addr_c;
        string c_addr_d;
        //string c_addr_old;
        //public string c_addr_new;
        public string c_addr_other_new;
        public string c_addr_other_old;

        string m_addr_a;
        string m_addr_b;
        string m_addr_c;
        string m_addr_d;
        //string m_addr_old;
        //public string m_addr_new;
        public string m_addr_other_new;
        public string m_addr_other_old;

        SourceGrid.Cells.Editors.ComboBox cb_pantype;  // grid에 있는 판형에 들어갈 콤보박스
        SourceGrid.Cells.Controllers.CustomEvents clickEvent1 = new SourceGrid.Cells.Controllers.CustomEvents(); // file grid의 내려받기 버튼

        public Form_103a(bool id,string sn)
        {
            InitializeComponent();
            ent_id = id;  //신규,수정 구분
            m_no = sn;    //회사번호
            if (ent_id == false)  // 신규등록이 아닐시 
                Com_num = true;
        }

        private void Form41_Load(object sender, EventArgs e)
        {
            Screen srn = Screen.PrimaryScreen;
            int Xb = this.Width;   //좌,우
            int Yb = this.Height;  //위,아래
            if (this.MdiParent == null)
                this.Location = new Point((srn.Bounds.Width - Xb) / 2, 60);  //좌/우,위/아래
            else
                this.Location = new Point((srn.Bounds.Width - Xb) / 2, 1);  //좌/우,위/아래
            //
            for (int i = 0; i < axx.Length; i++)
            {
                axx[i] = "";
            }
            var DBConn = new MySqlConnection(Config.DB_con1);
            DBConn.Open();
            string cQuery = "";
            //
            cQuery = "select a_code,aitem from C_amodel ";
            MySqlDataAdapter returnVal = new MySqlDataAdapter(cQuery, DBConn);
            returnVal.Fill(a_dt);
            returnVal.Dispose();
            //
            cQuery = "select a_code,b_code,bitem,m_id,tap from C_bmodel ";
            returnVal = new MySqlDataAdapter(cQuery, DBConn);
            returnVal.Fill(b_dt);
            returnVal.Dispose();
            //
            this.tabControl1.SizeMode = TabSizeMode.Fixed;
            this.tabControl1.ItemSize = new Size(70, 26);

            if (ent_id == true)  //신규모드
            {
                textBox12.Text = DateTime.Today.ToShortDateString();
                textBox17.Text = "";
            }
            else                //수정모드(기존사용자)
            {
                cQuery = " select * from C_hcustomer where row_id='"+m_no+"'";
                var cmd = new MySqlCommand(cQuery, DBConn);
                var myRead = cmd.ExecuteReader();
                myRead.Read();
                //
                textBox9.Text = myRead["row_id"].ToString();
                int start = Convert.ToInt32(myRead["rank"].ToString());
                m_no = myRead["row_id"].ToString();          //row_id
                if (start == 1)
                    textBox17.Text = "☆";
                else if (start == 2)
                    textBox17.Text = "☆☆";
                else if (start == 3)
                    textBox17.Text = "☆☆☆";
                else if (start == 4)
                    textBox17.Text = "☆☆☆☆";
                else if (start == 5)
                    textBox17.Text = "☆☆☆☆☆";
                else
                    textBox17.Text = "";
                //
                textBox12.Text=myRead["in_day"].ToString();  //등록일
                comboBox4.Text=myRead["area"].ToString();    //지역
                textBox3.Text = c_change(myRead["yubjong"].ToString());//업종
                yu_jong = myRead["yubjong"].ToString();      //업종 원이름
                textBox1.Text =myRead["mast"].ToString();    //대표
                textBox5.Text =myRead["mh_tel"].ToString();  //휴대폰
                textBox6.Text =myRead["ctel"].ToString();    //전화
                textBox7.Text =myRead["fax"].ToString();     //팩스
                textBox4.Text =myRead["sangho"].ToString();  //상호(법인면)
                textBox2.Text =myRead["name"].ToString();    //성명
                textBox10.Text=myRead["yubtae"].ToString();  //업태
                textBox11.Text=myRead["jongmok"].ToString(); //종목
                First_ent_no = textBox14.Text=myRead["enter_no"].ToString();//등록번호
                textBox16.Text=myRead["bank_no"].ToString(); //회사통장
                textBox8.Text = myRead["homp_ip"].ToString();//홈피주소

                tbAddrc.Text = myRead["c_addr_a"].ToString() + " " + myRead["c_addr_b"].ToString() + " " + myRead["c_addr_" + Config.addr_tail].ToString();  //사업장주소
                tbAddrotherc.Text = myRead["c_addr_other_" + Config.addr_other].ToString();

                tbAddrm.Text = myRead["m_addr_a"].ToString() + " " + myRead["m_addr_b"].ToString() + " " + myRead["m_addr_" + Config.addr_tail].ToString();
                tbAddrotherm.Text = myRead["m_addr_other_" + Config.addr_other].ToString();

                //if (myRead["c_addr_new"].ToString() != "")
                //{
                //    tbAddrc.Text = myRead["c_addr_new"].ToString();  //사업장주소
                //    tbAddrotherc.Text = myRead["c_addr_other"].ToString();
                //    tbAddrotherc.Visible = true;
                //}
                //else
                //{
                //    tbAddrc.Text = myRead["c_addr"].ToString();  //사업장주소
                //    tbAddrotherc.Visible = false;
                //    tbAddrc.Size = new System.Drawing.Size(389, 21);
                //}
                //if (myRead["m_addr_new"].ToString() != "")
                //{
                //    tbAddrm.Text = myRead["m_addr_new"].ToString();  
                //    tbAddrotherm.Text = myRead["m_addr_other"].ToString();
                //}
                //else
                //{
                //    tbAddrm.Text = myRead["m_addr"].ToString();  
                //}

                if (Convert.ToBoolean(myRead["security_id"].ToString()) == true)
                    checkBox2.Checked = true;
                else
                    checkBox2.Checked = false;
                //
                richTextBox1.Text = myRead["sp_memo"].ToString(); //특징
                //
                myRead.Close();
                //
                cQuery = "select count(*) FROM C_hman where int_id='" + m_no + "'";
                cmd = new MySqlCommand(cQuery, DBConn);
                myRead = cmd.ExecuteReader();
                int k = 0;
                if (myRead.Read())
                    k = Convert.ToInt32(myRead[0]);
                myRead.Close();
                if (k == 0)
                    k = 1;
                //
                dataGridView1.Rows.Add(k);
                //
                cQuery = "select * FROM C_hman where int_id='" + m_no + "'";
                cmd = new MySqlCommand(cQuery, DBConn);
                myRead = cmd.ExecuteReader();
                int m = 0;
                while (myRead.Read())
                {
                    dataGridView1.Rows[m].Cells[0].Value = myRead["row_id"].ToString();
                    dataGridView1.Rows[m].Cells[1].Value = false;
                    dataGridView1.Rows[m].Cells[2].Value = (m + 1).ToString();
                    dataGridView1.Rows[m].Cells[3].Value = myRead["charge"].ToString();
                    dataGridView1.Rows[m].Cells[4].Value = myRead["account"].ToString();
                    dataGridView1.Rows[m].Cells[5].Value = myRead["mission"].ToString();
                    dataGridView1.Rows[m].Cells[6].Value = myRead["name"].ToString();
                    dataGridView1.Rows[m].Cells[7].Value = myRead["post"].ToString();
                    dataGridView1.Rows[m].Cells[8].Value = myRead["h_tel"].ToString();
                    dataGridView1.Rows[m].Cells[9].Value = myRead["c_tel"].ToString();
                    dataGridView1.Rows[m].Cells[10].Value = myRead["email"].ToString();
                    dataGridView1.Rows[m].Cells[12].Value = myRead["memo"].ToString();
                    m++;
                }
                myRead.Close();
            }
            DBConn.Close();
            //
            make_tap();
            FileGrid_View();
            //
            dataGridView1.CellValueChanged += new DataGridViewCellEventHandler(dg1_edit); //여기가 중요
            clickEvent1.Click += new EventHandler(clickEvent_Click1);   // 그리드에서 버튼 클릭 이벤트
            button6.Select();

            checkBox1.Checked = false;
            if (tbAddrc.Text == tbAddrm.Text && tbAddrotherc.Text == tbAddrotherm.Text)
            {
                checkBox1.Checked = true;
            }
        }

        private void make_tap() //탭만들기
        {
            int tap_no = tabControl1.SelectedIndex;
            tabControl1.TabPages.Clear();
            //
            string[] mxx;
            mxx = yu_jong.Split(new char[1] { '/' });  //업종번호 분리
            string xno1 = "";
            string xno2 = "";
            //
            DataRow[] dr;
            for (int i = 0; i < mxx.Length - 1; i++)   //업종 돌면서 생성
            {
                xno1 = mxx[i].Substring(0, 2).ToString();
                xno2 = mxx[i].Substring(2, 2).ToString();
                string tt = "";
                string xno = "";
                string mno = "";
                dr = b_dt.Select("a_code='" + xno1 + "' and  b_code='" + xno2 + "'");
                if (dr.Length != 0)
                {
                    tt = dr[0]["tap"].ToString();   //탭이름
                    xno = dr[0]["m_id"].ToString(); //폼번호
                    mno = dr[0]["a_code"].ToString().Trim() + dr[0]["b_code"].ToString().Trim();  //a_code+b_code
                    //
                    if (xno != "0")  //폼번호가 '0'이 아니라면
                    {
                        tabControl1.TabPages.Add(CreateTabPage(tt, xno, i.ToString(), mno));  //탭이름,폼번호,순서,a+b 코드
                    }
                }
            }
            if (tap_no == -1)
                tap_no = 0;
            //
            tabControl1.SelectedIndex=tap_no;
        }
        //
        private void Xbutton1_Click(object sender, EventArgs e) //항목 추가
        {
            int form_no=0;
            string tx = "";
            if (m_no.Equals("0"))
            {
                MessageBox.Show("1차 내용을 저장하셔야 등록이 가능합니다.");
                return;
            }
            //
            Button button = sender as Button;
            tx = button.Name;

            int index = tx.ToString().LastIndexOf(':');
            tx = tx.Substring(index+1).Trim(); 
            //
            if (tx.Equals("bt10"))
                form_no = 0;
            else if (tx.ToString().Equals("bt11"))
                form_no = 1;
            else if (tx.ToString().Equals("bt12"))
                form_no = 2;
            else if (tx.ToString().Equals("bt13"))
                form_no = 3;
            else if (tx.ToString().Equals("bt14"))
                form_no = 4;
            else if (tx.ToString().Equals("bt15"))
                form_no = 5;
            else if (tx.ToString().Equals("bt16"))
                form_no = 6;
            else if (tx.ToString().Equals("bt17"))
                form_no = 7;
            else if (tx.ToString().Equals("bt18"))
                form_no = 8;
            else if (tx.ToString().Equals("bt19"))
                form_no = 9;
            //
            if (form[form_no, 0].Equals("1"))  //폼번호가 '1' 이면
            {
                Form_machin Frm0 = new Form_machin(m_no, form[form_no, 0], form[form_no, 1]);  //업체번호,폼번호,a+b 코드번호
                if (Frm0.ShowDialog() == DialogResult.OK)
                    make_tap();
            }
            else if (form[form_no, 0].Equals("2") || form[form_no, 0].Equals("3") || form[form_no, 0].Equals("4") || form[form_no, 0].Equals("5") )
            {
                Form_machins Frm1 = new Form_machins(m_no, "2", form[form_no, 0], form[form_no, 1]);  //회사번호,버튼비활성화,폼번호,기계번호
                if (Frm1.ShowDialog() == DialogResult.OK)
                    make_tap();
            }
        }

        private void Xbutton2_Click(object sender, EventArgs e) //항목 삭제
        {
            int form_no = 0;
            string tx = sender.ToString();
            int index = tx.ToString().LastIndexOf(':');
            Button button = sender as Button;
            tx = button.Name;
            string[] sd;
            //
            if (tx.Equals("bt20"))
                form_no = 0;
            else if (tx.ToString().Equals("bt21"))
                form_no = 1;
            else if (tx.ToString().Equals("bt22"))
                form_no = 2;
            else if (tx.ToString().Equals("bt23"))
                form_no = 3;
            else if (tx.ToString().Equals("bt24"))
                form_no = 4;
            else if (tx.ToString().Equals("bt25"))
                form_no = 5;
            else if (tx.ToString().Equals("bt26"))
                form_no = 6;
            else if (tx.ToString().Equals("bt27"))
                form_no = 7;
            else if (tx.ToString().Equals("bt28"))
                form_no = 8;
            else if (tx.ToString().Equals("bt29"))
                form_no = 9;
            // 
            if (MessageBox.Show("선택하신 항목을 삭제합니까 ?", "항목 삭제", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                if (tx.Equals("bt20"))
                {
                    sd = new string[frt0.grid1.RowsCount];//
                    for (int i = 0; i < sd.Length; i++)
                        sd[i] = "0";
                    //
                    int s = 2;
                    for (int i = 2; i < frt0.grid1.RowsCount; i++)
                    {
                        if (frt0.grid1[i, 1].Value.Equals(true))
                        {
                            sd[s] = frt0.grid1[i, 0].Value.ToString().Trim();
                            s++;
                        }
                    }
                }
                else if (tx.Equals("bt21"))
                {
                    sd = new string[frt1.grid1.RowsCount];//
                    for (int i = 0; i < sd.Length; i++)
                        sd[i] = "0";
                    //
                    int s = 2;
                    for (int i = 2; i < frt1.grid1.RowsCount; i++)
                    {
                        if (frt1.grid1[i, 1].Value.Equals(true))
                        {
                            sd[s] = frt1.grid1[i, 0].Value.ToString().Trim();
                            s++;
                        }
                    }
                }
                else if (tx.Equals("bt22"))
                {
                    sd = new string[frt2.grid1.RowsCount];//
                    for (int i = 0; i < sd.Length; i++)
                        sd[i] = "0";
                    //
                    int s = 2;
                    for (int i = 2; i < frt2.grid1.RowsCount; i++)
                    {
                        if (frt2.grid1[i, 1].Value.Equals(true))
                        {
                            sd[s] = frt2.grid1[i, 0].Value.ToString().Trim();
                            s++;
                        }
                    }
                }
                else if (tx.Equals("bt23"))
                {
                    sd = new string[frt3.grid1.RowsCount];//
                    for (int i = 0; i < sd.Length; i++)
                        sd[i] = "0";
                    //
                    int s = 2;
                    for (int i = 2; i < frt3.grid1.RowsCount; i++)
                    {
                        if (frt3.grid1[i, 1].Value.Equals(true))
                        {
                            sd[s] = frt3.grid1[i, 0].Value.ToString().Trim();
                            s++;
                        }
                    }
                }
                else if (tx.Equals("bt24"))
                {
                    sd = new string[frt4.grid1.RowsCount];//
                    for (int i = 0; i < sd.Length; i++)
                        sd[i] = "0";
                    //
                    int s = 2;
                    for (int i = 2; i < frt4.grid1.RowsCount; i++)
                    {
                        if (frt4.grid1[i, 1].Value.Equals(true))
                        {
                            sd[s] = frt4.grid1[i, 0].Value.ToString().Trim();
                            s++;
                        }
                    }
                }
                else if (tx.Equals("bt25"))
                {
                    sd = new string[frt5.grid1.RowsCount];//
                    for (int i = 0; i < sd.Length; i++)
                        sd[i] = "0";
                    //
                    int s = 2;
                    for (int i = 2; i < frt5.grid1.RowsCount; i++)
                    {
                        if (frt5.grid1[i, 1].Value.Equals(true))
                        {
                            sd[s] = frt5.grid1[i, 0].Value.ToString().Trim();
                            s++;
                        }
                    }
                }
                else if (tx.Equals("bt26"))
                {
                    sd = new string[frt6.grid1.RowsCount];//
                    for (int i = 0; i < sd.Length; i++)
                        sd[i] = "0";
                    //
                    int s = 2;
                    for (int i = 2; i < frt6.grid1.RowsCount; i++)
                    {
                        if (frt6.grid1[i, 1].Value.Equals(true))
                        {
                            sd[s] = frt6.grid1[i, 0].Value.ToString().Trim();
                            s++;
                        }
                    }
                }
                else if (tx.Equals("bt27"))
                {
                    sd = new string[frt7.grid1.RowsCount];//
                    for (int i = 0; i < sd.Length; i++)
                        sd[i] = "0";
                    //
                    int s = 2;
                    for (int i = 2; i < frt7.grid1.RowsCount; i++)
                    {
                        if (frt7.grid1[i, 1].Value.Equals(true))
                        {
                            sd[s] = frt7.grid1[i, 0].Value.ToString().Trim();
                            s++;
                        }
                    }
                }
                else if (tx.Equals("bt28"))
                {
                    sd = new string[frt8.grid1.RowsCount];//
                    for (int i = 0; i < sd.Length; i++)
                        sd[i] = "0";
                    //
                    int s = 2;
                    for (int i = 2; i < frt8.grid1.RowsCount; i++)
                    {
                        if (frt8.grid1[i, 1].Value.Equals(true))
                        {
                            sd[s] = frt8.grid1[i, 0].Value.ToString().Trim();
                            s++;
                        }
                    }
                }
                else if (tx.Equals("bt29"))
                {
                    sd = new string[frt9.grid1.RowsCount];//
                    for (int i = 0; i < sd.Length; i++)
                        sd[i] = "0";
                    //
                    int s = 2;
                    for (int i = 2; i < frt9.grid1.RowsCount; i++)
                    {
                        if (frt9.grid1[i, 1].Value.Equals(true))
                        {
                            sd[s] = frt9.grid1[i, 0].Value.ToString().Trim();
                            s++;
                        }
                    }
                }
                else
                    sd = new string[0];//

                //  DB 삭제
                var DBConn = new MySqlConnection(Config.DB_con1);
                DBConn.Open();
                for (int i = 2; i < sd.Length; i++)
                {
                    if (sd[i].Equals("0"))
                        break;
                    else
                    {
                        string row_no = sd[i];
                        string cQuery = " delete from C_hmachin where row_id='" + row_no + "'";
                        var cmd = new MySqlCommand(cQuery, DBConn);
                        if (cmd.ExecuteNonQuery() == 0)
                        {
                            MessageBox.Show("서버 자료 삭제에 실패 했습니다.");
                            break;
                        }
                    }
                }
                DBConn.Close();
                make_tap();
            }
        }

        private TabPage CreateTabPage(string name, string form_no, string no, string m_no)  //(탭이름,폼번호,순서,a+b 코드)
        {
            TabPage page = new TabPage();
            page.Text = name;
            //
            if (no.Equals("0"))
            {
                form[0, 0] = form_no;  //폼번호
                form[0, 1] = m_no;     //회사번호
                frt0 = new Form6();
                frt0.TopLevel = false;
                frt0.Visible = true;
                frt0.button1.Text = "추가";
                frt0.button1.Name = "bt10";
                frt0.button2.Text = "삭제";
                frt0.button2.Name = "bt20";
                frt0.button1.Click += new System.EventHandler(Xbutton1_Click);
                frt0.button2.Click += new System.EventHandler(Xbutton2_Click);
                make_grid(frt0, form_no, m_no);  //(폼,폼번호,a+b코드)
                frt0.grid1.Name = "g0/"+form_no;
                page.Controls.Add(frt0);
            }
            else if (no.Equals("1"))
            {
                form[1, 0] = form_no;
                form[1, 1] = m_no;
                frt1 = new Form6();
                frt1.TopLevel = false;
                frt1.Visible = true;
                frt1.button1.Name = "bt11";
                frt1.button1.Text = "추가";
                frt1.button2.Text = "삭제";
                frt1.button2.Name = "bt21";
                frt1.button1.Click += new System.EventHandler(Xbutton1_Click);
                frt1.button2.Click += new System.EventHandler(Xbutton2_Click);
                frt1.grid1.Name = "g1/" + form_no;
                 make_grid(frt1, form_no, m_no);
                page.Controls.Add(frt1);
            }
            else if (no.Equals("2"))
            {
                form[2, 0] = form_no;
                form[2, 1] = m_no;
                frt2 = new Form6();
                frt2.TopLevel = false;
                frt2.Visible = true;
                frt2.button1.Name = "bt12";
                frt2.button1.Text = "추가";
                frt2.button2.Text = "삭제";
                frt2.button2.Name = "bt22";
                frt2.button1.Click += new System.EventHandler(Xbutton1_Click);
                frt2.button2.Click += new System.EventHandler(Xbutton2_Click);
                frt2.grid1.Name = "g2/" + form_no;
                make_grid(frt2, form_no, m_no);
                page.Controls.Add(frt2);
            }
            else if (no.Equals("3"))
            {
                form[3, 0] = form_no;
                form[3, 1] = m_no;
                frt3 = new Form6();
                frt3.TopLevel = false;
                frt3.Visible = true;
                frt3.button1.Name = "bt13";
                frt3.button1.Text = "추가";
                frt3.button2.Text = "삭제";
                frt3.button2.Name = "bt23";
                frt3.button1.Click += new System.EventHandler(Xbutton1_Click);
                frt3.button2.Click += new System.EventHandler(Xbutton2_Click);
                frt3.grid1.Name = "g3/" + form_no;
                make_grid(frt3, form_no, m_no);
                page.Controls.Add(frt3);
            }
            else if (no.Equals("4"))
            {
                form[4, 0] = form_no;
                form[4, 1] = m_no;
                frt4 = new Form6();
                frt4.TopLevel = false;
                frt4.Visible = true;
                frt4.button1.Name = "bt14";
                frt4.button1.Text = "추가";
                frt4.button2.Text = "삭제";
                frt4.button2.Name = "bt24";
                frt4.button1.Click += new System.EventHandler(Xbutton1_Click);
                frt4.button2.Click += new System.EventHandler(Xbutton2_Click);
                frt4.grid1.Name = "g4/" + form_no;
                make_grid(frt4, form_no, m_no);
                page.Controls.Add(frt4);
            }
            else if (no.Equals("5"))
            {
                form[5, 0] = form_no;
                form[5, 1] = m_no;
                frt5 = new Form6();
                frt5.TopLevel = false;
                frt5.Visible = true;
                frt5.button1.Name = "bt15";
                frt5.button1.Text = "추가";
                frt5.button2.Text = "삭제";
                frt5.button2.Name = "bt25";
                frt5.button1.Click += new System.EventHandler(Xbutton1_Click);
                frt5.button2.Click += new System.EventHandler(Xbutton2_Click);
                frt5.grid1.Name = "g5/" + form_no;
                make_grid(frt5, form_no, m_no);
                page.Controls.Add(frt5);
            }
            else if (no.Equals("6"))
            {
                form[6, 0] = form_no;
                form[6, 1] = m_no;
                frt6 = new Form6();
                frt6.TopLevel = false;
                frt6.Visible = true;
                frt6.button1.Name = "bt16";
                frt6.button1.Text = "추가";
                frt6.button2.Text = "삭제";
                frt6.button2.Name = "bt26";
                frt6.button1.Click += new System.EventHandler(Xbutton1_Click);
                frt6.button2.Click += new System.EventHandler(Xbutton2_Click);
                frt6.grid1.Name = "g6/" + form_no;
                make_grid(frt6, form_no, m_no);
                page.Controls.Add(frt6);
            }
            else if (no.Equals("7"))
            {
                form[7, 0] = form_no;
                form[7, 1] = m_no;
                frt7 = new Form6();
                frt7.TopLevel = false;
                frt7.Visible = true;
                frt7.button1.Name = "bt17";
                frt7.button1.Text = "추가";
                frt7.button2.Text = "삭제";
                frt7.button2.Name = "bt27";
                frt7.button1.Click += new System.EventHandler(Xbutton1_Click);
                frt7.button2.Click += new System.EventHandler(Xbutton2_Click);
                frt7.grid1.Name = "g7/" + form_no;
                make_grid(frt7, form_no, m_no);
                page.Controls.Add(frt7);
            }
            else if (no.Equals("8"))
            {
                form[8, 0] = form_no;
                form[8, 1] = m_no;
                frt8 = new Form6();
                frt8.TopLevel = false;
                frt8.Visible = true;
                frt8.button1.Name = "bt18";
                frt8.button1.Text = "추가";
                frt8.button2.Text = "삭제";
                frt8.button2.Name = "bt28";
                frt8.button1.Click += new System.EventHandler(Xbutton1_Click);
                frt8.button2.Click += new System.EventHandler(Xbutton2_Click);
                frt8.grid1.Name = "g8/" + form_no;
                make_grid(frt8, form_no, m_no);
                page.Controls.Add(frt8);
            }
            else if (no.Equals("9"))
            {
                form[9, 0] = form_no;
                form[9, 1] = m_no;
                frt9 = new Form6();
                frt9.TopLevel = false;
                frt9.Visible = true;
                frt9.button1.Name = "bt19";
                frt9.button1.Text = "추가";
                frt9.button2.Text = "삭제";
                frt9.button2.Name = "bt29";
                frt9.button1.Click += new System.EventHandler(Xbutton1_Click);
                frt9.button2.Click += new System.EventHandler(Xbutton2_Click);
                frt9.grid1.Name = "g9/" + form_no;
                make_grid(frt9, form_no, m_no);
                page.Controls.Add(frt9);
            }
            //
            return page;
        }

        class DoubleClickController : SourceGrid.Cells.Controllers.ControllerBase
        {
            public override void OnDoubleClick(SourceGrid.CellContext sender, EventArgs e)
            {
                base.OnDoubleClick(sender, e);
                //
                string form_no = "";
                base.OnValueChanged(sender, e);
                int ps = sender.Position.Column;
                SourceGrid.Grid grid = (SourceGrid.Grid)sender.Grid;
                string nam = grid.Name.ToString();
                //
                string[] axx = nam.Split(new char[1] { '/' });
                form_no = axx[1];       //폼번호
                //
                int rows = grid.Selection.ActivePosition.Row;
                int column = grid.Selection.ActivePosition.Column;
                string row_no = grid[rows, 0].ToString().Trim();
                
                //
                if (form_no.Equals("1"))
                {
                    if (column == 26)
                        GetDangaForm(grid, rows, column, row_no);
                }
                else if (form_no.Equals("2"))
                {
                    if (column == 20)
                        GetDangaForm(grid, rows, column, row_no);
                }
                else if (form_no.Equals("3"))
                {
                    if (column == 18)
                        GetDangaForm(grid, rows, column, row_no);
                }
                else if (form_no.Equals("4"))
                {
                    if (column == 19)
                        GetDangaForm(grid, rows, column, row_no);
                }
                else if (form_no.Equals("5"))
                {
                    if (column == 25)
                        GetDangaForm(grid, rows, column, row_no);
                }
            }

            private void GetDangaForm(SourceGrid.Grid grid, int rows, int column, string row_id)
            {
                SourceGrid.Cells.Views.Cell Mycell = new SourceGrid.Cells.Views.Cell();
                Mycell.TextAlignment = DevAge.Drawing.ContentAlignment.MiddleCenter;

                Form_register_dangaform Frm = new Form_register_dangaform();
                Frm.ShowDialog();
                if (Frm.form_name == "")
                    return;
                string cQuery = " update C_hmachin set form='" + Frm.form_name + "' where row_id='" + row_id + "'";

                ksgcontrol KC = new ksgcontrol();
                KC.ControlInit(Config.DB_con1, "", "", "");
                if (KC.DataUpdate(cQuery) == "-1")
                {
                    MessageBox.Show("서버 업데이트에 실패했습니다)");
                    return;
                }

                grid[rows, column] = new SourceGrid.Cells.Cell(Frm.form_name, typeof(string));
                grid[rows, column].View = Mycell;
                grid.Refresh();
            }
        }
        

        private void make_grid(Form6 fm, string in_no, string x_no)   //(폼,폼번호,a+b코드)
        {
            cell_d cc = new cell_d();
            //
            //콤보박스 셀
            string[] items = new string[] { "Yes", "No" };
            SourceGrid.Cells.Editors.ComboBox combo_cell = new SourceGrid.Cells.Editors.ComboBox(typeof(string), items, false);
            combo_cell.EditableMode = SourceGrid.EditableMode.Default | SourceGrid.EditableMode.SingleClick;

            string[] pantype = new string[1];
            pantype = Get_pantype_combo();
            cb_pantype = new SourceGrid.Cells.Editors.ComboBox(typeof(string), pantype, false);
            cb_pantype.EditableMode = SourceGrid.EditableMode.Focus | SourceGrid.EditableMode.AnyKey | SourceGrid.EditableMode.SingleClick;

            //
            var DBConn = new MySqlConnection(Config.DB_con1);
            DBConn.Open();
            string cQuery = "";
            //
            fm.grid1.Controller.AddController(new ValueChangedEvent());
            fm.grid1.Controller.AddController(new DoubleClickController());
            //
            if (in_no.Equals("1"))  //폼번호  //인쇄기계
            {
                fm.grid1.BorderStyle = BorderStyle.FixedSingle;
                fm.grid1.Font = new Font("굴림체", 9, FontStyle.Regular);
                fm.grid1.ColumnsCount = 30;
                fm.grid1.FixedRows = 2;
                fm.grid1.Rows.Insert(0);
                fm.grid1.Rows[0].Height = 22;
                fm.grid1.Rows.Insert(1);
                fm.grid1.Rows[1].Height = 22;
                //
                fm.grid1[0, 0] = new SourceGrid.Cells.ColumnHeader("row_id");
                fm.grid1[0, 0].RowSpan = 2;
                fm.grid1.Columns[0].Visible = false;

                fm.grid1[0, 1] = new MyHeader1("√");
                fm.grid1[0, 1].RowSpan = 2;
                fm.grid1[0, 2] = new MyHeader1("No");
                fm.grid1[0, 2].RowSpan = 2;
                fm.grid1[0, 3] = new MyHeader1("업종1");
                fm.grid1[0, 3].RowSpan = 2;
                fm.grid1[0, 4] = new MyHeader1("업종2");
                fm.grid1[0, 4].RowSpan = 2;
                fm.grid1[0, 5] = new MyHeader1("도수(통)");
                fm.grid1[0, 5].RowSpan = 2;
                fm.grid1[0, 6] = new MyHeader1("판형");
                fm.grid1[0, 6].RowSpan = 2;
                fm.grid1[0, 7] = new MyHeader1("기종");
                fm.grid1[0, 7].RowSpan = 2;

                fm.grid1[0, 8] = new MyHeader1("기계이름");
                fm.grid1[0, 8].RowSpan = 2;


                fm.grid1[0, 9] = new MyHeader1("년식");
                fm.grid1[0, 9].RowSpan = 2;
                fm.grid1[0, 10] = new MyHeader1("기G");
                fm.grid1[0, 10].RowSpan = 2;
                fm.grid1[0, 11] = new MyHeader1("종G");
                fm.grid1[0, 11].RowSpan = 2;
                fm.grid1[0, 12] = new MyHeader1("판Sz");
                fm.grid1[0, 12].RowSpan = 2;
                fm.grid1[0, 13] = new MyHeader1("종이무게");
                fm.grid1[0, 13].ColumnSpan = 2;
                fm.grid1[0, 15] = new MyHeader1("종이최대Sz");
                fm.grid1[0, 15].ColumnSpan = 2;
                fm.grid1[0, 17] = new MyHeader1("종이최소Sz");
                fm.grid1[0, 17].ColumnSpan = 2;
                fm.grid1[0, 19] = new MyHeader1("CIP");
                fm.grid1[0, 19].RowSpan = 2;
                fm.grid1[0, 20] = new MyHeader1("단가폼");
                fm.grid1[0, 20].RowSpan = 2;
                fm.grid1.Columns[20].Visible = false;
                fm.grid1[0, 21] = new MyHeader1("9절");
                fm.grid1[0, 21].RowSpan = 2;
                fm.grid1[0, 22] = new MyHeader1("8절");
                fm.grid1[0, 22].RowSpan = 2;
                fm.grid1[0, 23] = new MyHeader1("국8절(소)");
                fm.grid1[0, 23].RowSpan = 2;
                fm.grid1[0, 24] = new MyHeader1("국8절(대)");
                fm.grid1[0, 24].RowSpan = 2;
                fm.grid1[0, 25] = new MyHeader1("국4절(소)");
                fm.grid1[0, 25].RowSpan = 2;
                fm.grid1[0, 26] = new MyHeader1("국4절(대)");
                fm.grid1[0, 26].RowSpan = 2;
                fm.grid1[0, 27] = new MyHeader1("단가폼");
                fm.grid1[0, 27].RowSpan = 2;
                fm.grid1[0, 28] = new MyHeader1("확인");
                fm.grid1[0, 28].RowSpan = 2;
                fm.grid1[0, 29] = new MyHeader1("거래");
                fm.grid1[0, 29].RowSpan = 2;
                //
                fm.grid1[1, 13] = new MyHeader("최소");
                fm.grid1[1, 14] = new MyHeader("최대");
                fm.grid1[1, 15] = new MyHeader("가로");
                fm.grid1[1, 16] = new MyHeader("세로");
                fm.grid1[1, 17] = new MyHeader("가로");
                fm.grid1[1, 18] = new MyHeader("세로");
                //
                fm.grid1.Columns[0].Width = 100;
                fm.grid1.Columns[1].Width = 30;
                fm.grid1.Columns[2].Width = 30;
                fm.grid1.Columns[3].Width = 70;  //
                fm.grid1.Columns[4].Width = 80;
                fm.grid1.Columns[5].Width = 60;
                fm.grid1.Columns[6].Width = 60;
                fm.grid1.Columns[7].Width = 200;

                fm.grid1.Columns[8].Width = 150;

                fm.grid1.Columns[9].Width = 50;
                fm.grid1.Columns[10].Width = 50;
                fm.grid1.Columns[11].Width = 50;
                fm.grid1.Columns[12].Width = 90; //
                fm.grid1.Columns[13].Width = 50;
                fm.grid1.Columns[14].Width = 50;
                fm.grid1.Columns[15].Width = 50;
                fm.grid1.Columns[16].Width = 50;
                fm.grid1.Columns[17].Width = 50;
                fm.grid1.Columns[18].Width = 50;
                fm.grid1.Columns[19].Width = 50; //
                fm.grid1.Columns[20].Width = 50; //
                fm.grid1.Columns[21].Width = 60; //
                fm.grid1.Columns[22].Width = 60; //
                fm.grid1.Columns[23].Width = 60; //
                fm.grid1.Columns[24].Width = 60; //
                fm.grid1.Columns[25].Width = 60; //
                fm.grid1.Columns[26].Width = 60; //
                fm.grid1.Columns[27].Width = 60; //
                fm.grid1.Columns[28].Width = 60; //
                fm.grid1.Columns[29].Width = 60; //
                //
                cQuery = " select a.*,b.aitem d1,c.bitem d2, d.hang as pan_hang FROM C_hmachin a";
                cQuery += " Left Outer Join C_amodel b ON b.a_code=a.a_model";
                cQuery += " Left Outer Join C_bmodel c ON c.a_code=a.a_model and c.b_code=a.b_model";
                cQuery += " Left Outer Join hang_manage d ON a.pan_type = d.code1  and d.class = '판형' ";
                cQuery += " where int_id='" + m_no + "' and form_id='" + in_no + "'";  //회사번호,폼번호,A+B코드번호
                var cmd = new MySqlCommand(cQuery, DBConn);
                var myRead = cmd.ExecuteReader();

                int m = 2;
                string confirm = "";
                string deal = "";
                while (myRead.Read())
                {
                    fm.grid1.Rows.Insert(m);
                    fm.grid1.Rows[m].Height = 28;
                    fm.grid1[m, 0] = new SourceGrid.Cells.Cell(myRead["row_id"], typeof(string));
                    fm.grid1[m, 1] = new SourceGrid.Cells.CheckBox(null, false);                 //√
                    fm.grid1[m, 2] = new SourceGrid.Cells.Cell((m - 1), typeof(string));         //No
                    fm.grid1[m, 2].View = cc.center_cell;
                    fm.grid1[m, 3] = new SourceGrid.Cells.Cell(myRead["d1"], typeof(string));     //업종1
                    fm.grid1[m, 3].View = cc.center_cell;
                    fm.grid1[m, 4] = new SourceGrid.Cells.Cell(myRead["d2"], typeof(string));     //업종2
                    fm.grid1[m, 4].View = cc.center_cell;
                    fm.grid1[m, 5] = new SourceGrid.Cells.Cell(myRead["dosu"], typeof(string));     //도수(통)
                    fm.grid1[m, 5].View = cc.center_cell;
                    fm.grid1[m, 6] = new SourceGrid.Cells.Cell(myRead["pan_hang"], typeof(string));     //판형
                    fm.grid1[m, 6].View = cc.center_cell;
                    fm.grid1[m, 6].Editor = cb_pantype;
                    fm.grid1[m, 7] = new SourceGrid.Cells.Cell(myRead["machin_model"], typeof(string)); //기종
                    fm.grid1[m, 8] = new SourceGrid.Cells.Cell(myRead["machin_name"], typeof(string)); //기종

                    fm.grid1[m, 9] = new SourceGrid.Cells.Cell(myRead["year_type"], typeof(string));    //년식
                    fm.grid1[m, 9].View = cc.center_cell;
                    fm.grid1[m,10] = new SourceGrid.Cells.Cell(myRead["machin_guy"], typeof(string));     //기계G
                    fm.grid1[m,10].View = cc.center_cell;
                    fm.grid1[m, 11] = new SourceGrid.Cells.Cell(myRead["paper_guy"], typeof(string));     //종이G
                    fm.grid1[m, 11].View = cc.center_cell;
                    fm.grid1[m, 12] = new SourceGrid.Cells.Cell(myRead["pan_size"], typeof(string));    //판Size
                    fm.grid1[m, 12].View = cc.center_cell;
                    fm.grid1[m, 13] = new SourceGrid.Cells.Cell(myRead["p_weight_min"], typeof(string));    //종이무게(최소)
                    fm.grid1[m, 13].View = cc.int_cell;
                    fm.grid1[m, 13].Editor = cc.int_editor;
                    fm.grid1[m, 14] = new SourceGrid.Cells.Cell(myRead["p_weight_max"], typeof(string));    //종이무게(최대)
                    fm.grid1[m, 14].View = cc.int_cell;
                    fm.grid1[m, 14].Editor = cc.int_editor;
                    fm.grid1[m, 15] = new SourceGrid.Cells.Cell(myRead["p_garo_max"], typeof(string));    //종이최대size(가로)
                    fm.grid1[m, 15].View = cc.int_cell;
                    fm.grid1[m, 15].Editor = cc.int_editor;
                    fm.grid1[m, 16] = new SourceGrid.Cells.Cell(myRead["p_sero_max"], typeof(string));    //종이최대size(세로)
                    fm.grid1[m, 16].View = cc.int_cell;
                    fm.grid1[m, 16].Editor = cc.int_editor;
                    fm.grid1[m, 17] = new SourceGrid.Cells.Cell(myRead["p_garo_min"], typeof(string));    //종이최소size(가로)
                    fm.grid1[m, 17].View = cc.int_cell;
                    fm.grid1[m, 17].Editor = cc.int_editor;
                    fm.grid1[m, 18] = new SourceGrid.Cells.Cell(myRead["p_sero_min"], typeof(string));    //종이최소size(세로)
                    fm.grid1[m, 18].View = cc.int_cell;
                    fm.grid1[m, 18].Editor = cc.int_editor;
                    fm.grid1[m, 19] = new SourceGrid.Cells.Cell(myRead["cip"], typeof(string));    //CIP
                    fm.grid1[m, 19].View = cc.center_cell;
                    fm.grid1[m, 19].Editor = combo_cell;
                    fm.grid1[m, 20] = new SourceGrid.Cells.Cell(myRead["form"], typeof(string));   //단가폼
                    fm.grid1[m, 20].View = cc.center_cell;
                    fm.grid1[m, 20].Editor = cc.disable_cell;
                    fm.grid1[m, 21] = new SourceGrid.Cells.Cell(myRead["p46_9"], typeof(string));   //46 9절
                    fm.grid1[m, 21].View = cc.center_cell;
                    fm.grid1[m, 22] = new SourceGrid.Cells.Cell(myRead["p46_8"], typeof(string));   //46 8절
                    fm.grid1[m, 22].View = cc.center_cell;
                    fm.grid1[m, 23] = new SourceGrid.Cells.Cell(myRead["kook_8_sin"], typeof(string));   //국8절 신국판
                    fm.grid1[m, 23].View = cc.center_cell;
                    fm.grid1[m, 24] = new SourceGrid.Cells.Cell(myRead["kook_8_kook"], typeof(string));   //국8절 국배판
                    fm.grid1[m, 24].View = cc.center_cell;
                    fm.grid1[m, 25] = new SourceGrid.Cells.Cell(myRead["kook_4_s"], typeof(string));   //국4절
                    fm.grid1[m, 25].View = cc.center_cell;
                    fm.grid1[m, 26] = new SourceGrid.Cells.Cell(myRead["kook_4_b"], typeof(string));   //국4절(대)
                    fm.grid1[m, 26].View = cc.center_cell;
                    fm.grid1[m, 27] = new SourceGrid.Cells.Cell(myRead["danga_form"], typeof(string));   //단가
                    fm.grid1[m, 27].View = cc.center_cellb;

                    if (myRead["confirm"].ToString() == "False" || myRead["confirm"].ToString() == "false")
                        confirm = "N";
                    else
                        confirm = "Y";
                    fm.grid1[m, 28] = new SourceGrid.Cells.Cell(confirm, typeof(string));   //확인
                    fm.grid1[m, 28].View = cc.center_cellb;
                    fm.grid1[m, 28].Editor = combo_cell;

                    if (myRead["deal_state"].ToString() == "False" || myRead["deal_state"].ToString() == "false")
                        deal = "N";
                    else
                        deal = "Y";
                    fm.grid1[m, 29] = new SourceGrid.Cells.Cell(deal, typeof(string));   //거래유무
                    fm.grid1[m, 29].View = cc.center_cellb;
                    fm.grid1[m, 29].Editor = combo_cell;
                    m++;
                }
                myRead.Close();
                DBConn.Close();
            }
            else if (in_no.Equals("2"))  //제본기계
            {
                fm.grid1.BorderStyle = BorderStyle.FixedSingle;
                fm.grid1.Font = new Font("굴림체", 9, FontStyle.Regular);
                fm.grid1.ColumnsCount = 24;
                fm.grid1.FixedRows = 2;
                fm.grid1.Rows.Insert(0);
                fm.grid1.Rows[0].Height = 22;
                fm.grid1.Rows.Insert(1);
                fm.grid1.Rows[1].Height = 22;

                fm.grid1[0, 0] = new SourceGrid.Cells.ColumnHeader("row_id");
                fm.grid1[0, 0].RowSpan = 2;
                fm.grid1.Columns[0].Visible = false;

                fm.grid1[0, 1] = new MyHeader1("√");
                fm.grid1[0, 1].RowSpan = 2;

                fm.grid1[0, 2] = new MyHeader1("No");
                fm.grid1[0, 2].RowSpan = 2;

                fm.grid1[0, 3] = new MyHeader1("업종1");
                fm.grid1[0, 3].RowSpan = 2;

                fm.grid1[0, 4] = new MyHeader1("업종2");
                fm.grid1[0, 4].RowSpan = 2;

                fm.grid1[0, 5] = new MyHeader1("기계이름");
                fm.grid1[0, 5].RowSpan = 2;

                fm.grid1[0, 6] = new MyHeader1("인쇄방식");
                fm.grid1[0, 6].RowSpan = 2;

                fm.grid1[0, 7] = new MyHeader1("기  종");
                fm.grid1[0, 7].RowSpan = 2;

                fm.grid1[0, 8] = new MyHeader1("년식");
                fm.grid1[0, 8].RowSpan = 2;

                fm.grid1[0, 9] = new MyHeader1("표지 최소");
                fm.grid1[0, 9].ColumnSpan = 2;

                fm.grid1[0, 11] = new MyHeader1("표지 최대");
                fm.grid1[0, 11].ColumnSpan = 2;

                fm.grid1[0, 13] = new MyHeader1("최소 책싸이즈");
                fm.grid1[0, 13].ColumnSpan = 2;

                fm.grid1[0, 15] = new MyHeader1("최대 책싸이즈");
                fm.grid1[0, 15].ColumnSpan = 2;

                fm.grid1[0, 17] = new MyHeader1("책두께(세네카)");
                fm.grid1[0, 17].ColumnSpan = 2;

                fm.grid1[0, 19] = new MyHeader1("콤마수");
                fm.grid1[0, 19].RowSpan = 2;

                fm.grid1[0, 20] = new MyHeader1("단가폼");
                fm.grid1[0, 20].RowSpan = 2;

                fm.grid1[0, 21] = new MyHeader1("확인");
                fm.grid1[0, 21].RowSpan = 2;

                fm.grid1[0, 22] = new MyHeader1("거래");
                fm.grid1[0, 22].RowSpan = 2;
                // grid1.Rows.Insert(1);

                fm.grid1[1, 9] = new MyHeader1("가로");
                fm.grid1[1, 10] = new MyHeader1("세로");
                fm.grid1[1, 11] = new MyHeader("가로");
                fm.grid1[1, 12] = new MyHeader("세로");
                fm.grid1[1, 13] = new MyHeader("가로");
                fm.grid1[1, 14] = new MyHeader("세로");
                fm.grid1[1, 15] = new MyHeader("가로");
                fm.grid1[1, 16] = new MyHeader("세로");
                fm.grid1[1, 17] = new MyHeader("최대");
                fm.grid1[1, 18] = new MyHeader("최소");
                //
                fm.grid1.Columns[0].Width = 100;
                fm.grid1.Columns[1].Width = 30;
                fm.grid1.Columns[2].Width = 30;
                fm.grid1.Columns[3].Width = 50;  //업종-1
                fm.grid1.Columns[4].Width = 90;  //업종-2
                fm.grid1.Columns[5].Width = 70;  //기계이름
                fm.grid1.Columns[6].Width = 80;  //인쇄방식
                fm.grid1.Columns[7].Width = 130;  //기종 
                fm.grid1.Columns[8].Width = 50;  //년식
                fm.grid1.Columns[9].Width = 50;  //표지최소
                fm.grid1.Columns[10].Width = 50;  //
                fm.grid1.Columns[11].Width = 50; //표지최대
                fm.grid1.Columns[12].Width = 50; //
                fm.grid1.Columns[13].Width = 50; //최소책싸이즈
                fm.grid1.Columns[14].Width = 50; //
                fm.grid1.Columns[15].Width = 50; //최대책싸이즈
                fm.grid1.Columns[16].Width = 50; //
                fm.grid1.Columns[17].Width = 50; //책두께(세네카)
                fm.grid1.Columns[18].Width = 50; //
                fm.grid1.Columns[19].Width = 50; //콤마수
                fm.grid1.Columns[20].Width = 50; //단가폼
                fm.grid1.Columns[21].Width = 50; //확인
                fm.grid1.Columns[22].Width = 50; //거래유무
                //
                cQuery = " select a.*,b.aitem d1,c.bitem d2,d.bitem d3  FROM C_hmachin a";
                cQuery += " Left Outer Join C_amodel b ON b.a_code=a.a_model";
                cQuery += " Left Outer Join C_bmodel c ON c.a_code=a.a_model and c.b_code=a.b_model";
                cQuery += " Left Outer Join C_bmodel d ON d.a_code='08' and d.b_code=a.print_type";
                cQuery += " where int_id='" + m_no + "' and form_id='" + in_no + "'";  //회사번호,폼번호,A+B코드번호
                var cmd = new MySqlCommand(cQuery, DBConn);
                var myRead = cmd.ExecuteReader();

                int m = 2;
                string confirm = "";
                string deal = "";
                while (myRead.Read())
                {
                    fm.grid1.Rows.Insert(m);
                    fm.grid1.Rows[m].Height = 24;

                    fm.grid1.Rows.Insert(m);
                    fm.grid1.Rows[m].Height = 24;
                    fm.grid1[m, 0] = new SourceGrid.Cells.Cell(myRead["row_id"], typeof(string));
                    fm.grid1[m, 1] = new SourceGrid.Cells.CheckBox(null, false);            //"√"
                    fm.grid1[m, 2] = new SourceGrid.Cells.Cell(myRead["no"], typeof(string));//No
                    fm.grid1[m, 2].Editor = cc.disable_cell;
                    fm.grid1[m, 2].View = cc.center_cell;
                    fm.grid1[m, 3] = new SourceGrid.Cells.Cell(myRead["d1"], typeof(string));//"업종1"
                    fm.grid1[m, 3].Editor = cc.disable_cell;
                    fm.grid1[m, 3].View = cc.left_cell;
                    fm.grid1[m, 4] = new SourceGrid.Cells.Cell(myRead["d2"], typeof(string));//"업종2"
                    fm.grid1[m, 4].Editor = cc.disable_cell;
                    fm.grid1[m, 4].View = cc.left_cell;
                    fm.grid1[m, 5] = new SourceGrid.Cells.Cell(myRead["machin_name"], typeof(string));//"기계이름"
                    fm.grid1[m, 6] = new SourceGrid.Cells.Cell(myRead["d3"], typeof(string)); //"인쇄방식"
                    fm.grid1[m, 6].View = cc.center_cellb;
                    fm.grid1[m, 6].Editor = cc.disable_cell;
                    fm.grid1[m, 7] = new SourceGrid.Cells.Cell(myRead["machin_model"], typeof(string));//"기  종"
                    fm.grid1[m, 8] = new SourceGrid.Cells.Cell(myRead["year_type"], typeof(string));//"년식"
                    fm.grid1[m, 8].View = cc.center_cell;
                    fm.grid1[m, 9] = new SourceGrid.Cells.Cell(myRead["c_garo_min"], typeof(string));//"표지 최소(가로)"
                    fm.grid1[m, 9].View = cc.int_cell;
                    fm.grid1[m, 10] = new SourceGrid.Cells.Cell(myRead["c_sero_min"], typeof(string));//"표지 최소(세로)"
                    fm.grid1[m, 10].View = cc.int_cell;
                    fm.grid1[m, 11] = new SourceGrid.Cells.Cell(myRead["c_garo_max"], typeof(string));//"표지 최대(가로)"
                    fm.grid1[m, 11].View = cc.int_cell;
                    fm.grid1[m, 12] = new SourceGrid.Cells.Cell(myRead["c_sero_max"], typeof(string));//"표지 최대(세로)"
                    fm.grid1[m, 12].View = cc.int_cell;
                    fm.grid1[m, 13] = new SourceGrid.Cells.Cell(myRead["d_garo_min"], typeof(string));//"최소 책싸이즈(가로)"
                    fm.grid1[m, 13].View = cc.int_cell;
                    fm.grid1[m, 14] = new SourceGrid.Cells.Cell(myRead["d_sero_min"], typeof(string));//"최소 책싸이즈(세로)"
                    fm.grid1[m, 14].View = cc.int_cell;
                    fm.grid1[m, 15] = new SourceGrid.Cells.Cell(myRead["d_garo_max"], typeof(string));//"최대 책싸이즈(가로)"
                    fm.grid1[m, 15].View = cc.int_cell;
                    fm.grid1[m, 16] = new SourceGrid.Cells.Cell(myRead["d_sero_max"], typeof(string));//"최대 책싸이즈(세로)"
                    fm.grid1[m, 16].View = cc.int_cell;
                    fm.grid1[m, 17] = new SourceGrid.Cells.Cell(myRead["seneca_max"], typeof(string));//"책두께(세네카)(최대)
                    fm.grid1[m, 17].View = cc.int_cell;
                    fm.grid1[m, 18] = new SourceGrid.Cells.Cell(myRead["seneca_min"], typeof(string));//"책두께(세네카)(최소)
                    fm.grid1[m, 18].View = cc.int_cell;
                    fm.grid1[m, 19] = new SourceGrid.Cells.Cell(myRead["koma_su"], typeof(string)); //"콤마수";
                    fm.grid1[m, 19].View = cc.int_cell;
                    fm.grid1[m, 20] = new SourceGrid.Cells.Cell(myRead["danga_form"], typeof(string));//"단가폼";
                    fm.grid1[m, 20].View = cc.center_cellb;
                    if (myRead["confirm"].ToString() == "False" || myRead["confirm"].ToString() == "false")
                        confirm = "N";
                    else
                        confirm = "Y";
                    fm.grid1[m, 21] = new SourceGrid.Cells.Cell(confirm, typeof(string));   //단가
                    fm.grid1[m, 21].View = cc.center_cellb;
                    fm.grid1[m, 21].Editor = combo_cell;

                    if (myRead["deal_state"].ToString() == "False" || myRead["deal_state"].ToString() == "false")
                        deal = "N";
                    else
                        deal = "Y";
                    fm.grid1[m, 22] = new SourceGrid.Cells.Cell(deal, typeof(string));   //거래유무
                    fm.grid1[m, 22].View = cc.center_cellb;
                    fm.grid1[m, 22].Editor = combo_cell;
                    m++;
                }
                myRead.Close();
                DBConn.Close();
            }
            else if (in_no.Equals("3"))  //코팅기계
            {
                fm.grid1.BorderStyle = BorderStyle.FixedSingle;
                fm.grid1.Font = new Font("굴림체", 9, FontStyle.Regular);
                fm.grid1.ColumnsCount = 21;
                fm.grid1.FixedRows = 2;
                fm.grid1.Rows.Insert(0);
                fm.grid1.Rows[0].Height = 22;
                fm.grid1.Rows.Insert(1);
                fm.grid1.Rows[1].Height = 22;

                fm.grid1[0, 0] = new SourceGrid.Cells.ColumnHeader("row_id");
                fm.grid1[0, 0].RowSpan = 2;
                fm.grid1.Columns[0].Visible = false;

                fm.grid1[0, 1] = new MyHeader1("√");
                fm.grid1[0, 1].RowSpan = 2;

                fm.grid1[0, 2] = new MyHeader1("No");
                fm.grid1[0, 2].RowSpan = 2;

                fm.grid1[0, 3] = new MyHeader1("업종1");
                fm.grid1[0, 3].RowSpan = 2;

                fm.grid1[0, 4] = new MyHeader1("업종2");
                fm.grid1[0, 4].RowSpan = 2;

                fm.grid1[0, 5] = new MyHeader1("업종3");
                fm.grid1[0, 5].RowSpan = 2;
                fm.grid1.Columns[5].Visible = false;

                fm.grid1[0, 6] = new MyHeader1("기계이름");
                fm.grid1[0, 6].RowSpan = 2;

                fm.grid1[0, 7] = new MyHeader1("판형");
                fm.grid1[0, 7].RowSpan = 2;

                fm.grid1[0, 8] = new MyHeader1("기  종");
                fm.grid1[0, 8].RowSpan = 2;

                fm.grid1[0, 9] = new MyHeader1("년식");
                fm.grid1[0, 9].RowSpan = 2;

                fm.grid1[0, 10] = new MyHeader1("수량");
                fm.grid1[0, 10].RowSpan = 2;

                fm.grid1[0, 11] = new MyHeader1("종이G");
                fm.grid1[0, 11].RowSpan = 2;

                fm.grid1[0, 12] = new MyHeader1("종이무게");
                fm.grid1[0, 12].ColumnSpan = 2;

                fm.grid1[0, 14] = new MyHeader1("종이 최대싸이즈");
                fm.grid1[0, 14].ColumnSpan = 2;

                fm.grid1[0, 16] = new MyHeader1("종이 최소싸이즈");
                fm.grid1[0, 16].ColumnSpan = 2;

                fm.grid1[0, 18] = new MyHeader1("단가폼");
                fm.grid1[0, 18].RowSpan = 2;

                fm.grid1[0, 19] = new MyHeader1("확인");
                fm.grid1[0, 19].RowSpan = 2;

                fm.grid1[0, 20] = new MyHeader1("거래");
                fm.grid1[0, 20].RowSpan = 2;

                // fm.grid1.Rows.Insert(1);
                fm.grid1[1, 12] = new MyHeader("최소");
                fm.grid1[1, 13] = new MyHeader("최대");
                fm.grid1[1, 14] = new MyHeader("가로");
                fm.grid1[1, 15] = new MyHeader("세로");
                fm.grid1[1, 16] = new MyHeader("최대");
                fm.grid1[1, 17] = new MyHeader("최소");
                //
                fm.grid1.Columns[0].Width = 100;
                fm.grid1.Columns[1].Width = 30;
                fm.grid1.Columns[2].Width = 30;  //no
                fm.grid1.Columns[3].Width = 70;  //업종-1
                fm.grid1.Columns[4].Width = 80;  //업종-2
                fm.grid1.Columns[5].Width = 100; //업종-3
                fm.grid1.Columns[6].Width = 90;  //기계이름
                fm.grid1.Columns[7].Width = 60;  //판형
                fm.grid1.Columns[8].Width = 120; //기종 
                fm.grid1.Columns[9].Width = 40;  //년식
                fm.grid1.Columns[10].Width = 40; //수량
                fm.grid1.Columns[11].Width = 60; //종이G
                fm.grid1.Columns[12].Width = 60; //종이무게
                fm.grid1.Columns[13].Width = 60; //
                fm.grid1.Columns[14].Width = 60; //종이최대싸이즈
                fm.grid1.Columns[15].Width = 60; //
                fm.grid1.Columns[16].Width = 60; //종이최소싸이즈
                fm.grid1.Columns[17].Width = 60; //
                fm.grid1.Columns[18].Width = 50; //단가폼
                fm.grid1.Columns[19].Width = 50; //확인
                fm.grid1.Columns[20].Width = 50; //거래유무
                //
                cQuery = " select a.*,b.aitem d1,c.bitem d2,d.citem d3, e.hang as pan_hang FROM C_hmachin a";
                cQuery += " Left Outer Join C_amodel b ON b.a_code=a.a_model";
                cQuery += " Left Outer Join C_bmodel c ON c.a_code=a.a_model and c.b_code=a.b_model";
                cQuery += " Left Outer Join C_cmodel d ON d.a_code=a.a_model and d.b_code=a.b_model and d.c_code=a.c_model";
                cQuery += " Left Outer Join hang_manage e ON a.pan_type = e.code1  and e.class = '판형'";
                cQuery += " where int_id='" + m_no + "' and form_id='" + in_no + "'";  //회사번호,폼번호,A+B코드번호
                var cmd = new MySqlCommand(cQuery, DBConn);
                var myRead = cmd.ExecuteReader();

                int m = 2;
                string confirm = "";
                string deal = "";
                while (myRead.Read())
                {
                    fm.grid1.Rows.Insert(m);
                    fm.grid1.Rows[m].Height = 24;
                    fm.grid1[m, 0] = new SourceGrid.Cells.Cell(myRead["row_id"], typeof(string));
                    fm.grid1[m, 1] = new SourceGrid.Cells.CheckBox(null, false);               //√
                    fm.grid1[m, 2] = new SourceGrid.Cells.Cell(myRead["no"], typeof(string));   //no
                    fm.grid1[m, 2].Editor = cc.disable_cell;
                    fm.grid1[m, 2].View = cc.center_cell;
                    fm.grid1[m, 3] = new SourceGrid.Cells.Cell(myRead["d1"], typeof(string));   //업종1 
                    fm.grid1[m, 3].Editor = cc.disable_cell;
                    fm.grid1[m, 4] = new SourceGrid.Cells.Cell(myRead["d2"], typeof(string));   //업종2
                    fm.grid1[m, 4].Editor = cc.disable_cell;
                    fm.grid1[m, 5] = new SourceGrid.Cells.Cell(myRead["d3"], typeof(string));   //업종3
                    fm.grid1[m, 5].Editor = cc.disable_cell;
                    fm.grid1[m, 6] = new SourceGrid.Cells.Cell(myRead["machin_name"], typeof(string));  //기계이름 
                    fm.grid1[m, 7] = new SourceGrid.Cells.Cell(myRead["pan_hang"], typeof(string));     //판형
                    fm.grid1[m, 7].Editor = cb_pantype;
                    fm.grid1[m, 8] = new SourceGrid.Cells.Cell(myRead["machin_model"], typeof(string)); //기종
                    fm.grid1[m, 9] = new SourceGrid.Cells.Cell(myRead["year_type"], typeof(string));    //년식 
                    fm.grid1[m, 9].View = cc.center_cell;
                    fm.grid1[m, 10] = new SourceGrid.Cells.Cell(myRead["machin_su"], typeof(string));  //수량;
                    fm.grid1[m, 10].View = cc.center_cell;
                    fm.grid1[m, 11] = new SourceGrid.Cells.Cell(myRead["paper_guy"], typeof(string));  //종이G
                    fm.grid1[m, 11].View = cc.center_cell;
                    fm.grid1[m, 12] = new SourceGrid.Cells.Cell(myRead["p_weight_min"], typeof(string));  //종이무게(최소) 
                    fm.grid1[m, 12].View = cc.int_cell;
                    fm.grid1[m, 13] = new SourceGrid.Cells.Cell(myRead["p_weight_max"], typeof(string));  //종이무게(최대)
                    fm.grid1[m, 13].View = cc.int_cell;
                    fm.grid1[m, 14] = new SourceGrid.Cells.Cell(myRead["p_garo_max"], typeof(string));  //종이 최대싸이즈(가로)
                    fm.grid1[m, 14].View = cc.int_cell;
                    fm.grid1[m, 15] = new SourceGrid.Cells.Cell(myRead["p_sero_max"], typeof(string));  //종이 최대싸이즈(세로) 
                    fm.grid1[m, 15].View = cc.int_cell;
                    fm.grid1[m, 16] = new SourceGrid.Cells.Cell(myRead["p_garo_min"], typeof(string));  //종이 최소싸이즈(가로)
                    fm.grid1[m, 16].View = cc.int_cell;
                    fm.grid1[m, 17] = new SourceGrid.Cells.Cell(myRead["p_sero_min"], typeof(string));  //종이 최소싸이즈(세로)
                    fm.grid1[m, 17].View = cc.int_cell;
                    fm.grid1[m, 18] = new SourceGrid.Cells.Cell(myRead["danga_form"], typeof(string)); //단가폼
                    fm.grid1[m, 18].View = cc.center_cellb;

                    if (myRead["confirm"].ToString() == "False" || myRead["confirm"].ToString() == "false")
                        confirm = "N";
                    else
                        confirm = "Y";
                    fm.grid1[m, 19] = new SourceGrid.Cells.Cell(confirm, typeof(string));   //단가
                    fm.grid1[m, 19].View = cc.center_cellb;
                    fm.grid1[m, 19].Editor = combo_cell;

                    if (myRead["deal_state"].ToString() == "False" || myRead["deal_state"].ToString() == "false")
                        deal = "N";
                    else
                        deal = "Y";
                    fm.grid1[m, 20] = new SourceGrid.Cells.Cell(deal, typeof(string));   //거래유무
                    fm.grid1[m, 20].View = cc.center_cellb;
                    fm.grid1[m, 20].Editor = combo_cell;
                    m++;
                }
                myRead.Close();
                DBConn.Close();
            }
            else if (in_no.Equals("4"))  //접지기계
            {
                fm.grid1.BorderStyle = BorderStyle.FixedSingle;
                fm.grid1.Font = new Font("굴림체", 9, FontStyle.Regular);
                fm.grid1.ColumnsCount = 22;
                fm.grid1.FixedRows = 2;
                fm.grid1.Rows.Insert(0);
                fm.grid1.Rows[0].Height = 22;
                fm.grid1.Rows.Insert(1);
                fm.grid1.Rows[1].Height = 22;
                //  
                fm.grid1[0, 0] = new SourceGrid.Cells.ColumnHeader("row_id");
                fm.grid1[0, 0].RowSpan = 2;
                fm.grid1.Columns[0].Visible = false;
                fm.grid1[0, 1] = new MyHeader1("√");
                fm.grid1[0, 1].RowSpan = 2;
                fm.grid1[0, 2] = new MyHeader1("No");
                fm.grid1[0, 2].RowSpan = 2;
                fm.grid1[0, 3] = new MyHeader1("업종1");
                fm.grid1[0, 3].RowSpan = 2;
                fm.grid1[0, 4] = new MyHeader1("업종2");
                fm.grid1[0, 4].RowSpan = 2;
                fm.grid1[0, 5] = new MyHeader1("기계이름");
                fm.grid1[0, 5].RowSpan = 2;
                fm.grid1[0, 6] = new MyHeader1("판형");
                fm.grid1[0, 6].RowSpan = 2;
                fm.grid1[0, 7] = new MyHeader1("기  종");
                fm.grid1[0, 7].RowSpan = 2;
                fm.grid1[0, 8] = new MyHeader1("년식");
                fm.grid1[0, 8].RowSpan = 2;
                fm.grid1[0, 9] = new MyHeader1("수량");
                fm.grid1[0, 9].RowSpan = 2;
                fm.grid1[0, 10] = new MyHeader1("종이구와이");
                fm.grid1[0, 10].ColumnSpan = 2;
                fm.grid1[0, 12] = new MyHeader1("종이최대싸이즈");
                fm.grid1[0, 12].ColumnSpan = 2;
                fm.grid1[0, 14] = new MyHeader1("종이최소싸이즈");
                fm.grid1[0, 14].ColumnSpan = 2;
                fm.grid1[0, 16] = new MyHeader1("발   체");
                fm.grid1[0, 16].ColumnSpan = 2;
                fm.grid1[0, 18] = new MyHeader1("최소접지간격");
                fm.grid1[0, 18].RowSpan = 2;
                fm.grid1[0, 19] = new MyHeader1("단가폼");
                fm.grid1[0, 19].RowSpan = 2;
                fm.grid1[0, 20] = new MyHeader1("확인");
                fm.grid1[0, 20].RowSpan = 2;
                fm.grid1[0, 21] = new MyHeader1("거래");
                fm.grid1[0, 21].RowSpan = 2;
                //
                fm.grid1[1, 10] = new MyHeader("최소");
                fm.grid1[1, 11] = new MyHeader("최대");
                fm.grid1[1, 12] = new MyHeader("구와이");
                fm.grid1[1, 13] = new MyHeader("하리");
                fm.grid1[1, 14] = new MyHeader("구와이");
                fm.grid1[1, 15] = new MyHeader("하리");
                fm.grid1[1, 16] = new MyHeader("1차");
                fm.grid1[1, 17] = new MyHeader("2차");
                //
                fm.grid1.Columns[0].Width = 100;
                fm.grid1.Columns[1].Width = 30;
                fm.grid1.Columns[2].Width = 30;
                fm.grid1.Columns[3].Width = 60;  //업종-1
                fm.grid1.Columns[4].Width = 70;  //업종-2
                fm.grid1.Columns[5].Width = 120; //기계이름
                fm.grid1.Columns[6].Width = 60;  //판형 
                fm.grid1.Columns[7].Width = 50;  //기종
                fm.grid1.Columns[8].Width = 50;  //년식
                fm.grid1.Columns[9].Width = 50;  //수량
                fm.grid1.Columns[10].Width = 50; //종이구와이1
                fm.grid1.Columns[11].Width = 50; //종이구와이2
                fm.grid1.Columns[12].Width = 50; //종이최대싸이즈1
                fm.grid1.Columns[13].Width = 50; //종이최대싸이즈2
                fm.grid1.Columns[14].Width = 50; //종이최소싸이즈1
                fm.grid1.Columns[15].Width = 50;//종이최소싸이즈2
                fm.grid1.Columns[16].Width = 50; //발체1
                fm.grid1.Columns[17].Width = 50; //발체2
                fm.grid1.Columns[18].Width = 80; //최소접지간격
                fm.grid1.Columns[19].Width = 60; //단가폼
                fm.grid1.Columns[20].Width = 60; //확인
                fm.grid1.Columns[21].Width = 60; //거래
                //
                cQuery = " select a.*,b.aitem d1,c.bitem d2, d.hang as pan_hang FROM C_hmachin a";
                cQuery += " Left Outer Join C_amodel b ON b.a_code=a.a_model";
                cQuery += " Left Outer Join C_bmodel c ON c.a_code=a.a_model and c.b_code=a.b_model";
                cQuery += " Left Outer Join hang_manage d ON a.pan_type = d.code1  and d.class = '판형' ";
                cQuery += " where int_id='" + m_no + "' and form_id='" + in_no + "'";  //회사번호,폼번호,A+B코드번호
                var cmd = new MySqlCommand(cQuery, DBConn);
                var myRead = cmd.ExecuteReader();

                int m = 2;
                string confirm = "";
                string deal = "";
                while (myRead.Read())
                {
                    fm.grid1.Rows.Insert(m);
                    fm.grid1.Rows[m].Height = 24;
                    fm.grid1[m, 0] = new SourceGrid.Cells.Cell(myRead["row_id"], typeof(string));
                    fm.grid1[m, 1] = new SourceGrid.Cells.CheckBox(null, false);              //√
                    fm.grid1[m, 2] = new SourceGrid.Cells.Cell(myRead["no"], typeof(string));  //no
                    fm.grid1[m, 2].Editor = cc.disable_cell;
                    fm.grid1[m, 2].View = cc.center_cell;
                    fm.grid1[m, 3] = new SourceGrid.Cells.Cell(myRead["d1"], typeof(string));  //업종1
                    fm.grid1[m, 3].Editor = cc.disable_cell;
                    fm.grid1[m, 4] = new SourceGrid.Cells.Cell(myRead["d2"], typeof(string));  //업종2  
                    fm.grid1[m, 4].Editor = cc.disable_cell;
                    fm.grid1[m, 5] = new SourceGrid.Cells.Cell(myRead["machin_name"], typeof(string));  //기계이름
                    fm.grid1[m, 6] = new SourceGrid.Cells.Cell(myRead["pan_hang"], typeof(string));  //판형
                    fm.grid1[m, 6].Editor = cb_pantype;
                    fm.grid1[m, 7] = new SourceGrid.Cells.Cell(myRead["machin_model"], typeof(string));  //기종
                    fm.grid1[m, 7].View = cc.center_cell;
                    fm.grid1[m, 8] = new SourceGrid.Cells.Cell(myRead["year_type"], typeof(string));  //년식              
                    fm.grid1[m, 8].View = cc.int_cell;
                    fm.grid1[m, 9] = new SourceGrid.Cells.Cell(myRead["machin_su"], typeof(string));  //수량
                    fm.grid1[m, 9].View = cc.int_cell;
                    fm.grid1[m, 10] = new SourceGrid.Cells.Cell(myRead["p_weight_min"], typeof(string));  //종이무게(최소)
                    fm.grid1[m, 10].View = cc.int_cell;
                    fm.grid1[m, 11] = new SourceGrid.Cells.Cell(myRead["p_weight_max"], typeof(string));  //종이무게(최대) 
                    fm.grid1[m, 11].View = cc.int_cell;
                    fm.grid1[m, 12] = new SourceGrid.Cells.Cell(myRead["p_garo_max"], typeof(string));  //종이최대싸이즈(구와이)
                    fm.grid1[m, 12].View = cc.int_cell;
                    fm.grid1[m, 13] = new SourceGrid.Cells.Cell(myRead["p_sero_max"], typeof(string));  //종이최대싸이즈(하리)
                    fm.grid1[m, 13].View = cc.int_cell;
                    fm.grid1[m, 14] = new SourceGrid.Cells.Cell(myRead["p_garo_min"], typeof(string));  //종이최소싸이즈(구와이)
                    fm.grid1[m, 14].View = cc.int_cell;
                    fm.grid1[m, 15] = new SourceGrid.Cells.Cell(myRead["p_garo_min"], typeof(string));  //종이최소싸이즈(하리)
                    fm.grid1[m, 15].View = cc.int_cell;
                    fm.grid1[m, 16] = new SourceGrid.Cells.Cell(myRead["balche_1"], typeof(string)); //발체1
                    fm.grid1[m, 17] = new SourceGrid.Cells.Cell(myRead["balche_2"], typeof(string)); //발체2
                    fm.grid1[m, 18] = new SourceGrid.Cells.Cell(myRead["jubji_min_gap"], typeof(string)); //최소접지간격
                    fm.grid1[m, 19] = new SourceGrid.Cells.Cell(myRead["danga_form"], typeof(string)); //단가폼
                    fm.grid1[m, 19].View = cc.center_cellb;
                    if (myRead["confirm"].ToString() == "False" || myRead["confirm"].ToString() == "false")
                        confirm = "N";
                    else
                        confirm = "Y";
                    fm.grid1[m, 20] = new SourceGrid.Cells.Cell(confirm, typeof(string));   //단가
                    fm.grid1[m, 20].View = cc.center_cellb;
                    fm.grid1[m, 20].Editor = combo_cell;

                    if (myRead["deal_state"].ToString() == "False" || myRead["deal_state"].ToString() == "false")
                        deal = "N";
                    else
                        deal = "Y";
                    fm.grid1[m, 21] = new SourceGrid.Cells.Cell(deal, typeof(string));   //거래유무
                    fm.grid1[m, 21].View = cc.center_cellb;
                    fm.grid1[m, 21].Editor = combo_cell;
                    m++;
                }
                myRead.Close();
                DBConn.Close();
            }
            else if (in_no.Equals("5"))
            {
                fm.grid1.BorderStyle = BorderStyle.FixedSingle;
                fm.grid1.Font = new Font("굴림체", 9, FontStyle.Regular);
                fm.grid1.ColumnsCount = 28;
                fm.grid1.FixedRows = 2;
                fm.grid1.Rows.Insert(0);
                fm.grid1.Rows[0].Height = 22;
                fm.grid1.Rows.Insert(1);
                fm.grid1.Rows[1].Height = 22;
                //
                fm.grid1[0, 0] = new SourceGrid.Cells.ColumnHeader("row_id");
                fm.grid1[0, 0].RowSpan = 2;
                fm.grid1.Columns[0].Visible = false;
                fm.grid1[0, 1] = new MyHeader1("√");
                fm.grid1[0, 1].RowSpan = 2;
                fm.grid1[0, 2] = new MyHeader1("No");
                fm.grid1[0, 2].RowSpan = 2;
                fm.grid1[0, 3] = new MyHeader1("업종1");
                fm.grid1[0, 3].RowSpan = 2;
                fm.grid1[0, 4] = new MyHeader1("업종2");
                fm.grid1[0, 4].RowSpan = 2;
                fm.grid1[0, 5] = new MyHeader1("업종3");
                fm.grid1[0, 5].RowSpan = 2;
                fm.grid1[0, 6] = new MyHeader1("기계이름");
                fm.grid1[0, 6].RowSpan = 2;
                fm.grid1[0, 7] = new MyHeader1("판형");
                fm.grid1[0, 7].RowSpan = 2;
                fm.grid1[0, 8] = new MyHeader1("기종");
                fm.grid1[0, 8].RowSpan = 2;
                fm.grid1[0, 9] = new MyHeader1("연식");
                fm.grid1[0, 9].RowSpan = 2;
                fm.grid1[0, 10] = new MyHeader1("수량");
                fm.grid1[0, 10].RowSpan = 2;
                fm.grid1[0, 11] = new MyHeader1("종이\r\n\r\n구와이");
                fm.grid1[0, 11].RowSpan = 2;
                fm.grid1[0, 12] = new MyHeader1("종이무게");
                fm.grid1[0, 12].ColumnSpan = 2;
                fm.grid1[0, 14] = new MyHeader1("종이 최대싸이즈");
                fm.grid1[0, 14].ColumnSpan = 2;
                fm.grid1[0, 16] = new MyHeader1("종이 최소싸이즈");
                fm.grid1[0, 16].ColumnSpan = 2;
                fm.grid1[0, 18] = new MyHeader1("최대\r\n\r\n접착면");
                fm.grid1[0, 18].RowSpan = 2;
                fm.grid1[0, 19] = new MyHeader1("최대싸이즈");
                fm.grid1[0, 19].ColumnSpan = 3;
                fm.grid1[0, 22] = new MyHeader1("최소싸이즈");
                fm.grid1[0, 22].ColumnSpan = 3;
                fm.grid1[0, 25] = new MyHeader1("단가폼");
                fm.grid1[0, 25].RowSpan = 2;
                fm.grid1[0, 26] = new MyHeader1("확인");
                fm.grid1[0, 26].RowSpan = 2;
                fm.grid1[0, 27] = new MyHeader1("거래");
                fm.grid1[0, 27].RowSpan = 2;
                // grid1.Rows.Insert(1);
                fm.grid1[1, 12] = new MyHeader("최소");
                fm.grid1[1, 13] = new MyHeader("최대");
                fm.grid1[1, 14] = new MyHeader("가로");
                fm.grid1[1, 15] = new MyHeader("세로");
                fm.grid1[1, 16] = new MyHeader("가로");
                fm.grid1[1, 17] = new MyHeader("세로");
                fm.grid1[1, 19] = new MyHeader("장");
                fm.grid1[1, 20] = new MyHeader("폭");
                fm.grid1[1, 21] = new MyHeader("고");
                fm.grid1[1, 22] = new MyHeader("장");
                fm.grid1[1, 23] = new MyHeader("폭");
                fm.grid1[1, 24] = new MyHeader("고");
                //
                fm.grid1.Columns[0].Width = 100;
                fm.grid1.Columns[1].Width = 30;
                fm.grid1.Columns[2].Width = 30;
                fm.grid1.Columns[3].Width = 50;  //업종-1
                fm.grid1.Columns[4].Width = 60;  //업종-2
                fm.grid1.Columns[5].Width = 80;  //업종-3
                fm.grid1.Columns[6].Width = 90;  //기계이름
                fm.grid1.Columns[7].Width = 40;  //판형 
                fm.grid1.Columns[8].Width = 40;  //기종
                fm.grid1.Columns[9].Width = 40;  //연식
                fm.grid1.Columns[10].Width = 40; //수량
                fm.grid1.Columns[11].Width = 50; //종이구와이
                fm.grid1.Columns[12].Width = 40; //종이무게(최소)
                fm.grid1.Columns[13].Width = 40; //종이무게(최대)
                fm.grid1.Columns[14].Width = 50; //종이최대싸이즈(가로)
                fm.grid1.Columns[15].Width = 50; //종이최대싸이즈(세로)
                fm.grid1.Columns[16].Width = 50; //종이최소싸이즈(가로)
                fm.grid1.Columns[17].Width = 50; //종이최소싸이즈(세로)
                fm.grid1.Columns[18].Width = 50; //최대접착면
                fm.grid1.Columns[19].Width = 30; //최대싸이즈(장)
                fm.grid1.Columns[20].Width = 30; //최대싸이즈(폭)
                fm.grid1.Columns[21].Width = 30; //최대싸이즈(고)
                fm.grid1.Columns[22].Width = 30; //최소싸이즈(장)
                fm.grid1.Columns[23].Width = 30; //최소싸이즈(폭)
                fm.grid1.Columns[24].Width = 30; //최소싸이즈(고)
                fm.grid1.Columns[25].Width = 50; //단가폼
                fm.grid1.Columns[26].Width = 50; //확인
                fm.grid1.Columns[27].Width = 50; //거래
                //
                cQuery = " select a.*,b.aitem d1,c.bitem d2,d.citem d3, e.hang as pan_hang FROM C_hmachin a";
                cQuery += " Left Outer Join C_amodel b ON b.a_code=a.a_model";
                cQuery += " Left Outer Join C_bmodel c ON c.a_code=a.a_model and c.b_code=a.b_model";
                cQuery += " Left Outer Join C_cmodel d ON d.a_code=a.a_model and d.b_code=a.b_model and d.c_code=a.c_model";
                cQuery += " Left Outer Join hang_manage e ON a.pan_type = e.code1  and e.class = '판형'";
                cQuery += " where int_id='" + m_no + "' and form_id='" + in_no + "'";  //회사번호,폼번호,A+B코드번호
                cQuery += "  and a.a_model='" + x_no.Substring(0, 2) + "' and a.b_model='" + x_no.Substring(2, 2) + "'";
                var cmd = new MySqlCommand(cQuery, DBConn);
                var myRead = cmd.ExecuteReader();

                int m = 2;
                string confirm = "";
                string deal = "";
                while (myRead.Read())
                {
                    fm.grid1.Rows.Insert(m);
                    fm.grid1.Rows[m].Height = 24;
                    fm.grid1[m, 0] = new SourceGrid.Cells.Cell(myRead["row_id"], typeof(string));
                    fm.grid1[m, 1] = new SourceGrid.Cells.CheckBox(null, false);
                    fm.grid1[m, 2] = new SourceGrid.Cells.Cell(myRead["no"], typeof(string));
                    fm.grid1[m, 2].Editor = cc.disable_cell;
                    fm.grid1[m, 2].View = cc.center_cell;
                    fm.grid1[m, 3] = new SourceGrid.Cells.Cell(myRead["d1"], typeof(string)); //업종-1
                    fm.grid1[m, 3].Editor = cc.disable_cell;
                    fm.grid1[m, 4] = new SourceGrid.Cells.Cell(myRead["d2"], typeof(string)); //업종-2
                    fm.grid1[m, 4].Editor = cc.disable_cell;
                    fm.grid1[m, 5] = new SourceGrid.Cells.Cell(myRead["d3"], typeof(string)); //업종-3
                    fm.grid1[m, 5].Editor = cc.disable_cell;
                    fm.grid1[m, 6] = new SourceGrid.Cells.Cell(myRead["machin_name"], typeof(string)); //기계이름
                    fm.grid1[m, 7] = new SourceGrid.Cells.Cell(myRead["pan_hang"], typeof(string));  //판형
                    fm.grid1[m, 7].View = cc.center_cell;
                    fm.grid1[m, 7].Editor = cb_pantype;
                    fm.grid1[m, 8] = new SourceGrid.Cells.Cell(myRead["machin_model"], typeof(string));  //기종
                    fm.grid1[m, 8].View = cc.center_cell;
                    fm.grid1[m, 9] = new SourceGrid.Cells.Cell(myRead["year_type"], typeof(string));  //연식
                    fm.grid1[m, 9].View = cc.center_cell;
                    fm.grid1[m, 10] = new SourceGrid.Cells.Cell(myRead["machin_su"], typeof(string));  //수량
                    fm.grid1[m, 10].View = cc.int_cell;
                    fm.grid1[m, 11] = new SourceGrid.Cells.Cell(myRead["paper_guy"], typeof(string));  //종이구와이
                    fm.grid1[m, 11].View = cc.int_cell;
                    fm.grid1[m, 12] = new SourceGrid.Cells.Cell(myRead["p_weight_min"], typeof(string));  //종이무게(최소)
                    fm.grid1[m, 12].View = cc.int_cell;
                    fm.grid1[m, 13] = new SourceGrid.Cells.Cell(myRead["p_weight_max"], typeof(string));  //종이무게(최대)
                    fm.grid1[m, 13].View = cc.int_cell;
                    fm.grid1[m, 14] = new SourceGrid.Cells.Cell(myRead["p_garo_max"], typeof(string));  //종이최대싸이즈(가로)
                    fm.grid1[m, 14].View = cc.int_cell;
                    fm.grid1[m, 15] = new SourceGrid.Cells.Cell(myRead["p_sero_max"], typeof(string));  //종이최대싸이즈(세로)
                    fm.grid1[m, 15].View = cc.int_cell;
                    fm.grid1[m, 16] = new SourceGrid.Cells.Cell(myRead["p_garo_min"], typeof(string));  //종이최소싸이즈(가로)
                    fm.grid1[m, 16].View = cc.int_cell;
                    fm.grid1[m, 17] = new SourceGrid.Cells.Cell(myRead["p_sero_min"], typeof(string));  //종이최소싸이즈(세로)
                    fm.grid1[m, 17].View = cc.int_cell;
                    fm.grid1[m, 18] = new SourceGrid.Cells.Cell(myRead["bond_max"], typeof(string));  //초대접착면
                    fm.grid1[m, 19] = new SourceGrid.Cells.Cell(myRead["jang_max"], typeof(string));  //최대싸이즈(장)
                    fm.grid1[m, 19].View = cc.int_cell;
                    fm.grid1[m, 20] = new SourceGrid.Cells.Cell(myRead["pok_max"], typeof(string));  //최대싸이즈(폭)
                    fm.grid1[m, 20].View = cc.int_cell;
                    fm.grid1[m, 21] = new SourceGrid.Cells.Cell(myRead["go_max"], typeof(string));  //최대싸이즈(고)
                    fm.grid1[m, 21].View = cc.int_cell;
                    fm.grid1[m, 22] = new SourceGrid.Cells.Cell(myRead["jang_min"], typeof(string));  //최소싸이즈(장)
                    fm.grid1[m, 22].View = cc.int_cell;
                    fm.grid1[m, 23] = new SourceGrid.Cells.Cell(myRead["pok_min"], typeof(string));  //최소싸이즈(폭)
                    fm.grid1[m, 23].View = cc.int_cell;
                    fm.grid1[m, 24] = new SourceGrid.Cells.Cell(myRead["go_min"], typeof(string));  //최소싸이즈(고)
                    fm.grid1[m, 24].View = cc.int_cell;
                    fm.grid1[m, 25] = new SourceGrid.Cells.Cell(myRead["danga_form"], typeof(string));  //단가폼
                    fm.grid1[m, 25].View = cc.center_cellb;
                    if (myRead["confirm"].ToString() == "False" || myRead["confirm"].ToString() == "false")
                        confirm = "N";
                    else
                        confirm = "Y";
                    fm.grid1[m, 26] = new SourceGrid.Cells.Cell(confirm, typeof(string));   //단가
                    fm.grid1[m, 26].View = cc.center_cellb;
                    fm.grid1[m, 26].Editor = combo_cell;

                    if (myRead["deal_state"].ToString() == "False" || myRead["deal_state"].ToString() == "false")
                        deal = "N";
                    else
                        deal = "Y";
                    fm.grid1[m, 27] = new SourceGrid.Cells.Cell(deal, typeof(string));   //거래유무
                    fm.grid1[m, 27].View = cc.center_cellb;
                    fm.grid1[m, 27].Editor = combo_cell;
                    m++;
                }
                myRead.Close();
                DBConn.Close();
            }
        }

        private void tabControl1_Selected(object sender, TabControlEventArgs e)
        {
            //MessageBox.Show("tap");

        }

        private void button1_Click(object sender, EventArgs e)  //업종선택
        {
            Form43 Frm = new Form43(axx);
            if (Frm.ShowDialog() == DialogResult.OK)
            {
                pxx = Frm.bxx;
                yu_jong = "";
                for (int i = 0; i < pxx.Length; i++)
                {
                    if (pxx[i].Equals("0"))
                        if ((i < axx.Length) && (!axx[i].Equals("")))
                            yu_jong += axx[i] + "/";
                }
                yu_jong += Frm.citem;
                textBox3.Text = c_change(yu_jong);
            }
        }
        /// <summary>
        /// ////////////////////////////
        /// </summary>
        /// <param name="mm"></param>
        /// <returns></returns>
        private string c_change(string mm)  //업종분해
        {
            string xx = "";
            axx = mm.Split(new char[1] { '/' });
            string xno = "";
            string xno1 = "";
            //
            for (int i = 0; i < axx.Length - 1; i++)   //
            {
                xno = axx[i].Substring(0, 2);
                xno1 = axx[i].Substring(2, 2);
                for (int s = 0; s < b_dt.Rows.Count; s++)
                {
                    if (b_dt.Rows[s][0].ToString().Trim().Equals(xno) && b_dt.Rows[s][1].ToString().Trim().Equals(xno1))
                    {
                        xx += b_dt.Rows[s][4].ToString().Trim() + "/";
                        break;
                    }
                }
            }
            return xx;
        }
        
        private void button4_Click(object sender, EventArgs e)  //직원 항목추가
        {
            if (m_no == "0")
                MessageBox.Show("1차 내용을 저장하셔야 추가가 가능합니다.");
            else
            {
                dataGridView1.CellValueChanged -= new DataGridViewCellEventHandler(dg1_edit); //수정이벤트 등록
                var DBConn = new MySqlConnection(Config.DB_con1);
                DBConn.Open();
                string cQuery = "insert into C_hman(int_id,charge,account,mission,name,post,h_tel,c_tel,email,memo)";
                cQuery += " values('" + m_no + "','','','','','','','','','')"; ;
                var cmd = new MySqlCommand(cQuery, DBConn);
                if (cmd.ExecuteNonQuery() == 0)
                    MessageBox.Show("DB 서버 오류 입니다.");
                else
                {
                    dataGridView1.Rows.Add(1);
                    cQuery = "select * FROM C_hman where row_id=LAST_INSERT_ID()";
                    cmd = new MySqlCommand(cQuery, DBConn);
                    var myRead = cmd.ExecuteReader();
                    myRead.Read();
                    int m = dataGridView1.RowCount - 1;
                    dataGridView1.Rows[m].Cells[0].Value = myRead["row_id"].ToString();
                    dataGridView1.Rows[m].Cells[1].Value = false;
                    dataGridView1.Rows[m].Cells[2].Value = (m + 1).ToString();
                    dataGridView1.Rows[m].Cells[3].Value = myRead["charge"].ToString();
                    dataGridView1.Rows[m].Cells[4].Value = myRead["account"].ToString();
                    dataGridView1.Rows[m].Cells[5].Value = myRead["mission"].ToString();
                    dataGridView1.Rows[m].Cells[6].Value = myRead["name"].ToString();
                    dataGridView1.Rows[m].Cells[7].Value = myRead["post"].ToString();
                    dataGridView1.Rows[m].Cells[8].Value = myRead["h_tel"].ToString();
                    dataGridView1.Rows[m].Cells[9].Value = myRead["c_tel"].ToString();
                    dataGridView1.Rows[m].Cells[10].Value = myRead["email"].ToString();
                    dataGridView1.Rows[m].Cells[12].Value = myRead["memo"].ToString();
                    //
                    myRead.Close();
                    dataGridView1.CurrentCell = dataGridView1.Rows[m].Cells[1]; //크스옮기기
                }
                dataGridView1.CellValueChanged += new DataGridViewCellEventHandler(dg1_edit); //수정이벤트 등록
                DBConn.Close();
            }
        }

        private void button5_Click(object sender, EventArgs e)   //직원 항목삭제
        {
            if (MessageBox.Show("선택하신 항목을 삭제합니까 ?", "항목 삭제", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                dataGridView1.CellValueChanged -= new DataGridViewCellEventHandler(dg1_edit); //여기가 중요
                var DBConn = new MySqlConnection(Config.DB_con1);
                DBConn.Open();
                //
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
                        string cQuery = " delete from C_hman where row_id='" + row_no + "'";
                        var cmd = new MySqlCommand(cQuery, DBConn);
                        if (cmd.ExecuteNonQuery() == 0)
                        {
                            MessageBox.Show("직원자료 삭제에 실패 했습니다.");
                            break;
                        }
                        //
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
                //
                DBConn.Close();
                dataGridView1.CellValueChanged += new DataGridViewCellEventHandler(dg1_edit); //여기가 중요
            }
        }

        private void button2_Click(object sender, EventArgs e)  //달력
        {
            Calendar_Form fm = new Calendar_Form(textBox12);
            fm.ShowDialog();

        }

        private void button6_Click_1(object sender, EventArgs e)  //주항목 내용저장
        {
            checkBox1.Checked = false;
            if (tbAddrc.Text == tbAddrm.Text && tbAddrotherc.Text == tbAddrotherm.Text)
            {
                checkBox1.Checked = true;
            }

            if (ent_id == false && First_ent_no == textBox14.Text.Trim()) // 신규등록이 아니고 사업자 번호 수정이 없었다면 true
                Com_num = true;

            if (Com_num == false)
            {
                MessageBox.Show("사업자등록번호 중복검색을 해주세요");
                return;
            }
            string[] d = new string[18];
            d[0] = textBox12.Text.Trim();  //설립일
            d[1] = comboBox4.Text.Trim();  //지역
            if (textBox3.Text.Contains("/"))
                d[2] = yu_jong;            //업종
            else
                d[2] = "";                 //업종
            d[3] = textBox1.Text.Trim();   //대표
            d[4] = textBox5.Text.Trim();   //휴대폰
            d[5] = textBox6.Text.Trim();   //전화
            d[6] = textBox7.Text.Trim();   //팩스
            d[7] = textBox4.Text.Trim();   //상호(법인면)
            d[8] = textBox2.Text.Trim();   //성명
            d[9] = textBox10.Text.Trim();  //업태
            d[10] = textBox11.Text.Trim(); //종목
            d[11] = textBox14.Text.Trim(); //등록번호

            d[12] = tbAddrotherc.Text.Trim(); //사업장주소

            d[13] = textBox16.Text.Trim(); //회사통장
            d[14] = textBox8.Text.Trim();  //홈피주소

            d[15] = tbAddrotherm.Text.Trim();  //공장주소
            if (c_addr_other_old != null || c_addr_other_new != null)
                addr_control.Convert_other_addr(ref c_addr_other_old, ref c_addr_other_new, d[12]);
            if (m_addr_other_old != null || m_addr_other_new != null)
                addr_control.Convert_other_addr(ref m_addr_other_old, ref m_addr_other_new, d[15]);
            if(checkBox2.Checked == true)
                d[16] = "1";  //보안
            else
                d[16] = "0";  //보안
            //
            d[17] = richTextBox1.Text.Trim();  //특징메모
            //
            var DBConn = new MySqlConnection(Config.DB_con1);
            DBConn.Open();
            string cQuery = "";
            if (ent_id == true)  //신규
            {
                cQuery = "insert into C_hcustomer (in_day,area,yubjong,mast,mh_tel,ctel,fax,sangho,name,yubtae,jongmok,enter_no, bank_no,homp_ip,en_day";
                cQuery += ",rank ,security_id,sp_memo, c_addr_a, c_addr_b, c_addr_c, c_addr_d, m_addr_a, m_addr_b, m_addr_c, m_addr_d, c_addr_other_old, c_addr_other_new, m_addr_other_old, m_addr_other_new)";
                cQuery += " values('" + d[0] + "','" + d[1] + "','" + d[2] + "','" + d[3] + "','" + d[4] + "','" + d[5] + "','" + d[6] + "','" + d[7] + "','" + d[8];
                cQuery += "','" + d[9] + "','" + d[10] + "','" + d[11] + "','" + d[13] + "','" + d[14] + "',curdate(),'1', ";
                cQuery += "'" + d[16] + "','" + d[17] + "', '" + c_addr_a + "', '" + c_addr_b + "', '" + c_addr_c + "' ,'" + c_addr_d + "'";
                cQuery += ", '" + m_addr_a + "', '" + m_addr_b + "', '" + m_addr_c + "' ,'" + m_addr_d + "', '" + c_addr_other_old + "', '" + c_addr_other_new + "', '" + m_addr_other_old + "', '" + m_addr_other_new + "')";
                var cmd1 = new MySqlCommand(cQuery, DBConn);
                if (cmd1.ExecuteNonQuery() == 0)
                    MessageBox.Show("DB 서버 오류 입니다.");
                else
                {
                    MessageBox.Show("저장하였습니다.");
                    cQuery = " select LAST_INSERT_ID() as rn";
                    cmd1 = new MySqlCommand(cQuery, DBConn);
                    var myRead = cmd1.ExecuteReader();
                    myRead.Read();
                    m_no = myRead["rn"].ToString();          //row_id
                    myRead.Close();
                }
                if (d[3] != "")
                {
                    dataGridView1.CellValueChanged -= new DataGridViewCellEventHandler(dg1_edit); //여기가 중요
                    //
                    cQuery = "insert into C_hman(int_id,charge,account,mission,name,post,h_tel,c_tel,email,memo)";
                    cQuery += " values('" + m_no + "','','','대표','" + d[3] + "','','','" + d[5] + "','','')"; ;
                    var cmd = new MySqlCommand(cQuery, DBConn);
                    if (cmd.ExecuteNonQuery() == 0)
                    {
                        MessageBox.Show("DB 서버 오류 입니다.");
                        DBConn.Close();
                        return;
                    }
                    else
                    {
                        cQuery = " select LAST_INSERT_ID() as rn";
                        cmd = new MySqlCommand(cQuery, DBConn);
                        var myRead = cmd.ExecuteReader();
                        myRead.Read();
                        string x_no = myRead["rn"].ToString();          //row_id
                        myRead.Close();
                        // 
                        dataGridView1.Rows.Add(1);
                        dataGridView1.Rows[0].Cells[0].Value = x_no;
                        dataGridView1.Rows[0].Cells[1].Value = false;
                        dataGridView1.Rows[0].Cells[2].Value = 1.ToString();
                        dataGridView1.Rows[0].Cells[3].Value = "";
                        dataGridView1.Rows[0].Cells[4].Value = "";
                        dataGridView1.Rows[0].Cells[5].Value = "대표";
                        dataGridView1.Rows[0].Cells[6].Value = d[3];
                        dataGridView1.Rows[0].Cells[7].Value = "";
                        dataGridView1.Rows[0].Cells[8].Value = "";
                        dataGridView1.Rows[0].Cells[9].Value = d[5];
                        dataGridView1.Rows[0].Cells[10].Value = "";
                        dataGridView1.Rows[0].Cells[12].Value = "";
                    }
                    dataGridView1.CellValueChanged += new DataGridViewCellEventHandler(dg1_edit); //여기가 중요
                }
                DBConn.Close();
                ent_id = false;
            }
            else    //수정
            {
                cQuery = "update C_hcustomer set in_day='" + d[0] + "',area='" + d[1] + "',yubjong='" + d[2] + "',mast='" + d[3] + "'";
                cQuery += ",mh_tel='" + d[4] + "',ctel='" + d[5] + "',fax='" + d[6] + "',sangho='" + d[7] + "',name='" + d[8]+"'";
                cQuery += ",yubtae='" + d[9] + "',jongmok='" + d[10] + "',enter_no='" + d[11] + "', bank_no='" + d[13]+"'";
                cQuery += ",homp_ip='" + d[14] + "', security_id='" + d[16] + "',sp_memo='"+d[17]+"'";
                if (tbAddrc.Text == "" && tbAddrotherc.Text == "")
                {
                    //cQuery += ",c_addr_new=''";
                    //cQuery += ",c_addr_old=''";
                    cQuery += ",c_addr_a=''";
                    cQuery += ",c_addr_b=''";
                    cQuery += ",c_addr_c=''";
                    cQuery += ",c_addr_d=''";
                    cQuery += ",c_addr_other_old = ''";
                    cQuery += ",c_addr_other_new = ''";
                }
                else
                {
                    //if (c_addr_new != null)
                    //    cQuery += ",c_addr_new='" + c_addr_new + "'";
                    //if (c_addr_old != null)
                    //    cQuery += ",c_addr_old='" + c_addr_old + "'";
                    if (c_addr_a != null)
                        cQuery += ",c_addr_a='" + c_addr_a + "'";
                    if (c_addr_b != null)
                        cQuery += ",c_addr_b='" + c_addr_b + "'";
                    if (c_addr_c != null)
                        cQuery += ",c_addr_c='" + c_addr_c + "'";
                    if (c_addr_d != null)
                        cQuery += ",c_addr_d='" + c_addr_d + "'";
                    if (c_addr_other_old != null)
                        cQuery += ",c_addr_other_old='" + c_addr_other_old + "'";
                    if (c_addr_other_new != null)
                        cQuery += ",c_addr_other_new='" + c_addr_other_new + "'";
                }
                if (tbAddrm.Text == "" && tbAddrotherm.Text == "")
                {
                    //cQuery += ",m_addr_new=''";
                    //cQuery += ",m_addr_old=''";
                    cQuery += ",m_addr_a=''";
                    cQuery += ",m_addr_b=''";
                    cQuery += ",m_addr_c=''";
                    cQuery += ",m_addr_d=''";
                    cQuery += ",m_addr_other_old = ''";
                    cQuery += ",m_addr_other_new = ''";
                }
                else
                {
                    //if (m_addr_new != null)
                    //    cQuery += ",m_addr_new='" + m_addr_new + "'";
                    //if (m_addr_old != null)
                    //    cQuery += ",m_addr_old='" + m_addr_old + "'";
                    if (m_addr_a != null)
                        cQuery += ",m_addr_a='" + m_addr_a + "'";
                    if (m_addr_b != null)
                        cQuery += ",m_addr_b='" + m_addr_b + "'";
                    if (m_addr_c != null)
                        cQuery += ",m_addr_c='" + m_addr_c + "'";
                    if (m_addr_d != null)
                        cQuery += ",m_addr_d='" + m_addr_d + "'";
                    if (m_addr_other_old != null)
                        cQuery += ",m_addr_other_old='" + m_addr_other_old + "'";
                    if (m_addr_other_new != null)
                        cQuery += ",m_addr_other_new='" + m_addr_other_new + "'";
                }
                cQuery += " where row_id='" + m_no + "'";
                var cmd = new MySqlCommand(cQuery, DBConn);
                if (cmd.ExecuteNonQuery() == 0)
                    MessageBox.Show("DB 서버 오류 입니다.");
                else
                    MessageBox.Show("수정 저장 하였습니다.");
                DBConn.Close();
            }

            
        }

        //----------------------------------------------------------------------------------------
        private void dg1_edit(object sender, DataGridViewCellEventArgs e)        //직원창 내용수정
        {
            dataGridView1.CellValueChanged -= new DataGridViewCellEventHandler(dg1_edit); //여기가 중요
            //
            string cQuery = "";
            string dat = dataGridView1.CurrentCell.Value.ToString().Trim();                   //선택자료
            string row_no = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString().Trim();
            bool x_id = false;
            //
            var DBConn = new MySqlConnection(Config.DB_con1);
            DBConn.Open();
            //
            if (e.ColumnIndex.Equals(3))  //담당
                cQuery = " update C_hman set charge='" + dat + "' where row_id='" + row_no + "'";
            else if (e.ColumnIndex.Equals(4))  //경리
                cQuery = " update C_hman set account='" + dat + "' where row_id='" + row_no + "'";
            else if (e.ColumnIndex.Equals(5))  //직책
                cQuery = " update C_hman set mission='" + dat + "' where row_id='" + row_no + "'";
            else if (e.ColumnIndex.Equals(6))  //성함
                cQuery = " update C_hman set name='" + dat + "' where row_id='" + row_no + "'";
            else if (e.ColumnIndex.Equals(7))  //부서
                cQuery = " update C_hman set post='" + dat + "' where row_id='" + row_no + "'";
            else if (e.ColumnIndex.Equals(8))  //핸드폰
                cQuery = " update C_hman set h_tel='" + dat + "' where row_id='" + row_no + "'";
            else if (e.ColumnIndex.Equals(9))  //전화
                cQuery = " update C_hman set c_tel='" + dat + "' where row_id='" + row_no + "'";
            else if (e.ColumnIndex.Equals(10))  //이메일
                cQuery = " update C_hman set email='" + dat + "' where row_id='" + row_no + "'";
            else
                cQuery = "";
            //
            if (!cQuery.Equals(""))
            {
                var cmd = new MySqlCommand(cQuery, DBConn);
                if (cmd.ExecuteNonQuery() == 0)
                {
                    dataGridView1.CellValueChanged += new DataGridViewCellEventHandler(dg1_edit); //여기가 중요
                    DBConn.Close();
                    return;
                }
            }
            DBConn.Close();
            dataGridView1.CellValueChanged += new DataGridViewCellEventHandler(dg1_edit); //여기가 중요
        }

        private void dataGridView1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true;
                int iColumn = dataGridView1.CurrentCell.ColumnIndex;
                int iRow = dataGridView1.CurrentCell.RowIndex;

                if (iColumn < dataGridView1.Columns.Count-2)
                    dataGridView1.CurrentCell = dataGridView1[iColumn + 1, iRow];

            }
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)  //Grid1에서 원클릭시
        {
            if (e.ColumnIndex.Equals(11))
            {
                string dat = dataGridView1.Rows[e.RowIndex].Cells[12].Value.ToString().Trim();
                Form_memo fm = new Form_memo(dat);

                if (fm.ShowDialog() == DialogResult.OK)
                {
                    dataGridView1.CellValueChanged -= new DataGridViewCellEventHandler(dg1_edit); //여기가 중요
                    //
                    dat = fm.mtext;
                    string cQuery = "";
                    string row_no = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString().Trim();
                    //
                    var DBConn = new MySqlConnection(Config.DB_con1);
                    DBConn.Open();
                    //
                    cQuery = " update C_hman set memo='" + dat + "' where row_id='" + row_no + "'";
                    //
                    var cmd = new MySqlCommand(cQuery, DBConn);
                    if (cmd.ExecuteNonQuery() == 0)
                    {
                        MessageBox.Show("DB 서버 오류 입니다.");
                    }
                    else
                    {
                        dataGridView1.Rows[e.RowIndex].Cells[12].Value = dat;
                    }
                    dataGridView1.CellValueChanged += new DataGridViewCellEventHandler(dg1_edit); //여기가 중요
                    DBConn.Close();
                }

            }


        }
        //
        public class ValueChangedEvent : SourceGrid.Cells.Controllers.ControllerBase   //내용 수정
        {
            public override void OnValueChanged(SourceGrid.CellContext sender, EventArgs e)
            {
                
                SourceGrid.Cells.Editors.TextBox disable_cell = new SourceGrid.Cells.Editors.TextBox(typeof(string));  //수정불가
                disable_cell.EnableEdit = false;
                // 
                SourceGrid.Cells.Editors.TextBox enable_cell = new SourceGrid.Cells.Editors.TextBox(typeof(string));  //수정가능
                enable_cell.EnableEdit = true;
                //
                string form_no = "";
                base.OnValueChanged(sender, e);
                int ps = sender.Position.Column;
                SourceGrid.Grid grid = (SourceGrid.Grid)sender.Grid;

                if (grid.Name == "FileGrid")
                {
                    FileGrid_Change(grid, ps);
                    return;
                }
                string nam = grid.Name.ToString();
                //
                string[] axx = nam.Split(new char[1] { '/' });
                form_no = axx[1];       //폼번호
                //
                string cQuery = "";
                string row_no = grid[grid.Selection.ActivePosition.Row, 0].ToString().Trim();
                string dat = grid[grid.Selection.ActivePosition.Row, grid.Selection.ActivePosition.Column].ToString().Trim();
                //
                if (form_no.Equals("1"))
                {
                    if (ps == 5)
                        cQuery = " update C_hmachin set dosu='" + dat + "' where row_id='" + row_no + "'";
                    else if (ps == 6)
                    {
                        cQuery = "select * from hang_manage where hang = '" + dat + "' and class = '판형'";

                        var DBConn1 = new MySqlConnection(Config.DB_con1);
                        DBConn1.Open();
                        var cmd1 = new MySqlCommand(cQuery, DBConn1);
                        var myRead1 = cmd1.ExecuteReader();

                        if (myRead1.Read())
                            dat = myRead1["code1"].ToString().Trim();
                        else
                        {
                            MessageBox.Show("등록되지 않은 판형입니다. 수정에 실패하였습니다");
                            myRead1.Close();
                            DBConn1.Close();
                            return;
                        }

                        myRead1.Close();
                        DBConn1.Close();
                        cQuery = " update C_hmachin set pan_type='" + dat + "' where row_id='" + row_no + "'";
                    }
                    else if (ps == 7)
                        cQuery = " update C_hmachin set machin_model='" + dat + "' where row_id='" + row_no + "'";

                    else if (ps == 8)
                        cQuery = " update C_hmachin set machin_name='" + dat + "' where row_id='" + row_no + "'";

                    else if (ps == 9)
                        cQuery = " update C_hmachin set year_type='" + dat + "' where row_id='" + row_no + "'";
                    else if (ps == 10)
                        cQuery = " update C_hmachin set machin_guy='" + dat + "' where row_id='" + row_no + "'";
                    else if (ps == 11)
                        cQuery = " update C_hmachin set paper_guy='" + dat + "', paper_guy_result=" + dat + " where row_id='" + row_no + "'";
                    else if (ps == 12)
                        cQuery = " update C_hmachin set pan_size='" + dat + "' where row_id='" + row_no + "'";
                    else if (ps == 13)
                        cQuery = " update C_hmachin set p_weight_min='" + dat + "' where row_id='" + row_no + "'";
                    else if (ps == 14)
                        cQuery = " update C_hmachin set p_weight_max='" + dat + "' where row_id='" + row_no + "'";
                    else if (ps == 15)
                        cQuery = " update C_hmachin set p_garo_max='" + dat + "' where row_id='" + row_no + "'";
                    else if (ps == 16)
                        cQuery = " update C_hmachin set p_sero_max='" + dat + "' where row_id='" + row_no + "'";
                    else if (ps == 17)
                        cQuery = " update C_hmachin set p_garo_min='" + dat + "' where row_id='" + row_no + "'";
                    else if (ps == 18)
                        cQuery = " update C_hmachin set p_sero_min='" + dat + "' where row_id='" + row_no + "'";
                    else if (ps == 19)
                        cQuery = " update C_hmachin set cip='" + dat + "' where row_id='" + row_no + "'";
                    else if (ps == 20)
                        cQuery = " update C_hmachin set form='" + dat + "' where row_id='" + row_no + "'";
                    else if (ps == 21)
                        cQuery = " update C_hmachin set p46_9='" + dat + "' where row_id='" + row_no + "'";
                    else if (ps == 22)
                        cQuery = " update C_hmachin set p46_8='" + dat + "' where row_id='" + row_no + "'";
                    else if (ps == 23)
                        cQuery = " update C_hmachin set kook_8_sin='" + dat + "' where row_id='" + row_no + "'";
                    else if (ps == 24)
                        cQuery = " update C_hmachin set kook_8_kook='" + dat + "' where row_id='" + row_no + "'";
                    else if (ps == 25)
                        cQuery = " update C_hmachin set kook_4_s='" + dat + "' where row_id='" + row_no + "'";
                    else if (ps == 26)
                        cQuery = " update C_hmachin set kook_4_b='" + dat + "' where row_id='" + row_no + "'";
                    else if (ps == 27)
                        cQuery = " update C_hmachin set danga_form='" + dat + "' where row_id='" + row_no + "'";
                    else if (ps == 28)  //확인
                        if (dat == "Yes")
                            cQuery = " update C_hmachin set confirm='1' where row_id='" + row_no + "'";
                        else if (dat == "No")
                            cQuery = " update C_hmachin set confirm='0' where row_id='" + row_no + "'";
                        else
                            cQuery = " update C_hmachin set confirm='0' where row_id='" + row_no + "'";
                    else if (ps == 29)  // 거래유무
                        if (dat == "Yes")
                            cQuery = " update C_hmachin set deal_state='1' where row_id='" + row_no + "'";
                        else if (dat == "No")
                            cQuery = " update C_hmachin set deal_state='0' where row_id='" + row_no + "'";
                        else
                            cQuery = " update C_hmachin set deal_state='0' where row_id='" + row_no + "'";
                    else
                        return;
                }
                else if (form_no.Equals("2"))
                {
                    if (ps == 5)
                        cQuery = " update C_hmachin set machin_name='" + dat + "' where row_id='" + row_no + "'";
                    //else if (ps == 6)
                    //cQuery = " update C_hmachin set print_type='" + dat + "' where row_id='" + row_no + "'";
                    else if (ps == 7)
                        cQuery = " update C_hmachin set machin_model='" + dat + "' where row_id='" + row_no + "'";
                    else if (ps == 8)
                        cQuery = " update C_hmachin set year_type='" + dat + "' where row_id='" + row_no + "'";
                    else if (ps == 9)
                        cQuery = " update C_hmachin set c_garo_min='" + dat + "' where row_id='" + row_no + "'";
                    else if (ps == 10)
                        cQuery = " update C_hmachin set c_sero_min='" + dat + "' where row_id='" + row_no + "'";
                    else if (ps == 11)
                        cQuery = " update C_hmachin set c_garo_max='" + dat + "' where row_id='" + row_no + "'";
                    else if (ps == 12)
                        cQuery = " update C_hmachin set c_sero_max='" + dat + "' where row_id='" + row_no + "'";
                    else if (ps == 13)
                        cQuery = " update C_hmachin set d_garo_min='" + dat + "' where row_id='" + row_no + "'";
                    else if (ps == 14)
                        cQuery = " update C_hmachin set d_sero_min='" + dat + "' where row_id='" + row_no + "'";
                    else if (ps == 15)
                        cQuery = " update C_hmachin set d_garo_max='" + dat + "' where row_id='" + row_no + "'";
                    else if (ps == 16)
                        cQuery = " update C_hmachin set d_sero_max='" + dat + "' where row_id='" + row_no + "'";
                    else if (ps == 17)
                        cQuery = " update C_hmachin set seneca_max='" + dat + "' where row_id='" + row_no + "'";
                    else if (ps == 18)
                        cQuery = " update C_hmachin set seneca_min='" + dat + "' where row_id='" + row_no + "'";
                    else if (ps == 19)
                        cQuery = " update C_hmachin set koma_su='" + dat + "' where row_id='" + row_no + "'";
                    else if (ps == 20)
                        cQuery = " update C_hmachin set danga_form='" + dat + "' where row_id='" + row_no + "'";
                    else if (ps == 21)
                        if (dat == "Yes")
                            cQuery = " update C_hmachin set confirm='1' where row_id='" + row_no + "'";
                        else if (dat == "No")
                            cQuery = " update C_hmachin set confirm='0' where row_id='" + row_no + "'";
                        else
                            cQuery = " update C_hmachin set confirm='0' where row_id='" + row_no + "'";
                    else if (ps == 22)
                        if (dat == "Yes")
                            cQuery = " update C_hmachin set deal_state='1' where row_id='" + row_no + "'";
                        else if (dat == "No")
                            cQuery = " update C_hmachin set deal_state='0' where row_id='" + row_no + "'";
                        else
                            cQuery = " update C_hmachin set deal_state='0' where row_id='" + row_no + "'";
                    else
                        return;
                }
                else if (form_no.Equals("3"))
                {
                    if (ps == 6)
                        cQuery = " update C_hmachin set machin_name='" + dat + "' where row_id='" + row_no + "'";
                    else if (ps == 7)
                    {
                        cQuery = "select * from hang_manage where hang = '" + dat + "' and class = '판형'";

                        var DBConn1 = new MySqlConnection(Config.DB_con1);
                        DBConn1.Open();
                        var cmd1 = new MySqlCommand(cQuery, DBConn1);
                        var myRead1 = cmd1.ExecuteReader();

                        if (myRead1.Read())
                            dat = myRead1["code1"].ToString().Trim();
                        else
                        {
                            MessageBox.Show("등록되지 않은 판형입니다. 수정에 실패하였습니다");
                            myRead1.Close();
                            DBConn1.Close();
                            return;
                        }

                        myRead1.Close();
                        DBConn1.Close();
                        cQuery = " update C_hmachin set pan_type='" + dat + "' where row_id='" + row_no + "'";
                    }
                    else if (ps == 8)
                        cQuery = " update C_hmachin set machin_model='" + dat + "' where row_id='" + row_no + "'";
                    else if (ps == 9)
                        cQuery = " update C_hmachin set year_type='" + dat + "' where row_id='" + row_no + "'";
                    else if (ps == 10)
                        cQuery = " update C_hmachin set machin_su='" + dat + "' where row_id='" + row_no + "'";
                    else if (ps == 11)
                        cQuery = " update C_hmachin set paper_guy='" + dat + "', paper_guy_result=" + dat + " where row_id='" + row_no + "'";
                    else if (ps == 12)
                        cQuery = " update C_hmachin set p_weight_min='" + dat + "' where row_id='" + row_no + "'";
                    else if (ps == 13)
                        cQuery = " update C_hmachin set p_weight_max='" + dat + "' where row_id='" + row_no + "'";
                    else if (ps == 14)
                        cQuery = " update C_hmachin set P_garo_max='" + dat + "' where row_id='" + row_no + "'";
                    else if (ps == 15)
                        cQuery = " update C_hmachin set p_sero_max='" + dat + "' where row_id='" + row_no + "'";
                    else if (ps == 16)
                        cQuery = " update C_hmachin set p_garo_min='" + dat + "' where row_id='" + row_no + "'";
                    else if (ps == 17)
                        cQuery = " update C_hmachin set p_sero_min='" + dat + "' where row_id='" + row_no + "'";
                    else if (ps == 18)
                        cQuery = " update C_hmachin set danga_form='" + dat + "' where row_id='" + row_no + "'";
                    else if (ps == 19)
                        if (dat == "Yes")
                            cQuery = " update C_hmachin set confirm='1' where row_id='" + row_no + "'";
                        else if (dat == "No")
                            cQuery = " update C_hmachin set confirm='0' where row_id='" + row_no + "'";
                        else
                            cQuery = " update C_hmachin set confirm='0' where row_id='" + row_no + "'";
                    else if (ps == 20)
                        if (dat == "Yes")
                            cQuery = " update C_hmachin set deal_state='1' where row_id='" + row_no + "'";
                        else if (dat == "No")
                            cQuery = " update C_hmachin set deal_state='0' where row_id='" + row_no + "'";
                        else
                            cQuery = " update C_hmachin set deal_state='0' where row_id='" + row_no + "'";
                    else
                        return;
                }
                else if (form_no.Equals("4"))
                {
                    if (ps == 5)
                        cQuery = " update C_hmachin set machin_name='" + dat + "' where row_id='" + row_no + "'";
                    else if (ps == 6)
                    {
                        cQuery = "select * from hang_manage where hang = '" + dat + "' and class = '판형'";

                        var DBConn1 = new MySqlConnection(Config.DB_con1);
                        DBConn1.Open();
                        var cmd1 = new MySqlCommand(cQuery, DBConn1);
                        var myRead1 = cmd1.ExecuteReader();

                        if (myRead1.Read())
                            dat = myRead1["code1"].ToString().Trim();
                        else
                        {
                            MessageBox.Show("등록되지 않은 판형입니다. 수정에 실패하였습니다");
                            myRead1.Close();
                            DBConn1.Close();
                            return;
                        }

                        myRead1.Close();
                        DBConn1.Close();
                        cQuery = " update C_hmachin set pan_type='" + dat + "' where row_id='" + row_no + "'";
                    }
                    else if (ps == 7)
                        cQuery = " update C_hmachin set machin_model='" + dat + "' where row_id='" + row_no + "'";
                    else if (ps == 8)
                        cQuery = " update C_hmachin set year_type='" + dat + "' where row_id='" + row_no + "'";
                    else if (ps == 9)
                        cQuery = " update C_hmachin set machin_su='" + dat + "' where row_id='" + row_no + "'";
                    else if (ps == 10)
                        cQuery = " update C_hmachin set p_weight_min='" + dat + "' where row_id='" + row_no + "'";
                    else if (ps == 11)
                        cQuery = " update C_hmachin set p_weight_max='" + dat + "' where row_id='" + row_no + "'";
                    else if (ps == 12)
                        cQuery = " update C_hmachin set p_garo_max='" + dat + "' where row_id='" + row_no + "'";
                    else if (ps == 13)
                        cQuery = " update C_hmachin set p_sero_max='" + dat + "' where row_id='" + row_no + "'";
                    else if (ps == 14)
                        cQuery = " update C_hmachin set p_garo_min='" + dat + "' where row_id='" + row_no + "'";
                    else if (ps == 15)
                        cQuery = " update C_hmachin set p_sero_min='" + dat + "' where row_id='" + row_no + "'";
                    else if (ps == 16)
                        cQuery = " update C_hmachin set balche_1='" + dat + "' where row_id='" + row_no + "'";
                    else if (ps == 17)
                        cQuery = " update C_hmachin set balche_2='" + dat + "' where row_id='" + row_no + "'";
                    else if (ps == 18)
                        cQuery = " update C_hmachin set jubji_min_gap='" + dat + "' where row_id='" + row_no + "'";
                    else if (ps == 19)
                        cQuery = " update C_hmachin set danga_form='" + dat + "' where row_id='" + row_no + "'";
                    else if (ps == 20)
                        if (dat == "Yes")
                            cQuery = " update C_hmachin set confirm='1' where row_id='" + row_no + "'";
                        else if (dat == "No")
                            cQuery = " update C_hmachin set confirm='0' where row_id='" + row_no + "'";
                        else
                            cQuery = " update C_hmachin set confirm='0' where row_id='" + row_no + "'";
                    else if (ps == 21)
                        if (dat == "Yes")
                            cQuery = " update C_hmachin set deal_state='1' where row_id='" + row_no + "'";
                        else if (dat == "No")
                            cQuery = " update C_hmachin set deal_state='0' where row_id='" + row_no + "'";
                        else
                            cQuery = " update C_hmachin set deal_state='0' where row_id='" + row_no + "'";
                    else
                        return;
                }
                else if (form_no.Equals("5"))
                {
                    if (ps == 6)
                        cQuery = " update C_hmachin set machin_name='" + dat + "' where row_id='" + row_no + "'";
                    else if (ps == 7)
                    {
                        cQuery = "select * from hang_manage where hang = '" + dat + "' and class = '판형'";

                        var DBConn1 = new MySqlConnection(Config.DB_con1);
                        DBConn1.Open();
                        var cmd1 = new MySqlCommand(cQuery, DBConn1);
                        var myRead1 = cmd1.ExecuteReader();

                        if (myRead1.Read())
                            dat = myRead1["code1"].ToString().Trim();


                        myRead1.Close();
                        DBConn1.Close();
                        cQuery = " update C_hmachin set pan_type='" + dat + "' where row_id='" + row_no + "'";
                    }
                    else if (ps == 8)
                        cQuery = " update C_hmachin set machin_model='" + dat + "' where row_id='" + row_no + "'";
                    else if (ps == 9)
                        cQuery = " update C_hmachin set year_type='" + dat + "' where row_id='" + row_no + "'";
                    else if (ps == 10)
                        cQuery = " update C_hmachin set machin_su='" + dat + "' where row_id='" + row_no + "'";
                    else if (ps == 11)
                        cQuery = " update C_hmachin set paper_guy='" + dat + "', paper_guy_result=" + dat + " where row_id='" + row_no + "'";
                    else if (ps == 12)
                        cQuery = " update C_hmachin set p_weight_min='" + dat + "' where row_id='" + row_no + "'";
                    else if (ps == 13)
                        cQuery = " update C_hmachin set p_weight_max='" + dat + "' where row_id='" + row_no + "'";
                    else if (ps == 14)
                        cQuery = " update C_hmachin set p_garo_max='" + dat + "' where row_id='" + row_no + "'";
                    else if (ps == 15)
                        cQuery = " update C_hmachin set p_sero_max='" + dat + "' where row_id='" + row_no + "'";
                    else if (ps == 16)
                        cQuery = " update C_hmachin set p_garo_min='" + dat + "' where row_id='" + row_no + "'";
                    else if (ps == 17)
                        cQuery = " update C_hmachin set p_sero_min='" + dat + "' where row_id='" + row_no + "'";
                    else if (ps == 18)
                        cQuery = " update C_hmachin set bond_max='" + dat + "' where row_id='" + row_no + "'";
                    else if (ps == 19)
                        cQuery = " update C_hmachin set jang_max='" + dat + "' where row_id='" + row_no + "'";
                    else if (ps == 20)
                        cQuery = " update C_hmachin set pok_max='" + dat + "' where row_id='" + row_no + "'";
                    else if (ps == 21)
                        cQuery = " update C_hmachin set go_max='" + dat + "' where row_id='" + row_no + "'";
                    else if (ps == 22)
                        cQuery = " update C_hmachin set jang_min='" + dat + "' where row_id='" + row_no + "'";
                    else if (ps == 23)
                        cQuery = " update C_hmachin set pok_min='" + dat + "' where row_id='" + row_no + "'";
                    else if (ps == 24)
                        cQuery = " update C_hmachin set go_min='" + dat + "' where row_id='" + row_no + "'";
                    else if (ps == 25)
                        cQuery = " update C_hmachin set danga_form='" + dat + "' where row_id='" + row_no + "'";
                    else if (ps == 26)
                        if (dat == "Yes")
                            cQuery = " update C_hmachin set confirm='1' where row_id='" + row_no + "'";
                        else if (dat == "No")
                            cQuery = " update C_hmachin set confirm='0' where row_id='" + row_no + "'";
                        else
                            cQuery = " update C_hmachin set confirm='0' where row_id='" + row_no + "'";
                    else if (ps == 27)
                        if (dat == "Yes")
                            cQuery = " update C_hmachin set deal_state='1' where row_id='" + row_no + "'";
                        else if (dat == "No")
                            cQuery = " update C_hmachin set deal_state='0' where row_id='" + row_no + "'";
                        else
                            cQuery = " update C_hmachin set deal_state='0' where row_id='" + row_no + "'";
                    else
                        return;
                }
                 
                var DBConn = new MySqlConnection(Config.DB_con1);
                DBConn.Open();
                var cmd = new MySqlCommand(cQuery, DBConn);
                if (cmd.ExecuteNonQuery() == 0)
                    MessageBox.Show("서버 자료 수정에 실패 했습니다.");
                DBConn.Close();
                //
            }

            public void FileGrid_Change(SourceGrid.Grid grid, int cpos)
            {
                string DB_TableName_file = "C_file_total_manage";
                string cQuery = "";
                ksgcontrol KC = new ksgcontrol();
                KC.ControlInit(Config.DB_con1, "", "", "");

                string row_no = grid[grid.Selection.ActivePosition.Row, 0].ToString().Trim();
                var dat = grid[grid.Selection.ActivePosition.Row, grid.Selection.ActivePosition.Column].Value;
                var DBConn = new MySqlConnection(Config.DB_con1);
                util.Con_DB_Open(ref DBConn);

                if (cpos.Equals(5))       //
                {
                    cQuery = " update " + DB_TableName_file + " set group1='" + dat + "' where row_id='" + row_no + "'";
                }
                else if (cpos.Equals(6))       //
                {
                    cQuery = " update " + DB_TableName_file + " set comment='" + dat + "' where row_id='" + row_no + "'";
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

                DBConn.Close();
            }
        }

        private void button9_Click(object sender, EventArgs e)  //홈피열기
        {

            System.Diagnostics.Process.Start("C:\\Program Files\\Internet Explorer\\IExplore.exe", textBox8.Text.Trim());
            //Webform Frm = new Webform(textBox8.Text.Trim(), "2");
            //this.IsMdiContainer = false;
            //Frm.Show();
        }

        private void textBox14_TextChanged(object sender, EventArgs e)
        {
            Com_num = false;
        }

        private void bNumConfirm_Click(object sender, EventArgs e)
        {
            if (textBox14.Text.Length != 12)
            {
                MessageBox.Show("'-'를 포함하여 총 12자리를 입력해주세요");
                return;
            }
            if (textBox14.Text.Substring(3, 1) != "-" || textBox14.Text.Substring(6, 1) != "-")
            {
                MessageBox.Show("'-'를 넣어서 입력해주세요");
                return;
            }

            string Query = "select * from C_hcustomer where enter_no = '" + textBox14.Text.Trim()+"'";
            var DBConn = new MySqlConnection(Config.DB_con1);
            DBConn.Open();
            var cmd = new MySqlCommand(Query, DBConn);
            var myRead = cmd.ExecuteReader();
            if (myRead.Read())
            {
                MessageBox.Show("'"+myRead["sangho"].ToString() + "' 로 이미 등록되어 있습니다.");
                Com_num = false;
                DBConn.Close();
                return;
            }
            else
            {
                Com_num = true;
                MessageBox.Show("입력하신 사업자등록번호로 등록 가능합니다.");
                DBConn.Close();
                return;
            }
            

        }
        string addr1 = "";
        string addr2 = "";
        private void checkBox1_Click(object sender, EventArgs e)  //상동 체크시
        {
            if (checkBox1.Checked == true)
            {
                if (tbAddrm.Text != "")
                    addr1 = tbAddrm.Text;
                if (tbAddrotherm.Text != "")
                    addr2 = tbAddrotherm.Text;

                //this.tbAddrm.Size = new System.Drawing.Size(246, 21);
                //tbAddrotherm.Visible = true;
                tbAddrm.Text = tbAddrc.Text;
                tbAddrotherm.Text = tbAddrotherc.Text;

                string Query = "select c_addr_a, c_addr_b,c_addr_c ,c_addr_d, c_addr_other_old, c_addr_other_new from C_hcustomer where row_id = " + m_no;
                var DBConn = new MySqlConnection(Config.DB_con1);
                DBConn.Open();
                var cmd = new MySqlCommand(Query, DBConn);
                var myRead = cmd.ExecuteReader();
                if (myRead.Read())
                {
                    m_addr_a = myRead["c_addr_a"].ToString();
                    m_addr_b = myRead["c_addr_b"].ToString();
                    m_addr_c = myRead["c_addr_c"].ToString();
                    m_addr_d = myRead["c_addr_d"].ToString();
                    //m_addr_old = myRead["c_addr_old"].ToString();
                    //m_addr_new = myRead["c_addr_new"].ToString();
                    m_addr_other_old = myRead["c_addr_other_old"].ToString();
                    m_addr_other_new = myRead["c_addr_other_new"].ToString();
                }
                myRead.Close();
                DBConn.Close();
                if (m_addr_a == "")
                {
                    m_addr_a = c_addr_a;
                    m_addr_b = c_addr_b;
                    m_addr_c = c_addr_c;
                    m_addr_d = c_addr_d;
                    m_addr_other_old = c_addr_other_old;
                    m_addr_other_new = c_addr_other_new;
                }
            }
            else
            {
                tbAddrm.Text = addr1;
                tbAddrotherm.Text = addr2;
            }
        }

        private string[] Get_pantype_combo()
        {
            string cQuery = "select distinct hang from hang_manage where class='판형'";


            var DBConn = new MySqlConnection(Config.DB_con1);
            DBConn.Open();
            var cmd1 = new MySqlCommand(cQuery, DBConn);
            var myRead1 = cmd1.ExecuteReader();
            string[] item = new string[15];

            for (int i = 0; i < 15; i++)
                item[i] = "0";

            int y = 0;
            while (myRead1.Read())
            {
                item[y] = myRead1["hang"].ToString().Trim();
                y++;
            }

            string[] result = new string[y];

            for (int i = 0; i < y; i++)
            {
                result[i] = item[i];
            }
            myRead1.Close();
            DBConn.Close();
           

            return result;
        }

        private void bPostc_Click(object sender, EventArgs e)
        {
            Form_post fm = new Form_post(tbAddrc);
            if (fm.ShowDialog() == DialogResult.OK)
            {
                c_addr_a = fm.addr_a;
                c_addr_b = fm.addr_b;
                c_addr_c = fm.addr_c;
                c_addr_d = fm.addr_d;
                c_addr_other_new = fm.addr_other_new;
                c_addr_other_old = fm.addr_other_old;
                //c_addr_old = fm.addr_old;
                //c_addr_new = fm.addr;
              
                if (c_addr_a != "")
                {
                    this.tbAddrc.Size = new System.Drawing.Size(246, 21);
                    tbAddrc.SelectionStart = tbAddrc.TextLength;
                    if(Config.addr_other == "old")
                        tbAddrotherc.Text = fm.addr_other_old;
                    else
                        tbAddrotherc.Text = fm.addr_other_new;

                    if (fm.addr_gunmool != "")
                        tbAddrotherc.Text += " " + fm.addr_gunmool;
                    tbAddrc.SelectionLength = 0;
                    tbAddrotherc.Visible = true;
                    tbAddrotherc.Focus();
                    tbAddrotherc.SelectionStart = tbAddrotherc.Text.Length + 1;
                }
                if (Config.addr_other == "old")
                    tbAddrc.Text = c_addr_a + " " + c_addr_b + " " + c_addr_c;
                else
                    tbAddrc.Text = c_addr_a + " " + c_addr_b + " " + c_addr_d;
                tbAddrc.SelectionStart = tbAddrc.TextLength;
                tbAddrc.SelectionLength = 0;
                checkBox1.Checked = false;
                if (tbAddrc.Text == tbAddrm.Text && tbAddrotherc.Text == tbAddrotherm.Text)
                {
                    checkBox1.Checked = true;
                }
            }
        }

        private void button7_Click(object sender, EventArgs e)
        {
            Form_post fm = new Form_post(tbAddrm);
            if (fm.ShowDialog() == DialogResult.OK)
            {
                m_addr_a = fm.addr_a;
                m_addr_b = fm.addr_b;
                m_addr_c = fm.addr_c;
                m_addr_d = fm.addr_d;
                m_addr_other_new = fm.addr_other_new;
                m_addr_other_old = fm.addr_other_old;
                //m_addr_old = fm.addr_old;
                //m_addr_new = fm.addr;

                if (m_addr_a != "")
                {
                    tbAddrotherm.Text = fm.addr_gunmool;
                    tbAddrm.SelectionStart = tbAddrm.TextLength;
                    if (Config.addr_other == "old")
                        tbAddrotherm.Text = fm.addr_other_old;
                    else
                        tbAddrotherm.Text = fm.addr_other_new;
                    if (fm.addr_gunmool != "")
                        tbAddrotherm.Text += " " + fm.addr_gunmool;
                    tbAddrotherm.Focus();
                    tbAddrotherm.SelectionStart = tbAddrotherm.Text.Length+1;
                }
                if (Config.addr_other == "old")
                    tbAddrm.Text = m_addr_a + " " + m_addr_b + " " + m_addr_c;
                else
                    tbAddrm.Text = m_addr_a + " " + m_addr_b + " " + m_addr_d;
                tbAddrm.SelectionStart = tbAddrm.TextLength;
                tbAddrm.SelectionLength = 0;
                checkBox1.Checked = false;
                if (tbAddrc.Text == tbAddrm.Text && tbAddrotherc.Text == tbAddrotherm.Text)
                {
                    checkBox1.Checked = true;
                }
            }
        }

        private void FileGrid_View()
        {

            SourceGrid.Cells.Views.Link viewLink = new SourceGrid.Cells.Views.Link();
            viewLink.ImageAlignment = DevAge.Drawing.ContentAlignment.MiddleCenter;
            viewLink.TextAlignment = DevAge.Drawing.ContentAlignment.MiddleCenter;

            cell_d cc = new cell_d();
            DataTable p_dt = new DataTable();  //브라우저 자료
            FileGrid.Rows.Clear();
            var DBConn = new MySqlConnection(Config.DB_con1);
            util.Con_DB_Open(ref DBConn);
            string cQuery = " select * FROM " + DB_TableName_file + " where db_nm ='" + DB_TableName_cust + "' and int_id='" + m_no + "'";
            cQuery += " order by row_id desc";
            MySqlDataAdapter returnVal = new MySqlDataAdapter(cQuery, DBConn);
            returnVal.Fill(p_dt);
            returnVal.Dispose();
            DBConn.Close();

            //
            ValueChangedEvent valueChangedController = new ValueChangedEvent();
            FileGrid.Controller.AddController(valueChangedController);

            //
            FileGrid.BorderStyle = BorderStyle.FixedSingle;
            FileGrid.SelectionMode = SourceGrid.GridSelectionMode.Cell;
            FileGrid.ColumnsCount = 10;
            FileGrid.FixedRows = 1;
            FileGrid.Rows.Insert(0);
            FileGrid.Rows[0].Height = 30;
            //
            FileGrid[0, 0] = new MyHeader1("row_id");
            FileGrid.Columns[0].Visible = false;
            FileGrid[0, 1] = new MyHeader1("√");
            FileGrid[0, 2] = new MyHeader1("No");

            FileGrid[0, 3] = new MyHeader1("파일명");

            FileGrid[0, 4] = new MyHeader1("내려\r\n받기");

            FileGrid[0, 5] = new MyHeader1("분류");
            FileGrid[0, 6] = new MyHeader1("요약설명");
            FileGrid[0, 7] = new MyHeader1("server_file");
            FileGrid.Columns[7].Visible = false;
            //
            FileGrid.Columns[0].Width = 100;
            FileGrid.Columns[1].Width = 22;
            FileGrid.Columns[2].Width = 38;
            FileGrid.Columns[3].Width = 350;  //
            FileGrid.Columns[4].Width = 40;  //
            FileGrid.Columns[5].Width = 60;  //

            FileGrid.Columns[6].Width = 255;  //
            FileGrid.Columns[7].Width = 40;  //
            //
            int m = 1;
            Bitmap objBitmap;
            for (int i = 0; i < p_dt.Rows.Count; i++)
            {
                FileGrid.Rows.Insert(m);
                FileGrid.Rows[m].Height = 22;
                //
                FileGrid[m, 0] = new SourceGrid.Cells.Cell(p_dt.Rows[i]["row_id"].ToString().Trim(), typeof(string));
                FileGrid[m, 1] = new SourceGrid.Cells.CheckBox(null, false);
                FileGrid[m, 2] = new SourceGrid.Cells.Cell((i + 1).ToString(), typeof(string));
                FileGrid[m, 2].View = cc.center_cell;
                FileGrid[m, 3] = new SourceGrid.Cells.Cell(p_dt.Rows[i]["user_file"].ToString().Trim(), typeof(string));
                FileGrid[m, 3].View = cc.left_cellb;
                FileGrid[m, 3].Editor = cc.disable_cell;

                FileGrid[m, 4] = new SourceGrid.Cells.Link();
                FileGrid[m, 4].AddController(clickEvent1);
                FileGrid[m, 4].Editor = cc.disable_cell;
                FileGrid[m, 4].View = viewLink;
                objBitmap = new Bitmap(Properties.Resources.K_11, new Size(23, 30));
                FileGrid[m, 4].Image = objBitmap;

                FileGrid[m, 5] = new SourceGrid.Cells.Cell(p_dt.Rows[i]["group1"].ToString().Trim(), typeof(string));
                FileGrid[m, 5].View = cc.center_cellr;

                FileGrid[m, 6] = new SourceGrid.Cells.Cell(p_dt.Rows[i]["comment"].ToString().Trim(), typeof(string));
                FileGrid[m, 6].View = cc.left_cellr;
                FileGrid[m, 7] = new SourceGrid.Cells.Cell(p_dt.Rows[i]["server_file"].ToString().Trim(), typeof(string));

                m++;
            }
        }

        private void clickEvent_Click1(object sender, EventArgs e)  //Grid1에서 내려받기 클릭시
        {
            int columns = FileGrid.Selection.ActivePosition.Column;
            int now_row = FileGrid.Selection.ActivePosition.Row;

            string FilePath = DB_TableName_cust + "\\" + FileGrid[now_row, 7].ToString().Trim();  //7번이 file 명.
            string User_FileNm = FileGrid[now_row, 3].ToString().Trim();  //3번이 사용자가 보는file 명.

            SaveFileDialog sfd = new SaveFileDialog();
            sfd.Title = "Save File";
            sfd.FileName = User_FileNm;
            sfd.Filter = "ALL File(*.*)|*.*";
            sfd.InitialDirectory = "C:\\";
            sfd.RestoreDirectory = true;

            if (sfd.ShowDialog() == DialogResult.OK)
            {
                OhFTP Ftp = new OhFTP(Config.Ftp_ip1, Config.Ftp_id1, Config.Ftp_pw1);
                Ftp.DownLoadFile1(@sfd.FileName, FilePath);
                if (MessageBox.Show("내려받기 완료. file을 실행시키겠습니까?", "파일", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                    Process.Start(sfd.FileName);

            }

        }

        private void FileGrid_DoubleClick(object sender, EventArgs e)
        {

            int columns = FileGrid.Selection.ActivePosition.Column;
            int now_row = FileGrid.Selection.ActivePosition.Row;
            string FilePath = DB_TableName_cust + "\\" + FileGrid[now_row, 7].ToString().Trim();  //7번이 file 명.
            string User_FileNm = FileGrid[now_row, 3].ToString().Trim();  //3번이 사용자가 보는file 명.

            if (columns == 3)  // 파일명 더블클릭시
            {

                SaveFileDialog sfd = new SaveFileDialog();
                sfd.Title = "Save File";
                sfd.FileName = User_FileNm;
                sfd.Filter = "ALL File(*.*)|*.*";
                sfd.InitialDirectory = "C:\\temp\\";
                sfd.RestoreDirectory = true;

                OhFTP Ftp = new OhFTP(Config.Ftp_ip1, Config.Ftp_id1, Config.Ftp_pw1);
                Ftp.DownLoadFile1(@"C:\temp\" + sfd.FileName, FilePath);
                Process.Start(@"C:\temp\" + sfd.FileName);

            }
        }

        private void bFileDel_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("선택한 파일을 삭제하시겠습니까?", "파일삭제", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) != DialogResult.Yes)
            {
                return;
            }
            FileControl FC = new FileControl();
            FC.FileControlInit(Config.DB_con1, Config.Ftp_ip1, Config.Ftp_id1, Config.Ftp_pw1);
            int first_data_row = 1;
            int chkbox_position = 1;
            int row_id_position = 0;
            int file_position = 7;
            string s1 = "";
            string Query = "";

            for (int i = first_data_row; i < FileGrid.RowsCount; i++)
            {
                if (FileGrid[i, chkbox_position].Value.Equals(true))
                {
                    FC.FileDel(FileGrid[i, file_position].Value.ToString(), DB_TableName_cust);
                    s1 += " or row_id='" + FileGrid[i, row_id_position].Value.ToString() + "'";
                }
            }

            if (s1 != "") // 지울데이터가 있음
            {
                Query = "delete from " + DB_TableName_file + " where  row_id < 0" + s1;
                FC.DataUpdate(Query);
                MessageBox.Show("file을 삭제하였습니다");

                Query = "select * from " + DB_TableName_file + " where db_nm='" + DB_TableName_cust + "' and int_id = '" + m_no + "' and f_option = 'file'";

                var DBConn = new MySqlConnection(Config.DB_con1);
                util.Con_DB_Open(ref DBConn);
                var cmd = new MySqlCommand(Query, DBConn);

                var myRead = cmd.ExecuteReader();
                if (!myRead.Read())
                {
                    Query = "update " + DB_TableName_cust + " set sub_file = '0' where row_id = '" + m_no + "'";
                    FC.DataUpdate(Query);
                }
                myRead.Close();
                DBConn.Close();
                FileGrid_View();
            }
            else
                MessageBox.Show("삭제할 file을 체크하여 주십시오");

        }

        private void bFileAdd_Click(object sender, EventArgs e)
        {
            FileControl FC = new FileControl();
            FC.FileControlInit(Config.DB_con1, Config.Ftp_ip1, Config.Ftp_id1, Config.Ftp_pw1);
            OpenFileDialog ofd = new OpenFileDialog();// File descriptor
            if (FC.FileOpenDlg(ofd) == 1)
                return;

            string server_file_name = FC.FileReg(ofd, DB_TableName_cust, "sub_file", m_no, "file");

            FileGrid_View();
        }

    }
}