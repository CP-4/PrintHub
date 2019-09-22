using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using HubLibrary.Model;
using Microsoft.Office.Interop.Word;
using System.Diagnostics;

namespace HubLibrary
{
    public static class PrintJobProcessor
    {
        public static async Task<Queue<PrintJobModel>> LoadPrintJobs()
        {
            string url = "http://127.0.0.1:8000/file2/files/";

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

        public static async Task<string> GetDocument(string documentUrl)
        {
            string url = documentUrl;

            using (HttpResponseMessage response = await ApiHelper.ApiClient.GetAsync(url))
            {
                if (response.IsSuccessStatusCode)
                {
                    var documentByte = response.Content.ReadAsByteArrayAsync().Result;

                    //Debug.WriteLine("Content Type: " + response.Content.GetType());
                    //Debug.WriteLine("Document Type: " + documentByte.GetType());

                    string tempDocumentPath = @"I:\pc app\PrintHub\tmp_document\tempdoc.docx";

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
            string url = "http://127.0.0.1:8000/file2/files/updateprintstatus/" + $"{ id }";

            using (HttpResponseMessage response = await ApiHelper.ApiClient.GetAsync(url))
            {
                if (response.IsSuccessStatusCode)
                {
                    PrintJobModel printJobsQueue = await response.Content.ReadAsAsync<PrintJobModel>();

                    return printJobsQueue;
                }
                else
                {
                    throw new Exception(response.ReasonPhrase);
                }
            }
        }

        public static async void PrintJobThread()
        {
            ApiHelper.InitializeClient();
            Microsoft.Office.Interop.Word.Application word = new Microsoft.Office.Interop.Word.Application { Visible = false };
            Microsoft.Office.Interop.Word.Document document;

            Queue<PrintJobModel> printJobsQueue = await LoadPrintJobs();
            PrintJobModel printJob;


            while (true)
            {
                printJobsQueue = await LoadPrintJobs();

                while (printJobsQueue.Count != 0)
                {
                    printJob = printJobsQueue.Dequeue();

                    //string url = "http://127.0.0.1:8000/media/documents/2019/09/22/print.docx";

                    string tempDocumentPath = await GetDocument(printJob.docfile);


                    document = word.Documents.Open(FileName: tempDocumentPath);
                    document.PrintOut();
                    document.Close();

                    await UpdatePrintJobStatus(printJob.id);
                }
            }
                
        }

        // TODO - Request PrintJob <Queue> - Make API call to retrive PrintJobs

        // TODO - 
        // if (isPlay)
        // - get file - API call
        // - print file
        // - generate token
        // - updte PrintJobStatus, tokenId
        // - remove file form PrintJob <Queue>
    }    
}
