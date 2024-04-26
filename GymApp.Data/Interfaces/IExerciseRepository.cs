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
        RepositoryResponse<dynamic> AddExercise(Exercise exercise);

    }
}
