using System;
using System.Collections.Generic;
using System.Text;

namespace GelezaStyleMobileApp.Models
{
    public class ShoppingCart
    {
        private List<OrderedItems> OrderedItems = new List<OrderedItems>();

        public ShoppingCart()
        {

        }


        public void ClearCart()
        {
            OrderedItems.Clear();
        }

        public void AddToCart(OrderedItems orderItems)
        {
            OrderedItems.Add(orderItems);
        }

        public List<OrderedItems> GetOrderedItems()
        {
            return OrderedItems;
        }
    }
}
