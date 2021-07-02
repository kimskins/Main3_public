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
    public partial class Form_209 : Form
    {
        SourceGridControl GridHandle = new SourceGridControl();
        string DB_TableName_safty = "C_safty_model";

        public Form_209()
        {
            InitializeComponent();
        }

        private void Form_209_Load(object sender, EventArgs e)
        {
            Screen srn = Screen.PrimaryScreen;
            int Xb = this.Width;  //좌,우
            this.Location = new Point((srn.Bounds.Width - Xb) / 2, 1);  //좌/우,위/아래

            GridHandle.SourceGrideInit(grid1, Config.DB_con1, Config.Ftp_ip1, Config.Ftp_id1, Config.Ftp_pw1);

            string Query = "select * from " + DB_TableName_safty + " order by ord_no";

            SourceGrid.Cells.Controllers.CustomEvents val_c1 = new SourceGrid.Cells.Controllers.CustomEvents();
            val_c1.ValueChanged += new EventHandler(ValueChangedEvent1);
            grid1.Controller.AddController(val_c1);


            GridView(Query);    
        }

        public void GridView(string Query)
        {

            cell_d cc = new cell_d();
            int Rows = 0;
            grid1.Rows.Clear();

            grid1.BorderStyle = BorderStyle.FixedSingle;
            grid1.ColumnsCount = 6;
            grid1.FixedRows = 1;

            grid1.Rows.Insert(0);

            grid1.Rows[0].Height = 26;

            grid1[Rows, 0] = new MyHeader1("row_id");
            grid1.Columns[0].Visible = false;
            grid1[Rows, 1] = new MyHeader1("√");
            grid1[Rows, 2] = new MyHeader1("No");
            grid1[Rows, 3] = new MyHeader1("안전항목");
            grid1[Rows, 4] = new MyHeader1("코드");
            grid1[Rows, 5] = new MyHeader1("ord_no");
            grid1.Columns[5].Visible = false;

            Rows++;

            var DBConn = new MySqlConnection(Config.DB_con1);
            DBConn.Open();
            var cmd = new MySqlCommand(Query, DBConn);

            var myRead = cmd.ExecuteReader();

            grid1.Columns[1].Width = 20;
            grid1.Columns[2].Width = 30;
            grid1.Columns[3].Width = 500;
            grid1.Columns[4].Width = 300;

            while (myRead.Read())
            {
                grid1.Rows.Insert(Rows);
                grid1.Rows[Rows].Height = 24;

                grid1[Rows, 0] = new SourceGrid.Cells.Cell(myRead["row_id"], typeof(string));
                grid1[Rows, 1] = new SourceGrid.Cells.CheckBox(null, false);
                
                grid1[Rows, 2] = new SourceGrid.Cells.Cell(Rows.ToString(), typeof(string));
                grid1[Rows, 2].View = cc.int_cell;
                grid1[Rows, 2].Editor = cc.disable_cell;

                grid1[Rows, 3] = new SourceGrid.Cells.Cell(myRead["hang"], typeof(string));
                grid1[Rows, 3].View = cc.left_cellr;

                grid1[Rows, 4] = new SourceGrid.Cells.Cell(myRead["gubun"], typeof(string));
                grid1[Rows, 4].View = cc.left_cellr;

                grid1[Rows, 5] = new SourceGrid.Cells.Cell(myRead["ord_no"], typeof(string));
                                
                Rows++;
            }

            myRead.Close();
            DBConn.Close();

        }

        private void bAdd_Click(object sender, EventArgs e)
        {
            string Query = "insert into " + DB_TableName_safty + " ( ord_no ) select max(ord_no)+1 from " + DB_TableName_safty;
            var DBConn = new MySqlConnection(Config.DB_con1);
            DBConn.Open();
            var cmd = new MySqlCommand(Query, DBConn);

            cmd.ExecuteNonQuery();

            Query = "select max(ord_no) as aa, (SELECT LAST_INSERT_ID()) as dd from "+DB_TableName_safty;
            cmd = new MySqlCommand(Query, DBConn);

            var myRead = cmd.ExecuteReader();
            string row_no = "";
            string ord_no = "";
            while (myRead.Read())
            {
                row_no = myRead["dd"].ToString();
                ord_no = myRead["aa"].ToString();
            }

            GridNewLine(row_no, ord_no);

            DBConn.Close();
            myRead.Close();

            var position = new SourceGrid.Position(grid1.Rows.Count - 1, 3);
            grid1.Selection.Focus(position, true);
        }

        void GridNewLine(string row_no, string ord_no)
        {
            cell_d cc = new cell_d();
            int Rows = grid1.RowsCount;

            grid1.Rows.Insert(Rows);
            grid1.Rows[Rows].Height = 24;

            grid1[Rows, 0] = new SourceGrid.Cells.Cell(row_no, typeof(string));
            grid1[Rows, 1] = new SourceGrid.Cells.CheckBox(null, false);

            grid1[Rows, 2] = new SourceGrid.Cells.Cell(Rows.ToString(), typeof(string));
            grid1[Rows, 2].View = cc.int_cell;

            grid1[Rows, 3] = new SourceGrid.Cells.Cell("", typeof(string));
            grid1[Rows, 3].View = cc.left_cellr;

            grid1[Rows, 4] = new SourceGrid.Cells.Cell("", typeof(string));
            grid1[Rows, 4].View = cc.left_cellr;

            grid1[Rows, 5] = new SourceGrid.Cells.Cell(ord_no, typeof(string));

        }

        private void bDel_Click(object sender, EventArgs e)
        {
            GridHandle.ChkDataDelete(DB_TableName_safty, 1, 0, 1);
        }

        private void ValueChangedEvent1(object sender, EventArgs e)  //Grid1에서 볼륨첸지
        {
            string row_no = grid1[grid1.Selection.ActivePosition.Row, 0].ToString().Trim();
            int cpos = grid1.Selection.ActivePosition.Column;
            string dat = grid1[grid1.Selection.ActivePosition.Row, grid1.Selection.ActivePosition.Column].ToString().Trim();
            string cQuery = "";

            if (cpos.Equals(3))       //
                cQuery = " update " + DB_TableName_safty + " set hang='" + dat + "' where row_id='" + row_no + "'";
            else if (cpos.Equals(4))  //
                cQuery = " update " + DB_TableName_safty + " set gubun='" + dat + "' where row_id='" + row_no + "'";
            
            //
            if (!cQuery.Equals(""))
            {
                if( GridHandle.DataUpdate(cQuery) != 0)
                {
                    MessageBox.Show("서버에라 발생으로 수정되지 않았습니다.");
                }
            }
        }

        private void bUp_Click(object sender, EventArgs e)
        {
            GridHandle.ChkMoveUp(1, 1, 0, 5, "ord_no", 2, DB_TableName_safty);
        }

        private void bDown_Click(object sender, EventArgs e)
        {
            GridHandle.ChkMoveDown(1, 1, 0, 5, "ord_no", 2, DB_TableName_safty);
        }

        private void Form_209_SizeChanged(object sender, EventArgs e)
        {
            this.grid1.Size = new System.Drawing.Size(this.Size.Width - 80, this.Height - 116);
            grid1.Columns[4].Width = this.Size.Width - 650;
        }
    }
}
