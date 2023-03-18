using GelezaStyleService.Data;
using GelezaStyleService.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace GelezaStyleService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ItemsPurchasedController : ControllerBase
    {
        private PurchasedItemRepo purchaseRepo = new PurchasedItemRepo();

        [HttpGet("GetPurchasedItemsByOrderId/{orderId}")]
        public IEnumerable<PurchasedItem> GetOrderedItems(int orderId)
        {
            return purchaseRepo.GetOrderedItems(orderId);
        }
    }
}
