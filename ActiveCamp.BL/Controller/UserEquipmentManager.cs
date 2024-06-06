using ActiveCamp.BL.Model;
using System;
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
        public RecordOfUserEquipment GetUserEquipment(int EquipmentID, int UserID)
        {
            RecordOfUserEquipment userEquipment = new RecordOfUserEquipment();

            using (_connection)
            {
                string query = "SELECT * FROM UserEquipment WHERE UserID = @UserID AND EquipmentID = @EquipmentID";

                SqlCommand command = new SqlCommand(query, _connection);
                command.Parameters.AddWithValue("@EquipmentID", EquipmentID);
                command.Parameters.AddWithValue("@UserID", UserID);
                try
                {
                    _connection.Open();
                    SqlDataReader reader = command.ExecuteReader();

                    if (reader.Read())
                    {
                        userEquipment.UserEquipmentID = Convert.ToInt32(reader["UserEquipmentID "]);
                        userEquipment.OwnerID = Convert.ToInt32(reader["OwnerID"]);
                    }
                    reader.Close();
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error: " + ex.Message);
                }
            }
            return userEquipment;
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
        public int GetUserEquipmentID(UserEquipment userEquipment)
        {
            int userEquipmentID = -1;
            using (_connection)
            {
                string query = "SELECT * FROM UserEquipment WHERE EquipmentID = @EquipmentID AND UserID = @UserID";

                SqlCommand command = new SqlCommand(query, _connection);
                command.Parameters.AddWithValue("@EquipmentID", userEquipment.EquipmentID);
                command.Parameters.AddWithValue("@UserID", userEquipment.UserID); 
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
    }
}
