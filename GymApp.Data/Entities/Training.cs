using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GymApp.Data.Entities
{
    [Table("Training")]
    public class Training
    {
        [Key] [Required] public Guid ID { get; set; }

        [Required] public Guid TrainerID { get; set; }

        [ForeignKey(nameof(TrainerID))]
        [DeleteBehavior(DeleteBehavior.NoAction)]
        public virtual User Trainer { get; set; }

        [Required] public Guid TrainingScheduleID { get; set; }

        [ForeignKey(nameof(TrainingScheduleID))]
        [DeleteBehavior(DeleteBehavior.NoAction)]
        public virtual TrainingSchedule TrainingSchedule { get; set; }

        [Required] public DateTime Time { get; set; }

        [Required] public uint MaxParticipants { get; set; }

        public uint CurrentParticipants { get; set; }

        public Training()
        {
        }
    }
}
