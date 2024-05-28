using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ActiveCamp.BL.Model
{
    public class Session
    {
        public string Username { get; set; }
        public DateTime LoginTime { get; set; }
        public Guid SessionId { get; private set; }

        public Session(string username)
        {
            Username = username;
            LoginTime = DateTime.Now;
            SessionId = Guid.NewGuid(); // Можно создавать любой другой идентификатор
        }
    }

}
