using MySql.Data.MySqlClient;
using System;
using System.Data;
using System.Drawing;
using System.IO;
using System.Net;
using System.Text;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;


namespace Dukyou3
{
    public partial class Form_4014 : Form
    {
        DataTable auto1 = new DataTable();
        DataTable auto2 = new DataTable();
        DataTable corp_jumoon = new DataTable();
        DataTable month_pan = new DataTable();
        DataTable month_gyun = new DataTable();
        DataTable month_joo = new DataTable();
        DataTable best_com = new DataTable();
        DataTable login_log = new DataTable();
        sync sy = new sync();
        ksgcontrol ks = new ksgcontrol();
        string temp = "";
        string[,] pan_arr;
        string int_id = "";
        string chk = "";
        public Form_4014()
        {
            InitializeComponent();
            this.cbYear.Text = "2015년";
            
            sy.dt(Config.DB_con1, auto1, "select distinct int_id,super_id from C_auto1");
            sy.dt(Config.DB_con1, auto2, "select distinct int_id,super_id from C_auto2");
            sy.dt(Config.DB_con1, corp_jumoon, "select client_id from C_corp_jumoon");

            datatable_make(month_pan, "corp");
            datatable_make(month_gyun, "auto1");
            datatable_make(month_joo, "auto2");
            rbJop.Checked = true;
            this.grid1.Controls.Remove(grid2);
            grid1_view();
            grid2_view();
            chk = "gyun";
        }
        private void grid1_view()
        {
            cell_d cc = new cell_d();
            grid1.Rows.Clear();
            grid1.BorderStyle = BorderStyle.FixedSingle;
            grid1.SelectionMode = SourceGrid.GridSelectionMode.Row;
            grid1.ColumnsCount = 7;
            grid1.FixedRows = 1;
            grid1.Rows.Insert(0);
            grid1.Rows[0].Height = 24;


            grid1[0, 0] = new MyHeader1("row_id");
            grid1.Columns[0].Visible = false;
            grid1[0, 1] = new MyHeader1("√");
            grid1.Columns[1].Visible = false;

            grid1[0, 2] = new MyHeader1("no");
            grid1.Columns[2].Visible = true;

            grid1[0, 3] = new MyHeader1("회사");
            grid1[0, 4] = new MyHeader1("총 판");
            grid1[0, 5] = new MyHeader1("총 견적");
            grid1[0, 6] = new MyHeader1("총 주문");

            grid1.Columns[2].Width = 48;
            grid1.Columns[3].Width = 150;
            grid1.Columns[4].Width = 50;
            grid1.Columns[5].Width = 50;
            grid1.Columns[6].Width = 56;


            MySqlConnection DBConn;
            DBConn = new MySqlConnection(Config.DB_con1);
            DBConn.Open();
            string Query = "select * from C_client";
            var cmd = new MySqlCommand(Query, DBConn);
            var myRead = cmd.ExecuteReader();

            int m = 1;
            DataRow[] dr;

            DataRow row = null;
            best_com.Columns.Add(new DataColumn("name", typeof(string)));
            best_com.Columns.Add(new DataColumn("gyun", typeof(int)));
            best_com.Columns.Add(new DataColumn("joo", typeof(int)));
            best_com.Columns.Add(new DataColumn("pan", typeof(int)));

         
            while (myRead.Read())
            {
                grid1.Rows.Insert(m);
                grid1.Rows[m].Height = 20;
                
                grid1[m, 0] = new SourceGrid.Cells.Cell(myRead["row_id"].ToString(), typeof(string));
                grid1[m, 0].View = cc.center_cell;
                grid1[m, 1] = new SourceGrid.Cells.CheckBox(null, false);
                grid1[m, 2] = new SourceGrid.Cells.Cell((m).ToString(), typeof(string));
                grid1[m, 2].Editor = cc.disable_cell;
                grid1[m, 2].View = cc.center_cell;
                grid1[m, 3] = new SourceGrid.Cells.Cell(myRead["name"].ToString(), typeof(string));
                grid1[m, 3].Editor = cc.disable_cell;

                dr = corp_jumoon.Select("client_id = " + grid1[m, 0].ToString());
                grid1[m, 4] = new SourceGrid.Cells.Cell(dr.Length, typeof(string));
                grid1[m, 4].Editor = cc.disable_cell;
                grid1[m, 4].View = cc.int_cell;

                dr = auto1.Select("super_id = " + grid1[m, 0].ToString());
                grid1[m, 5] = new SourceGrid.Cells.Cell(dr.Length, typeof(string));
                grid1[m, 5].Editor = cc.disable_cell;
                grid1[m, 5].View = cc.int_cell;

                dr = auto2.Select("super_id = " + grid1[m, 0].ToString());
                grid1[m, 6] = new SourceGrid.Cells.Cell(dr.Length, typeof(string));
                grid1[m, 6].Editor = cc.disable_cell;
                grid1[m, 6].View = cc.int_cell;

                row = best_com.NewRow();  //행추가
                
                row["name"] = grid1[m, 3].ToString();
                row["pan"] = Convert.ToInt32(grid1[m, 4].ToString());
                row["gyun"] = Convert.ToInt32(grid1[m, 5].ToString());
                row["joo"] = Convert.ToInt32(grid1[m, 6].ToString());
                best_com.Rows.Add(row);

                m++;
            }
            myRead.Close();
            DBConn.Close();    
        }
        
        private void chart_init(string rb_check, DataTable dt)
        {
            string data = "";
            string row_name = "";
            string date_name = "";
            cbYear.Enabled = true;
            chart1.Series.Clear();
            Series ser;

            this.chart1.ChartAreas[0].AxisY.Interval = 1;   //그래프 증가(1씩 증가)
            this.chart1.ChartAreas[0].AxisX.Interval = 1;
            
            int max_y = 2;
            DataRow[] dr;
            if (temp == "")
                temp = grid1[1, 0].ToString();

            this.chart1.ChartAreas[0].AxisX.Maximum = 12;
            if (rb_check == "M_pan")
            {
                ser = new Series("판");
                chart1.Series.Add(ser);
                ser.Color = Color.Blue;   // 막대 색을 Blue로 지정
                row_name = "client_id";
                date_name = "receive_date";
            }

            else if (rb_check == "M_gyun")
            {
                ser = new Series("견적");
                chart1.Series.Add(ser);
                ser.Color = Color.Green;   // 막대 색을 Green로 지정
                row_name = "super_id";
                date_name = "p_day";
                this.chart1.ChartAreas[0].AxisY.Maximum = max_y + 2;
            }

            else
            {
                ser = new Series("주문");
                chart1.Series.Add(ser);
                ser.Color = Color.Orange;   // 막대 색을 Orange로 지정
                row_name = "super_id";
                date_name = "p_day";
            }

            for (int z = 1; z < 13; z++)
            {
                string day = z.ToString();
                if (z.ToString().Length == 1)
                    day = "0" + z;
                string year = cbYear.Text.Substring(0, 4);
                dr = dt.Select(row_name + " = " + temp + " and " + date_name + " like '%" + year + "-" + day + "%'");
                //    pan = dr[0]["receive_date"].ToString();
                data = dr.Length.ToString();
                ser.Points.AddXY(z + "월", data);
                if (dr.Length >= max_y)
                    max_y = dr.Length;
            }
            this.chart1.ChartAreas[0].AxisY.Maximum = max_y + 2;
            if(max_y >40)
                this.chart1.ChartAreas[0].AxisY.Interval = 5; 
        }

        private void chart_()
        {

            Series Series1 = new Series("가족");  // 우측 상단에 가족 출력
            Series Series2 = new Series("합계");  // 우측 상단에 합계 출력


            int cnt = 0, fam_cnt, tot_cnt;
            string com_cd;

            //while (Reader.Read())
            //{
            //com_cd = Reader["com_cd"].ToString();
            //fam_cnt = (int)Reader["fam_cnt"];
            //tot_cnt = (int)Reader["tot_cnt"];
            fam_cnt = 0;
            tot_cnt = 0;
            com_cd = "0";



            Series1.Points.AddXY((cnt + 1), fam_cnt.ToString());   // AddXY(x, y) 두개의 파라미터가 들어갑니다.
            Series2.Points.AddXY((cnt + 1), tot_cnt.ToString());    // 막대 그래프를 그립니다.
            Series1.Points[cnt].AxisLabel = com_cd;                   // y 축의 01 ~ 31을 출력합니다.
            cnt += 1;



            this.chart1.ChartAreas[0].AxisX.Minimum = 0;         // x축 최소값을 0으로 합니다.
            //this.chart1.ChartAreas[0].AxisX.Maximum = 31;     // x축 최대값을 31로 합니다.
            this.chart1.ChartAreas[0].AxisX.Interval = 1;          // x증가값을 1로 지정합니다. (5로 설정하면 5씩 증가함)



            this.chart1.ChartAreas[0].AxisY.Minimum = 0;         // y축 최소값을 0으로 합니다.
            //this.chart1.ChartAreas[0].AxisY.Maximum = 5;      <-- y축 최대값을 31로 합니다.
            this.chart1.ChartAreas[0].AxisY.Interval = 1;            // y 증가값을 1로 지정합니다. (5로 설정하면 5씩 증가함)


            Series1.Color = Color.Red;   // 막대 색을 Red로 지정
            Series1.MarkerSize = 15;      // 막대 사이즈는 15
            //Series1.MarkerStyle = System.Windows.Forms.DataVisualization.Charting.MarkerStyle.Diamond;  <-- 막대 꼭대기 다이아
            Series1.IsValueShownAsLabel = true;      // 막대 꼭대기 숫자표시
            Series1.LabelForeColor = Color.Red;        //막대 꼭대기 숫자 컬러를 Red로 지정
            Series1.ChartType = SeriesChartType.Column;  // Chart 타입을 막대그래프로 사용할거라면 Colmn으로 지정


            Series2.Color = Color.Green;
            Series2.MarkerColor = Color.Green;
            Series2.MarkerSize = 10;
            //Series2.MarkerStyle = System.Windows.Forms.DataVisualization.Charting.MarkerStyle.Circle;  <-- 막대 꼭대기 원
            Series2.IsValueShownAsLabel = true;
            Series2.LabelForeColor = Color.Green;

            Series2.ChartType = SeriesChartType.Column;


            chart1.Series.Clear();             // 매번 호출 될때 마다 chart1.Series를 초기화 합니다. 
            chart1.Series.Add(Series1);      //  Series1 내용을 chart1.Series 에 추가합니다.
            chart1.Series.Add(Series2);     //  Series2 내용을 chart1.Series 에 추가합니다.
            //chart1.ChartAreas[0].BackColor = Color.LightCyan;

            //Axis ax = chart1.ChartAreas[0].AxisX;
            //ax.MajorGrid.LineColor = Color.LightGray;
            //Axis ay = chart1.ChartAreas[0].AxisY;
            //ay.MajorGrid.LineColor = Color.LightGray;
        }

        private void datatable_make(DataTable dt, string table)
        {
            MySqlConnection DBConn;
            DBConn = new MySqlConnection(Config.DB_con1);
            DBConn.Open();

            if (table == "corp")
            {
                DataRow row = null;
                string id_column = "client_id";
                string date_column = "receive_date";
                dt.Columns.Add(new DataColumn(id_column, typeof(string)));
                dt.Columns.Add(new DataColumn(date_column, typeof(string)));

                string Query = "select " + id_column + "," + date_column + " from C_corp_jumoon";
                var cmd = new MySqlCommand(Query, DBConn);
                var myRead = cmd.ExecuteReader();

                while (myRead.Read())
                {
                    row = dt.NewRow();  //행추가
                    row[id_column] = myRead[id_column].ToString();
                    row[date_column] = myRead[date_column].ToString();
                    dt.Rows.Add(row);
                }
            }
            else if (table == "auto1" || table == "auto2")
            {
                DataRow row = null;
                string id_column = "super_id";
                string date_column = "p_day";
                string intid_column = "int_id";

                dt.Columns.Add(new DataColumn(id_column, typeof(string)));
                dt.Columns.Add(new DataColumn(date_column, typeof(string)));
                dt.Columns.Add(new DataColumn(intid_column, typeof(string)));

                string table_name = "C_auto1";
                if (table == "auto2")
                    table_name = "C_auto2";

                string Query = "select distinct int_id, super_id, p_day from " + table_name;
                var cmd = new MySqlCommand(Query, DBConn);
                var myRead = cmd.ExecuteReader();

                while (myRead.Read())
                {
                    row = dt.NewRow();  //행추가
                    row[id_column] = myRead[id_column].ToString();
                    row[date_column] = myRead[date_column].ToString();
                    row[intid_column] = myRead[intid_column].ToString();
                    dt.Rows.Add(row);
                }
                myRead.Close();
            }
            DBConn.Close();
        }

        private void grid1_MouseClick(object sender, MouseEventArgs e)
        {
            if (grid1.Selection.ActivePosition.Row == -1)
                return;
            temp = grid1[grid1.Selection.ActivePosition.Row, 0].ToString();
            if (chk == "pan")
                chart_init("M_pan",month_pan);
            if (chk == "gyun")
                chart_init("M_gyun", month_gyun);
            if (chk == "joo")
                chart_init("M_joo",month_joo);
        }

        private void cbYear_SelectedValueChanged(object sender, EventArgs e)
        {
            if (chk == "pan")
                chart_init("M_pan",month_pan);
            if (chk == "gyun")
                chart_init("M_gyun", month_gyun);
            if (chk == "joo")
                chart_init("M_joo",month_joo);
        }

        private void best_company(string chart_check)
        {
            chart1.Series.Clear();
            Series ser;
            if (chart_check == "pan")
            {
                ser = new Series("판");
                ser.Color = Color.Blue;
            }
            else if (chart_check == "gyun")
            {
                ser = new Series("견적");
                ser.Color = Color.Green;
            }
            else
            {
                ser = new Series("주문");
                ser.Color = Color.Orange;
            }
            chart1.Series.Add(ser);
            chart1.ChartAreas[0].AxisX.Title = "";              // X 축 이름

            this.chart1.ChartAreas[0].AxisX.Maximum = 11;
            int max_y = 2;
            best_com.DefaultView.Sort = chart_check+" desc";
            DataRow[] dr = best_com.Select();
            for (int z = 0; z < 11; z++)
            {
                    ser.Points.AddXY(dr[z]["name"], dr[z][chart_check]);
                if (Convert.ToInt32(dr[z][chart_check]) > max_y)
                    max_y = Convert.ToInt32(dr[z][chart_check]);
            }
            
            this.chart1.ChartAreas[0].AxisY.Interval = 1;   //그래프 증가(1씩 증가)
            this.chart1.ChartAreas[0].AxisX.Interval = 1;
            if (max_y > 40)
                this.chart1.ChartAreas[0].AxisY.Interval = 5;
            this.chart1.ChartAreas[0].AxisY.Maximum = max_y + 2;

        }
        FileControl FC = new FileControl();
        private void button1_Click(object sender, EventArgs e)
        {
        }

        private void bGyoun_Click(object sender, EventArgs e)
        {
            chart1.ChartAreas[0].AxisX.Title = "";              // X 축 이름
            best_company("gyun");
            cbYear.Enabled = false;
            this.bMjoo.UseVisualStyleBackColor = true;
            this.bMgyoun.UseVisualStyleBackColor = true;
            this.bMpan.UseVisualStyleBackColor = true;
        }

        private void bJoo_Click(object sender, EventArgs e)
        {
            best_company("joo");
            cbYear.Enabled = false;
            chart1.ChartAreas[0].AxisX.Title = "";              // X 축 이름
            this.bMjoo.UseVisualStyleBackColor = true;
            this.bMgyoun.UseVisualStyleBackColor = true;
            this.bMpan.UseVisualStyleBackColor = true;
        }

        private void bPan_Click(object sender, EventArgs e)
        {
            best_company("pan");
            cbYear.Enabled = false;
            chart1.ChartAreas[0].AxisX.Title = "";              // X 축 이름
            this.bMjoo.UseVisualStyleBackColor = true;
            this.bMgyoun.UseVisualStyleBackColor = true;
            this.bMpan.UseVisualStyleBackColor = true;
        }

        private void bMgyoun_Click(object sender, EventArgs e)
        {
            chart_init("M_gyun", month_gyun);
            chk = "gyun";
            chart1.ChartAreas[0].AxisX.Title = "월별 견적";              // X 축 이름
            this.bMgyoun.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.bMjoo.UseVisualStyleBackColor = true;
            this.bMpan.UseVisualStyleBackColor = true;
        }

        private void bMjoo_Click(object sender, EventArgs e)
        {
            chart_init("M_joo", month_joo);
            chk = "joo";
            chart1.ChartAreas[0].AxisX.Title = "월별 주문";              // X 축 이름
            this.bMjoo.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.bMgyoun.UseVisualStyleBackColor = true;
            this.bMpan.UseVisualStyleBackColor = true;
        }

        private void bMpan_Click(object sender, EventArgs e)
        {
            chart_init("M_pan", month_pan);
            chk = "pan";
            chart1.ChartAreas[0].AxisX.Title = "월별 판";              // X 축 이름
            this.bMpan.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.bMjoo.UseVisualStyleBackColor = true;
            this.bMgyoun.UseVisualStyleBackColor = true;
        }

        private void rbJop_CheckedChanged(object sender, EventArgs e)
        {
            if (rbJop.Checked == true)
            {
                grid1.Visible = true;
                grid2.Visible = false;
                grid3.Visible = false;
                this.ClientSize = new System.Drawing.Size(1427, 757);
                this.groupBox1.Size = new System.Drawing.Size(1295, 58);

                label2.Visible = true;
                label5.Visible = true;
                bPan.Visible = true;
                bJoo.Visible = true;
                bGyoun.Visible = true;
                bMpan.Visible = true;
                bMjoo.Visible = true;
                bMgyoun.Visible = true;
                chart1.Visible = true;
                cbYear.Visible = true;
            }
            else
            {
                grid2.Visible = true;
                grid1.Visible = false;
                grid3.Visible = true;
                label2.Visible = false;
                label5.Visible = false;
                bPan.Visible = false;
                bJoo.Visible = false;
                bGyoun.Visible = false;
                bMpan.Visible = false;
                bMjoo.Visible = false;
                bMgyoun.Visible = false;
                chart1.Visible = false;
                cbYear.Visible = false;
                this.ClientSize = new System.Drawing.Size(1000, 757);
                this.groupBox1.Size = new System.Drawing.Size(975, 58);
                grid3_view(int_id);
            }
        }

        private void KJH_Load(object sender, EventArgs e)
        {
            Screen srn = Screen.PrimaryScreen;
            int Xb = this.Width;  //좌,우
            this.Location = new Point((srn.Bounds.Width - Xb) / 2, 1);  //좌/우,위/아래
            chart_init("M_pan", month_pan);
            chk = "pan";
            chart1.ChartAreas[0].AxisX.Title = "월별 판";              // X 축 이름
            int_id = grid2[1, 0].ToString();

            grid1.Selection.EnableMultiSelection = false;
            grid2.Selection.EnableMultiSelection = false;
            
        }

        private void grid2_view()
        {
            cell_d cc = new cell_d();
            grid2.Rows.Clear();
            grid2.BorderStyle = BorderStyle.FixedSingle;
            grid2.SelectionMode = SourceGrid.GridSelectionMode.Row;
            grid2.ColumnsCount = 6;
            grid2.FixedRows = 1;
            grid2.Rows.Insert(0);
            grid2.Rows[0].Height = 24;


            grid2[0, 0] = new MyHeader1("row_id");
            grid2.Columns[0].Visible = false;
            grid2[0, 1] = new MyHeader1("√");
            grid2.Columns[1].Visible = false;

            grid2[0, 2] = new MyHeader1("no");
            grid2.Columns[2].Visible = true;

            grid2[0, 3] = new MyHeader1("회사");
            grid2[0, 4] = new MyHeader1("접속 횟수");
            grid2[0, 5] = new MyHeader1("최근 접속일");

            grid2.Columns[2].Width = 30;
            grid2.Columns[3].Width = 120;
            grid2.Columns[4].Width = 50;
            grid2.Columns[5].Width = 100;


            MySqlConnection DBConn;
            DBConn = new MySqlConnection(Config.DB_con1);
            DBConn.Open();
            string Query = "select * from C_client";
            var cmd = new MySqlCommand(Query, DBConn);
            var myRead = cmd.ExecuteReader();

            int m = 1;
            DataRow[] dr;
            
            while (myRead.Read())
            {
                grid2.Rows.Insert(m);
                grid2.Rows[m].Height = 20;
                string com_id = myRead["row_id"].ToString();
                grid2[m, 0] = new SourceGrid.Cells.Cell(com_id, typeof(string));
                grid2[m, 0].View = cc.center_cell;
                grid2[m, 1] = new SourceGrid.Cells.CheckBox(null, false);
                grid2[m, 2] = new SourceGrid.Cells.Cell((m).ToString(), typeof(string));
                grid2[m, 2].Editor = cc.disable_cell;
                grid2[m, 2].View = cc.center_cell;
                grid2[m, 3] = new SourceGrid.Cells.Cell(myRead["name"].ToString(), typeof(string));
                grid2[m, 3].Editor = cc.disable_cell;
                sy.dt(Config.DB_con1, login_log, "select max(con_time) as time, count(com_id) as count from C_login_log where com_id = " + com_id);
                dr = login_log.Select();
                DateTime time;
                if(dr[0]["count"].ToString() == "0")
                {
                    grid2[m, 4] = new SourceGrid.Cells.Cell("0", typeof(string));
                    grid2[m, 5] = new SourceGrid.Cells.Cell("없음", typeof(string));
                }
                else
                {
                        time = Convert.ToDateTime(dr[0]["time"]);
                    grid2[m, 4] = new SourceGrid.Cells.Cell(dr[0]["count"], typeof(string));
                    grid2[m, 5] = new SourceGrid.Cells.Cell(time.ToString("yyyy-MM-dd"), typeof(string));
                }
                grid2[m, 4].Editor = cc.disable_cell;
                grid2[m, 4].View = cc.int_cell;
                grid2[m, 5].Editor = cc.disable_cell;

                m++;
            }
            myRead.Close();
            DBConn.Close();
        }

        private void grid2_MouseClick(object sender, MouseEventArgs e)
        {
            if (grid2.Selection.ActivePosition.Row == -1)
                return;

            int_id = grid2[grid2.Selection.ActivePosition.Row, 0].ToString();
            grid3_view(int_id);
            grid3.Selection.EnableMultiSelection = false;
        }
        private void grid3_view(string int_id)
        {
            
            DataRow[] dr;

            cell_d cc = new cell_d();
            grid3.Rows.Clear();
            grid3.BorderStyle = BorderStyle.FixedSingle;
            grid3.SelectionMode = SourceGrid.GridSelectionMode.Row;
            grid3.ColumnsCount = 8;
            grid3.FixedRows = 1;
            grid3.Rows.Insert(0);
            grid3.Rows[0].Height = 24;


            grid3[0, 0] = new MyHeader1("row_id");
            grid3.Columns[0].Visible = false;
            grid3[0, 1] = new MyHeader1("√");
            grid3.Columns[1].Visible = false;

            grid3[0, 2] = new MyHeader1("no");
            grid3.Columns[2].Visible = true;

            grid3[0, 3] = new MyHeader1("이름");
            grid3[0, 4] = new MyHeader1("직급");
            grid3[0, 5] = new MyHeader1("접속횟수");
            grid3[0, 6] = new MyHeader1("접속여부");
            grid3[0, 7] = new MyHeader1("최근 접속 시간");

            grid3.Columns[2].Width = 30;
            grid3.Columns[3].Width = 80;
            grid3.Columns[4].Width = 70;
            grid3.Columns[5].Width = 65;
            grid3.Columns[6].Width = 65;
            grid3.Columns[7].Width = 180;

            MySqlConnection DBConn;
            DBConn = new MySqlConnection(Config.DB_con1);
            DBConn.Open();
            string Query = "select * from C_member where int_id = " + int_id;
            var cmd = new MySqlCommand(Query, DBConn);
            var myRead = cmd.ExecuteReader();


            int m = 1;
            while (myRead.Read())
            {
                grid3.Rows.Insert(m);
                grid3.Rows[m].Height = 20;
                string mem_id = myRead["row_id"].ToString();
                grid3[m, 0] = new SourceGrid.Cells.Cell(mem_id, typeof(string));
                grid3[m, 0].View = cc.center_cell;
                grid3[m, 1] = new SourceGrid.Cells.CheckBox(null, false);
                grid3[m, 2] = new SourceGrid.Cells.Cell((m).ToString(), typeof(string));
                grid3[m, 2].Editor = cc.disable_cell;
                grid3[m, 2].View = cc.center_cell;

                grid3[m, 3] = new SourceGrid.Cells.Cell(myRead["name"].ToString(), typeof(string));
                grid3[m, 3].Editor = cc.disable_cell;

                grid3[m, 4] = new SourceGrid.Cells.Cell(myRead["position"].ToString(), typeof(string));
                grid3[m, 4].Editor = cc.disable_cell;
                grid3[m, 4].View = cc.int_cell;
                int jcount = 0;
                string con = "X";
                int max_row_id = 0;
                string con_time = "";
                if (mem_id != "")
                {
                    sy.dt(Config.DB_con1, login_log, "select * from C_login_log where mem_id = " + mem_id);
                    dr = login_log.Select();
                    if (dr.Length != 0)
                    {
                        max_row_id = Convert.ToInt32(login_log.Compute("max(row_id)", string.Empty));   //가장큰 row_id 최근에 로그인된 로그 찾기 위해서
                        jcount = dr.Length;
                    }
                    string row_id = max_row_id.ToString();
                    dr = login_log.Select("row_id = " + max_row_id);

                    if (dr.Length != 0)
                    {
                        if (dr[0]["discon_time"].ToString() == "")
                            con = "O";

                       con_time = dr[0]["con_time"].ToString();
                    }
                }

                grid3[m, 5] = new SourceGrid.Cells.Cell(jcount.ToString(), typeof(string));
                grid3[m, 5].Editor = cc.disable_cell;
                grid3[m, 5].View = cc.int_cell;
                grid3[m, 6] = new SourceGrid.Cells.Cell(con, typeof(string));
                grid3[m, 6].Editor = cc.disable_cell;
                grid3[m, 6].View = cc.center_cell;
                grid3[m, 7] = new SourceGrid.Cells.Cell(con_time, typeof(string));
                grid3[m, 7].Editor = cc.disable_cell;
                grid3[m, 7].View = cc.int_cell;
                m++;
            }
            myRead.Close();
            DBConn.Close();
        }

        private void rbCust_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void grid2_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            int row = grid2.Selection.ActivePosition.Row;
            if (row == -1)
                return;
            string row_id = grid2[row, 0].ToString();

            Form_client_info fm = new Form_client_info(row_id);
            fm.ShowDialog();
        }

        private void grid1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            int row = grid1.Selection.ActivePosition.Row;
            if (row == -1)
                return;
            string row_id = grid1[row, 0].ToString();

            Form_client_info fm = new Form_client_info(row_id);
            fm.ShowDialog();
        }

    }
} 




