using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ActiveCamp.BL.Model
{
    internal class Group
    {
        public int GroupId { get;}
        public List<User> users { get;}
        public User GroupSupervisor { get;}
        // Добавить роли для участников

    }
}
