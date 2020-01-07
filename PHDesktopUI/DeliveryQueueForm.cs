using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using HubLibrary;
using HubLibrary.Model;
using System.Runtime.InteropServices;
using System.Net.Http;
using Squirrel;

namespace PHDesktopUI
{
    public partial class PrintHubForm : Form
    {

        public const int WM_NCLBUTTONDOWN = 0xA1;
        public const int HT_CAPTION = 0x2;

        [DllImportAttribute("user32.dll")]
        public static extern int SendMessage(IntPtr hWnd,
                         int Msg, int wParam, int lParam);
        [DllImportAttribute("user32.dll")]
        public static extern bool ReleaseCapture();
        

        public PrintHubForm()
        {
            InitializeComponent();

            BringToFront();

            //var startTimeSpan = TimeSpan.Zero;
            //var periodTimeSpan = TimeSpan.FromSeconds(3);

            //var timer = new System.Threading.Timer((e) =>
            //{
            //    refreshDeliveryJobQueue();
            //}, null, startTimeSpan, periodTimeSpan);

            checkLoggedInAsync();

            CheckShopIdAsync();

            //CheckForUpdates();

            printQueueControl1.BringToFront();
        }

        private async Task CheckShopIdAsync()
        {
            string id = Properties.Settings.Default.shopId;
            ShopModel shop = await SettingsHelper.FetchShopFromUserAsync();
            
            if (string.IsNullOrWhiteSpace(id))
            {
                if (!string.IsNullOrWhiteSpace(shop.Id))
                {
                    Debug.WriteLine(shop.Id);
                    Properties.Settings.Default.shopId = shop.Id;
                    Properties.Settings.Default.Save();
                }
            }
            else
            {
                if (!string.IsNullOrWhiteSpace(shop.Id))
                {
                    if (id != shop.Id)
                    {
                        Debug.WriteLine(shop.Id);
                        Properties.Settings.Default.shopId = shop.Id;
                        Properties.Settings.Default.Save();
                    }
                }
            }
        }

        public async Task checkLoggedInAsync()
        {
            Debug.WriteLine(Properties.Settings.Default.accessToken);
            Properties.Settings.Default.Upgrade();

            string url = GlobalConfig.ApiHost + "/file2/shop/getprintjobs";

            using (HttpResponseMessage response = await ApiHelper.ApiClient.GetAsync(url))
            {
                //Debug.WriteLine(response.StatusCode);

                if (response.StatusCode == HttpStatusCode.Unauthorized)
                {
                    MessageBox.Show("Please login again.");
                    Properties.Settings.Default.accessToken = "";
                    Properties.Settings.Default.Save();
                    ApiHelper.InitializeClient();
                    var t = new Thread(() => Application.Run(new LoginForm()));
                    t.Start();
                    //this.Hide();
                    this.Close();
                }
                else if (response.StatusCode == HttpStatusCode.OK)
                {
                    
                }
                else
                {
                    throw new Exception(response.ReasonPhrase);
                }
            }
        }

        private async Task CheckForUpdates()
        {
            using (var manager = new UpdateManager(@"https://github.com/CP-4/PreasyWinApp"))
            {
                try
                {
                    await manager.UpdateApp();
                }
                catch (Exception e)
                {
                    MessageBox.Show("Update did not complete successfully.\n" + e.Message);
                }
            }
        }

        private void PrintHubForm_Click(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        private void PrintHub_Load(object sender, EventArgs e)
        {

        }

        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void buttonDoneDeliveryJob_Click(object sender, EventArgs e)
        {

        }

        private void buttonCancleDeliveryJob_Click(object sender, EventArgs e)
        {

        }

        private async void buttonPrintPause_Click(object sender, EventArgs e)
        {
            if (PrintJobProcessor.PausePrint)
            {
                panelPrintPause.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(200)))), ((int)(((byte)(84)))));
                buttonPrintPause.BackColor =  System.Drawing.Color.FromArgb(((int)(((byte)(36)))), ((int)(((byte)(140)))), ((int)(((byte)(80)))));
                buttonPrintPause.Image = global::PHDesktopUI.Properties.Resources.pause_24;
                PrintJobProcessor.PausePrint = false;
                buttonPrintPause.Text = "   Auto accept: ON";
            }
            else
            {
                panelPrintPause.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(36)))), ((int)(((byte)(40)))));
                buttonPrintPause.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(18)))), ((int)(((byte)(20)))));
                this.buttonPrintPause.Image = global::PHDesktopUI.Properties.Resources.play_7_24;
                PrintJobProcessor.PausePrint = true;
                buttonPrintPause.Text = "   Auto accept: OFF";
            }
        }

        private void buttonPrintQueue_Click(object sender, EventArgs e)
        {
            panelSelected.Top = buttonPrintQueue.Top;
            printQueueControl1.RefreshPrintJobQueue(new Queue<PrintJobModel>());
            printQueueControl1.BringToFront();
        }

        private void buttonDeliveryQueue_Click(object sender, EventArgs e)
        {
            panelSelected.Top = buttonDeliveryQueue.Top;
            deliveryQueueControl1.RefreshDeliveryJobQueue();
            deliveryQueueControl1.BringToFront();
        }

        private void buttonClose_Click(object sender, EventArgs e)
        {
            this.Close();
            Application.Exit();
        }

        private void PrintHubForm_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                ReleaseCapture();
                SendMessage(Handle, WM_NCLBUTTONDOWN, HT_CAPTION, 0);
            }
        }

        private void buttonMinimize_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void PrintHubForm_Shown(object sender, EventArgs e)
        {
            //this.WindowState = FormWindowState.Maximized;
        }

        private void buttonSettings_Click(object sender, EventArgs e)
        {
            settingsControl1.LoadSettingsFieldAsync();
            settingsControl1.BringToFront();
        }
        
    }
}
