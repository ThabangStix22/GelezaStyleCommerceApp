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
    public partial class SchoolPage : ContentPage
    {
        private ClientAPI api = new ClientAPI();
        private SelectedSchoolControl _SelectedSchoolControl = new SelectedSchoolControl();


        public SchoolPage()
        {
            InitializeComponent();
            loadSchools();

        }

        private async void loadSchools()
        {
       
            IEnumerable<Schools> schools = await api.GetActiveSchools(1);
            foreach(Schools school in schools)
            {
                School_ID school_ID = new School_ID
                {
                    SchoolId = school.SchID,
                    SchoolName = school.SchName
                };

              _SelectedSchoolControl.addSchool(school_ID);
              itemPicker.Items.Add(school.SchName);
            }
    
        }

        private async void btnNextLoad_Clicked(object sender, EventArgs e)
        {
           // var i = Convert.ToInt32(Application.Current.Properties["LoggedUser"]);
           if(itemPicker.SelectedItem != null)
            {
                _SelectedSchoolControl.setSelectedSchool(itemPicker.SelectedItem.ToString());

                await Navigation.PushAsync(new Shopping());
            }
            else
            {
                await DisplayAlert("School selection alert Message", "You did not select a school!", "Let me try again.");
            }
          
        }
    }
}