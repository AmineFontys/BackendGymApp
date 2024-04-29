using AutoMapper;
using GymApp.Data.Entities;
using GymApp.Data.Interfaces;
using GymApp.Data.Repositories;
using GymAppTraining.Api.Interfaces;
using GymAppTraining.Api.Models;

namespace GymAppTraining.Api.Services
{
    public class ExerciseService : IExerciseService
    {
        private readonly IExerciseRepository _iExerciseRepository;
        private readonly IMapper _mapper;

        public ExerciseService(IExerciseRepository exerciseRepository, IMapper mapper)
        {
            _iExerciseRepository = exerciseRepository;
            _mapper = mapper;
        }

        private static ServiceResponse<dynamic> CreateResponse(bool success, dynamic data, string message) => new ServiceResponse<dynamic> { Success = success, Data = data, Message = message };

        private static ServiceResponse<dynamic> HandleResponse(RepositoryResponse<dynamic> response) => CreateResponse(response.Success, response.Data, response.Message);

        public ServiceResponse<dynamic> GetAllExercises() => HandleResponse(_iExerciseRepository.GetAllExercises());

        public ServiceResponse<dynamic> AddExercise(AddExerciseModel exercise) => HandleResponse(_iExerciseRepository.AddExercise(_mapper.Map<Exercise>(exercise)));

        public ServiceResponse<dynamic> GetExerciseById(Guid id) => HandleResponse(_iExerciseRepository.GetExerciseById(id));

        public ServiceResponse<dynamic> UpdateExercise(UpdateExerciseModel exercise) => HandleResponse(_iExerciseRepository.UpdateExercise(_mapper.Map<Exercise>(exercise)));

        public ServiceResponse<dynamic> DeleteExercise(Guid id) => HandleResponse(_iExerciseRepository.DeleteExercise(id));
    }
}
