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
    public partial class Form_3072d : Form
    {
        string DB_TableName_gyeon = "C_detail_gyeon_model";
        int chk_num = 0;
        int[] leader_num;
        int gubun_count = 0;
        SourceGrid.Grid grid;

        decimal design = 0;
        decimal paper = 0;
        decimal ctp = 0;
        decimal film = 0;
        decimal mastapan = 0;
        decimal off_set = 0;
        decimal uv = 0;
        decimal yunjun = 0;
        decimal masta = 0;
        decimal digital = 0;
        decimal indigo = 0;
        decimal gong = 0;
        decimal carry = 0;

        public bool bConfirm_flag = false;
        public Form_3072d(int chk_num, int[] leader_num, int gubun_count, SourceGrid.Grid grid)
        {
            InitializeComponent();
            this.chk_num = chk_num;
            this.leader_num = leader_num;
            this.grid = grid;
            this.gubun_count = gubun_count;
            explanation();

            tbDesign.GotFocus += tbDesign_GotFocus;
            tbPaper.GotFocus += tbPaper_GotFocus;
            tbCTP.GotFocus += tbCTP_GotFocus;
            tbFilm.GotFocus += tbFilm_GotFocus;
            tbMastapan.GotFocus += tbMastapan_GotFocus;
            tbOff_Set.GotFocus += tbOff_Set_GotFocus;
            tbUv.GotFocus += tbUv_GotFocus;
            tbYunjun.GotFocus += tbYunjun_GotFocus;
            tbMasta.GotFocus += tbMasta_GotFocus;
            tbDigital.GotFocus += tbDigital_GotFocus;
            tbIndigo.GotFocus += tbIndigo_GotFocus;
            tbGong.GotFocus += tbGong_GotFocus;
            tbCarry.GotFocus += tbCarry_GotFocus;
        }
        private void tbDesign_GotFocus(object sender, EventArgs e)
        {
            tbDesign.SelectAll();
        }
        private void tbPaper_GotFocus(object sender, EventArgs e)
        {
            tbPaper.SelectAll();
        }
        private void tbCTP_GotFocus(object sender, EventArgs e)
        {
            tbCTP.SelectAll();
        }
        private void tbFilm_GotFocus(object sender, EventArgs e)
        {
            tbCTP.SelectAll();
        }
        private void tbMastapan_GotFocus(object sender, EventArgs e)
        {
            tbCTP.SelectAll();
        }
        private void tbOff_Set_GotFocus(object sender, EventArgs e)
        {
            tbOff_Set.SelectAll();
        }
        private void tbUv_GotFocus(object sender, EventArgs e)
        {
            tbOff_Set.SelectAll();
        }
        private void tbYunjun_GotFocus(object sender, EventArgs e)
        {
            tbOff_Set.SelectAll();
        }
        private void tbMasta_GotFocus(object sender, EventArgs e)
        {
            tbOff_Set.SelectAll();
        }
        private void tbDigital_GotFocus(object sender, EventArgs e)
        {
            tbOff_Set.SelectAll();
        }
        private void tbIndigo_GotFocus(object sender, EventArgs e)
        {
            tbOff_Set.SelectAll();
        }
        private void tbGong_GotFocus(object sender, EventArgs e)
        {
            tbGong.SelectAll();
        }
        private void tbCarry_GotFocus(object sender, EventArgs e)
        {
            tbCarry.SelectAll();
        }

        private void Form_3092d_Load(object sender, EventArgs e)
        {
            Screen srn = Screen.PrimaryScreen;
            int Xb = this.Width;  //좌,우
            int Yb = this.Height; //상,하
            this.Location = new Point((srn.Bounds.Width - Xb) / 2, (srn.Bounds.Height - Yb) / 2);  //좌/우,위/아래
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
                design = Convert.ToDecimal(tbDesign.Text.ToString());
                paper = Convert.ToDecimal(tbPaper.Text.ToString());
                ctp = Convert.ToDecimal(tbCTP.Text.ToString());
                film = Convert.ToDecimal(tbFilm.Text.ToString());
                mastapan = Convert.ToDecimal(tbMastapan.Text.ToString());
                off_set = Convert.ToDecimal(tbOff_Set.Text.ToString());
                uv = Convert.ToDecimal(tbUv.Text.ToString());
                yunjun = Convert.ToDecimal(tbYunjun.Text.ToString());
                masta = Convert.ToDecimal(tbMasta.Text.ToString());
                digital = Convert.ToDecimal(tbDigital.Text.ToString());
                indigo = Convert.ToDecimal(tbIndigo.Text.ToString());
                gong = Convert.ToDecimal(tbGong.Text.ToString());
                carry = Convert.ToDecimal(tbCarry.Text.ToString());

                if (rbGrade.Checked == true)
                    Grade_auto_input();
                else
                    Gugan_auto_input();

                bConfirm_flag = true;
                this.Close();
            }
            catch
            {
                MessageBox.Show("숫자만 입력해 주세요");
                return;
            }
        }

        private void Grade_auto_input()
        {
            ksgcontrol kc = new ksgcontrol();
            kc.ControlInit(Config.DB_con1, "", "", "");
            string cQuery = "";
            int start_input_column_index = 8;
            int input_column_count = grid.ColumnsCount - (start_input_column_index + 1);  //start_input_column_index값은 index이기 때문에 실제로는 9번째 값이다.

            string now_colum = "";
            int now_column_index = start_input_column_index + 1;

            int rows_num = 0;

            string temp = "";
            decimal temp_add = 0;
            string row_id = "";
            for (int a = 0; a < chk_num; a++)
            {
                rows_num = leader_num[a];
                for (int i = start_input_column_index + 1; i < grid.ColumnsCount; i++)
                {
                    now_colum = grid[2, i].Value.ToString();
                    for (int y = 0; y < gubun_count; y++)
                    {
                        if (y == 0)
                        {
                            temp_add = design;
                        }
                        else if (y == 1)
                        {
                            temp_add = paper;
                        }
                        else if (y == 2)
                        {
                            temp_add = ctp;
                        }
                        else if (y == 3)
                        {
                            temp_add = film;
                        }
                        else if (y == 4)
                        {
                            temp_add = mastapan;
                        }
                        else if (y == 5)
                        {
                            temp_add = off_set;
                        }
                        else if (y == 6)
                        {
                            temp_add = uv;
                        }
                        else if (y == 7)
                        {
                            temp_add = yunjun;
                        }
                        else if (y == 8)
                        {
                            temp_add = masta;
                        }
                        else if (y == 9)
                        {
                            temp_add = digital;
                        }
                        else if (y == 10)
                        {
                            temp_add = indigo;
                        }
                        else if (y == 11)
                        {
                            temp_add = gong;
                        }
                        else if (y == 12)
                        {
                            temp_add = carry;
                        }
                        row_id = grid[rows_num + y, 0].Value.ToString();
                        temp = (Convert.ToDecimal(grid[rows_num + y, i - 1].Value.ToString().Replace(",", "")) + temp_add).ToString();
                        grid[rows_num + y, i] = new SourceGrid.Cells.Cell(temp, typeof(string));
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
            int start_input_column_index = 8;
            int input_column_count = grid.ColumnsCount - (start_input_column_index + 1);  //start_input_column_index값은 index이기 때문에 실제로는 9번째 값이다.

            string now_colum = "";
            int now_column_index = start_input_column_index + 1;

            int rows_num = leader_num[0] + gubun_count;

            string temp = "";
            decimal temp_add = 0;
            string row_id = "";
            for (; rows_num < grid.RowsCount; rows_num = rows_num + gubun_count)
            {
                for (int i = start_input_column_index; i < grid.ColumnsCount; i++)
                {
                    now_colum = grid[2, i].Value.ToString();
                    for (int y = 0; y < gubun_count; y++)
                    {
                        if (y == 0)
                        {
                            temp_add = design;
                        }
                        else if (y == 1)
                        {
                            temp_add = paper;
                        }
                        else if (y == 2)
                        {
                            temp_add = ctp;
                        }
                        else if (y == 3)
                        {
                            temp_add = off_set;
                        }
                        else if (y == 4)
                        {
                            temp_add = uv;
                        }
                        else if (y == 5)
                        {
                            temp_add = yunjun;
                        }
                        else if (y == 6)
                        {
                            temp_add = masta;
                        }
                        else if (y == 7)
                        {
                            temp_add = digital;
                        }
                        else if (y == 8)
                        {
                            temp_add = indigo;
                        }
                        else if (y == 9)
                        {
                            temp_add = gong;
                        }
                        else if (y == 10)
                        {
                            temp_add = carry;
                        } if (y == 0)
                        {
                            temp_add = design;
                        }
                        else if (y == 1)
                        {
                            temp_add = paper;
                        }
                        else if (y == 2)
                        {
                            temp_add = ctp;
                        }
                        else if (y == 3)
                        {
                            temp_add = film;
                        }
                        else if (y == 4)
                        {
                            temp_add = mastapan;
                        }
                        else if (y == 5)
                        {
                            temp_add = off_set;
                        }
                        else if (y == 6)
                        {
                            temp_add = uv;
                        }
                        else if (y == 7)
                        {
                            temp_add = yunjun;
                        }
                        else if (y == 8)
                        {
                            temp_add = masta;
                        }
                        else if (y == 9)
                        {
                            temp_add = digital;
                        }
                        else if (y == 10)
                        {
                            temp_add = indigo;
                        }
                        else if (y == 11)
                        {
                            temp_add = gong;
                        }
                        else if (y == 12)
                        {
                            temp_add = carry;
                        }
                        row_id = grid[rows_num + y, 0].Value.ToString();
                        temp = (Convert.ToDecimal(grid[rows_num + y - gubun_count, i].Value.ToString().Replace(",", "")) + temp_add).ToString();
                        grid[rows_num + y, i] = new SourceGrid.Cells.Cell(temp, typeof(string));
                        cQuery = "update " + DB_TableName_gyeon + " set " + now_colum + "= '" + temp + "' where row_id = '" + row_id + "'";
                        kc.DataUpdate(cQuery);
                    }
                }
            }
        }

        private void rbGrade_CheckedChanged(object sender, EventArgs e)
        {
            explanation();
        }

    }
}
