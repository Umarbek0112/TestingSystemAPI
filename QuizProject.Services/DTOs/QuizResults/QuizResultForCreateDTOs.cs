using System.ComponentModel.DataAnnotations;

namespace QuizProject.Service.DTOs.QuizResults
{
    public class QuizResultForCreateDTOs
    {
        [Required]
        public int CorrectAnswers { get; set; }
        [Required]
        public int TestId { get; set; }
        [Required]
        public int UserId { get; set; }
    }
}
