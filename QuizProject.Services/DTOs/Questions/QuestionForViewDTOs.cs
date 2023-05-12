using QuizProject.Domain.Entities.Answers;
using QuizProject.Domain.Entities.Attachments;
using QuizProject.Service.DTOs.Answers;
using QuizProject.Service.DTOs.Quizes;
using System.Collections.Generic;

namespace QuizProject.Service.DTOs.Questions
{
    public class QuestionForViewDTOs
    {
        public int Id { get; set; }
        public int Number { get; set; }
        public int TestId { get; set; }
        public QuizeForViewDTOs Test { get; set; }
        public int AttachmentId { get; set; }
        public AttachmentForViewDTOs Attachment { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public ICollection<AnswerForViewDTOs> Answers { get; set; }
    }
}
