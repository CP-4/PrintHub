using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PdfSharp.Pdf;
using MigraDoc.DocumentObjectModel;
using MigraDoc.DocumentObjectModel.Fields;
using MigraDoc.Rendering;
using System.Diagnostics;
using MigraDoc.DocumentObjectModel.Shapes;
using PdfSharp.Drawing;
using PdfSharp.Pdf.IO;

namespace HubLibrary
{
    public static class PrintPdfHelper
    {
        public static void MigraDocSample()
        {
            var document = new Document();
            var section = document.AddSection();
            var footer = section.Footers.Primary;

            // Add content to footer.
            var paragraph = footer.AddParagraph();
            var t = paragraph.AddText("Printed with Love by Preasy");
            paragraph.Format.Alignment = ParagraphAlignment.Center;
            

            FormattedText ft = paragraph.AddFormattedText("asdf");
            var tf = section.AddTextFrame();
            //tf.Top 

            const bool unicode = false;

            PdfDocumentRenderer pdfRenderer = new PdfDocumentRenderer(unicode);
            
            pdfRenderer.Document = document;
            
            pdfRenderer.RenderDocument();
            
            const string filename = "HelloWorld.pdf";

            pdfRenderer.PdfDocument.Save(filename);
            

            Process.Start(filename);
        }
        

        public static string PdfSharpSample(string oldFile, int fileId)
        {
            //string oldFile = @"I:\pc app\PrintHub\test.pdf";
            //string newFile = @"I:\pc app\PrintHub\out.pdf";

            try
            {
                string footerFileId = "# " + fileId.ToString();

                PdfDocument PDFDoc = PdfReader.Open(oldFile, PdfDocumentOpenMode.Import);
                PdfDocument PDFNewDoc = new PdfDocument();
                XPdfFontOptions options = new XPdfFontOptions(PdfFontEncoding.Unicode);

                for (int Pg = 0; Pg < PDFDoc.Pages.Count; Pg++)
                {
                    PDFNewDoc.AddPage(PDFDoc.Pages[Pg]);
                }

                PdfPage pp = PDFNewDoc.Pages[0];
                XGraphics gfx = XGraphics.FromPdfPage(pp);
                XFont font = new XFont("Arial", 10, XFontStyle.Regular, options);
                gfx.DrawString(footerFileId, font, XBrushes.Black, new XRect(20, 0, pp.Width, pp.Height), XStringFormats.BottomLeft);
                gfx.DrawString("Printed with love by Preasy", font, XBrushes.Black, new XRect(100, 0, pp.Width, pp.Height), XStringFormats.BottomLeft);

                PDFNewDoc.Save(oldFile);
                return oldFile;

            }
            catch (Exception e)
            {
                System.Windows.Forms.MessageBox.Show(e.Message);
                return "";
            }

            //Process.Start(newFile);
        }
    }
}
