using GymApp.Data.Entities;
using GymApp.Data.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GymApp.Data.Repositories
{
    public class TrainingRepository : ITrainingRepository
    {
        private readonly ITrainingContext _trainingContext;
        private readonly IRepository _repository;

        public TrainingRepository(ITrainingContext trainingContext, IRepository repository)
        {
            _trainingContext = trainingContext;
            _repository = repository;
        }

        public RepositoryResponse<dynamic> GetAllTrainings()
        {
            try
            {
                var trainings = _trainingContext.Trainings.ToList();
                return _repository.CreateResponse(true, trainings);
            }
            catch (Exception ex)
            {
                return _repository.HandleException(ex);
            }
        }

        public RepositoryResponse<dynamic> GetTrainingById(Guid id)
        {
            try
            {
                var training = _trainingContext.Trainings.Find(id);
                if (training == null)
                {
                    return _repository.CreateResponse(false, null, "Training not found");
                }
                return _repository.CreateResponse(true, training);
            }
            catch (Exception ex)
            {
                return _repository.HandleException(ex);
            }
        }
        public RepositoryResponse<dynamic> AddTraining(Training training)
        {
            try
            {
                _trainingContext.Trainings.Add(training);
                _trainingContext.SaveChanges();
                return _repository.CreateResponse(true, training);
            }
            catch (Exception ex)
            {
                return _repository.HandleException(ex);
            }
        }

         

        public RepositoryResponse<dynamic> UpdateTraining(Training training)
        {
            try
            {
                var existingTraining = _trainingContext.Trainings.Find(training.Id);
                if (existingTraining == null)
                {
                    return _repository.CreateResponse(false, null, "Training not found");
                }
                _trainingContext.Entry(existingTraining).CurrentValues.SetValues(training);
                _trainingContext.SaveChanges();
                return _repository.CreateResponse(true, training);
            }
            catch (Exception ex)
            {
                return _repository.HandleException(ex);
            }
        }
        public RepositoryResponse<dynamic> DeleteTraining(Guid id)
        {
            try
            {
                var training = _trainingContext.Trainings.Find(id);
                if (training == null)
                {
                    return _repository.CreateResponse(false, null, "Training not found");
                }
                _trainingContext.Trainings.Remove(training);
                _trainingContext.SaveChanges();
                return _repository.CreateResponse(true, training);
            }
            catch (Exception ex)
            {
                return _repository.HandleException(ex);
            }
        }
    }
}
