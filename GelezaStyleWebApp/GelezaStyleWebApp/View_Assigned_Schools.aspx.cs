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
    public partial class View_Assigned_Schools : System.Web.UI.Page
    {
       private ClientApi api = new ClientApi();

        protected async void Page_Load(object sender, EventArgs e)
        {
            int itemID = Convert.ToInt32(Request.QueryString["ItemID"]);
            IEnumerable<Compatibility> compatibilities = await api.GetCompatibility(itemID);

            string strViewAssignedSchools = "";

            foreach (Compatibility compatibility in compatibilities)
            {
                Schools school = new Schools();
                school = await api.GetSchool(compatibility.SchID);

                string strIsActive = "";
                if (school.SchIsActive == 1)
                {
                    strIsActive = "Active";
                }
                else
                {
                    strIsActive = "Not Active";
                }


                strViewAssignedSchools += $"<div class='card card-info'>" +
                                $"<div class='card-header'>" +
                                $"<h3 class='card-title'>{school.SchName}</h3>" +
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
                                $"<td>{school.SchAddress}</td>" +
                                $"<td>{strIsActive}</td>" +
                                $"<td>0{school.SchContactNo}</td>" +
                                $"<td>{school.SchEmail}</td>" +
                                $"<td class='text-right py-0 align-middle'>" +
                                $"<div class='btn-group btn-group-sm'>" +
                                $"</div>" +
                                $"</td>" +
                                $"</tr></tbody>" +
                                $"</table>" +
                                $"</div>" +
                                $"</div>";

            }

            ViewAssignedSchools.InnerHtml = strViewAssignedSchools;



        }
    }
}