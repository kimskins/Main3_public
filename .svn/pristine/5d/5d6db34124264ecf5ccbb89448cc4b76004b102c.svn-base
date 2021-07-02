using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Security;
using System.Security.Cryptography;
using System.Windows.Forms;
using System.Net.NetworkInformation;
using System.Data;
using System.Drawing;
using System.Management;
using System.Reflection;
using System.ComponentModel;
using Excel = Microsoft.Office.Interop.Excel;
using System.Runtime.InteropServices;
using MySql.Data.MySqlClient;
using System.Diagnostics;
using System.Net;
using System.Net.Mail;
using System.Collections.Specialized;

namespace Dukyou3
{
    public class util
    {
        public static bool RunExe(string RenExePath)  //메세지 전송
        {
            bool retb = false;
            try
            {
                System.Diagnostics.ProcessStartInfo psi = new System.Diagnostics.ProcessStartInfo();
                psi.Verb = "open";
                psi.FileName = RenExePath;//  

                psi.UseShellExecute = true;
                System.Diagnostics.Process.Start(psi);
                retb = true;
            }
            catch { };
            return retb;
        }
        // 위 함수를 사용해서..
        // c:\xsms.exe s 아이디 암호 "내전화번호" "상대방에게표시될번호" "메세지내용" "time" "name1:010-0000-0000;이름:전화번호;" "MMS이미지경로"
        // 를  위 파라미터 함수로 전송하면 메세지나 이미지가 전송 될 겁니다.. --> 실행  util.RunExe("aaaa");
        public static void IsFormAlreadyOpen(Type FormType)
        {
            foreach (Form OpenForm in Application.OpenForms)
            {
                if (OpenForm.GetType() == FormType)
                {
                    OpenForm.Close();
                    return;
                }
            }
        }

        public static bool Con_DB_Open(ref MySqlConnection DB_Con)
        {
            try
            {
                DB_Con.Open();
            }
            catch
            {
                MessageBox.Show("서버 접속이 원할하지 않아 프로그램을 종료합니다.");
                Application.ExitThread();

                Environment.Exit(0);
                return false;
            }
            return true;
        }
    }
    //
    public struct Config  //프로그램 전체에서 사용하는 고정형자료
    {                                      //임시로 메인에서 테스트DB 구분하여 재정의함 

        public const string version = "2.000.04";
        public static string DB_con1 = ""; //Data Source=1.234.4.126;Database=dokyou1;User Id=root;Password=kss1270;allow zero datetime=yes";//공동서버
        public static string DB_con2 = ""; //Data Source=1.234.27.80;Database=dokyou1;User Id=root;Password=kss1270;allow zero datetime=yes";//이모션서버
        //public const string DB_conp = "Data Source=1.234.4.126;Database=post;User Id=kssmd;Password=kss1270;allow zero datetime=yes";//이모션서버
        public static string DB_conSms = "";//"Data Source=1.234.4.126;Database=sms;User Id=sms;Password=sms;character set=euckr;allow zero datetime=yes";//공동서버
        public static string DB_conp = "";//"Data Source=1.234.4.146;Database=kssmd;User Id=root;Password=kss_1270!@#;allow zero datetime=yes";//이모션서버
        public static string DB_conMacro = "";
        public static string DB_conMacro_sang = "";
        public static string Ftp_ip1 = "";// "1.234.4.146";   //ftp 주소
        public static string Ftp_ip2 = "";//"1.234.4.146";   //ftp 주소 
        public static string Ftp_ip_sms = "";//"1.234.4.126";   //ftp sms주소(로컬서버)
        public static string DB_name = "Pera";
        public static string DB_con3 = "Data Source=175.207.12.133;Database=main_db;User Id=root;Password=sql_super4548;allow zero datetime=yes";//이모션 main_db
        public static string Ftp_id_sms = "";//"sms";   //ftp sms주소(로컬서버)
        public static string Ftp_id1 = "";//"beta2";        //ftp 아이디1
        public static string Ftp_id2 = "";//"beta2";        //ftp 아이디2

        public static string Ftp_pw1 = "";//"kss1270";      //ftp 암호1
        public static string Ftp_pw2 = "";// "kss1270";      //ftp 암호2


        public static string p_no   = "";             //전역변수 개념 사용가능
        public static string temp1  = "";             //전역변수 개념 임시사용하는 변수1(별지싸이즈, )
        public static string temp2  = "";             //전역변수 개념 임시사용하는 변수2(국.46,)
        public static string temp3  = "";             //전역변수 개념 임시사용하는 변수3(종이절수,)
        public static string temp4 = "";              //전역변수 개념 임시사용하는 변수4(M_종이싸이즈)
        public static string temp5 = "";              //전역변수 개념 임시사용하는 변수5(M_kook)
        public static string temp6 = "";              //전역변수 개념 임시사용하는 변수6(m_juldu)
        public static string temp7 = "";              //전역변수 개념 임시사용하는 변수7(Link)정규격,비규격,재단Sz
        public static int tools_bottom = 0;           //toolStrip1 아래수치
        public static bool tem_b = false;             //전역사용가능 변수(bool)
        public static string tem_c = "";              //전역사용가능 변수(string)
        public static string[] paper = new string[10];//종이선택시 사용하는 전역변수 
        public static DataTable m_dtable = new DataTable(); //종이 테이블
        public static Form ff;
        public static string DB_id = "";  //임시로 테스트 자료 사용하기 문자
        public static DataTable s_dat = new DataTable();    //전역사용 절 테이블(종이선택에서 사용함)

        public const string addr_tail = "c";        // c 는 구주소, d는 신주소   ex) string tmp_tail = "addr_"+config.addr_tail;
        public const string addr_other = "old";     // old는 구주소, new는 신주소.   ex) string tmp_other = "addr_other_"+config.addr_other;
    }

    public struct User
    {
        public static string Cli_name = "";
    }

    
    public class main_info
    {
        public static Boolean check = false;
        public static int index;
        public static string tem1;
        public static string tem2;
        public static string tem3;
    }
    //
    public class CryptorEngine
    {
        /// <summary>
        /// Encrypt a string using dual encryption method. Return a encrypted cipher Text
        /// </summary>
        /// <param name="toEncrypt">string to be encrypted</param>
        /// <param name="useHashing">use hashing? send to for extra secirity</param>
        /// <returns></returns>
        public static string Encrypt(string toEncrypt, bool useHashing)
        {
            if (toEncrypt.Trim() == "")
                return "";
            byte[] keyArray;
            byte[] toEncryptArray = UTF8Encoding.UTF8.GetBytes(toEncrypt);

            //System.Configuration.AppSettingsReader settingsReader = new AppSettingsReader();
            // Get the key from config file
            string key = "kssmd";// (string)settingsReader.GetValue("SecurityKey", typeof(String));
            //System.Windows.Forms.MessageBox.Show(key);
            if (useHashing)
            {
                MD5CryptoServiceProvider hashmd5 = new MD5CryptoServiceProvider();
                keyArray = hashmd5.ComputeHash(UTF8Encoding.UTF8.GetBytes(key));
                hashmd5.Clear();
            }
            else
                keyArray = UTF8Encoding.UTF8.GetBytes(key);

            TripleDESCryptoServiceProvider tdes = new TripleDESCryptoServiceProvider();
            tdes.Key = keyArray;
            tdes.Mode = CipherMode.ECB;
            tdes.Padding = PaddingMode.PKCS7;

            ICryptoTransform cTransform = tdes.CreateEncryptor();
            byte[] resultArray = cTransform.TransformFinalBlock(toEncryptArray, 0, toEncryptArray.Length);
            tdes.Clear();
            return Convert.ToBase64String(resultArray, 0, resultArray.Length);
        }
        /// <summary>
        /// DeCrypt a string using dual encryption method. Return a DeCrypted clear string
        /// </summary>
        /// <param name="cipherString">encrypted string</param>
        /// <param name="useHashing">Did you use hashing to encrypt this data? pass true is yes</param>
        /// <returns></returns>
        public static string Decrypt(string cipherString, bool useHashing)
        {
            if (cipherString.Trim() == "")
                return "";
            byte[] keyArray;
            byte[] toEncryptArray = Convert.FromBase64String(cipherString);

            //System.Configuration.AppSettingsReader settingsReader = new AppSettingsReader();
            //Get your key from config file to open the lock!
            string key = "kssmd";// (string)settingsReader.GetValue("SecurityKey", typeof(String));

            if (useHashing)
            {
                MD5CryptoServiceProvider hashmd5 = new MD5CryptoServiceProvider();
                keyArray = hashmd5.ComputeHash(UTF8Encoding.UTF8.GetBytes(key));
                hashmd5.Clear();
            }
            else
                keyArray = UTF8Encoding.UTF8.GetBytes(key);

            TripleDESCryptoServiceProvider tdes = new TripleDESCryptoServiceProvider();
            tdes.Key = keyArray;
            tdes.Mode = CipherMode.ECB;
            tdes.Padding = PaddingMode.PKCS7;

            ICryptoTransform cTransform = tdes.CreateDecryptor();
            byte[] resultArray = cTransform.TransformFinalBlock(toEncryptArray, 0, toEncryptArray.Length);

            tdes.Clear();
            return UTF8Encoding.UTF8.GetString(resultArray);
        }
    }
    //
    public class Make_table
    {
        public static void make()
        {
            string subPath = @".\data"; // your code goes here

            bool exists = System.IO.Directory.Exists(subPath);

            if (!exists)
                System.IO.Directory.CreateDirectory(subPath);

            var DBConn = new MySqlConnection(Config.DB_con1);
            DBConn.Open();
            string tex = "";
            string cQuery = "";
            //
            System.IO.StreamWriter objSaveFile2 = new System.IO.StreamWriter(@".\data\hang_m.dat");  //hang_manage 테이블
            tex = "";
            cQuery = " select * from hang_manage order by class,no";  //
            var cmd = new MySqlCommand(cQuery, DBConn);
            var myRead = cmd.ExecuteReader();
            while (myRead.Read())
            {
                tex = myRead["code1"].ToString() + "#" + myRead["hang"].ToString() + "#" + myRead["class"].ToString() + "#" + myRead["code2"].ToString() + "#" + myRead["abc_code"].ToString();
                objSaveFile2.Write(CryptorEngine.Encrypt(tex, true) + "\r\n");
            }
            myRead.Close();
            objSaveFile2.Close();
            objSaveFile2.Dispose();
            //
            System.IO.StreamWriter objSaveFile3 = new System.IO.StreamWriter(@".\data\jebona.dat");
            tex = "";
            cQuery = "select a.*, b.hang as a4 from (select a.*, b.bitem as a11s from (select a.*, b.bitem as a2s FROM C_jebon_prn as a left outer join";
            cQuery += " C_bmodel as b on b.a_code='16' and a.a2=b.b_code) as a left outer join C_bmodel as b on b.a_code='08'";
            cQuery += " and a.a11=b.b_code ) as a left outer join (select * from hang_manage where class = '항목') as b on a.a5=b.code1 where a.row_id > 0";  //분개창 각 항목에 대한 자료파일 
            cmd = new MySqlCommand(cQuery, DBConn);
            myRead = cmd.ExecuteReader();
            while (myRead.Read())
            {
                tex = myRead["a1"].ToString() + "#" + myRead["a2"].ToString() + "#" + myRead["a3"].ToString() + "#" + myRead["a4"].ToString()
                     + "#" + myRead["a5"].ToString() + "#" + myRead["a6"].ToString() + "#" + myRead["a7"].ToString() + "#" + myRead["a8"].ToString()
                     + "#" + myRead["a9"].ToString() + "#" + myRead["a10"].ToString() + "#" + myRead["a11"].ToString() + "#" + myRead["a12"].ToString()
                     + "#" + myRead["a13"].ToString() + "#" + myRead["a14"].ToString() + "#" + myRead["a15"].ToString() + "#" + myRead["a16"].ToString()
                     + "#" + myRead["a17"].ToString() + "#" + myRead["a18"].ToString() + "#" + myRead["a19"].ToString()
                     + "#" + myRead["a20"].ToString() + "#" + myRead["a20a"].ToString() + "#" + myRead["a20b"].ToString() + "#" + myRead["a20c"].ToString()
                     + "#" + myRead["a20d"].ToString() + "#" + myRead["a21"].ToString() + "#" + myRead["a22"].ToString() + "#" + myRead["a23"].ToString()
                     + "#" + myRead["a24"].ToString() + "#" + myRead["a25"].ToString() + "#" + myRead["a26"].ToString() + "#" + myRead["a27"].ToString()
                     + "#" + myRead["a28"].ToString() + "#" + myRead["a29"].ToString() + "#" + myRead["a30"].ToString()
                     + "#" + myRead["a31"].ToString() + "#" + myRead["a32"].ToString() + "#" + myRead["a33"].ToString()
                     + "#" + myRead["a34"].ToString() + "#" + myRead["a35"].ToString() + "#" + myRead["a36"].ToString();
                objSaveFile3.Write(CryptorEngine.Encrypt(tex, true) + "\r\n");
            }
            myRead.Close();
            objSaveFile3.Close();
            objSaveFile3.Dispose();
            //
            System.IO.StreamWriter objSaveFile4 = new System.IO.StreamWriter(@".\data\jebonb.dat");
            tex = "";
            cQuery = " select * FROM C_bungae_d";  //코드별 분개창에 뿌려줄 항목이 있는자료
            cmd = new MySqlCommand(cQuery, DBConn);
            myRead = cmd.ExecuteReader();
            while (myRead.Read())
            {
                tex = myRead["a_1"].ToString() + "#" + myRead["b_1"].ToString() + "#" + myRead["c_1"].ToString() + "#" + myRead["d"].ToString()
                     + "#" + myRead["e"].ToString() + "#" + myRead["f"].ToString() + "#" + myRead["g"].ToString() + "#" + myRead["h"].ToString()
                     + "#" + myRead["i"].ToString() + "#" + myRead["kong_sub"].ToString();
                objSaveFile4.Write(CryptorEngine.Encrypt(tex, true) + "\r\n");
            }
            myRead.Close();
            objSaveFile4.Close();
            objSaveFile4.Dispose();
            //
            System.IO.StreamWriter objSaveFile5 = new System.IO.StreamWriter(@".\data\jebon_dt.dat");  //prn_dt.dat 포함
            tex = "";
            cQuery = " select * from C_bmodel where a_code='08' or a_code='16' order by no";  //
            cmd = new MySqlCommand(cQuery, DBConn);
            myRead = cmd.ExecuteReader();
            while (myRead.Read())
            {
                tex = myRead["b_code"].ToString() + "#" + myRead["bitem"].ToString() + "#" + myRead["a_code"].ToString() + "#" + myRead["go"].ToString();
                objSaveFile5.Write(CryptorEngine.Encrypt(tex, true) + "\r\n");
            }
            myRead.Close();
            objSaveFile5.Close();
            objSaveFile5.Dispose();
            //
            DBConn.Close();
        }
    }
    //
    public class MyHeader : SourceGrid.Cells.ColumnHeader //Sort Enable
    {
        public MyHeader(object value)
            : base(value)
        {
            DevAge.Drawing.BorderLine border_l = new DevAge.Drawing.BorderLine(Color.FromArgb(220, 220, 220), 0);
            DevAge.Drawing.BorderLine border_r = new DevAge.Drawing.BorderLine(Color.FromArgb(220, 220, 220), 0);
            DevAge.Drawing.BorderLine top = new DevAge.Drawing.BorderLine(Color.FromArgb(220, 220, 220), 1);
            DevAge.Drawing.BorderLine bottom = new DevAge.Drawing.BorderLine(Color.FromArgb(220, 220, 220), 1);
            DevAge.Drawing.RectangleBorder border1 = new DevAge.Drawing.RectangleBorder(top, bottom, border_r, border_l);
            //Header Row
            SourceGrid.Cells.Views.ColumnHeader view = new SourceGrid.Cells.Views.ColumnHeader();
            view.Font = new Font(FontFamily.GenericSansSerif, 8, FontStyle.Regular);
            view.Border = border1;
            view.TextAlignment = DevAge.Drawing.ContentAlignment.MiddleCenter;
            View = view;
            AutomaticSortEnabled = true;
        }
    }

    public class MyHeader1 : SourceGrid.Cells.ColumnHeader  //Sort Disable
    {
        public MyHeader1(object value)
            : base(value)
        {
            DevAge.Drawing.BorderLine border_l = new DevAge.Drawing.BorderLine(Color.FromArgb(220, 220, 220), 0);
            DevAge.Drawing.BorderLine border_r = new DevAge.Drawing.BorderLine(Color.FromArgb(220, 220, 220), 0);
            DevAge.Drawing.BorderLine top = new DevAge.Drawing.BorderLine(Color.FromArgb(220, 220, 220), 1);
            DevAge.Drawing.BorderLine bottom = new DevAge.Drawing.BorderLine(Color.FromArgb(220, 220, 220), 1);
            DevAge.Drawing.RectangleBorder border1 = new DevAge.Drawing.RectangleBorder(top, bottom, border_r, border_l);
            //Header Row
            SourceGrid.Cells.Views.ColumnHeader view = new SourceGrid.Cells.Views.ColumnHeader();
            view.Font = new Font(FontFamily.GenericSansSerif, 8, FontStyle.Regular);
            view.Border = border1;
            view.TextAlignment = DevAge.Drawing.ContentAlignment.MiddleCenter;
            View = view;
            AutomaticSortEnabled = false;
        }
    }
    public class MyHeader2 : SourceGrid.Cells.ColumnHeader  //Sort Disable 회색
    {
        public MyHeader2(object value)
            : base(value)
        {
            DevAge.Drawing.BorderLine border_l = new DevAge.Drawing.BorderLine(Color.FromArgb(220, 220, 220), 0);
            DevAge.Drawing.BorderLine border_r = new DevAge.Drawing.BorderLine(Color.FromArgb(220, 220, 220), 0);
            DevAge.Drawing.BorderLine top = new DevAge.Drawing.BorderLine(Color.FromArgb(220, 220, 220), 0);
            DevAge.Drawing.BorderLine bottom = new DevAge.Drawing.BorderLine(Color.FromArgb(220, 220, 220), 0);
            DevAge.Drawing.RectangleBorder border1 = new DevAge.Drawing.RectangleBorder(top, bottom, border_r, border_l);
            // 
            DevAge.Drawing.VisualElements.ColumnHeader backHeader = new DevAge.Drawing.VisualElements.ColumnHeader();
            backHeader.BackColor = Color.AliceBlue;
            //Header Row
            SourceGrid.Cells.Views.ColumnHeader view = new SourceGrid.Cells.Views.ColumnHeader();
            view.Background = backHeader;
            view.ForeColor = Color.Black;
            view.Font = new Font(FontFamily.GenericSansSerif, 8, FontStyle.Regular);
            view.Border = border1;
            view.TextAlignment = DevAge.Drawing.ContentAlignment.MiddleCenter;
            View = view;
            AutomaticSortEnabled = false;
        }
    }
    //
    public class cell_d
    {
        public SourceGrid.Cells.Views.Cell center_cell_bold;    //중앙셀 bold black
        public SourceGrid.Cells.Views.Cell center_cell;   //중앙셀
        public SourceGrid.Cells.Views.Cell center_cellr;  //중앙셀r
        public SourceGrid.Cells.Views.Cell center_cellb;  //중앙셀b
        public SourceGrid.Cells.Views.Cell center_celly;  //중앙셀y
        public SourceGrid.Cells.Views.Cell left_cell;     //좌측셀
        public SourceGrid.Cells.Views.Cell left_cell_bold;     //좌측셀 bold black
        public SourceGrid.Cells.Views.Cell left_cellr;    //좌측셀r
        public SourceGrid.Cells.Views.Cell left_cellb;    //좌측셀b
        public SourceGrid.Cells.Views.Cell left_celly;    //좌측셀y
        public SourceGrid.Cells.Views.Cell int_cell;      //우측셀
        public SourceGrid.Cells.Views.Cell int_cellr;     //우측셀r
        public SourceGrid.Cells.Views.Cell int_cellb;     //우측셀b
        public SourceGrid.Cells.Views.Cell int_celly;     //우측셀y
        // 
        public SourceGrid.Cells.Views.Cell int_cell_r;      //우측셀  적색글자
        public SourceGrid.Cells.Views.Cell int_cellr_r;     //우측셀r  적색글자
        public SourceGrid.Cells.Views.Cell int_cellb_r;     //우측셀b  적색글자
        public SourceGrid.Cells.Views.Cell int_celly_r;     //우측셀y  적색글자
        //
        public SourceGrid.Cells.Views.Cell center_cell_r;      //우측셀  적색글자
        public SourceGrid.Cells.Views.Cell center_cellr_r;     //우측셀r  적색글자
        public SourceGrid.Cells.Views.Cell center_cellb_r;     //우측셀b  적색글자
        public SourceGrid.Cells.Views.Cell center_celly_r;     //우측셀y  적색글자
        //
        public SourceGrid.Cells.Views.Cell viewImage;     //그림보기(중앙)
        public SourceGrid.Cells.Editors.TextBox disable_cell; //수정불가
        public SourceGrid.Cells.Editors.TextBoxNumeric int_editor = new SourceGrid.Cells.Editors.TextBoxNumeric(typeof(int));
        public SourceGrid.Cells.Editors.TextBoxNumeric decimal_editor = new SourceGrid.Cells.Editors.TextBoxNumeric(typeof(decimal));
        public SourceGrid.Cells.Editors.TextBoxNumeric double_editor = new SourceGrid.Cells.Editors.TextBoxNumeric(typeof(double));
        //
        public SourceGrid.Cells.Editors.TextBoxNumeric int_editor_disable = new SourceGrid.Cells.Editors.TextBoxNumeric(typeof(int));
        public SourceGrid.Cells.Editors.TextBoxNumeric decimal_editor_disable = new SourceGrid.Cells.Editors.TextBoxNumeric(typeof(decimal));
        public SourceGrid.Cells.Editors.TextBoxNumeric double_editor_disable = new SourceGrid.Cells.Editors.TextBoxNumeric(typeof(double));
        //
        public cell_d()
        {
            center_cell_bold = new SourceGrid.Cells.Views.Cell();
            center_cell_bold.TextAlignment = DevAge.Drawing.ContentAlignment.MiddleCenter;
            center_cell_bold.Font = new Font("", 9, FontStyle.Bold);
            center_cell = new SourceGrid.Cells.Views.Cell();
            center_cell.TextAlignment = DevAge.Drawing.ContentAlignment.MiddleCenter;
            center_cellr = new SourceGrid.Cells.Views.Cell();
            center_cellr.TextAlignment = DevAge.Drawing.ContentAlignment.MiddleCenter;
            center_cellr.BackColor = Color.FromArgb(255, 250, 250);
            center_cellb = new SourceGrid.Cells.Views.Cell();
            center_cellb.TextAlignment = DevAge.Drawing.ContentAlignment.MiddleCenter;
            center_cellb.BackColor = Color.FromArgb(240, 248, 255);
            center_celly = new SourceGrid.Cells.Views.Cell();
            center_celly.TextAlignment = DevAge.Drawing.ContentAlignment.MiddleCenter;
            center_celly.BackColor = Color.FromArgb(255, 255, 0);
            //
            left_cell_bold = new SourceGrid.Cells.Views.Cell();
            left_cell_bold.TextAlignment = DevAge.Drawing.ContentAlignment.MiddleLeft;
            left_cell_bold.Font = new Font("", 9, FontStyle.Bold);
            left_cell = new SourceGrid.Cells.Views.Cell();
            left_cell.TextAlignment = DevAge.Drawing.ContentAlignment.MiddleLeft;
            left_cellr = new SourceGrid.Cells.Views.Cell();
            left_cellr.TextAlignment = DevAge.Drawing.ContentAlignment.MiddleLeft;
            left_cellr.BackColor = Color.FromArgb(255, 250, 250);
            left_cellb = new SourceGrid.Cells.Views.Cell();
            left_cellb.TextAlignment = DevAge.Drawing.ContentAlignment.MiddleLeft;
            left_cellb.BackColor = Color.FromArgb(240, 248, 255);
            left_celly = new SourceGrid.Cells.Views.Cell();
            left_celly.TextAlignment = DevAge.Drawing.ContentAlignment.MiddleLeft;
            left_celly.BackColor = Color.FromArgb(255, 255, 0);
            //
            int_cell = new SourceGrid.Cells.Views.Cell();
            int_cell.TextAlignment = DevAge.Drawing.ContentAlignment.MiddleRight;
            int_cellr = new SourceGrid.Cells.Views.Cell();
            int_cellr.TextAlignment = DevAge.Drawing.ContentAlignment.MiddleRight;
            int_cellr.BackColor = Color.FromArgb(255, 250, 250);
            int_cellb = new SourceGrid.Cells.Views.Cell();
            int_cellb.TextAlignment = DevAge.Drawing.ContentAlignment.MiddleRight;
            int_cellb.BackColor = Color.FromArgb(240, 248, 255);
            int_celly = new SourceGrid.Cells.Views.Cell();
            int_celly.TextAlignment = DevAge.Drawing.ContentAlignment.MiddleRight;
            int_celly.BackColor = Color.FromArgb(255, 255, 0);
            //
            int_cell_r = new SourceGrid.Cells.Views.Cell();
            int_cell_r.TextAlignment = DevAge.Drawing.ContentAlignment.MiddleRight;
            int_cell_r.ForeColor = Color.FromArgb(255, 0, 0);
            int_cellr_r = new SourceGrid.Cells.Views.Cell();
            int_cellr_r.TextAlignment = DevAge.Drawing.ContentAlignment.MiddleRight;
            int_cellr_r.BackColor = Color.FromArgb(255, 250, 250);
            int_cellr_r.ForeColor = Color.FromArgb(255, 0, 0);
            int_cellb_r = new SourceGrid.Cells.Views.Cell();
            int_cellb_r.TextAlignment = DevAge.Drawing.ContentAlignment.MiddleRight;
            int_cellb_r.BackColor = Color.FromArgb(240, 248, 255);
            int_cellb_r.ForeColor = Color.FromArgb(255, 0, 0);
            int_celly_r = new SourceGrid.Cells.Views.Cell();
            int_celly_r.TextAlignment = DevAge.Drawing.ContentAlignment.MiddleRight;
            int_celly_r.BackColor = Color.FromArgb(255, 255, 0);
            int_celly_r.ForeColor = Color.FromArgb(255, 0, 0);
            //
            center_cell_r = new SourceGrid.Cells.Views.Cell();
            center_cell_r.TextAlignment = DevAge.Drawing.ContentAlignment.MiddleCenter;
            center_cell_r.ForeColor = Color.FromArgb(255, 0, 0);
            center_cellr_r = new SourceGrid.Cells.Views.Cell();
            center_cellr_r.TextAlignment = DevAge.Drawing.ContentAlignment.MiddleCenter;
            center_cellr_r.BackColor = Color.FromArgb(255, 250, 250);
            center_cellr_r.ForeColor = Color.FromArgb(255, 0, 0);
            center_cellb_r = new SourceGrid.Cells.Views.Cell();
            center_cellb_r.TextAlignment = DevAge.Drawing.ContentAlignment.MiddleCenter;
            center_cellb_r.BackColor = Color.FromArgb(240, 248, 255);
            center_cellb_r.ForeColor = Color.FromArgb(255, 0, 0);
            center_celly_r = new SourceGrid.Cells.Views.Cell();
            center_celly_r.TextAlignment = DevAge.Drawing.ContentAlignment.MiddleCenter;
            center_celly_r.BackColor = Color.FromArgb(255, 255, 0);
            center_celly_r.ForeColor = Color.FromArgb(255, 0, 0);
            //
            viewImage = new SourceGrid.Cells.Views.Cell();
            viewImage.BackColor = Color.FromArgb(240, 248, 255);
            viewImage.ImageStretch = false;
            viewImage.ImageAlignment = DevAge.Drawing.ContentAlignment.MiddleCenter;
            //
            disable_cell = new SourceGrid.Cells.Editors.TextBox(typeof(string));  //수정불가
            disable_cell.EnableEdit = false;
            //
            int_editor.TypeConverter = new DevAge.ComponentModel.Converter.NumberTypeConverter(typeof(int), "N0");
            decimal_editor.TypeConverter = new DevAge.ComponentModel.Converter.NumberTypeConverter(typeof(decimal), "N3");
            double_editor.TypeConverter = new DevAge.ComponentModel.Converter.NumberTypeConverter(typeof(double), "N3");
            //
            int_editor_disable.TypeConverter = new DevAge.ComponentModel.Converter.NumberTypeConverter(typeof(int), "N0");
            int_editor_disable.EnableEdit = false;
            decimal_editor_disable.TypeConverter = new DevAge.ComponentModel.Converter.NumberTypeConverter(typeof(decimal), "N3");
            decimal_editor_disable.EnableEdit = false;
            double_editor_disable.TypeConverter = new DevAge.ComponentModel.Converter.NumberTypeConverter(typeof(double), "N3");
            double_editor_disable.EnableEdit = false;
            //
            int_editor.AllowNull = true;
            decimal_editor.AllowNull = true;
            double_editor.AllowNull = true;
        }
    }

    //
    public class Excel_convert
    {
        DataGridView dataGridView = new DataGridView();   // 그리드
        DataTable dataTable;
        SourceGrid.DataGrid dataGrid;
        SourceGrid.Grid SourceGrid;
        string GridType;

        int RowCount;
        int ColumnCount;

        public Excel_convert(DataGridView dgv)
        {
            dataGridView = dgv;
            RowCount = dataGridView.RowCount;
            ColumnCount = dataGridView.ColumnCount;
            GridType = "DataGridView";
        }

        public Excel_convert(DataTable dt, SourceGrid.DataGrid dg)
        {
            dataTable = dt;
            dataGrid = dg;
            RowCount = dataTable.Rows.Count;
            ColumnCount = dataTable.Columns.Count;
            GridType = "DataGrid";
        }

        public Excel_convert(SourceGrid.Grid SourceGrid, string null1, string null2)
        {
            this.SourceGrid = SourceGrid;
            RowCount = SourceGrid.Rows.Count;
            ColumnCount = SourceGrid.Columns.Count;
            GridType = "SourceGrid";
        }

        string HeaderText(int Index)
        {
            if (GridType.Equals("DataGridView"))
                return dataGridView.Columns[Index].HeaderText;
            else if (GridType.Equals("DataGrid"))
                return dataGrid.Columns[Index].HeaderCell.ToString();
            else if (GridType.Equals("SourceGrid"))
                return "";
            else
                return "";

        }

        string GetGridValue(int Row, int Column)
        {
            if (GridType.Equals("DataGridView"))
                return dataGridView.Rows[Row].Cells[Column].Value.ToString();
            else if (GridType.Equals("DataGrid"))
                return dataTable.Rows[Row][Column].ToString();
            else if (GridType.Equals("SourceGrid"))
                return SourceGrid[Row,Column].ToString();
            else
                return "";
        }

        public void Convert()
        {
            try
            {
                object missingType = Type.Missing;
                Excel.Application excelApp = new Microsoft.Office.Interop.Excel.Application();
                Excel.Workbook excelBook = excelApp.Workbooks.Add(missingType);
                Excel.Worksheet excelWokrsheet = (Excel.Worksheet)excelBook.Worksheets.Add(missingType, missingType, missingType, missingType);

                excelApp.Visible = true; //false(엑셀 안보이기)
                //excelApp.UserControl = true;
                excelWokrsheet.PrintPreview(true);
                //excelApp = (Excel.Application)

                for (int i = 0; i < RowCount; i++)
                {
                    for (int j = 0; j < ColumnCount; j++)
                    {
                        string sRowValue = string.Empty;

                        if (i == 0)
                        {
                            excelWokrsheet.Cells[1, j + 1] = HeaderText(j);
                        }

                        try
                        {
                            sRowValue = GetGridValue(i, j);
                            excelWokrsheet.Cells[i + 2, j + 1] = " " + sRowValue;
                        }
                        catch
                        {
                            sRowValue = "";
                        }
                    }
                }

                System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.Default;
                //excelBook.PrintOut(1, 1, 1, true, defaultPrinterName, false, 2, System.Reflection.Missing.Value);

            }
            catch (Exception ex)
            {
                string sMsg = ex.Message;
                System.Windows.Forms.MessageBox.Show("변환 실패 ( " + sMsg + " )");
            }
        }
    }
    public class get_multi
    {
        public static double[] book_weight(string[] m_db, string[,] grid1, string[,] grid2)   //책1권 무게 구함
        {
            string jebon_n = m_db[50];

            int opt_g = 0;  //옵션 가로
            int opt_s = 0;  //옵션 세로
            int opt_h = 0;  //옵션 높이
            // 
            if (!string.IsNullOrEmpty(m_db[57]))
                opt_g = Convert.ToInt32(m_db[57]); //가로
            if (!string.IsNullOrEmpty(m_db[58]))
                opt_s = Convert.ToInt32(m_db[58]); //세로
            if (!string.IsNullOrEmpty(m_db[59]))
                opt_h = Convert.ToInt32(m_db[59]); //높이
            //
            string[] axx = m_db[10].Split(new char[1] { '*' }); //도큐싸이즈
            int f_dq = Convert.ToInt32(axx[0]); //책싸이즈1(앞수)
            int r_dq = Convert.ToInt32(axx[1]); //책싸이즈2(뒤수)
            double wt = 0;   //해당 무게
            //
            double w_su = 0;  //무게
            double d_su = 0;  //두께
            // 
            for (int n = 0; n < grid2.GetLength(0); n++)  //
            {
                if (grid2[n, 0] == "" || grid2[n, 1] == "")  //두께계산(두께*2)
                    continue;
                d_su += Convert.ToDouble(grid2[n, 0]) * 2;
                //
                wt = Convert.ToDouble(grid2[n, 1]); //무게
                //
                if (grid2[n, 2] == "1")  //go 가 1 이면
                    w_su += wt;  // 나오는 무게만 더한다
                else if (grid2[n, 2] == "2")
                    w_su += wt * r_dq / 10;  //무게*도큐뒷수/10
                else if (grid2[n, 2] == "0") //
                {
                    if (jebon_n == "05")  //바인더 제본(옵션 가로*세로 / 100 * 무게)
                        w_su += (((opt_s + 5) * 2) + opt_g) * opt_h / 100 * wt; //
                    else if (jebon_n == "06")  //양장제본 (옵션 도뮤 앞수*뒷수*2/100*무게)
                        w_su += f_dq * r_dq * 2 / 100 * wt;//
                    else if (jebon_n == "04")  //스프링제본 (무게*도큐뒷수/10)
                    {
                        w_su += wt * r_dq / 10; // 스프링 무게 (무게 * 도큐 뒷수 / 10)  
                        //
                        if (m_db[55] != "3")    //싸바리 없음이 아니라면
                            w_su += f_dq * r_dq * 2 / 100 * wt; // 도큐 가로*세로*2/100*무게
                    }
                }
            }
            //내부 무게, 두께 구한다음
            if (jebon_n == "05")  //바인더 제본
            {
                f_dq = opt_s; //책싸이즈1(앞수)
                r_dq = opt_h; //책싸이즈2(뒤수)
            }
            else if (jebon_n == "10")  //탁상스프링 카렌다
            {
                f_dq = opt_g; //책싸이즈1(앞수)
                r_dq = opt_s + opt_h + 4; //책싸이즈2(뒤수)
            }
            //                    
            //
            string[] page = new string[2];
            //
            for (int n = 0; n < grid1.GetLength(0); n++)   // 
            {
                if (grid1[n, 0].Contains("*") && grid1[n, 1] != "")  //도큐싸이즈
                {
                    page = grid1[n, 0].Trim().Split(new char[1] { '*' });    //도큐싸이즈 분리
                    w_su += Convert.ToDouble(page[0]) * Convert.ToDouble(page[1]) / 1000000 * Convert.ToDouble(grid1[n, 1])
                            * Convert.ToDouble(grid1[n, 2]) / 2; //좌수*우수/백만*무게(weight)*페이지(page)/2
                }
            }
            double[] www = new double[2];
            www[0] = w_su; //무게
            www[1] = d_su; //두께
            //
            return www;
        }
        public static string total_jung(string busu, string[] db, string f_boonsu, string r_boonsu)   //
        {
            double total = 0;
            total = Convert.ToDouble(busu) / 500 / Convert.ToDouble(db[17]);  //부수/500/인쇄절수
            //
            if (db[22] != "")
                total = total / Convert.ToDouble(db[22]);  //판걸이 적용
            //
            if (f_boonsu.Contains("/"))
            {
                string[] mm = f_boonsu.Split(new char[1] { '/' });
                total = total * Convert.ToDouble(mm[0]) / Convert.ToDouble(mm[1]);
            }
            //
            if (r_boonsu.Contains("/"))
            {
                string[] mm = r_boonsu.Split(new char[1] { '/' });
                total = total * Convert.ToDouble(mm[0]) / Convert.ToDouble(mm[1]);
            }
            //
            return total.ToString();
        }

        public static string total_c(string pp)   //종이 싸이즈의/국,46/절수 구함
        {
            string total = "";
            int t_int = 0;
            string[] mm = pp.Split(new char[1] { '+' });
            for (int i = 0; i < mm.Length; i++)
                t_int += Convert.ToInt32(mm[i]);
            //
            total = t_int.ToString().Trim();
            //
            return total;
        }

        public static string[] get_don_fan(string[] n_db, int j_page, int boonsu, int dos1, int dos2)   //
        {
            string[] don = new string[2];
            int garo = Convert.ToInt32(n_db[37]); //전지 가로수
            int sero = Convert.ToInt32(n_db[43]); //전지 세로수
            //
            string[] tem1 = n_db[31].Split(new char[1] { '/' }); //하리자료(5항목)-> 기계구와이/종이구와이/판싸이즈/cip/dos(슬래시없는도수)
            //
            //양쪽 도수에 '0'이 있거나, 양쪽도수가 다르거나, 전지세로의 갯수가 홀수이면 하리돈땡은 검사하지 않는다.
            if (sero % 2 != 0)//---------------------------------------------------------------------총도수로 수정
            {
                if (boonsu % garo == 0)
                {
                    don[0] = "혼각계";
                    don[1] = "판공용";
                }
                else
                {
                    don[0] = "혼각계";
                    don[1] = "";
                }
            }
            else
            {
                if (sero % j_page == 0 && boonsu % garo == 0)  //c
                {
                    don[0] = "하리돈땡";
                    don[1] = "판공용";
                }
                else if (boonsu % sero == 0)          //d
                {
                    don[0] = "하리돈땡";
                    don[1] = "";
                }
                else if (boonsu % garo == 0)          //e
                {
                    don[0] = "혼각계";
                    don[1] = "판공용";
                }
                else
                {
                    don[0] = "혼각계";
                    don[1] = "";
                }
            }
            //
            return don;
        }
        //--------------------------------------------------------------------------------
        public static string get_don(string[] n_db, int op)   //m_db(복합자료) 가지고 하리돈땡,구와이돈땡 구함
        {
            string don = "";
            int m_gy = 0;
            string[] tem1 = n_db[31].Split(new char[1] { '/' }); //하리자료(5항목)-> 기계구와이/종이구와이/판싸이즈/cip/dos(슬래시없는도수)
            //

            if (op == 1)
            {
                if (n_db[6] == "0")  //하리 추가수가 없다면
                {
                    if (Convert.ToInt32(n_db[37]) % 2 == 0)  //가로갯수가 짝수이면
                        don = "하리돈땡";
                    else
                    {
                        if (Convert.ToInt32(n_db[43]) % 2 == 0)  //세로갯수가 짝수이면
                        {
                            if (n_db[9] == "일반" || n_db[9] == "양면")
                            {
                                string[] tem2 = new string[4];
                                if (tem1[1] != "")
                                    tem2 = tem1[1].Split(new char[1] { '+' });  //종이 구와이의 구분 + 로 구분
                                else
                                    tem2[0] = "0";
                                //
                                m_gy = Convert.ToInt32(tem2[0]) * 2; //기계구와이 * 2
                            }
                            else
                                m_gy = 0;
                            //
                            if ((Convert.ToInt32(n_db[44]) + Convert.ToInt32(n_db[45])) < m_gy)  //세로여분1 + 세로여분2 < 기계구와이 보다 크다면 
                                don = "혼각계";
                            else
                                don = "구와이돈땡";
                        }
                        else
                            don = "혼각계";
                    }
                }
                else               //하리 추가수가 있다면
                    don = "혼각계";
            }
            else                   //if (op == 2)    //닷찌형 인쇄에서 호출하는 경우
            {
                if (Convert.ToInt32(n_db[37]) % 2 == 0)  //전지세로갯수가 아니고 자신의 가로갯수
                    don = "하리돈땡";
                else
                    don = "혼각계";
            }
            //
            return don;
        }
        //--------------------------------------------------------------------------------
        public static string[] selet_kook(string pp)   //종이 싸이즈의/국,46/절수 구함
        {
            string[] xx = new string[3];  //싸이즈/절수/국,46
            //
            if (pp.Equals("939*636") || pp.Equals("636*939"))
            {
                xx[0] = pp;
                xx[1] = "국";
                xx[2] = "1";
            }
            else if (pp.Equals("1091*788") || pp.Equals("788*1091"))
            {
                xx[0] = pp;
                xx[1] = "46";
                xx[2] = "1";
            }
            else if (pp.Equals("880*625") || pp.Equals("625*880"))
            {
                xx[0] = pp;
                xx[1] = "국";
                xx[2] = "1";
            }
            else if (pp.Equals("320*233") || pp.Equals("233*320"))
            {
                xx[0] = "939*636";  //엄마종이-싸이즈
                xx[1] = "국";        //엄마종이-국,46
                xx[2] = "1";        //엄마종이-절수
            }
            else if (pp.Equals("316*234") || pp.Equals("234*316"))
            {
                xx[0] = "939*636";  //엄마종이-싸이즈
                xx[1] = "국";        //엄마종이-국,46
                xx[2] = "1";        //엄마종이-절수
            }
            else if (pp.Equals("430*305") || pp.Equals("305*430"))
            {
                xx[0] = "880*625";  //엄마종이-싸이즈
                xx[1] = "국";        //엄마종이-국,46
                xx[2] = "1";        //엄마종이-절수
            }
            else if (pp.Equals("310*215") || pp.Equals("215*310"))
            {
                xx[0] = "880*625";  //엄마종이-싸이즈
                xx[1] = "국";        //엄마종이-국,46
                xx[2] = "1";        //엄마종이-절수
            }
            else if (pp.Equals("390*270") || pp.Equals("270*390"))
            {
                xx[0] = "1091*788"; //엄마종이-싸이즈
                xx[1] = "46";        //엄마종이-국,46
                xx[2] = "1";        //엄마종이-절수
            }
            else if (pp.Equals("210*297") || pp.Equals("297*210"))
            {
                xx[0] = "939*636";  //엄마종이-싸이즈
                xx[1] = "국";       //엄마종이-국,46
                xx[2] = "1";        //엄마종이-절수
            }
            else if (pp.Equals("476*315") || pp.Equals("315*476"))
            {
                xx[0] = "939*636";  //엄마종이-싸이즈
                xx[1] = "국";        //엄마종이-국,46
                xx[2] = "1";        //엄마종이-절수
            }
            else if (pp.Equals("438*310") || pp.Equals("310*438"))
            {
                xx[0] = "880*625";  //엄마종이-싸이즈
                xx[1] = "국";       //엄마종이-국,46
                xx[2] = "1";        //엄마종이-절수
            }
            else if (pp.Equals("390*270") || pp.Equals("270*390"))
            {
                xx[0] = "1091*788"; //엄마종이-싸이즈
                xx[1] = "46";        //엄마종이-국,46
                xx[2] = "1";        //엄마종이-절수
            }
            else if (pp.Equals("464*315") || pp.Equals("315*464"))
            {
                xx[0] = "939*636";  //엄마종이-싸이즈
                xx[1] = "국";       //엄마종이-국,46
                xx[2] = "1";        //엄마종이-절수
            }
            else if (pp.Equals("543*392") || pp.Equals("392*543"))
            {
                xx[0] = "1091*788";  //엄마종이-싸이즈
                xx[1] = "46";        //엄마종이-국,46
                xx[2] = "1";        //엄마종이-절수
            }
            else if (pp.Equals("636*467") || pp.Equals("467*636"))
            {
                xx[0] = "939*636";  //엄마종이-싸이즈
                xx[1] = "국";        //엄마종이-국,46
                xx[2] = "1";        //엄마종이-절수
            }
            //
            else if (pp.Equals("485*330") || pp.Equals("330*485"))
            {
                xx[0] = "1091*788";  //엄마종이-싸이즈
                xx[1] = "46";        //엄마종이-국,46
                xx[2] = "1";        //엄마종이-절수
            }

            else if (pp.Equals("360*260") || pp.Equals("260*360"))
            {
                xx[0] = "1091*788";  //엄마종이-싸이즈
                xx[1] = "46";        //엄마종이-국,46
                xx[2] = "1";        //엄마종이-절수
            }

            else if (pp.Equals("460*310") || pp.Equals("310*460"))
            {
                xx[0] = "939*636";  //엄마종이-싸이즈
                xx[1] = "국";        //엄마종이-국,46
                xx[2] = "1";        //엄마종이-절수
            }
            //
            else if (pp.Equals("485*330") || pp.Equals("330*485"))
            {
                xx[0] = "1091*788"; //엄마종이-싸이즈
                xx[1] = "46";        //엄마종이-국,46
                xx[2] = "1";        //엄마종이-절수
            }

            else if (pp.Equals("360*260") || pp.Equals("260*360"))
            {
                xx[0] = "1091*788";  //엄마종이-싸이즈
                xx[1] = "46";        //엄마종이-국,46
                xx[2] = "1";        //엄마종이-절수
            }

            else if (pp.Equals("460*310") || pp.Equals("310*460"))
            {
                xx[0] = "939*636";  //엄마종이-싸이즈
                xx[1] = "국";        //엄마종이-국,46
                xx[2] = "1";        //엄마종이-절수
            }
            else
            {
                xx[0] = pp;
                xx[1] = "";
                xx[2] = "";
            }
            return xx;
        }

        public static int y_to_jang(decimal y, decimal julsu)   //연수 --> 장수
        {
            decimal jang = y * 500 / julsu;  //연수 * 500 * 인쇄절수

            return (int)jang;  //소숫점 이하 버리고 반환
        }

        public static decimal jang_to_y(decimal jang, decimal julsu)   // 장수 --> 연수
        {
            decimal yunsu = jang / 500 / julsu;  //장수 / 500 / 인쇄절수

            return Math.Round(yunsu, 3);  //소숫점 3자리까지만 보냄
        }

        public static int[] total_d_s(string dos, string star)   // 도수와 별색 앞수,뒷수 각각 합하여 숫자형 배열값으로 보내고 / '0' 포함 여부를 보냄
        {
            int[] x_int = new int[5];
            x_int[0] = 0;  //총도수 앞수
            x_int[1] = 0;  //총도수 뒷수
            x_int[2] = 0;  //'0' 포함 여부(1=포함,0=미포함)
            x_int[3] = 0;  //별수 앞수
            x_int[4] = 0;  //별수 뒷수
            //
            int dos1 = 0;
            int dos2 = 0;
            int star1 = 0;
            int star2 = 0;
            //
            if (!string.IsNullOrEmpty(dos))
            {
                if (dos.Contains("/"))
                {
                    string[] c_dos = dos.Trim().Split(new char[1] { '/' });
                    dos1 = Convert.ToInt32(c_dos[0]);
                    dos2 = Convert.ToInt32(c_dos[1]);
                }
            }
            else
            {
                dos1 = 0;
                dos2 = 0;
            }
            //
            if (!string.IsNullOrEmpty(star))
            {
                if (star.Contains("/"))
                {
                    string[] c_star = star.Trim().Split(new char[1] { '/' });
                    star1 = Convert.ToInt32(c_star[0]);
                    star2 = Convert.ToInt32(c_star[1]);
                }
            }
            else
            {
                star1 = 0;
                star2 = 0;
            }
            x_int[0] = dos1 + star1;
            x_int[1] = dos2 + star2;
            if (x_int[0] == 0 || x_int[1] == 0)
                x_int[2] = 1;
            else
                x_int[2] = 0;
            //
            x_int[3] = star1;  //별수 앞수
            x_int[4] = star2;  //별수 뒷수
            //
            return x_int;  //
        }

        //public static string last_prnmod(string[] mdd, string[] dat)  //string pid=0, string hht=1, string prn_m=2, string jungr=3, string t_dos1=4, string t_dos2=5 
        //{
        //    //DataTable paper = new DataTable();          //종이정보 테이블
        //    //DataTable dontaeng_check = new DataTable(); //돈땡 체크 테이블
        //    //DataTable progres = new DataTable();        //공정 테이블
        //    //var DBCons = new MySqlConnection(Config.DB_con1); //개인서버
        //    //DBCons.Open();
        //    //string cQuery = " select row_id from C_paper where small like '%N%'";  //종이정보 테이블
        //    //MySqlDataAdapter returnVal = new MySqlDataAdapter(cQuery, DBCons);
        //    //returnVal.Fill(paper);                             //종이정보 테이블
        //    //returnVal.Dispose();
        //    ////
        //    //cQuery = " select * from C_dontaeng_check where row_id='1'";  //종이 돈땡테이블
        //    //MySqlDataAdapter returnVal1 = new MySqlDataAdapter(cQuery, DBCons);
        //    //returnVal1.Fill(dontaeng_check);                             //종이 돈땡테이블
        //    //returnVal1.Dispose();
        //    ////
        //    //paper.Columns["row_id"].Unique = true;
        //    //paper.PrimaryKey = new DataColumn[] { paper.Columns["row_id"] };
        //    ////
        //    //if (dat[7] == "1")  //견적
        //    //{
        //    //    cQuery = " select int_g,e_code  FROM C_progres1 ";
        //    //    cQuery += " where super_id='" + User.Cli_Row_id + "' and int_c='" + dat[6] + "'";
        //    //}
        //    //else
        //    //{
        //    //    cQuery = " select int_g,e_code  FROM C_progres2 ";
        //    //    cQuery += " where super_id='" + User.Cli_Row_id + "' and int_c='" + dat[6] + "'";
        //    //}
        //    //MySqlDataAdapter returnVal2 = new MySqlDataAdapter(cQuery, DBCons);
        //    //returnVal2.Fill(progres);
        //    //returnVal2.Dispose();
        //    ////
        //    //DataRow[] dr = paper.Select("row_id='" + dat[0] + "'");
        //    //string[] machine = mdd[31].Split(new char[1] { '/' });  //기계정보
        //    //bool in_db1 = false;
        //    //bool in_db2 = false;
        //    ////
        //    //DataRow[] dr1;
        //    //string cd1 = "";
        //    //string cd2 = "";
        //    //if (!string.IsNullOrEmpty(dat[1]))  //후공정있다면
        //    //{
        //    //    string[] ht = dat[1].Split(new char[1] { ',' });        //공정정보  //
        //    //    //
        //    //    for (int i = 0; i < ht.Length; i++) //후공정 부호가 돈땡 자료에 있는지 확인하는 과정
        //    //    {
        //    //        dr1 = progres.Select("e_code='" + ht[i] + "'");
        //    //        if (dr1.Length != 0)
        //    //        {
        //    //            cd1 = dr1[0]["int_g"].ToString().Substring(0, 4);
        //    //            cd2 = dr1[0]["int_g"].ToString();
        //    //            //
        //    //            if (dontaeng_check.Rows[0][1].ToString().Contains(cd1))
        //    //                in_db1 = true;
        //    //            //
        //    //            if (dontaeng_check.Rows[0][2].ToString().Contains(cd2))
        //    //                in_db2 = true;
        //    //        }
        //    //    }
        //    //}
        //    ////  
        //    //string x_prn = dat[2];   //인쇄모드 처음값
        //    ////
        //    //if (mdd[6] != "0")  //추가수가 있다면
        //    //    x_prn = "혼각계";
        //    //else if (Convert.ToInt32(mdd[12]) % 2 != 0)         //도큐절수가 홀수라면  
        //    //    x_prn = "혼각계";
        //    //else if (dr.Length != 0)                            //종이정보('small')에 'N' 이 포함되어 있다면
        //    //    x_prn = "혼각계";
        //    //else if (string.IsNullOrEmpty(mdd[31]))
        //    //    x_prn = "혼각계";
        //    //else if (!string.IsNullOrEmpty(mdd[31]) && !machine[4].Contains("0"))  //기계도수에 '0' 미포함 한다면 -- > 양면기 라면  
        //    //    x_prn = "혼각계";
        //    //else if (in_db1 == true)                             //일반 후공정 DB 포함이면
        //    //    x_prn = "혼각계";
        //    ////
        //    //else if (dat[2] == "구와이돈땡" && in_db2 == true)
        //    //    x_prn = "혼각계";
        //    //else
        //    //{
        //    //    if (dat[2] == "하리돈땡" && in_db2 == true)
        //    //    {
        //    //        if (Convert.ToDouble(mdd[38]) <= 12 && Convert.ToDouble(mdd[39]) <= 12)  //가로여분1,가로여분2  둘다 >= 12 야 한다
        //    //            x_prn = "혼각계";
        //    //    }
        //    //    //
        //    //    if ((x_prn == "구와이돈땡" || x_prn == "하리돈땡") && !string.IsNullOrEmpty(dat[3]))
        //    //    {
        //    //        if (Convert.ToDecimal(dat[3]) >= Convert.ToInt32(dontaeng_check.Rows[0][3].ToString()))  //해당 정r >= 돈땡체크 자료(koting_unit)
        //    //            x_prn = "혼각계";
        //    //    }
        //    //    if (x_prn != "혼각계")
        //    //    {
        //    //        if (dat[4] != dat[5])  //자기 총도수 앞뒤가  다르다면 --> 혼각계
        //    //            x_prn = "혼각계";
        //    //    }
        //    //}
        //    //DBCons.Close();
        //    //return x_prn;  //
        //}

        //public static bool insert_hgong(string[] dat)  // 
        //{
        //    //bool x_id = false;
        //    //var DBCons = new MySqlConnection(Config.DB_con1);  //개인서버
        //    //DBCons.Open();
        //    //string cQuery = "";
        //    //if (dat[17] == "1")
        //    //    cQuery = " insert into C_progres1";  //견적
        //    //else
        //    //    cQuery = " insert into C_progres2";  //주문
        //    ////
        //    //cQuery += " (super_id,int_id,no_1,no_2,no_3,p_day,busu,nalgae,count,sebari,miso,habji,int_g";
        //    //if (dat[18] == "1")
        //    //    cQuery += ",s_code4,ybun,act_id,jogun,paper_weight,book_thick,jubji,go_id,e_code,int_c)";
        //    //else
        //    //    cQuery += ",s_code4,ybun,act_id,jogun,paper_weight,book_thick,jubji,go_id,e_code,int_auto)";
        //    ////
        //    //cQuery += " VALUES('" + User.Cli_Row_id + "','" + dat[14] + "','" + dat[1] + "','" + dat[2] + "','" + dat[4] + "'";
        //    //cQuery += ",curdate(),'','','','','','','" + dat[16] + "'";
        //    //cQuery += ",'" + dat[5] + "','" + dat[6] + "','" + dat[7] + "','" + dat[8] + "','" + dat[9] + "','" + dat[10] + "'";
        //    //cQuery += ",'" + dat[11] + "','" + dat[12] + "','" + dat[13] + "','" + dat[15] + "')";
        //    ////
        //    //var cmd = new MySqlCommand(cQuery, DBCons);
        //    //if (cmd.ExecuteNonQuery() == 0)
        //    //    x_id = false;
        //    //else
        //    //    x_id = true;
        //    ////
        //    //DBCons.Close();
        //    //return x_id;
        //}

        public static double convert_jung_R(double dd, string mode)  // 
        {
            double x_jung = 0;
            double d1 = 0; ;   //정수 부분만
            double d2 = 0;    //분수 부분만 
            double d3 = 0;    //올림되는수 
            //
            if (mode == "0")     //1R단위(1.09=1, 1.1=2)
            {
                //소수 두자리 수로 변환(나머지는 버림)
                dd *= 100;
                dd = Math.Floor(dd);
                dd /= 100;
                //
                d1 = (int)Math.Floor(dd);  //정수 부분만
                d2 = dd - d1;              //분수 부분만
                d2 *= 100;
                d2 = Math.Floor(d2);
                d2 /= 100;
                //
                d3 = 0;                    //올림되는수 
                //
                if (d2 <= 0.09)
                    d3 = 0;
                else
                    d3 = 1;
                //
                x_jung = d1 + d3;
            }
            else if (mode == "1")  //0.5R단위(1.09=1, 1.1=1.5, 1.59=1.5, 1.6=2)
            {
                //소수 두자리 수로 변환(나머지는 버림)
                dd *= 100;
                dd = Math.Floor(dd);
                dd /= 100;
                //
                d1 = (int)Math.Floor(dd);  //정수 부분만
                d2 = dd - d1;              //분수 부분만 
                d2 *= 100;
                d2 = Math.Floor(d2);
                d2 /= 100;
                //
                d3 = 0;                    //올림되는수 
                //
                if (d2 <= 0.09)
                    d3 = 0;
                else if (d2 > 0.09 && d2 <= 0.59)
                    d3 = 0.5;
                else
                    d3 = 1;
                //
                x_jung = d1 + d3;
            }
            else if (mode == "2")  //0.00R단위(1.111=1.12, 1.171=1.18)
            {
                //소수 세자리 수로 변환(나머지는 버림)
                dd *= 1000;
                dd = Math.Floor(dd);
                dd /= 1000;
                //
                string nn = dd.ToString();
                string d4 = nn.Substring(nn.Length - 1, 1);  //마지막수
                //
                dd *= 100;  //소수 두자리 수
                dd = Math.Floor(dd);
                dd /= 100;
                //
                d3 = 0;                    //올림되는수 
                //
                if (nn.Length >= 5)
                {
                    if (d4 != "0")
                        d3 = 0.01;
                    else
                        d3 = 0;
                }
                else
                    d3 = 0;
                //
                x_jung = dd + d3;
            }
            if (x_jung < 1)  //최종수가 0 보다 작으면 1
                x_jung = 1;
            //  
            return x_jung;
        }
    }

    public class Paper_mo   //종이 선택하는 클래스
    {
        public DataTable p_dt = new DataTable();  //종이자료 검색용 테이블
        public string[] a_xno = new string[22];   //최종 절수정보 내보내는 변수
        public Double[,] xd = new Double[17, 26]; //내부 종이 정보 배열
        bool select_id = true;                   //true = 최상의 조건에서 종이선정하기 / false = 종이,가로,세로 조건에서 종이 선정하기
        string[] sub = new string[3];            //위 내용정보 0=종이가로세로, 1=가로갯수, 2=세로갯수 
        //
        public Paper_mo()
        {

        }
        //
        public string[] sel_paper(string[] pp, bool f_id, string[] dd)   //자동화창 가기전에 사용하는것임 dd = 종이싸이즈,가로개수,세로갯수
        {
            select_id = false;  //종이,가로,세로 조건에서 종이 선정하기
            sub = dd;           //정보 
            sel_paper(pp, f_id);
            return a_xno;
        }

        public string[] sel_paper(string[] pp, bool f_id)   //f_id = 결과표 보이기
        {
            bool macro_id = false;       //매크로 아님
            if (pp.Length >= 16)          //매크로 조건 반영
            {
                if (!string.IsNullOrEmpty(pp[16]))
                    macro_id = true;
            }
            //
            int at = 0;                        //for 문에서 사용하는숫자 
            Double f_su = 0;                   //인쇄절수 구하기 위한 책싸이즈 앞수(더블) 
            Double r_su = 0;                   //             ''               뒷수 
            Double af_su = 0;                  //인쇄절수 구하기 위한 책싸이즈 앞수(더블) 
            Double ar_su = 0;                  //             ''               뒷수 
            string temp = "";                  //임시로 사용
            Double m1 = 0;
            Double m2 = 0;
            //
            for (int i = 0; i < a_xno.Length; i++)
                a_xno[i] = "";
            //
            if (string.IsNullOrEmpty(pp[2]))
                return a_xno;
            // 
            if (Config.s_dat.Rows.Count == 0)  //절수 검색하는 테이블  //C_sel_jul
            {
                p_dt.Columns.Add("a");      //0 //국,46
                p_dt.Columns.Add("b");      //1 //상,좌
                p_dt.Columns.Add("c");      //2 //도큐절수
                p_dt.Columns.Add("d");      //3 //인쇄절수
                p_dt.Columns.Add("e");      //4
                p_dt.Columns.Add("f");      //5
                p_dt.Columns.Add("g");      //6 /가로,세로
                p_dt.Columns.Add("h");      //7
                p_dt.Columns.Add("i");      //8
                p_dt.Columns.Add("j");      //9
                p_dt.Columns.Add("k");      //10
                p_dt.Columns.Add("l");      //11
                p_dt.Columns.Add("mu_jubji_11");      //12
                p_dt.Columns.Add("mu_jubji_12");     //13
                p_dt.Columns.Add("ju_jubji_11");      //14
                p_dt.Columns.Add("ju_jubji_12");     //15
                p_dt.Columns.Add("da1");    //16
                p_dt.Columns.Add("da2");    //17
                p_dt.Columns.Add("d_size"); //18
                p_dt.Columns.Add("m_julsu");//19
                p_dt.Columns.Add("jarak");  //20
                p_dt.Columns.Add("p_id");   //21  //옵셋인쇄
                p_dt.Columns.Add("row_id"); //22
                //
                var DBConn = new MySqlConnection(Config.DB_con1);
                DBConn.Open();
                string cQuery = " select * FROM C_sel_jul ";
                var cmd = new MySqlCommand(cQuery, DBConn);
                var myRead = cmd.ExecuteReader();
                while (myRead.Read())
                {
                    p_dt.Rows.Add(new string[] { myRead["a"].ToString(), myRead["b"].ToString(), myRead["c"].ToString(),
                         myRead["d"].ToString(), myRead["e"].ToString(), myRead["f"].ToString(), myRead["g"].ToString(),
                         myRead["h"].ToString(), myRead["i"].ToString(), myRead["j"].ToString(), myRead["k"].ToString(),
                         myRead["l"].ToString(), myRead["mu_jubji_11"].ToString(), myRead["mu_jubji_12"].ToString(), myRead["ju_jubji_11"].ToString(),
                         myRead["ju_jubji_12"].ToString(), myRead["da1"].ToString(), myRead["da2"].ToString(),myRead["d_size"].ToString(),
                         myRead["m_julsu"].ToString(), myRead["jarak"].ToString(), myRead["p_id"].ToString(), myRead["row_id"].ToString()});
                }
                myRead.Close();
                DBConn.Close();
                Config.s_dat = p_dt;
            }
            else
                p_dt = Config.s_dat;  //
            //
            temp = pp[2].Trim();      //책싸이즈 가로, 세로 구함
            string[] axx = temp.Split(new char[1] { '*' });
            f_su = Convert.ToDouble(axx[0]); //책싸이즈의 앞수
            r_su = Convert.ToDouble(axx[1]); //책싸이즈의 뒷수
            //
            bool dajj = false;  //닷찌인쇄 불가
            if (f_su + (Convert.ToDouble(pp[3]) * 2) <= 360 || r_su + (Convert.ToDouble(pp[3]) * 2) <= 360)
                dajj = true;
            //
            for (int n = 0; n < 17; n++)
            {
                for (int s = 0; s < 26; s++)
                {
                    xd[n, s] = 0;
                }
            }
            //
            for (int n = 0; n < 16; n++)
            {
                a_xno[n] = "";
            }
            a_xno[12] = "0";
            //
            if (pp[1].Equals("1"))      //1=규격지,2=별지,3=2버튼,4=3번버튼
            {
                if (pp[11] == "01")     //마스타인쇄
                {
                    xd[1, 1] = 316;    //종이가로 싸이즈 
                    xd[1, 2] = 234;    //종이세로 싸이즈
                    xd[1, 3] = 8;      //I=절수
                    xd[1, 4] = 1;      //국,46   
                    //
                    xd[2, 1] = 430;
                    xd[2, 2] = 305;
                    xd[2, 3] = 4;
                    xd[2, 4] = 1;
                    //
                    xd[3, 1] = 310;
                    xd[3, 2] = 215;
                    xd[3, 3] = 8;
                    xd[3, 4] = 1;
                    //
                    xd[4, 1] = 390;
                    xd[4, 2] = 270;
                    xd[4, 3] = 8;
                    xd[4, 4] = 2;
                    //
                    xd[5, 1] = 360;
                    xd[5, 2] = 260;
                    xd[5, 3] = 9;
                    xd[5, 4] = 2;
                    //
                    if (pp[12] == "1")  //마스타 재물일때만 추가
                    {
                        xd[6, 1] = 460;
                        xd[6, 2] = 310;
                        xd[6, 3] = 4;
                        xd[6, 4] = 1;
                    }
                    //-----------------------------------
                    xd[9, 1] = 316;    //종이가로 싸이즈 
                    xd[9, 2] = 234;    //종이세로 싸이즈
                    xd[9, 3] = 8;      //I=절수
                    xd[9, 4] = 1;      //국,46   
                    //
                    xd[10, 1] = 430;
                    xd[10, 2] = 305;
                    xd[10, 3] = 4;
                    xd[10, 4] = 1;
                    //
                    xd[11, 1] = 310;
                    xd[11, 2] = 215;
                    xd[11, 3] = 8;
                    xd[11, 4] = 1;
                    //
                    xd[12, 1] = 390;
                    xd[12, 2] = 270;
                    xd[12, 3] = 8;
                    xd[12, 4] = 2;
                    //
                    xd[13, 1] = 360;
                    xd[13, 2] = 260;
                    xd[13, 3] = 9;
                    xd[13, 4] = 2;
                    //
                    if (pp[12] == "1")  //마스타 재물일때만 추가
                    {
                        xd[14, 1] = 460;
                        xd[14, 2] = 310;
                        xd[14, 3] = 4;
                        xd[14, 4] = 1;
                    }
                }
                //
                else if (pp[11] == "02")   //디지탈인쇄
                {
                    if (pp[12] == "3")     //A4 선택되어 있다면
                    {
                        xd[1, 1] = 297;    //종이가로 싸이즈 
                        xd[1, 2] = 210;    //종이세로 싸이즈
                        xd[1, 3] = 9;      //I=절수
                        xd[1, 4] = 1;      //국,46   
                        //
                        xd[9, 1] = 297;    //종이가로 싸이즈 
                        xd[9, 2] = 210;    //종이세로 싸이즈
                        xd[9, 3] = 9;      //I=절수
                        xd[9, 4] = 1;      //국,46   
                    }
                    else
                    {
                        xd[1, 1] = 485;    //종이가로 싸이즈 
                        xd[1, 2] = 330;    //종이세로 싸이즈
                        xd[1, 3] = 4;      //I=절수
                        xd[1, 4] = 2;      //국,46   
                        //
                        xd[2, 1] = 464;
                        xd[2, 2] = 315;
                        xd[2, 3] = 4;
                        xd[2, 4] = 1;
                        //
                        xd[3, 1] = 438;
                        xd[3, 2] = 310;
                        xd[3, 3] = 4;
                        xd[3, 4] = 1;
                        //
                        xd[4, 1] = 390;
                        xd[4, 2] = 270;
                        xd[4, 3] = 8;
                        xd[4, 4] = 2;
                        //
                        xd[5, 1] = 310;
                        xd[5, 2] = 215;
                        xd[5, 3] = 8;
                        xd[5, 4] = 1;
                        //
                        xd[9, 1] = 485;    //종이가로 싸이즈 
                        xd[9, 2] = 330;    //종이세로 싸이즈
                        xd[9, 3] = 4;      //I=절수
                        xd[9, 4] = 2;      //국,46   
                        //
                        xd[10, 1] = 464;
                        xd[10, 2] = 315;
                        xd[10, 3] = 4;
                        xd[10, 4] = 1;
                        //
                        xd[11, 1] = 438;
                        xd[11, 2] = 310;
                        xd[11, 3] = 4;
                        xd[11, 4] = 1;
                        //
                        xd[12, 1] = 390;
                        xd[12, 2] = 270;
                        xd[12, 3] = 8;
                        xd[12, 4] = 2;
                        //
                        xd[13, 1] = 310;
                        xd[13, 2] = 215;
                        xd[13, 3] = 8;
                        xd[13, 4] = 1;
                    }
                }
                else if (pp[11] == "03")  //인디고
                {
                    xd[1, 1] = 464;    //종이가로 싸이즈 
                    xd[1, 2] = 315;    //종이세로 싸이즈
                    xd[1, 3] = 4;      //I=절수
                    xd[1, 4] = 1;      //국,46   
                    //
                    xd[9, 1] = 464;    //종이가로 싸이즈 
                    xd[9, 2] = 315;    //종이세로 싸이즈
                    xd[9, 3] = 4;      //I=절수
                    xd[9, 4] = 1;      //국,46   
                }
                //
                else if (pp[5].Equals("재물"))  //구와이 조건
                {
                    xd[1, 1] = 939;    //종이가로 싸이즈 
                    xd[1, 2] = 636;    //종이세로 싸이즈
                    xd[1, 3] = 1;      //I=절수
                    xd[1, 4] = 1;      //국,46   
                    //
                    xd[2, 1] = 880;
                    xd[2, 2] = 625;
                    xd[2, 3] = 1;
                    xd[2, 4] = 1;
                    //
                    xd[3, 1] = 788;
                    xd[3, 2] = 545;
                    xd[3, 3] = 2;
                    xd[3, 4] = 2;
                    //
                    xd[4, 1] = 760;
                    xd[4, 2] = 545;
                    xd[4, 3] = 2;
                    xd[4, 4] = 2;
                    //
                    xd[5, 1] = 636;
                    xd[5, 2] = 467;
                    xd[5, 3] = 2;
                    xd[5, 4] = 1;
                    //
                    xd[6, 1] = 543;
                    xd[6, 2] = 392;
                    xd[6, 3] = 4;
                    xd[6, 4] = 2;
                    //
                    if (pp[14].Equals("2"))  //전지인쇄
                    {
                        xd[7, 1] = 1091;
                        xd[7, 2] = 788;
                        xd[7, 3] = 1;
                        xd[7, 4] = 2;
                    }
                    else if (pp[14].Equals("3"))  //닷찌인쇄
                    {
                        if (dajj == true)
                        {
                            xd[7, 1] = 1091;
                            xd[7, 2] = 788;
                            xd[7, 3] = 1;
                            xd[7, 4] = 2;
                        }
                    }
                    else if (pp[14].Equals("4"))  //닷찌인쇄, 전지인쇄
                    {
                        xd[7, 1] = 1091;
                        xd[7, 2] = 788;
                        xd[7, 3] = 1;
                        xd[7, 4] = 2;
                    }
                    //----------------------------------
                    xd[9, 1] = 939;    //종이가로 싸이즈 
                    xd[9, 2] = 636;    //종이세로 싸이즈
                    xd[9, 3] = 1;      //I=절수
                    xd[9, 4] = 1;      //국,46   
                    //
                    xd[10, 1] = 880;
                    xd[10, 2] = 625;
                    xd[10, 3] = 1;
                    xd[10, 4] = 1;
                    //
                    //
                    xd[11, 1] = 788;
                    xd[11, 2] = 545;
                    xd[11, 3] = 2;
                    xd[11, 4] = 2;
                    //
                    xd[12, 1] = 760;
                    xd[12, 2] = 545;
                    xd[12, 3] = 2;
                    xd[12, 4] = 2;
                    //
                    xd[13, 1] = 636;
                    xd[13, 2] = 467;
                    xd[13, 3] = 2;
                    xd[13, 4] = 1;
                    //
                    xd[14, 1] = 543;
                    xd[14, 2] = 392;
                    xd[14, 3] = 4;
                    xd[14, 4] = 2;
                    //
                    if (pp[14].Equals("2"))  //전지인쇄
                    {
                        xd[15, 1] = 1091;
                        xd[15, 2] = 788;
                        xd[15, 3] = 1;
                        xd[15, 4] = 2;
                    }
                    else if (pp[14].Equals("3"))  //닷찌인쇄
                    {
                        if (dajj == true)
                        {
                            xd[15, 1] = 1091;
                            xd[15, 2] = 788;
                            xd[15, 3] = 1;
                            xd[15, 4] = 2;
                        }
                    }
                    else if (pp[14].Equals("4"))  //닷찌인쇄, 전지인쇄
                    {
                        xd[15, 1] = 1091;
                        xd[15, 2] = 788;
                        xd[15, 3] = 1;
                        xd[15, 4] = 2;
                    }
                }
                else     //나머지 모두
                {
                    if (pp[5] == "양면")  //구와이 조건
                    {
                        xd[1, 1] = 939;    //종이가로 싸이즈 
                        xd[1, 2] = 636;    //종이세로 싸이즈
                        xd[1, 3] = 1;      //I=절수
                        xd[1, 4] = 1;      //국,46   
                        //
                        xd[2, 1] = 880;
                        xd[2, 2] = 625;
                        xd[2, 3] = 1;
                        xd[2, 4] = 1;
                        //
                        xd[3, 1] = 788;
                        xd[3, 2] = 545;
                        xd[3, 3] = 2;
                        xd[3, 4] = 2;
                        //
                        xd[4, 1] = 760;
                        xd[4, 2] = 545;
                        xd[4, 3] = 2;
                        xd[4, 4] = 2;
                        //----------------------------------
                        xd[9, 1] = 939;    //종이가로 싸이즈 
                        xd[9, 2] = 636;    //종이세로 싸이즈
                        xd[9, 3] = 1;      //I=절수
                        xd[9, 4] = 1;      //국,46   
                        //
                        xd[10, 1] = 880;
                        xd[10, 2] = 625;
                        xd[10, 3] = 1;
                        xd[10, 4] = 1;
                        //
                        xd[11, 1] = 788;
                        xd[11, 2] = 545;
                        xd[11, 3] = 2;
                        xd[11, 4] = 2;
                        //
                        xd[12, 1] = 760;
                        xd[12, 2] = 545;
                        xd[12, 3] = 2;
                        xd[12, 4] = 2;
                    }
                    else   //양면을 제외한 나머지( 싸이즈 추가적용 --> 636*467, 1067*797 )
                    {
                        xd[1, 1] = 939;    //종이가로 싸이즈 
                        xd[1, 2] = 636;    //종이세로 싸이즈
                        xd[1, 3] = 1;      //I=절수
                        xd[1, 4] = 1;      //국,46   
                        //
                        xd[2, 1] = 880;
                        xd[2, 2] = 625;
                        xd[2, 3] = 1;
                        xd[2, 4] = 1;
                        //
                        xd[3, 1] = 636;
                        xd[3, 2] = 467;
                        xd[3, 3] = 2;
                        xd[3, 4] = 1;
                        //
                        xd[4, 1] = 788;
                        xd[4, 2] = 545;
                        xd[4, 3] = 2;
                        xd[4, 4] = 2;
                        //
                        xd[5, 1] = 760;
                        xd[5, 2] = 545;
                        xd[5, 3] = 2;
                        xd[5, 4] = 2;
                        if (pp[14].Equals("2"))  //전지인쇄
                        {
                            xd[6, 1] = 1091;
                            xd[6, 2] = 788;
                            xd[6, 3] = 1;
                            xd[6, 4] = 2;
                            //
                            xd[7, 1] = 543;
                            xd[7, 2] = 392;
                            xd[7, 3] = 4;
                            xd[7, 4] = 2;
                        }
                        else if (pp[14].Equals("3"))  //닷찌인쇄
                        {
                            xd[6, 1] = 1067;
                            xd[6, 2] = 797;
                            xd[6, 3] = 1;
                            xd[6, 4] = 2;
                            //
                            xd[7, 1] = 543;
                            xd[7, 2] = 392;
                            xd[7, 3] = 4;
                            xd[7, 4] = 2;
                        }
                        else if (pp[14].Equals("4"))  //닷찌인쇄,전지인쇄
                        {
                            xd[6, 1] = 1067;
                            xd[6, 2] = 797;
                            xd[6, 3] = 1;
                            xd[6, 4] = 2;
                            //
                            xd[7, 1] = 1091;
                            xd[7, 2] = 788;
                            xd[7, 3] = 1;
                            xd[7, 4] = 2;
                            //
                            xd[8, 1] = 543;
                            xd[8, 2] = 392;
                            xd[8, 3] = 4;
                            xd[8, 4] = 2;
                        }
                        else if (pp[14].Equals("1"))  //닷찌인쇄 빼고, 전지빼고,
                        {
                            xd[6, 1] = 543;
                            xd[6, 2] = 392;
                            xd[6, 3] = 4;
                            xd[6, 4] = 2;
                        }
                        //----------------------------------
                        xd[9, 1] = 939;    //종이가로 싸이즈 
                        xd[9, 2] = 636;    //종이세로 싸이즈
                        xd[9, 3] = 1;      //I=절수
                        xd[9, 4] = 1;      //국,46   
                        //
                        xd[10, 1] = 880;
                        xd[10, 2] = 625;
                        xd[10, 3] = 1;
                        xd[10, 4] = 1;
                        //
                        xd[11, 1] = 636;
                        xd[11, 2] = 467;
                        xd[11, 3] = 2;
                        xd[11, 4] = 1;
                        //
                        xd[12, 1] = 788;
                        xd[12, 2] = 545;
                        xd[12, 3] = 2;
                        xd[12, 4] = 2;
                        //
                        xd[13, 1] = 760;
                        xd[13, 2] = 545;
                        xd[13, 3] = 2;
                        xd[13, 4] = 2;
                        //
                        if (pp[14].Equals("2")) // 전지인쇄
                        {
                            xd[14, 1] = 1091;
                            xd[14, 2] = 788;
                            xd[14, 3] = 1;
                            xd[14, 4] = 2;
                            //
                            xd[15, 1] = 543;
                            xd[15, 2] = 392;
                            xd[15, 3] = 4;
                            xd[15, 4] = 2;
                        }
                        else if (pp[14].Equals("3"))  //닷찌인쇄
                        {
                            xd[14, 1] = 1067;
                            xd[14, 2] = 797;
                            xd[14, 3] = 1;
                            xd[14, 4] = 2;
                            //
                            xd[15, 1] = 543;
                            xd[15, 2] = 392;
                            xd[15, 3] = 4;
                            xd[15, 4] = 2;
                        }
                        if (pp[14].Equals("4"))  //닷찌인쇄,전지인쇄
                        {
                            xd[14, 1] = 1067;
                            xd[14, 2] = 797;
                            xd[14, 3] = 1;
                            xd[14, 4] = 2;
                            //
                            xd[15, 1] = 1091;
                            xd[15, 2] = 788;
                            xd[15, 3] = 1;
                            xd[15, 4] = 2;
                            //
                            xd[16, 1] = 543;
                            xd[16, 2] = 392;
                            xd[16, 3] = 4;
                            xd[16, 4] = 2;
                        }
                        else if (pp[14].Equals("1"))  //닷찌불가, 전지제외
                        {
                            xd[14, 1] = 543;
                            xd[14, 2] = 392;
                            xd[14, 3] = 4;
                            xd[14, 4] = 2;
                        }
                    }
                }
                //
            }
            else if (pp[1].Equals("2"))     //2=별지
            {
                if (pp[7].Equals(""))
                {
                    MessageBox.Show("별지 종이 절수가 없습니다. 별지선택창에서 별지를 선택해 주세요.");
                    return a_xno;
                }

                string[] mxx = pp[9].Split(new char[1] { '*' });  //싸이즈를 가지고 종,횡목에 따라 인쇄 싸이즈 재설정
                Double f_su1 = Convert.ToDouble(mxx[0]); //싸이즈의 앞수
                Double r_su1 = Convert.ToDouble(mxx[1]); //싸이즈의 뒷수
                if (f_su1 < r_su1)  //앞수가 작다면 큰수로 교체하고
                {
                    Double temd = f_su1;
                    f_su1 = r_su1;
                    r_su1 = temd;
                }
                xd[1, 1] = f_su1;      //가로
                xd[1, 2] = r_su1;      //세로
                if (pp[7].Contains("/"))
                    xd[1, 3] = 1;
                else
                    xd[1, 3] = Convert.ToDouble(pp[7]);     //I절수
                //
                if (pp[8].Equals("1") || pp[8].Equals("국"))
                    xd[1, 4] = 1;
                else
                    xd[1, 4] = 2;
                //
                xd[9, 1] = xd[1, 1];      //가로
                xd[9, 2] = xd[1, 2];      //세로
                xd[9, 3] = xd[1, 3];      //I절수
                xd[9, 4] = xd[1, 4];      //국,46
            }
            else if (pp[1].Equals("3"))   //2번버튼 호출
            {
                xd[1, 1] = 939;    //종이가로 싸이즈 
                xd[1, 2] = 636;    //종이세로 싸이즈
                xd[1, 3] = 1;      //I=절수
                xd[1, 4] = 1;      //국,46   
                //
                xd[2, 1] = 1091;
                xd[2, 2] = 788;
                xd[2, 3] = 1;
                xd[2, 4] = 2;
                //
                xd[3, 1] = 880;
                xd[3, 2] = 625;
                xd[3, 3] = 1;
                xd[3, 4] = 1;
                //
                //
                xd[9, 1] = 939;    //종이가로 싸이즈 
                xd[9, 2] = 636;    //종이세로 싸이즈
                xd[9, 3] = 1;      //I=절수
                xd[9, 4] = 1;      //국,46   
                //
                xd[10, 1] = 1091;
                xd[10, 2] = 788;
                xd[10, 3] = 1;
                xd[10, 4] = 2;
                //
                xd[11, 1] = 880;
                xd[11, 2] = 625;
                xd[11, 3] = 1;
                xd[11, 4] = 1;
                //
            }
            else if (pp[1].Equals("4"))   //3번버튼 호출
            {
                xd[1, 1] = 939;    //종이가로 싸이즈 
                xd[1, 2] = 636;    //종이세로 싸이즈
                xd[1, 3] = 1;      //I=절수
                xd[1, 4] = 1;      //국,46   
                //
                xd[2, 1] = 1091;
                xd[2, 2] = 788;
                xd[2, 3] = 1;
                xd[2, 4] = 2;
                //
                xd[3, 1] = 880;
                xd[3, 2] = 625;
                xd[3, 3] = 1;
                xd[3, 4] = 1;
                //
                xd[4, 1] = 1200;
                xd[4, 2] = 900;
                xd[4, 3] = 1;
                xd[4, 4] = 2;
                //
                xd[5, 1] = 1020;
                xd[5, 2] = 720;
                xd[5, 3] = 1;
                xd[5, 4] = 1;
                //------------------------------------------------------------
                xd[9, 1] = 939;    //종이가로 싸이즈 
                xd[9, 2] = 636;    //종이세로 싸이즈
                xd[9, 3] = 1;      //I=절수
                xd[9, 4] = 1;      //국,46   
                //
                xd[10, 1] = 1091;
                xd[10, 2] = 788;
                xd[10, 3] = 1;
                xd[10, 4] = 2;
                //
                xd[11, 1] = 880;
                xd[11, 2] = 625;
                xd[11, 3] = 1;
                xd[11, 4] = 1;
                //
                xd[12, 1] = 1200;
                xd[12, 2] = 900;
                xd[12, 3] = 1;
                xd[12, 4] = 2;
                //
                xd[13, 1] = 1020;
                xd[13, 2] = 720;
                xd[13, 3] = 1;
                xd[13, 4] = 1;
            }
            else if (pp[1].Equals("5"))   //3번버튼 앞서 호출
            {
                xd[1, 1] = 1091;
                xd[1, 2] = 788;
                xd[1, 3] = 1;
                xd[1, 4] = 2;
                //------------------------------------------------------------
                xd[9, 1] = 1091;
                xd[9, 2] = 788;
                xd[9, 3] = 1;
                xd[9, 4] = 2;
            }
            else if (pp[1].Equals("6"))   //3번버튼 호출후 true 일때
            {
                xd[1, 1] = 939;    //종이가로 싸이즈 
                xd[1, 2] = 636;    //종이세로 싸이즈
                xd[1, 3] = 1;      //I=절수
                xd[1, 4] = 1;      //국,46   
                //
                xd[2, 1] = 1091;
                xd[2, 2] = 788;
                xd[2, 3] = 1;
                xd[2, 4] = 2;
                //
                xd[3, 1] = 880;
                xd[3, 2] = 625;
                xd[3, 3] = 1;
                xd[3, 4] = 1;
                //------------------------------------------------------------
                xd[9, 1] = 939;    //종이가로 싸이즈 
                xd[9, 2] = 636;    //종이세로 싸이즈
                xd[9, 3] = 1;      //I=절수
                xd[9, 4] = 1;      //국,46   
                //
                xd[10, 1] = 1091;
                xd[10, 2] = 788;
                xd[10, 3] = 1;
                xd[10, 4] = 2;
                //
                xd[11, 1] = 880;
                xd[11, 2] = 625;
                xd[11, 3] = 1;
                xd[11, 4] = 1;
            }
            else if (pp[1].Equals("7"))   //3번버튼 호출후 false 일때
            {
                xd[1, 1] = 1200;
                xd[1, 2] = 900;
                xd[1, 3] = 1;
                xd[1, 4] = 2;
                //
                xd[2, 1] = 1020;
                xd[2, 2] = 720;
                xd[2, 3] = 1;
                xd[2, 4] = 1;
                //------------------------------------------------------------
                xd[9, 1] = 1200;
                xd[9, 2] = 900;
                xd[9, 3] = 1;
                xd[9, 4] = 2;
                //
                xd[10, 1] = 1020;
                xd[10, 2] = 720;
                xd[10, 3] = 1;
                xd[10, 4] = 1;
            }
            //
            if (macro_id == true)  //매크로 요구 조건이 있다면 여기서 처리 pp[16]->pp[19] == 제거
            {
                int n1 = Convert.ToInt32(pp[16].ToString());
                int n2 = Convert.ToInt32(pp[17].ToString());
                int n3 = Convert.ToInt32(pp[18].ToString());
                int n4 = Convert.ToInt32(pp[19].ToString());
                //
                Double[,] td = new Double[17, 26]; //내부 종이 정보 배열
                Array.Copy(xd, 0, td, 0, xd.Length); //기존자료 복사하고
                // 
                for (int n = 0; n < 17; n++)       //xd 초기화
                {
                    for (int s = 0; s < 26; s++)
                    {
                        xd[n, s] = 0;
                    }
                }
                int nn = 1;
                for (int n = 1; n < 9; n++)
                {
                    if (td[n, 1] != n1 && td[n, 1] != n2 && td[n, 1] != n3 && td[n, 1] != n4)
                    {
                        xd[nn, 1] = td[n, 1];
                        xd[nn, 2] = td[n, 2];
                        xd[nn, 3] = td[n, 3];
                        xd[nn, 4] = td[n, 4];
                        nn++;
                    }
                }
                //  
                nn = 9;
                for (int n = 9; n < 17; n++)
                {
                    if (td[n, 1] != n1 && td[n, 1] != n2 && td[n, 1] != n3 && td[n, 1] != n4)
                    {
                        xd[nn, 1] = td[n, 1];
                        xd[nn, 2] = td[n, 2];
                        xd[nn, 3] = td[n, 3];
                        xd[nn, 4] = td[n, 4];
                        nn++;
                    }
                }
            }
            //인쇄싸이즈 구하기
            if (pp[11] == "01")                 //마스타인쇄
            {
                for (int i = 1; i < 17; i++)    //인쇄싸이즈 구하기
                {
                    if (!xd[i, 1].Equals(0))
                    {
                        if (pp[12] == "1")      //마스타 재물일때
                        {
                            xd[i, 5] = xd[i, 1];
                            xd[i, 6] = xd[i, 2];
                        }
                        else                    //마스타 풀 일때는 10mm 뺌
                        {
                            xd[i, 5] = xd[i, 1] - 10;
                            xd[i, 6] = xd[i, 2];
                        }
                    }
                }
            }
            else if (pp[11] == "02")             //디지탈인쇄
            {
                for (int i = 1; i < 17; i++)    //인쇄싸이즈 구하기
                {
                    if (pp[12] == "1" || pp[12] == "3")      //재물일때, A4
                    {
                        xd[i, 5] = xd[i, 1];
                        xd[i, 6] = xd[i, 2];
                    }
                    else                    //풀 일때 (사방4mm여백 뺌)
                    {
                        xd[i, 5] = xd[i, 1] - 8;
                        xd[i, 6] = xd[i, 2] - 8;
                    }
                }
            }
            else if (pp[11] == "03")             //인디고인쇄
            {
                for (int i = 1; i < 17; i++)    //인쇄싸이즈 구하기
                {
                    if (!xd[i, 1].Equals(0))
                    {
                        if (pp[12] == "1")      //재물일때 
                        {
                            xd[i, 5] = xd[i, 1];
                            xd[i, 6] = xd[i, 2];
                        }
                        else                    //풀일때
                        {
                            xd[i, 5] = xd[i, 1] - 10;
                            xd[i, 6] = xd[i, 2] - 8;
                        }
                    }
                }
            }
            else if (pp[11] == "제로")          //제로 비규격 호출시 인쇄싸이즈 0로 적용
            {
                for (int i = 1; i < 17; i++)    //인쇄싸이즈 구하기
                {
                    if (!xd[i, 1].Equals(0))
                    {
                        xd[i, 5] = xd[i, 1];
                        xd[i, 6] = xd[i, 2];
                    }
                }
            }
            else   //위조건이 아닌 나머지       
            {
                for (int i = 1; i < 17; i++)    //인쇄싸이즈 구하기
                {
                    if (!xd[i, 1].Equals(0))
                    {
                        if (pp[5].Equals("일반"))   //구와이 조건
                        {
                            xd[i, 5] = xd[i, 1];
                            xd[i, 6] = xd[i, 2] - 10;
                        }
                        else if (pp[5].Equals("양면"))
                        {
                            xd[i, 5] = xd[i, 1];
                            xd[i, 6] = xd[i, 2] - 20;
                        }
                        else if (pp[5].Equals("재물"))
                        {
                            xd[i, 5] = xd[i, 1];
                            xd[i, 6] = xd[i, 2];
                            //
                        }
                        else if (pp[5].Equals("윤전"))
                        {
                            xd[i, 5] = xd[i, 1];
                            xd[i, 6] = xd[i, 2];
                        }
                    }
                }
            }
            //하리꼬미 조건 대입
            string j_s = "";
            int j_n = 0;
            string xx_jj = pp[13];  //a,b,c 옵션
            if (pp[13].Length == 1)
            {
                j_s = pp[13];
                j_n = 0;
            }
            else
            {
                j_s = pp[13].Substring(0, 1);
                j_n = Convert.ToInt32(pp[13].Substring(2, 1));
            }
            //
            if (pp[4].Equals("책자형") && j_s.Equals("a"))  ////책자형 중에서 A형
            {
                af_su = f_su + (Convert.ToDouble(pp[3]) * 1) + j_n;  //앞수+(닷찌*1)+넘어오는 수(a+3) 
                ar_su = r_su + (Convert.ToDouble(pp[3]) * 2);        //뒷수+(닷찌*2)
            }
            else if (pp[4].Equals("책자형") && j_s.Equals("b")) //책자형 중에서 B형
            {
                af_su = f_su + (Convert.ToDouble(pp[3]) * 1);      //앞수+(닷찌*1)
                ar_su = r_su + (Convert.ToDouble(pp[3]) * 2);      //뒷수+(닷찌*2)
            }
            else if (pp[4].Equals("책자형") && j_s.Equals("c")) //책자형 중에서 C형
            {
                af_su = f_su + (Convert.ToDouble(pp[3]) * 2);      //앞수+(닷찌*2)
                ar_su = r_su + (Convert.ToDouble(pp[3]) * 2);      //뒷수+(닷찌*2)
            }
            else if (pp[4].Equals("책자형") && j_s.Equals("d")) //책자형 중에서 D형
            {
                af_su = f_su + (Convert.ToDouble(pp[3]) * 2);      //앞수+(닷찌*2)
                ar_su = r_su + (Convert.ToDouble(pp[3]) * 2);      //뒷수+(닷찌*2)
            }
            else   //낱장형 과 나머지
            {
                af_su = f_su + (Convert.ToDouble(pp[3]) * 2);      //앞수+(닷찌*2)
                ar_su = r_su + (Convert.ToDouble(pp[3]) * 2);      //뒷수+(닷찌*2) 
            }
            //
            double t1 = 0.0;
            double t2 = 0.0;
            for (int i = 1; i < 9; i++)    //각줄 종이(인쇄싸이즈)에서 책의 가로,세로로 나누어서 갯수를 구하고 절수를 구함
            {
                if (!xd[i, 1].Equals(0))
                {                         //8절은 정상, 16절은 강제 위치선정 합판에 맞춤, 싸이즈 고정 
                    if (pp[4].Equals("낱장형") && pp[1].Equals("2") && pp[9].Trim().Equals("788*650") && (pp[2].Trim().Equals("260*185") || pp[2].Trim().Equals("185*260")))
                    {
                        t1 = xd[i, 5] / af_su;
                        xd[i, 7] = double.Parse(t1.ToString("#.000"));       //가로 
                        xd[i, 8] = 2;// Math.Round(xd[i, 6] / ar_su, 2);     //세로
                        xd[i, 9] = (int)Math.Floor(xd[i, 7]) * (int)Math.Floor(xd[i, 8]) * xd[i, 3]; //절수
                        break;
                    }
                    else
                    {
                        //앞수 -> 앞수로 나누기
                        t1 = xd[i, 5] / af_su;
                        t2 = xd[i, 6] / ar_su;
                        //
                        xd[i, 7] = double.Parse(t1.ToString("#.000"));   //가로 
                        xd[i, 8] = double.Parse(t2.ToString("#.000"));   //세로
                        xd[i, 9] = (int)Math.Floor(xd[i, 7]) * (int)Math.Floor(xd[i, 8]) * xd[i, 3];     //절수
                    }
                    //
                }
            }
            //낱장형,비규격 조건에서 역방향계산시 종이=788*650 이고 도큐싸이즈가 160*185 or 185*160 이면 세로=2  넣고 빠져나간다
            //
            //
            for (int i = 9; i < 17; i++)    //각줄 종이(인쇄싸이즈)에서 책의 가로,세로로 나누어서 갯수를 구하고 절수를 구함
            {
                if (!xd[i, 1].Equals(0))
                {
                    if (pp[4].Equals("낱장형") && pp[1].Equals("2") && pp[9].Trim().Equals("788*650") && (pp[2].Trim().Equals("260*185") || pp[2].Trim().Equals("185*260")))
                    {
                        t1 = xd[i, 5] / ar_su;
                        xd[i, 7] = double.Parse(t1.ToString("#.000"));       //가로 
                        xd[i, 8] = 2;// Math.Round(xd[i, 6] / af_su, 2);     //세로
                        xd[i, 9] = (int)Math.Floor(xd[i, 7]) * (int)Math.Floor(xd[i, 8]) * xd[i, 3]; //절수
                        break;
                    }
                    else
                    {
                        //앞수 -> 뒷수로 나누기
                        t1 = xd[i, 5] / ar_su;
                        t2 = xd[i, 6] / af_su;
                        //
                        xd[i, 7] = double.Parse(t1.ToString("#.000"));   //가로 
                        xd[i, 8] = double.Parse(t2.ToString("#.000"));   //세로
                        xd[i, 9] = (int)Math.Floor(xd[i, 7]) * (int)Math.Floor(xd[i, 8]) * xd[i, 3];     //절수
                    }
                    //
                }
            }
            //
            if (pp[4].Equals("낱장형") || j_s.Equals("c"))     //낱장형일 경우 와 'c' 인경우에  여분에 추가분 계산
            {
                for (int i = 1; i < 9; i++)   //정방향 계산
                {
                    if (!xd[i, 1].Equals(0))
                    {
                        if (xd[i, 1].Equals(1067) && xd[i, 2].Equals(797))  //제외조건
                            continue;
                        //
                        m1 = (xd[i, 5] - (af_su * (int)Math.Floor(xd[i, 7]))) / ar_su;   //(인쇄종이가로-(앞수*앞갯수)) / 뒷수
                        m2 = xd[i, 6] / af_su;
                        m1 = Math.Round(m1, 2);
                        m2 = Math.Round(m2, 2);
                        if (m1 < 0)
                            m1 = 0;
                        if (m2 < 0)
                            m2 = 0;
                        //
                        xd[i, 16] = (int)Math.Floor(m1) * (int)Math.Floor(m2);  //앞 추가수
                        //
                        m1 = (xd[i, 6] - (ar_su * (int)Math.Floor(xd[i, 8]))) / af_su;   //(인쇄종이세로-(뒷수*뒷갯수)) / 앞수
                        m2 = xd[i, 5] / ar_su;
                        m1 = Math.Round(m1, 2);
                        m2 = Math.Round(m2, 2);
                        if (m1 < 0)
                            m1 = 0;
                        if (m2 < 0)
                            m2 = 0;
                        //
                        xd[i, 17] = (int)Math.Floor(m1) * (int)Math.Floor(m2);  //뒤 추가수
                        //
                        xd[i, 15] = (xd[i, 16] + xd[i, 17]) * xd[i, 3];         //총갯수
                    }
                }
                //
                for (int i = 9; i < 17; i++)  //역방향 계산
                {
                    if (!xd[i, 1].Equals(0))
                    {
                        if (xd[i, 1].Equals(1067) && xd[i, 2].Equals(797))  //제외조건
                            continue;
                        //
                        m1 = (xd[i, 5] - (ar_su * (int)Math.Floor(xd[i, 7]))) / af_su;   //(인쇄종이가로-(뒷수*앞갯수)) / 앞수
                        m2 = xd[i, 6] / ar_su;
                        m1 = Math.Round(m1, 2);
                        m2 = Math.Round(m2, 2);
                        if (m1 < 0)
                            m1 = 0;
                        if (m2 < 0)
                            m2 = 0;
                        //
                        xd[i, 16] = (int)Math.Floor(m1) * (int)Math.Floor(m2);  //앞추가수
                        //
                        m1 = (xd[i, 6] - (af_su * (int)Math.Floor(xd[i, 8]))) / ar_su;   //(인쇄종이세로-(앞수*뒷갯수)) / 뒷수
                        m2 = xd[i, 5] / af_su;
                        m1 = Math.Round(m1, 2);
                        m2 = Math.Round(m2, 2);
                        if (m1 < 0)
                            m1 = 0;
                        if (m2 < 0)
                            m2 = 0;
                        //
                        xd[i, 17] = (int)Math.Floor(m1) * (int)Math.Floor(m2);  //뒤추가수
                        //
                        xd[i, 15] = (xd[i, 16] + xd[i, 17]) * xd[i, 3];         //총갯수
                        //
                    }
                }
            }

            //
            //  책자형은 실절수,계산절수 동일하게 가고, 낱장형은 비율공식에 따라 계산 절수가 수정됨
            Double q_su = 0;
            for (int i = 0; i < 17; i++)
            {
                if (!xd[i, 1].Equals(0))
                {
                    if (pp[4].Equals("책자형") && j_s.Equals("a"))   //책자형 'a' 일 경우
                        xd[i, 10] = xd[i, 9];
                    else                          //낱장형
                    {
                        xd[i, 9] = xd[i, 9] + xd[i, 15];
                        //
                        if (xd[i, 1].Equals(939))       //939*636
                            q_su = 1;
                        else if (xd[i, 1].Equals(880))  //880*625
                            q_su = 1.09;
                        else if (xd[i, 1].Equals(636))  //636*467
                            q_su = 0.99;
                        else if (xd[i, 1].Equals(788))  //788*545
                            q_su = 0.72;
                        else if (xd[i, 1].Equals(760))  //760*545
                            q_su = 0.73;
                        else if (xd[i, 1].Equals(1067)) //1067*797
                            q_su = 0.71;
                        else if (xd[i, 1].Equals(1091)) //1091*788
                            q_su = 0.70;
                        else if (xd[i, 1].Equals(543))  //543*392 
                            q_su = 0.68;
                        else if (xd[i, 1].Equals(543))  //543*392 
                            q_su = 0.68;
                        else if (xd[i, 1].Equals(310))  //310*215 
                            q_su = 1;
                        else if (xd[i, 1].Equals(438))  //438*310 
                            q_su = 1.1;
                        else if (xd[i, 1].Equals(464))  //464*315 
                            q_su = 1.1;
                        else if (xd[i, 1].Equals(320))  //320*233 
                            q_su = 1;
                        else if (xd[i, 1].Equals(430))  //430*305 
                            q_su = 1.1;
                        else if (xd[i, 1].Equals(460))  //460*310 
                            q_su = 1.1;
                        else if (xd[i, 1].Equals(390))  //390*270 
                            q_su = 0.71;
                        else if (xd[i, 1].Equals(485))  //485*330 
                            q_su = 0.72;
                        else if (xd[i, 1].Equals(360))  //360*260 
                            q_su = 0.7;
                        //
                        else
                            q_su = 1;
                        // 
                        xd[i, 10] = xd[i, 9] * q_su;    //환산절수
                    }
                }
            }
            //도지 및 최종 절수 구하기 -----------------------------------
            if (pp[4].Equals("책자형") && j_s.Equals("a"))     //책자형 'a' 일 경우에
            {
                //도지선택
                for (int i = 1; i < 17; i++)
                {
                    if (!xd[i, 1].Equals(0))
                    {
                        if (i <= 8)        //정방향 사용
                            xd[i, 11] = 2; //"세로";
                        else
                            xd[i, 11] = 1; //"가로";  //역방향
                        //
                        if (f_su <= r_su)   //f_su-->책싸이즈의 앞수,r_su-->책싸이즈의 뒷수
                            xd[i, 13] = 2;  //좌
                        else
                            xd[i, 13] = 1;  //상
                    }
                }
            }
            else            //낱장형일 경우  // ------------
            {
                for (int i = 1; i < 17; i++)
                {
                    if (!xd[i, 1].Equals(0))
                    {
                        if (i <= 8)
                        {
                            xd[i, 11] = 2;    //세로
                            xd[i, 12] = 2;    //횡목
                        }
                        else
                        {
                            xd[i, 11] = 1;    //가로
                            xd[i, 12] = 1;    //종목
                        }
                        //
                        if (xd[i, 3] == 2)    //2절이라면 서로 교체
                        {
                            if (xd[i, 12] == 2)  //종목
                                xd[i, 12] = 1;   //횡목
                            else
                                xd[i, 12] = 2;   //횡목
                        }
                        //
                        if (f_su <= r_su)
                            xd[i, 13] = 2;  //좌
                        else
                            xd[i, 13] = 1;  //상
                    }
                }
                //
            }   //선택 절수구하기 끝  ----------------------------------------------------- 여기서 부터
            //  -------------------------------------- 책자형 인 경우 db 자료검색하기
            a_xno[21] = "";
            if (pp[4].Equals("책자형") && j_s.Equals("a")) //최종 확인 테이블에서 자료확인 ------------------------------------------------------
            {
                string aa = "";    //국,46(검색조건)
                string bb = "";    //좌,상(검색조건)
                string cc = "";    //도지(검색조건)
                string jj = "";    //절수(책싸이즈 절수)(검색조건)
                string mm = "";    //절수(인쇄절수)(검색조건)
                int xjj = 0;       //숫자절수(책싸이즈 절수)
                int garo = 0;      //가로갯수(검색조건)
                int sero = 0;      //세로갯수(검색조건)
                int x1 = 0;
                int x2 = 0;
                string w_id = "";
                string jamul = "";
                if (pp[5].Equals("재물"))
                    jamul = "1091";
                else
                    jamul = "1067";
                //         
                if (pp[11] == "01" || pp[11] == "02" || pp[11] == "03")
                    w_id = "b";  //기타인쇄
                else
                    w_id = "a";  //옵셋인쇄
                //
                string find_id = "";  //종이싸이즈 앞수
                string pan_id = "";   //판걸이 확인수
                string[] fff = pp[2].Split(new char[1] { '*' });      //도큐싸이즈

                //사용업체별 변동자료 적용
                if (pp[6] == "02" && Convert.ToInt32(fff[1]) <= 140)  //중철제본  
                    pan_id = "1";
                else if (Convert.ToInt32(fff[1]) <= 132)              //나머지
                    pan_id = "1";
                else
                    pan_id = "";


                //
                for (int a = 1; a < 17; a++)
                {
                    if (!xd[a, 1].Equals(0))
                    {
                        find_id = xd[a, 1].ToString().Trim();  //종이싸이즈 앞수
                        if (xd[a, 4] == 1)
                            aa = "국";   //국,46
                        else
                            aa = "46";
                        //
                        if (xd[a, 13] == 1)
                            bb = "상";   //상,좌
                        else
                            bb = "좌";
                        //
                        jj = "";                          //절수
                        xjj = (int)Math.Floor(xd[a, 9]);  //숫자절수(실절수)
                        if (xd[a, 3] == 2)                //종이절수가 2절이라면(46)
                        {
                            garo = (int)Math.Floor(xd[a, 8]) * 2; //가로=세로*2
                            sero = (int)Math.Floor(xd[a, 7]);     //가로
                            if (xd[a, 11] == 1)
                                cc = "세로";   //도지6
                            else
                                cc = "가로";
                        }
                        else                                    //국
                        {
                            garo = (int)Math.Floor(xd[a, 7]);   //가로
                            sero = (int)Math.Floor(xd[a, 8]);   //세로
                            if (xd[a, 11] == 1)
                                cc = "가로";   //도지6
                            else
                                cc = "세로";
                        }
                        mm = Convert.ToString(xd[a, 3]);  //인쇄절수
                        x1 = 0;
                        x2 = 0;
                        //
                        int sno = 999;
                        //
                        string k_id = "x";
                        //MessageBox.Show(aa + "/" + bb + "/" + cc + "/" + xjj.ToString() + "/" + garo + "/" + sero + "/" + mm + "/" + w_id+"/"+pp[1]);
                        if (pp[1].Equals("1"))     //1=규격지    ,2=별지
                        {
                            for (int m = xjj; m > 0; m--)  //절수 1씩 줄여가면서 0이 될때까지 계속
                            {
                                jj = m.ToString().Trim();
                                for (int i = 0; i < p_dt.Rows.Count; i++)
                                {
                                    x1 = Convert.ToInt32(p_dt.Rows[i][7]);
                                    x2 = Convert.ToInt32(p_dt.Rows[i][8]);
                                    if (p_dt.Rows[i][0].ToString().Trim().Equals(aa) && p_dt.Rows[i][1].ToString().Trim().Equals(bb)
                                        && p_dt.Rows[i][6].ToString().Trim().Equals(cc) && p_dt.Rows[i][2].ToString().Trim().Equals(jj)
                                        && x1 == garo && x2 == sero && p_dt.Rows[i][3].ToString().Trim().Equals(mm)
                                        && p_dt.Rows[i][21].ToString().Trim().Equals(w_id) && !p_dt.Rows[i][9].ToString().Equals(pan_id))
                                    {
                                        if (find_id.Equals(jamul) && p_dt.Rows[i][16].ToString() == "")   //1091,1067 이 아니고 / da1 필드가 공문자가 아닌경우
                                        {
                                        }
                                        else
                                        {
                                            sno = i;
                                            break;
                                        }
                                    }
                                }
                                if (sno != 999)
                                    break;
                            }
                        }
                        else         //별지 일경우
                        {
                            k_id = "x";
                            sno = 999;
                            //
                            for (int v = 1; v < 20; v++)  //
                            {
                                xjj = (int)Math.Floor(xd[a, 9]);  //숫자절수
                                //
                                for (int m = xjj; m > 0; m--)  //절수 1씩 줄여가면서 0이 될때까지 계속
                                {
                                    jj = m.ToString().Trim();
                                    for (int i = 0; i < p_dt.Rows.Count; i++)
                                    {
                                        x1 = Convert.ToInt32(p_dt.Rows[i][7]);
                                        x2 = Convert.ToInt32(p_dt.Rows[i][8]);
                                        if (p_dt.Rows[i][0].ToString().Trim().Equals(aa) && p_dt.Rows[i][1].ToString().Trim().Equals(bb)
                                            && p_dt.Rows[i][6].ToString().Trim().Equals(cc) && p_dt.Rows[i][2].ToString().Trim().Equals(jj)
                                            && x1 == garo && x2 == sero && p_dt.Rows[i][3].ToString().Trim().Equals(mm)
                                            && p_dt.Rows[i][21].ToString().Trim().Equals(w_id) && !p_dt.Rows[i][9].ToString().Equals(pan_id))
                                        {
                                            if (find_id.Equals("1067") && p_dt.Rows[i][16].ToString() == "")
                                            {
                                            }
                                            else
                                            {
                                                sno = i;
                                                break;
                                            }
                                        }
                                    }
                                    if (sno != 999)
                                        break;
                                }
                                if (sno != 999)
                                    break;
                                //
                                if (k_id == "x")
                                {
                                    //가로 세로 줄이기
                                    if (garo >= sero)
                                    {
                                        garo = --garo;   //가로
                                        k_id = "s";
                                    }
                                    else
                                    {
                                        sero = --sero;   //세로
                                        k_id = "g";
                                    }
                                }
                                else if (k_id == "g")   //가로
                                {
                                    garo = --garo;    //가로
                                    k_id = "s";
                                }
                                else                  //k_id == "s" 세로
                                {
                                    sero = --sero;   //세로
                                    k_id = "g";
                                }
                            }
                        }
                        //
                        if (sno != 999)
                        {
                            xd[a, 18] = Convert.ToDouble(p_dt.Rows[sno][2]);  //절수
                            xd[a, 19] = Convert.ToDouble(p_dt.Rows[sno][4]);  //실가로
                            xd[a, 20] = Convert.ToDouble(p_dt.Rows[sno][5]);  //실세로
                            if (p_dt.Rows[sno][10].Equals("종목"))
                                xd[a, 21] = 1; //종목
                            else
                                xd[a, 21] = 2; //횡목
                            //
                            if (p_dt.Rows[sno][6].Equals("가로"))
                                xd[a, 22] = 1; //가로
                            else
                                xd[a, 22] = 2; //세로
                            //
                            if (!p_dt.Rows[sno][9].Equals(""))
                            {
                                xd[a, 23] = Convert.ToDouble(p_dt.Rows[sno][9]);  //판걸이
                            }

                            if (!p_dt.Rows[sno][11].Equals(""))
                                xd[a, 24] = Convert.ToDouble(p_dt.Rows[sno][11]); //연결번호
                            //
                            xd[a, 25] = sno;                                      //p_dat 테이블의 row 번호
                        }
                        else
                            xd[a, 21] = 3;  //불가로 이용
                        //
                    }
                }
            }   //====================================== 
            // 책자형일 경우 절수 환산하기
            Double x_su = 0;
            if (pp[4].Equals("책자형") && j_s.Equals("a"))     //책자형 'a' 일 경우에
            {
                for (int v = 1; v < 17; v++)
                {
                    if (xd[v, 1].Equals(939))      //939*636
                        x_su = 1;
                    else if (xd[v, 1].Equals(880)) //880*625
                        x_su = 1.09;
                    else if (xd[v, 1].Equals(636))  //636*467
                        x_su = 0.99;
                    else if (xd[v, 1].Equals(788))  //788*545
                        x_su = 0.72;
                    else if (xd[v, 1].Equals(760))  //760*545
                        x_su = 0.73;
                    else if (xd[v, 1].Equals(1067)) //1067*797
                        x_su = 0.71;
                    else if (xd[v, 1].Equals(1091)) //1091*788
                        x_su = 0.70;
                    else if (xd[v, 1].Equals(543))  //543*392 
                        x_su = 0.68;
                    else if (xd[v, 1].Equals(310))  //310*215 
                        x_su = 1;
                    else if (xd[v, 1].Equals(438))  //438*310 
                        x_su = 1.1;
                    else if (xd[v, 1].Equals(464))  //464*315 
                        x_su = 1.1;
                    else if (xd[v, 1].Equals(320))  //320*233 
                        x_su = 1;
                    else if (xd[v, 1].Equals(430))  //430*305 
                        x_su = 1.1;
                    else if (xd[v, 1].Equals(460))  //460*310 
                        x_su = 1.1;
                    else if (xd[v, 1].Equals(390))  //390*270 
                        x_su = 0.71;
                    else if (xd[v, 1].Equals(485))  //485*330 
                        x_su = 0.72;
                    else if (xd[v, 1].Equals(360))  //360*260 
                        x_su = 0.7;
                    //
                    else
                        x_su = 1;
                    // 
                    xd[v, 14] = xd[v, 18] * x_su;//환산절수
                }
            }
            // 최종선택하기  ==================================================================
            if (pp[4].Equals("책자형") && j_s.Equals("a"))     //책자형 'a' 일 경우에
            {
                if (select_id == false)  //종이, 가로, 세로, 에서 찾기
                {
                    double jul = 0;
                    double x_nu = 0;  //여분수
                    x_su = 0;
                    //
                    string[] paper = sub[0].Split(new char[1] { '*' });
                    //
                    int paper_garo = Convert.ToInt32(paper[0]);
                    int paper_sero = Convert.ToInt32(paper[1]);
                    int garo_su = Convert.ToInt32(sub[1]);
                    int sero_su = Convert.ToInt32(sub[2]);
                    int tem = 0;
                    //
                    if (paper_garo < paper_sero)  //종이 앞수 큰수로 가져오기
                    {
                        tem = paper_garo;
                        paper_garo = paper_sero;
                        paper_sero = tem;
                    }
                    //
                    for (int v = 1; v < 17; v++)
                    {
                        if (paper_garo == xd[v, 1] && paper_sero == xd[v, 2] && garo_su == xd[v, 19] && sero_su == xd[v, 20])  //종이 가로,세로 수 같다면
                        {
                            a_xno[0] = Convert.ToString(xd[v, 18]); //절수
                            a_xno[1] = Convert.ToString(xd[v, 1]);  //선택종이좌
                            a_xno[2] = Convert.ToString(xd[v, 2]);  //선택종이우
                            if (xd[v, 4] == 1)
                                a_xno[3] = "국";//국,46
                            else
                                a_xno[3] = "46";
                            //  
                            if (xd[v, 13] == 1)
                                a_xno[4] = "상";//상,좌
                            else
                                a_xno[4] = "좌";

                            if (xd[v, 21] == 1)
                                a_xno[5] = "종목";//종,횡
                            else
                                a_xno[5] = "횡목";
                            a_xno[6] = Convert.ToString(xd[v, 23]);         //판걸이
                            a_xno[7] = Convert.ToString(xd[v, 24]);         //연결번호
                            a_xno[11] = Convert.ToString(xd[v, 25]);        //선택된 p_dt row 번호
                            a_xno[12] = Convert.ToString(v);                //선택된 xd row 번호
                            //                        
                            if (v <= 8)
                                a_xno[16] = "횡목";   //정방향 선택시 
                            else
                                a_xno[16] = "종목";   //역방향 선택시 
                            // 
                            a_xno[17] = Convert.ToString(xd[v, 3]);   //종이절수
                            a_xno[18] = Convert.ToString(xd[v, 9]);   //실절수
                            a_xno[19] = Convert.ToString(xd[v, 19]);  //실가로
                            a_xno[20] = Convert.ToString(xd[v, 20]);  //실세로
                            a_xno[21] = p_dt.Rows[Convert.ToInt32(xd[v, 25])][22].ToString();  //row_id
                            jul = xd[v, 3];
                            x_su = xd[v, 14];
                            x_nu = (xd[v, 7] - (int)Math.Floor(xd[v, 7])) + (xd[v, 8] - (int)Math.Floor(xd[v, 8]));
                            break;
                        }
                    }
                }
                else     //가장 효과적인 절수 찾기
                {
                    double jul = 0;
                    double x_nu = 0;  //여분수
                    x_su = 0;
                    for (int v = 1; v < 17; v++)
                    {
                        if (xd[v, 14] > x_su)
                        {
                            a_xno[0] = Convert.ToString(xd[v, 18]); //절수
                            a_xno[1] = Convert.ToString(xd[v, 1]);  //선택종이좌
                            a_xno[2] = Convert.ToString(xd[v, 2]);  //선택종이우
                            if (xd[v, 4] == 1)
                                a_xno[3] = "국";//국,46
                            else
                                a_xno[3] = "46";
                            //  
                            if (xd[v, 13] == 1)
                                a_xno[4] = "상";//상,좌
                            else
                                a_xno[4] = "좌";

                            if (xd[v, 21] == 1)
                                a_xno[5] = "종목";//종,횡
                            else
                                a_xno[5] = "횡목";
                            a_xno[6] = Convert.ToString(xd[v, 23]);         //판걸이
                            a_xno[7] = Convert.ToString(xd[v, 24]);         //연결번호
                            a_xno[11] = Convert.ToString(xd[v, 25]);        //선택된 p_dt row 번호
                            a_xno[12] = Convert.ToString(v);                //선택된 xd row 번호
                            //                        
                            if (v <= 8)
                                a_xno[16] = "횡목";   //정방향 선택시 
                            else
                                a_xno[16] = "종목";   //역방향 선택시 
                            // 
                            a_xno[17] = Convert.ToString(xd[v, 3]);  //종이절수
                            a_xno[18] = Convert.ToString(xd[v, 9]);  //실절수
                            a_xno[19] = Convert.ToString(xd[v, 19]);  //실가로
                            a_xno[20] = Convert.ToString(xd[v, 20]);  //실세로
                            a_xno[21] = p_dt.Rows[Convert.ToInt32(xd[v, 25])][22].ToString();  //row_id
                            jul = xd[v, 3];
                            x_su = xd[v, 14];
                            x_nu = (xd[v, 7] - (int)Math.Floor(xd[v, 7])) + (xd[v, 8] - (int)Math.Floor(xd[v, 8]));
                        }
                        else if (xd[v, 14] == x_su)  //같다면
                        {
                            if (x_nu > (xd[v, 7] - (int)Math.Floor(xd[v, 7])) + (xd[v, 8] - (int)Math.Floor(xd[v, 8])))
                            {
                                a_xno[0] = Convert.ToString(xd[v, 18]); //절수
                                a_xno[1] = Convert.ToString(xd[v, 1]);  //선택종이좌
                                a_xno[2] = Convert.ToString(xd[v, 2]);  //선택종이우
                                if (xd[v, 4] == 1)
                                    a_xno[3] = "국";//국,46
                                else
                                    a_xno[3] = "46";
                                //  
                                if (xd[v, 13] == 1)
                                    a_xno[4] = "상";//상,좌
                                else
                                    a_xno[4] = "좌";

                                if (xd[v, 21] == 1)
                                    a_xno[5] = "종목";//종,횡
                                else
                                    a_xno[5] = "횡목";
                                a_xno[6] = Convert.ToString(xd[v, 23]);         //판걸이
                                a_xno[7] = Convert.ToString(xd[v, 24]);         //연결번호
                                a_xno[11] = Convert.ToString(xd[v, 25]);        //선택된 p_dt row 번호
                                a_xno[12] = Convert.ToString(v);                //선택된 xd row 번호
                                //                        
                                if (v <= 8)
                                    a_xno[16] = "횡목";   //정방향 선택시 
                                else
                                    a_xno[16] = "종목";   //역방향 선택시 
                                // 
                                a_xno[17] = Convert.ToString(xd[v, 3]);  //종이절수
                                a_xno[18] = Convert.ToString(xd[v, 9]);  //실절수
                                a_xno[19] = Convert.ToString(xd[v, 19]);  //실가로
                                a_xno[20] = Convert.ToString(xd[v, 20]);  //실세로
                                a_xno[21] = p_dt.Rows[Convert.ToInt32(xd[v, 25])][22].ToString();  //row_id
                                jul = xd[v, 3];
                                x_su = xd[v, 14];
                                x_nu = (xd[v, 7] - (int)Math.Floor(xd[v, 7])) + (xd[v, 8] - (int)Math.Floor(xd[v, 8]));
                            }
                        }
                    }
                }
                //
                if (a_xno[1].Equals("1067") && a_xno[2].Equals("797"))   //
                {
                    a_xno[14] = a_xno[1];  //원 선택종이좌
                    a_xno[15] = a_xno[2];  //원 선택종이우
                    a_xno[1] = "1091";     //선택종이좌
                    a_xno[2] = "788";      //선택종이우
                }
                else if (a_xno[1].Equals("797") && a_xno[2].Equals("1067"))
                {
                    a_xno[14] = a_xno[1];  //원 선택종이좌
                    a_xno[15] = a_xno[2];  //원 선택종이우
                    a_xno[1] = "788";      //선택종이좌
                    a_xno[2] = "1091";     //선택종이우
                }
                else
                {
                    a_xno[14] = a_xno[1];  //원 선택종이좌
                    a_xno[15] = a_xno[2];  //원 선택종이우
                }
                // 
                a_xno[13] = "";
                // 책자형 'a' 일경우 끝 ============================================
            }
            else   //낱장형
            {
                double jul = 0;
                double x_nu = 0;  //여분수
                x_su = 0;
                for (int v = 1; v < 17; v++)
                {
                    if (xd[v, 10] > x_su)
                    {
                        a_xno[0] = Convert.ToString(xd[v, 9]);  //절수
                        a_xno[1] = Convert.ToString(xd[v, 1]);  //선택종이좌
                        a_xno[2] = Convert.ToString(xd[v, 2]);  //선택종이우
                        if (xd[v, 4] == 1)
                            a_xno[3] = "국";//국,46
                        else
                            a_xno[3] = "46";
                        //  
                        if (xd[v, 13] == 1)
                            a_xno[4] = "상";//상,좌
                        else
                            a_xno[4] = "좌";

                        if (xd[v, 12] == 1)
                            a_xno[5] = "종목";//종,횡
                        else
                            a_xno[5] = "횡목";
                        a_xno[6] = "1"; //판걸이
                        a_xno[7] = "";  //연결번호
                        a_xno[11] = ""; //선택된 p_dt row 번호
                        a_xno[12] = Convert.ToString(v);  //선택된 xd row 번호
                        //                        
                        if (v <= 8)
                            a_xno[16] = "횡목";   //정방향 선택시 
                        else
                            a_xno[16] = "종목";   //역방향 선택시 
                        // 
                        a_xno[17] = Convert.ToString(xd[v, 3]);  //종이절수
                        a_xno[18] = Convert.ToString(xd[v, 9]);  //실절수
                        a_xno[19] = Convert.ToString(xd[v, 7]);  //앞갯수
                        a_xno[20] = Convert.ToString(xd[v, 8]);  //뒷갯수
                        //
                        jul = xd[v, 3];
                        x_su = xd[v, 10];
                        x_nu = (xd[v, 7] - (int)Math.Floor(xd[v, 7])) + (xd[v, 8] - (int)Math.Floor(xd[v, 8]));
                    }
                    else if (xd[v, 10] == x_su)  //같다면
                    {
                        if (x_nu > (xd[v, 7] - (int)Math.Floor(xd[v, 7])) + (xd[v, 8] - (int)Math.Floor(xd[v, 8])))
                        {
                            a_xno[0] = Convert.ToString(xd[v, 9]);  //절수
                            a_xno[1] = Convert.ToString(xd[v, 1]);  //선택종이좌
                            a_xno[2] = Convert.ToString(xd[v, 2]);  //선택종이우
                            if (xd[v, 4] == 1)
                                a_xno[3] = "국";//국,46
                            else
                                a_xno[3] = "46";
                            //  
                            if (xd[v, 13] == 1)
                                a_xno[4] = "상";//상,좌
                            else
                                a_xno[4] = "좌";

                            if (xd[v, 12] == 1)
                                a_xno[5] = "종목";//종,횡
                            else
                                a_xno[5] = "횡목";
                            a_xno[6] = "1";//판걸이
                            a_xno[7] = ""; //연결번호
                            a_xno[11] = "";//선택된 p_dt row 번호
                            a_xno[12] = Convert.ToString(v);  //선택된 xd row 번호
                            //                        
                            if (v <= 8)
                                a_xno[16] = "횡목";   //정방향 선택시 
                            else
                                a_xno[16] = "종목";   //역방향 선택시 
                            // 
                            a_xno[17] = Convert.ToString(xd[v, 3]);  //종이절수
                            a_xno[18] = Convert.ToString(xd[v, 9]);  //실절수
                            a_xno[19] = Convert.ToString(xd[v, 7]);  //앞갯수
                            a_xno[20] = Convert.ToString(xd[v, 8]);  //뒷갯수
                            jul = xd[v, 3];
                            x_su = xd[v, 10];
                            x_nu = (xd[v, 7] - (int)Math.Floor(xd[v, 7])) + (xd[v, 8] - (int)Math.Floor(xd[v, 8]));
                        }
                    }
                }
                //
                a_xno[13] = "";
                //
                if (xd[Convert.ToInt32(a_xno[12]), 15] == 0)  //추가수가 0 이라면
                {
                    if ((a_xno[1].Equals("1091") && a_xno[2].Equals("788")) || (a_xno[1].Equals("788") && a_xno[2].Equals("1091")))// 재물 닷찌조건
                    {
                        int xx1 = Convert.ToInt32(a_xno[12]);  //선택된 row_no
                        int xx2 = (int)Math.Floor(xd[xx1, 7]); //나눈 앞갯수
                        // 
                        if (xx2.Equals(3) || xx2.Equals(5) || xx2.Equals(7) || xx2.Equals(9) || xx2.Equals(11))
                        {
                            a_xno[14] = a_xno[1];  //원 선택종이좌
                            a_xno[15] = a_xno[2];  //원 선택종이우
                            a_xno[13] = "※";
                        }
                    }
                    else if ((a_xno[1].Equals("1067") && a_xno[2].Equals("797")) || (a_xno[1].Equals("797") && a_xno[2].Equals("1067")))// 일반 닷찌조건
                    {
                        int xx1 = Convert.ToInt32(a_xno[12]);
                        int xx2 = (int)Math.Floor(xd[xx1, 7]);
                        if (xx2.Equals(3) || xx2.Equals(5) || xx2.Equals(7) || xx2.Equals(9) || xx2.Equals(11))
                        {
                            a_xno[14] = a_xno[1];  //원 선택종이좌
                            a_xno[15] = a_xno[2];  //원 선택종이우
                            a_xno[13] = "※";
                            //
                            if (a_xno[1].Equals("1067") && a_xno[2].Equals("797"))
                            {
                                a_xno[1] = "1091";     //선택종이좌
                                a_xno[2] = "788";      //선택종이우
                            }
                            else
                            {
                                a_xno[1] = "788";     //선택종이좌
                                a_xno[2] = "1091";    //선택종이우
                            }
                        }
                        else   //
                        {
                            if (a_xno[1].Equals("1067") && a_xno[2].Equals("797"))
                            {
                                a_xno[1] = "1091";     //선택종이좌
                                a_xno[2] = "788";      //선택종이우
                            }
                            else
                            {
                                a_xno[1] = "788";     //선택종이좌
                                a_xno[2] = "1091";    //선택종이우
                            }
                            a_xno[14] = a_xno[1];  //원 선택종이좌
                            a_xno[15] = a_xno[2];  //원 선택종이우
                        }
                    }
                    else
                    {
                        a_xno[14] = a_xno[1];  //원 선택종이좌
                        a_xno[15] = a_xno[2];  //원 선택종이우
                    }
                }
                else
                {
                    a_xno[14] = a_xno[1];  //원 선택종이좌
                    a_xno[15] = a_xno[2];  //원 선택종이우
                }
            }
            //선택 종이 싸이즈 수정하기
            if (Convert.ToInt32(a_xno[12]) >= 9)
            {
                string tem1 = a_xno[1];
                string tem2 = a_xno[2];
                a_xno[1] = tem2;//선택종이좌
                a_xno[2] = tem1;//선택종이우
            }
            //
            a_xno[8] = pp[3];                   //닷찌  
            a_xno[9] = Convert.ToString(af_su); //앞수+(닷찌*2)  
            a_xno[10] = Convert.ToString(ar_su);//뒷수+(닷찌*2)
            //
            if (f_id == true)  //결과표 보이기
            {
                bool xxx = false;
                if (a_xno[11] != null && a_xno[11] != "")
                {
                    if (p_dt.Rows[Convert.ToInt32(a_xno[11])]["da1"] != "" && a_xno[14] == "1067")
                        xxx = true;
                    else
                        xxx = false;
                }
                //  
                if (pp[4].Equals("책자형") && j_s.Equals("a"))     //책자형일 경우에
                {
                    
                }
                else    //낱장형
                {
                   
                }
            }
            //
            return a_xno;
        }
    }

    static public class cEventHelper
    {
        static Dictionary<Type, List<FieldInfo>> dicEventFieldInfos = new Dictionary<Type, List<FieldInfo>>();

        static BindingFlags AllBindings
        {
            get { return BindingFlags.IgnoreCase | BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.Static; }
        }

        //--------------------------------------------------------------------------------
        static List<FieldInfo> GetTypeEventFields(Type t)
        {
            if (dicEventFieldInfos.ContainsKey(t))
                return dicEventFieldInfos[t];

            List<FieldInfo> lst = new List<FieldInfo>();
            BuildEventFields(t, lst);
            dicEventFieldInfos.Add(t, lst);
            return lst;
        }

        //--------------------------------------------------------------------------------
        static void BuildEventFields(Type t, List<FieldInfo> lst)
        {
            // Type.GetEvent(s) gets all Events for the type AND it's ancestors
            // Type.GetField(s) gets only Fields for the exact type.
            //  (BindingFlags.FlattenHierarchy only works on PROTECTED & PUBLIC
            //   doesn't work because Fieds are PRIVATE)

            // NEW version of this routine uses .GetEvents and then uses .DeclaringType
            // to get the correct ancestor type so that we can get the FieldInfo.
            foreach (EventInfo ei in t.GetEvents(AllBindings))
            {
                Type dt = ei.DeclaringType;
                FieldInfo fi = dt.GetField(ei.Name, AllBindings);
                if (fi != null)
                    lst.Add(fi);
            }

            // OLD version of the code - called itself recursively to get all fields
            // for 't' and ancestors and then tested each one to see if it's an EVENT
            // Much less efficient than the new code
            /*
                  foreach (FieldInfo fi in t.GetFields(AllBindings))
                  {
                    EventInfo ei = t.GetEvent(fi.Name, AllBindings);
                    if (ei != null)
                    {
                      lst.Add(fi);
                      Console.WriteLine(ei.Name);
                    }
                  }
                  if (t.BaseType != null)
                    BuildEventFields(t.BaseType, lst);*/
        }

        //--------------------------------------------------------------------------------
        static EventHandlerList GetStaticEventHandlerList(Type t, object obj)
        {
            MethodInfo mi = t.GetMethod("get_Events", AllBindings);
            return (EventHandlerList)mi.Invoke(obj, new object[] { });
        }

        //--------------------------------------------------------------------------------
        public static void RemoveAllEventHandlers(object obj) { RemoveEventHandler(obj, ""); }

        //--------------------------------------------------------------------------------
        public static void RemoveEventHandler(object obj, string EventName)
        {
            if (obj == null)
                return;

            Type t = obj.GetType();
            List<FieldInfo> event_fields = GetTypeEventFields(t);
            EventHandlerList static_event_handlers = null;

            foreach (FieldInfo fi in event_fields)
            {
                if (EventName != "" && string.Compare(EventName, fi.Name, true) != 0)
                    continue;

                // After hours and hours of research and trial and error, it turns out that
                // STATIC Events have to be treated differently from INSTANCE Events...
                if (fi.IsStatic)
                {
                    // STATIC EVENT
                    if (static_event_handlers == null)
                        static_event_handlers = GetStaticEventHandlerList(t, obj);

                    object idx = fi.GetValue(obj);
                    Delegate eh = static_event_handlers[idx];
                    if (eh == null)
                        continue;

                    Delegate[] dels = eh.GetInvocationList();
                    if (dels == null)
                        continue;

                    EventInfo ei = t.GetEvent(fi.Name, AllBindings);
                    foreach (Delegate del in dels)
                        ei.RemoveEventHandler(obj, del);
                }
                else
                {
                    // INSTANCE EVENT
                    EventInfo ei = t.GetEvent(fi.Name, AllBindings);
                    if (ei != null)
                    {
                        object val = fi.GetValue(obj);
                        Delegate mdel = (val as Delegate);
                        if (mdel != null)
                        {
                            foreach (Delegate del in mdel.GetInvocationList())
                                ei.RemoveEventHandler(obj, del);
                        }
                    }
                }
            }
        }
    }

    public class c_string
    {
        public static string remove_zero(string dat)   //
        {
            string dd = dat;
            if (!dat.Contains("."))
                return dd;
            //
            dd = dat.Replace(",", "").Trim();
            for (int n = 1; n < 100; n++)
            {
                if (dd.Substring(dd.Length - 1, 1) == "0")
                    dd = dd.Substring(0, dd.Length - 1);
                else
                    break;
            }
            //
            if (dd.Substring(dd.Length - 1, 1) == ".")
                dd = dd.Substring(0, dd.Length - 1);
            //
            return dd;
        }

        public static string Rzero_Icoma(string dat)   //
        {
            string ss = "";  //최종값
            string mm = "";  //중간에 '.'이후값
            string dd = dat.Replace(",", "").Trim();
            string[] a_dd = new string[14];
            for (int n = 0; n < 14; n++)
            {
                a_dd[n] = "x";
            }
            //
            if (dd.Contains("."))
            {
                for (int n = 1; n < 100; n++)
                {
                    if (dd.Substring(dd.Length - 1, 1) == "0")
                        dd = dd.Substring(0, dd.Length - 1);
                    else
                        break;
                }
                //
                if (dd.Substring(dd.Length - 1, 1) == ".")
                    dd = dd.Substring(0, dd.Length - 1);
            }
            //
            if (dd.Contains("."))
            {
                int index = dd.LastIndexOf('.');
                mm = dd.Substring(index);
                dd = dd.Substring(0, index);
            }
            //
            if (dd.Length > 3)
            {
                int ano = 13;
                int coma = 1;
                for (int n = dd.Length - 1; n >= 0; n--)
                {
                    a_dd[ano] = dd.Substring(n, 1);
                    if (coma % 3 == 0)
                    {
                        ano--;
                        a_dd[ano] = ",";
                        ano--;
                        coma = 1;
                    }
                    else
                    {
                        ano--;
                        coma++;
                    }
                }
                for (int n = 0; n < 14; n++)
                {
                    if (a_dd[n] != "x")
                        ss += a_dd[n];
                }
            }
            else
                ss = dd;
            //
            ss = ss.TrimStart(new char[1] { ',' });
            string tt = ss + mm;
            if (tt.Contains("-,"))
            {
                tt = tt.Substring(2);
                tt = "-" + tt;
            }
            return tt;
        }
    }
    
}
