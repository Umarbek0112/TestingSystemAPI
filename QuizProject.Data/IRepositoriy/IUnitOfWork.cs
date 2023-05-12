using QuizProject.Data.DbContexts;
using QuizProject.Domain.Entities.Answers;
using QuizProject.Domain.Entities.Attachments;
using QuizProject.Domain.Entities.Courses;
using QuizProject.Domain.Entities.Questions;
using QuizProject.Domain.Entities.QuizResults;
using QuizProject.Domain.Entities.Quizs;
using QuizProject.Domain.Entities.Users;
using System;
using System.Threading.Tasks;

namespace QuizProject.Data.IRepositoriy
{
    public interface IUnitOfWork : IDisposable
    {
        public IGenericRepositoriy<User> User { get; }
        public IGenericRepositoriy<Answer> Answer { get; }
        public IGenericRepositoriy<Attachment> Attachment { get; }
        public IGenericRepositoriy<Course> Course { get; }
        public IGenericRepositoriy<Question> Question { get; }
        public IGenericRepositoriy<Quiz> Quiz { get; }
        public IGenericRepositoriy<QuizResult> QuizResult { get; }
        public QuizProjectDbContext DbContext { get; }
        public Task SaveChangesAsync();
    }
}
