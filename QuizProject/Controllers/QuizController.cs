using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using QuizProject.Domain.Configurations;
using QuizProject.Service.DTOs.Courses;
using QuizProject.Service.DTOs.Quizes;
using QuizProject.Service.Interfaces.Quizs;
using System.Threading.Tasks;

namespace QuizProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class QuizController : ControllerBase
    {
        IQuizService _service;
        public QuizController(IQuizService quizService)
        {
            _service = quizService;
        }

        [HttpPost]
        public async Task<IActionResult> CreateAsync(QuizeForCreateDTOs quizeForCreateDTO)
            => Ok(await _service.CreateAsync(quizeForCreateDTO));

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
