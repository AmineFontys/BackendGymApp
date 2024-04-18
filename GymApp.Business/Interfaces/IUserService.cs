using GymAppTraining.Api.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GymApp.Business.Interfaces
{
    public interface IUserService
    {
        ServiceResponse<dynamic> GetAllUsers();
    }
}
