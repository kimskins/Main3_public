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
    public partial class Form_405a : Form
    {
        string DB_TableName_mac = "C_mac_address";
        string DB_TableName_cli = "C_client";
        string DB_TableName_mem = "C_member";

        SourceGridControl GH = new SourceGridControl();
        public Form_405a()
        {
            InitializeComponent();
        }


        private void Form_405a_Load(object sender, EventArgs e)
        {
            Screen srn = Screen.PrimaryScreen;
            int Xb = this.Width;  //좌,우
            int Yb = this.Height; //상,하
            this.Location = new Point((srn.Bounds.Width - Xb) / 2, (srn.Bounds.Height - Yb) / 2  - 200);  //좌/우,위/아래

            GH.SourceGrideInit(grid1, Config.DB_con1);

            Refresh();
        }


        private void Refresh()
        {
            string cQuery = "select a.*, b.id, b.name as sangho, c.name as member from " + DB_TableName_mac + " as a left outer join " + DB_TableName_cli + " as b on a.com_id = b.row_id ";
            cQuery += " left outer join " + DB_TableName_mem + " as c on a.mem_id = c.row_id where a.bad_user = false" + " order by b.id, c.name"; ;
            Grid_View(cQuery);
        }

        private void bSearch_Click(object sender, EventArgs e)
        {
            string s1, s2, s3, s4;

            if(tbId.Text.Trim() != "")
                s1 = " and b.id like '%"+tbId.Text.Trim()+"%' " ;
            else 
                s1 = "";

            if(tbCompany.Text.Trim() != "")
                s2 = " and b.name like '%"+tbCompany.Text.Trim()+"%' ";
            else
                s2 = "";

            if(tbMember.Text.Trim() != "")
                s3 = " and c.name like '%"+tbMember.Text.Trim()+"%' ";
            else
                s3 = "";

            if(tbMac.Text.Trim() != "")
                s4 = " and a.mac_address like '%"+tbMac.Text.Trim() + "%' ";
            else
                s4 = "";

            string cQuery = "select a.*, b.id, b.name as sangho, c.name as member from " + DB_TableName_mac + " as a left outer join " + DB_TableName_cli + " as b on a.com_id = b.row_id ";
            cQuery += " left outer join " + DB_TableName_mem + " as c on a.mem_id = c.row_id";
            cQuery += " where a.row_id > 0 and bad_user = false " + s1 + s2 + s3 + s4+" order by b.id, c.name";
            Grid_View(cQuery);
        }

        private void Grid_View(string cQuery)
        {
            cell_d cc = new cell_d();

            int Rows = 0;
            int Column = 0;

            grid1.Rows.Clear();

            grid1.BorderStyle = BorderStyle.FixedSingle;
            grid1.ColumnsCount = 7;
            grid1.FixedRows = 1;

            grid1.Rows.Insert(0);

            grid1.Rows[0].Height = 30;

            grid1[Rows, Column] = new MyHeader1("row_id");  // 0
            grid1.Columns[Column].Visible = false;
            Column++;

            grid1[Rows, Column] = new MyHeader1("√");       // 1
            grid1.Columns[Column].Width = 20;
            Column++;

            grid1[Rows, Column] = new MyHeader1("No");      // 2
            grid1.Columns[Column].Width = 30;
            Column++;

            grid1[Rows, Column] = new MyHeader1("ID");      // 3
            grid1.Columns[Column].Width = 80;
            Column++;

            grid1[Rows, Column] = new MyHeader1("회사명");   // 4
            grid1.Columns[Column].Width = 200;
            Column++;

            grid1[Rows, Column] = new MyHeader1("사용자");   // 5
            grid1.Columns[Column].Width = 100;
            Column++;

            grid1[Rows, Column] = new MyHeader1("mac");   // 6
            grid1.Columns[Column].Width = 300;
            Column++;

            Rows++;

            MySqlConnection DBConn;
            DBConn = new MySqlConnection(Config.DB_con1);

            util.Con_DB_Open(ref DBConn);
            MySqlDataReader myRead;

            var cmd = new MySqlCommand(cQuery, DBConn);
            myRead = cmd.ExecuteReader();

            int m = 1;
            while (myRead.Read())
            {
                grid1.Rows.Insert(Rows);
                grid1.Rows[Rows].Height = 24;
                Column = 0;

                grid1[Rows, Column] = new SourceGrid.Cells.Cell(myRead["row_id"], typeof(string));    // 0
                Column++;

                grid1[Rows, Column] = new SourceGrid.Cells.CheckBox(null, false);                       // 1
                Column++;

                grid1[Rows, Column] = new SourceGrid.Cells.Cell(Rows.ToString(), typeof(string));       // 2
                grid1[Rows, Column].View = cc.center_cell;
                Column++;

                grid1[Rows, Column] = new SourceGrid.Cells.Cell(myRead["id"], typeof(string));          // 3
                grid1[Rows, Column].View = cc.center_cell;
                grid1[Rows, Column].Editor = cc.disable_cell;
                Column++;
                    
                grid1[Rows, Column] = new SourceGrid.Cells.Cell(myRead["sangho"], typeof(int));            // 4
                grid1[Rows, Column].View = cc.center_cell;
                grid1[Rows, Column].Editor = cc.disable_cell;
                Column++;

                grid1[Rows, Column] = new SourceGrid.Cells.Cell(myRead["member"], typeof(int));           // 5
                grid1[Rows, Column].View = cc.center_cell;
                grid1[Rows, Column].Editor = cc.disable_cell;
                Column++;

                grid1[Rows, Column] = new SourceGrid.Cells.Cell(myRead["mac_address"], typeof(int));           // 6
                grid1[Rows, Column].View = cc.center_cell;
                grid1[Rows, Column].Editor = cc.disable_cell;
                Column++;

                Rows++;
            }

            myRead.Close();
            DBConn.Close();
        }

        private void bRegist_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("불량업체등록하면 모든 실행파일을 지웁니다\r\n\r\n불량업체로 등록하시겠습니까?", "메세지창", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                string where = "";
                for (int i = 1; i < grid1.RowsCount; i++)
                {
                    if (grid1[i, 1].Value.Equals(true))
                    {
                        where += " or row_id = '" + grid1[i, 0].ToString() + "' ";
                    }
                }

                if (where != "")
                {
                    where = where.Substring(4);
                    string cQuery = "update " + DB_TableName_mac + " set bad_user = true where " + where;
                    GH.DataUpdate(cQuery);
                }
                this.Close();
            }
        }

        private void bClear_Click(object sender, EventArgs e)
        {
            tbCompany.Text = "";
            tbId.Text = "";
            tbMac.Text = "";
            tbMember.Text = "";

            tbCompany.Refresh();
            tbId.Refresh();
            tbMac.Refresh();
            tbMember.Refresh();
        }
    }
}
