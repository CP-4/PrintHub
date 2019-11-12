using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Office.Core;
using System.Drawing.Printing;
using Microsoft.Office.Interop.Word;
using System.Diagnostics;
using PdfiumViewer;
using HubLibrary.Model;

namespace HubLibrary
{
    public static class PrintDocumentHelper
    {
        static Microsoft.Office.Interop.Word.Application word = new Microsoft.Office.Interop.Word.Application { Visible = false };
        static Microsoft.Office.Interop.Word.Document document;


        //private static void AddHeader1(Application WordApp, string HeaderText, WdParagraphAlignment wdAlign)
        //{
        //    Object oMissing = System.Reflection.Missing.Value;
        //    WordApp.ActiveWindow.View.Type = WdViewType.wdOutlineView;
        //    WordApp.ActiveWindow.View.SeekView = WdSeekView.wdSeekPrimaryHeader;
        //    Microsoft.Office.Interop.Word.Shape textBox = WordApp.ActiveDocument.Shapes.AddTextbox(MsoTextOrientation.msoTextOrientationVertical, 150, 10, 40, 40);
        //    textBox.TextFrame.TextRange.Text = HeaderText;
        //    WordApp.ActiveWindow.View.SeekView = WdSeekView.wdSeekMainDocument;
        //}

        private static void AddFooterWord(Application WordApp, string fileId, WdParagraphAlignment wdAlign, Document document)
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

        public static void PrintWord(string docPath, PrintJobModel printJob)
        {
            try
            {
                document = word.Documents.Open(FileName: docPath);
                
                Debug.WriteLine(document.ActiveWindow.Selection.PageSetup.PageHeight);

                //String HeaderText = "# 028 9461";
                String HeaderText = "# " + printJob.Id.ToString();
                WdParagraphAlignment wdAlign = WdParagraphAlignment.wdAlignParagraphLeft;
                AddFooterWord(word, HeaderText, wdAlign, document);
                document.PrintOut();
                object saveOption = WdSaveOptions.wdDoNotSaveChanges;
                object originalFormat = WdOriginalFormat.wdOriginalDocumentFormat;
                object routeDocument = false;
                document.Close(ref saveOption, ref originalFormat, ref routeDocument);
                //File.Delete(tempDocumentPath);
            }
            catch (Exception e)
            {
                Console.WriteLine("{0} Exception caught.", e);
                //word.Quit();
            }
            finally
            {
                //word.Quit();
            }
        }


        private static void PrintPdf(string docPath, PrintJobModel printJob)
        {
            try
            {
                // Now print the PDF document
                using (var document = PdfDocument.Load(docPath))
                {
                    using (var printDocument = document.CreatePrintDocument())
                    {
                        printDocument.PrintController = new StandardPrintController();
                        printDocument.Print();
                    }
                }
            }
            catch (Exception e)
            {
                Debug.WriteLine(e.Message);
            }
        }


        public static void PrintDocument(string docPath, PrintJobModel printJob)
        {
            switch (printJob.DocType)
            {

                case ".doc":
                case ".docx":
                    PrintWord(docPath, printJob);
                    break;

                case ".pdf":
                    PrintPdf(docPath, printJob);
                    break;

                default:
                    break;
            }
        }

    }
}
