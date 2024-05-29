using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ActiveCamp.BL.Model
{
    [Serializable]
    public class Session
    {
        public string Username { get; set; }
        public DateTime LoginTime { get; set; }
        public Guid SessionId { get;}

        public Session() { }
        public Session(string username)
        {
            Username = username;
            LoginTime = DateTime.Now;
            SessionId = Guid.NewGuid(); // Можно создавать любой другой идентификатор
        }
    }

}
