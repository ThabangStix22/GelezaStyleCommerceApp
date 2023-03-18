using System;
using System.Collections.Generic;

namespace GelezaStyleMobileApp.Models
{
    public class Orders
    {
        public int OrderID { get; set; }
        public int ClientID { get; set; }
        public int OrderCollected { get; set; }
        public DateTime OrderDate { get; set; }
        public int OrderPlaced { get; set; }
        public int OrderIsReady { get; set; }
        public DateTime DateCollected { get; set; }
        public int IsActive { get; set; } 
    }
}
