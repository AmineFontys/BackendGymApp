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
    public class Training
    {
        public Guid ID { get; set; }

        public User? Trainer { get; set; }

        public TrainingSchedule? TrainingSchedule { get; set; }

        public DateTime Time { get; set; }

        public uint MaxParticipants { get; set; }

        public uint CurrentParticipants { get; set; }
    }
}
