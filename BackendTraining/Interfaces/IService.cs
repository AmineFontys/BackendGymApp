using GymApp.Data.Repositories;
using GymAppTraining.Api.Services;

namespace GymAppTraining.Api.Interfaces
{
    public interface IService
    {
        ServiceResponse<dynamic> HandleResponse<TSrc, TDest>(RepositoryResponse<dynamic> response);
        ServiceResponse<dynamic> ReturnResponse(RepositoryResponse<dynamic> response);
    }
}
