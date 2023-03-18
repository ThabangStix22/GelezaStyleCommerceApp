using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GelezaStyleService.Models
{
    public class OrderedItems
    {
        public int OrderID { get; set; }
        public int ItemID { get; set; }
        public int ItemsOrdered { get; set; }
    }
}
