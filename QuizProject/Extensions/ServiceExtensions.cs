using Microsoft.Extensions.DependencyInjection;
using QuizProject.Data.IRepositoriy;
using QuizProject.Data.Repositoriy;
using QuizProject.Service.Interfaces.Answers;
using QuizProject.Service.Interfaces.Attachments;
using QuizProject.Service.Interfaces.Courses;
using QuizProject.Service.Interfaces.Questions;
using QuizProject.Service.Interfaces.QuizResults;
using QuizProject.Service.Interfaces.Quizs;
using QuizProject.Service.Interfaces.Users;
using QuizProject.Service.Services.Answers;
using QuizProject.Service.Services.Attachments;
using QuizProject.Service.Services.Courses;
using QuizProject.Service.Services.Questions;
using QuizProject.Service.Services.Quizes;
using QuizProject.Service.Services.QuizResults;
using QuizProject.Service.Services.Users;

namespace QuizProject.Extensions
{
    public static class ServiceExtensions
    {
        public static void AddCustomServices (this IServiceCollection services)
        {
            services.AddScoped<IUnitOfWork, UnitOfWork>();

            services.AddScoped<IUserService, UserService>();
            services.AddScoped<ICourseService, CourseService>();
            services.AddScoped<IQuizService, QuizService>();
            services.AddScoped<IQuestionService, QuestionService>();
            services.AddScoped<IAttachmentService, AttachmentService>();
            services.AddScoped<IQuizResultsService, QuizResultService>();
            services.AddScoped<IAnswerService, AnswerService>();
        }
    }
}
