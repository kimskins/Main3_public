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
    public partial class Form_3071d : Form
    {
        string DB_TableName_gyeon = "C_detail_gyeon_model";
        int chk_num = 0;

        SourceGrid.Grid grid;
        int add_num = 0;
        int chk_rows = 0;
        public bool bConfirm_flag = false;

        int start_input_column_index = 0;
        public Form_3071d(int start_input_column_index, SourceGrid.Grid grid, int chk_num, int chk_rows)
        {
            InitializeComponent();
            this.start_input_column_index = start_input_column_index;
            this.grid = grid;
            this.chk_num = chk_num;
            this.chk_rows = chk_rows;
        }

        private void Form_309d_Load(object sender, EventArgs e)
        {
            Screen srn = Screen.PrimaryScreen;
            int Xb = this.Width;  //좌,우
            int Yb = this.Height; //상,하
            this.Location = new Point((srn.Bounds.Width - Xb) / 2, (srn.Bounds.Height - Yb) / 2);  //좌/우,위/아래

            explanation();
        }

        private void explanation()
        {
            if (rbGrade.Checked == true)
            {
                label7.Text = "* 체크된 구간에 대하여 등급 증가율을 \r\n  일괄적으로 적용시킵니다.\r\n\r\n* 가장 첫번째 등급에 입력된 값을 \r\n  기준으로 계산됩니다.\r\n\r\n* 감소를 넣으시려면 -부호를 붙여주세요";
                if (chk_num == 0)
                    bAutoInput.Enabled = false;
                else
                    bAutoInput.Enabled = true;
            }
            else
            {
                label7.Text = "* 체크된 구간을 기준으로 다른 구간에 \r\n  값을 적용시킵니다.\r\n\r\n* 기준 구간보다 아래 구간에만 적용되며 \r\n  체크는 반드시 하나만 해야합니다.\r\n\r\n* 감소를 넣으시려면 -부호를 붙여주세요";
                if (chk_num > 1 || chk_num == 0)
                    bAutoInput.Enabled = false;
                else
                    bAutoInput.Enabled = true;
            }
            label7.Refresh();
        }

        private void bAutoInput_Click(object sender, EventArgs e)
        {
            try
            {
                add_num = Convert.ToInt32(tbAdd.Text.ToString());

                if (rbGrade.Checked == true)
                    Grade_auto_input();
                else
                    Gugan_auto_input();

                bConfirm_flag = true;
                this.Close();
            }
            catch
            {
                MessageBox.Show("정수만 입력해주세요");
                return;
            }
        }
        private void Grade_auto_input()
        {
            ksgcontrol kc = new ksgcontrol();
            kc.ControlInit(Config.DB_con1, "", "", "");
            string cQuery = "";
            int input_column_count = grid.ColumnsCount - (start_input_column_index + 1);  //start_input_column_index값은 index이기 때문에 실제로는 9번째 값이다.

            string now_colum = "";
            int now_column_index = start_input_column_index + 1;

            string temp = "";
            string row_id = "";

            for (int i = 3; i < grid.RowsCount; i++)
            {
                if (grid[i, 1].Value.Equals(true))
                {
                    for (int y = start_input_column_index + 1; y < grid.ColumnsCount; y++)
                    {
                        now_colum = grid[2, y].Value.ToString();
                        row_id = grid[i, 0].Value.ToString();
                        temp = (Convert.ToInt32(grid[i, y - 1].Value.ToString()) + add_num).ToString();
                        grid[i, y] = new SourceGrid.Cells.Cell(temp, typeof(string));
                        cQuery = "update " + DB_TableName_gyeon + " set " + now_colum + "= '" + temp + "' where row_id = '" + row_id + "'";
                        kc.DataUpdate(cQuery);
                    }
                }
            }

        }

        private void Gugan_auto_input()
        {
            ksgcontrol kc = new ksgcontrol();
            kc.ControlInit(Config.DB_con1, "", "", "");
            string cQuery = "";
            int input_column_count = grid.ColumnsCount - (start_input_column_index + 1);  //start_input_column_index값은 index이기 때문에 실제로는 9번째 값이다.

            string now_colum = "";

            string temp = "";
            string row_id = "";

            for (int i = chk_rows + 1; i < grid.RowsCount; i++)
            {
                for (int y = start_input_column_index; y < grid.ColumnsCount; y++)
                {
                    now_colum = grid[2, y].Value.ToString();
                    row_id = grid[i, 0].Value.ToString();
                    temp = (Convert.ToInt32(grid[i - 1, y].Value.ToString()) + add_num).ToString();
                    grid[i, y] = new SourceGrid.Cells.Cell(temp, typeof(string));
                    cQuery = "update " + DB_TableName_gyeon + " set " + now_colum + "= '" + temp + "' where row_id = '" + row_id + "'";
                    kc.DataUpdate(cQuery);
                }
            }

        }

        private void rbGrade_CheckedChanged(object sender, EventArgs e)
        {
            explanation();
        }

        private void tbAdd_Click(object sender, EventArgs e)
        {
            tbAdd.SelectAll();
        }

    }
}
