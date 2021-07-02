using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Runtime.InteropServices;
using MySql.Data.MySqlClient;
using System.Net;
using System.Reflection;

namespace Dukyou3
{
    public partial class login : Form
    {
        string DB_TableName_client = "C_client";

        //string[] result1;
        //string[] result2;
        [DllImport("P_B2_import.dll", CallingConvention = CallingConvention.Cdecl)]
        private static extern void Chk_Mac(StringBuilder _input, StringBuilder _output1, StringBuilder _output2);


        public login()
        {
            InitializeComponent();
            connect_chk();
        }

        private void login_Load(object sender, EventArgs e)
        {
            textIP.Text = Properties.Settings.Default.ip;
            txtID.Text = Properties.Settings.Default.id;
            txtPwd.Text = Properties.Settings.Default.pw;

            string mysql_dll_path = Application.StartupPath + "\\MySql.Data.dll";
            //mysql_dll_down(mysql_dll_path);

            //FileInfo fileInfo = new FileInfo(mysql_dll_path);
            ////파일 있는지 확인 있을때(true), 없으면(false)
            //bool file_chk = fileInfo.Exists;
            //if (!fileInfo.Exists)
            //    mysql_dll_down(mysql_dll_path);
            //else
            //{
            //    //Assembly assembly = Assembly.LoadFrom("MySql.Data.dll");
            //    //Version ver = assembly.GetName().Version;

            //    AppDomain dom = AppDomain.CreateDomain("some");
            //    AssemblyName assemblyName = new AssemblyName();
            //    assemblyName.CodeBase = mysql_dll_path;
            //    Assembly assembly = dom.Load(assemblyName);
            //    Type[] types = assembly.GetTypes();
            //    AppDomain.Unload(dom);

            //    //if (ver.ToString() != "6.6.4.0")
            //        mysql_dll_down(mysql_dll_path);

            //}
            
            

        }
        private void mysql_dll_down(string mysql_dll_path)
        {
            string ftp_user = "other_file";
            string ftp_pw = "emotion$#@!";
            using (WebClient client = new WebClient())
            {
                client.Credentials = new NetworkCredential(ftp_user, ftp_pw);
                client.Encoding = Encoding.Default;
                client.DownloadFile("ftp://peras1.synology.me:21212/home/main3_mysql/MySql.Data.dll", mysql_dll_path);
            }
        }
        private void connect_chk()
        {
            //ksgcontrol kc = new ksgcontrol();
            //string mac = kc.GetMacAddr();

            //StringBuilder _input = new StringBuilder(mac);
            //StringBuilder _output1 = new StringBuilder(55);
            //StringBuilder _output2 = new StringBuilder(55);
            //Chk_Mac(_input, _output1, _output2);
            ////output1에서 not allow connect 확인

            //string output1 = _output1.ToString();
            //string output2 = "";

            //if (output1.Contains("connectiong error"))
            //{
            //    MessageBox.Show("DB접속을 할 수 없습니다.");
            //    Application.ExitThread();
            //    Environment.Exit(0);
            //}

            //if (output1.Contains("not allow"))
            //{
            //    MessageBox.Show("허용되지 않은 사용자 입니다(MacAddress : " + mac + "). 02-907-9297으로 연락 주시기 바랍니다.");
            //    Application.ExitThread();
            //    Environment.Exit(0);
            //}
            //if (output1.Contains("confirm"))
            //{
            //    output2 = _output2.ToString();
            //    result1 = output1.Split(' ');
            //    result2 = output2.Split(' ');

            //    // confirm 1.234.4.146 DB_Center_2 beta2 Bet@IsSecret!
            //    // 1.234.4.126 sms 1.234.27.80 DB_Local_2 Bet@G00dMem!

            Config.DB_con1 = "Data Source=103.60.126.142;Database=Pera;User Id=root;Password=pera_4548tps@;command timeout=6000;character set=euckr;allow zero datetime=yes";//공동서버
            Config.DB_con2 = Config.DB_con1;
            Config.DB_conp = "Data Source=dev.pera.co.kr;Database=post;User Id=beta2;Password=beta!))!1234;command timeout=6000;character set=euckr;allow zero datetime=yes";//공동서버
            Config.DB_conMacro = "Data Source=dev.pera.co.kr;Database=DB_Macro_146;User Id=beta2;Password=beta!))!1234;character set=euckr;allow zero datetime=yes";//공동서버
            Config.DB_conMacro_sang = "Data Source=dev.pera.co.kr;Database=DB_Macro;User Id=beta2;Password=beta!))!1234;character set=euckr;allow zero datetime=yes";//공동서버
            Config.DB_conSms = "Data Source=dev.pera.co.kr;Database=sms;User Id=beta2;Password=For_Beta2;character set=euckr;allow zero datetime=yes";//공동서버
            Config.DB_name = "Pera";
            Config.Ftp_ip_sms = "dev.pera.co.kr";   //ftp sms주소(로컬서버)
            //
            Config.Ftp_id_sms = "dev.pera.co.kr";
            Config.Ftp_ip1 = "dev.pera.co.kr";    //ftp 주소(공동서버)
            Config.Ftp_ip2 = "dev.pera.co.kr";    //ftp 주소(로컬서버)

            Config.Ftp_id1 = "beta2";          //ftp 아이디1
            Config.Ftp_id2 = "beta2";          //ftp 아이디2
            Config.Ftp_pw1 = "beta!))!1234";     //ftp 암호1
            Config.Ftp_pw2 = "beta!))!1234";      //ftp 암호2

            //}
            //else
            //{
            //    MessageBox.Show("허용되지 않은 사용자 입니다. 02-907-9297으로 연락 주시기 바랍니다.");
            //    Application.ExitThread();
            //    Environment.Exit(0);
            //}
        }
        private void button1_Click(object sender, EventArgs e)  //로그인
        {
            save_config();
            //
            this.Text = "■ 플랫폼 협력업체 자료관리 시스템(실자료 사용)";
            if (!login_chk())
                return;

            Main frm = new Main();
            frm.Show();
            this.Hide();

        }
        //
        private bool login_chk()
        {
            string ID = txtID.Text.Trim();
            string PW = txtPwd.Text.Trim();
            if (ID == "pera_s" || ID == "pera_dev")
            {
                User.Cli_name = ID;
                string cQuery = "select * from " + DB_TableName_client + " where id = '" + ID + "' and pw = password('" + PW + "')";
                var DBConn = new MySqlConnection(Config.DB_con1);
                DBConn.Open();
                var cmd = new MySqlCommand(cQuery, DBConn);
                var myRead = cmd.ExecuteReader();

                if (myRead.Read())
                {

                    myRead.Close();
                    DBConn.Close();
                    return true;
                }
                else
                {
                    myRead.Close();
                    DBConn.Close();
                    MessageBox.Show("회사 ID/PW를 확인하여주세요");
                    return false;
                }
            }
            else
            {
                MessageBox.Show("관리자 아이디가 아닙니다");
                return false;
            }

        }
        private void button2_Click(object sender, EventArgs e)  //취소시
        {
            Application.Exit();
        }

        private void button3_Click(object sender, EventArgs e)  //신규가입
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
        //
        private void save_config()
        {
            Properties.Settings.Default.ip = textIP.Text.Trim();
            Properties.Settings.Default.id = txtID.Text.Trim();
            Properties.Settings.Default.pw = txtPwd.Text.Trim();
            Properties.Settings.Default.Save();
        }

        private void login_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                button1_Click(null, null);
        }
    }
}
