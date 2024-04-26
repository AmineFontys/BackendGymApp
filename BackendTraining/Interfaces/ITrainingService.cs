using GymAppTraining.Api.Models;
using GymAppTraining.Api.Services;

namespace GymAppTraining.Api.Interfaces
{
    public interface ITrainingService
    {
        ServiceResponse<dynamic> GetAllTrainings();
        ServiceResponse<dynamic> AddTraining(AddTrainingScheduleModel training);
        ServiceResponse<dynamic> GetTrainingById(int id);
        ServiceResponse<dynamic> UpdateTraining(UpdateTrainingModel training);
        ServiceResponse<dynamic> DeleteTraining(int id);
    }
}
