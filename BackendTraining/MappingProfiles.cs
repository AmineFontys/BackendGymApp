using AutoMapper;
using GymApp.Data.Entities;
using GymAppTraining.Api.Models;

namespace GymAppTraining.Api
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            CreateMap<User, AddUserModel>();
            CreateMap<AddUserModel, User>();
            



        }
    }
}
