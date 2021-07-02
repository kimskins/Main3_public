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
    public partial class Form_604 : Form
    {
        SourceGrid.Cells.Controllers.CustomEvents clickEvent = new SourceGrid.Cells.Controllers.CustomEvents();  // 작업의뢰서 버튼
        SourceGrid.Cells.Controllers.CustomEvents clickEvent1 = new SourceGrid.Cells.Controllers.CustomEvents();  // CTP 주문정보 버튼

        const string DB_TableName_joo = "C_corp_jumoon";   // 하청업체 주문 테이블
        string DB_TableName_auto = "C_auto2";        // 자동화창 Table
        string DB_TableName_client = "C_client";     // 회원정보 테이블
        string DB_TableName_hang = "hang_manage";    // 항목 테이블
        string DB_TableName_hcust = "C_hcustomer";   // 협력업체 테이블
        string DB_TableName_jumoon = "C_jumoon2";    // Local 주문 테이블에서 필요한 데이터 복사한 테이블
        string DB_TableName_hmachine = "C_hmachin";  // 협력업체 기계 테이블

        Boolean Chk = false;

        SourceGridControl GridHandle = new SourceGridControl();
        public Form_604()
        {
            InitializeComponent();
            GridHandle.SourceGrideInit(grid1, Config.DB_con1);
        }

        private void Form_604_Load(object sender, EventArgs e)
        {
            Screen srn = Screen.PrimaryScreen;
            int Xb = this.Width;  //좌,우
            int Yb = this.Height; //좌,우
            this.Location = new Point((srn.Bounds.Width - Xb) / 2, (srn.Bounds.Height - Yb)/2);  //좌/우,위/아래
            ksgcontrol kc = new ksgcontrol();
            kc.ControlInit(Config.DB_con1, "", "", "");

            clickEvent.Click += new EventHandler(clickEvent_Click);   // 그리드에서 버튼 클릭 이벤트
            clickEvent1.Click += new EventHandler(clickEvent_Click1);   // 그리드에서 버튼 클릭 이벤트

            Chk = false;

            tbStartDate.Text = DateTime.Now.ToString("yyyy-MM-dd");
            tbEndDate.Text = tbStartDate.Text;
            tbStartDate.Refresh();
            tbEndDate.Refresh();

            kc.ComboBoxItemInsert("C_client", "ver", cbGubun);

            string s1, s2 = "";
            if (!string.IsNullOrEmpty(tbStartDate.Text))  //날짜
            {
                s1 = " and a.receive_date >= '" + tbStartDate.Text + " 00:00:00' ";
            }
            else
                s1 = "";

            if (!string.IsNullOrEmpty(tbEndDate.Text))  //날짜
            {
                s2 = " and a.receive_date <= '" + tbEndDate.Text + " 23:59:59' ";
            }
            else
                s2 = "";

            string cQuery = "";
            cQuery = "select d.hang, h.sangho as prn_com, g.pan_size, g.machin_guy, a.*, b.*";
            cQuery += ", c.name, c.ver, d.hang, e.sangho as paper_com, f.item from " + DB_TableName_joo + " as a ";
            cQuery += " Left outer join " + DB_TableName_auto + " as b on a.auto2_id = b.row_id ";
            cQuery += " Left outer join " + DB_TableName_client + " as c on a.client_id = c.row_id ";
            cQuery += " Left outer join " + DB_TableName_hang + " as d on b.hang_id = d.code1 ";
            cQuery += " Left outer join " + DB_TableName_hcust + " as e on b.supply_id = e.row_id";
            cQuery += " Left outer join " + DB_TableName_jumoon + " as f on f.jumoon_no = a.jumoon2_id";
            cQuery += " Left outer join " + DB_TableName_hmachine + " as g on g.row_id = a.corp_machine_id";
            cQuery += " Left outer join " + DB_TableName_hcust + " as h on h.row_id = g.int_id";
            cQuery += " where d.class = '항목' and b.action = '2' " + s1 + s2 + " order by a.jumoon2_id";
            Grid_View(cQuery);
        }

        private void Grid_View(string cQuery)
        {
            string[] mdd = new string[60];
            cell_d cc = new cell_d();
            ksgcontrol kc = new ksgcontrol();
            
            // 
            grid1.Rows.Clear();
            grid1.BorderStyle = BorderStyle.FixedSingle;
            grid1.SelectionMode = SourceGrid.GridSelectionMode.Cell;
            grid1.ColumnsCount = 40;
            grid1.FixedRows = 1;
            grid1.Rows.Insert(0);
            grid1.Rows[0].Height = 24;
            //
            grid1[0, 0] = new MyHeader1("row_id");
            grid1[0, 1] = new MyHeader1("auto_id");
            grid1[0, 2] = new MyHeader1("√");
            grid1[0, 3] = new MyHeader1("No");
            grid1[0, 4] = new MyHeader1("접수일");
            grid1[0, 5] = new MyHeader1("진행과정");
            grid1[0, 6] = new MyHeader1("구분");
            grid1[0, 7] = new MyHeader1("상호");
            grid1[0, 8] = new MyHeader1("제작물이름");
            grid1[0, 9] = new MyHeader1("제작유형");
            grid1[0, 10] = new MyHeader1("항목");
            grid1[0, 11] = new MyHeader1("작업");
            grid1[0, 12] = new MyHeader1("인쇄소");
            grid1[0, 13] = new MyHeader1("기계구와이");
            grid1[0, 14] = new MyHeader1("판Size");
            grid1[0, 15] = new MyHeader1("종이Size");
            grid1[0, 16] = new MyHeader1("도큐Size");
            grid1[0, 17] = new MyHeader1("도수");
            grid1[0, 18] = new MyHeader1("별");
            grid1[0, 19] = new MyHeader1("분수");
            grid1[0, 20] = new MyHeader1("유형");
            grid1[0, 21] = new MyHeader1("대수");
            grid1[0, 22] = new MyHeader1("판수");
            grid1[0, 23] = new MyHeader1("M");
            grid1[0, 24] = new MyHeader1("M-내용");
            grid1[0, 25] = new MyHeader1("처리");
            grid1[0, 26] = new MyHeader1("사고자");
            grid1[0, 27] = new MyHeader1("종이공장");
            grid1[0, 28] = new MyHeader1("인쇄업체");  // 메모형식
            grid1[0, 29] = new MyHeader1("전화번호");
            grid1[0, 30] = new MyHeader1("메모");
            grid1[0, 31] = new MyHeader1("m_dat");
            grid1[0, 32] = new MyHeader1("client_id");
            grid1[0, 33] = new MyHeader1("jumoon_id");
            grid1[0, 34] = new MyHeader1("prn_id");  // 셋트번호
            grid1[0, 35] = new MyHeader1("인쇄업체");   // row_id 로 link된 업체명
            grid1[0, 36] = new MyHeader1("판사이즈");  
            grid1[0, 37] = new MyHeader1("기계구와이");  
            grid1[0, 38] = new MyHeader1("작업의뢰서");  
            grid1[0, 39] = new MyHeader1("CTP주문정보");  

            grid1.Columns[0].Visible = false;
            grid1.Columns[1].Visible = false;
            grid1.Columns[6].Visible = false;
            grid1.Columns[12].Visible = false;
            grid1.Columns[13].Visible = false;
            grid1.Columns[14].Visible = false;
            grid1.Columns[24].Visible = false;
            grid1.Columns[25].Visible = false;
            grid1.Columns[26].Visible = false;
            grid1.Columns[27].Visible = false;
            grid1.Columns[28].Visible = false;
            grid1.Columns[29].Visible = false;
            grid1.Columns[30].Visible = false;
            grid1.Columns[31].Visible = false;
            grid1.Columns[32].Visible = false;
            grid1.Columns[33].Visible = false;
            grid1.Columns[34].Visible = false;

            //
            grid1.Columns[2].Width = 22;
            grid1.Columns[3].Width = 40;
            grid1.Columns[4].Width = 90;
            grid1.Columns[5].Width = 60;
            grid1.Columns[6].Width = 90;
            grid1.Columns[7].Width = 150;
            grid1.Columns[8].Width = 230;
            grid1.Columns[9].Width = 60;
            grid1.Columns[10].Width = 100;
            grid1.Columns[11].Width = 60;
            grid1.Columns[12].Width = 120;
            grid1.Columns[13].Width = 100;
            grid1.Columns[14].Width = 100;
            grid1.Columns[15].Width = 80;
            grid1.Columns[16].Width = 80;
            grid1.Columns[17].Width = 40;
            grid1.Columns[18].Width = 40;
            grid1.Columns[19].Width = 40;
            grid1.Columns[20].Width = 60;
            grid1.Columns[21].Width = 40;
            grid1.Columns[22].Width = 40;
            grid1.Columns[23].Width = 26;
            //grid1.Columns[28].Width = 150;
            //grid1.Columns[29].Width = 100;
            //grid1.Columns[30].Width = 300;
            grid1.Columns[35].Width = 120;
            grid1.Columns[36].Width = 80;
            grid1.Columns[37].Width = 80;
            grid1.Columns[38].Width = 80;
            grid1.Columns[39].Width = 80;

            int m = 1;

            var DBConn = new MySqlConnection(Config.DB_con1);
            DBConn.Open();

            var cmd = new MySqlCommand(cQuery, DBConn);
            var myRead = cmd.ExecuteReader();
            // 
            string temp_jumoon_id = "";
            int merge_count = 0;
            while (myRead.Read())
            {
                grid1.Rows.Insert(m);
                grid1.Rows[m].Height = 22;

                mdd = myRead["m_dat"].ToString().Split(new char[1] { '#' });
                //
                grid1[m, 0] = new SourceGrid.Cells.Cell(myRead["row_id"], typeof(string));
                grid1[m, 1] = new SourceGrid.Cells.Cell(myRead["auto2_id"], typeof(string));
                grid1[m, 2] = new SourceGrid.Cells.CheckBox(null, false);

                grid1[m, 3] = new SourceGrid.Cells.Cell(m.ToString(), typeof(string));
                grid1[m, 3].View = cc.center_cell;
                grid1[m, 3].Editor = cc.disable_cell;

                string receive_date = "";
                receive_date = Convert.ToDateTime(myRead["receive_date"].ToString()).ToString("yyyy-MM-dd");
                grid1[m, 4] = new SourceGrid.Cells.Cell(receive_date, typeof(string));
                grid1[m, 4].View = cc.center_cell;
                grid1[m, 4].Editor = cc.disable_cell;

                string condition = "";
                if (myRead["action"].ToString() == "1")
                    condition = "";
                else if (myRead["action"].ToString() == "2")
                    condition = "접수";
                else if (myRead["action"].ToString() == "3")
                    condition = "진행";
                else if (myRead["action"].ToString() == "4")
                    condition = "완료";
                grid1[m, 5] = new SourceGrid.Cells.Cell(condition, typeof(string));
                grid1[m, 5].View = cc.center_cell;
                grid1[m, 5].Editor = cc.disable_cell;

                grid1[m, 6] = new SourceGrid.Cells.Cell(myRead["ver"], typeof(string));  //C_client table의 column
                grid1[m, 6].View = cc.center_cell;
                grid1[m, 6].Editor = cc.disable_cell;

                grid1[m, 7] = new SourceGrid.Cells.Cell(myRead["name"], typeof(string));  //C_client table의 column
                grid1[m, 7].View = cc.center_cell;
                grid1[m, 7].Editor = cc.disable_cell;

                if (temp_jumoon_id == myRead["jumoon2_id"].ToString())
                {
                    merge_count++;
                    grid1[m - merge_count, 8].RowSpan = merge_count + 1;
                    //grid1[m, 8] = new SourceGrid.Cells.Cell(myRead["item"], typeof(string));
                    //grid1[m, 8].View = cc.left_cell;
                    //grid1[m, 8].Editor = cc.disable_cell;
                    
                }
                else
                {
                    merge_count = 0;
                    grid1[m, 8] = new SourceGrid.Cells.Cell(myRead["item"], typeof(string));
                    grid1[m, 8].View = cc.left_cellb;
                    grid1[m, 8].Editor = cc.disable_cell;
                }
                

                grid1[m, 9] = new SourceGrid.Cells.Cell(mdd[0], typeof(string));   // 제작유형
                grid1[m, 9].View = cc.center_cell;
                grid1[m, 9].Editor = cc.disable_cell;

                string hang = "";

                if (myRead["hang"].ToString() != "" && myRead["hang"].ToString().Trim() != "")
                    hang = myRead["d_boonsu"].ToString() + myRead["hang_s"].ToString() + myRead["hang"].ToString();
                else
                    hang = "";
                grid1[m, 10] = new SourceGrid.Cells.Cell(hang, typeof(string));   // 항목
                grid1[m, 10].View = cc.center_cell;
                grid1[m, 10].Editor = cc.disable_cell;

                grid1[m, 11] = new SourceGrid.Cells.Cell(myRead["agroup"], typeof(string));   // 작업
                grid1[m, 11].View = cc.center_cell;
                grid1[m, 11].Editor = cc.disable_cell;

                grid1[m, 15] = new SourceGrid.Cells.Cell(mdd[15], typeof(string));   // 인쇄싸이즈
                grid1[m, 15].View = cc.center_cell;
                grid1[m, 15].Editor = cc.disable_cell;

                grid1[m, 16] = new SourceGrid.Cells.Cell(mdd[10], typeof(string));   // 도큐싸이즈
                grid1[m, 16].View = cc.center_cell;
                grid1[m, 16].Editor = cc.disable_cell;

                grid1[m, 17] = new SourceGrid.Cells.Cell(myRead["dosu"], typeof(string));   // 도수
                grid1[m, 17].View = cc.center_cell;
                grid1[m, 17].Editor = cc.disable_cell;

                grid1[m, 18] = new SourceGrid.Cells.Cell(myRead["star"], typeof(string));   // 별색
                grid1[m, 18].View = cc.center_cell;
                grid1[m, 18].Editor = cc.disable_cell;

                grid1[m, 19] = new SourceGrid.Cells.Cell(myRead["boonsu"], typeof(string));   // 분수
                grid1[m, 19].View = cc.center_cell;
                grid1[m, 19].Editor = cc.disable_cell;

                grid1[m, 20] = new SourceGrid.Cells.Cell(myRead["prn_model"], typeof(string));   // 유형
                grid1[m, 20].View = cc.center_cellb;
                grid1[m, 20].Editor = cc.disable_cell;

                grid1[m, 21] = new SourceGrid.Cells.Cell(myRead["deasu"], typeof(string));   // 대수
                grid1[m, 21].View = cc.center_cell;
                grid1[m, 21].Editor = cc.disable_cell;

                grid1[m, 22] = new SourceGrid.Cells.Cell(GridHandle.decimaldel(myRead["total_su"].ToString()), typeof(string));   // 판수
                grid1[m, 22].View = cc.center_cell;
                grid1[m, 22].Editor = cc.disable_cell;

                grid1[m, 23] = new SourceGrid.Cells.Cell("");
                grid1[m, 23].Image = Properties.Resources.note_25_icon_16;  //메모 아이콘
                grid1[m, 23].View = cc.center_cellb;
                grid1[m, 23].Editor = cc.disable_cell;

                grid1[m, 24] = new SourceGrid.Cells.Cell(myRead["memo1"], typeof(string));   // 메모 내용

                grid1[m, 25] = new SourceGrid.Cells.Cell(myRead["cheri"], typeof(string));   // 처리
                grid1[m, 25].View = cc.center_cell;
                grid1[m, 25].Editor = cc.disable_cell;

                grid1[m, 26] = new SourceGrid.Cells.Cell(myRead["accident_name"], typeof(string));   // 사고자
                grid1[m, 26].View = cc.center_cell;
                grid1[m, 26].Editor = cc.disable_cell;

                grid1[m, 27] = new SourceGrid.Cells.Cell(myRead["paper_com"], typeof(string));   // 공장
                grid1[m, 27].View = cc.center_cell;
                grid1[m, 27].Editor = cc.disable_cell;


                grid1[m, 28] = new SourceGrid.Cells.Cell(myRead["print_company"], typeof(string));   // 인쇄업체
                grid1[m, 28].View = cc.left_cell;
                grid1[m, 28].Editor = cc.disable_cell;

                grid1[m, 29] = new SourceGrid.Cells.Cell(myRead["company_tel"], typeof(string));   // 전화번호
                grid1[m, 29].View = cc.center_cell;
                grid1[m, 29].Editor = cc.disable_cell;

                grid1[m, 30] = new SourceGrid.Cells.Cell(myRead["work_memo"], typeof(string));   // 메모
                grid1[m, 30].View = cc.left_cell;
                grid1[m, 30].Editor = cc.disable_cell;

                grid1[m, 31] = new SourceGrid.Cells.Cell(myRead["m_dat"], typeof(string));   // data 모음
                grid1[m, 32] = new SourceGrid.Cells.Cell(myRead["client_id"], typeof(string));   // 고객id
                grid1[m, 33] = new SourceGrid.Cells.Cell(myRead["jumoon2_id"], typeof(string));   // 주문id
                grid1[m, 34] = new SourceGrid.Cells.Cell(myRead["prn_id"], typeof(string));   // 주문id

                grid1[m, 35] = new SourceGrid.Cells.Cell(myRead["prn_com"], typeof(string));   // 인쇄업체
                grid1[m, 35].View = cc.left_cell;
                grid1[m, 35].Editor = cc.disable_cell;

                grid1[m, 36] = new SourceGrid.Cells.Cell(myRead["pan_size"], typeof(string));   // 판사이즈
                grid1[m, 36].View = cc.center_cell;
                grid1[m, 36].Editor = cc.disable_cell;

                grid1[m, 37] = new SourceGrid.Cells.Cell(myRead["machin_guy"], typeof(string));   // 기계구와이
                grid1[m, 37].View = cc.center_cell;
                grid1[m, 37].Editor = cc.disable_cell;

                grid1[m, 38] = new SourceGrid.Cells.Button("");
                grid1[m, 38].AddController(clickEvent);
                grid1[m, 38].Editor = cc.disable_cell;

                grid1[m, 39] = new SourceGrid.Cells.Button("");
                grid1[m, 39].AddController(clickEvent1);
                grid1[m, 39].Editor = cc.disable_cell;
                
                
                temp_jumoon_id = myRead["jumoon2_id"].ToString();
                m++;
            }
            myRead.Close();
            DBConn.Close();
        }

        private void bStartDate_Click(object sender, EventArgs e)
        {
            Calendar_Form fm = new Calendar_Form(tbStartDate);
            fm.ShowDialog();
        }

        private void bEndDate_Click(object sender, EventArgs e)
        {
            Calendar_Form fm = new Calendar_Form(tbEndDate);
            fm.ShowDialog();
        }

        private void bClear_Click(object sender, EventArgs e)
        {
            tbStartDate.Text = DateTime.Now.ToString("yyyy-MM-dd");
            tbEndDate.Text = tbStartDate.Text;
            chkRecieve.Checked = true;
            chkWork.Checked = false;
            chkComplete.Checked = false;
            cbGubun.Text = "";
            tbSangho.Text = "";
            tbItem.Text = "";
            tbPrintCompany.Text = "";

            tbStartDate.Refresh();
            tbEndDate.Refresh();
            tbEndDate.Refresh();
            chkRecieve.Refresh();
            chkWork.Refresh();
            chkComplete.Refresh();
            cbGubun.Refresh();
            tbSangho.Refresh();
            tbItem.Refresh();
            tbPrintCompany.Refresh();
        }

        private void bSearch_Click(object sender, EventArgs e)
        {
            ksgcontrol kc = new ksgcontrol();
            kc.ControlInit(Config.DB_con1, "", "", "");
            string s1, s2, s3, s4, s5, s6, s7 = "";

            if (!string.IsNullOrEmpty(tbStartDate.Text))  //날짜
            {
                s1 = " and a.receive_date >= '" + tbStartDate.Text + " 00:00:00' ";
            }
            else
                s1 = "";

            if (!string.IsNullOrEmpty(tbEndDate.Text))  //날짜
            {
                s2 = " and a.receive_date <= '" + tbEndDate.Text + " 23:59:59' ";
            }
            else
                s2 = "";

            if (chkComplete.Checked == true || chkRecieve.Checked == true || chkWork.Checked == true)
            {
                s3 = " and ( b.action = '-1' ";
                if (chkRecieve.Checked == true)
                    s3 += "or b.action = '2' ";

                if (chkWork.Checked == true)
                    s3 += "or b.action = '3' ";

                if (chkComplete.Checked == true)
                    s3 += "or b.action = '4' ";

                s3 += ")";

            }
            else
                s3 = "";

            if (!string.IsNullOrEmpty(cbGubun.Text))  //구분
            {
                s4 = " and c.ver = '" + cbGubun.Text + "' ";
            }
            else
                s4 = "";

            if (!string.IsNullOrEmpty(tbSangho.Text))  //상호
            {
                s5 = " and c.name like '%" + tbSangho.Text + "%' ";
            }
            else
                s5 = "";

            if (!string.IsNullOrEmpty(tbItem.Text))  //제작물이름
            {
                s6 = " and a.item like '%" + tbItem.Text + "%' ";
            }
            else
                s6 = "";
            
            if (!string.IsNullOrEmpty( tbPrintCompany.Text))  //인쇄업체명
            {
                s7 = " and a.print_company like '%" + tbPrintCompany.Text + "%' ";
            }
            else
                s7 = "";

            string cQuery = "";
            cQuery = "select d.hang, h.sangho as prn_com, g.pan_size, g.machin_guy, a.*, b.*";
            cQuery += ", c.name, c.ver, d.hang, e.sangho as paper_com, f.item from " + DB_TableName_joo + " as a ";
            cQuery += " Left outer join " + DB_TableName_auto + " as b on a.auto2_id = b.row_id ";
            cQuery += " Left outer join " + DB_TableName_client + " as c on a.client_id = c.row_id ";
            cQuery += " Left outer join " + DB_TableName_hang + " as d on b.hang_id = d.code1 ";
            cQuery += " Left outer join " + DB_TableName_hcust + " as e on b.supply_id = e.row_id";
            cQuery += " Left outer join " + DB_TableName_jumoon + " as f on f.jumoon_no = a.jumoon2_id";
            cQuery += " Left outer join " + DB_TableName_hmachine + " as g on g.row_id = a.corp_machine_id";
            cQuery += " Left outer join " + DB_TableName_hcust + " as h on h.row_id = g.int_id";
            cQuery += " where d.class = '항목' " + s1 + s2 + s3 + s4 + s5 + s6 + s7 + " order by a.jumoon2_id"; 
            Grid_View(cQuery);
        }

        private void grid1_MouseClick(object sender, MouseEventArgs e)
        {
            Rect ChkArea = new Rect();
            ChkArea.Top = 0;
            ChkArea.Left = 0;
            ChkArea.Bottom = GridHandle.grid.Rows[0].Height;
            ChkArea.Right = 22;

            int m_x = e.X;
            int m_y = e.Y;

            if (m_x > ChkArea.Left && m_x < ChkArea.Right && m_y > ChkArea.Top && m_y < ChkArea.Bottom)  // chk 컬럼 클릭
            {
                if (Chk == false)
                {
                    Chk = true;
                    GridHandle.ChkCheckAll(2);
                }
                else
                {
                    Chk = false;
                    GridHandle.ChkCancel(2);
                }
            }
        }

        private void bStartCTP_Click(object sender, EventArgs e)
        {
            cell_d cc = new cell_d();
            string auto_id_collect = "";
            for (int i = 1; i < grid1.RowsCount; i++)
            {
                if (grid1[i, 2].Value.Equals(true))
                {
                    auto_id_collect += " or row_id = '" + grid1[i, 1].ToString() + "' ";

                    grid1[i, 5] = new SourceGrid.Cells.Cell("진행", typeof(string));
                    grid1[i, 5].View = cc.center_cell;
                    grid1[i, 5].Editor = cc.disable_cell;

                }
            }
            string cQuery = "update " + DB_TableName_auto + " set action = '3' where row_id = '-1' " + auto_id_collect;
            GridHandle.DataUpdate(cQuery);
            grid1.Refresh();
            GridHandle.ChkCancel(2);
        }

        private void bCompleteCTP_Click(object sender, EventArgs e)
        {
            cell_d cc = new cell_d();
            string auto_id_collect = "";
            for (int i = 1; i < grid1.RowsCount; i++)
            {
                if (grid1[i, 2].Value.Equals(true))
                {
                    auto_id_collect += " or row_id = '" + grid1[i, 1].ToString() + "' ";

                    grid1[i, 5] = new SourceGrid.Cells.Cell("완료", typeof(string));
                    grid1[i, 5].View = cc.center_cell;
                    grid1[i, 5].Editor = cc.disable_cell;

                }
            }
            string cQuery = "update " + DB_TableName_auto + " set action = '4' where row_id = '-1' " + auto_id_collect;
            GridHandle.DataUpdate(cQuery);
            grid1.Refresh();
            GridHandle.ChkCancel(2);
        }

        private void grid1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            int cpos = grid1.Selection.ActivePosition.Column;
            int rpos = grid1.Selection.ActivePosition.Row;

            if (rpos < 0)
                return;

            if (cpos == 8)
            {
                string item = grid1[rpos, 8].ToString();
                string jumoon_id = grid1[rpos, 33].ToString();
                string client_id = grid1[rpos, 32].ToString();

                util.IsFormAlreadyOpen(typeof(Form_auto));
                Form_auto Frm = new Form_auto("2", jumoon_id, false, client_id, item);  
                Frm.MdiParent = Main.ActiveForm;
                Frm.Show();
            }
            else if (cpos == 20)
            {
                string item = grid1[rpos, 8].ToString();
                string jumoon_id = grid1[rpos, 33].ToString();
                string client_id = grid1[rpos, 32].ToString();
                string set_num = grid1[rpos, 34].ToString();
                Form_auto Frm = new Form_auto("2", jumoon_id, false, client_id, item, set_num);
                //Frm.Show();
            }
            else if (cpos == 23) // 메모
            {

                string[] ss = new string[4];
                ss[0] = grid1[rpos, 24].ToString();  //메모
                ss[1] = grid1[rpos, 25].ToString();  //처리
                ss[2] = grid1[rpos, 26].ToString();  //사고자
                ss[3] = grid1[rpos, 27].ToString();  //공장
                //
                Form_memo_auto fm = new Form_memo_auto(ss);  //박스,메모1,사고자
                fm.ShowDialog();
            }
        }

        private void clickEvent_Click(object sender, EventArgs e)  //Grid1에서 작업의뢰서 클릭스
        {
            Excel_make ex = new Excel_make();
            ex.Get_Form3(grid1, grid1.Selection.ActivePosition.Row.ToString());
        }

        private void clickEvent_Click1(object sender, EventArgs e)  //Grid1에서 CTP주문정보 클릭시
        {
            int cpos = grid1.Selection.ActivePosition.Column;
            int rpos = grid1.Selection.ActivePosition.Row;

            string PrnCom = grid1[rpos, 28].ToString(); ;
            string Tel = grid1[rpos, 29].ToString(); ;
            string Memo = grid1[rpos, 30].ToString(); ;
            Form_604a Frm = new Form_604a(Control.MousePosition.X, Control.MousePosition.Y, PrnCom, Tel, Memo);
            Frm.ShowDialog();
        }

        private void bWork_Cancle_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("선택한 접수를 삭제합니까 ?", "삭제", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                string sub_Query = " where row_id = -1 ";
                string auto_id = " where row_id = -1 ";
                for (int i = 1; i < grid1.RowsCount; i++)
                {
                    if (grid1[i, 2].Value.Equals(true))
                    {
                        sub_Query += " or row_id = '"+grid1[i, 0].ToString()+"'" ; // corp_jumoon Query
                        auto_id += " or row_id = '" + grid1[i, 1].ToString() + "'";//auto Query
                    }
                }

                // grid에서 제거
                int s = 1;
                int count = grid1.RowsCount;
                for (int i = 1; i < count; i++)
                {
                    if (grid1[s, 2].Value.Equals(true))
                    {
                        grid1.Rows.Remove(s);
                    }
                    else
                        s++;
                }

                string cQuery = "";
                cQuery = "delete from " + DB_TableName_joo + sub_Query;
                GridHandle.DataUpdate(cQuery);
                cQuery = "update " + DB_TableName_auto + " set action = '1'" + auto_id;
                GridHandle.DataUpdate(cQuery);


            }
        }

        private void bDesignate_Com_Click(object sender, EventArgs e)
        {
            Form_604b Frm = new Form_604b();
            Frm.ShowDialog();
            string cQuery = "";
            string sub_Query = " where row_id = -1";
            if (Frm.choice_machine_id != "")
            {
                for (int i = 0; i < grid1.RowsCount ; i++)
                {
                    if (grid1[i, 2].Value.Equals(true))
                    {
                        sub_Query += " or row_id = '" + grid1[i, 0].ToString() + "' ";
                    }
                }

                cQuery = "update " + DB_TableName_joo + " set corp_machine_id='" + Frm.choice_machine_id + "' " + sub_Query;
                GridHandle.DataUpdate(cQuery);

                GridHandle.ChkCancel(2);
                bSearch_Click(null, null);
            }
        }

        private void Form_604_SizeChanged(object sender, EventArgs e)
        {
            this.grid1.Size = new System.Drawing.Size(this.Size.Width - 28, this.Height - 162);
        }
    }
}
