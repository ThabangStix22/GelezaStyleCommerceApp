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
    public partial class Login : System.Web.UI.Page
    {
        private ClientApi api = new ClientApi();
        public static Client _client;
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected async void btn_SignIn(object sender, EventArgs e)
        {
            Client client = await api.LoginClient(txtEmail.Value, txtPassword.Value);
            
            if (client != null && client.ClientIsActive==1 && client.ClientRole=="Manager")
            {
                _client= client;

                Response.Redirect($"Manager_Portal.aspx");
            }else if (client != null && client.ClientIsActive == 1 && client.ClientRole == "Clerk")
            {
                _client = client;

                Response.Redirect($"Manager_Portal.aspx");
            }
            else if(client != null && client.ClientIsActive==0)
            {
                WarningAlertMessage.Visible = false;
                CautionMessage.InnerText = "User has been deactivated!";
                CautionMessage.Visible = true;

            }
            else if(client == null)
            {
                CautionMessage.Visible = false;
                WarningAlertMessage.InnerText = "Username/password is incorrect!";
                WarningAlertMessage.Visible = true;
            }
        }
    }
}