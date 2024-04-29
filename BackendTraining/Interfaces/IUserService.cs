
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
        ServiceResponse<dynamic> AddUser(AddUserModel user);
        ServiceResponse<dynamic> GetUserById(Guid id);
        ServiceResponse<dynamic> UpdateUser(UpdateUserModel user);
        ServiceResponse<dynamic> DeleteUser(Guid id);
    }
}
