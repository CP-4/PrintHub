using HubLibrary.Model;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HubLibrary
{
    public static class DeliveryJobProcessor
    {
        public static async Task<Queue<PrintJobModel>> LoadDeliveryJobs()
        {
            string url = GlobalConfig.ApiHost + "/file2/shop/getdeliveryjobs";

            using (HttpResponseMessage response = await ApiHelper.ApiClient.GetAsync(url))
            {
                if (response.IsSuccessStatusCode)
                {
                    Queue<PrintJobModel> deliveryJobsQueue = await response.Content.ReadAsAsync<Queue<PrintJobModel>>();

                    return deliveryJobsQueue;
                }
                else
                {
                    throw new Exception(response.ReasonPhrase);
                }
            }
        }
        
        public static async Task<Queue<PrintJobModel>> GetDeliveryJobs()
        {

            try
            {
                Queue<PrintJobModel> deliveryJobQueue = await LoadDeliveryJobs();
                return deliveryJobQueue;
            }
            catch
            {
                //MessageBox.Show("Unable to connect to Internet.");
                return new Queue<PrintJobModel>();
            }

            
        }

        public static async Task<PrintJobModel> SetDelivered(PrintJobModel job)
        {
            if (job == null)
            {
                throw new ArgumentNullException(nameof(job));
            }

            string url = GlobalConfig.ApiHost + "/file2/shop/setprintjobstatus/"; // + job.Id.ToString();

            job.PrintJobStatus = 4;
            var jsonJob = JsonConvert.SerializeObject(job);

            var stringContent = new StringContent(jsonJob, Encoding.UTF8, "application/json");

            using (HttpResponseMessage response = await ApiHelper.ApiClient.PutAsync(url, stringContent))
            {
                if (response.IsSuccessStatusCode)
                {
                    PrintJobModel deliveredJob = await response.Content.ReadAsAsync<PrintJobModel>();

                    return deliveredJob;
                }
                else
                {
                    throw new Exception(response.ReasonPhrase);
                }

            }

        }

        public static async Task<PrintJobModel> CancelDelivery(PrintJobModel job)
        {
            if (job == null)
            {
                throw new ArgumentNullException(nameof(job));
            }

            string url = GlobalConfig.ApiHost + "/file2/shop/setprintjobstatus/"; // + job.Id.ToString();

            job.PrintJobStatus = 2;
            var jsonJob = JsonConvert.SerializeObject(job);

            var stringContent = new StringContent(jsonJob, Encoding.UTF8, "application/json");

            using (HttpResponseMessage response = await ApiHelper.ApiClient.PutAsync(url, stringContent))
            {
                if (response.IsSuccessStatusCode)
                {
                    PrintJobModel deliveredJob = await response.Content.ReadAsAsync<PrintJobModel>();

                    return deliveredJob;
                }
                else
                {
                    throw new Exception(response.ReasonPhrase);
                }

            }

        }
    }
}
