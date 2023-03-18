using System;
using System.Collections.Generic;
using System.Text;

namespace GelezaStyleMobileApp.Models
{
    public class Product
    {
        public string productName { get; set; }
        public string productPrice { get; set; }
        public string productImage { get; set; }
        public string productDescription { get; set; }
        public bool newProduct { get; set; }
    }
}
