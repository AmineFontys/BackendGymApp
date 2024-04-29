using AutoMapper;
using GymApp.Data.Entities;
using GymApp.Data.Interfaces;
using GymApp.Data.Repositories;
using GymAppTraining.Api.Interfaces;
using GymAppTraining.Api.Models;

namespace GymAppTraining.Api.Services
{
    public class EnrollmentService : IEnrollmentService
    {
        private readonly IEnrollmentRepository _iEnrollmentRepository;
        private readonly IMapper _mapper;

        public EnrollmentService(IEnrollmentRepository enrollmentRepository, IMapper mapper)
        {
            _iEnrollmentRepository = enrollmentRepository;
            _mapper = mapper;
        }

        private ServiceResponse<dynamic> CreateResponse(bool success, dynamic data, string message) => new ServiceResponse<dynamic> { Success = success, Data = data, Message = message };

        private ServiceResponse<dynamic> HandleResponse(RepositoryResponse<dynamic> response) => CreateResponse(response.Success, response.Data, response.Message);

        public ServiceResponse<dynamic> GetAllEnrollments() => HandleResponse(_iEnrollmentRepository.GetAllEnrollments());

        public ServiceResponse<dynamic> AddEnrollment(AddEnrollmentModel enrollment) => HandleResponse(_iEnrollmentRepository.AddEnrollment(_mapper.Map<Enrollment>(enrollment)));

        public ServiceResponse<dynamic> GetEnrollmentById(Guid id) => HandleResponse(_iEnrollmentRepository.GetEnrollmentById(id));

        public ServiceResponse<dynamic> UpdateEnrollment(UpdateEnrollmentModel enrollment) => HandleResponse(_iEnrollmentRepository.UpdateEnrollment(_mapper.Map<Enrollment>(enrollment)));

        public ServiceResponse<dynamic> DeleteEnrollment(Guid id) => HandleResponse(_iEnrollmentRepository.DeleteEnrollment(id));
    }
}
