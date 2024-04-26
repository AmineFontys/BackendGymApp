using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GymApp.Data.Entities
{
    [Table("Exercise")]
    public class Exercise
    {
        [Key] [Required] public Guid ID { get; set; }

        [Required] [StringLength(50)] public string? Name { get; set; }

        [Required] [StringLength(50)] public string? MuscleGroup { get; set; }

        [Required] [StringLength(250)] public string? Description { get; set; }

        [Required] public uint Reps { get; set; }

        [Required] public uint Sets { get; set; }

        [Required] public uint Weight { get; set; }

        [Required] public uint RestTime { get; set; }

        [Required] public uint DurationInSeconds { get; set; }

        public virtual ICollection<TrainingSchedule> TrainingSchedules { get; set; } = [];

    }

}

