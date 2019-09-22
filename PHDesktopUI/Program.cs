using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Threading;
using System.Windows.Forms;
using HubLibrary;

namespace PHDesktopUI
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);


            Thread thr = new Thread(PrintJobProcessor.PrintJobThread);
            thr.Start();



            Application.Run(new PrintHubForm());
        }
    }
}
