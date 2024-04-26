using AutoMapper;
using GymApp.Data.Entities;
using GymApp.Data.Repositories;
using GymAppTraining.Api.Interfaces;
using GymAppTraining.Api.Models;

namespace GymAppTraining.Api.Services
{
    public class TrainingService : ITrainingService
    {
        private readonly TrainingRepository _iTrainingRepository;
        private readonly IMapper _mapper;

        public TrainingService(TrainingRepository trainingRepository, IMapper mapper)
        {
            _iTrainingRepository = trainingRepository;
            _mapper = mapper;
        }


        public ServiceResponse<dynamic> AddTraining(AddTrainingScheduleModel training)
        {
            var trainingEntity = _mapper.Map<Training>(training);
            var response = _iTrainingRepository.AddTraining(trainingEntity);
            if (response.Success)
            {
                return new ServiceResponse<dynamic>
                {
                    Success = true,
                    Data = response.Data
                };
            }
            else
            {
                return new ServiceResponse<dynamic>
                {
                    Success = false,
                    Data = response.Data,
                    Message = response.Message
                };
            }
        }

        public ServiceResponse<dynamic> DeleteTraining(int id)
        {
            var response = _iTrainingRepository.DeleteTraining(id);
            if (response.Success)
            {
                return new ServiceResponse<dynamic>
                {
                    Success = true,
                    Data = response.Data
                };
            }
            else
            {
                return new ServiceResponse<dynamic>
                {
                    Success = false,
                    Data = response.Data,
                    Message = response.Message
                };
            }
        }

        public ServiceResponse<dynamic> GetAllTrainings()
        {
            var trainings = _iTrainingRepository.GetAllTrainings();
            if (trainings.Success)
            {
                try
                {
                    return new ServiceResponse<dynamic>
                    {
                        Success = true,
                        Data = trainings.Data
                    };
                }
                catch (System.Exception ex)
                {
                    return new ServiceResponse<dynamic>
                    {
                        Success = false,
                        Data = ex,
                        Message = ex.Message
                    };
                }
            }
            else
            {
                return new ServiceResponse<dynamic>
                {
                    Success = false,
                    Data = trainings.Data,
                    Message = trainings.Message
                };
            }
        }

        public ServiceResponse<dynamic> GetTrainingById(int id)
        {
            var training = _iTrainingRepository.GetTrainingById(id);
            if (training.Success)
            {
                try
                {
                    return new ServiceResponse<dynamic>
                    {
                        Success = true,
                        Data = training.Data
                    };
                }
                catch (System.Exception ex)
                {
                    return new ServiceResponse<dynamic>
                    {
                        Success = false,
                        Data = ex,
                        Message = ex.Message
                    };
                }
            }
            else
            {
                return new ServiceResponse<dynamic>
                {
                    Success = false,
                    Data = training.Data,
                    Message = training.Message
                };
            }
        }

        public ServiceResponse<dynamic> UpdateTraining(UpdateTrainingModel training)
        {
            var trainingEntity = _mapper.Map<Training>(training);
            var response = _iTrainingRepository.UpdateTraining(trainingEntity);
            if (response.Success)
            {
                return new ServiceResponse<dynamic>
                {
                    Success = true,
                    Data = response.Data
                };
            }
            else
            {
                return new ServiceResponse<dynamic>
                {
                    Success = false,
                    Data = response.Data,
                    Message = response.Message
                };
            }
        }




    }
}
