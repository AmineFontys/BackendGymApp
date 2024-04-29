using GymAppTraining.Api.Models;
using GymAppTraining.Api.Services;

namespace GymAppTraining.Api.Interfaces
{
    public interface ITrainingService
    {
        ServiceResponse<dynamic> GetAllTrainings();
        ServiceResponse<dynamic> AddTraining(AddTrainingModel training);
        ServiceResponse<dynamic> GetTrainingById(Guid id);
        ServiceResponse<dynamic> UpdateTraining(UpdateTrainingModel training);
        ServiceResponse<dynamic> DeleteTraining(Guid id);
    }
}
