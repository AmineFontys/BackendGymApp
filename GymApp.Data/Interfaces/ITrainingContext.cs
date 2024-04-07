using GymApp.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace GymApp.Data.Interfaces
{
    public interface ITrainingContext: IDisposable
    {
        DbSet<Enrollment> Enrollments { get; set; }
        DbSet<Exercise> Exercise { get; set; }
        DbSet<Training> Training { get; set; }
        DbSet<TrainingSchedule> TrainingSchedule { get; set; }
        DbSet<User> Users { get; set; }


    }
}
