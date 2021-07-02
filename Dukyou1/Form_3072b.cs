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
    public partial class Form_3072b : Form
    {
        string DB_TableName_gyeon = "";
        string flag = "0"; //// 1은 전체견적, 0는 % 견적
        string cust_id = ""; // 개별 세부등급일때 고객의 id가 들어온다.
        int gubun_count = 0;
        public bool bConfirm_chk = false;

        public Form_3072b(int gubun_count, string flag, string DB_TableName_gyeon)
        {
            InitializeComponent();
            this.gubun_count = gubun_count;
            this.flag = flag;
            this.DB_TableName_gyeon = DB_TableName_gyeon;
        }

        public Form_3072b(int gubun_count, string flag, string DB_TableName_gyeon, string cust_id)
        {
            InitializeComponent();
            this.gubun_count = gubun_count;
            this.flag = flag;
            this.DB_TableName_gyeon = DB_TableName_gyeon;
            this.cust_id = cust_id;
        }

        private void Form_3092b_Load(object sender, EventArgs e)
        {
            Screen srn = Screen.PrimaryScreen;
            int Xb = this.Width;  //좌,우
            int Yb = this.Height; //상,하
            this.Location = new Point((srn.Bounds.Width - Xb) / 2, (srn.Bounds.Height - Yb) / 2);  //좌/우,위/아래

            if (chkPriceUnit.Checked == true)
                tbPrice_unit.Enabled = true;
            else
                tbPrice_unit.Enabled = false;

            tbPrice_unit.Refresh();
        }

        private void bConfirm_Click(object sender, EventArgs e)
        {
            try
            {
                string start_price = tbStartPrice.Text;
                string end_price = tbEndPrice.Text;
                int s_price = 0;
                int e_price = 0;
                ksgcontrol kc = new ksgcontrol();
                kc.ControlInit(Config.DB_con1, "", "", "");


                if (start_price != "" && start_price.Trim() != "")
                    start_price = start_price.Trim();
                else
                {
                    MessageBox.Show("시작 금액을 넣어주세요");
                    return;
                }

                if (end_price != "" && end_price.Trim() != "")
                    end_price = end_price.Trim();
                else
                {
                    MessageBox.Show("종료 금액을 넣어주세요");
                    return;
                }

                s_price = Convert.ToInt32(start_price);
                e_price = Convert.ToInt32(end_price);
                string cQuery = "";
                if (chkPriceUnit.Checked == true)
                {
                    string unit_price = tbPrice_unit.Text;
                    if (unit_price != "" && unit_price.Trim() != "")
                        unit_price = unit_price.Trim();
                    else
                    {
                        MessageBox.Show("금액 단위를 넣어주세요");
                        return;
                    }
                    int u_price = Convert.ToInt32(unit_price);

                    while (s_price + u_price <= e_price)
                    {
                        string sub_Query = "";
                        if (flag == "2")    // 개별 세부 견적일때
                        {
                            sub_Query = "select * from " + DB_TableName_gyeon + " where sales_min = '" + s_price.ToString();
                            sub_Query += "' and sales_max = '" + (s_price + u_price).ToString() + "' and cust_id = '" + cust_id + "'";
                        }
                        else
                        {
                            sub_Query = "select * from " + DB_TableName_gyeon + " where sales_min = '" + s_price.ToString();
                            sub_Query += "' and sales_max = '" + (s_price + u_price).ToString() + "' and flag = '" + flag + "'";
                        }
                        var DBConn = new MySqlConnection(Config.DB_con1);
                        DBConn.Open();

                        var cmd = new MySqlCommand(sub_Query, DBConn);
                        var myRead = cmd.ExecuteReader();
                        if (myRead.Read())
                        {
                            MessageBox.Show(start_price + " ~ " + (s_price + u_price).ToString() + " 구간은 이미 존재 하기에 skip 합니다.");
                            myRead.Close();
                            DBConn.Close();

                        }
                        else
                        {
                            myRead.Close();
                            DBConn.Close();

                            for (int i = 1; i <= gubun_count; i++)
                            {
                                if (flag == "2")  // 개별 세부 견적일때...
                                {
                                    cQuery = "insert into " + DB_TableName_gyeon + " (sales_min, sales_max, cust_id) values('" + s_price.ToString() + "', '" + (s_price + u_price).ToString();
                                    cQuery += "', '" + cust_id + "')";
                                }
                                else
                                {
                                    cQuery = "insert into " + DB_TableName_gyeon + " (sales_min, sales_max, gubun_id, flag) values('" + s_price.ToString() + "', '" + (s_price + u_price).ToString();
                                    cQuery += "', '" + i.ToString() + "', '" + flag + "')";
                                }
                                kc.DataUpdate(cQuery);

                            }
                        }
                        s_price = s_price + u_price;
                    }
                }
                else
                {
                    string sub_Query = "";
                    if (flag == "2") // 개별 세부 견적일때
                    {
                        sub_Query = "select * from " + DB_TableName_gyeon + " where sales_min = '" + start_price;
                        sub_Query += "' and sales_max = '" + end_price + "' and cust_id='" + cust_id + "'";
                    }
                    else
                    {
                        sub_Query = "select * from " + DB_TableName_gyeon + " where sales_min = '" + start_price;
                        sub_Query += "' and sales_max = '" + end_price + "' and flag='" + flag + "'";
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
                        for (int i = 1; i <= gubun_count; i++)
                        {
                            if (flag == "2") // 개별 세부 견적일때
                            {
                                cQuery = "insert into " + DB_TableName_gyeon + " (sales_min, sales_max, gubun_id, cust_id) values('" + start_price + "', '" + end_price + "', '" + i.ToString() + "', '" + cust_id + "')";
                            }
                            else
                            {
                                cQuery = "insert into " + DB_TableName_gyeon + " (sales_min, sales_max, gubun_id, flag) values('" + start_price + "', '" + end_price + "', '" + i.ToString() + "', '" + flag + "')";
                            }
                            kc.DataUpdate(cQuery);
                        }
                    }
                }
                bConfirm_chk = true;
                this.Close();
            }
            catch
            {
                MessageBox.Show("정수만 입력해 주세요");
                return;
            }
        }

        private void chkPriceUnit_CheckedChanged(object sender, EventArgs e)
        {
            if (chkPriceUnit.Checked == true)
                tbPrice_unit.Enabled = true;
            else
                tbPrice_unit.Enabled = false;

            tbPrice_unit.Refresh();
        }


    }
}
