
using GelezaStyleMobileApp.Models;
using MobileApp.ApiHandler;
using Newtonsoft.Json;
using Prism.Commands;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace GelezaStyleMobileApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ItemPage : ContentPage
    {
        private ClientAPI api = new ClientAPI();

        private ShoppingCart cart;
        private Items _items;
        private NavigationPage nvPage = new NavigationPage();

        public ItemPage(Items item)
        {
            InitializeComponent();


            _items = item;
            loadItemSizes();
            this.BindingContext = item;


        }
        

        private async void loadItemSizes()
        {
            //var directory = itemImage.Replace(@"\","%");

            cart = (ShoppingCart)Application.Current.Properties["ShoppingCart"];

            
           var sizes = await api.GetItemsSizeByName(_items.ItemName);
            foreach(string strSize in sizes)
            {
                SizePicker.Items.Add(strSize);
            }
          
        }

        private void btnBuy_Clicked(object sender, EventArgs e)
        {
            OrderedItems item = new OrderedItems()
            {
                ItemsOrdered = Convert.ToInt32(AmountPicker.SelectedItem.ToString()),
                ItemID = _items.ItemID

            };

            cart.AddToCart(item);
            DisplayAlert("Shopping cart alert", "Successfully Added Item to cart","OK!");
            
            Navigation.PopModalAsync().Wait(30);
        }
    }
}
