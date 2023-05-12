using QuizProject.Domain.Entities.Questions;
using QuizProject.Service.DTOs.Questions;
using System.Collections.Generic;

namespace QuizProject.Service.DTOs.Answers
{
    public class AnswerForViewDTOs
    {
        public int Id { get; set; }
        public string Content { get; set; }
        public string Option { get; set; }
        public bool IsCorrect { get; set; }
        public int QuestionId { get; set; }
        public QuestionForViewDTOs Question { get; set; }
    }
}
