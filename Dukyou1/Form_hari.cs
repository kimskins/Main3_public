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
using System.Runtime.InteropServices;

namespace Dukyou3
{
    public partial class Form_hari : Form
    {
        [DllImport("shell32.dll")]  //나중에 확인후 샥제요
        public static extern int ShellExecute(int hwnd, string lpOperation, string lpFile, string lpParameters,
                                                                   string lpDirectory, int nShowcmd);
        //
        SourceGrid.Grid grid;
        //
        string message_id = "";                          //에라 메세지구분 기호(블랙박스 호출후 나오는 메지지 정보구분 기호) 
        public string[] m_db = new string[60];           //함축자료 배열
        public string hang_s = "";
        public string bk_ids = "";
        string row_n = "";
        string[] row_dat = new string[10];  
        string ns = "";
        bool h_id = false;
        string jebon_n = "";      //제본 번호
        int jebon_opt = 0;        //제본 번호 
        string prn_n = "";        //인쇄 번호
        bool h_box = false;
        Label[] g_lab ;
        Label[] s_lab ;
        string hang = "" ;    // 항목
        string joo_id = "";   //견적=1,주문=2
        string hari_n = "";
        string black_id = "";                     //블랙박스 돌아갈때 초기 설정값  
        //                                        //분개장Row,기본,제본테이블B,제본옵션,주문/견적
        bool paper_prn_id = false;                //종이싸이즈와인쇄싸이즈가 같은지 확인하는 부호
        string mast_bungae_no = "";               //블랙박스 돌때마다 절테이블 검색했어면 C_sel_jul 의 row_id가 온다.  
        string call_id = "";                      //주문창,자동화창 호출위치 
        //
        string prn_size = "";           //인쇄싸이즈
        string paper_size = "";         //종이싸이즈
        bool paper_id = false;          //종이 있고=T,없고=F
        //
        public Form_hari(string[] ss, string nt, string jb, string nn, SourceGrid.Grid gd)   //주문장nt=1,자동화창nt=2에서 호출
        {
            InitializeComponent();
            grid = gd;  //자동화창 그리드1
            call_id = nt;
            //함축자료 구하기
            row_dat[0] = ss[0];  //row_id
            row_dat[1] = ss[1];  //서버항목명 --> [닷찌]등
            row_dat[2] = ss[2];  //전체 종이이름
            if (string.IsNullOrEmpty(row_dat[2]))
                paper_id = false;
            else
                paper_id = true;
            row_dat[3] = ss[3];  //복합자료(m_dat)
            row_dat[4] = ss[4];  //하리수정불가 표시
            row_dat[5] = ss[5];  //혼각계등
            row_dat[6] = ss[6];  //수정전 이름(혼각계등)
            row_dat[7] = ss[7];  //수량(자동화창)
            row_dat[8] = ss[8];  //단가(자동화창)
            row_dat[9] = ss[9];  //대수
            //
            m_db = row_dat[3].Split(new char[1] { '#' });
            row_n = row_dat[0];   //row_id
            jebon_n = jb;   //제본옵션번호
            jebon_opt = Convert.ToInt32(jebon_n);
            joo_id = nn;    //견적=1,주문=2
            //
            hang = row_dat[1]; // 항목
            //
            c_prn_mode.Text = row_dat[5];  //인쇄유형
            if (call_id == "1")  //주문장
            {
                c_prn_mode.Visible = false;
                button9.Enabled = false;
            }
            else if (call_id == "2" && row_dat[5] == "혼각계" && string.IsNullOrEmpty(row_dat[6]))
                c_prn_mode.Enabled = false;
            else
            {
                if (row_dat[5] == "혼각계")
                {
                    c_prn_mode.Items.Add(row_dat[6]);
                    c_prn_mode.Items.Add(row_dat[5]);
                }
                else
                {
                    c_prn_mode.Items.Add(row_dat[5]);
                    c_prn_mode.Items.Add("혼각계");
                }
            }
        }
        //
       

        public Form_hari(string[] dd,string nn)   //하리 계산만 하는과정만 
        {
            m_db = dd;
            joo_id = nn;  //견적=1,주문=2,3=매크로
            InitializeComponent();
        }
        //-----------------------------------------------------------------------------
        private void Form_hari_Load(object sender, EventArgs e)
        {
            prn_n = m_db[51];  //인쇄번호
            prn_option();      //인쇄옵션 설정
            //
            if (m_db[5] == "1")                 //자동 닷찌 체크 
                this.checkBox4.Checked = true;
            //
            if (m_db[49].Length == 3)           //닷찌조건 저장(3자리 수로 정함/checkBox7,radioButton13,radioButton14,checkBox5)
            {
                if (prn_n == "09")
                {
                    radioButton6.Enabled = false;  //구와이설정
                    radioButton7.Enabled = false;
                    radioButton8.Enabled = false;
                    radioButton9.Enabled = false;
                    radioButton8.Checked = true;
                    //                             //닷찌설정
                    checkBox6.Enabled = false;
                    radioButton13.Enabled = false;
                    radioButton14.Enabled = false;
                    checkBox5.Enabled = true;
                    radioButton14.Checked = true;
                }
                else if (hang.Contains("스티커") || hang.Contains("PET"))
                {
                    if (prn_n == "01" || prn_n == "02" || prn_n == "03")
                    {
                        radioButton6.Enabled = false;  //구와이설정
                        radioButton7.Enabled = false;
                        radioButton8.Enabled = false;
                        radioButton9.Enabled = false;
                        radioButton8.Checked = true;
                        //                             //닷찌설정
                        checkBox6.Enabled = false;
                        radioButton13.Enabled = false;
                        radioButton14.Enabled = false;
                        checkBox5.Enabled = false;
                        radioButton14.Checked = true;
                        checkBox5.Checked = true;
                    }
                    else if (prn_n == "04" || prn_n == "05")
                    {
                        radioButton6.Enabled = true;  //구와이설정
                        radioButton7.Enabled = false;
                        radioButton8.Enabled = true;
                        radioButton9.Enabled = false;
                        radioButton6.Checked = true;
                        //                             //닷찌설정
                        checkBox6.Enabled = false;
                        radioButton13.Enabled = false;
                        radioButton14.Enabled = false;
                        checkBox5.Enabled = false;
                        radioButton14.Checked = true;
                        checkBox5.Checked = true;
                    }
                    else
                    {
                        radioButton6.Enabled = true;  //구와이설정
                        radioButton7.Enabled = false;
                        radioButton8.Enabled = true;
                        radioButton9.Enabled = false;
                        radioButton6.Checked = true;
                        //                             //닷찌설정
                        checkBox6.Enabled = false;
                        radioButton13.Enabled = false;
                        radioButton14.Enabled = false;
                        checkBox5.Enabled = false;
                        radioButton14.Checked = true;
                        checkBox5.Checked = true;
                    }
                }
                else
                {
                    if (m_db[49].Substring(0, 1) == "1")
                        checkBox6.Checked = true;
                    else
                        checkBox6.Checked = false;
                    //
                    if (m_db[49].Substring(1, 1) == "1")
                        radioButton13.Checked = true;
                    else if (m_db[49].Substring(1, 1) == "2")
                        radioButton14.Checked = true;
                    else
                    {
                        radioButton13.Checked = false;
                        radioButton14.Checked = false;
                    }
                    if (m_db[49].Substring(2, 1) == "1")
                        checkBox5.Checked = true;
                    else
                        checkBox5.Checked = false;
                    //
                }
            }
            hari_n = m_db[7]; //result[0]["a18"].ToString().Trim(); //하리모형
            //
            textBox15.Text = m_db[6];  //추가수
            //
            if (m_db[0].Equals("책자형"))
            {
                radioButton1.Text = "1.5mm";
                radioButton2.Text = "3mm";
                radioButton15.Text= "4mm";
                radioButton3.Text = "5mm";
                radioButton4.Text = "0mm";
                //
                if (m_db[8].Equals("1.5"))
                    radioButton1.Checked = true;
                else if (m_db[8].Equals("3"))
                    radioButton2.Checked = true;
                else if (m_db[8].Equals("4"))
                    radioButton15.Checked = true;
                else if (m_db[8].Equals("5"))
                    radioButton3.Checked = true;
                else if (m_db[8].Equals("0"))
                    radioButton4.Checked = true;
                //
                if (m_db[5].Equals("1"))
                    checkBox4.Checked = true;  //수동 닷찌
                //
            }
            else if (m_db[0].Equals("낱장형"))
            {

            }
            else if (m_db[0].Equals("쇼핑백형"))
            {
            }
            else if (m_db[0].Equals("봉투형"))
            {
            }
            //
            if (m_db[9].Equals("일반"))
                radioButton6.Checked = true;
            else if (m_db[9].Equals("양면"))
                radioButton7.Checked = true;
            else if (m_db[9].Equals("재물"))
                radioButton8.Checked = true;
            else if (m_db[9].Equals("윤전"))
                radioButton9.Checked = true;
            //
            textBox1.Text =  m_db[10];//도큐싸이즈
            textBox2.Text =  m_db[11];//국,46
            textBox3.Text =  m_db[12];//절수
            textBox4.Text =  m_db[13];//상,좌
            //
            textBox6.Text =  m_db[15];//인쇄 싸이즈
            textBox11.Text = m_db[16];//인쇄 국,46
            textBox12.Text = m_db[17];//인쇄 절수
            textBox16.Text = m_db[14];//인쇄 종,횡목
            //
            textBox8.Text =  m_db[18];//종이 싸이즈
            textBox13.Text = m_db[19];//종이 국,46
            textBox14.Text = m_db[20];//종이 절수
            textBox5.Text =  m_db[30];//종이 종,횡
            //
            textBox7.Text = m_db[32];//접지-1
            textBox9.Text = m_db[22];//판걸이
            //
            prn_size = m_db[15];           //인쇄싸이즈
            paper_size = m_db[18];         //종이싸이즈
            // 
            if (m_db[24].Equals("1"))
                label13.Text = "√"; 
            string[] axx = m_db[10].Split(new char[1] { '*' });
            //
            hari_sel(false);  //하리내용 호출
            dataGridView1.CellValueChanged -= new DataGridViewCellEventHandler(c_edit); //여기가 중요
            //스티커/PET 조건 설정
            if (row_dat[1].Contains("스티커") || row_dat[1].Contains("PET"))
            {
                label8.Visible = false;
                textBox6.Visible = false;
                button47.Visible = false;
                textBox11.Visible = false;
                textBox12.Visible = false;
                textBox16.Visible = false;
                label13.Visible = false;
                label4.Text = "원단Size";
            }
            //
            if (row_dat[4].Equals("0"))  //하리 수정가능/불가
            {
                checkBox2.Checked = false;  //수정가능 
            }
            else
            {
                checkBox2.Checked = true;   //수정불가
                dataGridView1.Enabled = false;
                //
                textBox1.Enabled = false;
                textBox6.Enabled = false;
                textBox8.Enabled = false;
                checkBox4.Enabled = false;
                checkBox6.Enabled = false;
                checkBox5.Enabled = false;
                panel1.Enabled = false;
                panel3.Enabled = false;
                panel6.Enabled = false;
                button2.Enabled = false;
                button47.Enabled = false;
                button3.Enabled = false;
            }
            //
            if (dataGridView1.RowCount != 0)
                dataGridView1.Rows[dataGridView1.CurrentCell.RowIndex].Selected = false;
            //
            if (dataGridView2.RowCount != 0)
                dataGridView2.Rows[dataGridView1.CurrentCell.RowIndex].Selected = false;
            //
            dataGridView1.CellValueChanged += new DataGridViewCellEventHandler(c_edit); //여기가 중요
            dataGridView2.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(c_click);
            checkBox2.CheckedChanged += new System.EventHandler(checkBox2_CheckedChanged);  //수정불가
            // 
            radioButton1.Click += new System.EventHandler(xx1);             //
            radioButton2.Click += new System.EventHandler(xx1);             //
            radioButton3.Click += new System.EventHandler(xx1);             //
            radioButton15.Click += new System.EventHandler(xx1);             //
            radioButton4.Click += new System.EventHandler(xx1);             //
            radioButton6.Click += new System.EventHandler(xx1);             //
            radioButton7.Click += new System.EventHandler(xx1);             //
            radioButton8.Click += new System.EventHandler(xx1);             //
            radioButton9.Click += new System.EventHandler(xx1);             //
            //
            dasjji();
            //
            this.radioButton13.CheckedChanged += new System.EventHandler(this.radioButton13_CheckedChanged);
            this.checkBox6.CheckedChanged += new System.EventHandler(this.checkBox6_CheckedChanged);
         }

        private void prn_option()  //인쇄 옵션설정
        {
            if (prn_n == "01" || prn_n == "02" || prn_n == "03")  //마스타,디지탈,인디고 구와이 설정
            {
                checkBox4.Enabled = true;
                checkBox4.Checked = false;
                //------------------------------------ 닷찌
                radioButton1.Enabled = true;  //1.5
                radioButton1.Checked = false;
                radioButton2.Enabled = true;  //3 √
                radioButton2.Checked = true;
                radioButton15.Enabled = true;  //4
                radioButton15.Checked = false;
                radioButton3.Enabled = true;  //5
                radioButton3.Checked = false;
                radioButton4.Enabled = true;  //0
                radioButton4.Checked = false;
                //------------------------------------ 구와이
                radioButton6.Enabled = false;  //일반
                radioButton6.Checked = false;
                radioButton7.Enabled = false;  //양면
                radioButton7.Checked = false;
                radioButton8.Enabled = false;  //재물 √
                radioButton8.Checked = true;
                radioButton9.Enabled = false;  //윤전
                radioButton9.Checked = false;
                //------------------------------------ 
                checkBox6.Enabled = false;     //닷찌검색
                checkBox6.Checked = false;
                //
                radioButton13.Enabled = false;  //Yes
                radioButton13.Checked = false;
                //
                radioButton14.Enabled = false;  //No  √
                radioButton14.Checked = true;
                //
                checkBox5.Enabled = false;     //전지제외
                checkBox5.Checked = true;
                //----------------------------------------
            }
            else if (prn_n == "04" || prn_n == "06")
            {
                checkBox4.Enabled = true;
                checkBox4.Checked = false;
                //------------------------------------ 닷찌
                radioButton1.Enabled = true;  //1.5
                radioButton1.Checked = false;
                radioButton2.Enabled = true;  //3 √
                radioButton2.Checked = true;
                radioButton15.Enabled = true;  //4
                radioButton15.Checked = false;
                radioButton3.Enabled = true;  //5
                radioButton3.Checked = false;
                radioButton4.Enabled = true;  //0
                radioButton4.Checked = false;
                //------------------------------------ 구와이
                radioButton6.Enabled = true;   //일반 √
                radioButton6.Checked = true;
                radioButton7.Enabled = true;  //양면
                radioButton7.Checked = false;
                radioButton8.Enabled = true;  //재물 
                radioButton8.Checked = false;
                radioButton9.Enabled = false;  //윤전
                radioButton9.Checked = false;
                //------------------------------------ 
                checkBox6.Enabled = true;     //닷찌검색
                checkBox6.Checked = false;
                //
                radioButton13.Enabled = true;  //Yes
                radioButton13.Checked = false;
                //
                radioButton14.Enabled = true;  //No  
                radioButton14.Checked = false;
                //
                checkBox5.Enabled = true;     //전지제외
                checkBox5.Checked = false;
                //----------------------------------------
            }
            else if (prn_n == "05")  //윤전인쇄
            {
                checkBox4.Enabled = false;
                checkBox4.Checked = true;
                //------------------------------------ 닷찌
                radioButton1.Enabled = false;  //1.5
                radioButton1.Checked = false;
                radioButton2.Enabled = false;  //3 
                radioButton2.Checked = false;
                radioButton15.Enabled = false;  //4
                radioButton15.Checked = false;
                radioButton3.Enabled = false;  //5
                radioButton3.Checked = false;
                radioButton4.Enabled = false;  //0  √
                radioButton4.Checked = true;
                //------------------------------------ 구와이
                radioButton6.Enabled = false;  //일반 
                radioButton6.Checked = false;
                radioButton7.Enabled = false;  //양면
                radioButton7.Checked = false;
                radioButton8.Enabled = false;  //재물 
                radioButton8.Checked = false;
                radioButton9.Enabled = false;  //윤전 √
                radioButton9.Checked = true;
                //------------------------------------ 
                checkBox6.Enabled = false;     //닷찌검색
                checkBox6.Checked = false;
                //
                radioButton13.Enabled = false;  //Yes
                radioButton13.Checked = false;
                //
                radioButton14.Enabled = false;  //No  √
                radioButton14.Checked = true;
                //
                checkBox5.Enabled = false;     //전지제외
                checkBox5.Checked = true;
                //----------------------------------------
            }
        }

        //----------------------------------------------------------------------------------
        private void c_edit(object sender, DataGridViewCellEventArgs e)        //수정
        {
            dataGridView1.CellValueChanged -= new DataGridViewCellEventHandler(c_edit);
            if (e.ColumnIndex.Equals(3)) //갯수
            {
                string dat = dataGridView1.CurrentCell.Value.ToString().Trim();
                string row_no = dataGridView1.Rows[dataGridView1.CurrentRow.Index].Cells[1].Value.ToString().Trim();
                //
                double pp = 0;  //종이
                double cc = 0;  //도큐
                double da = 0;  //닷찌
                double ea = 0;  //갯수
                //
                if (e.RowIndex.Equals(0)) //가로
                {
                    pp = Convert.ToDouble(dataGridView1.Rows[0].Cells[0].Value.ToString().Trim());  //종이(앞수)
                    cc = Convert.ToDouble(dataGridView1.Rows[0].Cells[1].Value.ToString().Trim());  //도큐(앞수)
                    da = Convert.ToDouble(dataGridView1.Rows[0].Cells[2].Value.ToString().Trim());  //(가로)닷찌
                    ea = Convert.ToDouble(dataGridView1.Rows[0].Cells[3].Value.ToString().Trim());  //(가로)갯수
                    //
                    dataGridView1.Rows[0].Cells[4].Value = Convert.ToString((pp - ((cc + da) * ea)) / 2);
                    dataGridView1.Rows[0].Cells[6].Value = Convert.ToString((pp - ((cc + da) * ea)) / 2);
                }
                else if (e.RowIndex.Equals(1)) //세로
                {
                    pp = Convert.ToDouble(dataGridView1.Rows[1].Cells[0].Value.ToString().Trim());  //종이(뒷수)
                    cc = Convert.ToDouble(dataGridView1.Rows[1].Cells[1].Value.ToString().Trim());  //도큐(뒷수)
                    da = Convert.ToDouble(dataGridView1.Rows[1].Cells[2].Value.ToString().Trim());  //(세로)닷찌
                    ea = Convert.ToDouble(dataGridView1.Rows[1].Cells[3].Value.ToString().Trim());  //(세로)갯수
                    //
                    dataGridView1.Rows[1].Cells[4].Value = Convert.ToString(10);
                    dataGridView1.Rows[1].Cells[6].Value = Convert.ToString((pp - ((cc + da) * ea)) - 10);
                }
                //
                string[] sd = new string[7];
                sd[0] = m_db[11];  //국,46(aa)=a
                sd[1] = m_db[13];  //상,좌(bb)=b
                if (!m_db[40].Equals(""))
                    sd[2] = "가로";  //도지(cc)=g
                else if (!m_db[46].Equals(""))
                    sd[2] = "세로";  //도지(cc)=g
                else
                    sd[2] = "";  //도지(cc)=g
                //
                sd[3] = m_db[12];  //책절수(jj)=c
                sd[4] = dataGridView1.Rows[0].Cells[3].Value.ToString();  //가로=garo
                sd[5] = dataGridView1.Rows[1].Cells[3].Value.ToString();  //세로=sero
                sd[6] = m_db[17];  //종이절수(mm)=d
                // 
                dataGridView2.Rows.Clear();
                //
                var DBConn = new MySqlConnection(Config.DB_con1);
                DBConn.Open();
                string cQuery = "select mu_jubji_11,mu_jubji_12,ju_jubji_11,ju_jubji_12,jarak from C_sel_jul where a='" + sd[0] + "' and b='" + sd[1] + "' and g='" + sd[2] + "'";
                cQuery += " and c='" + sd[3] + "' and h='" + sd[4] + "' and i='" + sd[5] + "' and d='" + sd[6] + "'";
                var cmd = new MySqlCommand(cQuery, DBConn);
                var myRead = cmd.ExecuteReader();
                string jarr = "";
                string jubx1 = "";
                string jubx2 = "";
                if (myRead.Read())
                {
                    if (jebon_n == "8")
                    {
                        m_db[32] = myRead["ju_jubji_11"].ToString().Trim();   //접지1
                        m_db[33] = myRead["ju_jubji_12"].ToString().Trim();  //접지2
                    }
                    else
                    {
                        m_db[32] = myRead["mu_jubji_11"].ToString().Trim();   //접지1;   //접지1
                        m_db[33] = myRead["mu_jubji_12"].ToString().Trim();  //접지1;   //접지2
                    }
                    //
                    jarr = myRead["jarak"].ToString().Trim();  //자략
                    jubx1 = myRead["mu_jubji_11"].ToString().Trim();      //
                    jubx2 = myRead["mu_jubji_12"].ToString().Trim();     //
                }
                else
                {
                    m_db[32] = "";  //접지1;   //접지1
                    m_db[33] = "";  //접지1;   //접지2
                    jarr = "";      //자략
                    jubx1 = "";     //
                    jubx2 = "";     //
                }
                myRead.Close();
                //
                if (!jarr.Equals(""))
                {
                    decimal ja = Convert.ToDecimal(jarr.Trim()); //자락
                    decimal ja1 = Convert.ToDecimal(dataGridView1.Rows[0].Cells[4].Value.ToString());   //여분1
                    decimal ja2 = Convert.ToDecimal(dataGridView1.Rows[0].Cells[6].Value.ToString());   //여분2
                    //
                    if (jebon_n.Equals("8"))  //중철접지 && a형
                    {
                        if (ja1 + ja2 < ja)      //중철접지 불가하므로 무선접지 방법으로 교체 
                        {
                            m_db[32] = jubx1;   //접지1
                            m_db[33] = jubx2;   //접지2
                        }
                        else
                        {
                            m_db[38] = (ja1 + ja2 - ja).ToString();  //가로여분-1
                            m_db[39] = ja.ToString();                //가로여분-2
                            //
                            dataGridView1.Rows[0].Cells[4].Value = m_db[38];
                            dataGridView1.Rows[0].Cells[6].Value = m_db[39];
                        }
                    }
                }
                //
                textBox7.Text = m_db[32];//접지-1
                //
                string[] jub1 = m_db[32].Split(new char[1] { '+' });
                string[] jub2 = m_db[33].Split(new char[1] { '+' });
                int ax = jub2.Length;
                dataGridView2.Rows.Add(ax);
                string jubc = "";
                for (int i = 0; i < ax; i++)
                {
                    if (jub2[i].Equals("1"))
                        jubc = "정접지";
                    else if (jub2[i].Equals("2"))
                        jubc = "두루마리A";
                    else if (jub2[i].Equals("3"))
                        jubc = "두루마리B";
                    else if (jub2[i].Equals("4"))
                        jubc = "두루마리C";
                    else if (jub2[i].Equals("5"))
                        jubc = "두루마리D";
                    else if (jub2[i].Equals("6"))
                        jubc = "N접지";
                    else
                        jubc = jub2[i];
                    //
                    dataGridView2.Rows[i].Cells[0].Value = (i + 1).ToString();
                    dataGridView2.Rows[i].Cells[1].Value = jub1[i];
                    dataGridView2.Rows[i].Cells[2].Value = jubc;
                }
                DBConn.Close();
            }
            dataGridView1.CellValueChanged += new DataGridViewCellEventHandler(c_edit);

        }
        //--------------------------------------------------------------------------
        public void hari_sel(bool ss)   //  하리설정
        {
            h_id = ss;  //최종 저장 확인  
            //
            dataGridView1.CellValueChanged -= new DataGridViewCellEventHandler(c_edit); //여기가 중요
            //
            textBox15.Text = m_db[6];  //추가수
            //
            if (h_id == true)  //분개장에서 호출시
            {
                if (m_db[49].Equals("1"))         //닷찌인쇄 일경우
                    radioButton13.Checked = true;
                else if (m_db[49].Equals("2"))    //전지인쇄 일경우
                    radioButton14.Checked = true;
                //
                if (m_db[0].Equals("책자형"))
                {
                    if (m_db[8].Equals("1.5"))
                        radioButton1.Checked = true;
                    else if (m_db[8].Equals("3"))
                        radioButton2.Checked = true;
                    else if (m_db[8].Equals("4"))
                        radioButton15.Checked = true;
                    else if (m_db[8].Equals("5"))
                        radioButton3.Checked = true;
                    else if (m_db[8].Equals("0"))
                        radioButton4.Checked = true;
                }
                //
                if (m_db[9].Equals("일반"))
                    radioButton6.Checked = true;
                else if (m_db[9].Equals("양면"))
                    radioButton7.Checked = true;
                else if (m_db[9].Equals("재물"))
                    radioButton8.Checked = true;
                else if (m_db[9].Equals("윤전"))
                    radioButton9.Checked = true;
                //
            }
            ///////
            if (m_db[10].Equals(""))
            {
                MessageBox.Show("도큐 싸이즈가 없습니다.");
                return;
            }
            // 
            string[] ax1 = m_db[10].Split(new char[1] { '*' });  //도큐싸이즈
            string[] ax2 = m_db[15].Split(new char[1] { '*' });  //인쇄싸이즈
            if (string.IsNullOrEmpty(ax1[0]) || string.IsNullOrEmpty(ax1[1]) || string.IsNullOrEmpty(ax2[0]) || string.IsNullOrEmpty(ax2[1]))
                return;
            //
            double cc1 = Convert.ToDouble(ax1[0]);  //도큐앞수
            double cc2 = Convert.ToDouble(ax1[1]);  //도큐뒤수
            double pp1 = Convert.ToDouble(ax2[0]);  //인쇄종이 앞수
            double pp2 = Convert.ToDouble(ax2[1]);  //인쇄종이 뒷수
            if (pp1 < pp2)  //종이싸이즈 앞수는 큰수로 교체
            {
                double temx = pp1;
                pp1 = pp2;
                pp2 = temx;
            }
            //
            double da1 = 0;
            double da2 = 0;
            double dax = 0;
            double su1 = 0;
            double su2 = 0;
            //
            if (!string.IsNullOrEmpty(m_db[37])) //
                su1 = Convert.ToDouble(m_db[37]);
            //
            if (!string.IsNullOrEmpty(m_db[43])) //
                su2 = Convert.ToDouble(m_db[43]);
            //
            //m_db[46] = "세로";             //세로도지
            dax = Convert.ToDouble(m_db[8]); //닷찌 수
            string abc = "";
            //
            int p_su = 0; //a +수

            abc = m_db[7];  //하리모형(a,b,c)
            if (abc.Length != 1)
                p_su = Convert.ToInt32(abc.Substring(2, 1));
            //
            if (abc == "a+3")
            {
                da1 = dax * 2;            //도지 
                da2 = dax + p_su;         //안도지
            }
            else if (abc == "a")
            {
                da1 = dax * 2;            //도지 
                da2 = dax * 1;            //안도지
            }
            else if (abc == "b")
            {
                da1 = dax * 2;            //도지 
                da2 = dax * 1;            //안도지
            }
            else                          //c,d 조건
            {
                da1 = dax * 2;   //가로닷찌 
                da2 = dax * 2;   //세로닷찌
            }
            //
            string p_id = m_db[40].Equals("가로") ? "역방향" : "정방향";
            //
            string[] s_db = new string[10];
            // 
            if (p_id == "정방향")
            {
                s_db[1] = Convert.ToString((pp1 - ((cc1 + da2) * Convert.ToDouble(m_db[37]))) / 2) ; //가로여분1=(종이큰수-(도큐앞수+안도지)*가로갯수/2  //
                s_db[2] = s_db[1];                                                                   //가로여분2=
                s_db[3] = "";        //가로간격
                s_db[4] = m_db[8];   //가로닷찌
                //
                if (radioButton6.Checked == true)  //일반
                {
                    if ((pp2 - ((cc2 + da1) * Convert.ToDouble(m_db[43]))) - 10 > 5)  //나머지가 5보타 크다면
                    {
                        s_db[5] = "15"; // Convert.ToString((pp2 - ((cc2 + da1) * Convert.ToDouble(m_db[43]))) / 2);  //세로여분1
                        s_db[6] = Convert.ToString((pp2 - ((cc2 + da1) * Convert.ToDouble(m_db[43]))) - 15);          //세로여분2
                    }
                    else
                    {
                        s_db[5] = "10"; // Convert.ToString((pp2 - ((cc2 + da1) * Convert.ToDouble(m_db[43]))) / 2);  //세로여분1
                        s_db[6] = Convert.ToString((pp2 - ((cc2 + da1) * Convert.ToDouble(m_db[43]))) - 10);          //세로여분2
                    }
                }
                else
                {
                    s_db[5] = Convert.ToString((pp2 - ((cc2 + da1) * Convert.ToDouble(m_db[43]))) / 2);  //세로여분1
                    s_db[6] = Convert.ToString((pp2 - ((cc2 + da1) * Convert.ToDouble(m_db[43]))) / 2);  //세로여분2
                }
                s_db[7] = "";        //세로간격
                s_db[8] = m_db[8];   //세로닷찌
            }
            else  //역방향
            {
                s_db[1] = Convert.ToString((pp1 - ((cc2 + da1) * Convert.ToDouble(m_db[37]))) / 2);  //가로여분1
                s_db[2] = s_db[1];                                                                   //가로여분2
                s_db[3] = "";        //가로간격
                s_db[4] = m_db[8];   //가로닷찌
                if (radioButton6.Checked == true)  //일반
                {
                    if ((pp2 - ((cc1 + da2) * Convert.ToDouble(m_db[43]))) - 10 > 5)
                    {
                        s_db[5] = "15";                                                                     //세로여분1
                        s_db[6] = Convert.ToString((pp2 - ((cc1 + da2) * Convert.ToDouble(m_db[43]))) - 15);//세로여분2
                    }
                    else
                    {
                        s_db[5] = "10";                                                                     //세로여분1
                        s_db[6] = Convert.ToString((pp2 - ((cc1 + da2) * Convert.ToDouble(m_db[43]))) - 10);//세로여분2
                    }
                }
                else
                {
                    s_db[5] = Convert.ToString((pp2 - ((cc1 + da2) * Convert.ToDouble(m_db[43]))) / 2); //세로여분1
                    s_db[6] = Convert.ToString((pp2 - ((cc1 + da2) * Convert.ToDouble(m_db[43]))) / 2); //세로여분2
                }
                s_db[7] = "";        //세로간격
                s_db[8] = m_db[8];   //세로닷찌
            }
            //
            if (checkBox6.Checked == true && radioButton13.Checked == true)     //닷찌인쇄
            {
                if (p_id == "정방향")
                {
                    s_db[5] = Convert.ToString((pp2 - ((cc2 + da1) * su2)) / 2);//세로여분-1
                    s_db[6] = s_db[5];//세로여분-2
                }
                else       //역방향
                {
                    s_db[5] = Convert.ToString((pp2 - ((cc1 + da2) * su2)) / 2); //세로여분-1
                    s_db[6] = s_db[5];                                           //세로여분-2
                }
            }
            //경고 메세지
            if (h_id == false)   // true==분개장에서 호출시
            {
                if (radioButton7.Checked == true)  //양면기(구와이)
                {
                    if (Convert.ToDouble(s_db[1]) < 0 || Convert.ToDouble(s_db[2]) < 0 || Convert.ToDouble(s_db[5]) < 10 || Convert.ToDouble(s_db[6]) < 10)
                        MessageBox.Show("인쇄싸이즈가 맞지않아 인쇄가 불가 합니다.", " ★ 경고문 ");
                }
                else
                {
                    if (Convert.ToDouble(s_db[1]) < 0 || Convert.ToDouble(s_db[2]) < 0 || Convert.ToDouble(s_db[5]) < 0 || Convert.ToDouble(s_db[6]) < 0)
                        MessageBox.Show("인쇄싸이즈가 맞지않아 인쇄가 불가 합니다.", " ★ 경고문");
                }
                //
                if (checkBox6.Checked == true && radioButton13.Checked == true && (textBox6.Text == "1091*788" || textBox6.Text == "788*1091"))     //닷찌인쇄
                {
                    if (Convert.ToDouble(s_db[1]) < 12 || Convert.ToDouble(s_db[2]) < 12)
                        MessageBox.Show("인쇄싸이즈가 맞지않아 인쇄가 불가 합니다.", " ★ 경고문 ");
                }
            }
            //
            dataGridView1.Rows.Clear();
            dataGridView2.Rows.Clear();
            //
            dataGridView1.Rows.Add(2);
            dataGridView1.Rows[0].Cells[0].Value = pp1.ToString();    //I-size
            dataGridView1.Rows[0].Cells[3].Value = m_db[37];  //갯수
            dataGridView1.Rows[0].Cells[4].Value = s_db[1];  //여분-1
            dataGridView1.Rows[0].Cells[5].Value = s_db[3];  //간격
            dataGridView1.Rows[0].Cells[6].Value = s_db[2];  //여분-2
            //
            dataGridView1.Rows[1].Cells[0].Value = pp2.ToString();    //I-size
            dataGridView1.Rows[1].Cells[3].Value = m_db[43];  //갯수
            dataGridView1.Rows[1].Cells[4].Value = s_db[5];  //여분-1
            dataGridView1.Rows[1].Cells[5].Value = s_db[7];  //간격
            dataGridView1.Rows[1].Cells[6].Value = s_db[6];  //여분-2
            //
            if (p_id == "정방향")
            {
                dataGridView1.Rows[0].Cells[1].Value = cc1.ToString();     //c-size
                dataGridView1.Rows[1].Cells[1].Value = cc2.ToString();     //c-size
                if (jebon_n.Equals("7") || jebon_n.Equals("6"))  //PUR제본=7/초가다미=6 일경우
                {
                    da2 = da2 - 3;
                    dataGridView1.Rows[0].Cells[2].Value = da2.ToString()+"+3"; //딧찌
                    dataGridView1.Rows[1].Cells[2].Value = da1.ToString();      //딧찌
                }
                else
                {
                    dataGridView1.Rows[0].Cells[2].Value = da2.ToString();      //딧찌
                    dataGridView1.Rows[1].Cells[2].Value = da1.ToString();      //딧찌
                }
                dataGridView1.Rows[0].Cells[7].Value = "";                 //도지
                dataGridView1.Rows[1].Cells[7].Value = "※";               //도지
            }
            else  //역방향
            {
                dataGridView1.Rows[0].Cells[1].Value = cc2.ToString();     //c-size
                dataGridView1.Rows[1].Cells[1].Value = cc1.ToString();     //c-size
                if (jebon_n.Equals("7") || jebon_n.Equals("6"))  //PUR제본=7/초가다미=6 일경우
                {
                    da2 = da2 - 3;
                    dataGridView1.Rows[0].Cells[2].Value = da1.ToString();         //딧찌
                    dataGridView1.Rows[1].Cells[2].Value = da2.ToString() + "+3";  //딧찌
                }
                else
                {
                    dataGridView1.Rows[0].Cells[2].Value = da1.ToString();     //딧찌
                    dataGridView1.Rows[1].Cells[2].Value = da2.ToString();     //딧찌
                }
                dataGridView1.Rows[0].Cells[7].Value = "※";               //도지
                dataGridView1.Rows[1].Cells[7].Value = "";                 //도지
            }
            //
            if (!hang.Contains("표지"))  //항목이 표지가 아니라면
            {
                string[] jub1 = m_db[32].Split(new char[1] { '+' }); //접지1 분해
                string[] jub2 = m_db[33].Split(new char[1] { '+' }); //접지2 분해
                int xx = jub2.Length;
                dataGridView2.Rows.Add(xx);
                string jubc = "";
                for (int i = 0; i < xx; i++)
                {
                    if (jub2[i].Equals("1"))
                        jubc = "정접지";
                    else if (jub2[i].Equals("2"))
                        jubc = "두루마리A";
                    else if (jub2[i].Equals("3"))
                        jubc = "두루마리B";
                    else if (jub2[i].Equals("4"))
                        jubc = "두루마리C";
                    else if (jub2[i].Equals("5"))
                        jubc = "두루마리D";
                    else if (jub2[i].Equals("6"))
                        jubc = "N접지";
                    else if (jub2[i].Equals("11"))
                        jubc = "16p정접지";
                    else if (jub2[i].Equals("12"))
                        jubc = "8p정접지";
                    else if (jub2[i].Equals("13"))
                        jubc = "4p정접지";
                    else
                        jubc = jub2[i];
                    //
                    dataGridView2.Rows[i].Cells[0].Value = (i + 1).ToString();
                    dataGridView2.Rows[i].Cells[1].Value = jub1[i];
                    dataGridView2.Rows[i].Cells[2].Value = jubc;
                }
            }
            //
            dataGridView1.CellValueChanged += new DataGridViewCellEventHandler(c_edit); //여기가 중요
        }
        //
        private void button2_Click(object sender, EventArgs e)   //1버튼(계산기) 종이 선택하는 과정
        {
            mast_bungae_no = "";    //분개번호 초기화
            message_id = "1";       //에라 메세지구분 기호(블랙박스 호출후 나오는 메지지 정보구분 기호) 
 
            if (string.IsNullOrEmpty(textBox1.Text))
            {
                MessageBox.Show("도큐 싸이즈를 입력해 주세요.");
                return;
            }
            if (textBox1.Text.Contains("*") == false)
            {
                MessageBox.Show("도큐싸이즈 가로,세로를 '123.5*123.5' 으로 표시해 주세요");
                return;
            }
            //
            // 
            string[] jj = new string[5];  //초기정보 배열
            jj[0] = "규격";         //규격,비규격
            jj[1] = textBox1.Text;  //도큐싸이즈
            jj[2] = "";             //별지싸이즈
            jj[3] = "";             //별지절수
            jj[4] = "";             //별지국,46
            black_id = "0";         //기본조건
            // 
            if (f21_Enter(jj) == false)   //1차 기본으로 돌리고
            {
                dat_del();  //자료 일괄 삭제
                return;
            }
            //
            if (prn_n == "01" || prn_n == "02" || prn_n == "03")  //디지탈,마스타,인디고
            {
                string[] tem1 = new string[3];
                tem1 = get_multi.selet_kook(textBox6.Text.Trim());
                textBox8.Text = tem1[0];
                textBox13.Text = tem1[1];
                textBox14.Text = tem1[2];
            }
            else                                        // 나머지는 인세싸이즈와 동일
            {
                textBox8.Text = textBox6.Text.Trim();
                textBox13.Text = textBox11.Text.Trim();
                textBox14.Text = textBox12.Text.Trim();
            }
            //
            string[] axx = textBox6.Text.Trim().Split(new char[1] { '*' });  //인쇄싸이즈를 가지고 종,횡목에 따라 인쇄 싸이즈 재설정
            Double f_su = Convert.ToDouble(axx[0]); //인쇄싸이즈의 앞수
            Double r_su = Convert.ToDouble(axx[1]); //인쇄싸이즈의 뒷수
            if (f_su < r_su)  //앞수가 작다면 큰수로 교체하고
            {
                Double temd = f_su;
                f_su = r_su;  //큰수
                r_su = temd;  //작은수
            }
            //
            if (textBox16.Text.Trim().Equals("종목"))   //뒷수가 큰거
                textBox6.Text = r_su.ToString() + "*" + f_su;
            else
                textBox6.Text = f_su.ToString() + "*" + r_su;
            // 
            jj[0] = "비규격";               //규격,비규격
            jj[1] = textBox6.Text.Trim();   //도큐싸이즈
            jj[2] = textBox8.Text.Trim();   //별지싸이즈
            jj[3] = textBox14.Text.Trim();  //별지절수
            jj[4] = textBox13.Text.Trim();  //별지국,46
            black_id = "3";         //기본조건
            if (f21_Enter(jj) == false)   //1차 기본으로 돌리고
            {
                dat_del();  //자료 일괄 삭제
                return;
            }
            //
            axx = textBox8.Text.Trim().Split(new char[1] { '*' });  //종이싸이즈를 가지고 종,횡목에 따라 인쇄 싸이즈 재설정
            f_su = Convert.ToDouble(axx[0]); //종이싸이즈의 앞수
            r_su = Convert.ToDouble(axx[1]); //종이싸이즈의 뒷수
            if (f_su < r_su)  //앞수가 작다면 큰수로 교체하고
            {
                Double temd = f_su;
                f_su = r_su;
                r_su = temd;
            }
            //
            if (textBox5.Text.Trim().Equals("종목"))   //뒷수가 큰거
                textBox8.Text = r_su.ToString() + "*" + f_su;
            else
                textBox8.Text = f_su.ToString() + "*" + r_su;
            //
            dat_all();
            //
            //최종 종이싸이즈 재결정 하는 과정
            if (textBox6.Text == "636*467" || textBox6.Text == "467*636" || textBox6.Text == "543*392" || textBox6.Text == "392*543")
                button47_Click(null, null);   //2번 계산버튼
            //
            hari_sel(false);   //하리 refresh
            button7_Click(null, null); //그림 refresh
        }
        //
        private void dat_del()  //자료 일괄 삭제
        {
            textBox2.Text = "";
            textBox3.Text = "";
            textBox4.Text = "";
            textBox6.Text = "";
            textBox11.Text = "";
            textBox12.Text = "";
            textBox16.Text = "";
            textBox8.Text = "";
            textBox13.Text = "";
            textBox14.Text = "";
            textBox5.Text = "";
        }
        //
        private void dat_all()  //도큐등 자료 일괄 대입
        {
            m_db[10] = textBox1.Text.Trim(); // pp[2].Trim();     //도큐싸이즈
            m_db[11] = textBox2.Text.Trim(); // sel_pp.a_xno[3].Trim(); //국,46
            m_db[12] = textBox3.Text.Trim(); // sel_pp.a_xno[0].Trim(); //절수
            m_db[13] = textBox4.Text.Trim(); // sel_pp.a_xno[4].Trim(); //상,좌

            m_db[14] = textBox16.Text.Trim(); // sel_pp.a_xno[5].Trim(); //인쇄 종,횡목
            m_db[15] = textBox6.Text.Trim(); // sel_pp.a_xno[1].Trim() + "*" + sel_pp.a_xno[2].Trim(); //인쇄싸이즈
            m_db[16] = textBox11.Text.Trim(); //인쇄싸이즈 국/46
            m_db[17] = textBox12.Text.Trim(); //인쇄싸이즈 절수

            m_db[18] = textBox8.Text.Trim(); //종이 싸이즈
            m_db[19] = textBox13.Text.Trim(); //종이 국/46
            m_db[20] = textBox14.Text.Trim(); //종이 절수
            m_db[30] = textBox5.Text.Trim(); //종이 종,횡목
        }
        //-----------------------------------------------------------------------------------------
        private bool f21_Enter(string[] jj)     //책자형에서 버튼클릭시 //
        {
            bool x_bool;
            string[] ss = new string[12];       //보내는 배열정보 12개로 수정
            //
            for (int i = 0; i < ss.Length; i++)
                ss[i] = "";
            //
            if (radioButton14.Checked == false && checkBox5.Checked == false)  //닷찌검색 조건
                ss[9] = "4";  //닷찌,전지인쇄가능
            else if (radioButton14.Checked == false && checkBox5.Checked == true)
                ss[9] = "3";  //닷찌인쇄
            else if (radioButton14.Checked == true && checkBox5.Checked == false)
                ss[9] = "2";  //전지인쇄
            else if (radioButton14.Checked == true && checkBox5.Checked == true)
                ss[9] = "1";  //둘다 불가
            //
            ss[0] = "책자형";  // 
            ss[8] = hari_n;    //
            // 
            if (radioButton1.Checked)    //닷찌  체크값에 따라 숫자형 배당
                ss[1] = "1.5";
            else if (radioButton2.Checked)
                ss[1] = "3";
            else if (radioButton15.Checked)
                ss[1] = "4";
            else if (radioButton3.Checked)
                ss[1] = "5";
            else if (radioButton4.Checked)
                ss[1] = "0";
            //
            if (radioButton6.Checked)     //구와이
                ss[2] = "일반";
            else if (radioButton7.Checked)
                ss[2] = "양면";
            else if (radioButton8.Checked)
                ss[2] = "재물";
            else if (radioButton9.Checked)
                ss[2] = "윤전";
            //
            ss[3] = jj[1];          //도큐싸이즈
            ss[4] = jj[2];          //종이/별지싸이즈
            ss[5] = jj[0];          //규격,비규격,종이
            ss[10] = jj[3];         //별지 절수
            ss[11] = jj[4];         //별지 국,46
            //
            if (black_id == "3" || black_id == "4")     //제로조건
            {
                ss[1] = "0";
                ss[2] = "재물";
                ss[8] = "c";   //
            }
            //
            if (prn_n == "01")   //마스타인쇄
            {
                if (m_db[52] == "1")  //재물 체크
                {
                    ss[6] = "01";
                    ss[7] = "1";        //재물
                }
                else
                {
                    ss[6] = "01";
                    ss[7] = "2";        //풀인쇄
                }
            }
            else if (prn_n == "02")  //디지탈인쇄
            {
                if (m_db[52] == "1")  //재물
                {
                    ss[6] = "02";
                    ss[7] = "1";
                }
                else if (m_db[52] == "1")  //풀
                {
                    ss[6] = "02";
                    ss[7] = "2";
                }
                else if (m_db[52] == "3")  //A4
                {
                    ss[6] = "02";
                    ss[7] = "3";
                }
                else
                {
                    ss[6] = "02";
                    ss[7] = "0";
                }
            }
            else if (prn_n == "03")  //인디고인쇄
            {
                if (m_db[52] == "1")  //
                {
                    ss[6] = "03";                  //재물
                    ss[7] = "1";
                }
                else                               //풀
                {
                    ss[6] = "03";
                    ss[7] = "2";
                }
            }
            else
            {
                ss[6] = prn_n;
                ss[7] = "";
            }
            x_bool = paper_select1(ss);       //책자형
            //
            return x_bool;
        }
        //-----------------------------------------------------------------------------------------
        private bool paper_select1(string[] xx) //xx=선택시 정보모음
        {
            Paper_mo sel_pp = new Paper_mo();
            // 
            string[] mm = new string[22];
            string[] pp = new string[15];  //보내는 배열정보
            string[] ss = new string[11];  //받는 배열정보
            string dsiz = "";              //책싸이즈
            //
            for (int n = 0; n < 15; n++)
            {
                pp[n] = string.Empty;
            }
            //
            for (int n = 0; n < 11; n++)
            {
                ss[n] = string.Empty;
            }
            //
            dsiz = xx[3];     //책싸이즈
            //
            if (xx[5].Equals("규격"))
                pp[1] = "1";      //규격지
            else if (xx[5].Equals("비규격"))
                pp[1] = "2";      //선택종이(별지)
            else if (xx[5].Equals("2")) //2번 버튼에서 호출
                pp[1] = "3";      
            else if (xx[5].Equals("3")) //3번 버튼에서 호출
                pp[1] = "4";
            else if (xx[5].Equals("4")) //3번버튼 앞서 호출하는 과정
                pp[1] = "5";
            else if (xx[5].Equals("5")) //3번버튼 앞서 호출하는 과정
                pp[1] = "6";
            else if (xx[5].Equals("6")) //3번버튼 앞서 호출하는 과정
                pp[1] = "7";
            else
                pp[1] = "";       //미정의      
            //
            pp[2] = dsiz;         //c-size(책싸이즈)
            //
            pp[3] = xx[1];        //닷찌  
            //
            pp[4] = xx[0];        //책자형 등
            //
            pp[5] = xx[2];        //구와이(일반 등)
            //
            pp[6] = jebon_n;      //제본방식코드번호
            //
            pp[7] = xx[10];        //비규격 I절수
            pp[8] = xx[11];        //국,46
            pp[9] = xx[4];         //별지종이싸이즈
            //
            pp[10] = m_db[3]     ; //쓰나기있음,없음
            pp[11] = xx[6];  //인쇄방식
            pp[12] = xx[7];  //체크값
            pp[13] = xx[8];  //책자형 중에서('a','b','c') 낱장형인 경우 == 'c'
            pp[14] = xx[9];  //닷찌인쇄 및 1091*788 제외조건 
            //
            string jul_su = "";
            string p_size = "";
            int s = 3;
            //
            if (black_id == "3" || black_id == "4")  //제로 비규격조건일때
                pp[11] = "제로";
            // 
            if (pp[4] == "책자형")    //책자형 =========================================시작
            {
                if (black_id == "1" || black_id == "2" || black_id == "3" || black_id == "4")  //
                {
                    if (this.checkBox1.Checked == true)  //테이블 보기 체크
                        mm = sel_pp.sel_paper(pp, true);      //최종표시 있음
                    else
                        mm = sel_pp.sel_paper(pp, false);     //최종표시 없음
                    //
                }
                else
                {
                    if (checkBox4.Checked == false)         //닷찌 고정형이 아니라면 자동 닷찌계산
                    {
                        pp[3] = "3";                        //닷찌값 설정
                        mm = sel_pp.sel_paper(pp, false);   //최종표시 없음
                        jul_su = mm[0];                     //절수
                        p_size = mm[14] + "*" + mm[15];     //선택종이
                        //
                        for (int i = 4; i < 6; i++)
                        {
                            pp[3] = i.ToString();
                            pp[13] = xx[8];
                            mm = sel_pp.sel_paper(pp, false);     //최종표시 없음
                            if (jul_su == mm[0] && p_size == mm[14] + "*" + mm[15])
                            {
                                s = i;
                                continue;
                            }
                            else
                                break;
                        }
                        pp[3] = s.ToString();
                        pp[13] = xx[8];
                        if (this.checkBox1.Checked == true)
                            mm = sel_pp.sel_paper(pp, true);      //최종표시 있음
                        else
                            mm = sel_pp.sel_paper(pp, false);     //최종표시 없음
                        //
                        pp[3] = s.ToString();
                        pp[13] = xx[8];

                        if (pp[3] == "3")
                            radioButton2.Checked = true;
                        else if (pp[3] == "4")
                            radioButton15.Checked = true;
                        else if (pp[3] == "5")
                            radioButton3.Checked = true;
                    }
                    else
                    {
                        if (this.checkBox1.Checked == true)
                            mm = sel_pp.sel_paper(pp, true);      //최종표시 있음
                        else
                            mm = sel_pp.sel_paper(pp, false);     //최종표시 없음
                    }
                }
            }
            //
            //최종 자료 입력하기
            if (!mm[0].Equals(""))
            {
                if (black_id == "1")         // 종이싸이즈 구할시 1번째
                {
                    textBox11.Text = mm[3];  //국,46
                    textBox12.Text = mm[0];  //절수
                    textBox8.Text = mm[1] + "*" + mm[2];  //인쇄 싸이즈
                    textBox13.Text = mm[3];  //국,46
                    textBox14.Text = mm[17]; //절수
                    return true;
                }
                else if (black_id == "2")    //종이싸이즈 구할시 2번째
                {
                    textBox13.Text = mm[3];  //국,46
                    textBox14.Text = mm[18]; //실절수
                    return true;
                }
                else if (black_id == "3")    //종이결만 확인
                {
                    textBox5.Text = mm[16];  //종,횡목 조건
                    return true;
                }
                else if (black_id == "4")    //3번 버튼에서 호출됨
                {
                    textBox11.Text = mm[3];  //국,46
                    textBox12.Text = mm[0];  //절수
                    return true;
                }
                else           //0번 조건
                {
                    mast_bungae_no = mm[21];         //블랙박스 돌때마다 절테이블 검색했어면 C_sel_jul 의 row_id  
                    //최종 화면에 자료 채우기
                    string[] temp1 = new string[3];
                    textBox2.Text = mm[3];  //국,46
                    textBox3.Text = mm[0];  //절수
                    textBox4.Text = mm[4];  //상,좌
                    textBox5.Text = "";     //종,횡(가공전)
                    textBox6.Text = mm[1] + "*" + mm[2];  //인쇄 싸이즈
                    textBox16.Text = mm[16]; //종,횡
                    textBox11.Text = mm[3];  //국,46
                    // 
                    textBox12.Text = mm[17]; //종이절수
                    //
                    string temp = textBox1.Text.Trim();  //(책자형)책싸이즈 가로, 세로 구함
                    //
                    string[] axx = temp.Split(new char[1] { '*' });
                    Double f_su = Convert.ToDouble(axx[0]); //책싸이즈의 앞수
                    Double r_su = Convert.ToDouble(axx[1]); //책싸이즈의 뒷수
                    //
                }
            }
            else
            {
                if (message_id == "1")
                    MessageBox.Show("접지 가능 범위를 초과 하였습니다." + "\r\n" + "다시 입력해 주세요.[01_1]");
                else if (message_id == "2")
                    MessageBox.Show("인쇄 가능 범위를 초과 하였습니다." + "\r\n" + "다시 입력해 주세요.[02_1]");
                else if (message_id == "3")
                    MessageBox.Show("해당 종이는 사용 할 수가 없습니다." + "\r\n" + "다시 입력해 주세요.[03_1]");
                //
                return false;
            }
            //
            //종합자료 담기  ==============================
            int xno1 = 0; //p_dt row 번호 담을 변수
            int xno2 = 0; //선택된 xd row 번호 담을 변수
            //
            if (checkBox2.Checked == true)  //딧찌 고정 체크
                m_db[5] = "1";              //
            else
                m_db[5] = "0";              //
            //
            m_db[8] = pp[3].Trim();      //닷찌
            m_db[9] = pp[5].Trim();      //구와이
            m_db[10] = textBox1.Text.Trim(); // pp[2].Trim();     //도큐싸이즈
            m_db[11] = textBox2.Text.Trim(); // sel_pp.a_xno[3].Trim(); //국,46
            m_db[12] = textBox3.Text.Trim(); // sel_pp.a_xno[0].Trim(); //절수
            m_db[13] = textBox4.Text.Trim(); // sel_pp.a_xno[4].Trim(); //상,좌
            //
            m_db[14] = textBox16.Text.Trim(); // sel_pp.a_xno[5].Trim(); //인쇄 종,횡목
            m_db[15] = textBox6.Text.Trim();  // sel_pp.a_xno[1].Trim() + "*" + sel_pp.a_xno[2].Trim(); //인쇄싸이즈
            m_db[16] = textBox11.Text.Trim(); //인쇄싸이즈 국/46
            m_db[17] = textBox12.Text.Trim(); //인쇄싸이즈 절수
            //
            m_db[18] = textBox8.Text.Trim();  //종이 싸이즈
            m_db[19] = textBox13.Text.Trim(); //종이 국/46
            m_db[20] = textBox14.Text.Trim(); //종이 절수
            m_db[30] = textBox5.Text.Trim();  //종이 종,횡목
            //            
            if (!sel_pp.a_xno[11].Equals(""))
                xno1 = Convert.ToInt32(sel_pp.a_xno[11]); //선택된 p_dt row 번호
            else
                xno1 = 0;
            if (!sel_pp.a_xno[12].Equals(""))
                xno2 = Convert.ToInt32(sel_pp.a_xno[12]); //선택된 xd row 번호
            else
                xno2 = 0;
            //
            if (xno1 != 0)        //선택된 항목이 있다면
            {
                m_db[22] = sel_pp.p_dt.Rows[xno1]["j"].ToString().Trim();  //판걸이
                m_db[23] = sel_pp.p_dt.Rows[xno1]["l"].ToString().Trim();  //판걸이 번호
                if (m_db[54].Contains("8"))
                {
                    m_db[32] = sel_pp.p_dt.Rows[xno1]["ju_jubji_11"].ToString().Trim();   //접지1
                    m_db[33] = sel_pp.p_dt.Rows[xno1]["ju_jubji_12"].ToString().Trim();  //접지2
                }
                else             //나머지는 무선제본
                {
                    m_db[32] = sel_pp.p_dt.Rows[xno1]["mu_jubji_11"].ToString().Trim();   //접지1
                    m_db[33] = sel_pp.p_dt.Rows[xno1]["mu_jubji_12"].ToString().Trim();  //접지2
                }
                //
                m_db[34] = sel_pp.p_dt.Rows[xno1]["da1"].ToString().Trim();    //닷찌(인쇄)
                m_db[35] = sel_pp.p_dt.Rows[xno1]["d_size"].ToString().Trim(); //닷찌(싸이즈)
                m_db[36] = sel_pp.p_dt.Rows[xno1]["m_julsu"].ToString().Trim();//닷찌(절수)
            }
            else                 //없다면
            {
                m_db[22] = "1";  //판걸이
                m_db[23] = "";   //판걸이 번호
                m_db[32] = "";   //접지1
                m_db[33] = "";   //접지2
                m_db[34] = "";   //닷찌(인쇄)
                m_db[35] = "";   //닷찌(싸이즈)
                m_db[36] = "";   //닷찌(절수)
            }
            if (xno2 != 0)
            {
                m_db[6] = Convert.ToString(sel_pp.xd[xno2, 16] + sel_pp.xd[xno2, 17]);  //추가수
                //
                if (m_db[0] == "책자형" && pp[13] == "a")
                {
                    m_db[37] = Convert.ToString(sel_pp.xd[xno2, 19]);  //가로갯수
                    m_db[43] = Convert.ToString(sel_pp.xd[xno2, 20]);  //세로갯수
                }
                else  //나머지 모두
                {
                    m_db[37] = Convert.ToString((int)Math.Floor(sel_pp.xd[xno2, 7]));  //가로갯수
                    m_db[43] = Convert.ToString((int)Math.Floor(sel_pp.xd[xno2, 8]));  //세로갯수
                }
                //
                if (sel_pp.xd[xno2, 11] == 1)
                {
                    m_db[40] = "가로";  //가로도지
                    m_db[46] = "";      //세로도지
                }
                else
                {
                    m_db[40] = "";      //가로도지
                    m_db[46] = "세로";  //세로도지
                }
                //
            }
            else
            {
                m_db[6] = "";   //추가수
                m_db[37] = "";  //가로갯수
                m_db[43] = "";  //세로갯수
                m_db[40] = "";  //가로도지
                m_db[46] = "";  //세로도지
            }
            //
            if (pp[1].Equals("1"))   //1=규격지,2=별지
                m_db[21] = "규격";   //
            else
                m_db[21] = "비규격"; //
            //
            if (m_db[34].Equals(""))
                m_db[34] = mm[13];   //닷찌 결과 표시
            // 
            if (m_db[34] != "" && (mm[14] == "1067" || mm[14] == "1091") && prn_n != "05")  //윤전인쇄가 아니라면   //닷찌인쇄 체크하는 과정
            {
                if (radioButton14.Checked == false)  //No 체크가 아니라면
                {
                    checkBox6.Checked = true;       //닷찌검색
                    radioButton13.Checked = true;    //Yes 체크
                }
                else                                //No 체크라면 
                {
                    checkBox6.Checked = false;      //닷찌검색 
                    radioButton13.Checked = false;   //Yes 체크
                }

            }
            else
            {
                if (prn_n != "05")    //윤전인쇄가 아니라면
                {
                    checkBox6.Checked = false;
                    radioButton13.Checked = false;
                }
            }                     //윤전인쇄인 경우 아무것도 안한다 
            //  
            string[] d_size = m_db[15].Split(new char[1] { '*' });
            int s1 = Convert.ToInt32(d_size[0]);
            int s2 = Convert.ToInt32(d_size[1]);
            if (s1 < s2)
            {
                int temp = s1;
                s1 = s2;
                s2 = temp;
            }
            Form_hari fm = new Form_hari(m_db, joo_id);
            fm.hari_sel(true);
            //
            m_db[38] = fm.dataGridView1.Rows[0].Cells[4].Value.ToString().Trim();  //가로여분-1
            m_db[39] = fm.dataGridView1.Rows[0].Cells[6].Value.ToString().Trim();  //가로여분-2
            m_db[41] = fm.dataGridView1.Rows[0].Cells[5].Value.ToString().Trim();  //가로간격
            m_db[42] = fm.dataGridView1.Rows[0].Cells[2].Value.ToString().Trim();  //가로닷찌
            m_db[44] = fm.dataGridView1.Rows[1].Cells[4].Value.ToString().Trim();  //세로여분-1
            m_db[45] = fm.dataGridView1.Rows[1].Cells[6].Value.ToString().Trim();  //세로여분-2
            m_db[47] = fm.dataGridView1.Rows[1].Cells[5].Value.ToString().Trim();  //세로간격
            m_db[48] = fm.dataGridView1.Rows[1].Cells[2].Value.ToString().Trim();  //세로닷찌
            //
            if (!sel_pp.p_dt.Rows[xno1]["jarak"].ToString().Equals(""))
            {
                decimal ja = Convert.ToDecimal(sel_pp.p_dt.Rows[xno1]["jarak"].ToString().Trim()); //자락
                decimal ja1 = Convert.ToDecimal(m_db[38]);  //여분1
                decimal ja2 = Convert.ToDecimal(m_db[39]);  //여분2
                if (m_db[54].Equals("8"))  //중철접지
                {
                    if (ja1 + ja2 < ja)      //중철접지 불가하므로 무선접지 방법으로 교체 
                    {
                        m_db[32] = sel_pp.p_dt.Rows[xno1]["mu_jubji_11"].ToString().Trim();   //접지1
                        m_db[33] = sel_pp.p_dt.Rows[xno1]["mu_jubji_12"].ToString().Trim();  //접지2
                    }
                    else
                    {
                        m_db[38] = (ja1 + ja2 - ja).ToString();  //가로여분-1
                        m_db[39] = ja.ToString();                //가로여분-2
                    }
                }
            }
            return true;
        }
        //

        private void button1_Click(object sender, EventArgs e)  //저장
        {
            if (checkBox2.Checked == true && call_id == "1")
            {
                MessageBox.Show("수정 할 수가 없습니다.");
                return;
            }
            //
            if (call_id == "1")
            {
                if (dataGridView1.Rows.Count == 0)
                {
                    MessageBox.Show("저장할 자료가 맞지 않습니다");
                    return;
                }
                m_db[37] = dataGridView1.Rows[0].Cells[3].Value.ToString().Trim();//가로갯수
                m_db[38] = dataGridView1.Rows[0].Cells[4].Value.ToString().Trim();//가로여분-1
                m_db[39] = dataGridView1.Rows[0].Cells[6].Value.ToString().Trim();//가로여분-2
                m_db[43] = dataGridView1.Rows[1].Cells[3].Value.ToString().Trim();//세로갯수
                m_db[44] = dataGridView1.Rows[1].Cells[4].Value.ToString().Trim();//세로여분-1
                m_db[45] = dataGridView1.Rows[1].Cells[6].Value.ToString().Trim();//세로여분-2
                m_db[12] = textBox3.Text.Trim();//절수
                //
                if (checkBox4.Checked == true)  //닷찌 자동화 여부
                    m_db[5] = "1";
                else
                    m_db[5] = "0";
                //
                string tem3 = "";  //닷찌인쇄 관련 정보 저장
                if (checkBox6.Checked == true)
                    tem3 = "1";
                else
                    tem3 = "0";
                //
                if (radioButton13.Checked == true)
                    tem3 += "1";
                else if (radioButton14.Checked == true)
                    tem3 += "2";
                else
                    tem3 += "0";
                //
                if (checkBox5.Checked == true)
                    tem3 += "1";
                else
                    tem3 += "0";
                //
                m_db[49] = tem3;  //
                //
                string md0 = m_db[10]; //도큐싸이즈
                string md1 = m_db[17]; //I-절수
                string md2 = m_db[11]; //C-국,46
                string md3 = m_db[12]; //C-절수
                // 
                if (paper_id == true)
                {
                    if ((m_db[15] != prn_size) || (m_db[18] != paper_size))  //종이,인쇄 싸이즈가 다르면
                        m_db[31] = "";  //기계정보
                }
                //  
                string mdb = "";
                for (int i = 0; i < 60; i++)
                {
                    mdb += m_db[i].Trim() + "#";
                }
                mdb = mdb.Substring(0, mdb.Length - 1);
                //
                string temp = "";
                if ((m_db[15] == "1091*788" || m_db[15] == "788*1091") && m_db[49].Substring(1, 1) == "1") //인쇄싸이즈가 1091*788 이고 Y 이면 닷찌 
                    temp = "[닷찌]";
                else if ((m_db[15] == "1091*788" || m_db[15] == "788*1091") && m_db[49].Substring(1, 1) == "2") //인쇄싸이즈가 1091*788 이고 N 이면 전지
                    temp = "[전지]";
                else
                    temp = "";
                //
                var DBConn = new MySqlConnection(Config.DB_con2);
                DBConn.Open();
                string cQuery = "";
                if (((m_db[15] == prn_size) && (m_db[18] == paper_size)) || paper_id == false)  //종이,인쇄 동일하다면
                {
                    if (joo_id == "1")   //견적=1,주문=2,매크로=3 
                    {
                        cQuery = "update L_bungae1 set m_dat='" + mdb + "',i_jul1='" + md1 + "',kook='" + md2 + "',c_jul2='" + md3 + "'";
                        cQuery += ",c_size='" + md0 + "',hang_s='" + temp + "'";
                        cQuery += ",bungae_id='" + mast_bungae_no + "'";
                        cQuery += " where row_id='" + row_n + "'";
                    }
                    else if (joo_id == "2")   //견적=1,주문=2
                    {
                        cQuery = "update L_bungae2 set m_dat='" + mdb + "',i_jul1='" + md1 + "',kook='" + md2 + "',c_jul2='" + md3 + "'";
                        cQuery += ",c_size='" + md0 + "',hang_s='" + temp + "'";
                        cQuery += ",bungae_id='" + mast_bungae_no + "'";
                        cQuery += " where row_id='" + row_n + "'";
                    }
                    else if (joo_id == "3")   //견적=1,주문=2
                    {
                        cQuery = "update L_bungae_macro set m_dat='" + mdb + "',i_jul1='" + md1 + "',kook='" + md2 + "',c_jul2='" + md3 + "'";
                        cQuery += ",c_size='" + md0 + "',hang_s='" + temp + "'";
                        cQuery += ",bungae_id='" + mast_bungae_no + "'";
                        cQuery += " where row_id='" + row_n + "'";
                    }
                    else
                        cQuery = "";
                }
                else                         //상이하면
                {
                    MessageBox.Show("종이의 판형과 하리꼬미 판형이 일치하지 않아 종이는 초기화 됩니다." + "\r\n" + " 확인후 진행해 주세요.");
                    if (joo_id == "1")   //견적=1,주문=2,3=매크로 
                    {
                        cQuery = "update L_bungae1 set m_dat='" + mdb + "',i_jul1='" + md1 + "',kook='" + md2 + "',c_jul2='" + md3 + "'";
                        cQuery += ",c_size='" + md0 + "',t_paperm='',bigo='',j_comp='',rank=''";
                        cQuery += ",bungae_id='" + mast_bungae_no + "'";
                        cQuery += ",weight='',thick='',hang_s='" + temp + "',p_com='' where row_id='" + row_n + "'";
                    }
                    else if (joo_id == "2")
                    {
                        cQuery = "update L_bungae2 set m_dat='" + mdb + "',i_jul1='" + md1 + "',kook='" + md2 + "',c_jul2='" + md3 + "'";
                        cQuery += ",c_size='" + md0 + "',t_paperm='',bigo='',j_comp='',rank=''";
                        cQuery += ",bungae_id='" + mast_bungae_no + "'";
                        cQuery += ",weight='',thick='',hang_s='" + temp + "',p_com='' where row_id='" + row_n + "'";
                    }
                    else if (joo_id == "3")
                    {
                        cQuery = "update L_bungae_macro set m_dat='" + mdb + "',i_jul1='" + md1 + "',kook='" + md2 + "',c_jul2='" + md3 + "'";
                        cQuery += ",c_size='" + md0 + "',t_paperm='',bigo='',j_comp='',rank=''";
                        cQuery += ",bungae_id='" + mast_bungae_no + "'";
                        cQuery += ",weight='',thick='',hang_s='" + temp + "',p_com='' where row_id='" + row_n + "'";
                    }
                    else
                        cQuery = "";

                }
                if(cQuery != "")
                {
                    var cmd = new MySqlCommand(cQuery, DBConn);
                    if (cmd.ExecuteNonQuery() == 0)
                        MessageBox.Show("DB 서버 오류 입니다.");
                    else
                    {
                        hang_s = temp;
                        this.DialogResult = DialogResult.OK;
                        MessageBox.Show("저장 하였습니다.");
                    }                    
                }
                DBConn.Close();
            }
            else       //자동화창에서 접지방법 및 인쇄모형만 저장
            {
                //접지방법
                if(textBox7.Text != m_db[32])
                {
                    m_db[32] =  textBox7.Text.Trim();  //접지1
                    m_db[33] =  textBox10.Text.Trim(); //접지2
                }
                string mdb = "";
                for (int i = 0; i < 60; i++)
                {
                    mdb += m_db[i].Trim() + "#";
                }
                mdb = mdb.Substring(0, mdb.Length - 1);
                //인쇄모형
                string f_prn = "";
                string s_prn = "";
                string ea_su = "";
                string w_won = "";
                if(c_prn_mode.Text != row_dat[5])  //인쇄유형이 수정되었다면(혼각계등)
                {
                    f_prn = c_prn_mode.Text.Trim();  //new
                    s_prn = row_dat[5];              //old 
                }
                else
                {
                    f_prn = row_dat[5];  //new
                    s_prn = row_dat[6];  //old 
                }
                //
                var DBCons = new MySqlConnection(Config.DB_con1);
                DBCons.Open();
                string cQuery = "";
                string table_n = "";
                if (joo_id == "1")   //견적=1,주문=2,
                    table_n = "C_auto1";
                else if (joo_id == "2")
                    table_n = "C_auto2";
                else if (joo_id == "3")
                    table_n = "C_auto_macro";
                else
                    table_n = "";
                //
                if (table_n != "")
                {
                    cQuery = "update " + table_n + " set m_dat='" + mdb + "',jubji1='" + m_db[32] + "',jubji2='" + m_db[33] + "'";
                    cQuery += ",prn_model='" + f_prn + "',w_prn_model='" + s_prn + "'";
                    cQuery += " where row_id='" + row_n + "'";
                    //
                    var cmd = new MySqlCommand(cQuery, DBCons);
                    if (cmd.ExecuteNonQuery() == 0)
                        MessageBox.Show("DB 서버 오류 입니다.");
                    else
                    {
                        int kk = 0;
                        int nn = 0;
                        string prn_no = "";
                        for (int i = 1; i < grid.Rows.Count; i++)
                        {
                            if (grid[i, 0].ToString() == row_dat[0])
                            {
                                prn_no = grid[i, 42].ToString();
                                kk = i;
                                break;
                            }
                        }
                        //
                        for (int i = 1; i < grid.Rows.Count; i++)
                        {
                            if (grid[i, 42].ToString() == prn_no && (grid[i, 48].ToString() == "2" || grid[i, 48].ToString() == "3"))
                            {
                                nn = i;
                                break;
                            }
                        }
                        //
                        if (nn != 0)
                        {
                            int[] xx = get_multi.total_d_s(grid[nn, 9].ToString(), grid[nn, 10].ToString());
                            if (f_prn.Contains("돈땡"))
                                ea_su = ((xx[0] + xx[1]) / 2).ToString();
                            else
                                ea_su = (xx[0] + xx[1]).ToString();
                            //
                            w_won = (Convert.ToDouble(grid[nn, 24].ToString()) * Convert.ToDouble(ea_su) * Convert.ToDouble(grid[nn, 17].ToString())).ToString();  //단가*수량*대수 = 총액
                        }
                        //
                        cQuery = "update " + table_n + " set total_su='" + ea_su + "',won_2='" + w_won + "',prn_model='" + f_prn + "'";   //ctp,필림,소부 --> 수량/총액 수정
                        cQuery += " where prn_id='" + prn_no + "' and (set_no='2' or set_no='3')";
                        cmd = new MySqlCommand(cQuery, DBCons);
                        cmd.ExecuteNonQuery();
                        // 
                        this.DialogResult = DialogResult.OK;
                        MessageBox.Show("저장 하였습니다.");
                    }
                }
                DBCons.Close();
            }
        }
        //
        //
        private void button9_Click(object sender, EventArgs e) //접지창 열기
        {
            DataGridView dgv1 = new DataGridView();     //검색용 그리드
            Listview_no fm = new Listview_no(textBox7, 0);
            DataTable m_dt = new DataTable();           //검색용 테이블

            dgv1 = fm.dataGridView1;
            //
            fm.Text = "■ 접지방식 선택";
            fm.Size = new Size(184, 188); //좌우,위,아래

            m_dt.Clear();
            m_dt.TableName = "Form1";

            if (m_dt.Columns.Count == 0)
            {
                m_dt.Columns.Add("접지방법1");
                m_dt.Columns.Add("접지방법2");
            }
            //
            m_dt.Rows.Add(new string[] { "16+16+8+1", "16+16+8+1" });
            m_dt.Rows.Add(new string[] { "16+16+8+2", "16+16+8+2" });
            m_dt.Rows.Add(new string[] { "16+16+8+3", "16+16+8+3" });
            m_dt.Rows.Add(new string[] { "16+16+8+4", "16+16+8+4" });
            m_dt.Rows.Add(new string[] { "16+16+8+5", "16+16+8+5" });
            m_dt.Rows.Add(new string[] { "16+16+8+6", "16+16+8+6" });

            dgv1.DataSource = m_dt;
            //
            dgv1.Columns[0].Width = 90;
            dgv1.Columns[1].Width = 90;

            //           
            dgv1.Rows[dgv1.CurrentCell.RowIndex].Selected = false;
            fm.ShowDialog();
        }

        private void c_click(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridView2.RowCount != 0)
            {
                if (e.ColumnIndex == 3)
                {
                    string pic = dataGridView2.Rows[dataGridView2.CurrentRow.Index].Cells[2].Value.ToString().Trim();
                    if (!pic.Equals(""))
                    {
                        ShellExecute(0, String.Empty, ".\\picture\\" + pic + ".jpg", String.Empty, String.Empty, 1);
                    }
                }
            }
        }
        //
        private void checkBox2_CheckedChanged(object sender, EventArgs e)  //  수정불가 체크시
        {
            if (checkBox2.Checked == true)
            {
                dataGridView1.Enabled = false;
            }
            else
            {
                dataGridView1.Enabled = true;
            }
        }

        private void dataGridView1_CellLeave(object sender, DataGridViewCellEventArgs e)
        {
            dataGridView1.Rows[dataGridView1.CurrentCell.RowIndex].Selected = false;
        }

        private void dataGridView2_CellLeave(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridView2.SelectedRows != null)
                dataGridView2.Rows[dataGridView2.CurrentCell.RowIndex].Selected = false;

        }

        private void Form_hari_FormClosed(object sender, FormClosedEventArgs e)  //나중에 확인
        {
            string dat = "";
            var DBConn = new MySqlConnection(Config.DB_con2);
            DBConn.Open();
            var DBCons = new MySqlConnection(Config.DB_con1);
            DBCons.Open();
            string cQuery = "";
            //
            if (call_id == "1")
            {
                if (h_id == false)
                {
                    if (checkBox2.Checked == true)
                        dat = "1";
                    else
                        dat = "0";
                    //
                    bk_ids = dat;
                    if (joo_id == "1")   //견적=1,주문=2 
                        cQuery = "update L_bungae1 set bk_id='" + dat + "' where row_id='" + row_n + "'";
                    else if (joo_id == "2")
                        cQuery = "update L_bungae2 set bk_id='" + dat + "' where row_id='" + row_n + "'";
                    else if (joo_id == "3")
                        cQuery = "update L_bungae_macro set bk_id='" + dat + "' where row_id='" + row_n + "'";
                    else
                        cQuery = "";
                    //
                    if (cQuery != "")
                    {
                        var cmd = new MySqlCommand(cQuery, DBConn);
                        cmd.ExecuteNonQuery();
                    }
                }
            }
            else if (call_id == "2")
            {
                if (h_id == false)
                {
                    if (checkBox2.Checked == true)
                        dat = "1";
                    else
                        dat = "0";
                    //
                    if (joo_id == "1")   //견적=1,주문=2 
                        cQuery = "update C_auto1 set bk_id='" + dat + "' where row_id='" + row_n + "'";
                    else if (joo_id == "2")
                        cQuery = "update C_auto2 set bk_id='" + dat + "' where row_id='" + row_n + "'";
                    else if (joo_id == "3")
                        cQuery = "update C_auto_macro set bk_id='" + dat + "' where row_id='" + row_n + "'";
                    else
                        cQuery = "";
                    //
                    if (cQuery != "")
                    {
                        var cmd = new MySqlCommand(cQuery, DBCons);
                        cmd.ExecuteNonQuery();
                    }
                }
            }
            DBConn.Close();
            DBCons.Close();
        }

        private void xx1(object sender, EventArgs e)  //주문 내용 수정시 텍스트 박스 초기화 
        {
            textBox2.Text = "";  //도큐 국/46
            textBox3.Text = "";  //도큐 절수
            textBox4.Text = "";  //도큐 상좌

            textBox11.Text = "";  //인쇄 국/46
            textBox12.Text = "";  //인쇄 절수
            textBox16.Text = "";  //인쇄 종,횡목

            textBox13.Text = "";  //종이 국/46
            textBox14.Text = "";  //종이 절수
            textBox5.Text = "";   //종이 종,횡목
            //
            textBox6.Text = "";   //인쇄싸이즈
            textBox8.Text = "";   //종이싸이즈
            //
            if (radioButton9.Checked == true)
                radioButton4.Checked = true;
            //
            dataGridView1.Rows.Clear();
            dataGridView2.Rows.Clear();
        }

        private void button7_Click(object sender, EventArgs e)  //하리도형 그리기
        {
            if (dataGridView1.Rows.Count == 0)
            {
                MessageBox.Show("하리 자료가 없습니다.");
                return;
            }
            //
            double ratio = (double)panel7.Height / (double)panel7.Width; //가로에서 세로로 갈때는 가로*비율,  세로에서 가로로 갈때는 세로/비율
            double std_n = 0;  //추가로 인해 기본감하는 박스 길이
            //
            double add_box = 0;//추가 박스수
            double dass = 0;   //닷찌 수치자료
            string abc = "";   //a,b,c형 a,b=a, b=b
            string doji = "";  //도지표시
            double add_su = 0; //a형에 더해지는 수
            //
            if (string.IsNullOrEmpty(textBox15.Text) || textBox15.Text.Equals("0")) //
            {
                add_box = 0;
                label11.Text = "";
            }
            else
            {
                add_box = Convert.ToDouble(textBox15.Text.Trim()); //추가 박스수
                //가로도큐싸이즈가 <= 세로여분-2 하다면 
                if (Convert.ToDouble(dataGridView1.Rows[0].Cells[1].Value.ToString()) <= Convert.ToDouble(dataGridView1.Rows[1].Cells[6].Value.ToString()))
                    label11.Text = "세로";
                else
                    label11.Text = "가로";
            }
            //
            if (dataGridView1.Rows[0].Cells[7].Value.Equals("※"))
                doji = "gg";  //가로표시 //닷찌가 위에 있다면
            else 
                doji = "ss";  //세로표시
            //
            abc = m_db[7];
            // 위에서 설정한 내용임
            Graphics p = Graphics.FromHwnd(panel7.Handle);
            if (g_lab != null)
            {
                for (int m = 0; m < g_lab.Length; m++)
                    panel7.Controls.Remove(g_lab[m]);
            }
            if (s_lab != null)
            {
                for (int m = 0; m < s_lab.Length; m++)
                    panel7.Controls.Remove(s_lab[m]);
            }
            p.FillRectangle(new SolidBrush(Color.FromArgb(240, 240, 240)), 0, 0, panel7.Width, panel7.Height);
            //  
            //
            string[] gui = new string[5];
            for (int s = 0; s < 5; s++)
                gui[s] = "";
            //
            string g_pz = dataGridView1.Rows[0].Cells[0].Value.ToString();  //종이 가로싸이즈
            string s_pz = dataGridView1.Rows[1].Cells[0].Value.ToString();  //종이 세로싸이즈
            //
            if (m_db[31] == "")
            {
                gui[0] = "";  //기계 구와이
                gui[1] = "";  //종이구와이
                gui[2] = "";  //판싸이즈
                gui[3] = "";  //cip(Y,N)
            }
            else
            {
                string[] tem1 = m_db[31].Split(new char[1] { '/' }); //하리자료(4항목)-> 기계구와이/종이구와이/판싸이즈/cip/슬래시 없는 도수
                string[] tem2 = new string[4];
                if (tem1[1] != "")  //종이 구와이가 공문자가 아니라면
                    tem2 = tem1[1].Split(new char[1] { '+' });  //종이 구와이의 구분 + 로 구분
                else
                    tem2[0] = "0";
                //
                gui[0] = tem1[0];                                    //기계 구와이
                gui[1] = (Convert.ToInt32(tem2[0]) * 2).ToString();  //종이구와이
                gui[2] = tem1[2]; //판싸이즈
                gui[3] = tem1[3]; //cip(Y,N)
            }
            //
            if (radioButton1.Checked == true)
                gui[4] = "1.5";           //닷찌
            else if (radioButton2.Checked == true)
                gui[4] = "3";           //닷찌
            else if (radioButton15.Checked == true)
                gui[4] = "4";           //닷찌
            else if (radioButton3.Checked == true)
                gui[4] = "5";           //닷찌
            else if (radioButton4.Checked == true)
                gui[4] = "0";           //닷찌
            else
                gui[4] = "0";           //닷찌
            //
            dass = Convert.ToDouble(gui[4]); //숫자형 닷찌로 전환
            double g_su = Convert.ToDouble(dataGridView1.Rows[0].Cells[3].Value.ToString());  //가로갯수
            double s_su = Convert.ToDouble(dataGridView1.Rows[1].Cells[3].Value.ToString());  //세로갯수 
            double g_tot = 0;      //가로사용 가능수 
            double s_tot = 0;      //세로사용 가능수
            double g_box = 0;      //박스 가로길이     
            double s_box = 0;      //박스 세로길이     
            double temp = 0;       //임시
            // 
            double dajj_n = 0;  //닷찌줄긋기 시작점
            if (checkBox6.Checked == true && radioButton13.Checked == true && (textBox6.Text == "1091*788" || textBox6.Text == "788*1091"))  //닷찌인쇄 체크되었을시
                dajj_n = g_su * 2 / 3;   
            //
            g_lab = new Label[(int)g_su + 1];
            double[] g_yub = new double[(int)g_su + 1];  //가로갯수
            for (int i = 0; i < (int)g_su + 1; i++)      //가로갯수대로 간격 설정하기
            {
                if (i == 0)
                    g_yub[i] = Convert.ToDouble(dataGridView1.Rows[0].Cells[4].Value.ToString()) + dass;  //가로여분1 //처음 간격
                else if (i == (int)g_su)
                    g_yub[i] = Convert.ToDouble(dataGridView1.Rows[0].Cells[6].Value.ToString()) + dass;  //가로여분2 //끝 간격
                else  //중간 간격
                {
                    if (abc == "a+3")
                    {
                        if (doji == "ss")  //도지가 세로이면
                        {
                            if (i % 2 == 0)  //짝수
                                g_yub[i] = Convert.ToDouble(gui[4]) * 2; //닷찌*2
                            else             //홀수
                                g_yub[i] = 6; //
                        }
                        else               //가로라면
                            g_yub[i] = Convert.ToDouble(gui[4]) * 2; //닷찌*2
                    }
                    else if (abc == "a")
                    {
                        if (doji == "ss")  //도지가 세로이면
                        {
                            if (i % 2 == 0)
                                g_yub[i] = Convert.ToDouble(gui[4]) * 2; //닷찌*2
                            else
                                g_yub[i] = 0; //
                        }
                        else
                            g_yub[i] = Convert.ToDouble(gui[4]) * 2; //닷찌*2
                    }
                    else if (abc == "b")
                    {
                        if (doji == "ss")  //도지가 세로이면
                        {
                            if (i % 2 == 0)
                                g_yub[i] = Convert.ToDouble(gui[4]) * 2; //닷찌*2
                            else
                                g_yub[i] = 0; //
                        }
                        else
                            g_yub[i] = Convert.ToDouble(gui[4]) * 2; //닷찌*2
                    }
                    else  //b,c,d
                        g_yub[i] = Convert.ToDouble(gui[4]) * 2;     //닷찌*2
                    //
                 }
                //
                if (g_yub[i] != 0)
                    temp += 10;
                //
            }
            g_tot = 410 - temp;  //가로 사용가능수
            //
            s_lab = new Label[(int)s_su + 1];
            double[] s_yub = new double[(int)s_su + 1];  //세로여분 
            temp = 0;
            for (int i = 0; i < (int)s_su + 1; i++)   //세로갯수대로 간격 설정하기
            {
                if (i == 0)
                    s_yub[i] = Convert.ToDouble(dataGridView1.Rows[1].Cells[6].Value.ToString()) + dass; //세로여분2  //처음 간격
                else if (i == (int)s_su) 
                    s_yub[i] = Convert.ToDouble(dataGridView1.Rows[1].Cells[4].Value.ToString()) + dass; //세로여분1  //끝 간격
                else   //중간 간격
                {
                    if (abc == "a+3")
                    {
                        if (doji == "gg")  //도지가 가로이면
                        {
                            if (i % 2 == 0)
                                s_yub[i] = Convert.ToDouble(gui[4]) * 2; //닷찌*2
                            else
                                s_yub[i] = 6; //
                        }
                        else
                            s_yub[i] = Convert.ToDouble(gui[4]) * 2; //닷찌*2
                     }
                    else if (abc == "a")
                    {
                        if (doji == "gg")  //도지가 가로이면
                        {
                            if (i % 2 == 0)
                                s_yub[i] = Convert.ToDouble(gui[4]) * 2; //닷찌*2
                            else
                                s_yub[i] = 0; //
                        }
                        else
                            s_yub[i] = Convert.ToDouble(gui[4]) * 2; //닷찌*2
                    }
                    else if (abc == "b")
                    {
                        if (doji == "gg")  //도지가 가로이면
                        {
                            if (i % 2 == 0)
                                s_yub[i] = Convert.ToDouble(gui[4]) * 2; //닷찌*2
                            else
                                s_yub[i] = 0; //
                        }
                        else
                            s_yub[i] = Convert.ToDouble(gui[4]) * 2; //닷찌*2
                    }
                    else
                        s_yub[i] = Convert.ToDouble(gui[4]) * 2; //닷찌*2
                //
                }
                if (s_yub[i] != 0)
                    temp += 10;
                //
            }
            s_tot = 340 - temp;   //세로 사용가능수
            //
            //double ratio = panel7.Height / panel7.Width; //가로에서 세로로 갈때는 가로*비율,  세로에서 가로로 갈때는 세로/비율
            if (add_box != 0)
            {
                if (label11.Text == "세로")  //밑으로 그리기
                {
                    g_box = g_tot / g_su;  //박스 가로길이
                    std_n = (g_box + 10) * ratio;  //감하는 길이
                    s_tot = s_tot - std_n;
                    s_box = s_tot / s_su;  //박스 세로길이
                }
                else
                {
                    s_box = s_tot / s_su;  //박스 세로길이
                    std_n = (s_box + 10) / ratio; //감하는 길이 
                    g_tot = g_tot - std_n;
                    g_box = g_tot / g_su;  //박스 가로길이
                }
            }
            else
            {
                g_box = g_tot / g_su;  //박스 가로길이
                s_box = s_tot / s_su;  //박스 세로길이
            }
            //
            Brush b = new SolidBrush(this.ForeColor);
            Brush t = new SolidBrush(Color.White);
            Pen m_Pen = new Pen(Color.Black, 1);
            Pen m_Pen1 = new Pen(Color.Red, 1);
            p.DrawLine(m_Pen, 70, 70, 480, 70);  //좌우긴선(좌우,위아래)
            p.DrawLine(m_Pen, 70, 60, 70, 80);   //앞작은선
            p.DrawLine(m_Pen, 480, 60, 480, 80); //뒤작은선
            p.DrawLine(m_Pen, 70, 70, 76, 64);   //앞화살표위
            p.DrawLine(m_Pen, 70, 70, 76, 76);   //앞화살표아래
            p.DrawLine(m_Pen, 480, 70, 474, 64); //앞화살표위
            p.DrawLine(m_Pen, 480, 70, 474, 76); //앞화살표아래
            //
            p.DrawLine(m_Pen, 30, 120, 30, 460);   //좌우,위아래
            p.DrawLine(m_Pen, 20, 120, 40, 120);   //좌우,위아래
            p.DrawLine(m_Pen, 20, 460, 40, 460);   //좌우,위아래
            p.DrawLine(m_Pen, 30, 120, 24, 130);   //앞화살표아래
            p.DrawLine(m_Pen, 30, 120, 36, 130);   //앞화살표아래
            p.DrawLine(m_Pen, 30, 460, 24, 450);   //앞화살표아래
            p.DrawLine(m_Pen, 30, 460, 36, 450);   //앞화살표아래
            Rectangle rectangle1 = new Rectangle(70, 120, 410, 340);  //좌,우 시작점/위,아래 시작점/좌,우 길이/위,아래 길이
            p.FillRectangle(t, rectangle1);
            p.DrawRectangle(Pens.Black, rectangle1);
            //
            double g_pos = 70;
            double s_pos = 120;
            //
            int g_start = 0; //닷찌 줄 긋기 시작점
            for (int i = 0; i < (int)s_su; i++)
            {
                if (s_yub[i] != 0)
                    s_pos += 10;
                //
                g_pos = 70.9;
                int x_pos = 0;
                int old_pos = 0;
                for (int m = 0; m < (int)g_su; m++)
                {
                    if (g_yub[m] != 0)
                        g_pos += 10;
                    //
                    x_pos = (int)Math.Floor(g_pos);
                    if (old_pos == x_pos)
                        x_pos += 1;
                    //
                    Rectangle rectanglex = new Rectangle(x_pos, (int)s_pos, (int)g_box, (int)s_box);  //계산추가요
                    p.DrawRectangle(Pens.SlateBlue, rectanglex);
                    //
                    g_pos += g_box;
                    old_pos = x_pos + (int)g_box;
                    if (m == (int)dajj_n - 1)
                        g_start = (int)g_pos + 5;
                }
                s_pos += s_box+1;
            }
            if (dajj_n != 0)
            {
                p.DrawLine(m_Pen1, g_start, 120, g_start, 460);   //좌우,위아래
            }
            //
            if (gui[4] == "0")
                g_pos = 56;
            else
                g_pos = 52;
            //
            for (int m = 0; m < (int)g_su + 1; m++)
            {
                g_lab[m] = new Label();
                g_lab[m].Top = 96;
                if (g_yub[m] == 0)
                    g_lab[m].Text = (add_su * 2).ToString();
                else
                    g_lab[m].Text = g_yub[m].ToString();
                //
                g_lab[m].Size = new System.Drawing.Size(30, 18);
                g_lab[m].TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
                g_lab[m].BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;

                if (g_yub[m] != 0)
                    g_pos += 10;
                //
                if (m == 0)
                    g_lab[m].Left = 70;
                else if (m == (int)g_su)
                    g_lab[m].Left = 452;
                else
                    if (g_yub[m] == 0)
                        g_lab[m].Left = (int)g_pos+3;
                    else
                        g_lab[m].Left = (int)g_pos;
                //    
                panel7.Controls.Add(g_lab[m]);
                g_pos += g_box;
            }
            //
            if (gui[4] == "0")
                s_pos = 110;
            else
                s_pos = 107;
            //
            for (int m = 0; m < (int)s_su + 1; m++)
            {
                s_lab[m] = new Label();
                s_lab[m].Left = 39;
                //
                if (s_yub[m] == 0)
                    s_lab[m].Text = (add_su * 2).ToString();
                else
                    s_lab[m].Text = s_yub[m].ToString();
                //
                s_lab[m].Size = new System.Drawing.Size(30, 18);
                s_lab[m].TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
                s_lab[m].BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;

                if (s_yub[m] != 0)
                    s_pos += 10;
                //
                if (m == 0)
                    s_lab[m].Top = 120;
                else if (m == (int)s_su)
                    s_lab[m].Top = 444;
                else
                    if (s_yub[m] == 0)
                        s_lab[m].Top = (int)s_pos + 5;
                    else
                        s_lab[m].Top = (int)s_pos;
                //    
                panel7.Controls.Add(s_lab[m]);
                s_pos += s_box;
            }
            //=============================
            //double ratio = panel7.Height / panel7.Width; //가로에서 세로로 갈때는 가로*비율,  세로에서 가로로 갈때는 세로/비율
            if (add_box != 0)  //추가 박스 그리기
            {
                if (label11.Text == "세로")    //밑으로 그리기
                {
                    g_pos = 80.9;
                    s_pos = s_pos - s_box + 10;
                    for (int m = 0; m < add_box; m++)
                    {
                        Rectangle rectanglex = new Rectangle((int)g_pos, (int)s_pos, (int)(s_box / ratio), (int)(g_box * ratio));  //계산추가요
                        p.DrawRectangle(Pens.SlateBlue, rectanglex);
                        //
                        g_pos += (s_box + 10) / ratio;
                    }
                }
                else
                {
                    s_pos = 130;
                    g_pos = g_pos - g_box + 16;
                    for (int m = 0; m < add_box; m++)
                    {
                        Rectangle rectanglex = new Rectangle((int)g_pos, (int)s_pos, (int)(s_box / ratio), (int)(g_box * ratio));  //계산추가요
                        //Rectangle rectanglex = new Rectangle((int)g_pos, (int)s_pos, (int)(g_box), (int)(s_box));  //계산추가요
                        p.DrawRectangle(Pens.SlateBlue, rectanglex);
                        //
                        s_pos += (g_box + 10) * ratio;
                    }
                }
            }
            //
            Font s_font = new Font("굴림체", 9, FontStyle.Regular);
            Font m_font = new Font("굴림체", 9, FontStyle.Underline);
            //
            p.DrawString("종이싸이즈 : " + g_pz + " ㎜", s_font, b, 210, 50);
            p.DrawString("기계G : " + gui[0] + " ㎜", m_font, b, 70, 500);  //좌우,위아래
            p.DrawString("종이G : " + gui[1] + " ㎜", m_font, b, 240, 500);  //좌우,위아래
            p.DrawString("닷찌 : " + gui[4] + " ㎜", m_font, b, 404, 500);   //좌우,위아래
            p.DrawString("판싸이즈 : " + gui[2] + " ㎜", m_font, b, 70, 534);   //좌우,위아래
            p.DrawString("CIP : " + gui[3] + " ", m_font, b, 240, 534);         //좌우,위아래
            //
            label10.Visible = false;
            StringFormat string_format = new StringFormat();
            string_format.Alignment = StringAlignment.Center;
            string_format.LineAlignment = StringAlignment.Center;
            DrawSidewaysText(p, Font, Brushes.Black,
            label10.Bounds, string_format, "종이싸이즈 : " + s_pz + " ㎜");
            //
        }

        private void DrawSidewaysText(Graphics gr, Font font, Brush brush, Rectangle bounds, StringFormat string_format, string txt)
        {
            Rectangle rotated_bounds = new Rectangle(0, 0, bounds.Height, bounds.Width);
            gr.ResetTransform();
            gr.RotateTransform(-90);
            gr.TranslateTransform(bounds.Left, bounds.Bottom, System.Drawing.Drawing2D.MatrixOrder.Append);
            gr.DrawString(txt, font, brush, rotated_bounds, string_format);
        }

        private void panel7_Paint(object sender, PaintEventArgs e)
        {
            if (h_box == false)
            {
                button7_Click(null, null);
                h_box = true;
            }
        }

        private void button47_Click(object sender, EventArgs e)  //2번 버튼
        {
            string[] old_dt = new string[5];
            old_dt[0] = textBox8.Text.Trim();   //종이싸이즈
            old_dt[1] = textBox13.Text.Trim();  //종이국,46
            old_dt[2] = textBox14.Text.Trim();  //종이절수
            old_dt[3] = textBox5.Text.Trim();   //종이결
            old_dt[4] = label13.Text.Trim();    //종이업결 확인수
            //
            mast_bungae_no = "";    //분개번호 초기화
            message_id = "2";       //에라 메세지구분 기호(블랙박스 호출후 나오는 메지지 정보구분 기호) 
            
            if (string.IsNullOrEmpty(textBox1.Text) || string.IsNullOrEmpty(textBox6.Text))
            {
                MessageBox.Show("도큐/인쇄 싸이즈를 입력해 주세요.");
                return;
            }
            if (textBox1.Text.Contains("*") == false || textBox6.Text.Contains("*") == false)
            {
                MessageBox.Show("도큐/인쇄 싸이즈 가로,세로를 '123.5*123.5' 으로 표시해 주세요");
                return;
            }
            //             
            //
            black_id = "1";  //종이정보 구하기
            if (jonge_sel(textBox6.Text.Trim(),"2") == false)   //1차 기본으로 돌리고
            {
                dat_del();  //자료 일괄 삭제
                return;
            }
            //
            string[] jj = new string[5];   //초기정보 배열
            jj[0] = "비규격";              //규격,비규격
            jj[1] = textBox1.Text.Trim();  //도큐싸이즈
            jj[2] = textBox6.Text.Trim();  //별지싸이즈
            jj[3] = textBox12.Text.Trim(); //별지절수
            jj[4] = textBox11.Text.Trim(); //별지국,46
            black_id = "0";                //기본조건
            if (f21_Enter(jj) == false)    //2차 기본으로 돌리고
            {
                dat_del();  //자료 일괄 삭제
                return;
            }
            //
            string[] axx = textBox6.Text.Trim().Split(new char[1] { '*' });  //인쇄싸이즈를 가지고 종,횡목에 따라 인쇄 싸이즈 재설정
            Double f_su = Convert.ToDouble(axx[0]); //인쇄싸이즈의 앞수
            Double r_su = Convert.ToDouble(axx[1]); //인쇄싸이즈의 뒷수
            if (f_su < r_su)  //앞수가 작다면 큰수로 교체하고
            {
                Double temd = f_su;
                f_su = r_su;
                r_su = temd;
            }
            //
            if (textBox16.Text.Trim().Equals("종목"))   //뒷수가 큰거
                textBox6.Text = r_su.ToString() + "*" + f_su;
            else
                textBox6.Text = f_su.ToString() + "*" + r_su;
            // 
            jj[0] = "비규격";               //규격,비규격
            jj[1] = textBox6.Text.Trim();   //인쇄싸이즈
            jj[2] = textBox8.Text.Trim();   //종이싸이즈
            jj[3] = textBox14.Text.Trim();  //종이절수
            jj[4] = textBox13.Text.Trim();  //종이국,46
            black_id = "3";                 //기본조건
            if (f21_Enter(jj) == false)     //3차 기본으로 돌리고
            {
                dat_del();  //자료 일괄 삭제
                return;
            }
            //
            axx = textBox8.Text.Trim().Split(new char[1] { '*' });  //종이싸이즈를 가지고 종,횡목에 따라 인쇄 싸이즈 재설정
            f_su = Convert.ToDouble(axx[0]); //종이싸이즈의 앞수
            r_su = Convert.ToDouble(axx[1]); //종이싸이즈의 뒷수
            if (f_su < r_su)  //앞수가 작다면 큰수로 교체하고
            {
                Double temd = f_su;
                f_su = r_su;
                r_su = temd;
            }
            //
            if (textBox5.Text.Trim().Equals("종목"))   //뒷수가 큰거
                textBox8.Text = r_su.ToString() + "*" + f_su;
            else
                textBox8.Text = f_su.ToString() + "*" + r_su;
            // 
            dat_all();
            hari_sel(false);   //하리 refresh
            button7_Click(null, null); //그림 refresh
        }

        private void button3_Click_1(object sender, EventArgs e) //3번 버튼
        {
            mast_bungae_no = "";    //분개번호 초기화
            message_id = "3";       //에라 메세지구분 기호(블랙박스 호출후 나오는 메지지 정보구분 기호) 
            
            if (row_dat[1].Contains("스티커") || row_dat[1].Contains("PET"))
                textBox6.Text = textBox8.Text.Trim();
            //            
            if (string.IsNullOrEmpty(textBox1.Text) || string.IsNullOrEmpty(textBox6.Text) || string.IsNullOrEmpty(textBox8.Text))
            {
                MessageBox.Show("도큐/인쇄/종이 싸이즈를 입력해 주세요.");
                return;
            }
            if (textBox1.Text.Contains("*") == false || textBox6.Text.Contains("*") == false || textBox8.Text.Contains("*") == false)
            {
                MessageBox.Show("도큐/인쇄/종이 싸이즈 가로,세로를 '123.5*123.5' 으로 표시해 주세요");
                return;
            }
            //
            string[] axx1 = textBox6.Text.Trim().Split(new char[1] { '*' });  //2번(인쇄싸이즈)
            string[] axx2 = textBox8.Text.Trim().Split(new char[1] { '*' });  //3번(종이싸이즈)
            int big_56 = Convert.ToInt32(axx1[0]);
            int small_56 = Convert.ToInt32(axx1[1]);
            int big_10 = Convert.ToInt32(axx2[0]);
            int small_10 = Convert.ToInt32(axx2[1]);
            int temp = 0;
            if (big_56 < small_56)
            {
                temp = big_56;
                big_56 = small_56;
                small_56 = temp;
            }
            //
            if (big_10 < small_10)
            {
                temp = big_10;
                big_10 = small_10;
                small_10 = temp;
            }
            //
            string t10 = textBox8.Text.Trim();  //3번값(종이싸이즈)
            bool m_id = false;
            //   
            if (paper_prn_id == true)  //종이싸이즈 입력전 인쇄싸이즈와 동일한지 구분하는 변수(동일하다면)
            {
                if (t10 == "788*545" || t10 == "545*788")
                    m_id = true;
                else if (t10 == "760*545" || t10 == "545*760")
                    m_id = true;
                else if (t10 == "880*625" || t10 == "625*880")
                    m_id = true;
                else if (t10 == "939*636" || t10 == "636*939")
                    m_id = true;
                else if (t10 == "1091*788" || t10 == "788*1091")
                    m_id = true;
                else if (t10 == "1200*900" || t10 == "900*1200")
                    m_id = true;
                else if (t10 == "1020*720" || t10 == "720*1020")
                    m_id = true;
                 else
                    m_id = false;
                //
                if (m_id == true)
                    textBox6.Text = t10;
                else
                {
                    if (Convert.ToInt32(big_56) * Convert.ToInt32(small_56) > Convert.ToInt32(big_10) * Convert.ToInt32(small_10))  //평량 인쇄싸이즈가 크다면
                        textBox6.Text = t10;
                    else
                        if (big_56 > big_10 || small_56 > small_10)  //종이싸이즈가 하나라도 작다면
                            textBox6.Text = t10;
                    // 
                }
            }
            else
            {
                if (Convert.ToInt32(big_56) * Convert.ToInt32(small_56) > Convert.ToInt32(big_10) * Convert.ToInt32(small_10))  //평량인쇄싸이즈가 크다면
                    textBox6.Text = t10;
                else
                    if (big_56 > big_10 || small_56 > small_10)  //종이싸이즈가 하나라도 작다면
                        textBox6.Text = t10;
            }
            //-------------------------------------------------------
            black_id = "2";  //종이정보 구하기
            //
            message_id = "9";  //최종 메세지 없음
            bool xx = jonge_sel(textBox8.Text.Trim(), "4");

            message_id = "3";  //최종 메세지 
            if (xx == true)
            {
                if (jonge_sel(textBox8.Text.Trim(), "5") == false)    //결과에 따라서
                {
                    dat_del();  //자료 일괄 삭제
                    return;
                }
            }
            else
            {
                if (jonge_sel(textBox8.Text.Trim(), "6") == false)    //
                {
                    dat_del();  //자료 일괄 삭제
                    return;
                }
            }
            //            
            string[] jj = new string[5];   //초기정보 배열
            jj[0] = "비규격";              //규격,비규격
            jj[1] = textBox6.Text.Trim(); //도큐싸이즈
            jj[2] = textBox8.Text.Trim(); //별지싸이즈
            jj[3] = textBox14.Text.Trim(); //별지절수
            jj[4] = textBox13.Text.Trim(); //별지국,46
            black_id = "4";         //
            if (f21_Enter(jj) == false)    //1차 기본으로 돌리고
            {
                dat_del();  //자료 일괄 삭제
                return;
            }
            //
            jj = new string[5];   //초기정보 배열
            jj[0] = "비규격";              //규격,비규격
            jj[1] = textBox1.Text.Trim(); //도큐싸이즈
            jj[2] = textBox6.Text.Trim(); //별지싸이즈
            jj[3] = textBox12.Text.Trim(); //별지절수
            jj[4] = textBox11.Text.Trim(); //별지국,46
            black_id = "0";         //기본조건
            if (f21_Enter(jj) == false)    //1차 기본으로 돌리고
            {
                dat_del();  //자료 일괄 삭제
                return;
            }
            //
            string[] axx = textBox6.Text.Trim().Split(new char[1] { '*' });  //인쇄싸이즈를 가지고 종,횡목에 따라 인쇄 싸이즈 재설정
            Double f_su = Convert.ToDouble(axx[0]); //인쇄싸이즈의 앞수
            Double r_su = Convert.ToDouble(axx[1]); //인쇄싸이즈의 뒷수
            if (f_su < r_su)  //앞수가 작다면 큰수로 교체하고
            {
                Double temd = f_su;
                f_su = r_su;
                r_su = temd;
            }
            //
            if (textBox16.Text.Trim().Equals("종목"))   //뒷수가 큰거
                textBox6.Text = r_su.ToString() + "*" + f_su;
            else
                textBox6.Text = f_su.ToString() + "*" + r_su;
            // 
            jj[0] = "비규격";               //규격,비규격
            jj[1] = textBox6.Text.Trim();  //도큐싸이즈
            jj[2] = textBox8.Text.Trim();  //별지싸이즈
            jj[3] = textBox14.Text.Trim();  //별지절수
            jj[4] = textBox13.Text.Trim();  //별지국,46
            black_id = "3";         //기본조건
            if (f21_Enter(jj) == false)    //1차 기본으로 돌리고
            {
                dat_del();  //자료 일괄 삭제
                return;
            }
            //
            axx = textBox8.Text.Trim().Split(new char[1] { '*' });  //종이싸이즈를 가지고 종,횡목에 따라 인쇄 싸이즈 재설정
            f_su = Convert.ToDouble(axx[0]); //종이싸이즈의 앞수
            r_su = Convert.ToDouble(axx[1]); //종이싸이즈의 뒷수
            if (f_su < r_su)  //앞수가 작다면 큰수로 교체하고
            {
                Double temd = f_su;
                f_su = r_su;
                r_su = temd;
            }
            //
            if (textBox5.Text.Trim().Equals("종목"))   //뒷수가 큰거
                textBox8.Text = r_su.ToString() + "*" + f_su;
            else
                textBox8.Text = f_su.ToString() + "*" + r_su;
            //
            dat_all();
            textBox15.Text = m_db[6];   //추가수
            hari_sel(false);            //하리 refresh
            button7_Click(null, null);  //그림 refresh
        }

        private bool jonge_sel(string pp,string p_su)       //종이 블랙박스  
        {
            bool x_bool;
            string[] ss = new string[12];       //보내는 배열정보 12개로 수정
            for (int i = 0; i < ss.Length; i++)
                ss[i] = "";
            //
            ss[0] = "책자형";  // 
            ss[1] = "0";       //닷찌
            ss[2] = "재물";    //구와이
            ss[3] = pp;        //도큐싸이즈
            ss[4] = "";        //별지종이싸이즈
            ss[5] = p_su;      //별도추가(호출버튼번호)
            ss[6] = "5";       //윤전인쇄 고정
            ss[7] = "";
            ss[8] = "c";       //
            ss[9] = "1";       //기본만
            ss[10] = "";       //별지 절수
            ss[11] = "";       //별지 국,46
            //
            x_bool = paper_select1(ss); //
             return x_bool;
        }

        private void button4_Click(object sender, EventArgs e)   //하리 Refresh
        {
            hari_sel(false); 
        }

        private void textBox8_Enter(object sender, EventArgs e)  //종이싸이즈 입력할려고 하는 순간에 인쇄/종이 싸이즈 동일한지 확인하는 절차
        {
            string t56 = textBox6.Text.Trim(); //2번
            string t10 = textBox8.Text.Trim(); //3번
            //
            if (t56 == "788*545" && t10 == "788*545")
                paper_prn_id = true;
            else if (t56 == "545*788" && t10 == "545*788")
                paper_prn_id = true;
            else if (t56 == "760*545" && t10 == "760*545")
                paper_prn_id = true;
            else if (t56 == "545*760" && t10 == "545*760")
                paper_prn_id = true;
            else if (t56 == "880*625" && t10 == "880*625")
                paper_prn_id = true;
            else if (t56 == "625*880" && t10 == "625*880")
                paper_prn_id = true;
            else if (t56 == "939*636" && t10 == "939*636")
                paper_prn_id = true;
            else if (t56 == "636*939" && t10 == "636*939")
                paper_prn_id = true;
            else if (t56 == "1200*900" && t10 == "1200*900")
                paper_prn_id = true;
            else if (t56 == "900*1200" && t10 == "900*1200")
                paper_prn_id = true;
            else if (t56 == "1020*720" && t10 == "1020*720")
                paper_prn_id = true;
            else if (t56 == "720*1020" && t10 == "720*1020")
                paper_prn_id = true;
            else
                paper_prn_id = false;
        }

        private void label3_Click(object sender, EventArgs e)      //도큐싸이즈
        {
            if (checkBox2.Checked == false)
            {

                Form_size_view frm = new Form_size_view(label3, "1", "hari");
                if (frm.ShowDialog() == DialogResult.OK)
                {
                    textBox1.Text = frm.m_size;
                    button2_Click(null, null);
                }
            }
        }

        private void label3_MouseEnter(object sender, EventArgs e)  
        {
            this.Cursor = Cursors.Hand;
        }

        private void label3_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Arrow;
        }

        private void label8_Click(object sender, EventArgs e)     //인쇄싸이즈
        {
            if (checkBox2.Checked == false)
            {
                Form_size_view frm = new Form_size_view(label8, "2", "hari");
                if (frm.ShowDialog() == DialogResult.OK)
                {
                    textBox6.Text = frm.m_size;
                    button47_Click(null, null);
                }
            }
        }

        private void label8_MouseEnter(object sender, EventArgs e) 
        {
            this.Cursor = Cursors.Hand;
        }

        private void label8_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Arrow;
        }


        private void label4_Click(object sender, EventArgs e)    //종이싸이즈
        {
            if (checkBox2.Checked == false)
            {
                Form_size_view frm = new Form_size_view(label4, "3", "hari");
                if (frm.ShowDialog() == DialogResult.OK)
                {
                    textBox8_Enter(null, null);
                    textBox8.Text = frm.m_size;
                    button3_Click_1(null, null);
                }
            }
        }

        private void label4_MouseEnter(object sender, EventArgs e)  
        {
            this.Cursor = Cursors.Hand;
        }

        private void label4_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Arrow;
        }

        private void checkBox6_CheckedChanged(object sender, EventArgs e)      //닷찌체크 변동시
        {
            dasjji();
        }

        private void radioButton13_CheckedChanged(object sender, EventArgs e)  //닷찌 레디오 버튼 변동시
        {
            dasjji();
        }

        private void dasjji()
        {
            if(checkBox2.Checked == false)
            {
                if (checkBox6.Checked == true && radioButton13.Checked == true)
                {
                    button47.Enabled = false;  //2번 버튼 작동불
                    button3.Enabled = false;   //3번 버튼 작동불
                }
                else
                {
                    button47.Enabled = true;  //2번 버튼 작동불
                    button3.Enabled = true;   //3번 버튼 작동불
                }
            }
        }

    }
}
