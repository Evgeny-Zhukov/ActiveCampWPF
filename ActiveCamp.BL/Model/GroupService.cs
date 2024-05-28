using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ActiveCamp.BL.Model
{
    public class GroupService
    {
        private List<Group> groups = new List<Group>();
        private List<User> users = new List<User>();
        private List<GroupMembership> groupMemberships = new List<GroupMembership>();

        public Group CreateGroup(int routeId, string invitationLink)
        {
            var newGroup = new Group
            {
                RouteId = routeId,
                InvitationLink = invitationLink
            };

            groups.Add(newGroup);
            return newGroup;
        }

        public void AddUserToGroup(int groupId, int userId)
        {
            var group = groups.FirstOrDefault(g => g.GroupId == groupId);
            var user = users.FirstOrDefault(u => u.UserID == userId);

            if (group == null)
            {
                throw new Exception("Группа не обнаружена");
            }

            if (user == null)
            {
                throw new Exception("ПОльзователь не обнаружен");
            }

            group.UserIds.Add(userId);
            groupMemberships.Add(new GroupMembership
            {
                GroupMembershipId = groupMemberships.Count + 1,
                GroupId = groupId,
                UserId = userId,
                JoinedDate = DateTime.Now
            });
        }

        public List<User> GetUsersInGroup(int groupId)
        {
            var group = groups.FirstOrDefault(g => g.GroupId == groupId);

            if (group == null)
            {
                throw new Exception("Group not found");
            }

            return users.Where(u => group.UserIds.Contains(u.UserID)).ToList();
        }
    }
}
