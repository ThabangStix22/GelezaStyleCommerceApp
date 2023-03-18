using GelezaStyleService.Models;
using GelezaStyleWebApp.Api;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace GelezaStyleWebApp
{
    public partial class Assign_New_School : System.Web.UI.Page
    {
        private ClientApi api = new ClientApi();

        private static ListItemCollection listItemCollection = new ListItemCollection();
        private static int itemID { set; get; }


        protected async void Page_Load(object sender, EventArgs e)
        {
           if(!IsPostBack)
            {
               itemID = Convert.ToInt32(Request.QueryString["ItemID"]);
                IEnumerable<Schools> schools = await api.GetActiveSchools(1);

                foreach (Schools school in schools)
                {
                    ListItem listItem = new ListItem();
                    listItem.Value = school.SchID.ToString();
                    listItem.Text = school.SchName;
                    //SelectSchool.Items.Add(listItem);
                    SelectedSchools.Items.Add(listItem);
                }
                

               
            }

        }

        protected async void btnAssignItem(object sender, EventArgs e)
        {
           
            int IsSuccess = -2;

            //List<int> indices = new List<int>(SelectedSchools.GetSelectedIndices());

            foreach (ListItem item in SelectedSchools.Items)
            {
                if (item.Selected)
                {
                    Compatibility comp = new Compatibility();
                    comp.ItemID = itemID;
                    comp.SchID = Convert.ToInt32(item.Value);
                    IsSuccess = await api.CreateCompatibility(comp);
                }
               
            }

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