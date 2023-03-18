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
    public partial class Register : ContentPage
    {
        private ClientAPI api = new ClientAPI();
        private NavigationPage nvPage = new NavigationPage();
        public Register()
        {
            InitializeComponent();
           
        }

        private async void btnRegister_Clicked(object sender, EventArgs e)
        {
           
            Client client = new Client()
            {
                ClientName = txtName.Text,
                ClientSurname = txtSurname.Text,
                ClientAddress = txtAddress.Text,
                ClientEmail = txtEmail.Text,
                ClientIsActive = 1,
                ClientPhoneNo = Convert.ToInt32(txtPhoneNo.Text),
                ClientPassword = txtPassword.Text,
                ClientRole = "Customer"
            };

            int IsSuccess = await api.CreateClient(client);

            switch (IsSuccess)
            {

                case 0:
                    {
                        await DisplayAlert("Registration Alert", "Email already exists!", "OK.");
                       
                    }
                    break;
                case 1:
                    {
                      
                        await DisplayAlert("Registration Alert", "User Successfully Registerd", "OK.");
                        ClearFields();
                        await Navigation.PopModalAsync();
                    }
                    break;
                default:
                    {
                        await DisplayAlert("Registration Alert", "An error occured when registering", "OK.");
                    }
                    break;
            
            }

           
            

            
           
        }

        private void ClearFields()
        {
            txtAddress.Text = String.Empty;
            txtEmail.Text = String.Empty;
            txtName.Text = String.Empty;
            txtPassword.Text = String.Empty;
            txtPhoneNo.Text = String.Empty;
            txtSurname.Text = String.Empty;
        }
    }
}