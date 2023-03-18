using GelezaStyleWebApp.Api;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace GelezaStyleWebApp
{
    public partial class CompleteOrder : System.Web.UI.Page
    {
        ClientApi api = new ClientApi();

        protected void Page_Load(object sender, EventArgs e)
        {
            int OrderID = Convert.ToInt32(Request.QueryString["OrderID"]);
        
            cardText.InnerHtml = $"Before completing order #{OrderID} have you ensured the following:</br>"+
                                 $"-The correct items have been picked out?</br>" +
                                 $"-All items are present?</br>" +
                                 $"-Correct sizes have been picked out?</br>" +
                                 $"-The correct quantities have been taken?";
        }

        protected async void completeOrder_Click(object sender, EventArgs e)
        {
            int OrderID = Convert.ToInt32(Request.QueryString["OrderID"]);
            int response = await api.CompleteOrder(OrderID);


            if (response == 1)
            {
                cardBody.Visible = false;
                SuccessRegistrationAlert.Visible = true;
            }
            else if (response == -1)
            {

                cardBody.Visible = false;
                FailRegistrationAlert.Visible = true;

            }
        }
    }
}