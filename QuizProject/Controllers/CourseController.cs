using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using QuizProject.Domain.Configurations;
using QuizProject.Service.DTOs.Courses;
using QuizProject.Service.DTOs.Users;
using QuizProject.Service.Interfaces.Courses;
using System.Threading.Tasks;

namespace QuizProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CourseController : ControllerBase
    {
        private readonly ICourseService _service;

        public CourseController(ICourseService courseService)
        {
            _service = courseService;
        }

        [HttpPost]
        public async Task<IActionResult> CreateAsync(CourseForCreateDTOs courseForCreateDTO)
            => Ok(await _service.CreateAsync(courseForCreateDTO));

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
