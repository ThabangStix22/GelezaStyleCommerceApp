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
    public class SchoolController : ControllerBase
    {
        SchoolRepository schoolRepo = new SchoolRepository();

        [HttpPost("CreateSchool")]
        public int CreateSchool([FromBody]Schools school)
        {
            return schoolRepo.CreateSchool(school);
        }

        [HttpGet("GetActiveSchools/{chActive}")]
        public IEnumerable<Schools> GetActiveSchool(int chActive)
        {
            return schoolRepo.GetActiveSchool(chActive);
        }

        [HttpGet("GetSchool/{Id}")]
        public Schools GetSchool(int Id)
        {
            return schoolRepo.GetSchool(Id);
        }

        [HttpGet("GetSchools")]
        public IEnumerable<Schools> GetSchools()
        {
            return schoolRepo.GetSchools();

        }

        [HttpPut("DeleteSchool/{Id}")]
        public int DeleteSchool(int Id)
        {
            return schoolRepo.DeleteSchool(Id);
        }

        [HttpPut("updateSchool")]
        public int updateSchool([FromBody] Schools updateSchool)
        {
            return schoolRepo.updateSchool(updateSchool);
        }

    }
}
