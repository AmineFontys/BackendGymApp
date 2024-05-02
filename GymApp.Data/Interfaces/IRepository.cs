using GymApp.Data.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GymApp.Data.Interfaces
{
    public interface IRepository
    {
        RepositoryResponse<dynamic> CreateResponse(bool success, dynamic? data, string? message = null);
        RepositoryResponse<dynamic> HandleException(Exception ex);
    }
}
