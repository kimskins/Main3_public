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
    public partial class Calendar_Form : Form
    {
        private TextBox textbx = new TextBox();
        private int Xb = 0;
        private int Yb = 0;
        
        public Calendar_Form(TextBox tb)
        {
            InitializeComponent();
            textbx = tb;
            //
            Xb = textbx.PointToScreen(Location).X;  //좌,우
            Yb = textbx.PointToScreen(Location).Y + tb.Height+6;  //위,아래
        }
        //
        private void Calendar_Form_Load(object sender, EventArgs e)
        {
          this.Location = new Point(Xb, Yb);  //130 = 메뉴+버튼 길이보강
          //
          if (textbx.Text != "" && textbx.Text != "0000-00-00")
             this.monthCalendar1.SetDate(DateTime.Parse(textbx.Text));
          this.Focus();
        }

        private void monthCalendar1_DateSelected(object sender, DateRangeEventArgs e)
        {
            textbx.Text = this.monthCalendar1.SelectionEnd.ToShortDateString();
            this.Close();
        }

        private void monthCalendar1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)27)
               this.Close();
        }
    }
}
