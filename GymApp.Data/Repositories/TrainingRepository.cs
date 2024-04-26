using GymApp.Data.Entities;
using GymApp.Data.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GymApp.Data.Repositories
{
    public class TrainingRepository: ITrainingRepository
    {
        private readonly ITrainingContext _trainingContext;

        public TrainingRepository(ITrainingContext trainingContext)
        {
            _trainingContext = trainingContext;
        }

        public RepositoryResponse<dynamic> AddTraining(Training training)
        {
            try
            {
                _trainingContext.Trainings.Add(training);
                _trainingContext.SaveChanges();
                return new RepositoryResponse<dynamic>
                {
                    Success = true,
                    Data = training
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

        public RepositoryResponse<dynamic> DeleteTraining(int id)
        {
            try
            {
                var training = _trainingContext.Trainings.Find(id);
                if (training == null)
                {
                    return new RepositoryResponse<dynamic>
                    {
                        Success = false,
                        Data = null,
                        Message = "Training not found"
                    };
                }
                _trainingContext.Trainings.Remove(training);
                _trainingContext.SaveChanges();
                return new RepositoryResponse<dynamic>
                {
                    Success = true,
                    Data = training
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

        public RepositoryResponse<dynamic> GetAllTrainings()
        {
            try
            {
                var trainings = _trainingContext.Trainings.ToList();
                return new RepositoryResponse<dynamic>
                {
                    Success = true,
                    Data = trainings
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

        public RepositoryResponse<dynamic> GetTrainingById(int id)
        {
            try
            {
                var training = _trainingContext.Trainings.Find(id);
                if (training == null)
                {
                    return new RepositoryResponse<dynamic>
                    {
                        Success = false,
                        Data = null,
                        Message = "Training not found"
                    };
                }
                return new RepositoryResponse<dynamic>
                {
                    Success = true,
                    Data = training
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

        public RepositoryResponse<dynamic> UpdateTraining(Training training)
        {
            try
            {
                var existingTraining = _trainingContext.Trainings.Find(training.Id);
                if (existingTraining == null)
                {
                    return new RepositoryResponse<dynamic>
                    {
                        Success = false,
                        Data = null,
                        Message = "Training not found"
                    };
                }
                existingTraining = training;

                _trainingContext.SaveChanges();

                return new RepositoryResponse<dynamic>
                {
                    Success = true,
                    Data = training
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
