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
    public partial class Login : ContentPage
    {
        ClientAPI api = new ClientAPI();
        MainPage main;
        ShoppingCart cart = new ShoppingCart();
        public Login()
        {
            InitializeComponent();
            
        }

        private async void btnSignIn_Clicked(object sender, EventArgs e)
        {
            Client client = await api.LoginClient(txtEmail.Text,txtPassword.Text);

            if (client != null && client.ClientRole == "Customer")
            {
                main = new MainPage();
                Application.Current.Properties["LoggedUser"] = client.ClientID;
                Application.Current.Properties["ShoppingCart"] = cart;
                ClearFields();
                await Navigation.PushModalAsync(main);
            
            }

            else if (txtPassword.Text == null && txtEmail.Text == null)
            {
                await DisplayAlert("Login Failed", "Password and Username field is empty", "Retry", "Exit");
            }
            else if (txtPassword.Text == null || txtEmail.Text == null)
            {
                await DisplayAlert("Login Failed", "Please check if Password and Username field have a value",
                    "Retry", "Exit");
            }
            else if (client == null)
            {
                await DisplayAlert("Login Failed", "Username or Password is incorrect!", "Retry", "Exit");
            }

        }

        private async void TapGestureRecognizer_Tapped(object sender, EventArgs e)
        {

            await Navigation.PushModalAsync(new Register());
        }

        private void ClearFields()
        {
            txtEmail.Text = String.Empty;
            txtPassword.Text = String.Empty;
        }
    }
}