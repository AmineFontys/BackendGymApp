using GymApp.Data.Entities;
using GymApp.Data.Interfaces;
using Microsoft.Identity.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GymApp.Data.Repositories
{
    public class EnrollmentRepository: IEnrollmentRepository
    {
        private readonly ITrainingContext _trainingContext;

        public EnrollmentRepository(ITrainingContext trainingContext)
        {
            _trainingContext = trainingContext;
        }

        public RepositoryResponse<dynamic> AddEnrollment(Enrollment enrollment)
        {
            try
            {
                _trainingContext.Enrollments.Add(enrollment);
                _trainingContext.SaveChanges();
                return new RepositoryResponse<dynamic>
                {
                    Success = true,
                    Data = enrollment
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

        public RepositoryResponse<dynamic> DeleteEnrollment(Guid id)
        {
            try
            {
                var enrollment = _trainingContext.Enrollments.Find(id);
                if (enrollment == null)
                {
                    return new RepositoryResponse<dynamic>
                    {
                        Success = false,
                        Data = null,
                        Message = "Enrollment not found"
                    };
                }
                _trainingContext.Enrollments.Remove(enrollment);
                _trainingContext.SaveChanges();
                return new RepositoryResponse<dynamic>
                {
                    Success = true,
                    Data = enrollment
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

        public RepositoryResponse<dynamic> GetAllEnrollments()
        {
            try
            {
                var enrollments = _trainingContext.Enrollments.ToList();
                return new RepositoryResponse<dynamic>
                {
                    Success = true,
                    Data = enrollments
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

        public RepositoryResponse<dynamic> GetEnrollmentById(Guid id)
        {
            try
            {
                var enrollment = _trainingContext.Enrollments.Find(id);
                if (enrollment == null)
                {
                    return new RepositoryResponse<dynamic>
                    {
                        Success = false,
                        Data = null,
                        Message = "Enrollment not found"
                    };
                }
                return new RepositoryResponse<dynamic>
                {
                    Success = true,
                    Data = enrollment
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
        public RepositoryResponse<dynamic> UpdateEnrollment(Enrollment enrollment)
        {
            try
            {
                _trainingContext.Enrollments.Update(enrollment);
                _trainingContext.SaveChanges();
                return new RepositoryResponse<dynamic>
                {
                    Success = true,
                    Data = enrollment
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
