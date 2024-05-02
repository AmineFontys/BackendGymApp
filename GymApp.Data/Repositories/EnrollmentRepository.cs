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
        private readonly IRepository _repository;

        public EnrollmentRepository(ITrainingContext trainingContext, IRepository repository)
        {
            _trainingContext = trainingContext;
            _repository = repository;
        }

        public RepositoryResponse<dynamic> GetAllEnrollments()
        {
            try
            {
                var enrollments = _trainingContext.Enrollments.ToList();
                return _repository.CreateResponse(true, enrollments);
            }
            catch (Exception ex)
            {
                return _repository.HandleException(ex);
            }
        }

        public RepositoryResponse<dynamic> GetEnrollmentById(Guid id)
        {
            try
            {
                var enrollment = _trainingContext.Enrollments.Find(id);
                if (enrollment == null)
                {
                    return _repository.CreateResponse(false, null, "Enrollment not found");
                }
                return _repository.CreateResponse(true, enrollment);
            }
            catch (Exception ex)
            {
                return _repository.HandleException(ex);
            }
        }
        public RepositoryResponse<dynamic> AddEnrollment(Enrollment enrollment)
        {
            try
            {
                _trainingContext.Enrollments.Add(enrollment);
                _trainingContext.SaveChanges();
                return _repository.CreateResponse(true, enrollment);
            }
            catch (Exception ex)
            {
                return _repository.HandleException(ex);
            }
        }
        public RepositoryResponse<dynamic> UpdateEnrollment(Enrollment enrollment)
        {
            try
            {
                _trainingContext.Enrollments.Update(enrollment);
                _trainingContext.SaveChanges();
                return _repository.CreateResponse(true, enrollment);
            }
            catch (Exception ex)
            {
                return _repository.HandleException(ex);
            }
        }
        public RepositoryResponse<dynamic> DeleteEnrollment(Guid id)
        {
            try
            {
                var enrollment = _trainingContext.Enrollments.Find(id);
                if (enrollment == null)
                {
                    return _repository.CreateResponse(false, null, "Enrollment not found");
                }
                _trainingContext.Enrollments.Remove(enrollment);
                _trainingContext.SaveChanges();
                return _repository.CreateResponse(true, enrollment);
            }
            catch (Exception ex)
            {
                return _repository.HandleException(ex);
            }
        }

        

        

        
    }
}
