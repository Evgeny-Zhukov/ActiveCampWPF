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
        public GroupManager()
        {
            dbContext = new ActiveCampDbContext();
            _connection = dbContext.GetSqlConnection();
        }
        public Group CreateGroup(int routeId, string invitationLink)
        {
            Group newGroup = new Group
            {
                RouteId = routeId,
                InvitationLink = invitationLink
            };

            groups.Add(newGroup);

            using (_connection)
            {
                SqlCommand command = new SqlCommand("CreateGroup", _connection)
                {
                    CommandType = CommandType.StoredProcedure
                };
                command.Parameters.AddWithValue("@RouteID", routeId);
                command.Parameters.AddWithValue("@InvitationLink", invitationLink);

                SqlParameter groupIdParam = new SqlParameter("@GroupID", SqlDbType.Int)
                {
                    Direction = ParameterDirection.Output
                };
                command.Parameters.Add(groupIdParam);

                _connection.Open();
                command.ExecuteNonQuery();
                int groupId = (int)groupIdParam.Value;

                return newGroup;
            }
        }

        public void AddUserToGroup(int groupId, int userId)
        {
            Group group = groups.FirstOrDefault(g => g.GroupId == groupId);
            User user = users.FirstOrDefault(u => u.UserID == userId);

            if (group == null)
            {
                throw new Exception("Группа не обнаружена");
            }

            if (user == null)
            {
                throw new Exception("Пользователь не обнаружен");
            }

            group.UserIds.Add(userId);
            groupMemberships.Add(new GroupMembership
            {
                GroupMembershipId = groupMemberships.Count + 1,
                GroupId = groupId,
                UserId = userId,
                JoinedDate = DateTime.Now
            });

            using (_connection)
            {
                SqlCommand command = new SqlCommand("AddUserToGroup", _connection)
                {
                    CommandType = CommandType.StoredProcedure
                };
                command.Parameters.AddWithValue("@GroupId", groupId);
                command.Parameters.AddWithValue("@UserId", userId);

                _connection.Open();
                command.ExecuteNonQuery();
            }
        }

        public List<User> GetUsersInGroup(int groupId)
        {
            Group group = groups.FirstOrDefault(g => g.GroupId == groupId);

            if (group == null)
            {
                throw new Exception("Group not found");
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
