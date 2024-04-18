using Microsoft.EntityFrameworkCore;
using GymApp.Data.Interfaces;
using GymApp.Data.DTO;

namespace GymApp.Data.DAL
{
    public class TrainingContext : DbContext, ITrainingContext
    {
        public TrainingContext(DbContextOptions<TrainingContext> options) : base(options) { }

        public void InitializeDatabase()
        {
            Database.EnsureCreated();
        }

        public virtual DbSet<EnrollmentDTO> Enrollments { get; set; }
        public virtual DbSet<ExerciseDTO> Exercise { get; set; }
        public virtual DbSet<TrainingDTO> Training { get; set; }
        public virtual DbSet<TrainingScheduleDTO> TrainingSchedule { get; set; }
        public virtual DbSet<UserDTO> Users { get; set; }

        
    }
}
