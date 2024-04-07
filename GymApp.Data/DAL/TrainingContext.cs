using Microsoft.EntityFrameworkCore;
using GymApp.Data.Entities;
using GymApp.Data.Interfaces;

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
        public virtual DbSet<Exercise> Exercise { get; set; }
        public virtual DbSet<Training> Training { get; set; }
        public virtual DbSet<TrainingSchedule> TrainingSchedule { get; set; }
        public virtual DbSet<User> Users { get; set; }

        
    }
}
