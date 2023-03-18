using GelezaStyleService.Models;
using GelezaStyleWebApp.Api;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace GelezaStyleWebApp
{
    public partial class UpdateRemoveUser : System.Web.UI.Page
    {
        private ClientApi clientApi = new ClientApi();


        protected async void Page_Load(object sender, EventArgs e)
        {
            IEnumerable<Client> AllClients = await clientApi.GetAllClients();

            string strUserCard = "";
            foreach (Client client in AllClients)
            {
                
                string strIsActive;
                if(client.ClientIsActive==1)
                {
                    strIsActive = "Active";
                }
                else
                {
                    strIsActive = "Not Active";
                }

                strUserCard += $"<div class='col'>" +
                   $"<div class='card' style='width: 18rem;'>" +
                 $"<div class='card-body'>" +
                 $"<h5 class='card-title'>{client.ClientName} {client.ClientSurname}</h5>" +
                 $"<h6 class='card-subtitle mb-2 text-muted'></h6>" +
                 $"<p class='card-text'>{client.ClientAddress}</p>" +
                 $"<ul class='list-group list-group-flush'>" +
                 $"<li class='list-group-item'>{client.ClientPhoneNo}</li>" +
                 $"<li class='list-group-item'>{client.ClientEmail}</li>" +
                 $"<li class='list-group-item'>{client.ClientRole}</li>" +
                 $"</ul>" +
                 $"<div class='card-body'>" +
               $"<a href='ManagerUpdateUser.aspx?UserId={client.ClientID}&UserName={client.ClientName}&UserSurname={client.ClientSurname}' class='btn btn-primary'>Update</a>" +
                //$"<a href='ManagerDeleteUser.aspx?Email={client.ClientEmail}' class='btn btn-primary'>Delete</a>" +
                   $"</div>" +
                  $"<div class='card- footer'>" +
                  $"<small class='text-muted'>{strIsActive}</small>" +
                  $"</div>" +
                   $"</div>" +
                    $"</div>" +
                    $"</div>";
                    
            }

            UserCard.InnerHtml = strUserCard;


        }

        protected void btn_GoBack(object sender, EventArgs e)
        {
            Response.Redirect("ManageUsers.aspx");
        }
    }
}