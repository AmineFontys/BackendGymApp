
using GymAppTraining.Api.Models;
using GymAppTraining.Api.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GymAppTraining.Interfaces
{
    public interface IUserService
    {
        ServiceResponse<dynamic> GetAllUsers();
        ServiceResponse<dynamic> GetUserById(Guid id);
        ServiceResponse<dynamic> AddUser(UserModel user);
        ServiceResponse<dynamic> UpdateUser(UserModel user);
        ServiceResponse<dynamic> DeleteUser(Guid id);
    }
}
