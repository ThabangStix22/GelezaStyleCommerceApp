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
    public partial class ManageUsers : System.Web.UI.Page
    {
        ClientApi api = new ClientApi();

        protected async void Page_Load(object sender, EventArgs e)
        {
            IEnumerable<Client> AllActiveClients = await api.GetAllClients();

            string strClientCard = "";
            foreach (Client clients in AllActiveClients)
            {


                string strIsActive = "";
                if (clients.ClientIsActive == 1)
                {
                    strIsActive = "Active";
                }
                else
                {
                    strIsActive = "Not Active";
                }


                if (clients.ClientIsActive == 1)
                {
                    strClientCard += $"<div class='card card-info'>" +
                               $"<div class='card-header'>" +
                               $"<h3 class='card-title'>{clients.ClientName} {clients.ClientSurname}</h3>" +
                               $"<div class='card-tools'>" +
                               $"<button type='button' class='btn btn-tool' data-card-widget='collapse' title='Collapse'>" +
                               $"<i class='fas fa-minus'></i>" +
                               $"</button>" +
                               $"</div>" +
                               $"</div>" +
                               $"<div class='card-body p-0' style='display: block;'>" +
                               $"<table class='table'>" +
                               $"<thead>" +
                               $"<tr>" +
                               $"<th>Residential Address</th>" +
                               $"<th>Active</th>" +
                               $"<th>Contact Number</th>" +
                               $"<th>Email Address</th>" +
                               $"<th>Role</th>" +
                               $"</tr>" +
                               $"</thead>" +
                               $"<tbody>" +
                               $"<tr>" +
                               $"<td>{clients.ClientAddress}</td>" +
                               $"<td>{strIsActive}</td>" +
                               $"<td>0{clients.ClientPhoneNo}</td>" +
                               $"<td>{clients.ClientEmail}</td>" +
                               $"<td>{clients.ClientRole}</td>" +
                               $"<td class='text-right py-0 align-middle'>" +
                               $"<div class='btn-group btn-group-sm'>";

                    if (clients.ClientRole == "Clerk")
                    {
                        strClientCard += //$"<a href='Update_User.aspx?ClientID={clients.ClientID}' class='btn btn-info'><i class='fas fa-eye'></i></a>" +
                       $"<a href='Delete_User.aspx?ClientID={clients.ClientID}' class='btn btn-danger'><i class='fas fa-trash'></i></a>";
                    }
                    else if (clients.ClientRole == "Customer")
                    {
                        strClientCard += $"<a href='Delete_User.aspx?ClientID={clients.ClientID}' class='btn btn-danger'><i class='fas fa-trash'></i></a>";
                    }



                    strClientCard += $"</div>" +
                                    $"</td>" +
                                    $"</tr></tbody>" +
                                    $"</table>" +
                                    $"</div>" +
                                    $"</div>";
                }

            }
               

            ClientCard.InnerHtml = strClientCard;
        }

            

    }

}
