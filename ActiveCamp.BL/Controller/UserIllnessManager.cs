using ActiveCamp.BL.Model;
using System;
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
        public Illness GetUserIllness(int IllnessID, int UserID)
        {
            Illness userIllness = new Illness();

            using (_connection)
            {
                string query = "SELECT * FROM UserIllness WHERE UserID = @UserID AND IllnessID = @IllnessID";

                SqlCommand command = new SqlCommand(query, _connection);
                command.Parameters.AddWithValue("@IllnessID", IllnessID);
                command.Parameters.AddWithValue("@UserID", UserID);
                try
                {
                    _connection.Open();
                    SqlDataReader reader = command.ExecuteReader();

                    if (reader.Read())
                    {
                        userIllness.IllnessID = Convert.ToInt32(reader["IllnessID"]);
                        userIllness.IllnessName = reader["Name"].ToString();
                    }
                    reader.Close();
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error: " + ex.Message);
                }
            }
            return userIllness;
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
