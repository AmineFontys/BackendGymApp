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
        private readonly IService _service;

        public EnrollmentService(IEnrollmentRepository enrollmentRepository, IMapper mapper, IService service)
        {
            _iEnrollmentRepository = enrollmentRepository;
            _mapper = mapper;
            _service = service;
        }

        
        public ServiceResponse<dynamic> GetAllEnrollments() => _service.HandleResponse<Exercise, ExerciseModel>(_iEnrollmentRepository.GetAllEnrollments());
        public ServiceResponse<dynamic> GetEnrollmentById(Guid id) => _service.HandleResponse<Exercise, ExerciseModel>(_iEnrollmentRepository.GetEnrollmentById(id));
        public ServiceResponse<dynamic> AddEnrollment(EnrollmentModel enrollment) => _service.HandleResponse<Exercise, ExerciseModel>(_iEnrollmentRepository.AddEnrollment(_mapper.Map<Enrollment>(enrollment)));
        public ServiceResponse<dynamic> UpdateEnrollment(EnrollmentModel enrollment) => _service.HandleResponse<Exercise, ExerciseModel>(_iEnrollmentRepository.UpdateEnrollment(_mapper.Map<Enrollment>(enrollment)));
        public ServiceResponse<dynamic> DeleteEnrollment(Guid id) => _service.HandleResponse<Exercise, ExerciseModel>(_iEnrollmentRepository.DeleteEnrollment(id));
    }
}
