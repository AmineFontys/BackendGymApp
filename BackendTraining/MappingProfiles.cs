using AutoMapper;
using GymApp.Data.Entities;
using GymApp.Data.Repositories;
using GymAppTraining.Api.Models;
using GymAppTraining.Api.Services;
using static GymApp.Data.Entities.User;

namespace GymAppTraining.Api
{
    public class MappingProfiles : Profile
    {
        
        public MappingProfiles()
        {
            CreateMap<User, UserModel>()
            .ForMember(dest => dest.Role, opt => opt.MapFrom(src => (uint)src.Role));
            CreateMap<UserModel, User>()
                .ForMember(dest => dest.Role, opt => opt.MapFrom(src => (UserRole)src.Role));

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
