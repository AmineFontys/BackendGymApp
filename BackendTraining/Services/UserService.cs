using AutoMapper;
using GymApp.Data.Entities;
using GymApp.Data.Interfaces;
using GymAppTraining.Api.Models;
using GymAppTraining.Interfaces;

namespace GymAppTraining.Api.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _iUserRepository;
        private readonly IMapper _mapper;
        public UserService(IUserRepository userRepository, IMapper mapper) 
        {
            _iUserRepository = userRepository;
            _mapper = mapper;
        }

        public ServiceResponse<dynamic> GetAllUsers()
        {
            var users = _iUserRepository.GetAllUsers();
            if (users.Success)
            {
                try
                {
                    var userModels = _mapper.Map<List<User>>(users);
                    return new ServiceResponse<dynamic>
                    {
                        Success = true,
                        Data = userModels
                    };
                }
                catch (Exception ex) 
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
                    Data = users.Data,
                    Message = users.Message

                };
            }

            
        }
        public ServiceResponse<dynamic> AddUser(AddUserModel user)
        {
            var userEntity = _mapper.Map<User>(user);
            var result = _iUserRepository.AddUser(userEntity);
            if (result.Success)
            {
                return new ServiceResponse<dynamic>
                {
                    Success = true,
                    Message = "User added successfully"
                };
            }
            else
            {
                return new ServiceResponse<dynamic>
                {
                    Success = false,
                    Message = result.Message
                };
            }
        }   

    }
}
