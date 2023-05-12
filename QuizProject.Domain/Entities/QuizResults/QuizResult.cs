using QuizProject.Domain.Commons;
using QuizProject.Domain.Entities.Quizs;
using QuizProject.Domain.Entities.Users;

namespace QuizProject.Domain.Entities.QuizResults
{
    public class QuizResult : Auditable
    {
        public int CorrectAnswers { get; set; }
        public int TestId { get; set; }
        public Quiz Test { get; set; }
        public int UserId { get; set; }
        public User User { get; set; } 
    }
}
