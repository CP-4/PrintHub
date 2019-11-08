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
using Microsoft.Office.Core;

namespace HubLibrary
{
    public static class PrintJobProcessor
    {
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

        public static async Task<string> GetDocument(string documentUrl)
        {
            string url = documentUrl;

            using (HttpResponseMessage response = await ApiHelper.ApiClient.GetAsync(url))
            {
                if (response.IsSuccessStatusCode)
                {
                    var documentByte = response.Content.ReadAsByteArrayAsync().Result;

                    Debug.WriteLine("Content Type: " + response.Content.GetType());
                    Debug.WriteLine("Document Type: " + documentByte.GetType());

                    string tempDocumentPath = @"I:\pc app\PrintHub\tmp_document\tempdoc.docx";

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


        //private static void AddHeader1(Application WordApp, string HeaderText, WdParagraphAlignment wdAlign)
        //{
        //    Object oMissing = System.Reflection.Missing.Value;
        //    WordApp.ActiveWindow.View.Type = WdViewType.wdOutlineView;
        //    WordApp.ActiveWindow.View.SeekView = WdSeekView.wdSeekPrimaryHeader;
        //    Microsoft.Office.Interop.Word.Shape textBox = WordApp.ActiveDocument.Shapes.AddTextbox(MsoTextOrientation.msoTextOrientationVertical, 150, 10, 40, 40);
        //    textBox.TextFrame.TextRange.Text = HeaderText;
        //    WordApp.ActiveWindow.View.SeekView = WdSeekView.wdSeekMainDocument;
        //}

        private static void AddFooter1(Application WordApp, string fileId, WdParagraphAlignment wdAlign, Document document)
        {

            // TODO: add footer to every page. look into using document.sections() something 

            float pageHeight = (float)document.ActiveWindow.Selection.PageSetup.PageHeight;

            Object oMissing = System.Reflection.Missing.Value;
            WordApp.ActiveWindow.View.Type = WdViewType.wdOutlineView;
            WordApp.ActiveWindow.View.SeekView = WdSeekView.wdSeekPrimaryFooter;
            Microsoft.Office.Interop.Word.Shape tagLineLabel = WordApp.ActiveDocument.Shapes.AddLabel(MsoTextOrientation.msoTextOrientationHorizontal, 100, pageHeight - 25, 150, 25);

            tagLineLabel.TextFrame.TextRange.Text = "Printed with \u2764 by Preasy";
            tagLineLabel.Line.Visible = MsoTriState.msoFalse;

            Microsoft.Office.Interop.Word.Shape fileIdLabel = WordApp.ActiveDocument.Shapes.AddLabel(MsoTextOrientation.msoTextOrientationHorizontal, 0, pageHeight - 25, 75, 25);
            fileIdLabel.TextFrame.TextRange.Text = fileId;
            fileIdLabel.Line.Visible = MsoTriState.msoFalse;

            WordApp.ActiveWindow.View.SeekView = WdSeekView.wdSeekMainDocument;
        }

        public static async void PrintJobThread()
        {
            Microsoft.Office.Interop.Word.Application word = new Microsoft.Office.Interop.Word.Application { Visible = false };
            Microsoft.Office.Interop.Word.Document document;



            Queue<PrintJobModel> printJobQueue = await LoadPrintJobs();
            PrintJobModel printJob;

            int printCount = 0;

            while (true)
            {
                printJobQueue = await LoadPrintJobs();

                while (printJobQueue.Count != 0)
                {
                    Debug.WriteLine("Printing One File");

                    //string url = GlobalConfig.ApiHost + "/media/documents/2019/09/22/print_VioYlRI.docx";
                    //string url = GlobalConfig.ApiHost + "/media/documents/2019/09/22/DE_Report_3.docx";

                    printJob = printJobQueue.Dequeue();
                    string tempDocumentPath = await GetDocument(printJob.Docfile);

                    //string tempDocumentPath = "C:\\Users\\dell\\Desktop\\print.docx";
                    //string tempDocumentPath = @"C:\Program Files\Preasy\PrintHub\print.docx";

                    try
                    {
                        document = word.Documents.Open(FileName: tempDocumentPath);


                        Debug.WriteLine(document.ActiveWindow.Selection.PageSetup.PageHeight);


                        String HeaderText = "# 028 9461";
                        WdParagraphAlignment wdAlign = WdParagraphAlignment.wdAlignParagraphLeft;
                        AddFooter1(word, HeaderText, wdAlign, document);
                        document.PrintOut(OutputFileName: @"I:\pc app\PrintHub\tmp_document\tempdoc.docx");
                        object saveOption = WdSaveOptions.wdDoNotSaveChanges;
                        object originalFormat = WdOriginalFormat.wdOriginalDocumentFormat;
                        object routeDocument = false;
                        document.Close(ref saveOption, ref originalFormat, ref routeDocument);
                        //File.Delete(tempDocumentPath);
                        Debug.WriteLine(printCount++);

                    }
                    catch (Exception e)
                    {
                        Console.WriteLine("{0} Exception caught.", e);
                        word.Quit();
                    }
                    finally
                    {
                        word.Quit();
                    }
                    await UpdatePrintJobStatus(printJob.Id);
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
