using GymAppTraining.Api.Interfaces;
using GymAppTraining.Api.Models;
using GymAppTraining.Api.Services;
using Microsoft.AspNetCore.Mvc;

namespace GymAppTraining.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TrainingController : Controller
    {
        private readonly ITrainingService _trainingService;

        public TrainingController(ITrainingService trainingService)
        {
            _trainingService = trainingService;
        }

        [HttpGet]
        public IActionResult GetAllTrainings() => HandleResponse(_trainingService.GetAllTrainings());

        [HttpPost]
        public IActionResult AddTraining([FromBody] AddTrainingModel training) => HandleResponse(_trainingService.AddTraining(training));

        [HttpGet("{id}")]
        public IActionResult GetTrainingById(Guid id) => HandleResponse(_trainingService.GetTrainingById(id));

        [HttpPut]
        public IActionResult UpdateTraining([FromBody] UpdateTrainingModel training) => HandleResponse(_trainingService.UpdateTraining(training));

        [HttpDelete("{id}")]
        public IActionResult DeleteTraining(Guid id) => HandleResponse(_trainingService.DeleteTraining(id));

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
