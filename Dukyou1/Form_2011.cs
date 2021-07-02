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
    public partial class Form_2011 : Form
    {
        string DB_TableName = "C_sel_jul";
        SourceGridControl GridHandle = new SourceGridControl();

        public Form_2011()
        {
            InitializeComponent();
        }

        private void Form_201b_Load(object sender, EventArgs e)
        {
            int Xb = this.Width;   //좌,우
            int Yb = this.Height;  //위,아래
            Screen srn = Screen.PrimaryScreen;
            this.Location = new Point((srn.Bounds.Width - Xb) / 2, 1);  //좌/우,위/아래

            SourceGrid.Cells.Controllers.CustomEvents val_c1 = new SourceGrid.Cells.Controllers.CustomEvents();
            val_c1.ValueChanged += new EventHandler(ValueChangedEvent1);
            grid1.Controller.AddController(val_c1);

            GridHandle.SourceGrideInit(grid1, Config.DB_con1);

            string[] Paper_items = new string[] { "국", "46" };
            GridHandle.InputComboItem(Paper_items);

            string[] Sang_joa = new string[] { "상", "좌" };
            GridHandle.InputComboItem(Sang_joa);

            string[] jong = new string[] { "횡목", "종목" };
            GridHandle.InputComboItem(jong);

            string cQuery = " select * FROM " + DB_TableName + " where m_id='1'";
            cQuery += " order by c";
            Grid_View(cQuery);
        }

        private void Grid_View(string cQuery)
        {
            grid1.Rows.Clear();
            cell_d cc = new cell_d();
            //
            grid1.BorderStyle = BorderStyle.FixedSingle;
            grid1.SelectionMode = SourceGrid.GridSelectionMode.Cell;
            grid1.ColumnsCount = 39;
            grid1.FixedRows = 2;
            //grid1.FixedColumns = 16;
            grid1.Rows.Insert(0);
            grid1.Rows[0].Height = 26;
            grid1.Rows.Insert(1);
            grid1.Rows[1].Height = 26;
            //
            grid1[0, 0] = new MyHeader1("row_id");
            grid1[0, 0].RowSpan = 2;
            grid1.Columns[0].Visible = false;
            grid1[0, 1] = new MyHeader1("√");
            grid1[0, 1].RowSpan = 2;
            grid1[0, 2] = new MyHeader1("No");
            grid1[0, 2].RowSpan = 2;
            grid1[0, 3] = new MyHeader1("P");
            grid1[0, 4] = new MyHeader1("IDNo");
            grid1[0, 5] = new MyHeader1("국");
            grid1[0, 6] = new MyHeader1("상");
            grid1[0, 7] = new MyHeader1("C절수");
            grid1[0, 8] = new MyHeader1("I절수");
            grid1[0, 9] = new MyHeader1("실가");
            grid1[0, 10] = new MyHeader1("실세");
            grid1[0, 11] = new MyHeader1("전가");
            grid1[0, 12] = new MyHeader1("전세");
            grid1[0, 13] = new MyHeader1("도지");
            grid1.Columns[13].Visible = false;
            grid1[0, 14] = new MyHeader1("인쇄결");
            grid1[0, 15] = new MyHeader1("판");
            grid1[0, 16] = new MyHeader1("연결");
            grid1[0, 17] = new MyHeader1("닷찌");
            grid1[0, 17].ColumnSpan = 2;
            grid1[0, 19] = new MyHeader1("인쇄유형");
            grid1[0, 19].RowSpan = 2;
            grid1[0, 20] = new MyHeader1("싸이즈");
            grid1[0, 20].RowSpan = 2;
            grid1[0, 21] = new MyHeader1("M절수");
            grid1[0, 21].RowSpan = 2;
            grid1[0, 22] = new MyHeader1("자락");
            grid1[0, 22].RowSpan = 2;

            grid1[0, 23] = new MyHeader1("매엽");
            grid1[0, 23].RowSpan = 2;
            grid1[0, 24] = new MyHeader1("윤전");
            grid1[0, 24].RowSpan = 2;
            grid1[0, 25] = new MyHeader1("디지털" + "\r\n" + "윤전");
            grid1[0, 25].RowSpan = 2;

            grid1[0, 26] = new MyHeader1("정접지");  //23
            grid1[0, 26].RowSpan = 2;

            grid1[0, 27] = new MyHeader1("무선형 - 1안");  //24
            grid1[0, 27].ColumnSpan = 3;
            grid1[0, 30] = new MyHeader1("무선형 - 2안");  //27
            grid1[0, 30].ColumnSpan = 3;
            grid1[0, 33] = new MyHeader1("중철형 - 1안");  //30
            grid1[0, 33].ColumnSpan = 3;
            grid1[0, 36] = new MyHeader1("중철형 - 2안");  //33
            grid1[0, 36].ColumnSpan = 3;
            //
            grid1[1, 3] = new MyHeader("-");
            grid1[1, 4] = new MyHeader("-");
            grid1[1, 5] = new MyHeader("-");
            grid1[1, 6] = new MyHeader("-");
            grid1[1, 7] = new MyHeader("-");
            grid1[1, 8] = new MyHeader("-");
            grid1[1, 9] = new MyHeader("-");
            grid1[1, 10] = new MyHeader("-");
            grid1[1, 11] = new MyHeader("-");
            grid1[1, 12] = new MyHeader("-");
            grid1[1, 13] = new MyHeader("-");
            grid1[1, 14] = new MyHeader("-");
            grid1[1, 15] = new MyHeader("-");
            grid1[1, 16] = new MyHeader("-");
            grid1[1, 17] = new MyHeader1("");
            grid1[1, 18] = new MyHeader1("");

            grid1[1, 27] = new MyHeader1("접지1");
            grid1[1, 28] = new MyHeader1("접지2");
            grid1[1, 29] = new MyHeader1("파일");
            grid1.Columns[29].Visible = false;
            grid1[1, 30] = new MyHeader1("접지1");
            grid1[1, 31] = new MyHeader1("접지2");
            grid1[1, 32] = new MyHeader1("파일");
            grid1.Columns[32].Visible = false;
            grid1[1, 33] = new MyHeader1("접지1");
            grid1[1, 34] = new MyHeader1("접지2");
            grid1[1, 35] = new MyHeader1("파일");
            grid1.Columns[35].Visible = false;
            grid1[1, 36] = new MyHeader1("접지1");
            grid1[1, 37] = new MyHeader1("접지2");
            grid1[1, 38] = new MyHeader1("파일");
            grid1.Columns[38].Visible = false;
            //
            grid1.Columns[1].Width = 22;   //√
            grid1.Columns[2].Width = 36;   //
            grid1.Columns[3].Width = 30;   //
            grid1.Columns[4].Width = 36;   //
            grid1.Columns[5].Width = 50;   //
            grid1.Columns[6].Width = 50;   //
            grid1.Columns[7].Width = 50;   //
            grid1.Columns[8].Width = 50;   //
            grid1.Columns[9].Width = 40;   //
            grid1.Columns[10].Width = 40;  //
            grid1.Columns[11].Width = 40;  //
            grid1.Columns[12].Width = 40;  //
            //grid1.Columns[13].Width = 40;  //
            grid1.Columns[14].Width = 60;  //
            grid1.Columns[15].Width = 20;  //
            grid1.Columns[16].Width = 40;  //
            grid1.Columns[17].Width = 20;  //
            grid1.Columns[18].Width = 20;  //
            grid1.Columns[19].Width = 60;  //
            grid1.Columns[20].Width = 58;  //
            grid1.Columns[21].Width = 50;  //
            grid1.Columns[22].Width = 40;  //

            grid1.Columns[23].Width = 50;  //
            grid1.Columns[24].Width = 50;  //
            grid1.Columns[25].Width = 50;  //

            grid1.Columns[26].Width = 55;  //
            grid1.Columns[27].Width = 110;  //
            grid1.Columns[28].Width = 80;  //
            //grid1.Columns[29].Width = 60;  //
            grid1.Columns[30].Width = 140;  //
            grid1.Columns[31].Width = 140;  //
            //grid1.Columns[32].Width = 60;  //
            grid1.Columns[33].Width = 110;  //
            grid1.Columns[34].Width = 80;  //
            //grid1.Columns[35].Width = 60;  //
            grid1.Columns[36].Width = 140;  //
            grid1.Columns[37].Width = 140;  //
            //grid1.Columns[38].Width = 60;  //
            //
            var DBConn = new MySqlConnection(Config.DB_con1);
            DBConn.Open();
            
            var cmd = new MySqlCommand(cQuery, DBConn);
            var myRead = cmd.ExecuteReader();
            // 
            int m = 2;
            while (myRead.Read())
            {
                grid1.Rows.Insert(m);
                grid1.Rows[m].Height = 22;
                //
                grid1[m, 0] = new SourceGrid.Cells.Cell(myRead["row_id"], typeof(string));
                grid1[m, 1] = new SourceGrid.Cells.CheckBox(null, false);
                grid1[m, 2] = new SourceGrid.Cells.Cell((m - 1).ToString(), typeof(string));  //no
                grid1[m, 2].View = cc.center_cell;
                grid1[m, 2].Editor = cc.disable_cell;
                grid1[m, 3] = new SourceGrid.Cells.Cell(myRead["p_id"].ToString(), typeof(string));  //Type
                grid1[m, 3].View = cc.center_cell;
                grid1[m, 4] = new SourceGrid.Cells.Cell(Convert.ToInt32(myRead["row_id"].ToString()), typeof(int));
                grid1[m, 4].View = cc.center_cell;
                grid1[m, 4].Editor = cc.disable_cell;
                grid1[m, 5] = new SourceGrid.Cells.Cell(myRead["a"].ToString(), typeof(string));
                grid1[m, 5].View = cc.center_cell;
                grid1[m, 5].Editor = GridHandle.CbBox[0];
                grid1[m, 6] = new SourceGrid.Cells.Cell(myRead["b"].ToString(), typeof(string));
                grid1[m, 6].View = cc.center_cell;
                grid1[m, 6].Editor = GridHandle.CbBox[1];
                grid1[m, 7] = new SourceGrid.Cells.Cell(myRead["c"].ToString(), typeof(string));
                grid1[m, 7].View = cc.center_cell;
                grid1[m, 8] = new SourceGrid.Cells.Cell(myRead["d"].ToString(), typeof(string));
                grid1[m, 8].View = cc.center_cell;
                grid1[m, 9] = new SourceGrid.Cells.Cell(myRead["e"].ToString(), typeof(string));
                grid1[m, 9].View = cc.center_cell;
                grid1[m, 10] = new SourceGrid.Cells.Cell(myRead["f"].ToString(), typeof(string));
                grid1[m, 10].View = cc.center_cell;
                grid1[m, 11] = new SourceGrid.Cells.Cell(myRead["h"].ToString(), typeof(string));
                grid1[m, 11].View = cc.center_cell;
                grid1[m, 12] = new SourceGrid.Cells.Cell(myRead["i"].ToString(), typeof(string));
                grid1[m, 12].View = cc.center_cell;
                grid1[m, 13] = new SourceGrid.Cells.Cell(myRead["g"].ToString(), typeof(string));
                grid1[m, 13].View = cc.center_cell;
                grid1[m, 14] = new SourceGrid.Cells.Cell(myRead["prn_grain"].ToString(), typeof(string));
                grid1[m, 14].View = cc.center_cell;
                grid1[m, 14].Editor = GridHandle.CbBox[2];
                grid1[m, 15] = new SourceGrid.Cells.Cell(myRead["j"].ToString(), typeof(string));
                grid1[m, 15].View = cc.center_cell;
                grid1[m, 16] = new SourceGrid.Cells.Cell(myRead["l"].ToString(), typeof(string));
                grid1[m, 16].View = cc.center_cell;
                grid1[m, 17] = new SourceGrid.Cells.Cell(myRead["da1"].ToString(), typeof(string));
                grid1[m, 17].View = cc.center_cell;
                grid1[m, 18] = new SourceGrid.Cells.Cell(myRead["da2"].ToString(), typeof(string));
                grid1[m, 18].View = cc.center_cell;
                grid1[m, 19] = new SourceGrid.Cells.Cell(myRead["print_pattern"].ToString(), typeof(string));
                grid1[m, 19].View = cc.center_cell;
                grid1[m, 20] = new SourceGrid.Cells.Cell(myRead["d_size"].ToString(), typeof(string));
                grid1[m, 20].View = cc.center_cell;
                grid1[m, 21] = new SourceGrid.Cells.Cell(myRead["m_julsu"].ToString(), typeof(string));
                grid1[m, 21].View = cc.center_cell;
                grid1[m, 22] = new SourceGrid.Cells.Cell(myRead["jarak"].ToString(), typeof(string));
                grid1[m, 22].View = cc.center_cell;
                //
                if (myRead["m_id"].Equals(true))
                    grid1[m, 23] = new SourceGrid.Cells.CheckBox(null, true);
                else
                    grid1[m, 23] = new SourceGrid.Cells.CheckBox(null, false);
                //
                if (myRead["y_id"].Equals(true))
                    grid1[m, 24] = new SourceGrid.Cells.CheckBox(null, true);
                else
                    grid1[m, 24] = new SourceGrid.Cells.CheckBox(null, false);
                //
                if (myRead["d_id"].Equals(true))
                    grid1[m, 25] = new SourceGrid.Cells.CheckBox(null, true);
                else
                    grid1[m, 25] = new SourceGrid.Cells.CheckBox(null, false);
                //
                if (myRead["jung_jubji"].Equals(true))
                    grid1[m, 26] = new SourceGrid.Cells.CheckBox(null, true);
                else
                    grid1[m, 26] = new SourceGrid.Cells.CheckBox(null, false);
                //
                grid1[m, 27] = new SourceGrid.Cells.Cell(myRead["mu_jubji_11"].ToString(), typeof(string));
                grid1[m, 28] = new SourceGrid.Cells.Cell(myRead["mu_jubji_12"].ToString(), typeof(string));
                grid1[m, 29] = new SourceGrid.Cells.Cell(myRead["mu_file_1"].ToString(), typeof(string));
                grid1[m, 30] = new SourceGrid.Cells.Cell(myRead["mu_jubji_21"].ToString(), typeof(string));
                grid1[m, 31] = new SourceGrid.Cells.Cell(myRead["mu_jubji_22"].ToString(), typeof(string));
                grid1[m, 32] = new SourceGrid.Cells.Cell(myRead["mu_file_2"].ToString(), typeof(string));
                grid1[m, 33] = new SourceGrid.Cells.Cell(myRead["ju_jubji_11"].ToString(), typeof(string));
                grid1[m, 34] = new SourceGrid.Cells.Cell(myRead["ju_jubji_12"].ToString(), typeof(string));
                grid1[m, 35] = new SourceGrid.Cells.Cell(myRead["ju_file_1"].ToString(), typeof(string));
                grid1[m, 36] = new SourceGrid.Cells.Cell(myRead["ju_jubji_21"].ToString(), typeof(string));
                grid1[m, 37] = new SourceGrid.Cells.Cell(myRead["ju_jubji_22"].ToString(), typeof(string));
                grid1[m, 38] = new SourceGrid.Cells.Cell(myRead["ju_file_2"].ToString(), typeof(string));
                m++;
            }
            myRead.Close();
            DBConn.Close();
        }

        private void ValueChangedEvent1(object sender, EventArgs e)  //Grid1에서 볼륨첸지
        {
            var DBConn = new MySqlConnection(Config.DB_con1);
            DBConn.Open();
            string cQuery = "";
            int pos = grid1.Selection.ActivePosition.Column;
            int row = grid1.Selection.ActivePosition.Row;
            string dat = grid1[row, pos].ToString().Trim();
            string row_no = grid1[row, 0].ToString().Trim(); //row_id 
            //
            if (pos == 3)
                cQuery = " update " + DB_TableName + " set p_id='" + dat + "' where row_id='" + row_no + "'";
            else if (pos == 5)
                cQuery = " update " + DB_TableName + " set a='" + dat + "' where row_id='" + row_no + "'";
            else if (pos == 6)
                cQuery = " update " + DB_TableName + " set b='" + dat + "' where row_id='" + row_no + "'";
            else if (pos == 7)
                cQuery = " update " + DB_TableName + " set c='" + dat + "' where row_id='" + row_no + "'";
            else if (pos == 8)
                cQuery = " update " + DB_TableName + " set d='" + dat + "' where row_id='" + row_no + "'";
            else if (pos == 9)
                cQuery = " update " + DB_TableName + " set e='" + dat + "' where row_id='" + row_no + "'";
            else if (pos == 10)
                cQuery = " update " + DB_TableName + " set f='" + dat + "' where row_id='" + row_no + "'";
            else if (pos == 11)
                cQuery = " update " + DB_TableName + " set h='" + dat + "' where row_id='" + row_no + "'";
            else if (pos == 12)
                cQuery = " update " + DB_TableName + " set i='" + dat + "' where row_id='" + row_no + "'";
            else if (pos == 14)
                cQuery = " update " + DB_TableName + " set prn_grain='" + dat + "' where row_id='" + row_no + "'";
            else if (pos == 15)
                cQuery = " update " + DB_TableName + " set j='" + dat + "' where row_id='" + row_no + "'";
            else if (pos == 16)
                cQuery = " update " + DB_TableName + " set l='" + dat + "' where row_id='" + row_no + "'";
            else if (pos == 17)
                cQuery = " update " + DB_TableName + " set da1='" + dat + "' where row_id='" + row_no + "'";
            else if (pos == 18)
                cQuery = " update " + DB_TableName + " set da2='" + dat + "' where row_id='" + row_no + "'";
                ////
            else if (pos == 19)
                cQuery = " update " + DB_TableName + " set print_pattern='" + dat + "' where row_id='" + row_no + "'";
            else if (pos == 20)
                cQuery = " update " + DB_TableName + " set d_size='" + dat + "' where row_id='" + row_no + "'";
            else if (pos == 21)
                cQuery = " update " + DB_TableName + " set m_julsu='" + dat + "' where row_id='" + row_no + "'";
            else if (pos == 22)
                cQuery = " update " + DB_TableName + " set jarak='" + dat + "' where row_id='" + row_no + "'";

            else if (pos == 23)
                cQuery = " update " + DB_TableName + " set m_id=" + dat + " where row_id='" + row_no + "'";
            else if (pos == 24)
                cQuery = " update " + DB_TableName + " set y_id=" + dat + " where row_id='" + row_no + "'";
            else if (pos == 25)
                cQuery = " update " + DB_TableName + " set d_id=" + dat + " where row_id='" + row_no + "'";

            else if (pos == 26)
                cQuery = " update " + DB_TableName + " set jung_jubji=" + dat + " where row_id='" + row_no + "'";
            else if (pos == 27)
                cQuery = " update " + DB_TableName + " set mu_jubji_11='" + dat + "' where row_id='" + row_no + "'";
            else if (pos == 28)
                cQuery = " update " + DB_TableName + " set mu_jubji_12='" + dat + "' where row_id='" + row_no + "'";
            else if (pos == 29)
                cQuery = " update " + DB_TableName + " set mu_file_1='" + dat + "' where row_id='" + row_no + "'";
            else if (pos == 30)
                cQuery = " update " + DB_TableName + " set mu_jubji_21='" + dat + "' where row_id='" + row_no + "'";
            else if (pos == 31)
                cQuery = " update " + DB_TableName + " set mu_jubji_22='" + dat + "' where row_id='" + row_no + "'";
            else if (pos == 32)
                cQuery = " update " + DB_TableName + " set mu_file_2='" + dat + "' where row_id='" + row_no + "'";
            else if (pos == 33)
                cQuery = " update " + DB_TableName + " set ju_jubji_11='" + dat + "' where row_id='" + row_no + "'";
            else if (pos == 34)
                cQuery = " update " + DB_TableName + " set ju_jubji_12='" + dat + "' where row_id='" + row_no + "'";
            else if (pos == 35)
                cQuery = " update " + DB_TableName + " set ju_file_1='" + dat + "' where row_id='" + row_no + "'";
            else if (pos == 36)
                cQuery = " update " + DB_TableName + " set ju_jubji_21='" + dat + "' where row_id='" + row_no + "'";
            else if (pos == 37)
                cQuery = " update " + DB_TableName + " set ju_jubji_22='" + dat + "' where row_id='" + row_no + "'";
            else if (pos == 38)
                cQuery = " update " + DB_TableName + " set ju_file_2='" + dat + "' where row_id='" + row_no + "'";
            else
            {
                DBConn.Close();
                return;
            }

            //
            if (cQuery != "")
            {
                var cmd = new MySqlCommand(cQuery, DBConn);
                if (cmd.ExecuteNonQuery() == 0)
                {
                    MessageBox.Show("DB 서버 오류 입니다.");
                    DBConn.Close();
                    return;
                }
            }
            DBConn.Close();
        }

        private void bClear_Click(object sender, EventArgs e)
        {
            cbKook.Text = "";
            cbSang_Joa.Text = "";
            cbPrnGrain.Text = "";
            tbC_jul.Text = "";
            tbI_jul.Text = "";
            tbPan.Text = "";
            cbTrue.Checked = true;
            cbFalse.Checked = true;
            cbKook.Refresh();
            cbSang_Joa.Refresh();
            cbPrnGrain.Refresh();
            tbC_jul.Refresh();
            tbI_jul.Refresh();
            tbPan.Refresh();
        }

        private void bSearch_Click(object sender, EventArgs e)
        {
            string s1, s2, s3, s4, s5, s6, s7, s8, s10, s11, s12;
            string s9 = "";
            if (cbKook.Text != "")
                s1 = " and a = '" + cbKook.Text + "'";
            else
                s1 = "";

            if (cbSang_Joa.Text != "")
                s2 = " and b = '" + cbSang_Joa.Text + "'";
            else
                s2 = "";

            if (tbC_jul.Text != "")
                s3 = " and c = '" + tbC_jul.Text + "'";
            else
                s3 = "";

            if (tbI_jul.Text != "")
                s4 = " and d = '" + tbI_jul.Text + "'";
            else
                s4 = "";

            if (cbPrnGrain.Text != "")
                s5 = " and prn_grain = '" + cbPrnGrain.Text + "'";
            else
                s5 = "";

            if (tbPan.Text != "")
                s6 = " and j = '" + tbPan.Text + "'";
            else
                s6 = "";

            if (chkNormal_prn.Checked == true && chkDotji_prn.Checked == true)
            {
                s7 = "";
                s8 = "";
            }
            else
            {

                if (chkNormal_prn.Checked == true)
                    s7 = " and ( concat(coalesce(da1,''), coalesce(da2,'')) is null or concat(coalesce(da1,''), coalesce(da2,'')) = '')";
                else
                    s7 = "";


                if (chkDotji_prn.Checked == true)
                    s8 = " and (concat(coalesce(da1,''), coalesce(da2,'')) is not null and concat(coalesce(da1,''), coalesce(da2,'')) <> '')";
                else
                    s8 = "";
                //if (chkNormal_prn.Checked == true)
                //    s7 = " and ( concat(coalesce(da1,''), coalesce(da2,'')) is null or concat(da1, da2) = '')";
                //else
                //    s7 = "";


                //if (chkDotji_prn.Checked == true)
                //    s8 = " and (concat(coalesce(da1,''), coalesce(da2,'')) is not null and concat(da1, da2) <> '')";
                //else
                //    s8 = "";
            }
            if (cbTrue.Checked == true)
                s9 = " and jung_jubji = 1";
            if (cbFalse.Checked == true)
                s9 = " and jung_jubji = 0";
            if (cbTrue.Checked == true && cbFalse.Checked == true)
                s9 = "";
            //
            s10 = "";
            s11 = "";
            s12 = "";
            if (checkBox2.Checked == true)
                s10 = " and m_id = 1";
            if (checkBox1.Checked == true)
                s11 = " and y_id = 1";
            if (checkBox3.Checked == true)
                s12 = " and d_id = 1";
            //
            string cQuery = " select * FROM " + DB_TableName + " where row_id > 0 " + s1 + s2 + s3 + s4 + s5 + s6 + s7 + s8 + s9 + s10 + s11 + s12;
            cQuery += " order by c";
            Grid_View(cQuery);
        }

        private void bAdd_Click(object sender, EventArgs e)
        {
            ksgcontrol kc = new ksgcontrol();
            kc.ControlInit(Config.DB_con1, "", "", "");
            string cQuery = "insert into " + DB_TableName + " (jung_jubji) values(0)";
            string input_id = kc.DataUpdate(cQuery);
            cell_d cc = new cell_d();
            int m = grid1.RowsCount;
            grid1.Rows.Insert(m);
            grid1.Rows[m].Height = 22;
            //
            grid1[m, 0] = new SourceGrid.Cells.Cell(input_id, typeof(string));
            grid1[m, 1] = new SourceGrid.Cells.CheckBox(null, false);
            grid1[m, 2] = new SourceGrid.Cells.Cell((m - 1).ToString(), typeof(string));  //no
            grid1[m, 2].View = cc.center_cell;
            grid1[m, 2].Editor = cc.disable_cell;
            grid1[m, 3] = new SourceGrid.Cells.Cell("", typeof(string));  //Type
            grid1[m, 3].View = cc.center_cell;
            grid1[m, 4] = new SourceGrid.Cells.Cell(input_id, typeof(int));
            grid1[m, 4].View = cc.center_cell;
            grid1[m, 4].Editor = cc.disable_cell;
            grid1[m, 5] = new SourceGrid.Cells.Cell("", typeof(string));
            grid1[m, 5].View = cc.center_cell;
            grid1[m, 5].Editor = GridHandle.CbBox[0];
            grid1[m, 6] = new SourceGrid.Cells.Cell("", typeof(string));
            grid1[m, 6].View = cc.center_cell;
            grid1[m, 6].Editor = GridHandle.CbBox[1];
            grid1[m, 7] = new SourceGrid.Cells.Cell("", typeof(string));
            grid1[m, 7].View = cc.center_cell;
            grid1[m, 8] = new SourceGrid.Cells.Cell("", typeof(string));
            grid1[m, 8].View = cc.center_cell;
            grid1[m, 9] = new SourceGrid.Cells.Cell("", typeof(string));
            grid1[m, 9].View = cc.center_cell;
            grid1[m, 10] = new SourceGrid.Cells.Cell("", typeof(string));
            grid1[m, 10].View = cc.center_cell;
            grid1[m, 11] = new SourceGrid.Cells.Cell("", typeof(string));
            grid1[m, 11].View = cc.center_cell;
            grid1[m, 12] = new SourceGrid.Cells.Cell("", typeof(string));
            grid1[m, 12].View = cc.center_cell;
            grid1[m, 13] = new SourceGrid.Cells.Cell("", typeof(string));
            grid1[m, 13].View = cc.center_cell;
            grid1[m, 14] = new SourceGrid.Cells.Cell("", typeof(string));
            grid1[m, 14].View = cc.center_cell;
            grid1[m, 14].Editor = GridHandle.CbBox[2];
            grid1[m, 15] = new SourceGrid.Cells.Cell("", typeof(string));
            grid1[m, 15].View = cc.center_cell;
            grid1[m, 16] = new SourceGrid.Cells.Cell("", typeof(string));
            grid1[m, 16].View = cc.center_cell;
            grid1[m, 17] = new SourceGrid.Cells.Cell("", typeof(string));
            grid1[m, 17].View = cc.center_cell;
            grid1[m, 18] = new SourceGrid.Cells.Cell("", typeof(string));
            grid1[m, 18].View = cc.center_cell;
            grid1[m, 19] = new SourceGrid.Cells.Cell("", typeof(string));
            grid1[m, 19].View = cc.center_cell;
            grid1[m, 20] = new SourceGrid.Cells.Cell("", typeof(string));
            grid1[m, 20].View = cc.center_cell;
            grid1[m, 21] = new SourceGrid.Cells.Cell("", typeof(string));
            grid1[m, 21].View = cc.center_cell;
            grid1[m, 22] = new SourceGrid.Cells.Cell("", typeof(string));
            grid1[m, 22].View = cc.center_cell;
            grid1[m, 23] = new SourceGrid.Cells.CheckBox(null, false);
            grid1[m, 24] = new SourceGrid.Cells.CheckBox(null, false);
            grid1[m, 25] = new SourceGrid.Cells.CheckBox(null, false);

            grid1[m, 26] = new SourceGrid.Cells.CheckBox(null, false);
            grid1[m, 27] = new SourceGrid.Cells.Cell("", typeof(string));
            grid1[m, 28] = new SourceGrid.Cells.Cell("", typeof(string));
            grid1[m, 29] = new SourceGrid.Cells.Cell("", typeof(string));
            grid1[m, 30] = new SourceGrid.Cells.Cell("", typeof(string));
            grid1[m, 31] = new SourceGrid.Cells.Cell("", typeof(string));
            grid1[m, 32] = new SourceGrid.Cells.Cell("", typeof(string));
            grid1[m, 33] = new SourceGrid.Cells.Cell("", typeof(string));
            grid1[m, 34] = new SourceGrid.Cells.Cell("", typeof(string));
            grid1[m, 35] = new SourceGrid.Cells.Cell("", typeof(string));
            grid1[m, 36] = new SourceGrid.Cells.Cell("", typeof(string));
            grid1[m, 37] = new SourceGrid.Cells.Cell("", typeof(string));
            grid1[m, 38] = new SourceGrid.Cells.Cell("", typeof(string));

            var position = new SourceGrid.Position(m, 2);
            GridHandle.grid.Selection.Focus(position, true);
            grid1.Refresh();
        }

        private void bDel_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("선택하신 항목을 삭제합니까 ?", "항목 삭제", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                GridHandle.ChkDataDelete(DB_TableName, 2, 0, 1);
            }
        }

        private void b2Excel_Click(object sender, EventArgs e)
        {
            Excel_convert Ec = new Excel_convert(grid1, "", "");
            Ec.Convert();
        }

        private void bCopy_Click(object sender, EventArgs e)
        {
            cell_d cc = new cell_d();
            int m = grid1.RowsCount;
            int chk = 0;
            for (int i = 0; i < grid1.RowsCount; i++)
            {
                if (grid1[i, 1].ToString() == "True")
                {
                    string row_temp = GridHandle.OneDataCopy(DB_TableName, grid1[i, 0].ToString());

                    var DBConn = new MySqlConnection(Config.DB_con1);
                    DBConn.Open();
                    string cQuery = "select * from " + DB_TableName + " where row_id = " + row_temp;
                    var cmd = new MySqlCommand(cQuery, DBConn);
                    var myRead = cmd.ExecuteReader();

                    while (myRead.Read())
                    {
                        grid1.Rows.Insert(m);
                        grid1.Rows[m].Height = 22;
                        //
                        grid1[m, 0] = new SourceGrid.Cells.Cell(myRead["row_id"], typeof(string));
                        grid1[m, 1] = new SourceGrid.Cells.CheckBox(null, false);
                        grid1[m, 2] = new SourceGrid.Cells.Cell((m - 1).ToString(), typeof(string));  //no
                        grid1[m, 2].View = cc.center_cell;
                        grid1[m, 2].Editor = cc.disable_cell;
                        grid1[m, 3] = new SourceGrid.Cells.Cell(myRead["p_id"].ToString(), typeof(string));  //Type
                        grid1[m, 3].View = cc.center_cell;
                        grid1[m, 4] = new SourceGrid.Cells.Cell(Convert.ToInt32(myRead["row_id"].ToString()), typeof(int));
                        grid1[m, 4].View = cc.center_cell;
                        grid1[m, 4].Editor = cc.disable_cell;
                        grid1[m, 5] = new SourceGrid.Cells.Cell(myRead["a"].ToString(), typeof(string));
                        grid1[m, 5].View = cc.center_cell;
                        grid1[m, 5].Editor = GridHandle.CbBox[0];
                        grid1[m, 6] = new SourceGrid.Cells.Cell(myRead["b"].ToString(), typeof(string));
                        grid1[m, 6].View = cc.center_cell;
                        grid1[m, 6].Editor = GridHandle.CbBox[1];
                        grid1[m, 7] = new SourceGrid.Cells.Cell(myRead["c"].ToString(), typeof(string));
                        grid1[m, 7].View = cc.center_cell;
                        grid1[m, 8] = new SourceGrid.Cells.Cell(myRead["d"].ToString(), typeof(string));
                        grid1[m, 8].View = cc.center_cell;
                        grid1[m, 9] = new SourceGrid.Cells.Cell(myRead["e"].ToString(), typeof(string));
                        grid1[m, 9].View = cc.center_cell;
                        grid1[m, 10] = new SourceGrid.Cells.Cell(myRead["f"].ToString(), typeof(string));
                        grid1[m, 10].View = cc.center_cell;
                        grid1[m, 11] = new SourceGrid.Cells.Cell(myRead["h"].ToString(), typeof(string));
                        grid1[m, 11].View = cc.center_cell;
                        grid1[m, 12] = new SourceGrid.Cells.Cell(myRead["i"].ToString(), typeof(string));
                        grid1[m, 12].View = cc.center_cell;
                        grid1[m, 13] = new SourceGrid.Cells.Cell(myRead["g"].ToString(), typeof(string));
                        grid1[m, 13].View = cc.center_cell;
                        grid1[m, 14] = new SourceGrid.Cells.Cell(myRead["prn_grain"].ToString(), typeof(string));
                        grid1[m, 14].View = cc.center_cell;
                        grid1[m, 14].Editor = GridHandle.CbBox[2];
                        grid1[m, 15] = new SourceGrid.Cells.Cell(myRead["j"].ToString(), typeof(string));
                        grid1[m, 15].View = cc.center_cell;
                        grid1[m, 16] = new SourceGrid.Cells.Cell(myRead["l"].ToString(), typeof(string));
                        grid1[m, 16].View = cc.center_cell;
                        grid1[m, 17] = new SourceGrid.Cells.Cell(myRead["da1"].ToString(), typeof(string));
                        grid1[m, 17].View = cc.center_cell;
                        grid1[m, 18] = new SourceGrid.Cells.Cell(myRead["da2"].ToString(), typeof(string));
                        grid1[m, 18].View = cc.center_cell;
                        grid1[m, 19] = new SourceGrid.Cells.Cell(myRead["print_pattern"].ToString(), typeof(string));
                        grid1[m, 19].View = cc.center_cell;
                        grid1[m, 20] = new SourceGrid.Cells.Cell(myRead["d_size"].ToString(), typeof(string));
                        grid1[m, 20].View = cc.center_cell;
                        grid1[m, 21] = new SourceGrid.Cells.Cell(myRead["m_julsu"].ToString(), typeof(string));
                        grid1[m, 21].View = cc.center_cell;
                        grid1[m, 22] = new SourceGrid.Cells.Cell(myRead["jarak"].ToString(), typeof(string));
                        grid1[m, 22].View = cc.center_cell;

                        if (myRead["m_id"].Equals(true))
                            grid1[m, 23] = new SourceGrid.Cells.CheckBox(null, true);
                        else
                            grid1[m, 23] = new SourceGrid.Cells.CheckBox(null, false);

                        if (myRead["y_id"].Equals(true))
                            grid1[m, 24] = new SourceGrid.Cells.CheckBox(null, true);
                        else
                            grid1[m, 24] = new SourceGrid.Cells.CheckBox(null, false);

                        if (myRead["d_id"].Equals(true))
                            grid1[m, 25] = new SourceGrid.Cells.CheckBox(null, true);
                        else
                            grid1[m, 25] = new SourceGrid.Cells.CheckBox(null, false);

                        if (myRead["jung_jubji"].Equals(true))
                            grid1[m, 26] = new SourceGrid.Cells.CheckBox(null, true);
                        else
                            grid1[m, 26] = new SourceGrid.Cells.CheckBox(null, false);

                        grid1[m, 27] = new SourceGrid.Cells.Cell(myRead["mu_jubji_11"].ToString(), typeof(string));
                        grid1[m, 28] = new SourceGrid.Cells.Cell(myRead["mu_jubji_12"].ToString(), typeof(string));
                        grid1[m, 29] = new SourceGrid.Cells.Cell(myRead["mu_file_1"].ToString(), typeof(string));
                        grid1[m, 30] = new SourceGrid.Cells.Cell(myRead["mu_jubji_21"].ToString(), typeof(string));
                        grid1[m, 31] = new SourceGrid.Cells.Cell(myRead["mu_jubji_22"].ToString(), typeof(string));
                        grid1[m, 32] = new SourceGrid.Cells.Cell(myRead["mu_file_2"].ToString(), typeof(string));
                        grid1[m, 33] = new SourceGrid.Cells.Cell(myRead["ju_jubji_11"].ToString(), typeof(string));
                        grid1[m, 34] = new SourceGrid.Cells.Cell(myRead["ju_jubji_12"].ToString(), typeof(string));
                        grid1[m, 35] = new SourceGrid.Cells.Cell(myRead["ju_file_1"].ToString(), typeof(string));
                        grid1[m, 36] = new SourceGrid.Cells.Cell(myRead["ju_jubji_21"].ToString(), typeof(string));
                        grid1[m, 37] = new SourceGrid.Cells.Cell(myRead["ju_jubji_22"].ToString(), typeof(string));
                        grid1[m, 38] = new SourceGrid.Cells.Cell(myRead["ju_file_2"].ToString(), typeof(string));
                        m++;
                        chk++;
                    }
                    myRead.Close();
                    DBConn.Close();
                }
            }

            grid1.Refresh();
            if (chk == 0)
                MessageBox.Show("복사할 데이터가 없습니다");
            else
            {
                MessageBox.Show("복사 하였습니다");
                GridHandle.ChkCancel(1);
                var position = new SourceGrid.Position(m - 1, 1);
                grid1.Selection.Focus(position, true);
            }
        }
    }
}
