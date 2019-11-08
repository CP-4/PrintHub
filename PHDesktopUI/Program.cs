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

        public static int isPause { get; set; }
        public static int IsPause
        {
            get { return isPause; }
            set
            {
                isPause = value;
                if (isPause == 1)
                {
                    // DO SOMETHING HERE
                }
            }
        }


        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            ApiHelper.InitializeClient();

            Thread threadPrintJobProcessor = new Thread(PrintJobProcessor.PrintJobThread);
            threadPrintJobProcessor.Start();

            Application.Run(new PrintHubForm());
        }
    }
}
