using AutoMapper;
using QuizProject.Data.IRepositoriy;
using QuizProject.Domain.Configurations;
using QuizProject.Domain.Entities.Attachments;
using QuizProject.Service.DTOs.Attachment;
using QuizProject.Service.Exceptions;
using QuizProject.Service.Extensions;
using QuizProject.Service.Interfaces.Attachments;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace QuizProject.Service.Services.Attachments
{
    public class AttachmentService : IAttachmentService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public AttachmentService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }
        public async Task<AttachmentForViewDTOs> CreateAsync(AttachmentForCreateDtos attachmentForCreateDto)
        {
            var attechment = _mapper.Map<Attachment>(attachmentForCreateDto);
            attechment.CreateAt = DateTime.UtcNow;
            var createAtQuestion = await _unitOfWork.Attachment.CreateAsync(attechment);
            await _unitOfWork.SaveChangesAsync();

            return _mapper.Map<AttachmentForViewDTOs>(attechment);
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var deleted = await _unitOfWork.Attachment.GetAsync(x => x.Id == id);
            if (deleted is null)
                throw new QuizProjectException(404, "Attechment not found");

            var deletResault = await _unitOfWork.Attachment.DeleteAsync(deleted.Id);
            await _unitOfWork.SaveChangesAsync();

            return deletResault;
        }

        public IEnumerable<AttachmentForViewDTOs> GetAll(PaginationParams @params, Expression<Func<Attachment, bool>> expression = null)
             => _mapper.Map<IEnumerable<AttachmentForViewDTOs>>(
                _unitOfWork.Attachment.GetAll(expression, isTracking: false)
                .ToPagedList(@params));

        public async Task<AttachmentForViewDTOs> GetAsync(Expression<Func<Attachment, bool>> expression)
        {
            var attachment = await _unitOfWork.Attachment.GetAsync(expression);
            if (attachment is null)
                throw new QuizProjectException(404, "Attechment not found");

            return _mapper.Map<AttachmentForViewDTOs>(attachment);
        }
    }
}
