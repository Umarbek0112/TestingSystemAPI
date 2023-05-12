using QuizProject.Domain.Configurations;
using QuizProject.Domain.Entities.Attachments;
using QuizProject.Service.DTOs.Attachment;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using System;
using QuizProject.Service.DTOs.Answers;
using QuizProject.Domain.Entities.Answers;

namespace QuizProject.Service.Interfaces.Answers
{
    public interface IAnswerService
    {
        IEnumerable<AnswerForViewDTOs> GetAll(PaginationParams @params, Expression<Func<Answer, bool>> expression = null);
        Task<AnswerForViewDTOs> GetAsync(Expression<Func<Answer, bool>> expression);
        Task<AnswerForViewDTOs> CreateAsync(AnswerForCreateDTOs answerForCreateDTO);
        Task<bool> DeleteAsync(int id);
    }
}
