using GymAppTraining.Api.Interfaces;
using GymAppTraining.Api.Models;
using GymAppTraining.Api.Services;
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
        public IActionResult GetAllEnrollments() => HandleResponse(_enrollmentService.GetAllEnrollments());
        [HttpGet]
        public IActionResult GetEnrollmentById(Guid id) => HandleResponse(_enrollmentService.GetEnrollmentById(id));
        [HttpPost]
        public IActionResult AddEnrollment([FromBody] AddEnrollmentModel enrollment) => HandleResponse(_enrollmentService.AddEnrollment(enrollment));
        [HttpPut]
        public IActionResult UpdateEnrollment([FromBody] UpdateEnrollmentModel enrollment) => HandleResponse(_enrollmentService.UpdateEnrollment(enrollment));
        [HttpDelete]
        public IActionResult DeleteEnrollment(Guid id) => HandleResponse(_enrollmentService.DeleteEnrollment(id));

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
