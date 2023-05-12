using QuizProject.Domain.Configurations;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using System;
using QuizProject.Domain.Entities.Questions;
using QuizProject.Service.DTOs.Questions;

namespace QuizProject.Service.Interfaces.Questions
{
    public interface IQuestionService
    {
        IEnumerable<QuestionForViewDTOs> GetAll(PaginationParams @params, Expression<Func<Question, bool>> expression = null);
        Task<QuestionForViewDTOs> GetAsync(Expression<Func<Question, bool>> expression);
        Task<QuestionForViewDTOs> CreateAsync(QuestionForCreateDTOs questionForCreateDTO);
        Task<bool> DeleteAsync(int id);
        Task<QuestionForViewDTOs> UpdateAsync(int id, QuestionForCreateDTOs questionForCreateDTO);
    }
}


