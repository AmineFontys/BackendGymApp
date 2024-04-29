using GymAppTraining.Api.Models;
using GymAppTraining.Api.Services;

namespace GymAppTraining.Api.Interfaces
{
    public interface IExerciseService
    {
        ServiceResponse<dynamic> GetAllExercises();
        ServiceResponse<dynamic> AddExercise(AddExerciseModel exercise);
        ServiceResponse<dynamic> UpdateExercise(UpdateExerciseModel exercise);
        ServiceResponse<dynamic> GetExerciseById(Guid id);
        ServiceResponse<dynamic> DeleteExercise(Guid id);

    }
}
