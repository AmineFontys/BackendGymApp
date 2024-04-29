using AutoMapper;
using GymApp.Data.Entities;
using GymApp.Data.Interfaces;
using GymApp.Data.Repositories;
using GymAppTraining.Api.Models;
using GymAppTraining.Interfaces;

namespace GymAppTraining.Api.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _iUserRepository;
        private readonly IMapper _mapper;

        public UserService(IUserRepository iuserRepository, IMapper mapper)
        {
            _iUserRepository = iuserRepository;
            _mapper = mapper;
        }

        private ServiceResponse<dynamic> CreateResponse(bool success, dynamic data, string message) => new ServiceResponse<dynamic> { Success = success, Data = data, Message = message };

        private ServiceResponse<dynamic> HandleResponse(RepositoryResponse<dynamic> response) => CreateResponse(response.Success, response.Data, response.Message);

        public ServiceResponse<dynamic> GetAllUsers() => HandleResponse(_iUserRepository.GetAllUsers());

        public ServiceResponse<dynamic> AddUser(AddUserModel user) => HandleResponse(_iUserRepository.AddUser(_mapper.Map<User>(user)));

        public ServiceResponse<dynamic> UpdateUser(UpdateUserModel user) => HandleResponse(_iUserRepository.UpdateUser(_mapper.Map<User>(user)));

        public ServiceResponse<dynamic> DeleteUser(Guid id) => HandleResponse(_iUserRepository.DeleteUser(id));

        public ServiceResponse<dynamic> GetUserById(Guid id) => HandleResponse(_iUserRepository.GetUserById(id));
    }
}
