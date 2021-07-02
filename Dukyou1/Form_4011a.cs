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
    public partial class Form_4011a : Form
    {
        cell_d cc = new cell_d();

        string client_row_id = "";
        string mem_row_id = "";
        int Rows = 0;
        Form_4011 mom;
        string DB_TableName_Client = "C_client";
        string DB_TableName_Member = "C_member";
        string DB_TableName_Mac = "C_mac_address";
        string DB_TalbeName_file = "C_file_total_manage";
        string DB_TableName_Dealer = "C_dealer_manage";
        SourceGridControl FileGridHandle = new SourceGridControl();
        SourceGridControl MacGridHandle = new SourceGridControl();

        public Form_4011a(string row_id, Form_4011 mom, int Rows)
        {
            InitializeComponent();
            client_row_id = row_id;
            this.mom = mom;
            this.Rows = Rows;

            bSave.Visible = false;
            ReadOnlyControl();
        }

        private void Form_4011a_Load(object sender, EventArgs e)
        {
            string Query = "";
            ksgcontrol KC = new ksgcontrol();

            KC.ControlInit(Config.DB_con1, Config.Ftp_ip1, Config.Ftp_id1, Config.Ftp_pw1);
            FileGridHandle.SourceGrideInit(FileGrid, Config.DB_con1, Config.Ftp_ip1, Config.Ftp_id1, Config.Ftp_pw1);
            MacGridHandle.SourceGrideInit(MacGrid, Config.DB_con1, Config.Ftp_ip1, Config.Ftp_id1, Config.Ftp_pw1);
            MacGrid.HorizontalScroll.Enabled = false;

            KC.ComboBoxItemInsert("C_ctp_danga_model", "grade_name", cbCTPGrade);


            Query = "select * from " + DB_TableName_Client + " where row_id = '" + client_row_id + "'";
            var DBConn = new MySqlConnection(Config.DB_con1);
            DBConn.Open();
            var cmd = new MySqlCommand(Query, DBConn);

            var myRead = cmd.ExecuteReader();

            myRead.Read();

            tbRegistDay.Text = myRead["registday"].ToString();
            tbRegistDay.Refresh();

            tbID.Text = myRead["id"].ToString();
            tbID.Refresh();

            tbMaxCnt.Text = myRead["max_cnt"].ToString();
            tbMaxCnt.Refresh();

            tbTrader.Text = myRead["trader"].ToString();
            tbTrader.Refresh();

            cbVer.Text = myRead["ver"].ToString();
            cbVer.Refresh();

            tbStartDate.Text = myRead["start_date"].ToString();
            tbStartDate.Refresh();

            tbEndDate.Text = myRead["end_date"].ToString();
            tbEndDate.Refresh();

            tbPayInfo1.Text = myRead["pay_info1"].ToString();
            tbPayInfo1.Refresh();

            tbPayInfo2.Text = myRead["pay_info2"].ToString();
            tbPayInfo2.Refresh();

            tbPayCharge.Text = myRead["pay_charge"].ToString();
            tbPayCharge.Refresh();

            tbPhone.Text = myRead["tel"].ToString();
            tbPhone.Refresh();

            tbChargePhone.Text = myRead["pay_phone"].ToString();
            tbChargePhone.Refresh();

            tbMemo.Text = myRead["memo"].ToString();
            tbMemo.Refresh();

            tbPermission.Text = myRead["permission_grade"].ToString();
            tbPermission.Refresh();

            string main_com = chk_double_dealer(client_row_id);
            if (main_com != "")  // 딜러로 등록되어 있는 업체라면.
            {
                label17.Text = "Main 업체";
                label17.Location = new System.Drawing.Point(175, 74);
                tbMainCompany.Location = new System.Drawing.Point(240, 69);
                tbMainCompany.Text = main_com;
                tbMainCompany.Enabled = false;
                tbMainCompany.Refresh();
                cbCTPGrade.Visible = false;

            }
            else
            {
                cbCTPGrade.Text = myRead["ctp_danga_grade"].ToString();
                cbCTPGrade.Refresh();
                tbMainCompany.Visible = false;
            }

            if (myRead["use_erp"].ToString() == "1")
            {
                rbUse.Checked = true;
                rbBan.Checked = false;
            }
            else
            {
                rbUse.Checked = false;
                rbBan.Checked = true;
            }

            if (myRead["personal_grade"].ToString() == "1")
            {
                cbDanga_DB.Text = "개별";
            }
            else
            {
                cbDanga_DB.Text = "공용";
            }
            myRead.Close();
            DBConn.Close();
            GetUserGrid();
            GetFileGrid();

        }

        public void ReadOnlyControl()
        {
            tbRegistDay.ReadOnly = true;
            tbID.ReadOnly = true;
            tbMaxCnt.ReadOnly = true;
            tbTrader.ReadOnly = true;
            cbVer.Enabled = false;
            cbCTPGrade.Enabled = false;
            tbStartDate.ReadOnly = true;
            tbEndDate.ReadOnly = true;
            tbPayInfo1.ReadOnly = true;
            tbPayInfo2.ReadOnly = true;
            tbPayCharge.ReadOnly = true;
            tbPhone.ReadOnly = true;
            tbChargePhone.ReadOnly = true;
            rbBan.AutoCheck = false;
            rbUse.AutoCheck = false;

            bStartDate.Visible = false;
            bEndDate.Visible = false;
            bPermission.Visible = false;
            
        }

        public void ModiControl()
        {
            tbMaxCnt.ReadOnly = false;
            tbTrader.ReadOnly = false;
            cbVer.Enabled = true;
            cbCTPGrade.Enabled = true;
            tbStartDate.ReadOnly = false;
            tbEndDate.ReadOnly = false;
            tbPayInfo1.ReadOnly = false;
            tbPayInfo2.ReadOnly = false;
            tbPayCharge.ReadOnly = false;
            tbPhone.ReadOnly = false;
            tbChargePhone.ReadOnly = false;
            rbBan.AutoCheck = true;
            rbUse.AutoCheck = true;


            bStartDate.Visible = true;
            bEndDate.Visible = true;
            bPermission.Visible = true;

        }

        public void GetUserGrid()
        {
            string Query = "select * from " + DB_TableName_Member + " where int_id = '" + client_row_id + "'";

            int Rows = 0;

            UserGrid.Rows.Clear();

            UserGrid.BorderStyle = BorderStyle.FixedSingle;
            UserGrid.ColumnsCount = 3;
            UserGrid.FixedRows = 1;

            UserGrid.Rows.Insert(0);

            UserGrid.Rows[0].Height = 26;

            UserGrid[Rows, 0] = new MyHeader1("row_id");
            UserGrid.Columns[0].Visible = false;

            UserGrid[Rows, 1] = new MyHeader1("");

            UserGrid[Rows, 2] = new MyHeader1("ID");

            Rows++;

            var DBConn = new MySqlConnection(Config.DB_con1);
            DBConn.Open();
            var cmd = new MySqlCommand(Query, DBConn);

            var myRead = cmd.ExecuteReader();

            UserGrid.Columns[1].Width = 30;
            UserGrid.Columns[2].Width = 96;


            while (myRead.Read())
            {
                UserGrid.Rows.Insert(Rows);
                UserGrid.Rows[Rows].Height = 24;

                UserGrid[Rows, 0] = new SourceGrid.Cells.Cell(myRead["row_id"], typeof(string));

                if (Rows == 1)
                {
                    mem_row_id = UserGrid[Rows, 0].ToString();
                    string cQuery = "select * from " + DB_TableName_Mac + " where com_id = '" + client_row_id + "' and mem_id = '" + UserGrid[Rows, 0].ToString() + "'";
                    
                    GetMacGrid(cQuery);
                    var position = new SourceGrid.Position(1, 1);
                    UserGrid.Selection.Focus(position, true);
                }

                UserGrid[Rows, 1] = new SourceGrid.Cells.Cell(Rows.ToString(), typeof(string));
                UserGrid[Rows, 1].View = cc.int_cell;
                UserGrid[Rows, 1].Editor = cc.disable_cell;

                UserGrid[Rows, 2] = new SourceGrid.Cells.Cell(myRead["name"], typeof(string));
                UserGrid[Rows, 2].View = cc.center_cell;
                UserGrid[Rows, 2].Editor = cc.disable_cell;


                Rows++;
            }

            myRead.Close();
            DBConn.Close();

        }

        public void GetMacGrid(string Query)
        {
            int Rows = 0;

            MacGrid.Rows.Clear();

            MacGrid.BorderStyle = BorderStyle.FixedSingle;
            MacGrid.ColumnsCount = 7;
            MacGrid.FixedRows = 1;

            MacGrid.Rows.Insert(0);

            MacGrid.Rows[0].Height = 26;

            MacGrid[Rows, 0] = new MyHeader1("row_id");
            MacGrid.Columns[0].Visible = false;

            MacGrid[Rows, 1] = new MyHeader1("√");

            MacGrid[Rows, 2] = new MyHeader1("No");
            MacGrid[Rows, 3] = new MyHeader1("mac_별칭");
            MacGrid[Rows, 4] = new MyHeader1("접속현황");
            MacGrid[Rows, 5] = new MyHeader1("허용여부");
            MacGrid[Rows, 6] = new MyHeader1("mac_address");
            MacGrid.Columns[6].Visible = false;

            Rows++;

            var DBConn = new MySqlConnection(Config.DB_con1);
            DBConn.Open();
            var cmd = new MySqlCommand(Query, DBConn);

            var myRead = cmd.ExecuteReader();

            MacGrid.Columns[1].Width = 20;
            MacGrid.Columns[2].Width = 25;
            MacGrid.Columns[3].Width = 120;
            MacGrid.Columns[4].Width = 85;
            MacGrid.Columns[5].Width = 85;

            while (myRead.Read())
            {
                MacGrid.Rows.Insert(Rows);
                MacGrid.Rows[Rows].Height = 24;

                MacGrid[Rows, 0] = new SourceGrid.Cells.Cell(myRead["row_id"], typeof(string));

                MacGrid[Rows, 1] = new SourceGrid.Cells.CheckBox(null, false);

                MacGrid[Rows, 2] = new SourceGrid.Cells.Cell(Rows.ToString(), typeof(string));
                MacGrid[Rows, 2].View = cc.int_cell;
                MacGrid[Rows, 2].Editor = cc.disable_cell;

                MacGrid[Rows, 3] = new SourceGrid.Cells.Cell(myRead["mac_alias"], typeof(string));
                MacGrid[Rows, 3].View = cc.center_cell;
                MacGrid[Rows, 3].Editor = cc.disable_cell;

                if(myRead["n_use"].ToString() == "True")
                    MacGrid[Rows, 4] = new SourceGrid.Cells.Cell("사용", typeof(string));
                else
                    MacGrid[Rows, 4] = new SourceGrid.Cells.Cell("미사용", typeof(string));

                MacGrid[Rows, 4].View = cc.center_cell;
                MacGrid[Rows, 4].Editor = cc.disable_cell;

                if (myRead["permit_chk"].ToString() == "True")
                    MacGrid[Rows, 5] = new SourceGrid.Cells.Cell("O", typeof(string));
                else
                    MacGrid[Rows, 5] = new SourceGrid.Cells.Cell("X", typeof(string));

                MacGrid[Rows, 5].View = cc.center_cell;
                MacGrid[Rows, 5].Editor = cc.disable_cell;

                MacGrid[Rows, 6] = new SourceGrid.Cells.Cell(myRead["mac_address"].ToString(), typeof(string));

                Rows++;
            }

            myRead.Close();
            DBConn.Close();
        }

        public void GetFileGrid()
        {
            ValueChangedEvent valueChangedController = new ValueChangedEvent();

            string Query = "select * from "+DB_TalbeName_file+" where db_nm='" + DB_TableName_Client + "' and int_id= '" + client_row_id + "'";

            int Rows = 0;

            FileGrid.Rows.Clear();

            FileGrid.BorderStyle = BorderStyle.FixedSingle;
            FileGrid.ColumnsCount = 6;
            FileGrid.FixedRows = 1;

            FileGrid.Rows.Insert(0);

            FileGrid.Rows[0].Height = 26;

            FileGrid[Rows, 0] = new MyHeader1("row_id");
            FileGrid.Columns[0].Visible = false;

            FileGrid[Rows, 1] = new MyHeader1("√");

            FileGrid[Rows, 2] = new MyHeader1("No");
            FileGrid[Rows, 3] = new MyHeader1("파일명");
            FileGrid[Rows, 4] = new MyHeader1("file_path");
            FileGrid.Columns[4].Visible = false;
            FileGrid[Rows, 5] = new MyHeader1("요약설명");

            Rows++;

            var DBConn = new MySqlConnection(Config.DB_con1);
            DBConn.Open();
            var cmd = new MySqlCommand(Query, DBConn);

            var myRead = cmd.ExecuteReader();

            FileGrid.Columns[1].Width = 20;
            FileGrid.Columns[2].Width = 30;
            FileGrid.Columns[3].Width = 83;
            FileGrid.Columns[5].Width = 135;

            while ( myRead.Read())
            {
                FileGrid.Rows.Insert(Rows);
                FileGrid.Rows[Rows].Height = 24;

                FileGrid[Rows, 0] = new SourceGrid.Cells.Cell(myRead["row_id"], typeof(string));
                FileGrid[Rows, 1] = new SourceGrid.Cells.CheckBox(null, false);

                FileGrid[Rows, 2] = new SourceGrid.Cells.Cell(Rows.ToString(), typeof(string));
                FileGrid[Rows, 2].View = cc.int_cell;
                FileGrid[Rows, 2].Editor = cc.disable_cell;

                FileGrid[Rows, 3] = new SourceGrid.Cells.Cell(myRead["user_file"], typeof(string));
                FileGrid[Rows, 3].Editor = cc.disable_cell;

                FileGrid[Rows, 4] = new SourceGrid.Cells.Cell(myRead["server_file"], typeof(string));

                FileGrid[Rows, 5] = new SourceGrid.Cells.Cell(myRead["comment"], typeof(string));
                FileGrid[Rows, 5].View = cc.center_cell;
                FileGrid[Rows, 5].AddController(valueChangedController);

                Rows++;

            }

            myRead.Close();
            DBConn.Close();
        
        }

        private void UserGrid_MouseClick(object sender, MouseEventArgs e)
        {
            int column = UserGrid.Selection.ActivePosition.Column;
            int Rows = UserGrid.Selection.ActivePosition.Row;

            if (Rows < 0)
                return;

            string row_no = "";
            row_no = UserGrid[Rows, 0].ToString().Trim();
            mem_row_id = row_no;
            string Query = Query = "select * from " + DB_TableName_Mac + " where com_id = '" + client_row_id + "' and mem_id = '" + mem_row_id + "'";
            if (rbPermit.Checked == true)
                Query = "select * from " + DB_TableName_Mac + " where permit_chk = 1 and com_id = '" + client_row_id + "' and mem_id = '" + mem_row_id + "'";
            if(rbDel.Checked == true)
                Query = "select * from " + DB_TableName_Mac + " where permit_chk = 0 and com_id = '" + client_row_id + "' and mem_id = '" + mem_row_id + "'";
            
            GetMacGrid(Query);
        }

        private void FileGrid_DoubleClick(object sender, EventArgs e)
        {
            if (client_row_id == "")
            {
                MessageBox.Show("선택된 사용자가 없습니다. 선택후 사용하여 주십시오");
                return;
            }

            int now_row = FileGrid.Selection.ActivePosition.Row;
            int now_column = FileGrid.Selection.ActivePosition.Column;

            if (now_column == -1)
                return;
            if (now_column == 5)   //  요약설명을 더블클릭하면 return; 하여 text 입력가능하게..
                return;

            if (FileGrid[now_row, 4].ToString() == "")
                return;

            string FilePath = DB_TableName_Client+"\\"+FileGrid[now_row, 4].ToString().Trim();  //3번이 user_file 명.

            SaveFileDialog sfd = new SaveFileDialog();
            sfd.Title = "Save File";
            sfd.FileName =FileGrid[now_row, 3].ToString().Trim();  //3번이 user_file 명.
            sfd.Filter = "ALL File(*.*)|*.*";
            sfd.InitialDirectory = "C:\\";
            sfd.RestoreDirectory = true;

            if (sfd.ShowDialog() == DialogResult.OK)
            {
                OhFTP Ftp = new OhFTP(Config.Ftp_ip1, Config.Ftp_id1, Config.Ftp_pw1);
                Ftp.DownLoadFile1(@sfd.FileName, FilePath);
                MessageBox.Show(sfd.FileName + " 내려받기 완료");
            }
        }

        private void bFileAdd_Click(object sender, EventArgs e)
        {
            if (client_row_id == "")
            {
                MessageBox.Show("선택된 사용자가 없습니다. 선택후 사용하여 주십시오");
                return;
            }

            OpenFileDialog ofd = new OpenFileDialog();// File descriptor
            FileControl FC = new FileControl();
            FC.FileControlInit(Config.DB_con1, Config.Ftp_ip1, Config.Ftp_id1, Config.Ftp_pw1);

            if (FC.FileOpenDlg(ofd) == 1)
                return;

            string server_file_name = FC.FileReg(ofd, DB_TableName_Client, "sub_file", client_row_id, "file");
            GetFileGrid();
        }

        private void bFileDel_Click(object sender, EventArgs e)
        {
            if (client_row_id == "")
            {
                MessageBox.Show("선택된 사용자가 없습니다. 선택후 사용하여 주십시오");
                return;
            }

            FileControl FC = new FileControl();
            FC.FileControlInit(Config.DB_con1, Config.Ftp_ip1, Config.Ftp_id1, Config.Ftp_pw1);

            int first_data_row = 1;
            int chkbox_position = 1;
            int row_id_position = 0;
            int file_position = 4;
            string s1 = "";
            string Query = "";
            for (int i = first_data_row; i < FileGrid.RowsCount; i++)
            {
                if (FileGrid[i, chkbox_position].Value.Equals(true))
                {
                    FC.FileDel(FileGrid[i, file_position].Value.ToString(), DB_TableName_Client);
                    s1 += " or row_id='" + FileGrid[i, row_id_position].Value.ToString() + "'";
                }
            }

            if (s1 != "") // 지울데이터가 있음
            {
                Query = "delete from " + DB_TalbeName_file + " where  row_id < 0" + s1;
                FC.DataUpdate(Query);
                MessageBox.Show("file을 삭제하였습니다");

                Query = "select * from " + DB_TalbeName_file + " where db_nm='" + DB_TableName_Client + "' and int_id = '" + client_row_id + "' and f_option = 'file'";

                var DBConn = new MySqlConnection(Config.DB_con1);
                DBConn.Open();
                var cmd = new MySqlCommand(Query, DBConn);

                var myRead = cmd.ExecuteReader();
                if (!myRead.Read())
                {
                    Query = "update " + DB_TableName_Client + " set sub_file = '0' where row_id = '" + client_row_id + "'";
                    FileGridHandle.DataUpdate(Query);
                }
                myRead.Close();
                DBConn.Close();
                GetFileGrid();
            }
            else
                MessageBox.Show("삭제할 file을 체크하여 주십시오");

            
        }

        private void bAddrDel_Click(object sender, EventArgs e)
        {
            if (client_row_id == "")
            {
                MessageBox.Show("선택된 사용자가 없습니다. 선택후 사용하여 주십시오");
                return;
            }

            MacGridHandle.ChkDataDelete(DB_TableName_Mac, 1, 0, 1);

        }

        private void bDisCon_Click(object sender, EventArgs e)
        {
            if (client_row_id == "")
            {
                MessageBox.Show("선택된 사용자가 없습니다. 선택후 사용하여 주십시오");
                return;
            }
            //string mac_row_id = MacGrid[
            string Query = "update " + DB_TableName_Mac + " set n_use = false where com_id = '" + client_row_id + "' and mem_id = '"+mem_row_id+"'";
            MacGridHandle.DataUpdate(Query);
            Query = "select * from " + DB_TableName_Mac + " where com_id = '" + client_row_id + "' and mem_id = '" + mem_row_id + "'";
            GetMacGrid(Query);
        }

        private void bModi_Click(object sender, EventArgs e)
        {
            if (client_row_id == "")
            {
                MessageBox.Show("선택된 사용자가 없습니다. 선택후 사용하여 주십시오");
                return;
            }
            bModi.Visible = false;
            bSave.Visible = true;

            ModiControl();
        }

        private void bSave_Click(object sender, EventArgs e)
        {
            bModi.Visible = true;
            bSave.Visible = false;

            ReadOnlyControl();

            string Max_Cnt = tbMaxCnt.Text;
            string Trader = tbTrader.Text;
            string Ver = cbVer.Text;
            string StartDate = tbStartDate.Text;
            string EndDate = tbEndDate.Text;
            string PayInfo1 = tbPayInfo1.Text;
            string PayInfo2 = tbPayInfo2.Text;
            string PayCharge = tbPayCharge.Text;
            string Phone = tbPhone.Text;
            string ChargePhone = tbChargePhone.Text;
            string Erp_use = "";
            string Personal_grade = "";
            string CTP_danga_grade = cbCTPGrade.Text;
            string permission = tbPermission.Text;
            if (rbUse.Checked == true)
                Erp_use = "true";
            else
                Erp_use = "false";

            if (cbDanga_DB.Text == "개별")
                Personal_grade = "true";
            else
                Personal_grade = "false";

            string Query = "update " + DB_TableName_Client + " set max_cnt = " + Max_Cnt + ", trader = '" + Trader + "'";
            Query += ", ver='" + Ver + "', start_date='" + StartDate + "', end_date='" + EndDate + "', pay_info1='" + PayInfo1 + "'";
            Query += ", pay_info2='" + PayInfo2 + "', pay_charge='" + PayCharge + "', tel='" + Phone + "', pay_phone='" + ChargePhone + "'";
            Query += ", use_erp=" + Erp_use + ", personal_grade = " + Personal_grade + ", ctp_danga_grade = '" + CTP_danga_grade + "', permission_grade = '" + permission + "' where row_id = '" + client_row_id + "'"; 


            FileGridHandle.DataUpdate(Query); // Handle은 DB_Center 이면 어떠한 핸들을 사용하던지 무방함

            mom.GridLineRefresh(Rows);

        }

        private void bPwInit_Click(object sender, EventArgs e)
        {
            if (client_row_id == "")
            {
                MessageBox.Show("선택된 사용자가 없습니다. 선택후 사용하여 주십시오");
                return;
            }
            string Query = "";
            string PW_Init = "1234";

            Query = "update " + DB_TableName_Client + " set pw = password('" + PW_Init + "') where row_id = '" + client_row_id + "'";
            FileGridHandle.DataUpdate(Query); // Handle은 DB_Center 이면 어떠한 핸들을 사용하던지 무방함
            MessageBox.Show("비밀번호를 1234으로 초기화하였습니다");
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

        private void bMemoSave_Click(object sender, EventArgs e)
        {
            if (client_row_id == "")
            {
                MessageBox.Show("선택된 사용자가 없습니다. 선택후 사용하여 주십시오");
                return;
            }
            string Query = "";
            string memo = "";

            memo = tbMemo.Text;

            Query = "update " + DB_TableName_Client + " set memo ='" + memo + "' where row_id = '" + client_row_id + "'";
            FileGridHandle.DataUpdate(Query);
        }

        public class ValueChangedEvent : SourceGrid.Cells.Controllers.ControllerBase
        {
            string DB_TalbeName_file = "C_file_total_manage";
            public override void OnValueChanged(SourceGrid.CellContext sender, EventArgs e)
            {
                base.OnValueChanged(sender, e);
                int ps = sender.Position.Column;
                SourceGrid.Grid grid = (SourceGrid.Grid)sender.Grid;
                string row_no = grid[grid.Selection.ActivePosition.Row, 0].ToString().Trim();
                string dat;
                if (sender.Value == null)
                    dat = "";
                else
                    dat = sender.Value.ToString().Trim();
                string cQuery;
                //

                cQuery = "update " + DB_TalbeName_file + " set comment";
                cQuery += "= '"+dat+"' where row_id = '"+row_no+"'";
            
                var DBConn = new MySqlConnection(Config.DB_con1);
                DBConn.Open();
                var cmd = new MySqlCommand(cQuery, DBConn);
                if (cmd.ExecuteNonQuery() == 0)
                    MessageBox.Show("서버 자료 수정에 실패 했습니다.");
                DBConn.Close();

            }
        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void Form_4011a_FormClosing(object sender, FormClosingEventArgs e)
        {
        }

        private void bInsertDB_Click(object sender, EventArgs e)
        {
            Form_4011c Frm = new Form_4011c(client_row_id);
            Frm.ShowDialog();
        }

        private void bPermit_Click(object sender, EventArgs e)
        {
            string Query = "";
            for(int i = 1; i<MacGrid.RowsCount; i++)
            {
                if (MacGrid[i, 1].Value.Equals(true))
                {
                    Query = "update " + DB_TableName_Mac + " set permit_chk = 1 where mac_address = '" + MacGrid[i, 6].ToString() + "'";
                    MacGridHandle.DataUpdate(Query);

                    for (int m = 1; m < MacGrid.RowsCount; m++)
                    {
                        if (MacGrid[m, 6].ToString() == MacGrid[i, 6].ToString())
                        {
                            MacGrid[m, 1] = new SourceGrid.Cells.CheckBox(null, false);

                            MacGrid[m, 5] = new SourceGrid.Cells.Cell("O", typeof(string));

                            MacGrid[m, 5].View = cc.center_cell;
                            MacGrid[m, 5].Editor = cc.disable_cell;
                        }
                    }
                }
            }

            MacGrid.Refresh();

            MessageBox.Show("허용 되었습니다");
        }

        private void rbPermit_CheckedChanged(object sender, EventArgs e)
        {
            string Query = "select * from " + DB_TableName_Mac + " where permit_chk = 1 and com_id = '" + client_row_id + "' and mem_id = '" + mem_row_id + "'";
            GetMacGrid(Query);
        }

        private void rbDel_CheckedChanged(object sender, EventArgs e)
        {
            string Query = "select * from " + DB_TableName_Mac + " where permit_chk = 0 and com_id = '" + client_row_id + "' and mem_id = '" + mem_row_id + "'";
            GetMacGrid(Query);
        }

        private void bDel_Click(object sender, EventArgs e)
        {
            string Query = "";
            for (int i = 1; i < MacGrid.RowsCount; i++)
            {
                if (MacGrid[i, 1].Value.Equals(true))
                {
                    Query = "update " + DB_TableName_Mac + " set permit_chk = 0 where mac_address = '" + MacGrid[i, 6].ToString() + "'";
                    MacGridHandle.DataUpdate(Query);

                    for (int m = 1; m < MacGrid.RowsCount; m++)
                    {
                        if (MacGrid[m, 6].ToString() == MacGrid[i, 6].ToString())
                        {
                            MacGrid[m, 1] = new SourceGrid.Cells.CheckBox(null, false);

                            MacGrid[m, 5] = new SourceGrid.Cells.Cell("X", typeof(string));

                            MacGrid[m, 5].View = cc.center_cell;
                            MacGrid[m, 5].Editor = cc.disable_cell;
                        }
                    }
                }
            }

            MacGrid.Refresh();

            MessageBox.Show("불허 처리 되었습니다");
        }

        private void rbAll_CheckedChanged(object sender, EventArgs e)
        {
            string Query = "select * from " + DB_TableName_Mac + " where com_id = '" + client_row_id + "' and mem_id = '" + mem_row_id + "'";
            GetMacGrid(Query);
        }

        // 이미 딜러회사로 등록되어있는지 확인 여부 검사
        // input : 딜러회사 row_id(C_client)
        // output : 딜러가 아니면 "", 이미 등록되어있으면 부모의 상호를 return
        private string chk_double_dealer(string dealer_id)
        {
            string cQuery = "select b.name from " + DB_TableName_Dealer + " as a left outer join C_client as b ";
            cQuery += " on a.parents_id = b.row_id where dealer_id = '" + dealer_id + "'";

            MySqlConnection DBConn;
            DBConn = new MySqlConnection(Config.DB_con1);
            util.Con_DB_Open(ref DBConn);

            var cmd = new MySqlCommand(cQuery, DBConn);
            var myRead = cmd.ExecuteReader();

            if (myRead.Read())
            {
                string name = myRead["name"].ToString();
                myRead.Close();
                DBConn.Close();
                return name;
            }

            myRead.Close();
            DBConn.Close();
            return "";
        }

        private void bPermission_Click(object sender, EventArgs e)
        {
            Form_4011e fm = new Form_4011e(tbPermission.Text, tbPermission);
            if (fm.ShowDialog() == DialogResult.OK)
                tbPermission.Text = fm.permission;
        }
    }
}
