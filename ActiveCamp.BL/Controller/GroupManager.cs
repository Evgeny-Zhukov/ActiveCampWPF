using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;

namespace ActiveCamp.BL.Model
{
    public class GroupManager
    {
        private List<Group> groups = new List<Group>();
        private List<User> users = new List<User>();
        private List<GroupMembership> groupMemberships = new List<GroupMembership>();
        private ActiveCampDbContext dbContext;
        private SqlConnection _connection;

        /// <summary>
        /// Создает экземпляр GroupManager и устанавливает соединение с базой данных.
        /// </summary>
        public GroupManager()
        {
            dbContext = new ActiveCampDbContext();
            _connection = dbContext.GetSqlConnection();
        }

        public int CreateGroup(Group group)
        {
            using (_connection)
            {
                SqlCommand command = new SqlCommand("CreateGroup", _connection)
                {
                    CommandType = CommandType.StoredProcedure
                };
                command.Parameters.AddWithValue("@RouteID", group.RouteId);
                command.Parameters.AddWithValue("@GroupName", group.GroupName);
                command.Parameters.AddWithValue("@InvitationLink", group.InvitationLink);
                command.Parameters.AddWithValue("@AuthorID", group.AuthorID);

                SqlParameter groupIdParam = new SqlParameter("@GroupID", SqlDbType.Int)
                {
                    Direction = ParameterDirection.Output
                };
                command.Parameters.Add(groupIdParam);

                _connection.Open();
                command.ExecuteNonQuery();

                int id = (int)command.Parameters["@GroupID"].Value;

                return id;
            }
        }


        /// <summary>
        /// Добавляет пользователя в группу.
        /// </summary>
        /// <param name="groupId">Идентификатор группы</param>
        /// <param name="userId">Идентификатор пользователя</param>
        public void AddUserToGroup(int groupId, int userId)
        {
            using (_connection)
            {
                _connection.Open();
                using (SqlCommand command = new SqlCommand("INSERT INTO GroupMemberships (GroupID, UserID, JoinedDate, IsAproved) VALUES (@GroupID, @UserID, @JoinedDate, @IsAproved)", _connection))
                {
                    command.Parameters.AddWithValue("@GroupID", groupId);
                    command.Parameters.AddWithValue("@UserID", userId);
                    command.Parameters.AddWithValue("@JoinedDate", DateTime.Now);
                    command.Parameters.AddWithValue("@IsAproved", 0);

                    command.ExecuteNonQuery();
                }
            }
        }

        public Group GetGroups(int UserID)
        {
            Group group = new Group();

            using (_connection)
            {
                string query = "SELECT * FROM Groups WHERE AuthorID = @AuthorID";

                SqlCommand command = new SqlCommand(query, _connection);
                command.Parameters.AddWithValue("@AuthorID", UserID);
                try
                {
                    _connection.Open();
                    SqlDataReader reader = command.ExecuteReader();

                    if (reader.Read())
                    {
                        group.GroupId = Convert.ToInt32(reader["GroupId"]);
                        group.RouteId = Convert.ToInt32(reader["RouteId"]);
                        group.GroupName = reader["GroupName"].ToString();
                        group.InvitationLink = reader["InvitationLink"].ToString();
                        group.AuthorID = Convert.ToInt32(reader["AuthorID"]);
                    }
                    reader.Close();
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error: " + ex.Message);
                }
            }
            return group;
        }
        public List<Group> GetGroup(int UserID)
        {
            List<Group> groups = new List<Group>();

            using (_connection)
            {
                string query = "SELECT * FROM Groups WHERE AuthorID = @AuthorID";

                SqlCommand command = new SqlCommand(query, _connection);

                command.Parameters.AddWithValue("@AuthorID", UserID);
                try
                {
                    _connection.Open();
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Group group = new Group();
                            {
                                group.GroupId = Convert.ToInt32(reader["GroupId"]);
                                group.RouteId = Convert.ToInt32(reader["RouteId"]);
                                group.GroupName = reader["GroupName"].ToString();
                                group.InvitationLink = reader["InvitationLink"].ToString();
                                group.AuthorID = Convert.ToInt32(reader["AuthorID"]);
                            }
                            groups.Add(group);
                        }
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error: " + ex.Message);
                }
            }

            return groups;
        }
        /// <summary>
        /// Получает список пользователей в группе.
        /// </summary>
        /// <param name="groupId">Идентификатор группы</param>
        /// <returns>Возвращает список пользователей в группе</returns>
        public List<User> GetUsersInGroup(int groupId)
        {
            Group group = groups.FirstOrDefault(g => g.GroupId == groupId);

            if (group == null)
            {
                throw new Exception("Группа не обнаружена");
            }

            List<User> users = new List<User>();

            using (_connection)
            {
                SqlCommand command = new SqlCommand("GetUsersInGroup", _connection) 
                {
                    CommandType = CommandType.StoredProcedure
                };
                command.Parameters.AddWithValue("@GroupId", groupId);

                _connection.Open();
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        users.Add(new User((int)reader["UserId"], reader["UserName"].ToString()));
                    }
                }
            }

            return users;
        }
    }

}
