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
    public partial class Form_607 : Form
    {
        string DB_TableName = "C_job_sms";
        SourceGridControl GridHandle = new SourceGridControl();
        ksgcontrol kc = new ksgcontrol();
        cell_d cc = new cell_d();
        public Form_607()
        {
            InitializeComponent();
            GridHandle.SourceGrideInit(grid1, Config.DB_con1);
            kc.ControlInit(Config.DB_con1, null, null, null);
        }

        private void grid1_make()
        {
            
            SourceGrid.Cells.Views.Button dd;
            dd = new SourceGrid.Cells.Views.Button();
            dd.TextAlignment = DevAge.Drawing.ContentAlignment.MiddleCenter;

            grid1.Rows.Clear();
            grid1.BorderStyle = BorderStyle.FixedSingle;
            grid1.SelectionMode = SourceGrid.GridSelectionMode.Cell;
            grid1.ColumnsCount = 7;
            grid1.FixedRows = 1;
            grid1.Rows.Insert(0);
            grid1.Rows[0].Height = 24;

            grid1[0, 0] = new MyHeader1("row_id");  //row_id
            grid1.Columns[0].Visible = false;
            grid1[0, 1] = new MyHeader1("√");
            grid1[0, 2] = new MyHeader1("No");
            grid1[0, 3] = new MyHeader1("이름");
            grid1[0, 4] = new MyHeader1("구  분");
            grid1[0, 4].ColumnSpan = 2;
            grid1[0, 6] = new MyHeader1("bigo");


            grid1.Columns[1].Width = 20;
            grid1.Columns[2].Width = 25;
            grid1.Columns[3].Width = 80;
            grid1.Columns[4].Width = 70;
            grid1.Columns[5].Width = 200;
            grid1.Columns[6].Width = 100;

            MySqlConnection DBConn;
            DBConn = new MySqlConnection(Config.DB_con1);
            DBConn.Open();
            string Query = "select * from " + DB_TableName + " order by row_id";
            var cmd = new MySqlCommand(Query, DBConn);
            var myRead = cmd.ExecuteReader();

            int m = 1;
            while (myRead.Read())
            {
                grid1.Rows.Insert(m);
                grid1.Rows[m].Height = 22;

                grid1[m, 0] = new SourceGrid.Cells.Cell(myRead["row_id"].ToString(), typeof(string));

                grid1[m, 1] = new SourceGrid.Cells.CheckBox(null, false);
                grid1[m, 2] = new SourceGrid.Cells.Cell((m).ToString(), typeof(string));
                grid1[m, 2].Editor = cc.disable_cell;
                grid1[m, 2].View = cc.center_cell;

                grid1[m, 3] = new SourceGrid.Cells.Cell(myRead["name"].ToString(), typeof(string));
                grid1[m, 3].View = cc.center_cell;

                if (myRead["gubun"].ToString() == "1")
                    grid1[m, 4] = new SourceGrid.Cells.Cell("sms", typeof(string));
                else
                    grid1[m, 4] = new SourceGrid.Cells.Cell("mail", typeof(string));
                grid1[m, 4].View = cc.center_cell;
                grid1[m, 4].Editor = GridHandle.CbBox[0];

                grid1[m, 5] = new SourceGrid.Cells.Cell(myRead["phone"].ToString(), typeof(string));
                grid1[m, 5].View = cc.center_cell;

                grid1[m, 6] = new SourceGrid.Cells.Cell(myRead["bigo"].ToString(), typeof(string));
                grid1[m, 6].View = cc.center_cell;
                m++;
            }

            myRead.Close();
            DBConn.Close();
        }

        private void Form_607_Load(object sender, EventArgs e)
        {
            Screen srn = Screen.PrimaryScreen;
            int Xb = this.Width;  //좌,우
            this.Location = new Point((srn.Bounds.Width - Xb) / 2, 1);  //좌/우,위/아래

            SourceGrid.Cells.Controllers.CustomEvents val_c1 = new SourceGrid.Cells.Controllers.CustomEvents();
            val_c1.ValueChanged += new EventHandler(ValueChangedEvent1);
            grid1.Controller.AddController(val_c1);

            string[] mail_item = new string[] { "sms", "mail" };
            GridHandle.InputComboItem(mail_item);

            grid1_make();
        }
        private void ValueChangedEvent1(object sender, EventArgs e)
        {
            string Query = "";
            int pos = grid1.Selection.ActivePosition.Column;
            int row = grid1.Selection.ActivePosition.Row;
            string dat = grid1[row, pos].ToString().Trim();
            string row_no = grid1[row, 0].ToString().Trim(); //row_id 

            if (pos == 3)
                Query = "update " + DB_TableName + " set name = '" + dat + "' where row_id = " + row_no;

            if (pos == 4)
            {
                if (dat == "sms")
                    dat = "1";
                else
                    dat = "2";
                Query = "update " + DB_TableName + " set gubun = '" + dat + "' where row_id = " + row_no;
            }
            if (pos == 5)
            {
                if (grid1[row, 4].ToString() == "sms")
                {
                    if (!kc.Sms_number_chk(dat))
                    {
                        MessageBox.Show("올바른 핸드폰번호를 입력해 주세요.");
                        grid1[row, 5] = new SourceGrid.Cells.Cell("", typeof(string));
                        grid1[row, 5].View = cc.center_cell;
                        grid1.Refresh();
                        var position = new SourceGrid.Position(grid1.RowsCount - 1, 5);
                        grid1.Selection.Focus(position, true);
                        return;
                    }
                }
                if (grid1[row, 4].ToString() == "mail")
                {
                    if (!kc.Email_Check(dat))
                    {
                        MessageBox.Show("올바른 메일 주소를 입력해 주세요.");
                        grid1[row, 5] = new SourceGrid.Cells.Cell("", typeof(string));
                        grid1[row, 5].View = cc.center_cell;
                        grid1.Refresh();
                        var position = new SourceGrid.Position(grid1.RowsCount - 1, 5);
                        grid1.Selection.Focus(position, true);
                        return;
                    }
                }
                Query = "update " + DB_TableName + " set phone = '" + dat + "' where row_id = " + row_no;
            }
            if (pos == 6)
                Query = "update " + DB_TableName + " set bigo = '" + dat + "' where row_id = " + row_no;

            if (Query != "")
                GridHandle.DataUpdate(Query);            
        }

        private void bAdd_Click(object sender, EventArgs e)
        {
            string Query = "insert into " + DB_TableName + "(gubun) values('1')";
            string row_no = kc.DataUpdate(Query);

            int m = grid1.RowsCount;
            grid1.Rows.Insert(m);
            grid1.Rows[m].Height = 22;

            grid1[m, 0] = new SourceGrid.Cells.Cell(row_no, typeof(string));

            grid1[m, 1] = new SourceGrid.Cells.CheckBox(null, false);
            grid1[m, 2] = new SourceGrid.Cells.Cell((m).ToString(), typeof(string));
            grid1[m, 2].Editor = cc.disable_cell;
            grid1[m, 2].View = cc.center_cell;

            grid1[m, 3] = new SourceGrid.Cells.Cell("", typeof(string));
            grid1[m, 3].View = cc.center_cell;

            grid1[m, 4] = new SourceGrid.Cells.Cell("sms", typeof(string));
            grid1[m, 4].View = cc.center_cell;
            grid1[m, 4].Editor = GridHandle.CbBox[0];

            grid1[m, 5] = new SourceGrid.Cells.Cell("", typeof(string));
            grid1[m, 5].View = cc.center_cell;

            grid1[m, 6] = new SourceGrid.Cells.Cell("", typeof(string));
            grid1[m, 6].View = cc.center_cell;

            grid1.Refresh();
            var position = new SourceGrid.Position(grid1.RowsCount-1, 3);
            grid1.Selection.Focus(position, true);
        }

        private void bDel_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("삭제하시겠습니까?", "메세지창", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                GridHandle.ChkDataDelete(DB_TableName, 1, 0, 1);

                for (int m = 1; m < grid1.RowsCount; m++)
                {
                    grid1[m, 2] = new SourceGrid.Cells.Cell((m).ToString(), typeof(string));
                    grid1[m, 2].Editor = cc.disable_cell;
                    grid1[m, 2].View = cc.center_cell;
                }
                grid1.Refresh();

            }
        }
    }
}
