using GymApp.Data.Entities;
using GymApp.Data.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GymApp.Data.Repositories
{
    public class TrainingScheduleRepository : ITrainingScheduleRepository
    {
        private readonly ITrainingContext _trainingContext;
        private readonly IRepository _repository;

        public TrainingScheduleRepository(ITrainingContext trainingContext, IRepository repository)
        {
            _trainingContext = trainingContext;
            _repository = repository;
        }

        public RepositoryResponse<dynamic> GetAllTrainingSchedules()
        {
            try
            {
                var trainingSchedules = _trainingContext.TrainingSchedules
                                 .Include(ts => ts.Exercises)
                                 .ToList();
                return _repository.CreateResponse(true, trainingSchedules);
            }
            catch (Exception ex)
            {
                return _repository.HandleException(ex);
            }
        }

        public RepositoryResponse<dynamic> GetTrainingScheduleById(Guid id)
        {
            try
            {
                var trainingSchedule = _trainingContext.TrainingSchedules
                    .Include(ts => ts.Exercises)
                    .SingleOrDefault(ts => ts.Id == id);

                if (trainingSchedule == null)
                {
                    return _repository.CreateResponse(false, null, "Training Schedule not found");
                }
                return _repository.CreateResponse(true, trainingSchedule);
            }
            catch (Exception ex)
            {
                return _repository.HandleException(ex);
            }
        }
        public RepositoryResponse<dynamic> AddTrainingSchedule(TrainingSchedule newSchedule)
        {
            try
            {

                var exercises = newSchedule.Exercises
                    .Select(e => _trainingContext.Exercises.Find(e.Id))
                    .Where(exercise => exercise != null)
                    .ToList();


                newSchedule.Exercises.Clear();
                foreach (var exercise in exercises)
                {
                    newSchedule.Exercises.Add(exercise);
                }


                _trainingContext.TrainingSchedules.Add(newSchedule);
                _trainingContext.SaveChanges();

                return _repository.CreateResponse(true, newSchedule);
            }
            catch (Exception ex)
            {
                return _repository.HandleException(ex);
            }
        }

       

        

        public RepositoryResponse<dynamic> UpdateTrainingSchedule(TrainingSchedule updatedSchedule)
        {
            try
            {
                var existingSchedule = _trainingContext.TrainingSchedules
                    .Include(ts => ts.Exercises)
                    .FirstOrDefault(ts => ts.Id == updatedSchedule.Id);

                if (existingSchedule == null)
                {
                    return _repository.CreateResponse(false, null, "Training Schedule not found");
                }
                _trainingContext.Entry(existingSchedule).CurrentValues.SetValues(updatedSchedule);

                foreach (var existingExercise in existingSchedule.Exercises.ToList())
                {
                    if (!updatedSchedule.Exercises.Any(e => e.Id == existingExercise.Id))
                        existingSchedule.Exercises.Remove(existingExercise);
                }

                
                foreach (var newExercise in updatedSchedule.Exercises)
                {
                    if (!existingSchedule.Exercises.Any(e => e.Id == newExercise.Id))
                    {
                        var exerciseToAdd = _trainingContext.Exercises.Find(newExercise.Id) ?? newExercise;
                        existingSchedule.Exercises.Add(exerciseToAdd);
                    }
                }
                _trainingContext.SaveChanges();
                return _repository.CreateResponse(true, existingSchedule);
            }
            catch (Exception ex)
            {
                return _repository.HandleException(ex);
            }



        }
        public RepositoryResponse<dynamic> DeleteTrainingSchedule(Guid id)
        {
            try
            {
                var trainingSchedule = _trainingContext.TrainingSchedules.Find(id);
                if (trainingSchedule == null)
                {
                    return _repository.CreateResponse(false, null, "Training Schedule not found");
                }
                _trainingContext.TrainingSchedules.Remove(trainingSchedule);
                _trainingContext.SaveChanges();
                return _repository.CreateResponse(true, trainingSchedule);
            }
            catch (Exception ex)
            {
                return _repository.HandleException(ex);
            }
        }
    }
}
