using QuizProject.Domain.Commons;
using QuizProject.Domain.Entities.Quizs;
using System.Collections.Generic;

namespace QuizProject.Domain.Entities.Courses
{
    public class Course : Auditable
    {
        public string Name { get; set; }
       public ICollection<Quiz> Quizs { get; set; }
    }
}
