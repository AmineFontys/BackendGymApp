
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
        private readonly IRepository _repository;

        public UserRepository(ITrainingContext trainingContext, IRepository repository)
        {
            _trainingContext = trainingContext;
            _repository = repository;
        }
        public RepositoryResponse<dynamic> GetAllUsers()
        {
            try
            {
                var users = _trainingContext.Users.ToList();
                return _repository.CreateResponse(true, users);
            }
            catch (Exception ex)
            {
                return _repository.HandleException(ex);
            }
        }
        public RepositoryResponse<dynamic> GetUserById(Guid id)
        {
            try
            {
                var user = _trainingContext.Users.Find(id);
                if (user == null)
                {
                    return _repository.CreateResponse(false, null, "User not found");
                }
                return _repository.CreateResponse(true, user);
            }
            catch (Exception ex)
            {
                return _repository.HandleException(ex);
            }
        }

        public RepositoryResponse<dynamic> AddUser(User user)
        {
            try
            {
                _trainingContext.Users.Add(user);
                _trainingContext.SaveChanges();
                return _repository.CreateResponse(true, null, "User added successfully");
            }
            catch (Exception ex)
            {
                return _repository.HandleException(ex);
            }
        }

        public RepositoryResponse<dynamic> UpdateUser(User user)
        {
            try
            {
                var existingUser = _trainingContext.Users.Find(user.Id);
                if (existingUser == null)
                {
                    return _repository.CreateResponse(false, null, "User not found");
                }
                _trainingContext.Entry(existingUser).CurrentValues.SetValues(user);
                _trainingContext.SaveChanges();
                return _repository.CreateResponse(true, user);
            }
            catch (Exception ex)
            {
                return _repository.HandleException(ex);
            }
        }

        public RepositoryResponse<dynamic> DeleteUser(Guid id)
        {
            try
            {
                var user = _trainingContext.Users.Find(id);
                if (user == null)
                {
                    return _repository.CreateResponse(false, null, "User not found");
                }
                _trainingContext.Users.Remove(user);
                _trainingContext.SaveChanges();
                return _repository.CreateResponse(true, user);
            }
            catch (Exception ex)
            {
                return _repository.HandleException(ex);
            }
        }

       
    }
}
