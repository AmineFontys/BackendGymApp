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

        public virtual DbSet<EnrollmentDto> Enrollments { get; set; }
        public virtual DbSet<ExerciseDto> Exercise { get; set; }
        public virtual DbSet<TrainingDto> Training { get; set; }
        public virtual DbSet<TrainingScheduleDto> TrainingSchedule { get; set; }
        public virtual DbSet<UserDTO> Users { get; set; }

        
    }
}
