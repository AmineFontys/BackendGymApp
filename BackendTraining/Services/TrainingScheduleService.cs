using AutoMapper;
using GymApp.Data.Entities;
using GymApp.Data.Interfaces;
using GymApp.Data.Repositories;
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

        private static ServiceResponse<dynamic> CreateResponse(bool success, dynamic data, string message) => new ServiceResponse<dynamic> { Success = success, Data = data, Message = message };

        private static ServiceResponse<dynamic> HandleResponse(RepositoryResponse<dynamic> response) => CreateResponse(response.Success, response.Data, response.Message);

        public ServiceResponse<dynamic> GetAllTrainingSchedules() => HandleResponse(_trainingScheduleRepository.GetAllTrainingSchedules());

        public ServiceResponse<dynamic> AddTrainingSchedule(AddTrainingScheduleModel trainingSchedule) => HandleResponse(_trainingScheduleRepository.AddTrainingSchedule(_mapper.Map<TrainingSchedule>(trainingSchedule)));

        public ServiceResponse<dynamic> UpdateTrainingSchedule(UpdateTrainingScheduleModel trainingSchedule) => HandleResponse(_trainingScheduleRepository.UpdateTrainingSchedule(_mapper.Map<TrainingSchedule>(trainingSchedule)));

        public ServiceResponse<dynamic> GetTrainingScheduleById(Guid id) => HandleResponse(_trainingScheduleRepository.GetTrainingScheduleById(id));

        public ServiceResponse<dynamic> DeleteTrainingSchedule(Guid id) => HandleResponse(_trainingScheduleRepository.DeleteTrainingSchedule(id));
    }
}
