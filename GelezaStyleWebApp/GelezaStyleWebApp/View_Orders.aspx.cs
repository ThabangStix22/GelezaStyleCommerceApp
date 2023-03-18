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
    public partial class View_Orders : System.Web.UI.Page
    {
        private ClientApi api = new ClientApi();


        protected async void Page_Load(object sender, EventArgs e)
        {
            IEnumerable<Orders> newOrders = await api.GetNewOrders();

            string str = "";

            foreach (Orders order in newOrders)
            {
                string IsReady = "";

                if(order.OrderIsReady==0)
                {
                    IsReady = "Not completed";
                    str += $"<tr>" +
                      $"<td>" +
                      $"<div class='icheck-primary'>" +
                      $"<input type='checkbox' value='{order.OrderID}' id='check1'>" +
                      $"<label for='check1'></label>" +
                      $"</div>" +
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
                      $"<td class='project-actions text-right'>" +
                      $"<a class='btn btn-primary btn-sm' href='View_Order_Contents.aspx?OrderID={order.OrderID}'>" +
                      $"<i class='fas fa-folder'>" +
                      $"</i>" +
                      $"View Order" +
                      $"</a>" +
                      $"<a class='btn btn-info btn-sm' href='Complete_Order.aspx?OrderID={order.OrderID}'>" +
                       $"<i class='fas fa-pencil-alt'>" +
                       $"</i>" +
                       $"Complete Order" +
                       $"</a>" +
                      $"</td>" +
                      $"</tr>";
                    OrdersDisplay.InnerHtml = str;
                }
                
            }

            
        }
    }
}