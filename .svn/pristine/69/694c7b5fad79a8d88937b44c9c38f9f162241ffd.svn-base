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
    public partial class Form_207 : Form
    {
        string row_id = "";
        string DB_TableName = "C_dontaeng_check";

        public Form_207()
        {
            InitializeComponent();
        }

        private void Form_214_Load(object sender, EventArgs e)
        {
            string cQuery = "select * from "+DB_TableName+" where row_id = (select max(row_id) from C_dontaeng_check)";

            var DBConn = new MySqlConnection(Config.DB_con1);
            DBConn.Open();
            var cmd = new MySqlCommand(cQuery, DBConn);

            var myRead = cmd.ExecuteReader();

            if (myRead.Read())
            {
                row_id = myRead["row_id"].ToString();
                tbGeneral.Text = myRead["general_code"].ToString();
                tbKoting.Text = myRead["koting_code"].ToString();

                tbGeneral.Refresh();
                tbKoting.Refresh();
                myRead.Close();
                DBConn.Close();                
            }
            else
            {
                MessageBox.Show("데이터에 오류가 있습니다. 개발자에게 문의해주세요");
                DBConn.Close();
                myRead.Close();
                this.Close();
            }
        }

        private void bGeneral_Click(object sender, EventArgs e)
        {
            ksgcontrol kc = new ksgcontrol();
            kc.ControlInit(Config.DB_con1, "", "", "");
            string cQuery = "update " + DB_TableName + " set general_code = '" + tbGeneral.Text.Trim() + "' where row_id = '" + row_id + "'";
            kc.DataUpdate(cQuery);
            MessageBox.Show("일반 후공정 저장완료");
        }

        private void bKoting_Click(object sender, EventArgs e)
        {
            ksgcontrol kc = new ksgcontrol();
            kc.ControlInit(Config.DB_con1, "", "", "");
            string cQuery = "update " + DB_TableName + " set koting_code = '" + tbKoting.Text.Trim() + "' where row_id = '" + row_id + "'";
            kc.DataUpdate(cQuery);
            MessageBox.Show("코팅 후공정 저장완료");
        }

    }
}
