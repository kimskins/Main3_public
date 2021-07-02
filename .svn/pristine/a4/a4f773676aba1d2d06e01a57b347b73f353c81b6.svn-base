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
    public partial class Form_305 : Form
    {
        cell_d cc = new cell_d();
        string cQuery;
        string DB_TableName = "C_bakwondan";
        string DB_TableName_file = "C_file_total_manage";
        public int picture_column = 11;

        public DataGridControl GridHandle = new DataGridControl();
        FileControl FileControl = new FileControl();

        public Form_305()
        {
            InitializeComponent();

            bPictureReg.Text = "선택항목\r\n사진등록";
            bPictureDel.Text = "선택항목\r\n사진삭제";
        }

        private void Form_505_Load(object sender, EventArgs e)
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
            FileControl.FileControlInit(Config.DB_con1, Config.Ftp_ip1, Config.Ftp_id1, Config.Ftp_pw1);

            cQuery = "select distinct(b.citem) as wondan_kind from " + DB_TableName + " as a left outer join C_cmodel as b on b.a_code='13' and b.b_code='01' and a.kind_code = b.c_code";
            GridHandle.ComboBoxItemInsert(DB_TableName, "wondan_kind", cbWondanKind, cQuery);
            GridHandle.ComboBoxItemInsert(DB_TableName, "kind_code", cbKindCode);
            GridHandle.ComboBoxItemInsert(DB_TableName, "company", cbCompany);
            GridHandle.ComboBoxItemInsert(DB_TableName, "price_cd", cbDangaCd);

            GridHandle.dataGrid1.Columns.Clear();
            DB_DTSet();

            //cQuery = "select * FROM " + DB_TableName + " order by wondan_kind, wondan_no";
            cQuery = "select a.*, b.citem as wondan_kind, c.hang as price_name from " + DB_TableName + " as a left outer join C_cmodel as b";
            cQuery += " on b.a_code='13' and b.b_code='01' and a.kind_code = b.c_code left outer join hang_manage as c on c.class='박원단그룹' and a.price_cd = c.code1 order by wondan_kind, wondan_no"; 

            Grid_View(cQuery);
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
            No++;  //1
            GridHandle.dataGrid1.Columns[No].HeaderCell = new MyHeader("√");
            GridHandle.dataGrid1.Columns[No].Width = 30;
            
            No++;  //2
            GridHandle.dataGrid1.Columns[No].HeaderCell = new MyHeader("No");
            GridHandle.dataGrid1.Columns[No].Width = 40;
            GridHandle.dataGrid1.Columns[No].DataCell.Editor = cc.disable_cell;
            GridHandle.dataGrid1.Columns[No].DataCell.View = cc.int_cell;
           
            No++;  //3
            GridHandle.dataGrid1.Columns[No].HeaderCell = new MyHeader("분류");
            GridHandle.dataGrid1.Columns[No].Width = 50;
            GridHandle.dataGrid1.Columns[No].DataCell.View = cc.center_cell;
            
            No++;  //4
            GridHandle.dataGrid1.Columns[No].HeaderCell = new MyHeader("원단종류");
            GridHandle.dataGrid1.Columns[No].Width = 120;
            GridHandle.dataGrid1.Columns[No].DataCell.View = cc.center_cell;
            GridHandle.dataGrid1.Columns[No].DataCell.Editor = cc.disable_cell;
            
            No++;  //5
            GridHandle.dataGrid1.Columns[No].HeaderCell = new MyHeader("종류\r\n코드");
            GridHandle.dataGrid1.Columns[No].Width = 40;
            GridHandle.dataGrid1.Columns[No].DataCell.View = cc.center_cell;
           
            No++;  //6
            GridHandle.dataGrid1.Columns[No].HeaderCell = new MyHeader("원단업체");
            GridHandle.dataGrid1.Columns[No].Width = 100;
            GridHandle.dataGrid1.Columns[No].DataCell.View = cc.center_cell;
            No++;  //7

            GridHandle.dataGrid1.Columns[No].HeaderCell = new MyHeader("원단이름");
            GridHandle.dataGrid1.Columns[No].Width = 100;
            GridHandle.dataGrid1.Columns[No].DataCell.View = cc.center_cell;
            
            No++;  //8
            GridHandle.dataGrid1.Columns[No].HeaderCell = new MyHeader("단가그룹");
            GridHandle.dataGrid1.Columns[No].Width = 80;
            GridHandle.dataGrid1.Columns[No].DataCell.View = cc.center_cell;
            GridHandle.dataGrid1.Columns[No].DataCell.Editor = cc.disable_cell;
            
            No++;  //9
            GridHandle.dataGrid1.Columns[No].HeaderCell = new MyHeader("단가\r\n코드");
            GridHandle.dataGrid1.Columns[No].Width = 40;
            GridHandle.dataGrid1.Columns[No].DataCell.View = cc.center_cell;

            No++;  //10
            GridHandle.dataGrid1.Columns[No].HeaderCell = new MyHeader("기본");
            GridHandle.dataGrid1.Columns[No].Width = 40;
                       
            No++;  //11
            GridHandle.dataGrid1.Columns[No].HeaderCell = new MyHeader("후공정코드");
            GridHandle.dataGrid1.Columns[No].Width = 100;
            GridHandle.dataGrid1.Columns[No].DataCell.View = cc.center_cell;

            No++;  //12
            GridHandle.dataGrid1.Columns[No].HeaderCell = new MyHeader("");
            GridHandle.dataGrid1.Columns[No].Width = 20;
            GridHandle.dataGrid1.Columns[No].DataCell.Editor = cc.disable_cell;
            GridHandle.dataGrid1.Columns[No].DataCell.View = cc.left_cell;
            
            No++;  //13
            GridHandle.dataGrid1.Columns[No].HeaderCell = new MyHeader("보기");
            GridHandle.dataGrid1.Columns[No].Width = 40;
            GridHandle.dataGrid1.Columns[No].DataCell = button_cell;
            GridHandle.dataGrid1.Columns[No].DataCell.Editor = disable_cell;
           
            No++;  //14
            GridHandle.View_dt.ColumnChanging += new DataColumnChangeEventHandler(custTable_ColumnChanging);
            GridHandle.dataGrid1.Selection.FocusRow(1);
        }

        private void custTable_ColumnChanging(object sender, DataColumnChangeEventArgs e)
        {
            int Count = GridHandle.View_dt.Rows.Count;
            if (GridHandle.dataGrid1.Selection.ActivePosition.Row.Equals(-1) ||
                GridHandle.dataGrid1.Selection.ActivePosition.Row.Equals(Count + 1))
                return;

            string cQuery = "";
            string dat = e.ProposedValue.ToString().Trim();
            string row_no = GridHandle.View_dt.Rows[dataGrid1.Selection.ActivePosition.Row - 1][0].ToString();         //row_id

            //
            if (GridHandle.dataGrid1.Selection.ActivePosition.Column == 3)
                cQuery = " update " + DB_TableName + " set class='" + dat + "' where row_id='" + row_no + "'";
            //else if (GridHandle.dataGrid1.Selection.ActivePosition.Column == 4)
            //    cQuery = " update " + DB_TableName + " set wondan_kind='" + dat + "' where row_id='" + row_no + "'";
            else if (GridHandle.dataGrid1.Selection.ActivePosition.Column == 5)
                cQuery = " update " + DB_TableName + " set kind_code='" + dat + "' where row_id='" + row_no + "'";
            else if (GridHandle.dataGrid1.Selection.ActivePosition.Column == 6)
                cQuery = " update " + DB_TableName + " set company='" + dat + "' where row_id='" + row_no + "'";
            else if (GridHandle.dataGrid1.Selection.ActivePosition.Column == 7)
                cQuery = " update " + DB_TableName + " set wondan_no='" + dat + "' where row_id='" + row_no + "'";
            else if (GridHandle.dataGrid1.Selection.ActivePosition.Column == 9)
                cQuery = " update " + DB_TableName + " set price_cd='" + dat + "' where row_id='" + row_no + "'";
            else if (GridHandle.dataGrid1.Selection.ActivePosition.Column == 10)
                cQuery = " update " + DB_TableName + " set default_value=" + dat + " where row_id='" + row_no + "'";
            else if (GridHandle.dataGrid1.Selection.ActivePosition.Column == 11)
                cQuery = " update " + DB_TableName + " set gongjung='" + dat + "' where row_id='" + row_no + "'";
            else
                return;

            if (GridHandle.DataUpdate(cQuery) == 1)
                MessageBox.Show("서버 자료 수정에 실패 했습니다.");
        }

        void Convert_Table(int i, int No)
        {
            string view = "";

                if (GridHandle.DB_dt.Rows[i]["picture"].ToString() == "False" || GridHandle.DB_dt.Rows[i]["picture"].ToString() == "false")
                    view = "";
                else
                    view = "*";
            

            GridHandle.View_dt.Rows.Add(new object[] { GridHandle.DB_dt.Rows[i]["row_id"].ToString(),  false, No, 
                  GridHandle.DB_dt.Rows[i]["class"].ToString(), GridHandle.DB_dt.Rows[i]["wondan_kind"].ToString(), GridHandle.DB_dt.Rows[i]["kind_code"].ToString()
                , GridHandle.DB_dt.Rows[i]["company"].ToString(), GridHandle.DB_dt.Rows[i]["wondan_no"].ToString()
                , GridHandle.DB_dt.Rows[i]["price_name"].ToString(), GridHandle.DB_dt.Rows[i]["price_cd"].ToString(), Convert.ToBoolean(GridHandle.DB_dt.Rows[i]["default_value"].ToString()), GridHandle.DB_dt.Rows[i]["gongjung"].ToString(), view,null });

        }

        void DB_DTSet()
        {
            String[] DB_Item = new String[] {
                "row_id", "string",
                "class", "string",
                "wondan_kind", "string",
                "kind_code", "string",
                "company", "string",
                "wondan_no", "string",
                "picture", "string",
                "price_name", "string",
                "price_cd", "string",
                "gongjung", "string",
                "default_value", "string"};


            String[] View_Item = new String[] {
                "row_id",   "string",
                "chk",      "bool",
                "No",       "int",
                "class",    "string",
                "wondan_kind", "string",
                "kind_code","string",
                "company",  "string",
                "wondan_no","string",
                "price_name",    "string",
                "price_cd",  "string",
                "default_value", "bool",
                "gongjung", "string",
                "button",   "string",
                "view",     "button"};

            GridHandle.DataTableInit(DB_Item, View_Item);

        }

        private void bAdd_Click(object sender, EventArgs e)
        {
            GridHandle.View_dt.ColumnChanging -= new DataColumnChangeEventHandler(custTable_ColumnChanging);

            cQuery = " insert into " + DB_TableName + " ( class, picture)";
            cQuery += " values('',0)";

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

        private void Form_505_FormClosing(object sender, FormClosingEventArgs e)
        {
           
        }

        private void bCopy_Click(object sender, EventArgs e)
        {
            string row_no = "";
            string temp = "";
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
                    ;//DataBase 상의 Data만 복사. Grid 갱신은 별도로 수행
                    
                    // Grid 화면 갱신
                    temp = GridHandle.OneDataCopy(DB_TableName, row_no);   // db 복사
                    GridHandle.OneFileCopy(DB_TableName, row_no, temp);  // file이 있으면 복사
                    

                    cQuery = "select a.*, b.citem as wondan_kind, c.hang as price_name from " + DB_TableName + " as a inner join C_cmodel as b";
                    cQuery += " on b.a_code='13' and b.b_code='01' and a.kind_code = b.c_code and a.row_id = " + temp + " left outer join hang_manage as c on ";
                    cQuery += " c.class='박원단그룹' and a.price_cd = c.code1 order by wondan_kind, wondan_no"; 

                    //cQuery = " select * from " + DB_TableName + " where row_id=" + temp;
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
                Del_Picture(GetRow[i], GetRowid[i]);
            }

            DBConn.Close();

            GridHandle.ChkDataDelete(DB_TableName, 0, 1);

            dataGrid1.Refresh();
            GridHandle.View_dt.ColumnChanging += new DataColumnChangeEventHandler(custTable_ColumnChanging);
        }

        public void Del_Picture(int select_row, string row_id)
        {
            FileControl FC = new FileControl();
            FC.FileControlInit(Config.DB_con1, Config.Ftp_ip1, Config.Ftp_id1, Config.Ftp_pw1);
            FC.OneFile2ManyRowId_Del(DB_TableName, "picture", row_id, "");

            GridHandle.View_dt.Rows[select_row][picture_column - 1] = false;

            //string Query = "update " + DB_TableName + " set picture = '' where row_id = '" + row_id + "'";
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
            // //   FC.FileDel(File_Path);// 다른 항목에서 그림을 참조하고 있지 않으면 File서버에서 삭제후 끝   
            //}
        }

        private void dataGrid1_Click(object sender, EventArgs e)
        {
            int select_row = dataGrid1.Selection.ActivePosition.Row;

            if (select_row < 0)
                return;

            if (dataGrid1.Selection.ActivePosition.Column == picture_column)
            {
                string row_no = GridHandle.View_dt.Rows[dataGrid1.Selection.ActivePosition.Row - 1][0].ToString();
                string Query = "select * from " + DB_TableName_file + " where int_id = '" + row_no + "' and db_nm = '" + DB_TableName + "'";
                MySqlConnection DBConn = new MySqlConnection(Config.DB_con1);

                DBConn.Open();
                MySqlDataReader myRead;

                var cmd = new MySqlCommand(Query, DBConn);
                myRead = cmd.ExecuteReader();

                if (!myRead.Read())
                {
                    myRead.Close();
                    DBConn.Close();
                    return;
                }

                string file_path = myRead["server_file"].ToString();
                myRead.Close();
                DBConn.Close();

                if (file_path == "")
                {
                    MessageBox.Show("등록된 사진이 없습니다");
                    DBConn.Close();
                    return;
                }
                else
                {
                    Form_305a Frm = new Form_305a(row_no, file_path, select_row, this, picture_column);
                    Frm.ShowDialog();
                }
                DBConn.Close();
            }
        }

        private void bPictureReg_Click(object sender, EventArgs e)
        {
            string temp = "row_id < 0 ";
            FileControl FC = new FileControl();
            FC.FileControlInit(Config.DB_con1, Config.Ftp_ip1, Config.Ftp_id1, Config.Ftp_pw1);

            string[] GetRowid = new string[GridHandle.View_dt.Rows.Count];
            int[] GetRow = new int[GridHandle.View_dt.Rows.Count];
            int i;
            for (i = 0; i < GetRowid.Length; i++)
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
                    temp += " or row_id = '" + GridHandle.View_dt.Rows[i][0].ToString().Trim() + "'";
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

            cbKindCode.Text = "";
            cbKindCode.Refresh();

            cbCompany.Text = "";
            cbCompany.Refresh();

            tbWondanNo.Text = "";
            tbWondanNo.Refresh();
        }

        private void bSearch_Click(object sender, EventArgs e)
        {
            string s1, s2, s3, s4, s5 = "";

            if (cbWondanKind.Text != "")
            {
                cQuery = "select * from C_cmodel where a_code = '13' and b_code='01' and citem = '" + cbWondanKind.Text.Trim() + "'";
                var DBConn = new MySqlConnection(Config.DB_con1);
                DBConn.Open();
                var cmd = new MySqlCommand(cQuery, DBConn);
                var myRead = cmd.ExecuteReader();

                if (myRead.Read())
                    s1 = "and a.kind_code = '" + myRead["c_code"].ToString() +"' ";
                else
                    s1 = "and a.kind_code = 'none_data' ";

                DBConn.Close();
            }
            else
                s1 = "";

            if (cbKindCode.Text != "")
            {
                s2 = " and a.kind_code ='" + cbKindCode.Text.Trim() + "' ";
            }
            else
                s2 = "";

            if (cbCompany.Text != "")
            {
                s3 = " and a.company ='" + cbCompany.Text.Trim() + "' ";
            }
            else
                s3 = "";

            if (tbWondanNo.Text != "")
            {
                s4 = " and a.wondan_no like '%" + tbWondanNo.Text.Trim() + "%' ";
            }
            else
                s4 = "";

            if (cbDangaCd.Text != "")
            {
                s5 = " and a.price_cd like '%" + cbDangaCd.Text.Trim() + "%' ";
            }
            else
                s5 = "";


            cQuery = "select a.*, b.citem as wondan_kind, c.hang as price_name from " + DB_TableName + " as a inner join C_cmodel as b";
            cQuery += " on b.a_code='13' and b.b_code='01' and a.kind_code = b.c_code " + s1 + s2 + s3 + s4 + s5 + "left outer join hang_manage as c on c.class='박원단그룹' and a.price_cd = c.code1 order by wondan_kind, wondan_no"; 



            //cQuery = "select * FROM " + DB_TableName;
            //cQuery += " where row_id is not null " + s1 + s2 + s3 + s4+s5;
            //cQuery += " order by wondan_kind, wondan_no";

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
                for (i = 0; i < GridHandle.View_dt.Rows.Count; i++)
                {
                    if (GetRowid[i] == "0")
                        break;
                    
                    Del_Picture(GetRow[i], GetRowid[i]);
                }

                GridHandle.ChkCancel(1);
            }

            DBConn.Close();
        }





    }
}
