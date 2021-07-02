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
    public partial class Form_207_old : Form
    {
        SourceGrid.Cells.Controllers.CustomEvents clickEvent1 = new SourceGrid.Cells.Controllers.CustomEvents();

        public Form_207_old()
        {
            InitializeComponent();
        }

        private void Form_sam_Load(object sender, EventArgs e)
        {
            label1.Text = "■ 접지유형 자료관리";
            this.Location = new Point(140, 1);
            button3_Click(null, null);
            grid1.Controller.AddController(new ValueChangedEvent());
            clickEvent1.Click += new EventHandler(clickEvent_Click1);
        }

        public class ValueChangedEvent : SourceGrid.Cells.Controllers.ControllerBase   //내용 수정
        {
            public override void OnValueChanged(SourceGrid.CellContext sender, EventArgs e)
            {
                base.OnValueChanged(sender, e);

                int ps = sender.Position.Column;
                SourceGrid.Grid grid = (SourceGrid.Grid)sender.Grid;
                string cQuery = "";
                string row_no = grid[grid.Selection.ActivePosition.Row, 0].ToString().Trim();
                string dat = grid[grid.Selection.ActivePosition.Row, grid.Selection.ActivePosition.Column].ToString().Trim();
                //
                if (ps == 2)
                    cQuery = " update C_sel_jubji set m='" + dat + "' where row_id='" + row_no + "'";
                else if (ps == 4)
                    cQuery = " update C_sel_jubji set n='" + dat + "' where row_id='" + row_no + "'";
                else if (ps == 6)
                    cQuery = " update C_sel_jubji set nn='" + dat + "' where row_id='" + row_no + "'";
                else
                    return;

                var DBConn = new MySqlConnection(Config.DB_con1);
                DBConn.Open();
                var cmd = new MySqlCommand(cQuery, DBConn);
                if (cmd.ExecuteNonQuery() == 0)
                    MessageBox.Show("서버 자료 수정에 실패 했습니다.");
                DBConn.Close();
            }
        }

        private void button3_Click(object sender, EventArgs e)  //검색
        {
            //
            grid1.Rows.Clear();
            //중앙셀
            SourceGrid.Cells.Views.Cell center_cell = new SourceGrid.Cells.Views.Cell();
            center_cell.TextAlignment = DevAge.Drawing.ContentAlignment.MiddleCenter;
            //좌측셀
            SourceGrid.Cells.Views.Cell left_cell = new SourceGrid.Cells.Views.Cell();
            left_cell.TextAlignment = DevAge.Drawing.ContentAlignment.MiddleLeft;
            //숫자형 셀(int) 오른쪽셀
            SourceGrid.Cells.Views.Cell Int_cell = new SourceGrid.Cells.Views.Cell();
            Int_cell.TextAlignment = DevAge.Drawing.ContentAlignment.MiddleRight;
            //
            SourceGrid.Cells.Editors.TextBox Int_Editor = new SourceGrid.Cells.Editors.TextBox(typeof(int));
            DevAge.ComponentModel.Converter.NumberTypeConverter int_fomat = new DevAge.ComponentModel.Converter.NumberTypeConverter(typeof(int));
            int_fomat.Format = "###,###,###";
            Int_Editor.TypeConverter = int_fomat;
            // 
            grid1.BorderStyle = BorderStyle.FixedSingle;
            grid1.ColumnsCount = 9;
            grid1.FixedRows = 1;
            grid1.Rows.Insert(0);
            grid1.Rows[0].Height = 26;
            //
            grid1[0, 0] = new SourceGrid.Cells.ColumnHeader("row_id");
            grid1.Columns[0].Visible = false;
            grid1[0, 1] = new MyHeader("√");
            grid1[0, 2] = new MyHeader("접지유형");
            grid1[0, 3] = new MyHeader1("그림1");
            grid1[0, 4] = new MyHeader("신접지 유형1");
            grid1[0, 5] = new MyHeader1("그림2");
            grid1[0, 6] = new MyHeader("신접지 유형2");
            grid1[0, 7] = new MyHeader("그림파일1");
            grid1.Columns[7].Visible = false;
            grid1[0, 8] = new MyHeader("그림파일2");
            grid1.Columns[8].Visible = false;
            //
            grid1.Columns[0].Width = 100;
            grid1.Columns[1].Width = 30;
            grid1.Columns[2].Width = 200;
            grid1.Columns[3].Width = 46;
            grid1.Columns[4].Width = 200;  //
            grid1.Columns[5].Width = 46;
            grid1.Columns[6].Width = 200;  //
            grid1.Columns[7].Width = 200;  //
            grid1.Columns[8].Width = 200;  //
            //
            var DBConn = new MySqlConnection(Config.DB_con1);
            DBConn.Open();
            string cQuery = " select * FROM C_sel_jubji order by m";
            var cmd = new MySqlCommand(cQuery, DBConn);
            var myRead = cmd.ExecuteReader();
            //
            int m = 1;
            while (myRead.Read())
            {
                grid1.Rows.Insert(m);
                grid1.Rows[m].Height = 24;
                grid1[m, 0] = new SourceGrid.Cells.Cell(myRead["row_id"], typeof(string));

                grid1[m, 1] = new SourceGrid.Cells.CheckBox(null, false);

                grid1[m, 2] = new SourceGrid.Cells.Cell(myRead["m"], typeof(string));
                grid1[m, 2].View = left_cell;

                if (myRead["grim1"].ToString().Equals(""))
                    grid1[m, 3] = new SourceGrid.Cells.Button("");
                else
                    grid1[m, 3] = new SourceGrid.Cells.Button("  **");
                //
                grid1[m, 3].AddController(clickEvent1);

                grid1[m, 4] = new SourceGrid.Cells.Cell(myRead["n"], typeof(string));
                grid1[m, 4].View = left_cell;

                if (myRead["grim2"].ToString().Equals(""))
                    grid1[m, 5] = new SourceGrid.Cells.Button("");
                else
                    grid1[m, 5] = new SourceGrid.Cells.Button("  **");
                //
                grid1[m, 5].AddController(clickEvent1);

                grid1[m, 6] = new SourceGrid.Cells.Cell(myRead["nn"], typeof(string));
                grid1[m, 6].View = left_cell;

                grid1[m, 7] = new SourceGrid.Cells.Cell(myRead["grim1"], typeof(string));
                grid1[m, 8] = new SourceGrid.Cells.Cell(myRead["grim2"], typeof(string));
                m++;
            }
            //
            grid1.Selection.FocusFirstCell(true);
            myRead.Close();
            DBConn.Close();
        }

        private void button2_Click(object sender, EventArgs e)  //추가
        {
            var DBConn = new MySqlConnection(Config.DB_con1);
            DBConn.Open();
            string cQuery = "";
            cQuery = " insert into C_sel_jubji (m,n,nn) values('','','')";
            var cmd = new MySqlCommand(cQuery, DBConn);
            //
            if (cmd.ExecuteNonQuery() == 0)
            {
                MessageBox.Show("서버 자료 등록에 실패 했습니다.");
                DBConn.Close();
                return;
            }
            else
                button3_Click(null, null);

            DBConn.Close();
        }

        private void button1_Click(object sender, EventArgs e)  //삭제
        {
            if (MessageBox.Show("선택하신 항목을 삭제합니까 ?", "항목 삭제", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                string[] sd = new string[grid1.RowsCount];//
                for (int i = 0; i < sd.Length; i++)
                    sd[i] = "0";
                //
                int s = 1;
                for (int i = 1; i < grid1.RowsCount; i++)
                    if (grid1[i, 1].Value.Equals(true))
                    {
                        sd[s] = grid1[i, 0].Value.ToString().Trim();
                        s++;
                    }

                //  DB 삭제
                var DBConn = new MySqlConnection(Config.DB_con1);
                DBConn.Open();
                //
                for (int i = 1; i < sd.Length; i++)
                {

                    if (sd[i].Equals("0"))
                        break;
                    else
                    {
                        string row_no = sd[i];
                        string cQuery = " delete from C_sel_jubji where row_id='" + row_no + "'";
                        var cmd = new MySqlCommand(cQuery, DBConn);
                        if (cmd.ExecuteNonQuery() == 0)
                        {
                            MessageBox.Show("서버 자료 삭제에 실패 했습니다.");
                            DBConn.Close();
                            break;
                        }
                    }
                }
                DBConn.Close();
                //  그리드 삭제
                for (int i = 1; i < sd.Length; i++)
                {
                    if (sd[i].Equals("0"))
                        break;
                    else
                    {
                        for (s = 1; s < grid1.RowsCount; s++)
                        {
                            if (grid1[s, 0].Value.ToString().Equals(sd[i]))
                            {
                                grid1.Rows.Remove(s);
                            }
                        }
                    }
                }
                if (grid1.RowsCount > 1)
                {
                    grid1.Selection.FocusFirstCell(true);
                }
            }
        }

        private void clickEvent_Click1(object sender, EventArgs e)  //Grid1에서 클릭시
        {
            string row_no = grid1[grid1.Selection.ActivePosition.Row, 0].ToString().Trim();
            string grim1 = grid1[grid1.Selection.ActivePosition.Row, 7].ToString().Trim();
            string grim2 = grid1[grid1.Selection.ActivePosition.Row, 8].ToString().Trim();
            int cpos = grid1.Selection.ActivePosition.Column;
            //
            OhFTP Ftp = new OhFTP(Config.Ftp_ip1, Config.Ftp_id1, Config.Ftp_pw1);
            var DBConn = new MySqlConnection(Config.DB_con1);
            DBConn.Open();
            string cQuery = "";
            //
            if (cpos.Equals(3))
            {
                OpenFileDialog ofd = new OpenFileDialog();//파일열기
                if (grim1.Equals(""))  //그림파일 등록
                {
                    ofd.DefaultExt = "*.*"; //기본 확장자 설정
                    ofd.Filter = "ALL File(*.*)|*.*";
                    ofd.FilterIndex = 1; //기본으로 선택되는 파일 유형 설정 2로하면 모든파일이 선택됨
                    ofd.Multiselect = false;// true;
                    ofd.InitialDirectory = "C:\\";
                    ofd.RestoreDirectory = true;
                    //
                    if (ofd.ShowDialog() == DialogResult.OK)
                    {
                        string ff1 = ofd.FileName;
                        string ff2 = row_no + "-jubji_1.";
                        ff2 += ofd.FileName.Substring(ofd.FileName.LastIndexOf(".") + 1, ofd.FileName.Length - ofd.FileName.LastIndexOf(".") - 1);
                        Ftp.UpLoadFile(ff1, ff2, "C_sel_jubji");
                        //
                        cQuery = " update C_sel_jubji set grim1='" + ff2 + "' where row_id='" + row_no + "'";
                        var cmd = new MySqlCommand(cQuery, DBConn);
                        if (cmd.ExecuteNonQuery() == 0)
                            MessageBox.Show("서버 등록에 실패 했습니다.");
                        grid1[grid1.Selection.ActivePosition.Row, 7].Value = ff2;
                        grid1[grid1.Selection.ActivePosition.Row, 3].Value = "  **";
                    }
                }
                else                         //그림파일 보기
                {
                    Ftp.ViewLoadFile(grim1, "C_sel_jubji");  //서버에 있는 파일보기
                }
            }
            else if (cpos.Equals(5))
            {
                OpenFileDialog ofd = new OpenFileDialog();//파일열기
                if (grim2.Equals(""))  //그림파일 등록
                {
                    ofd.DefaultExt = "*.*"; //기본 확장자 설정
                    ofd.Filter = "ALL File(*.*)|*.*";
                    ofd.FilterIndex = 1; //기본으로 선택되는 파일 유형 설정 2로하면 모든파일이 선택됨
                    ofd.Multiselect = false;// true;
                    ofd.InitialDirectory = "C:\\";
                    ofd.RestoreDirectory = true;
                    //
                    if (ofd.ShowDialog() == DialogResult.OK)
                    {
                        string ff1 = ofd.FileName;
                        string ff2 = row_no + "-jubji_1.";
                        ff2 += ofd.FileName.Substring(ofd.FileName.LastIndexOf(".") + 1, ofd.FileName.Length - ofd.FileName.LastIndexOf(".") - 1);
                        Ftp.UpLoadFile(ff1, ff2, "C_sel_jubji");
                        //
                        cQuery = " update C_sel_jubji set grim2='" + ff2 + "' where row_id='" + row_no + "'";
                        var cmd = new MySqlCommand(cQuery, DBConn);
                        if (cmd.ExecuteNonQuery() == 0)
                            MessageBox.Show("서버 등록에 실패 했습니다.");
                        grid1[grid1.Selection.ActivePosition.Row, 8].Value = ff2;
                        grid1[grid1.Selection.ActivePosition.Row, 5].Value = "  **";
                    }
                }
                else                         //그림파일 보기
                {
                    Ftp.ViewLoadFile(grim2, "C_sel_jubji");  //서버에 있는 파일보기
                }
            }
            DBConn.Close();
        }

    }
}
