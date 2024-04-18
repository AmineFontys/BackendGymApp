using AutoMapper;
using GymApp.Data.DTO;
using GymAppTraining.Api.Models;
using GymApp.Business.Entities;

namespace GymAppTraining.Api
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            CreateMap<User, UserModel>();
        }
    }
}
