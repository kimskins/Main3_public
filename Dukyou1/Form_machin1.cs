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
    public partial class Form_machin1 : Form
    {
        string x_id = "0";  //업체고유번호
        string f_id = "1";  //폼번호
        string a_code = "";    //a코드
        string b_code = "";    //b코드
        public int nn = 0;
        DataTable prn_dt = new DataTable();  //프린트방식코드번호

        SourceGrid.Cells.Editors.ComboBox cb_pantype;  // grid에 있는 판형에 들어갈 콤보박스

   
       public Form_machin1(string id, string sd, string md)
        {
            InitializeComponent();
            x_id = id;  //업체 고유번호
            f_id = sd;  //폼번호
            a_code = md.Substring(0,2)   ;  //대분류 코드번호
        }

       public Form_machin1(string dd)
       {
           InitializeComponent();
           a_code = dd;  //대분류 코드번호
       }



        private void Form_machin1_Load(object sender, EventArgs e)
        {
            if (x_id == "0")   //업체번호가 있나 없나 에 따라서 수정/추가 가 결정됨
            {
                this.button7.Enabled = false;
                //
                Screen srn = Screen.PrimaryScreen;
                int Xb = this.Width;  //좌,우
                this.Location = new Point((srn.Bounds.Width - Xb) / 2, 1);  //좌/우,위/아래
            }
            else
            {
                this.button7.Enabled = true;
                this.button1.Enabled = false;
                this.button2.Enabled = false;
                this.button5.Enabled = false;
                this.button6.Enabled = false;
            }
            // 인쇄방식 데이타 테이블 만들기
            var DBConn = new MySqlConnection(Config.DB_con1); //공동서버
            DBConn.Open();
            string cQuery = " select b_code,bitem from C_bmodel where a_code='04' order by b_code";  //
            MySqlDataAdapter returnVal = new MySqlDataAdapter(cQuery, DBConn);
            returnVal.Fill(prn_dt);
            returnVal.Dispose();
            DBConn.Close();
            //
            comboBox1.Items.Clear();
            for (int i = 0; i < prn_dt.Rows.Count; i++)
                comboBox1.Items.Add(prn_dt.Rows[i][1].ToString());

            ksgcontrol KC = new ksgcontrol();
            KC.ControlInit(Config.DB_con1, "", "", "");
            KC.ComboBoxItemInsert("hang", comboBox3, "select distinct hang from hang_manage where class='판형'");
            //  
            button3_Click(null, null);
            grid1.Controller.AddController(new ValueChangedEvent());
        }

        private void button3_Click(object sender, EventArgs e)
        {
            cell_d cc = new cell_d();
            string[] pantype = new string[1];

            pantype = Get_pantype_combo();
            cb_pantype = new SourceGrid.Cells.Editors.ComboBox(typeof(string), pantype, false);
            cb_pantype.EditableMode = SourceGrid.EditableMode.Focus | SourceGrid.EditableMode.AnyKey | SourceGrid.EditableMode.SingleClick;
            //
            string s1, s2, s3, s4 = "";
            string c1, c2, c3, c4 = "";

            s1 = "";
            if (comboBox1.Text != "")  //업종-2
            {
                for (int i = 0; i < prn_dt.Rows.Count; i++)
                {
                    if (prn_dt.Rows[i][1].ToString() == comboBox1.Text)
                    {
                        c1 = prn_dt.Rows[i][0].ToString();
                        s1 = " and a.b_model ='" + c1 + "'";
                        break;
                    }
                }
            }
            //
            if (textBox2.Text != "")  //도수
            {
                c2 = textBox2.Text.Trim();
                s2 = " and a.dosu like '%" + c2 + "%'";
            }
            else
                s2 = "";
            //
            if (comboBox3.Text != "")  //판형
            {
                c3 = comboBox3.Text.Trim();
                s3 = " and d.hang like '%" + c3 + "%'";
            }
            else
                s3 = "";
            //
            if (textBox1.Text != "")  //기종
            {
                c4 = textBox1.Text.Trim();
                s4 = " and a.machin_model like '%" + c4 + "%'";
            }
            else
                s4 = "";
            //
            //
            grid1.Rows.Clear();
            //콤보박스 셀
            string[] items = new string[] { "Y", "N" };
            SourceGrid.Cells.Editors.ComboBox combo_cell = new SourceGrid.Cells.Editors.ComboBox(typeof(string), items, false);
            combo_cell.EditableMode = SourceGrid.EditableMode.Default | SourceGrid.EditableMode.Focus;
            //  
            grid1.BorderStyle = BorderStyle.FixedSingle;
            grid1.ColumnsCount = 28;
            grid1.FixedRows = 2;
            grid1.Rows.Insert(0);
            grid1.Rows[0].Height = 26;
            grid1.Rows.Insert(1);
            grid1.Rows[1].Height = 26;

            grid1[0, 0] = new SourceGrid.Cells.ColumnHeader("row_id");
            grid1[0, 0].RowSpan = 2;
            grid1.Columns[0].Visible = false;

            grid1[0, 1] = new MyHeader1("√");
            grid1[0, 1].RowSpan = 2;
            grid1[0, 2] = new MyHeader1("No");
            grid1[0, 2].RowSpan = 2;
            grid1[0, 3] = new MyHeader1("업종1");
            grid1[0, 3].RowSpan = 2;
            grid1[0, 4] = new MyHeader1("업종2");
            grid1[0, 4].RowSpan = 2;
            grid1[0, 5] = new MyHeader1("도수(통)");
            grid1[0, 5].RowSpan = 2;
            grid1[0, 6] = new MyHeader1("판형");
            grid1[0, 6].RowSpan = 2;
            grid1[0, 7] = new MyHeader1("기종");
            grid1[0, 7].RowSpan = 2;

            grid1[0, 8] = new MyHeader1("기계이름");
            grid1[0, 8].RowSpan = 2;

            grid1[0, 9] = new MyHeader1("년식");
            grid1[0, 9].RowSpan = 2;
            grid1[0, 10] = new MyHeader1("기계등급");
            grid1[0, 10].RowSpan = 2;

            grid1[0, 11] = new MyHeader1("기G");
            grid1[0, 11].RowSpan = 2;
            grid1[0, 12] = new MyHeader1("종G");
            grid1[0, 12].RowSpan = 2;
            grid1[0, 13] = new MyHeader1("판Sz");
            grid1[0, 13].RowSpan = 2;
            grid1[0, 14] = new MyHeader1("종이무게");
            grid1[0, 14].ColumnSpan = 2;
            grid1[0, 16] = new MyHeader1("종이최대Sz");
            grid1[0, 16].ColumnSpan = 2;
            grid1[0, 18] = new MyHeader1("종이최소Sz");
            grid1[0, 18].ColumnSpan = 2;
            grid1[0, 20] = new MyHeader1("CIP");
            grid1[0, 20].RowSpan = 2;
            grid1[0, 21] = new MyHeader1("9절");
            grid1[0, 21].RowSpan = 2;
            grid1[0, 22] = new MyHeader1("8절");
            grid1[0, 22].RowSpan = 2;
            grid1[0, 23] = new MyHeader1("국8절(소)");
            grid1[0, 23].RowSpan = 2;
            grid1[0, 24] = new MyHeader1("국8절(대)");
            grid1[0, 24].RowSpan = 2;
            grid1[0, 25] = new MyHeader1("국4절(소)");
            grid1[0, 25].RowSpan = 2;
            grid1[0, 26] = new MyHeader1("국4절(대)");
            grid1[0, 26].RowSpan = 2;
            grid1[0, 27] = new MyHeader1("단가폼");
            grid1[0, 27].RowSpan = 2;
            //  
            grid1[1, 14] = new MyHeader("최소");
            grid1[1, 15] = new MyHeader("최대");
            grid1[1, 16] = new MyHeader("가로");
            grid1[1, 17] = new MyHeader("세로");
            grid1[1, 18] = new MyHeader("가로");
            grid1[1, 19] = new MyHeader("세로");
            //
            var DBConn = new MySqlConnection(Config.DB_con1);
            DBConn.Open();
            //
            string cQuery = " select a.*,b.aitem d1,c.bitem d2, d.hang as pan_hang FROM C_pmachine a";
            cQuery += " Left Outer Join C_amodel b ON b.a_code=a.a_model";
            cQuery += " Left Outer Join C_bmodel c ON c.a_code=a.a_model and c.b_code=a.b_model";
            cQuery += " Left Outer Join hang_manage d ON a.pan_type = d.code1  and d.class = '판형' ";
            cQuery += " where a.a_model='" + a_code + "' " + s1 + s2 + s3 + s4;
            var cmd = new MySqlCommand(cQuery, DBConn);
            var myRead = cmd.ExecuteReader();

            int m = 2;
            while (myRead.Read())
            {
                grid1.Rows.Insert(m);
                grid1.Rows[m].Height = 24;
                grid1[m, 0] = new SourceGrid.Cells.Cell(myRead["row_id"], typeof(string));
                grid1[m, 1] = new SourceGrid.Cells.CheckBox(null, false);                 //√
                grid1[m, 2] = new SourceGrid.Cells.Cell((m - 1), typeof(string));         //No
                grid1[m, 2].View = cc.center_cell;
                grid1[m, 3] = new SourceGrid.Cells.Cell(myRead["d1"], typeof(string));     //업종1
                grid1[m, 3].View = cc.center_cell;
                grid1[m, 4] = new SourceGrid.Cells.Cell(myRead["d2"], typeof(string));     //업종2
                grid1[m, 4].View = cc.center_cell;
                grid1[m, 5] = new SourceGrid.Cells.Cell(myRead["dosu"], typeof(string));     //도수(통)
                grid1[m, 5].View = cc.center_cell;
                grid1[m, 6] = new SourceGrid.Cells.Cell(myRead["pan_hang"], typeof(string));     //판형
                grid1[m, 6].View = cc.center_cell;
                grid1[m, 6].Editor = cb_pantype;

                grid1[m, 7] = new SourceGrid.Cells.Cell(myRead["machin_model"], typeof(string)); //기종

                grid1[m, 8] = new SourceGrid.Cells.Cell(myRead["machin_name"], typeof(string)); //기종

                grid1[m, 9] = new SourceGrid.Cells.Cell(myRead["year_type"], typeof(string));    //년식
                grid1[m, 9].View = cc.center_cell;
                grid1[m, 10] = new SourceGrid.Cells.Cell(myRead["machine_grade"], typeof(string));    //기계등급
                grid1[m, 10].View = cc.center_cell;

                grid1[m, 11] = new SourceGrid.Cells.Cell(myRead["machin_guy"], typeof(string));     //기계G
                grid1[m, 11].View = cc.center_cell;
                grid1[m, 12] = new SourceGrid.Cells.Cell(myRead["paper_guy"], typeof(string));     //종이G
                grid1[m, 12].View = cc.center_cell;
                grid1[m, 13] = new SourceGrid.Cells.Cell(myRead["pan_size"], typeof(string));    //판Size
                grid1[m, 13].View = cc.center_cell;
                grid1[m, 14] = new SourceGrid.Cells.Cell(myRead["p_weight_min"], typeof(string));    //종이무게(최소)
                grid1[m, 14].View = cc.int_cell;
                grid1[m, 14].Editor = cc.int_editor;
                grid1[m, 15] = new SourceGrid.Cells.Cell(myRead["p_weight_max"], typeof(string));    //종이무게(최대)
                grid1[m, 15].View = cc.int_cell;
                grid1[m, 15].Editor = cc.int_editor;
                grid1[m, 16] = new SourceGrid.Cells.Cell(myRead["p_garo_max"], typeof(string));    //종이최대size(가로)
                grid1[m, 16].View = cc.int_cell;
                grid1[m, 16].Editor = cc.int_editor;
                grid1[m, 17] = new SourceGrid.Cells.Cell(myRead["p_sero_max"], typeof(string));    //종이최대size(세로)
                grid1[m, 17].View = cc.int_cell;
                grid1[m, 17].Editor = cc.int_editor;
                grid1[m, 18] = new SourceGrid.Cells.Cell(myRead["p_garo_min"], typeof(string));    //종이최소size(가로)
                grid1[m, 18].View = cc.int_cell;
                grid1[m, 18].Editor = cc.int_editor;
                grid1[m, 19] = new SourceGrid.Cells.Cell(myRead["p_sero_min"], typeof(string));    //종이최소size(세로)
                grid1[m, 19].View = cc.int_cell;
                grid1[m, 19].Editor = cc.int_editor;
                grid1[m, 20] = new SourceGrid.Cells.Cell(myRead["cip"], typeof(string));    //CIP
                grid1[m, 20].View = cc.center_cell;
                grid1[m, 20].Editor = combo_cell;

                grid1[m, 21] = new SourceGrid.Cells.Cell(myRead["p46_9"], typeof(string));   //46 9절
                grid1[m, 21].View = cc.center_cell;

                grid1[m, 22] = new SourceGrid.Cells.Cell(myRead["p46_8"], typeof(string));   //46 8절
                grid1[m, 22].View = cc.center_cell;

                grid1[m, 23] = new SourceGrid.Cells.Cell(myRead["kook_8_sin"], typeof(string));   //국8절 신국판
                grid1[m, 23].View = cc.center_cell;

                grid1[m, 24] = new SourceGrid.Cells.Cell(myRead["kook_8_kook"], typeof(string));   //국8절 국배판
                grid1[m, 24].View = cc.center_cell;

                grid1[m, 25] = new SourceGrid.Cells.Cell(myRead["kook_4_s"], typeof(string));   //국4절
                grid1[m, 25].View = cc.center_cell;

                grid1[m, 26] = new SourceGrid.Cells.Cell(myRead["kook_4_b"], typeof(string));   //국4절(대)
                grid1[m, 26].View = cc.center_cell;

                grid1[m, 27] = new SourceGrid.Cells.Cell(myRead["danga_form"], typeof(string));   //단가폼
                grid1[m, 27].View = cc.center_cellb;
                //                                                                        
                if (x_id != "0")
                {
                    grid1[m, 2].Editor = cc.disable_cell;
                    grid1[m, 3].Editor = cc.disable_cell;
                    grid1[m, 4].Editor = cc.disable_cell;
                    grid1[m, 5].Editor = cc.disable_cell;
                    grid1[m, 6].Editor = cc.disable_cell;
                    grid1[m, 7].Editor = cc.disable_cell;

                    grid1[m, 9].Editor = cc.disable_cell;
                    grid1[m, 10].Editor = cc.disable_cell;
                    grid1[m, 11].Editor = cc.disable_cell;
                    grid1[m, 12].Editor = cc.disable_cell;
                    grid1[m, 13].Editor = cc.disable_cell;
                    grid1[m, 14].Editor = cc.disable_cell;
                    grid1[m, 15].Editor = cc.disable_cell;
                    grid1[m, 16].Editor = cc.disable_cell;
                    grid1[m, 17].Editor = cc.disable_cell;
                    grid1[m, 18].Editor = cc.disable_cell;
                    grid1[m, 19].Editor = cc.disable_cell;
                    grid1[m, 20].Editor = cc.disable_cell;
                    grid1[m, 21].Editor = cc.disable_cell;
                    grid1[m, 22].Editor = cc.disable_cell;
                    grid1[m, 23].Editor = cc.disable_cell;
                    grid1[m, 24].Editor = cc.disable_cell;
                    grid1[m, 25].Editor = cc.disable_cell;
                    grid1[m, 26].Editor = cc.disable_cell;
                    grid1[m, 27].Editor = cc.disable_cell;
                }
                else
                {
                    grid1[m, 2].Editor = cc.disable_cell;
                    grid1[m, 3].Editor = cc.disable_cell;
                    grid1[m, 4].Editor = cc.disable_cell;
                }
                m++;
            }
            //
            grid1.Columns[0].Width = 100;

            grid1.Columns[1].Width = 30;
            grid1.Columns[2].Width = 30;
            grid1.Columns[3].Width = 70;  //
            grid1.Columns[4].Width = 80;
            grid1.Columns[5].Width = 60;
            grid1.Columns[6].Width = 60;
            grid1.Columns[7].Width = 200;
            grid1.Columns[8].Width = 150;

            grid1.Columns[9].Width = 50;

            grid1.Columns[10].Width = 60;
            grid1.Columns[11].Width = 50;
            grid1.Columns[12].Width = 50;
            grid1.Columns[13].Width = 90; //
            grid1.Columns[14].Width = 50;
            grid1.Columns[15].Width = 50;
            grid1.Columns[16].Width = 50;
            grid1.Columns[17].Width = 50;
            grid1.Columns[18].Width = 50;
            grid1.Columns[19].Width = 50;
            grid1.Columns[20].Width = 50; //
            grid1.Columns[21].Width = 60; //
            grid1.Columns[22].Width = 60; //
            grid1.Columns[23].Width = 60; //
            grid1.Columns[24].Width = 60; //
            grid1.Columns[25].Width = 60; //
            grid1.Columns[26].Width = 60; //
            grid1.Columns[27].Width = 50; //
            //
            myRead.Close();
            DBConn.Close();
            grid1.Focus();
  
        }
        //
        public class ValueChangedEvent : SourceGrid.Cells.Controllers.ControllerBase   //내용 수정
        {
            public override void OnValueChanged(SourceGrid.CellContext sender, EventArgs e)
            {
                base.OnValueChanged(sender, e);

                int ps = sender.Position.Column;
                SourceGrid.Grid grid = (SourceGrid.Grid)sender.Grid;
                string cQuery = "";
                string row_no = grid[grid.Selection.ActivePosition.Row, 0].ToString().Trim();
                string dat = grid[grid.Selection.ActivePosition.Row, grid.Selection.ActivePosition.Column].ToString().Trim().Replace(",", "");
                //
                if (ps == 5)
                    cQuery = " update C_pmachine set dosu='" + dat + "' where row_id='" + row_no + "'";
                else if (ps == 6)
                {
                    cQuery = "select * from hang_manage where hang = '" + dat + "' and class = '판형'";

                    var DBConn1 = new MySqlConnection(Config.DB_con1);
                    DBConn1.Open();
                    var cmd1 = new MySqlCommand(cQuery, DBConn1);
                    var myRead1 = cmd1.ExecuteReader();

                    if (myRead1.Read())
                        dat = myRead1["code1"].ToString().Trim();
                    else
                    {
                        MessageBox.Show("등록되지 않은 판형입니다. 수정에 실패하였습니다");
                        myRead1.Close();
                        DBConn1.Close();
                        return;
                    }

                    myRead1.Close();
                    DBConn1.Close();
                    cQuery = " update C_pmachine set pan_type='" + dat + "' where row_id='" + row_no + "'";
                }
                else if (ps == 7)
                    cQuery = " update C_pmachine set machin_model='" + dat + "' where row_id='" + row_no + "'";
                else if (ps == 8)
                    cQuery = " update C_pmachine set machin_name='" + dat + "' where row_id='" + row_no + "'";

                else if (ps == 9)
                    cQuery = " update C_pmachine set year_type='" + dat + "' where row_id='" + row_no + "'";
                else if (ps == 10)
                    cQuery = " update C_pmachine set machine_grade='" + dat + "' where row_id='" + row_no + "'";
                else if (ps == 11)
                    cQuery = " update C_pmachine set machin_guy='" + dat + "' where row_id='" + row_no + "'";
                else if (ps == 12)
                    cQuery = " update C_pmachine set paper_guy='" + dat + "', paper_guy_result=" + dat + " where row_id='" + row_no + "'";
                else if (ps == 13)
                    cQuery = " update C_pmachine set pan_size='" + dat + "' where row_id='" + row_no + "'";
                else if (ps == 14)
                    cQuery = " update C_pmachine set p_weight_min='" + dat + "' where row_id='" + row_no + "'";
                else if (ps == 15)
                    cQuery = " update C_pmachine set p_weight_max='" + dat + "' where row_id='" + row_no + "'";
                else if (ps == 16)
                    cQuery = " update C_pmachine set p_garo_max='" + dat + "' where row_id='" + row_no + "'";
                else if (ps == 17)
                    cQuery = " update C_pmachine set p_sero_max='" + dat + "' where row_id='" + row_no + "'";
                else if (ps == 18)
                    cQuery = " update C_pmachine set p_garo_min='" + dat + "' where row_id='" + row_no + "'";
                else if (ps == 19)
                    cQuery = " update C_pmachine set p_sero_min='" + dat + "' where row_id='" + row_no + "'";
                else if (ps == 20)
                    cQuery = " update C_pmachine set cip='" + dat + "' where row_id='" + row_no + "'";
                else if (ps == 21)
                    cQuery = " update C_pmachine set p46_9='" + dat + "' where row_id='" + row_no + "'";
                else if (ps == 22)
                    cQuery = " update C_pmachine set p46_8='" + dat + "' where row_id='" + row_no + "'";
                else if (ps == 23)
                    cQuery = " update C_pmachine set kook_8_sin='" + dat + "' where row_id='" + row_no + "'";
                else if (ps == 24)
                    cQuery = " update C_pmachine set kook_8_kook='" + dat + "' where row_id='" + row_no + "'";
                else if (ps == 25)
                    cQuery = " update C_pmachine set kook_4_s='" + dat + "' where row_id='" + row_no + "'";
                else if (ps == 26)
                    cQuery = " update C_pmachine set kook_4_b='" + dat + "' where row_id='" + row_no + "'";
                else if (ps == 27)
                    cQuery = " update C_pmachine set danga_form='" + dat + "' where row_id='" + row_no + "'";
                else
                    return;
                //   
                var DBConn = new MySqlConnection(Config.DB_con1);
                DBConn.Open();
                var cmd = new MySqlCommand(cQuery, DBConn);
                if (cmd.ExecuteNonQuery() == 0)
                    MessageBox.Show("서버 자료 수정에 실패 했습니다.");
                DBConn.Close();
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            try
            {
                string l_Path = System.IO.Path.Combine(System.IO.Path.GetTempPath(), "CsvFile.csv");

                using (System.IO.StreamWriter writer = new System.IO.StreamWriter(l_Path, false, System.Text.Encoding.Default))
                {
                    SourceGrid.Exporter.CSV csv = new SourceGrid.Exporter.CSV();
                    csv.Export(grid1, writer);
                    writer.Close();
                }

                DevAge.Shell.Utilities.OpenFile(l_Path);
            }
            catch (Exception err)
            {
                DevAge.Windows.Forms.ErrorDialog.Show(this, err, "CSV Export Error");
            }

        }

        private void button5_Click_1(object sender, EventArgs e)
             {       
            PrintPreviewDialog dlg = new PrintPreviewDialog();
            grid1.Columns[1].Visible = false;
            grid1.Columns[2].Visible = false;
            grid1.Columns[12].Visible = false;
            grid1.Columns[13].Visible = false;

            SourceGrid.Exporter.GridPrintDocument pd = new SourceGrid.Exporter.GridPrintDocument(grid1);
            pd.RangeToPrint = new SourceGrid.Range(0, 0, this.grid1.Rows.Count - 1, this.grid1.Columns.Count - 1);
            pd.DefaultPageSettings.Landscape = true;
            pd.DefaultPageSettings.Margins.Left = 20;
            pd.DefaultPageSettings.Margins.Right = 0;
            pd.DefaultPageSettings.Margins.Top = 30;
            pd.DefaultPageSettings.Margins.Bottom = 20;

            pd.PageHeaderText = "";
            pd.PageTitleText = "\t인쇄기 정보";
            pd.PageFooterText = "\tPage [PageNo] from [PageCount]";
            dlg.Document = pd;
            dlg.ShowDialog(this);

            grid1.Columns[1].Visible = true;
            grid1.Columns[2].Visible = true;
            grid1.Columns[12].Visible = true;
            grid1.Columns[13].Visible = true;
        }

        private void button2_Click_1(object sender, EventArgs e)
             {
            string[] ss = new string[4];
            ss[0] = a_code;
            ss[1] = "";  //b_code
            ss[2] = "";  //c_code
            ss[3] = "1"; //폼번호
            //
            Form_model frm = new Form_model(button2, ss);
            if (frm.ShowDialog() == DialogResult.OK)
            {
                button3_Click(null, null);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("선택하신 항목을 삭제합니까 ?", "항목 삭제", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                string[] sd = new string[grid1.RowsCount];//
                for (int i = 0; i < sd.Length; i++)
                    sd[i] = "0";
                //
                int s = 0;
                for (int i = 2; i < grid1.RowsCount; i++)
                    if (grid1[i, 1].Value.Equals(true))
                    {
                        sd[s] = grid1[i, 0].Value.ToString().Trim();
                        s++;
                    }

                //  DB 삭제
                var DBConn = new MySqlConnection(Config.DB_con1);
                DBConn.Open();
                //
                for (int i = 0; i < sd.Length; i++)
                {
                    if (sd[i].Equals("0"))
                        break;
                    else
                    {
                        string row_no = sd[i];
                        string cQuery = " delete from C_pmachine where row_id='" + row_no + "'";
                        var cmd = new MySqlCommand(cQuery, DBConn);
                        if (cmd.ExecuteNonQuery() == 0)
                        {
                            MessageBox.Show("서버 자료 삭제에 실패 했습니다.");
                            break;
                        }
                    }
                }
                DBConn.Close();
                //  그리드 삭제
                for (int i = 0; i < sd.Length; i++)
                {
                    if (sd[i].Equals("0"))
                        break;
                    else
                    {
                        for (s = 2; s < grid1.RowsCount; s++)
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

        private void button7_Click(object sender, EventArgs e)
        {
            int insert = 0;
            if (x_id != "0")  //업체번호가 '0'아니라면
            {
                var DBConn = new MySqlConnection(Config.DB_con1);
                DBConn.Open();
                string cQuery = "";
                string field_1 = "";
                string field_2 = "";
                string row_no = "";
                //
                cQuery = "SELECT `COLUMN_NAME` FROM `INFORMATION_SCHEMA`.`COLUMNS` WHERE `TABLE_SCHEMA`='" + Config.DB_name + "' AND `TABLE_NAME`='C_pmachine'";
                var cmd = new MySqlCommand(cQuery, DBConn);
                var myRead = cmd.ExecuteReader();
                string temp = "";
                while (myRead.Read())
                {
                    if (myRead["column_name"].ToString() != "row_id")
                    {
                        temp = myRead["column_name"].ToString().Trim();
                        //
                        field_1 += temp + ",";
                        //
                        if (temp == "int_id")
                            field_2 += "'" + x_id + "',";
                        else if (temp == "form_id")
                            field_2 += "'" + f_id + "',";
                        else
                            field_2 += temp + ",";
                    }
                }
                //       
                myRead.Close();
                field_1 = field_1.Substring(0, field_1.Length - 1);
                field_2 = field_2.Substring(0, field_2.Length - 1);
                // 
                for (int i = 2; i < grid1.RowsCount; i++)
                {
                    if (grid1[i, 1].Value.Equals(true))
                    {
                        row_no = grid1[i, 0].Value.ToString();
                        //               
                        cQuery = "insert into C_hmachin(" + field_1 + ")  select " + field_2 + " from C_pmachine where row_id='" + row_no + "'";
                        var cmd1 = new MySqlCommand(cQuery, DBConn);
                        if (cmd1.ExecuteNonQuery() == 0)
                        {
                            MessageBox.Show("DB 서버 오류 입니다.");
                            break;
                        }
                        insert++;
                    }
                }
                MessageBox.Show("총" + insert.ToString().Trim() + "항목 등록 하였습니다.");
                this.DialogResult = DialogResult.OK;
                this.Close();
                DBConn.Close();
            }
            else
                MessageBox.Show("등록 가능한 상태가 아닙니다.");
            //
        }

        private void grid1_DoubleClick(object sender, EventArgs e)
        {
            int Rows = grid1.Selection.ActivePosition.Row;
            string row_no = grid1[grid1.Selection.ActivePosition.Row, 0].ToString().Trim();
            int column = grid1.Selection.ActivePosition.Column;
            string cQuery = "";

            SourceGrid.Cells.Views.Cell Mycell = new SourceGrid.Cells.Views.Cell();
            Mycell.TextAlignment = DevAge.Drawing.ContentAlignment.MiddleCenter;
            Mycell.BackColor = Color.FromArgb(240, 248, 255);

            if (column == 26)
            {
                Form_register_dangaform Frm = new Form_register_dangaform();
                Frm.ShowDialog();
                if (Frm.form_name == "")
                    return;
                cQuery = " update C_pmachine set danga_form='" + Frm.form_name + "' where row_id='" + row_no + "'";

                var DBConn = new MySqlConnection(Config.DB_con1);
                DBConn.Open();
                var cmd = new MySqlCommand(cQuery, DBConn);
                if (cmd.ExecuteNonQuery() == 0)
                    MessageBox.Show("서버 자료 수정에 실패 했습니다.");
                DBConn.Close();

                grid1[Rows, column] = new SourceGrid.Cells.Cell(Frm.form_name, typeof(string));
                grid1[Rows, column].View = Mycell;
                grid1.Refresh();
            }
        }
             private string[] Get_pantype_combo()
            {
            string cQuery = "select distinct hang from hang_manage where class='판형'";


            var DBConn = new MySqlConnection(Config.DB_con1);
            DBConn.Open();
            var cmd1 = new MySqlCommand(cQuery, DBConn);
            var myRead1 = cmd1.ExecuteReader();
            string[] item = new string[15];

            for (int i = 0; i < 15; i++)
                item[i] = "0";

            int y = 0;
            while (myRead1.Read())
            {
                item[y] = myRead1["hang"].ToString().Trim();
                y++;
            }

            string[] result = new string[y];

            for (int i = 0; i < y; i++)
            {
                result[i] = item[i];
            }

            DBConn.Close();
            myRead1.Close();

            return result;
        }

             private void button4_Click(object sender, EventArgs e)
             {
                 comboBox1.Text = "";
                 comboBox3.Text = "";
                 textBox1.Text = "";
                 textBox2.Text = "";

                 comboBox1.Refresh();
                 comboBox3.Refresh();
                 textBox1.Refresh();
                 textBox2.Refresh();
             }

             private void Form_machin_SizeChanged(object sender, EventArgs e)
             {
                 this.grid1.Size = new System.Drawing.Size(this.Size.Width - 44, this.Height - 151);
             }

            

            
    }
}
