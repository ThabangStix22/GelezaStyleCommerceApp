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
    public partial class ManageSchools : System.Web.UI.Page
    {
        private ClientApi clientApi = new ClientApi();


        protected async void Page_Load(object sender, EventArgs e)
        {
            IEnumerable<Schools> AllActiveSchools = await clientApi.GetActiveSchools(1);

            string strSchoolCard = "";
            foreach (Schools schools in AllActiveSchools.OrderBy(x=>x.SchName))
            {

                
                string strIsActive = "";
                if (schools.SchIsActive == 1)
                {
                    strIsActive = "Active";
                }
                else
                {
                    strIsActive = "Not Active";
                }


                    strSchoolCard +=$"<div class='card card-info'>" +
                                    $"<div class='card-header'>" +
                                    $"<h3 class='card-title'>{schools.SchName}</h3>" +
                                    $"<div class='card-tools'>" +
                                    $"<button type='button' class='btn btn-tool' data-card-widget='collapse' title='Collapse'>" +
                                    $"<i class='fas fa-minus'></i>" +
                                    $"</button>" +
                                    $"</div>" +
                                    $"</div>" +
                                    $"<div class='card-body p-0' style='display: block;'>" +
                                    $"<table class='table'>" +
                                    $"<thead>" +
                                    $"<tr>" +
                                    $"<th>School Address</th>" +
                                    $"<th>Active</th>" +
                                    $"<th>Contact Number</th>" +
                                    $"<th>Email Address</th>" +
                                    $"</tr>" +
                                    $"</thead>" +
                                    $"<tbody>" +
                                    $"<tr>" +
                                    $"<td>{schools.SchAddress}</td>" +
                                    $"<td>{strIsActive}</td>" +
                                    $"<td>0{schools.SchContactNo}</td>" +
                                    $"<td>{schools.SchEmail}</td>" +
                                    $"<td class='text-right py-0 align-middle'>" +
                                    $"<div class='btn-group btn-group-sm'>" +
                                    $"<a href='Update_School.aspx?SchoolID={schools.SchID}' class='btn btn-info'><i class='fas fa-eye'></i></a>" +
                                    $"<a href='Delete_School.aspx?SchoolID={schools.SchID}' class='btn btn-danger'><i class='fas fa-trash'></i></a>" +
                                    $"</div>" +
                                    $"</td>" +
                                    $"</tr></tbody>" +
                                    $"</table>" +
                                    $"</div>" +
                                    $"</div>";

            }

            SchoolCard.InnerHtml = strSchoolCard;


        }

        protected void btn_GoBack(object sender, EventArgs e)
        {
            Response.Redirect("ManageUsers.aspx");
        }
    }

}
