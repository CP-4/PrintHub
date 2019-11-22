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
using System.Windows.Forms;

namespace HubLibrary
{
    public static class PrintJobProcessor
    {

        public static bool PausePrint = true;
        public static bool GetPrintJobs = true;
        public static int OngoingPrintJobRequests = 0;
        public static bool showMessageBox = false;
        public static Queue<PrintJobModel> printJobQueue = new Queue<PrintJobModel>();

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

                    //string tempDocumentPath = @"I:\pc app\PrintHub\tmp_document\tempdoc" + documentType;
                    string tempDir = @"C:\ProgramData\Preasy\";
                    string tempDocumentPath = tempDir + @"tempdoc" + documentType;

                    System.IO.Directory.CreateDirectory(tempDir);

                    try
                    {
                        File.Delete(tempDocumentPath);
                    }
                    catch (Exception e)
                    {
                        Debug.WriteLine(e.Message);
                    }

                    try
                    {
                        using (Stream file = File.OpenWrite(tempDocumentPath))
                        {
                            file.Write(documentByte, 0, documentByte.Length);
                        }

                        return tempDocumentPath;
                    }
                    catch (Exception e)
                    {
                        Debug.WriteLine(e.Message);
                        return "Some exception occured while writing file to drive";
                    }
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


        public static async Task PrintJobThread(IProgress<Queue<PrintJobModel>> progress)
        {

            // = await LoadPrintJobs();
            PrintJobModel printJob;

            int printCount = 0;

            while (true)
            {

                if (!PausePrint)
                {
                    printJobQueue = await LoadPrintJobs();
                    // TODO: Implement an Hacky AF solution here as well.
                    progress.Report(printJobQueue);
                    GetPrintJobs = false;
                    while (printJobQueue.Count != 0)
                    {

                        printJob = printJobQueue.Dequeue();

                        progress.Report(printJobQueue);
                        string tempDocumentPath = await GetDocument(printJob.Docfile, printJob.DocType);
                        
                        //string tempDocumentPath = @"C:\Program Files\Preasy\PrintHub\print.docx";

                        try
                        {
                            //MessageBox.Show("Just before PrintDocument");
                            PrintDocumentHelper.PrintDocument(tempDocumentPath, printJob);
                            //MessageBox.Show("Just exited PrintDocument");
                            Debug.WriteLine(printCount++);

                            await UpdatePrintJobStatus(printJob.Id);

                            if (PausePrint)
                            {
                                break;
                            }
                        }
                        catch (Exception e)
                        {
                            MessageBox.Show(e.Message);
                            Debug.WriteLine(e.Message);
                        }

                        //System.Threading.Thread.Sleep(10000);
                        GetPrintJobs = true;
                    }
                    // Automatic Operation Mode
                    if (!GetPrintJobs)
                    {
                        System.Threading.Thread.Sleep(10000);
                    }
                }
                else
                {
                    // Manual Opernation Mode.
                    printJobQueue = await LoadPrintJobs();
                    // TODO: Implement an Hacky AF solution here as well.
                    if (OngoingPrintJobRequests == 0)
                    {
                        progress.Report(printJobQueue);
                    }

                    System.Threading.Thread.Sleep(10000);
                }

            }
        }

        public static async Task PrintOneFile(PrintJobModel printJob, IProgress<Queue<PrintJobModel>> progress)
        {
            OngoingPrintJobRequests += 1;
            string tempDocumentPath = await GetDocument(printJob.Docfile, printJob.DocType);

            try
            {
                
                PrintDocumentHelper.PrintDocument(tempDocumentPath, printJob);

                await UpdatePrintJobStatus(printJob.Id);

                OngoingPrintJobRequests -= 1;
                // TODO: Hacky AF
                //  Why:
                //  - When printButton is used the row is removed from the printQueueTable.
                //    However, printJobStatus for the job is not updated on backend.
                //    So, only refresh table from backend once all ongoing jobs are finished, and the printJobStatus is updated on backend.
                if (OngoingPrintJobRequests == 0)
                {
                    showMessageBox = false;
                    progress.Report(new Queue<PrintJobModel>());
                }
                
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
                Debug.WriteLine(e.Message);
            }
        }
        
    }
}
