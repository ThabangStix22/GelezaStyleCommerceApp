using GelezaStyleService.Models;
using GelezaStyleWebApp.Api;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace GelezaStyleWebApp.Uploads
{
    public partial class Delete_School : System.Web.UI.Page
    {
        ClientApi api = new ClientApi();
        int SchoolID;

        protected async void Page_Load(object sender, EventArgs e)
        {
            string strSchoolID = Request.QueryString["SchoolID"];
            int.TryParse(strSchoolID, out SchoolID);
            Schools school = await api.GetSchool(SchoolID);
            cardText.InnerText = $"Are you sure you want to delete {school.SchName} ?";
        }

        protected async void btn_DeleteClick(object sender, EventArgs e)
        {
            int response = await api.DeleteSchool(SchoolID);
            
            if(response == 1)
            {
                cardBody.Visible = false;
                SuccessRegistrationAlert.Visible = true;
            }else if (response == -1)
            {

                cardBody.Visible = false;
                FailRegistrationAlert.Visible = true;
                
            }

        }
    }
}