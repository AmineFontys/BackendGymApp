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

        private static ServiceResponse<dynamic> CreateResponse(bool success, dynamic data, string message) => new ServiceResponse<dynamic> { Success = success, Data = data, Message = message };

        private static ServiceResponse<dynamic> HandleResponse(RepositoryResponse<dynamic> response) => CreateResponse(response.Success, response.Data, response.Message);

        public ServiceResponse<dynamic> AddTraining(AddTrainingModel training) => HandleResponse(_iTrainingRepository.AddTraining(_mapper.Map<Training>(training)));
        
        public ServiceResponse<dynamic> DeleteTraining(Guid id) => HandleResponse(_iTrainingRepository.DeleteTraining(id));

        public ServiceResponse<dynamic> GetAllTrainings() => HandleResponse(_iTrainingRepository.GetAllTrainings());

        public ServiceResponse<dynamic> GetTrainingById(Guid id) => HandleResponse(_iTrainingRepository.GetTrainingById(id));

        public ServiceResponse<dynamic> UpdateTraining(UpdateTrainingModel training) => HandleResponse(_iTrainingRepository.UpdateTraining(_mapper.Map<Training>(training)));
    }
}
