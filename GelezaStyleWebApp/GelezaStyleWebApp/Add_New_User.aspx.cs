using GelezaStyleService.Models;
using GelezaStyleWebApp.Api;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace GelezaStyleWebApp
{
    public partial class AddUser : System.Web.UI.Page
    {
        private ClientApi clientApi = new ClientApi();

        private int IsSuccess;

        protected void Page_Load(object sender, EventArgs e)
        {

        }


        private int extractZero(string PhoneNumber)
        {
            string number = PhoneNumber.Substring(1);
            int PhoneNo;
            int.TryParse(number, out PhoneNo);

            return PhoneNo;
        }

        protected async void btnCreateUser(object sender, EventArgs e)
        {
            Client newClient = new Client()
            {
                ClientName = inputName.Value,
                ClientSurname = inputSurname.Value,
                ClientAddress = inputAddress.Value,
                ClientPhoneNo = extractZero(inputContactNo.Value),
                ClientEmail = inputEmail.Value,
                ClientPassword = inputPassword.Value,
                ClientIsActive = 1,
                ClientRole = inputRole.Value
            };

            IsSuccess = await clientApi.CreateClient(newClient);

            if (IsSuccess == 1)
            {
                RegistrationBox.Visible = false;
                SuccessRegistrationAlert.Visible = true;
                ActionButtons.Visible = false;

            }
            else if (IsSuccess == 0)
            {
                RegistrationBox.Visible = false;
                FailRegistrationAlert.Visible = true;
                ActionButtons.Visible = false;
            }
        }
    }
}


    