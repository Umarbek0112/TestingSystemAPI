using QuizProject.Domain.Commons;
using QuizProject.Domain.Entities.QuizResults;
using QuizProject.Domain.Enums;
using System.Collections.Generic;

namespace QuizProject.Domain.Entities.Users
{
    public class User : Auditable
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public UserRole Role { get; set; }
        public string IpAddress { get; set; }
        public ICollection<QuizResult> QuizResualts { get; set; }
    }
}
