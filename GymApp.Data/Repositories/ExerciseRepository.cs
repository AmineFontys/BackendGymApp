using GymApp.Data.Entities;
using GymApp.Data.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GymApp.Data.Repositories
{
    public class ExerciseRepository : IExerciseRepository
    {
        private readonly ITrainingContext _trainingContext;

        public ExerciseRepository(ITrainingContext trainingContext)
        {
            _trainingContext = trainingContext;
        }

        private RepositoryResponse<dynamic> CreateResponse(bool success, dynamic? data, string? message = null)
        {
            return new RepositoryResponse<dynamic>
            {
                Success = success,
                Data = data,
                Message = message
            };
        }

        private RepositoryResponse<dynamic> HandleException(Exception ex)
        {
            return CreateResponse(false, ex, ex.Message);
        }

        public RepositoryResponse<dynamic> GetAllExercises()
        {
            try
            {
                var exercises = _trainingContext.Exercises.ToList();

                return CreateResponse(true, exercises);
            }
            catch (Exception ex)
            {
                return HandleException(ex);
            }
        }

        public RepositoryResponse<dynamic> AddExercise(Exercise exercise)
        {
            try
            {
                _trainingContext.Exercises.Add(exercise);
                _trainingContext.SaveChanges();

                return CreateResponse(true, null, "Exercise added successfully");
            }
            catch (Exception ex)
            {
                return HandleException(ex);
            }
        }

        public RepositoryResponse<dynamic> DeleteExercise(Guid id)
        {
            try
            {
                var exercise = _trainingContext.Exercises.Find(id);
                if (exercise == null)
                {
                    return CreateResponse(false, null, "Exercise not found");
                }
                _trainingContext.Exercises.Remove(exercise);
                _trainingContext.SaveChanges();
                return CreateResponse(true, exercise);
            }
            catch (Exception ex)
            {
                return HandleException(ex);
            }
        }

        public RepositoryResponse<dynamic> GetExerciseById(Guid id)
        {
            try
            {
                var exercise = _trainingContext.Exercises.Find(id);
                if (exercise == null)
                {
                    return CreateResponse(false, null, "Exercise not found");
                }
                return CreateResponse(true, exercise);
            }
            catch (Exception ex)
            {
                return HandleException(ex);
            }
        }

        public RepositoryResponse<dynamic> UpdateExercise(Exercise exercise)
        {
            try
            {
                _trainingContext.Exercises.Update(exercise);
                _trainingContext.SaveChanges();
                return CreateResponse(true, exercise);
            }
            catch (Exception ex)
            {
                return HandleException(ex);
            }
        }
    }
}
