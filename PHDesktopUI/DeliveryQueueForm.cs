using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using HubLibrary;
using HubLibrary.Model;

namespace PHDesktopUI
{
    public partial class PrintHubForm : Form
    {
        public PrintHubForm()
        {
            InitializeComponent();

            Queue < PrintJobModel > deliveryJobQueue = await DeliveryJobProcessor.GetDeliveryJobs();
            
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
    }
}
