using GelezaStyleService.Models;
using System;
using System.Collections.Generic;

namespace GelezaStyleService.Interface
{
    public interface IOrders
    {
        //CRUD
        public int CreateOrder(Orders orders);

        public IEnumerable<Orders> GetAllOrders();
        public IEnumerable<Orders> GetClientOrders(int clientId,int isReady);
        public IEnumerable<Orders> GetOrderByDate(int clientId, DateTime date);
        public IEnumerable<Orders> GetOrderCollection(int isCollected);
        public Orders GetOrder(int orderId);

        public int CompleteOrder(int OrderID);
        public IEnumerable<Orders> GetNewOrders();
        public int GetLastOrderID();

        public IEnumerable<Orders> GetCompletedOrders();

        public IEnumerable<ViewOrders> viewOrders(int orderID);
        public int activateOrder(int orderId, int chActivate);

    }
}
