using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HubLibrary.Model
{
    class ShopModel
    {

        public string ShopId { get; set; }
        public string ShopName { get; set; }
        public List<PersonModel> Owners { get; set; }
        public int NumOperators { get; set; }
        public List<PersonModel> Operators { get; set; }
        public LocationModel ShopLoc { get; set; }
        public PrintRateModel ShopRate { get; set; }
        public RevenueModel ShopRevenue { get; set; }
        public List<Printer> Printers { get; set; }

    }
}
