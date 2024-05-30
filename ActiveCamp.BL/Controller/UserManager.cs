﻿using System.Data.SqlClient;
using System.Data;
using System.Security.Cryptography;
using System;

namespace ActiveCamp.BL.Controller
{
    public class UserManager
    {
        private readonly string _connectionString;

        public UserManager(string connectionString)
        {
            _connectionString = connectionString;
        }

        public bool RegisterUser(User user)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {

                SqlCommand command = new SqlCommand("CreateUser", connection)
                {
                    CommandType = CommandType.StoredProcedure
                };
                command.Parameters.AddWithValue("@Username", user.Username);
                command.Parameters.AddWithValue("@Password", user.Password);

                SqlParameter successParameter = new SqlParameter("@Success", SqlDbType.Bit)
                {
                    Direction = ParameterDirection.Output
                };
                command.Parameters.Add(successParameter);

                connection.Open();
                command.ExecuteNonQuery();
                
                return (bool)successParameter.Value;
            }
        }
        public bool VerifyUserByLogin(string username, string password)
        {
            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                using (SqlCommand cmd = new SqlCommand("VerifyUserByLogin", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@Username", username);
                    cmd.Parameters.AddWithValue("@Password", password);

                    SqlParameter isLoginSuccessfulParam = new SqlParameter("@IsLoginSuccessful", SqlDbType.Bit)
                    {
                        Direction = ParameterDirection.Output
                    };
                    cmd.Parameters.Add(isLoginSuccessfulParam);

                    conn.Open();
                    cmd.ExecuteNonQuery();

                    return (bool)isLoginSuccessfulParam.Value;
                }
            }
        }

        public User GetUserById(int userId)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                SqlCommand command = new SqlCommand("GetUserById", connection)
                {
                    CommandType = CommandType.StoredProcedure
                };
                command.Parameters.AddWithValue("@UserID", userId);

                connection.Open();
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        return new User((int)reader["UserId"], reader["Username"].ToString());
                    }
                }
            }

            return null;
        }
    }

}
