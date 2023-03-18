using GelezaStyleService.Models;
using System.Collections.Generic;

namespace GelezaStyleService.Interface
{
    public interface IPurchasedItem
    {
        public IEnumerable<PurchasedItem> GetOrderedItems(int orderId);
    }
}
