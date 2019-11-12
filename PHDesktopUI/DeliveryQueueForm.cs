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
        private const string delivered = "Delivered";
        private const string cancel = "X";
        private Queue<PrintJobModel> deliveryJobQueue;
        private List<Button> deliveredButton = new List<Button>();
        private List<Button> cancleButton = new List<Button>();
        private List<DataDelivered> data = new List<DataDelivered>();

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

            refreshDeliveryJobQueue();

        }

        private void populateDeliveryQueue(Queue<PrintJobModel> deliveryJobQueue)
        {
            PrintJobModel deliveryJob;

            while (deliveryJobQueue.Count != 0)
            {
                deliveryJob = deliveryJobQueue.Dequeue();
                tableLayoutDeliveryQueue.RowCount += 1;

                data.Add(new DataDelivered(deliveryJob, tableLayoutDeliveryQueue.RowCount - 1));

                deliveredButton.Add(new Button() { Text = delivered, Tag = data.Last() });
                deliveredButton.Last().Click += new EventHandler (setDelivered);

                cancleButton.Add(new Button() { Text = cancel, Tag = data.Last() });
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

            TableLayoutHelper.ClearTable(tableLayoutDeliveryQueue);
            
            deliveryJobQueue = await DeliveryJobProcessor.GetDeliveryJobs();

            populateDeliveryQueue(deliveryJobQueue);
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

        private void buttonPrintPause_Click(object sender, EventArgs e)
        {
            if (PrintJobProcessor.PausePrint)
            {
                PrintJobProcessor.PausePrint = false;
                Thread threadPrintJobProcessor = new Thread(PrintJobProcessor.PrintJobThread);
                threadPrintJobProcessor.Start();
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
