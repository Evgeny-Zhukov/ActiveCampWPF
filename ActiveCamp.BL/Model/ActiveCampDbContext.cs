using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Security.Cryptography;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ActiveCamp.BL.Model
{
    // TODO: Можно выгрузить в xml 
    public class ActiveCampDbContext
    {
        private readonly string connectionString = "Server=DESKTOP-VJNL8L9;Database = HikingAppDB;Trusted_Connection=True;MultipleActiveResultSets=True";

        public ActiveCampDbContext()
        {
        }

        public static SqlConnection GetSqlConnection()
        {
            string connectionString = ConfigurationManager.ConnectionStrings["Server=DESKTOP-VJNL8L9;Database = HikingAppDB;Trusted_Connection=True;MultipleActiveResultSets=True"].ConnectionString; // TODO: Сделать явное преобразование (string)
            SqlConnection connection = new SqlConnection(connectionString);
            return connection;
        }
        #region User 2/4
        public bool RegisterUser(User user)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                byte[] salt = new byte[16];
                using (var rng = new RNGCryptoServiceProvider())
                {
                    rng.GetBytes(salt);
                }

                byte[] hash = HashPasswordWithSalt(user.Password, salt);

                SqlCommand command = new SqlCommand("CreateUser", connection)
                {
                    CommandType = CommandType.StoredProcedure
                };
                command.Parameters.AddWithValue("@Username", user.Username);
                command.Parameters.AddWithValue("@PasswordHash", hash);
                command.Parameters.AddWithValue("@Salt", salt);

                SqlParameter successParameter = new SqlParameter("@Success", SqlDbType.Bit)
                {
                    Direction = ParameterDirection.Output
                };
                command.Parameters.Add(successParameter);

                connection.Open();
                command.ExecuteNonQuery();

                return (bool)successParameter.Value;
                return (bool)successParameter.Value;
            }
        }
        public bool ValidateUser(string username, string password)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand("GetUserByUsername", connection)
                {
                    CommandType = CommandType.StoredProcedure
                };
                command.Parameters.AddWithValue("@Username", username);

                connection.Open();
                using (var reader = command.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        byte[] storedHash = (byte[])reader["PasswordHash"];
                        byte[] storedSalt = (byte[])reader["Salt"];

                        byte[] enteredHash = HashPasswordWithSalt(password, storedSalt);

                        return storedHash.SequenceEqual(enteredHash);
                    }
                }
            }

            return false;
        }
        private byte[] HashPasswordWithSalt(string password, byte[] salt)
        {
            using (var rfc2898 = new Rfc2898DeriveBytes(password, salt, 10000))
            {
                return rfc2898.GetBytes(64);
            }
        }
        public User GetUserById(int userId)
        {
            using (var connection = new SqlConnection(connectionString))
            {
                var command = new SqlCommand("GetUserById", connection)
                {
                    CommandType = CommandType.StoredProcedure
                };
                command.Parameters.AddWithValue("@UserID", userId);

                connection.Open();
                using (var reader = command.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        return new User
                        {
                            UserID = (int)reader["UserId"],
                            Username = reader["Username"].ToString(),
                        };
                    }
                }
            }

            return null;
        }
        #endregion
        #region Route 4/4
        public bool AddRoute(Route route)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {

                SqlCommand command = new SqlCommand("AddRoute", connection);
                command.CommandType = CommandType.StoredProcedure;
                SqlParameter successParameter = new SqlParameter("@success", SqlDbType.Bit);
                successParameter.Direction = ParameterDirection.Output;
                command.Parameters.Add(successParameter);
                command.Parameters.AddWithValue("@Difficulty", route.Difficulty);
                command.Parameters.AddWithValue("@StartData", route.StartDate);
                command.Parameters.AddWithValue("@EndData", route.EndDate);
                command.Parameters.AddWithValue("@Description", route.Description);
                command.Parameters.AddWithValue("@StartPoint", route.StartPoint);
                command.Parameters.AddWithValue("@EndPoint", route.EndPoint);
                connection.Open();
                command.ExecuteNonQuery();
                bool success = (bool)successParameter.Value;
                return success;
            }
        }
        public Route GetRouteById(int id)
        {
            Route route = new Route();

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "SELECT * FROM HikingRoutes WHERE RouteId = @Id";

                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@Id", id);

                try
                {
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();

                    if (reader.Read())
                    {
                        // Чтение данных маршрута из результата запроса
                        route.RouteId = Convert.ToInt32(reader["RouteId"]);
                        route.RouteName = reader["RouteName"].ToString();
                        route.Description = reader["Description"].ToString();
                        route.StartDate = Convert.ToDateTime(reader["StartDate"]);
                        route.EndDate = Convert.ToDateTime(reader["EndDate"]);
                        route.StartPoint = reader["StartPoint"].ToString();
                        route.EndPoint = reader["EndPoint"].ToString();
                        route.Difficulty = reader["Difficulty"].ToString();
                    }
                    reader.Close();
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error: " + ex.Message);
                }
            }
            return route;
        }
        public bool UpdateRoute(Route route)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {

                SqlCommand command = new SqlCommand("UpdateRoute", connection);
                command.CommandType = CommandType.StoredProcedure;
                SqlParameter successParameter = new SqlParameter("@success", SqlDbType.Bit);
                successParameter.Direction = ParameterDirection.Output;
                command.Parameters.Add(successParameter);
                command.Parameters.AddWithValue("@routeName", route.RouteName);
                command.Parameters.AddWithValue("@DurationInDays", route.Duration);
                command.Parameters.AddWithValue("@LengthInKm", route.Length);
                command.Parameters.AddWithValue("@Difficulty", route.Difficulty);
                command.Parameters.AddWithValue("@AuthorID", route.AuthorId);
                connection.Open();
                command.ExecuteNonQuery();
                bool success = (bool)successParameter.Value;
                return success;
            }
        }
        public bool DeleteRoute(int routeId)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand("DeleateRouteById", connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@RouteID", routeId);
                SqlParameter successParameter = new SqlParameter("@success", SqlDbType.Bit);
                successParameter.Direction = ParameterDirection.Output;
                command.Parameters.Add(successParameter);
                connection.Open();
                command.ExecuteNonQuery();
                bool success = (bool)successParameter.Value;
                return success;
            }
        }
        #endregion
        #region FoodConsumption 3/4
        public bool AddFoodConsumption(FoodConsumption foodConsuption)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand("AddFoodConsumption", connection);
                command.CommandType = CommandType.StoredProcedure;
                SqlParameter successParameter = new SqlParameter("@success", SqlDbType.Bit);
                successParameter.Direction = ParameterDirection.Output;
                command.Parameters.Add(successParameter);
                command.Parameters.AddWithValue("@RouteID", foodConsuption.Route.RouteId);
                command.Parameters.AddWithValue("@StringNumber", foodConsuption.StringNumber);
                command.Parameters.AddWithValue("@Dish", foodConsuption.Dish);
                command.Parameters.AddWithValue("@ConsumptionTime", foodConsuption.ConsumptionTime);
                command.Parameters.AddWithValue("@DayOfRoute", foodConsuption.DayOfRoute);
                command.Parameters.AddWithValue("@AmountPerPerson", foodConsuption.AmountPerPerson);
                command.Parameters.AddWithValue("@AmountPerGroup", foodConsuption.AmountPerGroup);
                connection.Open();
                command.ExecuteNonQuery();
                bool success = (bool)successParameter.Value;
                return success;
            }
        }
        public FoodConsumption GetFoodConsumptionByID(int id)
        {
            FoodConsumption foodConsuption = new FoodConsumption();

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "SELECT * FROM HikingRoutes WHERE RouteId = @Id";

                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@Id", id);

                try
                {
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();

                    if (reader.Read())
                    {
                        // Чтение данных маршрута из результата запроса
                        foodConsuption.FCId = Convert.ToInt32(reader["ID"]);
                        foodConsuption.Route.RouteId = Convert.ToInt32(reader["RouteID"]);
                        foodConsuption.StringNumber = Convert.ToInt32(reader["StringNumber"]);
                        foodConsuption.Dish = reader["Dish"].ToString();
                        foodConsuption.ConsumptionTime = reader["ConsumptionTime"].ToString();
                        foodConsuption.DayOfRoute = Convert.ToInt32(reader["DayOfRoute"]);
                        foodConsuption.AmountPerPerson = Convert.ToInt32(reader["AmountPerPerson"]);
                        foodConsuption.AmountPerGroup = Convert.ToInt32(reader["AmountPerGroup"]);
                    }
                    reader.Close();
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error: " + ex.Message);
                }
            }
            return foodConsuption;
        }
        public bool DeleteFoodConsumption(int id)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand("DeleateFoodConsumptionById", connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@ID", id);
                SqlParameter successParameter = new SqlParameter("@success", SqlDbType.Bit);
                successParameter.Direction = ParameterDirection.Output;
                command.Parameters.Add(successParameter);
                connection.Open();
                command.ExecuteNonQuery();
                bool success = (bool)successParameter.Value;
                return success;
            }
        }
        #endregion
        #region SyrveyResult 3/4
        public bool AddSurveyResults(Questionnaire questionnaire)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand("AddQuestionnaire", connection);
                command.CommandType = CommandType.StoredProcedure;
                SqlParameter successParameter = new SqlParameter("@success", SqlDbType.Bit);
                successParameter.Direction = ParameterDirection.Output;
                command.Parameters.Add(successParameter);
                command.Parameters.AddWithValue("@QuestionId", questionnaire.QuestionId);
                command.Parameters.AddWithValue("@UserId", questionnaire.UserId);
                command.Parameters.AddWithValue("@Ratings", questionnaire.Rating);
                connection.Open();
                command.ExecuteNonQuery();
                bool success = (bool)successParameter.Value;
                return success;
            }
        }
        public Questionnaire GetSurveyResults(int UserID, int QuestionID)
        {
            Questionnaire questionnaire = new Questionnaire();

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "SELECT * FROM Questionnaire WHERE UserId = @UserId AND QuestionId = @QuestionId";

                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@UserId", UserID);
                command.Parameters.AddWithValue("@QuestionId", QuestionID);

                try
                {
                    connection.Open();
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
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand("DeleateFoodConsumptionById", connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@ID", id);
                SqlParameter successParameter = new SqlParameter("@success", SqlDbType.Bit);
                successParameter.Direction = ParameterDirection.Output;
                command.Parameters.Add(successParameter);
                connection.Open();
                command.ExecuteNonQuery();
                bool success = (bool)successParameter.Value;
                return success;
            }
        }
        #endregion
        #region UserIllness 3/4
        public bool AddUserIllness(Illness illness)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand("AddUserIllness", connection);
                command.CommandType = CommandType.StoredProcedure;
                SqlParameter successParameter = new SqlParameter("@success", SqlDbType.Bit);
                successParameter.Direction = ParameterDirection.Output;
                command.Parameters.Add(successParameter);
                command.Parameters.AddWithValue("@Name", illness.IllnessName);
                connection.Open();
                command.ExecuteNonQuery();
                bool success = (bool)successParameter.Value;
                return success;
            }
        }
        public Illness GetUserIllness(int IllnessID, int UserID)
        {
            Illness userIllness = new Illness();

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "SELECT * FROM UserIllness WHERE UserID = @UserID AND IllnessID = @IllnessID";

                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@IllnessID", IllnessID);
                command.Parameters.AddWithValue("@UserID", UserID);
                try
                {
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();

                    if (reader.Read())
                    {
                        // Чтение данных маршрута из результата запроса
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
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand("DeleateUserIllnessById", connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@ID", id);
                SqlParameter successParameter = new SqlParameter("@success", SqlDbType.Bit);
                successParameter.Direction = ParameterDirection.Output;
                command.Parameters.Add(successParameter);
                connection.Open();
                command.ExecuteNonQuery();
                bool success = (bool)successParameter.Value;
                return success;
            }
        }
        #endregion
        #region UserEquipment 3/4
        public bool AddUserEquipment(UserEquipment userEquipment)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand("AddUserEquipment", connection);
                command.CommandType = CommandType.StoredProcedure;
                SqlParameter successParameter = new SqlParameter("@success", SqlDbType.Bit);
                successParameter.Direction = ParameterDirection.Output;
                command.Parameters.Add(successParameter);
                command.Parameters.AddWithValue("@EquipmentID", userEquipment.EquipmentID);
                command.Parameters.AddWithValue("@UserID", userEquipment.UserID);
                connection.Open();
                command.ExecuteNonQuery();
                bool success = (bool)successParameter.Value;
                return success;
            }
        }
        public UserEquipment GetUserEquipment(int EquipmentID, int UserID)
        {
            UserEquipment userEquipment = new UserEquipment();

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "SELECT * FROM UserEquipment WHERE UserID = @UserID AND EquipmentID = @EquipmentID";

                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@EquipmentID", EquipmentID);
                command.Parameters.AddWithValue("@UserID", UserID);
                try
                {
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();

                    if (reader.Read())
                    {
                        // Чтение данных маршрута из результата запроса
                        userEquipment.EquipmentID = Convert.ToInt32(reader["EquipmentID"]);
                        userEquipment.UserID = Convert.ToInt32(reader["UserID"]);
                    }
                    reader.Close();
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error: " + ex.Message);
                }
            }
            return userEquipment;
        }
        public bool DeleteUserEquipment(int id)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand("DeleteUserEquipmentById", connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@UserEquipmentID", id);
                SqlParameter successParameter = new SqlParameter("@success", SqlDbType.Bit);
                successParameter.Direction = ParameterDirection.Output;
                command.Parameters.Add(successParameter);
                connection.Open();
                command.ExecuteNonQuery();
                bool success = (bool)successParameter.Value;
                return success;
            }
        }
        #endregion
        #region UserDish 3/4
        public bool AddUserDish(UserDish userDish)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand("AddUserDishes", connection);
                command.CommandType = CommandType.StoredProcedure;
                SqlParameter successParameter = new SqlParameter("@success", SqlDbType.Bit);
                successParameter.Direction = ParameterDirection.Output;
                command.Parameters.Add(successParameter);
                command.Parameters.AddWithValue("@DishID", userDish.DishID);
                command.Parameters.AddWithValue("@UserID", userDish.UserID);
                connection.Open();
                command.ExecuteNonQuery();
                bool success = (bool)successParameter.Value;
                return success;
            }
        }
        public UserDish GetUserDish(int DishID, int UserID)
        {
            UserDish userDish = new UserDish();

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "SELECT * FROM UserDishes WHERE UserID = @UserID AND DishesID = @DishesID";

                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@DishesID", DishID);
                command.Parameters.AddWithValue("@UserID", UserID);
                try
                {
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();

                    if (reader.Read())
                    {
                        // Чтение данных маршрута из результата запроса
                        userDish.DishID = Convert.ToInt32(reader["EquipmentID"]);
                        userDish.UserID = Convert.ToInt32(reader["UserID"]);
                    }
                    reader.Close();
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error: " + ex.Message);
                }
            }
            return userDish;
        }
        public bool DeleteUserDish(int id)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand("DeleteUserDishById", connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@UserDishID", id);
                SqlParameter successParameter = new SqlParameter("@success", SqlDbType.Bit);
                successParameter.Direction = ParameterDirection.Output;
                command.Parameters.Add(successParameter);
                connection.Open();
                command.ExecuteNonQuery();
                bool success = (bool)successParameter.Value;
                return success;
            }
        }
        #endregion
        #region Equipment 3/4
        public bool AddEquipment(Equipment equipment)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand("AddEquipment", connection);
                command.CommandType = CommandType.StoredProcedure;
                SqlParameter successParameter = new SqlParameter("@success", SqlDbType.Bit);
                successParameter.Direction = ParameterDirection.Output;
                command.Parameters.Add(successParameter);
                command.Parameters.AddWithValue("@equipmentName", equipment.equipmentName);
                command.Parameters.AddWithValue("@equipmentWeight", equipment.equipmentWeight);
                connection.Open();
                command.ExecuteNonQuery();
                bool success = (bool)successParameter.Value;
                return success;
            }
        }
        public Equipment GetEquipment(int equipmentID)
        {
            Equipment equipment = new Equipment();

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "SELECT * FROM Equipment WHERE equipmentID = @equipmentID";

                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@equipmentID", equipmentID);
                try
                {
                    connection.Open();
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
        public bool DeleteEquipment(int id)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand("DeleateEquipmentById", connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@equipmentID", id);
                SqlParameter successParameter = new SqlParameter("@success", SqlDbType.Bit);
                successParameter.Direction = ParameterDirection.Output;
                command.Parameters.Add(successParameter);
                connection.Open();
                command.ExecuteNonQuery();
                bool success = (bool)successParameter.Value;
                return success;
            }
        }
        #endregion
        #region Dish 3/4
        public bool AddDish(Dish dish)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand("AddDish", connection);
                command.CommandType = CommandType.StoredProcedure;
                SqlParameter successParameter = new SqlParameter("@success", SqlDbType.Bit);
                successParameter.Direction = ParameterDirection.Output;
                command.Parameters.Add(successParameter);
                command.Parameters.AddWithValue("@Name", dish.Name);
                command.Parameters.AddWithValue("@Proteins", dish.Proteins);
                command.Parameters.AddWithValue("@Fats", dish.Fats);
                command.Parameters.AddWithValue("@Carbohydrates", dish.Carbohydrates);
                command.Parameters.AddWithValue("@Calories", dish.Calories);
                connection.Open();
                command.ExecuteNonQuery();
                bool success = (bool)successParameter.Value;
                return success;
            }
        }
        public Dish GetDish(int DishID)
        {
            Dish dish = new Dish();

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "SELECT * FROM Dish WHERE DishID = @DishID";

                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@DishID", DishID);
                try
                {
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();

                    if (reader.Read())
                    {
                        // Чтение данных маршрута из результата запроса
                        dish.DishID = Convert.ToInt32(reader["DishID"]);
                        dish.Name = reader["Name"].ToString();
                        dish.Proteins = Convert.ToDouble(reader["Proteins"]);
                        dish.Fats = Convert.ToDouble(reader["Fats"]);
                        dish.Carbohydrates = Convert.ToDouble(reader["Carbohydrates"]);
                        dish.Calories = Convert.ToDouble(reader["Calories"]);
                    }
                    reader.Close();
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error: " + ex.Message);
                }
            }
            return dish;
        }
        public bool DeleteDish(int id)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand("DeleateDishById", connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@DishID", id);
                SqlParameter successParameter = new SqlParameter("@success", SqlDbType.Bit);
                successParameter.Direction = ParameterDirection.Output;
                command.Parameters.Add(successParameter);
                connection.Open();
                command.ExecuteNonQuery();
                bool success = (bool)successParameter.Value;
                return success;
            }
        }
        #endregion 
        #region Illness 3/4
        public bool AddIllness(Illness illness)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand("AddIllness", connection);
                command.CommandType = CommandType.StoredProcedure;
                SqlParameter successParameter = new SqlParameter("@success", SqlDbType.Bit);
                successParameter.Direction = ParameterDirection.Output;
                command.Parameters.Add(successParameter);
                command.Parameters.AddWithValue("@IllnessID", illness.IllnessID);
                command.Parameters.AddWithValue("@IllnessName", illness.IllnessName);
                command.Parameters.AddWithValue("@IllnessDescription", illness.IllnessDescription);
                connection.Open();
                command.ExecuteNonQuery();
                bool success = (bool)successParameter.Value;
                return success;
            }
        }
        public Illness GetIllness(int IllnessID)
        {
            Illness illness = new Illness();

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "SELECT * FROM Illness WHERE IllnessID = @IllnessID";

                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@IllnessID", IllnessID);
                try
                {
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();

                    if (reader.Read())
                    {
                        // Чтение данных маршрута из результата запроса
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
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand("DeleateIllnessById", connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@IllnessID", id);
                SqlParameter successParameter = new SqlParameter("@success", SqlDbType.Bit);
                successParameter.Direction = ParameterDirection.Output;
                command.Parameters.Add(successParameter);
                connection.Open();
                command.ExecuteNonQuery();
                bool success = (bool)successParameter.Value;
                return success;
            }
        }
        #endregion
        #region Group
        public Group CreateGroup(int routeId, string invitationLink)
        {
            using (var connection = new SqlConnection(connectionString))
            {
                var command = new SqlCommand("CreateGroup", connection)
                {
                    CommandType = CommandType.StoredProcedure
                };
                command.Parameters.AddWithValue("@RouteID", routeId);
                command.Parameters.AddWithValue("@InvitationLink", invitationLink);

                var groupIdParam = new SqlParameter("@GroupID", SqlDbType.Int)
                {
                    Direction = ParameterDirection.Output
                };
                command.Parameters.Add(groupIdParam);

                connection.Open();
                command.ExecuteNonQuery();
                int groupId = (int)groupIdParam.Value;

                return new Group { GroupId = groupId, RouteId = routeId, InvitationLink = invitationLink };
            }
        }

        public void AddUserToGroup(int groupId, int userId)
        {
            using (var connection = new SqlConnection(connectionString))
            {
                var command = new SqlCommand("AddUserToGroup", connection)
                {
                    CommandType = CommandType.StoredProcedure
                };
                command.Parameters.AddWithValue("@GroupId", groupId);
                command.Parameters.AddWithValue("@UserId", userId);

                connection.Open();
                command.ExecuteNonQuery();
            }
        }

        public List<User> GetUsersInGroup(int groupId)
        {
            var users = new List<User>();

            using (var connection = new SqlConnection(connectionString))
            {
                var command = new SqlCommand("GetUsersInGroup", connection)
                {
                    CommandType = CommandType.StoredProcedure
                };
                command.Parameters.AddWithValue("@GroupId", groupId);

                connection.Open();
                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        users.Add(new User
                        {
                            UserID = (int)reader["UserId"],
                            Username = reader["UserName"].ToString(),
                        });
                    }
                }
            }

            return users;
        }
        #endregion
    }
}
