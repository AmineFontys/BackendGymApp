using GymApp.Data.Entities;
using GymApp.Data.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GymApp.Data.Interfaces
{
    public interface ITrainingScheduleRepository
    {
        RepositoryResponse<dynamic> GetAllTrainingSchedules();
        RepositoryResponse<dynamic> GetTrainingScheduleById(Guid id);
        RepositoryResponse<dynamic> AddTrainingSchedule(TrainingSchedule trainingSchedule);
        RepositoryResponse<dynamic> UpdateTrainingSchedule(TrainingSchedule trainingSchedule);
        RepositoryResponse<dynamic> DeleteTrainingSchedule(Guid id);
    }
}
