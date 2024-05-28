using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ActiveCamp.BL.Model
{
    public static class SessionManager
    {
        private static Session _currentSession;

        public static void CreateSession(string username)
        {
            _currentSession = new Session(username);
        }

        public static Session GetCurrentSession()
        {
            return _currentSession;
        }

        public static void DestroySession()
        {
            _currentSession = null;
        }
    }

}
