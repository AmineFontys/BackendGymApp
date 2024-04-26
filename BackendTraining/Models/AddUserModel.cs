using System.ComponentModel.DataAnnotations;

namespace GymAppTraining.Api.Models
{
    public class AddUserModel
    {
        public Guid Id { get; set; }

        public string? FirstName { get; set; }
        
        public string? SurName { get; set; }

        public DateTime Birthdate { get; set; }

        public bool IsMale { get; set; }

        public string? PhoneNumber { get; set; }

        public string? Email { get; set; }

        //public string? PasswordHash { get; set; }

        public UserRole Role { get; set; }

        public enum UserRole
        {
            Admin,
            Trainer,
            Member,
        }

        public AddUserModel() { }
        
    }
}
