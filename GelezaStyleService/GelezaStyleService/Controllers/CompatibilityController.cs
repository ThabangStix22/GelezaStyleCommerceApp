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
    public class CompatibilityController : ControllerBase
    {
        private CompatibilityRepository compaRepo = new CompatibilityRepository();

        [HttpPost("CreateCompatibility")]
        public int CreateCompatibility([FromBody] Compatibility compatibility)
        {
            return compaRepo.CreateCompatibility(compatibility);
        }

        [HttpGet("GetCompatibility/{itemID}")]
        public IEnumerable<Compatibility> GetCompatibility(int itemID)
        {
            return compaRepo.GetCompatibility(itemID);
        }

        //[HttpGet("GetCompatibilities")]
        //public IEnumerable<Compatibility> GetCompatibilities()
        //{
        //    return compaRepo.GetCompatibilities();
        //}

        [HttpDelete("DeleteCompatibility")]
        public int DeleteCompatibility([FromBody]Compatibility compatibility)
        {
            return compaRepo.DeleteCompatibility(compatibility);
        }
    }
}
