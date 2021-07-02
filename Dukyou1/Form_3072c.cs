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
    public partial class Form_3072c : Form
    {
        public bool bConfirm_chk = false;
        string DB_TableName_gyeon = "";
        public string start_price = "";
        public string end_price = "";
        string cust_id = "";

        string flag_id = "0";
        public Form_3072c(string flag_id, string DB_TableName_geyon)
        {
            InitializeComponent();
            this.flag_id = flag_id;
            this.DB_TableName_gyeon = DB_TableName_gyeon;
        }

        public Form_3072c(string flag_id, string DB_TableName_geyon, string cust_id)
        {
            InitializeComponent();
            this.flag_id = flag_id;
            this.DB_TableName_gyeon = DB_TableName_gyeon;
            this.cust_id = cust_id;
        }

        private void Form_3092c_Load(object sender, EventArgs e)
        {
            Screen srn = Screen.PrimaryScreen;
            int Xb = this.Width;  //좌,우
            int Yb = this.Height; //상,하
            this.Location = new Point((srn.Bounds.Width - Xb) / 2, (srn.Bounds.Height - Yb) / 2);  //좌/우,위/아래
        }

        private void bConfirm_Click(object sender, EventArgs e)
        {
            start_price = tbStartPrice.Text;
            if (start_price != "" && start_price.Trim() != "")
                start_price = start_price.Trim();
            else
            {
                MessageBox.Show("시작 금액을 입력하여 주세요");
                return;
            }

            end_price = tbEndPrice.Text;
            if (end_price != "" && end_price.Trim() != "")
                end_price = end_price.Trim();
            else
            {
                MessageBox.Show("종료 금액을 입력하여 주세요");
                return;
            }
            string sub_Query = "";

            if (flag_id == "2")  // 개별 세부 견적일때
            {
                sub_Query = "select * from " + DB_TableName_gyeon + " where sales_min = '" + start_price;
                sub_Query += "' and sales_max = '" + end_price + "' and cust_id ='" + cust_id + "'";
            }
            else
            {
                sub_Query = "select * from " + DB_TableName_gyeon + " where sales_min = '" + start_price;
                sub_Query += "' and sales_max = '" + end_price + "' and flag ='" + flag_id + "'";
            }
            var DBConn = new MySqlConnection(Config.DB_con1);
            DBConn.Open();

            var cmd = new MySqlCommand(sub_Query, DBConn);
            var myRead = cmd.ExecuteReader();
            if (myRead.Read())
            {
                MessageBox.Show(start_price + " ~ " + end_price + " 구간은 이미 존재합니다");
                myRead.Close();
                DBConn.Close();
                return;
            }
            else
            {
                myRead.Close();
                DBConn.Close();
                bConfirm_chk = true;
                this.Close();
            }

        }

    }
}
