using GymAppTraining.Api.Models;
using GymAppTraining.Api.Services;
using GymAppTraining.Interfaces;
using Microsoft.AspNetCore.Mvc;


namespace GymAppTraining.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : Controller
    {
        private readonly IUserService _iuserService;

        public UserController(IUserService iuserService)
        {
            _iuserService = iuserService;
        }


        [HttpGet]
        public IActionResult GetAllUsers() => HandleResponse(_iuserService.GetAllUsers());
        [HttpGet("{id}")]
        public IActionResult GetUserById(Guid id) => HandleResponse(_iuserService.GetUserById(id));
        [HttpPost]
        public IActionResult AddUser([FromBody] UserModel user) => HandleResponse(_iuserService.AddUser(user));
        [HttpPut]
        public IActionResult UpdateUser([FromBody] UserModel user) => HandleResponse(_iuserService.UpdateUser(user));
        [HttpDelete("{id}")]
        public IActionResult DeleteUser(Guid id) => HandleResponse(_iuserService.DeleteUser(id));




        private IActionResult HandleResponse<T>(ServiceResponse<T> response)
        {
            if (response.Success)
            {
                return Ok(response.Data);
            }
            else
            {
                return BadRequest(response.Message);
            }
        }
    }
}
