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

        //private const string textDeliveredButtom = "Delivered";
        //private const string textCancelButton = "X";
        //private const string textPrintButton = "Print";

        //private Queue<PrintJobModel> deliveryJobQueue;
        //private List<Button> deliveredButton = new List<Button>();
        //private List<Button> cancleButton = new List<Button>();
        //private List<Button> printButton = new List<Button>();
        //private List<DataDelivered> data = new List<DataDelivered>();

        //public Queue<PrintJobModel> PrintJobQueue = new Queue<PrintJobModel>();
        //public string StringPrintJobQueue = "";
        //public int TopPrintJobId = 0;


        //public class DataDelivered
        //{
        //    public PrintJobModel Job { get; set; }
        //    public int RowIndex { get; set; }

        //    public DataDelivered(PrintJobModel job, int rowIndex)
        //    {
        //        Job = job;
        //        RowIndex = rowIndex;
        //    }         
        //}


        public PrintHubForm()
        {
            InitializeComponent();

            //var startTimeSpan = TimeSpan.Zero;
            //var periodTimeSpan = TimeSpan.FromSeconds(3);

            //var timer = new System.Threading.Timer((e) =>
            //{
            //    refreshDeliveryJobQueue();
            //}, null, startTimeSpan, periodTimeSpan);

            //var progressIndicator = new Progress<Queue<PrintJobModel>>(refreshPrintJobQueue);
            //PrintJobProcessor.PrintJobThread(progressIndicator);

            //var progressIndicator = new Progress<Queue<PrintJobModel>>(RefreshPrintJobQueue);

            //Task.Factory.StartNew(() => PrintJobProcessor.PrintJobThread(progressIndicator), TaskCreationOptions.LongRunning);



            //refreshDeliveryJobQueue();
            //refreshPrintJobQueue(PrintJobQueue);

            checkLoggedInAsync();

            printQueueControl1.BringToFront();
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

        //private async void setDelivered(object sender, EventArgs e)
        //{
        //    Button button = sender as Button;
        //    DataDelivered data = (DataDelivered)button.Tag;
        //    try
        //    {
        //        await DeliveryJobProcessor.SetDelivered(data.Job);
        //        TableLayoutHelper.RemoveArbitraryRow(tableLayoutDeliveryQueue, data.RowIndex);
        //    }
        //    catch (WebException ex)
        //    {
        //        Debug.WriteLine(ex.Message);
        //    }

        //}

        //private async void cancelDelivery(object sender, EventArgs e)
        //{
        //    Button button = sender as Button;
        //    DataDelivered data = (DataDelivered)button.Tag;
        //    try
        //    {
        //        await DeliveryJobProcessor.CancelDelivery(data.Job);
        //        TableLayoutHelper.RemoveArbitraryRow(tableLayoutDeliveryQueue, data.RowIndex);
        //    }
        //    catch (WebException ex)
        //    {
        //        Debug.WriteLine(ex.Message);
        //    }
        //}

        //private void populateDeliveryQueue(Queue<PrintJobModel> deliveryJobQueue)
        //{
        //    PrintJobModel deliveryJob;

        //    while (deliveryJobQueue.Count != 0)
        //    {
        //        deliveryJob = deliveryJobQueue.Dequeue();
        //        tableLayoutDeliveryQueue.RowCount += 1;

        //        data.Add(new DataDelivered(deliveryJob, tableLayoutDeliveryQueue.RowCount - 1));

        //        deliveredButton.Add(new Button() { Text = textDeliveredButtom, Tag = data.Last() });
        //        deliveredButton.Last().Click += new EventHandler (setDelivered);

        //        cancleButton.Add(new Button() { Text = textCancelButton, Tag = data.Last() });
        //        cancleButton.Last().Click += new EventHandler (cancelDelivery);


        //        tableLayoutDeliveryQueue.Controls.Add(new Label() { Text = deliveryJob.Id.ToString() }, 0, tableLayoutDeliveryQueue.RowCount - 1);
        //        tableLayoutDeliveryQueue.Controls.Add(new Label() { Text = deliveryJob.Student_Name }, 1, tableLayoutDeliveryQueue.RowCount - 1);
        //        tableLayoutDeliveryQueue.Controls.Add(new Label() { Text = deliveryJob.Pages.ToString() }, 2, tableLayoutDeliveryQueue.RowCount - 1);
        //        tableLayoutDeliveryQueue.Controls.Add(deliveredButton.Last(), 3, tableLayoutDeliveryQueue.RowCount - 1);
        //        tableLayoutDeliveryQueue.Controls.Add(cancleButton.Last(), 4, tableLayoutDeliveryQueue.RowCount - 1);

        //    }

        //}

        //private async void refreshDeliveryJobQueue()
        //{
        //    try
        //    {
        //        deliveryJobQueue = await DeliveryJobProcessor.GetDeliveryJobs();
        //    }
        //    catch
        //    {
        //        //MessageBox.Show("Unable to connect to Internet.");
        //    }

        //    TableLayoutHelper.ClearTable(tableLayoutDeliveryQueue);

        //    populateDeliveryQueue(deliveryJobQueue);
        //}

        private void PrintHubForm_Click(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        //private void addDeliveryQueue()
        //{
        //    tableLayoutDeliveryQueue.RowCount += 1;
        //    tableLayoutDeliveryQueue.Controls.Add(new Label() { Text = "Street, City, State" }, 0, tableLayoutDeliveryQueue.RowCount - 1);
        //}
        


        //private string printJobQueueToString(Queue<PrintJobModel> printJobQueue)
        //{
        //    string toString = "";
            
        //    for (int i=0; i<printJobQueue.Count; i++)
        //    {
        //        toString += printJobQueue.ElementAt(i).Id.ToString() + ",";
        //    }

        //    return toString;
        //}

        //private async void manualPrintFile(object sender, EventArgs e)
        //{
        //    Button button = sender as Button;
        //    DataDelivered data = (DataDelivered)button.Tag;
        //    var progressIndicator = new Progress<Queue<PrintJobModel>>(RefreshPrintJobQueue);

        //    try
        //    {
        //        // TODO: Check if Application is running in manual mode
        //        // if in manual mode:
        //        //  print selected file
        //        //  update printjobstatus
        //        //  update tablelayout
        //        // else:
        //        //  Switch to Manual mode
        //        //  follow the steps for manual mode
        //        //  switch to automatic mode

        //        if (PrintJobProcessor.PausePrint)
        //        {
        //            Task.Factory.StartNew(() => PrintJobProcessor.PrintOneFile(data.Job, progressIndicator), TaskCreationOptions.LongRunning);
        //        }

        //        TableLayoutHelper.RemoveArbitraryRow(tableLayoutPrintQueue, data.RowIndex);
        //    }
        //    catch (WebException ex)
        //    {
        //        Debug.WriteLine(ex.Message);
        //    }

        //}

        //private void populatePrintQueue(Queue<PrintJobModel> printJobQueue)
        //{
        //    PrintJobModel printJob;

        //    while (printJobQueue.Count != 0)
        //    {
        //        printJob = printJobQueue.Dequeue();
        //        tableLayoutPrintQueue.RowCount += 1;
                
                

        //        data.Add(new DataDelivered(printJob, tableLayoutPrintQueue.RowCount - 1));

        //        printButton.Add(new Button() { Text = textPrintButton, Tag = data.Last() });
        //        printButton.Last().Click += new EventHandler(manualPrintFile);

        //        //cancleButton.Add(new Button() { Text = cancel, Tag = data.Last() });
        //        //cancleButton.Last().Click += new EventHandler(cancelDelivery);


        //        tableLayoutPrintQueue.Controls.Add(new Label() { Text = printJob.Id.ToString() }, 0, tableLayoutPrintQueue.RowCount - 1);
        //        tableLayoutPrintQueue.Controls.Add(new Label() { Text = printJob.Student_Name }, 1, tableLayoutPrintQueue.RowCount - 1);
        //        tableLayoutPrintQueue.Controls.Add(new Label() { Text = printJob.Pages.ToString() }, 2, tableLayoutPrintQueue.RowCount - 1);
        //        tableLayoutPrintQueue.Controls.Add(printButton.Last(), 3, tableLayoutPrintQueue.RowCount - 1);
        //        //tableLayoutPrintQueue.Controls.Add(cancleButton.Last(), 3, tableLayoutPrintQueue.RowCount - 1);

        //    }

        //}

        //private async void RefreshPrintJobQueue(Queue<PrintJobModel> printJobQueue)
        //{
        //    //PrintJobQueue = GetPrintJobs();

        //    // TODO: Remove this server call and use formal parameter
        //    printJobQueue = await PrintJobProcessor.LoadPrintJobs();
        //    //int topPrintJobId = printJobQueue.Last().Id;
        //    string stringPrintJobQueue = printJobQueueToString(printJobQueue);
        //    if (!string.Equals(StringPrintJobQueue, stringPrintJobQueue))
        //    {
        //        StringPrintJobQueue = stringPrintJobQueue;

        //        // Only show this message in Manual operation
        //        if (PrintJobProcessor.PausePrint && PrintJobProcessor.showMessageBox)
        //        {
        //            MessageBox.Show("We have a new Print Job");
        //        }
        //        PrintJobProcessor.showMessageBox = true;
        //        TableLayoutHelper.ClearTable(tableLayoutPrintQueue);
        //        populatePrintQueue(printJobQueue);
        //    }
        //}

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

        //private void buttonRefreshDeliveryJob_Click(object sender, EventArgs e)
        //{

        //    refreshDeliveryJobQueue();
        //}

        private async void buttonPrintPause_Click(object sender, EventArgs e)
        {
            if (PrintJobProcessor.PausePrint)
            {
                panelPrintPause.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(36)))), ((int)(((byte)(40)))));
                buttonPrintPause.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(18)))), ((int)(((byte)(20)))));
                buttonPrintPause.Image = global::PHDesktopUI.Properties.Resources.pause_24;
                PrintJobProcessor.PausePrint = false;
                buttonPrintPause.Text = "   Auto accept: ON";
            }
            else
            {
                panelPrintPause.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(200)))), ((int)(((byte)(84)))));
                buttonPrintPause.BackColor =  System.Drawing.Color.FromArgb(((int)(((byte)(36)))), ((int)(((byte)(140)))), ((int)(((byte)(80)))));
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
    }
}
