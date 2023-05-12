using QuizProject.Domain.Commons;

namespace QuizProject.Domain.Entities.Attachments
{
    public class Attachment : Auditable
    {
        public string Path { get; set; }
    }
}
