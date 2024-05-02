using GymAppTraining.Api.Models;
using GymAppTraining.Api.Services;

namespace GymAppTraining.Api.Interfaces
{
    public interface IEnrollmentService
    {
        ServiceResponse<dynamic> GetAllEnrollments();
        ServiceResponse<dynamic> GetEnrollmentById(Guid id);
        ServiceResponse<dynamic> AddEnrollment(EnrollmentModel enrollment);
        ServiceResponse<dynamic> UpdateEnrollment(EnrollmentModel enrollment);
        ServiceResponse<dynamic> DeleteEnrollment(Guid id);
    }
}
