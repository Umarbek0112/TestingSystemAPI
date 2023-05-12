using AutoMapper;
using Microsoft.EntityFrameworkCore;
using QuizProject.Data.IRepositoriy;
using QuizProject.Domain.Configurations;
using QuizProject.Domain.Entities.Courses;
using QuizProject.Domain.Entities.Questions;
using QuizProject.Service.DTOs.Courses;
using QuizProject.Service.DTOs.Questions;
using QuizProject.Service.DTOs.Users;
using QuizProject.Service.Exceptions;
using QuizProject.Service.Extensions;
using QuizProject.Service.Interfaces.Questions;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace QuizProject.Service.Services.Questions
{
    public class QuestionService : IQuestionService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public QuestionService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public async Task<QuestionForViewDTOs> CreateAsync(QuestionForCreateDTOs questionForCreateDTO)
        {
            var question = _mapper.Map<Question>(questionForCreateDTO);
            question.CreateAt = DateTime.UtcNow;
            var createAtQuestion = await _unitOfWork.Question.CreateAsync(question);
            await _unitOfWork.SaveChangesAsync();

            return _mapper.Map<QuestionForViewDTOs>(createAtQuestion);
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var question = await _unitOfWork.Question.GetAsync(x => x.Id == id);
            if (question == null)
                throw new QuizProjectException(404, "Question not found");

            var deleteResult = await _unitOfWork.Question.DeleteAsync(question.Id);
            await _unitOfWork.SaveChangesAsync();

            return deleteResult;
        }

        public IEnumerable<QuestionForViewDTOs> GetAll(PaginationParams @params, Expression<Func<Question, bool>> expression = null)
        => _mapper.Map<IEnumerable<QuestionForViewDTOs>>(
                _unitOfWork.Question.GetAll(expression, isTracking: false)
                .Include(an => an.Test).ThenInclude(att => att.Course)
                .Include(an => an.Answers)
                .Include(att => att.Attachment)
                .ToPagedList(@params));

        public async Task<QuestionForViewDTOs> GetAsync(Expression<Func<Question, bool>> expression)
        {
            var question = await _unitOfWork.Question.GetAsync(expression, isTracking: false);
            if (question is null)
                throw new QuizProjectException(404, "Question not found");

            return _mapper.Map<QuestionForViewDTOs>(question);
        }

        public async Task<QuestionForViewDTOs> UpdateAsync(int id, QuestionForCreateDTOs questionForCreateDTO)
        {
            var updatedQuestion = await _unitOfWork.Question.GetAsync(x => x.Id == id);
            if (updatedQuestion == null)
                throw new QuizProjectException(404, "Question notfound");

            updatedQuestion.UpdateAt = DateTime.UtcNow;
            updatedQuestion = _unitOfWork.Question.Update(_mapper.Map(questionForCreateDTO, updatedQuestion));
            await _unitOfWork.SaveChangesAsync();

            return _mapper.Map<QuestionForViewDTOs>(updatedQuestion);
        }
    }
}
