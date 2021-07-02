using System;
using System.IO;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using System.Diagnostics;
using Excel = Microsoft.Office.Interop.Excel;
using System.Runtime.InteropServices;

namespace Dukyou3
{
    public partial class Form_101 : Form
    {
     //   private DataView mView;
     //   private DataTable p_dt = new DataTable();  //main 자료 테이블
        DataTable hcustomer = new DataTable();
        DataTable s_prn_mode = new DataTable();
        SourceGridControl GridHandle = new SourceGridControl();
        SourceGridControl GridHandle_1 = new SourceGridControl();
        ksgcontrol ks = new ksgcontrol();
        FileControl FC = new FileControl();
        int k = 0;
        string m_id;
        int[] i_su = new int[3];
        public string[] l_st = new string[5];
        string DB_TableName_mok = "C_mokyung";
        string DB_TableName_cust = "C_hcustomer";
        string DB_TableName_file = "C_file_total_manage";
        
        string cQuery = "";
        SourceGrid.Cells.Views.Cell center_cell = new SourceGrid.Cells.Views.Cell();
        SourceGrid.Cells.Views.Cell Int_cell = new SourceGrid.Cells.Views.Cell();
        SourceGrid.Cells.Views.Cell decimal_cell = new SourceGrid.Cells.Views.Cell();
        SourceGrid.Cells.Editors.TextBox Int_Editor = new SourceGrid.Cells.Editors.TextBox(typeof(int));
        SourceGrid.Cells.Editors.TextBox decimal_Editor = new SourceGrid.Cells.Editors.TextBox(typeof(decimal));
         
        int server_file_col = 36;
        int user_file_col = 31;
        string hang_class = "쇼핑백인쇄방법";
        public Form_101(string s_id,int[] s_su)
        {
            InitializeComponent();
            m_id = s_id;
            i_su = s_su;
            for (int i = 0; i < 5; i++)
            {
                l_st[1]="";
            }
          
        }
        private void cell()
        {
            center_cell.TextAlignment = DevAge.Drawing.ContentAlignment.MiddleCenter;
            Int_cell.TextAlignment = DevAge.Drawing.ContentAlignment.MiddleRight;
            DevAge.ComponentModel.Converter.NumberTypeConverter int_fomat = new DevAge.ComponentModel.Converter.NumberTypeConverter(typeof(int));
           
            Int_Editor.TypeConverter = int_fomat;
        }

        private void Form_101_Load(object sender, EventArgs e)
        {
            sync sy = new sync();
            sy.dt(Config.DB_con1, hcustomer, "select sangho, area from " + DB_TableName_cust + " where yubjong like '%1501%' or yubjong like '%1517%' or yubjong like '%1518%'");
            sy.dt(Config.DB_con1, s_prn_mode, "select code1,hang from hang_manage where class='" + hang_class + "' order by no");
            FC.FileControlInit(Config.DB_con1, Config.Ftp_ip1, Config.Ftp_id1, Config.Ftp_pw1);
            cell();
            SourceGrid.Cells.Controllers.CustomEvents val_c1 = new SourceGrid.Cells.Controllers.CustomEvents();
            val_c1.ValueChanged += new EventHandler(ValueChangedEvent1);
            grid1.Controller.AddController(val_c1);

            GridHandle.SourceGrideInit(grid1, Config.DB_con1);
            ks.ControlInit(Config.DB_con1, null, null, null);
            //
            DataRow[] dr = hcustomer.Select();
            cbSangho.Text = "";
            cbSangho.Items.Clear();

            cbArea.Text = "";
            cbArea.Items.Clear();
            
            if (m_id == "1")  //메인에서("1")
            {
                //button3.Enabled = false;
                //checkBox1.Visible = false;
                //
                Screen srn = Screen.PrimaryScreen;
                int Xb = this.Width;  //좌,우
                this.Location = new Point((srn.Bounds.Width - Xb) / 2, 1);  //좌/우,위/아래


                if (dr.Length != 0)
                {
                    string[] s_temp = new string[dr.Length];
                    string[] a_temp = new string[dr.Length];

                    for (int i = 0; i < dr.Length; i++)
                    {
                        s_temp[i] = dr[i]["sangho"].ToString();
                        a_temp[i] = dr[i]["area"].ToString();
                    }
                    cbSangho.Items.AddRange(s_temp);
                    cbArea.Items.AddRange(a_temp);
                }
            }
            else             //주문창에서("2")
            {
                //button1.Enabled = false;
                //button2.Enabled = false;
                //checkBox1.Checked = false;
                ////
                //textBox2.Text = i_su[0].ToString();
                //textBox3.Text = i_su[1].ToString();
                //textBox4.Text = i_su[2].ToString();
                //textBox5.Text = (10).ToString();
            }
            this.Focus();
        }

        private void ValueChangedEvent1(object sender, EventArgs e)
        {
            string Query = "";
            int pos = grid1.Selection.ActivePosition.Column;
            int row = grid1.Selection.ActivePosition.Row;
            string dat = grid1[row, pos].ToString().Trim();
            string row_no = grid1[row, 0].ToString().Trim(); //row_id 
            //
            if (pos == 5)
            {
                Query = "update " + DB_TableName_mok + " set i_no = '" + dat + "' where row_id = " + row_no;
                ks.DataUpdate(Query);
            }
            else if (pos == 6)
            {
                Query = "update " + DB_TableName_mok + " set jang = '" + dat + "' where row_id = " + row_no;
                ks.DataUpdate(Query);
            }
            else if (pos == 7)
            {
                Query = "update " + DB_TableName_mok + " set pok = '" + dat + "' where row_id = " + row_no;
                ks.DataUpdate(Query);
            }
            else if (pos == 8)
            {
                Query = "update " + DB_TableName_mok + " set go = '" + dat + "' where row_id = " + row_no;
                ks.DataUpdate(Query);
            }
            else if (pos == 9)
            {
                Query = "update " + DB_TableName_mok + " set top = '" + dat + "' where row_id = " + row_no;
                ks.DataUpdate(Query);
            }
            else if (pos == 10)
            {
                Query = "update " + DB_TableName_mok + " set bottom = '" + dat + "' where row_id = " + row_no;
                ks.DataUpdate(Query);
            }
            else if (pos == 11)
            {
                Query = "update " + DB_TableName_mok + " set attach = '" + dat + "' where row_id = " + row_no;
                ks.DataUpdate(Query);
            }
            else if (pos == 12)
            {
                Query = "update " + DB_TableName_mok + " set attach_position = '" + dat + "' where row_id = " + row_no;
                ks.DataUpdate(Query);
            }
            else if (pos == 13)
            {
                Query = "update " + DB_TableName_mok + " set dot = '" + dat + "' where row_id = " + row_no;
                ks.DataUpdate(Query);
            }
            else if (pos == 14)
            {
                string prn_mode = "";
                if (!string.IsNullOrEmpty(dat))
                {
                    DataRow[] dr = s_prn_mode.Select("hang='" + dat + "'");
                    if (dr.Length != 0)
                        prn_mode = dr[0]["code1"].ToString(); //특성-2
                }
                Query = "update " + DB_TableName_mok + " set prn_mode = '" + prn_mode + "' where row_id = " + row_no;
                ks.DataUpdate(Query);
            }
            else if (pos == 15)
            {
                Query = "update " + DB_TableName_mok + " set tq_wide = '" + dat + "' where row_id = " + row_no;
                ks.DataUpdate(Query);
            }
            else if (pos == 16)
            {
                Query = "update " + DB_TableName_mok + " set tq_doji = '" + dat + "' where row_id = " + row_no;
                ks.DataUpdate(Query);
            }
            else if (pos == 17)
            {
                Query = "update " + DB_TableName_mok + " set tq_code = '" + dat + "' where row_id = " + row_no;
                ks.DataUpdate(Query);
            }
            else if (pos == 18)
            {
                Query = "update " + DB_TableName_mok + " set cal_code = '" + dat + "' where row_id = " + row_no;
                ks.DataUpdate(Query);
            }
            else if (pos == 19)
            {
                Query = "update " + DB_TableName_mok + " set error_code = '" + dat + "' where row_id = " + row_no;
                ks.DataUpdate(Query);
            }
            else if (pos == 20)
            {
                Query = "update " + DB_TableName_mok + " set tq_pan = '" + dat + "' where row_id = " + row_no;
                ks.DataUpdate(Query);
            }
            else if (pos == 21)
            {
                Query = "update " + DB_TableName_mok + " set tq_julsu = '" + dat + "' where row_id = " + row_no;
                ks.DataUpdate(Query);
            }
            else if (pos == 22)
            {
                Query = "update " + DB_TableName_mok + " set tq_gul = '" + dat + "' where row_id = " + row_no;
                ks.DataUpdate(Query);
            }
            else if (pos == 23)
            {
                Query = "update " + DB_TableName_mok + " set prn_pan = '" + dat + "' where row_id = " + row_no;
                ks.DataUpdate(Query);
            }
            else if (pos == 24)
            {
                Query = "update " + DB_TableName_mok + " set prn_julsu = '" + dat + "' where row_id = " + row_no;
                ks.DataUpdate(Query);
            }
            else if (pos == 25)
            {
                Query = "update " + DB_TableName_mok + " set prn_gul = '" + dat + "' where row_id = " + row_no;
                ks.DataUpdate(Query);
            }
            else if (pos == 26)
            {
                Query = "update " + DB_TableName_mok + " set prn_size = '" + dat + "' where row_id = " + row_no;
                ks.DataUpdate(Query);
            }
            else if (pos == 27)
            {
                Query = "update " + DB_TableName_mok + " set paper_pan = '" + dat + "' where row_id = " + row_no;
                ks.DataUpdate(Query);
            }
            else if (pos == 28)
            {
                Query = "update " + DB_TableName_mok + " set paper_julsu = '" + dat + "' where row_id = " + row_no;
                ks.DataUpdate(Query);
            }
            else if (pos == 29)
            {
                Query = "update " + DB_TableName_mok + " set paper_gul = '" + dat + "' where row_id = " + row_no;
                ks.DataUpdate(Query);
            }
            else if (pos == 30)
            {
                Query = "update " + DB_TableName_mok + " set paper_size = '" + dat + "' where row_id = " + row_no;
                ks.DataUpdate(Query);
            }
            else if (pos == 33)
            {
                Query = "update " + DB_TableName_mok + " set bigo_2 = '" + dat + "' where row_id = " + row_no;
                ks.DataUpdate(Query);
            }
            else if (pos == 34)
            {
                Query = "update " + DB_TableName_mok + " set bigo_1 = '" + dat + "' where row_id = " + row_no;
                ks.DataUpdate(Query);
            }
        }

        private void grid1_view(string cQuery)
        {
            this.Cursor = Cursors.WaitCursor;
            grid1.Rows.Clear();
            cell_d cc = new cell_d();
            //
            grid1.BorderStyle = BorderStyle.FixedSingle;
            grid1.ColumnsCount = 37;
            grid1.FixedRows = 2;
            //grid1.FixedColumns = 15;
            grid1.Rows.Insert(0);
            grid1.Rows[0].Height = 24;
            grid1.Rows.Insert(1);
            grid1.Rows[1].Height = 34;

            grid1[0, 0] = new MyHeader1("row_id");
            grid1[0, 0].RowSpan = 2;
            grid1.Columns[0].Visible = false;
            //
            grid1[0, 1] = new MyHeader1("√");
            grid1[0, 1].RowSpan = 2;
            grid1.Columns[1].Visible = true;
            //
            grid1[0, 2] = new MyHeader1("No");
            grid1[0, 2].RowSpan = 2;
            //
            grid1[0, 3] = new MyHeader1("목형보유업체");
            grid1[0, 3].RowSpan = 2;
            //
            grid1[0, 4] = new MyHeader1("지역");
            grid1[0, 4].RowSpan = 2;
            //
            grid1[0, 5] = new MyHeader2("목형번호");
            grid1[0, 5].RowSpan = 2;
            // 
            grid1[0, 6] = new MyHeader2("쇼핑백 사이즈");
            grid1[0, 6].ColumnSpan = 3;
            //
            grid1[0, 9] = new MyHeader2("쇼핑백 보조사이즈");
            grid1[0, 9].ColumnSpan = 3;
            //
            grid1[0, 12] = new MyHeader2("풀발이" + "\r\n" + "위치");
            grid1[0, 12].RowSpan = 2;
            //
            grid1[0, 13] = new MyHeader2("닷찌");
            grid1[0, 13].RowSpan = 2;
            //
            grid1[0, 14] = new MyHeader2("쇼핑백" + "\r\n" + "인쇄방법");
            grid1[0, 14].RowSpan = 2;
            //
            grid1[0, 15] = new MyHeader1("도큐사이즈");
            grid1[0, 15].ColumnSpan = 2;
            //
            grid1[0, 17] = new MyHeader1("도큐" + "\r\n" + "코드");
            grid1[0, 17].RowSpan = 2;
            //
            grid1[0, 18] = new MyHeader1("계산" + "\r\n" + "코드");
            grid1[0, 18].RowSpan = 2;
            //
            grid1[0, 19] = new MyHeader1("오류" + "\r\n" + "코드");
            grid1[0, 19].RowSpan = 2;
            //
            grid1[0, 20] = new MyHeader1("도　　큐");
            grid1[0, 20].ColumnSpan = 3;
            //
            grid1[0, 23] = new MyHeader1("인　　쇄");
            grid1[0, 23].ColumnSpan = 4;
            //
            grid1[0, 27] = new MyHeader1("종　　이");
            grid1[0, 27].ColumnSpan = 4;
            //
            grid1[0, 31] = new MyHeader1("목형파일");
            grid1[0, 31].ColumnSpan = 2;
            grid1[0, 31].RowSpan = 2;
            //
            grid1[0, 33] = new MyHeader1("비　　고");
            grid1[0, 33].RowSpan = 2;
            //
            grid1[0, 34] = new MyHeader1("인쇄방법" + "\r\n" + "(구)");
            grid1[0, 34].RowSpan = 2;

            grid1[0, 35] = new MyHeader1("sort");
            grid1[0, 35].RowSpan = 2;
            grid1[0, 36] = new MyHeader1("server_file");
            grid1[0, 36].RowSpan = 2;
            grid1.Columns[35].Visible = false;
            grid1.Columns[36].Visible = false;
            //==================================
            grid1[1, 6] = new MyHeader2("장");
            grid1[1, 7] = new MyHeader2("폭");
            grid1[1, 8] = new MyHeader2("고");
            grid1[1, 9] = new MyHeader2("상단");
            grid1[1, 10] = new MyHeader2("하단");
            grid1[1, 11] = new MyHeader2("풀발이");
            
            grid1[1, 15] = new MyHeader1("너비");
            grid1[1, 16] = new MyHeader1("도지");
            grid1[1, 20] = new MyHeader1("판형");
            grid1[1, 21] = new MyHeader1("절수");
            grid1[1, 22] = new MyHeader1("결");
            
            grid1[1, 23] = new MyHeader1("판형");
            grid1[1, 24] = new MyHeader1("절수");
            grid1[1, 25] = new MyHeader1("결");
            grid1[1, 26] = new MyHeader1("인쇄" + "\r\n" + "사이즈");
            
            grid1[1, 27] = new MyHeader1("판형");
            grid1[1, 28] = new MyHeader1("절수");
            grid1[1, 29] = new MyHeader1("결");
            grid1[1, 30] = new MyHeader1("종이" + "\r\n" + "사이즈");
            //
            grid1.Columns[1].Width = 25;
            grid1.Columns[2].Width = 40;
            grid1.Columns[3].Width = 120;
            grid1.Columns[4].Width = 90;
            grid1.Columns[5].Width = 60;
            grid1.Columns[6].Width = 50;
            grid1.Columns[7].Width = 50;
            grid1.Columns[8].Width = 50;
            grid1.Columns[9].Width = 40;
            grid1.Columns[10].Width = 50;
            grid1.Columns[11].Width = 50;
            grid1.Columns[12].Width = 50;
            grid1.Columns[13].Width = 50;
            grid1.Columns[14].Width = 90;
            grid1.Columns[15].Width = 50;
            grid1.Columns[16].Width = 50;
            grid1.Columns[17].Width = 50;
            grid1.Columns[18].Width = 50;
            grid1.Columns[19].Width = 50;
            grid1.Columns[20].Width = 50;
            grid1.Columns[21].Width = 50;
            grid1.Columns[22].Width = 50;
            grid1.Columns[23].Width = 50;
            grid1.Columns[24].Width = 50;
            grid1.Columns[25].Width = 50;
            grid1.Columns[26].Width = 60;
            grid1.Columns[27].Width = 50;
            grid1.Columns[28].Width = 50;
            grid1.Columns[29].Width = 50;
            grid1.Columns[30].Width = 60;
            grid1.Columns[31].Width = 120;
            grid1.Columns[32].Width = 30;
            grid1.Columns[33].Width = 120;
            grid1.Columns[34].Width = 90;
            grid1.Columns[35].Width = 90;
            grid1.Columns[36].Width = 90;
            //
            DataTable temp = new DataTable();
            MySqlConnection DBConn;
            DBConn = new MySqlConnection(Config.DB_con1);
            DBConn.Open();
            MySqlDataAdapter returnVal = new MySqlDataAdapter(cQuery, DBConn);
            returnVal.Fill(temp);
            returnVal.Dispose();
            //
            SourceGridControl GH = new SourceGridControl();
            //
            SourceGrid.Cells.Editors.ComboBox combobox1 = new SourceGrid.Cells.Editors.ComboBox(typeof(string));
            combobox1.StandardValues = new string[] { "폭", "장" };
            combobox1.EditableMode = SourceGrid.EditableMode.Focus | SourceGrid.EditableMode.SingleClick | SourceGrid.EditableMode.AnyKey;
            //
            string[] prn_item = new string[s_prn_mode.Rows.Count];
            for (int i = 0; i < s_prn_mode.Rows.Count; i++)
                prn_item[i] = s_prn_mode.Rows[i][1].ToString();
            SourceGrid.Cells.Editors.ComboBox combobox2 = new SourceGrid.Cells.Editors.ComboBox(typeof(string));
            combobox2.StandardValues = prn_item;
            combobox2.EditableMode = SourceGrid.EditableMode.Focus | SourceGrid.EditableMode.SingleClick | SourceGrid.EditableMode.AnyKey;
            //
            this.Cursor = Cursors.Default;
            ProgressBar PbBar = new ProgressBar();
            PbBar.Style = ProgressBarStyle.Continuous;
            PbBar.Value = 0;
            PbBar.Minimum = 0;
            PbBar.Maximum = temp.Rows.Count;
            PbBar.Location = new Point(20, 15);
            PbBar.Size = new Size(310, 20);
            //
            Form pbForm = new Form();
            pbForm.ClientSize = new System.Drawing.Size(350, 50);
            pbForm.Controls.Add(PbBar);
            pbForm.Text = "■ 자료 생성중.......";
            pbForm.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            pbForm.Show();
            PbBar.Value = 1;
            //
            int m = 0;
            for (int n = 0; n < temp.Rows.Count; n++)
            {
                m = n + 2;
                grid1.Rows.Insert(m);
                grid1.Rows[m].Height = 22;
                //
                grid1[m, 0] = new SourceGrid.Cells.Cell(temp.Rows[n]["row_id"], typeof(string));
                grid1[m, 1] = new SourceGrid.Cells.CheckBox(null, false);

                grid1[m, 2] = new SourceGrid.Cells.Cell((m - 1).ToString(), typeof(string));  //no
                grid1[m, 2].View = cc.center_cell;
                grid1[m, 2].Editor = cc.disable_cell;

                grid1[m, 3] = new SourceGrid.Cells.Cell(temp.Rows[n]["sangho"], typeof(string));
                grid1[m, 3].View = cc.center_cell;
                grid1[m, 3].Editor = cc.disable_cell;

                grid1[m, 4] = new SourceGrid.Cells.Cell(temp.Rows[n]["area"].ToString(), typeof(string));
                grid1[m, 4].View = cc.center_cell;
                grid1[m, 4].Editor = cc.disable_cell;

                grid1[m, 5] = new SourceGrid.Cells.Cell(temp.Rows[n]["i_no"].ToString(), typeof(int));
                grid1[m, 5].View = center_cell;

                grid1[m, 6] = new SourceGrid.Cells.Cell(Convert.ToDecimal(GH.decimaldel(temp.Rows[n]["jang"].ToString())), typeof(string));
                grid1[m, 6].View = center_cell;
                grid1[m, 6].Editor = decimal_Editor;

                grid1[m, 7] = new SourceGrid.Cells.Cell(Convert.ToDecimal(GH.decimaldel(temp.Rows[n]["pok"].ToString())), typeof(string));
                grid1[m, 7].View = center_cell;
                grid1[m, 7].Editor = decimal_Editor;

                grid1[m, 8] = new SourceGrid.Cells.Cell(Convert.ToDecimal(GH.decimaldel(temp.Rows[n]["go"].ToString())), typeof(string));
                grid1[m, 8].View = center_cell;
                grid1[m, 8].Editor = decimal_Editor;

                grid1[m, 9] = new SourceGrid.Cells.Cell(Convert.ToInt32(temp.Rows[n]["top"]), typeof(int));
                grid1[m, 9].View = center_cell;
                grid1[m, 9].Editor = Int_Editor;

                grid1[m, 10] = new SourceGrid.Cells.Cell(Convert.ToInt32(temp.Rows[n]["bottom"]), typeof(int));
                grid1[m, 10].View = center_cell;
                grid1[m, 10].Editor = Int_Editor;

                grid1[m, 11] = new SourceGrid.Cells.Cell(Convert.ToInt32(temp.Rows[n]["attach"]), typeof(int));
                grid1[m, 11].View = center_cell;
                grid1[m, 11].Editor = Int_Editor;

                grid1[m, 12] = new SourceGrid.Cells.Cell(temp.Rows[n]["attach_position"].ToString(), combobox1);
                grid1[m, 12].View = SourceGrid.Cells.Views.ComboBox.Default;

                grid1[m, 13] = new SourceGrid.Cells.Cell(Convert.ToDecimal(GH.decimaldel(temp.Rows[n]["dot"].ToString())), typeof(string));
                grid1[m, 13].View = center_cell;
                grid1[m, 13].Editor = decimal_Editor;

                string prn_mode = "";
                if (!string.IsNullOrEmpty(temp.Rows[n]["prn_mode"].ToString()))
                {
                    DataRow[] dr = s_prn_mode.Select("code1='" + temp.Rows[n]["prn_mode"].ToString().Trim() + "'");
                    if (dr.Length != 0)
                        prn_mode = dr[0]["hang"].ToString(); //특성-2
                }
                grid1[m, 14] = new SourceGrid.Cells.Cell(prn_mode, combobox2);
                grid1[m, 14].View = SourceGrid.Cells.Views.ComboBox.Default;

                grid1[m, 15] = new SourceGrid.Cells.Cell(temp.Rows[n]["tq_wide"].ToString(), typeof(int));
                grid1[m, 15].View = cc.int_cell;

                grid1[m, 16] = new SourceGrid.Cells.Cell(temp.Rows[n]["tq_doji"].ToString(), typeof(int));
                grid1[m, 16].View = cc.int_cell;

                grid1[m, 17] = new SourceGrid.Cells.Cell(temp.Rows[n]["tq_code"].ToString(), typeof(int));
                grid1[m, 17].View = cc.int_cell;

                grid1[m, 18] = new SourceGrid.Cells.Cell(temp.Rows[n]["cal_code"].ToString(), typeof(int));
                grid1[m, 18].View = cc.int_cell;

                grid1[m, 19] = new SourceGrid.Cells.Cell(temp.Rows[n]["error_code"].ToString(), typeof(int));
                grid1[m, 19].View = cc.int_cell;

                grid1[m, 20] = new SourceGrid.Cells.Cell(temp.Rows[n]["tq_pan"].ToString(), typeof(string));
                grid1[m, 20].View = cc.center_cell;

                grid1[m, 21] = new SourceGrid.Cells.Cell(temp.Rows[n]["tq_julsu"].ToString(), typeof(int));
                grid1[m, 21].View = cc.int_cell;

                grid1[m, 22] = new SourceGrid.Cells.Cell(temp.Rows[n]["tq_gul"].ToString(), typeof(string));
                grid1[m, 22].View = cc.center_cell;

                grid1[m, 23] = new SourceGrid.Cells.Cell(temp.Rows[n]["prn_pan"].ToString(), typeof(string));
                grid1[m, 23].View = cc.center_cell;

                grid1[m, 24] = new SourceGrid.Cells.Cell(temp.Rows[n]["prn_julsu"].ToString(), typeof(int));
                grid1[m, 24].View = cc.int_cell;

                grid1[m, 25] = new SourceGrid.Cells.Cell(temp.Rows[n]["prn_gul"].ToString(), typeof(string));
                grid1[m, 25].View = cc.center_cell;

                grid1[m, 26] = new SourceGrid.Cells.Cell(temp.Rows[n]["prn_size"].ToString(), typeof(string));
                grid1[m, 26].View = cc.center_cell;

                grid1[m, 27] = new SourceGrid.Cells.Cell(temp.Rows[n]["paper_pan"].ToString(), typeof(string));
                grid1[m, 27].View = cc.center_cell;

                grid1[m, 28] = new SourceGrid.Cells.Cell(temp.Rows[n]["paper_julsu"].ToString(), typeof(int));
                grid1[m, 28].View = cc.int_cell;

                grid1[m, 29] = new SourceGrid.Cells.Cell(temp.Rows[n]["paper_gul"].ToString(), typeof(string));
                grid1[m, 29].View = cc.center_cell;

                grid1[m, 30] = new SourceGrid.Cells.Cell(temp.Rows[n]["paper_size"].ToString(), typeof(string));
                grid1[m, 30].View = cc.center_cell;

                string file_name = temp.Rows[n]["m_file"].ToString();
                grid1[m, 31] = new SourceGrid.Cells.Cell(file_name, typeof(string));
                grid1[m, 31].View = cc.center_cellb;
                grid1[m, 31].Editor = cc.disable_cell;

                if (file_name != "")
                {
                    grid1[m, 32] = new SourceGrid.Cells.Cell("");
                    grid1[m, 32].Image = Properties.Resources.up1;
                }
                else
                {
                    grid1[m, 32] = new SourceGrid.Cells.Button("");
                    grid1[m, 32].Editor = cc.disable_cell;
                }

                grid1[m, 33] = new SourceGrid.Cells.Cell(temp.Rows[n]["bigo_2"].ToString(), typeof(string));
                grid1[m, 33].View = cc.left_cell;

                grid1[m, 34] = new SourceGrid.Cells.Cell(temp.Rows[n]["bigo_1"].ToString(), typeof(string));
                grid1[m, 34].View = cc.center_cell;
                grid1[m, 34].Editor = cc.disable_cell;

                grid1[m, 35] = new SourceGrid.Cells.Cell(temp.Rows[n]["sort"].ToString(), typeof(string));
                grid1[m, 36] = new SourceGrid.Cells.Cell(temp.Rows[n]["server_file_name"].ToString(), typeof(string));
                //
                PbBar.Value = n + 1;
            }
            DBConn.Close();
            pbForm.Close();  //progress bar Form
        }

        private void bAdd_Click(object sender, EventArgs e)
        {
            cell_d cc = new cell_d();
            MySqlConnection DBConn;
            DBConn = new MySqlConnection(Config.DB_con1);
            DBConn.Open();
            string Query = "select max(sort) from " + DB_TableName_mok;
            var cmd = new MySqlCommand(Query, DBConn);
            var myRead = cmd.ExecuteReader();
            myRead.Read();
            string sort_temp = myRead["max(sort)"].ToString();
            myRead.Close();
            DBConn.Close();
            //
            int max_sort = (Convert.ToInt32(sort_temp) + 1);
            Query = "insert into " + DB_TableName_mok + "(sort,hcust_id) values(" + max_sort + ",'365')"; //User.Cli_Row_id 현재는 선언되어 있지않음 
            string add_row_id = ks.DataUpdate(Query);
            //
            SourceGridControl GH = new SourceGridControl();
            SourceGrid.Cells.Editors.ComboBox combobox1 = new SourceGrid.Cells.Editors.ComboBox(typeof(string));
            combobox1.StandardValues = new string[] { "폭", "장" };
            combobox1.EditableMode = SourceGrid.EditableMode.Focus | SourceGrid.EditableMode.SingleClick | SourceGrid.EditableMode.AnyKey;
            //
            string[] prn_item = new string[s_prn_mode.Rows.Count];
            for (int i = 0; i < s_prn_mode.Rows.Count; i++)
                prn_item[i] = s_prn_mode.Rows[i][1].ToString();
            SourceGrid.Cells.Editors.ComboBox combobox2 = new SourceGrid.Cells.Editors.ComboBox(typeof(string));
            combobox2.StandardValues = prn_item;
            combobox2.EditableMode = SourceGrid.EditableMode.Focus | SourceGrid.EditableMode.SingleClick | SourceGrid.EditableMode.AnyKey;
            //
            int m = grid1.RowsCount;
            grid1.Rows.Insert(m);
            grid1.Rows[m].Height = 22;
            //
            grid1[m, 0] = new SourceGrid.Cells.Cell(add_row_id, typeof(string));
            grid1[m, 1] = new SourceGrid.Cells.CheckBox(null, false);

            grid1[m, 2] = new SourceGrid.Cells.Cell(m.ToString(), typeof(string));  //no
            grid1[m, 2].View = cc.center_cell;
            grid1[m, 2].Editor = cc.disable_cell;

            grid1[m, 3] = new SourceGrid.Cells.Cell("", typeof(string));
            grid1[m, 3].View = cc.center_cell;
            grid1[m, 3].Editor = cc.disable_cell;

            grid1[m, 4] = new SourceGrid.Cells.Cell("", typeof(string));
            grid1[m, 4].View = cc.center_cell;
            grid1[m, 4].Editor = cc.disable_cell;

            grid1[m, 5] = new SourceGrid.Cells.Cell("", typeof(int));
            grid1[m, 5].View = center_cell;

            grid1[m, 6] = new SourceGrid.Cells.Cell("", typeof(string));
            grid1[m, 6].View = center_cell;
            grid1[m, 6].Editor = Int_Editor;

            grid1[m, 7] = new SourceGrid.Cells.Cell("", typeof(string));
            grid1[m, 7].View = center_cell;
            grid1[m, 7].Editor = Int_Editor;

            grid1[m, 8] = new SourceGrid.Cells.Cell("", typeof(string));
            grid1[m, 8].View = center_cell;
            grid1[m, 8].Editor = Int_Editor;

            grid1[m, 9] = new SourceGrid.Cells.Cell("", typeof(int));
            grid1[m, 9].View = center_cell;
            grid1[m, 9].Editor = Int_Editor;

            grid1[m, 10] = new SourceGrid.Cells.Cell("", typeof(int));
            grid1[m, 10].View = center_cell;
            grid1[m, 10].Editor = Int_Editor;

            grid1[m, 11] = new SourceGrid.Cells.Cell("", typeof(int));
            grid1[m, 11].View = center_cell;
            grid1[m, 11].Editor = Int_Editor;

            grid1[m, 12] = new SourceGrid.Cells.Cell("", combobox1);
            grid1[m, 12].View = SourceGrid.Cells.Views.ComboBox.Default;

            grid1[m, 13] = new SourceGrid.Cells.Cell("", typeof(string));
            grid1[m, 13].View = center_cell;

            grid1[m, 14] = new SourceGrid.Cells.Cell("", combobox2);
            grid1[m, 14].View = SourceGrid.Cells.Views.ComboBox.Default;

            grid1[m, 15] = new SourceGrid.Cells.Cell("", typeof(int));
            grid1[m, 15].View = cc.int_cell;

            grid1[m, 16] = new SourceGrid.Cells.Cell("", typeof(int));
            grid1[m, 16].View = cc.int_cell;

            grid1[m, 17] = new SourceGrid.Cells.Cell("", typeof(int));
            grid1[m, 17].View = cc.int_cell;

            grid1[m, 18] = new SourceGrid.Cells.Cell("", typeof(int));
            grid1[m, 18].View = cc.int_cell;

            grid1[m, 19] = new SourceGrid.Cells.Cell("", typeof(int));
            grid1[m, 19].View = cc.int_cell;

            grid1[m, 20] = new SourceGrid.Cells.Cell("", typeof(string));
            grid1[m, 20].View = cc.center_cell;

            grid1[m, 21] = new SourceGrid.Cells.Cell("", typeof(int));
            grid1[m, 21].View = cc.int_cell;

            grid1[m, 22] = new SourceGrid.Cells.Cell("", typeof(string));
            grid1[m, 22].View = cc.center_cell;

            grid1[m, 23] = new SourceGrid.Cells.Cell("", typeof(string));
            grid1[m, 23].View = cc.center_cell;

            grid1[m, 24] = new SourceGrid.Cells.Cell("", typeof(int));
            grid1[m, 24].View = cc.int_cell;

            grid1[m, 25] = new SourceGrid.Cells.Cell("", typeof(string));
            grid1[m, 25].View = cc.center_cell;

            grid1[m, 26] = new SourceGrid.Cells.Cell("", typeof(string));
            grid1[m, 26].View = cc.center_cell;

            grid1[m, 27] = new SourceGrid.Cells.Cell("", typeof(string));
            grid1[m, 27].View = cc.center_cell;

            grid1[m, 28] = new SourceGrid.Cells.Cell("", typeof(int));
            grid1[m, 28].View = cc.int_cell;

            grid1[m, 29] = new SourceGrid.Cells.Cell("", typeof(string));
            grid1[m, 29].View = cc.center_cell;

            grid1[m, 30] = new SourceGrid.Cells.Cell("", typeof(string));
            grid1[m, 30].View = cc.center_cell;

            grid1[m, 31] = new SourceGrid.Cells.Cell("", typeof(string));
            grid1[m, 31].View = cc.center_cellb;
            grid1[m, 31].Editor = cc.disable_cell;

            grid1[m, 32] = new SourceGrid.Cells.Button("");
            grid1[m, 32].Editor = cc.disable_cell;

            grid1[m, 33] = new SourceGrid.Cells.Cell("", typeof(string));
            grid1[m, 33].View = cc.center_cell;

            grid1[m, 34] = new SourceGrid.Cells.Cell("", typeof(string));
            grid1[m, 34].View = cc.center_cell;
            grid1[m, 34].Editor = cc.disable_cell;

            grid1[m, 35] = new SourceGrid.Cells.Cell(max_sort, typeof(string));
            grid1[m, 36] = new SourceGrid.Cells.Cell("", typeof(string));

            var position = new SourceGrid.Position(grid1.RowsCount-1, 1);
            grid1.Selection.Focus(position, true);
        }

        private void bCopy_Click(object sender, EventArgs e)
        {
            int m = grid1.RowsCount;
            SourceGridControl GH = new SourceGridControl();
            center_cell = new SourceGrid.Cells.Views.Cell();
            center_cell.TextAlignment = DevAge.Drawing.ContentAlignment.MiddleCenter;
            Int_cell = new SourceGrid.Cells.Views.Cell();
            Int_cell.TextAlignment = DevAge.Drawing.ContentAlignment.MiddleRight;
            decimal_cell = new SourceGrid.Cells.Views.Cell();
            decimal_cell.TextAlignment = DevAge.Drawing.ContentAlignment.MiddleRight;
            Int_Editor = new SourceGrid.Cells.Editors.TextBox(typeof(int));
            decimal_Editor = new SourceGrid.Cells.Editors.TextBox(typeof(decimal));
            //
            SourceGrid.Cells.Editors.ComboBox combobox1 = new SourceGrid.Cells.Editors.ComboBox(typeof(string));
            combobox1.StandardValues = new string[] { "폭", "장" };
            combobox1.EditableMode = SourceGrid.EditableMode.Focus | SourceGrid.EditableMode.SingleClick | SourceGrid.EditableMode.AnyKey;
            //
            string[] prn_item = new string[s_prn_mode.Rows.Count];
            for (int i = 0; i < s_prn_mode.Rows.Count; i++)
                prn_item[i] = s_prn_mode.Rows[i][1].ToString();
            SourceGrid.Cells.Editors.ComboBox combobox2 = new SourceGrid.Cells.Editors.ComboBox(typeof(string));
            combobox2.StandardValues = prn_item;
            combobox2.EditableMode = SourceGrid.EditableMode.Focus | SourceGrid.EditableMode.SingleClick | SourceGrid.EditableMode.AnyKey;
            //
            for (int i = 0; i < grid1.RowsCount; i++)
            {
                cell_d cc = new cell_d();
                if (grid1[i, 1].ToString() == "True")
                {
                    string row_id = GridHandle.OneDataCopy(DB_TableName_mok, grid1[i, 0].ToString());
                    MySqlConnection DBConn1;
                    DBConn1 = new MySqlConnection(Config.DB_con1);
                    DBConn1.Open();
                    string Query = "select max(sort) from " + DB_TableName_mok;
                    var cmd1 = new MySqlCommand(Query, DBConn1);
                    var myRead1 = cmd1.ExecuteReader();
                    myRead1.Read();
                    string sort_temp = myRead1["max(sort)"].ToString();
                    myRead1.Close();
                    DBConn1.Close();
                    int max_sort = (Convert.ToInt32(sort_temp) + 1);

                    Query = "update " + DB_TableName_mok + " set sort = " + max_sort + " where row_id = " + row_id;
                    ks.DataUpdate(Query);

                    MySqlConnection DBConn;
                    DBConn = new MySqlConnection(Config.DB_con1);
                    DBConn.Open();
                    Query = "select a.*, b.sangho as sangho, b.area as area from " + DB_TableName_mok + " as a ";
                    Query += "left outer join " + DB_TableName_cust + " as b on a.hcust_id = b.row_id ";
                    Query += " where a.row_id = '" + row_id + "' order by a.jang ";
                    var cmd = new MySqlCommand(Query, DBConn);
                    var myRead = cmd.ExecuteReader();
                    myRead.Read();
                    grid1.Rows.Insert(m);
                    grid1.Rows[m].Height = 22;
                    //
                    grid1[m, 0] = new SourceGrid.Cells.Cell(myRead["row_id"], typeof(string));
                    grid1[m, 1] = new SourceGrid.Cells.CheckBox(null, false);

                    grid1[m, 2] = new SourceGrid.Cells.Cell(m.ToString(), typeof(string));  //no
                    grid1[m, 2].View = cc.center_cell;
                    grid1[m, 2].Editor = cc.disable_cell;

                    grid1[m, 3] = new SourceGrid.Cells.Cell(myRead["sangho"], typeof(string));
                    grid1[m, 3].View = cc.center_cell;
                    grid1[m, 3].Editor = cc.disable_cell;

                    grid1[m, 4] = new SourceGrid.Cells.Cell(myRead["area"].ToString(), typeof(string));
                    grid1[m, 4].View = cc.center_cell;
                    grid1[m, 4].Editor = cc.disable_cell;

                    grid1[m, 5] = new SourceGrid.Cells.Cell(myRead["i_no"].ToString(), typeof(int));
                    grid1[m, 5].View = center_cell;

                    grid1[m, 6] = new SourceGrid.Cells.Cell(Convert.ToDecimal(GH.decimaldel(myRead["jang"].ToString())), typeof(string));
                    grid1[m, 6].View = center_cell;
                    grid1[m, 6].Editor = decimal_Editor;

                    grid1[m, 7] = new SourceGrid.Cells.Cell(Convert.ToDecimal(GH.decimaldel(myRead["pok"].ToString())), typeof(string));
                    grid1[m, 7].View = center_cell;
                    grid1[m, 7].Editor = decimal_Editor;

                    grid1[m, 8] = new SourceGrid.Cells.Cell(Convert.ToDecimal(GH.decimaldel(myRead["go"].ToString())), typeof(string));
                    grid1[m, 8].View = center_cell;
                    grid1[m, 8].Editor = decimal_Editor;

                    grid1[m, 9] = new SourceGrid.Cells.Cell(Convert.ToInt32(myRead["top"]), typeof(int));
                    grid1[m, 9].View = center_cell;
                    grid1[m, 9].Editor = Int_Editor;

                    grid1[m, 10] = new SourceGrid.Cells.Cell(Convert.ToInt32(myRead["bottom"]), typeof(int));
                    grid1[m, 10].View = center_cell;
                    grid1[m, 10].Editor = Int_Editor;

                    grid1[m, 11] = new SourceGrid.Cells.Cell(Convert.ToInt32(myRead["attach"]), typeof(int));
                    grid1[m, 11].View = center_cell;
                    grid1[m, 11].Editor = Int_Editor;

                    grid1[m, 12] = new SourceGrid.Cells.Cell(myRead["attach_position"].ToString(), combobox1);
                    grid1[m, 12].View = SourceGrid.Cells.Views.ComboBox.Default;

                    grid1[m, 13] = new SourceGrid.Cells.Cell(Convert.ToDecimal(GH.decimaldel(myRead["dot"].ToString())), typeof(string));
                    grid1[m, 13].View = center_cell;
                    grid1[m, 13].Editor = decimal_Editor;

                    string prn_mode = "";
                    if (!string.IsNullOrEmpty(myRead["prn_mode"].ToString()))
                    {
                        DataRow[] dr = s_prn_mode.Select("code1='" + myRead["prn_mode"].ToString().Trim() + "'");
                        if (dr.Length != 0)
                            prn_mode = dr[0]["hang"].ToString(); //특성-2
                    }
                    grid1[m, 14] = new SourceGrid.Cells.Cell(prn_mode, combobox2);
                    grid1[m, 14].View = SourceGrid.Cells.Views.ComboBox.Default;

                    grid1[m, 15] = new SourceGrid.Cells.Cell(myRead["tq_wide"].ToString(), typeof(int));
                    grid1[m, 15].View = cc.int_cell;

                    grid1[m, 16] = new SourceGrid.Cells.Cell(myRead["tq_doji"].ToString(), typeof(int));
                    grid1[m, 16].View = cc.int_cell;

                    grid1[m, 17] = new SourceGrid.Cells.Cell(myRead["tq_code"].ToString(), typeof(int));
                    grid1[m, 17].View = cc.int_cell;

                    grid1[m, 18] = new SourceGrid.Cells.Cell(myRead["cal_code"].ToString(), typeof(int));
                    grid1[m, 18].View = cc.int_cell;

                    grid1[m, 19] = new SourceGrid.Cells.Cell(myRead["error_code"].ToString(), typeof(int));
                    grid1[m, 19].View = cc.int_cell;

                    grid1[m, 20] = new SourceGrid.Cells.Cell(myRead["tq_pan"].ToString(), typeof(string));
                    grid1[m, 20].View = cc.center_cell;

                    grid1[m, 21] = new SourceGrid.Cells.Cell(myRead["tq_julsu"].ToString(), typeof(int));
                    grid1[m, 21].View = cc.int_cell;

                    grid1[m, 22] = new SourceGrid.Cells.Cell(myRead["tq_gul"].ToString(), typeof(string));
                    grid1[m, 22].View = cc.center_cell;

                    grid1[m, 23] = new SourceGrid.Cells.Cell(myRead["prn_pan"].ToString(), typeof(string));
                    grid1[m, 23].View = cc.center_cell;

                    grid1[m, 24] = new SourceGrid.Cells.Cell(myRead["prn_julsu"].ToString(), typeof(int));
                    grid1[m, 24].View = cc.int_cell;

                    grid1[m, 25] = new SourceGrid.Cells.Cell(myRead["prn_gul"].ToString(), typeof(string));
                    grid1[m, 25].View = cc.center_cell;

                    grid1[m, 26] = new SourceGrid.Cells.Cell(myRead["prn_size"].ToString(), typeof(string));
                    grid1[m, 26].View = cc.center_cell;

                    grid1[m, 27] = new SourceGrid.Cells.Cell(myRead["paper_pan"].ToString(), typeof(string));
                    grid1[m, 27].View = cc.center_cell;

                    grid1[m, 28] = new SourceGrid.Cells.Cell(myRead["paper_julsu"].ToString(), typeof(int));
                    grid1[m, 28].View = cc.int_cell;

                    grid1[m, 29] = new SourceGrid.Cells.Cell(myRead["paper_gul"].ToString(), typeof(string));
                    grid1[m, 29].View = cc.center_cell;

                    grid1[m, 30] = new SourceGrid.Cells.Cell(myRead["paper_size"].ToString(), typeof(string));
                    grid1[m, 30].View = cc.center_cell;

                    grid1[m, 31] = new SourceGrid.Cells.Cell("", typeof(string));
                    grid1[m, 31].View = cc.center_cellb;
                    grid1[m, 31].Editor = cc.disable_cell;

                    grid1[m, 32] = new SourceGrid.Cells.Button("");
                    grid1[m, 32].Editor = cc.disable_cell;

                    grid1[m, 33] = new SourceGrid.Cells.Cell(myRead["bigo_2"].ToString(), typeof(string));
                    grid1[m, 33].View = cc.left_cell;

                    grid1[m, 34] = new SourceGrid.Cells.Cell(myRead["bigo_1"].ToString(), typeof(string));
                    grid1[m, 34].View = cc.center_cell;
                    grid1[m, 34].Editor = cc.disable_cell;

                    grid1[m, 35] = new SourceGrid.Cells.Cell(myRead["sort"].ToString(), typeof(string));
                    grid1[m, 36] = new SourceGrid.Cells.Cell("", typeof(string));
                    //
                    m++;
                    myRead.Close();
                    DBConn.Close();
                    grid1.Refresh();
                }
            }
            var position = new SourceGrid.Position(m - 1, 1);
            grid1.Selection.Focus(position, true);
        }

        private void bDel_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("삭제하시겠습니까?", "메세지창", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                for (int i = 0; i < grid1.RowsCount; i++)
                {
                    if (grid1[i, 1].Value.Equals(true) && grid1[i, server_file_col].ToString() != "")
                    {
                        FC.FileDel(grid1[i, server_file_col].ToString(), DB_TableName_mok);
                        string cQuery = "delete from " + DB_TableName_file + " where int_id = " + grid1[i, 0].ToString() + " and db_nm = '" + DB_TableName_mok + "' ";
                        GridHandle.DataUpdate(cQuery);
                    }
                }
                GridHandle.ChkDataDelete(DB_TableName_mok, 1, 0, 1);
            }
        }

        private void Form_101_ClientSizeChanged(object sender, EventArgs e)
        {
            this.bUp.Size = new System.Drawing.Size(31, (grid1.Size.Height / 2));
            this.bUp.Location = new System.Drawing.Point(grid1.Location.X-37,grid1.Location.Y);

            int temp = bUp.Size.Height + bUp.Location.Y;
            this.bDown.Location = new System.Drawing.Point(grid1.Location.X - 37, bUp.Size.Height + bUp.Location.Y);
            this.bDown.Size = new System.Drawing.Size(31, (grid1.Size.Height / 2));

        }

        private void bClear_Click(object sender, EventArgs e)
        {
            cbSangho.Text = "";
            cbArea.Text = "";
            tbJang.Text = "";
            tbPok.Text = "";
            tbGo.Text = "";
            tbPjulsu.Text = "";
            tbPan.Text = "";
            cbPmethod.Text = "";
            cbPguk.Text = "";
            tbGagam.Text = "";
        }

        private void bSearch_Click(object sender, EventArgs e)
        {
            string search = "";
            if(cbSangho.Text !="")
                search += " and sangho = '"+cbSangho.Text+"'";
            if (cbArea.Text != "")
                search += " and area = '" + cbArea.Text + "'";
            if (cbPmethod.Text != "")
            {
                DataRow[] dr = s_prn_mode.Select("hang='" + cbPmethod.Text.Trim() + "'");
                if (dr.Length != 0)
                    search += " and prn_mode = '" + dr[0]["code1"].ToString() + "'";
            }
            if (cbPguk.Text != "")
                search += " and p_guk = '" + cbPguk.Text + "'";
            if (tbPjulsu.Text != "")
                search += " and p_julsu = '" + tbPjulsu.Text + "'";
            if (tbPan.Text != "")
                search += " and pan = '" + tbPan.Text + "'";
            int gagam_temp = 0;
            if (tbGagam.Text != "")
            {
                if (tbJang.Text != "")
                    search += " and jang >= " + (Convert.ToInt32(tbJang.Text) - Convert.ToInt32(tbGagam.Text)) + " and jang <= " + (Convert.ToInt32(tbJang.Text) + Convert.ToInt32(tbGagam.Text)) + "";
                if (tbPok.Text != "")
                    search += " and pok >= " + (Convert.ToInt32(tbPok.Text) - Convert.ToInt32(tbGagam.Text)) + " and pok <= " + (Convert.ToInt32(tbPok.Text) + Convert.ToInt32(tbGagam.Text)) + "";
                if (tbGo.Text != "")
                    search += " and go >= " + (Convert.ToInt32(tbGo.Text) - Convert.ToInt32(tbGagam.Text)) + " and go <= " + (Convert.ToInt32(tbGo.Text) + Convert.ToInt32(tbGagam.Text)) + "";
            }
            else
            {
                if (tbJang.Text != "")
                    search += " and jang = " + tbJang.Text;
                if (tbPok.Text != "")
                    search += " and pok = " + tbPok.Text;
                if (tbGo.Text != "")
                    search += " and go = " + tbGo.Text;
            }
            cQuery = "select a.*, b.sangho as sangho, b.area as area, c.user_file as m_file, c.server_file as server_file_name from " + DB_TableName_mok + " as a ";
            cQuery += "left outer join " + DB_TableName_cust + " as b on a.hcust_id = b.row_id ";
            cQuery += "left outer join " + DB_TableName_file + " as c on a.row_id = c.int_id and db_nm = '" + DB_TableName_mok + "' ";
            cQuery += "where a.row_id is not null " + search;
            //cQuery += "where a.row_id < 100 " + search;
            cQuery += " order by a.sort";
            //            
            grid1_view(cQuery);
        }

        private void bUp_Click(object sender, EventArgs e)
        {
            GridHandle.ChkMoveUp(1, 1, 0, 21, "sort", 2, DB_TableName_mok);
        }

        private void bDown_Click(object sender, EventArgs e)
        {
            GridHandle.ChkMoveDown(1, 1, 0, 21, "sort", 2, DB_TableName_mok);
        }

        private void grid1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            cell_d cc = new cell_d();
            int pos = grid1.Selection.ActivePosition.Column;
            int row = grid1.Selection.ActivePosition.Row;

            if (row == -1)
                return;
            string row_no = grid1[row, 0].ToString().Trim(); //row_id 
            string Query = "";
            string FilePath = DB_TableName_mok + "\\" + grid1[row, server_file_col].ToString().Trim();  //22번이 file 명.
            string User_FileNm = grid1[row, user_file_col].ToString().Trim();  //16번이 사용자가 보는file 명.
            string aQuery = "select * from " + DB_TableName_cust + " where yubjong like '%1501%' and yubjong like '%1517%' and yubjong like '%1518%'";
            if(pos == 3)
            {
                Form_404a Frm = new Form_404a(e.X, e.Y, row_no, aQuery, DB_TableName_mok);
                Frm.ShowDialog();

                Query = "select b.sangho as sangho, b.area as area from " + DB_TableName_mok + " as a ";
                Query += "left outer join " + DB_TableName_cust + " as b on a.hcust_id = b.row_id ";
                Query += "where a.row_id = " + row_no;

                var DBConn = new MySqlConnection(Config.DB_con1);
                DBConn.Open();
                var cmd = new MySqlCommand(Query, DBConn);

                var myRead = cmd.ExecuteReader();
                myRead.Read();

                grid1[row, 3] = new SourceGrid.Cells.Cell(myRead["sangho"], typeof(string));
                grid1[row, 3].View = cc.center_cell;
                grid1[row, 3].Editor = cc.disable_cell;

                grid1[row, 4] = new SourceGrid.Cells.Cell(myRead["area"], typeof(string));
                grid1[row, 4].View = cc.center_cell;
                grid1[row, 4].Editor = cc.disable_cell;

                myRead.Close();
                DBConn.Close();

                grid1.Refresh();
            }


            if (grid1[row, user_file_col].ToString() != "")
            {
                if (pos == user_file_col)
                {
                    SaveFileDialog sfd = new SaveFileDialog();
                    sfd.Title = "Save File";
                    sfd.FileName = User_FileNm;
                    sfd.Filter = "ALL File(*.*)|*.*";
                    sfd.InitialDirectory = "C:\\";
                    sfd.RestoreDirectory = true;

                    if (sfd.ShowDialog() == DialogResult.OK)
                    {
                        OhFTP Ftp = new OhFTP(Config.Ftp_ip2, Config.Ftp_id2, Config.Ftp_pw2);
                        Ftp.DownLoadFile1(@sfd.FileName, FilePath);
                        if (MessageBox.Show("내려받기 완료. file을 실행시키겠습니까?", "파일", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                            Process.Start(sfd.FileName);
                    }
                }
                if (pos == 32)
                {
                    if (MessageBox.Show("기존 파일을 삭제하고 다시 올리시겠습니까?", "메세지창", MessageBoxButtons.YesNo) == DialogResult.Yes)
                    {
                        OpenFileDialog ofd = new OpenFileDialog();// File descriptor
                        if (FC.FileOpenDlg(ofd) == 1)
                            return;
                        string file_path = ofd.FileName;

                        FileInfo file_name = new FileInfo(file_path);

                        string File_Table = DB_TableName_mok.Substring(0, 1) + "_file_total_manage";

                        Query = "select * from " + File_Table + " where db_nm='" + DB_TableName_mok + "' and int_id = " + row_no;

                        var DBConn = new MySqlConnection(Config.DB_con1);
                        DBConn.Open();
                        var cmd = new MySqlCommand(Query, DBConn);

                        var myRead = cmd.ExecuteReader();

                        myRead.Read();
                        FC.FileDel(myRead["server_file"].ToString(), DB_TableName_mok);
                        myRead.Close();
                        DBConn.Close();

                        Query = "delete from " + File_Table + " where db_nm='" + DB_TableName_mok + "' and int_id = " + row_no;
                        ks.DataUpdate(Query);

                        string server_file_name = FC.FileReg(ofd, DB_TableName_mok, "sub_file", row_no, "mok");

                        grid1[row, 31] = new SourceGrid.Cells.Cell(file_name.Name, typeof(string));
                        grid1[row, 31].View = cc.center_cellb;
                        grid1[row, 31].Editor = cc.disable_cell;

                        grid1[row, 32] = new SourceGrid.Cells.Cell("");
                        grid1[row, 32].Image = Properties.Resources.up1;
                        grid1[row, 36] = new SourceGrid.Cells.Cell(server_file_name, typeof(string));
                        grid1.Refresh();
                    }
                }
            }
        }

        private void grid1_MouseClick(object sender, MouseEventArgs e)
        {
            cell_d cc = new cell_d();
            string Query = "";
            int pos = grid1.Selection.ActivePosition.Column;
            int row = grid1.Selection.ActivePosition.Row;
            if (row == -1)
                return;
            string row_no = grid1[row, 0].ToString().Trim(); //row_id 
            
            if (pos == 32)
            {
                if (grid1[row, 30].ToString() == "")
                {
                    OpenFileDialog ofd = new OpenFileDialog();// File descriptor
                    if (FC.FileOpenDlg(ofd) == 1)
                        return;
                    string file_path = ofd.FileName;

                    FileInfo file_name = new FileInfo(file_path);

                    string server_file_name = FC.FileReg(ofd, DB_TableName_mok, "sub_file", row_no, "mok");

                    //Query = "update " + TableName_mok + " set m_file = '" + file_name.Name + "', server_file_name = '"+server_file_name+"' where row_id = " + row_no;
                    //ks.DataUpdate(Query);

                    grid1[row, 31] = new SourceGrid.Cells.Cell(file_name.Name, typeof(string));
                    grid1[row, 31].View = cc.center_cellb;
                    grid1[row, 31].Editor = cc.disable_cell;

                    grid1[row, 32] = new SourceGrid.Cells.Cell("");
                    grid1[row, 32].Image = Properties.Resources.up1;
                    grid1[row, 36] = new SourceGrid.Cells.Cell(server_file_name, typeof(string));
                }
                else
                {
                    return;
                }
                grid1.Refresh();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            mokyoung_excel();
        }


        private void mokyoung_excel()
        {
            this.Cursor = Cursors.WaitCursor;
            string file_path = "";

            file_path = @"c:\temp\mokyoung.xlsx";
            try
            {
                if (File.Exists(file_path))
                    File.Delete(file_path);
            }
            catch
            {
                MessageBox.Show("이미 파일이 열려있습니다.");
                return;
            }

            Excel.Application excelApp = null;
            Excel.Workbook excelBook = null;
            Excel.Worksheet excelWokrsheet = null;

            try
            {
                // Excel 첫번째 워크시트 가져오기                
                excelApp = new Excel.Application();
                excelBook = excelApp.Workbooks.Add();
                excelWokrsheet = excelBook.Worksheets.get_Item(1) as Excel.Worksheet;
                Excel.PageSetup ps = excelWokrsheet.PageSetup;
                excelApp.ActiveWindow.DisplayGridlines = false;
                ps.LeftMargin = 0;
                ps.RightMargin = 0;
                ps.TopMargin = 0.8;
                ps.BottomMargin = 0;
                ps.Orientation = Excel.XlPageOrientation.xlLandscape;

                // 데이타 넣기
                int excel_row = 1;
                excelWokrsheet.get_Range("A" + excel_row.ToString() + ":J" + excel_row.ToString()).Merge();
                excelWokrsheet.Cells[excel_row, 1] = "■ 목형 자료";
                excel_row++;
                int start_row = excel_row;
                excelWokrsheet.Cells[excel_row, 1] = "목형번호";
                excelWokrsheet.Cells[excel_row, 2] = "장";
                excelWokrsheet.Cells[excel_row, 3] = "폭";
                excelWokrsheet.Cells[excel_row, 4] = "고";
                excelWokrsheet.Cells[excel_row, 5] = "상단";
                excelWokrsheet.Cells[excel_row, 6] = "하단";
                excelWokrsheet.Cells[excel_row, 7] = "풀발이";
                excelWokrsheet.Cells[excel_row, 8] = "풀발이위치";
                excelWokrsheet.Cells[excel_row, 9] = "닷찌";
                excelWokrsheet.Cells[excel_row, 10] = "인쇄방법";
                excel_row++;

                //grid1 엑셀변환
                for (int i = 2; i < grid1.RowsCount; i++)
                {
                    excelWokrsheet.Cells[excel_row, 1] = grid1[i, 5].ToString();
                    excelWokrsheet.Cells[excel_row, 2] = grid1[i, 6].ToString();
                    excelWokrsheet.Cells[excel_row, 3] = grid1[i, 7].ToString();
                    excelWokrsheet.Cells[excel_row, 4] = grid1[i, 8].ToString();
                    excelWokrsheet.Cells[excel_row, 5] = grid1[i, 9].ToString();
                    excelWokrsheet.Cells[excel_row, 6] = grid1[i, 10].ToString();
                    excelWokrsheet.Cells[excel_row, 7] = grid1[i, 11].ToString();
                    excelWokrsheet.Cells[excel_row, 8] = grid1[i, 12].ToString();
                    excelWokrsheet.Cells[excel_row, 9] = grid1[i, 13].ToString();
                    excelWokrsheet.Cells[excel_row, 10] = grid1[i, 14].ToString();

                    excel_row++;
                }
                excelWokrsheet.get_Range("1:1").Rows.RowHeight = 24;
                excelWokrsheet.get_Range("A:A").Columns.ColumnWidth = 15;
                excelWokrsheet.get_Range("B:B").Columns.ColumnWidth = 10;
                excelWokrsheet.get_Range("C:C").Columns.ColumnWidth = 10;
                excelWokrsheet.get_Range("D:D").Columns.ColumnWidth = 10;
                excelWokrsheet.get_Range("E:E").Columns.ColumnWidth = 10;
                excelWokrsheet.get_Range("F:F").Columns.ColumnWidth = 10;
                excelWokrsheet.get_Range("G:G").Columns.ColumnWidth = 10;
                excelWokrsheet.get_Range("H:H").Columns.ColumnWidth = 14;
                excelWokrsheet.get_Range("I:I").Columns.ColumnWidth = 10;
                excelWokrsheet.get_Range("J:J").Columns.ColumnWidth = 20;

                excelWokrsheet.get_Range("A" + start_row.ToString() + ":j" + (excel_row - 1).ToString()).HorizontalAlignment = 3;

                Excel.Range All_Range = excelWokrsheet.get_Range("A1", "J" + (excel_row - 1).ToString());
                All_Range.Borders.LineStyle = BorderStyle.FixedSingle;

                // 엑셀파일 저장
                excelBook.SaveAs(file_path, Excel.XlFileFormat.xlWorkbookDefault, Type.Missing, Type.Missing, false, false, Excel.XlSaveAsAccessMode.xlShared, false, false, Type.Missing, Type.Missing, Type.Missing);

                excelBook.Close(true);
                excelApp.Quit();
            }
            finally
            {
                // Clean up
                ReleaseExcelObject(excelWokrsheet);
                ReleaseExcelObject(excelBook);
                ReleaseExcelObject(excelApp);
            }
            this.Cursor = Cursors.Default;
            try
            {
                System.Diagnostics.Process.Start(file_path);
            }
            catch { }
        }

        private static void ReleaseExcelObject(object obj)
        {
            try
            {
                if (obj != null)
                {
                    Marshal.ReleaseComObject(obj);
                    obj = null;
                }
            }
            catch (Exception ex)
            {
                obj = null;
                throw ex;
            }
            finally
            {
                GC.Collect();
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            grid1.Columns[15].Visible = true;
            grid1.Columns[16].Visible = true;
            grid1.Columns[17].Visible = true;
            grid1.Columns[18].Visible = true;
            grid1.Columns[19].Visible = true;
            grid1.Columns[20].Visible = true;
            grid1.Columns[21].Visible = true;
            grid1.Columns[22].Visible = true;
            grid1.Columns[23].Visible = true;
            grid1.Columns[24].Visible = true;
            grid1.Columns[25].Visible = true;
            grid1.Columns[26].Visible = true;
            //
            grid1.Selection.Focus(new SourceGrid.Position(2, 1), true);
            grid1.Selection.Focus(new SourceGrid.Position(2, 15), true);
            grid1.Select();
            grid1.Refresh();

        }

        private void button2_Click(object sender, EventArgs e)
        {
            grid1.Columns[15].Visible = false;
            grid1.Columns[16].Visible = false;
            grid1.Columns[17].Visible = false;
            grid1.Columns[18].Visible = false;
            grid1.Columns[19].Visible = false;
            grid1.Columns[20].Visible = false;
            grid1.Columns[21].Visible = false;
            grid1.Columns[22].Visible = false;
            grid1.Columns[23].Visible = false;
            grid1.Columns[24].Visible = false;
            grid1.Columns[25].Visible = false;
            grid1.Columns[26].Visible = false;
            //
            grid1.Selection.Focus(new SourceGrid.Position(2, 1), true);
            grid1.Selection.Focus(new SourceGrid.Position(2, 27), true);
            grid1.Select();
        }

        //private void button2_Click(object sender, EventArgs e)  //임시버튼
        //{
            //var DBConn = new MySqlConnection(Config.DB_con1);
            //DBConn.Open();
            //string cQuery = "select * from temp order by i_no,row_id";
            //var cmd = new MySqlCommand(cQuery, DBConn);
            //MySqlDataAdapter returnVal1 = new MySqlDataAdapter(cQuery, DBConn);
            //DataTable temp = new DataTable();
            //returnVal1.Fill(temp);
            //returnVal1.Dispose();
            ////
            //cQuery = " delete from C_mokyung;"; 
            //cQuery += " TRUNCATE TABLE C_mokyung;";
            //var cmd1 = new MySqlCommand(cQuery, DBConn);
            //cmd1.ExecuteNonQuery();
            ////
            //string[] d = new string[10];
            //for (int m = 0; m < temp.Rows.Count; m++)
            //{
            //    d[0] = temp.Rows[m]["hcust_id"].ToString();
            //    d[1] = temp.Rows[m]["i_no"].ToString();
            //    d[2] = temp.Rows[m]["item"].ToString();
            //    d[3] = temp.Rows[m]["jang"].ToString();
            //    d[4] = temp.Rows[m]["pok"].ToString();
            //    d[5] = temp.Rows[m]["go"].ToString();
            //    d[6] = temp.Rows[m]["bigo2"].ToString();
            //    d[7] = temp.Rows[m]["bigo3"].ToString();
            //    //
            //    cQuery = " insert into C_mokyung (hcust_id,i_no,item,jang,pok,go,bigo_1,bigo_2)";
            //    cQuery += " values('" + d[0] + "','" + d[1] + "','" + d[2] + "','" + d[3] + "','" + d[4] + "','" + d[5] + "','" + d[6] + "','" + d[7] + "')";
            //    try
            //    {
            //        cmd1 = new MySqlCommand(cQuery, DBConn);
            //        cmd1.ExecuteNonQuery();
            //    }
            //    catch 
            //    {
            //        MessageBox.Show(temp.Rows[m]["row_id"].ToString());
            //    }
            //}
            //MessageBox.Show("완료 하였습니다.");
        //}

    }
}
