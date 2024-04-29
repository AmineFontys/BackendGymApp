using GymAppTraining.Api.Interfaces;
using GymAppTraining.Api.Models;
using GymAppTraining.Api.Services;
using Microsoft.AspNetCore.Mvc;

namespace GymAppTraining.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TrainingScheduleController : Controller
    {
        private readonly ITrainingScheduleService _trainingScheduleService;

        public TrainingScheduleController(ITrainingScheduleService trainingScheduleService)
        {
            _trainingScheduleService = trainingScheduleService;
        }

        [HttpGet]
        public IActionResult GetAllTrainingSchedules() => HandleResponse(_trainingScheduleService.GetAllTrainingSchedules());
        [HttpGet]
        public IActionResult GetTrainingById(Guid id) => HandleResponse(_trainingScheduleService.GetTrainingScheduleById(id));
        [HttpPost]
        public IActionResult AddTraining([FromBody] AddTrainingScheduleModel training) => HandleResponse(_trainingScheduleService.AddTrainingSchedule(training));
        [HttpPut]
        public IActionResult UpdateTraining([FromBody] UpdateTrainingScheduleModel training) => HandleResponse(_trainingScheduleService.UpdateTrainingSchedule(training));
        [HttpDelete]
        public IActionResult DeleteTraining(Guid id) => HandleResponse(_trainingScheduleService.DeleteTrainingSchedule(id));


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
