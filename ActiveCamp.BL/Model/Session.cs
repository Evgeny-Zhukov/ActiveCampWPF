using System;

namespace ActiveCamp.BL.Model
{
    [Serializable]
    public class Session
    {

        private string _userName;
        private DateTime _loginTime;
        private string _sessionID;

        public string Username { get { return _userName; } set { } }
        public DateTime LoginTime { get; set; }  
        public Guid SessionID { get; set; }

        public Session() { }
        
        public Session(string username)
        {
            this._userName = username;
            LoginTime = DateTime.Now;
            SessionID = Guid.NewGuid(); // Можно создавать любой другой идентификатор
        }

    }

}
