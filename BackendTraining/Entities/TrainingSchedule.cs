using GymApp.Data.DTO;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GymApp.Business.Entities
{
    public class TrainingSchedule
    {
        public Guid ID { get; set; }
                
        public virtual User? Trainer { get; set; }

        public uint DurationInMinutes { get; set; }


        public virtual ICollection<Exercise?> Exercises { get; set; } = [];
    }
}
