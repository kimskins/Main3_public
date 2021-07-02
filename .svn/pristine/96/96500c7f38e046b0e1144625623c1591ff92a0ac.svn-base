using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Threading;
using MySql.Data.MySqlClient;
using System.Diagnostics;


namespace Dukyou3
{

    public partial class Main : Form
    {
        public Main()
        {
            InitializeComponent();

        }
        private void Version_chk()
        {
            //MessageBox.Show("Beta2 입니다.");
            string Query = "select * from C_version_manage where row_id = '2'";
            var DBConn = new MySqlConnection(Config.DB_con1);
            DBConn.Open();
            var cmd = new MySqlCommand(Query, DBConn);

            var myRead = cmd.ExecuteReader();
            myRead.Read();
            if (myRead["now_version"].ToString() != Config.version)
            {
                MessageBox.Show("버젼 정보가 다릅니다. update 후 실행하여 주세요");
                myRead.Close();
                DBConn.Close();

                this.Close();
                Application.ExitThread();
                Environment.Exit(0);
            }
            DBConn.Close();
        }

        private void Main_Load(object sender, EventArgs e)
        {
            new Thread(Make_table.make).Start();

            //Only_paper();
            menu_chk();
            //Version_chk();
        }
        private void menu_chk()
        {
            if (User.Cli_name == "pera_s")
            {
                운영관리ToolStripMenuItem.Visible = false;
                단가관리ToolStripMenuItem.Visible = false;
                솔류션사용업체관리ToolStripMenuItem.Visible = false;
                시스템관리ToolStripMenuItem.Visible = false;
                플랫폼매입장부ToolStripMenuItem.Visible = false;
                대기창진행창ToolStripMenuItem1.Visible = false;
                지업사단가관리ToolStripMenuItem.Visible = false;
                지업사코드관리ToolStripMenuItem.Visible = false;
                이모션Paper이모션지업사ToolStripMenuItem.Visible = false;
                목형자료DB목형자료관리ToolStripMenuItem.Visible = false;
                목형자료DB목형자료관리ToolStripMenuItem1.Visible = false;
                목형자료DB목형자료관리ToolStripMenuItem2.Text = "1. 협력업체 DB(협력업체관리)";
            }
        }
        private void Only_paper()
        {
            dB관리ToolStripMenuItem.Visible = false;
            운영관리ToolStripMenuItem.Visible = false;
            단가관리ToolStripMenuItem.Visible = false;
            솔류션사용업체관리ToolStripMenuItem.Visible = false;
            시스템관리ToolStripMenuItem.Visible = false;
            플랫폼매입장부ToolStripMenuItem.Visible = false;
            대기창진행창ToolStripMenuItem1.Visible = false;
            이모션Paper이모션지업사ToolStripMenuItem.Text = "이모션 Paper(이모션지업사)";
            지업사단가관리ToolStripMenuItem.Visible = false;
            지업사코드관리ToolStripMenuItem.Visible = false;

            지류단가DB등록수정ToolStripMenuItem.Text = "지류단가 DB(등록/수정)";


        }
        //

        private void Main_FormClosing(object sender, FormClosingEventArgs e)
        {
            //DirectoryInfo target = new DirectoryInfo("c:\\temp");
            //foreach (FileInfo fInfo in target.GetFiles())
            //    if (fInfo.Length > 0)
            //        fInfo.Delete();
            //           
            Application.Exit();
        }

        private void 목형자료DBToolStripMenuItem_Click(object sender, EventArgs e)   //Form_101
        {
            int[] mm = new int[3];
            mm[0] = 0;
            mm[1] = 0;
            mm[2] = 0;
            // 
            util.IsFormAlreadyOpen(typeof(Form_101));
            Form_101 Frm = new Form_101("1", mm);
            Frm.MdiParent = this;
            Frm.Show();
        }

        private void 인쇄ToolStripMenuItem_Click(object sender, EventArgs e)  //Form_machin 인쇄
        {
            util.IsFormAlreadyOpen(typeof(Form_machin));
            Form_machin Frm = new Form_machin("08");
            Frm.MdiParent = this;
            Frm.Show();

        }

        private void 제본ToolStripMenuItem_Click(object sender, EventArgs e)  //Form_machins 제본
        {
            util.IsFormAlreadyOpen(typeof(Form_machins));
            Form_machins Frm = new Form_machins("16", "2");  //대분류코드,폼번호
            Frm.MdiParent = this;
            Frm.Show();

        }

        private void 코팅ToolStripMenuItem_Click(object sender, EventArgs e)  //Form_machins 코팅
        {
            util.IsFormAlreadyOpen(typeof(Form_machins));
            Form_machins Frm = new Form_machins("10", "3");
            Frm.MdiParent = this;
            Frm.Show();

        }

        private void 접지ToolStripMenuItem_Click(object sender, EventArgs e)  //Form_machins 접지
        {
            util.IsFormAlreadyOpen(typeof(Form_machins));
            Form_machins Frm = new Form_machins("11", "4");
            Frm.MdiParent = this;
            Frm.Show();

        }

        private void 도무송ToolStripMenuItem_Click(object sender, EventArgs e)  //Form_machins 기타
        {
            util.IsFormAlreadyOpen(typeof(Form_machins));
            Form_machins Frm = new Form_machins("", "5");
            Frm.MdiParent = this;
            Frm.Show();

        }
        /*20190215 강한별*/
        private void cTPToolStripMenuItem_Click(object sender, EventArgs e)
        {
            util.IsFormAlreadyOpen(typeof(Form_machin1));
            Form_machin1 Frm = new Form_machin1("04");
            Frm.MdiParent = this;
            Frm.Show();
        }
        //--------------------------

        private void 협력업체DBToolStripMenuItem2_Click(object sender, EventArgs e)  //103
        {
            util.IsFormAlreadyOpen(typeof(Form_103));
            Form_103 Frm = new Form_103();
            Frm.MdiParent = this;
            Frm.Show();

        }

        private void 협력업체업종관리ToolStripMenuItem_Click(object sender, EventArgs e)  //203
        {
            util.IsFormAlreadyOpen(typeof(Form_203));
            Form_203 Frm = new Form_203();
            Frm.MdiParent = this;
            Frm.Show();

        }

        private void 항목자료AToolStripMenuItem_Click(object sender, EventArgs e)  //205
        {
            util.IsFormAlreadyOpen(typeof(Form_205));
            Form_205 Frm = new Form_205();
            Frm.MdiParent = this;
            Frm.Show();
        }

        private void 항목자료BToolStripMenuItem_Click(object sender, EventArgs e)  //206
        {
            util.IsFormAlreadyOpen(typeof(Form_206));
            Form_206 Frm = new Form_206();
            Frm.MdiParent = this;
            Frm.Show();
        }


        private void 배송방법차량관리ToolStripMenuItem_Click(object sender, EventArgs e)  //208
        {
            util.IsFormAlreadyOpen(typeof(Form_208));
            Form_208 Frm = new Form_208();
            Frm.MdiParent = this;
            Frm.Show();
        }

        private void 플렛폼단가ToolStripMenuItem_Click(object sender, EventArgs e)  //  301
        {

        }

        private void 관공서단가ToolStripMenuItem_Click(object sender, EventArgs e)  //  302
        {

        }

        private void 운송단가DBToolStripMenuItem_Click(object sender, EventArgs e)  //  303
        {
            util.IsFormAlreadyOpen(typeof(Form_301));
            Form_301 Frm = new Form_301();
            Frm.MdiParent = this;
            Frm.Show();
        }

        private void 업체관리업체정보장부정보ToolStripMenuItem_Click(object sender, EventArgs e)  //401
        {

        }

        private void 지업사단가관리ToolStripMenuItem_Click(object sender, EventArgs e)  //501
        {
            util.IsFormAlreadyOpen(typeof(Form_502));
            Form_502 Frm = new Form_502();
            Frm.Owner = this;
            Frm.MdiParent = this;
            Frm.Show();
        }

        private void 기본설정ToolStripMenuItem_Click(object sender, EventArgs e)  //601 
        {

        }

        private void 공지QAToolStripMenuItem_Click(object sender, EventArgs e)
        {
            util.IsFormAlreadyOpen(typeof(Form_402));
            Form_402 Frm = new Form_402();
            Frm.MdiParent = this;
            Frm.Show();
        }

        private void 사용업체ID관리ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            util.IsFormAlreadyOpen(typeof(Form_4011));
            Form_4011 Frm = new Form_4011();
            Frm.MdiParent = this;
            Frm.Show();
        }

        private void 박원단DB들록수정ToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }

        private void 지류매출장부ToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }

        private void 기성박스단가ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            util.IsFormAlreadyOpen(typeof(Form_302));
            Form_302 Frm = new Form_302();
            Frm.MdiParent = this;
            Frm.Show();
        }

        private void 스티커PET원단단가ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            util.IsFormAlreadyOpen(typeof(Form_303));
            Form_303 Frm = new Form_303();
            Frm.MdiParent = this;
            Frm.Show();
        }

        private void 싸바리원단단가ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            util.IsFormAlreadyOpen(typeof(Form_304));
            Form_304 Frm = new Form_304();
            Frm.MdiParent = this;
            Frm.Show();
        }

        private void 박원단DBToolStripMenuItem_Click(object sender, EventArgs e)
        {
            util.IsFormAlreadyOpen(typeof(Form_305));
            Form_305 Frm = new Form_305();
            Frm.MdiParent = this;
            Frm.Show();
        }

        private void toolStripMenuItem2_Click(object sender, EventArgs e)
        {

        }

        private void 접지단가ToolStripMenuItem_Click(object sender, EventArgs e)  //접지단가
        {

        }

        private void 항목ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            util.IsFormAlreadyOpen(typeof(Form_2121));
            Form_2121 Frm = new Form_2121();
            Frm.MdiParent = this;
            Frm.Show();
        }

        private void 옵셋인쇄111ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            util.IsFormAlreadyOpen(typeof(Form_2122));
            Form_2122 Frm = new Form_2122("0804");
            Frm.MdiParent = this;
            Frm.Show();
        }

        private void uVToolStripMenuItem_Click(object sender, EventArgs e)
        {
            util.IsFormAlreadyOpen(typeof(Form_2122));
            Form_2122 Frm = new Form_2122("0806");
            Frm.MdiParent = this;
            Frm.Show();
        }

        private void 윤전ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            util.IsFormAlreadyOpen(typeof(Form_2122));
            Form_2122 Frm = new Form_2122("0805");
            Frm.MdiParent = this;
            Frm.Show();
        }

        private void 디지털ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            util.IsFormAlreadyOpen(typeof(Form_2122));
            Form_2122 Frm = new Form_2122("0802");
            Frm.MdiParent = this;
            Frm.Show();
        }

        private void 인디고ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            util.IsFormAlreadyOpen(typeof(Form_2122));
            Form_2122 Frm = new Form_2122("0803");
            Frm.MdiParent = this;
            Frm.Show();
        }

        private void 마스터ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            util.IsFormAlreadyOpen(typeof(Form_2122));
            Form_2122 Frm = new Form_2122("0801");
            Frm.MdiParent = this;
            Frm.Show();
        }


        private void 기본선택업체ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            util.IsFormAlreadyOpen(typeof(Form_213));
            Form_213 Frm = new Form_213();
            Frm.MdiParent = this;
            Frm.Show();
        }

        private void 안전항목DBToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            util.IsFormAlreadyOpen(typeof(Form_209));
            Form_209 Frm = new Form_209();
            Frm.MdiParent = this;
            Frm.Show();
        }

        private void 단가ToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }

        private void 세부견적ToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }

        private void cTP접수ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            util.IsFormAlreadyOpen(typeof(Form_604));
            Form_604 Frm = new Form_604();
            Frm.MdiParent = this;
            Frm.Show();

        }

        private void 광고설정ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            util.IsFormAlreadyOpen(typeof(Form_404));
            Form_404 Frm = new Form_404();
            Frm.MdiParent = this;
            Frm.Show();
        }

        private void cTP폐판수거ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            util.IsFormAlreadyOpen(typeof(Form_605));
            Form_605 Frm = new Form_605();
            Frm.MdiParent = this;
            Frm.Show();
        }

        private void cTP단가등급ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            util.IsFormAlreadyOpen(typeof(Form_606));
            Form_606 Frm = new Form_606();
            Frm.MdiParent = this;
            Frm.Show();
        }

        private void 도큐인쇄종이ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            util.IsFormAlreadyOpen(typeof(Form_2111));
            Form_2111 Frm = new Form_2111();
            Frm.MdiParent = this;
            Frm.Show();
        }

        private void 종이원자재사이즈ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            util.IsFormAlreadyOpen(typeof(Form_2112));
            Form_2112 Frm = new Form_2112();
            Frm.MdiParent = this;
            Frm.Show();
        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            util.IsFormAlreadyOpen(typeof(Form_501));
            Form_501 Frm = new Form_501();
            Frm.Owner = this;
            Frm.MdiParent = this;
            Frm.Show();
        }

        private void 지업사코드관리ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            util.IsFormAlreadyOpen(typeof(Form_503));
            Form_503 Frm = new Form_503("4001", null);
            Frm.Owner = this;
            Frm.MdiParent = this;
            Frm.Show();
        }

        private void 박스계산설정ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            util.IsFormAlreadyOpen(typeof(Form_202));
            Form_202 Frm = new Form_202();
            Frm.MdiParent = this;
            Frm.Show();
        }

        private void 후공정단가연결설정ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            util.IsFormAlreadyOpen(typeof(Form_204));
            Form_204 Frm = new Form_204(99);
            Frm.MdiParent = this;
            Frm.Show();
        }

        private void 돈땡검사ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            util.IsFormAlreadyOpen(typeof(Form_207));
            Form_207 Frm = new Form_207();
            Frm.MdiParent = this;
            Frm.Show();
        }

        private void 코드관리ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            util.IsFormAlreadyOpen(typeof(Form_210));
            Form_210 Frm = new Form_210();
            Frm.MdiParent = this;
            Frm.Show();
        }

        private void 인쇄사이즈ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            util.IsFormAlreadyOpen(typeof(Form_2113));
            Form_2113 Frm = new Form_2113();
            Frm.MdiParent = this;
            Frm.Show();
        }

        private void 인쇄사이즈설정ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            util.IsFormAlreadyOpen(typeof(Form_2114));
            Form_2114 Frm = new Form_2114();
            Frm.MdiParent = this;
            Frm.Show();
        }

        private void 제본사이즈기본값ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            util.IsFormAlreadyOpen(typeof(Form_2115));
            Form_2115 Frm = new Form_2115();
            Frm.MdiParent = this;
            Frm.Show();
        }

        private void 돈땡검사ToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            util.IsFormAlreadyOpen(typeof(Form_207));
            Form_207 Frm = new Form_207();
            Frm.MdiParent = this;
            Frm.Show();
        }

        private void 기본계산ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            util.IsFormAlreadyOpen(typeof(Form_2011));
            Form_2011 Frm = new Form_2011();
            Frm.MdiParent = this;
            Frm.Show();
        }

        private void 대수분개ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            util.IsFormAlreadyOpen(typeof(Form_2012));
            Form_2012 Frm = new Form_2012();
            Frm.MdiParent = this;
            Frm.Show();
        }

        private void 쇼핑백사이즈검사및계산ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            util.IsFormAlreadyOpen(typeof(Form_214));
            Form_214 Frm = new Form_214();
            Frm.MdiParent = this;
            Frm.Show();
        }

        private void 기성박스우찌누끼ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            util.IsFormAlreadyOpen(typeof(Form_2151));
            Form_2151 Frm = new Form_2151();
            Frm.MdiParent = this;
            Frm.Show();
        }

        private void 제작봉투사이즈설정ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            util.IsFormAlreadyOpen(typeof(Form_2152));
            Form_2152 Frm = new Form_2152();
            Frm.MdiParent = this;
            Frm.Show();
        }

        private void 유형별접지단가ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            util.IsFormAlreadyOpen(typeof(Form_3061));
            Form_3061 Frm = new Form_3061();
            Frm.MdiParent = this;
            Frm.Show();
        }

        private void 할증율ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            util.IsFormAlreadyOpen(typeof(Form_3062));
            Form_3062 Frm = new Form_3062();
            Frm.MdiParent = this;
            Frm.Show();
        }

        private void 인쇄도수검색ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            util.IsFormAlreadyOpen(typeof(Form_216));
            Form_216 Frm = new Form_216();
            Frm.MdiParent = this;
            Frm.Show();
        }

        private void 인쇄00ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            util.IsFormAlreadyOpen(typeof(Form_2122));
            Form_2122 Frm = new Form_2122("0809");
            Frm.MdiParent = this;
            Frm.Show();
        }

        private void 협력업체ID관리ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            util.IsFormAlreadyOpen(typeof(Form_4012));
            Form_4012 Frm = new Form_4012();
            Frm.MdiParent = this;
            Frm.Show();
        }

        private void 불량유져관리ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            util.IsFormAlreadyOpen(typeof(Form_405));
            Form_405 Frm = new Form_405();
            Frm.MdiParent = this;
            Frm.Show();
        }

        private void 회원관리ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            util.IsFormAlreadyOpen(typeof(Form_4014));
            Form_4014 Frm = new Form_4014();
            Frm.MdiParent = this;
            Frm.Show();
        }

        private void 딜러업체ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            util.IsFormAlreadyOpen(typeof(Form_4013));
            Form_4013 Frm = new Form_4013();
            Frm.MdiParent = this;
            Frm.Show();
        }

        private void 작업의뢰서관리ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            util.IsFormAlreadyOpen(typeof(Form_607));
            Form_607 Frm = new Form_607();
            Frm.MdiParent = this;
            Frm.Show();
        }

        private void pET원단단가ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            util.IsFormAlreadyOpen(typeof(Form_pet));
            Form_pet Frm = new Form_pet();
            Frm.MdiParent = this;
            Frm.Show();
        }

        private void 가름끈헤드밴드단가ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            util.IsFormAlreadyOpen(typeof(Form_308));
            Form_308 Frm = new Form_308();
            Frm.MdiParent = this;
            Frm.Show();
        }

        private void 인쇄기계별할증율ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            util.IsFormAlreadyOpen(typeof(Form_2017));
            Form_2017 Frm = new Form_2017();
            Frm.MdiParent = this;
            Frm.Show();
        }

        private void 접지설정ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            util.IsFormAlreadyOpen(typeof(Form_2018));
            Form_2018 Frm = new Form_2018();
            Frm.MdiParent = this;
            Frm.Show();
        }

        private void 데이타파일관리ToolStripMenuItem_Click(object sender, EventArgs e)  //데이타파일 관리
        {
            util.IsFormAlreadyOpen(typeof(Form_data_file));
            Form_data_file frm = new Form_data_file();
            frm.Owner = this;
            frm.MdiParent = this;
            frm.Show();
        }

        private void toolStripMenuItem2_Click_1(object sender, EventArgs e)
        {
            util.IsFormAlreadyOpen(typeof(Form_douzone_code));
            Form_douzone_code frm = new Form_douzone_code();
            frm.Owner = this;
            frm.MdiParent = this;
            frm.Show();
        }
    }
}
