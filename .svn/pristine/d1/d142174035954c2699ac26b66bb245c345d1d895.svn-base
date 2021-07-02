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
    public partial class Form_605 : Form
    {
        const string DB_TableName_joo = "C_corp_jumoon";           // 하청업체 주문 테이블
        const string DB_TableName_joo_sub = "C_corp_jumoon_sub";   // 별도 항목으로 생성되는 하부 테이블
        string DB_TableName_auto = "C_auto2";        // 자동화창 Table
        string DB_TableName_client = "C_client";     // 회원정보 테이블
        string DB_TableName_hang = "hang_manage";    // 항목 테이블
        string DB_TableName_hcust = "C_hcustomer";   // 협력업체 테이블
        string DB_TableName_jumoon = "C_jumoon2";    // Local 주문 테이블에서 필요한 데이터 복사한 테이블
        string DB_TableName_hmachine = "C_hmachin";  // 협력업체 기계 테이블
        //
        public Form_605()
        {
            InitializeComponent();
        }

        private void Form_605_Load(object sender, EventArgs e)
        {
            Screen srn = Screen.PrimaryScreen;
            int Xb = this.Width;  //좌,우
            this.Location = new Point((srn.Bounds.Width - Xb) / 2, 1);  //좌/우,위/아래
            // 
            make_grid1();
        }


        private void make_grid1()  //그리드 생성
        {
            cell_d cc = new cell_d();
            SourceGridControl GH = new SourceGridControl();
            SourceGrid.Cells.Controllers.CustomEvents ClickedEvent1 = new SourceGrid.Cells.Controllers.CustomEvents();
            ClickedEvent1.Click += new EventHandler(Clicked1);
            //
            SourceGrid.Cells.Controllers.CustomEvents ValueChangedEvent1 = new SourceGrid.Cells.Controllers.CustomEvents();
            ValueChangedEvent1.ValueChanged += new EventHandler(ValueChanged1);
            //
            grid1.Rows.Clear();
            grid1.ColumnsCount = 16;
            grid1.FixedRows = 1;
            grid1.Rows.Insert(0);
            grid1.Rows[0].Height = 28;
            grid1.Selection.EnableMultiSelection = false;
            grid1.Selection.FocusStyle = grid1.Selection.FocusStyle | SourceGrid.FocusStyle.RemoveSelectionOnLeave;
            //
            grid1[0, 0] = new MyHeader1("row_id");  //고유번호(숨김)
            grid1.Columns[0].Visible = false;
            grid1[0, 1] = new EditableColumnHeader1("√");
            grid1[0, 2] = new MyHeader1("No");
            grid1[0, 3] = new MyHeader1("진행일");
            grid1[0, 4] = new MyHeader1("상  호");
            grid1[0, 5] = new MyHeader1("제 작 물 이 름");
            grid1[0, 6] = new MyHeader1("판싸이즈");
            grid1[0, 7] = new MyHeader1("입고처(인쇄업체)");
            grid1[0, 8] = new MyHeader1("수 량");
            grid1[0, 9] = new MyHeader1("제 외");
            grid1[0, 10] = new MyHeader1("수 거");
            grid1[0, 11] = new MyHeader1("단 가");
            grid1[0, 12] = new MyHeader1("금 액");
            grid1[0, 13] = new MyHeader1("세 금");
            grid1[0, 14] = new MyHeader1("총 액");
            grid1[0, 15] = new MyHeader1("row_id_sub");
            grid1.Columns[15].Visible = false;
            //
            grid1.Columns[0].Width = 60;
            grid1.Columns[1].Width = 24;
            grid1.Columns[2].Width = 30;
            grid1.Columns[3].Width = 86;
            grid1.Columns[4].Width = 110;
            grid1.Columns[5].Width = 230;
            grid1.Columns[6].Width = 70;
            grid1.Columns[7].Width = 140;
            grid1.Columns[8].Width = 50;
            grid1.Columns[9].Width = 40;
            grid1.Columns[10].Width = 60;
            grid1.Columns[11].Width = 70;
            grid1.Columns[12].Width = 80;
            grid1.Columns[13].Width = 70;
            grid1.Columns[14].Width = 80;
            grid1.Columns[15].Width = 80;
            //
            string s1,s2,s3;
            if (rbAll.Checked == true)
                s1 = "";
            else if (rbCheck.Checked == true)
                s1 = " and a.use_id='1'";
            else if (rbNonCheck.Checked == true)
                s1 = " and a.use_id='0'";
            else
                s1 = ""; 
            //
            if (string.IsNullOrEmpty(tbNalja1.Text))     
                s2 = "";
            else
                s2 = " and a.receive_date >='" + tbNalja1.Text + "'"; ;
            // 
            if (string.IsNullOrEmpty(tbNalja2.Text))     
                s3 = "";
            else
                s3 = " and a.receive_date <='" + tbNalja2.Text + "'"; ;
            // 
            var DBConn = new MySqlConnection(Config.DB_con1);
            DBConn.Open();
            //
            string cQuery = "select a.*, c.name, f.item, b.total_su, b.paper_name,b.memo1,h.sangho as prn_com,i.row_id as i_row_id,i.name_sub,i.item_sub,";
            cQuery += " i.paper_name_sub,i.prn_com_sub,i.total_su_sub from " + DB_TableName_joo + " as a ";
            cQuery += " Left outer join " + DB_TableName_auto + " as b on a.auto2_id = b.row_id ";
            cQuery += " Left outer join " + DB_TableName_client + " as c on a.client_id = c.row_id ";
            cQuery += " Left outer join " + DB_TableName_jumoon + " as f on f.jumoon_no = a.jumoon2_id";
            cQuery += " Left outer join " + DB_TableName_hmachine + " as g on g.row_id = a.corp_machine_id";
            cQuery += " Left outer join " + DB_TableName_hcust + " as h on h.row_id = g.int_id";
            cQuery += " Left outer join " + DB_TableName_joo_sub + " as i on a.sub_id = i.row_id";
            cQuery += " where b.action = '2' or b.action = '3' or b.action = '4' or a.jumoon2_id=-1" + s1 + s2 + s3 + " order by a.receive_date";
            //
            var cmd = new MySqlCommand(cQuery, DBConn);
            var myRead = cmd.ExecuteReader();
            int m = 1;
            while (myRead.Read())
            {
                grid1.Rows.Insert(m);
                grid1.Rows[m].Height = 22;
                //
                grid1[m, 0] = new SourceGrid.Cells.Cell(myRead["row_id"].ToString(), typeof(string));    //

                grid1[m, 1] = new SourceGrid.Cells.CheckBox(null, false);

                grid1[m, 2] = new SourceGrid.Cells.Cell(m, typeof(int));   //
                grid1[m, 2].View = cc.center_cell;
                grid1[m, 2].Editor = cc.disable_cell;

                grid1[m, 3] = new SourceGrid.Cells.Cell(myRead["receive_date"].ToString().Substring(0,10), typeof(string));   //
                grid1[m, 3].View = cc.center_cell;
                grid1[m, 3].Editor = cc.disable_cell;

                if (myRead["jumoon2_id"].ToString() == "-1")
                {
                    grid1[m, 4] = new SourceGrid.Cells.Cell(myRead["name_sub"].ToString(), typeof(string));   //
                    grid1[m, 4].View = cc.left_cellr;
                    grid1[m, 4].AddController(ValueChangedEvent1);
                }
                else
                {
                    grid1[m, 4] = new SourceGrid.Cells.Cell(myRead["name"].ToString(), typeof(string));   //
                    grid1[m, 4].View = cc.left_cell;
                    grid1[m, 4].Editor = cc.disable_cell;
                }

                if (myRead["jumoon2_id"].ToString() == "-1")
                {
                    grid1[m, 5] = new SourceGrid.Cells.Cell(myRead["item_sub"].ToString(), typeof(string));   //
                    grid1[m, 5].View = cc.left_cellr;
                    grid1[m, 5].AddController(ValueChangedEvent1);
                }
                else
                {
                    grid1[m, 5] = new SourceGrid.Cells.Cell(myRead["item"].ToString(), typeof(string));   //
                    grid1[m, 5].View = cc.left_cell;
                    grid1[m, 5].Editor = cc.disable_cell;
                }

                if (myRead["jumoon2_id"].ToString() == "-1")
                {
                    grid1[m, 6] = new SourceGrid.Cells.Cell(myRead["paper_name_sub"].ToString(), typeof(string));   //
                    grid1[m, 6].View = cc.center_cellr;
                    grid1[m, 6].AddController(ValueChangedEvent1);
                }
                else
                {
                    grid1[m, 6] = new SourceGrid.Cells.Cell(myRead["paper_name"].ToString(), typeof(string));   //
                    grid1[m, 6].View = cc.center_cell;
                    grid1[m, 6].Editor = cc.disable_cell;
                }

                if (myRead["jumoon2_id"].ToString() == "-1")
                {
                    grid1[m, 7] = new SourceGrid.Cells.Cell(myRead["prn_com_sub"], typeof(string));   // 인쇄업체
                    grid1[m, 7].View = cc.left_cellr;
                    grid1[m, 7].AddController(ValueChangedEvent1);
                }
                else
                {
                    grid1[m, 7] = new SourceGrid.Cells.Cell(myRead["prn_com"], typeof(string));   // 인쇄업체
                    grid1[m, 7].View = cc.left_cell;
                    grid1[m, 7].Editor = cc.disable_cell;
                }

                if (myRead["jumoon2_id"].ToString() == "-1")
                {
                    if (string.IsNullOrEmpty(myRead["total_su_sub"].ToString()))
                        grid1[m, 8] = new SourceGrid.Cells.Cell("0", typeof(string));  //수량
                    else
                        grid1[m, 8] = new SourceGrid.Cells.Cell(Convert.ToDecimal(GH.decimaldel(myRead["total_su_sub"].ToString())), typeof(string));  //수량
                    //
                    grid1[m, 8].View = cc.center_cellr;
                    grid1[m, 8].AddController(ValueChangedEvent1);
                }
                else
                {
                    if (string.IsNullOrEmpty(myRead["total_su"].ToString()))
                        grid1[m, 8] = new SourceGrid.Cells.Cell("0", typeof(string));  //수량
                    else
                        grid1[m, 8] = new SourceGrid.Cells.Cell(Convert.ToDecimal(GH.decimaldel(myRead["total_su"].ToString())), typeof(string));  //수량
                    //
                    grid1[m, 8].View = cc.center_cell;
                    grid1[m, 8].Editor = cc.disable_cell;
                }

                grid1[m, 9] = new SourceGrid.Cells.CheckBox(null, Convert.ToBoolean(myRead["use_id"].ToString()));
                grid1[m, 9].AddController(ClickedEvent1);

                grid1[m, 10] = new SourceGrid.Cells.Cell(myRead["collect"].ToString(), typeof(string));   //수거
                grid1[m, 10].View = cc.center_cell;
                grid1[m, 10].Editor = cc.disable_cell;

                grid1[m, 11] = new SourceGrid.Cells.Cell(string.Format("{0:n0}", myRead["ctp_danga"]), typeof(string));  //CTP단가
                grid1[m, 11].View = cc.int_cell;
                grid1[m, 11].Editor = cc.disable_cell;

                grid1[m, 12] = new SourceGrid.Cells.Cell(string.Format("{0:n0}", myRead["ctp_won"]), typeof(string));   //금액
                grid1[m, 12].View = cc.int_cell;
                grid1[m, 12].Editor = cc.disable_cell;

                grid1[m, 13] = new SourceGrid.Cells.Cell(string.Format("{0:n0}", myRead["ctp_tax"]), typeof(string));   //세금
                grid1[m, 13].View = cc.int_cell;
                grid1[m, 13].Editor = cc.disable_cell;

                grid1[m, 14] = new SourceGrid.Cells.Cell(string.Format("{0:n0}", myRead["ctp_twon"]), typeof(string));  //총액
                grid1[m, 14].View = cc.int_cell;
                grid1[m, 14].Editor = cc.disable_cell;

                grid1[m, 15] = new SourceGrid.Cells.Cell(myRead["i_row_id"].ToString(), typeof(string));    //

                m++;
            }
            myRead.Close();
            DBConn.Close();
        }

        private void Clicked1(object sender, EventArgs e)        //Grid1에서 원클릭시
        {
            int cpos = grid1.Selection.ActivePosition.Column;
            int row = grid1.Selection.ActivePosition.Row;
            // 
            var DBConn = new MySqlConnection(Config.DB_con1);
            DBConn.Open();
            string cQuery = "";
            string row_no = grid1[row, 0].ToString();  //row_id
            if (cpos.Equals(9))  //
            {
                if (grid1[row, 9].Value.Equals(true))
                    cQuery = " update " + DB_TableName_joo + " set use_id='1' where row_id='" + row_no + "'";
                else
                    cQuery = " update " + DB_TableName_joo + " set use_id='0' where row_id='" + row_no + "'";
                //
                var cmd = new MySqlCommand(cQuery, DBConn);
                if (cmd.ExecuteNonQuery() == 0)
                {
                    MessageBox.Show("DB 서버 오류 입니다.");
                }
            }
            DBConn.Close();
        }

        private void ValueChanged1(object sender, EventArgs e)   //Grid1에서 볼륨첸지
        {
            var DBConn = new MySqlConnection(Config.DB_con1);
            DBConn.Open();
            string cQuery = "";
            string xx = "";
            int pos = grid1.Selection.ActivePosition.Column;
            int row = grid1.Selection.ActivePosition.Row;
            //
            string dat = grid1[row, pos].ToString().Trim().Replace(",", "");
            string row_no = grid1[row, 15].ToString().Trim();  //row_id
            //
            if (pos == 4)
                cQuery = " update " + DB_TableName_joo_sub + " set name_sub='" + dat + "' where row_id='" + row_no + "'";
            else if (pos == 5)
                cQuery = " update " + DB_TableName_joo_sub + " set item_sub='" + dat + "' where row_id='" + row_no + "'";
            else if (pos == 6)
                cQuery = " update " + DB_TableName_joo_sub + " set paper_name_sub='" + dat + "' where row_id='" + row_no + "'";
            else if (pos == 7)
                cQuery = " update " + DB_TableName_joo_sub + " set prn_com_sub='" + dat + "' where row_id='" + row_no + "'";
            else if (pos == 8)
                cQuery = " update " + DB_TableName_joo_sub + " set total_su_sub='" + dat + "' where row_id='" + row_no + "'";
            else
                cQuery = "";
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

        private void bDanga_Click(object sender, EventArgs e)
        {
            bool x_id = false;
            if (string.IsNullOrEmpty(tbDanga.Text))
            {
                MessageBox.Show("단가를 입력해 주십시요..");
                return;
            }
            //
            bool save_id = false;
            for (int i = 1; i < grid1.Rows.Count; i++)   // 
            {
                if (grid1[i, 1].Value.Equals(true))
                {
                    save_id = true;
                    break;
                }
            }
            if (save_id == false)
            {
                MessageBox.Show("'√' 항목을 선택해 주십시요.");
                return;
            }
            //
            var DBConn = new MySqlConnection(Config.DB_con1);
            DBConn.Open();
            string cQuery = "";
            string[] ctp_s = new string[2];
            //
            string row_no = "";
            Double d_su = Convert.ToDouble(tbDanga.Text.Trim()) / 824000; 
            int t_su = 0; 
            int dwon = 0; 
            int vat = 0;  
            int twon = 0; 
            //
            for (int i = 1; i < grid1.Rows.Count; i++)   // 
            {
                if (grid1[i, 1].Value.Equals(true))
                {
                    x_id = true;
                    row_no = grid1[i, 0].ToString();
                    ctp_s = grid1[i, 6].ToString().Split(new char[1] { '*' });  //CTP싸이즈 분리
                    t_su =	(int)(Convert.ToDouble(ctp_s[0]) * Convert.ToDouble(ctp_s[1]) * d_su);  //단가
                    t_su = ((int)(t_su / 10 )) * 10 ;         //10단위버림  
	                //
					dwon = Convert.ToInt32(grid1[i, 8].ToString()) * t_su;          //금액 
					vat  = (int)(dwon * 0.1);   //세금
					twon = dwon + vat;          //총액 
                    //
                    cQuery = " update " + DB_TableName_joo + " set ctp_danga='" + t_su + "',ctp_won='" + dwon + "',ctp_tax='" + vat + "'";
                    cQuery += ",ctp_twon='" + twon + "' where row_id='" + row_no + "'";
                    //
                    var cmd = new MySqlCommand(cQuery, DBConn);
                    if (cmd.ExecuteNonQuery() == 0)
                    {
                        MessageBox.Show("DB 서버 오류 입니다.");
                        break;
                    }
                }
            }
            if (x_id)
                make_grid1();
            //
            DBConn.Close();
        }

        private void bSearch_Click(object sender, EventArgs e)  //검색
        {
            make_grid1();
        }

        private void tbDanga_KeyPress(object sender, KeyPressEventArgs e)  //
        {
            if (e.KeyChar == (char)13)
            {
                bDanga_Click(null,null);
            }
        }

        private void bCollect_Click(object sender, EventArgs e)  //수거처리
        {
            bool save_id = false;
            for (int i = 1; i < grid1.Rows.Count; i++)   // 
            {
                if (grid1[i, 1].Value.Equals(true))
                {
                    save_id = true;
                    break;
                }
            }
            if (save_id == false)
            {
                MessageBox.Show("'√' 항목을 선택해 주십시요.");
                return;
            }
            //
            save_id = false;
            if (rbCollect.Checked == false && rbNon_Collect.Checked == false)
            {
                MessageBox.Show("수거내용을 체크해 주십시요..");
                return;
            }
            //
            //
            var DBConn = new MySqlConnection(Config.DB_con1);
            DBConn.Open();
            string cQuery = "";
            //
            string row_no = "";
            string rb_cc = "";
            //
            if (rbCollect.Checked == true)
                rb_cc = "수거";
            else
                rb_cc = "미수거";
            // 
            for (int i = 1; i < grid1.Rows.Count; i++)   // 
            {
                if (grid1[i, 1].Value.Equals(true))
                {
                    save_id = true;
                    row_no = grid1[i, 0].ToString();
                    //
                    cQuery = " update " + DB_TableName_joo + " set collect='" + rb_cc + "' where row_id='" + row_no + "'";
                    //
                    var cmd = new MySqlCommand(cQuery, DBConn);
                    if (cmd.ExecuteNonQuery() == 0)
                    {
                        MessageBox.Show("DB 서버 오류 입니다.");
                        break;
                    }
                }
            }
            if (save_id)
                make_grid1();
            //
            DBConn.Close();
        }

        private void bNalja1_Click(object sender, EventArgs e)  //날자1
        {
            Calendar_Form fm = new Calendar_Form(tbNalja1);
            fm.ShowDialog();
        }

        private void bNalja2_Click(object sender, EventArgs e) //날자2
        {
            Calendar_Form fm = new Calendar_Form(tbNalja2);
            fm.ShowDialog();
        }

        private void bExcell_Click(object sender, EventArgs e)  //엑셀변환
        {
            SourceGrid.Grid grid = new SourceGrid.Grid();
            grid = grid1;
            for (int i = 1; i < grid.Rows.Count; i++)   // 
            {
                grid[i, 11].Value = grid[i, 11].ToString().Replace(",", "");   //
                grid[i, 12].Value = grid[i, 12].ToString().Replace(",", "");   //
                grid[i, 13].Value = grid[i, 13].ToString().Replace(",", "");   //
                grid[i, 14].Value = grid[i, 14].ToString().Replace(",", "");   //
            }
            // 
            try
            {
                string l_Path = System.IO.Path.Combine(System.IO.Path.GetTempPath(), "CsvFile.csv");

                using (System.IO.StreamWriter writer = new System.IO.StreamWriter(l_Path, false, System.Text.Encoding.Default))
                {
                    SourceGrid.Exporter.CSV csv = new SourceGrid.Exporter.CSV();
                    csv.Export(grid, writer);
                    writer.Close();
                }

                DevAge.Shell.Utilities.OpenFile(l_Path);
            }
            catch (Exception err)
            {
                DevAge.Windows.Forms.ErrorDialog.Show(this, err, "CSV Export Error");
            }
        }

        private void button1_Click(object sender, EventArgs e)  //항목추가
        {
            int row = 0;
            for (int i = 1; i < grid1.Rows.Count; i++)   // 
            {
                if (grid1[i, 1].Value.Equals(true))
                    row = i;
            }
            //
            if (row == 0)
            {
                MessageBox.Show("복사 선택한 항목이 없습니다.");
                return;
            }
            //
            var DBConn = new MySqlConnection(Config.DB_con1);
            DBConn.Open();
            string cQuery = "";
            //
            string[] dd = new string[15];
            dd[0] = "";
            dd[1] = "";
            dd[2] = "";                         
            dd[3] = grid1[row, 3].ToString();   //p_day
            dd[4] = grid1[row, 4].ToString();   //sangho-->'machine' 에 저장 
            dd[5] = grid1[row, 5].ToString();   //item --> 'paper_company' 에 저장
            dd[6] = grid1[row, 6].ToString();   //paper_name
            dd[7] = grid1[row, 7].ToString();   //인쇄공장 --> 'hari_file' 에 저장
            dd[8] = grid1[row, 8].ToString();   //total_su
            dd[9] = grid1[row, 9].ToString();   //use_id
            dd[10] = grid1[row, 10].ToString();  //collect
            dd[11] = grid1[row, 11].ToString().Replace(",", "");  //ctp_danga
            dd[12] = grid1[row, 12].ToString().Replace(",", "");  //ctp_won
            dd[13] = grid1[row, 13].ToString().Replace(",", "");  //ctp_tax
            dd[14] = grid1[row, 14].ToString().Replace(",", "");  //ctp_twon
            //
            cQuery = " INSERT INTO " + DB_TableName_joo_sub + " (name_sub,item_sub,paper_name_sub,prn_com_sub,total_su_sub)";
            cQuery += " VALUES('" + dd[4] + "','" + dd[5] + "','" + dd[6] + "','" + dd[7] + "'";
            cQuery += ",'" + dd[8] + "')";
            var cmd = new MySqlCommand(cQuery, DBConn);
            if (cmd.ExecuteNonQuery() == 0)
            {
                MessageBox.Show("DB 서버 오류 입니다.");
                return;
            }
            //
            string sub_no = "";
            cQuery = "SELECT LAST_INSERT_ID() dd";
            cmd = new MySqlCommand(cQuery, DBConn);
            var myRead = cmd.ExecuteReader();
            if (myRead.Read())
                sub_no = myRead[0].ToString();  //추가된 row_id 번호
            myRead.Close();
            // 
            cQuery = " INSERT INTO " + DB_TableName_joo + " (client_id,jumoon2_id,auto2_id,corp_machine_id,sub_id,print_company,company_tel";
            cQuery += ",work_memo,receive_date,collect,use_id,ctp_danga,ctp_won,ctp_tax,ctp_twon)";
            cQuery += " VALUES('294','-1','-1','','"+ sub_no +"','','','','" + dd[3] + "','" + dd[10] + "','" + dd[9] + "'";
            cQuery += ",'" + dd[11] + "','" + dd[12] + "','" + dd[13] + "','" + dd[14] + "')";
            //
            cmd = new MySqlCommand(cQuery, DBConn);
            cmd.ExecuteNonQuery();
            //
            DBConn.Close();
            make_grid1();
        }

        private void button2_Click(object sender, EventArgs e)  //항목삭제
        {
            bool save_id = false;
            for (int i = 1; i < grid1.Rows.Count; i++)   // 
            {
                if (grid1[i, 1].Value.Equals(true))
                {
                    save_id = true;
                    break;
                }
            }
            //
            if (save_id == false)
            {
                MessageBox.Show("삭제 선택한 항목이 없습니다.");
                return;
            }
            //
            if (MessageBox.Show("선택하신 항목을 삭제합니까 ?", "항목 삭제", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                string[] sd = new string[grid1.RowsCount];//
                for (int i = 0; i < sd.Length; i++)
                    sd[i] = "0";
                //
                int s = 0;
                for (int i = 1; i < grid1.Rows.Count; i++)   // 
                {
                    if (grid1[i, 1].Value.Equals(true))
                    {
                        sd[s] = grid1[i, 15].ToString().Trim();  //row_id
                        s++;
                    }
                }
                //
                var DBConn = new MySqlConnection(Config.DB_con1);
                DBConn.Open();
                string cQuery = "";
                string row_no = "";
                //
                for (int i = 0; i < sd.Length; i++)
                {
                    if (sd[i].Equals("0"))
                        break;
                    else
                    {
                        if (string.IsNullOrEmpty(sd[i]))     
                            continue;
                        //
                        row_no = sd[i];
                        cQuery = " delete from " + DB_TableName_joo + " where sub_id='" + row_no + "'";
                        var cmd = new MySqlCommand(cQuery, DBConn);
                        if (cmd.ExecuteNonQuery() == 0)
                        {
                            MessageBox.Show("DB 서버 오류 입니다.");
                            break;
                        }
                        else
                        {
                            cQuery = " delete from " + DB_TableName_joo_sub + " where row_id='" + row_no + "'";
                            cmd = new MySqlCommand(cQuery, DBConn);
                            cmd.ExecuteNonQuery();
                        }
                    }
                }
                DBConn.Close();
                make_grid1();
            }
        }
    }

    public class EditableColumnHeader1 : SourceGrid.Cells.ColumnHeader
    {
        private static LeftClickEditing leftClickEditing = new LeftClickEditing();

        public EditableColumnHeader1(string caption)
            : base(caption)
        {
            AddController(leftClickEditing);

            SourceGrid.Cells.Views.ColumnHeader view = new SourceGrid.Cells.Views.ColumnHeader();
            view.Font = new Font(FontFamily.GenericSansSerif, 8, FontStyle.Regular);
            view.TextAlignment = DevAge.Drawing.ContentAlignment.MiddleCenter;
            View = view;
            AutomaticSortEnabled = false;

            RemoveController(SourceGrid.Cells.Controllers.Unselectable.Default);
        }

        private class LeftClickEditing : SourceGrid.Cells.Controllers.ControllerBase
        {
            public override void OnMouseDown(SourceGrid.CellContext sender, MouseEventArgs e)
            {
                base.OnMouseDown(sender, e);

                if (e.Button == MouseButtons.Left)
                {
                    SourceGrid.Grid grid = (SourceGrid.Grid)sender.Grid;
                    bool x_id;
                    if (Convert.ToBoolean(grid[1, 1].ToString())) // 체크 되어있으면
                        x_id = false;
                    else
                        x_id = true;
                    //
                    for (int i = 1; i < grid.RowsCount; i++)
                        grid[i, 1].Value = x_id;
                }
            }
        }
    } 

}
