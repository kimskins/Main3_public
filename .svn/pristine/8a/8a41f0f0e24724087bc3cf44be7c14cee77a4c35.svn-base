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
    public partial class Form_size_view : Form
    {
        string DB_TableName = "C_size_type";
        public string m_size = "";
        private Label label = new Label();
        string code = "";
        private int Xb = 0;
        private int Yb = 0;

        public Form_size_view(Label la, string cc)    //주문창에서 사용함
        {
            InitializeComponent();
            label = la;
            code = cc; //폼띄우는 구분번호(3종류)
            //
            Xb = label.PointToScreen(Location).X - (this.Width / 4);//좌,우
            Yb = label.PointToScreen(Location).Y + label.Height;    //위,아래
        }

        public Form_size_view(Label la, string cc, string hh) //하리창에서 사용함
        {
            InitializeComponent();
            label = la;
            code = cc; //폼띄우는 구분번호(3종류)
            //
            if (hh == "hari")
            {
                Xb = label.PointToScreen(Location).X;                   //좌,우
                Yb = label.PointToScreen(Location).Y + label.Height;    //위,아래
            }
            else  //추후 사용예정
            {
                Xb = label.PointToScreen(Location).X - (this.Width / 2);//좌,우
                Yb = label.PointToScreen(Location).Y + label.Height;    //위,아래
            }
        }

        private void Form_size_view_Load(object sender, EventArgs e)
        {
            this.Location = new Point(Xb, Yb);
            //
            if(code == "1")
                label1.Text = "도큐싸이즈";
            else if (code == "2")
                label1.Text = "인쇄싸이즈";
            else if (code == "3")
                label1.Text = "종이싸이즈";
            //
            cell_d cc = new cell_d();
            SourceGrid.Cells.Controllers.CustomEvents clickEvent1 = new SourceGrid.Cells.Controllers.CustomEvents();
            clickEvent1.Click += new EventHandler(clickEvent_Click1);
            SourceGrid.Cells.Controllers.CustomEvents clickEvent2 = new SourceGrid.Cells.Controllers.CustomEvents();
            clickEvent2.Click += new EventHandler(clickEvent_Click2);
            //           
            grid1.Rows.Clear();
            grid1.ColumnsCount = 5;
            grid1.VScrollBar.Visible = true;

            grid1.FixedRows = 1;
            grid1.Rows.Insert(0);
            grid1.Rows[0].Height = 28;
            //
            grid1[0, 0] = new MyHeader1("√");
            grid1[0, 1] = new MyHeader1("판형");
            grid1[0, 2] = new MyHeader1("절수");
            grid1[0, 3] = new MyHeader1("크기(mm)");
            grid1[0, 4] = new MyHeader1("참  고");
            //
            grid1.Columns[0].Width = 22;
            grid1.Columns[1].Width = 34;
            grid1.Columns[2].Width = 34;
            grid1.Columns[3].Width = 66;
            grid1.Columns[4].Width = 66;
            //
            //
            grid2.Rows.Clear();
            grid2.ColumnsCount = 5;
            grid2.VScrollBar.Visible = true;

            grid2.FixedRows = 1;
            grid2.Rows.Insert(0);
            grid2.Rows[0].Height = 28;
            //
            grid2[0, 0] = new MyHeader1("√");
            grid2[0, 1] = new MyHeader1("판형");
            grid2[0, 2] = new MyHeader1("절수");
            grid2[0, 3] = new MyHeader1("크기(mm)");
            grid2[0, 4] = new MyHeader1("참  고");
            //
            grid2.Columns[0].Width = 22;
            grid2.Columns[1].Width = 34;
            grid2.Columns[2].Width = 34;
            grid2.Columns[3].Width = 66;
            grid2.Columns[4].Width = 66;
            //
            var DBConn = new MySqlConnection(Config.DB_con1);
            DBConn.Open();
            //
            string cQuery = "select * FROM "+DB_TableName+" where mast_id='"+ code +"' and pan_type = '46' order by julsu";
            
            var cmd = new MySqlCommand(cQuery, DBConn);
            var myRead = cmd.ExecuteReader();
            int m = 1;
            while (myRead.Read())
            {

                grid1.Rows.Insert(m);
                grid1.Rows[m].Height = 22;
                //
                grid1[m, 0] = new SourceGrid.Cells.CheckBox(null, false);
                grid1[m, 0].AddController(clickEvent1);
                grid1[m, 1] = new SourceGrid.Cells.Cell(myRead["pan_type"].ToString(), typeof(string));    //판형
                grid1[m, 1].View = cc.center_cell;
                grid1[m, 1].Editor = cc.disable_cell;
                grid1[m, 2] = new SourceGrid.Cells.Cell(myRead["julsu"].ToString(), typeof(string));       //절수
                grid1[m, 2].View = cc.center_cell;
                grid1[m, 2].Editor = cc.disable_cell;
                grid1[m, 3] = new SourceGrid.Cells.Cell(myRead["size"].ToString(), typeof(string));        //싸이즈
                grid1[m, 3].View = cc.center_cell;
                grid1[m, 3].Editor = cc.disable_cell;
                grid1[m, 4] = new SourceGrid.Cells.Cell(myRead["remark"].ToString(), typeof(string));      //참고
                grid1[m, 4].View = cc.left_cell;
                grid1[m, 4].Editor = cc.disable_cell;

                m++;
            }

            myRead.Close();

            cQuery = "select * FROM " + DB_TableName + " where mast_id='" + code + "' and pan_type = '국' order by julsu";

            cmd = new MySqlCommand(cQuery, DBConn);
            myRead = cmd.ExecuteReader();
            m = 1;
            while (myRead.Read())
            {
                grid2.Rows.Insert(m);
                grid2.Rows[m].Height = 22;
                //
                grid2[m, 0] = new SourceGrid.Cells.CheckBox(null, false);
                grid2[m, 0].AddController(clickEvent2);
                grid2[m, 1] = new SourceGrid.Cells.Cell(myRead["pan_type"].ToString(), typeof(string));    //판형
                grid2[m, 1].View = cc.center_cell;
                grid2[m, 1].Editor = cc.disable_cell;
                grid2[m, 2] = new SourceGrid.Cells.Cell(myRead["julsu"].ToString(), typeof(string));       //절수
                grid2[m, 2].View = cc.center_cell;
                grid2[m, 2].Editor = cc.disable_cell;
                grid2[m, 3] = new SourceGrid.Cells.Cell(myRead["size"].ToString(), typeof(string));        //싸이즈
                grid2[m, 3].View = cc.center_cell;
                grid2[m, 3].Editor = cc.disable_cell;
                grid2[m, 4] = new SourceGrid.Cells.Cell(myRead["remark"].ToString(), typeof(string));      //참고
                grid2[m, 4].View = cc.left_cell;
                grid2[m, 4].Editor = cc.disable_cell;
                m++;
            }

            myRead.Close();
            DBConn.Close();


        }

        private void clickEvent_Click1(object sender, EventArgs e)  //Grid1에서 클릭시
        {
            int cpos = grid1.Selection.ActivePosition.Column;
            int rpos = grid1.Selection.ActivePosition.Row;
            if (cpos.Equals(0))  //부공정 호출
            {
                for (int i = 1; i < grid1.RowsCount; i++)
                {
                    if (rpos != i)
                        grid1[i, 0].Value = false;
                }
                //
                for (int i = 1; i < grid2.RowsCount; i++)
                    grid2[i, 0].Value = false;

                grid2.SelectionMode = SourceGrid.GridSelectionMode.Cell;

            }
        }

        private void clickEvent_Click2(object sender, EventArgs e)  //Grid2에서 클릭시
        {
            int cpos = grid2.Selection.ActivePosition.Column;
            int rpos = grid2.Selection.ActivePosition.Row;
            if (cpos.Equals(0))  //부공정 호출
            {
                for (int i = 1; i < grid2.RowsCount; i++)
                {
                    if (rpos != i)
                        grid2[i, 0].Value = false;
                }
                //
                for (int i = 1; i < grid1.RowsCount; i++)
                    grid1[i, 0].Value = false;
                
                grid1.SelectionMode = SourceGrid.GridSelectionMode.Cell;
            }
        }

        private void button1_Click(object sender, EventArgs e)  //저장
        {

            for (int i = 1; i < grid1.RowsCount; i++)
            {
                if (grid1[i, 0].Value.Equals(true))
                {
                    m_size = grid1[i, 3].Value.ToString();
                    break;
                }
            }
            //
            if (m_size == "")
            {
                for (int i = 1; i < grid2.RowsCount; i++)
                {
                    if (grid2[i, 0].Value.Equals(true))
                    {
                        m_size = grid2[i, 3].Value.ToString();
                        break;
                    }
                }

            }
            if (m_size == "")
                MessageBox.Show("선택한 항목이 없습니다.");
            else
            {
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
        }
    }
}
