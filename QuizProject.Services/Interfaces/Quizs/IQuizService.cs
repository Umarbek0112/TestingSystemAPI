using QuizProject.Domain.Configurations;
using QuizProject.Domain.Entities.Courses;
using QuizProject.Service.DTOs.Courses;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using System;
using QuizProject.Domain.Entities.Quizs;
using QuizProject.Service.DTOs.Quizes;

namespace QuizProject.Service.Interfaces.Quizs
{
    public interface IQuizService
    {
        IEnumerable<QuizeForViewDTOs> GetAll(PaginationParams @params, Expression<Func<Quiz, bool>> expression = null);
        Task<QuizeForViewDTOs> GetAsync(Expression<Func<Quiz, bool>> expression);
        Task<QuizeForCreateDTOs> CreateAsync(QuizeForCreateDTOs quizeForCreateDTO);
        Task<bool> DeleteAsync(int id);
    }
}
