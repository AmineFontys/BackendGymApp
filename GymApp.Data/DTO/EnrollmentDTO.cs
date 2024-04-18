using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace GymApp.Data.DTO
{
    [Table("Enrollments")]
    public class EnrollmentDTO
    {
        [Key] [Required] public Guid ID { get; set; }

        [ForeignKey("TrainingID")] [Required] public virtual TrainingDTO? Training { get; set; }

        [Required] public Guid TrainingID { get; set; }

        [ForeignKey("MemberID")] [Required] public virtual UserDTO? Member { get; set; }

        [Required] public Guid MemberID { get; set; }

        [Required] public bool EnrollmentCanceled { get; set; }


    }

}
