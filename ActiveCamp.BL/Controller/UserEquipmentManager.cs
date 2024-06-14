using ActiveCamp.BL.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace ActiveCamp.BL.Controller
{
    public class UserEquipmentManager
    {
        private ActiveCampDbContext dbContext;
        private SqlConnection _connection;
        public UserEquipmentManager()
        {
            dbContext = new ActiveCampDbContext();
            _connection = dbContext.GetSqlConnection();
        }
        public bool AddUserEquipment(RecordOfUserEquipment userEquipment)
        {
            using (_connection)
            {
                SqlCommand command = new SqlCommand("AddUserEquipment", _connection);
                command.CommandType = CommandType.StoredProcedure;
                SqlParameter successParameter = new SqlParameter("@success", SqlDbType.Bit);
                successParameter.Direction = ParameterDirection.Output;
                command.Parameters.Add(successParameter);
                command.Parameters.AddWithValue("@EquipmentName", userEquipment.EquipmentName);
                command.Parameters.AddWithValue("@CountOfEquipment", userEquipment.CountOfEquipment);
                command.Parameters.AddWithValue("@WightOfEquipment", userEquipment.WightOfEquipment);
                command.Parameters.AddWithValue("@OwnerID", userEquipment.OwnerID);
                command.Parameters.AddWithValue("@EquipmentDescription", userEquipment.EquipmentDescription);
                _connection.Open();
                command.ExecuteNonQuery();
                bool success = (bool)successParameter.Value;
                return success;
            }
        }
        public bool AddUserEquipment(List<RecordOfUserEquipment> userEquipment)
        {
            bool allSuccess = true;
            using (_connection)
            {
                _connection.Open();
                foreach (RecordOfUserEquipment item in userEquipment)
                {
                    using (SqlCommand command = new SqlCommand("AddUserEquipment", _connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;

                        SqlParameter successParameter = new SqlParameter("@success", SqlDbType.Bit);
                        successParameter.Direction = ParameterDirection.Output;
                        command.Parameters.Add(successParameter);

                        command.Parameters.AddWithValue("@EquipmentName", item.EquipmentName);
                        command.Parameters.AddWithValue("@CountOfEquipment", item.CountOfEquipment);
                        command.Parameters.AddWithValue("@WightOfEquipment", item.WightOfEquipment);
                        command.Parameters.AddWithValue("@OwnerID", item.OwnerID);
                        command.Parameters.AddWithValue("@EquipmentDescription", item.EquipmentDescription);

                        command.ExecuteNonQuery();

                        bool success = (bool)successParameter.Value;
                        if (!success)
                        {
                            allSuccess = false;
                        }
                    }
                }
            }
            return allSuccess;
        }

        public List<UserEquipment> GetUserEquipment(int UserID)
        {
            List<UserEquipment> userEquipments = new List<UserEquipment>();

            using (_connection)
            {
                string query = "SELECT * FROM UserEquipment WHERE UserID = @UserID";

                SqlCommand command = new SqlCommand(query, _connection);

                command.Parameters.AddWithValue("@UserID", UserID);
                try
                {
                    _connection.Open();
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            UserEquipment userEquipment = new UserEquipment();
                            {
                                command.Parameters.AddWithValue("@UserEquipmentId", userEquipment.UserEquipmentId);
                                command.Parameters.AddWithValue("@EquipmentID", userEquipment.EquipmentID);
                                command.Parameters.AddWithValue("@UserID", userEquipment.UserID);
                            }
                            userEquipments.Add(userEquipment);
                        }
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error: " + ex.Message);
                }
            }

            return userEquipments;
        }
        public bool DeleteUserEquipment(int id)
        {
            using (_connection)
            {
                SqlCommand command = new SqlCommand("DeleteUserEquipmentById", _connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@UserEquipmentID", id);
                SqlParameter successParameter = new SqlParameter("@success", SqlDbType.Bit);
                successParameter.Direction = ParameterDirection.Output;
                command.Parameters.Add(successParameter);
                _connection.Open();
                command.ExecuteNonQuery();
                bool success = (bool)successParameter.Value;
                return success;
            }
        }
        public int GetUserEquipmentID(RecordOfUserEquipment userEquipment)
        {
            int userEquipmentID = -1;
            using (_connection)
            {
                string query = "SELECT * FROM UserEquipment WHERE UserEquipmentID = @UserEquipmentID AND UserID = @UserID";

                SqlCommand command = new SqlCommand(query, _connection);
                command.Parameters.AddWithValue("@UserEquipmentID", userEquipment.UserEquipmentID);
                command.Parameters.AddWithValue("@UserID", userEquipment.OwnerID); 
                try
                {
                    _connection.Open();
                    SqlDataReader reader = command.ExecuteReader();

                    if (reader.Read())
                    {
                        userEquipmentID = Convert.ToInt32(reader["UserEquipmentID"]);
                    }
                    reader.Close();
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error: " + ex.Message);
                }

            }
            if (userEquipmentID <= 0)
            {
                throw new ArgumentOutOfRangeException(nameof(userEquipmentID), "ID снаряжения пользователя должен быть положительным числом.");
            }
            return userEquipmentID;
        }
        public List<RecordOfUserEquipment> CreateList()
        {
            List<RecordOfUserEquipment> list = new List<RecordOfUserEquipment>();
            return list;
        }
        
    }
}
