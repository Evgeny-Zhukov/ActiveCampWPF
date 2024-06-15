using ActiveCamp.BL.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace ActiveCamp.BL.Controller
{
    public class UserDishManager
    {
        private ActiveCampDbContext dbContext;
        private SqlConnection _connection;
        public UserDishManager()
        {
            dbContext = new ActiveCampDbContext();
            _connection = dbContext.GetSqlConnection();
        }
        public bool AddUserDish(UserDish userDish)
        {
            using (_connection)
            {
                SqlCommand command = new SqlCommand("AddUserDishes", _connection);
                command.CommandType = CommandType.StoredProcedure;
                SqlParameter successParameter = new SqlParameter("@success", SqlDbType.Bit);
                successParameter.Direction = ParameterDirection.Output;
                command.Parameters.Add(successParameter);
                command.Parameters.AddWithValue("@DishID", userDish.DishID);
                command.Parameters.AddWithValue("@UserID", userDish.UserID);
                _connection.Open();
                command.ExecuteNonQuery();
                bool success = (bool)successParameter.Value;
                return success;
            }
        }
        public UserDish GetUserDish(int DishID, int UserID)
        {
            UserDish userDish = new UserDish();

            using (_connection)
            {
                string query = "SELECT * FROM UserDishes WHERE UserID = @UserID AND DishesID = @DishesID";

                SqlCommand command = new SqlCommand(query, _connection);
                command.Parameters.AddWithValue("@DishesID", DishID);
                command.Parameters.AddWithValue("@UserID", UserID);
                try
                {
                    _connection.Open();
                    SqlDataReader reader = command.ExecuteReader();

                    if (reader.Read())
                    {
                        userDish.DishID = Convert.ToInt32(reader["DishID"]);
                        userDish.UserID = Convert.ToInt32(reader["UserID"]);
                    }
                    reader.Close();
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error: " + ex.Message);
                }
            }
            return userDish;
        }
        public List<UserDish> GetUserDish(int UserID)
        {
            List<UserDish> userDishes = new List<UserDish>();

            using (_connection)
            {
                string query = "SELECT * FROM UserDishes WHERE UserID = @UserID";

                SqlCommand command = new SqlCommand(query, _connection);

                command.Parameters.AddWithValue("@UserID", UserID);
                try
                {
                    _connection.Open();
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            UserDish userDish = new UserDish();
                            {
                                userDish.UserDishID = Convert.ToInt32(reader["UserDishID"]);
                                userDish.DishID = Convert.ToInt32(reader["DishID"]);
                                userDish.UserID = Convert.ToInt32(reader["UserID"]);
                            }
                            userDishes.Add(userDish);
                        }
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error: " + ex.Message);
                }
            }
            
            return userDishes;
        }
        public bool UpdateUserDish(UserDish userDish)
        {
            using (_connection)
            {

                SqlCommand command = new SqlCommand("UpdateUserDish", _connection);
                command.CommandType = CommandType.StoredProcedure;
                SqlParameter successParameter = new SqlParameter("@success", SqlDbType.Bit);
                successParameter.Direction = ParameterDirection.Output;
                command.Parameters.Add(successParameter);

                command.Parameters.AddWithValue("@UserDishID", userDish.UserDishID);
                command.Parameters.AddWithValue("@UserID", userDish.UserID);
                command.Parameters.AddWithValue("@DishID", userDish.DishID);


                _connection.Open();
                command.ExecuteNonQuery();
                bool success = (bool)successParameter.Value;
                return success;
            }
        }
        public bool DeleteUserDish(int id)
        {
            using (_connection)
            {
                SqlCommand command = new SqlCommand("DeleteUserDishById", _connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@UserDishID", id);
                SqlParameter successParameter = new SqlParameter("@success", SqlDbType.Bit);
                successParameter.Direction = ParameterDirection.Output;
                command.Parameters.Add(successParameter);
                _connection.Open();
                command.ExecuteNonQuery();
                bool success = (bool)successParameter.Value;
                return success;
            }
        }
    }
}
