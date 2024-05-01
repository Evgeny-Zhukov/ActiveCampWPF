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
        public DateTime startDate { get; set; }
        public DateTime endDate { get; set; }
        public string startPoint { get; set; }
        public string endPoint { get; set; }
        public int Duration { get; set; }
        public double Length { get; set; }
        public string Difficulty { get; set; }
        public int AuthorId { get; set; }

        public Route() { }
        public Route(DateTime startDate, DateTime endDate, string description, string startPoint, string endPoint, string difficulty)
        {
            this.startDate = startDate;
            this.endDate = endDate;
            Description = description;
            this.startPoint = startPoint;
            this.endPoint = endPoint;
            Difficulty = difficulty;
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
