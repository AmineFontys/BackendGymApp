using GymAppTraining.Api.Models;
using GymAppTraining.Api.Services;

namespace GymAppTraining.Api.Interfaces
{
    public interface IExerciseService
    {
        ServiceResponse<dynamic> GetAllExercises();
        ServiceResponse<dynamic> GetExerciseById(Guid id);
        ServiceResponse<dynamic> AddExercise(ExerciseModel exercise);
        ServiceResponse<dynamic> UpdateExercise(ExerciseModel exercise);
        ServiceResponse<dynamic> DeleteExercise(Guid id);

    }
}
