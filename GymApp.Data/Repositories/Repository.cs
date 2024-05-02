using GymApp.Data.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GymApp.Data.Repositories
{
    public class Repository : IRepository
    {
        public RepositoryResponse<dynamic> CreateResponse(bool success, dynamic? data, string? message = null)
        {
            return new() { Success = success, Data = data, Message = message };
        }

        public RepositoryResponse<dynamic> HandleException(Exception ex)
        {
            return CreateResponse(false, ex, ex.Message);
        }
    }
}
