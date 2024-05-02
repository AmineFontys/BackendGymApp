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
    [Table("TrainingSchedule")]
    public class TrainingSchedule
    {
        [Key] [Required] public Guid Id { get; private set; }

        [ForeignKey(nameof(TrainerId))]
        [DeleteBehavior(DeleteBehavior.NoAction)]
        public virtual User? Trainer { get; private set; }

        [Required] public Guid TrainerId { get; private set; }

        [Required] public uint DurationInMinutes { private get; set; }


        public virtual ICollection<Exercise?> Exercises { get; private set; } = [];

    }


}
