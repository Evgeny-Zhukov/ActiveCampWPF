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

        public ActiveCampDbContext()
        {
        }

        public SqlConnection GetSqlConnection()
        {
            SqlConnection connection = new SqlConnection(_connectionString);
            return connection;
        }

        #region User 2/4

        #endregion
        #region Route 4/4
        
        #endregion
        #region FoodConsumption 3/4
        
        #endregion
        #region SyrveyResult 3/4
        
        #endregion
        #region UserIllness 3/4
        #endregion
        #region UserEquipment 3/4
        #endregion
        #region UserDish 3/4
        #endregion
        #region Equipment 3/4
        #endregion
        #region Dish 3/4
        #endregion 
        #region Illness 3/4
        #endregion
        #region Group
        #endregion
    }
}
