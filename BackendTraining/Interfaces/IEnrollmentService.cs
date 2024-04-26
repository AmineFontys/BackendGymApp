using GymAppTraining.Api.Models;
using GymAppTraining.Api.Services;

namespace GymAppTraining.Api.Interfaces
{
    public interface IEnrollmentService
    {
        ServiceResponse<dynamic> GetAllEnrollments();
        ServiceResponse<dynamic> AddEnrollment(AddEnrollmentModel enrollment);
        ServiceResponse<dynamic> GetEnrollmentById(Guid id);
        ServiceResponse<dynamic> UpdateEnrollment(UpdateEnrollmentModel enrollment);
        ServiceResponse<dynamic> DeleteEnrollment(Guid id);
    }
}
