using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace GymApp.Data.Entities
{
    [Table("Enrollments")]
    public class Enrollment
    {
        [Key] [Required] public Guid Id { get; set; }

        [ForeignKey(nameof(TrainingId))] [Required] public virtual Training? Training { get; set; }

        [Required] public Guid TrainingId { get; set; }

        [ForeignKey(nameof(MemberId))] [Required] public virtual User? Member { get; set; }

        [Required] public Guid MemberId { get; set; }

        [Required] public bool EnrollmentCanceled { get; set; }


    }

}
