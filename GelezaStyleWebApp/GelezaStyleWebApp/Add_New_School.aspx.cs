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
    public partial class AddNewSchool : System.Web.UI.Page
    {
     

        ClientApi api = new ClientApi();

        protected void Page_Load(object sender, EventArgs e)
        {

        }

      
        protected  async void btnCreateSchool(object sender, EventArgs e)
        {

            Schools school = new Schools()
            {
                SchName = inputName.Value,
                SchAddress = inputAddress.Value,
                SchEmail = inputEmail.Value,
                SchContactNo = extractZero(inputContactNo.Value),
                SchIsActive = 1

            };

        

            int IsSuccess = await api.CreateSchool(school);

            if (IsSuccess == 1)
            {
                RegistrationBox.Visible = false;
                SuccessRegistrationAlert.Visible = true;
                ActionButtons.Visible = false;
               // createSchoolButton.Visible = false;
                //GoBackButton.Visible = true;
            }
            else if (IsSuccess == 0)
            {
                RegistrationBox.Visible = false;
                FailRegistrationAlert.Visible = true;
                ActionButtons.Visible = false;
               // createSchoolButton.Visible = false;
                //GoBackButton.Visible = true;
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