using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using System.Net.Mail;

namespace Dukyou3
{
    public partial class Form_213 : Form
    {
        SourceGridControl GridHandle = new SourceGridControl();

        string DB_TableName_c_com = "C_choice_company";


        public Form_213()
        {
            InitializeComponent();
            //MailMessage mail = new MailMessage();
            //SmtpClient SmtpServer = new SmtpClient("smtp.nate.com", 587);

            //mail.From = new MailAddress("lovesk927@nate.com", "김상균");
            //mail.To.Add("kercer@naver.com");
            //mail.BodyEncoding = System.Text.Encoding.UTF8;

            //mail.Subject = "Test Mail";
            //mail.Body = " hi hihihihiz";

            //SmtpServer.Credentials = new System.Net.NetworkCredential("lovesk927", "zldzktkdrbs841101");
            //SmtpServer.EnableSsl = true;

            //SmtpServer.Send(mail);
            //MessageBox.Show("mail send");
            
        }

        private void Form_213_Load(object sender, EventArgs e)
        {
            Screen srn = Screen.PrimaryScreen;
            int Xb = this.Width;  //좌,우
            int Yb = this.Height; //좌,우
            this.Location = new Point((srn.Bounds.Width - Xb) / 2, (srn.Bounds.Height - Yb) / 2);  //좌/우,위/아래

            GridHandle.SourceGrideInit(grid1, Config.DB_con1);
            Refresh();
        }

        private void Refresh()
        {
            string cQuery = "select a.*, e.sangho,b.dosu hdosu, b.pan_type hpan_type, c.hang hhang, d.bitem hbitem, b.machin_name hmachin_name, ";
            cQuery += " f.dosu pdosu, f.pan_type ppan_type, g.hang phang, h.bitem pbitem, f.machin_name pmachin_name ";
            cQuery += " from  C_choice_company  as a";
            cQuery += " left outer join C_hmachin as b on a.machine_id = b.row_id ";   // 사용자 machine 정보를 join
            cQuery += " left outer join hang_manage as c on b.pan_type=c.code1 and c.class='판형' ";
            cQuery += " left outer join C_bmodel as d on d.a_code = b.a_model and d.b_code = b.b_model";
            cQuery += " left outer join C_hcustomer as e on b.int_id=e.row_id";

            cQuery += " left outer join C_platform_machine as f on a.plat_machine_id = f.row_id ";   // plat_machine 정보를 join
            cQuery += " left outer join hang_manage as g on f.pan_type=g.code1 and g.class='판형' ";
            cQuery += " left outer join C_bmodel as h on h.a_code = f.a_model and h.b_code = f.b_model";
            cQuery += " left outer join C_hcustomer as i on f.int_id=i.row_id";
            cQuery += " order by row_id";

            Grid_View(cQuery);
        }

        private void Grid_View(string Query)
        {
            cell_d cc = new cell_d();
            // 
            grid1.Rows.Clear();
            grid1.BorderStyle = BorderStyle.FixedSingle;
            grid1.SelectionMode = SourceGrid.GridSelectionMode.Cell;
            grid1.ColumnsCount = 14;
            grid1.FixedRows = 2;
            grid1.Rows.Insert(0);
            grid1.Rows[0].Height = 24;
            grid1.Rows.Insert(1);
            grid1.Rows[1].Height = 24;

            grid1[0, 0] = new MyHeader1("row_id");
            grid1.Columns[0].Visible = false;
            grid1[0, 0].RowSpan = 2;

            grid1[0, 1] = new MyHeader1("√");
            grid1[0, 1].RowSpan = 2;
            grid1[0, 2] = new MyHeader1("no");
            grid1[0, 2].RowSpan = 2;
            grid1[0, 3] = new MyHeader1("업체명");
            grid1[0, 3].RowSpan = 2;
            grid1[0, 4] = new MyHeader1("title");
            grid1[0, 4].RowSpan = 2;
            grid1[0, 5] = new MyHeader1("사용자 기계구분");
            grid1[0, 5].ColumnSpan = 4;
            grid1[1, 5] = new MyHeader1("중분류");
            grid1[1, 6] = new MyHeader1("도수");
            grid1[1, 7] = new MyHeader1("절수");
            grid1[1, 8] = new MyHeader1("기계명");
            grid1[0, 9] = new MyHeader1("ab 코드");
            grid1[0, 9].RowSpan = 2;
            grid1[0, 10] = new MyHeader1("플랫폼 기계구분");
            grid1[0, 10].ColumnSpan = 4;
            grid1[1, 10] = new MyHeader1("중분류");
            grid1[1, 11] = new MyHeader1("도수");
            grid1[1, 12] = new MyHeader1("절수");
            grid1[1, 13] = new MyHeader1("기계명");

            grid1.Columns[1].Width = 22;
            grid1.Columns[2].Width = 40;
            grid1.Columns[3].Width = 150;
            grid1.Columns[4].Width = 100;
            grid1.Columns[5].Width = 100;
            grid1.Columns[6].Width = 50;
            grid1.Columns[7].Width = 60;
            grid1.Columns[8].Width = 100;
            grid1.Columns[9].Width = 50;
            grid1.Columns[10].Width = 100;
            grid1.Columns[11].Width = 50;
            grid1.Columns[12].Width = 60;
            grid1.Columns[13].Width = 100;

            MySqlConnection DBConn;
            DBConn = new MySqlConnection(Config.DB_con1);
            DBConn.Open();

            var cmd = new MySqlCommand(Query, DBConn);
            var myRead = cmd.ExecuteReader();

            int Rows = 2;
            while (myRead.Read())
            {
                grid1.Rows.Insert(Rows);
                grid1.Rows[Rows].Height = 24;

                grid1[Rows, 0] = new SourceGrid.Cells.Cell(myRead["row_id"], typeof(string));
                grid1[Rows, 1] = new SourceGrid.Cells.CheckBox(null, false);

                grid1[Rows, 2] = new SourceGrid.Cells.Cell((Rows - 1).ToString(), typeof(string));
                grid1[Rows, 2].View = cc.center_cell;
                grid1[Rows, 2].Editor = cc.disable_cell;

                grid1[Rows, 3] = new SourceGrid.Cells.Cell(myRead["sangho"], typeof(string));
                grid1[Rows, 3].View = cc.left_cell;

                grid1[Rows, 4] = new SourceGrid.Cells.Cell(myRead["title"], typeof(string));
                grid1[Rows, 4].View = cc.left_cell;

                grid1[Rows, 5] = new SourceGrid.Cells.Cell(myRead["hbitem"], typeof(string));
                grid1[Rows, 5].View = cc.left_cell;

                grid1[Rows, 6] = new SourceGrid.Cells.Cell(myRead["hdosu"], typeof(string));
                grid1[Rows, 6].View = cc.center_cell;

                grid1[Rows, 7] = new SourceGrid.Cells.Cell(myRead["hhang"], typeof(string));
                grid1[Rows, 7].View = cc.center_cell;

                grid1[Rows, 8] = new SourceGrid.Cells.Cell(myRead["hmachin_name"], typeof(string));
                grid1[Rows, 8].View = cc.center_cell;

                grid1[Rows, 9] = new SourceGrid.Cells.Cell(myRead["ab_code"], typeof(string));
                grid1[Rows, 9].View = cc.center_cell;

                grid1[Rows, 10] = new SourceGrid.Cells.Cell(myRead["pbitem"], typeof(string));
                grid1[Rows, 10].View = cc.left_cell;

                grid1[Rows, 11] = new SourceGrid.Cells.Cell(myRead["pdosu"], typeof(string));
                grid1[Rows, 11].View = cc.center_cell;

                grid1[Rows, 12] = new SourceGrid.Cells.Cell(myRead["phang"], typeof(string));
                grid1[Rows, 12].View = cc.center_cell;

                grid1[Rows, 13] = new SourceGrid.Cells.Cell(myRead["pmachin_name"], typeof(string));
                grid1[Rows, 13].View = cc.center_cell;

                Rows++;
            }
            myRead.Close();
            DBConn.Close();
        }

        private void bAdd_Click(object sender, EventArgs e)
        {
            string User_machine_id = "";
            string User_customer_id = "";
            string Plat_machine_id = "";
            Form_213a Frm = new Form_213a();
            Frm.ShowDialog();

            if (Frm.ab_code == "")  // 선택을 안하고 그냥 닫으면 ab_code가 ""임.
                return;

            Form_213b Frm1 = new Form_213b(Frm.ab_code, "user");
            Frm1.ShowDialog();

            if (Frm1.machine_row_id == "no data") // 선택을 안하고 그냥 닫으면 machine_row_id와 customer_row_id 의 값은 "no data"임
                return;

            User_machine_id = Frm1.machine_row_id;
            User_customer_id = Frm1.customer_row_id;

            Form_213b Frm2 = new Form_213b(Frm.ab_code, "platform");
            Frm2.ShowDialog();

            if (Frm2.machine_row_id == "no data") // 선택을 안하고 그냥 닫으면 machine_row_id와 customer_row_id 의 값은 "no data"임
                return;

            Plat_machine_id = Frm2.machine_row_id;

            string Query = "insert into " + DB_TableName_c_com + " (company_id, machine_id, ab_code, plat_machine_id) ";
            Query += " values('" + User_customer_id + "', '" + User_machine_id + "', '" + Frm.ab_code + "', '" + Plat_machine_id + "')";
            GridHandle.DataUpdate(Query);

            Refresh();
        }

        private void bDelete_Click(object sender, EventArgs e)
        {
            GridHandle.ChkDataDelete(DB_TableName_c_com, 2, 0, 1);
        }

        private void bRefresh_Click(object sender, EventArgs e)
        {

        }
    }
}
