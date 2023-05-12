using System;
using System.ComponentModel.DataAnnotations;

namespace QuizProject.Domain.Commons
{
    public class Auditable
    {
        [Key]
        public int Id { get; set; }
        public DateTime CreateAt { get; set; }
        public DateTime UpdateAt { get; set; }
    }
}
