using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HubLibrary.Model
{
    public class ShopModel
    {

        public string Id { get; set; }
        public string Name { get; set; }
        public string Gmap_Url { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Address { get; set; }
        public float Price_SS { get; set; }
        public float Price_DS { get; set; }
        //public List<PersonModel> Owners { get; set; }
        //public int NumOperators { get; set; }
        //public List<PersonModel> Operators { get; set; }
        //public LocationModel ShopLoc { get; set; }
        //public PrintRateModel ShopRate { get; set; }
        //public RevenueModel ShopRevenue { get; set; }
        //public List<Printer> Printers { get; set; }

    }
}
