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
    public partial class HomePage : ContentPage
    {
        public HomePage()
        {
            InitializeComponent();
        }

        private void Profile_Clicked(object sender, EventArgs e)
        {

        }

        private void Orders_Clicked(object sender, EventArgs e)
        {

        }

        private async void Shopping_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushModalAsync(null);
        }

        private void Invoices_Clicked(object sender, EventArgs e)
        {

        }

        private void Logout_Clicked(object sender, EventArgs e)
        {

        }
    }
}