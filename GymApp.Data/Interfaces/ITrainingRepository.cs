using GymApp.Data.Entities;
using GymApp.Data.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GymApp.Data.Interfaces
{
    public interface ITrainingRepository
    {
        RepositoryResponse<dynamic> GetAllTrainings();
        RepositoryResponse<dynamic> GetTrainingById(Guid id);
        RepositoryResponse<dynamic> AddTraining(Training addTraining);
        RepositoryResponse<dynamic> UpdateTraining(Training updateTraining);
        RepositoryResponse<dynamic> DeleteTraining(Guid id);
    }
}
