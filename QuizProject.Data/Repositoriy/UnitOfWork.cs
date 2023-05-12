using QuizProject.Data.DbContexts;
using QuizProject.Data.IRepositoriy;
using QuizProject.Domain.Entities.Answers;
using QuizProject.Domain.Entities.Attachments;
using QuizProject.Domain.Entities.Courses;
using QuizProject.Domain.Entities.Questions;
using QuizProject.Domain.Entities.QuizResults;
using QuizProject.Domain.Entities.Quizs;
using QuizProject.Domain.Entities.Users;
using System;
using System.Threading.Tasks;

namespace QuizProject.Data.Repositoriy
{
    public class UnitOfWork : IUnitOfWork
    {
        public IGenericRepositoriy<User> User { get; }
        public IGenericRepositoriy<Answer> Answer { get; }
        public IGenericRepositoriy<Attachment> Attachment { get; }
        public IGenericRepositoriy<Course> Course { get; }
        public IGenericRepositoriy<Question> Question { get; }
        public IGenericRepositoriy<Quiz> Quiz { get; }
        public IGenericRepositoriy<QuizResult> QuizResult { get; }

        public QuizProjectDbContext DbContext { get; }

        public UnitOfWork(QuizProjectDbContext dbContext)
        {
            DbContext = dbContext;

            User = new GenericRepositoriy<User>(dbContext);
            Answer = new GenericRepositoriy<Answer>(dbContext);
            Attachment = new GenericRepositoriy<Attachment>(dbContext);
            Course = new GenericRepositoriy<Course>(dbContext);
            Question = new GenericRepositoriy<Question>(dbContext);
            Quiz = new GenericRepositoriy<Quiz>(dbContext);
            QuizResult = new GenericRepositoriy<QuizResult>(dbContext);
        }

        public async Task SaveChangesAsync()
            => await DbContext.SaveChangesAsync();

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }
    }
}
