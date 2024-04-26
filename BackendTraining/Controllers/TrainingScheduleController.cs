using GymAppTraining.Api.Interfaces;
using GymAppTraining.Api.Models;
using Microsoft.AspNetCore.Mvc;

namespace GymAppTraining.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TrainingScheduleController : Controller
    {
        private readonly ITrainingService _trainingService;

        public TrainingScheduleController(ITrainingService trainingService)
        {
            _trainingService = trainingService;
        }

        [HttpGet]
        public IActionResult GetAllTrainings()
        {
            var response = _trainingService.GetAllTrainings();
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
        public IActionResult AddTraining([FromBody] AddTrainingScheduleModel training)
        {
            var response = _trainingService.AddTraining(training);
            if (response.Success)
            {
                return Ok(response.Data);
            }
            else
            {
                return BadRequest(response.Message);
            }
        }

        [HttpGet("{id}")]
        public IActionResult GetTrainingById(int id)
        {
            var response = _trainingService.GetTrainingById(id);
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
        public IActionResult UpdateTraining([FromBody] UpdateTrainingModel training)
        {
            var response = _trainingService.UpdateTraining(training);
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
        public IActionResult DeleteTraining(int id)
        {
            var response = _trainingService.DeleteTraining(id);
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
