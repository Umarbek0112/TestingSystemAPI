using QuizProject.Service.DTOs.Quizes;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace QuizProject.Service.DTOs.Courses
{
    public class CourseForViewDTOs
    {
        [Required]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        public ICollection<QuizeForViewDTOs> Quizs { get; set; }
    }
}
