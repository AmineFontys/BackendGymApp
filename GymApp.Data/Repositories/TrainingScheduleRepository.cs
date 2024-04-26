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

        public RepositoryResponse<dynamic> AddTrainingSchedule(TrainingSchedule trainingSchedule)
        {
            try
            {
                _trainingContext.TrainingSchedules.Add(trainingSchedule);
                _trainingContext.SaveChanges();
                return new RepositoryResponse<dynamic>
                {
                    Success = true,
                    Data = trainingSchedule
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

        public RepositoryResponse<dynamic> DeleteTrainingSchedule(Guid id)
        {
            try
            {
                var trainingSchedule = _trainingContext.TrainingSchedules.Find(id);
                if (trainingSchedule == null)
                {
                    return new RepositoryResponse<dynamic>
                    {
                        Success = false,
                        Data = null,
                        Message = "Training Schedule not found"
                    };
                }
                _trainingContext.TrainingSchedules.Remove(trainingSchedule);
                _trainingContext.SaveChanges();
                return new RepositoryResponse<dynamic>
                {
                    Success = true,
                    Data = trainingSchedule
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

        public RepositoryResponse<dynamic> GetAllTrainingSchedules()
        {
            try
            {
                var trainingSchedules = _trainingContext.TrainingSchedules.ToList();
                return new RepositoryResponse<dynamic>
                {
                    Success = true,
                    Data = trainingSchedules
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

        public RepositoryResponse<dynamic> GetTrainingScheduleById(Guid id)
        {
            try
            {
                var trainingSchedule = _trainingContext.TrainingSchedules.Find(id);
                if (trainingSchedule == null)
                {
                    return new RepositoryResponse<dynamic>
                    {
                        Success = false,
                        Data = null,
                        Message = "Training Schedule not found"
                    };
                }
                return new RepositoryResponse<dynamic>
                {
                    Success = true,
                    Data = trainingSchedule
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
        public RepositoryResponse<dynamic> UpdateTrainingSchedule(TrainingSchedule trainingSchedule)
        {
            try
            {
                _trainingContext.TrainingSchedules.Update(trainingSchedule);
                _trainingContext.SaveChanges();
                return new RepositoryResponse<dynamic>
                {
                    Success = true,
                    Data = trainingSchedule
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
