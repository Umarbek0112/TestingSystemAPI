using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using QuizProject.Domain.Configurations;
using QuizProject.Service.DTOs.Attachment;
using QuizProject.Service.DTOs.Courses;
using QuizProject.Service.Interfaces.Attachments;
using QuizProject.Service.Interfaces.Courses;
using System.Threading.Tasks;

namespace QuizProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AttachmentController : ControllerBase
    {
        private readonly IAttachmentService _service;

        public AttachmentController(IAttachmentService courseService)
        {
            _service = courseService;
        }

        [HttpPost]
        public async Task<IActionResult> CreateAsync(AttachmentForCreateDtos attachmentForCreate)
            => Ok(await _service.CreateAsync(attachmentForCreate));

        [HttpGet]
        public IActionResult GetAll([FromQuery] PaginationParams @params)
            => Ok(_service.GetAll(@params));

        [HttpGet("{id}")]
        public async Task<IActionResult> GetAsync(int id)
            => Ok(await _service.GetAsync(x => x.Id == id));

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAsync(int id)
            => Ok(await _service.DeleteAsync(id));
    }
}
