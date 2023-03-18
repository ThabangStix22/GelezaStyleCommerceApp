using GelezaStyleMobileApp.PageModels;
using GelezaStyleMobileApp.Views;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace GelezaStyleMobileApp
{
    public partial class MainPage : FlyoutPage
    {
        public MainPage()
        {
            InitializeComponent();
            MenuFlyout.listView.ItemSelected += OnSelectedItem;
        }

        private async void OnSelectedItem(object sender, SelectedItemChangedEventArgs e)
        {
            var item = e.SelectedItem as FlyoutItemPage;

            if(item != null)
            {
                Detail = new NavigationPage((Page)Activator.CreateInstance(item.TargetPage));
                MenuFlyout.listView.SelectedItem = null;
                IsPresented = false;
            }else if(e.SelectedItemIndex ==4 )
            {
                Application.Current.Properties["LoggedUser"] = null;
                Application.Current.Properties["ShoppingCart"] = null;
                MenuFlyout.IsEnabled = false;
                await Navigation.PopToRootAsync(true);

            }
        }
    }
}
