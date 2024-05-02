using AutoMapper;
using GymApp.Data.Entities;
using GymApp.Data.Repositories;
using GymAppTraining.Api.Models;
using GymAppTraining.Api.Services;

namespace GymAppTraining.Api
{
    public class MappingProfiles : Profile
    {
        
        public MappingProfiles()
        {
            CreateMap<User, UserModel>();
            CreateMap<UserModel, User>();
            CreateMap<Training, TrainingModel>();
            CreateMap<TrainingModel, Training>();
            CreateMap<TrainingSchedule, TrainingScheduleModel>();
            CreateMap<TrainingScheduleModel, TrainingSchedule>()
            .ForMember(dest => dest.Exercises, opt => opt.MapFrom(src => src.ExercisesId.Select(id => new Exercise { Id = id })));
            CreateMap<Exercise, ExerciseModel>();
            CreateMap<ExerciseModel, Exercise>();
            CreateMap<ServiceResponse<dynamic>, RepositoryResponse<dynamic>>();
            CreateMap<RepositoryResponse<dynamic>, ServiceResponse<dynamic>>();
           
        }
        
    }
}
