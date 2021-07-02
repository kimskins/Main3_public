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
    public partial class Form_501e : Form
    {
        //mall인쇄방법 선택을 위한 멀티콤보박스 용도의 화면

        private DataTable dt;
        public bool selected;
        public string selected_string;
        int Xb;
        int Yb;

        public Form_501e(DataTable dt,System.Windows.Forms.ButtonBase ctrl)
        {
            InitializeComponent();
            this.dt = dt;
            this.selected = false;
            this.selected_string = "";
            Xb = ctrl.PointToScreen(Location).X - this.Width + ctrl.Width;  //좌,우
            Yb = ctrl.PointToScreen(Location).Y + ctrl.Height + 6;  //위,아래            
        }

        private void Form_501e_Load(object sender, EventArgs e)
        {
            make_grid1();
            this.Location = new Point(Xb, Yb);
        }

        private void make_grid1()
        {
            cell_d cc = new cell_d();
            grid1.Rows.Clear();
            grid1.BorderStyle = BorderStyle.FixedSingle;
            grid1.SelectionMode = SourceGrid.GridSelectionMode.Cell;
            grid1.ColumnsCount = 16;
            grid1.FixedRows = 1;
            grid1.Rows.Insert(0);
            grid1.Rows[0].Height = 24;
            grid1.AutoScroll = false;        

            //           

            grid1[0, 0] = new MyHeader1("√");
            grid1[0, 1] = new MyHeader1("No");
            grid1[0, 2] = new MyHeader1("코드");
            grid1[0, 3] = new MyHeader1("항목");        

            grid1.Columns[0].Width = 22;
            grid1.Columns[1].Width = 30;            
            grid1.Columns[2].Width = 50;
            grid1.Columns[3].Width = 80;

            int m = 1;

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                grid1.Rows.Insert(m);
                grid1.Rows[m].Height = 22;

                grid1[m, 0] = new SourceGrid.Cells.CheckBox(null, false);

                grid1[m, 1] = new SourceGrid.Cells.Cell(m.ToString(), typeof(string));
                grid1[m, 1].View = cc.center_cell;
                grid1[m, 1].Editor = cc.disable_cell;

                grid1[m, 2] = new SourceGrid.Cells.Cell(dt.Rows[i]["code1"].ToString(), typeof(string));
                grid1[m, 2].View = cc.center_cell;
                grid1[m, 2].Editor = cc.disable_cell;

                grid1[m, 3] = new SourceGrid.Cells.Cell(dt.Rows[i]["hang"].ToString(), typeof(string));
                grid1[m, 2].View = cc.center_cell;
                grid1[m, 2].Editor = cc.disable_cell;

                m++;
            }           

        }

        private void button1_Click(object sender, EventArgs e)
        {
            selected = true;
            for(int i = 1; i < grid1.RowsCount; i++)
            {
                if (grid1[i, 0].Value.ToString() == "True")
                    selected_string += grid1[i, 2].ToString();
            }            
            this.Close();
        }
    }
}
