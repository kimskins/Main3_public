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
    public partial class Webform : Form
    {
        string h_ip = "";
        string b_id = "";
        public Webform(string mm, string id)
        {
            InitializeComponent();
            h_ip = mm;
            b_id = id;
        }

        private void Webform_Load(object sender, EventArgs e)
        {
            if (b_id == "1")
            {
                this.Location = new Point(1, 1);
                this.webBrowser1.Url = new System.Uri("http://" + h_ip, System.UriKind.Absolute);
            }
            else if (b_id == "2")
            {
                this.Location = new Point(1, Config.tools_bottom);
                this.webBrowser1.Url = new System.Uri("http://" + h_ip, System.UriKind.Absolute);
            }
            else if (b_id == "3")
            {
                this.Location = new Point(1, Config.tools_bottom);
                //webBrowser1.Navigate(System.IO.Directory.GetCurrentDirectory().ToString()+"\\Documents\\SourceGrid_EN.html");
                webBrowser1.Navigate(h_ip);

            }
            else
                return;
        }

        private void webBrowser1_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
        {

        }
    }
}
