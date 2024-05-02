using AutoMapper;
using GymApp.Data.Entities;
using GymApp.Data.Interfaces;
using GymApp.Data.Repositories;
using GymAppTraining.Api.Interfaces;
using GymAppTraining.Api.Models;
using GymAppTraining.Interfaces;

namespace GymAppTraining.Api.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _iUserRepository;
        private readonly IMapper _mapper;
        private readonly IService _service;

        public UserService(IUserRepository iuserRepository, IMapper mapper, IService service)
        {
            _iUserRepository = iuserRepository;
            _mapper = mapper;
            _service = service;
        }

        public ServiceResponse<dynamic> GetAllUsers() => _service.HandleResponse<User, UserModel>(_iUserRepository.GetAllUsers());
        public ServiceResponse<dynamic> GetUserById(Guid id) => _service.HandleResponse<User, UserModel>(_iUserRepository.GetUserById(id));
        public ServiceResponse<dynamic> AddUser(UserModel user) => _service.HandleResponse<User, UserModel>(_iUserRepository.AddUser(_mapper.Map<User>(user)));
        public ServiceResponse<dynamic> UpdateUser(UserModel user) => _service.HandleResponse<User, UserModel>(_iUserRepository.UpdateUser(_mapper.Map<User>(user)));
        public ServiceResponse<dynamic> DeleteUser(Guid id) => _service.HandleResponse<User, UserModel>(_iUserRepository.DeleteUser(id));

    }
}
