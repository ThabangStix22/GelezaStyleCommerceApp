using GelezaStyleService.Interface;
using GelezaStyleService.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Dapper;

namespace GelezaStyleService.Data
{
    public class OrderRepository : IOrders
    {
        internal Connection _con = new Connection();



        public int CreateOrder(Orders orders)
        {

            int control = 2;
            try
            {

                control = _con.OpenConnection()
                    .Execute(@"INSERT INTO dbo.Orders VALUES(" + orders.ClientID + "," +
                    "" + 0 + ",'" + DateTime.Today + "'," +
                    "" + 1 + "," + 0 + ",'" + null + "'," + 1 + ")", orders);
            }
            catch (Exception e)
            {
                control = -1;
                e.GetBaseException();
            }
            _con.CloseConnection();
            return control;
        }

        public Orders GetOrder(int orderId)
        {
            Orders existingOrder = _con.OpenConnection()
                .QueryFirstOrDefault<Orders>(
                $"SELECT * FROM dbo.Orders " +
                $"WHERE OrderID="+orderId+"");
            _con.CloseConnection();

            return existingOrder;
        }

        public IEnumerable<Orders> GetAllOrders()
        {
            IEnumerable<Orders> existOrders = _con.OpenConnection().Query<Orders>(
                @"SELECT * FROM dbo.Orders");
            _con.CloseConnection();

            return existOrders;
        }

        public IEnumerable<Orders> GetClientOrders(int clientId, int isReady)
        {
            IEnumerable<Orders> existOrders = _con.OpenConnection()
                .Query<Orders>(@"SELECT * FROM dbo.Orders 
                                WHERE ClientID="+clientId+" AND OrderIsReady="+isReady+" AND IsActive=1");
            _con.CloseConnection();
            return existOrders;
        }

        public IEnumerable<Orders> GetOrderByDate(int clientId, DateTime date)
        {
            IEnumerable<Orders> existOrders = _con.OpenConnection()
                .Query<Orders>(@"SELECT * FROM dbo.Orders 
                                WHERE ClientID="+clientId+" AND OrderDate='" + date.Date+ "' AND IsActive=1");
            _con.CloseConnection();
            return existOrders;
        }

         public IEnumerable<Orders> GetNewOrders(){
                 IEnumerable<Orders> existOrders = _con.OpenConnection()
                .Query<Orders>(@"SELECT * FROM dbo.Orders 
                        WHERE OrderPlaced=1 AND OrderIsReady=0
                        AND (OrderDate='"+DateTime.Today+"' OR OrderDate<='"+DateTime.Today+"') AND IsActive=1");
              _con.CloseConnection();
                return existOrders;
         }

        public IEnumerable<Orders> GetOrderCollection(int isCollected)
        {
            IEnumerable<Orders> existOrders = _con.OpenConnection()
                .Query<Orders>(@"SELECT * FROM dbo.Orders 
                                WHERE OrderCollected=" + isCollected + " AND IsActive=1");
            _con.CloseConnection();
            return existOrders;
        }

        public int CompleteOrder(int OrderId)
        {
            Orders existOrders = GetOrder(OrderId);

                int control = 2;

                if(existOrders!=null)
                {
                try
                {
                    control = _con.OpenConnection().Execute($"UPDATE dbo.Orders " +
                                $"SET OrderIsReady={1} "+
                                $"WHERE OrderID={existOrders.OrderID}");
                    }catch(Exception e)
                    {
                        control = -1;
                        e.GetBaseException();
                    }
                }else if(existOrders==null)
                {
                control = 0;
                }

            _con.CloseConnection();
            return control;
        }

        public int activateOrder(int orderId, int chActivate)
        {
            Orders existOrder = GetOrder(orderId);

            int control = 2;

            if (existOrder != null)
            {
                try
                {
                    control = _con.OpenConnection().Execute(@"UPDATE dbo.Orders 
                                    SET IsActive=" + chActivate + " " +
                                     "WHERE OrderID=" + orderId + "");
                }
                catch (Exception e)
                {
                    control = -1;
                    e.GetBaseException();
                }
            }
            else if (existOrder == null)
            {
                control = 0;
            }

            _con.CloseConnection();
            return control;
        }


        public int GetLastOrderID()
        {
            int LastOrderID = _con.OpenConnection()
                .QueryFirstOrDefault<int>($"SELECT TOP 1 " +
                                         $"OrderID "+ 
                                         $"FROM dbo.Orders "+ 
                                        "ORDER BY(OrderID) DESC " );
              _con.CloseConnection();
                return LastOrderID;
        }

        public IEnumerable<ViewOrders> viewOrders(int orderID)
        {
            IEnumerable<ViewOrders> viewOrders = _con.OpenConnection()
               .Query<ViewOrders>($"SELECT ItemName,ItemDescription," +
                                 $"ItemImage,ItemSize,ItemGender,ItemsOrdered " +
                                 $"FROM dbo.Items " +
                                 $"LEFT JOIN dbo.OrderedItems " +
                                 $"ON dbo.Items.ItemID = dbo.OrderedItems.ItemID " +
                                 $"WHERE OrderedItems.OrderID={orderID}");
            _con.CloseConnection();
            return viewOrders;
        }

        public IEnumerable<Orders> GetCompletedOrders()
        {
            IEnumerable<Orders> completeOrders = _con.OpenConnection()
               .Query<Orders>($"SELECT * " +
                              $"FROM dbo.Orders " +
                              $"WHERE OrderIsReady = 1 AND IsActive=1 AND OrderPlaced=1 ");
            _con.CloseConnection();
            return completeOrders;
        }
    }
}
