using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ActiveCamp.BL.Model
{
    public class Questionnaire
    {
        public int QuestionId { get; set; }
        public string QuestionText { get; set; }
        public int Rating { get; set; }

        public Questionnaire() { }
        public Questionnaire(int questionId, string questionText, int rating)
        {
            QuestionId = questionId;
            QuestionText = questionText;
            Rating = rating;
        }
    }

}
