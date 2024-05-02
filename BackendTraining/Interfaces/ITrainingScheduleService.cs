using GymAppTraining.Api.Models;
using GymAppTraining.Api.Services;

namespace GymAppTraining.Api.Interfaces
{
    public interface ITrainingScheduleService
    {
        ServiceResponse<dynamic> GetAllTrainingSchedules();
        ServiceResponse<dynamic> GetTrainingScheduleById(Guid id);
        ServiceResponse<dynamic> AddTrainingSchedule(TrainingScheduleModel trainingSchedule);
        ServiceResponse<dynamic> UpdateTrainingSchedule(TrainingScheduleModel trainingSchedule);
        ServiceResponse<dynamic> DeleteTrainingSchedule(Guid id);
    }
}
