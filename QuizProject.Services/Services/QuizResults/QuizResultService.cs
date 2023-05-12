using AutoMapper;
using Microsoft.EntityFrameworkCore;
using QuizProject.Data.IRepositoriy;
using QuizProject.Domain.Configurations;
using QuizProject.Domain.Entities.QuizResults;
using QuizProject.Domain.Entities.Users;
using QuizProject.Service.DTOs.QuizResults;
using QuizProject.Service.Exceptions;
using QuizProject.Service.Extensions;
using QuizProject.Service.Interfaces.QuizResults;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace QuizProject.Service.Services.QuizResults
{
    public class QuizResultService : IQuizResultsService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public QuizResultService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public async Task<QuizResultForViewDTOs> CreateAsync(QuizResultForCreateDTOs quizResultForCreateDTO)
        {
            var quizeResult = _mapper.Map<QuizResult>(quizResultForCreateDTO);
            quizeResult.CreateAt = DateTime.UtcNow;
            var createAtQuiz = await _unitOfWork.QuizResult.CreateAsync(quizeResult);
            await _unitOfWork.SaveChangesAsync();

            return _mapper.Map<QuizResultForViewDTOs>(createAtQuiz);
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var deleted = await _unitOfWork.QuizResult.GetAsync(x => x.Id == id);
            if (deleted is null)
                throw new QuizProjectException(404, "Quiz Not found");

            var deletReselt = await _unitOfWork.QuizResult.DeleteAsync(deleted.Id);
            await _unitOfWork.SaveChangesAsync();

            return deletReselt;
        }

        public IEnumerable<QuizResultForViewDTOs> GetAll(PaginationParams @params, Expression<Func<QuizResult, bool>> expression = null)
            => _mapper.Map<IEnumerable<QuizResultForViewDTOs>>(
                _unitOfWork.QuizResult.GetAll(expression, isTracking: false)
                .Include(u => u.User)
                .Include(r => r.Test).ThenInclude(q => q.Course)
                .Include(r => r.Test).ThenInclude(q => q.Questions).ThenInclude(z => z.Attachment)
                .Include(r => r.Test).ThenInclude(q => q.Questions).ThenInclude(z => z.Answers)
                .ToPagedList(@params));

        public async Task<QuizResultForViewDTOs> GetAsync(Expression<Func<QuizResult, bool>> expression)
        {
            var quizResult = await _unitOfWork.QuizResult.GetAsync(expression);
            if (quizResult is null)
                throw new QuizProjectException(404, "QuizResult not found");

            return _mapper.Map<QuizResultForViewDTOs>(quizResult);
        }
    }
}
