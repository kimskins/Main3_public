using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using System.Drawing.Printing;
using System.Drawing.Drawing2D;


namespace Dukyou3
{
    public partial class Form_2011_old : Form
    {
        int page_n = 0;
        PrintDocument doc = new PrintDocument();
        PrintDialog dlg = new PrintDialog();
        string cQuery;

        cell_d cc = new cell_d();
        string DB_TableName = "C_sel_jul";
        string DB_TableName_file = "C_file_total_manage";

        DataGridControl GridHandle = new DataGridControl();

        public Form_2011_old()
        {
            InitializeComponent();
        }

        void DB_DTSet()  // Data Table Column Set
        {

            String[] DB_Item = new String[] {
                "chk", "bool",
                "row_id", "string",
                "a", "string",
                "b", "string",
                "c", "string",
                "d", "string",
                "e", "string",
                "f", "string",
                "g", "string",
                "h", "string",
                "i", "string",
                "j", "string",
                "k", "string",
                "l", "string",
                "m", "string",
                "n", "string",
                "nn", "string",
                "p", "string",
                "q", "string",
                "r", "string",
                "rr", "string",
                "t", "string",
                "da1", "string",
                "da2", "string",
                "d_size", "string",
                "m_julsu", "string",
                "jarak", "string",
                "grim1", "string",
                "grim2", "string"};

            String[] View_Item = new String[] {
                "row_id", "string",
                "chk", "bool",
                "No", "int",
                "a", "string",
                "b", "string",
                "c", "string",
                "d", "string",
                "e", "string",
                "f", "string",
                "h", "string",
                "i", "string",
                "g", "string",
                "k", "string",
                "j", "string",
                "l", "string",
                "m", "string",
                "n", "string",
                "nn", "string",
                "q", "string",
                "r", "string",
                "rr", "string",
                "da1", "string",
                "da2", "string",
                "d_size", "string",
                "m_julsu", "string",
                "jarak", "string",
                "grim1", "string",
                "grim2", "string",
                "grim1_path", "string",
                "grim2_path", "string"};
            GridHandle.DataTableInit(DB_Item, View_Item);
        }

        void Convert_Table(int i, int No)
        {
            string Moosun_Chk;
            string Jungchul_Chk;

            if (GridHandle.DB_dt.Rows[i]["grim1"].ToString() == "False" || GridHandle.DB_dt.Rows[i]["grim1"].ToString() == "false")
                Moosun_Chk = "";
            else
                Moosun_Chk = "**";

            if (GridHandle.DB_dt.Rows[i]["grim2"].ToString() == "False" || GridHandle.DB_dt.Rows[i]["grim2"].ToString() == "false")
                Jungchul_Chk = "";
            else
                Jungchul_Chk = "**";

            GridHandle.View_dt.Rows.Add(new object[] { GridHandle.DB_dt.Rows[i]["row_id"].ToString(),  false, GridHandle.DB_dt.Rows[i]["row_id"].ToString(), GridHandle.DB_dt.Rows[i]["a"].ToString()
                , GridHandle.DB_dt.Rows[i]["b"].ToString()
                , GridHandle.DB_dt.Rows[i]["c"].ToString(), GridHandle.DB_dt.Rows[i]["d"].ToString(), GridHandle.DB_dt.Rows[i]["e"].ToString(), GridHandle.DB_dt.Rows[i]["f"].ToString()
                , GridHandle.DB_dt.Rows[i]["h"].ToString(), GridHandle.DB_dt.Rows[i]["i"].ToString(), GridHandle.DB_dt.Rows[i]["g"].ToString(), GridHandle.DB_dt.Rows[i]["k"].ToString()
                , GridHandle.DB_dt.Rows[i]["j"].ToString(), GridHandle.DB_dt.Rows[i]["l"].ToString(), GridHandle.DB_dt.Rows[i]["m"].ToString(), GridHandle.DB_dt.Rows[i]["n"].ToString()
                , GridHandle.DB_dt.Rows[i]["nn"].ToString(), GridHandle.DB_dt.Rows[i]["q"].ToString(), GridHandle.DB_dt.Rows[i]["r"].ToString(), GridHandle.DB_dt.Rows[i]["rr"].ToString()
                , GridHandle.DB_dt.Rows[i]["da1"].ToString(), GridHandle.DB_dt.Rows[i]["da2"].ToString(), GridHandle.DB_dt.Rows[i]["d_size"].ToString(), GridHandle.DB_dt.Rows[i]["m_julsu"].ToString()
                , GridHandle.DB_dt.Rows[i]["jarak"].ToString(), Moosun_Chk, Jungchul_Chk, GridHandle.DB_dt.Rows[i]["grim1"].ToString(), GridHandle.DB_dt.Rows[i]["grim2"].ToString() });
        }

        void Grid_View(string Query)
        {
            GridHandle.View_dt.ColumnChanging -= new DataColumnChangeEventHandler(custTable_ColumnChanging);

            GridHandle.GetData(Query);

            GridHandle.ViewDtClear();

            for (int i = 0; i < GridHandle.DB_dt.Rows.Count; i++)
            {
                Convert_Table(i, i + 1);
            }

            //mView = GridHandle.View_dt.DefaultView;
            //mView.AllowDelete = true;
            //mView.AllowNew = false;
            //mView.AllowEdit = true;
            GridHandle.dataGrid1.SelectionMode = SourceGrid.GridSelectionMode.Cell;
            GridHandle.dataGrid1.DataSource = new DevAge.ComponentModel.BoundDataView(GridHandle.View_dt.DefaultView);
            GridHandle.dataGrid1.Rows.HeaderHeight = 30;
            GridHandle.dataGrid1.Rows.RowHeight = 24;
            GridHandle.dataGrid1.EnableSort = false;

            SourceGrid.Cells.Controllers.CustomEvents click1 = new SourceGrid.Cells.Controllers.CustomEvents();
            click1.Click += new EventHandler(o_Click);
            SourceGrid.Cells.Button button_cell = new SourceGrid.Cells.Button("");        //버튼셀
            button_cell.AddController(click1);

            string[] Paper_items = new string[] { "국", "46" };
            GridHandle.InputComboItem(Paper_items);

            string[] LeftUp_items = new string[] { "좌", "상" };
            GridHandle.InputComboItem(LeftUp_items);

            string[] Doji_items = new string[] { "가로", "세로" };
            GridHandle.InputComboItem(Doji_items);

            string[] Gyul_items = new string[] { "종목", "횡목" };
            GridHandle.InputComboItem(Gyul_items);

            GridHandle.dataGrid1.Columns[0].Visible = false;

            GridHandle.dataGrid1.Columns[1].HeaderCell = new MyHeader("√");
            GridHandle.dataGrid1.Columns[1].Width = 30;

            GridHandle.dataGrid1.Columns[2].HeaderCell = new MyHeader("No");
            GridHandle.dataGrid1.Columns[2].Width = 40;
            GridHandle.dataGrid1.Columns[2].DataCell.Editor = cc.disable_cell;

            GridHandle.dataGrid1.Columns[3].HeaderCell = new MyHeader("");
            GridHandle.dataGrid1.Columns[3].DataCell.Editor = GridHandle.CbBox[0];
            GridHandle.dataGrid1.Columns[3].Width = 30;

            GridHandle.dataGrid1.Columns[4].HeaderCell = new MyHeader("");
            GridHandle.dataGrid1.Columns[4].DataCell.Editor = GridHandle.CbBox[1];
            GridHandle.dataGrid1.Columns[4].Width = 30;

            GridHandle.dataGrid1.Columns[5].HeaderCell = new MyHeader("C절수");
            GridHandle.dataGrid1.Columns[5].Width = 44;

            GridHandle.dataGrid1.Columns[6].HeaderCell = new MyHeader("I절수");
            GridHandle.dataGrid1.Columns[6].Width = 42;

            GridHandle.dataGrid1.Columns[7].HeaderCell = new MyHeader("실가");
            GridHandle.dataGrid1.Columns[7].Width = 35;

            GridHandle.dataGrid1.Columns[8].HeaderCell = new MyHeader("실세");
            GridHandle.dataGrid1.Columns[8].Width = 35;

            GridHandle.dataGrid1.Columns[9].HeaderCell = new MyHeader("전가");
            GridHandle.dataGrid1.Columns[9].Width = 35;

            GridHandle.dataGrid1.Columns[10].HeaderCell = new MyHeader("전세");
            GridHandle.dataGrid1.Columns[10].Width = 35;

            GridHandle.dataGrid1.Columns[11].HeaderCell = new MyHeader("도지");
            GridHandle.dataGrid1.Columns[11].DataCell.Editor = GridHandle.CbBox[2];
            GridHandle.dataGrid1.Columns[11].Width = 35;

            GridHandle.dataGrid1.Columns[12].HeaderCell = new MyHeader("");
            GridHandle.dataGrid1.Columns[12].DataCell.Editor = GridHandle.CbBox[3];
            GridHandle.dataGrid1.Columns[12].Width = 40;

            GridHandle.dataGrid1.Columns[13].HeaderCell = new MyHeader("판");
            GridHandle.dataGrid1.Columns[13].Width = 20;

            GridHandle.dataGrid1.Columns[14].HeaderCell = new MyHeader("연결");
            GridHandle.dataGrid1.Columns[14].Width = 40;
            GridHandle.dataGrid1.Columns[14].DataCell.View = cc.center_cell;

            GridHandle.dataGrid1.Columns[15].HeaderCell = new MyHeader("무선형");
            GridHandle.dataGrid1.Columns[15].Width = 50;

            GridHandle.dataGrid1.Columns[16].HeaderCell = new MyHeader("접지1");
            GridHandle.dataGrid1.Columns[16].Width = 100;

            GridHandle.dataGrid1.Columns[17].HeaderCell = new MyHeader("접지2");
            GridHandle.dataGrid1.Columns[17].Width = 75;

            GridHandle.dataGrid1.Columns[18].HeaderCell = new MyHeader("중철형");
            GridHandle.dataGrid1.Columns[18].Width = 50;

            GridHandle.dataGrid1.Columns[19].HeaderCell = new MyHeader("접지1");
            GridHandle.dataGrid1.Columns[19].Width = 110;

            GridHandle.dataGrid1.Columns[20].HeaderCell = new MyHeader("접지2");
            GridHandle.dataGrid1.Columns[20].Width = 70;

            GridHandle.dataGrid1.Columns[21].HeaderCell = new MyHeader("닷");
            GridHandle.dataGrid1.Columns[21].Width = 30;

            GridHandle.dataGrid1.Columns[22].HeaderCell = new MyHeader("찌");
            GridHandle.dataGrid1.Columns[22].Width = 30;

            GridHandle.dataGrid1.Columns[23].HeaderCell = new MyHeader("Size");
            GridHandle.dataGrid1.Columns[23].Width = 60;

            GridHandle.dataGrid1.Columns[24].HeaderCell = new MyHeader("m - \r\n 절수");
            GridHandle.dataGrid1.Columns[24].Width = 40;

            GridHandle.dataGrid1.Columns[25].HeaderCell = new MyHeader("자락");
            GridHandle.dataGrid1.Columns[25].Width = 40;

            GridHandle.dataGrid1.Columns[26].HeaderCell = new MyHeader("무선\r\n그림");
            GridHandle.dataGrid1.Columns[26].Width = 36;
            GridHandle.dataGrid1.Columns[26].DataCell.View = cc.center_cellr;
            GridHandle.dataGrid1.Columns[26].DataCell.Editor = cc.disable_cell;

            GridHandle.dataGrid1.Columns[27].HeaderCell = new MyHeader("중철\r\n그림");
            GridHandle.dataGrid1.Columns[27].Width = 36;
            GridHandle.dataGrid1.Columns[27].DataCell.View = cc.center_cellr;
            GridHandle.dataGrid1.Columns[27].DataCell.Editor = cc.disable_cell;

            GridHandle.dataGrid1.Columns[28].Visible = false;  // 그림1의 경로 저장
            GridHandle.dataGrid1.Columns[29].Visible = false;  // 그림2의 경로 저장

            GridHandle.View_dt.ColumnChanging += new DataColumnChangeEventHandler(custTable_ColumnChanging);
            var position = new SourceGrid.Position(1, 3);
            GridHandle.dataGrid1.Selection.FocusRow(1);

        }

        private void o_Click(object sender, EventArgs e)  //클릭 이벤트
        {


        }

        private void Form_201_Load(object sender, EventArgs e)
        {
            DataView mView;
            mView = GridHandle.View_dt.DefaultView;
            mView.AllowDelete = true;
            mView.AllowNew = false;
            mView.AllowEdit = true;

            Screen srn = Screen.PrimaryScreen;
            int Xb = this.Width;  //좌,우
            this.Location = new Point((srn.Bounds.Width - Xb) / 2, 1);  //좌/우,위/아래
            //

            GridHandle.DataGrideInit(dataGrid1, Config.DB_con1, Config.Ftp_ip1, Config.Ftp_id1, Config.Ftp_pw1);
            GridHandle.dataGrid1.Columns.Clear();
            DB_DTSet();

            cQuery = "select * FROM "+DB_TableName+" where p_id='a' order by c";

            Grid_View(cQuery);

        }

        //----------------------------------------------------------------------------------

        private void button2_Click(object sender, EventArgs e)      //추가
        {
            GridHandle.View_dt.ColumnChanging -= new DataColumnChangeEventHandler(custTable_ColumnChanging);
            string s1, s2, s3, s4, s5 = "";
            s1 = comboBox1.Text.Trim();
            s2 = comboBox2.Text.Trim();
            s3 = textBox1.Text.Trim();
            s4 = comboBox3.Text.Trim();
            s5 = comboBox4.Text.Trim();
            //
            string id = "";
            if (comboBox5.Text.Equals("기타인쇄"))
            {
                id = "b";
            }
            else
            {
                id = "a";
            }

            string cQuery = "";
            cQuery = " insert into "+DB_TableName+" (a,b,c,g,k, d,e,f,h,i,j,l,m,n,nn,p,q,r,rr,t,da1,da2,d_size,m_julsu,jarak,p_id) values('" + s1 + "','" + s2 + "','" + s3 + "'";
            cQuery += ",'" + s4 + "','" + s5 + "','','','','','','','','','','','','','','','','','','','','','" + id + "')";

            int m = 0;
            if (GridHandle.DataUpdate(cQuery) == 1)  // DB Update
            {
                MessageBox.Show("서버 자료 등록에 실패 했습니다.");
                return;
            }
            else
            {
                cQuery = " select * from "+DB_TableName+" where row_id=(SELECT LAST_INSERT_ID())";
                GridHandle.GetData(cQuery);
                Convert_Table(0, GridHandle.View_dt.Rows.Count + 1); // 마지막 Data를 Select 하여 GridHandle.View_dt에 Add

            }
            GridHandle.View_dt.ColumnChanging += new DataColumnChangeEventHandler(custTable_ColumnChanging);

            var position = new SourceGrid.Position(GridHandle.View_dt.Rows.Count, 3);
            GridHandle.dataGrid1.Selection.Focus(position, true);

        }

        private void button1_Click(object sender, EventArgs e)     //삭제
        {
            GridHandle.View_dt.ColumnChanging -= new DataColumnChangeEventHandler(custTable_ColumnChanging);

            GridHandle.FtpDataDel(28, 1, DB_TableName);
            GridHandle.FtpDataDel(29, 1, DB_TableName); 
            GridHandle.ChkDataDelete(DB_TableName, 0, 1);

            GridHandle.View_dt.ColumnChanging += new DataColumnChangeEventHandler(custTable_ColumnChanging);
        }

        private void button3_Click(object sender, EventArgs e)  //검색(Refresh)
        {
            string s1, s2, s3, s4, s5, s6 = "";
            string c1, c2, c3, c4, c5, c6 = "";
            if (comboBox5.Text.Equals("기타인쇄"))
            {
                s6 = " and p_id ='b'";
            }
            else
            {
                s6 = " and p_id ='a'";
            }
            //
            if (comboBox1.Text != "")
            {
                c1 = comboBox1.Text.Trim();
                s1 = " and a ='" + c1 + "'";
            }
            else
                s1 = "";
            //
            if (comboBox2.Text != "")
            {
                c2 = comboBox2.Text.Trim();
                s2 = " and b ='" + c2 + "'";
            }
            else
                s2 = "";
            //
            if (textBox1.Text != "")
            {
                c3 = textBox1.Text.Trim();
                s3 = " and c ='" + c3 + "'";
            }
            else
                s3 = "";
            //
            if (comboBox3.Text != "")
            {
                c4 = comboBox3.Text.Trim();
                s4 = " and g ='" + c4 + "'";
            }
            else
                s4 = "";
            //
            if (comboBox4.Text != "")
            {
                c5 = comboBox4.Text.Trim();
                s5 = " and k ='" + c5 + "'";
            }
            else
                s5 = "";
            //

            cQuery = " select * FROM "+DB_TableName;
            cQuery += " where row_id is not null " + s1 + s2 + s3 + s4 + s5 + s6;
            cQuery += " order by c";

            Grid_View(cQuery);

        }


        private void button4_Click(object sender, EventArgs e)     //clear
        {
            comboBox1.Text = "";
            comboBox2.Text = "";
            comboBox3.Text = "";
            comboBox4.Text = "";
            textBox1.Text = "";
        }

        private void button5_Click(object sender, EventArgs e)    //인쇄
        {
            /*
            PrintPreviewDialog dlg = new PrintPreviewDialog();
            PrintDocument doc = new PrintDocument();
            PageSettings ps = new PageSettings();
            ps.Margins = new Margins(10, 10, 10, 10);
            ps.PrinterSettings.FromPage = 1;
            ps.PrinterSettings.ToPage = 2;
            dlg.Document = doc;
            doc.PrintPage += new PrintPageEventHandler(doc_PrintPage);
            doc.DefaultPageSettings = ps;
            dlg.Location = new Point(100,100);  //좌/우,위/아래
            dlg.ShowDialog();
            */
            doc = new PrintDocument();
            dlg.Document = doc;
            //dlg.AllowCurrentPage = true;
            //dlg.AllowSelection = true;
            //dlg.AllowSomePages = true;
            //dlg.PrinterSettings.FromPage = 1;
            //dlg.PrinterSettings.ToPage = 2;
            doc.PrinterSettings = dlg.PrinterSettings;
            doc.PrintPage += new PrintPageEventHandler(doc_PrintPage);

            if (dlg.ShowDialog() == DialogResult.OK)
            {
                doc.Print();
            }
        }

        void doc_PrintPage(object sender, PrintPageEventArgs e)
        {
            //MessageBox.Show(page_n.ToString());
            Graphics g = e.Graphics;
            Pen p = new Pen(Brushes.Black, 1);
            GraphicsPath gp = new GraphicsPath(); //그릴경로지정객체
            //Font M_font = new Font("궁서체", 15, FontStyle.Bold);
            //Font S_font = new Font("굴림체", 13);
            //Font R_font = new Font("바탕체", 9);
            //g.FillRectangle(Brushes.White, 100, 50, 800, 600);   // 배경 네모 만들기
            //g.DrawImage(backimg, 100, 50);   // 배경그림넣기

            StringFormat sf = new StringFormat();
            sf.Alignment = StringAlignment.Far;//Far=왼쪽,Near=오른쪽,Center=중앙

            string ct = "";  //임시 글자
            int Ln = 50;     //페이지 설정수
            int Gn = page_n; //그리드 row수
            gp.AddLine(20, Ln, 780, Ln);  //(좌우,수직,좌우,수직)4:1
            gp.StartFigure();  //실제로 그림
            Ln += 8;
            g.DrawString("No", new Font("Arial", 10), Brushes.Black, 40, Ln);        //(row_id)
            g.DrawString("국/46", new Font("Arial", 10), Brushes.Black, 85, Ln);    //(국/46)
            g.DrawString("상/좌", new Font("Arial", 10), Brushes.Black, 130, Ln);    //(상/좌)
            g.DrawString("인쇄절수", new Font("Arial", 10), Brushes.Black, 180, Ln); //(인쇄절수)
            g.DrawString("종이절수", new Font("Arial", 10), Brushes.Black, 255, Ln); //(종이절수)
            g.DrawString("실가로", new Font("Arial", 10), Brushes.Black, 330, Ln);   //(실가로)
            g.DrawString("실세로", new Font("Arial", 10), Brushes.Black, 390, Ln);   //(실세로)
            g.DrawString("전지가로", new Font("Arial", 10), Brushes.Black, 460, Ln); //(전지가로)
            g.DrawString("전지세로", new Font("Arial", 10), Brushes.Black, 530, Ln); //(전지세로)
            g.DrawString("도지방향", new Font("Arial", 10), Brushes.Black, 600, Ln); //(도지방향)
            g.DrawString("종/횡목", new Font("Arial", 10), Brushes.Black, 690, Ln);  //(종/횡목)
            Ln += 22;
            gp.AddLine(20, Ln, 780, Ln);  //(좌우,수직,좌우,수직)4:1
            gp.StartFigure();
            // 
            while (Gn < GridHandle.View_dt.Rows.Count && Ln < 1100) //
            {
                Ln += 8;
                ct = GridHandle.View_dt.Rows[Gn][2].ToString();
                g.DrawString(ct, new Font("Arial", 10), Brushes.Black, 65, Ln, sf);  //row_id

                ct = GridHandle.View_dt.Rows[Gn][3].ToString();
                g.DrawString(ct, new Font("Arial", 10), Brushes.Black, 95, Ln);  //국,46

                ct = GridHandle.View_dt.Rows[Gn][4].ToString();
                g.DrawString(ct, new Font("Arial", 10), Brushes.Black, 140, Ln);  //상/좌

                ct = GridHandle.View_dt.Rows[Gn][5].ToString();
                g.DrawString(ct, new Font("Arial", 10), Brushes.Black, 200, Ln);  //인쇄절수

                ct = GridHandle.View_dt.Rows[Gn][6].ToString();
                g.DrawString(ct, new Font("Arial", 10), Brushes.Black, 280, Ln);  //종이절수

                ct = GridHandle.View_dt.Rows[Gn][7].ToString();
                g.DrawString(ct, new Font("Arial", 10), Brushes.Black, 350, Ln);  //실가로

                ct = GridHandle.View_dt.Rows[Gn][8].ToString();
                g.DrawString(ct, new Font("Arial", 10), Brushes.Black, 410, Ln);  //실세로

                ct = GridHandle.View_dt.Rows[Gn][9].ToString();
                g.DrawString(ct, new Font("Arial", 10), Brushes.Black, 490, Ln);  //전지가로

                ct = GridHandle.View_dt.Rows[Gn][10].ToString();
                g.DrawString(ct, new Font("Arial", 10), Brushes.Black, 560, Ln);  //전지세로

                ct = GridHandle.View_dt.Rows[Gn][11].ToString();
                g.DrawString(ct, new Font("Arial", 10), Brushes.Black, 610, Ln);  //도지방향

                ct = GridHandle.View_dt.Rows[Gn][12].ToString();
                g.DrawString(ct, new Font("Arial", 10), Brushes.Black, 700, Ln);  //종,횡목
                Ln += 22;
                gp.AddLine(20, Ln, 780, Ln);  //(좌우,수직,좌우,수직)4:1
                gp.StartFigure();
                Gn++;
            }
            gp.AddLine(20, 50, 20, Ln);  //수직선(좌우,수직,좌우,수직)4:1
            gp.StartFigure();
            gp.AddLine(80, 50, 80, Ln);  //수직선(좌우,수직,좌우,수직)4:1
            gp.StartFigure();
            gp.AddLine(128, 50, 128, Ln);  //수직선(좌우,수직,좌우,수직)4:1
            gp.StartFigure();
            gp.AddLine(176, 50, 176, Ln);  //수직선(좌우,수직,좌우,수직)4:1
            gp.StartFigure();
            gp.AddLine(248, 50, 248, Ln);  //수직선(좌우,수직,좌우,수직)4:1
            gp.StartFigure();
            gp.AddLine(324, 50, 324, Ln);  //수직선(좌우,수직,좌우,수직)4:1
            gp.StartFigure();
            gp.AddLine(384, 50, 384, Ln);  //수직선(좌우,수직,좌우,수직)4:1
            gp.StartFigure();
            gp.AddLine(452, 50, 452, Ln);  //수직선(좌우,수직,좌우,수직)4:1
            gp.StartFigure();
            gp.AddLine(528, 50, 528, Ln);  //수직선(좌우,수직,좌우,수직)4:1
            gp.StartFigure();
            gp.AddLine(594, 50, 594, Ln);  //수직선(좌우,수직,좌우,수직)4:1
            gp.StartFigure();
            gp.AddLine(680, 50, 680, Ln);  //수직선(좌우,수직,좌우,수직)4:1
            gp.StartFigure();
            gp.AddLine(780, 50, 780, Ln);  //수직선(좌우,수직,좌우,수직)4:1
            gp.StartFigure();
            //
            gp.StartFigure();
            g.DrawPath(p, gp);       //선은 일괄해서 그리고
            if (Gn < GridHandle.View_dt.Rows.Count)
            {
                page_n = Gn;
                e.HasMorePages = true;
            }
            else
                page_n = 0;
        }

        private void button6_Click(object sender, EventArgs e)
        {
            Excel_convert Ec = new Excel_convert(GridHandle.View_dt, GridHandle.dataGrid1);
            Ec.Convert();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)  //셀클릭
        {


        }

        private void Grid_DoubleClick(object sender, EventArgs e)
        {
            if (dataGrid1.Selection.ActivePosition.Row < 0)
                return;
            OhFTP Ftp = new OhFTP(Config.Ftp_ip1, Config.Ftp_id1, Config.Ftp_pw1);
            string row_no = GridHandle.View_dt.Rows[dataGrid1.Selection.ActivePosition.Row - 1][0].ToString();
            string pic_Moosun = GridHandle.View_dt.Rows[dataGrid1.Selection.ActivePosition.Row - 1][26].ToString();
            string pic_Jungchul = GridHandle.View_dt.Rows[dataGrid1.Selection.ActivePosition.Row - 1][27].ToString();

            string pic_Moosun_Path = "";
            string pic_Jungchul_Path = "";
            string Query = "select * from " + DB_TableName_file + " where db_nm = '" + DB_TableName + "' and int_id = '" + row_no + "' and f_option = 'jungchul'";
            var DBConn = new MySqlConnection(Config.DB_con1);
            DBConn.Open();
            var cmd = new MySqlCommand(Query, DBConn);
            var myRead = cmd.ExecuteReader();
            if (myRead.Read())
            {
                pic_Jungchul_Path = myRead["server_file"].ToString();
            }
            myRead.Close();

            Query = "select * from " + DB_TableName_file + " where db_nm = '" + DB_TableName + "' and int_id = '" + row_no + "' and f_option = 'moosun'";
            cmd = new MySqlCommand(Query, DBConn);
            myRead = cmd.ExecuteReader();
            
            if (myRead.Read())
            {
                pic_Moosun_Path = myRead["server_file"].ToString();
            }
            myRead.Close();
            DBConn.Close();

            string FilePath;
            if (dataGrid1.Selection.ActivePosition.Column == 26)
            {
                if (pic_Moosun.Equals(""))  //그림파일 등록
                {
                    FilePath = GridHandle.PictureReg("-jubji_1", DB_TableName, "grim1", row_no, "moosun");
                    if (FilePath != "")
                    {
                        GridHandle.View_dt.Rows[dataGrid1.Selection.ActivePosition.Row - 1][26] = "**";
                        GridHandle.View_dt.Rows[dataGrid1.Selection.ActivePosition.Row - 1]["grim1_path"] = FilePath;
                    }
                }
                else                         //그림파일 보기
                {
                    Ftp.ViewLoadFile(pic_Moosun_Path, DB_TableName);  //서버에 있는 파일보기
                }
            }
            if (dataGrid1.Selection.ActivePosition.Column == 27)
            {
                if (pic_Jungchul.Equals(""))  //그림파일 등록
                {
                    FilePath = GridHandle.PictureReg("-jubji_2", DB_TableName, "grim2", row_no, "jungchul");
                    if (FilePath != "")
                    {
                        GridHandle.View_dt.Rows[dataGrid1.Selection.ActivePosition.Row - 1][27] = "**";
                        GridHandle.View_dt.Rows[dataGrid1.Selection.ActivePosition.Row - 1]["grim2_path"] = FilePath;
                    }
                }
                else                         //그림파일 보기
                {
                    Ftp.ViewLoadFile(pic_Jungchul_Path, DB_TableName);  //서버에 있는 파일보기
                }
            }
            //
            dataGrid1.Refresh();
        }

        private void custTable_ColumnChanging(object sender, DataColumnChangeEventArgs e)
        {
            if (GridHandle.dataGrid1.Selection.ActivePosition.Row.Equals(-1))
                return;

            string cQuery = "";
            string dat = e.ProposedValue.ToString().Trim();
            string row_no = GridHandle.View_dt.Rows[dataGrid1.Selection.ActivePosition.Row - 1][0].ToString();         //row_id
            //
            if (GridHandle.dataGrid1.Selection.ActivePosition.Column == 3)
                cQuery = " update "+DB_TableName+" set a='" + dat + "' where row_id='" + row_no + "'";
            else if (GridHandle.dataGrid1.Selection.ActivePosition.Column == 4)
                cQuery = " update "+DB_TableName+" set b='" + dat + "' where row_id='" + row_no + "'";
            else if (GridHandle.dataGrid1.Selection.ActivePosition.Column == 5)
                cQuery = " update "+DB_TableName+" set c='" + dat + "' where row_id='" + row_no + "'";
            else if (GridHandle.dataGrid1.Selection.ActivePosition.Column == 6)
                cQuery = " update "+DB_TableName+" set d='" + dat + "' where row_id='" + row_no + "'";
            else if (GridHandle.dataGrid1.Selection.ActivePosition.Column == 7)
                cQuery = " update "+DB_TableName+" set e='" + dat + "' where row_id='" + row_no + "'";
            else if (GridHandle.dataGrid1.Selection.ActivePosition.Column == 8)
                cQuery = " update "+DB_TableName+" set f='" + dat + "' where row_id='" + row_no + "'";
            else if (GridHandle.dataGrid1.Selection.ActivePosition.Column == 9)
                cQuery = " update "+DB_TableName+" set h='" + dat + "' where row_id='" + row_no + "'";
            else if (GridHandle.dataGrid1.Selection.ActivePosition.Column == 10)
                cQuery = " update "+DB_TableName+" set i='" + dat + "' where row_id='" + row_no + "'";
            else if (GridHandle.dataGrid1.Selection.ActivePosition.Column == 11)
                cQuery = " update "+DB_TableName+" set g='" + dat + "' where row_id='" + row_no + "'";
            else if (GridHandle.dataGrid1.Selection.ActivePosition.Column == 12)
                cQuery = " update "+DB_TableName+" set k='" + dat + "' where row_id='" + row_no + "'";
            else if (GridHandle.dataGrid1.Selection.ActivePosition.Column == 13)
                cQuery = " update "+DB_TableName+" set j='" + dat + "' where row_id='" + row_no + "'";
            else if (GridHandle.dataGrid1.Selection.ActivePosition.Column == 14)
                cQuery = " update "+DB_TableName+" set l='" + dat + "' where row_id='" + row_no + "'";
            else if (GridHandle.dataGrid1.Selection.ActivePosition.Column == 15)
                cQuery = " update "+DB_TableName+" set m='" + dat + "' where row_id='" + row_no + "'";
            else if (GridHandle.dataGrid1.Selection.ActivePosition.Column == 16)
                cQuery = " update "+DB_TableName+" set n='" + dat + "' where row_id='" + row_no + "'";
            else if (GridHandle.dataGrid1.Selection.ActivePosition.Column == 17)
                cQuery = " update "+DB_TableName+" set nn='" + dat + "' where row_id='" + row_no + "'";
            else if (GridHandle.dataGrid1.Selection.ActivePosition.Column == 18)
                cQuery = " update "+DB_TableName+" set q='" + dat + "' where row_id='" + row_no + "'";
            else if (GridHandle.dataGrid1.Selection.ActivePosition.Column == 19)
                cQuery = " update "+DB_TableName+" set r='" + dat + "' where row_id='" + row_no + "'";
            else if (GridHandle.dataGrid1.Selection.ActivePosition.Column == 20)
                cQuery = " update "+DB_TableName+" set rr='" + dat + "' where row_id='" + row_no + "'";
            else if (GridHandle.dataGrid1.Selection.ActivePosition.Column == 21)
                cQuery = " update "+DB_TableName+" set da1='" + dat + "' where row_id='" + row_no + "'";
            else if (GridHandle.dataGrid1.Selection.ActivePosition.Column == 22)
                cQuery = " update "+DB_TableName+" set da2='" + dat + "' where row_id='" + row_no + "'";
            else if (GridHandle.dataGrid1.Selection.ActivePosition.Column == 23)
                cQuery = " update "+DB_TableName+" set d_size='" + dat + "' where row_id='" + row_no + "'";
            else if (GridHandle.dataGrid1.Selection.ActivePosition.Column == 24)
                cQuery = " update "+DB_TableName+" set m_julsu='" + dat + "' where row_id='" + row_no + "'";
            else if (GridHandle.dataGrid1.Selection.ActivePosition.Column == 25)
                cQuery = " update "+DB_TableName+" set jarak='" + dat + "' where row_id='" + row_no + "'";
            else
                return;

            if (GridHandle.DataUpdate(cQuery) == 1)
                MessageBox.Show("서버 자료 수정에 실패 했습니다.");

        }

        private void Form_201_FormClosing(object sender, FormClosingEventArgs e)
        {
            
        }

    }

}
