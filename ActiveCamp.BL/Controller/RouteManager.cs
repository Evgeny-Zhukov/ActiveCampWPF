using ActiveCamp.BL.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace ActiveCamp.BL.Controller
{
    public class RouteManager
    {
        private ActiveCampDbContext dbContext;
        private SqlConnection _connection;
        public RouteManager()
        {
            dbContext = new ActiveCampDbContext();
            _connection = dbContext.GetSqlConnection();
        }
        public bool AddRoute(Route route)
        {
            using (_connection)
            {
                _connection.Open();
                SqlCommand command = new SqlCommand("AddRoute", _connection);
                command.CommandType = CommandType.StoredProcedure;
                SqlParameter successParameter = new SqlParameter("@success", SqlDbType.Bit);
                successParameter.Direction = ParameterDirection.Output;
                command.Parameters.Add(successParameter);
                command.Parameters.AddWithValue("@AuthorID", route.AuthorId);
                command.Parameters.AddWithValue("@RouteName", route.RouteName);
                command.Parameters.AddWithValue("@StartData", route.StartDate);
                command.Parameters.AddWithValue("@EndData", route.EndDate);
                command.Parameters.AddWithValue("@Description", route.Description);
                command.Parameters.AddWithValue("@StartPoint", route.StartPoint);
                command.Parameters.AddWithValue("@EndPoint", route.EndPoint);
                command.Parameters.AddWithValue("@LengthInKm", route.Length);
                command.Parameters.AddWithValue("@Difficulty", route.Difficulty);
                command.Parameters.AddWithValue("@MemberCount", route.MemberCount);
                command.Parameters.AddWithValue("@IsPrivate", route.IsPrivate);

                command.ExecuteNonQuery();
                bool success = (bool)successParameter.Value;
                return success;
            }
        }
        public List<Route> GetRouteById(int AuthorId)
        {
            List<Route> routes = new List<Route>();

            using (_connection)
            {
                string query = "SELECT * FROM HikingRoutes WHERE AuthorID = @Id";

                SqlCommand command = new SqlCommand(query, _connection);
                command.Parameters.AddWithValue("@Id", AuthorId);

                try
                {
                    _connection.Open();
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Route route = new Route();
                            {
                                route.RouteId = Convert.ToInt32(reader["RouteId"]);
                                route.AuthorId = Convert.ToInt32(reader["AuthorID"]);
                                route.Duration = Convert.ToInt32(reader["DurationInDays"]);
                                route.RouteName = (reader["RouteName"].ToString());
                                route.Description = (reader["Description"].ToString());
                                route.Length = Convert.ToInt32(reader["LengthInKm"]);
                                route.StartDate = (Convert.ToDateTime(reader["StartDate"]));
                                route.EndDate = (Convert.ToDateTime(reader["EndDate"]));
                                route.StartPoint = (reader["StartPoint"].ToString());
                                route.EndPoint = (reader["EndPoint"].ToString());
                                route.Difficulty = (reader["Difficulty"].ToString());
                                route.MemberCount = Convert.ToInt32(reader["MemberCount"]);
                                route.IsPrivate = Convert.ToBoolean(reader["IsPrivate"]);
                            }
                            routes.Add(route);
                        }
                    }      
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error: " + ex.Message);
                }
            }
            return routes;
        }

        public List<Route> GetRouteList()
        {
            List<Route> routes = new List<Route>();

            using (_connection)
            {
                string query = "SELECT * FROM HikingRoutes";

                SqlCommand command = new SqlCommand(query, _connection);

                try
                {
                    _connection.Open();
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Route route = new Route();
                            {
                                route.RouteId = Convert.ToInt32(reader["RouteId"]);
                                route.AuthorId = Convert.ToInt32(reader["AuthorID"]);
                                route.Duration = Convert.ToInt32(reader["DurationInDays"]);
                                route.RouteName = (reader["RouteName"].ToString());
                                route.Description = (reader["Description"].ToString());
                                route.Length = Convert.ToInt32(reader["LengthInKm"]);
                                route.StartDate = (Convert.ToDateTime(reader["StartDate"]));
                                route.EndDate = (Convert.ToDateTime(reader["EndDate"]));
                                route.StartPoint = (reader["StartPoint"].ToString());
                                route.EndPoint = (reader["EndPoint"].ToString());
                                route.Difficulty = (reader["Difficulty"].ToString());
                                route.MemberCount = Convert.ToInt32(reader["MemberCount"]);
                                route.IsPrivate = Convert.ToBoolean(reader["IsPrivate"]);
                            }
                            routes.Add(route);
                        }
                    }      
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error: " + ex.Message);
                }
            }
            return routes;
        }
        public List<Route> GetAllRoutes()
        {
            List<Route> routes = new List<Route>();

            using (_connection)
            {
                string query = "SELECT * FROM HikingRoutes";

                SqlCommand command = new SqlCommand(query, _connection);

                try
                {
                    _connection.Open();
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Route route = new Route();
                            {
                                route.RouteId = Convert.ToInt32(reader["RouteId"]);
                                route.AuthorId = Convert.ToInt32(reader["AuthorID"]);
                                route.Duration = Convert.ToInt32(reader["DurationInDays"]);
                                route.RouteName = (reader["RouteName"].ToString());
                                route.Description = (reader["Description"].ToString());
                                route.Length = Convert.ToInt32(reader["LengthInKm"]);
                                route.StartDate = (Convert.ToDateTime(reader["StartDate"]));
                                route.EndDate = (Convert.ToDateTime(reader["EndDate"]));
                                route.StartPoint = (reader["StartPoint"].ToString());
                                route.EndPoint = (reader["EndPoint"].ToString());
                                route.Difficulty = (reader["Difficulty"].ToString());
                                route.MemberCount = Convert.ToInt32(reader["MemberCount"]);
                                route.IsPrivate = Convert.ToBoolean(reader["IsPrivate"]);
                            }
                            routes.Add(route);
                        }
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error: " + ex.Message);
                }
            }
            return routes;
        }

        public bool UpdateRoute(Route route)
        {
            using (_connection)
            {

                SqlCommand command = new SqlCommand("UpdateRoutes", _connection);
                command.CommandType = CommandType.StoredProcedure;
                SqlParameter successParameter = new SqlParameter("@success", SqlDbType.Bit);
                successParameter.Direction = ParameterDirection.Output;
                command.Parameters.Add(successParameter);

                command.Parameters.AddWithValue("@RouteId", route.RouteId);
                command.Parameters.AddWithValue("@RouteName", route.RouteName);
                command.Parameters.AddWithValue("@AuthorID", route.AuthorId);
                command.Parameters.AddWithValue("@StartDate", route.StartDate);
                command.Parameters.AddWithValue("@EndDate", route.EndDate);
                command.Parameters.AddWithValue("@Description", route.Description);
                command.Parameters.AddWithValue("@StartPoint", route.StartPoint);
                command.Parameters.AddWithValue("@EndPoint", route.EndPoint);
                command.Parameters.AddWithValue("@LengthInKm", route.Length);
                command.Parameters.AddWithValue("@DurationInDays", route.Duration);
                command.Parameters.AddWithValue("@Difficulty", route.Difficulty);
                command.Parameters.AddWithValue("@MemberCount", route.MemberCount);
                command.Parameters.AddWithValue("@IsPrivate", route.IsPrivate);
                
                _connection.Open();
                command.ExecuteNonQuery();
                bool success = (bool)successParameter.Value;
                return success;
            }
        }
        public bool DeleteRoute(int routeId)
        {
            using (_connection)
            {
                SqlCommand command = new SqlCommand("DeleateRouteById", _connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@RouteID", routeId);
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
