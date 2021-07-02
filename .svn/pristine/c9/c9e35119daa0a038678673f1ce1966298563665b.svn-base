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
    public partial class Form_register_dangaform : Form
    {
        public string form_name = "";
        cell_d cc = new cell_d();
        string DB_TableName_form_manager = "C_danga_form_manage";

        SourceGridControl GridHandle = new SourceGridControl();

        int selection_row = 0;
        Boolean manage = false;
        Boolean MouseDown = false;
        Point currentMousePos;
        public Form_register_dangaform()
        {
            InitializeComponent();

        }
        public Form_register_dangaform(string main)
        {
            InitializeComponent();

            if(main == "main")
                manage = true;

        }

        private void Form_register_dangaform_Load(object sender, EventArgs e)
        {
            Screen srn = Screen.PrimaryScreen;
            int Xb = this.Width;  //좌,우
            int Yb = this.Height;
            this.Location = new Point((srn.Bounds.Width - Xb) / 2, (srn.Bounds.Height - Yb-130)/ 2);  //좌/우,위/아래

            if (manage)
                bChoice.Visible = false;

            GridHandle.SourceGrideInit(grid1, Config.DB_con1, Config.Ftp_ip1, Config.Ftp_id1, Config.Ftp_pw1);

            SourceGrid.Cells.Controllers.CustomEvents val_c1 = new SourceGrid.Cells.Controllers.CustomEvents();
            val_c1.ValueChanged += new EventHandler(ValueChangedEvent1);
            grid1.Controller.AddController(val_c1);

            string cQuery = "select * from " + DB_TableName_form_manager+" order by form_name";
            Grid_View(cQuery);
        }

        public void Grid_View(string Query)
        {
            int Rows = 0;

            grid1.Rows.Clear();

            grid1.BorderStyle = BorderStyle.FixedSingle;
            grid1.ColumnsCount = 7;
            grid1.FixedRows = 1;

            grid1.Rows.Insert(0);

            grid1.Rows[0].Height = 26;

            grid1[Rows, 0] = new MyHeader1("row_id");
            grid1.Columns[0].Visible = false;

            grid1[Rows, 1] = new MyHeader1("√");

            grid1[Rows, 2] = new MyHeader1("No");

            grid1[Rows, 3] = new MyHeader1("폼번호");

            grid1[Rows, 4] = new MyHeader1("▼");

            grid1[Rows, 5] = new MyHeader1("메모");
            grid1[Rows, 6] = new MyHeader1("picture");
            grid1.Columns[6].Visible = false;

            Rows++;

            var DBConn = new MySqlConnection(Config.DB_con1);
            DBConn.Open();
            var cmd = new MySqlCommand(Query, DBConn);

            var myRead = cmd.ExecuteReader();

            grid1.Columns[1].Width = 20;
            grid1.Columns[2].Width = 30;
            grid1.Columns[3].Width = 70;
            grid1.Columns[4].Width = 20;
            grid1.Columns[5].Width = 200;

            
            while (myRead.Read())
            {
                grid1.Rows.Insert(Rows);
                grid1.Rows[Rows].Height = 24;

                grid1[Rows, 0] = new SourceGrid.Cells.Cell(myRead["row_id"], typeof(string));
                grid1[Rows, 1] = new SourceGrid.Cells.CheckBox(null, false);
                
                grid1[Rows, 2] = new SourceGrid.Cells.Cell(Rows.ToString(), typeof(string));
                grid1[Rows, 2].View = cc.int_cell;
                grid1[Rows, 2].Editor = cc.disable_cell;

                grid1[Rows, 3] = new SourceGrid.Cells.Cell(myRead["form_name"], typeof(string));
                grid1[Rows, 3].View = cc.center_cell;

                if (myRead["picture"].ToString() != "False" && myRead["picture"].ToString() != "false")
                    grid1[Rows, 4] = new SourceGrid.Cells.Button("*");
                else
                    grid1[Rows, 4] = new SourceGrid.Cells.Button("");

                grid1[Rows, 5] = new SourceGrid.Cells.Cell(myRead["memo"], typeof(string));
                grid1[Rows, 5].View = cc.left_cell;

                grid1[Rows, 6] = new SourceGrid.Cells.Cell(myRead["picture"], typeof(string));
                
                Rows++;
            }

            myRead.Close();
            DBConn.Close();

            selection_row = 1;
            label1.Text = grid1[selection_row, 3].ToString();
            label1.Refresh();
            var position = new SourceGrid.Position(selection_row, 3);
            grid1.Selection.Focus(position, true);
            Picture_Refresh();
        }

        private void Picture_Refresh()
        {
            int selection_row = this.selection_row;
            string row_id = "";
            if (selection_row < 0)
            {
                selection_row = 1;
                row_id = grid1[selection_row, 0].ToString().Trim();
            }
            else if (this.selection_row == 0)
            {
                selection_row = 0;
                row_id = "0";
            }
            else
                row_id = grid1[selection_row, 0].ToString().Trim();

            if (GridHandle.PictureRefresh2(pictureBox1, "server1", DB_TableName_form_manager, "", row_id ) == 1)  // 수정요망 ------------------------------------------
            {
                bPictureDel.Visible = false;
                bPictureAdd.Visible = true;
            }
            else
            {
                bPictureDel.Visible = true;
                bPictureAdd.Visible = false;
            }
        }

        private void bChoice_Click(object sender, EventArgs e)
        {
            string[] row_ids = new string[grid1.RowsCount];
            row_ids = GridHandle.GetChkRowid(1, 1, 0);
            string row_id = row_ids[0];

            if (row_id == "0")
            {
                MessageBox.Show("선택된 데이터가 없습니다");
                return;
            }
            else
            {
                string Query = "select * from " + DB_TableName_form_manager + " where row_id = " + row_id;
                var DBConn = new MySqlConnection(Config.DB_con1);
                DBConn.Open();
                var cmd = new MySqlCommand(Query, DBConn);

                var myRead = cmd.ExecuteReader();
                myRead.Read();

                form_name = myRead["form_name"].ToString().Trim();
                this.Close();
                myRead.Close();
                DBConn.Close();

            }

        }

        private void bPictureAdd_Click(object sender, EventArgs e)
        {
            int selection_row = this.selection_row;

            if (selection_row < 0)
                selection_row = 1;

            string row_no = grid1[selection_row, 0].ToString().Trim();
            FileControl FC = new FileControl();
            FC.FileControlInit(Config.DB_con1, Config.Ftp_ip1, Config.Ftp_id1, Config.Ftp_pw1);

            OpenFileDialog ofd = new OpenFileDialog();// File descriptor
            if (FC.FileOpenDlg(ofd) == 1)
                return;

            string File = FC.FileReg(ofd, DB_TableName_form_manager, "picture", row_no, "");

            grid1[selection_row, 6] = new SourceGrid.Cells.Cell(File, typeof(string));
            grid1[selection_row, 4] = new SourceGrid.Cells.Button("*");
            grid1.Refresh();
            Picture_Refresh();
        }

        private void bPictureDel_Click(object sender, EventArgs e)
        {
            int selection_row = this.selection_row;

            if (selection_row < 0)
                selection_row = 1;

            string row_no = grid1[selection_row, 0].ToString().Trim();
            FileControl FC = new FileControl();
            FC.FileControlInit(Config.DB_con1, Config.Ftp_ip1, Config.Ftp_id1, Config.Ftp_pw1);

            FC.FileDel(DB_TableName_form_manager, "picture", row_no, "");
            grid1[selection_row, 6] = new SourceGrid.Cells.Cell("", typeof(string));
            grid1[selection_row, 4] = new SourceGrid.Cells.Button("");
            grid1.Refresh();
            Picture_Refresh();
        }

        private void bAdd_Click(object sender, EventArgs e)
        {
            string Query = "insert into " + DB_TableName_form_manager + " (form_name) values('')";
            var DBConn = new MySqlConnection(Config.DB_con1);
            DBConn.Open();
            var cmd = new MySqlCommand(Query, DBConn);

            cmd.ExecuteNonQuery();

            Query = "SELECT LAST_INSERT_ID() dd";
            cmd = new MySqlCommand(Query, DBConn);

            var myRead = cmd.ExecuteReader();
            string row_no = "";
            while (myRead.Read())
                row_no = myRead["dd"].ToString();

            GridNewLine(row_no);
            myRead.Close();
            DBConn.Close();
            

            var position = new SourceGrid.Position(grid1.Rows.Count - 1, 3);
            grid1.Selection.Focus(position, true);
            selection_row = grid1.Rows.Count - 1;  // selection_row 맞추기
            label1.Text = grid1[selection_row, 3].ToString();
            label1.Refresh();
            Picture_Refresh();
        }

        private void GridNewLine(string row_no)
        {
            int Rows = grid1.RowsCount;
            grid1.Rows.Insert(Rows);
            grid1.Rows[Rows].Height = 24;

            grid1[Rows, 0] = new SourceGrid.Cells.Cell(row_no, typeof(string));
            grid1[Rows, 1] = new SourceGrid.Cells.CheckBox(null, false);

            grid1[Rows, 2] = new SourceGrid.Cells.Cell(Rows.ToString(), typeof(string));
            grid1[Rows, 2].View = cc.int_cell;
            grid1[Rows, 2].Editor = cc.disable_cell;

            grid1[Rows, 3] = new SourceGrid.Cells.Cell("", typeof(string));
            grid1[Rows, 3].View = cc.center_cell;

            grid1[Rows, 4] = new SourceGrid.Cells.Button("");

            grid1[Rows, 5] = new SourceGrid.Cells.Cell("", typeof(string));
            grid1[Rows, 5].View = cc.left_cell;

            grid1[Rows, 6] = new SourceGrid.Cells.Cell("", typeof(string));
        }

        private void ValueChangedEvent1(object sender, EventArgs e)  //Grid1에서 볼륨첸지
        {
            string row_no = grid1[grid1.Selection.ActivePosition.Row, 0].ToString().Trim();
            int cpos = grid1.Selection.ActivePosition.Column;
            string dat = grid1[grid1.Selection.ActivePosition.Row, grid1.Selection.ActivePosition.Column].ToString().Trim();
            //
            string cQuery = "";
            //

            if (cpos.Equals(3))       //
                cQuery = " update " + DB_TableName_form_manager + " set form_name='" + dat + "' where row_id='" + row_no + "'";
            else if (cpos.Equals(5))  //
                cQuery = " update " + DB_TableName_form_manager + " set memo='" + dat + "' where row_id='" + row_no + "'";
            
            //
            if (!cQuery.Equals(""))
            {
                if (GridHandle.DataUpdate(cQuery) == 1)
                    MessageBox.Show("서버에라 발생으로 수정되지 않았습니다.");
            }
        }

        private void grid1_Click(object sender, EventArgs e)
        {

            if (grid1.Selection.ActivePosition.Column == 4)
            {
                selection_row = grid1.Selection.ActivePosition.Row;
                label1.Text = grid1[selection_row, 3].ToString();
                label1.Refresh();
                Picture_Refresh();
            }
            else if (grid1.Selection.ActivePosition.Column == 1)
            {
                GridHandle.OnlyOneChk(1, grid1.Selection.ActivePosition.Row, 1);
            }
        }

        private void bDelete_Click(object sender, EventArgs e)
        {
            string[] row_ids = new string[grid1.RowsCount];

            FileControl FC = new FileControl();
            FC.FileControlInit(Config.DB_con1, Config.Ftp_ip1, Config.Ftp_id1, Config.Ftp_pw1);

            row_ids = GridHandle.GetChkRowid(1, 1, 0);
            for (int i = 0; i < grid1.RowsCount; i++)
            {
                if (row_ids[i] == "0")
                    break;

                FC.FileDel(DB_TableName_form_manager, "picture", row_ids[i], "");
            }

            GridHandle.ChkDataDelete(DB_TableName_form_manager, 1, 0, 1);

            if (grid1.RowsCount ==1)
            {
                selection_row = 0;
                label1.Text = "";
                label1.Refresh();
                Picture_Refresh();
            }
            else
            {
                selection_row = 1;
                label1.Text = grid1[selection_row, 3].ToString();
                label1.Refresh();
                var position = new SourceGrid.Position(selection_row, 3);
                grid1.Selection.Focus(position, true);
                Picture_Refresh();
            }
        }

        private void bRefresh_Click(object sender, EventArgs e)
        {
            string cQuery = "select * from " + DB_TableName_form_manager + " order by form_name";
            Grid_View(cQuery);
        }

        private void pictureBox1_MouseDown(object sender, MouseEventArgs e)
        {
            MouseDown = true;
            currentMousePos = e.Location;
        }

        private void pictureBox1_MouseLeave(object sender, EventArgs e)
        {
            MouseDown = false;
        }

        private void pictureBox1_MouseMove(object sender, MouseEventArgs e)
        {
            Point movepos = e.Location;
            if (MouseDown)
            {
                if (movepos.X - currentMousePos.X > 0) // 우측으로 움직일때
                {
                    if (panel1.HorizontalScroll.Value + (movepos.X - currentMousePos.X) <= panel1.HorizontalScroll.Maximum)
                        panel1.HorizontalScroll.Value += (movepos.X - currentMousePos.X);
                    else
                        panel1.HorizontalScroll.Value = panel1.HorizontalScroll.Maximum;
                }
                else if (movepos.X - currentMousePos.X < 0) // 좌측으로 움직일때
                {
                    if (panel1.HorizontalScroll.Value - (currentMousePos.X - movepos.X) >= panel1.HorizontalScroll.Minimum)
                        panel1.HorizontalScroll.Value -= (currentMousePos.X - movepos.X);
                    else
                        panel1.HorizontalScroll.Value = panel1.HorizontalScroll.Minimum;
                }

                // 반대로 해보려고했으나.. 왜안되는지 모르겠음...;;
                //if (movepos.X - currentMousePos.X > 0) // 우측으로 움직일때
                //{
                //    if (panel1.HorizontalScroll.Value - 3 >= panel1.HorizontalScroll.Minimum)
                //        panel1.HorizontalScroll.Value -= 3;
                //    else
                //        panel1.HorizontalScroll.Value = panel1.HorizontalScroll.Minimum;
                //}
                //else if (movepos.X - currentMousePos.X < 0) // 좌측으로 움직일때
                //{
                //    if (panel1.HorizontalScroll.Value + 3 <= panel1.HorizontalScroll.Maximum)
                //        panel1.HorizontalScroll.Value = panel1.HorizontalScroll.Value+3;
                //    else
                //        panel1.HorizontalScroll.Value = panel1.HorizontalScroll.Maximum;
                //}
            }
            currentMousePos = movepos;
        }

        private void pictureBox1_MouseUp(object sender, MouseEventArgs e)
        {
            MouseDown = false;
        }

    }
}
