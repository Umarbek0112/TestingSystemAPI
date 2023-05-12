using System.ComponentModel.DataAnnotations;

namespace QuizProject.Service.DTOs.Courses
{
    public class CourseForCreateDTOs
    {
        [Required]
        public string Name { get; set; }
    }
}
