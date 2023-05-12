using QuizProject.Domain.Entities.Quizs;
using QuizProject.Domain.Entities.Users;
using QuizProject.Service.DTOs.Quizes;
using QuizProject.Service.DTOs.Users;

namespace QuizProject.Service.DTOs.QuizResults
{
    public class QuizResultForViewDTOs
    {
        public int Id { get; set; }
        public int CorrectAnswers { get; set; }
        public int TestId { get; set; }
        public QuizeForViewDTOs Test { get; set; }
        public int UserId { get; set; }
        public UserForViewDTOs User { get; set; }
    }
}
