using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System;
using System.Data.SqlClient;

namespace GelezaStyleService.Models
{
    public class Connection
    {
        private static readonly string _configuration = "Data Source=DESKTOP-7SJDS25\\THABANGMSSQLSERV;Initial Catalog=GelezaStyleDB;Integrated Security=True;TrustServerCertificate=True";
        private readonly SqlConnection conn = new SqlConnection(_configuration);
         
        /*Connection(IConfiguration configuration)
        {
            _configuration = configuration["GelezaStyleConnection:DefaultConnection"] ;
        }*/

        //Opens Connection
        public SqlConnection OpenConnection()
        {
            try
            {
                conn.Open();
            }catch(Exception e)
            {
                e.GetBaseException();
            }

            return conn;
        }

        public void CloseConnection()
        {
            try
            {
                conn.Close();
            }catch(Exception e)
            {
                e.GetBaseException();
            }
        }

    }
}
