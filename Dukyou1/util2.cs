using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Security;
using System.Security.Cryptography;
using System.Windows.Forms;
using System.Data;
using System.Drawing;
using System.Net.NetworkInformation;
using System.Drawing.Imaging;
using System.Drawing.Drawing2D;
using System.Threading;
using System.Globalization;
using Spire.Xls;
using Excel = Microsoft.Office.Interop.Excel;
using System.Net;
using System.Text.RegularExpressions;
using MySql.Data.MySqlClient;


namespace Dukyou3
{
    public struct jh  //프로그램 전체에서 사용하는 고정형자료
    {
    }

    public class sms
    {
        ProgressBar PbBar = new ProgressBar();
        Form pbForm = new Form();

        ksgcontrol ks = new ksgcontrol();
        ksgcontrol ks1 = new ksgcontrol();

        DataTable send1 = new DataTable();
        OhFTP Ftp = new OhFTP(Config.Ftp_ip_sms, Config.Ftp_id1, Config.Ftp_pw1);
        FileControl FC = new FileControl();
        Thread thr;
        string[] log_msg_seq;
        string TableName_log = "MSG_LOG";
        string TableName_MSG_DATA = "MSG_DATA";
        string TableName_Sms = "L_sms_total_manage";
        string TableName_MMS_INFO = "MMS_CONTENTS_INFO";

        //     string  = "1.234.4.126"; //메시지 전송 서버
        string UserFN = ""; //파일 이름
        string ftpServerFolderName = "sms";   //mms 이미지 저장 폴더(리눅스)

        int sms_count = 0;    //배열 카운트
        int sms_nocount = 0;    //전송 실패 카운트
        int sms_all_count_temp = 0; //총 전송될 문자 갯수
        bool mms_chk = false;

        Bitmap memoryImage;

        /*
         * client_size 캡처할 사이즈
         * cretegraphics this.CreateGraphics();
         * path 파일 저장 경로
         * ftp_folder 저장할 ftp폴더
         * x y location
        */
        public void CaptureScreen(Size client_size, Graphics creategraphics, string path, string ftp_folder, int x, int y)
        {
            Graphics myGraphics = creategraphics;
            Size s = client_size;
            //Size s = new System.Drawing.Size(596, 650);
            memoryImage = new Bitmap(s.Width, s.Height, myGraphics);
            Graphics memoryGraphics = Graphics.FromImage(memoryImage);
            memoryGraphics.CopyFromScreen(x + 8, y + 30, 0, 0, s);

            int temp = 0;
            FileInfo file_info = new FileInfo(@"" + path + "");
            if (file_info.Exists)
            {
                path = "C:\\Temp\\aaa" + temp + ".jpg";
                memoryImage.Save(@"" + path + "", System.Drawing.Imaging.ImageFormat.Jpeg);
                temp++;
            }

            else
                memoryImage.Save(@"" + path + "", System.Drawing.Imaging.ImageFormat.Jpeg);

            if (ftp_folder != "")
            {
                FileInfo fileInf = new FileInfo(path);
                UserFN = fileInf.Name;    //파일 이름
                sync sy = new sync();
                if (sy.FtpDirectoryExists(ftp_folder + UserFN, Config.Ftp_id1, Config.Ftp_pw1) == true)
                    Ftp.DeleteFTP(UserFN, ftpServerFolderName);

                file_up(path);
            }
        }
        public void file_up(string fullPathName)
        {
            ks.ControlInit(Config.DB_conSms, null, null, null);

            FC.FileControlInit(Config.DB_conSms, Config.Ftp_ip1, Config.Ftp_id1, Config.Ftp_pw1);
            //여기부터 파일 검색
            //OpenFileDialog ofd = new OpenFileDialog();// File descriptor
            //if (FC.FileOpenDlg(ofd) == 1)
            //    return;

            // string fullPathName = ofd.FileName;//파일 전체 경로 이름 확장자 포함

            FileInfo fileInf = new FileInfo(fullPathName);
            UserFN = fileInf.Name;    //파일 이름
            //여기까지
            FtpWebRequest reqFTP;

            reqFTP = (FtpWebRequest)FtpWebRequest.Create(new Uri("ftp://" + Config.Ftp_ip_sms + "/" + ftpServerFolderName + "/" + UserFN));
            //
            reqFTP.Credentials = new NetworkCredential("kssmd", "kss1270"); //ftp 정보

            reqFTP.KeepAlive = false;
            reqFTP.Method = WebRequestMethods.Ftp.UploadFile;

            reqFTP.UseBinary = true;

            reqFTP.ContentLength = fileInf.Length;

            int buffLength = 2048;
            byte[] buff = new byte[buffLength];
            int contentLen;
            FileStream fs = fileInf.OpenRead();

            try
            {
                Stream strm = reqFTP.GetRequestStream();
                contentLen = fs.Read(buff, 0, buffLength);
                while (contentLen != 0)
                {
                    strm.Write(buff, 0, contentLen);
                    contentLen = fs.Read(buff, 0, buffLength);
                }
                strm.Close();
                fs.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Upload Error");
            }
        }

        public void main_send(string[] c_id, string[] tophone, string fromphone, string mess, string send_name, int count, string[] receive_name, string file_path)
        {
            ks1.ControlInit(Config.DB_con2, null, null, null);
            sms_all_count_temp = count;
            PbBar.Style = ProgressBarStyle.Marquee;
            PbBar.Minimum = 0;
            PbBar.Maximum = count;
            PbBar.Location = new Point(20, 15);
            PbBar.Size = new Size(310, 20);
            if (file_path != null)
            {
                FileInfo fileInf = new FileInfo(file_path);
                UserFN = fileInf.Name;
                //file_up(file_path);
                mms_chk = true;
            }

            pbForm.ClientSize = new System.Drawing.Size(350, 50);
            pbForm.Controls.Add(PbBar);
            pbForm.Text = "■ 문자 전송중.......";
            pbForm.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;

            string Query = "";
            log_msg_seq = new string[count];
            for (int i = 0; i < count; i++)
            {
                if (mms_chk == true)
                    send(c_id[i], tophone[i], fromphone, mess, send_name, receive_name[i]);
                else
                    send(c_id[i], tophone[i], fromphone, mess, send_name, receive_name[i]);
               
                    Query = "insert into " + TableName_Sms + " (sms_txt, send_num, receive_num, sender, receiver,  int_id, snd_time)";
                    Query += " values('" + mess + "', '" + fromphone + "', '" + tophone[i] + "', '이모션', '" + receive_name[i] + "', '" + c_id[i] + "', now())";
                    ks1.DataUpdate(Query);
                
            }

            thr = new Thread(new ThreadStart(send_check));
            thr.Start();
            pbForm.ShowDialog();

            if (mms_chk == true)
                Ftp.DeleteFTP(UserFN, ftpServerFolderName);
        }

        public void send(string customer_id, string to_phone, string from_phone, string message, string name, string receive_name)
        {
            ks.ControlInit(Config.DB_conSms, null, null, null);

            string temp = Regex.Replace(to_phone, @"\D", "");
            string cell_to = "0" + int.Parse(temp).ToString();

            temp = Regex.Replace(from_phone, @"\D", "");
            string cell_from = "0" + int.Parse(temp).ToString();
            string row_id = "";
            string title = "안녕하세요 (주)이모션.";
            string Query = "";
            string mQuery = "";
            byte[] byte_length = System.Text.Encoding.Default.GetBytes(message);
            if (mms_chk == true)
            {
                string save_path = "/home/kssmd/" + ftpServerFolderName + "/";
                Query = "insert into " + TableName_MMS_INFO + "(file_cnt, mms_body, mms_subject, file_type1, file_name1, service_dep1) ";
                Query += "values(2,'" + message + "','" + title + "','img','" + save_path + UserFN + "','ALL')";
                string cont_seq = ks.DataUpdate(Query);
                Query = "insert into " + TableName_MSG_DATA + "(cur_state,call_to, call_from, sms_txt,msg_type,name,cont_seq,c_id, c_name) ";
                Query += "values(0,'" + cell_to + "','" + cell_from + "','',6,'" + name + "','" + cont_seq + "','" + customer_id + "', '" + receive_name + "')";
                row_id = ks.DataUpdate(Query);
                log_msg_seq[sms_count] = row_id;
                sms_count++;
            }
            else
            {
                if (byte_length.Length > 90)
                {
                    mQuery = "insert into " + TableName_MMS_INFO + " (file_cnt, mms_body,mms_subject)values (1,'" + message + "', '" + title + "')";
                    row_id = ks.DataUpdate(mQuery);
                    Query = "insert into " + TableName_MSG_DATA + "(cur_state,  call_to, call_from, sms_txt, msg_type, cont_seq, name, c_id, c_name) ";
                    Query += "values (0,  '" + cell_to + "', '" + cell_from + "','" + message + "', 6,'" + row_id + "', '" + name + "', '" + customer_id + "', '" + receive_name + "')";
                }
                else
                {
                    Query = "insert into " + TableName_MSG_DATA + "(cur_state, call_to, call_from, sms_txt, msg_type, name, c_id, c_name) ";
                    Query += "values (0, '" + cell_to + "', '" + cell_from + "' , '" + message + "', 4,'" + name + "', '" + customer_id + "', '" + receive_name + "')";
                }


                row_id = ks.DataUpdate(Query);

                log_msg_seq[sms_count] = row_id;
                sms_count++;
            }

        }

        private void send_check()
        {
            sync sy = new sync();

            string wQuery = "";
            for (int i = 0; i < sms_all_count_temp - 1; i++)
            {
                wQuery += "msg_seq =" + log_msg_seq[i] + " or ";
            }
            wQuery += "msg_seq =" + log_msg_seq[sms_all_count_temp - 1];
            while (true)
            {
                sy.dt(Config.DB_conSms, send1, "select msg_seq, rslt_code2 from " + TableName_log);
                DataRow[] dr = send1.Select(wQuery);

                if (dr.Length == sms_count)
                {
                    for (int z = 0; z < dr.Length; z++)
                    {
                        if (dr[z]["rslt_code2"].ToString() == "0")
                        {
                            //    MessageBox.Show("완료");
                        }

                        else if (dr[z]["rslt_code2"].ToString() == "2")
                        {
                            //  MessageBox.Show("전화번호가 올바르지 않습니다.");
                            sms_nocount++;
                        }

                        else
                        {
                            //  MessageBox.Show("전송실패");
                            sms_nocount++;
                        }
                    }
                    break;
                }
            }
            pbform_close(pbForm);
            System.Windows.Forms.MessageBox.Show("전송 성공 : " + (sms_count - sms_nocount) + "개, 전송 실패 : " + sms_nocount + "개", "제목", MessageBoxButtons.OK, MessageBoxIcon.Information);

        }
        delegate void Form_Close(Form fm);
        private void pbform_close(Form fm)
        {
            // InvokeRequired required compares the thread ID of the
            // calling thread to the thread ID of the creating thread.
            // If these threads are different, it returns true.
            if (this.pbForm.InvokeRequired)
            {
                Form_Close d = new Form_Close(pbform_close);
                pbForm.Invoke(d, new object[] { fm });

            }
            else
            {
                pbForm.Close();
            }
        }
    }

    class Notice
    {
        /* ----------------------------------------------- *
        * Function : Point_no_increase
        * 기능     : point_no 의 값을 증가 시킨다.
        -------------------------------------------------- */
        public int Point_no_increase(string db_name_query)
        {
            string Query = "select max(point_no) from " + db_name_query;
            MySqlConnection DBConn;
            DBConn = new MySqlConnection(Config.DB_con1);
            DBConn.Open();
            var cmd = new MySqlCommand(Query, DBConn);
            var myRead = cmd.ExecuteReader();

            myRead.Read();
            int point_no;

            string max_point_no = myRead["max(point_no)"].ToString();
            if (max_point_no == "")
                point_no = 0;
            else
                point_no = Convert.ToInt32(max_point_no) + 1;

            myRead.Close();
            DBConn.Close();
            return point_no;
        }
    }
    public class sync
    {
        public bool FtpDirectoryExists(string directory, string username, string password)  //ftp파일 존재 검사
        {
            try
            {
                var request = (FtpWebRequest)WebRequest.Create(directory);
                request.Credentials = new NetworkCredential(username, password);
                request.Method = WebRequestMethods.Ftp.GetDateTimestamp;

                FtpWebResponse response = (FtpWebResponse)request.GetResponse();
            }
            catch (WebException ex)
            {
                FtpWebResponse response = (FtpWebResponse)ex.Response;
                if (response.StatusCode == FtpStatusCode.ActionNotTakenFileUnavailable)
                    return false;
                else
                    return true;
            }
            return true;
        }

        public void dt(string db_con, DataTable dt_name, string cQuery)
        {
            var DBCons = new MySqlConnection(db_con);
            DBCons.Open();
            dt_name.Rows.Clear();
            MySqlDataAdapter returnVal1 = new MySqlDataAdapter(cQuery, DBCons);
            returnVal1.Fill(dt_name);
            returnVal1.Dispose();
            DBCons.Close();
        }
    }
    public class Excel_make
    {
        Workbook excelBook;
        Worksheet excelWokrsheet;
        DataTable auto2 = new DataTable();
        DataTable cmodel = new DataTable();
        DataTable bmodel = new DataTable();
        DataTable client = new DataTable();
        SourceGridControl GridHandle = new SourceGridControl();
        int excel_row = 0;              // 엑셀이 변환되고 있는 row 카운트
        int grid_row = 1;                // grid의 작업중인 열
        string sangho = ""; //의뢰처
        string jopname = "";    //제작명
        string dname = "";  //담당자
        string tel = "";    //TEL 의뢰처 전화번호
        string damdang = "이진오"; //출력실 담당
        string dtel = "070-8730-2294";  //전화번호
        string dhp = "010-4377-2345";   //전화번호
        string tel24 = "010-2730-8944"; //사장님 전화번호 24시 비상연락망
        string mQuery = "";
        string DB_TableName_joo = "C_corp_jumoon";
        string DB_TableName_client = "C_client";
        string DB_TableName_hmachin = "C_hmachin";
        string DB_TableName_hcustomer = "C_hcustomer";
        string DB_TableName_progres2 = "C_progres2";
        int row_temp;
        string prn_company = "";
        string prn_tel = "";
        string prn_addr = "";
        string prn_hp = "";
        string joo_no = "";
        string sdate = "";  //접수일
        string auto2_row_id = "";
        string page = "";
        string dsize = "";  //도큐사이즈
        string pan = ""; //판형
        string ctp_size = ""; //CTP 판 사이즈
        string p_size = ""; //종이사이즈
        string machin_guy = ""; //기계구와이
        string dosu = ""; //도수
        string sdosu = ""; //별도수
        int daesu; //대수
        int pansu; //판수
        string c_id = "";
        
        

        public string Get_Form3(SourceGrid.Grid grid, string select_row)
        {
            try
            {
                row_temp = Convert.ToInt32(select_row);
                c_id = grid[row_temp, 32].ToString();
                string jname = grid[row_temp, 8].ToString();
                string file_path = @"c:\temp\test_작업_"+jname+".xlsx";
                if (File.Exists(file_path))
                    File.Delete(file_path);
                make_dt();
                excelBook = new Workbook();
                excelWokrsheet = excelBook.Worksheets[0];

                excelBook.Version = ExcelVersion.Version2007;
                excelWokrsheet.PageSetup.LeftMargin = 0;  //변환되는거같음... 0.5
                excelWokrsheet.PageSetup.RightMargin = 0; // 0.5
                excelWokrsheet.PageSetup.TopMargin = 0;   // 0.8  
                excelWokrsheet.PageSetup.BottomMargin = 0;
                excelWokrsheet.PageSetup.HeaderMarginInch = 0;
                excelWokrsheet.PageSetup.FooterMarginInch = 0;
                excelWokrsheet.PageSetup.CenterHorizontally = true;
                excelWokrsheet.PageSetup.Zoom = 100;
                //
                
                db_s(grid, row_temp);

                excelWokrsheet.Range["B2:AC3"].Merge();  // 
                excelWokrsheet.Range["B2"].HorizontalAlignment = HorizontalAlignType.Center;
                excelWokrsheet.Range["B2"].Text = "이모션 CTP 출력 작업의뢰서";
                excelWokrsheet.Range["B2"].Style.Font.FontName = "굴림";
                excelWokrsheet.Range["B2"].Style.Font.Size = 24;
                excelWokrsheet.Range["B2"].Style.Font.IsBold = true;

                Information();
                memo();
                excel_row = 17;
                ctp_content(grid);
                gongjung(grid);
                print_company();
                Set_Column_size();
                excelBook.SaveToFile(file_path);
                System.Diagnostics.Process.Start(file_path);
                Cursor.Current = Cursors.Default;
                return file_path;
            }
            catch
            {
            }
            return "";
        }
        public void make_dt()
        {
            var DBCons = new MySqlConnection(Config.DB_con1);
            DBCons.Open();

            // 
            string cQuery = "";
            auto2.Rows.Clear();
            cQuery = "select * FROM C_auto2";
            MySqlDataAdapter returnVal1 = new MySqlDataAdapter(cQuery, DBCons);
            returnVal1.Fill(auto2);
            returnVal1.Dispose();

            cmodel.Rows.Clear();
            cQuery = "select eng,citem FROM C_cmodel";
            MySqlDataAdapter returnVal2 = new MySqlDataAdapter(cQuery, DBCons);
            returnVal2.Fill(cmodel);
            returnVal2.Dispose();

            bmodel.Rows.Clear();
            cQuery = "select * from C_bmodel";
            MySqlDataAdapter returnVal3 = new MySqlDataAdapter(cQuery, DBCons);
            returnVal3.Fill(bmodel);
            returnVal3.Dispose();

            client.Rows.Clear();
            cQuery = "select * from C_client";
            MySqlDataAdapter returnVal4 = new MySqlDataAdapter(cQuery, DBCons);
            returnVal4.Fill(client);
            returnVal4.Dispose();

            DBCons.Close();
        }
        public string[] m_db = new string[60];
        private void db_s(SourceGrid.Grid grid, int row)
        {
            joo_no = grid[row, 33].ToString();
            sangho = grid[row, 7].ToString();
            jopname = grid[row, 8].ToString();
            // goowhy = grid[row, 13].ToString();
            sdate = Convert.ToDateTime(grid[row, 4].ToString()).ToString("yyyy-MM-dd");

            DataRow[] dr1;
            dr1 = client.Select("row_id = " + c_id);
            tel = dr1[0]["tel"].ToString();

        }
        private void Set_Column_size()
        {
            excelWokrsheet.Range["A1:AD"+excel_row+""].VerticalAlignment = VerticalAlignType.Center;
            excelWokrsheet.Range["A1:AD" + excel_row + ""].ColumnWidth = 2.6;
            excelWokrsheet.Range["A1:AD" + excel_row + ""].RowHeight = 20;
        }

        private void Information()
        {
            excelWokrsheet.Range["B5:AD38"].Style.Font.FontName = "맑은 고딕";
            excelWokrsheet.Range["B5:AD38"].Style.Font.Size = 9;
            excelWokrsheet.Range["B5:S8"].HorizontalAlignment = HorizontalAlignType.Center;
            excelWokrsheet.Range["B5:S8"].Style.Borders[BordersLineType.EdgeTop].Color = Color.Black;
            excelWokrsheet.Range["B5:S8"].Style.Borders[BordersLineType.EdgeTop].LineStyle = LineStyleType.Hair;
            excelWokrsheet.Range["B5:S8"].Style.Borders[BordersLineType.EdgeBottom].Color = Color.Black;
            excelWokrsheet.Range["B5:S8"].Style.Borders[BordersLineType.EdgeBottom].LineStyle = LineStyleType.Hair;
            excelWokrsheet.Range["B5:S8"].Style.Borders[BordersLineType.EdgeLeft].Color = Color.Black;
            excelWokrsheet.Range["B5:S8"].Style.Borders[BordersLineType.EdgeLeft].LineStyle = LineStyleType.Hair;
            excelWokrsheet.Range["B5:S8"].Style.Borders[BordersLineType.EdgeRight].Color = Color.Black;
            excelWokrsheet.Range["B5:S8"].Style.Borders[BordersLineType.EdgeRight].LineStyle = LineStyleType.Hair;

            excelWokrsheet.Range["B5:S5"].Style.Borders[BordersLineType.EdgeTop].Color = Color.Black;
            excelWokrsheet.Range["B5:S5"].Style.Borders[BordersLineType.EdgeTop].LineStyle = LineStyleType.Thin;
            excelWokrsheet.Range["B5:B8"].Style.Borders[BordersLineType.EdgeLeft].Color = Color.Black;
            excelWokrsheet.Range["B5:B8"].Style.Borders[BordersLineType.EdgeLeft].LineStyle = LineStyleType.Thin;
            excelWokrsheet.Range["B8:S8"].Style.Borders[BordersLineType.EdgeBottom].Color = Color.Black;
            excelWokrsheet.Range["B8:S8"].Style.Borders[BordersLineType.EdgeBottom].LineStyle = LineStyleType.Thin;
            excelWokrsheet.Range["S5:S8"].Style.Borders[BordersLineType.EdgeRight].Color = Color.Black;
            excelWokrsheet.Range["S5:S8"].Style.Borders[BordersLineType.EdgeRight].LineStyle = LineStyleType.Thin;

            excelWokrsheet.Range["B5:E5"].Merge();  // 
            excelWokrsheet.Range["B5"].Text = "의뢰처";
            excelWokrsheet.Range["F5:S5"].Merge();  // 
            excelWokrsheet.Range["F5"].Text = sangho;
            excelWokrsheet.Range["F5"].Style.IndentLevel = 1;
            excelWokrsheet.Range["F5"].HorizontalAlignment = HorizontalAlignType.Left;

            excelWokrsheet.Range["B6:E6"].Merge();  // 
            excelWokrsheet.Range["B6"].Text = "제작명";
            excelWokrsheet.Range["F6:S6"].Merge();  // 
            excelWokrsheet.Range["F6"].Text = jopname;
            excelWokrsheet.Range["F6"].Style.IndentLevel = 1;
            excelWokrsheet.Range["F6"].HorizontalAlignment = HorizontalAlignType.Left;

            excelWokrsheet.Range["B7:E7"].Merge();  // 
            excelWokrsheet.Range["B7"].Text = "T E L";
            excelWokrsheet.Range["F7:S7"].Merge();  // 
            excelWokrsheet.Range["F7"].Text = tel;
            excelWokrsheet.Range["F7"].Style.IndentLevel = 1;
            excelWokrsheet.Range["F7"].HorizontalAlignment = HorizontalAlignType.Left;

            excelWokrsheet.Range["B8:E8"].Merge();  // 
            excelWokrsheet.Range["B8"].Text = "담당자";
            excelWokrsheet.Range["F8:J8"].Merge();  // 
            excelWokrsheet.Range["F8"].Text = dname;
            excelWokrsheet.Range["F8"].Style.IndentLevel = 1;
            excelWokrsheet.Range["F8"].HorizontalAlignment = HorizontalAlignType.Left;

            excelWokrsheet.Range["K8:N8"].Merge();  // 
            excelWokrsheet.Range["K8"].Text = "H . P";
            excelWokrsheet.Range["O8:S8"].Merge();  // 
            excelWokrsheet.Range["O8"].Text = "";
            excelWokrsheet.Range["O8"].Style.IndentLevel = 1;
            excelWokrsheet.Range["O8"].HorizontalAlignment = HorizontalAlignType.Left;

            excelWokrsheet.Range["U5:AC8"].HorizontalAlignment = HorizontalAlignType.Center;
            excelWokrsheet.Range["U5:AC8"].Style.Borders[BordersLineType.EdgeTop].Color = Color.Black;
            excelWokrsheet.Range["U5:AC8"].Style.Borders[BordersLineType.EdgeTop].LineStyle = LineStyleType.Hair;
            excelWokrsheet.Range["U5:AC8"].Style.Borders[BordersLineType.EdgeBottom].Color = Color.Black;
            excelWokrsheet.Range["U8:AC8"].Style.Borders[BordersLineType.EdgeBottom].LineStyle = LineStyleType.Hair;
            excelWokrsheet.Range["U5:AC8"].Style.Borders[BordersLineType.EdgeLeft].Color = Color.Black;
            excelWokrsheet.Range["U5:AC8"].Style.Borders[BordersLineType.EdgeLeft].LineStyle = LineStyleType.Hair;
            excelWokrsheet.Range["U5:AC8"].Style.Borders[BordersLineType.EdgeRight].Color = Color.Black;
            excelWokrsheet.Range["U5:AC8"].Style.Borders[BordersLineType.EdgeRight].LineStyle = LineStyleType.Hair;

            excelWokrsheet.Range["U5:AC5"].Style.Borders[BordersLineType.EdgeTop].Color = Color.Black;
            excelWokrsheet.Range["U5:AC5"].Style.Borders[BordersLineType.EdgeTop].LineStyle = LineStyleType.Thin;
            excelWokrsheet.Range["U8:AC8"].Style.Borders[BordersLineType.EdgeBottom].Color = Color.Black;
            excelWokrsheet.Range["U8:AC8"].Style.Borders[BordersLineType.EdgeBottom].LineStyle = LineStyleType.Thin;
            excelWokrsheet.Range["U5:U8"].Style.Borders[BordersLineType.EdgeLeft].Color = Color.Black;
            excelWokrsheet.Range["U5:U8"].Style.Borders[BordersLineType.EdgeLeft].LineStyle = LineStyleType.Thin;
            excelWokrsheet.Range["Y5:AC8"].Style.Borders[BordersLineType.EdgeRight].Color = Color.Black;
            excelWokrsheet.Range["Y5:AC8"].Style.Borders[BordersLineType.EdgeRight].LineStyle = LineStyleType.Thin;

            excelWokrsheet.Range["U5:X5"].Merge();  // 
            excelWokrsheet.Range["U5"].Text = "출력실 담당";
            excelWokrsheet.Range["Y5:AC5"].Merge();  // 
            excelWokrsheet.Range["Y5"].Text = damdang;
            excelWokrsheet.Range["Y5"].Style.IndentLevel = 1;
            excelWokrsheet.Range["Y5"].HorizontalAlignment = HorizontalAlignType.Left;

            excelWokrsheet.Range["U6:X6"].Merge();  // 
            excelWokrsheet.Range["U6"].Text = "T E L";
            excelWokrsheet.Range["Y6:AC6"].Merge();  // 
            excelWokrsheet.Range["Y6"].Text = dtel;
            excelWokrsheet.Range["Y6"].Style.IndentLevel = 1;
            excelWokrsheet.Range["Y6"].HorizontalAlignment = HorizontalAlignType.Left;

            excelWokrsheet.Range["U7:X7"].Merge();  // 
            excelWokrsheet.Range["U7"].Text = "H . P";
            excelWokrsheet.Range["Y7:AC7"].Merge();  // 
            excelWokrsheet.Range["Y7"].Text = dhp;
            excelWokrsheet.Range["Y7"].Style.IndentLevel = 1;
            excelWokrsheet.Range["Y7"].HorizontalAlignment = HorizontalAlignType.Left;

            excelWokrsheet.Range["U8:X8"].Merge();  // 
            excelWokrsheet.Range["U8"].Text = "24시 비상연락망";
            excelWokrsheet.Range["Y8:AC8"].Merge();  // 
            excelWokrsheet.Range["Y8"].Text = tel24;
            excelWokrsheet.Range["Y8"].Style.IndentLevel = 1;
            excelWokrsheet.Range["Y8"].HorizontalAlignment = HorizontalAlignType.Left;
        }

        private void memo()
        {
            excelWokrsheet.Range["B10"].Text = "■ 메모";
            excelWokrsheet.Range["B10"].Style.Font.FontName = "맑은 고딕";
            excelWokrsheet.Range["B10"].Style.Font.Size = 11;
            excelWokrsheet.Range["B10"].Style.Font.IsBold = true;

            excelWokrsheet.Range["B11:X11"].HorizontalAlignment = HorizontalAlignType.Center;
            excelWokrsheet.Range["B12:AC15"].Style.Borders[BordersLineType.EdgeTop].Color = Color.Black;
            excelWokrsheet.Range["B12:AC15"].Style.Borders[BordersLineType.EdgeTop].LineStyle = LineStyleType.Hair;
            excelWokrsheet.Range["B11:AC11"].Style.Borders[BordersLineType.EdgeLeft].Color = Color.Black;
            excelWokrsheet.Range["B11:AC11"].Style.Borders[BordersLineType.EdgeLeft].LineStyle = LineStyleType.Hair;
            excelWokrsheet.Range["B11:AC11"].Style.Borders[BordersLineType.EdgeRight].Color = Color.Black;
            excelWokrsheet.Range["B11:AC11"].Style.Borders[BordersLineType.EdgeRight].LineStyle = LineStyleType.Hair;

            excelWokrsheet.Range["B11:AC15"].Style.Borders[BordersLineType.EdgeTop].Color = Color.Black;
            excelWokrsheet.Range["B11:AC15"].Style.Borders[BordersLineType.EdgeTop].LineStyle = LineStyleType.Thin;
            excelWokrsheet.Range["B15:AC15"].Style.Borders[BordersLineType.EdgeBottom].Color = Color.Black;
            excelWokrsheet.Range["B15:AC15"].Style.Borders[BordersLineType.EdgeBottom].LineStyle = LineStyleType.Thin;
            excelWokrsheet.Range["B11:B15"].Style.Borders[BordersLineType.EdgeLeft].Color = Color.Black;
            excelWokrsheet.Range["B11:B15"].Style.Borders[BordersLineType.EdgeLeft].LineStyle = LineStyleType.Thin;
            excelWokrsheet.Range["AC11:AC15"].Style.Borders[BordersLineType.EdgeRight].Color = Color.Black;
            excelWokrsheet.Range["AC11:AC15"].Style.Borders[BordersLineType.EdgeRight].LineStyle = LineStyleType.Thin;

            excelWokrsheet.Range["B11:E11"].Merge();  // 
            excelWokrsheet.Range["B11"].Text = "접수일";
            excelWokrsheet.Range["F11:J11"].Merge();  // 
            excelWokrsheet.Range["F11"].Text = sdate.ToString();
            excelWokrsheet.Range["F11"].Style.IndentLevel = 1;
            excelWokrsheet.Range["F11"].HorizontalAlignment = HorizontalAlignType.Left;

            excelWokrsheet.Range["K11:N11"].Merge();  // 
            excelWokrsheet.Range["K11"].Text = "컨펌일시";
            excelWokrsheet.Range["O11:T11"].Merge();  // 
            excelWokrsheet.Range["O11"].Text = "";
            excelWokrsheet.Range["O11"].Style.IndentLevel = 1;
            excelWokrsheet.Range["O11"].HorizontalAlignment = HorizontalAlignType.Left;

            excelWokrsheet.Range["U11:X11"].Merge();  // 
            excelWokrsheet.Range["U11"].Text = "출고일시";
            excelWokrsheet.Range["Y11:AC11"].Merge();  // 
            excelWokrsheet.Range["Y11"].Text = "";
            excelWokrsheet.Range["Y11"].Style.IndentLevel = 1;
            excelWokrsheet.Range["Y11"].HorizontalAlignment = HorizontalAlignType.Left;

            excelWokrsheet.Range["B12:AC15"].Style.Borders[BordersLineType.EdgeTop].Color = Color.Black;
            excelWokrsheet.Range["B12:AC15"].Style.Borders[BordersLineType.EdgeTop].LineStyle = LineStyleType.Hair;

            excelWokrsheet.Range["B12:AC15"].Merge();  // 
            excelWokrsheet.Range["B12"].Text = "";
            excelWokrsheet.Range["B12"].Style.IndentLevel = 1;
        }

        private void ctp_content(SourceGrid.Grid grid)
        {
            excelWokrsheet.Range["B" + excel_row + ""].Text = "■ CTP 내용";
            excelWokrsheet.Range["B" + excel_row + ""].Style.Font.FontName = "맑은 고딕";
            excelWokrsheet.Range["B" + excel_row + ""].Style.Font.Size = 11;
            excelWokrsheet.Range["B" + excel_row + ""].Style.Font.IsBold = true;
            excel_row += 1;
            int start_row = excel_row;
            excelWokrsheet.Range["C" + excel_row + ":D" + excel_row + ""].Merge();  // 
            excelWokrsheet.Range["C" + excel_row + ""].Text = "페이지";

            excelWokrsheet.Range["E" + excel_row + ":G" + excel_row + ""].Merge();  // 
            excelWokrsheet.Range["E" + excel_row + ""].Text = "도큐사이즈";

            excelWokrsheet.Range["H" + excel_row + ":J" + excel_row + ""].Merge();  // 
            excelWokrsheet.Range["H" + excel_row + ""].Text = "인쇄판형";

            excelWokrsheet.Range["K" + excel_row + ":N" + excel_row + ""].Merge();  // 
            excelWokrsheet.Range["K" + excel_row + ""].Text = "CTP 판사이즈";

            excelWokrsheet.Range["O" + excel_row + ":R" + excel_row + ""].Merge();  // 
            excelWokrsheet.Range["O" + excel_row + ""].Text = "종이사이즈";

            excelWokrsheet.Range["S" + excel_row + ":U" + excel_row + ""].Merge();  // 
            excelWokrsheet.Range["S" + excel_row + ""].Text = "기계구와이";

            excelWokrsheet.Range["V" + excel_row + ":W" + excel_row + ""].Merge();  // 
            excelWokrsheet.Range["V" + excel_row + ""].Text = "도수";

            excelWokrsheet.Range["X" + excel_row + ":Y" + excel_row + ""].Merge();  // 
            excelWokrsheet.Range["X" + excel_row + ""].Text = "별도수";

            excelWokrsheet.Range["Z" + excel_row + ":AA" + excel_row + ""].Merge();  // 
            excelWokrsheet.Range["Z" + excel_row + ""].Text = "대수";

            excelWokrsheet.Range["AB" + excel_row + ":AC" + excel_row + ""].Merge();  // 
            excelWokrsheet.Range["AB" + excel_row + ""].Text = "판수";

            excel_row += 1;
            DataRow[] dr1;
            MySqlConnection DBConn;
            DBConn = new MySqlConnection(Config.DB_con1);
            DBConn.Open();
            if (grid[row_temp, 35].ToString() != "")
            {
                mQuery = "select b.tel, a.auto2_id, c.pan_size, c.machin_guy, d.sangho as prn_com, d.ctel, d.m_addr from " + DB_TableName_joo + " as a ";
                mQuery += "left outer join " + DB_TableName_client + " as b on a.client_id = b.row_id ";
                mQuery += "Left outer join " + DB_TableName_hmachin + " as c on c.row_id = a.corp_machine_id ";
                mQuery += "Left outer join " + DB_TableName_hcustomer + " as d on d.row_id = c.int_id ";
                mQuery += "where d.sangho = '" + grid[row_temp, 35].ToString() + "' and a.jumoon2_id = " + joo_no;
            }
            else
            {
                mQuery = "select b.tel, a.auto2_id, c.pan_size, c.machin_guy, d.sangho as prn_com, d.ctel, d.m_addr from " + DB_TableName_joo + " as a ";
                mQuery += "left outer join " + DB_TableName_client + " as b on a.client_id = b.row_id ";
                mQuery += "Left outer join " + DB_TableName_hmachin + " as c on c.row_id = a.corp_machine_id ";
                mQuery += "Left outer join " + DB_TableName_hcustomer + " as d on d.row_id = c.int_id ";
                mQuery += "where a.jumoon2_id = " + joo_no;
            }
            var cmd = new MySqlCommand(mQuery, DBConn);
            var myRead = cmd.ExecuteReader();

            int m = 1;
            while (myRead.Read())
            {
                tel = myRead["tel"].ToString();
                auto2_row_id = myRead["auto2_id"].ToString();
                ctp_size = myRead["pan_size"].ToString();
                prn_company = myRead["prn_com"].ToString();
                machin_guy = myRead["machin_guy"].ToString();
                prn_tel = myRead["ctel"].ToString();
                prn_addr = myRead["m_addr"].ToString();


                dr1 = auto2.Select("row_id = " + auto2_row_id);

                dosu = dr1[0]["dosu"].ToString();
                sdosu = dr1[0]["star"].ToString();
                daesu = Convert.ToInt32(dr1[0]["deasu"].ToString());
                pansu = Convert.ToInt32(GridHandle.decimaldel(dr1[0]["total_su"].ToString()));

                int p_count = Convert.ToInt32(dr1[0]["page"].ToString()) * Convert.ToInt32(daesu);
                m_db = dr1[0][50].ToString().Split(new char[1] { '#' });
                dsize = m_db[10];
                pan = m_db[16] + " " + m_db[17] + "절";
                p_size = m_db[15];


                excelWokrsheet.Range["B" + excel_row + ""].NumberValue = m;

                excelWokrsheet.Range["C" + excel_row + ":D" + excel_row + ""].Merge();  // 
                excelWokrsheet.Range["C" + excel_row + ""].NumberValue = p_count;

                excelWokrsheet.Range["E" + excel_row + ":G" + excel_row + ""].Merge();  // 
                excelWokrsheet.Range["E" + excel_row + ""].Text = dsize;

                excelWokrsheet.Range["H" + excel_row + ":J" + excel_row + ""].Merge();  // 
                excelWokrsheet.Range["H" + excel_row + ""].Text = pan;

                excelWokrsheet.Range["K" + excel_row + ":N" + excel_row + ""].Merge();  // 
                excelWokrsheet.Range["K" + excel_row + ""].Text = ctp_size;

                excelWokrsheet.Range["O" + excel_row + ":R" + excel_row + ""].Merge();  // 
                excelWokrsheet.Range["O" + excel_row + ""].Text = p_size;

                excelWokrsheet.Range["S" + excel_row + ":U" + excel_row + ""].Merge();  // 
                excelWokrsheet.Range["S" + excel_row + ""].Text = machin_guy;

                excelWokrsheet.Range["V" + excel_row + ":W" + excel_row + ""].Merge();  // 
                excelWokrsheet.Range["V" + excel_row + ""].Text = dosu;

                excelWokrsheet.Range["X" + excel_row + ":Y" + excel_row + ""].Merge();  // 
                excelWokrsheet.Range["X" + excel_row + ""].Text = sdosu;

                excelWokrsheet.Range["Z" + excel_row + ":AA" + excel_row + ""].Merge();  // 
                excelWokrsheet.Range["Z" + excel_row + ""].NumberValue = daesu;

                excelWokrsheet.Range["AB" + excel_row + ":AC" + excel_row + ""].Merge();  // 
                excelWokrsheet.Range["AB" + excel_row + ""].NumberValue = pansu;

                m++;
                excel_row += 1;
            }
            myRead.Close();
            DBConn.Close();

            excel_row -= 1;
            excelWokrsheet.Range["B" + start_row + ":AC" + excel_row + ""].Style.Font.FontName = "맑은 고딕";
            excelWokrsheet.Range["B" + start_row + ":AC" + excel_row + ""].Style.Font.Size = 9;
            excelWokrsheet.Range["B" + start_row + ":AC" + excel_row + ""].HorizontalAlignment = HorizontalAlignType.Center;

            excelWokrsheet.Range["B" + start_row + ":AC" + excel_row + ""].Style.Borders[BordersLineType.EdgeTop].Color = Color.Black;
            excelWokrsheet.Range["B" + start_row + ":AC" + excel_row + ""].Style.Borders[BordersLineType.EdgeTop].LineStyle = LineStyleType.Hair;
            excelWokrsheet.Range["B" + start_row + ":AC" + excel_row + ""].Style.Borders[BordersLineType.EdgeBottom].Color = Color.Black;
            excelWokrsheet.Range["B" + start_row + ":AC" + excel_row + ""].Style.Borders[BordersLineType.EdgeBottom].LineStyle = LineStyleType.Hair;
            excelWokrsheet.Range["B" + start_row + ":AC" + excel_row + ""].Style.Borders[BordersLineType.EdgeLeft].Color = Color.Black;
            excelWokrsheet.Range["B" + start_row + ":AC" + excel_row + ""].Style.Borders[BordersLineType.EdgeLeft].LineStyle = LineStyleType.Hair;
            excelWokrsheet.Range["B" + start_row + ":AC" + excel_row + ""].Style.Borders[BordersLineType.EdgeRight].Color = Color.Black;
            excelWokrsheet.Range["B" + start_row + ":AC" + excel_row + ""].Style.Borders[BordersLineType.EdgeRight].LineStyle = LineStyleType.Hair;


            excelWokrsheet.Range["B" + start_row + ":AC" + start_row + ""].Style.Borders[BordersLineType.EdgeTop].Color = Color.Black;
            excelWokrsheet.Range["B" + start_row + ":AC" + start_row + ""].Style.Borders[BordersLineType.EdgeTop].LineStyle = LineStyleType.Thin;
            excelWokrsheet.Range["B" + excel_row + ":AC" + excel_row + ""].Style.Borders[BordersLineType.EdgeBottom].Color = Color.Black;
            excelWokrsheet.Range["B" + excel_row + ":AC" + excel_row + ""].Style.Borders[BordersLineType.EdgeBottom].LineStyle = LineStyleType.Thin;
            excelWokrsheet.Range["B" + start_row + ":B" + excel_row + ""].Style.Borders[BordersLineType.EdgeLeft].Color = Color.Black;
            excelWokrsheet.Range["B" + start_row + ":B" + excel_row + ""].Style.Borders[BordersLineType.EdgeLeft].LineStyle = LineStyleType.Thin;
            excelWokrsheet.Range["AC" + start_row + ":AC" + excel_row + ""].Style.Borders[BordersLineType.EdgeRight].Color = Color.Black;
            excelWokrsheet.Range["AC" + start_row + ":AC" + excel_row + ""].Style.Borders[BordersLineType.EdgeRight].LineStyle = LineStyleType.Thin;
        }

        private void gongjung(SourceGrid.Grid grid)
        {
            excel_row += 2;
            excelWokrsheet.Range["B" + excel_row + ""].Text = "■ 후공정 내용";
            excelWokrsheet.Range["B" + excel_row + ""].Style.Font.FontName = "맑은 고딕";
            excelWokrsheet.Range["B" + excel_row + ""].Style.Font.Size = 11;
            excelWokrsheet.Range["B" + excel_row + ""].Style.Font.IsBold = true;
            excel_row += 1;

            int start_row = excel_row;
            DataRow[] dr1;
            DataRow[] dr2;
            string acode = "";
            string bcode = "";
            string ccode = "";
            MySqlConnection DBConn;
            DBConn = new MySqlConnection(Config.DB_con1);
            DBConn.Open();
            mQuery = " select a.int_g,b.sangho FROM " + DB_TableName_progres2 + " as a ";  //공정테이블
            mQuery += " left outer join " + DB_TableName_hcustomer + " as b on a.comp_id = b.row_id ";
            mQuery += " where a.super_id='" + c_id + "' and a.int_id=" + joo_no + " order by a.no_1,a.no_2,a.no_3";
            var cmd = new MySqlCommand(mQuery, DBConn);
            var myRead = cmd.ExecuteReader();
            int m = 1;
            string hh = "";
            int temp;
            string temp1="", temp2="";
            bool s_id = false;
            while (myRead.Read())
            {
                acode = myRead["int_g"].ToString().Substring(0, 2);
                bcode = myRead["int_g"].ToString().Substring(2, 2); ;
                ccode = myRead["int_g"].ToString().Substring(4, 2); ;
                dr1 = bmodel.Select("a_code='" + acode + "' and b_code='" + bcode + "'");

                if (dr1.Length == 0)
                    hh = "";
                else
                    hh = dr1[0]["bitem"].ToString();

                temp2 = hh;
                dr2 = bmodel.Select("bitem='" + hh + "'");

                if (dr2[0]["a_code"].ToString() == "16" && temp1 != "")
                    s_id = true;
                else
                    s_id = false;
                //
                temp1 = temp2;

                temp = m % 2;
                if (temp != 0)
                {
                    if (s_id == false)
                    {
                        excelWokrsheet.Range["B" + excel_row + ""].NumberValue = m;  // 
                        excelWokrsheet.Range["C" + excel_row + ":O" + excel_row + ""].Merge();  // 
                        excelWokrsheet.Range["C" + excel_row + ""].Text = hh;
                        excelWokrsheet.Range["C" + excel_row + ""].Style.IndentLevel = 1;
                        excelWokrsheet.Range["C" + excel_row + ""].HorizontalAlignment = HorizontalAlignType.Left;
                        excelWokrsheet.Range["Q" + excel_row + ":AC" + excel_row + ""].Merge();  //
                        m++;
                    }
                }
                else
                {
                    if (s_id == false)
                    {
                        excelWokrsheet.Range["P" + excel_row + ""].NumberValue = m;
                        excelWokrsheet.Range["Q" + excel_row + ""].Text = hh;
                        excelWokrsheet.Range["Q" + excel_row + ""].Style.IndentLevel = 1;
                        excelWokrsheet.Range["Q" + excel_row + ""].HorizontalAlignment = HorizontalAlignType.Left;
                        excel_row += 1;
                        m++;
                    }
                }
            }
            temp = m % 2;
            if (temp != 0)
                excel_row -= 1;

            myRead.Close();
            DBConn.Close();
            excelWokrsheet.Range["B" + start_row + ":B" + excel_row + ""].Style.Font.FontName = "맑은 고딕";
            excelWokrsheet.Range["B" + start_row + ":B" + excel_row + ""].Style.Font.Size = 9;
            excelWokrsheet.Range["B" + start_row + ":B" + excel_row + ""].HorizontalAlignment = HorizontalAlignType.Center;
            excelWokrsheet.Range["P" + start_row + ":P" + excel_row + ""].Style.Font.FontName = "맑은 고딕";
            excelWokrsheet.Range["P" + start_row + ":P" + excel_row + ""].Style.Font.Size = 9;
            excelWokrsheet.Range["P" + start_row + ":P" + excel_row + ""].HorizontalAlignment = HorizontalAlignType.Center;

            excelWokrsheet.Range["B" + start_row + ":AC" + excel_row + ""].Style.Borders[BordersLineType.EdgeTop].Color = Color.Black;
            excelWokrsheet.Range["B" + start_row + ":AC" + excel_row + ""].Style.Borders[BordersLineType.EdgeTop].LineStyle = LineStyleType.Hair;
            excelWokrsheet.Range["B" + start_row + ":AC" + excel_row + ""].Style.Borders[BordersLineType.EdgeBottom].Color = Color.Black;
            excelWokrsheet.Range["B" + start_row + ":AC" + excel_row + ""].Style.Borders[BordersLineType.EdgeBottom].LineStyle = LineStyleType.Hair;
            excelWokrsheet.Range["B" + start_row + ":AC" + excel_row + ""].Style.Borders[BordersLineType.EdgeLeft].Color = Color.Black;
            excelWokrsheet.Range["B" + start_row + ":AC" + excel_row + ""].Style.Borders[BordersLineType.EdgeLeft].LineStyle = LineStyleType.Hair;
            excelWokrsheet.Range["B" + start_row + ":AC" + excel_row + ""].Style.Borders[BordersLineType.EdgeRight].Color = Color.Black;
            excelWokrsheet.Range["B" + start_row + ":AC" + excel_row + ""].Style.Borders[BordersLineType.EdgeRight].LineStyle = LineStyleType.Hair;


            excelWokrsheet.Range["B" + start_row + ":AC" + start_row + ""].Style.Borders[BordersLineType.EdgeTop].Color = Color.Black;
            excelWokrsheet.Range["B" + start_row + ":AC" + start_row + ""].Style.Borders[BordersLineType.EdgeTop].LineStyle = LineStyleType.Thin;
            excelWokrsheet.Range["B" + excel_row + ":AC" + excel_row + ""].Style.Borders[BordersLineType.EdgeBottom].Color = Color.Black;
            excelWokrsheet.Range["B" + excel_row + ":AC" + excel_row + ""].Style.Borders[BordersLineType.EdgeBottom].LineStyle = LineStyleType.Thin;
            excelWokrsheet.Range["B" + start_row + ":B" + excel_row + ""].Style.Borders[BordersLineType.EdgeLeft].Color = Color.Black;
            excelWokrsheet.Range["B" + start_row + ":B" + excel_row + ""].Style.Borders[BordersLineType.EdgeLeft].LineStyle = LineStyleType.Thin;
            excelWokrsheet.Range["AC" + start_row + ":AC" + excel_row + ""].Style.Borders[BordersLineType.EdgeRight].Color = Color.Black;
            excelWokrsheet.Range["AC" + start_row + ":AC" + excel_row + ""].Style.Borders[BordersLineType.EdgeRight].LineStyle = LineStyleType.Thin;
            
        }

        private void print_company()
        {
            excel_row += 2;
            excelWokrsheet.Range["B" + excel_row + ""].Text = "■ 인쇄업체 정보";
            excelWokrsheet.Range["B" + excel_row + ""].Style.Font.FontName = "맑은 고딕";
            excelWokrsheet.Range["B" + excel_row + ""].Style.Font.Size = 11;
            excelWokrsheet.Range["B" + excel_row + ""].Style.Font.IsBold = true;
            excel_row += 1;
            int start_row = excel_row;

            excelWokrsheet.Range["B" + excel_row + ":E" + excel_row + ""].Merge();  // 
            excelWokrsheet.Range["B" + excel_row + ""].Text = "업체명";
            excelWokrsheet.Range["B" + excel_row + ""].HorizontalAlignment = HorizontalAlignType.Center;
            excelWokrsheet.Range["F" + excel_row + ":K" + excel_row + ""].Merge();  // 
            excelWokrsheet.Range["F" + excel_row + ""].Text = prn_company;
            excelWokrsheet.Range["F" + excel_row + ""].Style.IndentLevel = 1;
            excelWokrsheet.Range["F" + excel_row + ""].HorizontalAlignment = HorizontalAlignType.Left;

            excelWokrsheet.Range["L" + excel_row + ":O" + excel_row + ""].Merge();  // 
            excelWokrsheet.Range["L" + excel_row + ""].Text = "T E L";
            excelWokrsheet.Range["L" + excel_row + ""].HorizontalAlignment = HorizontalAlignType.Center;
            excelWokrsheet.Range["P" + excel_row + ":T" + excel_row + ""].Merge();  // 
            excelWokrsheet.Range["P" + excel_row + ""].Text = prn_tel;
            excelWokrsheet.Range["P" + excel_row + ""].Style.IndentLevel = 1;
            excelWokrsheet.Range["P" + excel_row + ""].HorizontalAlignment = HorizontalAlignType.Left;

            excelWokrsheet.Range["U" + excel_row + ":X" + excel_row + ""].Merge();  // 
            excelWokrsheet.Range["U" + excel_row + ""].Text = "H . P";
            excelWokrsheet.Range["U" + excel_row + ""].HorizontalAlignment = HorizontalAlignType.Center;
            excelWokrsheet.Range["Y" + excel_row + ":AC" + excel_row + ""].Merge();  // 
            excelWokrsheet.Range["Y" + excel_row + ""].Text = prn_hp;
            excelWokrsheet.Range["Y" + excel_row + ""].Style.IndentLevel = 1;
            excelWokrsheet.Range["Y" + excel_row + ""].HorizontalAlignment = HorizontalAlignType.Left;
            excel_row += 1;

            excelWokrsheet.Range["B" + excel_row + ":E" + excel_row + ""].Merge();  // 
            excelWokrsheet.Range["B" + excel_row + ""].Text = "주소";
            excelWokrsheet.Range["B" + excel_row + ""].HorizontalAlignment = HorizontalAlignType.Center;
            excelWokrsheet.Range["F" + excel_row + ":AC" + excel_row + ""].Merge();  // 
            excelWokrsheet.Range["F" + excel_row + ""].Text = prn_addr;
            excelWokrsheet.Range["F" + excel_row + ""].Style.IndentLevel = 1;
            excelWokrsheet.Range["F" + excel_row + ""].HorizontalAlignment = HorizontalAlignType.Left;

            excelWokrsheet.Range["B" + start_row + ":AC" + excel_row + ""].Style.Font.FontName = "맑은 고딕";
            excelWokrsheet.Range["B" + start_row + ":AC" + excel_row + ""].Style.Font.Size = 9;
            

            excelWokrsheet.Range["B" + start_row + ":AC" + excel_row + ""].Style.Borders[BordersLineType.EdgeTop].Color = Color.Black;
            excelWokrsheet.Range["B" + start_row + ":AC" + excel_row + ""].Style.Borders[BordersLineType.EdgeTop].LineStyle = LineStyleType.Hair;
            excelWokrsheet.Range["B" + start_row + ":AC" + excel_row + ""].Style.Borders[BordersLineType.EdgeBottom].Color = Color.Black;
            excelWokrsheet.Range["B" + start_row + ":AC" + excel_row + ""].Style.Borders[BordersLineType.EdgeBottom].LineStyle = LineStyleType.Hair;
            excelWokrsheet.Range["B" + start_row + ":AC" + excel_row + ""].Style.Borders[BordersLineType.EdgeLeft].Color = Color.Black;
            excelWokrsheet.Range["B" + start_row + ":AC" + excel_row + ""].Style.Borders[BordersLineType.EdgeLeft].LineStyle = LineStyleType.Hair;
            excelWokrsheet.Range["B" + start_row + ":AC" + excel_row + ""].Style.Borders[BordersLineType.EdgeRight].Color = Color.Black;
            excelWokrsheet.Range["B" + start_row + ":AC" + excel_row + ""].Style.Borders[BordersLineType.EdgeRight].LineStyle = LineStyleType.Hair;


            excelWokrsheet.Range["B" + start_row + ":AC" + start_row + ""].Style.Borders[BordersLineType.EdgeTop].Color = Color.Black;
            excelWokrsheet.Range["B" + start_row + ":AC" + start_row + ""].Style.Borders[BordersLineType.EdgeTop].LineStyle = LineStyleType.Thin;
            excelWokrsheet.Range["B" + excel_row + ":AC" + excel_row + ""].Style.Borders[BordersLineType.EdgeBottom].Color = Color.Black;
            excelWokrsheet.Range["B" + excel_row + ":AC" + excel_row + ""].Style.Borders[BordersLineType.EdgeBottom].LineStyle = LineStyleType.Thin;
            excelWokrsheet.Range["B" + start_row + ":B" + excel_row + ""].Style.Borders[BordersLineType.EdgeLeft].Color = Color.Black;
            excelWokrsheet.Range["B" + start_row + ":B" + excel_row + ""].Style.Borders[BordersLineType.EdgeLeft].LineStyle = LineStyleType.Thin;
            excelWokrsheet.Range["AC" + start_row + ":AC" + excel_row + ""].Style.Borders[BordersLineType.EdgeRight].Color = Color.Black;
            excelWokrsheet.Range["AC" + start_row + ":AC" + excel_row + ""].Style.Borders[BordersLineType.EdgeRight].LineStyle = LineStyleType.Thin;

            excel_row += 3;

            start_row = excel_row;
            excelWokrsheet.Range["B" + excel_row + ""].Text = "※ 상기 출력의뢰서를 계약서로 간주 합니다.";
            excel_row += 1;
            excelWokrsheet.Range["B" + excel_row + ""].Text = "※ 출력의뢰시 최종PDF 교정을 확인하셔야 CTP출력이 진행됩니다.";
            excel_row += 1;
            excelWokrsheet.Range["B" + excel_row + ""].Text = "※ 최종 PDF 교정을 확인하지 않은 사고는 책임을 지지 않습니다.";
            excel_row += 1;
            excelWokrsheet.Range["B" + excel_row + ""].Text = "※ CTP판은 인쇄가 끝난후 이모션CTP에서 회수합니다.";

            excelWokrsheet.Range["B" + start_row + ":B" + excel_row + ""].Style.Font.FontName = "굴림";
            excelWokrsheet.Range["B" + start_row + ":B" + excel_row + ""].Style.Font.Size = 11;
            excelWokrsheet.Range["B" + start_row + ":B" + excel_row + ""].Style.Font.IsBold = true;
        }
    }
    public class dt
    {
        public static void make(string db_con, DataTable dt_name, string cQuery)
        {
            var DBCons = new MySqlConnection(db_con);
            DBCons.Open();
            dt_name.Rows.Clear();
            MySqlDataAdapter returnVal1 = new MySqlDataAdapter(cQuery, DBCons);
            returnVal1.Fill(dt_name);
            returnVal1.Dispose();
            DBCons.Close();
        }
    }
}

