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
        [Key] [Required] public Guid Id { get; set; }

        [Required] public Guid TrainerId { get; set; }

        [ForeignKey(nameof(TrainerId))]
        [DeleteBehavior(DeleteBehavior.NoAction)]
        public virtual User? Trainer { get; set; }

        [Required] public Guid TrainingScheduleId { get; set; }

        [ForeignKey(nameof(TrainingScheduleId))]
        [DeleteBehavior(DeleteBehavior.NoAction)]
        public virtual TrainingSchedule? TrainingSchedule { get; set; }

        [Required] public DateTime Time { get; set; }

        [Required] public uint MaxParticipants { get; set; }

        public uint CurrentParticipants { get; set; }

    }
}
