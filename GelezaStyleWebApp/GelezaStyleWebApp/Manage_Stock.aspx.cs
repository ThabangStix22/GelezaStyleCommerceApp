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
    public partial class ManageStock : System.Web.UI.Page
    {
        ClientApi api = new ClientApi();

        protected async void Page_Load(object sender, EventArgs e)
        {
            IEnumerable<Items> items = await api.GetAllItems();
            string strProdCard = "";

            if(items.Count() > 0)
            {
                foreach (Items item in items)
                {
                    string strActive = "";
                    if (item.ItemIsActive == 0)
                    {
                        strActive = "Not Active";
                    }
                    else if (item.ItemIsActive == 1)
                    {
                        strActive = "Active";
                    }

                    strProdCard +=
                         $"<div class='col'>" +
                         $"<div class='card h-100'>" +
                         $"<img src='{ImageDisplay(item.ItemImage)}' class='card-img-top' alt='...'>" +
                         $"<div class='card-body'>" +
                         $"<h1 class='card-title'><b>{item.ItemName}</b></h1>" +
                         $"<p class='card-text'>{item.ItemDescription}</p>" +
                         $"</div>" +
                         $"<ul class='list-group list-group-flush'>" +
                         $"<li class='list-group-item'>Price: R{item.ItemPrice}</li>" +
                         $"<li class='list-group-item'>Units Available: {item.ItemUnits} Units</li>" +
                         $"<li class='list-group-item'>Size: {item.ItemSize}</li>" +
                         $"</ul>" +
                         $"<div class='card-body'>" +
                         $"<a href='#' class='btn btn-primary'>Update</a>" +
                         $"</div>" +
                         $"<div class='card-footer'>" +
                         $"<small class='text-muted'>{strActive}</small>" +
                         $"</div>" +
                         $"</div>" +

                         $"</div>";


                }

                ProductCard.InnerHtml = strProdCard;
            }
            else
            {
                strProdCard +=  
                                $"<div class='container-fluid'>" +
                    
                                $"<h1>No Items Available</h1>" +
                                $"</div>";
         

                ProductCard.InnerHtml = strProdCard;
            }
            
        }

        private string ImageDisplay(string image)
        {
            string strFolder = image.Substring(27);

            string [] directoryImage = strFolder.Split('\\');

            return directoryImage[0] + "/" + directoryImage[1];
        }
    }
}