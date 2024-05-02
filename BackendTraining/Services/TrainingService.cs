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
        private readonly IService _service;

        public TrainingService(TrainingRepository trainingRepository, IMapper mapper, IService service)
        {
            _iTrainingRepository = trainingRepository;
            _mapper = mapper;
            _service = service;
        }

        public ServiceResponse<dynamic> GetAllTrainings() => _service.HandleResponse<Training, TrainingModel>(_iTrainingRepository.GetAllTrainings());
        public ServiceResponse<dynamic> GetTrainingById(Guid id) => _service.HandleResponse<Training, TrainingModel>(_iTrainingRepository.GetTrainingById(id));
        public ServiceResponse<dynamic> AddTraining(TrainingModel training) => _service.HandleResponse<Training, TrainingModel>(_iTrainingRepository.AddTraining(_mapper.Map<Training>(training)));
        public ServiceResponse<dynamic> UpdateTraining(TrainingModel training) => _service.HandleResponse<Training, TrainingModel>(_iTrainingRepository.UpdateTraining(_mapper.Map<Training>(training)));
        public ServiceResponse<dynamic> DeleteTraining(Guid id) => _service.HandleResponse<Training, TrainingModel>(_iTrainingRepository.DeleteTraining(id));
    }
}
