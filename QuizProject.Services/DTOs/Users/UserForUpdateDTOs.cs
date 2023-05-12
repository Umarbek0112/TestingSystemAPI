using QuizProject.Domain.Enums;
using System.ComponentModel.DataAnnotations;

namespace QuizProject.Service.DTOs.Users
{
    public class UserForUpdateDTOs
    {
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        public string UserName { get; set; }
        [Required]
        public string Password { get; set; }
        [Required]
        public UserRole Role { get; set; }
        [Required]
        public string IpAddress { get; set; }
    }
}
