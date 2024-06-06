using ActiveCamp.BL.Model;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ActiveCamp.BL.Controller
{
    public class IllnessManager
    {
        private ActiveCampDbContext dbContext;
        private SqlConnection _connection;
        public IllnessManager()
        {
            dbContext = new ActiveCampDbContext();
            _connection = dbContext.GetSqlConnection();
        }
        public bool AddIllness(Illness illness)
        {
            using (_connection)
            {
                SqlCommand command = new SqlCommand("AddIllness", _connection);
                command.CommandType = CommandType.StoredProcedure;
                SqlParameter successParameter = new SqlParameter("@success", SqlDbType.Bit);
                successParameter.Direction = ParameterDirection.Output;
                command.Parameters.Add(successParameter);
                command.Parameters.AddWithValue("@IllnessName", illness.IllnessName);
                command.Parameters.AddWithValue("@IllnessDescription", illness.IllnessDescription);
                _connection.Open();
                command.ExecuteNonQuery();
                bool success = (bool)successParameter.Value;
                return success;
            }
        }
        public Illness GetIllness(int IllnessID)
        {
            Illness illness = new Illness();

            using (_connection)
            {
                string query = "SELECT * FROM Illness WHERE IllnessID = @IllnessID";

                SqlCommand command = new SqlCommand(query, _connection);
                command.Parameters.AddWithValue("@IllnessID", IllnessID);
                try
                {
                    _connection.Open();
                    SqlDataReader reader = command.ExecuteReader();

                    if (reader.Read())
                    {
                        illness.SetIllnessID(illness);
                        illness.SetIllnessName(reader["IllnessName"].ToString());
                        illness.SetIllnessDescription(reader["IllnessDescription"].ToString());
                    }
                    reader.Close();
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error: " + ex.Message);
                }
            }
            return illness;
        }
        public bool DeleteIllness(int id)
        {
            using (_connection)
            {
                SqlCommand command = new SqlCommand("DeleateIllnessById", _connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@IllnessID", id);
                SqlParameter successParameter = new SqlParameter("@success", SqlDbType.Bit);
                successParameter.Direction = ParameterDirection.Output;
                command.Parameters.Add(successParameter);
                _connection.Open();
                command.ExecuteNonQuery();
                bool success = (bool)successParameter.Value;
                return success;
            }
        }
        public int GetIllnessID(Illness illness)
        {
            int illnessID = -1;
            using (_connection)
            {
                string query = "SELECT * FROM Illness WHERE IllnessName = @IllnessName";

                SqlCommand command = new SqlCommand(query, _connection);
                command.Parameters.AddWithValue("@IllnessName", illness.IllnessName);
                try
                {
                    _connection.Open();
                    SqlDataReader reader = command.ExecuteReader();

                    if (reader.Read())
                    {
                        illnessID = Convert.ToInt32(reader["IllnessID"]);
                    }
                    reader.Close();
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error: " + ex.Message);
                }

            }
            if (illnessID <= 0)
            {
                throw new ArgumentOutOfRangeException(nameof(illnessID), "ID недуга должен быть положительным числом.");
            }
            return illnessID;
        }
    }
}
