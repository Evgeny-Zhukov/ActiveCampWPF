using ActiveCamp.BL.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace ActiveCamp.BL.Controller
{
    public class GroupEquipmentManager
    {
        private ActiveCampDbContext dbContext;
        private SqlConnection _connection;
        public GroupEquipmentManager()
        {
            dbContext = new ActiveCampDbContext();
            _connection = dbContext.GetSqlConnection();
        }
        public bool AddGroupEquipment(List<GroupEquipment> groupEquipment)
        {

            using (_connection)
            {
                _connection.Open();
                using (SqlCommand command = new SqlCommand("AddGroupEquipment", _connection))
                {
                    command.CommandType = CommandType.StoredProcedure;

                    SqlParameter successParameter = new SqlParameter("@success", SqlDbType.Bit);
                    successParameter.Direction = ParameterDirection.Output;
                    command.Parameters.Add(successParameter);

                    SqlParameter GroupEquipmentParameter = new SqlParameter("@GroupEquipmentID", SqlDbType.Int);
                    GroupEquipmentParameter.Direction = ParameterDirection.Output;
                    command.Parameters.Add(GroupEquipmentParameter);

                    try
                    {
                        foreach (var item in groupEquipment)
                        {
                            command.Parameters.Clear();

                            command.Parameters.Add(new SqlParameter("@GroupID", item.GroupID));
                            command.Parameters.Add(new SqlParameter("@UserID", item.UserID));
                            command.Parameters.Add(new SqlParameter("@EquipmentName", item.EquipmentName));
                            command.Parameters.Add(new SqlParameter("@Weigth", item.Weigth));
                            command.Parameters.Add(new SqlParameter("@Count", item.Count));

                            command.Parameters.Add(successParameter);
                            command.Parameters.Add(GroupEquipmentParameter);

                            command.ExecuteNonQuery();

                            item.GroupEquipmentID = (int)GroupEquipmentParameter.Value;
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

        public List<GroupEquipment> GetGroupEquipmentById(int groupID)
        {
            List<GroupEquipment> routes = new List<GroupEquipment>();

            using (_connection)
            {
                string query = "SELECT * FROM GroupEquipment WHERE GroupID = @GroupID";
                SqlCommand command = new SqlCommand(query, _connection);
                command.Parameters.AddWithValue("@GroupID", groupID);

                try
                {
                    _connection.Open();
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            GroupEquipment route = new GroupEquipment
                            {
                                GroupEquipmentID = Convert.ToInt32(reader["GroupEquipmentID"]),
                                GroupID = Convert.ToInt32(reader["GroupID"]),
                                UserID = Convert.ToInt32(reader["UserID"]),
                                EquipmentName = reader["EquipmentName"].ToString(),
                                Weigth = Convert.ToInt32(reader["Weigth"]),
                                Count = Convert.ToInt32(reader["Count"]),
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

        public bool UpdateGroupEquipment(GroupEquipment groupEquipment)
        {
            using (_connection)
            {
                using (SqlCommand command = new SqlCommand("UpdateGroupEquipment", _connection))
                {
                    command.CommandType = CommandType.StoredProcedure;

                    command.Parameters.Add(new SqlParameter("@GroupEquipmentID", groupEquipment.GroupEquipmentID));
                    command.Parameters.Add(new SqlParameter("@GroupID", groupEquipment.GroupID));
                    command.Parameters.Add(new SqlParameter("@UserID", groupEquipment.UserID));
                    command.Parameters.Add(new SqlParameter("@EquipmentName", groupEquipment.EquipmentName));
                    command.Parameters.Add(new SqlParameter("@Weigth", groupEquipment.Weigth));
                    command.Parameters.Add(new SqlParameter("@Count", groupEquipment.Count));

                    SqlParameter successParameter = new SqlParameter("@success", SqlDbType.Bit);
                    successParameter.Direction = ParameterDirection.Output;
                    command.Parameters.Add(successParameter);

                    try
                    {
                        _connection.Open();
                        command.ExecuteNonQuery();

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


        public bool DeleteGroupEquipment(int groupEquipmentID)
        {
            using (_connection)
            {
                SqlCommand command = new SqlCommand("DeleateGroupEquipmentById", _connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@GroupEquipmentID", groupEquipmentID);
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
