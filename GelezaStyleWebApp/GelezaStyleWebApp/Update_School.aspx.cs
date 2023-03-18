using GelezaStyleService.Models;
using GelezaStyleWebApp.Api;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace GelezaStyleWebApp.bootstrap
{
    public partial class ManagerUpdateSchool : System.Web.UI.Page
    {
        ClientApi api = new ClientApi();
        private int SchoolID;

        protected async void Page_Load(object sender, EventArgs e)
        {
            string strSchoolID = Request.QueryString["SchoolID"];
            string SchoolName = Request.QueryString["SchoolName"];
            int.TryParse(strSchoolID, out SchoolID);

            Schools school = await api.GetSchool(SchoolID);

            inputName.Value= school.SchName;
            inputEmail.Value = school.SchEmail;
            inputAddress.Value = school.SchAddress;
            inputContactNo.Value = "0"+school.SchContactNo;


        }

        protected async void btnUpdateSchool(object sender, EventArgs e)
        {
            
            Schools school = await api.GetSchool(SchoolID);

                school.SchName = inputName.Value;
                school.SchAddress = inputAddress.Value;
                int contactNo;

                //school.SchContactNo = inputContactNo.Value;
                int.TryParse(inputContactNo.Value, out contactNo);
                school.SchContactNo = contactNo;
                school.SchEmail = inputEmail.Value;
                 int IsSuccess = await api.UpdateSchool(school);

            if(IsSuccess==0)
            {
                // UpdateBox.Visible = false;
                ActionButtons.Visible = false;
                RegistrationBox.Visible = false;
                FailRegistrationAlert.Visible = true;
                

            }
            else if(IsSuccess == 1)
            {
                ActionButtons.Visible = false;
                RegistrationBox.Visible = false;
                SuccessRegistrationAlert.Visible = true;
               

            }
            
        }

       


    }
}