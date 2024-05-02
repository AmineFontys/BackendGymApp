using AutoMapper;
using Azure;
using GymApp.Data.Repositories;
using GymAppTraining.Api.Interfaces;
using static System.Net.Mime.MediaTypeNames;

namespace GymAppTraining.Api.Services
{
    public class Service : IService
    {
        private readonly IMapper _mapper;

        public Service(IMapper mapper)
        {
            _mapper = mapper;
        }

        public ServiceResponse<dynamic> HandleResponse<TSrc, TDest>(RepositoryResponse<dynamic> response)
        {
            if (response.Success && response.Data != null)
            {

                if (response.Data is IEnumerable<TSrc> sourceCollection)
                {
                    response.Data = _mapper.Map<IEnumerable<TDest>>(sourceCollection);
                }

                else if (response.Data is TSrc sourceItem)
                {
                    response.Data = _mapper.Map<TDest>(sourceItem);
                }

                return ReturnResponse(response);
            }

            return ReturnResponse(response);
        }

        public ServiceResponse<dynamic> ReturnResponse(RepositoryResponse<dynamic> response)
        {
            return _mapper.Map<ServiceResponse<dynamic>>(response);
        }

        
    }
}
