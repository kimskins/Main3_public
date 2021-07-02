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
    public partial class Form_4011c : Form
    {
        string DB_TableName = "C_client";
        string client_row_id = "";
        public Form_4011c(string client_row_id)
        {
            InitializeComponent();
            this.client_row_id = client_row_id;
        }

        private void Form_4011c_Load(object sender, EventArgs e)
        {
            Screen srn = Screen.PrimaryScreen;
            int Xb = this.Width;  //좌,우
            int Yb = this.Height + 200; //상,하
            this.Location = new Point((srn.Bounds.Width - Xb) / 2, (srn.Bounds.Height - Yb) / 2);  //좌/우,위/아래

            string cQuery = "select local_db_ip, local_db_pw, local_db_user, local_db_nm from " + DB_TableName + " where row_id = '" + client_row_id + "'";
            var DBConn = new MySqlConnection(Config.DB_con1);
            DBConn.Open();
            var cmd = new MySqlCommand(cQuery, DBConn);
            var myRead = cmd.ExecuteReader();
            myRead.Read();
            tbDBIP.Text = myRead["local_db_ip"].ToString().Trim();

            tbDBPW.Text = CryptorEngine.Decrypt(myRead["local_db_pw"].ToString().Trim(), true);
            tbDBID.Text = myRead["local_db_user"].ToString().Trim();
            tbDBName.Text = myRead["local_db_nm"].ToString().Trim();

            tbDBID.Refresh();
            tbDBIP.Refresh();
            tbDBPW.Refresh();
            tbDBName.Refresh();

            myRead.Close();
            DBConn.Close();
        }

        private void bConfirm_Click(object sender, EventArgs e)
        {
            string id, ip, pw, name = "";

            id = tbDBID.Text;

            pw = CryptorEngine.Encrypt(tbDBPW.Text, true);
            ip = tbDBIP.Text;
            name = tbDBName.Text;

            string cQuery = "update " + DB_TableName + " set local_db_ip = '" + ip + "', local_db_user = '" + id + "', local_db_pw = '" + pw + "', local_db_nm = '" + name + "'";
            cQuery += " where row_id = '" + client_row_id + "'";
            ksgcontrol kc = new ksgcontrol();
            kc.ControlInit(Config.DB_con1, "", "", "");
            kc.DataUpdate(cQuery);

            this.Close();
        }


    }
}
