using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace GelezaStyleMobileApp.Models
{
    public class SelectedSchoolControl
    {
        private List<School_ID> _itemDictionary = new List<School_ID>();
       // private KeyValuePair<int, string> pair = new KeyValuePair<int, string>();

        private static string _selectedSchoolValue {get;set;}

       

        public void setSelectedSchool(string selectedSchoolValue)
        {
            _selectedSchoolValue = selectedSchoolValue;

            foreach (School_ID item in _itemDictionary)
            {
                if (item.SchoolName == _selectedSchoolValue)
                {
                    Application.Current.Properties["SelectedSchool"] = item.SchoolId;
                }
            }
        }

        public void addSchool(School_ID school)
        {
            _itemDictionary.Add(school);
        }
    }
}
