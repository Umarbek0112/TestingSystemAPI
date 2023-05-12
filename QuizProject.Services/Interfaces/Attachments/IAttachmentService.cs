using QuizProject.Domain.Configurations;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using System;
using QuizProject.Domain.Entities.Attachments;
using QuizProject.Service.DTOs.Attachment;

namespace QuizProject.Service.Interfaces.Attachments
{
    public interface IAttachmentService
    {
        IEnumerable<AttachmentForViewDTOs> GetAll(PaginationParams @params, Expression<Func<Attachment, bool>> expression = null);
        Task<AttachmentForViewDTOs> GetAsync(Expression<Func<Attachment, bool>> expression);
        Task<AttachmentForViewDTOs> CreateAsync(AttachmentForCreateDtos attachmentForCreateDto);
        Task<bool> DeleteAsync(int id);
    }
}
