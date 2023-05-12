using System.ComponentModel.DataAnnotations;

namespace QuizProject.Service.DTOs.Questions
{
    public class QuestionForCreateDTOs
    {
        [Required]
        public int Number { get; set; }
        [Required]
        public int TestId { get; set; }
        [Required]
        public int AttachmentId { get; set; }
        [Required]
        public string Title { get; set; }
        [Required]
        public string Description { get; set; }
    }
}
