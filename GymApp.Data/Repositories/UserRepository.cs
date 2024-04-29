
using GymApp.Data.DAL;
using GymApp.Data.Entities;
using GymApp.Data.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GymApp.Data.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly ITrainingContext _trainingContext;

        public UserRepository(ITrainingContext trainingContext)
        {
            _trainingContext = trainingContext;
        }

        private static RepositoryResponse<dynamic> CreateResponse(bool success, dynamic? data, string? message = null) => new RepositoryResponse<dynamic> { Success = success, Data = data, Message = message };
        private static RepositoryResponse<dynamic> HandleException(Exception ex) => CreateResponse(false, ex, ex.Message);


        public RepositoryResponse<dynamic> GetAllUsers()
        {
            try
            {
                var users = _trainingContext.Users.ToList();
                return CreateResponse(true, users);
            }
            catch (Exception ex)
            {
                return HandleException(ex);
            }
        }

        public RepositoryResponse<dynamic> AddUser(User user)
        {
            try
            {
                _trainingContext.Users.Add(user);
                _trainingContext.SaveChanges();
                return CreateResponse(true, null, "User added successfully");
            }
            catch (Exception ex)
            {
                return HandleException(ex);
            }
        }

        public RepositoryResponse<dynamic> UpdateUser(User user)
        {
            try
            {
                var existingUser = _trainingContext.Users.Find(user.Id);
                if (existingUser == null)
                {
                    return CreateResponse(false, null, "User not found");
                }
                _trainingContext.Entry(existingUser).CurrentValues.SetValues(user);
                _trainingContext.SaveChanges();
                return CreateResponse(true, user);
            }
            catch (Exception ex)
            {
                return HandleException(ex);
            }
        }

        public RepositoryResponse<dynamic> DeleteUser(Guid id)
        {
            try
            {
                var user = _trainingContext.Users.Find(id);
                if (user == null)
                {
                    return CreateResponse(false, null, "User not found");
                }
                _trainingContext.Users.Remove(user);
                _trainingContext.SaveChanges();
                return CreateResponse(true, user);
            }
            catch (Exception ex)
            {
                return HandleException(ex);
            }
        }

        public RepositoryResponse<dynamic> GetUserById(Guid id)
        {
            try
            {
                var user = _trainingContext.Users.Find(id);
                if (user == null)
                {
                    return CreateResponse(false, null, "User not found");
                }
                return CreateResponse(true, user);
            }
            catch (Exception ex)
            {
                return HandleException(ex);
            }
        }
    }
}
