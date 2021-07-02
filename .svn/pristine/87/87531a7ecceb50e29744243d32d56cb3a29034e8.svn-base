using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Net;
using System.IO;
using System.Text.RegularExpressions;
using MySql.Data.MySqlClient;

namespace Dukyou3
{
    public partial class Web_FTP : Form
    {

        int[,] m_result = new int[30, 4];
        string[,] c_result = new string[30, 4];
        string f_name = "";
        string row_no = "";
        string won_no = "";
        string jubsu_day = "";
        string db_name = "";
        string main_text = "";
        string s_down = "";// "http://pera.co.kr/upload/20160624/o_1alvs45ck1dmom6r4sf16iprjcc.jpg";
        string s_up = "http://pera.co.kr/plupload/examples/custom.html";
        string DB_C_img_total_manage = "C_img_total_manage";   //image 파일관리
        string DB_C_img_confirm_manage = "C_img_confirm_manage";   //confirm link 파일
        // 
        public Web_FTP(string addr, string row_no, string db_name, string won_no, string jubsu_day )  //addr=접속주소
        {
            InitializeComponent();
            this.s_up = addr;
            this.row_no = row_no;
            this.db_name = db_name;
            this.won_no = won_no;
            this.jubsu_day = jubsu_day;
        }

        public Web_FTP(string addr, string name) // 파일다운  //addr=접속주소 / name=파일다운(위치+파일명)
        {
            InitializeComponent();
            s_down = addr;
            f_name = name;
        }

        public void Webform_Load(object sender, EventArgs e)
        {
            Screen srn = Screen.PrimaryScreen;
            int Xb = this.Width;  //좌,우
            this.webBrowser1.ScriptErrorsSuppressed = true;
            this.Location = new Point((srn.Bounds.Width - Xb) / 2, 100);
            //
            if (f_name == "")
            {
                webBrowser1.Url = new System.Uri(s_up, System.UriKind.Absolute);
                timer1.Enabled = true;
                progressBar1.Visible = false;
            }
            else
            {
                timer1.Enabled = false;
                Down_Start();  //파일다운로드
                panel1.Visible = false;
                progressBar1.Visible = true;
                progressBar1.Location = new System.Drawing.Point(13, 30);
                this.Size = new System.Drawing.Size(704, 120);
             }
        }

        public void Down_Start()  //다운로드
        {
            WebClient webClient = new WebClient();
            webClient.DownloadFileCompleted += new AsyncCompletedEventHandler(Down_Completed);
            webClient.DownloadProgressChanged += new DownloadProgressChangedEventHandler(Down_ProgressChanged);
            webClient.DownloadFileAsync(new Uri(s_down), f_name);  //@"c:\mmm\myfile.jpg"
        }

        private void Down_ProgressChanged(object sender, DownloadProgressChangedEventArgs e)  //진행바
        {
            progressBar1.Value = e.ProgressPercentage;
        }

        private void Down_Completed(object sender, AsyncCompletedEventArgs e)  //다운 완료시
        {
            MessageBox.Show("파일 내려받기 완료하였습니다.");
            this.Close();
        }

        private void Document_Completed()  //적용
        {
            textBox1.Text = "";
            //  
            HtmlElement elem;
            if (webBrowser1.Document != null)
            {
                HtmlElementCollection elems = webBrowser1.Document.GetElementsByTagName("HTML");
                if (elems.Count == 1)
                {
                    elem = elems[0];
                    string pageSource = elem.OuterText;
                    textBox1.Text = pageSource;
                }
            }
        }

        private void main_result()  //
        {
            timer1.Enabled = false;
            //
            bool msg_id = false;
            string str = textBox1.Text;
            string ss = str.Replace(" ", "");
            //
            for (int i = 0; i < m_result.GetLength(0); i++)
            {
                for (int j = 0; j < m_result.GetLength(1); j++)
                {
                    m_result[i, j] = 0;
                    c_result[i, j] = "";
                }
            }
            //
            find_index("File:id=", ss, ref m_result, 0);  //서버 파일명
            find_index(",name=", ss, ref m_result, 1);    //원 파일명
            find_index(",percent=", ss, ref m_result, 2); //결과 퍼센트
            find_index(",lastModifiedDate=", ss, ref m_result, 3);  //생성일자
            //
            int row = 0;
            for (int i = 0; i < m_result.GetLength(0); i++)
            {
                for (int j = 0; j < m_result.GetLength(1); j++)
                {
                    if (m_result[i, j] != 0)
                    {
                        if (j == 0)
                            row = m_result[i, j] + 8;  //검색 글자수 만큼 더함
                        else if (j == 1)
                            row = m_result[i, j] + 6;  //
                        else if (j == 2)
                            row = m_result[i, j] + 9;  //
                        else if (j == 3)
                            row = m_result[i, j] + 18; //
                        //
                        if (j == 3)
                        {
                            c_result[i, j] = convert_digit(find_title(row, ss));

                        }
                        else
                            c_result[i, j] = find_title(row, ss);
                    }
                }
                //
                if (c_result[i, 0] != "" && c_result[i, 1] != "")
                {
                    int index = c_result[i, 1].LastIndexOf('.');
                    c_result[i, 0] = c_result[i, 0] + "." + c_result[i, 1].Substring(index + 1);
                }
            }
            //
            var DBCons = new MySqlConnection(Config.DB_con1);
            util.Con_DB_Open(ref DBCons);
            string cQuery = "";
            for (int i = 0; i < c_result.GetLength(0); i++)
            {
                if (c_result[i, 2] == "100")
                {
                    //string f_id = "";
                    //if(won_no == "0")
                    //    f_id = "won_file";
                    //else
                    //    f_id = "pdf_file";
                    //
                    //cQuery = " insert into " + DB_C_img_total_manage;  //
                    //cQuery += "  (client_id,db_nm,int_id,server_file,user_file,f_option,comment,group1,group2,class,update_time,auto_delete_day,edit_name,won_row_id,jubsu_day)";
                    //cQuery += " values('" + User.Cli_Row_id + "','" + db_name + "','" + row_no + "','" + c_result[i, 0] + "','" + c_result[i, 1] + "','" + f_id + "'";
                    //cQuery += ",'','','','',now(),DATE_ADD( CURDATE(), INTERVAL +3 month ),'" + User.UserName + "','" + won_no + "','" + jubsu_day + "')";
                    //var cmd1 = new MySqlCommand(cQuery, DBCons);
                    //if (cmd1.ExecuteNonQuery() == 0)
                    //    MessageBox.Show("DB 서버 오류 입니다.");
                    //else
                    //    Mesage_box.ShowAutoClosingMessageBox("등록하였습니다","등록");
                    //
                    msg_id = true;
                    break;
                }
            }
            if (msg_id)
            {
                webBrowser1.Url = new System.Uri(s_up, System.UriKind.Absolute);  //웹페이지 초기화
            }
            //
            timer1.Enabled = true;
        }

        private void find_index(string search_c, string all_c, ref int[,] m_result, int c_int)  //
        {
            int r_int = 0;
            Regex _regex = new System.Text.RegularExpressions.Regex(search_c);
            Match _match = _regex.Match(all_c);
            //
            while (_match.Success)
            {
                m_result[r_int, c_int] = _match.Index;
                _match = _match.NextMatch();
                r_int++;
            }
        }

        private string find_title(int st, string ss)  //
        {
            string title = "";
            for (int n = st; n < ss.Length; n++)
            {
                if (ss.Substring(n, 1) == ",")
                    break;
                else
                    title += ss.Substring(n, 1);
            }
            return title;
        }

        private string convert_digit(string dd)  //
        {
            string[] cc = new string[4];
            cc[0] = "";
            cc[1] = "";
            cc[2] = "";
            int nn = 0;
            char[] charArray = dd.Trim().ToCharArray();
            foreach (char c in charArray)
            {
                if (char.IsDigit(c))  //숫자문자 인지 확인
                {
                    cc[nn] += c;
                }
                else
                {
                    if (nn < 3)
                        nn++;
                    else
                        break;
                }
            }
            if (cc[1].Length == 1)
                cc[1] = "0" + cc[1];
            //
            if (cc[2].Length == 1)
                cc[2] = "0" + cc[2];
            //
            return cc[0] + cc[1] + cc[2];
        }

        private int find_index_sub(string search_c, string all_c)  //
        {
            int r_int = 0;
            Regex _regex = new System.Text.RegularExpressions.Regex(search_c);
            Match _match = _regex.Match(all_c);
            //
            while (_match.Success)
            {
                _match = _match.NextMatch();
                r_int++;
            }
            return r_int;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            main_text = textBox1.Text;
            Document_Completed();
            if (textBox1.Text != main_text)
            {
                main_result();
            }
        }

    }
}
