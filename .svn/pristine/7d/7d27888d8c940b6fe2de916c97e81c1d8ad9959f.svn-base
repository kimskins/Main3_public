using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Security;
using System.Security.Cryptography;
using System.Windows.Forms;
using System.Data;
using System.Drawing;
using Excel = Microsoft.Office.Interop.Excel;
using System.Net.NetworkInformation;
using System.Drawing.Imaging;
using System.Drawing.Drawing2D;
using System.Text.RegularExpressions;
namespace Dukyou3
{
    class util1
    {
    }

    public struct Rect
    {
        public int Top;
        public int Bottom;
        public int Left;
        public int Right;
    }
    public class DataGridControl
    {
        public DataView mView;
        public DataTable DB_dt = new DataTable();  //DataBase에서 Select 해온 값
        public DataTable View_dt = new DataTable();  //Grid View에 보여줄 정렬되어 있는 값
        public SourceGrid.DataGrid dataGrid1;
        public int CbBoxNo = 0;
        public SourceGrid.Cells.Editors.ComboBox[] CbBox = new SourceGrid.Cells.Editors.ComboBox[20];
        public string DB_Con = "";
        public string FTP_ConIP = "";
        public string FTP_Id = "";
        public string FTP_Pw = "";
        MySqlConnection DBConn;

        //
        public DataGridControl()
        {

        }

        public void DataGrideInit(SourceGrid.DataGrid dGrid, string DB)
        {
            dataGrid1 = dGrid;
            dataGrid1.Columns.Clear();
            DB_Con = DB;
            DBConn = new MySqlConnection(DB_Con);
        }

        public void DataGrideInit(SourceGrid.DataGrid dGrid, string DB, string FTP_IP, string FTP_ID, string FTP_PW)
        {
            dataGrid1 = dGrid;
            dataGrid1.Columns.Clear();
            DB_Con = DB;
            FTP_ConIP = FTP_IP;
            FTP_Id = FTP_ID;
            FTP_Pw = FTP_PW;
            DBConn = new MySqlConnection(DB_Con);
        }
        /* ----------------------------------------------- *
        * Function : DataTableInit
        * 기능     : DataGrid에 사용될 두개의 DataTable 변수(1: DataBase에서 불러온 변수, 2: Grid에 보여질 변수)
        *            의 항목을 초기화
       -------------------------------------------------- */
        public void DataTableInit(String[] DbDtItem, String[] ViewDtItem)  // DB_dt = 실제 Select 해온 값, View_dt = Grid에 정리되어 뿌려질 값
        {
            DB_dt.Clear();
            View_dt.Clear();


            for (int i = 0; i < (DbDtItem.Length); i = i + 2)
            {
                if (DbDtItem[i].Equals("0") || DbDtItem[i + 1].Equals("0"))
                    break;

                if (DbDtItem[i + 1].Equals("bool"))
                    DB_dt.Columns.Add(DbDtItem[i], typeof(bool));
                else if (DbDtItem[i + 1].Equals("string"))
                    DB_dt.Columns.Add(DbDtItem[i], typeof(string));
                else if (DbDtItem[i + 1].Equals("int"))
                    DB_dt.Columns.Add(DbDtItem[i], typeof(int));
                else if (DbDtItem[i + 1].Equals("double"))
                    DB_dt.Columns.Add(DbDtItem[i], typeof(double));
                else if (DbDtItem[i + 1].Equals("float"))
                    DB_dt.Columns.Add(DbDtItem[i], typeof(float));
                else if (DbDtItem[i + 1].Equals("decimal"))
                    DB_dt.Columns.Add(DbDtItem[i], typeof(decimal));
                else if (DbDtItem[i + 1].Equals("button"))
                    DB_dt.Columns.Add(DbDtItem[i], typeof(Button));

            }

            for (int i = 0; i < (ViewDtItem.Length); i = i + 2)
            {
                if (ViewDtItem[i].Equals("0") || ViewDtItem[i + 1].Equals("0"))
                    break;

                if (ViewDtItem[i + 1].Equals("bool"))
                    View_dt.Columns.Add(ViewDtItem[i], typeof(bool));
                else if (ViewDtItem[i + 1].Equals("string"))
                    View_dt.Columns.Add(ViewDtItem[i], typeof(string));
                else if (ViewDtItem[i + 1].Equals("int"))
                    View_dt.Columns.Add(ViewDtItem[i], typeof(int));
                else if (ViewDtItem[i + 1].Equals("double"))
                    View_dt.Columns.Add(ViewDtItem[i], typeof(double));
                else if (ViewDtItem[i + 1].Equals("float"))
                    View_dt.Columns.Add(ViewDtItem[i], typeof(float));
                else if (ViewDtItem[i + 1].Equals("decimal"))
                {
                    View_dt.Columns.Add(ViewDtItem[i], typeof(decimal));
                }
                else if (ViewDtItem[i + 1].Equals("button"))
                    View_dt.Columns.Add(ViewDtItem[i], typeof(Button));

            }

        }

        private DataTable DB_Select(String Query, DataTable DT)
        {
            DBConn.Open();
            DT.Clear();
            MySqlDataAdapter returnVal = new MySqlDataAdapter(Query, DBConn);
            returnVal.Fill(DT);
            returnVal.Dispose();
            DBConn.Close();
            return DT;
        }

        public DataTable GetData(String Query)
        {
            DB_dt = DB_Select(Query, DB_dt);
            return DB_dt;
        }

        public void ViewDtClear()
        {
            View_dt.Clear();
        }

        /* ----------------------------------------------- *
        * Function : DataUpdate
        * 기능     : 전달받은 Query를 실행
       -------------------------------------------------- */
        public int DataUpdate(string Query)
        {
            DBConn.Open();
            var cmd = new MySqlCommand(Query, DBConn);


            if (cmd.ExecuteNonQuery() == 0)
            {
                DBConn.Close();
                return 1;
            }
            else
            {
                DBConn.Close();
                return 0;
            }
        }

        // /* ----------------------------------------------- *
        // * Function : DataRead
        // * 기능     : 전달받은 Query를 읽음
        //-------------------------------------------------- */
        // public MySqlDataReader DataRead(string Query)
        // {
        //     MySqlDataReader myRead;

        //     var cmd = new MySqlCommand(Query, DBConn);
        //     myRead = cmd.ExecuteReader();

        //     return myRead;
        // }
        /* ----------------------------------------------- *
        * Function : ChkDataDelete
        * 기능     : 체크된 항목의 DataBase를 삭제
        *            별도의 Grid 화면 갱신은 필요없음
       -------------------------------------------------- */
        public int ChkDataDelete(string DB_TableName, int row_id_position, int chkbox_position)
        {
            string row_no = "";
            string Query;
            string[] sd = new string[View_dt.Rows.Count];//
            for (int i = 0; i < sd.Length; i++)
            {
                sd[i] = "0";
            }
            //
            int s = 0;

            for (int i = 0; i < View_dt.Rows.Count; i++)
            {
                if (View_dt.Rows[i][chkbox_position].Equals(true))
                {
                    sd[s] = View_dt.Rows[i][row_id_position].ToString().Trim();
                    s++;
                }
            }
            //
            for (int i = 0; i < sd.Length; i++)
            {
                if (sd[i].Equals("0"))
                    break;
                else
                {
                    row_no = sd[i];
                    Query = " delete from " + DB_TableName + " where row_id='" + row_no + "'";
                    if (DataUpdate(Query) != 0)
                    {
                        MessageBox.Show("서버 자료 삭제에 실패 했습니다.");
                        return 1;
                    }

                }
            }
            //

            s = 0;
            int count = View_dt.Rows.Count;
            for (int i = 0; i < count; i++)
            {

                if (View_dt.Rows[s][chkbox_position].Equals(true))
                {
                    View_dt.Rows.RemoveAt(s);
                }
                else
                    s++;
            }

            //for (int i = 0; i < sd.Length; i++)
            //{
            //    if (sd[i].Equals("0"))
            //        break;
            //    else
            //    {
            //        for (s = 0; s < View_dt.Rows.Count; s++)
            //        {
            //            if (View_dt.Rows[s][row_id_position].Equals(sd[i]))
            //                View_dt.Rows.RemoveAt(s);
            //        }
            //    }
            //}

            return 0;
        }


        //public void FtpDataDel(int grid_file_position, int chkbox_position)  기존 아규먼트
        // ftp file만 지움. DB는 따로 지워야함
        public void FtpDataDel(int grid_file_position, int chkbox_position, string DB_TableName)
        {
            string[] sd = new string[View_dt.Rows.Count];//

            for (int i = 0; i < sd.Length; i++)
                sd[i] = "0";
            //
            int s = 0;
            for (int i = 0; i < View_dt.Rows.Count; i++)
                if (View_dt.Rows[i][chkbox_position].Equals(true))
                {
                    if (View_dt.Rows[i][grid_file_position].ToString() != "False" && View_dt.Rows[i][grid_file_position].ToString() != "false")
                    {
                        sd[s] = View_dt.Rows[i][grid_file_position].ToString().Trim();
                        s++;
                    }
                }

            for (int i = 0; i < sd.Length; i++)
            {
                if (sd[i].Equals("0"))
                    break;
                else
                {
                    OhFTP Ftp = new OhFTP(FTP_ConIP, FTP_Id, FTP_Pw);
                    Ftp.DeleteFile(sd[i], DB_TableName);
                }
            }
        }

        /* ----------------------------------------------- *
         * Function : ChkDataCopy_OneData
         * 기능     : 체크된 항목의 DataBase를 복사
         *            Grid 화면 갱신은 별도로 해야함
        -------------------------------------------------- */
        public string OneDataCopy(string DB_TableName, string row_no)
        {
            string row_id = "";
            string[] sd = new string[View_dt.Rows.Count];
            string Use_DB = "";
            if (DB_Con.IndexOf("DB_Center_2") > 0)
                Use_DB = "DB_Center_2";
            else if (DB_Con.IndexOf("DB_Local_2") > 0)
                Use_DB = "DB_Local_2";


            DBConn.Open();

            string Query = "";
            string field_1 = "";  // row_id 를 제외한 Table의 모든 field를 담을 변수

            Query = "SELECT `COLUMN_NAME` FROM `INFORMATION_SCHEMA`.`COLUMNS` WHERE `TABLE_SCHEMA`='" + Config.DB_name + "' AND `TABLE_NAME`='" + DB_TableName + "'";
            var cmd1 = new MySqlCommand(Query, DBConn);
            var myRead1 = cmd1.ExecuteReader();


            while (myRead1.Read())
            {
                if (myRead1["column_name"].ToString() != "row_id")
                {
                    field_1 += myRead1["column_name"].ToString().Trim() + ",";
                }
                //
            }
            myRead1.Close();
            DBConn.Close();

            field_1 = field_1.Substring(0, field_1.Length - 1);

            Query = "insert into " + DB_TableName + " (" + field_1 + ")  select " + field_1 + " from " + DB_TableName + " where row_id='" + row_no + "'";

            DBConn.Open();
            var cmd = new MySqlCommand(Query, DBConn);


            if (cmd.ExecuteNonQuery() == 0)
            {
                DBConn.Close();
                MessageBox.Show("서버 자료 삽입에 실패 했습니다.");
                return "";
            }
            else
            {
                Query = " select * from " + DB_TableName + " where row_id=(SELECT LAST_INSERT_ID())";
                cmd = new MySqlCommand(Query, DBConn);
                var myRead = cmd.ExecuteReader();
                myRead.Read();
                row_id = myRead["row_id"].ToString();
                myRead.Close();
                DBConn.Close();
                return row_id;
            }

        }

        public string OneFileCopy(string DB_TableName, string target_no, string row_no )
        {
            string row_id = "";
            string[] sd = new string[View_dt.Rows.Count];
            string Use_DB = "";
            string DB_TableName_file = DB_TableName.Substring(0, 1) + "_file_total_manage";
            if (DB_Con.IndexOf("DB_Center_2") > 0)
                Use_DB = "DB_Center_2";
            else if (DB_Con.IndexOf("DB_Local_2") > 0)
                Use_DB = "DB_Local_2";


            DBConn.Open();

            string Query = "";
            string field_1 = "";  // row_id 를 제외한 Table의 모든 field를 담을 변수

            Query = "SELECT `COLUMN_NAME` FROM `INFORMATION_SCHEMA`.`COLUMNS` WHERE `TABLE_SCHEMA`='" + Config.DB_name + "' AND `TABLE_NAME`='" + DB_TableName_file + "'";
            var cmd1 = new MySqlCommand(Query, DBConn);
            var myRead1 = cmd1.ExecuteReader();


            while (myRead1.Read())
            {
                if (myRead1["column_name"].ToString() != "row_id")
                {
                    field_1 += myRead1["column_name"].ToString().Trim() + ",";
                }
                //
            }
            myRead1.Close();
            DBConn.Close();

            field_1 = field_1.Substring(0, field_1.Length - 1);

            Query = "insert into " + DB_TableName_file + " (" + field_1 + ")  select " + field_1 + " from " + DB_TableName_file + " where db_nm = '" + DB_TableName + "' and int_id='" + target_no + "'";

            DBConn.Open();
            var cmd = new MySqlCommand(Query, DBConn);


            if (cmd.ExecuteNonQuery() == 0)
            {
                DBConn.Close();
                MessageBox.Show("서버 자료 삽입에 실패 했습니다.");
                return "";
            }
            else
            {
                Query = " select * from " + DB_TableName_file + " where row_id=(SELECT LAST_INSERT_ID())";
                cmd = new MySqlCommand(Query, DBConn);
                var myRead = cmd.ExecuteReader();
                myRead.Read();
                row_id = myRead["row_id"].ToString();
                myRead.Close();
                DBConn.Close();

                Query = "update " + DB_TableName_file + " set int_id = " + row_no + " where row_id = " + row_id;
                DataUpdate(Query);
                return row_id;
            }

        }

        /* ----------------------------------------------- *
         * Function : InputComboItem
         * 기능     : DataGrid에서 사용하는 ComboBox에 Item을 삽입
        -------------------------------------------------- */
        public void InputComboItem(String[] Item)
        {
            CbBox[CbBoxNo] = new SourceGrid.Cells.Editors.ComboBox(typeof(string), Item, false);

            CbBox[CbBoxNo].EditableMode = SourceGrid.EditableMode.Focus | SourceGrid.EditableMode.AnyKey | SourceGrid.EditableMode.SingleClick;
            CbBoxNo++;
        }

        /* ----------------------------------------------- *
         * Function : PictureReg
         * 기능     : 파일 저장
        -------------------------------------------------- */
        //public string PictureReg(string NameRull, string DB_TableName, string ColumnName, string Row_id) 기존
        public string PictureReg(string NameRull, string DB_TableName, string ColumnName, string Row_id, string option)
        {
            string File_Table = DB_TableName.Substring(0, 1) + "_file_total_manage";
            OhFTP Ftp = new OhFTP(FTP_ConIP, FTP_Id, FTP_Pw);
            OpenFileDialog ofd = new OpenFileDialog();//파일열기
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
                FileInfo FI = new FileInfo(ff1);
                string UserFN = FI.Name;

                string Query = "insert into " + File_Table + " (db_nm, int_id, user_file, f_option) values('" + DB_TableName + "', '" + Row_id + "', '" + UserFN + "', '" + option + "')";
                DBConn.Open();
                var cmd = new MySqlCommand(Query, DBConn);

                if (cmd.ExecuteNonQuery() == 0)
                {
                    MessageBox.Show("서버 등록에 실패 했습니다.");
                    DBConn.Close();
                    return "";
                }
                Query = " SELECT LAST_INSERT_ID() as dd";
                cmd = new MySqlCommand(Query, DBConn);
                var myRead = cmd.ExecuteReader();
                myRead.Read();
                string Last_Id = myRead["dd"].ToString();
                string ff2 = Last_Id + NameRull;
                myRead.Close();
                DBConn.Close();

                ff2 += ofd.FileName.Substring(ofd.FileName.LastIndexOf("."), ofd.FileName.Length - ofd.FileName.LastIndexOf("."));
                Ftp.UpLoadFile(ff1, ff2, DB_TableName);
                //
                Query = " update " + File_Table + " set server_file='" + ff2 + "' where row_id='" + Last_Id + "'";

                if (DataUpdate(Query) != 0)
                    MessageBox.Show("서버 등록에 실패 했습니다.");

                Query = " update " + DB_TableName + " set " + ColumnName + "='1' where row_id='" + Row_id + "'";

                if (DataUpdate(Query) != 0)
                    MessageBox.Show("서버 등록에 실패 했습니다.");

                return ff2;

            }
            return "";
        }

        public void ComboBoxItemInsert(string DB_TableName, string Column, ComboBox cbBox)
        {
            string cQuery = "select distinct " + Column + " from " + DB_TableName;
            DBConn.Open();

            var cmd1 = new MySqlCommand(cQuery, DBConn);
            var myRead1 = cmd1.ExecuteReader();
            string[] item = new string[10];

            for (int i = 0; i < 10; i++)
                item[i] = "0";


            while (myRead1.Read())
            {
                cbBox.Items.Add(myRead1[Column].ToString().Trim());

            }
            cbBox.Items.Add("");
            myRead1.Close();
            DBConn.Close();
        }

        public void ComboBoxItemInsert(string DB_TableName, string Column, ComboBox cbBox, string cQuery)
        {
            DBConn.Open();

            var cmd1 = new MySqlCommand(cQuery, DBConn);
            var myRead1 = cmd1.ExecuteReader();
            string[] item = new string[10];

            for (int i = 0; i < 10; i++)
                item[i] = "0";


            while (myRead1.Read())
            {
                cbBox.Items.Add(myRead1[Column].ToString().Trim());

            }
            cbBox.Items.Add("");
            myRead1.Close();
            DBConn.Close();
        }

        public string decimaldel(string num)
        {
            int declength = num.Substring(num.IndexOf(".") + 1).Length;
            int dot = num.IndexOf("."); // . 이 있는 위치 추출

            if (dot == -1)
                return num;

            int jungsu = Int32.Parse(num.Substring(0, dot)); //정수 부분만 추출
            int sosu = Int32.Parse(num.Substring(dot + 1)); //소수 부분만 추출
            int temp = 0;

            int OriSosuLen = num.Substring(dot + 1).Length;
            int AfterSosuLen = sosu.ToString().Length;

            string Zero = "";

            switch (OriSosuLen - AfterSosuLen)
            {
                case 1:
                    Zero = "0";
                    break;
                case 2:
                    Zero = "00";
                    break;
                case 3:
                    Zero = "000";
                    break;
                case 4:
                    Zero = "0000";
                    break;
                default:
                    Zero = "";
                    break;

            }

            if (sosu == 0)
                return jungsu.ToString();
            else
            {
                for (int i = 0; i < declength; i++)
                {
                    temp = sosu / 10;
                    if (temp * 10 == sosu)
                        sosu = sosu / 10;
                    else
                        break;
                }
            }

            return jungsu.ToString() + "." + Zero + sosu.ToString();


        }

        public string[] GetChkRowid(int chkbox_position, int row_id_position)
        {
            string[] sd = new string[View_dt.Rows.Count];//

            for (int i = 0; i < sd.Length; i++)
                sd[i] = "0";
            //
            int s = 0;
            for (int i = 0; i < View_dt.Rows.Count; i++)
                if (View_dt.Rows[i][chkbox_position].Equals(true))
                {
                    sd[s] = View_dt.Rows[i][row_id_position].ToString().Trim();
                    s++;
                }

            return sd;
        }

        public void ChkCancel(int chkbox_position)
        {

            for (int i = 0; i < View_dt.Rows.Count; i++)
            {
                if (View_dt.Rows[i][chkbox_position].Equals(true))
                {
                    View_dt.Rows[i][chkbox_position] = false;
                }
            }

            return;
        }

        public void ChkCheckAll(int chkbox_position)
        {
            for (int i = 0; i < View_dt.Rows.Count; i++)
            {
                if (View_dt.Rows[i][chkbox_position].Equals(false))
                {
                    View_dt.Rows[i][chkbox_position] = true;
                }
            }

            return;
        }
    }

    class SourceGridControl
    {
        public SourceGrid.Grid grid;
        string DB_Con = "";
        MySqlConnection DBConn;
        public int CbBoxNo = 0;
        public SourceGrid.Cells.Editors.ComboBox[] CbBox = new SourceGrid.Cells.Editors.ComboBox[20];

        string FTP_ConIP = "";
        string FTP_Id = "";
        string FTP_Pw = "";
        public SourceGridControl()
        {
        }

        public void SourceGrideInit(SourceGrid.Grid sGrid, string DB)
        {
            grid = sGrid;
            DB_Con = DB;
            DBConn = new MySqlConnection(DB_Con);
        }

        public void SourceGrideInit(SourceGrid.Grid sGrid, string DB, string FTP_IP, string FTP_ID, string FTP_PW)
        {
            grid = sGrid;
            DB_Con = DB;
            FTP_ConIP = FTP_IP;
            FTP_Id = FTP_ID;
            FTP_Pw = FTP_PW;
            DBConn = new MySqlConnection(DB_Con);
        }

        public void InputComboItem(String[] Item)
        {
         
            CbBox[CbBoxNo] = new SourceGrid.Cells.Editors.ComboBox(typeof(string), Item, false);

            CbBox[CbBoxNo].EditableMode = SourceGrid.EditableMode.AnyKey | SourceGrid.EditableMode.SingleClick;
            CbBoxNo++;
        }

        /* ----------------------------------------------- *
       * Function : grid_area
       * 기능     : gird 내부 이외 선택 방지
         * sender = sender 입력
         * e = e입력
       -------------------------------------------------- */

        public bool grid_area(object sender, MouseEventArgs e)
        {
            Rect ChkArea = new Rect();
            int temp = 0;
            for (int i = 0; i < grid.ColumnsCount; i++)
            {
                if (grid.Columns[i].Visible == true)
                {
                    temp = temp + grid.Columns[i].Width;
                }

            }
            if (grid.RowsCount == 1)
                return false;
            else
            {
                ChkArea.Top = grid.Rows[0].Height;    //왼쪽위 y축 (ColumnsCount의 높이)
                ChkArea.Left = grid.Location.X;   //왼쪽 x축(그리드 왼쪽)
                ChkArea.Bottom = (grid.RowsCount - 1) * grid.Rows[1].Height + grid.Rows[0].Height;  //아래쪽 y축 
                ChkArea.Right = temp;

                //ChkArea.Right = grid.Location.X + grid.Size.Width; //오른쪽 x축 (그리드 오른쪽 값)

                int m_x = e.X;
                int m_y = e.Y;
                if (m_x > ChkArea.Left && m_x < ChkArea.Right && m_y > ChkArea.Top && m_y < ChkArea.Bottom)  // 그리드 클릭
                    return true;
                else
                    return false;
            }
        }

        public string OneDataCopy(string DB_TableName, string row_no)
        {
            MySqlConnection DBConn;
            DBConn = new MySqlConnection(Config.DB_con1);
            string row_id = "";
            //if (DB_Con.IndexOf("DB_Center_2") > 0)
            //    Use_DB = "DB_Center_2";
            //else if (DB_Con.IndexOf("DB_Local_2") > 0)
            //    Use_DB = "DB_Local_2";

            string Query = "";
            string field_1 = "";  // row_id 를 제외한 Table의 모든 field를 담을 변수

            DBConn.Open();
            Query = "SELECT `COLUMN_NAME` FROM `INFORMATION_SCHEMA`.`COLUMNS` WHERE `TABLE_SCHEMA`='" + Config.DB_name + "' AND `TABLE_NAME`='" + DB_TableName + "'";
            var cmd1 = new MySqlCommand(Query, DBConn);
            var myRead1 = cmd1.ExecuteReader();


            while (myRead1.Read())
            {
                if (myRead1["column_name"].ToString() != "row_id")
                {
                    field_1 += myRead1["column_name"].ToString().Trim() + ",";
                }
                //
            }
            myRead1.Close();
            DBConn.Close();
            field_1 = field_1.Substring(0, field_1.Length - 1);

            Query = "insert into " + DB_TableName + " (" + field_1 + ")  select " + field_1 + " from " + DB_TableName + " where row_id='" + row_no + "'";

            DBConn.Open();
            var cmd = new MySqlCommand(Query, DBConn);


            if (cmd.ExecuteNonQuery() == 0)
            {
                DBConn.Close();
                MessageBox.Show("서버 자료 삽입에 실패 했습니다.");
                return "";
            }
            else
            {
                Query = " select * from " + DB_TableName + " where row_id=(SELECT LAST_INSERT_ID())";
                cmd = new MySqlCommand(Query, DBConn);
                var myRead = cmd.ExecuteReader();
                myRead.Read();
                row_id = myRead["row_id"].ToString();
                myRead.Close();
                DBConn.Close();
                return row_id;
            }

        }


        public void ChkDataDelete(string DB_TableName, int first_data_row, int row_id_position, int chkbox_position)
        {
            string[] sd = new string[grid.RowsCount];//

            for (int i = 0; i < sd.Length; i++)
                sd[i] = "0";
            //
            int s = first_data_row;
            for (int i = first_data_row; i < grid.RowsCount; i++)
                if (grid[i, chkbox_position].Value.Equals(true))
                {
                    sd[s] = grid[i, row_id_position].Value.ToString().Trim();
                    s++;
                }

            //  DB 삭제
            DBConn.Open();
            //
            for (int i = first_data_row; i < sd.Length; i++)
            {
                if (sd[i].Equals("0"))
                    break;
                else
                {
                    string row_no = sd[i];
                    string cQuery = " delete from " + DB_TableName + " where row_id='" + row_no + "'";
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

            s = first_data_row;
            int count = grid.RowsCount;
            for (int i = first_data_row; i < count; i++)
            {
                if (grid[s, chkbox_position].Value.Equals(true))
                {
                    grid.Rows.Remove(s);
                }
                else
                    s++;
            }

            if (grid.RowsCount > 1)
            {
                grid.Selection.FocusFirstCell(true);
            }
        }

        public void ChkCheckAll(int chkbox_position)
        {
            for (int i = 0; i < grid.RowsCount; i++)
            {
                if (grid[i, chkbox_position].Value.Equals(false))
                {
                    grid[i, chkbox_position] = new SourceGrid.Cells.CheckBox(null, true);
                }
            }
            grid.Refresh();
            return;
        }

        public void ChkCancel(int chkbox_position)
        {

            for (int i = 1; i < grid.RowsCount; i++)
            {
                if (grid[i, chkbox_position].Value.Equals(true))
                {
                    grid[i, chkbox_position] = new SourceGrid.Cells.CheckBox(null, false);
                }
            }
            grid.Refresh();
            return;
        }

        public void OnlyOneChk(int chkbox_position, int Chk_row, int first_row)
        {
            int row_n = Chk_row;
            for (int i = first_row; i < grid.RowsCount; i++)
            {
                if (i != row_n)
                    grid[i, chkbox_position].Value = false;
            }

            return;
        }


        public int ChkMoveUp(int first_data_row, int chkbox_position, int row_id_position, int sort_no_position, string sort_column_name, int view_no_position, string Table_name, int[] MergeCol)
        {
            int before_row_id = 0;
            int before_no = 0;

            int now_row_id = 0;
            int now_no = 0;

            string Query = "";
            for (int i = first_data_row; i < grid.RowsCount; i++)
            {
                if (grid[i, chkbox_position].Value.Equals(true))
                {
                    if (i == first_data_row)
                    {
                        MessageBox.Show("맨 첫 데이터를 위로 이동할순 없습니다");
                        return 1;
                    }
                    before_row_id = Convert.ToInt32(grid[i - 1, row_id_position].Value.ToString());
                    before_no = Convert.ToInt32(grid[i - 1, sort_no_position].Value.ToString());

                    now_row_id = Convert.ToInt32(grid[i, row_id_position].Value.ToString());
                    now_no = Convert.ToInt32(grid[i, sort_no_position].Value.ToString());

                    Query = "update " + Table_name + " set "+sort_column_name+" = " + before_no + " where row_id = " + now_row_id;
                    DataUpdate(Query);
                    Query = "update " + Table_name + " set "+sort_column_name+" = " + now_no + " where row_id = " + before_row_id;
                    DataUpdate(Query);
                    GridUpDownChange(i - 1, i, sort_no_position, view_no_position, MergeCol);

                }
            }
            grid.Refresh();
            return 0;
        }

        public int ChkMoveUp(int first_data_row, int chkbox_position, int row_id_position, int sort_no_position, string sort_column_name, int view_no_position, string Table_name)
        {
            int before_row_id = 0;
            int before_no = 0;

            int now_row_id = 0;
            int now_no = 0;

            string Query = "";
            for (int i = first_data_row; i < grid.RowsCount; i++)
            {
                if (grid[i, chkbox_position].Value.Equals(true))
                {
                    if (i == first_data_row)
                    {
                        MessageBox.Show("맨 첫 데이터를 위로 이동할순 없습니다");
                        return 1;
                    }
                    before_row_id = Convert.ToInt32(grid[i - 1, row_id_position].Value.ToString());
                    before_no = Convert.ToInt32(grid[i - 1, sort_no_position].Value.ToString());

                    now_row_id = Convert.ToInt32(grid[i, row_id_position].Value.ToString());
                    now_no = Convert.ToInt32(grid[i, sort_no_position].Value.ToString());

                    Query = "update " + Table_name + " set " + sort_column_name + " = " + before_no + " where row_id = " + now_row_id;
                    DataUpdate(Query);
                    Query = "update " + Table_name + " set " + sort_column_name + " = " + now_no + " where row_id = " + before_row_id;
                    DataUpdate(Query);
                    GridUpDownChange(i - 1, i, sort_no_position, view_no_position);

                }
            }
            grid.Refresh();
            return 0;
        }

        private void GridUpDownChange(int Grid_row1, int Grid_row2, int sort_no_position, int view_no_position)
        {
            cell_d cc = new cell_d();
            int now_row = Grid_row1;
            int before_row = Grid_row2;

            int column_no = grid.ColumnsCount;
            int swap_int;
            string swap_string;
            decimal swap_deci;
            double swap_double;
            Boolean swap_bool;

            string type = "";

            for (int i = 0; i < column_no; i++)
            {
                if (grid[now_row, i].Value != null)
                    type = grid[now_row, i].Value.GetType().Name.Substring(0, 3);
                else
                {
                    grid[now_row, i] = new SourceGrid.Cells.Cell(" ", typeof(string));
                    type = "Str";
                }

                if (i != sort_no_position && i != view_no_position)
                {
                    if (type == "Int")
                    {
                        swap_int = Convert.ToInt32(grid[now_row, i].Value.ToString());
                        try
                        {
                            grid[now_row, i] = new SourceGrid.Cells.Cell(Convert.ToInt32(grid[before_row, i].Value), typeof(int));
                        }
                        catch
                        {
                            grid[now_row, i] = new SourceGrid.Cells.Cell("", typeof(int));
                        }
                        grid[now_row, i].View = grid[before_row, i].View;
                        grid[now_row, i].Editor = grid[before_row, i].Editor;

                        grid[before_row, i] = new SourceGrid.Cells.Cell(swap_int, typeof(int));
                        grid[before_row, i].View = grid[now_row, i].View;
                        grid[before_row, i].Editor = grid[now_row, i].Editor;
                    }
                    else if (type == "Str")
                    {
                        swap_string = grid[now_row, i].Value.ToString();
                        grid[now_row, i] = new SourceGrid.Cells.Cell(grid[before_row, i].Value, typeof(string));
                        grid[now_row, i].View = grid[before_row, i].View;
                        grid[now_row, i].Editor = grid[before_row, i].Editor;
                        grid[before_row, i] = new SourceGrid.Cells.Cell(swap_string, typeof(string));
                        grid[before_row, i].View = grid[now_row, i].View;
                        grid[before_row, i].Editor = grid[now_row, i].Editor;
                    }
                    else if (type == "Dec")
                    {
                        string temp = "";

                        swap_deci = Convert.ToDecimal(grid[now_row, i].Value.ToString());
                        try
                        {
                            temp = decimaldel(Convert.ToDecimal(grid[before_row, i].Value).ToString());
                            grid[now_row, i] = new SourceGrid.Cells.Cell(Convert.ToDecimal(temp), typeof(string));
                        }
                        catch
                        {
                            grid[now_row, i] = new SourceGrid.Cells.Cell("", typeof(string));
                        }
                        grid[now_row, i].View = grid[before_row, i].View;
                        grid[now_row, i].Editor = grid[before_row, i].Editor;

                        temp = decimaldel(swap_deci.ToString());
                        grid[before_row, i] = new SourceGrid.Cells.Cell(Convert.ToDecimal(temp), typeof(string));
                        grid[before_row, i].View = grid[now_row, i].View;
                        grid[before_row, i].Editor = grid[now_row, i].Editor;

                    }
                    else if (type == "Dou")
                    {
                        swap_double = Convert.ToDouble(grid[now_row, i].Value.ToString());
                        try
                        {
                            grid[now_row, i] = new SourceGrid.Cells.Cell(Convert.ToDouble(grid[before_row, i].Value), typeof(double));
                        }
                        catch
                        {
                            grid[now_row, i] = new SourceGrid.Cells.Cell("", typeof(double));
                        }
                        
                        grid[now_row, i].View = grid[before_row, i].View;
                        grid[now_row, i].Editor = grid[before_row, i].Editor;
                        grid[before_row, i] = new SourceGrid.Cells.Cell(swap_double, typeof(double));
                        grid[before_row, i].View = grid[now_row, i].View;
                        grid[before_row, i].Editor = grid[now_row, i].Editor;
                    }
                    else if (type == "Boo")
                    {
                        swap_bool = Convert.ToBoolean(grid[now_row, i].Value.ToString());
                        try
                        {
                            grid[now_row, i] = new SourceGrid.Cells.CheckBox(null, Convert.ToBoolean(grid[before_row, i].Value));
                        }
                        catch
                        {
                            grid[now_row, i] = new SourceGrid.Cells.CheckBox(null, false);
                        }
                        
                        grid[now_row, i].View = grid[before_row, i].View;
                        grid[now_row, i].Editor = grid[before_row, i].Editor;
                        grid[before_row, i] = new SourceGrid.Cells.CheckBox(null, swap_bool);
                        grid[before_row, i].View = grid[now_row, i].View;
                        grid[before_row, i].Editor = grid[now_row, i].Editor;
                    }
                }
                
            }
        }

        private void GridUpDownChange(int Grid_row1, int Grid_row2, int sort_no_position, int view_no_position, int[] MergeCol)
        {
            cell_d cc = new cell_d();
            int now_row = Grid_row1;
            int before_row = Grid_row2;

            int column_no = grid.ColumnsCount;
            int swap_int;
            string swap_string;
            decimal swap_deci;
            double swap_double;
            Boolean swap_bool;

            string type = "";
            int pp = 0;

            for (int i = 0; i < column_no; i++)
            {
                if (i != MergeCol[pp])  ////  합병된 셀은 좌/우 측이 있을때 우측 셀 번호를 입력
                {
                    type = grid[now_row, i].Value.GetType().Name.Substring(0, 3);

                    if (i != sort_no_position && i != view_no_position)
                    {
                        if (type == "Int")
                        {
                            swap_int = Convert.ToInt32(grid[now_row, i].Value.ToString());
                            try
                            {
                                grid[now_row, i] = new SourceGrid.Cells.Cell(Convert.ToInt32(grid[before_row, i].Value), typeof(int));
                            }
                            catch
                            {
                                grid[now_row, i] = new SourceGrid.Cells.Cell("", typeof(int));
                            }
                            
                            grid[now_row, i].View = cc.int_cell;
                            grid[now_row, i].Editor = cc.int_editor;

                            grid[before_row, i] = new SourceGrid.Cells.Cell(swap_int, typeof(int));
                            grid[before_row, i].View = cc.int_cell;
                            grid[before_row, i].Editor = cc.int_editor;

                            if (i == MergeCol[pp] - 1)
                            {
                                grid[before_row, i].ColumnSpan = 2;
                                grid[now_row, i].ColumnSpan = 2;
                            }
                        }
                        else if (type == "Str")
                        {
                            swap_string = grid[now_row, i].Value.ToString();
                            grid[now_row, i] = new SourceGrid.Cells.Cell(grid[before_row, i].Value, typeof(string));
                            grid[before_row, i] = new SourceGrid.Cells.Cell(swap_string, typeof(string));
                            if (i == MergeCol[pp] - 1)
                            {
                                grid[before_row, i].ColumnSpan = 2;
                                grid[now_row, i].ColumnSpan = 2;
                            }
                        }
                        else if (type == "Dec")
                        {
                            string temp = "";

                            swap_deci = Convert.ToDecimal(grid[now_row, i].Value.ToString());

                            try
                            {
                                temp = decimaldel(Convert.ToDecimal(grid[before_row, i].Value).ToString());
                                grid[now_row, i] = new SourceGrid.Cells.Cell(Convert.ToDecimal(temp), typeof(string));
                            }
                            catch
                            {
                                grid[now_row, i] = new SourceGrid.Cells.Cell("", typeof(string));
                            }
                            
                            grid[now_row, i].View = cc.int_cell;
                            //grid[now_row, i].Editor = cc.decimal_editor;

                            temp = decimaldel(swap_deci.ToString());
                            grid[before_row, i] = new SourceGrid.Cells.Cell(Convert.ToDecimal(temp), typeof(string));
                            grid[before_row, i].View = cc.int_cell;
                            //grid[before_row, i].Editor = cc.decimal_editor;

                            if (i == MergeCol[pp] - 1)
                            {
                                grid[before_row, i].ColumnSpan = 2;
                                grid[now_row, i].ColumnSpan = 2;
                            }

                        }
                        else if (type == "Dou")
                        {
                            swap_double = Convert.ToDouble(grid[now_row, i].Value.ToString());
                            try
                            {
                                grid[now_row, i] = new SourceGrid.Cells.Cell(Convert.ToDouble(grid[before_row, i].Value), typeof(double));
                            }
                            catch
                            {
                                grid[now_row, i] = new SourceGrid.Cells.Cell("", typeof(double));
                            }
                            
                            grid[before_row, i] = new SourceGrid.Cells.Cell(swap_double, typeof(double));

                            if (i == MergeCol[pp] - 1)
                            {
                                grid[before_row, i].ColumnSpan = 2;
                                grid[now_row, i].ColumnSpan = 2;
                            }
                        }
                        else if (type == "Boo")
                        {
                            swap_bool = Convert.ToBoolean(grid[now_row, i].Value.ToString());
                            try
                            {
                                grid[now_row, i] = new SourceGrid.Cells.CheckBox(null, Convert.ToBoolean(grid[before_row, i].Value));
                            }
                            catch
                            {
                                grid[now_row, i] = new SourceGrid.Cells.CheckBox(null, false);
                            }
                            
                            grid[before_row, i] = new SourceGrid.Cells.CheckBox(null, swap_bool);

                            if (i == MergeCol[pp] - 1)
                            {
                                grid[before_row, i].ColumnSpan = 2;
                                grid[now_row, i].ColumnSpan = 2;
                            }
                        }
                    }
                }
                else
                {
                    pp++;
                }
            }
        }

        public int ChkMoveDown(int first_data_row, int chkbox_position, int row_id_position, int sort_no_position, string sort_column_name, int view_no_position, string Table_name, int[] MergeCol)
        {
            int before_row_id = 0;
            int before_no = 0;

            int now_row_id = 0;
            int now_no = 0;

            string Query = "";
            for (int i = grid.RowsCount - 1; i >= first_data_row; i--)
            {
                if (grid[i, chkbox_position].Value.Equals(true))
                {
                    if (i == grid.RowsCount - 1)
                    {
                        MessageBox.Show("맨 마지막 데이터를 아래로 이동할순 없습니다");
                        return 1;
                    }
                    before_row_id = Convert.ToInt32(grid[i + 1, row_id_position].Value.ToString());
                    before_no = Convert.ToInt32(grid[i + 1, sort_no_position].Value.ToString());

                    now_row_id = Convert.ToInt32(grid[i, row_id_position].Value.ToString());
                    now_no = Convert.ToInt32(grid[i, sort_no_position].Value.ToString());

                    Query = "update " + Table_name + " set " + sort_column_name + " = " + before_no + " where row_id = " + now_row_id;
                    DataUpdate(Query);
                    Query = "update " + Table_name + " set " + sort_column_name + " = " + now_no + " where row_id = " + before_row_id;
                    DataUpdate(Query);
                    GridUpDownChange(i + 1, i, sort_no_position, view_no_position, MergeCol);
                    grid.Refresh();

                }
            }
            return 0;
        }

        public int ChkMoveDown(int first_data_row, int chkbox_position, int row_id_position, int sort_no_position, string sort_column_name, int view_no_position, string Table_name)
        {
            int before_row_id = 0;
            int before_no = 0;

            int now_row_id = 0;
            int now_no = 0;

            string Query = "";
            for (int i = grid.RowsCount - 1; i >= first_data_row; i--)
            {
                if (grid[i, chkbox_position].Value.Equals(true))
                {
                    if (i == grid.RowsCount - 1)
                    {
                        MessageBox.Show("맨 마지막 데이터를 아래로 이동할순 없습니다");
                        return 1;
                    }
                    before_row_id = Convert.ToInt32(grid[i + 1, row_id_position].Value.ToString());
                    before_no = Convert.ToInt32(grid[i + 1, sort_no_position].Value.ToString());

                    now_row_id = Convert.ToInt32(grid[i, row_id_position].Value.ToString());
                    now_no = Convert.ToInt32(grid[i, sort_no_position].Value.ToString());

                    Query = "update " + Table_name + " set "+sort_column_name+" = " + before_no + " where row_id = " + now_row_id;
                    DataUpdate(Query);
                    Query = "update " + Table_name + " set " + sort_column_name + " = " + now_no + " where row_id = " + before_row_id;
                    DataUpdate(Query);
                    GridUpDownChange(i + 1, i, sort_no_position, view_no_position);
                    grid.Refresh();

                }
            }
            return 0;
        }

        // ftp file만 지움. DB는 따로 지워야함
        public void FtpDataDel(int first_data_row, int grid_file_position, int chkbox_position, string DB_TableName)
        {
            string[] sd = new string[grid.RowsCount];//

            for (int i = 0; i < sd.Length; i++)
                sd[i] = "0";
            //
            int s = 0;
            for (int i = first_data_row; i < grid.RowsCount; i++)
                if (grid[i, chkbox_position].Value.Equals(true))
                {
                    //if (grid[i, grid_file_position].Value != null && grid[i, grid_file_position].Value.ToString() != "")
                    if (grid[i, grid_file_position].ToString() != "False" && grid[i, grid_file_position].Value.ToString() != "false")
                    {
                        sd[s] = grid[i, grid_file_position].Value.ToString().Trim();
                        s++;
                    }
                }

            for (int i = 0; i < sd.Length; i++)
            {
                if (sd[i].Equals("0"))
                    break;
                else
                {
                    OhFTP Ftp = new OhFTP(FTP_ConIP, FTP_Id, FTP_Pw);
                    Ftp.DeleteFile(sd[i], DB_TableName);
                }
            }
        }

        public int PictureRefresh(string picture_path, PictureBox PB, string server1_or_server2, string DB_TableName) // picturebox에 꽉차게 이미지 로드, 이미지가 늘어날수 있음
        {

            string FileName = picture_path;
            PictureBox pictureBox = PB;

            OhFTP Ftp;

            int return_value = 0;

            if (server1_or_server2 == "server1")
                Ftp = new OhFTP(Config.Ftp_ip1, Config.Ftp_id1, Config.Ftp_pw1);
            else
                Ftp = new OhFTP(Config.Ftp_ip2, Config.Ftp_id2, Config.Ftp_pw2);



            if (FileName != "")
            {
                Ftp.DownLoadFile(@"c:\temp\", FileName, DB_TableName);
                pictureBox.ImageLocation = @"c:\temp\" + FileName;
            }
            else
            {
                pictureBox.Image = null;
                return_value = 1;
            }
            pictureBox.Refresh();


            return return_value;
        }

        public int PictureRefresh2(PictureBox PB, string server1_or_server2, string DB_TableName, string option, string row_id) // 이미지에 맞게 picturebox 사이즈 변경. 이미지 원본 유지
        {
            PictureBox pictureBox = PB;
            string FileName = "";
            int return_value = 0;
            string File_Table = DB_TableName.Substring(0, 1) + "_file_total_manage";

            DBConn.Open();
            string Query = "select * from " + File_Table + " where db_nm='" + DB_TableName + "' and int_id = '" + row_id + "'";

            var cmd = new MySqlCommand(Query, DBConn);
            var myRead = cmd.ExecuteReader();
            if (!myRead.Read())
            {
                pictureBox.Image = null;
                return_value = 1;
                DBConn.Close();
                return return_value;
            }

            FileName = myRead["server_file"].ToString();
            OhFTP Ftp;

            if (server1_or_server2 == "server1")
                Ftp = new OhFTP(Config.Ftp_ip1, Config.Ftp_id1, Config.Ftp_pw1);
            else
                Ftp = new OhFTP(Config.Ftp_ip2, Config.Ftp_id2, Config.Ftp_pw2);

            if (FileName != "")
            {
                Ftp.DownLoadFile(@"c:\temp\", FileName, DB_TableName);

                Image imgFromFile = Image.FromFile(@"c:\temp\" + FileName);
                pictureBox.Width = imgFromFile.Width;
                pictureBox.Height = imgFromFile.Height;

                pictureBox.ImageLocation = @"c:\temp\" + FileName;
                imgFromFile.Dispose();
                //Image imgFromFile = resizeImage(pictureBox.Width, pictureBox.Height, @"c:\temp\" + FileName);
                //pictureBox.Image = imgFromFile;

            }
            else
            {
                pictureBox.Image = null;
                return_value = 1;
            }
            pictureBox.Refresh();

            DBConn.Close();
            return return_value;
        }

        private Image resizeImage(int newWidth, int newHeight, string stPhotoPath)
        {
            Image imgPhoto = Image.FromFile(stPhotoPath);

            int sourceWidth = imgPhoto.Width;
            int sourceHeight = imgPhoto.Height;

            //Consider vertical pics
            if (sourceWidth < sourceHeight)
            {
                int buff = newWidth;

                newWidth = newHeight;
                newHeight = buff;
            }

            int sourceX = 0, sourceY = 0, destX = 0, destY = 0;
            float nPercent = 0, nPercentW = 0, nPercentH = 0;

            nPercentW = ((float)newWidth / (float)sourceWidth);
            nPercentH = ((float)newHeight / (float)sourceHeight);
            if (nPercentH < nPercentW)
            {
                nPercent = nPercentH;
                destX = System.Convert.ToInt16((newWidth -
                          (sourceWidth * nPercent)) / 2);
            }
            else
            {
                nPercent = nPercentW;
                destY = System.Convert.ToInt16((newHeight -
                          (sourceHeight * nPercent)) / 2);
            }

            int destWidth = (int)(sourceWidth * nPercent);
            int destHeight = (int)(sourceHeight * nPercent);


            Bitmap bmPhoto = new Bitmap(newWidth, newHeight, PixelFormat.Format24bppRgb);

            bmPhoto.SetResolution(imgPhoto.HorizontalResolution,
                         imgPhoto.VerticalResolution);

            Graphics grPhoto = Graphics.FromImage(bmPhoto);
            grPhoto.Clear(Color.Black);
            grPhoto.InterpolationMode = InterpolationMode.HighQualityBicubic;

            grPhoto.DrawImage(imgPhoto,
                new Rectangle(destX, destY, destWidth, destHeight),
                new Rectangle(sourceX, sourceY, sourceWidth, sourceHeight),
                GraphicsUnit.Pixel);

            grPhoto.Dispose();
            imgPhoto.Dispose();
            return bmPhoto;
        }


        public string[] GetChkRowid(int first_data_row, int chkbox_position, int row_id_position)
        {
            string[] sd = new string[grid.RowsCount];//

            for (int i = 0; i < sd.Length; i++)
                sd[i] = "0";
            //
            int s = 0;
            for (int i = first_data_row; i < grid.RowsCount; i++)
                if (grid[i, chkbox_position].Value.Equals(true))
                {
                    sd[s] = grid[i, row_id_position].Value.ToString().Trim();
                    s++;
                }

            return sd;
        }

        /* ----------------------------------------------- *
        * Function : DataUpdate
        * 기능     : 전달받은 Query를 실행
        -------------------------------------------------- */
        public int DataUpdate(string Query)
        {
            DBConn.Open();
            var cmd = new MySqlCommand(Query, DBConn);


            if (cmd.ExecuteNonQuery() == 0)
            {
                DBConn.Close();
                return 1; // 비정상
            }
            else
            {
                DBConn.Close();
                return 0; // 정상
            }
        }
        //public MySqlDataReader DataRead(string Query)
        //{
        //    DBConn.Open();
        //    MySqlDataReader myRead;

        //    var cmd = new MySqlCommand(Query, DBConn);
        //    myRead = cmd.ExecuteReader();

        //    return myRead;
        //}

        public string FileReg(string NameRull, string DB_TableName, string ColumnName, string Row_id, string option)
        {
            string File_Table = DB_TableName.Substring(0, 1) + "_file_total_manage";
            OhFTP Ftp = new OhFTP(FTP_ConIP, FTP_Id, FTP_Pw);
            OpenFileDialog ofd = new OpenFileDialog();//파일열기
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

                FileInfo FI = new FileInfo(ff1);
                string UserFN = FI.Name;

                string Query = "insert into " + File_Table + " (db_nm, int_id, user_file, f_option) values('" + DB_TableName + "', '" + Row_id + "', '" + UserFN + "', '" + option + "')";
                DBConn.Open();
                var cmd = new MySqlCommand(Query, DBConn);

                if (cmd.ExecuteNonQuery() == 0)
                {
                    MessageBox.Show("서버 등록에 실패 했습니다.");
                    DBConn.Close();
                    return "";
                }
                Query = " SELECT LAST_INSERT_ID() as dd";
                cmd = new MySqlCommand(Query, DBConn);
                var myRead = cmd.ExecuteReader();
                myRead.Read();
                string Last_Id = myRead["dd"].ToString();
                string ff2 = Last_Id + NameRull;
                myRead.Close();
                DBConn.Close();

                ff2 += ofd.FileName.Substring(ofd.FileName.LastIndexOf("."), ofd.FileName.Length - ofd.FileName.LastIndexOf("."));
                Ftp.UpLoadFile(ff1, ff2, DB_TableName);
                //
                Query = " update " + File_Table + " set server_file='" + ff2 + "' where row_id='" + Last_Id + "'";

                if (DataUpdate(Query) != 0)
                {
                    MessageBox.Show("서버 등록에 실패 했습니다.");
                    return "";
                }

                Query = " update " + DB_TableName + " set " + ColumnName + "='1' where row_id='" + Row_id + "'";  // Table에 사진 있음을 표시
                if (DataUpdate(Query) != 0)
                {
                    MessageBox.Show("서버 등록에 실패 했습니다.");
                    return "";
                }

                return ff2;

            }
            return "";
        }

        public string decimaldel(string num)
        {
            int declength = num.Substring(num.IndexOf(".") + 1).Length;
            int dot = num.IndexOf("."); // . 이 있는 위치 추출
            if (dot == -1)
                return num;

            string jungsu = num.Substring(0, dot); //정수 부분만 추출
            int sosu = Int32.Parse(num.Substring(dot + 1)); //소수 부분만 추출
            int temp = 0;

            int OriSosuLen = num.Substring(dot + 1).Length;
            int AfterSosuLen = sosu.ToString().Length;

            string Zero = "";

            switch (OriSosuLen - AfterSosuLen)
            {
                case 1:
                    Zero = "0";
                    break;
                case 2:
                    Zero = "00";
                    break;
                case 3:
                    Zero = "000";
                    break;
                case 4:
                    Zero = "0000";
                    break;
                default:
                    Zero = "";
                    break;

            }

            if (sosu == 0)
                return jungsu;
            else
            {
                for (int i = 0; i < declength; i++)
                {
                    temp = sosu / 10;
                    if (temp * 10 == sosu)
                        sosu = sosu / 10;
                    else
                        break;
                }
            }

            return jungsu + "." + Zero + sosu.ToString();


        }

        // input : 정수를 string 형으로 입력
        // ouput : 정수에 세자리 숫자마다 콤마 입력된 값을 string으로 return
        public string numgetcoma(string num)
        {
            int dot = num.IndexOf("."); // . 이 있는 위치 추출
            string sosu = "";
            string jungsu = "";
            if (dot > -1)
            {
                sosu = num.Substring(dot);
                jungsu = num.Substring(0, dot); //정수 부분만 추출
                jungsu = jungsu.Replace(",", "");
            }
            else
            {
                jungsu = num;
                jungsu = jungsu.Replace(",", "");
            }

            string comaNum = "";
            int len = jungsu.Length - 3;

            while (len >= -2)
            {
                if (len <= 0)
                {
                    comaNum = jungsu.Substring(0, 3 + len) + comaNum;
                }
                else
                {
                    comaNum = "," + jungsu.Substring(len, 3) + comaNum;
                }
                len = len - 3;
            }
            comaNum = comaNum + sosu;


            return comaNum;
        }


    }

    public class ksgcontrol
    {
        public string DB_Con = "";
        public string FTP_ConIP = "";
        public string FTP_Id = "";
        public string FTP_Pw = "";


        public void ControlInit(string DB, string FTP_IP, string FTP_ID, string FTP_PW)
        {
            DB_Con = DB;
            FTP_ConIP = FTP_IP;
            FTP_Id = FTP_ID;
            FTP_Pw = FTP_PW;
        }
        public void ComboBoxItemInsert(string DB_TableName, string Column, ComboBox cbBox)
        {
            string cQuery = "select distinct " + Column + " from " + DB_TableName;


            var DBConn = new MySqlConnection(DB_Con);
            DBConn.Open();
            var cmd1 = new MySqlCommand(cQuery, DBConn);
            var myRead1 = cmd1.ExecuteReader();
            string[] item = new string[10];

            for (int i = 0; i < 10; i++)
                item[i] = "0";


            while (myRead1.Read())
            {
                if(myRead1[Column].ToString().Trim() != "")
                    cbBox.Items.Add(myRead1[Column].ToString().Trim());

            }
            cbBox.Items.Add("");
            DBConn.Close();
            myRead1.Close();
        }

        public bool Email_Check(string email)
        {
            if (email.IndexOf("@") < 0 ||    // @ 가 없는 경우
                email.IndexOf(".") < 0 ||    // . 이 없는 경우
                email.IndexOf("@") != email.LastIndexOf("@") ||    // @ 2개 들어간경우
                email.IndexOf(".") != email.LastIndexOf(".") ||    // . 2개 들어간 경우
                email.IndexOf("@") > email.IndexOf(".") ||    //  lovesk.naver@com  인 경우
                email.IndexOf("@") == 0 ||    //  @naver.com   인 경우
                email.IndexOf("@") + 1 == email.IndexOf(".") ||    // lovesk@.com  인경우
                email.IndexOf(".") + 1 == email.Length             // lovesk@naver. 인경우
                )
            {
                return false;
            }
            return true;
        }
        public bool Sms_number_chk(string num)
        {
            if (num.Substring(0, 2) != "01")
                return false;
            string num_tem1 = Regex.Replace(num, @"\d", "");
            if (num_tem1 != "--")
                return false;
            string num_tem = num.Replace("-", "");
            num_tem = num_tem.Replace(" ", "");
            if (num_tem.Length != 11 && num_tem.Length != 10)
                return false;
            try
            {
                int temp = Convert.ToInt32(num_tem);
            }
            catch
            {
                return false;
            }

            return true;
        }
        public int SndSMS(string[] company_row_id, string txt, string send_num, string[] receive_num, string send_man, string[] receive_man, int sms_count, string file_path)
        {
            string DB_TableName_Sms = "L_sms_total_manage";
            //string receive_num_ = receive_num.Replace("-", "");
            //string send_num_ = send_num.Replace("-", "");

            //if (send_num_.Trim() == "")
            //{
            //    MessageBox.Show("발신번호를 입력하여 주세요.");
            //    return 1;
            //}

            bool xx;
            string mm = "";
            string Query = "";


            //mm = " s " + User.Sms_id + " " + User.Sms_pw + " 010 " + send_num_ + " \"" + txt + "\" now " + receive_man + ":" + receive_num_ + ";";
            //xx = util.RunExe(mm);
            sms sm = new sms();
            sm.main_send(company_row_id, receive_num, send_num, txt, send_man, sms_count, receive_man, file_path);

            //progbar pr = new progbar(receive_num, send_num, txt, receive_man, sms_count);
            //pr.ShowDialog();
            //bool ch = sm.send(receive_num, send_num, txt, receive_man, sms_count);
            //if (xx == false)
            //{
            //    MessageBox.Show("[" + receive_man + ":" + receive_num_ + "]발송에 실패 하였습니다.");
            //    return -1;
            //}
            //if (ch == true)
            //{
            //    if (User.ERP_MODE == true)
            //    {
            //        Query = "insert into " + DB_TableName_Sms + " (sms_txt, send_num, receive_num, sender, receiver, int_id, snd_time)";
            //        Query += " values('" + txt + "', '" + send_num_ + "', '" + receive_num_ + "', '" + send_man + "', '" + receive_man + "', '" + company_row_id + "', now())";
            //        DataUpdate(Query);
            //    }
            //}
            //}

            return 0;
            // 위 함수를 사용해서..
            // c:\xsms.exe s 아이디 암호 "내전화번호" "상대방에게표시될번호" "메세지내용" "time" "name1:010-0000-0000;이름:전화번호;" "MMS이미지경로"
            // 를  위 파라미터 함수로 전송하면 메세지나 이미지가 전송 됩니다.. --> 실행  util.RunExe("aaaa");
        }

        public void ComboBoxItemInsert(string Column, ComboBox cbBox, string cQuery)
        {
            cQuery = "select distinct(" + Column + ") as " + Column + " from (" + cQuery + ") as a";
            var DBConn = new MySqlConnection(DB_Con);
            DBConn.Open();
            var cmd1 = new MySqlCommand(cQuery, DBConn);
            var myRead1 = cmd1.ExecuteReader();
            string[] item = new string[10];

            for (int i = 0; i < 10; i++)
                item[i] = "0";


            while (myRead1.Read())
            {
                if (myRead1[Column].ToString().Trim() != "")
                    cbBox.Items.Add(myRead1[Column].ToString().Trim());

            }

            DBConn.Close();
            myRead1.Close();
        }

        public string GetMacAddr()
        {
            string strMacAddress = "";
            NetworkInterface[] adapters = NetworkInterface.GetAllNetworkInterfaces();
            foreach (NetworkInterface adapter in adapters)
            {
                PhysicalAddress pa = adapter.GetPhysicalAddress();
                if (pa != null && !pa.ToString().Equals(""))
                {
                    strMacAddress = pa.ToString();
                    break;
                }
            }
            return strMacAddress;
        }
        public string DBCopy(string DB_TableName, string row_no)
        {
            string Use_DB = "";
            if (DB_Con.IndexOf("DB_Center_2") > 0)
                Use_DB = "DB_Center_2";
            else if (DB_Con.IndexOf("DB_Local_2") > 0)
                Use_DB = "DB_Local_2";

            string Query = "";
            string field_1 = "";  // row_id 를 제외한 Table의 모든 field를 담을 변수

            var DBConn = new MySqlConnection(DB_Con);
            DBConn.Open();
            Query = "SELECT `COLUMN_NAME` FROM `INFORMATION_SCHEMA`.`COLUMNS` WHERE `TABLE_SCHEMA`='" + Config.DB_name + "' AND `TABLE_NAME`='" + DB_TableName + "'";
            var cmd1 = new MySqlCommand(Query, DBConn);
            var myRead1 = cmd1.ExecuteReader();


            while (myRead1.Read())
            {
                if (myRead1["column_name"].ToString() != "row_id")
                {
                    field_1 += myRead1["column_name"].ToString().Trim() + ",";
                }
                //
            }
            myRead1.Close();
            field_1 = field_1.Substring(0, field_1.Length - 1);

            Query = "insert into " + DB_TableName + " (" + field_1 + ")  select " + field_1 + " from " + DB_TableName + " where row_id='" + row_no + "'";
            cmd1 = new MySqlCommand(Query, DBConn);
            cmd1.ExecuteNonQuery();

            Query = " select * from " + DB_TableName + " where row_id=(SELECT LAST_INSERT_ID())";
            cmd1 = new MySqlCommand(Query, DBConn);
            myRead1 = cmd1.ExecuteReader();
            myRead1.Read();

            string row_id = myRead1["row_id"].ToString();

            myRead1.Close();
            DBConn.Close();

            return row_id;
        }
        public string DataUpdate(string Query)
        {
            var DBConn = new MySqlConnection(DB_Con);
            DBConn.Open();
            var cmd = new MySqlCommand(Query, DBConn);


            if (cmd.ExecuteNonQuery() == 0)
            {
                DBConn.Close();
                return "-1";
            }
            else
            {
                string row_no = "";
                string cQuery = "SELECT LAST_INSERT_ID() as dd";
                cmd = new MySqlCommand(cQuery, DBConn);
                var myRead = cmd.ExecuteReader();
                if (myRead.Read())
                {
                    row_no = myRead[0].ToString().Trim();
                }
                myRead.Close();
                DBConn.Close();
                return row_no;
            }
        }

        public int DateCalcToMinuit(DateTime Start_Datetime, DateTime End_Datetime)
        {
            TimeSpan tsValue = End_Datetime - Start_Datetime;
            double dTotalHours = tsValue.TotalHours;
            int Day2Min = tsValue.Days * 24 * 60;
            int Hour2Min = tsValue.Hours * 60;
            int Min = tsValue.Minutes;
            // 초단위는 계산 안함

            return Day2Min + Hour2Min + Min;
        }

        public string numGetComma(string num)
        {
            string result = "";
            string temp = "";
            string head = "";

            int len = 0;
            temp = num.Replace(",", "");
            head = temp;
            len = temp.Length;

            for (len = temp.Length - 3; len > 0; len = len - 3)
            {
                result = "," + head.Substring(len) + result;
                head = head.Substring(0, len);

            }
            result = head + result;


            return result;
        }
       
    }
    public class DangaControl
    {
        string DB_Con = "";
        string machine_no = "";
        string DB_TableName_danga = "";
        string DB_TableName_danga_sub = "";
        string DB_TableName_manage = "";
        string DB_TableName_hmachin = "";
        string Client_id = "";
        string ver = "";

        public DangaControl(string machine_no, string Client_id, string Table_danga, string Table_manage, string Table_machine, string ver)
        {
            this.machine_no = machine_no;
            this.Client_id = Client_id;

            DB_TableName_danga = Table_danga;
            DB_TableName_hmachin = Table_machine;
            DB_TableName_manage = Table_manage;
            this.ver = ver;
        }

        public void Insert2Manage()
        {
            string Query = "";
            if (ver == "user")
                Query = "select * from " + DB_TableName_manage + " where machin_id = " + machine_no + " and master_id = " + Client_id;
            else
                Query = "select * from " + DB_TableName_manage + " where machin_id = " + machine_no;

            var DBConn1 = new MySqlConnection(Config.DB_con1);
            DBConn1.Open();
            var cmd1 = new MySqlCommand(Query, DBConn1);
            var myRead1 = cmd1.ExecuteReader();

            ksgcontrol KC = new ksgcontrol();
            KC.ControlInit(Config.DB_con1, Config.Ftp_ip1, Config.Ftp_id1, Config.Ftp_pw1);
            if (myRead1.Read())
            {
                if (ver == "user")
                    Query = "update " + DB_TableName_manage + " set danga_id = 1 where machin_id = " + machine_no + " and master_id = " + Client_id;
                else
                    Query = "update " + DB_TableName_manage + " set danga_id = 1 where machin_id = " + machine_no;
                KC.DataUpdate(Query);
            }
            else
            {
                if (ver == "user")
                {
                    Query = "insert into " + DB_TableName_manage + " (machin_id, custom_id, master_id, danga_id)";
                    Query += " select row_id, int_id, " + Client_id + ", 1 from " + DB_TableName_hmachin + " where row_id = " + machine_no;
                }
                {
                    Query = "insert into " + DB_TableName_manage + " (machin_id, custom_id, danga_id)";
                    Query += " select row_id, int_id, 1 from " + DB_TableName_hmachin + " where row_id = " + machine_no;
                }
                KC.DataUpdate(Query);
            }
            myRead1.Close();
            DBConn1.Close();
        }


        public void Delete2Manage()
        {
            string Query = "";
            MySqlConnection DBConn2;
            if (ver == "user")
            {
                Query = "select * from " + DB_TableName_danga + " where int_id = " + machine_no;
                DBConn2 = new MySqlConnection(Config.DB_con2);
            }
            else
            {
                Query = "select * from " + DB_TableName_danga + " where int_id = " + machine_no;
                DBConn2 = new MySqlConnection(Config.DB_con1);
            }

            DBConn2.Open();
            var cmd2 = new MySqlCommand(Query, DBConn2);
            var myRead2 = cmd2.ExecuteReader();

            ksgcontrol KC = new ksgcontrol();
            KC.ControlInit(Config.DB_con1, Config.Ftp_ip1, Config.Ftp_id1, Config.Ftp_pw1);
            if (myRead2.Read())
            {
                DBConn2.Close();
                return;
            }
            else
            {
                if (ver == "user")
                    Query = "update " + DB_TableName_manage + " set danga_id = 0, con_day1 = '0000-00-00' where machin_id = " + machine_no + " and master_id = " + Client_id;
                else
                    Query = "update " + DB_TableName_manage + " set danga_id = 0 where machin_id = " + machine_no;
                KC.DataUpdate(Query);
                DBConn2.Close();
            }
        }

        public void Mody2Manage()
        {
            ksgcontrol KC = new ksgcontrol();
            KC.ControlInit(Config.DB_con1, Config.Ftp_ip1, Config.Ftp_id1, Config.Ftp_pw1);
            string Query = "update " + DB_TableName_manage + " set con_day1 = now(), con_time1 = now() where machin_id = " + machine_no + " and master_id = " + Client_id;
            KC.DataUpdate(Query);

        }
    }
    public class FileControl
    {
        string DB_Con = "";
        string FTP_ConIP = "";
        string FTP_Id = "";
        string FTP_Pw = "";
        public FileControl()
        {

        }

        public void FileControlInit(string DB, string FTP_IP, string FTP_ID, string FTP_PW)
        {
            DB_Con = DB;
            FTP_ConIP = FTP_IP;
            FTP_Id = FTP_ID;
            FTP_Pw = FTP_PW;
        }
        public void FileControlInit(string FTP_IP, string FTP_ID, string FTP_PW)
        {
            FTP_ConIP = FTP_IP;
            FTP_Id = FTP_ID;
            FTP_Pw = FTP_PW;
        }

        public int FileOpenDlg(OpenFileDialog ofd)
        {
            ofd.DefaultExt = "*.*"; //기본 확장자 설정
            ofd.Filter = "ALL File(*.*)|*.*";
            ofd.FilterIndex = 1; //기본으로 선택되는 파일 유형 설정 2로하면 모든파일이 선택됨
            ofd.Multiselect = false;// true;
            ofd.InitialDirectory = "C:\\";
            ofd.RestoreDirectory = true;

            if (ofd.ShowDialog() == DialogResult.OK)
                return 0;
            else
                return 1;
        }


        public string FileReg(OpenFileDialog ofd, string DB_TableName, string ColumnName, string Row_id, string option)
        {
            OhFTP Ftp = new OhFTP(FTP_ConIP, FTP_Id, FTP_Pw);
            string File_Table = DB_TableName.Substring(0, 1) + "_file_total_manage";

            string NameRull = "-" + DB_TableName;
            string ff1 = ofd.FileName;

            FileInfo FI = new FileInfo(ff1);
            string UserFN = FI.Name;

            string Query = "insert into " + File_Table + " (db_nm, int_id, user_file, f_option) values('" + DB_TableName + "', '" + Row_id + "', '" + UserFN + "', '" + option + "')";
            var DBConn = new MySqlConnection(DB_Con);
            DBConn.Open();
            var cmd = new MySqlCommand(Query, DBConn);

            if (cmd.ExecuteNonQuery() == 0)
            {
                MessageBox.Show("서버 등록에 실패 했습니다.");
                DBConn.Close();
                return "";
            }
            Query = " SELECT LAST_INSERT_ID() as dd";
            cmd = new MySqlCommand(Query, DBConn);
            var myRead = cmd.ExecuteReader();
            myRead.Read();
            string Last_Id = myRead["dd"].ToString();
            string ff2 = Last_Id + NameRull;
            myRead.Close();
            DBConn.Close();

            ff2 += ofd.FileName.Substring(ofd.FileName.LastIndexOf("."), ofd.FileName.Length - ofd.FileName.LastIndexOf("."));
            Ftp.UpLoadFile(ff1, ff2, DB_TableName);  // file 올리기

            Query = " update " + File_Table + " set server_file='" + ff2 + "' where row_id='" + Last_Id + "'";

            if (DataUpdate(Query) != 0)
                MessageBox.Show("서버 등록에 실패 했습니다.");

            //
            Query = " update " + DB_TableName + " set " + ColumnName + "='1' where row_id='" + Row_id + "'";  // Table에 사진 있음을 표시
            if (DataUpdate(Query) != 0)
            {
                MessageBox.Show("서버 등록에 실패 했습니다.");
                return "";
            }
            return ff2;
        }

        /* ----------------------------------------------- *
        * Function : DataUpdate
        * 기능     : 전달받은 Query를 실행
        -------------------------------------------------- */
        public int DataUpdate(string Query)
        {
            var DBConn = new MySqlConnection(DB_Con);
            DBConn.Open();
            var cmd = new MySqlCommand(Query, DBConn);


            if (cmd.ExecuteNonQuery() == 0)
            {
                DBConn.Close();
                return 1;
            }
            else
            {
                DBConn.Close();
                return 0;
            }
        }

        public void FileDel(string FileName, string DB_TableName)  // 1:n 링크에서 사용
        {
            OhFTP Ftp = new OhFTP(FTP_ConIP, FTP_Id, FTP_Pw);
            Ftp.DeleteFile(FileName, DB_TableName);
        }


        // 한테이블에서 많은 file을 기록해야할때 option을 사용해 지우고 말고를 결정한다. 
        // 예를 들어 C_member table 에서는 사진과 직원 자료가 저장되게 되는데 직원 자료는 grid로 나와있어
        // FileDel(string FileName, string DB_TableName) 를 사용해서 control 하며 사진같은경우는 option = 'picture' 로 구분하여 사진만 지울수 있게된다.
        // 굳이 option 이 필요없는 경우는 ""로 빈 string을 주면 된다.
        // file upload 시에도 option이 필요하면 꼭 주자..
        public void FileDel(string DB_TableName, string ColumnName, string Row_id, string option) // 1:1 링크에서만 하용
        {
            string FileName = "";
            string File_Table = DB_TableName.Substring(0, 1) + "_file_total_manage";

            string Query = "select * from " + File_Table + " where db_nm = '" + DB_TableName + "' and int_id = '" + Row_id + "'";
            Query += " and f_option='" + option + "' ";
            var DBConn = new MySqlConnection(DB_Con);
            DBConn.Open();
            var cmd = new MySqlCommand(Query, DBConn);
            var myRead = cmd.ExecuteReader();

            if (!myRead.Read())
            {
                myRead.Close();
                DBConn.Close();
                MessageBox.Show("삭제할 자료가 없습니다");
                return;
            }

            FileName = myRead["server_file"].ToString();
            FileDel(FileName, DB_TableName);
            myRead.Close();
            DBConn.Close();

            Query = "update " + DB_TableName + " set " + ColumnName + "='0' where row_id = '" + Row_id + "'";
            DataUpdate(Query);
            Query = "delete from " + File_Table + " where db_nm = '" + DB_TableName + "' and int_id = '" + Row_id + "'";
            Query += " and f_option='" + option + "' ";
            DataUpdate(Query);

        }

        public string FilePath2File(string FilePath)
        {
            string result = "";
            result = FilePath.Substring(FilePath.LastIndexOf("\\") + 1, FilePath.Length - FilePath.LastIndexOf("\\") - 1);
            return result;
        }


        public void OneFile2ManyRowId(OpenFileDialog ofd, string DB_TableName, string ColumnName, string option, string SelectQuery)
        {
            OhFTP Ftp = new OhFTP(FTP_ConIP, FTP_Id, FTP_Pw);
            string File_Table = DB_TableName.Substring(0, 1) + "_file_total_manage";

            string NameRull = "-" + DB_TableName;
            string ff1 = ofd.FileName;

            FileInfo FI = new FileInfo(ff1);
            string UserFN = FI.Name;

            var DBConn = new MySqlConnection(DB_Con);
            DBConn.Open();
            var cmd = new MySqlCommand(SelectQuery, DBConn);
            var myRead = cmd.ExecuteReader();

            string Query = "";
            myRead.Read();

            Query = "insert into " + File_Table + " (db_nm, int_id, user_file, f_option) values('" + DB_TableName + "', '" + myRead["row_id"] + "', '" + UserFN + "', '" + option + "')";
            var DBConn1 = new MySqlConnection(DB_Con);
            DBConn1.Open();
            var cmd1 = new MySqlCommand(Query, DBConn1);

            if (cmd1.ExecuteNonQuery() == 0)
            {
                MessageBox.Show("서버 등록에 실패 했습니다.");
                myRead.Close();
                DBConn.Close();
                DBConn1.Close();
                return;
            }

            Query = " SELECT LAST_INSERT_ID() as dd";
            cmd1 = new MySqlCommand(Query, DBConn1);
            var myRead1 = cmd1.ExecuteReader();
            myRead1.Read();
            string Last_Id = myRead1["dd"].ToString();
            string ff2 = Last_Id + NameRull;
            myRead1.Close();
            DBConn1.Close();

            ff2 += ofd.FileName.Substring(ofd.FileName.LastIndexOf("."), ofd.FileName.Length - ofd.FileName.LastIndexOf("."));
            Ftp.UpLoadFile(ff1, ff2, DB_TableName);  // file 올리기

            Query = " update " + File_Table + " set server_file='" + ff2 + "' where row_id='" + Last_Id + "'";
            if (DataUpdate(Query) == 1)
            {
                MessageBox.Show("서버 등록에 실패 했습니다.");
                myRead.Close();
                DBConn.Close();
                myRead1.Close();
                DBConn1.Close();
                return;
            }

            Query = " update " + DB_TableName + " set " + ColumnName + "='1' where row_id='" + myRead["row_id"] + "'";  // Table에 사진 있음을 표시
            if (DataUpdate(Query) == 1)
            {
                MessageBox.Show("서버 등록에 실패 했습니다.");
                myRead.Close();
                DBConn.Close();
                myRead1.Close();
                DBConn1.Close();
                return;
            }

            while (myRead.Read())
            {
                Query = "insert into " + File_Table + " (db_nm, int_id, server_file, user_file, f_option) values('" + DB_TableName + "', '" + myRead["row_id"] + "', '" + ff2 + "', '" + UserFN + "', '" + option + "')";
                if (DataUpdate(Query) == 1)
                {
                    MessageBox.Show("서버 등록에 실패 했습니다.");
                    myRead.Close();
                    DBConn.Close();
                    myRead1.Close();
                    DBConn1.Close();
                    return;
                }

                //
                Query = " update " + DB_TableName + " set " + ColumnName + "='1' where row_id='" + myRead["row_id"] + "'";  // Table에 사진 있음을 표시
                if (DataUpdate(Query) == 1)
                {
                    MessageBox.Show("서버 등록에 실패 했습니다.");
                    myRead.Close();
                    DBConn.Close();
                    myRead1.Close();
                    DBConn1.Close();
                    return;
                }
            }
            myRead.Close();
            DBConn.Close();
            myRead1.Close();
            DBConn1.Close();
            return;
        }

        public void OneFile2ManyRowId_Del(string DB_TableName, string ColumnName, string row_id, string option)
        {
            string file_name = "";
            string File_Table = DB_TableName.Substring(0, 1) + "_file_total_manage";
            string Query = "update " + DB_TableName + " set " + ColumnName + " = '0' where row_id = '" + row_id + "'";
            DataUpdate(Query);

            Query = "select * from " + File_Table + " where int_id='" + row_id + "' and db_nm = '" + DB_TableName + "'";
            var DBConn = new MySqlConnection(DB_Con);
            DBConn.Open();

            var cmd = new MySqlCommand(Query, DBConn);
            var myRead = cmd.ExecuteReader();

            if (myRead.Read())
            {
                file_name = myRead["server_file"].ToString();
            }
            else
            {
                myRead.Close();
                DBConn.Close();
                return;
            }
            myRead.Close();

            Query = "delete from " + File_Table + " where int_id='" + row_id + "' and db_nm = '" + DB_TableName + "'";
            DataUpdate(Query);

            Query = "select * from " + File_Table + " where server_file='" + file_name + "'";
            cmd = new MySqlCommand(Query, DBConn);
            myRead = cmd.ExecuteReader();
            if (myRead.Read())
            {
                myRead.Close();
                DBConn.Close();
                return;
            }
            else
            {
                FileDel(file_name, DB_TableName);
            }


        }
    }

    public class GetDangaColumn
    {
        public GetDangaColumn()
        {
            
        }


        //input : form이름, 데이터
        //output : 데이터가 없으면 index[0]에 "null"문자를 return.  데이터가 있으면 index[0]에 금액, index[1]에 단가를 return
        public string[] GetDanga(string form_name, string[] dat)
        {
            string Column = "";
            string[] a = new string[2];
            if (form_name == "K_01")  //dat 순서 =  0: abc_code, 1: 국/46, 2: 절수, 3: 연수
            {
                string[] get_value = new string[2];
                string[] result = new string[20];
                Column = Get_K_01_first(dat[1], Convert.ToInt32(dat[2])); // Column 명 return   
                get_value = Get_K_01_second(dat[0], Column, dat[3]);  // 절수단가, 기본단가를 return
                //get_value[0]; // 절수단가
                //get_value[1]; // 기본단가
                //dat[3];       // 연수
                if(get_value[0] == "null")
                {
                    result[0] = "null";
                    return result;
                }
                

                result = Get_K_01_third(dat[0], get_value[0], get_value[1], dat[3]);
                result = GetLastCal(result);
                return result;  // result 0:금액   1:단가
            }
            else if (form_name == "J_01")  //dat 순서 =  0: abc_code, 1: 국/46, 2: 절수, 3: 부수, 4: 접지, 5: 페이지
            {
                string[] get_value = new string[3];
                string[] result = new string[20];
                Column = Get_J_01_first(dat[1], Convert.ToInt32(dat[2])); // Column 명 return   
                get_value = Get_J_01_second(dat[0], Column, dat[4], dat[3]);  // 단가, 기본단가, 기본금액을 return
                //get_value[0]; // 단가
                //get_value[1]; // 기본단가
                //get_value[2]; // 기본금액
                
                if (get_value[0] == "null")
                {
                    result[0] = "null";
                    return result;
                }


                result = Get_J_01_third(dat[0], get_value[0], get_value[1], get_value[2], dat[3], dat[5]);
                result = GetLastCal(result);
                return result;  // result 0:금액   1:단가
            }

            return a;
        }


        //input : 국/46, 절수
        //output : 컬럼명
        //수행내용 : 단가테이블에서 종이 크기에 맞는 컬럼명을 도출
        public string Get_K_01_first(string kook, int jul)
        {
            string result = "";
            if (kook == "국")
            {
                if (jul == 1 )
                    result = "n8";
                else if (jul == 2)
                    result = "n9";
                else if (jul >= 3 && jul < 8)
                    result = "n10";
                else if (jul >= 8 && jul < 32)
                    result = "n11";
                else if (jul >= 32)
                    result = "n12";
            }
            else
            {
                if (jul == 1 || jul == 2)
                    result = "n3";
                else if (jul >= 3 && jul < 8)
                    result = "n4";
                else if (jul >= 8 && jul < 16)
                    result = "n5";
                else if (jul >= 16 && jul < 32)
                    result = "n6";
                else if (jul >= 32)
                    result = "n7";
            }

            return result;
        }

        //input : 대중소분류 코드, 단가컬럼, 연수
        //output : 단가, 기본단가
        //수행내용 : 연수가 범위안에 들며 대중소분류가 같은 데이터를 검색하여 단가와 기본단가 return
        public string[] Get_K_01_second(string abc_code, string danga_column, string yunsu)
        {
            string[] result = new string[2];
            string ab_code = abc_code.Substring(0, 4);
            string c_code = abc_code.Substring(4, 2);
            string DB_TableName = "C_platform_danga_dat";
            string Query = "";

            Query = "select * from " + DB_TableName + " where n1 <=" + yunsu + " and n2 > " + yunsu + " and ab_code='" + ab_code + "' and c_code='" + c_code + "'";

            var DBConn = new MySqlConnection(Config.DB_con1);
            DBConn.Open();
            var cmd = new MySqlCommand(Query, DBConn);

            var myRead = cmd.ExecuteReader();
            if (myRead.Read())
            {
                result[0] = myRead[danga_column].ToString();
                result[1] = myRead["n13"].ToString();
            }
            else
            {
                result[0] = "null";
            }

            myRead.Close();

            DBConn.Close();

            return result;
        }

        //input : 대중소분류 코드, 단가, 기본단가, 연수

        //output : 결과값 배열. index[0]은 총 데이터 갯수.  index[홀수] : 항목명.  index[짝수] : 계산값.
        //output 배열 내용 예시
        //0 : 7   // 절대 짝수가 될수 없으며 index[0]을 포함한 총 index의 수
        //1 : 단가        2 : 700   // 계산할 항목명과 계산 결과. 2개가 1짝이 됨.
        //3 : 기본단가    4 : 20000 // 

        //수행내용 : 사용자가 입력한 계산법에 의해 계산을 마친값들을 result 배열에 담아 return
        public string[] Get_K_01_third(string abc_code, string danga, string default_danga, string yunsu)
        {
            string[] result = new string[20];
            string a_code = abc_code.Substring(0, 2);
            string b_code = abc_code.Substring(2, 2);
            string c_code = abc_code.Substring(4, 2);
            string Query = "select * from C_dtable_cal c inner join C_dtable a inner join C_cmodel b on a.code_id = b.x_code and b.a_code='"+a_code+"'";
            string cal = "";
            Query += " and b.b_code='"+b_code+"' and b.c_code='"+c_code+"' and c.int_id = a.row_id";

            var DBConn = new MySqlConnection(Config.DB_con1);
            DBConn.Open();
            var cmd = new MySqlCommand(Query, DBConn);
            var myRead = cmd.ExecuteReader();

            MySqlConnection Cal_DB = new MySqlConnection(Config.DB_con1);
            Cal_DB.Open();
            MySqlCommand Cal_cmd;
            MySqlDataReader Cal_Read;
            string Cal_Query = "";


            int i = 1;
            while (myRead.Read())
            {
                cal = myRead["calculat_str"].ToString();
                cal = cal.Replace("A", danga);          // 단가
                cal = cal.Replace("B", default_danga);  // 기본단가
                cal = cal.Replace("C", yunsu);          // 연수

                if (cal != "")
                {
                    Cal_Query = "select " + cal + " as dd";
                    Cal_cmd = new MySqlCommand(Cal_Query, Cal_DB);
                    Cal_Read = Cal_cmd.ExecuteReader();
                    Cal_Read.Read();

                    result[i] = myRead["hang_mok"].ToString();
                    i++;
                    result[i] = Cal_Read["dd"].ToString();
                    i++;
                    Cal_Read.Close();
                }

            }
            result[0] = i.ToString();
            Cal_DB.Close();
            myRead.Close();
            DBConn.Close();

            return result;

        }

        // input : 3차 쿼리문까지 계산하여 나온 배열
        // output : index[0] : 금액           index[1] : 단가 
        // 수행내용 : 기본금액 <> 금액 비교하여 큰것  // 기본단가 <> 단가 비교하여 큰것을 return한다
        private string[] GetLastCal(string[] sd)
        {
            string[] result = new string[2];
            string Max_Cal_Price = "0"; // 기본금액과 금액 중 큰것
            string Max_Base_Price = "0"; // 기본단가와 단가중 큰것
            for (int i = 1; i <= Convert.ToInt32(sd[0]); i++)
            { 
                if(sd[i] == "기본금액")
                {
                    if (Convert.ToDecimal(sd[i + 1]) > Convert.ToDecimal(Max_Cal_Price))
                        Max_Cal_Price = sd[i+1];
                }
                else if (sd[i] == "금액")
                {
                    if (Convert.ToDecimal(sd[i + 1]) > Convert.ToDecimal(Max_Cal_Price))
                        Max_Cal_Price = sd[i + 1];
                }
                else if (sd[i] == "단가")
                {
                    if (Convert.ToDecimal(sd[i + 1]) > Convert.ToDecimal(Max_Base_Price))
                        Max_Base_Price = sd[i + 1];
                }
                else if (sd[i] == "기본단가")
                {
                    if (Convert.ToDecimal(sd[i + 1]) > Convert.ToDecimal(Max_Base_Price))
                        Max_Base_Price = sd[i + 1];
                }
            }

            result[0] = Max_Cal_Price;  // 기본금액과 금액중 큰것
            result[1] = Max_Base_Price; // 기본단가와 단가중 큰것
            return result;
        }

        //input : 책 절수 a,b
        //output : 컬럼명
        //수행내용 : 단가테이블에서 책 절수에 맞는 컬럼명을 도출
        public string Get_J_01_first(string book_jul_a, int book_jul_b)
        {
            string result = "";
            if (book_jul_a == "국")
            {
                if (book_jul_b == 8)
                    result = "f6";
                else if (book_jul_b == 12)
                    result = "f7";
                else if (book_jul_b == 16 || book_jul_b == 18)
                    result = "f8";
                else if (book_jul_b == 24 || book_jul_b == 32)
                    result = "f9";
                else if (book_jul_b == 40 || book_jul_b == 48 || book_jul_b == 36 || book_jul_b == 54 || book_jul_b == 64 || book_jul_b == 72)
                    result = "f10";
            }
            else
            {
                if (book_jul_b == 8 || book_jul_b == 12)
                    result = "f1";
                else if (book_jul_b == 16 || book_jul_b == 18)
                    result = "f2";
                else if (book_jul_b == 24 )
                    result = "f3";
                else if (book_jul_b == 32 )
                    result = "f4";
                else if (book_jul_b == 40 || book_jul_b == 48 || book_jul_b == 36 || book_jul_b == 54 || book_jul_b == 64)
                    result = "f5";
            }

            return result;
        }

        //input : 대중소분류 코드, 단가컬럼, 접지, 부수
        //output : 단가, 기본단가, 기본금액
        //수행내용 : 부수가 범위안에 들며 대중소분류가 같고 접지가 맞는 데이터를 검색하여 단가와 기본단가, 기본금액을 return
        public string[] Get_J_01_second(string abc_code, string danga_column, string jubji, string busu)
        {
            string[] result = new string[3];
            string ab_code = abc_code.Substring(0, 4);
            string c_code = abc_code.Substring(4, 2);
            string DB_TableName = "C_platform_danga_dat";
            string Query = "";

            Query = "select * from " + DB_TableName + " where ab_code ='" + abc_code.Substring(0, 4).ToString();
            Query +="' and c_code = '" + abc_code.Substring(4,2).ToString() + "' and n1='" + jubji + "' and n2 <='" + busu + "' and n3>'"+busu+"'";

            var DBConn = new MySqlConnection(Config.DB_con1);
            DBConn.Open();
            var cmd = new MySqlCommand(Query, DBConn);

            var myRead = cmd.ExecuteReader();
            if (myRead.Read())
            {
                result[0] = myRead[danga_column].ToString();  // 단가
                result[1] = myRead["n4"].ToString();         // 기본단가
                result[2] = myRead["n5"].ToString();         // 기본금액
            }
            else
            {
                result[0] = "null";
            }

            myRead.Close();

            DBConn.Close();

            return result;
        }

        //output : 결과값 배열. index[0]은 총 데이터 갯수.  index[홀수] : 항목명.  index[짝수] : 계산값.
        //output 배열 내용 예시
        //0 : 7   // 절대 짝수가 될수 없으며 index[0]을 포함한 총 index의 수
        //1 : 단가        2 : 700   // 계산할 항목명과 계산 결과. 2개가 1짝이 됨.
        //3 : 기본단가    4 : 20000 // 

        //수행내용 : 사용자가 입력한 계산법에 의해 계산을 마친값들을 result 배열에 담아 return
        public string[] Get_J_01_third(string abc_code, string danga, string default_danga, string default_price, string busu, string page) // 대중소 코드, 단가, 기본단가, 기본금액, 부수, 페이지
        {
            string[] result = new string[20];
            string a_code = abc_code.Substring(0, 2);
            string b_code = abc_code.Substring(2, 2);
            string c_code = abc_code.Substring(4, 2);
            string Query = "select * from C_dtable_cal c inner join C_dtable a inner join C_cmodel b on a.code_id = b.x_code and b.a_code='" + a_code + "'";
            string cal = "";
            Query += " and b.b_code='" + b_code + "' and b.c_code='" + c_code + "' and c.int_id = a.row_id";

            var DBConn = new MySqlConnection(Config.DB_con1);
            DBConn.Open();
            var cmd = new MySqlCommand(Query, DBConn);
            var myRead = cmd.ExecuteReader();

            MySqlConnection Cal_DB = new MySqlConnection(Config.DB_con1);
            Cal_DB.Open();
            MySqlCommand Cal_cmd;
            MySqlDataReader Cal_Read;
            string Cal_Query = "";


            int i = 1;
            while (myRead.Read())
            {
                cal = myRead["calculat_str"].ToString();
                cal = cal.Replace("A", danga);          // 단가
                cal = cal.Replace("B", default_danga);  // 기본단가
                cal = cal.Replace("C", default_price);  // 기본금액
                cal = cal.Replace("D", busu);  // 부수
                cal = cal.Replace("E", page);  // 페이지

                if (cal != "")
                {
                    Cal_Query = "select " + cal + " as dd";
                    Cal_cmd = new MySqlCommand(Cal_Query, Cal_DB);
                    Cal_Read = Cal_cmd.ExecuteReader();
                    Cal_Read.Read();

                    result[i] = myRead["hang_mok"].ToString();
                    i++;
                    result[i] = Cal_Read["dd"].ToString();
                    i++;
                    Cal_Read.Close();
                }

            }
            result[0] = i.ToString();
            Cal_DB.Close();
            myRead.Close();
            DBConn.Close();

            return result;

        }

    }
    public class addr_control
    {
        // input : old 주소, new 주소, 텍스트 주소   ( other 주소만..)
        // output : 없음.  레퍼런스로 받아서 바로 적용시켜줌.
        public static void Convert_other_addr(ref string other_old, ref string other_new, string tb_text)
        {
            other_old = other_old.Replace("\r", "");
            other_new = other_new.Replace("\r", "");

            int old_len = other_old.Length;
            int new_len = other_new.Length;
            bool match_flag = false;

            int y = new_len;
            int i = old_len;
            // other_old, other_new 모두 세부 주소가 기록되어있을시에는 세부주소를 제거한 다른부분만 남겨두기 위해 수행
            // ex) old : 192-20 세영하이트빌라
            //     new : 고강로 118 세영하이트빌라
            //     결과 : old :192-20
            //            new : 고강로 118  이 나와야 정상임..
            for (; i > 0; i--)
            {
                if (other_old.Substring(i - 1, 1) == other_new.Substring(y - 1, 1))
                {
                    match_flag = true;
                    y--;
                }
                else
                {
                    if (match_flag == true) // true 였다가 false로 바뀌는경우는 없으므로 바로 break;
                        break;
                }
            }

            if (other_old.Length > 0 && other_new.Length > 0)
            {
                other_old = other_old.Substring(0, i);
                other_new = other_new.Substring(0, y);
            }

            if (tb_text.Length > 0)
            {
                if (Config.addr_tail == "c") // 구주소 사용하고있으면..
                {
                    if (tb_text.Substring(0, other_old.Length) == other_old)        // 앞에 주소가 바뀌지 않고 추가만했다면.
                    {
                        other_new = other_new + tb_text.Substring(other_old.Length);
                        other_old = tb_text;
                    }
                    else                // 앞에 주소를 삭제하고 다시 넣은거면 그 문자 그대로 그냥 주소가됨.
                    {
                        other_new = tb_text;
                        other_old = tb_text;
                    }
                }
                else                  // 신주소를 사용하고있으면
                {
                    if (tb_text.Substring(0, other_new.Length) == other_new)        // 앞에 주소가 바뀌지 않고 추가만했다면.
                    {
                        other_old = other_old + tb_text.Substring(other_new.Length);
                        other_new = tb_text;
                    }
                    else                // 앞에 주소를 삭제하고 다시 넣은거면 그 문자 그대로 그냥 주소가됨.
                    {
                        other_old = tb_text;
                        other_new = other_new;
                    }
                }
            }
        }
    }
}
