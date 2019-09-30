using HubLibrary.Model;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace HubLibrary
{
    static class DeliveryJobProcessor
    {
        public static async Task<Queue<PrintJobModel>> LoadDeliveryJobs()
        {
            string url = "http://127.0.0.1:8000/file2/shop/getdeliveryjobs";

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
            Queue<PrintJobModel> deliveryJobQueue = await LoadDeliveryJobs();

            return deliveryJobQueue;
            
        }
    }
}
