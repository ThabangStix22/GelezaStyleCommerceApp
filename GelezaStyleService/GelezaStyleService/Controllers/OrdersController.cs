using GelezaStyleService.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GelezaStyleService.Data
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrdersController : ControllerBase
    {
        OrderRepository orderRepo = new OrderRepository();

        [HttpPost("CreateOrder")]
        public int CreateOrder([FromBody]Orders orders)
        {
            return orderRepo.CreateOrder(orders);
        }

        [HttpGet("GetOrder/{orderId}")]
        public Orders GetOrder(int orderId)
        {
            return orderRepo.GetOrder(orderId);
        }


        [HttpGet("GetAllOrders")]
        public IEnumerable<Orders> GetAllOrders()
        {
            return orderRepo.GetAllOrders();
        }

        [HttpGet("ViewOrderedItems/{orderID}")]
        public IEnumerable<ViewOrders> viewOrders(int orderID)
        {
            return orderRepo.viewOrders(orderID);
        }

        [HttpGet("GetNewOrders")]
        public IEnumerable<Orders> GetNewOrders()
        {
            return orderRepo.GetNewOrders();
        }

        [HttpGet("GetClientOrders/{clientId}/{isReady}")]
        public IEnumerable<Orders> GetClientOrders(int clientId, int isReady)
        {
            return orderRepo.GetClientOrders(clientId, isReady);
        }

        [HttpGet("GetOrderByDate/{clientId}")]
        public IEnumerable<Orders> GetOrderByDate(int clientId, [FromBody]DateTime date)
        {
            return orderRepo.GetOrderByDate(clientId,date);
        }

        [HttpGet("GetCollectedOrders/{isCollected}")]
        public IEnumerable<Orders> GetOrderCollection(int isCollected)
        {
            return orderRepo.GetOrderCollection(isCollected);
        }

        [HttpGet("GetLastOrderId")]
         public int GetLastOrderID(){
            return orderRepo.GetLastOrderID();
         }

        [HttpGet("GetCompletedOrders")]
        public IEnumerable<Orders> GetCompletedOrders()
        {
            return orderRepo.GetCompletedOrders();
        }

        [HttpPut("CompleteOrder/{OrderId}")]
        public int CompleteOrder(int OrderId)
        {
            return orderRepo.CompleteOrder(OrderId);
        }

        [HttpPut("activateOrder/{orderId}/{chActivate}")]
        public int activateOrder(int orderId,int chActivate)
        {
            return orderRepo.activateOrder(orderId, chActivate);
        }


       
    }
}
