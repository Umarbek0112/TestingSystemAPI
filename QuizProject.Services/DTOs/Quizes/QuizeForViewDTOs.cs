using QuizProject.Service.DTOs.Courses;
using QuizProject.Service.DTOs.Questions;
using QuizProject.Service.DTOs.QuizResults;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace QuizProject.Service.DTOs.Quizes
{
    public class QuizeForViewDTOs
    {
        public int Id { get; set; }
        [Required]
        public int CourseId { get; set; }
        public CourseForViewDTOs Course { get; set; }
        [Required]
        public string Title { get; set; }

        public ICollection<QuestionForViewDTOs> Questions { get; set; }
        public ICollection<QuizResultForViewDTOs> QuizResults { get; set; }
    }
}
