using GelezaStyleService.Models;
using System;
using System.Collections.Generic;

namespace GelezaStyleService.Interface
{
    public interface IClient
    {
        //CRUD
        // 1 -> Success, 0 -> Fail , -1 -> Error
        public int CreateClient(Client client);
        public Client GetClient(int Id);
        public IEnumerable<Client> GetAllClients();
        public int UpdateClient(Client updatedClient);
        public int ActivateClient(string email,int chActivate);

        public Client LoginClient(string Email, string Password);
    }
}
