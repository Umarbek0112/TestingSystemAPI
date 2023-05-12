using AutoMapper;
using QuizProject.Data.IRepositoriy;
using QuizProject.Domain.Configurations;
using QuizProject.Domain.Entities.Answers;
using QuizProject.Domain.Entities.Attachments;
using QuizProject.Service.DTOs.Answers;
using QuizProject.Service.DTOs.Attachment;
using QuizProject.Service.Exceptions;
using QuizProject.Service.Extensions;
using QuizProject.Service.Interfaces.Answers;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace QuizProject.Service.Services.Answers
{
    public class AnswerService : IAnswerService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public AnswerService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public async Task<AnswerForViewDTOs> CreateAsync(AnswerForCreateDTOs answerForCreateDTO)
        {
            var answer = _mapper.Map<Answer>(answerForCreateDTO);
            answer.CreateAt = DateTime.UtcNow;
            var createAtQuestion = await _unitOfWork.Answer.CreateAsync(answer);
            await _unitOfWork.SaveChangesAsync();

            return _mapper.Map<AnswerForViewDTOs>(answer);
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var deletedAnswer = await _unitOfWork.Answer.GetAsync(x => x.Id == id);
            if (deletedAnswer is null)
                throw new QuizProjectException(404, "ANswer not found");

            var deletResult = await _unitOfWork.Answer.DeleteAsync(deletedAnswer.Id);
            
            return deletResult;
        }

        public IEnumerable<AnswerForViewDTOs> GetAll(PaginationParams @params, Expression<Func<Answer, bool>> expression = null)
            => _mapper.Map<IEnumerable<AnswerForViewDTOs>>(
                _unitOfWork.Answer.GetAll(expression, isTracking: false)
                .ToPagedList(@params));

        public async Task<AnswerForViewDTOs> GetAsync(Expression<Func<Answer, bool>> expression)
        {
            var attachment = await _unitOfWork.Answer.GetAsync(expression);
            if (attachment is null)
                throw new QuizProjectException(404, "Answer not found");

            return _mapper.Map<AnswerForViewDTOs>(attachment);
        }
    }
}
