using GymAppTraining.Api.Interfaces;
using GymAppTraining.Api.Models;
using Microsoft.AspNetCore.Mvc;

namespace GymAppTraining.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EnrollmentController : Controller
    {
        private readonly IEnrollmentService _enrollmentService;

        public EnrollmentController(IEnrollmentService enrollmentService)
        {
            _enrollmentService = enrollmentService;
        }

        [HttpGet]
        public IActionResult GetAllEnrollments()
        {
            var response = _enrollmentService.GetAllEnrollments();
            if (response.Success)
            {
                return Ok(response.Data);
            }
            else
            {
                return BadRequest(response.Message);
            }
        }

        [HttpPost]
        public IActionResult AddEnrollment([FromBody] AddEnrollmentModel enrollment)
        {
            var response = _enrollmentService.AddEnrollment(enrollment);
            if (response.Success)
            {
                return Ok(response.Data);
            }
            else
            {
                return BadRequest(response.Message);
            }
        }

        [HttpPut]
        public IActionResult UpdateEnrollment([FromBody] UpdateEnrollmentModel enrollment)
        {
            var response = _enrollmentService.UpdateEnrollment(enrollment);
            if (response.Success)
            {
                return Ok(response.Data);
            }
            else
            {
                return BadRequest(response.Message);
            }
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteEnrollment(Guid id)
        {
            var response = _enrollmentService.DeleteEnrollment(id);
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
