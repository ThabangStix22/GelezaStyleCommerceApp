using Newtonsoft.Json;
using System;
namespace GelezaStyleMobileApp.Models
{
    public class Items
    {
      
        public int ItemID { get; set; }
        public string ItemName { get; set; }
        public string ItemDescription { get; set; }
        public int ItemPrice { get; set; }
        public int ItemUnits { get; set; }
        public int ItemIsActive { get; set; }
        public string ItemImage { get; set; }
        public string ItemSize { get; set; }

        public string ItemCategory { get; set; }

        public DateTime ItemDateAdded { get; set; }

        public string ItemTempImageHolder { get; set; }
    }
}
