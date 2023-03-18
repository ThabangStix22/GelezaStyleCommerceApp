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
    public partial class Delete_User : System.Web.UI.Page
    {
        ClientApi api = new ClientApi();
        int UserID;
        Client client = new Client();

        protected async void Page_Load(object sender, EventArgs e)
        {
            string strClientID = Request.QueryString["ClientID"];
            int.TryParse(strClientID, out UserID);
            client = await api.GetClient(UserID);

            cardText.InnerText = $"Are you sure you want to delete {client.ClientName} {client.ClientSurname} ?";
        }

        protected async void btn_DeleteClick(object sender, EventArgs e)
        {
            int response = await api.ActivateClient(client.ClientEmail,0);

            if (response == 1)
            {
                cardBody.Visible = false;
                SuccessRegistrationAlert.Visible = true;
            }
            else if (response == -1)
            {

                cardBody.Visible = false;
                FailRegistrationAlert.Visible = true;

            }
        }
    }
}