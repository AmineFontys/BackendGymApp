using GymApp.Data.Entities;
using GymApp.Data.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GymApp.Data.Repositories
{
    public class ExerciseRepository: IExerciseRepository
    {
        private readonly ITrainingContext _trainingContext;
        public ExerciseRepository(ITrainingContext trainingContext)
        {
            _trainingContext = trainingContext;
        }

        public RepositoryResponse<dynamic> GetAllExercises()
        {
            try
            {
                var exercises = _trainingContext.Exercises.ToList();

                return new RepositoryResponse<dynamic>
                {
                    Success = true,
                    Data = exercises
                };

            }
            catch (Exception ex)
            {

                return new RepositoryResponse<dynamic>
                {
                    Success = false,
                    Data = ex,
                    Message = ex.Message
                };
            }

        }

        public RepositoryResponse<dynamic> AddExercise(Exercise exercise)
        {
            try
            {
                _trainingContext.Exercises.Add(exercise);
                _trainingContext.SaveChanges();

                return new RepositoryResponse<dynamic>
                {
                    Success = true,
                    Message = "Exercise added successfully"
                };
            }
            catch (Exception ex)
            {
                return new RepositoryResponse<dynamic>
                {
                    Success = false,
                    Data = ex,
                    Message = ex.Message
                };
            }
        }
    }
}
