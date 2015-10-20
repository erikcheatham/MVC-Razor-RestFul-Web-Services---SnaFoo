using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SnaFoo.Models
{
    public class RestDataModel
    {
        public struct AddSnack
        {
            public string Name { get; set; }
            public string Location { get; set; }
        }

        public struct GetSnacks
        {
            public int id { get; set; }
            public string name { get; set; }
            public bool optional { get; set; }
            public string purchaselocations { get; set; }
            public int purchaseCount { get; set; }
            public string lastPurchaseDate { get; set; }
        }
    }
}
