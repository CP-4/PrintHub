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
using System.Net;
using System.Diagnostics;


namespace PHDesktopUI
{
    public partial class DeliveryQueueControl : UserControl
    {
        private const string textDeliveredButtom = "Delivered";
        private const string textCancelButton = "X";

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


        public DeliveryQueueControl()
        {
            InitializeComponent();

            RefreshDeliveryJobQueue();
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

        private void populateDeliveryQueue(Queue<PrintJobModel> deliveryJobQueue)
        {
            PrintJobModel deliveryJob;

            while (deliveryJobQueue.Count != 0)
            {
                deliveryJob = deliveryJobQueue.Dequeue();
                tableLayoutDeliveryQueue.RowCount += 1;

                data.Add(new DataDelivered(deliveryJob, tableLayoutDeliveryQueue.RowCount - 1));

                deliveredButton.Add(new Button() { Text = textDeliveredButtom, Tag = data.Last() });
                deliveredButton.Last().Click += new EventHandler(setDelivered);

                cancleButton.Add(new Button() { Text = textCancelButton, Tag = data.Last() });
                cancleButton.Last().Click += new EventHandler(cancelDelivery);


                tableLayoutDeliveryQueue.Controls.Add(new Label() { Text = deliveryJob.Id.ToString() }, 0, tableLayoutDeliveryQueue.RowCount - 1);
                tableLayoutDeliveryQueue.Controls.Add(new Label() { Text = deliveryJob.Student_Name }, 1, tableLayoutDeliveryQueue.RowCount - 1);
                tableLayoutDeliveryQueue.Controls.Add(new Label() { Text = deliveryJob.Pages.ToString() }, 2, tableLayoutDeliveryQueue.RowCount - 1);
                tableLayoutDeliveryQueue.Controls.Add(deliveredButton.Last(), 3, tableLayoutDeliveryQueue.RowCount - 1);
                tableLayoutDeliveryQueue.Controls.Add(cancleButton.Last(), 4, tableLayoutDeliveryQueue.RowCount - 1);

            }

        }

        public async void RefreshDeliveryJobQueue()
        {
            try
            {
                deliveryJobQueue = await DeliveryJobProcessor.GetDeliveryJobs();
            }
            catch
            {
                //MessageBox.Show("Unable to connect to Internet.");
            }

            TableLayoutHelper.ClearTable(tableLayoutDeliveryQueue);

            populateDeliveryQueue(deliveryJobQueue);
        }

        private void buttonRefreshDeliveryJob_Click(object sender, EventArgs e)
        {
            RefreshDeliveryJobQueue();
        }
    }
}
