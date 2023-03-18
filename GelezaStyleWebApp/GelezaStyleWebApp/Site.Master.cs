using GelezaStyleService.Models;
using GelezaStyleWebApp.Api;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace GelezaStyleWebApp
{
    public partial class SiteMaster : MasterPage
    {
        private ClientApi api = new ClientApi();

       

        public void Page_Load(object sender, EventArgs e)
        {
           

            if (Login._client != null && Login._client.ClientRole =="Manager")
            {
                lblLoggedUser.InnerHtml = "Manager | " + Login._client.ClientName + " " + Login._client.ClientSurname;
                AdminControls.Visible = true;
            }
            else if (Login._client != null && Login._client.ClientRole=="Clerk")
            {
                //checkOrders();

                lblLoggedUser.InnerHtml = "Clerk | " +Login._client.ClientName + " " + Login._client.ClientSurname;

                ClerkControls.Visible = true;
            }



        }

        private async void checkOrders()
        {
            IEnumerable<Orders> newOrders = await api.GetNewOrders();
            if (newOrders != null)
            {
                OrderAlert.Visible = true;
            }
        }

        private void cast(string strNum, int outputVariable)
        {
            int.TryParse(strNum, out outputVariable);
        }

        private string buildUserName(string[] strUsernameValues)
        {
            StringBuilder sb = new StringBuilder();
            foreach (string strDisplayValues in strUsernameValues)
            {
                sb.Append(strDisplayValues + " ");
            }

            return sb.ToString();
        }
    }
}