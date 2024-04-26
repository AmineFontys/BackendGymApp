using GymAppTraining.Api.Models;
using GymAppTraining.Api.Services;

namespace GymAppTraining.Api.Interfaces
{
    public interface IExerciseService
    {
        ServiceResponse<dynamic> GetAllExercises();
        ServiceResponse<dynamic> AddExercise(AddExerciseModel exercise);
    }
}
