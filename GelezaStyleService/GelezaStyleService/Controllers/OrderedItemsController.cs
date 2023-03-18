using GelezaStyleService.Data;
using GelezaStyleService.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GelezaStyleService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderedItemsController : ControllerBase
    {
        private OrderedItemsRepository orderItemsRepo = new OrderedItemsRepository();

        [HttpPost("CreateOrderedItems")]
        public int CreateOrderedItems([FromBody] List<OrderedItems> orderedItems)
        {
            return orderItemsRepo.CreateOrderedItems(orderedItems);
        }
    }
}
