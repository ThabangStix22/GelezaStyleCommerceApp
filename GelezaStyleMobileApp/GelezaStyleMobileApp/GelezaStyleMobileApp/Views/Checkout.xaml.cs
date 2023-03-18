using GelezaStyleMobileApp.Models;
using GelezaStyleMobileApp.ModelView;
using MobileApp.ApiHandler;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GelezaStyleMobileApp.Models;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using System.Collections.ObjectModel;

namespace GelezaStyleMobileApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Checkout : ContentPage
    {
        private ClientAPI api = new ClientAPI();
        private static ShoppingCart cart = new ShoppingCart();

        private ShoppingCart _cart;

        public Checkout()
        {
            InitializeComponent();
            _cart = (ShoppingCart)Application.Current.Properties["ShoppingCart"];
            loadTotalPriceAsync(_cart);
            OnAppearing();
            //unloadItemsFromCart(_cart);



        }

        async void loadTotalPriceAsync(ShoppingCart _cart)
        {

            int sum = 0;
            foreach (OrderedItems items in _cart.GetOrderedItems())
            {
                Items item = await api.GetItem(items.ItemID);
                sum += item.ItemPrice * items.ItemsOrdered;
            }
            cart = _cart;
            lblPrice.Text = "R" + Convert.ToString(sum);
        }

        //private List<CartItems> cartItems;
        public ObservableCollection<CartItems> cartItems { get; set; }
        protected async override void OnAppearing()
        {

            base.OnAppearing();


            cartItems = new ObservableCollection<CartItems>();

            foreach (OrderedItems items in _cart.GetOrderedItems())
            {
                Items item =  await api.GetItem(items.ItemID);

                cartItems.Add(
                    new CartItems
                    {
                        ItemPrice = item.ItemPrice,
                        ItemName = item.ItemName,
                        Quantity = items.ItemsOrdered
                    });
            }

            itemsPurchased.ItemsSource = cartItems;
        }

       

        private async void btnPurchase_Clicked_1(object sender, EventArgs e)
        {
            GelezaStyleMobileApp.Models.Orders newOrder = new GelezaStyleMobileApp.Models.Orders()
            {
                ClientID = Convert.ToInt32(Application.Current.Properties["LoggedUser"])
            };

            int IsSuccess = await api.CreateOrder(newOrder);
            //int OrderID = await api.GetLastOrderId();

            /*foreach(OrderedItems orderedItems in _cart.GetOrderedItems())
            {
                orderedItems.OrderID = OrderID;
            }*/

            int LoadItemsBought = await api.CreateOrderedItems(_cart.GetOrderedItems());   

            switch (IsSuccess)
            {
                case 1:
                    {
                        await DisplayAlert("Order Message", "Your order has been placed!", "OK");
                        Navigation.PushAsync(new OrdersPage()).Wait(20);
                        break;
                    }
                case 0:
                    {
                        await DisplayAlert("Order Message", "Your order has been cannot be placed!", "OK");
                        Navigation.PopModalAsync().Wait(20);
                        break;
                    }
                case -1:
                    {
                        await DisplayAlert("Order Message", "Error! Server failed. Please try again later.", "OK");
                        break;
                    }
                default:
                    {
                        await DisplayAlert("Order Message", "Operation failed", "OK");
                        break;
                    }

            }
        }
    }
}