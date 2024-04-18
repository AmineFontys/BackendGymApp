using GymApp.Data.DTO;
using Microsoft.EntityFrameworkCore;

namespace GymApp.Data.Interfaces
{
    public interface ITrainingContext: IDisposable
    {
        DbSet<EnrollmentDto> Enrollments { get; set; }
        DbSet<ExerciseDto> Exercise { get; set; }
        DbSet<TrainingDto> Training { get; set; }
        DbSet<TrainingScheduleDto> TrainingSchedule { get; set; }
        DbSet<UserDto> Users { get; set; }


    }
}
