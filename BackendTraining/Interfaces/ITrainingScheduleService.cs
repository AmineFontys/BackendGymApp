using GymAppTraining.Api.Models;
using GymAppTraining.Api.Services;

namespace GymAppTraining.Api.Interfaces
{
    public interface ITrainingScheduleService
    {
        ServiceResponse<dynamic> GetAllTrainingSchedules();
        ServiceResponse<dynamic> AddTrainingSchedule(AddTrainingScheduleModel trainingSchedule);
        ServiceResponse<dynamic> GetTrainingScheduleById(Guid id);
        ServiceResponse<dynamic> UpdateTrainingSchedule(UpdateTrainingScheduleModel trainingSchedule);
        ServiceResponse<dynamic> DeleteTrainingSchedule(Guid id);
    }
}
