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
        public int Duration { get; set; }
        public double Length { get; set; }
        public string Difficulty { get; set; }
        public int AuthorId { get; set; }

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
