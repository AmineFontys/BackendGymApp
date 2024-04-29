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

        public TrainingRepository(ITrainingContext trainingContext)
        {
            _trainingContext = trainingContext;
        }

        private static RepositoryResponse<dynamic> CreateResponse(bool success, dynamic? data, string? message = null) => new RepositoryResponse<dynamic> { Success = success, Data = data, Message = message };

        private static RepositoryResponse<dynamic> HandleException(Exception ex) => CreateResponse(false, ex, ex.Message);

        public RepositoryResponse<dynamic> AddTraining(Training training)
        {
            try
            {
                _trainingContext.Trainings.Add(training);
                _trainingContext.SaveChanges();
                return CreateResponse(true, training);
            }
            catch (Exception ex)
            {
                return HandleException(ex);
            }
        }

        public RepositoryResponse<dynamic> DeleteTraining(Guid id)
        {
            try
            {
                var training = _trainingContext.Trainings.Find(id);
                if (training == null)
                {
                    return CreateResponse(false, null, "Training not found");
                }
                _trainingContext.Trainings.Remove(training);
                _trainingContext.SaveChanges();
                return CreateResponse(true, training);
            }
            catch (Exception ex)
            {
                return HandleException(ex);
            }
        }

        public RepositoryResponse<dynamic> GetAllTrainings()
        {
            try
            {
                var trainings = _trainingContext.Trainings.ToList();
                return CreateResponse(true, trainings);
            }
            catch (Exception ex)
            {
                return HandleException(ex);
            }
        }

        public RepositoryResponse<dynamic> GetTrainingById(Guid id)
        {
            try
            {
                var training = _trainingContext.Trainings.Find(id);
                if (training == null)
                {
                    return CreateResponse(false, null, "Training not found");
                }
                return CreateResponse(true, training);
            }
            catch (Exception ex)
            {
                return HandleException(ex);
            }
        }

        public RepositoryResponse<dynamic> UpdateTraining(Training training)
        {
            try
            {
                var existingTraining = _trainingContext.Trainings.Find(training.Id);
                if (existingTraining == null)
                {
                    return CreateResponse(false, null, "Training not found");
                }
                _trainingContext.Entry(existingTraining).CurrentValues.SetValues(training);
                _trainingContext.SaveChanges();
                return CreateResponse(true, training);
            }
            catch (Exception ex)
            {
                return HandleException(ex);
            }
        }
    }
}
