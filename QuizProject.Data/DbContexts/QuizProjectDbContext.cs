using Microsoft.EntityFrameworkCore;
using QuizProject.Domain.Entities.Answers;
using QuizProject.Domain.Entities.Attachments;
using QuizProject.Domain.Entities.Courses;
using QuizProject.Domain.Entities.Questions;
using QuizProject.Domain.Entities.QuizResults;
using QuizProject.Domain.Entities.Quizs;
using QuizProject.Domain.Entities.Users;

namespace QuizProject.Data.DbContexts
{
    public class QuizProjectDbContext : DbContext
    {
        public QuizProjectDbContext(DbContextOptions<QuizProjectDbContext> options) : base(options)
        {
            
        }

        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<QuizResult> QuizResults { get; set; }
        public virtual DbSet<Course> Courses { get; set; }
        public virtual DbSet<Quiz> Quizs { get; set; }
        public virtual DbSet<Question> Question { get; set; }
        public virtual DbSet<Attachment> Attachments { get; set; }
        public virtual DbSet<Answer> Answers { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>()
             .HasIndex(u => u.Email)
             .IsUnique();
        }

    }
}
