using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ActiveCamp.BL.Controller
{
    public class UserController
    {
        public User User { get;}
        public UserController(User user)
        {
            User = user ?? throw new ArgumentNullException(nameof(user));
        }
    }
}
