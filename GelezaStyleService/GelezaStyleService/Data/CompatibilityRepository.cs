using GelezaStyleService.Interface;
using GelezaStyleService.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Dapper;

namespace GelezaStyleService.Data
{
    public class CompatibilityRepository : ICompatibility
    {
        private Connection _con = new Connection();

        public int CreateCompatibility(Compatibility compatibility)
        {
            int control = 2;

            Compatibility existCompability = _con.OpenConnection().QueryFirstOrDefault<Compatibility>
                ($"SELECT * FROM dbo.Compatibility " +
                $"WHERE SchID={compatibility.SchID} AND ItemID={compatibility.ItemID}");

            if(existCompability == null)
            {
                try {
                    control = _con.OpenConnection().Execute(
                        $"INSERT INTO dbo.Compatibility " +
                        $"VALUES ({compatibility.SchID},{compatibility.ItemID})",compatibility);
                }catch(Exception e)
                {
                    control = -1;
                    e.GetBaseException();
                }
                
            }else if(existCompability != null)
            {
                control = 0;
            }

            _con.CloseConnection();
            return control;
        }

        public IEnumerable<Compatibility> GetCompatibility(int itemID)
        {
          

            IEnumerable<Compatibility> compatibilities = _con.OpenConnection()
                .Query<Compatibility>($"SELECT * FROM dbo.Compatibility " +
                $"WHERE ItemID={itemID}");
            _con.CloseConnection();

            return compatibilities;
        }

        public int DeleteCompatibility(Compatibility compatibility)
        {
            int control = 2;

            Compatibility existCompatibility = _con.OpenConnection()
                .QueryFirstOrDefault<Compatibility>($"SELECT * FROM dbo.Compatibility" +
                $"WHERE SchID={compatibility.SchID} AND ItemID={compatibility}");
            
            if(existCompatibility!= null)
            {
                try
                {
                    control = _con.OpenConnection().Execute(
                        $"DELETE FROM dbo.Compatibility " +
                        $"WHERE SchID={compatibility.SchID} AND ItemID={compatibility.ItemID}");

                }catch(Exception e)
                {
                    control = -1;
                    e.GetBaseException();
                }
            } else if(existCompatibility == null)
            {
                control = 0;
            }

            _con.CloseConnection();
            return control;
        }

        //public IEnumerable<Compatibility> GetCompatibilities()
        //{
        //    IEnumerable<Compatibility> compatibilities = _con.OpenConnection().Query<Compatibility>(
        //        $"SELECT * FROM dbo.Compatibility");
        //    _con.CloseConnection();

        //    return compatibilities;
        //}
    }
}
