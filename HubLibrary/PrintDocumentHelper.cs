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
using System.Windows;


namespace HubLibrary
{
    public static class PrintDocumentHelper
    {
        public static Microsoft.Office.Interop.Word.Application word = new Microsoft.Office.Interop.Word.Application { Visible = false };


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

            Microsoft.Office.Interop.Word.Shape fileIdLabel = WordApp.ActiveDocument.Shapes.AddLabel(MsoTextOrientation.msoTextOrientationHorizontal, 20, pageHeight - 25, 75, 25);
            fileIdLabel.TextFrame.TextRange.Text = fileId;
            fileIdLabel.Line.Visible = MsoTriState.msoFalse;

            WordApp.ActiveWindow.View.SeekView = WdSeekView.wdSeekMainDocument;
        }

        public static void QuitWord()
        {
            word.Quit();
        }

        public static void PrintWord(string docPath, PrintJobModel printJob)
        {
            try
            {
                Microsoft.Office.Interop.Word.Document document;

                //System.Windows.Forms.MessageBox.Show("Just before word.Document.Open");

                document = word.Documents.Open(FileName: docPath);
                
                Debug.WriteLine(document.ActiveWindow.Selection.PageSetup.PageHeight);

                //String HeaderText = "# 028 9461";
                String HeaderText = "# " + printJob.Id.ToString();
                WdParagraphAlignment wdAlign = WdParagraphAlignment.wdAlignParagraphLeft;
                AddFooterWord(word, HeaderText, wdAlign, document);

                //System.Windows.Forms.MessageBox.Show("Just before word.Document.PrintOut()");

                bool manualDuplexPrint = false;

                switch (printJob.Print_Feature)
                {
                    case "SINGLESIDE":
                        manualDuplexPrint = false;
                        break;

                    case "DOUBLESIDE":
                        manualDuplexPrint = true;
                        break;

                    default:
                        System.Windows.Forms.MessageBox.Show("In PrintDocument switch case: Default");
                        break;
                }

                document.PrintOut(Copies: printJob.Print_Copies, ManualDuplexPrint: manualDuplexPrint);
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
                //System.Windows.Forms.MessageBox.Show("Just before PdfDocument.Load()");

                docPath = PrintPdfHelper.PdfSharpSample(docPath, printJob.Id);

                using (var document = PdfDocument.Load(docPath))
                {
                    //System.Windows.Forms.MessageBox.Show("Just after PrintWord");
                    using (var printDocument = document.CreatePrintDocument())
                    {
                        switch (printJob.Print_Feature)
                        {
                            case "SINGLESIDE":
                                printDocument.PrinterSettings.Duplex = Duplex.Simplex;
                                break;

                            case "DOUBLESIDE":
                                printDocument.PrinterSettings.Duplex = Duplex.Vertical;
                                break;
                                
                            default:
                                System.Windows.Forms.MessageBox.Show("In PrintDocument switch case: Default");
                                break;
                        }

                        printDocument.PrintController = new StandardPrintController();
                        printDocument.PrinterSettings.Copies = (short)printJob.Print_Copies;
                        //System.Windows.Forms.MessageBox.Show("Just before printPdf.Print()");
                        printDocument.Print();
                        //System.Windows.Forms.MessageBox.Show("Just after printPdf.Print()");
                    }
                }
            }
            catch (Exception e)
            {
                System.Windows.Forms.MessageBox.Show(e.Message);
                Debug.WriteLine(e.Message);
            }
        }


        public static void PrintDocument(string docPath, PrintJobModel printJob)
        {
            //System.Windows.Forms.MessageBox.Show("Printing File ID: # " + printJob.Id);
            switch (printJob.DocType)
            {
                case ".doc":
                case ".docx":
                    //System.Windows.Forms.MessageBox.Show("Just before PrintWord");
                    PrintWord(docPath, printJob);
                    //System.Windows.Forms.MessageBox.Show("Just after PrintWord");
                    break;

                case ".pdf":
                    //System.Windows.Forms.MessageBox.Show("Just before PrintPdf");
                    PrintPdf(docPath, printJob);
                    //System.Windows.Forms.MessageBox.Show("Just after PrintPdf");
                    break;

                default:
                    System.Windows.Forms.MessageBox.Show("In PrintDocument switch case: Default");
                    break;
            }
        }
        
    }
}
