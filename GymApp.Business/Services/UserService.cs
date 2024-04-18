using AutoMapper;
using GymApp.Business.Interfaces;
using GymApp.Data.Interfaces;
using GymAppTraining.Api.Models;

namespace GymApp.Business.Services
{
    public class UserService : IUserService
    {
        IUserRepository _iUserRepository;
        IMapper _mapper;
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
                    var userModels = _mapper.Map<List<UserModel>>(users);
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

    }
}
