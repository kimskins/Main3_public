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
    public partial class ListView_no_2 : Form
    {
        private TextBox textbx = new TextBox();
        private Label labbx = new Label();
        private int Xb = 0;
        private int Yb = 0;
        int g_hight = 0;
        int s_row = 0;
        string x_id = "";
        public string row_no="";
        public string index = "";
        public int width = 0;
        public int height = 0;
        
        public ListView_no_2(TextBox tb, int row)
        {
            InitializeComponent();
            s_row = row;
            textbx = tb;
            //
            Xb = textbx.PointToScreen(Location).X;  //좌,우
            Yb = textbx.PointToScreen(Location).Y + tb.Height;  //위,아래
            //
            Config.ff = this;
            x_id = "T";
        }

        public ListView_no_2(Label tb, int row)
        {
            InitializeComponent();
            s_row = row;
            labbx = tb;
            //
            Xb = labbx.PointToScreen(Location).X;  //좌,우
            Yb = labbx.PointToScreen(Location).Y + tb.Height;  //위,아래
            //
            Config.ff = this;
            x_id = "L";
        }

        public ListView_no_2(int x, int y, int row, SourceGrid.Grid grid)
        {
            InitializeComponent();
            s_row = row;
            g_hight = grid.Rows.GetHeight(1);
            //
            Xb = grid.PointToScreen(Location).X + x;              //좌,우
            Yb = grid.PointToScreen(Location).Y + y + g_hight;  //위,아래
            //
            Config.ff = this;
        }

        private void ListView_no_2_Load(object sender, EventArgs e)
        {
            if ((Yb + this.Height) > Screen.PrimaryScreen.Bounds.Height)
                Yb = Yb - this.Height - g_hight;
            //
            this.Location = new Point(Xb, Yb);

            if (width > 0 && height > 0)
            {
                this.Size = new Size(width, height);
                this.Refresh();
            }

            //if (grid1.RowCount != 0)
            //    dataGridView1.Rows[dataGridView1.CurrentCell.RowIndex].Selected = false;
        }

        private void bClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void bSave_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void ListView_no_2_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
                this.Close();
        }


    }
}
