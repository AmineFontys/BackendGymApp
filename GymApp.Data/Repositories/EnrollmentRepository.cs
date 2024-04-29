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
    public class EnrollmentRepository : IEnrollmentRepository
    {
        private readonly ITrainingContext _trainingContext;

        public EnrollmentRepository(ITrainingContext trainingContext)
        {
            _trainingContext = trainingContext;
        }

        private RepositoryResponse<dynamic> CreateResponse(bool success, dynamic? data, string? message = null)
        {
            return new RepositoryResponse<dynamic>
            {
                Success = success,
                Data = data,
                Message = message
            };
        }

        private RepositoryResponse<dynamic> HandleException(Exception ex)
        {
            return CreateResponse(false, ex, ex.Message);
        }

        public RepositoryResponse<dynamic> AddEnrollment(Enrollment enrollment)
        {
            try
            {
                _trainingContext.Enrollments.Add(enrollment);
                _trainingContext.SaveChanges();
                return CreateResponse(true, enrollment);
            }
            catch (Exception ex)
            {
                return HandleException(ex);
            }
        }

        public RepositoryResponse<dynamic> DeleteEnrollment(Guid id)
        {
            try
            {
                var enrollment = _trainingContext.Enrollments.Find(id);
                if (enrollment == null)
                {
                    return CreateResponse(false, null, "Enrollment not found");
                }
                _trainingContext.Enrollments.Remove(enrollment);
                _trainingContext.SaveChanges();
                return CreateResponse(true, enrollment);
            }
            catch (Exception ex)
            {
                return HandleException(ex);
            }
        }

        public RepositoryResponse<dynamic> GetAllEnrollments()
        {
            try
            {
                var enrollments = _trainingContext.Enrollments.ToList();
                return CreateResponse(true, enrollments);
            }
            catch (Exception ex)
            {
                return HandleException(ex);
            }
        }

        public RepositoryResponse<dynamic> GetEnrollmentById(Guid id)
        {
            try
            {
                var enrollment = _trainingContext.Enrollments.Find(id);
                if (enrollment == null)
                {
                    return CreateResponse(false, null, "Enrollment not found");
                }
                return CreateResponse(true, enrollment);
            }
            catch (Exception ex)
            {
                return HandleException(ex);
            }
        }

        public RepositoryResponse<dynamic> UpdateEnrollment(Enrollment enrollment)
        {
            try
            {
                _trainingContext.Enrollments.Update(enrollment);
                _trainingContext.SaveChanges();
                return CreateResponse(true, enrollment);
            }
            catch (Exception ex)
            {
                return HandleException(ex);
            }
        }
    }
}
