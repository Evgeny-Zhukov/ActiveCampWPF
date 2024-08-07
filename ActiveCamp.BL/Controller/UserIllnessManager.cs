﻿using ActiveCamp.BL.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace ActiveCamp.BL.Controller
{

    public class UserIllnessManager
    {
        private ActiveCampDbContext dbContext;
        private SqlConnection _connection;
        public UserIllnessManager()
        {
            dbContext = new ActiveCampDbContext();
            _connection = dbContext.GetSqlConnection();
        }
        public bool AddUserIllness(Illness illness)
        {
            using (_connection)
            {
                SqlCommand command = new SqlCommand("AddUserIllness", _connection);
                command.CommandType = CommandType.StoredProcedure;
                SqlParameter successParameter = new SqlParameter("@success", SqlDbType.Bit);
                successParameter.Direction = ParameterDirection.Output;
                command.Parameters.Add(successParameter);
                command.Parameters.AddWithValue("@Name", illness.IllnessName);
                _connection.Open();
                command.ExecuteNonQuery();
                bool success = (bool)successParameter.Value;
                return success;
            }
        }
        public List<UserIllness> GetUserIllness(int UserID)
        {
            List<UserIllness> usersIllnesses = new List<UserIllness>();

            using (_connection)
            {
                string query = "SELECT * FROM UserIllness WHERE UserID = @UserID";

                SqlCommand command = new SqlCommand(query, _connection);
                command.Parameters.AddWithValue("@UserID", UserID);
                try
                {
                    _connection.Open();
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            UserIllness userIllness = new UserIllness();
                            {
                                userIllness.UserIllnessId = Convert.ToInt32(reader["UserIllnessId"]);
                                userIllness.IllnessID = Convert.ToInt32(reader["IllnessID"]);
                                userIllness.UserID = Convert.ToInt32(reader["UserID"]);
                            }
                            usersIllnesses.Add(userIllness);
                        }
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error: " + ex.Message);
                }
            }
            return usersIllnesses;
        }
        public bool UpdateUserIllness(UserIllness userIllness)
        {
            using (_connection)
            {

                SqlCommand command = new SqlCommand("UpdateUserIllness", _connection);
                command.CommandType = CommandType.StoredProcedure;
                SqlParameter successParameter = new SqlParameter("@success", SqlDbType.Bit);
                successParameter.Direction = ParameterDirection.Output;
                command.Parameters.Add(successParameter);

                command.Parameters.AddWithValue("@UserIllnessId", userIllness.UserIllnessId);
                command.Parameters.AddWithValue("@IllnessID", userIllness.IllnessID);
                command.Parameters.AddWithValue("@UserID", userIllness.UserID);

                _connection.Open();
                command.ExecuteNonQuery();
                bool success = (bool)successParameter.Value;
                return success;
            }
        }
        public bool DeleteUserIllness(int id)
        {
            using (_connection)
            {
                SqlCommand command = new SqlCommand("DeleateUserIllnessById", _connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@ID", id);
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
