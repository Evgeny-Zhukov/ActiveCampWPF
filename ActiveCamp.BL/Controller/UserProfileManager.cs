﻿using ActiveCamp.BL.Model;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ActiveCamp.BL.Controller
{
    internal class UserProfileManager
    {
        private ActiveCampDbContext dbContext;
        private SqlConnection _connection;

        public UserProfileManager()
        {
            dbContext = new ActiveCampDbContext();
            _connection = dbContext.GetSqlConnection();
        }

        public List<UserProfile> GetUserProfile(int UserID)
        {
            List<UserProfile> userProfiles = new List<UserProfile>();

            using (_connection)
            {
                string query = "SELECT * FROM UserProfile WHERE UserID = @UserID";

                SqlCommand command = new SqlCommand(query, _connection);
                command.Parameters.AddWithValue("@UserID", UserID);

                try
                {
                    _connection.Open();

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            UserProfile userProfile = new UserProfile();
                            {
                                userProfile.UserID = Convert.ToInt32(reader["UserID"]);
                                userProfile.FirstName = (reader["Name"].ToString());
                                userProfile.SecondName = (reader["SecondName"].ToString());
                                userProfile.Height = (Convert.ToInt32(reader["Height"]));
                                userProfile.Weight = (Convert.ToInt32(reader["Weight"]));
                                userProfile.ExperienceID = (Convert.ToInt32(reader["ExperienceID"]));
                                userProfile.IllnessID = (Convert.ToInt32(reader["IllnessID"]));
                                userProfile.EquipmentID = (Convert.ToInt32(reader["EquipmentID"]));
                                userProfile.DishID = (Convert.ToInt32(reader["DishID"]));
                            }
                            userProfiles.Add(userProfile);
                        }
                    }

                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error: " + ex.Message);
                }
            }
            return userProfiles;
        }

        public bool UpdateUserProfile(UserProfile userProfile)
        {
            using (_connection)
            {
                SqlCommand command = new SqlCommand("UpdateUserProfile", _connection);
                command.CommandType = CommandType.StoredProcedure;

                SqlParameter successParameter = new SqlParameter("@success", SqlDbType.Bit);
                successParameter.Direction = ParameterDirection.Output;
                command.Parameters.Add(successParameter);

                command.Parameters.AddWithValue("@FirstName", userProfile.FirstName);
                command.Parameters.AddWithValue("@SecondName", userProfile.SecondName);
                command.Parameters.AddWithValue("@Height", userProfile.Height);
                command.Parameters.AddWithValue("@Weight", userProfile.Weight);

                _connection.Open();
                command.ExecuteNonQuery();
                bool success = (bool)successParameter.Value;
                return success;
            }
        }
        public bool DeleteUserProfile(int userId)
        {
            using (_connection)
            {
                SqlCommand command = new SqlCommand("DeleteUserProfileById", _connection);
                command.CommandType = CommandType.StoredProcedure;

                command.Parameters.AddWithValue("@UserID", userId);

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