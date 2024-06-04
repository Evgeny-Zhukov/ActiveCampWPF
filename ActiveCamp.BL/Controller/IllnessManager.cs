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
                command.Parameters.AddWithValue("@IllnessID", illness.IllnessID);
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
                        illness.IllnessID = Convert.ToInt32(reader["IllnessID"]);
                        illness.IllnessName = reader["IllnessName"].ToString();
                        illness.IllnessDescription = reader["IllnessDescription"].ToString();
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
    }
}
