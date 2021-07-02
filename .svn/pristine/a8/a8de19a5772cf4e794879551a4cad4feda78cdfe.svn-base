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

namespace Dukyou3
{

    public partial class Form_sms_send : Form
    {
        int num = 0;
        string[] phone;
        string[] name;
        string[] customer_id_arr;

        string customer_id = "";        
        string TableName_cust_m = "L_cust_m";
        int Rows;
        int arr_count;
        string tel_temp = "";
        cell_d cc = new cell_d();
        public Form_sms_send(string customer_id)
        {
            InitializeComponent();
            this.customer_id = customer_id;
            if(customer_id == "-1")
            {
                
            }
            else
                grid1_view();
        }
        public void grid_column()
        {
            grid1.Rows.Clear();
            grid1.BorderStyle = BorderStyle.FixedSingle;
            grid1.ColumnsCount = 4;
            grid1.FixedRows = 1;
            grid1.Rows.Insert(0);
            grid1.Rows[0].Height = 26;
            grid1[0, 0] = new MyHeader1("√");
            grid1[0, 1] = new MyHeader1("이름");
            grid1[0, 2] = new MyHeader1("번호");
            grid1[0, 3] = new MyHeader1("customer");
            grid1.Columns[3].Visible = false;
            grid1.Columns[0].Width = 20;
            grid1.Columns[1].Width = 60;
            grid1.Columns[2].Width = 145;
        }
        public Form_sms_send(string[] c_id, string[] hp, string[] name_tmep, int count, string tel)
        {
            InitializeComponent();
            tel_temp = tel;
            customer_id_arr = new string[count];
            phone = new string[count];
            name = new string[count];
            customer_id_arr = c_id;
            phone = hp;
            name = name_tmep;
            arr_count = count;

            grid_view_2();
        }
        public Form_sms_send(string c_id, string hp, string name_tmep, string file_path)
        {
            InitializeComponent();
            tbSmsText.Text = "안녕하세요. 이모션 입니다.";
            tbSender.Refresh();
            tbSmsText.Refresh();
            tbSmsText.GotFocus += OnTxtGetFocus;

            if (file_path != "")
            {
                textBox1.Text = file_path;
                bSend.Visible = false;
                bMms.Visible = true;
            }
            int m = 1;
            grid_column();
            grid1.Rows.Insert(m);
            grid1.Rows[m].Height = 24;

            grid1[m, 0] = new SourceGrid.Cells.CheckBox(null, true);

            grid1[m, 1] = new SourceGrid.Cells.Cell(name_tmep, typeof(string));
            grid1[m, 1].View = cc.int_cell;

            grid1[m, 2] = new SourceGrid.Cells.Cell(hp, typeof(string));
            grid1[m, 2].View = cc.center_cell;
            grid1[m, 3] = new SourceGrid.Cells.Cell(c_id, typeof(string));
        }

        private void grid_view_2()
        {
            grid_column();
            int m = 1;
            for (int i = 0; i < arr_count; i++)
            {
                grid1.Rows.Insert(m);
                grid1.Rows[m].Height = 24;

                grid1[m, 0] = new SourceGrid.Cells.CheckBox(null, true);

                grid1[m, 1] = new SourceGrid.Cells.Cell(name[i], typeof(string));
                grid1[m, 1].View = cc.int_cell;
                grid1[m, 1].Editor = cc.disable_cell;

                grid1[m, 2] = new SourceGrid.Cells.Cell(phone[i], typeof(string));
                grid1[m, 2].View = cc.center_cell;
                grid1[m, 2].Editor = cc.disable_cell;
                grid1[m, 3] = new SourceGrid.Cells.Cell(customer_id_arr[i], typeof(string));
                m++;
            }
        }

        private void Form_sms_send_Load(object sender, EventArgs e)
        {
            Screen srn = Screen.PrimaryScreen;
            int Xb = this.Width;  //좌,우
            int Yb = this.Height; //좌,우
            this.Location = new Point((srn.Bounds.Width - Xb) / 2, (srn.Bounds.Height - Yb) / 2 - 100);  //좌/우,위/아래

            tbSender.Text = tel_temp;
            tbSmsText.Text = "안녕하세요. emotion TPS 입니다.";
            tbSender.Refresh();
            tbSmsText.Refresh();
            tbSmsText.GotFocus += OnTxtGetFocus;
        }

        private void OnTxtGetFocus(object sender, EventArgs e)
        {
            tbSmsText.SelectAll();
        }
        private void grid1_view()
        {
            grid_column();

            MySqlConnection DBConn;
            DBConn = new MySqlConnection(Config.DB_con2);
            util.Con_DB_Open(ref DBConn);
            string Query = "select name, phone_m, int_id from "+TableName_cust_m+" where int_id = " + customer_id;
            var cmd = new MySqlCommand(Query, DBConn);
            var myRead = cmd.ExecuteReader();

            int m = 1;
            while (myRead.Read())
            {
                grid1.Rows.Insert(m);
                grid1.Rows[m].Height = 24;

                grid1[m, 0] = new SourceGrid.Cells.CheckBox(null, false);

                grid1[m, 1] = new SourceGrid.Cells.Cell(myRead["name"].ToString(), typeof(string));
                grid1[m, 1].View = cc.int_cell;
                grid1[m, 1].Editor = cc.disable_cell;

                grid1[m, 2] = new SourceGrid.Cells.Cell(myRead["phone_m"].ToString(), typeof(string));
                grid1[m, 2].View = cc.center_cell;
                grid1[m, 2].Editor = cc.disable_cell;
                grid1[m, 3] = new SourceGrid.Cells.Cell(myRead["int_id"].ToString(), typeof(string));
                if (grid1[m, 1].ToString() == "" && grid1[m, 2].ToString() == "")
                    m--;
                else
                 m++;
            }
            
            myRead.Close();
            DBConn.Close();

        }

        private void tbSmsText_MouseClick(object sender, MouseEventArgs e)
        {
            tbSmsText.SelectAll();
        }

        private void tbSmsText_TextChanged(object sender, EventArgs e)
        {
            int size = 0;
            if (tbSmsText.Text != "")
            {
                size = Encoding.Default.GetBytes(tbSmsText.Text).Length;
                if (size > 90)
                {
                    label3.Text = "LMS";
                    label3.ForeColor = System.Drawing.Color.Red;
                }
                else
                    label3.Text = Encoding.Default.GetBytes(tbSmsText.Text).Length.ToString() + "/90";
            }
            else
                label3.Text = "0/90";

            label3.Refresh();
        }

        private void bAdd_Click(object sender, EventArgs e)
        {
            cell_d cc = new cell_d();
            Rows = grid1.RowsCount;
            grid1.Rows.Insert(Rows);
            grid1.Rows[Rows].Height = 22;

            grid1[Rows, 0] = new SourceGrid.Cells.CheckBox(null, true);
            grid1[Rows, 1] = new SourceGrid.Cells.Cell("", typeof(string));
            grid1[Rows, 1].View = cc.center_cell;
            

            grid1[Rows, 2] = new SourceGrid.Cells.Cell("", typeof(string));
            grid1[Rows, 2].View = cc.center_cell;
            grid1[Rows, 3] = new SourceGrid.Cells.Cell("0", typeof(string));
            
            Rows++;
        }

        private void bSend_Click(object sender, EventArgs e)
        {
            this.TopMost = false;
            int Rows = grid1.RowsCount;
            ksgcontrol KC = new ksgcontrol();
            KC.ControlInit(Config.DB_con2, Config.Ftp_ip2, Config.Ftp_id2, Config.Ftp_pw2);
            int sms_count = 0;
            

            for (int z = 0; z < Rows; z++)
            {
                if (grid1[z, 0].Value.Equals(true))
                    sms_count++;
            }

            string[] c_id = new string[sms_count];
           // string[] sms_txt = new string[sms_count];
            string[] to_phone = new string[sms_count];
            string[] from_phone = new string[sms_count];
            string[] to_name = new string[sms_count];
           // string[] from_name = new string[sms_count];
            int arr = 0;
            for (int i = 0; i < Rows; i++)
            {
                if (grid1[i, 0].Value.Equals(true))
                {
                    //c_id[arr] = customer_id;
                    c_id[arr] = grid1[i, 3].ToString();
                   // sms_txt[arr] = tbSmsText.Text;
                  //  to_phone[arr] = tbSender.Text;
                    to_phone[arr] = grid1[i, 2].Value.ToString();
                   // from_name[arr] = User.UserName;
                    if (grid1[i, 1].ToString() != null && grid1[i, 1].ToString().Trim() != "")
                        to_name[arr] = grid1[i, 1].Value.ToString();
                    else
                        to_name[arr] = "";

                    arr++;
                }
            }
            if (arr == 0)
                MessageBox.Show("받으실분을 선택해 주세요");
            else
                KC.SndSMS(c_id, tbSmsText.Text, tbSender.Text, to_phone, "이모션", to_name, sms_count, null);
            this.Close();
        }

        private void bMms_Click(object sender, EventArgs e)
        {
            this.TopMost = false;
            int Rows = grid1.RowsCount;
            ksgcontrol KC = new ksgcontrol();
            KC.ControlInit(Config.DB_con2, Config.Ftp_ip2, Config.Ftp_id2, Config.Ftp_pw2);
            int sms_count = 0;


            for (int z = 0; z < Rows; z++)
            {
                if (grid1[z, 0].Value.Equals(true))
                    sms_count++;
            }

            string[] c_id = new string[sms_count];
           // string[] sms_txt = new string[sms_count];
            string[] to_phone = new string[sms_count];
            string[] from_phone = new string[sms_count];
            string[] to_name = new string[sms_count];
           // string[] from_name = new string[sms_count];
            int arr = 0;
            for (int i = 0; i < Rows; i++)
            {
                if (grid1[i, 0].Value.Equals(true))
                {
                    //c_id[arr] = customer_id;
                    c_id[arr] = grid1[i, 3].ToString();
                  //  sms_txt[arr] = tbSmsText.Text;
                    to_phone[arr] = grid1[i, 2].Value.ToString();
                  
                  //  from_name[arr] = User.UserName;
                    if (grid1[i, 1].ToString() != null && grid1[i, 1].ToString().Trim() != "")
                        to_name[arr] = grid1[i, 1].Value.ToString();
                    else
                        to_name[arr] = "";
                    arr++;
                }
            }
            if (arr == 0)
                MessageBox.Show("받으실분을 선택해 주세요");
            else
                 KC.SndSMS(c_id, tbSmsText.Text, tbSender.Text, to_phone, "이모션", to_name, sms_count, textBox1.Text);

            this.Close();
        }

        private void bSearch_Click(object sender, EventArgs e)
        {
           // string dbconn = "Data Source=1.234.4.126;Database=sms;User Id=sms;Password=sms;character set=euckr;allow zero datetime=yes";//공동서버
            FileControl FC = new FileControl();
            FC.FileControlInit(Config.DB_conSms, Config.Ftp_ip1, Config.Ftp_id1, Config.Ftp_pw1);
            OpenFileDialog ofd = new OpenFileDialog();// File descriptor
            if (FC.FileOpenDlg(ofd) == 1)
                return;

            string fullPathName = ofd.FileName;//파일 전체 경로 이름 확장자 포함
            textBox1.Text = fullPathName;
            bSend.Visible = false;
            bMms.Visible = true;
            sms sm = new sms();
            sm.file_up(fullPathName);
        }

        private void Form_sms_send_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (textBox1.Text != "")
            {
                FileInfo fileInf = new FileInfo(textBox1.Text);
                string UserFN = fileInf.Name;    //파일 이름

                OhFTP Ftp = new OhFTP(Config.Ftp_ip_sms, Config.Ftp_id1, Config.Ftp_pw1);

                sync sync = new sync();

                if (sync.FtpDirectoryExists("ftp://" + Config.Ftp_ip_sms + "/" + Config.Ftp_id_sms + "/" + UserFN, Config.Ftp_id1, Config.Ftp_pw1) == true)
                    Ftp.DeleteFTP(UserFN, Config.Ftp_id_sms);
            }
        }

        private void Form_sms_send_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
                this.Close();
        }
    }
}
