namespace GymAppTraining.Api.Models
{
    public class UpdateEnrollmentModel
    {
        public Guid Id { get; set; }
        public Guid TrainingId { get; set; }
        public Guid UserId { get; set; }
        public bool IsAttending { get; set; }
    }
}
