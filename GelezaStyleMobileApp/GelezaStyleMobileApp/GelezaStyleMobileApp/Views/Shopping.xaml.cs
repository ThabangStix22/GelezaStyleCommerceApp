using GelezaStyleMobileApp.Models;
using MobileApp.ApiHandler;
using Prism.Commands;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace GelezaStyleMobileApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Shopping : ContentPage
    {
        private ClientAPI api = new ClientAPI();

        public ObservableCollection<Items> DisplayItems { get; set; } = new ObservableCollection<Items>();





        public Shopping()
        {
            InitializeComponent();
          
            //ShowItemDetailsCommand = new DelegateCommand<Items>(ShowItemDetails);
        }


       

        protected async override void OnAppearing()
        {
            base.OnAppearing();

            int schoolID = Convert.ToInt32(Application.Current.Properties["SelectedSchool"]);
          

            IEnumerable<Items> compItems = await api.GetActiveItemsBySchoolId(schoolID);

            DisplayItems.Clear();

            foreach (Items item in compItems)
            {
                if((item.ItemDateAdded.Month == DateTime.Now.Month))
                {

                    switch (item.ItemImage)
                    {
                        case "C:\\inetpub\\wwwroot\\Website\\Uploads\\Navy_Blazer.jpg":
                            {

                                item.ItemTempImageHolder = "https://cdn.shopify.com/s/files/1/0066/8686/7508/products/buy-gents-plain-blazer-navy-61-kids-online-on-zalemart-in-south-africa.jpg?v=1609741808&width=600";
                                DisplayItems.Add(item);
                            }
                            break;

                        case "C:\\inetpub\\wwwroot\\Website\\Uploads\\Black_Blazer.jpg":
                            {
                                item.ItemTempImageHolder = "https://assets.woolworthsstatic.co.za/Easy-Care-School-Blazer-BLACK-504579518.jpg?V=fuMr&o=eyJidWNrZXQiOiJ3dy1vbmxpbmUtaW1hZ2UtcmVzaXplIiwia2V5IjoiaW1hZ2VzL2VsYXN0aWNlcmEvcHJvZHVjdHMvaGVyby8yMDE5LTA3LTIyLzUwNDU3OTUxOF9CTEFDS19oZXJvLmpwZyJ9&w=800&q=85";
                                DisplayItems.Add(item);
                            }
                            break;


                        case "C:\\inetpub\\wwwroot\\Website\\Uploads\\Green_Blazer.jpg":
                            {
                                item.ItemTempImageHolder = "https://www.poobienaidoos.co.za/wp-content/uploads/2021/04/73210002-1.png";
                                DisplayItems.Add(item);
                            }
                            break;


                        case "C:\\inetpub\\wwwroot\\Website\\Uploads\\Navy_Dress.jpg":
                            {
                                item.ItemTempImageHolder = "https://i.ebayimg.com/thumbs/images/g/fXwAAOSwBSxbIEkF/s-l300.jpg";
                                DisplayItems.Add(item);
                            }
                            break;

                        case "C:\\inetpub\\wwwroot\\Website\\Uploads\\Scotch_Mono_Dress.jpg":
                            {
                                item.ItemTempImageHolder = "https://www.bigw.com.au/medias/sys_master/images/images/hdb/h73/26519480369182.jpg";
                                DisplayItems.Add(item);
                            }
                            break;


                        case "C:\\inetpub\\wwwroot\\Website\\Uploads\\Black_Jersey.jpg":
                            {
                                item.ItemTempImageHolder = "https://www.pepstores.com/cdn-proxy/prod-pep-cdn/product-images/prod/370_370_O074_web_PNG.webp";
                                DisplayItems.Add(item);
                            }
                            break;



                        case "C:\\inetpub\\wwwroot\\Website\\Uploads\\BlackPullOver.jpg":
                            {
                                item.ItemTempImageHolder = "https://assets.woolworthsstatic.co.za/Sleeveless-V-Neck-Pullover-BLACK-504151272.jpg?V=Abpj&o=eyJidWNrZXQiOiJ3dy1vbmxpbmUtaW1hZ2UtcmVzaXplIiwia2V5IjoiaW1hZ2VzL2VsYXN0aWNlcmEvcHJvZHVjdHMvaGVyby8yMDE4LTA4LTI4LzUwNDE1MTI3Ml9CTEFDS19oZXJvLmpwZyJ9&w=800&q=85";
                                DisplayItems.Add(item);
                            }
                            break;


                        case "C:\\inetpub\\wwwroot\\Website\\Uploads\\Navy_Jersey.jpg":
                            {
                                item.ItemTempImageHolder = "https://www.ackermans.co.za/cdn-proxy/prod-ack-cdn/product-images/prod/600_600_163945_1.webp";
                                DisplayItems.Add(item);
                            }
                            break;

                        case "C:\\inetpub\\wwwroot\\Website\\Uploads\\NavyPullOver.jpg":
                            {
                                item.ItemTempImageHolder = "https://mrfarmer.co.za/wp-content/uploads/2018/03/Vneck-Jersey-Pullover.jpg";
                                DisplayItems.Add(item);
                            }
                            break;



                        case "C:\\inetpub\\wwwroot\\Website\\Uploads\\Blue_Long_Shirt.jpg":
                            {
                                item.ItemTempImageHolder = "https://www.ackermans.co.za/cdn-proxy/prod-ack-cdn/product-images/prod/1100_1100_165876_1.webp";
                                DisplayItems.Add(item);
                            }
                            break;


                        case "C:\\inetpub\\wwwroot\\Website\\Uploads\\Yellow_Long_Shirt.jpg":
                            {
                                item.ItemTempImageHolder = "https://www.ackermans.co.za/cdn-proxy/prod-ack-cdn/product-images/prod/1100_1100_165881_1.webp";
                                DisplayItems.Add(item);
                            }
                            break;

                        case "C:\\inetpub\\wwwroot\\Website\\Uploads\\Yellow_Short_Shirt.jpg":
                            {
                                item.ItemTempImageHolder = "https://www.pepstores.com/cdn-proxy/prod-pep-cdn/product-images/prod/370_370_CJI73-2_web_PNG.webp";
                                DisplayItems.Add(item);
                            }
                            break;



                        case "C:\\inetpub\\wwwroot\\Website\\Uploads\\Khaki_Long_Shirt.jpg":
                            {
                                item.ItemTempImageHolder = "https://assets.woolworthsstatic.co.za/Easy-Care-Long-Sleeve-Boys-School-Shirts-2-Pack-KHAKI-505566102.jpg?V=a9F%24&o=eyJidWNrZXQiOiJ3dy1vbmxpbmUtaW1hZ2UtcmVzaXplIiwia2V5IjoiaW1hZ2VzL2VsYXN0aWNlcmEvcHJvZHVjdHMvaGVyby8yMDIxLTExLTA4LzUwNTU2NjEwMl9LSEFLSV9oZXJvLmpwZyJ9&q=85";
                                DisplayItems.Add(item);
                            }
                            break;


                        case "C:\\inetpub\\wwwroot\\Website\\Uploads\\Blue_Short_Shirt.jpg":
                            {
                                item.ItemTempImageHolder = "https://www.ackermans.co.za/cdn-proxy/prod-ack-cdn/product-images/prod/600_600_165916_1.webp";
                                DisplayItems.Add(item);
                            }
                            break;

                        case "C:\\inetpub\\wwwroot\\Website\\Uploads\\Boys_Bronx.jpg":
                            {
                                item.ItemTempImageHolder = "https://kingsmeadshoes.co.za/wp-content/uploads/2019/11/430102707.jpg";
                                DisplayItems.Add(item);
                            }
                            break;


                        case "C:\\inetpub\\wwwroot\\Website\\Uploads\\Boys_Toughees.jpg":
                            {
                                item.ItemTempImageHolder = "https://cdn.shopify.com/s/files/1/0559/3196/1536/products/4446015_2_00bd4924-02fe-4ab8-b3e4-a4ee715b86de.jpg?v=1664369730";
                                DisplayItems.Add(item);
                            }
                            break;

                        case "C:\\inetpub\\wwwroot\\Website\\Uploads\\Girls_Buccaneer.jpg":
                            {
                                item.ItemTempImageHolder = "https://www.ackermans.co.za/cdn-proxy/prod-ack-cdn/product-images/prod/600_600_800804029910_2.webp";
                                DisplayItems.Add(item);
                            }
                            break;



                        case "C:\\inetpub\\wwwroot\\Website\\Uploads\\Girls_Toughees.jpg":
                            {
                                item.ItemTempImageHolder = "https://cdn.shopify.com/s/files/1/0559/3196/1536/products/5446116_2.jpg?v=1664369831";
                                DisplayItems.Add(item);
                            }
                            break;


                        case "C:\\inetpub\\wwwroot\\Website\\Uploads\\Grasshoppers.jpg":
                            {
                                item.ItemTempImageHolder = "https://assets.superbalistcdn.co.za/500x720/filters:quality(75):format(jpg)/1888027/original.jpg";
                                DisplayItems.Add(item);
                            }
                            break;


                        case "C:\\inetpub\\wwwroot\\Website\\Uploads\\Grey_School_Skirt.jpg":
                            {
                                item.ItemTempImageHolder = "https://www.ackermans.co.za/cdn-proxy/prod-ack-cdn/product-images/prod/600_600_163951_1.webp";
                                DisplayItems.Add(item);
                            }
                            break;

                        case "C:\\inetpub\\wwwroot\\Website\\Uploads\\Black_Tie.jpg":
                            {
                                item.ItemTempImageHolder = "https://litb-cgis.rightinthebox.com/images/640x853/202205/bps/product/inc/ronnln1651807276628.jpg?fmt=webp&v=1";
                                DisplayItems.Add(item);
                            }
                            break;



                        case "C:\\inetpub\\wwwroot\\Website\\Uploads\\Navy_Tie.webp":
                            {
                                item.ItemTempImageHolder = "https://litb-cgis.rightinthebox.com/images/640x853/202205/bps/product/inc/bkngum1651807280109.jpg?fmt=webp&v=1";
                                DisplayItems.Add(item);
                            }
                            break;



                        case "C:\\inetpub\\wwwroot\\Website\\Uploads\\Green_Tie.jpg":
                            {
                                item.ItemTempImageHolder = "https://shopcentre.co.za/gallery/00/00/18/00008119_large-1000.jpg";
                                DisplayItems.Add(item);
                            }
                            break;


                        case "C:\\inetpub\\wwwroot\\Website\\Uploads\\Maroon_Tie.jpg":
                            {
                                item.ItemTempImageHolder = "https://shopcentre.co.za/gallery/00/00/18/00008118_large-1000.jpg";
                                DisplayItems.Add(item);
                            }
                            break;


                        case "C:\\inetpub\\wwwroot\\Website\\Uploads\\Blue_Tie.jpg":
                            {
                                item.ItemTempImageHolder = "https://litb-cgis.rightinthebox.com/images/640x853/202205/bps/product/inc/dcamvr1651807282143.jpg?fmt=webp&v=1";
                                DisplayItems.Add(item);
                            }
                            break;


                        case "C:\\inetpub\\wwwroot\\Website\\Uploads\\Red_Tie.jpg":
                            {
                                item.ItemTempImageHolder = "https://litb-cgis.rightinthebox.com/images/640x853/202205/bps/product/inc/zhdbyw1651807281036.jpg?fmt=webp&v=1";
                                DisplayItems.Add(item);
                            }
                            break;


                        case "C:\\inetpub\\wwwroot\\Website\\Uploads\\Pink_Tie.jpg":
                            {
                                item.ItemTempImageHolder = "https://litb-cgis.rightinthebox.com/images/640x853/202205/bps/product/inc/cnbqlw1651807283648.jpg?fmt=webp&v=1";
                                DisplayItems.Add(item);
                            }
                            break;



                        case "C:\\inetpub\\wwwroot\\Website\\Uploads\\Black_Socks.jpg":
                            {
                                item.ItemTempImageHolder = "https://cottonon.com/dw/image/v2/BBDS_PRD/on/demandware.static/-/Sites-catalog-master-factorie/default/dw563c580d/525051/525051-110-2.jpg?sw=640&sh=960&sm=fit";
                                DisplayItems.Add(item);
                            }
                            break;


                        case "C:\\inetpub\\wwwroot\\Website\\Uploads\\Grey_Socks.jpg":
                            {
                                item.ItemTempImageHolder = "https://media.takealot.com/covers_tsins/51925689/51925689-1-pdpxl.jpg";
                                DisplayItems.Add(item);
                            }
                            break;


                        case "C:\\inetpub\\wwwroot\\Website\\Uploads\\White_Socks.jpg":
                            {
                                item.ItemTempImageHolder = "https://cottonon.com/dw/image/v2/BBDS_PRD/on/demandware.static/-/Sites-catalog-master-factorie/default/dw6363073d/525051/525051-113-2.jpg?sw=640&sh=960&sm=fit";

                                DisplayItems.Add(item);
                            }
                            break;



                        case "C:\\inetpub\\wwwroot\\Website\\Uploads\\Grey_School_Trouser.jpg":
                            {
                                item.ItemTempImageHolder = "https://litb-cgis.rightinthebox.com/images/640x853/202110/bps/product/inc/zmocta1635322316504.jpg?fmt=webp&v=1";

                                DisplayItems.Add(item);
                            }
                            break;




                        case "C:\\inetpub\\wwwroot\\Website\\Uploads\\Navy_Trouser.jpeg":
                            {
                                item.ItemTempImageHolder = "https://5.imimg.com/data5/KX/KE/MY-10521202/mens-formal-trousers-500x500.jpg";

                                DisplayItems.Add(item);
                            }
                            break;


                        case "C:\\inetpub\\wwwroot\\Website\\Uploads\\Black_School_Trouser.jpg":
                            {
                                item.ItemTempImageHolder = "https://litb-cgis.rightinthebox.com/images/640x853/202208/bps/product/inc/pbaxae1660011853425.jpg?fmt=webp&v=1";

                                DisplayItems.Add(item);
                            }
                            break;

                        case "C:\\inetpub\\wwwroot\\Website\\Uploads\\Khaki_School_Trouser.jpg":
                            {
                                item.ItemTempImageHolder = "https://litb-cgis.rightinthebox.com/images/640x853/202208/bps/product/inc/ognyqb1660011874229.jpg?fmt=webp&v=1";

                                DisplayItems.Add(item);
                            }
                            break;

                        default:
                            {

                            }
                            break;

                    }
                }

                CollectionViews.ItemsSource = DisplayItems;

            }

                

            
        }


     

        private async void CollectionViews_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Items Item =(e.CurrentSelection.FirstOrDefault() as Items);
            await Navigation.PushModalAsync(new ItemPage(Item));
        }
    }
}