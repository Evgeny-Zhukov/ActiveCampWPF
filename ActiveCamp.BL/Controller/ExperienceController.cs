using ActiveCamp.BL.Model;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;

namespace ActiveCamp.BL.Controller
{
    public class ExperienceController
    {
        private ActiveCampDbContext dbContext;
        private SqlConnection _connection;
        public ExperienceController()
        {
            dbContext = new ActiveCampDbContext();
            _connection = dbContext.GetSqlConnection();
        }
        public bool AddExperience(Experience experience)
        {
            using (_connection)
            {
                SqlCommand command = new SqlCommand("AddUserExperience", _connection);
                command.CommandType = CommandType.StoredProcedure;
                SqlParameter successParameter = new SqlParameter("@success", SqlDbType.Bit);
                successParameter.Direction = ParameterDirection.Output;
                command.Parameters.Add(successParameter);

                command.Parameters.AddWithValue("@ExperienceID", experience.ExperienceID);
                command.Parameters.AddWithValue("@RouteID", experience.RouteID);


                _connection.Open();
                command.ExecuteNonQuery();
                bool success = (bool)successParameter.Value;
                return success;
            }
        }

        public List<Experience> GetExperience(int experienceID)
        {
            List<Experience> experiences = new List<Experience>();

            using (_connection)
            {
                string query = "SELECT * FROM UserEquipment WHERE ExperienceID = @ExperienceID";

                SqlCommand command = new SqlCommand(query, _connection);

                command.Parameters.AddWithValue("@ExperienceID", experienceID);
                try
                {
                    _connection.Open();
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Experience experience = new Experience();
                            {
                                command.Parameters.AddWithValue("@ExperienceID", experience.ExperienceID);
                                command.Parameters.AddWithValue("@RouteID", experience.RouteID);
                            }
                            experiences.Add(experience);
                        }
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error: " + ex.Message);
                }
            }

            return experiences;
        }
        public bool DeleteExperience(int ExperienceID)
        {
            using (_connection)
            {
                SqlCommand command = new SqlCommand("DeleteExperienceById", _connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@ExperienceID", ExperienceID);
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
