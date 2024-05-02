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
        private readonly IRepository _repository;

        public ExerciseRepository(ITrainingContext trainingContext, IRepository repository)
        {
            _trainingContext = trainingContext;
            _repository = repository;
        }



        public RepositoryResponse<dynamic> GetAllExercises()
        {
            try
            {
                var exercises = _trainingContext.Exercises.ToList();

                if(exercises.Count == 0)
                {
                    return _repository.CreateResponse(false, null, "No exercises found");
                }

                return _repository.CreateResponse(true, exercises);
            }
            catch (Exception ex)
            {
                return _repository.HandleException(ex);
            }
        }
        public RepositoryResponse<dynamic> GetExerciseById(Guid id)
        {
            try
            {
                var exercise = _trainingContext.Exercises.Find(id);
                if (exercise == null)
                {
                    return _repository.CreateResponse(false, null, "Exercise not found");
                }
                return _repository.CreateResponse(true, exercise);
            }
            catch (Exception ex)
            {
                return _repository.HandleException(ex);
            }
        }

        public RepositoryResponse<dynamic> AddExercise(Exercise exercise)
        {
            try
            {
                _trainingContext.Exercises.Add(exercise);
                _trainingContext.SaveChanges();

                return _repository.CreateResponse(true, null, "Exercise added successfully");
            }
            catch (Exception ex)
            {
                return _repository.HandleException(ex);
            }
        }

        

        

        public RepositoryResponse<dynamic> UpdateExercise(Exercise exercise)
        {
            try
            {
                _trainingContext.Exercises.Update(exercise);
                _trainingContext.SaveChanges();
                return _repository.CreateResponse(true, exercise);
            }
            catch (Exception ex)
            {
                return _repository.HandleException(ex);
            }
        }
        public RepositoryResponse<dynamic> DeleteExercise(Guid id)
        {
            try
            {
                var exercise = _trainingContext.Exercises.Find(id);
                if (exercise == null)
                {
                    return _repository.CreateResponse(false, null, "Exercise not found");
                }
                _trainingContext.Exercises.Remove(exercise);
                _trainingContext.SaveChanges();
                return _repository.CreateResponse(true, exercise);
            }
            catch (Exception ex)
            {
                return _repository.HandleException(ex);
            }
        }
    }
}
