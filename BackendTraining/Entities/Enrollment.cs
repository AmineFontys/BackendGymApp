using GymApp.Data.DTO;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GymAppTraining.Api.Entities
{
    public class Enrollment
    {
        public Guid ID { get; set; }

        public virtual Training? Training { get; set; }

        public virtual User? Member { get; set; }

        public bool EnrollmentCanceled { get; set; }

    }
}
