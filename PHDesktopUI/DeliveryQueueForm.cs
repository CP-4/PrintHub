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


namespace PHDesktopUI
{
    public partial class PrintHubForm : Form
    {
        private const string textDeliveredButtom = "Delivered";
        private const string textCancelButton = "X";
        private const string textPrintButton = "Print";

        private Queue<PrintJobModel> deliveryJobQueue;
        private List<Button> deliveredButton = new List<Button>();
        private List<Button> printButton = new List<Button>();
        private List<Button> cancleButton = new List<Button>();
        private List<DataDelivered> data = new List<DataDelivered>();

        public Queue<PrintJobModel> PrintJobQueue = new Queue<PrintJobModel>();
        public string StringPrintJobQueue = "";
        public int TopPrintJobId = 0;


        public class DataDelivered
        {
            public PrintJobModel Job { get; set; }
            public int RowIndex { get; set; }

            public DataDelivered(PrintJobModel job, int rowIndex)
            {
                Job = job;
                RowIndex = rowIndex;
            }         
        }


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

            var progressIndicator = new Progress<Queue<PrintJobModel>>(RefreshPrintJobQueue);

            Task.Factory.StartNew(() => PrintJobProcessor.PrintJobThread(progressIndicator), TaskCreationOptions.LongRunning);


            refreshDeliveryJobQueue();
            //refreshPrintJobQueue(PrintJobQueue);
        }
        

        private void populateDeliveryQueue(Queue<PrintJobModel> deliveryJobQueue)
        {
            PrintJobModel deliveryJob;

            while (deliveryJobQueue.Count != 0)
            {
                deliveryJob = deliveryJobQueue.Dequeue();
                tableLayoutDeliveryQueue.RowCount += 1;

                data.Add(new DataDelivered(deliveryJob, tableLayoutDeliveryQueue.RowCount - 1));

                deliveredButton.Add(new Button() { Text = textDeliveredButtom, Tag = data.Last() });
                deliveredButton.Last().Click += new EventHandler (setDelivered);

                cancleButton.Add(new Button() { Text = textCancelButton, Tag = data.Last() });
                cancleButton.Last().Click += new EventHandler (cancelDelivery);
                
                
                tableLayoutDeliveryQueue.Controls.Add(new Label() { Text = deliveryJob.Id.ToString() }, 0, tableLayoutDeliveryQueue.RowCount - 1);
                tableLayoutDeliveryQueue.Controls.Add(new Label() { Text = GetName(deliveryJob.Docfile) }, 1, tableLayoutDeliveryQueue.RowCount - 1);
                tableLayoutDeliveryQueue.Controls.Add(deliveredButton.Last(), 2, tableLayoutDeliveryQueue.RowCount - 1);
                tableLayoutDeliveryQueue.Controls.Add(cancleButton.Last(), 3, tableLayoutDeliveryQueue.RowCount - 1);

            }
            
        }

        public string GetName(string docfile)
        {
            string[] fileName = docfile.Split('/');

            return fileName.Last();
        }

        private void PrintHubForm_Click(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        private async void cancelDelivery(object sender, EventArgs e)
        {
            Button button = sender as Button;
            DataDelivered data = (DataDelivered)button.Tag;
            try
            {
                await DeliveryJobProcessor.CancelDelivery(data.Job);
                TableLayoutHelper.RemoveArbitraryRow(tableLayoutDeliveryQueue, data.RowIndex);
            }
            catch (WebException ex)
            {
                Debug.WriteLine(ex.Message);
            }
        }

        private async void setDelivered(object sender, EventArgs e)
        {
            Button button = sender as Button;
            DataDelivered data = (DataDelivered)button.Tag;
            try
            {
                await DeliveryJobProcessor.SetDelivered(data.Job);
                TableLayoutHelper.RemoveArbitraryRow(tableLayoutDeliveryQueue, data.RowIndex);
            }
            catch (WebException ex)
            {
                Debug.WriteLine(ex.Message);
            }
            
        }

        private void addDeliveryQueue()
        {
            tableLayoutDeliveryQueue.RowCount += 1;
            tableLayoutDeliveryQueue.Controls.Add(new Label() { Text = "Street, City, State" }, 0, tableLayoutDeliveryQueue.RowCount - 1);
        }
        
        private async void refreshDeliveryJobQueue()
        {

            deliveryJobQueue = await DeliveryJobProcessor.GetDeliveryJobs();
            
            TableLayoutHelper.ClearTable(tableLayoutDeliveryQueue);

            populateDeliveryQueue(deliveryJobQueue);
        }

        public Queue<PrintJobModel> GetPrintJobs()
        {
            return PrintJobProcessor.printJobQueue;
        }

        private async void manualPrintFile(object sender, EventArgs e)
        {
            Button button = sender as Button;
            DataDelivered data = (DataDelivered)button.Tag;
            var progressIndicator = new Progress<Queue<PrintJobModel>>(RefreshPrintJobQueue);

            try
            {
                // TODO: Check if Application is running in manual mode
                // if in manual mode:
                //  print selected file
                //  update printjobstatus
                //  update tablelayout
                // else:
                //  Switch to Manual mode
                //  follow the steps for manual mode
                //  switch to automatic mode

                if (PrintJobProcessor.PausePrint)
                {
                    Task.Factory.StartNew(() => PrintJobProcessor.PrintOneFile(data.Job, progressIndicator), TaskCreationOptions.LongRunning);
                }

                TableLayoutHelper.RemoveArbitraryRow(tableLayoutPrintQueue, data.RowIndex);
            }
            catch (WebException ex)
            {
                Debug.WriteLine(ex.Message);
            }

        }

        private void populatePrintQueue(Queue<PrintJobModel> printJobQueue)
        {
            PrintJobModel printJob;

            while (printJobQueue.Count != 0)
            {
                printJob = printJobQueue.Dequeue();
                tableLayoutPrintQueue.RowCount += 1;

                data.Add(new DataDelivered(printJob, tableLayoutPrintQueue.RowCount - 1));

                printButton.Add(new Button() { Text = textPrintButton, Tag = data.Last() });
                printButton.Last().Click += new EventHandler(manualPrintFile);

                //cancleButton.Add(new Button() { Text = cancel, Tag = data.Last() });
                //cancleButton.Last().Click += new EventHandler(cancelDelivery);


                tableLayoutPrintQueue.Controls.Add(new Label() { Text = printJob.Id.ToString() }, 0, tableLayoutPrintQueue.RowCount - 1);
                tableLayoutPrintQueue.Controls.Add(new Label() { Text = GetName(printJob.Docfile) }, 1, tableLayoutPrintQueue.RowCount - 1);
                tableLayoutPrintQueue.Controls.Add(printButton.Last(), 2, tableLayoutPrintQueue.RowCount - 1);
                //tableLayoutPrintQueue.Controls.Add(cancleButton.Last(), 3, tableLayoutPrintQueue.RowCount - 1);

            }

        }

        private string printJobQueueToString(Queue<PrintJobModel> printJobQueue)
        {
            string toString = "";
            
            for (int i=0; i<printJobQueue.Count; i++)
            {
                toString += printJobQueue.ElementAt(i).Id.ToString() + ",";
            }

            return toString;
        }

        private async void RefreshPrintJobQueue(Queue<PrintJobModel> printJobQueue)
        {
            //PrintJobQueue = GetPrintJobs();

            // TODO: Remove this server call and use formal parameter
            printJobQueue = await PrintJobProcessor.LoadPrintJobs();
            //int topPrintJobId = printJobQueue.Last().Id;
            string stringPrintJobQueue = printJobQueueToString(printJobQueue);
            if (!string.Equals(StringPrintJobQueue, stringPrintJobQueue))
            {
                StringPrintJobQueue = stringPrintJobQueue;

                // Only show this message in Manual operation
                if (PrintJobProcessor.PausePrint && PrintJobProcessor.showMessageBox)
                {
                    MessageBox.Show("We have a new Print Job");
                }
                PrintJobProcessor.showMessageBox = true;
                TableLayoutHelper.ClearTable(tableLayoutPrintQueue);
                populatePrintQueue(printJobQueue);
            }
        }

        private void PrintHub_Load(object sender, EventArgs e)
        {

        }

        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label1_Click_1(object sender, EventArgs e)
        {

        }

        private void buttonDoneDeliveryJob_Click(object sender, EventArgs e)
        {

        }

        private void buttonCancleDeliveryJob_Click(object sender, EventArgs e)
        {

        }

        private void buttonRefreshDeliveryJob_Click(object sender, EventArgs e)
        {

            refreshDeliveryJobQueue();
        }

        private async void buttonPrintPause_Click(object sender, EventArgs e)
        {
            if (PrintJobProcessor.PausePrint)
            {
                PrintJobProcessor.PausePrint = false;
                buttonPrintPause.Text = "Stop Printing";
            }
            else
            {
                PrintJobProcessor.PausePrint = true;
                buttonPrintPause.Text = "Start Printing";
            }
        }

    }
}
