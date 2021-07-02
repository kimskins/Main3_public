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
    public partial class Form_405 : Form
    {
        string DB_TableName_mac = "C_mac_address";
        string DB_TableName_cli = "C_client";
        SourceGridControl GH = new SourceGridControl();
        public Form_405()
        {
            InitializeComponent();
        }

        
        private void Form_405_Load(object sender, EventArgs e)
        {
            Screen srn = Screen.PrimaryScreen;
            int Xb = this.Width;  //좌,우
            int Yb = this.Height; //상,하
            this.Location = new Point((srn.Bounds.Width - Xb) / 2, (srn.Bounds.Height -Yb) / 2 -200);  //좌/우,위/아래

            GH.SourceGrideInit(grid1, Config.DB_con1);

            SourceGrid.Cells.Controllers.CustomEvents val_c1 = new SourceGrid.Cells.Controllers.CustomEvents();
            val_c1.ValueChanged += new EventHandler(ValueChangedEvent1);
            grid1.Controller.AddController(val_c1);

            Refresh();
        }

        private void Refresh()
        {
            string cQuery = "select a.*, b.id from " + DB_TableName_mac + " as a left outer join "+DB_TableName_cli+" as b ";
            cQuery += " on a.com_id = b.row_id where a.bad_user = true order by row_id desc";
            Grid_View(cQuery);
        }

        private void Grid_View(string cQuery)
        {
            cell_d cc = new cell_d();

            int Rows = 0;
            int Column = 0;


            grid1.Rows.Clear();

            grid1.BorderStyle = BorderStyle.FixedSingle;
            grid1.ColumnsCount = 6;
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

            grid1[Rows, Column] = new MyHeader1("Mac");   // 4
            grid1.Columns[Column].Width = 120;
            Column++;

            grid1[Rows, Column] = new MyHeader1("비고");   // 5
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

                grid1[Rows, Column] = new SourceGrid.Cells.Cell(myRead["row_id"], typeof(string));      // 0
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

                grid1[Rows, Column] = new SourceGrid.Cells.Cell(myRead["mac_address"], typeof(string));            // 4
                grid1[Rows, Column].View = cc.center_cell;
                grid1[Rows, Column].Editor = cc.disable_cell;
                Column++;

                grid1[Rows, Column] = new SourceGrid.Cells.Cell(myRead["bigo"], typeof(string));           // 5
                grid1[Rows, Column].View = cc.center_cell;
                Column++;

                Rows++;
            }

            myRead.Close();
            DBConn.Close();
        }

        private void bSearch_Click(object sender, EventArgs e)
        {
            Form_405a frm = new Form_405a();
            frm.ShowDialog();

            Refresh();
        }

        private void ValueChangedEvent1(object sender, EventArgs e)  //Grid1에서 볼륨첸지
        {
            string row_no = grid1[grid1.Selection.ActivePosition.Row, 0].ToString().Trim();
            int cpos = grid1.Selection.ActivePosition.Column;
            string dat = grid1[grid1.Selection.ActivePosition.Row, grid1.Selection.ActivePosition.Column].ToString().Trim();

            string cQuery = "";
            //

            if (cpos.Equals(5))       //
                cQuery = " update " + DB_TableName_mac + " set bigo='" + dat + "' where row_id='" + row_no + "'";
       
            if (!cQuery.Equals(""))
            {
                GH.DataUpdate(cQuery);
            }
        }

        private void bBadCancle_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("불량업체를 해제하시겠습니까?", "메세지창", MessageBoxButtons.YesNo) == DialogResult.Yes)
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
                    string cQuery = "update " + DB_TableName_mac + " set bad_user = false where " + where;
                    GH.DataUpdate(cQuery);
                }
                Refresh();
            }
        }
    }
}
