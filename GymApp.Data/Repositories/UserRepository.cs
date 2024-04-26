﻿
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

        public RepositoryResponse<dynamic> GetAllUsers() 
        {
            try
            {
                var users = _trainingContext.Users.ToList();

                return new RepositoryResponse<dynamic>
                {
                    Success = true,
                    Data = users
                };
                
            }
            catch (Exception ex) 
            {

                return new RepositoryResponse<dynamic>
                {
                    Success = false,
                    Data = ex,
                    Message = ex.Message
                };
            }
                 
        }
        public RepositoryResponse<dynamic> AddUser(User user)
        {
            try
            {
                _trainingContext.Users.Add(user);
                _trainingContext.SaveChanges();

                return new RepositoryResponse<dynamic>
                {
                    Success = true,
                    Message = "User added successfully"
                };
            }
            catch (Exception ex)
            {
                return new RepositoryResponse<dynamic>
                {
                    Success = false,
                    Data = ex,
                    Message = ex.Message
                };
            }
        }
    }
}
