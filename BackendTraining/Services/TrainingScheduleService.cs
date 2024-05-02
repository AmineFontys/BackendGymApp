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
        private readonly IService _service;

        public TrainingScheduleService(ITrainingScheduleRepository trainingScheduleRepository, IMapper mapper, IService service)
        {
            _trainingScheduleRepository = trainingScheduleRepository;
            _mapper = mapper;
            _service = service;
        }


        public ServiceResponse<dynamic> GetAllTrainingSchedules() => _service.HandleResponse<TrainingSchedule, TrainingScheduleModel>(_trainingScheduleRepository.GetAllTrainingSchedules());
        public ServiceResponse<dynamic> GetTrainingScheduleById(Guid id) => _service.HandleResponse<TrainingSchedule, TrainingScheduleModel>(_trainingScheduleRepository.GetTrainingScheduleById(id));
        public ServiceResponse<dynamic> AddTrainingSchedule(TrainingScheduleModel trainingScheduleModel) => _service.HandleResponse<TrainingSchedule, TrainingScheduleModel>(_trainingScheduleRepository.AddTrainingSchedule(_mapper.Map<TrainingSchedule>(trainingScheduleModel)));
        public ServiceResponse<dynamic> UpdateTrainingSchedule(TrainingScheduleModel trainingScheduleModel) => _service.HandleResponse<TrainingSchedule, TrainingScheduleModel>(_trainingScheduleRepository.UpdateTrainingSchedule(_mapper.Map<TrainingSchedule>(trainingScheduleModel)));
        public ServiceResponse<dynamic> DeleteTrainingSchedule(Guid id) => _service.HandleResponse<TrainingSchedule, TrainingScheduleModel>(_trainingScheduleRepository.DeleteTrainingSchedule(id));
    }
}
