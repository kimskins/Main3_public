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
    public partial class Form_501xx : Form
    {
        SourceGrid.Cells.Views.Cell center_cell;   //중앙셀
        SourceGrid.Cells.Views.Cell center_cellr;  //중앙셀r
        SourceGrid.Cells.Views.Cell center_cellb;  //중앙셀b
        SourceGrid.Cells.Views.Cell left_cell;     //좌측셀
        SourceGrid.Cells.Views.Cell left_cellr;    //좌측셀r
        SourceGrid.Cells.Views.Cell left_cellb;    //좌측셀b
        SourceGrid.Cells.Views.Cell int_cell;      //우측셀
        SourceGrid.Cells.Views.Cell int_cellr;     //우측셀r
        SourceGrid.Cells.Views.Cell int_cellb;     //우측셀b
        SourceGrid.Cells.Editors.TextBox disable_cell; //수정불가


        public Form_501xx()
        {
            InitializeComponent();

        }

        private void Form_jiupsa_Load(object sender, EventArgs e)
        {
            center_cell = new SourceGrid.Cells.Views.Cell();
            center_cell.TextAlignment = DevAge.Drawing.ContentAlignment.MiddleCenter;
            center_cellr = new SourceGrid.Cells.Views.Cell();
            center_cellr.TextAlignment = DevAge.Drawing.ContentAlignment.MiddleCenter;
            center_cellr.BackColor = Color.FromArgb(255, 250, 250);
            center_cellb = new SourceGrid.Cells.Views.Cell();
            center_cellb.TextAlignment = DevAge.Drawing.ContentAlignment.MiddleCenter;
            center_cellb.BackColor = Color.FromArgb(240, 248, 255);
            //
            left_cell = new SourceGrid.Cells.Views.Cell();
            left_cell.TextAlignment = DevAge.Drawing.ContentAlignment.MiddleLeft;
            left_cellr = new SourceGrid.Cells.Views.Cell();
            left_cellr.TextAlignment = DevAge.Drawing.ContentAlignment.MiddleLeft;
            left_cellr.BackColor = Color.FromArgb(255, 250, 250);
            left_cellb = new SourceGrid.Cells.Views.Cell();
            left_cellb.TextAlignment = DevAge.Drawing.ContentAlignment.MiddleLeft;
            left_cellb.BackColor = Color.FromArgb(240, 248, 255);
            //
            int_cell = new SourceGrid.Cells.Views.Cell();
            int_cell.TextAlignment = DevAge.Drawing.ContentAlignment.MiddleRight;
            int_cellr = new SourceGrid.Cells.Views.Cell();
            int_cellr.TextAlignment = DevAge.Drawing.ContentAlignment.MiddleRight;
            int_cellr.BackColor = Color.FromArgb(255, 250, 250);
            int_cellb = new SourceGrid.Cells.Views.Cell();
            int_cellb.TextAlignment = DevAge.Drawing.ContentAlignment.MiddleRight;
            int_cellb.BackColor = Color.FromArgb(240, 248, 255);
            //
            disable_cell = new SourceGrid.Cells.Editors.TextBox(typeof(string));  //수정불가
            disable_cell.EnableEdit = false;
            //
            this.Location = new Point(1, 1);
            button13_Click(null, null);  //검색
        }

        private void button13_Click(object sender, EventArgs e)  //검색
        {

            SourceGrid.Cells.Controllers.CustomEvents val_c1 = new SourceGrid.Cells.Controllers.CustomEvents();
            SourceGrid.Cells.Controllers.CustomEvents clickEvent1 = new SourceGrid.Cells.Controllers.CustomEvents();
            SourceGrid.Cells.Controllers.CustomEvents clickEventd1 = new SourceGrid.Cells.Controllers.CustomEvents();
            //
            clickEventd1 = new SourceGrid.Cells.Controllers.CustomEvents();
            clickEvent1.Click += new EventHandler(clickEvent_Click1);
            clickEventd1.DoubleClick += new EventHandler(clickEvent_Clickd1);
            grid1.Controller.AddController(val_c1);
            // 
            grid1.Rows.Clear();
            grid1.BorderStyle = BorderStyle.FixedSingle;
            grid1.SelectionMode = SourceGrid.GridSelectionMode.Cell;
            grid1.ColumnsCount = 30;
            grid1.FixedRows = 1;
            grid1.Rows.Insert(0);
            grid1.Rows[0].Height = 26;
            //
            grid1[0, 0] = new MyHeader1("row_id");
            grid1.Columns[0].Visible = false;
            grid1[0, 1] = new MyHeader1("√");
            grid1[0, 2] = new MyHeader1("No");
            grid1[0, 3] = new MyHeader1("조치");
            grid1[0, 4] = new MyHeader1("발주번호");
            grid1[0, 5] = new MyHeader1("메모");
            grid1[0, 6] = new MyHeader1("발주일");
            grid1[0, 7] = new MyHeader1("발주처");
            grid1[0, 8] = new MyHeader1("지업사");
            grid1[0, 9] = new MyHeader1("*");
            grid1[0, 10] = new MyHeader1("입고처");
            grid1[0, 11] = new MyHeader1("국46");
            grid1[0, 12] = new MyHeader1("절");
            grid1[0, 13] = new MyHeader1("전체 종이명");
            grid1[0, 14] = new MyHeader1("색상");
            grid1[0, 15] = new MyHeader1("제조사");
            grid1[0, 16] = new MyHeader1("재단Size");
            grid1[0, 17] = new MyHeader1("연수");
            grid1[0, 18] = new MyHeader1("％");
            grid1[0, 19] = new MyHeader1("단가1");
            grid1[0, 20] = new MyHeader1("=");
            grid1[0, 21] = new MyHeader1("％");
            grid1[0, 22] = new MyHeader1("단가2");
            grid1[0, 23] = new MyHeader1("=");
            grid1[0, 24] = new MyHeader1("금 액");
            grid1[0, 25] = new MyHeader1("VAT");
            grid1[0, 26] = new MyHeader1("총 액");
            grid1[0, 27] = new MyHeader1("결재금액");
            grid1[0, 28] = new MyHeader1("잔 액");
            grid1[0, 29] = new MyHeader1("세금코드");
            //
            grid1.Columns[0].Width = 100; //row_id
            grid1.Columns[1].Width = 22;  //√
            grid1.Columns[2].Width = 30;  //No
            grid1.Columns[3].Width = 40;  //조치
            grid1.Columns[4].Width = 70;  //발주번호
            grid1.Columns[5].Width = 40;  //메모
            grid1.Columns[6].Width = 60;  //발주일
            grid1.Columns[7].Width = 80;  //발주처
            grid1.Columns[8].Width = 80;  //지업사
            grid1.Columns[9].Width = 16;  //*
            grid1.Columns[10].Width = 80; //입고처
            grid1.Columns[11].Width = 40; //국46
            grid1.Columns[12].Width = 40; //절
            grid1.Columns[13].Width = 120;//전체 종이명
            grid1.Columns[14].Width = 60; //색상
            grid1.Columns[15].Width = 60; //제조사
            grid1.Columns[16].Width = 60; //재단Size
            grid1.Columns[17].Width = 40; //연수
            grid1.Columns[18].Width = 30; //％
            grid1.Columns[19].Width = 60; //단가1
            grid1.Columns[20].Width = 22; //=
            grid1.Columns[21].Width = 30; //％
            grid1.Columns[22].Width = 60; //단가2
            grid1.Columns[23].Width = 22; //=
            grid1.Columns[24].Width = 60; //금 액
            grid1.Columns[25].Width = 60; //VAT
            grid1.Columns[26].Width = 60; //총 액
            grid1.Columns[27].Width = 60; //결재금액
            grid1.Columns[28].Width = 60; //잔 액
            grid1.Columns[29].Width = 80; //세금코드
            //
            /*
            var DBConn = new MySqlConnection(Config.DB_con1);
            DBConn.Open();
            string cQuery = "select * FROM bungae2"; //주문
            cQuery += " where int_id='111' order by  no_s";
            var cmd = new MySqlCommand(cQuery, DBConn);
            var myRead = cmd.ExecuteReader();
            // 
            int m = 1;
            while (myRead.Read())
            {
                grid1.Rows.Insert(m);
                grid1.Rows[m].Height = 22;
                //
                grid1[m, 0] = new SourceGrid.Cells.Cell(myRead["row_id"], typeof(string));
                grid1[m, 1] = new SourceGrid.Cells.CheckBox(null, false);
                grid1[m, 2] = new SourceGrid.Cells.Cell(m.ToString(), typeof(string));
                grid1[m, 2].View = center_cell;
                grid1[m, 2].Editor = disable_cell;
                grid1[m, 3] = new SourceGrid.Cells.Cell(myRead["hang"].ToString(), typeof(string));
                grid1[m, 3].View = left_cell;
                grid1[m, 4] = new SourceGrid.Cells.Cell(myRead["t_paperm"].ToString(), typeof(string));
                grid1[m, 4].View = left_cellb;
                grid1[m, 4].AddController(clickEventd1);
                grid1[m, 5] = new SourceGrid.Cells.Cell(myRead["bigo"].ToString(), typeof(string));
                grid1[m, 6] = new SourceGrid.Cells.Cell(myRead["dosu"].ToString(), typeof(string));
                grid1[m, 6].View = center_cell;
                grid1[m, 7] = new SourceGrid.Cells.Cell(myRead["byeol_s"].ToString(), typeof(string));
                grid1[m, 7].View = center_cellb;
                grid1[m, 7].AddController(clickEventd1);
                m++;
            }
            myRead.Close();
            DBConn.Close();
            */
            for (int i = 1; i <= 30; i++)
            {
                grid1.Rows.Insert(i);
                grid1.Rows[i].Height = 22;
                //
                grid1[i, 0] = new SourceGrid.Cells.Cell("", typeof(string));
                grid1[i, 1] = new SourceGrid.Cells.CheckBox(null, false);
                grid1[i, 2] = new SourceGrid.Cells.Cell(i.ToString(), typeof(string));
                grid1[i, 2].View = center_cell;
                grid1[i, 2].Editor = disable_cell;
                grid1[i, 3] = new SourceGrid.Cells.Cell("", typeof(string));
                grid1[i, 4] = new SourceGrid.Cells.Cell("", typeof(string));
                grid1[i, 5] = new SourceGrid.Cells.Cell("", typeof(string));
                grid1[i, 6] = new SourceGrid.Cells.Cell("", typeof(string));
                grid1[i, 7] = new SourceGrid.Cells.Cell("", typeof(string));
                grid1[i, 8] = new SourceGrid.Cells.Cell("", typeof(string));
                grid1[i, 9] = new SourceGrid.Cells.Button("");
                grid1[i, 9].AddController(clickEvent1);
                grid1[i, 10] = new SourceGrid.Cells.Cell("", typeof(string));
                grid1[i, 11] = new SourceGrid.Cells.Cell("", typeof(string));
                grid1[i, 12] = new SourceGrid.Cells.Cell("", typeof(string));
                grid1[i, 13] = new SourceGrid.Cells.Cell("", typeof(string));
                grid1[i, 14] = new SourceGrid.Cells.Cell("", typeof(string));
                grid1[i, 15] = new SourceGrid.Cells.Cell("", typeof(string));
                grid1[i, 16] = new SourceGrid.Cells.Cell("", typeof(string));
                grid1[i, 17] = new SourceGrid.Cells.Cell("", typeof(string));
                grid1[i, 18] = new SourceGrid.Cells.Cell("", typeof(string));
                grid1[i, 19] = new SourceGrid.Cells.Cell("", typeof(string));
                grid1[i, 20] = new SourceGrid.Cells.CheckBox(null, false);
                grid1[i, 21] = new SourceGrid.Cells.Cell("", typeof(string));
                grid1[i, 22] = new SourceGrid.Cells.Cell("", typeof(string));
                grid1[i, 23] = new SourceGrid.Cells.Cell("", typeof(string));
                grid1[i, 24] = new SourceGrid.Cells.Cell("", typeof(string));
                grid1[i, 25] = new SourceGrid.Cells.Cell("", typeof(string));
                grid1[i, 26] = new SourceGrid.Cells.Cell("", typeof(string));
                grid1[i, 27] = new SourceGrid.Cells.Cell("", typeof(string));
                grid1[i, 28] = new SourceGrid.Cells.Cell("", typeof(string));
                grid1[i, 29] = new SourceGrid.Cells.Cell("", typeof(string));
            }


        }

        private void clickEvent_Click1(object sender, EventArgs e)  //Grid1에서 원클릭시
        {
            //string row_no = grid1[grid1.Selection.ActivePosition.Row, 0].Value.ToString(); //row_id
            //int cpos = grid1.Selection.ActivePosition.Column;

            //if (cpos == 9)        //
            //{
            //    Form_501a frm = new Form_501a();
            //    if (frm.ShowDialog() == DialogResult.OK)
            //    {


            //    }
            //}
        }

        private void clickEvent_Clickd1(object sender, EventArgs e)  //Grid1에서 더블클릭시
        {
            SourceGrid.Cells.Controllers.CustomEvents clickEventd1 = new SourceGrid.Cells.Controllers.CustomEvents();
            //
            clickEventd1 = new SourceGrid.Cells.Controllers.CustomEvents();
            clickEventd1.DoubleClick += new EventHandler(clickEvent_Clickd1);
            //
            string row_no = grid1[grid1.Selection.ActivePosition.Row, 0].ToString().Trim();
            int cpos = grid1.Selection.ActivePosition.Column;
            int rpos = grid1.Selection.ActivePosition.Row;

            if (cpos == 6)        //수정
            {

            }
        }
    }
}
