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

        /// <summary>
        /// Создает экземпляр EquipmentManager и устанавливает соединение с базой данных.
        /// </summary>
        public EquipmentManager()
        {
            dbContext = new ActiveCampDbContext();
            _connection = dbContext.GetSqlConnection();
        }

        /// <summary>
        /// Добавляет оборудование в базу данных.
        /// </summary>
        /// <param name="equipment">Экземпляр оборудования</param>
        /// <returns>Возвращает true, если оборудование успешно добавлено; в противном случае false</returns>
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

        /// <summary>
        /// Получает оборудование из базы данных по идентификатору.
        /// </summary>
        /// <param name="equipmentID">Идентификатор оборудования</param>
        /// <returns>Возвращает экземпляр оборудования</returns>
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
                        // Чтение данных оборудования из результата запроса
                        equipment.equipmentID = Convert.ToInt32(reader["equipmentID"]);
                        equipment.equipmentName = (reader["equipmentName"].ToString());
                        equipment.equipmentWeight = (Convert.ToDouble(reader["equipmentWeight"]));
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

        /// <summary>
        /// Обновляет информацию об оборудовании в базе данных.
        /// </summary>
        /// <param name="equipment">Экземпляр оборудования</param>
        /// <returns>Возвращает true, если информация успешно обновлена; в противном случае false</returns>
        public bool UpdateEquipment(Equipment equipment)
        {
            using (_connection)
            {
                SqlCommand command = new SqlCommand("UpdateEquipment", _connection);
                command.CommandType = CommandType.StoredProcedure;

                SqlParameter successParameter = new SqlParameter("@success", SqlDbType.Bit);
                successParameter.Direction = ParameterDirection.Output;
                command.Parameters.Add(successParameter);

                command.Parameters.AddWithValue("@equipmentID", equipment.equipmentID);
                command.Parameters.AddWithValue("@equipmentName", equipment.equipmentName);
                command.Parameters.AddWithValue("@equipmentWeight", equipment.equipmentWeight);

                _connection.Open();
                command.ExecuteNonQuery();
                bool success = (bool)successParameter.Value;
                return success;
            }
        }

        /// <summary>
        /// Удаляет оборудование из базы данных по идентификатору.
        /// </summary>
        /// <param name="id">Идентификатор оборудования</param>
        /// <returns>Возвращает true, если оборудование успешно удалено; в противном случае false</returns>
        public bool DeleteEquipment(int id)
        {
            using (_connection)
            {
                SqlCommand command = new SqlCommand("DeleteEquipmentById", _connection);
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
        public int GetEquipmentID(Equipment equipment)
        {
            int equipmentID = -1;
            using (_connection)
            {
                string query = "SELECT * FROM Dish WHERE equipmentName = @equipmentName";

                SqlCommand command = new SqlCommand(query, _connection);
                command.Parameters.AddWithValue("@Name", equipment.equipmentName);
                try
                {
                    _connection.Open();
                    SqlDataReader reader = command.ExecuteReader();

                    if (reader.Read())
                    {
                        equipmentID = Convert.ToInt32(reader["equipmentID"]);
                    }
                    reader.Close();
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error: " + ex.Message);
                }

            }
            if (equipmentID <= 0)
            {
                throw new ArgumentOutOfRangeException(nameof(equipmentID), "ID снаряжения должен быть положительным числом.");
            }
            return equipmentID;
        }
    }

}
