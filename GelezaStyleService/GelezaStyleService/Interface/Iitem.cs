using GelezaStyleService.Models;
using System.Collections.Generic;

namespace GelezaStyleService.Interface
{
    public interface Iitem
    {
        //CRUD 
        public int CreateItem(Items item);
        public Items GetItem(int Id);
        public IEnumerable<Items> GetAllItems();
        public IEnumerable<Items> GetActiveItems(int chActive);
        public IEnumerable<Items> GetItemsBySchool(int schoolId);

        public IEnumerable<Items> GetItemsByGender(string gender);
        public List<string> GetItemSizeByName(string itemName);

        public IEnumerable<Items> GetByGender(string gender);

        public int updateItem(Items item);
        public int ActivateItem(int Id, int chActivate);
    }
}
