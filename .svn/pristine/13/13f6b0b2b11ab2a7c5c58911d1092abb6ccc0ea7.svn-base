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
    public partial class Form_210a : Form
    {
        Form_210 mom;
        string DB_TableName_hang = "hang_manage";
        public string gCode = "";
        public string gClass = "";
        public Form_210a(Form_210 mom)
        {
            InitializeComponent();
            this.mom = mom;

        }

        private void Form_201a_Load(object sender, EventArgs e)
        {
            mom.InitCombo(DB_TableName_hang, "class", cbClass);
            Screen srn = Screen.PrimaryScreen;
            int Xb = this.Width;  //좌,우
            this.Location = new Point((srn.Bounds.Width - Xb) / 2, 1);  //좌/우,위/아래
        }

        private void bConfirm_Click(object sender, EventArgs e)
        {
            string GetClass = cbClass.Text;
            string GetCode = tbCode.Text;

            if (GetCode.Length > 3)
            {
                MessageBox.Show("코드는 3자리를 넘어갈수 없습니다");
                return;
            }

            string Query = "select * from " + DB_TableName_hang + " where class = '" + GetClass + "' and code1 = '" + GetCode + "'";
            var DBConn = new MySqlConnection(Config.DB_con1);
            DBConn.Open();
            var cmd = new MySqlCommand(Query, DBConn);

            var myRead = cmd.ExecuteReader();
            if (myRead.Read())
            {
                MessageBox.Show("'" + GetClass + "' 의 '" + GetCode + "' 코드는 이미 등록되어 있습니다");
                DBConn.Close();
                return;
            }
            else
            {
                gCode = GetCode;
                gClass = GetClass;
            }
            DBConn.Close();
            this.Close();
        }

        private void bCancle_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
