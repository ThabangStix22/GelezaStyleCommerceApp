using GelezaStyleService.Interface;
using GelezaStyleService.Models;
using System;
using Dapper;
using System.Collections.Generic;
using SmartInventoryAPI.Models;


namespace GelezaStyleService.Data
{
    public class ClientRepository : IClient
    {
        internal Connection _con = new Connection();

        public int CreateClient(Client client)
        {
            //1 -> Success; 0 -> Not Successful; -1 ->Error
            int control = 2;


            //Does client exist?
            Client existClient = _con.OpenConnection().QueryFirstOrDefault<Client>
                                (@"SELECT * 
                                FROM dbo.Client 
                                WHERE ClientEmail='"+client.ClientEmail+"'");

            if (existClient == null)
            {
                try
                {

                control = _con.OpenConnection().Execute($"INSERT INTO dbo.Client "+
                 $"VALUES('{client.ClientName}','{client.ClientSurname}'," +
                 $"'{client.ClientAddress}',{client.ClientPhoneNo },"+
                 $"'{client.ClientEmail}','{Encrypt.HashString(client.ClientPassword)}'," +
                 $"{1},'{client.ClientRole}')",client);

                }catch(Exception e)
                {
                    control = -1;
                    e.GetBaseException();
                   
                }

            }else if(existClient!=null)
            {
                control = 0;   
            }

            _con.CloseConnection();
            return control;   
        }

        
        public Client GetClient(int id)
        {
            //Check if client exists
            Client existClient = null;

            existClient = _con.OpenConnection().QueryFirstOrDefault<Client>(
                $"SELECT * FROM dbo.Client "+
                $" WHERE ClientID={id}");

            _con.CloseConnection();
            return existClient;
        }
        public IEnumerable<Client> GetAllClients()
        {
            //Get All Clients
            IEnumerable<Client> clients = _con.OpenConnection().Query<Client>(
                @"SELECT *
                FROM dbo.Client");

            _con.CloseConnection();

            return clients;
        }
        public int UpdateClient(Client updateClient)
        {
            //Check if client exists
            Client existClient = null;
            int control = 2;

            existClient = _con.OpenConnection().QueryFirstOrDefault<Client>(
                $"SELECT * FROM dbo.Client"+
                $"WHERE ClientID={updateClient.ClientID}");
            
            if(existClient!=null)
            {
                try
                {
                control = _con.OpenConnection().Execute(
                 $"UPDATE dbo.Client "+
                 $"SET ClientName='{updateClient.ClientName}'," +
                   $"ClientSurname='{updateClient.ClientSurname}'," +
                   $"ClientAddress='{updateClient.ClientAddress}'," +
                   $"ClientPhoneNo='{updateClient.ClientPhoneNo}'," +
                   $"ClientEmail='{updateClient.ClientEmail}'," +
                   $"ClientRole='{updateClient.ClientRole}'," +
                   $"ClientPassword= '{Encrypt.HashString(updateClient.ClientPassword)}' "+
                   $"WHERE ClientID={updateClient.ClientID}");
                }catch(Exception e)
                {
                    control = -1;
                    e.GetBaseException();
                }

            }else if (existClient==null)
            {
                control = 0;
            }

            _con.CloseConnection();
            return control;
        }
        public int ActivateClient(string email,int chActivate)
        {
            //Check if Client exists
            Client existClient = null;
            int control = 2;

            existClient = _con.OpenConnection().QueryFirstOrDefault<Client>(
                $"SELECT * FROM dbo.Client "+
                $"WHERE ClientEmail='{email}'");

            if (existClient!=null && chActivate==1)
            {
                try
                {
                    control = _con.OpenConnection().Execute(@"
                    UPDATE dbo.Client
                    SET ClientIsActive="+1+" " +
                    "WHERE ClientEmail='"+email+"'");
                }catch(Exception e)
                {
                    control = -1;
                    e.GetBaseException();
                }
            }else if(existClient != null && chActivate ==0)
            {
                try
                {
                    control = _con.OpenConnection().Execute(@"
                    UPDATE dbo.Client
                    SET ClientIsActive=" + 0 + " "+
                    "WHERE ClientEmail='"+email+"'");
                }
                catch (Exception e)
                {
                    control = -1;
                    e.GetBaseException();
                }
            }
            else if(existClient== null && (chActivate==0||chActivate ==1))
            {
                control = 0;
            }

            _con.CloseConnection();
            return control;
        }

        public Client LoginClient(string Email, string Password)
        {
            //Check if client exists
            Client client = null;
          
            Client existClient = _con.OpenConnection().QueryFirstOrDefault<Client>(
                @"SELECT * FROM dbo.Client
                WHERE ClientEmail='"+Email+"' AND " +
                "ClientPassword='"+Encrypt.HashString(Password)+"'");

            if(existClient!= null)
            {
             client = existClient;
            }else if (existClient == null)
            {
                client = null;
            }
            _con.CloseConnection();
            return client;
        }

    }
}
