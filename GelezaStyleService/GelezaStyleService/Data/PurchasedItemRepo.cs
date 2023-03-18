using GelezaStyleService.Interface;
using GelezaStyleService.Models;
using System.Collections.Generic;
using Dapper;
using System;


namespace GelezaStyleService.Data
{
    public class PurchasedItemRepo : IPurchasedItem
    {
        private Connection _con = new Connection();

        public IEnumerable<Models.PurchasedItem> GetOrderedItems(int orderId)
        {
            IEnumerable<Models.PurchasedItem> existOrders = _con.OpenConnection()
               .Query<Models.PurchasedItem>($"SELECT ItemImage, ItemID, ItemName,ItemsOrdered,ItemSize "+
                                $"From dbo.Items " +
                               $"Inner Join dbo.OrderedItems " +
                               $" ON Items.ItemID= AND ItemsOrdered.ItemID" +
                               $" WHERE dbo.OrderID={orderId}");
            _con.CloseConnection();
            return existOrders;
        }

    }
}
