using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HubLibrary.Model
{
    class FileModel
    {
        public string FileId { get; set; }
        public int PageCount { get; set; }
        public int PrintPageCount { get; set; }
        public string PrintPages { get; set; }
        public FileType Type { get; set; }
        public decimal PrintCost { get; set; }
    }

    public enum FileType
    {
    }
}
