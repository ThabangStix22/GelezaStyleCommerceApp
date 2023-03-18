using GelezaStyleMobileApp.Models;
using MobileApp.ApiHandler;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace GelezaStyleMobileApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Profile : ContentPage
    {
        private ClientAPI api = new ClientAPI();
        private int _clientID;
        public Profile()
        {
            InitializeComponent();
             _clientID = Convert.ToInt32(Application.Current.Properties["LoggedUser"]);
            loadUserInfo(_clientID);
        }

        private async void  loadUserInfo(int clientID)
        {

            Client existClient = await api.GetClient(clientID);

            txtName.Text = existClient.ClientName;
            txtSurname.Text = existClient.ClientSurname;
            txtAddress.Text = existClient.ClientAddress;
            txtEmail.Text = existClient.ClientEmail;
            txtPhoneNo.Text = "0" + existClient.ClientPhoneNo;

        }


        private async void btnUpdate_Clicked(object sender, EventArgs e)
        {
            Client existClient = new Client()
            {
                ClientID = _clientID,
                ClientAddress = txtAddress.Text,
                ClientEmail = txtEmail.Text,
                ClientName = txtName.Text,
                ClientSurname = txtSurname.Text,
                ClientIsActive = 1,
                ClientPassword = txtPassword.Text,
                ClientPhoneNo = Convert.ToInt32(txtPhoneNo.Text),
                ClientRole = "Customer"
            };

            int IsSuccess = await api.updateClient(existClient);

            switch (IsSuccess)
            {
                case 1:
                    {
                        await DisplayAlert("Update Status Message", "Profile Successfully update!", "Ok.");
                        await Navigation.PushModalAsync(new Offers());
                    }
                    break;
                case -1:
                    {
                        await DisplayAlert("Update Status Message", "Error occured! Email already exists", "Ok.");
                    }
                    break;
                case 0:
                    {
                        await DisplayAlert("Update Status Message", "Profile not updated! User not found", "Ok.");
                    }
                    break;
            }

        }
    }
}