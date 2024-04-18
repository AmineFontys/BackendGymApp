using GymApp.Data.DTO;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GymApp.Business.Entities
{
    public class Exercise
    {
        public Guid ID { get; set; }

        public string? Name { get; set; }

        public string? MuscleGroup { get; set; }
        
        public string? Description { get; set; }
        
        public uint Reps { get; set; }

        public uint Sets { get; set; }

        public uint Weight { get; set; }

        public uint RestTime { get; set; }

        public uint DurationInSeconds { get; set; }

        public virtual ICollection<TrainingSchedule> TrainingSchedules { get; set; } = [];
    }
}
