using AutoMapper;
using GymApp.Data.Entities;
using GymApp.Data.Interfaces;
using GymApp.Data.Repositories;
using GymAppTraining.Api.Interfaces;
using GymAppTraining.Api.Models;
using System.Reflection.Metadata.Ecma335;

namespace GymAppTraining.Api.Services
{
    public class ExerciseService : IExerciseService
    {
        private readonly IExerciseRepository _iExerciseRepository;
        private readonly IMapper _mapper;
        private readonly IService _service;

        public ExerciseService(IExerciseRepository exerciseRepository, IMapper mapper, IService service)
        {
            _iExerciseRepository = exerciseRepository;
            _mapper = mapper;
            _service = service;
        }
        
        public uint CalculateDurationInSeconds(ExerciseModel exercise)
        {
            uint totalRepTime = exercise.DurationRep * exercise.Reps * exercise.Sets;
            uint totalRestTime = (exercise.Sets - 1) * exercise.RestTime;
            return totalRepTime + totalRestTime;
        }
        public ServiceResponse<dynamic> AddExercise(ExerciseModel exercise)
        {
            exercise.TotalDuration = CalculateDurationInSeconds(exercise);
            return _service.HandleResponse<Exercise, ExerciseModel>(_iExerciseRepository.AddExercise(_mapper.Map<Exercise>(exercise)));
        }
        public ServiceResponse<dynamic> GetAllExercises() => _service.HandleResponse<Exercise, ExerciseModel>(_iExerciseRepository.GetAllExercises());
        public ServiceResponse<dynamic> GetExerciseById(Guid id) => _service.HandleResponse <Exercise, ExerciseModel> (_iExerciseRepository.GetExerciseById(id));
        public ServiceResponse<dynamic> UpdateExercise(ExerciseModel exercise) => _service.HandleResponse<Exercise, ExerciseModel>(_iExerciseRepository.UpdateExercise(_mapper.Map<Exercise>(exercise)));
        public ServiceResponse<dynamic> DeleteExercise(Guid id) => _service.HandleResponse<Exercise, ExerciseModel>(_iExerciseRepository.DeleteExercise(id));
    }
}
