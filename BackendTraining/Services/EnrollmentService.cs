using AutoMapper;
using GymApp.Data.Entities;
using GymApp.Data.Interfaces;
using GymApp.Data.Repositories;
using GymAppTraining.Api.Interfaces;
using GymAppTraining.Api.Models;

namespace GymAppTraining.Api.Services
{
    public class EnrollmentService: IEnrollmentService
    {
        private readonly IEnrollmentRepository _iEnrollmentRepository;
        private readonly IMapper _mapper;

        public EnrollmentService(IEnrollmentRepository enrollmentRepository, IMapper mapper)
        {
            _iEnrollmentRepository = enrollmentRepository;
            _mapper = mapper;
        }

        public ServiceResponse<dynamic> GetAllEnrollments()
        {
            var enrollments = _iEnrollmentRepository.GetAllEnrollments();
            if (enrollments.Success)
            {
                try
                {
                    return new ServiceResponse<dynamic>
                    {
                        Success = true,
                        Data = enrollments.Data
                    };
                }
                catch (System.Exception ex)
                {
                    return new ServiceResponse<dynamic>
                    {
                        Success = false,
                        Data = ex,
                        Message = ex.Message
                    };
                }
            }
            else
            {
                return new ServiceResponse<dynamic>
                {
                    Success = false,
                    Data = enrollments.Data,
                    Message = enrollments.Message
                };
            }
        }

        public ServiceResponse<dynamic> AddEnrollment(AddEnrollmentModel enrollment)
        {
            var enrollmentEntity = _mapper.Map<Enrollment>(enrollment);
            var response = _iEnrollmentRepository.AddEnrollment(enrollmentEntity);
            if (response.Success)
            {
                return new ServiceResponse<dynamic>
                {
                    Success = true,
                    Data = response.Data
                };
            }
            else
            {
                return new ServiceResponse<dynamic>
                {
                    Success = false,
                    Data = response.Data,
                    Message = response.Message
                };
            }
        }

        public ServiceResponse<dynamic> GetEnrollmentById(Guid id)
        {
            var enrollment = _iEnrollmentRepository.GetEnrollmentById(id);
            if (enrollment.Success)
            {
                try
                {
                    return new ServiceResponse<dynamic>
                    {
                        Success = true,
                        Data = enrollment.Data
                    };
                }
                catch (System.Exception ex)
                {
                    return new ServiceResponse<dynamic>
                    {
                        Success = false,
                        Data = ex,
                        Message = ex.Message
                    };
                }
            }
            else
            {
                return new ServiceResponse<dynamic>
                {
                    Success = false,
                    Data = enrollment.Data,
                    Message = enrollment.Message
                };
            }
        }

        public ServiceResponse<dynamic> UpdateEnrollment(UpdateEnrollmentModel enrollment)
        {
            var enrollmentEntity = _mapper.Map<Enrollment>(enrollment);
            var response = _iEnrollmentRepository.UpdateEnrollment(enrollmentEntity);
            if (response.Success)
            {
                return new ServiceResponse<dynamic>
                {
                    Success = true,
                    Data = response.Data
                };
            }
            else
            {
                return new ServiceResponse<dynamic>
                {
                    Success = false,
                    Data = response.Data,
                    Message = response.Message
                };
            }
        }

        public ServiceResponse<dynamic> DeleteEnrollment(Guid id)
        {
            var response = _iEnrollmentRepository.DeleteEnrollment(id);
            if (response.Success)
            {
                return new ServiceResponse<dynamic>
                {
                    Success = true,
                    Data = response.Data
                };
            }
            else
            {
                return new ServiceResponse<dynamic>
                {
                    Success = false,
                    Data = response.Data,
                    Message = response.Message
                };
            }
        }



    }
}
