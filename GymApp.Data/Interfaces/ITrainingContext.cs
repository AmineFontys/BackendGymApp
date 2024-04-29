using GymApp.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace GymApp.Data.Interfaces
{
    public interface ITrainingContext: IDisposable
    {
        DbSet<Enrollment> Enrollments { get; set; }
        DbSet<Exercise> Exercises { get; set; }
        DbSet<Training> Trainings { get; set; }
        DbSet<TrainingSchedule> TrainingSchedules { get; set; }
        DbSet<User> Users { get; set; }

        int SaveChanges();

        EntityEntry<TEntity> Entry<TEntity>(TEntity entity) where TEntity : class;



    }
}
