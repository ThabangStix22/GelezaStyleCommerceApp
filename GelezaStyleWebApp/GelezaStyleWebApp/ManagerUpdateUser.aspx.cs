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
    public partial class ManagerUpdateUser : System.Web.UI.Page
    {
        private string strUserId;
        private int UserId;

        private ClientApi api = new ClientApi();

        protected void Page_Load(object sender, EventArgs e)
        {
            string userName = Request.QueryString["UserName"];
            string surname = Request.QueryString["UserSurname"];
            strUserId = Request.QueryString["UserId"];

            int.TryParse(strUserId, out UserId);

            userNameTag.InnerText = userName + " " + surname;
        }

        protected async void  btn_Update(object sender, EventArgs e)
        {
            Client client = await api.GetClient(UserId);
            
            client.ClientRole = inputUserType.Value;
            int IsActive = 0;

             cast(inputActivate.Value, IsActive);
            client.ClientIsActive = IsActive;

            int IsSuccess = await api.UpdateClient(client);

            if(IsSuccess==1)
            {
                UpdateBox.Visible = false;
                SuccessRegistrationAlert.Visible = true;
                goBackDiv.Visible = true;

            }else if(IsSuccess ==0)
            {
                UpdateBox.Visible = false;
                FailRegistrationAlert.Visible = true;
                goBackDiv.Visible = true;
            }

        }

        private void cast(string strNum, int outputVariable)
        {
            int.TryParse(strNum, out outputVariable);
        }
    }
}