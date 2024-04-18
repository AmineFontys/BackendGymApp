using GymApp.Data.DTO;
using Microsoft.EntityFrameworkCore;

namespace GymApp.Data.Interfaces
{
    public interface ITrainingContext: IDisposable
    {
        DbSet<EnrollmentDTO> Enrollments { get; set; }
        DbSet<ExerciseDTO> Exercise { get; set; }
        DbSet<TrainingDTO> Training { get; set; }
        DbSet<TrainingScheduleDTO> TrainingSchedule { get; set; }
        DbSet<UserDTO> Users { get; set; }


    }
}
