namespace GelezaStyleService.Models
{
    public class PurchasedItem
    {
        public int ItemID { get; set; }
        public string ItemImage { get; set; }
        public string ItemGender { get; set; }
        public string ItemDescription { get; set; }

        public int ItemsOrdered { set; get; }
        public string ItemSize { get; set; }
    }
}
