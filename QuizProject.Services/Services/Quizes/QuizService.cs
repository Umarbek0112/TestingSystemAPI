using AutoMapper;
using Microsoft.EntityFrameworkCore;
using QuizProject.Data.IRepositoriy;
using QuizProject.Data.Repositoriy;
using QuizProject.Domain.Configurations;
using QuizProject.Domain.Entities.Courses;
using QuizProject.Domain.Entities.QuizResults;
using QuizProject.Domain.Entities.Quizs;
using QuizProject.Service.DTOs.Courses;
using QuizProject.Service.DTOs.Quizes;
using QuizProject.Service.Exceptions;
using QuizProject.Service.Extensions;
using QuizProject.Service.Interfaces.Quizs;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace QuizProject.Service.Services.Quizes
{
    public class QuizService : IQuizService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public QuizService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public async Task<QuizeForCreateDTOs> CreateAsync(QuizeForCreateDTOs quizeForCreateDTO)
        {
            var quize = _mapper.Map<Quiz>(quizeForCreateDTO);
            quize.CreateAt = DateTime.UtcNow;
            var createAtQuiz = await _unitOfWork.Quiz.CreateAsync(quize);
            await _unitOfWork.SaveChangesAsync();

            return _mapper.Map<QuizeForCreateDTOs>(createAtQuiz);
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var quiz = await _unitOfWork.Quiz.GetAsync(x => x.Id == id);
            if (quiz == null)
                throw new QuizProjectException(404, "Quiz not found");

            var deleteResult = await _unitOfWork.Course.DeleteAsync(quiz.Id);
            await _unitOfWork.SaveChangesAsync();

            return deleteResult;
        }

        public IEnumerable<QuizeForViewDTOs> GetAll(PaginationParams @params, Expression<Func<Quiz, bool>> expression = null)
            => _mapper.Map<IEnumerable<QuizeForViewDTOs>>(
                _unitOfWork.Quiz.GetAll(expression, isTracking: false)
                .Include(s => s.Course).Include(x => x.Questions).ThenInclude(a => a.Attachment)
                .Include(s => s.Course).Include(x => x.Questions).ThenInclude(a => a.Answers)
                .ToPagedList(@params));

        public async Task<QuizeForViewDTOs> GetAsync(Expression<Func<Quiz, bool>> expression)
        {
            var quiz = await _unitOfWork.Quiz.GetAsync(expression, isTracking: false, new string[] { "Course" });
            if (quiz is null)
                throw new QuizProjectException(404, "Quiz not found");

            return _mapper.Map<QuizeForViewDTOs>(quiz);
        }
    }
}
