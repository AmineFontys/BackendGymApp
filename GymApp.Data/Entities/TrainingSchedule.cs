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
        [Key] [Required] public Guid ID { get; set; }

        [ForeignKey(nameof(TrainerID))]
        [DeleteBehavior(DeleteBehavior.NoAction)]
        public virtual User Trainer { get; set; }

        [Required] public Guid TrainerID { get; set; }

        [Required] public uint DurationInMinutes { get; set; }


        public virtual ICollection<Exercise?> Exercises { get; set; } = [];




        public TrainingSchedule()
        {
        }
    }


}
