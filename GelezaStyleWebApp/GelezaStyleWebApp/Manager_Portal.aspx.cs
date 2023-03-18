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
    public partial class ManagerPortal : System.Web.UI.Page
    {
        private ClientApi api = new ClientApi();

      
        protected async void Page_Load(object sender, EventArgs e)
        {
            Client client = await api.GetClient(Login._client.ClientID);
            IEnumerable<Orders> newOrders = await api.GetNewOrders();

            string displayMessage = "";
            if(client.ClientRole=="Manager")
            {
                
             displayMessage+= $"<div class='card-header'>" +
                              $"<h3 class='card-title'>Stock level Update</h3>" +
                              $"<div class='card-tools'>" +
                              $"<button type='button' class='btn btn-tool' data-card-widget='collapse' title='Collapse'>" +
                              $"<i class='fas fa-minus'></i>" +
                            $"</button>" +
                            $"<button type='button' class='btn btn-tool' data-card-widget='remove' title='Remove'>" +
                            $"<i class='fas fa-times'></i>" +
                            $"</button>" +
                        $"</div>" +
                        $"</div>" +
                        $"<div class='card-body'>" +
                        $"Stock Levels are looking good!" +
                        $"</div>" +
                        $"<div class='card-footer'>" +
                        $"</div>";
                AlertDisplayMessage.InnerHtml = displayMessage;

            } else if(client.ClientRole == "Clerk" && newOrders!= null){

                displayMessage += $"<div class='card-header'>" +
                             $"<h3 class='card-title'>New Notification!<span class='badge bg-warning float-right'>New</span></h3>" +
                             $"<div class='card-tools'>" +
                             $"<button type='button' class='btn btn-tool' data-card-widget='collapse' title='Collapse'>" +
                             $"<i class='fas fa-minus'></i>" +
                           $"</button>" +
                           $"<button type='button' class='btn btn-tool' data-card-widget='remove' title='Remove'>" +
                           $"<i class='fas fa-times'></i>" +
                           $"</button>" +
                       $"</div>" +
                       $"</div>" +
                       $"<div class='card-body'>" +
                       $"{newOrders.Count()} New Order(s) For a New Style Just Rolled In!" +
                       $"</div>" +
                       $"<div class='card-footer'>" +
                       $"</div>";
              
                AlertDisplayMessage.InnerHtml = displayMessage;

            }
            else if (client.ClientRole == "Clerk" && newOrders == null)
            {
                
                displayMessage += $"<div class='card-header'>" +
                             $"<h3 class='card-title' style='background - color:#33475b' >No New Notification</h3>" +
                           
                             $"<div class='card-tools'>" +
                             $"<button type='button' class='btn btn-tool' data-card-widget='collapse' title='Collapse'>" +
                             $"<i class='fas fa-minus'></i>" +
                           $"</button>" +
                           $"<button type='button' class='btn btn-tool' data-card-widget='remove' title='Remove'>" +
                           $"<i class='fas fa-times'></i>" +
                           $"</button>" +
                       $"</div>" +
                       $"</div>" +
                       $"<div class='card-body'>" +
                       $"We have no new orders." +
                       $"</div>" +
                       $"<div class='card-footer'>" +
                       $"</div>";

                AlertDisplayMessage.InnerHtml = displayMessage;

            }

        }

    }
}