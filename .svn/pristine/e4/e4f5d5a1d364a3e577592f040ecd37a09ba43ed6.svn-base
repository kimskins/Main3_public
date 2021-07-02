using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Dukyou
{
    public class WATGroupBox : GroupBox
    {
        private Color borderColor;
        public Color BorderColor
        {
            get { return this.borderColor; }

            set
            {
                this.borderColor = value;
                this.Invalidate();
            }

        }


        public WATGroupBox()
        {
            this.borderColor = Color.Black;
        }


        protected override void OnPaint(PaintEventArgs e)
        {
            Size tSize = TextRenderer.MeasureText(this.Text, this.Font);
            Rectangle borderRect = this.ClientRectangle;
            borderRect.Y = (borderRect.Y + (tSize.Height / 2));
            borderRect.Height = (borderRect.Height - (tSize.Height / 2));
            ControlPaint.DrawBorder(e.Graphics, borderRect, this.borderColor, ButtonBorderStyle.Solid);
            Rectangle textRect = this.ClientRectangle;
            textRect.X = (textRect.X + 6);
            textRect.Width = tSize.Width;
            textRect.Height = tSize.Height;
            e.Graphics.FillRectangle(new SolidBrush(this.BackColor), textRect);
            e.Graphics.DrawString(this.Text, this.Font, new SolidBrush(this.ForeColor), textRect);
        }
    }
}
