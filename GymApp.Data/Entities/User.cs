
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace GymApp.Data.Entities
{
    [Table("User")]
    public class User
    {
        [Key] [Required] public Guid Id { get; private set; }

        [MaxLength(50)] [Required] public string? FirstName { get; private set; }

        [MaxLength(50)] [Required] public string? SurName { get; private set; }

        [Required] public DateTime Birthdate { get; private set; }

        [Required] public bool IsMale { get; private set; }

        [Required] [MaxLength(50)] public string? PhoneNumber { get; private set; }

        [Required]
        [EmailAddress]
        [MaxLength(100)]
        public string? Email { get; private set; }

        public string? PasswordHash { get; private set; }

        [Required] public UserRole Role { get; private set; }


        public enum UserRole
        {
            Admin,
            Trainer,
            Member,

        }
    }



}
