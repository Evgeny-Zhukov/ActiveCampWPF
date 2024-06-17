using ActiveCamp.BL.Model;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace ActiveCamp.BL.Controller
{
    public class GroupMembershipManager
    {
        private ActiveCampDbContext dbContext;
        private SqlConnection _connection;

        public GroupMembershipManager()
        {
            dbContext = new ActiveCampDbContext();
            _connection = dbContext.GetSqlConnection();
        }

        public bool AddGroupMembership(GroupMembership groupMembership)
        {
            using (_connection)
            {
                SqlCommand command = new SqlCommand("AddGroupMembership", _connection);
                command.CommandType = CommandType.StoredProcedure;

                SqlParameter successParameter = new SqlParameter("@success", SqlDbType.Bit);
                successParameter.Direction = ParameterDirection.Output;
                command.Parameters.Add(successParameter);

                command.Parameters.AddWithValue("@UserId", groupMembership.UserId);
                command.Parameters.AddWithValue("@GroupId", groupMembership.GroupId);
                command.Parameters.AddWithValue("@JoinedDate", groupMembership.JoinedDate);
                command.Parameters.AddWithValue("@IsAproved", groupMembership.IsAproved);

                _connection.Open();
                command.ExecuteNonQuery();
                bool success = (bool)successParameter.Value;
                return success;
            }
        }

        public List<GroupMembership> GetGroupMembership(int GroupId)
        {
            List<GroupMembership> memberships = new List<GroupMembership>();
            using (_connection)
            { 
                string query = "SELECT * FROM GroupMemberships WHERE GroupId = @GroupId";

                SqlCommand command = new SqlCommand(query, _connection);
                command.Parameters.AddWithValue("@GroupId", GroupId);

                try
                {
                    _connection.Open();

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            GroupMembership membership = new GroupMembership();
                            {
                                membership.GroupMembershipID = Convert.ToInt32(reader["GroupMembershipID"]);
                                membership.UserId = Convert.ToInt32(reader["UserId"]);
                                membership.GroupId = Convert.ToInt32(reader["GroupId"]);
                                membership.JoinedDate = Convert.ToDateTime(reader["JoinedDate"]);
                                membership.IsAproved = Convert.ToBoolean(reader["IsAproved"]);
                            }
                            memberships.Add(membership);
                        }
                    }

                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error: " + ex.Message);
                }
            }
            return memberships;
        }

        public bool UpdateGroupMembership(GroupMembership groupMembership)
        {
            using (_connection)
            {
                SqlCommand command = new SqlCommand("UpdateGroupMembership", _connection);
                command.CommandType = CommandType.StoredProcedure;

                SqlParameter successParameter = new SqlParameter("@success", SqlDbType.Bit);
                successParameter.Direction = ParameterDirection.Output;
                command.Parameters.Add(successParameter);

                command.Parameters.AddWithValue("@GroupMembershipId", groupMembership.GroupMembershipID);
                command.Parameters.AddWithValue("@UserId", groupMembership.UserId);
                command.Parameters.AddWithValue("@GroupId", groupMembership.GroupId);
                command.Parameters.AddWithValue("@JoinedDate", groupMembership.JoinedDate);
                command.Parameters.AddWithValue("@IsAproved", groupMembership.IsAproved);

                _connection.Open();
                command.ExecuteNonQuery();
                bool success = (bool)successParameter.Value;
                return success;
            }
        }
        public bool DeleteGroupMembership(int userID, int groupID)
        {
            using (_connection)
            {
                SqlCommand command = new SqlCommand("DeleteGroupMembershipById", _connection);
                command.CommandType = CommandType.StoredProcedure;

                SqlParameter successParameter = new SqlParameter("@success", SqlDbType.Bit);
                successParameter.Direction = ParameterDirection.Output;
                command.Parameters.Add(successParameter);

                command.Parameters.AddWithValue("@UserId", userID);
                command.Parameters.AddWithValue("@GroupId", groupID);

                _connection.Open();
                command.ExecuteNonQuery();
                bool success = (bool)successParameter.Value;
                return success;
            }
        }
    }
}
