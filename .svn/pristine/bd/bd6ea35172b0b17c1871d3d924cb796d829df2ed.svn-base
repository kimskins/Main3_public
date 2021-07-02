using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using System.Threading;
using System.Diagnostics;
using System.IO;
using System.Threading;

namespace Dukyou3
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main(string[] args)
        {

            bool bNew;
            Mutex mutex = new Mutex(true, "P_B2_C.exe", out bNew);
          
            if (bNew)
            {
                    Application.EnableVisualStyles();
                    Application.SetCompatibleTextRenderingDefault(false);
                    Application.Run(new login());
                    mutex.ReleaseMutex();
            }
            else
            {
                MessageBox.Show("프로그램 실행중 입니다.");
                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);
                Application.Run(new login());
            }
         }
    }
}
