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
    public partial class Form_304 : Form
    {
        cell_d cc = new cell_d();
        string cQuery;
        string DB_TableName = "C_coverwondan";
        string DB_TableName_file = "C_file_total_manage";
        string DB_TableName_hang = "hang_manage";
        string DB_TableName_code = "C_hcust_wondan_code";
        string DB_TableName_hcust = "C_hcustomer";
        public int picture_column = 12;
        bool code_chang = false;

        public DataGridControl GridHandle = new DataGridControl();
        SourceGridControl GridHandle_source = new SourceGridControl();
        FileControl FileControl = new FileControl();

        public Form_304()
        {
            InitializeComponent();
            //bPictureReg.Text = "선택항목\r\n사진등록";
            //bPictureDel.Text = "선택항목\r\n사진삭제";

        }

        private void Form_504_Load(object sender, EventArgs e)
        {
            DataView mView;
            mView = GridHandle.View_dt.DefaultView;
            mView.AllowDelete = true;
            mView.AllowNew = false;
            mView.AllowEdit = true;

            Screen srn = Screen.PrimaryScreen;
            int Xb = this.Width;  //좌,우
            this.Location = new Point((srn.Bounds.Width - Xb) / 2, 1);  //좌/우,위/아래

            GridHandle.DataGrideInit(dataGrid1, Config.DB_con1, Config.Ftp_ip1, Config.Ftp_id1, Config.Ftp_pw1);
            GridHandle_source.SourceGrideInit(null, Config.DB_con1);
            FileControl.FileControlInit(Config.DB_con1, Config.Ftp_ip1, Config.Ftp_id1, Config.Ftp_pw1);

            string[] wondan_name = new string[] { };
            string bQuery = "select hang as wondan  from " + DB_TableName_hang + " as a ";
            bQuery += " where class = '싸바리원단'";
            grid_combobox(wondan_name, bQuery, "wondan");

            string[] company = new string[] { };
            bQuery = "select distinct d.sangho as sangho from " + DB_TableName_code + " as a ";
            bQuery += "left outer join " + DB_TableName_hcust + " as d on a.hcust_id = d.row_id ";
            grid_combobox(company, bQuery, "sangho");

            string[] pattern_items = new string[] { "없음", "가로", "세로" };
            GridHandle.InputComboItem(pattern_items);

            GridHandle.dataGrid1.Columns.Clear();
            DB_DTSet();

            bQuery = "select b.sangho as sangho from " + DB_TableName_code + " as a ";
            bQuery += "left outer join " + DB_TableName_hcust + " as b on a.hcust_id = b.row_id ";

            GridHandle.ComboBoxItemInsert(DB_TableName, "sangho", cbCompany, bQuery);

            bQuery = "select distinct a.hang as wondan  from " + DB_TableName_hang + " as a ";
            bQuery += " where a.class = '싸바리원단'";
            GridHandle.ComboBoxItemInsert(DB_TableName, "wondan", cbWondanKind, bQuery);

            //cQuery = "select a.*, b.citem as item FROM " + DB_TableName + " as a ";
            //cQuery += "left outer join " + DB_TableName_cmode + " as b on a.kind_code = b.c_code and  b.a_code = '50' and b.b_code = '02'";
            //cQuery += " order by wondan_kind, wondan_no";

            bQuery = "select a.*,b.hang as wondan, d.sangho as sangho, e.user_file as file_name, if(a.pattern = 0,'없음',if(a.pattern = 1,'가로','세로')) as pat from " + DB_TableName + " as a ";
            bQuery += "left outer join " + DB_TableName_hang + " as b on a.kind_code = b.code1 and b.class = '싸바리원단' ";
            bQuery += "left outer join " + DB_TableName_code + " as c on a.company = c.code ";
            bQuery += "left outer join " + DB_TableName_hcust + " as d on c.hcust_id = d.row_id ";
            bQuery += "left outer join " + DB_TableName_file + " as e on a.row_id = e.int_id and e.db_nm = '" + DB_TableName + "'";
            bQuery += " order by wondan_no";
            Grid_View(bQuery);
        }

        private void grid_combobox(string[] arr_name, string bQuery, string column)
        {
            MySqlConnection DBConn;
            DBConn = new MySqlConnection(Config.DB_con1);
            DBConn.Open();
            arr_name = new string[] { };
            var cmd = new MySqlCommand(bQuery, DBConn);
            var myRead = cmd.ExecuteReader();
            int i = 0;
            string temp = "";
            while (myRead.Read())
            {
                temp += "#"+myRead[column].ToString();
                i++;
            }            
            myRead.Close();
            DBConn.Close();
            temp = temp.Substring(1);
            arr_name = temp.Split('#');
            GridHandle.InputComboItem(arr_name);
        }

        void Grid_View(string Query)
        {
            int No = 0;
            GridHandle.View_dt.ColumnChanging -= new DataColumnChangeEventHandler(custTable_ColumnChanging);

            GridHandle.GetData(Query);

            GridHandle.ViewDtClear();

            for (int i = 0; i < GridHandle.DB_dt.Rows.Count; i++)
            {
                Convert_Table(i, i + 1);
            }

            GridHandle.dataGrid1.SelectionMode = SourceGrid.GridSelectionMode.Cell;
            GridHandle.dataGrid1.DataSource = new DevAge.ComponentModel.BoundDataView(GridHandle.View_dt.DefaultView);

            GridHandle.dataGrid1.Rows.HeaderHeight = 33;

            GridHandle.dataGrid1.Rows.RowHeight = 24;

            GridHandle.dataGrid1.EnableSort = false;


            SourceGrid.Cells.Button button_cell = new SourceGrid.Cells.Button("");

            SourceGrid.Cells.Editors.TextBox disable_cell = new SourceGrid.Cells.Editors.TextBox(typeof(string));  //수정불가
            disable_cell.EnableEdit = false;

            GridHandle.dataGrid1.Columns[No].Visible = false;
            No++;

            GridHandle.dataGrid1.Columns[No].HeaderCell = new MyHeader("√");
            GridHandle.dataGrid1.Columns[No].Width = 30;
            No++;

            GridHandle.dataGrid1.Columns[No].HeaderCell = new MyHeader("No");
            GridHandle.dataGrid1.Columns[No].Width = 40;
            GridHandle.dataGrid1.Columns[No].DataCell.Editor = cc.disable_cell;
            GridHandle.dataGrid1.Columns[No].DataCell.View = cc.int_cell;
            No++;

            GridHandle.dataGrid1.Columns[No].HeaderCell = new MyHeader("원단종류");
            GridHandle.dataGrid1.Columns[No].Width = 120;
            GridHandle.dataGrid1.Columns[No].DataCell.Editor = GridHandle.CbBox[0];
            GridHandle.dataGrid1.Columns[No].DataCell.View = cc.center_cell;
            No++;

            GridHandle.dataGrid1.Columns[No].HeaderCell = new MyHeader("원단업체");
            GridHandle.dataGrid1.Columns[No].Width = 100;
            GridHandle.dataGrid1.Columns[No].DataCell.Editor = GridHandle.CbBox[1];
            GridHandle.dataGrid1.Columns[No].DataCell.View = cc.center_cell; 
            No++;

            GridHandle.dataGrid1.Columns[No].HeaderCell = new MyHeader("원단이름");
            GridHandle.dataGrid1.Columns[No].Width = 100;
            GridHandle.dataGrid1.Columns[No].DataCell.View = cc.center_cell;
            No++;
            GridHandle.dataGrid1.Columns[No].HeaderCell = new MyHeader("패턴");//0 없음, 1 가로, 2 세로
            GridHandle.dataGrid1.Columns[No].Width = 70;
            GridHandle.dataGrid1.Columns[No].DataCell.Editor = GridHandle.CbBox[2];
            GridHandle.dataGrid1.Columns[No].DataCell.View = cc.center_cell;
            No++;

            GridHandle.dataGrid1.Columns[No].HeaderCell = new MyHeader("폭[mm]");
            GridHandle.dataGrid1.Columns[No].Width = 80;
            GridHandle.dataGrid1.Columns[No].DataCell.View = cc.int_cell;
            No++;

            GridHandle.dataGrid1.Columns[No].HeaderCell = new MyHeader("Roll 길이[mm]");
            GridHandle.dataGrid1.Columns[No].Width = 80;
            GridHandle.dataGrid1.Columns[No].DataCell.View = cc.int_cell;
            No++;

            GridHandle.dataGrid1.Columns[No].HeaderCell = new MyHeader("단가");
            GridHandle.dataGrid1.Columns[No].Width = 60;
            GridHandle.dataGrid1.Columns[No].DataCell.View = cc.int_cell;
            No++;

            GridHandle.dataGrid1.Columns[No].HeaderCell = new MyHeader("주문단위[mm]");
            GridHandle.dataGrid1.Columns[No].Width = 100;
            GridHandle.dataGrid1.Columns[No].DataCell.View = cc.int_cell;
            No++;

            GridHandle.dataGrid1.Columns[No].HeaderCell = new MyHeader("설명");
            GridHandle.dataGrid1.Columns[No].Width = 400;
            GridHandle.dataGrid1.Columns[No].DataCell.View = cc.left_cell;
            No++;

            GridHandle.dataGrid1.Columns[No].HeaderCell = new MyHeader("보기");
            GridHandle.dataGrid1.Columns[No].Width = 40;
            GridHandle.dataGrid1.Columns[No].DataCell = button_cell;
            GridHandle.dataGrid1.Columns[No].DataCell.Editor = disable_cell;
            No++;

            GridHandle.dataGrid1.Columns[No].HeaderCell = new MyHeader("파일명");
            GridHandle.dataGrid1.Columns[No].Width = 80;
            GridHandle.dataGrid1.Columns[No].DataCell.Editor = cc.disable_cell;
            GridHandle.dataGrid1.Columns[No].DataCell.View = cc.left_cell;
            No++;

            

            GridHandle.View_dt.ColumnChanging += new DataColumnChangeEventHandler(custTable_ColumnChanging);
            GridHandle.dataGrid1.Selection.FocusRow(1);
        }

        private void custTable_ColumnChanging(object sender, DataColumnChangeEventArgs e)
        {
            int Count = GridHandle.View_dt.Rows.Count;
            if (GridHandle.dataGrid1.Selection.ActivePosition.Row.Equals(-1) ||
                GridHandle.dataGrid1.Selection.ActivePosition.Row.Equals(Count + 1))
                return;

            string mQuery = "";
            string dat = e.ProposedValue.ToString().Trim();
            string row_no = GridHandle.View_dt.Rows[dataGrid1.Selection.ActivePosition.Row - 1][0].ToString();         //row_id
            string No = GridHandle.View_dt.Rows[dataGrid1.Selection.ActivePosition.Row - 1][2].ToString();         //row_id
            int row = GridHandle.dataGrid1.Selection.ActivePosition.Row;
            int pos = GridHandle.dataGrid1.Selection.ActivePosition.Column;
            if (code_chang == true)
            {
                pos = 0;
                code_chang = false;
                return;
            }
            //
            //if (pos == 3)
            //    mQuery = " update " + DB_TableName + " set class='" + dat + "' where row_id='" + row_no + "'";
            //else if (pos == 4)
            //    mQuery = " update " + DB_TableName + " set wondan_kind='" + dat + "' where row_id='" + row_no + "'";
            if (pos == 3)
            {//원단종류
                MySqlConnection DBConn;
                DBConn = new MySqlConnection(Config.DB_con1);
                DBConn.Open();
                string Query = "select code1 from " + DB_TableName_hang + " where hang = '" + dat + "' and class = '싸바리원단'";
                var cmd = new MySqlCommand(Query, DBConn);
                var myRead = cmd.ExecuteReader();
                if (myRead.Read())
                    dat = myRead["code1"].ToString();
                myRead.Close();
                DBConn.Close();
                mQuery = " update " + DB_TableName + " set kind_code='" + dat + "' where row_id='" + row_no + "'";
            }
            else if(pos == 4)
            {
                //원단업체
                MySqlConnection DBConn;
                DBConn = new MySqlConnection(Config.DB_con1);
                DBConn.Open();
                string Query = "select a.code as code from " + DB_TableName_code + " as a ";
                Query += "left outer join " + DB_TableName_hcust + " as b on a.hcust_id = b.row_id ";
                Query += " where b.sangho = '" + dat + "'";
                //조인 쿼리 만들기
                var cmd = new MySqlCommand(Query, DBConn);
                var myRead = cmd.ExecuteReader();
                if (myRead.Read())
                    dat = myRead["code"].ToString();
                myRead.Close();
                DBConn.Close();
                mQuery = " update " + DB_TableName + " set company='" + dat + "' where row_id='" + row_no + "'";
            }
         

            else if (pos == 5)
                mQuery = " update " + DB_TableName + " set wondan_no='" + dat + "' where row_id='" + row_no + "'";
            else if (pos == 6)
            {
                if (dat == "없음")
                    dat = "0";
                else if (dat == "가로")
                    dat = "1";
                else
                    dat = "2";
                mQuery = " update " + DB_TableName + " set pattern='" + dat + "' where row_id='" + row_no + "'";
            }
            else if (pos == 7)
                mQuery = " update " + DB_TableName + " set width='" + dat + "' where row_id='" + row_no + "'";
            else if (pos == 8)
                mQuery = " update " + DB_TableName + " set height='" + dat + "' where row_id='" + row_no + "'";
            else if (pos == 9)
                mQuery = " update " + DB_TableName + " set price='" + dat + "' where row_id='" + row_no + "'";
            else if (pos == 10)
                mQuery = " update " + DB_TableName + " set unit='" + dat + "' where row_id='" + row_no + "'";
            else if (pos == 11)
                mQuery = " update " + DB_TableName + " set comment='" + dat + "' where row_id='" + row_no + "'";
            else
                return;
          
            //Grid_View(cQuery);
            if (GridHandle.DataUpdate(mQuery) == 1)
                MessageBox.Show("서버 자료 수정에 실패 했습니다.");

            //if (pos == 7 || pos == 8 || pos == 9 || pos == 10)
            //{
            //    code_chang = true;
            //    string temp = GridHandle_source.numgetcoma(dat);
            //    GridHandle.View_dt.Rows[row - 1][pos] = temp;
            //}
            //if (pos == 4)
            //{
            //    //GridHandle.GetData(cQuery);
            //    //GridHandle.ViewDtClear();

            //    //for (int i = 0; i < GridHandle.DB_dt.Rows.Count; i++)
            //    //{
            //    //    Convert_Table(i, i + 1);
            //    //}

            //    MySqlConnection DBConn;
            //    DBConn = new MySqlConnection(Config.DB_con1);
            //    DBConn.Open();
            //    string Query = "select citem from " + DB_TableName_cmode + " where a_code = '50' and b_code = '02' and c_code = '" + dat + "'";
            //    var cmd = new MySqlCommand(Query, DBConn);
            //    var myRead = cmd.ExecuteReader();
            //    if (myRead.Read())
            //    {
            //        code_chang = true;
            //        GridHandle.View_dt.Rows[row - 1]["item"] = myRead["citem"].ToString();
            //        dataGrid1.Refresh();
            //    }
            //}

        }

        void Convert_Table(int i, int No)
        {
            string pattern = "";
            if (GridHandle.DB_dt.Rows[i]["pattern"].ToString() == "0")
                pattern = "없음";
            if (GridHandle.DB_dt.Rows[i]["pattern"].ToString() == "1")
                pattern = "가로";
            if (GridHandle.DB_dt.Rows[i]["pattern"].ToString() == "2")
                pattern = "세로";

            string width_val = GridHandle_source.numgetcoma(GridHandle.DB_dt.Rows[i]["width"].ToString());
            string height_val = GridHandle_source.numgetcoma(GridHandle.DB_dt.Rows[i]["height"].ToString());
            string price_val = GridHandle_source.numgetcoma(GridHandle.DB_dt.Rows[i]["price"].ToString());
            string unit_val = GridHandle_source.numgetcoma(GridHandle.DB_dt.Rows[i]["unit"].ToString());

            GridHandle.View_dt.Rows.Add(new object[] { GridHandle.DB_dt.Rows[i]["row_id"].ToString(),  false, No, 
                  GridHandle.DB_dt.Rows[i]["wondan"].ToString(), GridHandle.DB_dt.Rows[i]["sangho"].ToString()
                  , GridHandle.DB_dt.Rows[i]["wondan_no"].ToString(), pattern, width_val, height_val, price_val, unit_val
                , GridHandle.DB_dt.Rows[i]["comment"].ToString(), null,GridHandle.DB_dt.Rows[i]["file_name"].ToString() });
            
        }

        void DB_DTSet()
        {
            String[] DB_Item = new String[] {
                "row_id", "string",
                "wondan", "string",
                "sangho", "string",
                "wondan_no", "string",
                "pattern", "string",
                "picture", "string",
                "width", "string",
                "height", "string",
                "price", "string",
                "unit", "string",
                "comment", "string",
                "file_name", "string"};

            String[] View_Item = new String[] {
                "row_id",   "string",
                "chk",      "bool",
                "No",       "int",
                "wondan", "string",
                "sangho",  "string",
                "wondan_no","string",
                "pattern", "string",
                "width",    "string",
                "height",   "string",
                "price",    "string",
                "unit", "string",
                "comment",  "string",
                "button",     "button",
                "file_name",   "string"};

            GridHandle.DataTableInit(DB_Item, View_Item);

        }

        private void bAdd_Click(object sender, EventArgs e)
        {
            GridHandle.View_dt.ColumnChanging -= new DataColumnChangeEventHandler(custTable_ColumnChanging);

            cQuery = " insert into " + DB_TableName + " ( class, picture)";
            cQuery += " values('','0')";

            MySqlConnection DBConn = new MySqlConnection(Config.DB_con1);
            DBConn.Open();
            var cmd = new MySqlCommand(cQuery, DBConn);
            if (cmd.ExecuteNonQuery() == 0)
            {
                MessageBox.Show("서버 자료 등록에 실패 했습니다.");
                return;
            }

                GridHandle.DB_dt.Clear();
            cQuery = " select * from " + DB_TableName + " where row_id=(SELECT LAST_INSERT_ID())";
            MySqlDataAdapter returnVal = new MySqlDataAdapter(cQuery, DBConn);
            returnVal.Fill(GridHandle.DB_dt);
            returnVal.Dispose();
            DBConn.Close();
                
            Convert_Table(0, GridHandle.View_dt.Rows.Count + 1); // 마지막 Data를 Select 하여 GridHandle.View_dt에 Add

            var position = new SourceGrid.Position(GridHandle.View_dt.Rows.Count, 3);
            GridHandle.dataGrid1.Selection.Focus(position, true);
            GridHandle.View_dt.ColumnChanging += new DataColumnChangeEventHandler(custTable_ColumnChanging);

        }

        private void Form_504_FormClosing(object sender, FormClosingEventArgs e)
        {
            
        }

        private void bCopy_Click(object sender, EventArgs e)
        {
            string row_no = "";
            string[] sd = new string[GridHandle.View_dt.Rows.Count];
            int copy_number = 0;

            for (int i = 0; i < sd.Length; i++)  // 배열 sd 초기화
            {
                sd[i] = "0";
            }
            //
            int s = 0;

            for (int i = 0; i < GridHandle.View_dt.Rows.Count; i++)   // string 배열 sd 에 row_id 삽입
            {
                if (GridHandle.View_dt.Rows[i][1].Equals(true))
                {
                    sd[s] = GridHandle.View_dt.Rows[i][0].ToString().Trim();
                    s++;
                }
            }

            if (sd[0] == "0")
            {
                MessageBox.Show("선택된 항목이 없습니다");
                return;
            }
            //
            for (int i = 0; i < sd.Length; i++)
            {
                if (sd[i].Equals("0"))
                {
                    copy_number = i - 1;
                    break;
                }
                else
                {
                    row_no = sd[i];
                    GridHandle.OneDataCopy(DB_TableName, row_no);//DataBase 상의 Data만 복사. Grid 갱신은 별도로 수행

                    // Grid 화면 갱신
                    cQuery = " select * from " + DB_TableName + " where row_id=(SELECT LAST_INSERT_ID())";
                    //cQuery = "select a.*, b.citem as item FROM " + DB_TableName + " as a ";
                    //cQuery += "left outer join " + DB_TableName_cmode + " as b on a.kind_code = b.c_code and  b.a_code = '50' and b.b_code = '02'";
                    //cQuery += " where a.row_id=(SELECT LAST_INSERT_ID())";
                   
                    GridHandle.GetData(cQuery);

                    Convert_Table(0, GridHandle.View_dt.Rows.Count + 1); // 마지막 Data를 Select 하여 GridHandle.View_dt에 Add
                   
                }
                copy_number = i;
            }
            
            GridHandle.ChkCancel(1);
            var position = new SourceGrid.Position(GridHandle.View_dt.Rows.Count - copy_number, 3);
            GridHandle.dataGrid1.Selection.Focus(position, true);
        }

        private void bDelete_Click(object sender, EventArgs e)
        {
            GridHandle.View_dt.ColumnChanging -= new DataColumnChangeEventHandler(custTable_ColumnChanging);

            string[] GetRowid = new string[GridHandle.View_dt.Rows.Count];
            int[] GetRow = new int[GridHandle.View_dt.Rows.Count];
            int i;
            string Query = "";
            string FilePath = "";
            MySqlDataReader myRead;

            for (i = 0; i < GetRowid.Length; i++)
            {
                GetRowid[i] = "0";
                GetRow[i] = 0;
            }
            //
            int s = 0;
            for (i = 0; i < GridHandle.View_dt.Rows.Count; i++)
            {
                if (GridHandle.View_dt.Rows[i][1].Equals(true))
                {
                    GetRowid[s] = GridHandle.View_dt.Rows[i][0].ToString().Trim();
                    GetRow[s] = i;
                    s++;
                }
            }

            if (GetRowid[0] == "0")
            {
                MessageBox.Show("선택된 항목이 없습니다");
                return;
            }

            MySqlConnection DBConn = new MySqlConnection(Config.DB_con1);
            DBConn.Open();
            MySqlCommand cmd;
            for (i = 0; i < GridHandle.View_dt.Rows.Count; i++)
            {
                if (GetRowid[i] == "0")
                    break;
                Query = "select * from " + DB_TableName + " where row_id ='" + GetRowid[i] + "'";
                cmd = new MySqlCommand(Query, DBConn);
                myRead = cmd.ExecuteReader();

                myRead.Read();
                FilePath = myRead["picture"].ToString();
                myRead.Close();
                Del_Picture(GetRow[i], GetRowid[i], FilePath);
            }
            DBConn.Close();

            GridHandle.ChkDataDelete(DB_TableName, 0, 1);

            dataGrid1.Refresh();

            GridHandle.View_dt.ColumnChanging += new DataColumnChangeEventHandler(custTable_ColumnChanging);
        }

        private void dataGrid1_Click(object sender, EventArgs e)
        {
            int select_row = dataGrid1.Selection.ActivePosition.Row;
            
            if (select_row < 0)
                return;

            string row_no = GridHandle.View_dt.Rows[dataGrid1.Selection.ActivePosition.Row - 1][0].ToString();
            string Query = "select * from " + DB_TableName_file + " where int_id = '" + row_no + "' and db_nm = '"+DB_TableName+"'";
            MySqlConnection DBConn = new MySqlConnection(Config.DB_con1);

            DBConn.Open();
            MySqlDataReader myRead;

            var cmd = new MySqlCommand(Query, DBConn);
            myRead = cmd.ExecuteReader();
            string file_path = "";
            if (myRead.Read())
                file_path = myRead["server_file"].ToString();

           
            myRead.Close();
            DBConn.Close();

            if (dataGrid1.Selection.ActivePosition.Column == picture_column)
            {
                if (file_path == "")
                {
                    //MessageBox.Show("등록된 사진이 없습니다");
                    //return;
                    FileControl FC = new FileControl();
                    FC.FileControlInit(Config.DB_con1, Config.Ftp_ip1, Config.Ftp_id1, Config.Ftp_pw1);
                    OpenFileDialog ofd = new OpenFileDialog();// File descriptor
                    if (FC.FileOpenDlg(ofd) == 1)
                        return;
                    this.Cursor = System.Windows.Forms.Cursors.WaitCursor;
                    FC.FileReg(ofd, DB_TableName, "picture", row_no, "file");
                    GridHandle.View_dt.Rows[dataGrid1.Selection.ActivePosition.Row - 1][picture_column + 1] = ofd.SafeFileName;
                    this.Cursor = System.Windows.Forms.Cursors.Default;
                }
                else
                {
                    Form_imgview Frm = new Form_imgview(row_no, file_path, DB_TableName);
                    if(Frm.ShowDialog() == DialogResult.OK)
                    {
                        GridHandle.View_dt.Rows[dataGrid1.Selection.ActivePosition.Row - 1][picture_column + 1] = "";
                    }
                }
            }
        }

        private void bPictureReg_Click(object sender, EventArgs e)
        {
            FileControl FC = new FileControl();
            FC.FileControlInit(Config.DB_con1, Config.Ftp_ip1, Config.Ftp_id1, Config.Ftp_pw1);
            string temp = "row_id < 0 ";

            string[] GetRowid = new string[GridHandle.View_dt.Rows.Count];
            int[] GetRow = new int[GridHandle.View_dt.Rows.Count];
            int i;
            for (i= 0; i < GetRowid.Length; i++)
            {
                GetRowid[i] = "0";
                GetRow[i] = 0;
            }
            //
            int s = 0;
            for (i = 0; i < GridHandle.View_dt.Rows.Count; i++)
                if (GridHandle.View_dt.Rows[i][1].Equals(true))
                {
                    GetRowid[s] = GridHandle.View_dt.Rows[i][0].ToString().Trim();
                    GetRow[s] = i;
                    temp += " or row_id = '" + GridHandle.View_dt.Rows[i][0].ToString().Trim() +"'";
                    s++;
                }
            
            if (GetRowid[0] == "0")
            {
                MessageBox.Show("선택된 항목이 없습니다");
                return;
            }

            OpenFileDialog ofd = new OpenFileDialog();// File descriptor

            if (FileControl.FileOpenDlg(ofd) == 1)
                return;

            string ff1 = ofd.FileName;
            string Query = "select row_id from " + DB_TableName + " where " + temp;
            FC.OneFile2ManyRowId(ofd, DB_TableName, "picture", "", Query);

            //OhFTP Ftp = new OhFTP(Config.Ftp_ip1, Config.Ftp_id1, Config.Ftp_pw1);
            //string ff1 = ofd.FileName;
            //string ff2 = GetRowid[0] + "-C_coverwondan";

            //ff2 += ofd.FileName.Substring(ofd.FileName.LastIndexOf("."), ofd.FileName.Length - ofd.FileName.LastIndexOf("."));
            //Ftp.UpLoadFile(ff1, ff2, DB_TableName);

            for (i = 0; i < GridHandle.View_dt.Rows.Count; i++)
            {
                if (GetRowid[i] == "0")
                    break;

                GridHandle.View_dt.Rows[GetRow[i]][picture_column - 1] = "*";

            }

            GridHandle.ChkCancel(1);
            
        }

        private void bClear_Click(object sender, EventArgs e)
        {
            cbWondanKind.Text = "";
            cbWondanKind.Refresh();


            cbCompany.Text = "";
            cbCompany.Refresh();

            cbPattern.Text = "";
            cbPattern.Refresh();

            tbWondanNo.Text = "";
            tbWondanNo.Refresh();

            tbWidth.Text = "";
            tbWidth.Refresh();

            tbHeight.Text = "";
            tbHeight.Refresh();
        }

        private void bSearch_Click(object sender, EventArgs e)
        {
            string wondan_kind = "";
            string company = "";
            string wondan_no = "";
            string width = "";
            string height = "";
            string pattern = "";

            if (cbWondanKind.Text != "")
                wondan_kind = " and b.hang ='" + cbWondanKind.Text.Trim() + "'";

            if ( cbCompany.Text != "")
                company = " and d.sangho ='" + cbCompany.Text.Trim() + "'";

            if ( tbWondanNo.Text != "")
                wondan_no = " and wondan_no like '%" + tbWondanNo.Text.Trim() + "%'";

            if ( tbWidth.Text != "")
                width = " and width ='" + tbWidth.Text.Trim() + "'";

            if ( tbHeight.Text != "")
                height = " and height ='" + tbHeight.Text.Trim() + "'";
            if (cbPattern.Text != "")
            {
                if (cbPattern.Text == "없음")
                    pattern = " and pattern = '0'";
                else if(cbPattern.Text == "가로")
                    pattern = " and pattern = '1'";
                else
                    pattern = " and pattern = '2'";
            }

            cQuery = "select a.*,b.hang as wondan, d.sangho as sangho, e.user_file as file_name, if(a.pattern = 0,'없음',if(a.pattern = 1,'가로','세로')) as pat from " + DB_TableName + " as a ";
            cQuery += "left outer join " + DB_TableName_hang + " as b on a.kind_code = b.code1 and b.class = '싸바리원단' ";
            cQuery += "left outer join " + DB_TableName_code + " as c on a.company = c.code ";
            cQuery += "left outer join " + DB_TableName_hcust + " as d on c.hcust_id = d.row_id ";
            cQuery += "left outer join " + DB_TableName_file + " as e on a.row_id = e.int_id and e.db_nm = '" + DB_TableName + "'";
            cQuery += " where a.row_id is not null " + wondan_kind + company + wondan_no + width + height + pattern;
            cQuery += " order by wondan_no";

            Grid_View(cQuery);
        }

        private void bPictureDel_Click(object sender, EventArgs e)
        {
            string[] GetRowid = new string[GridHandle.View_dt.Rows.Count];
            int[] GetRow = new int[GridHandle.View_dt.Rows.Count];
            int i;
            string Query = "";
            string FilePath = "";
            MySqlDataReader myRead;

            for (i = 0; i < GetRowid.Length; i++)
            {
                GetRowid[i] = "0";
                GetRow[i] = 0;
            }
            //
            int s = 0;
            for (i = 0; i < GridHandle.View_dt.Rows.Count; i++)
            {
                if (GridHandle.View_dt.Rows[i][1].Equals(true))
                {
                    GetRowid[s] = GridHandle.View_dt.Rows[i][0].ToString().Trim();
                    GetRow[s] = i;
                    s++;
                }
            }

            if (GetRowid[0] == "0")
            {
                MessageBox.Show("선택된 항목이 없습니다");
                return;
            }

            MySqlConnection DBConn = new MySqlConnection(Config.DB_con1);
            DBConn.Open();

            MySqlCommand cmd;

            if (MessageBox.Show("선택한 항목의 사진을 삭제합니까 ?", "사진 삭제", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                this.Cursor = System.Windows.Forms.Cursors.WaitCursor;
                for (i = 0; i < GridHandle.View_dt.Rows.Count; i++)
                {
                    if (GetRowid[i] == "0")
                    {
                        DBConn.Close();
                        break;
                    }
                    Query = "select * from " + DB_TableName + " where row_id ='" + GetRowid[i] + "'";
                    cmd = new MySqlCommand(Query, DBConn);
                    myRead = cmd.ExecuteReader();
                    myRead.Read();
                    FilePath = myRead["picture"].ToString();
                    myRead.Close();
                    Del_Picture(GetRow[i], GetRowid[i], FilePath);
                }
                for (i = 0; i < GridHandle.View_dt.Rows.Count; i++)
                {
                    if (GridHandle.View_dt.Rows[i][1].Equals(true))
                    {
                        GridHandle.View_dt.Rows[i][picture_column + 1] = "";
                    }
                }
                GridHandle.ChkCancel(1);

                this.Cursor = System.Windows.Forms.Cursors.Default;
            }
            DBConn.Close();
        }

        public void Del_Picture(int select_row, string row_id, string File_Path)
        {
            if (File_Path == "")
                return;

            FileControl FC = new FileControl();
            FC.FileControlInit(Config.DB_con1, Config.Ftp_ip1, Config.Ftp_id1, Config.Ftp_pw1);

            FC.OneFile2ManyRowId_Del(DB_TableName, "picture", row_id, "");

            GridHandle.View_dt.Rows[select_row][picture_column - 1] = "";
            //string Query = "update " + DB_TableName + " set picture = '0' where row_id = '" + row_id + "'";
            //FC.DataUpdate(Query);

            //Query = "select * from " + DB_TableName + " where picture='" + File_Path + "'";
            //var DBConn = new MySqlConnection(Config.DB_con1);
            //DBConn.Open();
            //var cmd = new MySqlCommand(Query, DBConn);
            //var myRead = cmd.ExecuteReader();


            //// Grid에서는 1번째 Row 지만 View_dt 에서는 0번째 Row 이다. 그래서 -1
            //GridHandle.View_dt.Rows[select_row][picture_column - 1] = "";

            //if (myRead.Read())
            //{
            //}
            //else
            //{
            //    FC.FileDel(File_Path,DB_TableName);// 다른 항목에서 그림을 참조하고 있지 않으면 File서버에서 삭제후 끝
            //}
        }

        private void bManage_Click(object sender, EventArgs e)
        {
            util.IsFormAlreadyOpen(typeof(Form_503));
            Form_503 Frm = new Form_503("5002", bManage);
            Frm.Owner = this;
            Frm.Show();
        }

    }
}
