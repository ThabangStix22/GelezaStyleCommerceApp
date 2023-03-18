using GelezaStyleService.Interface;
using GelezaStyleService.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Dapper;

namespace GelezaStyleService.Data
{
    public class SchoolRepository : ISchools
    {
        private Connection _con = new Connection();

        public int CreateSchool(Schools school)
        {
            int control = 2;

            Schools existSchool = _con.OpenConnection().QueryFirstOrDefault<Schools>
                 ($"SELECT * FROM dbo.Schools " +
                 $"WHERE SchEmail='{school.SchEmail}'");

            if(existSchool == null)
            {
                try
                {
                    control = _con.OpenConnection().Execute
                        ($"INSERT INTO dbo.Schools " +
                        $"VALUES('{school.SchName}','{school.SchAddress}'," +
                        $"{school.SchIsActive},'{school.SchContactNo}','{school.SchEmail}')",school);

                }catch(Exception e)
                {
                    control = -1;
                    e.GetBaseException();
                }
            }else if(existSchool!= null)
            {
                control = 0;
            }
            _con.CloseConnection();

            return control;
        }

        public IEnumerable<Schools> GetActiveSchool(int chActive)
        {
            IEnumerable<Schools> schools = _con.OpenConnection().Query<Schools>(
                $"SELECT * FROM dbo.Schools WHERE " +
                $"SchIsActive={chActive}");
            _con.CloseConnection();

            return schools;
        }

        public Schools GetSchool(int Id)
        {
            Schools existSchool = _con.OpenConnection().QueryFirstOrDefault<Schools>
                ($"SELECT * FROM dbo.Schools WHERE SchID={Id}");

            _con.CloseConnection();

            return existSchool;
        }

        public IEnumerable<Schools> GetSchools()
        {
            IEnumerable<Schools> schools = _con.OpenConnection().Query<Schools>(
                $"SELECT * FROM dbo.Schools");
            _con.CloseConnection();
            return schools;
        }

        public int DeleteSchool(int Id)
        {
            int control = 2;

            Schools existSchool = _con.OpenConnection().QueryFirstOrDefault<Schools>
                ($"SELECT * FROM dbo.Schools WHERE SchID={Id}");

            if(existSchool != null)
            {
                try
                {
                    control = _con.OpenConnection().Execute(
                        $"UPDATE dbo.Schools " +
                        $"SET SchIsActive={0} " +
                        $"WHERE SchID={Id}");
                }catch(Exception e)
                {
                    control = -1;
                    e.GetBaseException();
                }

            }else if(existSchool == null)
            {
                control = 0;
            }

            _con.CloseConnection();
            return control;
        }

        

       

        public int updateSchool(Schools updateSchool)
        {
            Schools existSchool = GetSchool(updateSchool.SchID);
            int control = 2;

            if(existSchool!= null)
            {
                try
                {
                    control = _con.OpenConnection().Execute(
                    $"UPDATE dbo.Schools " +
                    $"SET SchName='{updateSchool.SchName}'," +
                    $"SchAddress='{updateSchool.SchAddress}'," +
                    $"SchIsActive='{updateSchool.SchIsActive}'," +
                    $"SchContactNo='{updateSchool.SchContactNo}'," +
                    $"SchEmail='{updateSchool.SchEmail}' " +
                    $"WHERE SchID={updateSchool.SchID}");
                
                }catch(Exception e)
                {
                    control = -1;
                    e.GetBaseException();
                }
            }else if(existSchool == null)
            {
                control = 0;
            }

            _con.CloseConnection();

            return control;
        }
    }
}
