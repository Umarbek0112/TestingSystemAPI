using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using QuizProject.Domain.Configurations;
using QuizProject.Service.DTOs.Answers;
using QuizProject.Service.DTOs.Attachment;
using QuizProject.Service.Interfaces.Answers;
using QuizProject.Service.Interfaces.Attachments;
using System.Threading.Tasks;

namespace QuizProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AnswerController : ControllerBase
    {
        private readonly IAnswerService _service;

        public AnswerController(IAnswerService service)
        {
            _service = service;
        }

        [HttpPost]
        public async Task<IActionResult> CreateAsync(AnswerForCreateDTOs answerForCreateDTO)
            => Ok(await _service.CreateAsync(answerForCreateDTO));

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
