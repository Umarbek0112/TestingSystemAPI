using Microsoft.AspNetCore.Mvc;
using QuizProject.Domain.Configurations;
using QuizProject.Service.DTOs.Users;
using QuizProject.Service.Interfaces.Users;
using System.Threading.Tasks;

namespace QuizProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpPost]
        public async Task<IActionResult> CreateAsync(UserForCreateDTOs userForCreateDTOs)
            => Ok(await _userService.CreateAsync(userForCreateDTOs));

        [HttpGet]
        public IActionResult GetAllAsync([FromQuery] PaginationParams @params)
            => Ok(_userService.GetAll(@params));

        [HttpGet("{id}")]
        public async Task<IActionResult> GetAsync(int id)
            => Ok(await _userService.GetAsync(x => x.Id == id));

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateAsync(int id, UserForUpdateDTOs userForUpdateDTOs)
            => Ok(await _userService.UpdateAsync(id, userForUpdateDTOs));

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAsync(int id)
            => Ok(await _userService.DeleteAsync(id));
    }
}
