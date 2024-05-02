using AutoMapper;
using GymApp.Data.Entities;
using GymApp.Data.Interfaces;
using GymApp.Data.Repositories;
using GymAppTraining.Api.Interfaces;
using GymAppTraining.Api.Models;
using System.Reflection.Metadata.Ecma335;

namespace GymAppTraining.Api.Services
{
    /// <summary>
    /// Service class for managing exercises.
    /// </summary>
    public class ExerciseService : IExerciseService
    {
        private readonly IExerciseRepository _iExerciseRepository;
        private readonly IMapper _mapper;
        private readonly IService _service;

        /// <summary>
        /// Initializes a new instance of the <see cref="ExerciseService"/> class.
        /// </summary>
        /// <param name="exerciseRepository">The exercise repository.</param>
        /// <param name="mapper">The mapper.</param>
        /// <param name="service">The service.</param>
        public ExerciseService(IExerciseRepository exerciseRepository, IMapper mapper, IService service)
        {
            _iExerciseRepository = exerciseRepository;
            _mapper = mapper;
            _service = service;
        }

        /// <summary>
        /// Calculates the total duration of an exercise in seconds.
        /// </summary>
        /// <param name="exercise">The exercise model.</param>
        /// <returns>The total duration in seconds.</returns>
        public uint CalculateDurationInSeconds(ExerciseModel exercise)
        {
            uint totalRepTime = exercise.DurationRep * exercise.Reps * exercise.Sets;
            uint totalRestTime = (exercise.Sets - 1) * exercise.RestTime;
            return totalRepTime + totalRestTime;
        }

        /// <summary>
        /// Adds a new exercise.
        /// </summary>
        /// <param name="exercise">The exercise model.</param>
        /// <returns>The service response.</returns>
        public ServiceResponse<dynamic> AddExercise(ExerciseModel exercise)
        {
            exercise.TotalDuration = CalculateDurationInSeconds(exercise);
            return _service.HandleResponse<Exercise, ExerciseModel>(_iExerciseRepository.AddExercise(_mapper.Map<Exercise>(exercise)));
        }

        /// <summary>
        /// Gets all exercises.
        /// </summary>
        /// <returns>The service response.</returns>
        public ServiceResponse<dynamic> GetAllExercises() => _service.HandleResponse<Exercise, ExerciseModel>(_iExerciseRepository.GetAllExercises());

        /// <summary>
        /// Gets an exercise by its ID.
        /// </summary>
        /// <param name="id">The exercise ID.</param>
        /// <returns>The service response.</returns>
        public ServiceResponse<dynamic> GetExerciseById(Guid id) => _service.HandleResponse<Exercise, ExerciseModel>(_iExerciseRepository.GetExerciseById(id));

        /// <summary>
        /// Updates an existing exercise.
        /// </summary>
        /// <param name="exercise">The exercise model.</param>
        /// <returns>The service response.</returns>
        public ServiceResponse<dynamic> UpdateExercise(ExerciseModel exercise) => _service.HandleResponse<Exercise, ExerciseModel>(_iExerciseRepository.UpdateExercise(_mapper.Map<Exercise>(exercise)));

        /// <summary>
        /// Deletes an exercise by its ID.
        /// </summary>
        /// <param name="id">The exercise ID.</param>
        /// <returns>The service response.</returns>
        public ServiceResponse<dynamic> DeleteExercise(Guid id) => _service.HandleResponse<Exercise, ExerciseModel>(_iExerciseRepository.DeleteExercise(id));
    }
}
