using ActiveCamp.BL.Model;
using System;
using System.Data;
using System.Data.SqlClient;

namespace ActiveCamp.BL.Controller
{
    public class EquipmentManager
    {
        private ActiveCampDbContext dbContext;
        private SqlConnection _connection;

        public EquipmentManager()
        {
            dbContext = new ActiveCampDbContext();
            _connection = dbContext.GetSqlConnection();
        }
        public bool AddEquipment(Equipment equipment)
        {
            using (_connection)
            {
                SqlCommand command = new SqlCommand("AddEquipment", _connection);
                command.CommandType = CommandType.StoredProcedure;
                SqlParameter successParameter = new SqlParameter("@success", SqlDbType.Bit);
                successParameter.Direction = ParameterDirection.Output;
                command.Parameters.Add(successParameter);
                command.Parameters.AddWithValue("@equipmentName", equipment.equipmentName);
                command.Parameters.AddWithValue("@equipmentWeight", equipment.equipmentWeight);
                _connection.Open();
                command.ExecuteNonQuery();
                bool success = (bool)successParameter.Value;
                return success;
            }
        }
        public Equipment GetEquipment(int equipmentID)
        {
            Equipment equipment = new Equipment();

            using (_connection)
            {
                string query = "SELECT * FROM Equipment WHERE equipmentID = @equipmentID";

                SqlCommand command = new SqlCommand(query, _connection);
                command.Parameters.AddWithValue("@equipmentID", equipmentID);
                try
                {
                    _connection.Open();
                    SqlDataReader reader = command.ExecuteReader();

                    if (reader.Read())
                    {
                        // Чтение данных маршрута из результата запроса
                        equipment.equipmentID = Convert.ToInt32(reader["equipmentID"]);
                        equipment.equipmentName = reader["equipmentName"].ToString();
                        equipment.equipmentWeight = Convert.ToDouble(reader["equipmentWeight"]);
                    }
                    reader.Close();
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error: " + ex.Message);
                }
            }
            return equipment;
        }
        public bool UpdateEquipment(Equipment equipment) // TODO: Уточнить как будет работать
        {
            using (_connection)
            {
                SqlCommand command = new SqlCommand("UpdateEquipment", _connection);    
                command.CommandType = CommandType.StoredProcedure;
                SqlParameter successParameter = new SqlParameter("@success", SqlDbType.Bit);
                command.Parameters.AddWithValue("@equipmentName", equipment.equipmentName);
                command.Parameters.AddWithValue("@equipmentWeight", equipment.equipmentWeight);
                _connection.Open();
                command.ExecuteNonQuery();
                bool success = (bool)successParameter.Value;
                return success;
            }
        }
        public bool DeleteEquipment(int id)
        {
            using (_connection)
            {
                SqlCommand command = new SqlCommand("DeleateEquipmentById", _connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@equipmentID", id);
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
