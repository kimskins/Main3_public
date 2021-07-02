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
    public partial class Form_2113 : Form
    {
        SourceGridControl GridHandle = new SourceGridControl();
        string DB_TableName = "C_paper_blackbox";
        public Form_2113()
        {
            InitializeComponent();
        }

        private void Form_2113_Load(object sender, EventArgs e)
        {
            GridHandle.SourceGrideInit(grid1, Config.DB_con1);
            Screen srn = Screen.PrimaryScreen;
            int Xb = this.Width;  //좌,우
            int Yb = this.Height; // 상, 하
            this.Location = new Point((srn.Bounds.Width - Xb) / 2, (srn.Bounds.Height - Yb) / 2 - 50);  //좌/우,위/아래

            string[] item1 = new string[] { "국", "46" };
            GridHandle.InputComboItem(item1);
            string[] item2 = new string[] { "횡목", "종목" };
            GridHandle.InputComboItem(item2);

            SourceGrid.Cells.Controllers.CustomEvents val_c1 = new SourceGrid.Cells.Controllers.CustomEvents();
            val_c1.ValueChanged += new EventHandler(ValueChangedEvent1);
            grid1.Controller.AddController(val_c1);

            string cQuery = "select * from " + DB_TableName + " order by sort_no";
            Grid_View(cQuery);
        }

        private void Grid_View(string cQuery)
        {
            cell_d cc = new cell_d();
            // 
            grid1.Rows.Clear();
            grid1.BorderStyle = BorderStyle.FixedSingle;
            grid1.SelectionMode = SourceGrid.GridSelectionMode.Cell;
            grid1.ColumnsCount = 25;
            grid1.FixedRows = 2;
            grid1.Rows.Insert(0);
            grid1.Rows[0].Height = 24;
            grid1.Rows.Insert(1);
            grid1.Rows[1].Height = 24;
            //
            grid1[0, 0] = new MyHeader1("row_id");
            grid1.Columns[0].Visible = false;

            grid1[0, 1] = new MyHeader1("√");
            grid1[0, 1].RowSpan = 2;

            grid1[0, 2] = new MyHeader1("sort_no");
            grid1.Columns[2].Visible = false;
            grid1[0, 3] = new MyHeader1("no");
            grid1[0, 3].RowSpan = 2;
            grid1[0, 4] = new MyHeader1("코드");
            grid1[0, 4].RowSpan = 2;
            grid1[0, 5] = new MyHeader1("엇결코드");
            grid1[0, 5].RowSpan = 2;
            grid1[0, 6] = new MyHeader1("항목구분\r\n[ S/T, PET ]");
            grid1[0, 6].RowSpan = 2;
            grid1[0, 7] = new MyHeader1("인쇄코드");
            grid1[0, 7].RowSpan = 2;
            grid1[0, 8] = new MyHeader1("구와이코드");
            grid1[0, 8].RowSpan = 2;
            grid1[0, 9] = new MyHeader1("하리모형");
            grid1[0, 9].RowSpan = 2;
            grid1[0, 10] = new MyHeader1("대국전\r\n전지\r\n다찌");
            grid1[0, 10].RowSpan = 2;
            grid1[0, 11] = new MyHeader1("최대사이즈\r\n검사");
            grid1[0, 11].RowSpan = 2;

            grid1[0, 12] = new MyHeader1("스티커.PET\r\n기준사이즈");
            grid1[0, 12].RowSpan = 2;
            grid1[0, 13] = new MyHeader1("스티커.PET\r\n기준 계산");
            grid1[0, 13].RowSpan = 2;

            grid1[0, 14] = new MyHeader1("판형");
            grid1[0, 14].ColumnSpan = 2;
            grid1[0, 16] = new MyHeader1("결");
            grid1[0, 16].RowSpan = 2;
            grid1[0, 17] = new MyHeader1("원사이즈");
            grid1[0, 17].ColumnSpan = 2;
            grid1[0, 19] = new MyHeader1("순위계산\r\n적용율");
            grid1[0, 19].RowSpan = 2;
            grid1[0, 20] = new MyHeader1("정결종이 코드");
            grid1[0, 20].RowSpan = 2;
            grid1[0, 21] = new MyHeader1("엇결종이 코드");
            grid1[0, 21].RowSpan = 2;
            grid1[0, 22] = new MyHeader1("이름별칭");
            grid1[0, 22].RowSpan = 2;
            grid1[0, 23] = new MyHeader1("사이즈별칭");
            grid1[0, 23].RowSpan = 2;
            grid1[0, 24] = new MyHeader1("메모");
            grid1[0, 24].RowSpan = 2;

            grid1[1, 14] = new MyHeader1("46 국");
            grid1[1, 15] = new MyHeader1("절수");
            grid1[1, 17] = new MyHeader1("앞수");
            grid1[1, 18] = new MyHeader1("뒷수");

            //
            grid1.Columns[1].Width = 22;
            grid1.Columns[3].Width = 40;
            grid1.Columns[4].Width = 70;
            grid1.Columns[5].Width = 70;
            grid1.Columns[6].Width = 70;
            grid1.Columns[7].Width = 80;
            grid1.Columns[8].Width = 90;
            grid1.Columns[9].Width = 70;
            grid1.Columns[10].Width = 60;
            grid1.Columns[11].Width = 80;

            grid1.Columns[12].Width = 80;
            grid1.Columns[13].Width = 80;

            grid1.Columns[14].Width = 40;
            grid1.Columns[15].Width = 40;
            grid1.Columns[16].Width = 60;
            grid1.Columns[17].Width = 50;
            grid1.Columns[18].Width = 50;
            grid1.Columns[19].Width = 50;
            grid1.Columns[20].Width = 90;
            grid1.Columns[21].Width = 90;
            grid1.Columns[22].Width = 80;
            grid1.Columns[23].Width = 80;
            grid1.Columns[24].Width = 300;
            //
            MySqlConnection DBConn;

            DBConn = new MySqlConnection(Config.DB_con1);
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
                grid1[m, 2] = new SourceGrid.Cells.Cell(myRead["sort_no"], typeof(int));

                grid1[m, 3] = new SourceGrid.Cells.Cell((m-1).ToString(), typeof(string));
                grid1[m, 3].View = cc.center_cell;
                grid1[m, 3].Editor = cc.disable_cell;

                grid1[m, 4] = new SourceGrid.Cells.Cell(myRead["grain_code"], typeof(string));
                grid1[m, 4].View = cc.center_cell;

                grid1[m, 5] = new SourceGrid.Cells.Cell(myRead["reverse_grain_code"], typeof(string));
                grid1[m, 5].View = cc.center_cell;

                grid1[m, 6] = new SourceGrid.Cells.Cell(myRead["hang_gubun"], typeof(string));
                grid1[m, 6].View = cc.center_cell;

                grid1[m, 7] = new SourceGrid.Cells.Cell(myRead["prn_code"], typeof(string));
                grid1[m, 7].View = cc.center_cell;

                grid1[m, 8] = new SourceGrid.Cells.Cell(myRead["gui_code"], typeof(string));
                grid1[m, 8].View = cc.center_cell;

                grid1[m, 9] = new SourceGrid.Cells.Cell(myRead["hari_model"], typeof(string));
                grid1[m, 9].View = cc.center_cell;

                grid1[m, 10] = new SourceGrid.Cells.Cell(myRead["bigkook_junji_dotji"], typeof(string));
                grid1[m, 10].View = cc.center_cell;

                grid1[m, 11] = new SourceGrid.Cells.Cell(myRead["maximum_size_search"], typeof(string));
                grid1[m, 11].View = cc.center_cell;

                grid1[m, 12] = new SourceGrid.Cells.Cell(myRead["sticker_pet_size"], typeof(string));
                grid1[m, 12].View = cc.center_cell;
                grid1[m, 13] = new SourceGrid.Cells.Cell(myRead["sticker_pet_cal"], typeof(string));
                grid1[m, 13].View = cc.center_cell;



                grid1[m, 14] = new SourceGrid.Cells.Cell(myRead["kook"], typeof(string));
                grid1[m, 14].View = cc.center_cell;
                grid1[m, 14].Editor = GridHandle.CbBox[0];

                grid1[m, 15] = new SourceGrid.Cells.Cell(myRead["jul"], typeof(string));
                grid1[m, 15].View = cc.center_cell;

                grid1[m, 16] = new SourceGrid.Cells.Cell(myRead["grain"], typeof(string));
                grid1[m, 16].View = cc.center_cell;
                grid1[m, 16].Editor = GridHandle.CbBox[1];

                grid1[m, 17] = new SourceGrid.Cells.Cell(myRead["width"], typeof(string));
                grid1[m, 17].View = cc.center_cell;

                grid1[m, 18] = new SourceGrid.Cells.Cell(myRead["height"], typeof(string));
                grid1[m, 18].View = cc.center_cell;

                grid1[m, 19] = new SourceGrid.Cells.Cell(myRead["ranking_per"], typeof(string));
                grid1[m, 19].View = cc.center_cell;

                grid1[m, 20] = new SourceGrid.Cells.Cell(myRead["right_grain_paper_code"], typeof(string));
                grid1[m, 20].View = cc.center_cell;

                grid1[m, 21] = new SourceGrid.Cells.Cell(myRead["reverse_grain_paper_code"], typeof(string));
                grid1[m, 21].View = cc.center_cell;

                grid1[m, 22] = new SourceGrid.Cells.Cell(myRead["paper_alias"], typeof(string));
                grid1[m, 22].View = cc.center_cell;

                grid1[m, 23] = new SourceGrid.Cells.Cell(myRead["size_alias"], typeof(string));
                grid1[m, 23].View = cc.center_cell;

                grid1[m, 24] = new SourceGrid.Cells.Cell(myRead["memo"], typeof(string));
                grid1[m, 24].View = cc.left_cell;
                m++;
            }
            myRead.Close();
            DBConn.Close();
        }

        private void bUp_Click(object sender, EventArgs e)
        {
            GridHandle.ChkMoveUp(2, 1, 0, 2, "sort_no", 3, DB_TableName);
        }

        private void bDown_Click(object sender, EventArgs e)
        {
            GridHandle.ChkMoveDown(2, 1, 0, 2, "sort_no", 3, DB_TableName);
        }

        private void bAdd_Click(object sender, EventArgs e)
        {
            string cQuery = "insert into " + DB_TableName + " (sort_no) values(";
            cQuery += " (select if(max(sort_no)+1>0,max(sort_no)+1,1) from " + DB_TableName + "  as tmp ))";
            GridHandle.DataUpdate(cQuery);

            cQuery = "select * from " + DB_TableName + " order by sort_no";
            Grid_View(cQuery);
            var position = new SourceGrid.Position(grid1.Rows.Count - 1, 1);
            grid1.Selection.Focus(position, true);
        }

        private void ValueChangedEvent1(object sender, EventArgs e)  //Grid1에서 볼륨첸지
        {
            int cpos = grid1.Selection.ActivePosition.Column;
            int rpos = grid1.Selection.ActivePosition.Row;

            if (rpos < 0)
                return;

            string cQuery = "";
            string row_no = grid1[rpos, 0].ToString().Trim();
            string dat = grid1[rpos, cpos].ToString().Trim();
            //
            //
            if (cpos.Equals(4))       //
                cQuery = " update " + DB_TableName + " set grain_code='" + dat + "' where row_id='" + row_no + "'";
            else if (cpos.Equals(5))       //
                cQuery = " update " + DB_TableName + " set reverse_grain_code='" + dat + "' where row_id='" + row_no + "'";
            else if (cpos.Equals(6))       //
                cQuery = " update " + DB_TableName + " set hang_gubun='" + dat + "' where row_id='" + row_no + "'";
            else if (cpos.Equals(7))       //
                cQuery = " update " + DB_TableName + " set prn_code='" + dat + "' where row_id='" + row_no + "'";
            else if (cpos.Equals(8))       //
                cQuery = " update " + DB_TableName + " set gui_code='" + dat + "' where row_id='" + row_no + "'";
            else if (cpos.Equals(9))       //
                cQuery = " update " + DB_TableName + " set hari_model='" + dat + "' where row_id='" + row_no + "'";
            else if (cpos.Equals(10))       //
                cQuery = " update " + DB_TableName + " set bigkook_junji_dotji='" + dat + "' where row_id='" + row_no + "'";
            else if (cpos.Equals(11))       //
                cQuery = " update " + DB_TableName + " set maximum_size_search='" + dat + "' where row_id='" + row_no + "'";

            else if (cpos.Equals(12))       //
                cQuery = " update " + DB_TableName + " set sticker_pet_size='" + dat + "' where row_id='" + row_no + "'";
            else if (cpos.Equals(13))       //
                cQuery = " update " + DB_TableName + " set sticker_pet_cal='" + dat + "' where row_id='" + row_no + "'";

            else if (cpos.Equals(14))       //
                cQuery = " update " + DB_TableName + " set kook='" + dat + "' where row_id='" + row_no + "'";
            else if (cpos.Equals(15))  //
                cQuery = " update " + DB_TableName + " set jul='" + dat + "' where row_id='" + row_no + "'";
            else if (cpos.Equals(16))  //
                cQuery = " update " + DB_TableName + " set grain='" + dat + "' where row_id='" + row_no + "'";
            else if (cpos.Equals(17))  //
                cQuery = " update " + DB_TableName + " set width='" + dat + "' where row_id='" + row_no + "'";
            else if (cpos.Equals(18))  //
                cQuery = " update " + DB_TableName + " set height='" + dat + "' where row_id='" + row_no + "'";
            else if (cpos.Equals(19))  //
                cQuery = " update " + DB_TableName + " set ranking_per='" + dat + "' where row_id='" + row_no + "'";
            else if (cpos.Equals(20))  //
                cQuery = " update " + DB_TableName + " set right_grain_paper_code='" + dat + "' where row_id='" + row_no + "'";
            else if (cpos.Equals(21))  //
                cQuery = " update " + DB_TableName + " set reverse_grain_paper_code='" + dat + "' where row_id='" + row_no + "'";
            else if (cpos.Equals(22))  //
                cQuery = " update " + DB_TableName + " set paper_alias='" + dat + "' where row_id='" + row_no + "'";
            else if (cpos.Equals(23))  //
                cQuery = " update " + DB_TableName + " set size_alias='" + dat + "' where row_id='" + row_no + "'";
            else if (cpos.Equals(24))  //
                cQuery = " update " + DB_TableName + " set memo='" + dat + "' where row_id='" + row_no + "'";
            //
            if (!cQuery.Equals(""))
            {
                if (GridHandle.DataUpdate(cQuery) == 1)
                {
                    MessageBox.Show("서버에라 발생으로 수정되지 않았습니다.");
                }
            }
        }

        private void bRefresh_Click(object sender, EventArgs e)
        {
            string cQuery = "select * from " + DB_TableName + " order by sort_no";
            Grid_View(cQuery);
        }


        private void bClear_Click(object sender, EventArgs e)
        {
            chkOffUV.Checked = false;
            chkYun.Checked = false;
            chkNone.Checked = false;
            chkDigi.Checked = false;
            chkMasta.Checked = false;
            chkIndigo.Checked = false;

            chkJaemul.Checked = false;
            Chk2Side.Checked = false;
            chkNormal.Checked = false;
            chkGuiYun.Checked = false;
            chkPool.Checked = false;
            chkA4.Checked = false;

        }

        private string where_wirte(int num, string where, string condition )
        {
            if (num == 0)
                where = " (" + condition + " ) ";
            else
            {
                where = where.Substring(0, where.LastIndexOf(")") - 1) + " or " + condition + ")";
            }

            return where;
        }
        private void bSearch_Click(object sender, EventArgs e)
        {
            string where_prn = " row_id > 0 ";
            string where_gui = " row_id > 0 ";
            string where_hari = " row_id > 0 ";
            string where_hang = " row_id > 0 ";
            string where_last = " where row_id > 0 and ";
            int prn_code_num, gui_code_num, hari_code_num, hang_code_num;
            prn_code_num = gui_code_num = hari_code_num = hang_code_num = 0;

            if (chkOffUV.Checked == true)
            {
                where_prn = where_wirte(prn_code_num, where_prn, "prn_code = '04#06' ");
                prn_code_num++;
            }

            if (chkYun.Checked == true)
            {
                where_prn = where_wirte(prn_code_num, where_prn, "prn_code = '05' ");
                prn_code_num++;
            }

            if (chkNone.Checked == true)
            {
                where_prn = where_wirte(prn_code_num, where_prn, " prn_code = '09' ");
                prn_code_num++;
            }

            if (chkMasta.Checked == true)
            {
                where_prn = where_wirte(prn_code_num, where_prn, " prn_code = '01' ");
                prn_code_num++;
            }

            if (chkDigi.Checked == true)
            {
                where_prn = where_wirte(prn_code_num, where_prn, " prn_code = '02' ");
                prn_code_num++;
            }

            if (chkIndigo.Checked == true)
            {
                where_prn = where_wirte(prn_code_num, where_prn, " prn_code = '03' ");
                prn_code_num++;
            }

            ////---------- 여기까지 인쇄코드

            if (chkJaemul.Checked == true)
            {
                where_gui = where_wirte(gui_code_num, where_gui, " gui_code like '%A%' ");
                gui_code_num++;
            }

            if (Chk2Side.Checked == true)
            {
                where_gui = where_wirte(gui_code_num, where_gui, " gui_code like '%B%' ");
                gui_code_num++;
            }

            if (chkNormal.Checked == true)
            {
                where_gui = where_wirte(gui_code_num, where_gui, " gui_code like '%C%' ");
                gui_code_num++;
            }

            if (chkGuiYun.Checked == true)
            {
                where_gui = where_wirte(gui_code_num, where_gui, " gui_code like '%D%' ");
                gui_code_num++;
            }

            if (chkPool.Checked == true)
            {
                where_gui = where_wirte(gui_code_num, where_gui, " gui_code like '%E%' ");
                gui_code_num++;
            }

            if (chkA4.Checked == true)
            {
                where_gui = where_wirte(gui_code_num, where_gui, " gui_code like '%F%' ");
                gui_code_num++;
            }
            //---------- 여기까지 구와이 코드

            if ( chkHari_a.Checked == true)
            {
                where_hari = where_wirte(hari_code_num, where_hari, " hari_model like '%a%' ");
                hari_code_num++;
            }

            if (chkHari_a.Checked == true)
            {
                where_hari = where_wirte(hari_code_num, where_hari, " hari_model like '%a%' ");
                hari_code_num++;
            }

            if (chkHari_b.Checked == true)
            {
                where_hari = where_wirte(hari_code_num, where_hari, " hari_model like '%b%' ");
                hari_code_num++;
            }

            if (chkHari_c.Checked == true)
            {
                where_hari = where_wirte(hari_code_num, where_hari, " hari_model like '%c%' ");
                hari_code_num++;
            }

            if (chkHari_d.Checked == true)
            {
                where_hari = where_wirte(hari_code_num, where_hari, " hari_model like '%d%' ");
                hari_code_num++;
            }
            //---------- 여기까지 하리모형

            if (chkHang_a.Checked == true)
            {
                where_hang = where_wirte(hang_code_num, where_hang, " hang_gubun like '%a%' ");
                hang_code_num++;
            }

            if (chkHang_s.Checked == true)
            {
                where_hang = where_wirte(hang_code_num, where_hang, " hang_gubun like '%s%' ");
                hang_code_num++;
            }

            if (chkHang_p.Checked == true)
            {
                where_hang = where_wirte(hang_code_num, where_hang, " hang_gubun like '%p%' ");
                hang_code_num++;
            }
           

            where_last +=  where_prn + " and " + where_gui + " and "+ where_hari+" and "+where_hang;
            string cQuery = "select * from " + DB_TableName + where_last;
            cQuery += " order by sort_no";
            Grid_View(cQuery);

        }

        private void chkOffUV_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void chkYun_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void chkNone_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void chkMasta_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void chkDigi_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void chkIndigo_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void chkJaemul_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void Chk2Side_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void chkNormal_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void chkGuiYun_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void chkPool_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void chkA4_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void bDel_Click(object sender, EventArgs e)
        {
            GridHandle.ChkDataDelete(DB_TableName, 2, 0, 1);
        }

        private void Form_2113_SizeChanged(object sender, EventArgs e)
        {
            this.grid1.Size = new System.Drawing.Size(this.Size.Width - 75, this.Height - 223);
        }
    }
}
