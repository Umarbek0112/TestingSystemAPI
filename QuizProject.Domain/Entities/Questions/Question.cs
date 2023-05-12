using QuizProject.Domain.Commons;
using QuizProject.Domain.Entities.Answers;
using QuizProject.Domain.Entities.Attachments;
using QuizProject.Domain.Entities.Quizs;
using System.Collections;
using System.Collections.Generic;

namespace QuizProject.Domain.Entities.Questions
{
    public class Question : Auditable
    {
        public int Number { get; set; }
        public int TestId { get; set; }
        public Quiz Test { get; set; }
        public int AttachmentId { get; set; }
        public Attachment Attachment { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
       
       public ICollection<Answer> Answers { get; set; }
    }
}
