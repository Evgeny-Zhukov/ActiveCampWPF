using ActiveCamp.BL.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace ActiveCamp.BL.Controller
{
    public class GroupDishManager
    {
        private ActiveCampDbContext dbContext;
        private SqlConnection _connection;
        public GroupDishManager()
        {
            dbContext = new ActiveCampDbContext();
            _connection = dbContext.GetSqlConnection();
        }
        public bool AddGroupDish(List<GroupDish> groupDish)
        {
            using (_connection)
            {
                _connection.Open();
                using (SqlCommand command = new SqlCommand("AddGroupDish", _connection))
                {
                    command.CommandType = CommandType.StoredProcedure;

                    SqlParameter successParameter = new SqlParameter("@success", SqlDbType.Bit);
                    successParameter.Direction = ParameterDirection.Output;
                    command.Parameters.Add(successParameter);

                    try
                    {
                        foreach (var item in groupDish)
                        {
                            command.Parameters.Clear();

                            command.Parameters.Add(new SqlParameter("@GroupID", item.GroupID));
                            command.Parameters.Add(new SqlParameter("@RouteDay", item.RouteDay));
                            command.Parameters.Add(new SqlParameter("@DishName", item.DishName));
                            command.Parameters.Add(new SqlParameter("@Weigth1", item.Weigth1));
                            command.Parameters.Add(new SqlParameter("@WeigthAll", item.WeigthAll));
                            command.Parameters.Add(new SqlParameter("@DishTime", item.DishTime));
                            command.Parameters.Add(new SqlParameter("@Comment", item.Comment));

                            command.Parameters.Add(successParameter);

                            command.ExecuteNonQuery();
                        }

                        bool success = (bool)successParameter.Value;
                        return success;
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine("Error: " + ex.Message);
                        return false;
                    }
                }
            }
        }


        public List<GroupDish> GetGroupDishById(int groupID)
        {
            List<GroupDish> routes = new List<GroupDish>();

            using (_connection)
            {
                string query = "SELECT * FROM GroupDish WHERE GroupID = @GroupID";
                SqlCommand command = new SqlCommand(query, _connection);
                command.Parameters.AddWithValue("@GroupID", groupID);

                try
                {
                    _connection.Open();
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            GroupDish route = new GroupDish
                            {
                                GroupDishID = Convert.ToInt32(reader["GroupDishID"]),
                                GroupID = Convert.ToInt32(reader["GroupID"]),
                                RouteDay = Convert.ToInt32(reader["RouteDay"]),
                                DishName = reader["DishName"].ToString(),
                                Weigth1 = Convert.ToInt32(reader["Weigth1"]),
                                WeigthAll = Convert.ToInt32(reader["WeigthAll"]),
                                DishTime = reader["DishTime"].ToString(),
                                Comment = reader["Comment"].ToString()
                            };
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

        public bool UpdateGroupDish(GroupDish groupDish)
        {
            using (_connection)
            {

                SqlCommand command = new SqlCommand("UpdateGroupDish", _connection);
                command.CommandType = CommandType.StoredProcedure;
                SqlParameter successParameter = new SqlParameter("@success", SqlDbType.Bit);
                successParameter.Direction = ParameterDirection.Output;
                command.Parameters.Add(successParameter);

                command.Parameters.AddWithValue("@GroupDishID", groupDish.GroupDishID);
                command.Parameters.AddWithValue("@GroupID", groupDish.GroupID);
                command.Parameters.AddWithValue("@RouteDay", groupDish.RouteDay);
                command.Parameters.AddWithValue("@DishName", groupDish.DishName);
                command.Parameters.AddWithValue("@Weigth1", groupDish.Weigth1);
                command.Parameters.AddWithValue("@WeigthAll", groupDish.WeigthAll);
                command.Parameters.AddWithValue("@DishTime", groupDish.DishTime);
                command.Parameters.AddWithValue("@Comment", groupDish.Comment);

                _connection.Open();
                command.ExecuteNonQuery();
                bool success = (bool)successParameter.Value;
                return success;
            }
        }

        public bool DeleteGroupDish(int groupDishID)
        {
            using (_connection)
            {
                SqlCommand command = new SqlCommand("DeleateGroupDishById", _connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@GroupDishID", groupDishID);
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
