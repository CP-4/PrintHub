using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Threading;
using System.Windows.Forms;
using HubLibrary;
using System.Runtime.InteropServices;
using System.Net.Http;
using System.Diagnostics;
using System.Net;

namespace PHDesktopUI
{
    static class Program
    {
        public static string accessToken = "";
        public static bool isLoggedIn = false;

        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            GlobalConfig.ApiHost = Properties.Settings.Default.serverAddress;

            Application.ApplicationExit += new EventHandler(OnApplicationExit);

            //Properties.Settings.Default.accessToken = "asdf";
            //Properties.Settings.Default.Save();
            accessToken = Properties.Settings.Default.accessToken;

            //ApiHelper.InitializeClient();
            //(new LoginForm()).Show();
            //(new PrintHubForm()).Show();
            //Application.Run();

            if (!string.IsNullOrWhiteSpace(accessToken))
            {
                ApiHelper.InitializeClient(accessToken);
                (new PrintHubForm()).Show();
                Application.Run();
            }
            else
            {
                ApiHelper.InitializeClient();
                (new LoginForm()).Show();
                Application.Run();
            }


        }


        private static void OnApplicationExit(object sender, EventArgs e)
        {
            try
            {
                PrintDocumentHelper.QuitWord();
            }
            catch { }
        }
    }
}
