using GelezaStyleService.Models;
using GelezaStyleWebApp.Api;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace GelezaStyleWebApp
{
    public partial class Add_Item : System.Web.UI.Page
    {
        private string fileImagePath;
        ClientApi api = new ClientApi();

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected async void btnCreateItem(object sender, EventArgs e)
        {
            int intUnits, intPrice;

            int.TryParse(inputPrice.Value, out intPrice);
            int.TryParse(inputUnits.Value, out intUnits);
            UploadFile();
            int IsSuccess = -2;
            
                  Items item = new Items()
                      {
                                ItemName = inputName.Value,
                                ItemDescription = inputDescription.Value,
                                ItemIsActive = 1,
                                ItemSize = selectSize.SelectedValue,
                                ItemPrice = intPrice,
                                ItemUnits = intUnits,
                                ItemImage = fileImagePath,
                                ItemCategory = selectCategory.Value,
                                ItemDateAdded = DateTime.Now,
                                ItemGender = selectGender.Value

                            };

                        IsSuccess = await api.CreateItem(item);
                  
            
            

            if (IsSuccess == 0)
            {
                RegistrationBox.Visible = false;
                FailRegistrationAlert.Visible = true;
                ActionButtons.Visible = false;
               // goBackDiv.Visible = true;
            }
            else if (IsSuccess == 1)
            {
                RegistrationBox.Visible = false;
                SuccessRegistrationAlert.Visible = true;
                ActionButtons.Visible = false;
               // goBackDiv.Visible = true;
            }

        }

        private void UploadFile()
        {
            if (FileUpload.HasFile)
            {
                fileImagePath = Server.MapPath("~/Uploads/"+FileUpload.FileName);
              
                FileUpload.SaveAs(Server.MapPath("~/Uploads/" + FileUpload.FileName));

               // fileUploadPositiveAlert.Visible = true;
            }
            else
            {
               // fileUploadNegetiveAlert.Visible = true;
            }

        }
    }
}