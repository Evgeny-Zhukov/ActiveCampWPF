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
        public List<Tuple<int, int>> UserAnswers { get; set; }


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
        public void AddUserAnswer(int userId, int rating)
        {
            UserAnswers.Add(new Tuple<int, int>(userId, rating));
        }
        private void SaveAnswersToDatabase(List<Tuple<int, int>> userAnswers)
        {
            ActiveCampDbContext db = new ActiveCampDbContext();
            foreach (var answer in userAnswers)
            {
                var questionnaire = new Questionnaire
                {
                    QuestionId = this.QuestionId,
                    QuestionText = this.QuestionText,
                    UserId = answer.Item1,
                    Rating = answer.Item2
                };
                db.AddSurveyResults(questionnaire);
            }
        }
    }
}
