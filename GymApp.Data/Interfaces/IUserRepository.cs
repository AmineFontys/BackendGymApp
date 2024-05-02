
using GymApp.Data.Entities;
using GymApp.Data.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GymApp.Data.Interfaces
{
    public interface IUserRepository
    {
        RepositoryResponse<dynamic> GetAllUsers();
        RepositoryResponse<dynamic> DeleteUser(Guid id);
        RepositoryResponse<dynamic> AddUser(User addUser);
        RepositoryResponse<dynamic> UpdateUser(User updateUser);
        RepositoryResponse<dynamic> GetUserById(Guid id);
    }
}
