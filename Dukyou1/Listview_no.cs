using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using MySql.Data.MySqlClient;
using System.Security.Cryptography;
using System.Runtime.InteropServices;
using System.Diagnostics;

namespace Dukyou3
{
    public partial class Listview_no : Form
    {
        private static LowLevelMouseProc _proc = HookCallback;
        private static IntPtr _hookID = IntPtr.Zero;

        [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        private static extern IntPtr SetWindowsHookEx(int idHook,
            LowLevelMouseProc lpfn, IntPtr hMod, uint dwThreadId);

        [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        private static extern bool UnhookWindowsHookEx(IntPtr hhk);

        [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        private static extern IntPtr CallNextHookEx(IntPtr hhk, int nCode,
            IntPtr wParam, IntPtr lParam);

        [DllImport("kernel32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        private static extern IntPtr GetModuleHandle(string lpModuleName);

        private TextBox textbx = new TextBox();
        private Label labbx = new Label();
        private int Xb = 0;
        private int Yb = 0;
        int s_row = 0;
        string x_id = "";
        public string row_no="";

        public Listview_no(TextBox tb, int row)
        {
            InitializeComponent();
            s_row = row;
            textbx = tb;
            //
            Xb = textbx.PointToScreen(Location).X;  //좌,우
            Yb = textbx.PointToScreen(Location).Y + tb.Height;  //위,아래
            //
            _hookID = SetHook(_proc);
            Config.ff = this;
            x_id = "T"; 
        }

        public Listview_no(Label tb, int row)
        {
            InitializeComponent();
            s_row = row;
            labbx = tb;
            //
            Xb = labbx.PointToScreen(Location).X;  //좌,우
            Yb = labbx.PointToScreen(Location).Y + tb.Height;  //위,아래
            //
            _hookID = SetHook(_proc);
            Config.ff = this;
            x_id = "L"; 
        }

        public Listview_no(int x, int y, int row, SourceGrid.Grid grid )
        {
            InitializeComponent();
            s_row = row;
            //
            Xb = grid.PointToScreen(Location).X+x;  //좌,우
            Yb = grid.PointToScreen(Location).Y+y;  //위,아래
            //
            _hookID = SetHook(_proc);
            Config.ff = this;
        }

        private void Listview_no_Load(object sender, EventArgs e)
        {
            this.Location = new Point(Xb, Yb);
            dataGridView1.Rows[dataGridView1.CurrentCell.RowIndex].Selected = false;
        }

        private void dataGridView1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (e.Button.ToString().Equals("Left"))
            {
                if (dataGridView1.CurrentCell.ColumnIndex.Equals(s_row))
                {
                    if (dataGridView1.SelectedCells.Count != 0)
                    {
                        if (x_id == "T")
                        {
                            textbx.Text = dataGridView1.SelectedCells[0].Value.ToString();
                            if (dataGridView1.ColumnCount > 1)
                                row_no = dataGridView1.Rows[dataGridView1.CurrentRow.Index].Cells[1].Value.ToString().Trim();
                        }
                        else
                        {
                            labbx.Text = dataGridView1.SelectedCells[0].Value.ToString();
                            if (dataGridView1.ColumnCount > 1)
                                row_no = dataGridView1.Rows[dataGridView1.CurrentRow.Index].Cells[1].Value.ToString().Trim();
                        }
                        //
                        this.DialogResult = DialogResult.OK;
                        this.Close();
                        this.Dispose();
                    }
                }
            }
        }

        private void dataGridView1_MouseClick(object sender, MouseEventArgs e)  //마우스 클릭
        {
            if (e.Button.ToString().Equals("Left"))
            {
                if (dataGridView1.CurrentCell != null)
                {
                    if (dataGridView1.CurrentCell.ColumnIndex.Equals(s_row))
                    {
                        if (dataGridView1.SelectedCells.Count != 0)
                        {
                            if (x_id == "T")
                            {
                                textbx.Text = dataGridView1.SelectedCells[0].Value.ToString();
                                if (dataGridView1.ColumnCount > 1)                           
                                    row_no = dataGridView1.Rows[dataGridView1.CurrentRow.Index].Cells[1].Value.ToString().Trim();
                            }
                            else
                            {
                                labbx.Text = dataGridView1.SelectedCells[0].Value.ToString();
                                if (dataGridView1.ColumnCount > 1)
                                    row_no = dataGridView1.Rows[dataGridView1.CurrentRow.Index].Cells[1].Value.ToString().Trim();

                            }
                            //
                            this.DialogResult = DialogResult.OK;
                            this.Close();
                            this.Dispose();
                        }
                    }
                }
                else
                {
                    this.Close();
                    this.Dispose();
                }
            }

            /*
            if (e.Button.ToString().Equals ("Right"))
                 this.Close();
            else
            {
                if (dataGridView1.CurrentCell.GetType().Name.Equals("DataGridViewButtonCell"))
                {
                    MessageBox.Show("제본그림보기");

                }
            }
            */
        }

        private void dataGridView1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                textbx.Text = dataGridView1.SelectedCells[0].Value.ToString();
                this.DialogResult = DialogResult.OK;
                this.Close();
                this.Dispose();
            }
            else if (e.KeyCode == Keys.Escape)
            {
                this.Close();
                this.Dispose();
            }
        }

        private void Listview_no_Deactivate(object sender, EventArgs e)
        {
            this.Close();
            this.Dispose();
            //((Form)sender).Dispose();
        }

        private static IntPtr HookCallback(int nCode, IntPtr wParam, IntPtr lParam)
        {
            if (nCode >= 0 && MouseMessages.WM_LBUTTONDOWN == (MouseMessages)wParam)
            {
                //MSLLHOOKSTRUCT hookStruct = (MSLLHOOKSTRUCT)Marshal.PtrToStructure(lParam, typeof(MSLLHOOKSTRUCT));
                //MessageBox.Show(hookStruct.pt.x + ", " + hookStruct.pt.y);
                if (!Config.ff.RectangleToScreen(Config.ff.ClientRectangle).Contains(Cursor.Position))
                {
                    Config.ff.Close();
                }
            }
            return CallNextHookEx(_hookID, nCode, wParam, lParam);
        }

        private static IntPtr SetHook(LowLevelMouseProc proc)
        {
            using (Process curProcess = Process.GetCurrentProcess())
            using (ProcessModule curModule = curProcess.MainModule)
            {
                return SetWindowsHookEx(WH_MOUSE_LL, proc,
                    GetModuleHandle(curModule.ModuleName), 0);
            }
        }

        private delegate IntPtr LowLevelMouseProc(int nCode, IntPtr wParam, IntPtr lParam);

        private const int WH_MOUSE_LL = 14;

        private enum MouseMessages
        {
            WM_LBUTTONDOWN = 0x0201,
            WM_LBUTTONUP = 0x0202,
            WM_MOUSEMOVE = 0x0200,
            WM_MOUSEWHEEL = 0x020A,
            WM_RBUTTONDOWN = 0x0204,
            WM_RBUTTONUP = 0x0205
        }

        [StructLayout(LayoutKind.Sequential)]
        private struct POINT
        {
            public int x;
            public int y;
        }

        [StructLayout(LayoutKind.Sequential)]
        private struct MSLLHOOKSTRUCT
        {
            public POINT pt;
            public uint mouseData;
            public uint flags;
            public uint time;
            public IntPtr dwExtraInfo;
        }

        private void Listview_no_Deactivate_1(object sender, EventArgs e)
        {
            UnhookWindowsHookEx(_hookID);

        }

    }
}
