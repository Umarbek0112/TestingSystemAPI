using System.ComponentModel.DataAnnotations;

namespace QuizProject.Service.DTOs.Quizes
{
    public class QuizeForCreateDTOs
    {
        [Required]
        public int CourseId { get; set; }
        [Required]
        public string Title { get; set; }
    }
}
