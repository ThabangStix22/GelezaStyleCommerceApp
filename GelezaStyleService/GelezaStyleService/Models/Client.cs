using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GelezaStyleService.Models
{
    public class Client
    {
        public int ClientID { get; set; }
        public string ClientName { get; set; }
        public string ClientSurname { get; set; }
        public string ClientAddress { get; set; } 
        public int ClientPhoneNo { get; set; }
        public string ClientEmail { get; set; }
        public string ClientPassword { get; set; }
        public int ClientIsActive { get; set; }
        public string ClientRole { get; set; }
    
    }
}
