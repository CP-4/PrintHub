using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HubLibrary.Model
{
    public class PrintJobModel
    {
        public int id { get; set; }
        public string docfile { get; set; }
        public int PrintJobStatus { get; set; }
        

        //public string JobId { get; set; }
        //public string ShopId { get; set; }
        //public string UserId { get; set; }
        //public DateTime JobCreateTime { get; set; }
        //public DateTime JobFetchTime { get; set; }
        //public DateTime JobStartTime { get; set; }
        //public DateTime JobEndTime { get; set; }
        //public LinkedList<FileModel> PrintFileQueue { get; set; }
        //public decimal TotalPrintCost { get; set; }
    }
}
