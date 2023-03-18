using GelezaStyleService.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GelezaStyleService.Interface
{
    interface IOrderedItems
    {
        public int CreateOrderedItems(List<OrderedItems> orderedItems);
    }
}
