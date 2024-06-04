using ActiveCamp.BL.Model;
using System;
using System.Data;
using System.Data.SqlClient;

namespace ActiveCamp.BL.Controller
{
    internal class SyrveyManager
    {
        private ActiveCampDbContext dbContext;
        private SqlConnection _connection;
        public SyrveyManager()
        {
            dbContext = new ActiveCampDbContext();
            _connection = dbContext.GetSqlConnection();
        }
        public bool AddSurveyResults(Questionnaire questionnaire)
        {
            using (_connection)
            {
                SqlCommand command = new SqlCommand("AddQuestionnaire", _connection);
                command.CommandType = CommandType.StoredProcedure;
                SqlParameter successParameter = new SqlParameter("@success", SqlDbType.Bit);
                successParameter.Direction = ParameterDirection.Output;
                command.Parameters.Add(successParameter);
                command.Parameters.AddWithValue("@QuestionId", questionnaire.QuestionId);
                command.Parameters.AddWithValue("@UserId", questionnaire.UserId);
                command.Parameters.AddWithValue("@Ratings", questionnaire.Rating);
                _connection.Open();
                command.ExecuteNonQuery();
                bool success = (bool)successParameter.Value;
                return success;
            }
        }
        public Questionnaire GetSurveyResults(int UserID, int QuestionID)
        {
            Questionnaire questionnaire = new Questionnaire();

            using (_connection)
            {
                string query = "SELECT * FROM Questionnaire WHERE UserId = @UserId AND QuestionId = @QuestionId";

                SqlCommand command = new SqlCommand(query, _connection);
                command.Parameters.AddWithValue("@UserId", UserID);
                command.Parameters.AddWithValue("@QuestionId", QuestionID);

                try
                {
                    _connection.Open();
                    SqlDataReader reader = command.ExecuteReader();

                    if (reader.Read())
                    {
                        // Чтение данных маршрута из результата запроса
                        questionnaire.QuestionId = Convert.ToInt32(reader["QuestionId"]);
                        questionnaire.UserId = Convert.ToInt32(reader["UserId"]);
                        questionnaire.Rating = Convert.ToInt32(reader["Rating"]);
                    }
                    reader.Close();
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error: " + ex.Message);
                }
            }
            return questionnaire;
        }
        public bool DeleteSurveyResults(int id)
        {
            using (_connection)
            {
                SqlCommand command = new SqlCommand("DeleateFoodConsumptionById", _connection);
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
