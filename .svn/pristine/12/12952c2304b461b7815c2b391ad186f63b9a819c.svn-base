using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using SourceGrid;
using SourceGrid.Cells.Controllers;
using System.IO;

namespace Dukyou3
{
    public partial class Form_auto : Form
    {
        string joo_id = "";  //구분(견적=1,주문=2)
        string joo_no = "";  //주문번호
        bool sel_id = false; //초기화 여부  true=초기화함, false=안함
        DataTable b_model = new DataTable();      //b_model 자료 테이블
        DataTable c_model = new DataTable();      //c_model 자료 테이블
        DataTable hang_dt = new DataTable();      //항목 테이블
        DataTable h_customer = new DataTable();   //협력업체 테이블
        DataTable jebona_dat = new DataTable();   //제본항목 테이블a
        DataTable trans_dat = new DataTable();    //운송 테이블
        DataTable progres = new DataTable();      //공정 테이블
        DataTable sel_jul = new DataTable();      //접지가져오는 테이블(메인)
        DataTable sel_jul_sub = new DataTable();  //접지가져오는 테이블(서브)
        DataTable prn_dt = new DataTable();       //인쇄테이블
        //단가 호출시 사용
        DataTable bungae = new DataTable();         //분개장 테이블
        DataTable choice_com = new DataTable();     //초기설정 업체
        DataTable danga_dat = new DataTable();      //단가 테이블
        DataTable danga_dat_sub = new DataTable();  //단가 부메뉴 테이블
        DataTable paper = new DataTable();          //종이정보 테이블
        DataTable paper_sub = new DataTable();      //종이단가 테이블
        
        //
        string DB_TableName4 = "";  //자동화창 테이블
        string DB_TableName5 = "";  //공정 테이블
        string DB_TableName6 = "";  //운송 테이블
        
       //
        string[] n_db = new string[60]; //함축자료 배열(분개장에서 사용)
        // 
        string[] dd = new string[3];    //dd = 종이싸이즈,가로개수,세로갯수-->블랙박스 돌릴때 사용하는 것임 //sel_pp.sel_paper(pp, false, dd)
        int grid1_col = 0;                        //그리드1 재검색전 칼럼 위치
        int grid1_row = 1;                        //그리드1 재검색전 row 위치

        string client_id = "";          // 고객 row_id
        string busu = "";               // 부수
        string docu = "";               // 도큐
        //
        public Form_auto(string id, string joo, bool s_id, string client_id, string item)
        {
            InitializeComponent();
            joo_id = id;
            joo_no = joo;
            sel_id = s_id;      //초기화여부 true=초기화함,false=안함
            
            DB_TableName4 = "C_auto2";
            DB_TableName5 = "C_progres2";
            DB_TableName6 = "C_transd2";
            this.client_id = client_id;
            tbItem.Text = item;
        }

        public Form_auto(string id, string joo, bool s_id, string client_id, string item, string set_number)
        {
            InitializeComponent();
            this.Visible = false;
            joo_id = id;
            joo_no = joo;
            sel_id = s_id;      //초기화여부 true=초기화함,false=안함

            DB_TableName4 = "C_auto2";
            DB_TableName5 = "C_progres2";
            DB_TableName6 = "C_transd2";
            this.client_id = client_id;
            tbItem.Text = item;
            Form32_Load(null, null);

            for (int i = 1; i < grid1.RowsCount; i++)
            {
                if (grid1[i, 43].Value.ToString() == set_number && grid1[i, 4].Value.ToString().IndexOf("인쇄") > -1)
                {
                    int cpos = 14;
                    int row = i;
                    if (row < 0)
                        return;

                    if (cpos.Equals(14))  //하리모형 열기
                    {
                        string[] m_db = new string[60];         //함축자료 배열
                        string[] dat = new string[10];
                        m_db = grid1[row, 30].ToString().Split(new char[1] { '#' });
                        //
                        string j_bon = m_db[54];   //제본옵션
                        string sd = "2";  //자동화창에서호출
                        //
                        dat[0] = grid1[row, 0].ToString();  //row_id
                        dat[1] = grid1[row, 7].ToString();  //서버항목명 --> [닷찌]등
                        dat[2] = grid1[row, 8].ToString();  //전체 종이이름
                        dat[3] = grid1[row, 30].ToString(); //복합자료(m_dat)
                        dat[4] = grid1[row, 31].ToString(); //하리수정불가 표시
                        dat[5] = grid1[row, 14].ToString(); //인쇄유형
                        dat[6] = grid1[row, 51].ToString(); //원 인쇄유형
                        dat[7] = grid1[row, 20].ToString(); //수량
                        dat[8] = grid1[row, 24].ToString(); //단가
                        dat[9] = grid1[row, 17].ToString(); //대수
                        //  
                        Form_hari fm = new Form_hari(dat, sd, j_bon, joo_id, grid1);  //분개장Row,기본,제본옵션,주문/견적
                        if (fm.ShowDialog() == DialogResult.OK)
                        {
                            select_1();
                        }
                    }
                }
            }
            
        }

        private void Form32_Load(object sender, EventArgs e)
        {
            this.Location = new Point(1, 1);
            //
            DataTable hang_manage = new DataTable();
            hang_manage.Columns.Add("code");      //항목(종합)
            hang_manage.Columns.Add("항목");
            hang_manage.Columns.Add("class");
            //
            const Int32 BufferSize = 128;
            using (var fileStream = File.OpenRead(@".\data\hang_m.dat"))
            using (var streamReader = new StreamReader(fileStream, Encoding.UTF8, true, BufferSize))
            {
                String line;
                string[] axx = new string[2];
                while ((line = streamReader.ReadLine()) != null)
                {
                    string decryptedText = CryptorEngine.Decrypt(line, true);
                    axx = decryptedText.Split(new char[1] { '#' });
                    hang_manage.Rows.Add(new string[] { axx[0].ToString(), axx[1].ToString(), axx[2].ToString() });
                }
            } 
            make_model();
            select_2();              //공정항목
            // 
            // 
            make_table();
            select_1();  //종이.인쇄 등 항목
            select_3();  //운송항목
            //총계 표출하기
            total_plus();
            //
            this.splitContainer2.SplitterWidth = 10;
        }

        private void total_plus()              //총금액 내기
        {
            int total = 0;
            if (grid1 != null)
            {
                for (int i = 1; i < grid1.RowsCount; i++)  //자동화창
                {
                    if (!string.IsNullOrEmpty(grid1[i, 25].ToString()) && grid1[i, 25].ToString() != "0" && grid1[i, 25].ToString() != "*")     
                        total += Convert.ToInt32(grid1[i, 25].ToString().Replace(",", ""));
                }
            }
            //
            if (grid2 != null)
            {
                for (int i = 1; i < grid2.RowsCount; i++)  //공정창
                {
                    if (!string.IsNullOrEmpty(grid2[i, 17].ToString()) && grid2[i, 17].ToString() != "0" && grid2[i, 17].ToString() != "*")
                        total += Convert.ToInt32(grid2[i, 17].ToString().Replace(",", ""));
                }
            }
            //
            if (grid3 != null)
            {
                for (int i = 1; i < grid3.RowsCount; i++)  //운송창
                {
                    if (!string.IsNullOrEmpty(grid3[i, 13].ToString()) && grid3[i, 13].ToString() != "0" && grid3[i, 13].ToString() != "*")
                        total += Convert.ToInt32(grid3[i, 13].ToString().Replace(",", ""));
                }
            }
            //
            textBox16.Text = string.Format("{0:n0}", total);  //총액
        }
                

        private void make_table()              //기본테이블 생성
        {
            prn_dt.Columns.Add("code");           //인쇄전부
            prn_dt.Columns.Add("인쇄방식");
            //
            hang_dt.Columns.Add("code");          //항목
            hang_dt.Columns.Add("항목");
            //
            const Int32 BufferSize = 128;
            using (var fileStream = File.OpenRead(@".\data\hang_m.dat"))
            using (var streamReader = new StreamReader(fileStream, Encoding.UTF8, true, BufferSize))
            {
                String line;
                string[] axx = new string[2];
                while ((line = streamReader.ReadLine()) != null)
                {
                    string decryptedText = CryptorEngine.Decrypt(line, true);
                    axx = decryptedText.Split(new char[1] { '#' });
                    if (axx[2].ToString() == "항목")
                        hang_dt.Rows.Add(new string[] { axx[0].ToString(), axx[1].ToString() });
                }
            }
            //
            using (var fileStream = File.OpenRead(@".\data\jebon_dt.dat"))
            using (var streamReader = new StreamReader(fileStream, Encoding.UTF8, true, BufferSize))
            {
                String line;
                string[] axx = new string[3];
                while ((line = streamReader.ReadLine()) != null)
                {
                    string decryptedText = CryptorEngine.Decrypt(line, true);
                    axx = decryptedText.Split(new char[1] { '#' });
                    if (axx[2].ToString().Equals("08"))
                        prn_dt.Rows.Add(new string[] { axx[0].ToString(), axx[1].ToString() });
                    // 
                }
            }
        }

        private void select_1()       //Grid1
        {
            DevAge.Drawing.BorderLine border_l = new DevAge.Drawing.BorderLine(Color.FromArgb(210, 210, 210), 1);
            DevAge.Drawing.BorderLine border_r = new DevAge.Drawing.BorderLine(Color.FromArgb(220, 220, 220), 0);
            DevAge.Drawing.BorderLine top = new DevAge.Drawing.BorderLine(Color.FromArgb(93, 93, 93), 1);
            DevAge.Drawing.BorderLine bottom = new DevAge.Drawing.BorderLine(Color.FromArgb(210, 210, 210), 1);
            DevAge.Drawing.RectangleBorder border1 = new DevAge.Drawing.RectangleBorder(top, bottom, border_r, border_l);
            // 
            SourceGrid.Cells.Views.Cell line_center_cell;   //중앙셀
            SourceGrid.Cells.Views.Cell line_center_cellr;  //중앙셀r
            SourceGrid.Cells.Views.Cell line_center_cellb;  //중앙셀b
            SourceGrid.Cells.Views.Cell line_left_cell;     //좌측셀
            SourceGrid.Cells.Views.Cell line_left_cellr;    //좌측셀r
            SourceGrid.Cells.Views.Cell line_left_cellb;    //좌측셀b
            SourceGrid.Cells.Views.Cell line_int_cell;      //우측셀
            SourceGrid.Cells.Views.Cell line_int_cellr;     //우측셀r
            SourceGrid.Cells.Views.Cell line_int_cellb;     //우측셀b
            SourceGrid.Cells.Views.Cell line_int_cell_r;      //우측셀
            SourceGrid.Cells.Views.Cell line_int_cellr_r;     //우측셀r
            SourceGrid.Cells.Views.Cell line_int_cellb_r;     //우측셀b
            SourceGrid.Cells.Views.Cell line_center_cell_r;   //중앙셀
            SourceGrid.Cells.Views.Cell line_center_cellr_r;  //중앙셀r
            SourceGrid.Cells.Views.Cell line_center_cellb_r;  //중앙셀b
            SourceGrid.Cells.Views.CheckBox viewCheckBox1;
            SourceGrid.Cells.Views.CheckBox viewCheckBox2;
            viewCheckBox1 = new SourceGrid.Cells.Views.CheckBox();
            viewCheckBox2 = new SourceGrid.Cells.Views.CheckBox();
            viewCheckBox2.Border = border1; //top
            //
            line_center_cell = new SourceGrid.Cells.Views.Cell();
            line_center_cell.TextAlignment = DevAge.Drawing.ContentAlignment.MiddleCenter;
            line_center_cell.Border = border1; //top
            line_center_cellr = new SourceGrid.Cells.Views.Cell();
            line_center_cellr.TextAlignment = DevAge.Drawing.ContentAlignment.MiddleCenter;
            line_center_cellr.BackColor = Color.FromArgb(255, 250, 250);
            line_center_cellr.Border = border1; //top
            line_center_cellb = new SourceGrid.Cells.Views.Cell();
            line_center_cellb.TextAlignment = DevAge.Drawing.ContentAlignment.MiddleCenter;
            line_center_cellb.BackColor = Color.FromArgb(240, 248, 255);
            line_center_cellb.Border = border1; //top
            //
            line_left_cell = new SourceGrid.Cells.Views.Cell();
            line_left_cell.TextAlignment = DevAge.Drawing.ContentAlignment.MiddleLeft;
            line_left_cell.Border = border1; //top
            line_left_cellr = new SourceGrid.Cells.Views.Cell();
            line_left_cellr.TextAlignment = DevAge.Drawing.ContentAlignment.MiddleLeft;
            line_left_cellr.BackColor = Color.FromArgb(255, 250, 250);
            line_left_cellr.Border = border1; //top
            line_left_cellb = new SourceGrid.Cells.Views.Cell();
            line_left_cellb.TextAlignment = DevAge.Drawing.ContentAlignment.MiddleLeft;
            line_left_cellb.BackColor = Color.FromArgb(240, 248, 255);
            line_left_cellb.Border = border1; //top
            //
            line_int_cell = new SourceGrid.Cells.Views.Cell();
            line_int_cell.TextAlignment = DevAge.Drawing.ContentAlignment.MiddleRight;
            line_int_cell.Border = border1; //top
            line_int_cellr = new SourceGrid.Cells.Views.Cell();
            line_int_cellr.TextAlignment = DevAge.Drawing.ContentAlignment.MiddleRight;
            line_int_cellr.BackColor = Color.FromArgb(255, 250, 250);
            line_int_cellr.Border = border1; //top
            line_int_cellb = new SourceGrid.Cells.Views.Cell();
            line_int_cellb.TextAlignment = DevAge.Drawing.ContentAlignment.MiddleRight;
            line_int_cellb.BackColor = Color.FromArgb(240, 248, 255);
            line_int_cellb.Border = border1; //top
            //
            line_int_cell_r = new SourceGrid.Cells.Views.Cell();   //적색글자
            line_int_cell_r.TextAlignment = DevAge.Drawing.ContentAlignment.MiddleRight;
            line_int_cell_r.Border = border1; //top
            line_int_cell_r.ForeColor = Color.FromArgb(255, 0, 0);
            line_int_cellr_r = new SourceGrid.Cells.Views.Cell();
            line_int_cellr_r.TextAlignment = DevAge.Drawing.ContentAlignment.MiddleRight;
            line_int_cellr_r.BackColor = Color.FromArgb(255, 250, 250);
            line_int_cellr_r.Border = border1; //top
            line_int_cellr_r.ForeColor = Color.FromArgb(255, 0, 0);
            line_int_cellb_r = new SourceGrid.Cells.Views.Cell();
            line_int_cellb_r.TextAlignment = DevAge.Drawing.ContentAlignment.MiddleRight;
            line_int_cellb_r.BackColor = Color.FromArgb(240, 248, 255);
            line_int_cellb_r.Border = border1; //top
            line_int_cellb_r.ForeColor = Color.FromArgb(255, 0, 0);
            //
            line_center_cell_r = new SourceGrid.Cells.Views.Cell();   //적색글자
            line_center_cell_r.TextAlignment = DevAge.Drawing.ContentAlignment.MiddleCenter;
            line_center_cell_r.Border = border1; //top
            line_center_cell_r.ForeColor = Color.FromArgb(255, 0, 0);
            line_center_cellr_r = new SourceGrid.Cells.Views.Cell();
            line_center_cellr_r.TextAlignment = DevAge.Drawing.ContentAlignment.MiddleCenter;
            line_center_cellr_r.BackColor = Color.FromArgb(255, 250, 250);
            line_center_cellr_r.Border = border1; //top
            line_center_cellr_r.ForeColor = Color.FromArgb(255, 0, 0);
            line_center_cellb_r = new SourceGrid.Cells.Views.Cell();
            line_center_cellb_r.TextAlignment = DevAge.Drawing.ContentAlignment.MiddleCenter;
            line_center_cellb_r.BackColor = Color.FromArgb(240, 248, 255);
            line_center_cellb_r.Border = border1; //top
            line_center_cellb_r.ForeColor = Color.FromArgb(255, 0, 0);
            //
            SourceGrid.Cells.Views.Cell red_text_cell;   //레드셀
            red_text_cell = new SourceGrid.Cells.Views.Cell();
            red_text_cell.ForeColor = Color.FromArgb(255, 0, 0);
            //
            SourceGrid.Cells.Views.Cell viewImage = new SourceGrid.Cells.Views.Cell();
            viewImage.BackColor = Color.FromArgb(240, 248, 255);
            viewImage.ImageAlignment = DevAge.Drawing.ContentAlignment.MiddleCenter;
            //
            SourceGrid.Cells.Views.Cell line_viewImage = new SourceGrid.Cells.Views.Cell();
            line_viewImage.BackColor = Color.FromArgb(240, 248, 255);
            line_viewImage.ImageAlignment = DevAge.Drawing.ContentAlignment.MiddleCenter;
            line_viewImage.Border = border1; //top
            //   
            SourceGridControl GH = new SourceGridControl();
            cell_d cc = new cell_d();
                        // 
            //SourceGrid.Cells.Controllers.CustomEvents clickEvent1 = new SourceGrid.Cells.Controllers.CustomEvents();
            //clickEvent1.Click += new EventHandler(Clicked1);
            //

            //
            grid1.Rows.Clear();
            grid1.BorderStyle = BorderStyle.FixedSingle;
            grid1.SelectionMode = SourceGrid.GridSelectionMode.Cell;
            grid1.ColumnsCount = 54;
            grid1.FixedRows = 1;
            grid1.Rows.Insert(0);
            grid1.Rows[0].Height = 33;
            grid1.HScrollBar.Visible = false;
            grid1.Selection.FocusStyle = grid1.Selection.FocusStyle | SourceGrid.FocusStyle.RemoveSelectionOnLeave;
            // 
            grid1[0, 0] = new MyHeader1("row_id");
            grid1.Columns[0].Visible = false;
            grid1[0, 1] = new MyHeader1("√");
            grid1.Columns[1].Visible = false;
            grid1[0, 2] = new MyHeader1("");
            grid1[0, 3] = new MyHeader1("No");
            grid1[0, 4] = new MyHeader1("공  정");
            grid1[0, 5] = new MyHeader1("합판");
            grid1[0, 6] = new MyHeader1("업  체  명");
            grid1[0, 7] = new MyHeader1("항  목");
            grid1[0, 8] = new MyHeader1("종   이   명");
            grid1[0, 9] = new MyHeader1("도수");
            grid1[0, 10] = new MyHeader1("별색");
            grid1[0, 11] = new MyHeader1("도큐sz");
            grid1[0, 12] = new MyHeader1("Page");
            grid1[0, 13] = new MyHeader1("분수");
            grid1[0, 14] = new MyHeader1("인쇄유형");
            grid1[0, 15] = new MyHeader1("H");
            grid1.Columns[15].Visible = false;
            grid1[0, 16] = new MyHeader1("접지");
            grid1.Columns[16].Visible = false;
            grid1[0, 17] = new MyHeader1("대");
            grid1[0, 18] = new MyHeader1("정R");
            grid1[0, 19] = new MyHeader1("여분");
            grid1[0, 20] = new MyHeader1("수량");
            grid1[0, 21] = new MyHeader1("후공정");
            grid1[0, 22] = new MyHeader1("라인\r\n부수");
            grid1[0, 23] = new MyHeader1("％");
            grid1[0, 24] = new MyHeader1("단가");
            grid1[0, 25] = new MyHeader1("금액");

            grid1[0, 26] = new MyHeader1("비 고");
            grid1[0, 27] = new MyHeader1("M");
            grid1[0, 28] = new MyHeader1("진행일");

            grid1[0, 29] = new MyHeader1("처리");
            grid1.Columns[29].Visible = false;
            grid1[0, 30] = new MyHeader1("종합자료");
            grid1.Columns[30].Visible = false;
            grid1[0, 31] = new MyHeader1("하리");
            grid1.Columns[31].Visible = false;
            grid1[0, 32] = new MyHeader1("종이번호");
            grid1.Columns[32].Visible = false;
            grid1[0, 33] = new MyHeader1("사고자");
            grid1.Columns[33].Visible = false;
            grid1[0, 34] = new MyHeader1("메모");
            grid1.Columns[34].Visible = false;
            grid1[0, 35] = new MyHeader1("선수");
            grid1.Columns[35].Visible = false;
            grid1[0, 36] = new MyHeader1("혼양");
            grid1.Columns[36].Visible = false;
            grid1[0, 37] = new MyHeader1("순수종이명");
            grid1.Columns[37].Visible = false;
            grid1[0, 38] = new MyHeader1("종이공장");
            grid1.Columns[38].Visible = false;
            grid1[0, 39] = new MyHeader1("항목코드");
            grid1.Columns[39].Visible = false;
            grid1[0, 40] = new MyHeader1("인쇄코드");
            grid1.Columns[40].Visible = false;
            grid1[0, 41] = new MyHeader1("분개코드");
            grid1.Columns[41].Visible = false;
            grid1[0, 42] = new MyHeader1("그룹");
            grid1.Columns[42].Visible = false;
            grid1[0, 43] = new MyHeader1("prn_id");
            grid1.Columns[43].Visible = false;
            grid1[0, 44] = new MyHeader1("paper_w");  //종이 공시단가
            grid1.Columns[44].Visible = false;
            grid1[0, 45] = new MyHeader1("yubgun_1");  //여분_1
            grid1.Columns[45].Visible = false;
            grid1[0, 46] = new MyHeader1("yubgun_2");  //여분_2
            grid1.Columns[46].Visible = false;
            grid1[0, 47] = new MyHeader1("yubgun_3");  //여분_3
            grid1.Columns[47].Visible = false;
            grid1[0, 48] = new MyHeader1("yubgun_4");  //여분_4
            grid1.Columns[48].Visible = false;
            grid1[0, 49] = new MyHeader1("yubgun_4");  //set_no (공정구분번호)
            grid1.Columns[49].Visible = false;
            grid1[0, 50] = new MyHeader1("Tong");   //별색도수 할증율
            grid1.Columns[50].Visible = false;
            grid1[0, 51] = new MyHeader1("w_prn_model");   //수정전 인쇄유형
            grid1.Columns[51].Visible = false;
            grid1[0, 52] = new MyHeader1("jungr_c");       //계산정R
            grid1.Columns[52].Visible = false;
            grid1[0, 53] = new MyHeader1("action");        //진행상태
            grid1.Columns[53].Visible = false;
            //
            grid1.Columns[0].Width = 100;  //row_id
            grid1.Columns[1].Width = 22;   //√
            grid1.Columns[2].Width = 20;   //상황
            grid1.Columns[3].Width = 30;   //No
            grid1.Columns[4].Width = 70;   //공정
            grid1.Columns[5].Width = 40;   //합대\r\n합판
            grid1.Columns[6].Width = 110;  //업체명
            grid1.Columns[7].Width = 76;   //항목
            grid1.Columns[8].Width = 190;  //종이명
            grid1.Columns[9].Width = 40;   //도수
            grid1.Columns[10].Width = 40;  //별색
            grid1.Columns[11].Width = 60;  //도큐sz
            grid1.Columns[12].Width = 40;  //Page
            grid1.Columns[13].Width = 36;  //분수
            grid1.Columns[14].Width = 60;  //인쇄유형(혼각계등)
            grid1.Columns[15].Width = 20;  //H
            grid1.Columns[16].Width = 40;  //접지
            grid1.Columns[17].Width = 30;  //대
            grid1.Columns[18].Width = 54;  //정R
            grid1.Columns[19].Width = 46;  //여분
            grid1.Columns[20].Width = 50;  //수량
            grid1.Columns[21].Width = 65;  //후공정
            grid1.Columns[22].Width = 54;  //라인부수
            grid1.Columns[23].Width = 40;  //％
            grid1.Columns[24].Width = 66;  //단가
            grid1.Columns[25].Width = 78;  //금액
            grid1.Columns[26].Width = 70;  //비고
            grid1.Columns[27].Width = 26;  //M
            grid1.Columns[28].Width = 70;  //진행일
            grid1.Columns[29].Width = 36;  //처리
            grid1.Columns[30].Width = 100; //m_dat
            grid1.Columns[31].Width = 100; //bk_id
            grid1.Columns[32].Width = 100; //paper_id
            grid1.Columns[33].Width = 100; //accident_name
            grid1.Columns[34].Width = 100; //memo1
            grid1.Columns[35].Width = 100; //sunsu
            grid1.Columns[36].Width = 100; //hon_yang
            grid1.Columns[37].Width = 100; //soonsu_paper_name
            grid1.Columns[38].Width = 100; //supply_id
            grid1.Columns[39].Width = 100; //hang_id
            grid1.Columns[40].Width = 100; //prn_code
            grid1.Columns[41].Width = 100; //int_sid(분개창 row_id)
            grid1.Columns[42].Width = 100; //agroup
            grid1.Columns[43].Width = 60;  //prn_id
            grid1.Columns[44].Width = 60;  //pwon
            grid1.Columns[45].Width = 60;  //yubun_1
            grid1.Columns[46].Width = 60;  //yubun_2
            grid1.Columns[47].Width = 60;  //yubun_3
            grid1.Columns[48].Width = 60;  //yubun_4
            grid1.Columns[49].Width = 60;  //set_no
            grid1.Columns[50].Width = 60;  //tong
            grid1.Columns[51].Width = 60;  //w_prm_model
            grid1.Columns[52].Width = 60;  //jungr_c
            grid1.Columns[53].Width = 60;  //action
            //
            var DBCons = new MySqlConnection(Config.DB_con1);
            DBCons.Open();
            string cQuery = "";
            
            cQuery = "select a.*,b.won as pwon FROM " + DB_TableName4 + " as a";
            cQuery += " Left Outer Join C_paper as b on a.paper_id = b.row_id";
            cQuery += " where a.super_id='" + client_id + "' and a.int_id='" + joo_no + "' order by set_no,ord_no";

            var cmd = new MySqlCommand(cQuery, DBCons);
            var myRead = cmd.ExecuteReader();
            // 
            int m = 1;
            string hh = "";   //임시 항목
            string hh1 = "";  //일하는공장
            string hh2 = "";  //종이배달되는공장
            string mm;        //인쇄유형
            decimal yy1 = 0;
            decimal yy2 = 0;
            //
            DataRow[] dr1;
            DataRow[] dr2;
            string grp = "";
            while (myRead.Read())
            {
                
                dr1 = hang_dt.Select("code='" + myRead["hang_id"].ToString() + "'");  //항목
                if (dr1.Length == 0)
                    hh = "";
                else
                    hh = myRead["d_boonsu"].ToString() + myRead["hang_s"].ToString() + dr1[0][1].ToString();

                if (myRead["agroup"].ToString() == "인쇄" && docu == "" && hh.IndexOf("내지") >- 1)
                {
                    docu = myRead["doqu_size"].ToString();
                }
                //
                dr1 = h_customer.Select("row_id='" + myRead["company_id"].ToString() + "'"); //일하는공장
                if (dr1.Length == 0)
                    hh1 = "";
                else
                    hh1 = dr1[0]["sangho"].ToString();
                //
                dr1 = h_customer.Select("row_id='" + myRead["supply_id"].ToString() + "'");  //종이배달되는공장
                if (dr1.Length == 0)
                    hh2 = "";
                else
                    hh2 = dr1[0]["sangho"].ToString();
                //
                dr2 = prn_dt.Select("code='" + myRead["prn_code"].ToString() + "'");
                if (dr2.Length == 0)
                    mm = "";
                else
                    mm = dr2[0][1].ToString();
                //
                grid1.Rows.Insert(m);
                grid1.Rows[m].Height = 22;
                //
                grid1[m, 0] = new SourceGrid.Cells.Cell(myRead["row_id"].ToString(), typeof(string));

                grid1[m, 1] = new SourceGrid.Cells.CheckBox(null, false);
 
                grid1[m, 2] = new SourceGrid.Cells.Cell("");
                if (myRead["action"].ToString() == "1")  //처음
                    grid1[m, 2].Image = null;
                else if (myRead["action"].ToString() == "2")  //접수
                    grid1[m, 2].Image = Properties.Resources.check_mark_icon_16;
                else if (myRead["action"].ToString() == "3")  //진행
                    grid1[m, 2].Image = Properties.Resources.circle_icon_16;
                else if (myRead["action"].ToString() == "4")  //완료
                    grid1[m, 2].Image = Properties.Resources.lock_icon_16;
                else
                    grid1[m, 2].Image = null;
                //
                if (grp == "" || grp == myRead["agroup"].ToString())
                    grid1[m, 2].View = cc.center_cell;
                else
                    grid1[m, 2].View = line_center_cell;
                grid1[m, 2].Editor = cc.disable_cell;

                grid1[m, 3] = new SourceGrid.Cells.Cell(myRead["ord_no"].ToString(), typeof(string));
                if (grp == "" || grp == myRead["agroup"].ToString())
                    grid1[m, 3].View = cc.center_cell;
                else
                    grid1[m, 3].View = line_center_cell;
                grid1[m, 3].Editor = cc.disable_cell;

                if (myRead["agroup"].ToString() == "인쇄")
                    grid1[m, 4] = new SourceGrid.Cells.Cell(mm, typeof(string));
                else
                    grid1[m, 4] = new SourceGrid.Cells.Cell(myRead["agroup"].ToString(), typeof(string));
                if (grp == "" || grp == myRead["agroup"].ToString())
                    grid1[m, 4].View = cc.center_cell;
                else
                    grid1[m, 4].View = line_center_cell;
                grid1[m, 4].Editor = cc.disable_cell;

                grid1[m, 5] = new SourceGrid.Cells.Cell(myRead["hap"].ToString(), typeof(string));
 
                if (grp == "" || grp == myRead["agroup"].ToString())
                    grid1[m, 5].View = cc.center_cell;
                else
                    grid1[m, 5].View = line_center_cell;
                grid1[m, 5].Editor = cc.disable_cell;

                if ((myRead["agroup"].ToString() == "인쇄" || myRead["agroup"].ToString() == "소부") && myRead["company_id"].ToString() == "0")
                    grid1[m, 6] = new SourceGrid.Cells.Cell(mm + " 플랫폼", typeof(string));
                else
                    grid1[m, 6] = new SourceGrid.Cells.Cell(hh1, typeof(string));

                if (grp == "" || grp == myRead["agroup"].ToString())
                    grid1[m, 6].View = cc.left_cell;
                else
                    grid1[m, 6].View = line_left_cell;
                grid1[m, 6].Editor = cc.disable_cell;

                grid1[m, 7] = new SourceGrid.Cells.Cell(hh, typeof(string));
                if (grp == "" || grp == myRead["agroup"].ToString())
                    grid1[m, 7].View = cc.center_cell;
                else
                    grid1[m, 7].View = line_center_cell;
                grid1[m, 7].Editor = cc.disable_cell;

                if (myRead["agroup"].ToString() == "CTP" || myRead["agroup"].ToString() == "필림")  //인쇄유형
                    if (myRead["paper_name"].ToString().Contains("판공용"))
                        grid1[m, 8] = new SourceGrid.Cells.Cell(myRead["paper_name"].ToString() + "  " + myRead["sunsu"].ToString(), typeof(string));
                    else
                        grid1[m, 8] = new SourceGrid.Cells.Cell(myRead["paper_name"].ToString() + "            " + myRead["sunsu"].ToString(), typeof(string));
                else
                    grid1[m, 8] = new SourceGrid.Cells.Cell(myRead["paper_name"].ToString(), typeof(string));
                //  
                if (myRead["agroup"].ToString() == "CTP" || myRead["agroup"].ToString() == "필림" || myRead["agroup"].ToString() == "소부")  //인쇄유형
                {
                    if (grp == "" || grp == myRead["agroup"].ToString())
                        grid1[m, 8].View = cc.left_cell;
                    else
                        grid1[m, 8].View = line_left_cell;
                }
                else
                {
                    if (grp == "" || grp == myRead["agroup"].ToString())
                        grid1[m, 8].View = cc.left_cell;
                    else
                        grid1[m, 8].View = line_left_cell;
                    //
                }
                grid1[m, 8].Editor = cc.disable_cell;


                if (myRead["set_no"].ToString() == "1")  //종이
                    grid1[m, 9] = new SourceGrid.Cells.Cell("", typeof(string));
                else
                    grid1[m, 9] = new SourceGrid.Cells.Cell(myRead["dosu"].ToString(), typeof(string));
                //  
                if (grp == "" || grp == myRead["agroup"].ToString())
                {
                    if (myRead["set_no"].ToString() == "4")  //
                        grid1[m, 9].View = cc.center_cell;
                    else
                        grid1[m, 9].View = cc.center_cell;
                }
                else
                {
                    if (myRead["set_no"].ToString() == "4")  //
                        grid1[m, 9].View = line_center_cell;
                    else
                        grid1[m, 9].View = line_center_cell;
                }
                grid1[m, 9].Editor = cc.disable_cell;

                if (myRead["set_no"].ToString() == "1")  //종이
                    grid1[m, 10] = new SourceGrid.Cells.Cell("", typeof(string));
                else
                    grid1[m, 10] = new SourceGrid.Cells.Cell(myRead["star"].ToString(), typeof(string));
                if (grp == "" || grp == myRead["agroup"].ToString())
                {
                    if (myRead["set_no"].ToString() != "4")  //인쇄
                        grid1[m, 10].View = cc.center_cell;
                    else
                        grid1[m, 10].View = cc.center_cell;
                }
                else
                {
                    if (myRead["set_no"].ToString() != "4")  //인쇄
                        grid1[m, 10].View = line_center_cell;
                    else
                        grid1[m, 10].View = line_center_cell;
                }
                grid1[m, 10].Editor = cc.disable_cell;

                if (myRead["agroup"].ToString() == "종이" || myRead["agroup"].ToString() == "CTP" ||myRead["agroup"].ToString() == "필림" ||myRead["agroup"].ToString() == "소부")
                    grid1[m, 11] = new SourceGrid.Cells.Cell("", typeof(string));
                else
                    grid1[m, 11] = new SourceGrid.Cells.Cell(myRead["doqu_size"].ToString(), typeof(string));

                if (grp == "" || grp == myRead["agroup"].ToString())
                    grid1[m, 11].View = cc.center_cell;
                else
                    grid1[m, 11].View = line_center_cell;
                //
                grid1[m, 11].Editor = cc.disable_cell;

                if (myRead["agroup"].ToString() == "종이" || myRead["agroup"].ToString() == "CTP" || myRead["agroup"].ToString() == "필림" || myRead["agroup"].ToString() == "소부")
                    grid1[m, 12] = new SourceGrid.Cells.Cell("", typeof(string));
                else
                    grid1[m, 12] = new SourceGrid.Cells.Cell(myRead["page"].ToString(), typeof(string));
                if (grp == "" || grp == myRead["agroup"].ToString())
                    grid1[m, 12].View = cc.center_cell;
                else
                    grid1[m, 12].View = line_center_cell;
                //
                grid1[m, 12].Editor = cc.disable_cell;

                if (myRead["agroup"].ToString() == "종이")
                    grid1[m, 13] = new SourceGrid.Cells.Cell("", typeof(string));
                else
                    grid1[m, 13] = new SourceGrid.Cells.Cell(myRead["boonsu"].ToString(), typeof(string));
                if (grp == "" || grp == myRead["agroup"].ToString())
                    grid1[m, 13].View = cc.center_cell;
                else
                    grid1[m, 13].View = line_center_cell;
                //
                grid1[m, 13].Editor = cc.disable_cell;

                if (myRead["agroup"].ToString() == "종이")  //
                {
                    grid1[m, 14] = new SourceGrid.Cells.Cell("", typeof(string));
                    if (grp == "" || grp == myRead["agroup"].ToString())
                        grid1[m, 14].View = cc.center_cell;
                    else
                        grid1[m, 14].View = line_center_cell;
                }
                else if (myRead["agroup"].ToString() == "CTP" || myRead["agroup"].ToString() == "필림" || myRead["agroup"].ToString() == "소부")  //인쇄유형
                {
                    grid1[m, 14] = new SourceGrid.Cells.Cell(myRead["prn_model"].ToString(), typeof(string));
                    if (grp == "" || grp == myRead["agroup"].ToString())
                        grid1[m, 14].View = cc.center_cell;
                    else
                        grid1[m, 14].View = line_center_cell;
                }
                else
                {
                    grid1[m, 14] = new SourceGrid.Cells.Cell(myRead["prn_model"].ToString(), typeof(string));
                    if (grp == "" || grp == myRead["agroup"].ToString())
                        grid1[m, 14].View = cc.center_cellb;
                    else
                        grid1[m, 14].View = line_center_cellb;
                }
                grid1[m, 14].Editor = cc.disable_cell;
                //

                grid1[m, 15] = new SourceGrid.Cells.Button("");
                //grid1[m, 15].AddController(clickEvent1);

                grid1[m, 16] = new SourceGrid.Cells.Cell(myRead["jubji1"].ToString(), typeof(string));
                if (grp == "" || grp == myRead["agroup"].ToString())
                    grid1[m, 16].View = cc.center_cell;
                else
                    grid1[m, 16].View = line_center_cell;
                grid1[m, 16].Editor = cc.disable_cell;

                if (myRead["deasu"].ToString() == "0")
                    grid1[m, 17] = new SourceGrid.Cells.Cell("", typeof(string));
                else
                    grid1[m, 17] = new SourceGrid.Cells.Cell(myRead["deasu"].ToString(), typeof(string));

                if (grp == "" || grp == myRead["agroup"].ToString())
                    grid1[m, 17].View = cc.center_cell;
                else
                    grid1[m, 17].View = line_center_cell;
                //
                grid1[m, 17].Editor = cc.disable_cell;

                if (Convert.ToDecimal(myRead["jungr_t"].ToString()) == 0 || myRead["set_no"].ToString() == "2" || myRead["set_no"].ToString() == "3")
                    grid1[m, 18] = new SourceGrid.Cells.Cell("", typeof(string));
                else
                    grid1[m, 18] = new SourceGrid.Cells.Cell(Convert.ToDecimal(GH.decimaldel(myRead["jungr_t"].ToString())), typeof(string));

                if (grp == "" || grp == myRead["agroup"].ToString())
                {
                   if (myRead["set_no"].ToString() != "4")  //인쇄
                       grid1[m, 18].View = cc.int_cell;
                   else
                       grid1[m, 18].View = cc.int_cell;
                }
                else
                {
                   if (myRead["set_no"].ToString() != "4")  //인쇄
                       grid1[m, 18].View = line_int_cell;
                   else
                       grid1[m, 18].View = line_int_cell;
                }
                grid1[m, 18].Editor = cc.disable_cell;

                yy1 = Convert.ToDecimal(myRead["yubun_1"].ToString()) + Convert.ToDecimal(myRead["yubun_2"].ToString());
                yy2 = Convert.ToDecimal(myRead["yubun_3"].ToString()) + Convert.ToDecimal(myRead["yubun_4"].ToString());
                // 
                if (yy2 == 0 || myRead["set_no"].ToString() == "2" || myRead["set_no"].ToString() == "3")
                    grid1[m, 19] = new SourceGrid.Cells.Cell("", typeof(string));
                else
                    grid1[m, 19] = new SourceGrid.Cells.Cell(Convert.ToDecimal(GH.decimaldel(yy2.ToString())), typeof(string));
                if (yy1 != yy2)
                {
                    if (myRead["set_no"].ToString() == "4")  //종이
                    {
                        if (grp == "" || grp == myRead["agroup"].ToString())
                            grid1[m, 19].View = cc.int_cell_r;
                        else
                            grid1[m, 19].View = line_int_cell_r;
                    }
                    else
                    {
                        if (grp == "" || grp == myRead["agroup"].ToString())
                            grid1[m, 19].View = cc.int_cell_r;
                        else
                            grid1[m, 19].View = line_int_cell_r;
                    }
                }
                else
                {
                    if (myRead["set_no"].ToString() == "4")  //종이
                    {
                        if (grp == "" || grp == myRead["agroup"].ToString())
                            grid1[m, 19].View = cc.int_cell;
                        else
                            grid1[m, 19].View = line_int_cell;
                    }
                    else
                    {
                        if (grp == "" || grp == myRead["agroup"].ToString())
                            grid1[m, 19].View = cc.int_cell;
                        else
                            grid1[m, 19].View = line_int_cell;
                    }
                }
                grid1[m, 19].Editor = cc.disable_cell;

                grid1[m, 20] = new SourceGrid.Cells.Cell(Convert.ToDecimal(GH.decimaldel(myRead["total_su"].ToString())), typeof(string));  //수량
                if (grp == "" || grp == myRead["agroup"].ToString())
                    grid1[m, 20].View = cc.int_cell;
                else
                    grid1[m, 20].View = line_int_cell;
                //
                grid1[m, 20].Editor = cc.disable_cell;

                if (myRead["agroup"].ToString() == "인쇄")  //인쇄유형
                {
                    grid1[m, 21] = new SourceGrid.Cells.Cell(myRead["gongjung"].ToString(), typeof(string));
                    //
                    if (grp == "" || grp == myRead["agroup"].ToString())
                        grid1[m, 21].View = cc.left_cell;
                    else
                        grid1[m, 21].View = line_left_cell;
                }
                else
                {
                    grid1[m, 21] = new SourceGrid.Cells.Cell("", typeof(string));
                    //
                    if (grp == "" || grp == myRead["agroup"].ToString())
                        grid1[m, 21].View = cc.left_cell;
                    else
                        grid1[m, 21].View = line_left_cell;
                }
                //
                grid1[m, 21].Editor = cc.disable_cell;

                if (Convert.ToDecimal(myRead["line_busu"].ToString()) == 0)
                    grid1[m, 22] = new SourceGrid.Cells.Cell("", typeof(string));
                else
                    grid1[m, 22] = new SourceGrid.Cells.Cell(string.Format("{0:n0}", Convert.ToDecimal(myRead["line_busu"].ToString())), typeof(string));  //라인부수
                if (grp == "" || grp == myRead["agroup"].ToString())
                    grid1[m, 22].View = cc.int_cell;
                else
                    grid1[m, 22].View = line_int_cell;

                grid1[m, 22].Editor.EnableEdit = false;

                yy1 = Convert.ToDecimal(myRead["discount_1"].ToString());
                yy2 = Convert.ToDecimal(myRead["discount_2"].ToString());
                if (yy2 == 0 || myRead["set_no"].ToString() != "1")   //퍼센트가 0, 종이가 아니라면 
                    grid1[m, 23] = new SourceGrid.Cells.Cell("", typeof(string));
                else
                    grid1[m, 23] = new SourceGrid.Cells.Cell(yy2.ToString(), typeof(string));
                //
                if (myRead["set_no"].ToString() == "1")  //종이
                {
                    if (yy1 != yy2)
                    {
                        if (grp == "" || grp == myRead["agroup"].ToString())
                            grid1[m, 23].View = cc.center_cell_r;
                        else
                            grid1[m, 23].View = line_center_cell;
                    }
                    else
                    {
                        if (grp == "" || grp == myRead["agroup"].ToString())
                            grid1[m, 23].View = cc.center_cell;
                        else
                            grid1[m, 23].View = line_center_cell;
                    }
                }
                else
                {
                    if (grp == "" || grp == myRead["agroup"].ToString())
                        grid1[m, 23].View = cc.center_cell;
                    else
                        grid1[m, 23].View = line_center_cell;
                }
                
                grid1[m, 23].Editor = cc.disable_cell;
                //
                yy1 = Convert.ToDecimal(myRead["danga_1"].ToString());
                yy2 = Convert.ToDecimal(myRead["danga_2"].ToString());
                //
                if (grid1[m, 14].ToString() == "인쇄없음")
                    grid1[m, 24] = new SourceGrid.Cells.Cell("*", typeof(string));
                else
                {
                    if (myRead["set_no"].ToString() == "4")
                    {
                        if (myRead["prn_code"].ToString() == "01")  //마스타-->소숫점 처리
                            grid1[m, 24] = new SourceGrid.Cells.Cell(Convert.ToDecimal(GH.decimaldel(myRead["danga_2"].ToString())), typeof(string));
                        else                                        //나머지는 정수처리
                            grid1[m, 24] = new SourceGrid.Cells.Cell(string.Format("{0:n0}", myRead["danga_2"]), typeof(string));  //단가
                    }
                    else
                        grid1[m, 24] = new SourceGrid.Cells.Cell(string.Format("{0:n0}", myRead["danga_2"]), typeof(string));      //단가
                }
                //
                if (yy1 != yy2)  //단가1, 단가2 가 상이할 경우 적색으로 표시
                {
                    if (grp == "" || grp == myRead["agroup"].ToString())
                        grid1[m, 24].View = cc.int_cell_r;
                    else
                        grid1[m, 24].View = line_int_cell_r;
                }
                else
                {
                    if (grp == "" || grp == myRead["agroup"].ToString())
                        grid1[m, 24].View = cc.int_cell;
                    else
                        grid1[m, 24].View = line_int_cell;
                }

                grid1[m, 24].Editor = cc.disable_cell;
                if (grid1[m, 14].ToString() == "인쇄없음")
                    grid1[m, 25] = new SourceGrid.Cells.Cell("*", typeof(string));
                else
                    grid1[m, 25] = new SourceGrid.Cells.Cell(myRead["won_2"], typeof(int));
                //  
                if (grp == "" || grp == myRead["agroup"].ToString())
                    grid1[m, 25].View = cc.int_cell;
                else
                    grid1[m, 25].View = line_int_cell;
                grid1[m, 25].Editor = cc.int_editor_disable;

                grid1[m, 26] = new SourceGrid.Cells.Cell(myRead["line_bigo"].ToString(), typeof(string));
                if (grp == "" || grp == myRead["agroup"].ToString())
                    grid1[m, 26].View = cc.left_cell;
                else
                    grid1[m, 26].View = line_left_cell;
                grid1[m, 26].Editor = cc.disable_cell;
                grid1[m, 27] = new SourceGrid.Cells.Cell("");
                if (grp == "" || grp == myRead["agroup"].ToString())
                    grid1[m, 27].View = viewImage;
                else
                    grid1[m, 27].View = line_viewImage;
                grid1[m, 27].Image = Properties.Resources.note_25_icon_16;

                grid1[m, 28] = new SourceGrid.Cells.Cell(myRead["p_day"].ToString().Substring(2, 8), typeof(string));
                if (grp == "" || grp == myRead["agroup"].ToString())
                    grid1[m, 28].View = cc.center_cell;
                else
                    grid1[m, 28].View = line_center_cell;
                grid1[m, 28].Editor = cc.disable_cell;

                grid1[m, 29] = new SourceGrid.Cells.Cell(myRead["cheri"].ToString(), typeof(string));
                grid1[m, 30] = new SourceGrid.Cells.Cell(myRead["m_dat"].ToString(), typeof(string));
                grid1[m, 31] = new SourceGrid.Cells.Cell(myRead["bk_id"].ToString(), typeof(string));
                grid1[m, 32] = new SourceGrid.Cells.Cell(myRead["paper_id"].ToString(), typeof(string));
                grid1[m, 33] = new SourceGrid.Cells.Cell(myRead["accident_name"].ToString(), typeof(string));
                grid1[m, 34] = new SourceGrid.Cells.Cell(myRead["memo1"].ToString(), typeof(string));
                grid1[m, 35] = new SourceGrid.Cells.Cell(myRead["sunsu"].ToString(), typeof(string));
                grid1[m, 36] = new SourceGrid.Cells.Cell(myRead["hon_yang"].ToString(), typeof(string));
                grid1[m, 37] = new SourceGrid.Cells.Cell(myRead["soonsu_paper_name"].ToString(), typeof(string));
                grid1[m, 38] = new SourceGrid.Cells.Cell(hh2, typeof(string));
                grid1[m, 39] = new SourceGrid.Cells.Cell(myRead["hang_id"].ToString(), typeof(string));
                grid1[m, 40] = new SourceGrid.Cells.Cell(myRead["prn_code"].ToString(), typeof(string));
                grid1[m, 41] = new SourceGrid.Cells.Cell(myRead["int_sid"].ToString(), typeof(string));
                grid1[m, 42] = new SourceGrid.Cells.Cell(myRead["agroup"].ToString(), typeof(string));
                grid1[m, 43] = new SourceGrid.Cells.Cell(myRead["prn_id"].ToString(), typeof(string));
                grid1[m, 44] = new SourceGrid.Cells.Cell(myRead["pwon"].ToString(), typeof(string));
                grid1[m, 45] = new SourceGrid.Cells.Cell(myRead["yubun_1"].ToString(), typeof(string));  //여분1 //인쇄여분
                grid1[m, 46] = new SourceGrid.Cells.Cell(myRead["yubun_2"].ToString(), typeof(string));  //여분2 //후공정여분
                grid1[m, 47] = new SourceGrid.Cells.Cell(myRead["yubun_3"].ToString(), typeof(string));  //여분3 //인쇄여분(수정)
                grid1[m, 48] = new SourceGrid.Cells.Cell(myRead["yubun_4"].ToString(), typeof(string));  //여분4 //후공정여분(수정)
                grid1[m, 49] = new SourceGrid.Cells.Cell(myRead["set_no"].ToString(), typeof(string));   //공정구분번호(1=종이,2=필림,3=CTP/소부,4=인쇄
                grid1[m, 50] = new SourceGrid.Cells.Cell(myRead["tong"].ToString(), typeof(string));     //할증율
                grid1[m, 51] = new SourceGrid.Cells.Cell(myRead["w_prn_model"].ToString(), typeof(string));  //수정전 인쇄유형(혼각계등)
                grid1[m, 52] = new SourceGrid.Cells.Cell(myRead["jungr_c"].ToString(), typeof(string));      //계산정R
                grid1[m, 53] = new SourceGrid.Cells.Cell(myRead["action"].ToString(), typeof(string));       //진행상태

                grp = myRead["agroup"].ToString();
                m++;
            }
            myRead.Close();
            DBCons.Close();
            //
            grid1.Selection.Focus(new SourceGrid.Position(grid1_row, grid1_col), true);
            grid1.Select();
            tbDocu.Text = docu;
        }

        public void select_2()   //grid2
        {
            cell_d cc = new cell_d();
            SourceGridControl GH = new SourceGridControl();
            SourceGrid.Cells.Editors.TextBox disable_cell = new SourceGrid.Cells.Editors.TextBox(typeof(string));  //수정불가
            SourceGrid.Cells.Views.Cell viewImage = new SourceGrid.Cells.Views.Cell();
            viewImage.BackColor = Color.FromArgb(240, 248, 255);
            viewImage.ImageAlignment = DevAge.Drawing.ContentAlignment.MiddleCenter;
            //
            SourceGrid.Cells.Views.Cell viewImage1 = new SourceGrid.Cells.Views.Cell();
            viewImage1.BackColor = Color.FromArgb(240, 248, 255);
            viewImage1.ImageAlignment = DevAge.Drawing.ContentAlignment.MiddleCenter;
            //
            disable_cell.EnableEdit = false;
            //
            //
            grid2.Rows.Clear();
            grid2.ColumnsCount = 23;
            grid2.FixedRows = 1;
            //grid2.VScrollBar.Visible = false;
            grid2.Rows.Insert(0);
            grid2.Rows[0].Height = 28;
            grid2.Selection.FocusStyle = grid1.Selection.FocusStyle | SourceGrid.FocusStyle.RemoveSelectionOnLeave;
            //
            grid2[0, 0] = new MyHeader1("row_id");  //고유번호(숨김)
            grid2.Columns[0].Visible = false;
            grid2[0, 1] = new MyHeader1("√");
            grid2.Columns[1].Visible = false;
            grid2[0, 2] = new MyHeader1("");       //진행
            grid2[0, 3] = new MyHeader1("No");
            grid2[0, 4] = new MyHeader1("C");
            grid2[0, 5] = new MyHeader1("후공정");
            grid2[0, 6] = new MyHeader1("부공정");
            grid2[0, 7] = new MyHeader1("입력");
            grid2[0, 8] = new MyHeader1("업체명");
            grid2[0, 9] = new MyHeader1("Page");
            grid2[0, 10] = new MyHeader1("인쇄 절수");
            grid2[0, 10].ColumnSpan = 2;
            grid2[0, 12] = new MyHeader1("정R");
            grid2[0, 13] = new MyHeader1("꼭지");
            grid2[0, 14] = new MyHeader1("부수");
            grid2[0, 15] = new MyHeader1("P단가");
            grid2.Columns[15].Visible = false;
            grid2[0, 16] = new MyHeader1("단가");
            grid2[0, 17] = new MyHeader1("금 액");
            grid2[0, 18] = new MyHeader1("비 고");
            grid2[0, 19] = new MyHeader1("M");
            grid2[0, 20] = new MyHeader1("진행일");
            grid2[0, 21] = new MyHeader1("auto_rowid");
            grid2.Columns[21].Visible = false;
            grid2[0, 22] = new MyHeader1("int_g");
            grid2.Columns[22].Visible = false;
            //
            grid2.Columns[0].Width = 100;
            grid2.Columns[1].Width = 22;
            grid2.Columns[2].Width = 20;
            grid2.Columns[3].Width = 30;
            grid2.Columns[4].Width = 30;
            grid2.Columns[5].Width = 90;
            grid2.Columns[6].Width = 110;
            grid2.Columns[7].Width = 34;
            grid2.Columns[8].Width = 120;
            grid2.Columns[9].Width = 50;
            grid2.Columns[10].Width = 30;
            grid2.Columns[11].Width = 30;
            grid2.Columns[12].Width = 50;
            grid2.Columns[13].Width = 40;
            grid2.Columns[14].Width = 50;
            grid2.Columns[15].Width = 50;
            grid2.Columns[16].Width = 60;  //단가
            grid2.Columns[17].Width = 80;  //금액
            grid2.Columns[18].Width = 68;  //비고
            grid2.Columns[19].Width = 26;  //버튼
            grid2.Columns[20].Width = 70;  //진행일
            grid2.Columns[21].Width = 70;  //
            grid2.Columns[22].Width = 70;  //
            //
            DataTable dt = new DataTable();
            var DBCons = new MySqlConnection(Config.DB_con1);   
            DBCons.Open();
            // 
            string cQuery = "";
            cQuery = " select a.*,b.sangho FROM " + DB_TableName5 + " as a ";  //공정테이블
            cQuery += " left outer join C_hcustomer as b on a.comp_id = b.row_id ";
            cQuery += " where a.super_id='" + client_id + "' and a.int_id='" + joo_no + "' order by a.no_1,a.no_2,a.no_3";
            MySqlDataAdapter returnVal1 = new MySqlDataAdapter(cQuery, DBCons);
            returnVal1.Fill(dt);
            returnVal1.Dispose();
            progres = dt;   //전역테이블에 대입하고-->이른 방법이 빠름            
            //
            int m = 0;
            string temp1 = "";
            string temp2 = "";
            bool s_id = false;
            //
            DataRow[] dr1;
            DataRow[] dr2;
            string hh = "";
            string mm = "";
            string acode = "";
            string bcode = "";
            string ccode = "";
            //
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                m = i + 1;
                grid2.Rows.Insert(m);
                grid2.Rows[m].Height = 22;
                //
                grid2[m, 0] = new SourceGrid.Cells.Cell(dt.Rows[i]["row_id"].ToString(), typeof(string));  //고유번호
                grid2[m, 1] = new SourceGrid.Cells.CheckBox(null, false);

                grid2[m, 2] = new SourceGrid.Cells.Cell("", typeof(string));
                grid2[m, 2].Image = null;
                grid2[m, 2].Editor = cc.disable_cell;

                grid2[m, 3] = new SourceGrid.Cells.Cell(m.ToString(), typeof(string));
                grid2[m, 3].View = cc.center_cell;
                grid2[m, 3].Editor = cc.disable_cell;

                grid2[m, 4] = new SourceGrid.Cells.Cell(dt.Rows[i]["e_code"].ToString(), typeof(string));
                grid2[m, 4].View = cc.center_cell;
                grid2[m, 4].Editor = cc.disable_cell;
                //
                acode = dt.Rows[i]["int_g"].ToString().Substring(0, 2);
                bcode = dt.Rows[i]["int_g"].ToString().Substring(2, 2); ;
                ccode = dt.Rows[i]["int_g"].ToString().Substring(4, 2); ;
                //
                dr1 = b_model.Select("a_code='" + acode + "' and b_code='" + bcode + "'");
                if (dr1.Length == 0)
                    hh = "";
                else
                    hh = dr1[0]["bitem"].ToString();
                //
                dr2 = c_model.Select("a_code='" + acode + "' and b_code='" + bcode + "' and c_code='" + ccode + "'");
                if (dr2.Length == 0)
                    mm = "";
                else
                    mm = dr2[0]["citem"].ToString();
                // 
                temp2 = hh;
                if (temp1 == temp2)
                    s_id = true;
                else
                    s_id = false;
                //
                temp1 = temp2;
                //
                if (s_id == true)
                    grid2[m, 5] = new SourceGrid.Cells.Cell(" └", typeof(string));
                else
                {
                    grid2[m, 5] = new SourceGrid.Cells.Cell(hh, typeof(string));
                    if (hh.IndexOf("제본") > -1 && busu == "")
                        busu = dt.Rows[i]["busu"].ToString();
                }
                //
                grid2[m, 5].View = cc.left_cell;
                grid2[m, 5].Editor = cc.disable_cell;

                grid2[m, 6] = new SourceGrid.Cells.Cell(mm, typeof(string));
                grid2[m, 6].View = cc.left_cell;
                grid2[m, 6].Editor = cc.disable_cell;

                grid2[m, 7] = new SourceGrid.Cells.Cell("");
                if (!string.IsNullOrEmpty(dt.Rows[i]["jogun"].ToString()) || !string.IsNullOrEmpty(dt.Rows[i]["go_id"].ToString()))
                {
                    grid2[m, 7].Image = Properties.Resources.pencil_icon_16;
                }

                if (string.IsNullOrEmpty(dt.Rows[i]["sangho"].ToString()))
                    grid2[m, 8] = new SourceGrid.Cells.Cell(dt.Rows[i]["j_code5"].ToString(), typeof(string));
                else
                    grid2[m, 8] = new SourceGrid.Cells.Cell(dt.Rows[i]["sangho"].ToString(), typeof(string));
                // 
                grid2[m, 8].View = cc.left_cell;
                grid2[m, 8].Editor = cc.disable_cell;

                grid2[m, 9] = new SourceGrid.Cells.Cell(dt.Rows[i]["page"], typeof(int));
                grid2[m, 9].View = cc.int_cell;
                grid2[m, 9].Editor = cc.disable_cell;

                grid2[m, 10] = new SourceGrid.Cells.Cell(dt.Rows[i]["print_jul_a"].ToString(), typeof(string));  //인쇄 절수a
                grid2[m, 10].View = cc.center_cell;
                grid2[m, 10].Editor = cc.disable_cell;

                grid2[m, 11] = new SourceGrid.Cells.Cell(dt.Rows[i]["print_jul_b"].ToString(), typeof(string)); //인쇄 절수b
                grid2[m, 11].View = cc.center_cell;
                grid2[m, 11].Editor = cc.disable_cell;

                grid2[m, 12] = new SourceGrid.Cells.Cell(Convert.ToDecimal(GH.decimaldel(dt.Rows[i]["jung_R"].ToString())), typeof(string));
                grid2[m, 12].View = cc.int_cell;
                grid2[m, 12].Editor = cc.disable_cell;

                grid2[m, 13] = new SourceGrid.Cells.Cell(dt.Rows[i]["gokji"].ToString(), typeof(string)); //꼭지
                grid2[m, 13].View = cc.center_cell;
                grid2[m, 13].Editor = cc.disable_cell;

                grid2[m, 14] = new SourceGrid.Cells.Cell(dt.Rows[i]["busu"], typeof(int));
                grid2[m, 14].View = cc.int_cell;
                grid2[m, 14].Editor = cc.disable_cell;

                grid2[m, 15] = new SourceGrid.Cells.Cell(Convert.ToDecimal(GH.decimaldel(dt.Rows[i]["p_danga1"].ToString())), typeof(string));
                grid2[m, 15].View = cc.int_cell;
                grid2[m, 15].Editor = cc.disable_cell;

                //
                if (dt.Rows[i]["danga1"].ToString() == "-2.00")
                    grid2[m, 16] = new SourceGrid.Cells.Cell("*", typeof(string));
                else if (dt.Rows[i]["danga1"].ToString() == "-3.00")
                    grid2[m, 16] = new SourceGrid.Cells.Cell("기본", typeof(string));
                else
                    grid2[m, 16] = new SourceGrid.Cells.Cell(string.Format("{0:n0}", Convert.ToDecimal(dt.Rows[i]["danga1"].ToString())), typeof(string));  //
                //
                decimal yy1 = Convert.ToDecimal(dt.Rows[i]["danga1"].ToString());
                decimal yy2 = Convert.ToDecimal(dt.Rows[i]["danga2"].ToString());

                if (yy1 != yy2)  //단가1, 단가2 가 상이할 경우 적색으로 표시
                    grid2[m, 16].View = cc.int_cell_r;
                else
                    grid2[m, 16].View = cc.int_cell;
                grid2[m, 16].Editor = cc.disable_cell;
                //

                if (dt.Rows[i]["danga1"].ToString() == "-2.00")
                    grid2[m, 17] = new SourceGrid.Cells.Cell("*", typeof(string));
                else
                    grid2[m, 17] = new SourceGrid.Cells.Cell(string.Format("{0:n0}", Convert.ToDecimal(dt.Rows[i]["twon1"].ToString())), typeof(string));  //
                //  
                grid2[m, 17].View = cc.int_cell;
                grid2[m, 17].Editor = cc.disable_cell;

                grid2[m, 18] = new SourceGrid.Cells.Cell("", typeof(string));
                grid2[m, 18].View = cc.left_cell;
                grid2[m, 18].Editor = cc.disable_cell;

                grid2[m, 19] = new SourceGrid.Cells.Cell("");
                grid2[m, 19].View = viewImage1;
                grid2[m, 19].Image = Properties.Resources.note_25_icon_16;

                grid2[m, 20] = new SourceGrid.Cells.Cell(dt.Rows[i]["p_day"].ToString().Substring(2, 8), typeof(string));
                grid2[m, 20].View = cc.center_cell;
                grid2[m, 20].Editor = cc.disable_cell;

                grid2[m, 21] = new SourceGrid.Cells.Cell(dt.Rows[i]["int_auto"].ToString(), typeof(string));
                grid2[m, 21].View = cc.center_cell;
                grid2[m, 21].Editor = cc.disable_cell;

                grid2[m, 22] = new SourceGrid.Cells.Cell(dt.Rows[i]["int_g"].ToString(), typeof(string));


            }
            DBCons.Close();

            tbBusu.Text = busu;
        }

        private void select_3()  //grid3
        {
            SourceGrid.Cells.Views.Cell viewImage = new SourceGrid.Cells.Views.Cell();  //연필그림
            viewImage.BackColor = Color.FromArgb(240, 248, 255);
            viewImage.ImageAlignment = DevAge.Drawing.ContentAlignment.MiddleCenter;
            //
            SourceGrid.Cells.Views.Cell viewImage1 = new SourceGrid.Cells.Views.Cell();
            viewImage1.BackColor = Color.FromArgb(240, 248, 255);
            viewImage1.ImageAlignment = DevAge.Drawing.ContentAlignment.MiddleCenter;
            //
            cell_d cc = new cell_d();
            // 
            //SourceGrid.Cells.Controllers.CustomEvents val_c3 = new SourceGrid.Cells.Controllers.CustomEvents();
            //SourceGrid.Cells.Controllers.CustomEvents clickEvent3 = new SourceGrid.Cells.Controllers.CustomEvents();
            grid3.Rows.Clear();
            //  
            grid3.ColumnsCount = 17;
            grid3.FixedRows = 1;
            grid3.Rows.Insert(0);
            grid3.Rows[0].Height = 28;
            grid3.HScrollBar.Visible = false;
            grid3.Selection.FocusStyle = grid1.Selection.FocusStyle | SourceGrid.FocusStyle.RemoveSelectionOnLeave;
            //
            grid3[0, 0] = new MyHeader1("row_id");
            grid3.Columns[0].Visible = false;
            grid3[0, 1] = new MyHeader1("√");
            grid3[0, 2] = new MyHeader1("");       //진행
            grid3[0, 3] = new MyHeader1("배송방법");
            grid3[0, 4] = new MyHeader1("차 량");
            grid3[0, 5] = new MyHeader1("진행");
            grid3[0, 6] = new MyHeader1("입력");
            grid3[0, 7] = new MyHeader1("업체명");
            grid3[0, 8] = new MyHeader1("방법");
            grid3[0, 9] = new MyHeader1("결재");
            grid3[0, 10] = new MyHeader1("기사H.P");
            grid3[0, 11] = new MyHeader1("출발지");
            grid3[0, 12] = new MyHeader1("도착지");
            grid3[0, 13] = new MyHeader1("금 액");
            grid3[0, 14] = new MyHeader1("비   고");
            grid3[0, 15] = new MyHeader1("M");
            grid3[0, 16] = new MyHeader1("진행일");
            //
            grid3.Columns[0].Width = 100;
            grid3.Columns[1].Width = 22;
            grid3.Columns[2].Width = 22;
            grid3.Columns[3].Width = 80;
            grid3.Columns[4].Width = 70;
            grid3.Columns[5].Width = 40;
            grid3.Columns[6].Width = 34;
            grid3.Columns[7].Width = 100;
            grid3.Columns[8].Width = 60;
            grid3.Columns[9].Width = 60;
            grid3.Columns[10].Width = 70;
            grid3.Columns[11].Width = 90;
            grid3.Columns[12].Width = 90;
            grid3.Columns[13].Width = 70;
            grid3.Columns[14].Width = 70;
            grid3.Columns[15].Width = 26;
            grid3.Columns[16].Width = 74;
            // 
            var DBCons = new MySqlConnection(Config.DB_con1);
            DBCons.Open();
            //
            string cQuery = " select * FROM " + DB_TableName6;
            cQuery += " where super_id='" + client_id + "' and int_id='" + joo_no + "'";
            var cmd = new MySqlCommand(cQuery, DBCons);
            var myRead = cmd.ExecuteReader();
            // 
            int m = 1;
            while (myRead.Read())
            {
                grid3.Rows.Insert(m);
                grid3.Rows[m].Height = 22;
                //
                grid3[m, 0] = new SourceGrid.Cells.Cell(myRead["row_id"].ToString(), typeof(string));
                grid3[m, 1] = new SourceGrid.Cells.CheckBox(null, false);

                grid3[m, 2] = new SourceGrid.Cells.Cell("", typeof(string));
                grid3[m, 2].Image = null;
                grid3[m, 2].Editor = cc.disable_cell;

                grid3[m, 3] = new SourceGrid.Cells.Cell(myRead["send_type"].ToString(), typeof(string));
                grid3[m, 3].View = cc.left_cellb;
                grid3[m, 3].Editor = cc.disable_cell;

                grid3[m, 4] = new SourceGrid.Cells.Cell(myRead["vehicle_type"].ToString(), typeof(string));
                grid3[m, 4].View = cc.left_cellb;
                grid3[m, 4].Editor = cc.disable_cell;

                grid3[m, 5] = new SourceGrid.Cells.Cell(myRead["action"].ToString(), typeof(string));
                grid3[m, 5].View = cc.center_cellb;
                grid3[m, 5].Editor = cc.disable_cell;

                grid3[m, 6] = new SourceGrid.Cells.Cell("");
                grid3[m, 6].View = viewImage;
                grid3[m, 6].Image = Properties.Resources.pencil_icon_16;
                grid3[m, 6].Editor = cc.disable_cell;

                grid3[m, 7] = new SourceGrid.Cells.Cell("", typeof(string));
                grid3[m, 7].View = cc.left_cell;
                grid3[m, 7].Editor = cc.disable_cell;

                grid3[m, 8] = new SourceGrid.Cells.Cell("", typeof(string));
                grid3[m, 8].View = cc.left_cell;
                grid3[m, 8].Editor = cc.disable_cell;

                grid3[m, 9] = new SourceGrid.Cells.Cell("", typeof(string));
                grid3[m, 9].View = cc.left_cell;
                grid3[m, 9].Editor = cc.disable_cell;

                grid3[m, 10] = new SourceGrid.Cells.Cell("", typeof(string));
                grid3[m, 10].View = cc.left_cell;
                grid3[m, 10].Editor = cc.disable_cell;

                grid3[m, 11] = new SourceGrid.Cells.Cell("", typeof(string));
                grid3[m, 11].View = cc.left_cell;
                grid3[m, 11].Editor = cc.disable_cell;

                grid3[m, 12] = new SourceGrid.Cells.Cell("", typeof(string));
                grid3[m, 12].View = cc.left_cell;
                grid3[m, 12].Editor = cc.disable_cell;

                grid3[m, 13] = new SourceGrid.Cells.Cell("", typeof(string));
                grid3[m, 13].View = cc.left_cell;
                grid3[m, 13].Editor = cc.disable_cell;

                grid3[m, 14] = new SourceGrid.Cells.Cell("", typeof(string));
                grid3[m, 14].View = cc.left_cell;
                grid3[m, 14].Editor = cc.disable_cell;

                grid3[m, 15] = new SourceGrid.Cells.Cell("");
                grid3[m, 15].View = viewImage1;
                grid3[m, 15].Image = Properties.Resources.note_25_icon_16;
                grid3[m, 15].Editor = cc.disable_cell;

                if (myRead["balju_day"].ToString() == "")
                    grid3[m, 16] = new SourceGrid.Cells.Cell("", typeof(string));
                else
                    grid3[m, 16] = new SourceGrid.Cells.Cell(myRead["balju_day"].ToString().Substring(2, 8), typeof(string));
                grid3[m, 16].View = cc.center_cellb;
                grid3[m, 16].Editor = cc.disable_cell;

                m++;
            }
            myRead.Close();
            DBCons.Close();
        }

        private void make_model()   //a/b_model 생성
        {
            var DBCons = new MySqlConnection(Config.DB_con1);
            DBCons.Open();
            //
            string cQuery = " select * from C_bmodel ";
            MySqlDataAdapter returnVal = new MySqlDataAdapter(cQuery, DBCons);
            returnVal.Fill(b_model);
            returnVal.Dispose();
            //       
            cQuery = " select * from C_cmodel ";
            MySqlDataAdapter returnVal1 = new MySqlDataAdapter(cQuery, DBCons);
            returnVal1.Fill(c_model);
            returnVal1.Dispose();
            //       
            cQuery = " select row_id,sangho from C_hcustomer ";
            MySqlDataAdapter returnVal2 = new MySqlDataAdapter(cQuery, DBCons);
            returnVal2.Fill(h_customer);
            returnVal2.Dispose();
            h_customer.DefaultView.Sort = "row_id ASC";
            //
            DBCons.Close();
        }

        private void grid1_DoubleClick(object sender, EventArgs e)
        {
            int cpos = grid1.Selection.ActivePosition.Column;
            int row = grid1.Selection.ActivePosition.Row;
            if(row < 0 )
                return;

            if (cpos.Equals(14))  //하리모형 열기
            {
                string[] m_db = new string[60];         //함축자료 배열
                string[] dat = new string[10];
                m_db = grid1[row, 30].ToString().Split(new char[1] { '#' });
                //
                string j_bon = m_db[54];   //제본옵션
                string sd = "2";  //자동화창에서호출
                //
                dat[0] = grid1[row, 0].ToString();  //row_id
                dat[1] = grid1[row, 7].ToString();  //서버항목명 --> [닷찌]등
                dat[2] = grid1[row, 8].ToString();  //전체 종이이름
                dat[3] = grid1[row, 30].ToString(); //복합자료(m_dat)
                dat[4] = grid1[row, 31].ToString(); //하리수정불가 표시
                dat[5] = grid1[row, 14].ToString(); //인쇄유형
                dat[6] = grid1[row, 51].ToString(); //원 인쇄유형
                dat[7] = grid1[row, 20].ToString(); //수량
                dat[8] = grid1[row, 24].ToString(); //단가
                dat[9] = grid1[row, 17].ToString(); //대수
                //  
                Form_hari fm = new Form_hari(dat, sd, j_bon, joo_id, grid1);  //분개장Row,기본,제본옵션,주문/견적
                if (fm.ShowDialog() == DialogResult.OK)
                {
                    select_1();
                }
            }
        }


    }

    
}
