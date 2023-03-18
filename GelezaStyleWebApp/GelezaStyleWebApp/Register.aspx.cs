using GelezaStyleService.Models;
using GelezaStyleWebApp.Api;
using System;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace GelezaStyleWebApp
{
    public partial class HomePage : System.Web.UI.Page
    {
        private ClientApi clientApi = new ClientApi();

        private int IsSuccess;

        protected void Page_Load(object sender, EventArgs e)
        {
           
        }

        protected async void btn_Register(object sender, EventArgs e)
        {
            //Create client
            Client newClient = new Client()
            {
                ClientName = inputName.Value,
                ClientSurname = inputName.Value,
                ClientAddress = inputAddress.Value,
                ClientPhoneNo = extractZero(inputPhoneNo.Value),
                ClientEmail = inputEmail.Value,
                ClientPassword = inputPassword.Value,
                ClientIsActive = 1,
                ClientRole = "Customer"
            };

            IsSuccess = await clientApi.CreateClient(newClient);

            if (IsSuccess == 1)
            {
                RegistrationBox.Visible = false;
                SuccessRegistrationAlert.Visible = true;
            }else if(IsSuccess == 0)
            {
                RegistrationBox.Visible = false;
                FailRegistrationAlert.Visible = true;
            }
           

        }

        private int extractZero(string PhoneNumber)
        {
            string number = PhoneNumber.Substring(1);
            int PhoneNo;
            int.TryParse(number, out PhoneNo);

            return PhoneNo;
        }

    }
}
