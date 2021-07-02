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
    public partial class Form_2151 : Form
    {
        cell_d cc = new cell_d();
        SourceGrid.Cells.Views.Cell center_cell = new SourceGrid.Cells.Views.Cell();
        SourceGrid.Cells.Views.Cell Int_cell = new SourceGrid.Cells.Views.Cell();
        SourceGrid.Cells.Editors.TextBox Int_Editor = new SourceGrid.Cells.Editors.TextBox(typeof(int));
        SourceGridControl GridHandle = new SourceGridControl();
        DataTable hcustomer = new DataTable();
        ksgcontrol ks = new ksgcontrol();

        string TableName_bong = "C_bongto";
        string TableName_cust = "C_hcustomer";
        string mQuery = "";
        public Form_2151()
        {
            InitializeComponent();
        }

        private void Form_2151_Load(object sender, EventArgs e)
        {
            Screen srn = Screen.PrimaryScreen;
            int Xb = this.Width;  //좌,우
            this.Location = new Point((srn.Bounds.Width - Xb) / 2, 1);  //좌/우,위/아래
            ks.ControlInit(Config.DB_con1, null, null, null);

            SourceGrid.Cells.Controllers.CustomEvents val_c1 = new SourceGrid.Cells.Controllers.CustomEvents();
            val_c1.ValueChanged += new EventHandler(ValueChangedEvent1);
            grid1.Controller.AddController(val_c1);

            sync sy = new sync();
            sy.dt(Config.DB_con1, hcustomer, "select sangho, area from " + TableName_cust + " where yubjong like '%1507%' or yubjong like '%2621%'");
            DataRow[] dr = hcustomer.Select();
            if (dr.Length != 0)
            {
                string[] s_temp = new string[dr.Length];

                for (int i = 0; i < dr.Length; i++)
                {
                    s_temp[i] = dr[i]["sangho"].ToString();
                }
                cbSangho.Items.AddRange(s_temp);
            }



            GridHandle.SourceGrideInit(grid1, Config.DB_con1);
            string[] bongto_item = new string[] { "기성봉투", "우찌누끼" };
            GridHandle.InputComboItem(bongto_item);

            string[] bongto_type = new string[] { "대중소", "일반형(편지봉투)", "자켓형", "안내형(카드봉투)" };
            GridHandle.InputComboItem(bongto_type);

            cell();
            mQuery = "select a.*, b.sangho as sangho, b.area as area from " + TableName_bong + " as a ";
            mQuery += "left outer join " + TableName_cust + " as b on a.hcust_id = b.row_id order by a.sort";
            grid1_view(mQuery);
            
        }

       
        private void ValueChangedEvent1(object sender, EventArgs e)
        {
            string Query = "";
            int pos = grid1.Selection.ActivePosition.Column;
            int row = grid1.Selection.ActivePosition.Row;
            string dat = grid1[row, pos].ToString().Trim();
            string row_no = grid1[row, 0].ToString().Trim(); //row_id 

            if (pos == 3)
                Query = "update " + TableName_bong + " set gubun = '" + dat + "' where row_id = " + row_no;
            string type = "";
            if (dat == "대중소")
                type = "A";
            if (dat == "일반형(편지봉투)")
                type = "B";
            if (dat == "자켓형")
                type = "C";
            if (dat == "안내형(카드봉투)")
                type = "D";
            if (pos == 6)
                Query = "update " + TableName_bong + " set bongto_type = '" + type + "' where row_id = " + row_no;
            if (pos == 7)
                Query = "update " + TableName_bong + " set bongto_quality = '" + dat + "' where row_id = " + row_no;
            if (pos == 8)
                Query = "update " + TableName_bong + " set garo = '" + dat + "' where row_id = " + row_no;
            if (pos == 9)
                Query = "update " + TableName_bong + " set sero = '" + dat + "' where row_id = " + row_no;
            if (pos == 10)
                Query = "update " + TableName_bong + " set top = '" + dat + "' where row_id = " + row_no;
            if (pos == 11)
                Query = "update " + TableName_bong + " set bottom = '" + dat + "' where row_id = " + row_no;
            if (pos == 12)
                Query = "update " + TableName_bong + " set b_left = '" + dat + "' where row_id = " + row_no;
            if (pos == 13)
                Query = "update " + TableName_bong + " set b_right = '" + dat + "' where row_id = " + row_no;
            if (pos == 14)
                Query = "update " + TableName_bong + " set danga = '" + dat + "' where row_id = " + row_no;
            if (pos == 15)
                Query = "update " + TableName_bong + " set bigo = '" + dat + "' where row_id = " + row_no;
           
            if(Query !="")
                GridHandle.DataUpdate(Query);
        }

        private void cell()
        {
            center_cell.TextAlignment = DevAge.Drawing.ContentAlignment.MiddleCenter;
            Int_cell.TextAlignment = DevAge.Drawing.ContentAlignment.MiddleRight;
            DevAge.ComponentModel.Converter.NumberTypeConverter int_fomat = new DevAge.ComponentModel.Converter.NumberTypeConverter(typeof(int));
            int_fomat.Format = "###,###,###";
            Int_Editor.TypeConverter = int_fomat;
        }

        private void grid1_view(string cQuery)
        {
            grid1.Rows.Clear();
            grid1.BorderStyle = BorderStyle.FixedSingle;
            grid1.ColumnsCount = 17;
            grid1.FixedRows = 1;
            grid1.Rows.Insert(0);
            grid1.Rows[0].Height = 24;

            grid1[0, 0] = new MyHeader1("row_id");
            grid1.Columns[0].Visible = false;
            grid1[0, 1] = new MyHeader1("√");
            grid1.Columns[1].Visible = true;
            grid1[0, 2] = new MyHeader1("No");
            grid1[0, 3] = new MyHeader1("구분");
            grid1[0, 4] = new MyHeader1("업체명");
            grid1[0, 5] = new MyHeader1("지역");
            grid1[0, 6] = new MyHeader1("봉투종류");
            grid1[0, 7] = new MyHeader1("봉투재질");
            grid1[0, 8] = new MyHeader1("가로");
            grid1[0, 9] = new MyHeader1("세로");
            grid1[0, 10] = new MyHeader1("상");
            grid1[0, 11] = new MyHeader1("하");
            grid1[0, 12] = new MyHeader1("좌");
            grid1[0, 13] = new MyHeader1("우");
            grid1[0, 14] = new MyHeader1("단가");
            grid1[0, 15] = new MyHeader1("비고");
            grid1[0, 16] = new MyHeader1("sort");
            grid1.Columns[16].Visible = false;


            grid1.Columns[1].Width = 25;
            grid1.Columns[2].Width = 40;
            grid1.Columns[3].Width = 100;
            grid1.Columns[4].Width = 150;
            grid1.Columns[5].Width = 100;
            grid1.Columns[6].Width = 150;
            grid1.Columns[7].Width = 200;
            grid1.Columns[8].Width = 60;
            grid1.Columns[9].Width = 60;
            grid1.Columns[10].Width = 60;
            grid1.Columns[11].Width = 60;
            grid1.Columns[12].Width = 60;
            grid1.Columns[13].Width = 60;
            grid1.Columns[14].Width = 80;
            grid1.Columns[15].Width = 100;

            MySqlConnection DBConn;
            DBConn = new MySqlConnection(Config.DB_con1);
            DBConn.Open();

            var cmd = new MySqlCommand(cQuery, DBConn);
            var myRead = cmd.ExecuteReader();

            int m = 1;

            while (myRead.Read())
            {
                grid1.Rows.Insert(m);
                grid1.Rows[m].Height = 22;
                //
                grid1[m, 0] = new SourceGrid.Cells.Cell(myRead["row_id"], typeof(string));
                grid1[m, 1] = new SourceGrid.Cells.CheckBox(null, false);

                grid1[m, 2] = new SourceGrid.Cells.Cell((m).ToString(), typeof(string));  //no
                grid1[m, 2].View = cc.center_cell;
                grid1[m, 2].Editor = cc.disable_cell;

                grid1[m, 3] = new SourceGrid.Cells.Cell(myRead["gubun"], typeof(string));
              //  grid1[m, 3].View = cc.center_cell;
                grid1[m, 3].Editor = GridHandle.CbBox[0];

                grid1[m, 4] = new SourceGrid.Cells.Cell(myRead["sangho"], typeof(string));
               // grid1[m, 4].View = cc.center_cell;
                grid1[m, 4].Editor = cc.disable_cell;

                grid1[m, 5] = new SourceGrid.Cells.Cell(myRead["area"].ToString(), typeof(string));
               // grid1[m, 5].View = center_cell;
                grid1[m, 5].Editor = cc.disable_cell;

                string temp = myRead["bongto_type"].ToString();
                if (temp == "A")
                    temp = "대중소";
                if (temp == "B")
                    temp = "일반형(편지봉투)";
                if (temp == "C")
                    temp = "자켓형";
                if (temp == "D")
                    temp = "안내형(카드봉투)";

                grid1[m, 6] = new SourceGrid.Cells.Cell(temp, typeof(string));
              //  grid1[m, 6].View = center_cell;
                grid1[m, 6].Editor = GridHandle.CbBox[1];


                grid1[m, 7] = new SourceGrid.Cells.Cell(myRead["bongto_quality"].ToString(), typeof(string));
               // grid1[m, 7].View = center_cell;

                grid1[m, 8] = new SourceGrid.Cells.Cell(Convert.ToInt32(myRead["garo"]), typeof(int));
                grid1[m, 8].View = cc.int_cell;

                grid1[m, 9] = new SourceGrid.Cells.Cell(Convert.ToInt32(myRead["sero"]), typeof(int));
                grid1[m, 9].View = cc.int_cell;

                grid1[m, 10] = new SourceGrid.Cells.Cell(Convert.ToInt32(myRead["top"]), typeof(int));
                grid1[m, 10].View = cc.int_cell;

                grid1[m, 11] = new SourceGrid.Cells.Cell(Convert.ToInt32(myRead["bottom"].ToString()), typeof(int));
                grid1[m, 11].View = cc.int_cell;

                grid1[m, 12] = new SourceGrid.Cells.Cell(Convert.ToInt32(myRead["b_left"].ToString()), typeof(int));
                grid1[m, 12].View = cc.int_cell;
                grid1[m, 12].Editor = Int_Editor;

                grid1[m, 13] = new SourceGrid.Cells.Cell(Convert.ToInt32(myRead["b_right"].ToString()), typeof(int));
                grid1[m, 13].View = cc.int_cell;
                grid1[m, 13].Editor = Int_Editor;

                grid1[m, 14] = new SourceGrid.Cells.Cell(Convert.ToInt32(myRead["danga"].ToString()), typeof(int));
                grid1[m, 14].View = cc.int_cell;
                grid1[m, 14].Editor = Int_Editor;

                grid1[m, 15] = new SourceGrid.Cells.Cell(myRead["bigo"].ToString(), typeof(string));
              //  grid1[m, 15].View = center_cell;

                grid1[m, 16] = new SourceGrid.Cells.Cell(myRead["sort"].ToString(), typeof(string));
                m++;
            }
            myRead.Close();
            DBConn.Close();
        }

        private void bClear_Click(object sender, EventArgs e)
        {
            chGi.Checked = false;
            chWoochi.Checked = false;
            cbSangho.Text = "";
            chChung.Checked = false;
            chGuro.Checked = false;
            chSungsu.Checked = false;
            chIlsan.Checked = false;
            chSize.Checked = false;
            chJaket.Checked = false;
            chLetter.Checked = false;
            chCard.Checked = false;
            tbBongto.Text = "";
            tbGaro.Text = "";
            tbSero.Text = "";
            tbGagam.Text = "";
        }

        private void bSearch_Click(object sender, EventArgs e)
        {
            string search_temp = "";

            if (chGi.Checked == true && chWoochi.Checked == true)
                search_temp += " and (gubun = '기성봉투' or gubun = '우찌누끼')";
            else
            {
                if (chGi.Checked == true)
                    search_temp += " and gubun = '기성봉투'";
                if (chWoochi.Checked == true)
                    search_temp += " and gubun = '우찌누끼'";
            }
            if (cbSangho.Text != "")
                search_temp += " and sangho = '" + cbSangho.Text + "'";


            if (chChung.Checked == true)
            {
                search_temp += " and (area like '%충무로%'";

                if (chGuro.Checked == true)
                    search_temp += " or area like '%구로%'";
                if (chSungsu.Checked == true)
                    search_temp += " or area like '%성수%'";
                if (chIlsan.Checked == true)
                    search_temp += " or area like '%일산%'";

                search_temp += ")";
            }
            else if (chChung.Checked == false && chGuro.Checked == true)
            {
                search_temp += " and (area like '%구로%'";
                if (chSungsu.Checked == true)
                    search_temp += " or area like '%성수%'";
                if (chIlsan.Checked == true)
                    search_temp += " or area like '%일산%'";
                search_temp += ")";
            }
            else if (chChung.Checked == false && chGuro.Checked == false && chSungsu.Checked == true)
            {
                search_temp += " and (area like '%성수%'";
                if (chIlsan.Checked == true)
                    search_temp += " or area like '%일산%'";
                search_temp += ")";
            }
            else if (chChung.Checked == false && chGuro.Checked == false && chSungsu.Checked == false && chIlsan.Checked == true)
                search_temp += " and area like '%일산%'";


            if (chSize.Checked == true)
            {
                search_temp += " and (bongto_type = 'A'";
                if (chLetter.Checked == true)
                    search_temp += " or bongto_type = 'B'";
                if (chJaket.Checked == true)
                    search_temp += " or bongto_type = 'C'";
                if (chCard.Checked == true)
                    search_temp += " or bongto_type = 'D'";
                search_temp += ")";
            }

            if (chSize.Checked == false && chLetter.Checked == true)
            {
                search_temp += " and (bongto_type = 'B'";
                if (chJaket.Checked == true)
                    search_temp += " or bongto_type = 'C'";
                if (chCard.Checked == true)
                    search_temp += " or bongto_type = 'D'";
                search_temp += ")";
            }
            if (chSize.Checked == false && chLetter.Checked == false && chJaket.Checked == true)
            {
                search_temp += " and (bongto_type = 'C'";
                if (chCard.Checked == true)
                    search_temp += " or bongto_type = 'D'";
                search_temp += ")";
            }
            if (chSize.Checked == false && chLetter.Checked == false && chJaket.Checked == false && chCard.Checked == true)
                search_temp += " and bongto_type = 'D'";




            if (tbBongto.Text != "")
                search_temp += " and bongto_quality = '" + tbBongto.Text + "'";

            if (tbGagam.Text != "")
            {
                if (tbGaro.Text != "")
                    search_temp += " and garo >= " + (Convert.ToInt32(tbGaro.Text) - Convert.ToInt32(tbGagam.Text)) + " and garo <= " + (Convert.ToInt32(tbGaro.Text) + Convert.ToInt32(tbGagam.Text)) + "";
                if (tbSero.Text != "")
                    search_temp += " and sero >= " + (Convert.ToInt32(tbSero.Text) - Convert.ToInt32(tbGagam.Text)) + " and sero <= " + (Convert.ToInt32(tbSero.Text) + Convert.ToInt32(tbGagam.Text)) + "";
                
            }
            else
            {
                if (tbGaro.Text != "")
                    search_temp += " and garo = " + tbGaro.Text;
                if (tbSero.Text != "")
                    search_temp += " and sero = " + tbSero.Text;
            }

            mQuery = "select  a.*, b.sangho as sangho, b.area as area from " + TableName_bong + " as a ";
            mQuery += "left outer join " + TableName_cust + " as b on a.hcust_id = b.row_id ";
            mQuery += " where a.row_id is not null " + search_temp;
            mQuery += " order by a.sort";
            grid1_view(mQuery);
        }

        private void bAdd_Click(object sender, EventArgs e)
        {
            MySqlConnection DBConn;
            DBConn = new MySqlConnection(Config.DB_con1);
            DBConn.Open();
            string Query = "select max(sort) from " + TableName_bong;
            var cmd = new MySqlCommand(Query, DBConn);
            var myRead = cmd.ExecuteReader();
            myRead.Read();
            string sort_temp = myRead["max(sort)"].ToString();
            myRead.Close();
            DBConn.Close();
            if (sort_temp == "")
                sort_temp = "0";
            int max_sort = (Convert.ToInt32(sort_temp) + 1);

            Query = "insert into " + TableName_bong + "(row_id,sort) values('', " + max_sort + ")";
            string add_row_id = ks.DataUpdate(Query);

            int m = grid1.RowsCount;
            grid1.Rows.Insert(m);
            grid1.Rows[m].Height = 22;

            grid1[m, 0] = new SourceGrid.Cells.Cell(add_row_id, typeof(string));
            grid1[m, 1] = new SourceGrid.Cells.CheckBox(null, false);

            grid1[m, 2] = new SourceGrid.Cells.Cell((m).ToString(), typeof(string));  //no
            grid1[m, 2].View = cc.center_cell;
            grid1[m, 2].Editor = cc.disable_cell;

            grid1[m, 3] = new SourceGrid.Cells.Cell("", typeof(string));
           // grid1[m, 3].View = cc.center_cell;
            grid1[m, 3].Editor = GridHandle.CbBox[0];

            grid1[m, 4] = new SourceGrid.Cells.Cell("", typeof(string));
           // grid1[m, 4].View = cc.center_cell;
            grid1[m, 4].Editor = cc.disable_cell;

            grid1[m, 5] = new SourceGrid.Cells.Cell("", typeof(string));
           // grid1[m, 5].View = center_cell;
            grid1[m, 5].Editor = cc.disable_cell;

            grid1[m, 6] = new SourceGrid.Cells.Cell("", typeof(string));
          //  grid1[m, 6].View = center_cell;
            grid1[m, 6].Editor = GridHandle.CbBox[1];


            grid1[m, 7] = new SourceGrid.Cells.Cell("", typeof(string));
           // grid1[m, 7].View = center_cell;

            grid1[m, 8] = new SourceGrid.Cells.Cell("", typeof(int));
            grid1[m, 8].View = cc.int_cell;

            grid1[m, 9] = new SourceGrid.Cells.Cell("", typeof(int));
            grid1[m, 9].View = cc.int_cell;

            grid1[m, 10] = new SourceGrid.Cells.Cell("", typeof(int));
            grid1[m, 10].View = cc.int_cell;

            grid1[m, 11] = new SourceGrid.Cells.Cell("", typeof(int));
            grid1[m, 11].View = cc.int_cell;

            grid1[m, 12] = new SourceGrid.Cells.Cell("", typeof(int));
            grid1[m, 12].View = cc.int_cell;

            grid1[m, 13] = new SourceGrid.Cells.Cell("", typeof(int));
            grid1[m, 13].View = cc.int_cell;

            grid1[m, 14] = new SourceGrid.Cells.Cell("", typeof(int));
            grid1[m, 14].View = cc.int_cell;
            grid1[m, 14].Editor = Int_Editor;

            grid1[m, 15] = new SourceGrid.Cells.Cell("", typeof(string));
           // grid1[m, 15].View = center_cell;

            grid1[m, 16] = new SourceGrid.Cells.Cell(sort_temp.ToString(), typeof(string));

            var position = new SourceGrid.Position(grid1.RowsCount - 1, 1);
            grid1.Selection.Focus(position, true);
        }

        private void bDel_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("삭제하시겠습니까?", "메세지창", MessageBoxButtons.YesNo) == DialogResult.Yes)
                GridHandle.ChkDataDelete(TableName_bong, 1, 0, 1);
        }

        private void bCopy_Click(object sender, EventArgs e)
        {
            int m = grid1.RowsCount;

            for (int i = 0; i < grid1.RowsCount; i++)
            {
                if (grid1[i, 1].ToString() == "True")
                {
                    string row_id = GridHandle.OneDataCopy(TableName_bong, grid1[i, 0].ToString());
                    MySqlConnection DBConn1;
                    DBConn1 = new MySqlConnection(Config.DB_con1);
                    DBConn1.Open();
                    string Query = "select max(sort) from " + TableName_bong;
                    var cmd1 = new MySqlCommand(Query, DBConn1);
                    var myRead1 = cmd1.ExecuteReader();
                    myRead1.Read();
                    string sort_temp = myRead1["max(sort)"].ToString();
                    myRead1.Close();
                    DBConn1.Close();
                    int max_sort = (Convert.ToInt32(sort_temp) + 1);

                    Query = "update " + TableName_bong + " set sort = " + max_sort + " where row_id = " + row_id;
                    ks.DataUpdate(Query);

                    MySqlConnection DBConn;
                    DBConn = new MySqlConnection(Config.DB_con1);
                    DBConn.Open();


                    Query = "select a.*, b.sangho as sangho, b.area as area from " + TableName_bong + " as a ";
                    Query += "left outer join " + TableName_cust + " as b on a.hcust_id = b.row_id ";
                    Query += " where a.row_id = '" + row_id + "'";


                    var cmd = new MySqlCommand(Query, DBConn);
                    var myRead = cmd.ExecuteReader();
                    myRead.Read();
                    grid1.Rows.Insert(m);
                    grid1.Rows[m].Height = 22;
                    //
                    grid1[m, 0] = new SourceGrid.Cells.Cell(myRead["row_id"], typeof(string));
                    grid1[m, 1] = new SourceGrid.Cells.CheckBox(null, false);

                    grid1[m, 2] = new SourceGrid.Cells.Cell((m).ToString(), typeof(string));  //no
                    grid1[m, 2].View = cc.center_cell;
                    grid1[m, 2].Editor = cc.disable_cell;

                    grid1[m, 3] = new SourceGrid.Cells.Cell(myRead["gubun"], typeof(string));
                   // grid1[m, 3].View = cc.center_cell;
                    grid1[m, 3].Editor = GridHandle.CbBox[0];

                    grid1[m, 4] = new SourceGrid.Cells.Cell(myRead["sangho"], typeof(string));
                  //  grid1[m, 4].View = cc.center_cell;
                    grid1[m, 4].Editor = cc.disable_cell;

                    grid1[m, 5] = new SourceGrid.Cells.Cell(myRead["area"].ToString(), typeof(string));
                   // grid1[m, 5].View = center_cell;
                    grid1[m, 5].Editor = cc.disable_cell;

                    string temp = myRead["bongto_type"].ToString();
                    if(temp == "A")
                        temp = "대중소";
                    if(temp == "B")
                        temp = "일반형(편지봉투)";
                    if(temp == "C")
                        temp = "자켓형";
                    if(temp == "D")
                        temp = "안내형(카드봉투)";

                    grid1[m, 6] = new SourceGrid.Cells.Cell(temp, typeof(string));
                   // grid1[m, 6].View = center_cell;
                    grid1[m, 6].Editor = GridHandle.CbBox[1];


                    grid1[m, 7] = new SourceGrid.Cells.Cell(myRead["bongto_quality"].ToString(), typeof(string));
                  //  grid1[m, 7].View = center_cell;

                    grid1[m, 8] = new SourceGrid.Cells.Cell(Convert.ToInt32(myRead["garo"]), typeof(int));
                    grid1[m, 8].View = cc.int_cell;

                    grid1[m, 9] = new SourceGrid.Cells.Cell(Convert.ToInt32(myRead["sero"]), typeof(int));
                    grid1[m, 9].View = cc.int_cell;

                    grid1[m, 10] = new SourceGrid.Cells.Cell(Convert.ToInt32(myRead["top"]), typeof(int));
                    grid1[m, 10].View = cc.int_cell;

                    grid1[m, 11] = new SourceGrid.Cells.Cell(Convert.ToInt32(myRead["bottom"].ToString()), typeof(int));
                    grid1[m, 11].View = cc.int_cell;

                    grid1[m, 12] = new SourceGrid.Cells.Cell(Convert.ToInt32(myRead["b_left"].ToString()), typeof(int));
                    grid1[m, 12].View = cc.int_cell;

                    grid1[m, 13] = new SourceGrid.Cells.Cell(Convert.ToInt32(myRead["b_right"].ToString()), typeof(int));
                    grid1[m, 13].View = cc.int_cell;

                    grid1[m, 14] = new SourceGrid.Cells.Cell(Convert.ToInt32(myRead["danga"].ToString()), typeof(int));
                    grid1[m, 14].View = cc.int_cell;
                    grid1[m, 14].Editor = Int_Editor;

                    grid1[m, 15] = new SourceGrid.Cells.Cell(myRead["bigo"].ToString(), typeof(string));
                   // grid1[m, 15].View = center_cell;

                    grid1[m, 16] = new SourceGrid.Cells.Cell(myRead["sort"].ToString(), typeof(string));
                    m++;
                    myRead.Close();
                    DBConn.Close();
                    grid1.Refresh();
                }
            }
            var position = new SourceGrid.Position(m - 1, 1);
            grid1.Selection.Focus(position, true);
        }

        private void chSize_CheckedChanged(object sender, EventArgs e)
        {
            if (chSize.Checked == true)
                chSize2.Checked = true;
            else
                chSize2.Checked = false;
        }

        private void chJaket_CheckedChanged(object sender, EventArgs e)
        {
            if (chJaket.Checked == true)
                chJaket2.Checked = true;
            else
                chJaket2.Checked = false;
        }

        private void chLetter_CheckedChanged(object sender, EventArgs e)
        {
            if (chLetter.Checked == true)
                chLetter2.Checked = true;
            else
                chLetter2.Checked = false;
        }

        private void chCard_CheckedChanged(object sender, EventArgs e)
        {
            if (chCard.Checked == true)
                chCard2.Checked = true;
            else
                chCard2.Checked = false;
        }

        private void chSize2_CheckedChanged(object sender, EventArgs e)
        {
            if (chSize2.Checked == true)
                chSize.Checked = true;
            else
                chSize.Checked = false;
        }

        private void chLetter2_CheckedChanged(object sender, EventArgs e)
        {
            if (chLetter2.Checked == true)
                chLetter.Checked = true;
            else
                chLetter.Checked = false;
        }

        private void chJaket2_CheckedChanged(object sender, EventArgs e)
        {
            if (chJaket2.Checked == true)
                chJaket.Checked = true;
            else
                chJaket.Checked = false;
        }

        private void chCard2_CheckedChanged(object sender, EventArgs e)
        {
            if (chCard2.Checked == true)
                chCard.Checked = true;
            else
                chCard.Checked = false;
        }

        private void grid1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            int pos = grid1.Selection.ActivePosition.Column;
            int row = grid1.Selection.ActivePosition.Row;

            if (row == -1)
                return;
            string row_no = grid1[row, 0].ToString().Trim(); //row_id 
            string Query = "";
            string aQuery = "";
            string code = "";
            if (pos == 4)
            {
                if (grid1[row, 3].ToString() == "우찌누끼")
                    code = "1507";
                else
                    code = "2621";
                aQuery = "select * from C_hcustomer where yubjong like '%" + code + "%'";
                Form_404a Frm = new Form_404a(e.X, e.Y, row_no, aQuery,TableName_bong);
                Frm.ShowDialog();

                Query = "select b.sangho as sangho, b.area as area from "+TableName_bong+" as a ";
                Query += "left outer join C_hcustomer as b on a.hcust_id = b.row_id ";
                Query += "where a.row_id = " + row_no;

                var DBConn = new MySqlConnection(Config.DB_con1);
                DBConn.Open();
                var cmd = new MySqlCommand(Query, DBConn);

                var myRead = cmd.ExecuteReader();
                myRead.Read();

                grid1[row, 4] = new SourceGrid.Cells.Cell(myRead["sangho"], typeof(string));
                grid1[row, 4].View = cc.center_cell;
                grid1[row, 4].Editor = cc.disable_cell;

                grid1[row, 5] = new SourceGrid.Cells.Cell(myRead["area"], typeof(string));
                grid1[row, 5].View = cc.center_cell;
                grid1[row, 5].Editor = cc.disable_cell;

                myRead.Close();
                DBConn.Close();

                grid1.Refresh();
            }
        }

        private void bUp_Click(object sender, EventArgs e)
        {
            GridHandle.ChkMoveUp(1, 1, 0, 16, "sort", 2, TableName_bong);
        }

        private void bDown_Click(object sender, EventArgs e)
        {
            GridHandle.ChkMoveDown(1, 1, 0, 16, "sort", 2, TableName_bong);
        }

        private void Form_2151_ClientSizeChanged(object sender, EventArgs e)
        {
            this.bUp.Size = new System.Drawing.Size(31, (grid1.Size.Height / 2));
            this.bUp.Location = new System.Drawing.Point(grid1.Location.X - 37, grid1.Location.Y);

            int temp = bUp.Size.Height + bUp.Location.Y;
            this.bDown.Location = new System.Drawing.Point(grid1.Location.X - 37, bUp.Size.Height + bUp.Location.Y);
            this.bDown.Size = new System.Drawing.Size(31, (grid1.Size.Height / 2));
        }
    }
}
