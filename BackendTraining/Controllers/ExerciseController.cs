using GymAppTraining.Api.Interfaces;
using GymAppTraining.Api.Models;
using GymAppTraining.Api.Services;
using Microsoft.AspNetCore.Mvc;

namespace GymAppTraining.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ExerciseController : Controller
    {
        private readonly IExerciseService _exerciseService;

        public ExerciseController(IExerciseService exerciseService)
        {
            _exerciseService = exerciseService;
        }

        [HttpGet]
        public IActionResult GetAllExercises() => HandleResponse(_exerciseService.GetAllExercises());
        [HttpGet("{id}")]
        public IActionResult GetExerciseById(Guid id) => HandleResponse(_exerciseService.GetExerciseById(id));
        [HttpPost]
        public IActionResult AddExercise([FromBody] ExerciseModel exercise) => HandleResponse(_exerciseService.AddExercise(exercise));
        [HttpPut]
        public IActionResult UpdateExercise([FromBody] ExerciseModel exercise) => HandleResponse(_exerciseService.UpdateExercise(exercise));
        [HttpDelete("{id}")]
        public IActionResult DeleteExercise(Guid id) => HandleResponse(_exerciseService.DeleteExercise(id));


        private IActionResult HandleResponse<T>(ServiceResponse<T> response)
        {
            if (response.Success)
            {
                return Ok(response);
            }
            else
            {
                return BadRequest(response.Message);
            }
        }
    }
}
