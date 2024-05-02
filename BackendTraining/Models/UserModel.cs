namespace GymAppTraining.Api.Models
{
    public class UserModel
    {
        public Guid Id { get; set; }
        public string FirstName { get; set; } = string.Empty;
        public string SurName { get; set; } = string.Empty;
        public DateTime Birthdate { get; set; }
        public bool IsMale { get; set; }
        public string PhoneNumber { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string PasswordHash { get; set; } = string.Empty;
        public uint Role { get; set; }
    }
}
