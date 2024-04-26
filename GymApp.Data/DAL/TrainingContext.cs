using Microsoft.EntityFrameworkCore;
using GymApp.Data.Interfaces;
using GymApp.Data.Entities;

namespace GymApp.Data.DAL
{
    public class TrainingContext : DbContext, ITrainingContext
    {
        public TrainingContext(DbContextOptions<TrainingContext> options) : base(options) { }

        public void InitializeDatabase()
        {
            Database.EnsureCreated();
        }

        public virtual DbSet<Enrollment> Enrollments { get; set; }
        public virtual DbSet<Exercise> Exercises { get; set; }
        public virtual DbSet<Training> Trainings { get; set; }
        public virtual DbSet<TrainingSchedule> TrainingSchedules { get; set; }
        public virtual DbSet<User> Users { get; set; }

        
    }
}
