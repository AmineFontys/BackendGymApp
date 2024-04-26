using AutoMapper;
using GymApp.Data.Entities;
using GymApp.Data.Interfaces;
using GymAppTraining.Api.Interfaces;
using GymAppTraining.Api.Models;

namespace GymAppTraining.Api.Services
{
    public class TrainingScheduleService : ITrainingScheduleService
    {
        private readonly ITrainingScheduleRepository _trainingScheduleRepository;
        private readonly IMapper _mapper;

        public TrainingScheduleService(ITrainingScheduleRepository trainingScheduleRepository, IMapper mapper)
        {
            _trainingScheduleRepository = trainingScheduleRepository;
            _mapper = mapper;
        }

        public ServiceResponse<dynamic> GetAllTrainingSchedules()
        {
            var trainingSchedules = _trainingScheduleRepository.GetAllTrainingSchedules();
            if (trainingSchedules.Success)
            {
                try
                {
                    return new ServiceResponse<dynamic>
                    {
                        Success = true,
                        Data = trainingSchedules.Data
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
                    Data = trainingSchedules.Data,
                    Message = trainingSchedules.Message
                };
            }
        }

        public ServiceResponse<dynamic> AddTrainingSchedule(AddTrainingScheduleModel trainingSchedule)
        {
            var trainingScheduleEntity = _mapper.Map<TrainingSchedule>(trainingSchedule);
            var response = _trainingScheduleRepository.AddTrainingSchedule(trainingScheduleEntity);
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

        public ServiceResponse<dynamic> UpdateTrainingSchedule(UpdateTrainingScheduleModel trainingSchedule)
        {
            var trainingScheduleEntity = _mapper.Map<TrainingSchedule>(trainingSchedule);
            var response = _trainingScheduleRepository.UpdateTrainingSchedule(trainingScheduleEntity);
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

        public ServiceResponse<dynamic> GetTrainingScheduleById(Guid id)
        {
            var trainingSchedule = _trainingScheduleRepository.GetTrainingScheduleById(id);
            if (trainingSchedule.Success)
            {
                try
                {
                    return new ServiceResponse<dynamic>
                    {
                        Success = true,
                        Data = trainingSchedule.Data
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
                    Data = trainingSchedule.Data,
                    Message = trainingSchedule.Message
                };
            }
        }

        public ServiceResponse<dynamic> DeleteTrainingSchedule(Guid id)
        {
            var response = _trainingScheduleRepository.DeleteTrainingSchedule(id);
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
