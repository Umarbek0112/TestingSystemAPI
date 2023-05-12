using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using QuizProject.Domain.Configurations;
using QuizProject.Service.DTOs.Quizes;
using QuizProject.Service.DTOs.QuizResults;
using QuizProject.Service.Interfaces.QuizResults;
using QuizProject.Service.Interfaces.Quizs;
using System.Threading.Tasks;

namespace QuizProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class QuizResultController : ControllerBase
    {
        IQuizResultsService _service;
        public QuizResultController(IQuizResultsService Service)
        {
            _service = Service;
        }

        [HttpPost]
        public async Task<IActionResult> CreateAsync(QuizResultForCreateDTOs quizResultForCreateDTO)
            => Ok(await _service.CreateAsync(quizResultForCreateDTO));

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
