using QuizProject.Domain.Configurations;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using System;
using QuizProject.Service.DTOs.QuizResults;
using QuizProject.Domain.Entities.QuizResults;

namespace QuizProject.Service.Interfaces.QuizResults
{
    public interface IQuizResultsService
    {
        IEnumerable<QuizResultForViewDTOs> GetAll(PaginationParams @params, Expression<Func<QuizResult, bool>> expression = null);
        Task<QuizResultForViewDTOs> GetAsync(Expression<Func<QuizResult, bool>> expression);
        Task<QuizResultForViewDTOs> CreateAsync(QuizResultForCreateDTOs quizResultForCreateDTO);
        Task<bool> DeleteAsync(int id);
    }
}
