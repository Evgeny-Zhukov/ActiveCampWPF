using ActiveCamp.BL.Model;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;

namespace ActiveCamp.BL.Controller
{
    public class NewsController
    {
        private ActiveCampDbContext dbContext;
        private SqlConnection _connection;

        public NewsController()
        {
            dbContext = new ActiveCampDbContext();
            _connection = dbContext.GetSqlConnection();
        }

        public bool AddNews(News news)
        {
            using (_connection)
            {
                SqlCommand command = new SqlCommand("AddNews", _connection);
                command.CommandType = CommandType.StoredProcedure;

                SqlParameter successParameter = new SqlParameter("@success", SqlDbType.Bit);
                successParameter.Direction = ParameterDirection.Output;
                command.Parameters.Add(successParameter);

                command.Parameters.AddWithValue("@AuthorID", news.AuthorID);
                command.Parameters.AddWithValue("@NewsText", news.NewsText);
                command.Parameters.AddWithValue("@NewsDate", news.NewsDate);
                command.Parameters.AddWithValue("@IsAdminNews", news.IsAdminNews);

                _connection.Open();
                command.ExecuteNonQuery();
                bool success = (bool)successParameter.Value;
                return success;
            }
        }

        public List<News> GetNews(int AuthorId)
        {
            List<News> newses = new List<News>();

            using (_connection)
            {
                string query = "SELECT * FROM Dish WHERE AuthorId = @AuthorId";

                SqlCommand command = new SqlCommand(query, _connection);
                command.Parameters.AddWithValue("@AuthorId", AuthorId);

                try
                {
                    _connection.Open();

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            News news = new News();
                            {
                                news.NewsID = Convert.ToInt32(reader["NewsID"]);
                                news.AuthorID = Convert.ToInt32(reader["AuthorID"]);
                                news.NewsText = (reader["NewsText"].ToString());
                                news.IsAdminNews = (Convert.ToBoolean(reader["IsAdminNews"]));

                            }
                            newses.Add(news);
                        }
                    }

                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error: " + ex.Message);
                }
            }
            return newses;
        }

        public bool UpdateNews(News news)
        {
            using (_connection)
            {
                SqlCommand command = new SqlCommand("UpdateNews", _connection);
                command.CommandType = CommandType.StoredProcedure;

                SqlParameter successParameter = new SqlParameter("@success", SqlDbType.Bit);
                successParameter.Direction = ParameterDirection.Output;
                command.Parameters.Add(successParameter);

                command.Parameters.AddWithValue("@NewsText", news.NewsText);
                command.Parameters.AddWithValue("@NewsDate", news.NewsDate);
                command.Parameters.AddWithValue("@IsAdminNews", news.IsAdminNews);

                _connection.Open();
                command.ExecuteNonQuery();
                bool success = (bool)successParameter.Value;
                return success;
            }
        }
        public bool DeleteNews(int id)
        {
            using (_connection)
            {
                SqlCommand command = new SqlCommand("DeleteNewsById", _connection);
                command.CommandType = CommandType.StoredProcedure;

                command.Parameters.AddWithValue("@NewsID", id);

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
