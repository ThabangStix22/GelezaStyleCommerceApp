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
    public partial class Assign_Item_To_School : System.Web.UI.Page
    {
		ClientApi api = new ClientApi();

        protected async void Page_Load(object sender, EventArgs e)
        {
			IEnumerable<Items> ActiveItems = await api.GetActiveItems(1);

			string strItemsAssigned = "";

			if(ActiveItems.Count()>0)
            {
				foreach (Items items in ActiveItems)
				{
					strItemsAssigned += $"<div class='col'>" +
						$"<div class='card h-100'>" +
						$"<img src='{ImageDisplay(items.ItemImage)}' class='card-img-top' alt='...'>" +
						$"<div class='card-body'>" +
						$"<h5 class='card-title'><b>{items.ItemName}</b></h5>" +
						$"<p class='card-text'>{items.ItemDescription}</p>" +
						$"<a href='Assign_New_School.aspx?ItemID={items.ItemID}' class='btn btn-primary'>Assign New School</a>" +
						$"<a href='View_Assigned_Schools.aspx?ItemID={items.ItemID}' class='btn btn-primary'>View Assigned School</a>" +
						$"</div>" +
						$"<div class='card-footer'>" +
						$"<small class='text-muted'></small>" +
						$"</div>" +
						$"</div>" +
						$"</div>";
				}

				AssignedItems.InnerHtml = strItemsAssigned;
            }
            else
            {
				strItemsAssigned += $"<div class='container-fluid'>" +

									$"<h1>No Items Assigned to Schools</h1>" +
									$"</div>";
				AssignedItems.InnerHtml = strItemsAssigned;
			}
			
			
		}


		private string ImageDisplay(string image)
		{
			string strFolder = image.Substring(27);

			string[] directoryImage = strFolder.Split('\\');

			return directoryImage[0] + "/" + directoryImage[1];
		}

		

	}
}