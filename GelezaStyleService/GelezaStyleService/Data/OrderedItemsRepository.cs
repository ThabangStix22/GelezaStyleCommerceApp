using GelezaStyleService.Interface;
using GelezaStyleService.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Dapper;

namespace GelezaStyleService.Data
{
    public class OrderedItemsRepository : IOrderedItems
    {
        private Connection _con = new Connection();
        private OrderRepository orderRepo = new OrderRepository();

        public int CreateOrderedItems(List<OrderedItems> orderedItems)
        {
            int control = 2;
            int OrderID = orderRepo.GetLastOrderID();
           
            foreach(OrderedItems item in orderedItems)
            {
                try
                {
                    control = _con.OpenConnection()
                .Execute(@"INSERT INTO dbo.OrderedItems 
                        VALUES(" + OrderID + "," + item.ItemID + "," + item.ItemsOrdered + ")",orderedItems);

                }catch (Exception e)
                {
                    control = -1;
                    e.GetBaseException();
                }
                
            }
            return control;
        }
    }
}
