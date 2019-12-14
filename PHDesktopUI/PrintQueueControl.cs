using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using HubLibrary;
using HubLibrary.Model;
using System.Diagnostics;
using System.Net;

namespace PHDesktopUI
{
    public partial class PrintQueueControl : UserControl
    {
        private const string textPrintButton = "Print";
        private const string textCancelButton = "X";

        public Queue<PrintJobModel> PrintJobQueue = new Queue<PrintJobModel>();
        public string StringPrintJobQueue = "";
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


        private List<Button> printButton = new List<Button>();
        private List<Button> cancelButton = new List<Button>();

        public PrintQueueControl()
        {
            InitializeComponent();

            var progressIndicator = new Progress<Queue<PrintJobModel>>(RefreshPrintJobQueue);

            Task.Factory.StartNew(() => PrintJobProcessor.PrintJobThread(progressIndicator), TaskCreationOptions.LongRunning);
        }

        private string printJobQueueToString(Queue<PrintJobModel> printJobQueue)
        {
            string toString = "";

            for (int i = 0; i < printJobQueue.Count; i++)
            {
                toString += printJobQueue.ElementAt(i).Id.ToString() + ",";
            }

            return toString;
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

        private async void cancelPrint(object sender, EventArgs e)
        {
            Button button = sender as Button;
            DataDelivered data = (DataDelivered)button.Tag;
            try
            {
                await PrintJobProcessor.CancelPrint(data.Job);
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

                cancelButton.Add(new Button() { Text = textCancelButton, Tag = data.Last() });
                cancelButton.Last().Click += new EventHandler(cancelPrint);

                tableLayoutPrintQueue.Controls.Add(new Label() { Text = printJob.Id.ToString() }, 0, tableLayoutPrintQueue.RowCount - 1);
                tableLayoutPrintQueue.Controls.Add(new Label() { Text = printJob.Student_Name }, 1, tableLayoutPrintQueue.RowCount - 1);
                tableLayoutPrintQueue.Controls.Add(new Label() { Text = printJob.Pages.ToString() }, 2, tableLayoutPrintQueue.RowCount - 1);
                tableLayoutPrintQueue.Controls.Add(printButton.Last(), 3, tableLayoutPrintQueue.RowCount - 1);
                tableLayoutPrintQueue.Controls.Add(cancelButton.Last(), 4, tableLayoutPrintQueue.RowCount - 1);
                //tableLayoutPrintQueue.Controls.Add(cancleButton.Last(), 3, tableLayoutPrintQueue.RowCount - 1);

            }

        }



        public async void RefreshPrintJobQueue(Queue<PrintJobModel> printJobQueue)
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
        
    }
}
