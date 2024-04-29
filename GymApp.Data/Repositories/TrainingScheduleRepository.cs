using GymApp.Data.Entities;
using GymApp.Data.Interfaces;
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

        public TrainingScheduleRepository(ITrainingContext trainingContext)
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

        public RepositoryResponse<dynamic> AddTrainingSchedule(TrainingSchedule trainingSchedule)
        {
            try
            {
                _trainingContext.TrainingSchedules.Add(trainingSchedule);
                _trainingContext.SaveChanges();
                return CreateResponse(true, trainingSchedule);
            }
            catch (Exception ex)
            {
                return HandleException(ex);
            }
        }

        public RepositoryResponse<dynamic> DeleteTrainingSchedule(Guid id)
        {
            try
            {
                var trainingSchedule = _trainingContext.TrainingSchedules.Find(id);
                if (trainingSchedule == null)
                {
                    return CreateResponse(false, null, "Training Schedule not found");
                }
                _trainingContext.TrainingSchedules.Remove(trainingSchedule);
                _trainingContext.SaveChanges();
                return CreateResponse(true, trainingSchedule);
            }
            catch (Exception ex)
            {
                return HandleException(ex);
            }
        }

        public RepositoryResponse<dynamic> GetAllTrainingSchedules()
        {
            try
            {
                var trainingSchedules = _trainingContext.TrainingSchedules.ToList();
                return CreateResponse(true, trainingSchedules);
            }
            catch (Exception ex)
            {
                return HandleException(ex);
            }
        }

        public RepositoryResponse<dynamic> GetTrainingScheduleById(Guid id)
        {
            try
            {
                var trainingSchedule = _trainingContext.TrainingSchedules.Find(id);
                if (trainingSchedule == null)
                {
                    return CreateResponse(false, null, "Training Schedule not found");
                }
                return CreateResponse(true, trainingSchedule);
            }
            catch (Exception ex)
            {
                return HandleException(ex);
            }
        }

        public RepositoryResponse<dynamic> UpdateTrainingSchedule(TrainingSchedule trainingSchedule)
        {
            try
            {
                _trainingContext.TrainingSchedules.Update(trainingSchedule);
                _trainingContext.SaveChanges();
                return CreateResponse(true, trainingSchedule);
            }
            catch (Exception ex)
            {
                return HandleException(ex);
            }
        }
    }
}
