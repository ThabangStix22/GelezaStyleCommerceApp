using GelezaStyleService.Data;
using GelezaStyleService.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace GelezaStyleService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClientController : ControllerBase
    {
        internal ClientRepository clientRepo = new ClientRepository();

        //POST METHODS
      
        [HttpPost("CreateClient")]
        public int CreateClient([FromBody]Client client)
        {
            return clientRepo.CreateClient(client);
        }

        [HttpGet("GetClient/{id}")]
        public Client GetClient(int id)
        {
          
            return clientRepo.GetClient(id);
        }

        [HttpGet("LoginClient/{Email}/{Password}")]
        public Client LoginClient(string Email, string Password)
        {
            return clientRepo.LoginClient(Email, Password);
        }

        [HttpGet("GetAllClients")]
        public IEnumerable<Client> GetAllClients()
        {
            return clientRepo.GetAllClients();
        }

        [HttpPut("UpdateClient")]
        public int UpdateClient([FromBody]Client updatedClient)
        {
            return clientRepo.UpdateClient(updatedClient);
        }
       

        [HttpPut("ActivateClient/{Email}/{chActivate}")]
        public int ActivateClient(string Email,int chActivate)
        {
            return clientRepo.ActivateClient(Email, chActivate);
        }

    }
}
