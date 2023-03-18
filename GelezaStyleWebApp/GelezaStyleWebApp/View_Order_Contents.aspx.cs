using GelezaStyleWebApp.Api;
using GelezaStyleWebApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace GelezaStyleWebApp
{
    public partial class View_Order_Contents : System.Web.UI.Page
    {
		private ClientApi api = new ClientApi();

        protected async void Page_Load(object sender, EventArgs e)
        {
            int OrderID = Convert.ToInt32(Request.QueryString["OrderID"]);
            IEnumerable<ViewOrders> orderItems = await api.viewOrders(OrderID);

            string strProdCard = "";

                foreach (ViewOrders orderedItem in orderItems)
                {
                   

                    strProdCard +=
                         $"<div class='col'>" +
                         $"<div class='card h-100'>" +
                         $"<img src='{ImageDisplay(orderedItem.ItemImage)}' class='card-img-top' alt='...'>" +
                         $"<div class='card-body'>" +
                         $"<h1 class='card-title'><b>{orderedItem.ItemName}</b></h1>" +
                         $"<p class='card-text'>{orderedItem.ItemDescription}</p>" +
                         $"</div>" +
                         $"<ul class='list-group list-group-flush'>" +
                         $"<li class='list-group-item'>Gender: {orderedItem.ItemGender}</li>" +
                         $"<li class='list-group-item'>Units Purchased: {orderedItem.ItemsOrdered} Units</li>" +
                         $"<li class='list-group-item'>Size: {orderedItem.ItemSize}</li>" +
                         $"</ul>" +
                         $"<div class='card-body'>" +
                       
                         $"</div>" +
                         $"<div class='card-footer'>" +
                         $"<small class='text-muted'></small>" +
                         $"</div>" +
                         $"</div>" +
                         $"</div>";

                }

                ViewOrderItems.InnerHtml = strProdCard;
            }
            
            

                    private string ImageDisplay(string image)
                    {
                        string strFolder = image.Substring(27);

                        string[] directoryImage = strFolder.Split('\\');

                            return directoryImage[0] + "/" + directoryImage[1];
                        }



    }
}