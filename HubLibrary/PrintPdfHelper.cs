using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PdfSharp.Pdf;
using MigraDoc.DocumentObjectModel;
using MigraDoc.DocumentObjectModel.Fields;
using MigraDoc.Rendering;



namespace HubLibrary
{
    static class PrintPdfHelper
    {
        public static void MigraDocSample()
        {
            Document document = new Document();

            Section section = document.AddSection();

            var paragraph = new Paragraph();
            
        }
    }
}
