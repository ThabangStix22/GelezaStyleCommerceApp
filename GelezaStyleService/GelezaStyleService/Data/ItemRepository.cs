using GelezaStyleService.Interface;
using GelezaStyleService.Models;
using System.Collections.Generic;
using System;
using Dapper;

namespace GelezaStyleService.Data
{
    public class ItemRepository : Iitem
    {
        internal Connection _con = new Connection();

        public int CreateItem(Items item)
        {
            Items existItem = null;
            int control = 2;

            existItem = _con.OpenConnection().QueryFirstOrDefault<Items>(
                $"SELECT * FROM Items " +
                $"WHERE ItemSize='{item.ItemSize}' AND ItemUnits={item.ItemUnits} " +
                $" AND ItemName='{item.ItemName}' AND ItemDescription='{item.ItemDescription}'");
            

            if(existItem == null)
            {
                try
                {
                    control = _con.OpenConnection().Execute(
                    @"INSERT INTO dbo.Items 
                    VALUES('"+item.ItemName+"','"+item.ItemDescription+"'," +
                     "'"+item.ItemPrice+"','"+item.ItemUnits+"',"+item.ItemIsActive+","+
                     "'"+item.ItemImage+"','"+item.ItemSize+"','"+item.ItemCategory+"'," +
                     "'"+item.ItemDateAdded.ToShortDateString()+"','"+item.ItemGender+"')",item);
                }catch(Exception e)
                {
                    control = -1;
                    e.GetBaseException();
                }

            }else if (existItem != null)
            {
                control = 0;
            }

            _con.CloseConnection();
            return control;
        }

        public Items GetItem(int Id)
        {
            Items existItem = null;

            existItem = _con.OpenConnection().QueryFirstOrDefault<Items>(
                @"SELECT * FROM dbo.Items
                WHERE ItemID=" + Id + "");

            _con.CloseConnection();
            return existItem;
        }

        public IEnumerable<Items> GetAllItems()
        {
            IEnumerable<Items> existItems = _con.OpenConnection()
                                            .Query<Items>(@"SELECT *
                                            FROM dbo.Items");
            _con.CloseConnection();
            return existItems;
        }

        public IEnumerable<Items> GetActiveItems(int chActive)
        {
            IEnumerable<Items> existItems = _con.OpenConnection()
                                            .Query<Items>($"SELECT * "+
                                            $"FROM dbo.Items "+ 
                                            $"WHERE ItemIsActive={chActive}");
            _con.CloseConnection();
            return existItems;
        }

        public IEnumerable<Items> GetItemsBySchool(int schoolId)
        {

            IEnumerable<Items> schoolItems = _con.OpenConnection().Query<Items>(
                $"SELECT Items.* " +
                $"FROM Compatibility " +
                $"Right JOIN Items " +
                $"ON Compatibility.ItemID = Items.ItemID  " +
                $"WHERE Compatibility.SchID={schoolId}"
                  );

            _con.CloseConnection();
            return schoolItems;
        }
        
        /* public IEnumerable<Items> SearchItems(string name)
         {
             IEnumerable<Items> existItems = _con.OpenConnection().Query<Items>(
                 @"SELECT *  
                 FROM dbo.Items 
                 WHERE ItemName LIKE '"+name.ToString()+"'");
             _con.CloseConnection();
             return existItems;

         }*/

        //Category and DateAdded attributes not updated

        public int updateItem(Items item)
        {
            int control = 2;
            //Check if item exists
            Items existingItem = _con.OpenConnection()
                .QueryFirstOrDefault<Items>(@"SELECT * FROM dbo.Items 
                                            WHERE ItemID="+item.ItemID+"");

            if(existingItem != null)
            {
                try
                {
                    control = _con.OpenConnection().Execute(
                        @"UPDATE dbo.Items 
                        SET ItemName='"+item.ItemName+"'," +
                        "ItemDescription='"+item.ItemDescription+"'," +
                        "ItemPrice="+item.ItemPrice+"," +
                        "ItemUnits="+item.ItemUnits+"," +
                        "ItemIsActive='"+item.ItemIsActive+"'," +
                        "ItemImage='"+item.ItemImage+"'," +
                        "ItemSize='"+item.ItemSize+"' " +
                        "WHERE ItemID="+existingItem.ItemID+"");
                }catch(Exception e)
                {
                    control = -1;
                    e.GetBaseException();
                }
            }else if(existingItem == null)
            {
                control = 0;
            }

            _con.CloseConnection();
            return control;
        }

        public int ActivateItem(int Id, int chActivate)
        {
            int control = 2;
            Items existItem = _con.OpenConnection().QueryFirstOrDefault<Items>(
                @"SELECT * FROM dbo.Items
                WHERE ItemID=" + Id + "");

            

            if (existItem != null && (chActivate==1))
            {
                try
                {
                    control = _con.OpenConnection().Execute(@"
                    UPDATE dbo.Items
                    SET ItemIsActive=" + 1 + " " +
                    "WHERE ItemID=" + Id + "");
                }
                catch (Exception e)
                {
                    control = -1;
                    e.GetBaseException();
                }
            }
            else if (existItem != null && chActivate == 0)
            {
                try
                {
                    control = _con.OpenConnection().Execute(@"
                    UPDATE dbo.Items
                    SET ItemIsActive=" + 0 + " " +
                    "WHERE ItemID=" + Id+ "");
                }
                catch (Exception e)
                {
                    control = -1;
                    e.GetBaseException();
                }
            }
            else if (existItem == null && (chActivate == 0 || chActivate == 1))
            {
                control = 0;
            }

            _con.CloseConnection();
            return control;
        }

        public IEnumerable<Items> GetItemsByGender(string gender)
        {
            IEnumerable<Items> genderItems = _con.OpenConnection().Query<Items>
                ($"SELECT * FROM dbo.Items " +
                $"WHERE ItemGender = '{gender}'");
            _con.CloseConnection();

            return genderItems;
        }

        public List<string> GetItemSizeByName(string itemName)
        {
            List<string> itemSizes = _con.OpenConnection().Query<string>
                ($"SELECT ItemSize FROM dbo.Items " +
                $"WHERE ItemName='{itemName}'").AsList<string>();
            _con.CloseConnection();

            return itemSizes;
        }

        public IEnumerable<Items> GetByGender(string gender)
        {

            IEnumerable<Items>categoryItems = _con.OpenConnection().Query<Items>
                ($"SELECT * " +
                $"FROM dbo.Items " +
                $"WHERE ItemGender='{gender}' AND ItemIsActive=1 "+
                $"ORDER BY (ItemName) ASC");
            _con.CloseConnection();

            return categoryItems;

        }
    }
    
}
