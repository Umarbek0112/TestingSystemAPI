

namespace QuizProject.Service.DTOs.Answers
{
    public class AnswerForCreateDTOs
    {
        public string Content { get; set; }
        public string Option { get; set; }
        public bool IsCorrect { get; set; }
        public int QuestionId { get; set; }
    }
}
