using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace ActiveCamp.BL.Model
{
    // TODO: Можно выгрузить в xml 
    public class ActiveCampDbContext
    {
        private readonly string _connectionString = "Server=DESKTOP-VJNL8L9;Database = HikingAppDB;Trusted_Connection=True;MultipleActiveResultSets=True";
        //private readonly string _connectionString = "Server=DESKTOP-MONLUDU;Database = HikingAppDB;Trusted_Connection=True;MultipleActiveResultSets=True";

        public ActiveCampDbContext()
        {
        }

        public SqlConnection GetSqlConnection()
        {
            SqlConnection connection = new SqlConnection(_connectionString);
            return connection;
        }
    }
}
