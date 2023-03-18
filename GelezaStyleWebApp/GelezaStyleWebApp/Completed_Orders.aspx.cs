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
    public partial class Completed_Orders : System.Web.UI.Page
    {
        private ClientApi api = new ClientApi();

        protected async void Page_Load(object sender, EventArgs e)
        {
            IEnumerable<Orders> completeOrders = await api.GetCompletedOrders();

            string str = "";

            foreach (Orders order in completeOrders)
            {
                string IsReady = "";

                if (order.OrderIsReady == 1)
                {
                    IsReady = "Completed";
                    str += $"<tr>" +
                      $"<td>" +
                     
                      $"</td>" +
                      $"<td>" +
                      $"{order.OrderID}" +
                      $"</td>" +
                      $"<td>" +
                      $"<ul class='list-inline'>" +
                      $"<li class='mailbox-subject'>{order.OrderDate.ToShortDateString()}" +
                      $"</li> " +
                      $"</ul>" +
                      $"</td>" +
                      $"<td class='project-state'>" +
                      $"<span class='badge badge-success'>{IsReady}</span>" +
                      $"</td>" +
                     
                      $"</tr>";
                    OrdersDisplay.InnerHtml = str;
                }

            }
        }
    }
}