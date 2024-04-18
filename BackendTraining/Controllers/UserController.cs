using GymApp.Business.Interfaces;
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
        public IActionResult GetAll() 
        {
            var result = _iuserService.GetAllUsers();

            if (result.Success) 
            { 
                return Ok(result.Data);
            }
            else
            {
                return BadRequest(result.Message);
            }
        }
        
    }
}
