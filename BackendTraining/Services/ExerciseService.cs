using AutoMapper;
using GymApp.Data.Entities;
using GymApp.Data.Interfaces;
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

        public ServiceResponse<dynamic> GetAllExercises()
        {
            var exercises = _iExerciseRepository.GetAllExercises();
            if (exercises.Success)
            {
                try
                {
                    return new ServiceResponse<dynamic>
                    {
                        Success = true,
                        Data = exercises.Data
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
                    Data = exercises.Data,
                    Message = exercises.Message
                };
            }
        }

        public ServiceResponse<dynamic> AddExercise(AddExerciseModel exercise)
        {
            var exerciseEntity = _mapper.Map<Exercise>(exercise);
            var response = _iExerciseRepository.AddExercise(exerciseEntity);
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
