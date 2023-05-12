using QuizProject.Domain.Commons;
using QuizProject.Domain.Entities.Courses;
using QuizProject.Domain.Entities.Questions;
using QuizProject.Domain.Entities.QuizResults;
using System.Collections.Generic;

namespace QuizProject.Domain.Entities.Quizs
{
    public class Quiz : Auditable
    {
        public int CourseId { get; set; }
        public Course Course { get; set; }
        public string Title { get; set; }

        public ICollection<Question> Questions { get; set; }
        public ICollection<QuizResult> QuizResults { get; set; }
    }
}
