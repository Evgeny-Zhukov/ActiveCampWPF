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
        public int UserId { get; set; } // Идентификатор пользователя, который дал ответ
        public int Rating { get; set; } // Оценка, данная пользователем
        

        public Questionnaire() { }

        public Questionnaire(int questionId, string questionText)
        {
            QuestionId = questionId;
            QuestionText = questionText;
        }

        public Questionnaire(int questionId, string questionText, int userId, int rating)
            : this(questionId, questionText)
        {
            UserId = userId;
            Rating = rating;
        }
        public void SaveUserAnswers(Questionnaire questionnaire)
        {
            ActiveCampDbContext db = new ActiveCampDbContext();
            db.AddSurveyResults(questionnaire);
        }
    }
}
