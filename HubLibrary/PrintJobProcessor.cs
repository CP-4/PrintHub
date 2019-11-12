using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using HubLibrary.Model;
using System.Diagnostics;
using PdfiumViewer;


namespace HubLibrary
{
    public static class PrintJobProcessor
    {

        public static bool PausePrint = true;
        public static bool GetPrintJobs = true;


        public static async Task<Queue<PrintJobModel>> LoadPrintJobs()
        {
            string url = GlobalConfig.ApiHost + "/file2/shop/getprintjobs";

            using (HttpResponseMessage response = await ApiHelper.ApiClient.GetAsync(url))
            {
                if (response.IsSuccessStatusCode)
                {
                    Queue<PrintJobModel> printJobsQueue = await response.Content.ReadAsAsync<Queue<PrintJobModel>>();

                    return printJobsQueue;
                }
                else
                {
                    throw new Exception(response.ReasonPhrase);
                }
            }
        }


        public static async Task<string> GetDocument(string documentUrl, string documentType)
        {
            string url = documentUrl;

            using (HttpResponseMessage response = await ApiHelper.ApiClient.GetAsync(url))
            {
                if (response.IsSuccessStatusCode)
                {
                    var documentByte = response.Content.ReadAsByteArrayAsync().Result;

                    Debug.WriteLine("Content Type: " + response.Content.GetType());
                    Debug.WriteLine("Document Type: " + documentByte.GetType());

                    string tempDocumentPath = @"I:\pc app\PrintHub\tmp_document\tempdoc" + documentType;

                    File.Delete(tempDocumentPath);
                    using (Stream file = File.OpenWrite(tempDocumentPath))
                    {
                        file.Write(documentByte, 0, documentByte.Length);
                    }

                    return tempDocumentPath;
                }
                else
                {
                    throw new Exception(response.ReasonPhrase);
                }
            }
        }


        public static async Task<PrintJobModel> UpdatePrintJobStatus(int id)
        {
            string url = GlobalConfig.ApiHost + "/file2/shop/printjobdone/" + $"{ id }";

            using (HttpResponseMessage response = await ApiHelper.ApiClient.GetAsync(url))
            {
                if (response.IsSuccessStatusCode)
                {
                    PrintJobModel printJob = await response.Content.ReadAsAsync<PrintJobModel>();

                    return printJob;
                }
                else
                {
                    throw new Exception(response.ReasonPhrase);
                }
            }
        }


        public static async void PrintJobThread()
        {

            Queue<PrintJobModel> printJobQueue; // = await LoadPrintJobs();
            PrintJobModel printJob;

            int printCount = 0;

            while (!PausePrint)
            {
                printJobQueue = await LoadPrintJobs();
                GetPrintJobs = false;

                while (printJobQueue.Count != 0)
                {
                    Debug.WriteLine("Printing One File");

                    //string url = GlobalConfig.ApiHost + "/media/documents/2019/09/22/print_VioYlRI.docx";

                    printJob = printJobQueue.Dequeue();
                    string tempDocumentPath = await GetDocument(printJob.Docfile, printJob.DocType);

                    //string tempDocumentPath = @"C:\Program Files\Preasy\PrintHub\print.docx";

                    try
                    {
                        PrintDocumentHelper.PrintDocument(tempDocumentPath, printJob);
                        Debug.WriteLine(printCount++);

                        await UpdatePrintJobStatus(printJob.Id);

                        if (PausePrint)
                        {
                            break;
                        }
                    }
                    catch
                    {

                    }

                    GetPrintJobs = true;
                }

                if (PausePrint)
                {
                    break;
                }

                if (!GetPrintJobs)
                {
                    System.Threading.Thread.Sleep(10000);
                }
            }
        }
    }
}
