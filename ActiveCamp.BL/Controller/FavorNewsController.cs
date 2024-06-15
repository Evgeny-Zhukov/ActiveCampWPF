using ActiveCamp.BL.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ActiveCamp.BL.Controller
{
    public class FavorNewsController
    {
        private ActiveCampDbContext dbContext;
        private SqlConnection _connection;

        public FavorNewsController()
        {
            dbContext = new ActiveCampDbContext();
            _connection = dbContext.GetSqlConnection();
        }

        public bool AddFavorNews(FavorNews news)
        {
            using (_connection)
            {
                SqlCommand command = new SqlCommand("AddFavorNews", _connection);
                command.CommandType = CommandType.StoredProcedure;

                SqlParameter successParameter = new SqlParameter("@success", SqlDbType.Bit);
                successParameter.Direction = ParameterDirection.Output;
                command.Parameters.Add(successParameter);

                command.Parameters.AddWithValue("@AuthorID", news.AuthorID);
                command.Parameters.AddWithValue("@NewsID", news.NewsID);

                _connection.Open();
                command.ExecuteNonQuery();
                bool success = (bool)successParameter.Value;
                return success;
            }
        }

        public List<FavorNews> GetFavorNews(int AuthorId)
        {
            List<FavorNews> newses = new List<FavorNews>();

            using (_connection)
            {
                string query = "SELECT * FROM FavorNews WHERE AuthorId = @AuthorId";

                SqlCommand command = new SqlCommand(query, _connection);
                command.Parameters.AddWithValue("@AuthorId", AuthorId);

                try
                {
                    _connection.Open();

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            FavorNews news = new FavorNews();
                            {
                                news.NewsID = Convert.ToInt32(reader["NewsID"]);
                                news.AuthorID = Convert.ToInt32(reader["AuthorID"]);
                                news.FavorNewsID = Convert.ToInt32(reader["FavorNewsID"]);
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

        public bool UpdateFavorNews(FavorNews news)
        {
            using (_connection)
            {
                SqlCommand command = new SqlCommand("UpdateFavorNews", _connection);
                command.CommandType = CommandType.StoredProcedure;

                SqlParameter successParameter = new SqlParameter("@success", SqlDbType.Bit);
                successParameter.Direction = ParameterDirection.Output;
                command.Parameters.Add(successParameter);

                command.Parameters.AddWithValue("@AuthorID", news.AuthorID);
                command.Parameters.AddWithValue("@NewsID", news.NewsID);
                command.Parameters.AddWithValue("@FavorNewsID", news.FavorNewsID);

                _connection.Open();
                command.ExecuteNonQuery();
                bool success = (bool)successParameter.Value;
                return success;
            }
        }
        
        public bool DeleteNews(int newsId, int authorId)
        {
            using (_connection)
            {
                SqlCommand command = new SqlCommand("DeleteFavorNewsById", _connection);
                command.CommandType = CommandType.StoredProcedure;

                command.Parameters.AddWithValue("@NewsID", newsId);
                command.Parameters.AddWithValue("@AuthorID", authorId);

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
