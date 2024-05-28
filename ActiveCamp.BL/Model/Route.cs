using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ActiveCamp.BL.Model
{
    public class Route
    {
        public int RouteId { get; set; }
        public string RouteName { get; set; }
        public string Description { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string StartPoint { get; set; }
        public string EndPoint { get; set; }
        public int Duration { get; set; }
        public double Length { get; set; }
        public string Difficulty { get; set; }
        public int AuthorId { get; set; }
        public bool IsPrivate { get; set; }

        public Route() 
        { 
        
        }
        //TestLogin
        public Route(DateTime startDate, DateTime endDate, string description, string startPoint, string endPoint, string difficulty, bool isPrivate)
        {
            this.StartDate = startDate;
            this.EndDate = endDate;
            Description = description;
            this.StartPoint = startPoint;
            this.EndPoint = endPoint;
            Difficulty = difficulty;
            IsPrivate = isPrivate;
        }

        public Route(string routeName, int duration, double length, string difficulty, int authorId)
        {
            RouteName = routeName;
            Duration = duration;
            Length = length;
            Difficulty = difficulty;
            AuthorId = authorId;
        }
    }

}
