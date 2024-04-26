using GymApp.Data.Entities;
using GymApp.Data.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GymApp.Data.Interfaces
{
    public interface IEnrollmentRepository
    {
        RepositoryResponse<dynamic> GetAllEnrollments();
        RepositoryResponse<dynamic> GetEnrollmentById(Guid id);
        RepositoryResponse<dynamic> AddEnrollment(Enrollment enrollment);
        RepositoryResponse<dynamic> UpdateEnrollment(Enrollment enrollment);
        RepositoryResponse<dynamic> DeleteEnrollment(Guid id);
    }
}
