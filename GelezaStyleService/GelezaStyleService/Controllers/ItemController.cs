using GelezaStyleService.Data;
using GelezaStyleService.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace GelezaStyleService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ItemController : ControllerBase
    {
        internal ItemRepository itemRepo = new ItemRepository();

        [HttpPost("CreateItem")]
        public int CreateItem([FromBody]Items Item)
        {
            return itemRepo.CreateItem(Item);
        }

        [HttpGet("GetItem/{Id}")]
        public Items GetItem(int Id)
        {
            return itemRepo.GetItem(Id);
        }

        // GET api/<ItemController>/5
        [HttpGet("GetAllItems")]
        public IEnumerable<Items> GetAllItems()
        {
            return itemRepo.GetAllItems();
        }

        [HttpGet("GetActiveItems/{chActive}")]
        public IEnumerable<Items> GetActiveItems(int chActive)
        {
            return itemRepo.GetActiveItems(chActive);
        }

        [HttpGet("GetItemsBySchool/{schoolId}")]
        public IEnumerable<Items> GetItemsBySchool(int schoolId)
        {
            return itemRepo.GetItemsBySchool(schoolId);
        }

        [HttpGet("GetItemByGender/{gender}")]
        public IEnumerable<Items> GetItemByGender(string gender)
        {
            return itemRepo.GetItemsByGender(gender);
        }

        /*[HttpGet("SearchItems/name")]
        public IEnumerable<Items> SearchItems(string Name)
        {
            return itemRepo.SearchItems(Name);
        }*/

        [HttpGet("GetItemSizesByName/{itemName}")]
        public List<string> GetItemsByImage(string itemName)
        {
            return itemRepo.GetItemSizeByName(itemName);
        }

        [HttpGet("GetItemsByCategory/{category}")]
        public IEnumerable<Items> GetByCategorty(string category)
        {
            return itemRepo.GetByGender(category);
        }


        // PUT api/<ItemController>/5
        [HttpPut("updateItem")]
        public int updateItem(Items Item)
        {
            return itemRepo.updateItem(Item);
        }

        // DELETE api/<ItemController>/5
        [HttpPut("ActivateItem/{Id}/{chActivate}")]
        public int ActivateItem(int Id, int chActivate)
        {
            return itemRepo.ActivateItem(Id, chActivate);
        }

        
    }
}
