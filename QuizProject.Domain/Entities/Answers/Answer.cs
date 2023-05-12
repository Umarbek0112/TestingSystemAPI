using QuizProject.Domain.Commons;
using QuizProject.Domain.Entities.Questions;
using QuizProject.Domain.Entities.Quizs;
using System.Collections.Generic;

namespace QuizProject.Domain.Entities.Answers
{
    public class Answer : Auditable
    {
        public string Content { get; set; }
        public string Option { get; set; }
        public bool IsCorrect { get; set; }
        public int QuestionId { get; set; }
        public Question Question { get; set; }
    }
}
