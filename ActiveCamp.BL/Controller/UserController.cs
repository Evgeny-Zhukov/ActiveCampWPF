using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace ActiveCamp.BL.Controller
{
    public class UserController
    {
        public User user { get; }
        public User CurentUser { get; }
        //TODO: Создать связь с БД
        public List<User> users { get; }
        public UserController(string userName)
        {
            if (string.IsNullOrWhiteSpace(userName))
            {
                throw new ArgumentNullException(nameof(userName));
            }
            CurentUser = users.SingleOrDefault(u => u.Username == userName);

        }
    }
}