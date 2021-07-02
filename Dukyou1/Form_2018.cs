using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Dukyou3
{
    public partial class Form_2018 : Form
    {
        ksgcontrol ks = new ksgcontrol();
        string row_id = "";
        string DB_TableName = "C_dontaeng_check";
        public Form_2018()
        {
            InitializeComponent();
            ks.ControlInit(Config.DB_con1, "", "", "");
            input_dat();
        }

        private void bSave_Click(object sender, EventArgs e)
        {
            if (tbJubji1.Text.Trim() == "" || tbJubji2.Text.Trim() == "")
                return;
            string cQuery = "update " + DB_TableName + " set jubji_dat1 = '" + tbJubji1.Text.Trim() + "',jubji_dat2 = '" + tbJubji2.Text.Trim() + "' where row_id = '" + row_id + "'";
            ks.DataUpdate(cQuery);
            MessageBox.Show("저장하였습니다.");
        }
        private void input_dat()
        {
            string cQuery = "select * from " + DB_TableName + " where row_id = (select max(row_id) from C_dontaeng_check)";

            var DBConn = new MySqlConnection(Config.DB_con1);
            DBConn.Open();
            var cmd = new MySqlCommand(cQuery, DBConn);

            var myRead = cmd.ExecuteReader();

            if (myRead.Read())
            {
                row_id = myRead["row_id"].ToString();
                tbJubji1.Text = myRead["jubji_dat1"].ToString();
                tbJubji2.Text = myRead["jubji_dat2"].ToString();
            }
            myRead.Close();
            DBConn.Close();
        }
    }
}
