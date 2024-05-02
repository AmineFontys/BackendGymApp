using GymApp.Data.Entities;
using GymApp.Data.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GymApp.Data.Interfaces
{
    public interface IExerciseRepository
    {
        RepositoryResponse<dynamic> GetAllExercises();
        RepositoryResponse<dynamic> GetExerciseById(Guid id);
        RepositoryResponse<dynamic> AddExercise(Exercise addExercise);
        RepositoryResponse<dynamic> UpdateExercise(Exercise updateExercise);
        RepositoryResponse<dynamic> DeleteExercise(Guid id);
        

    }
}
