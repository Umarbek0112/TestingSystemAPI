using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using QuizProject.Domain.Configurations;
using QuizProject.Service.DTOs.Questions;
using QuizProject.Service.Interfaces.Questions;
using System.Threading.Tasks;

namespace QuizProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class QuestionController : ControllerBase
    {
        private readonly IQuestionService _service;

        public QuestionController(IQuestionService question)
        {
            _service = question;
        }

        [HttpPost]
        public async Task<IActionResult> CreateAsync(QuestionForCreateDTOs questionForCreateDTO)
            => Ok(await _service.CreateAsync(questionForCreateDTO));

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
