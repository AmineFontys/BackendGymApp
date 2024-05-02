using GymAppTraining.Api.Models;
using GymAppTraining.Api.Services;

namespace GymAppTraining.Api.Interfaces
{
    public interface ITrainingService
    {
        ServiceResponse<dynamic> GetAllTrainings();
        ServiceResponse<dynamic> GetTrainingById(Guid id);
        ServiceResponse<dynamic> AddTraining(TrainingModel training);
        ServiceResponse<dynamic> UpdateTraining(TrainingModel training);
        ServiceResponse<dynamic> DeleteTraining(Guid id);
    }
}
