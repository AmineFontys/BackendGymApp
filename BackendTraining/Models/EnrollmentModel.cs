namespace GymAppTraining.Api.Models
{
    public class EnrollmentModel
    {
        public Guid Id { get; set; }
        public Guid TrainingId { get; set; }
        public Guid UserId { get; set; }
        public DateTime EnrollmentDate { get; set; }
    }
}
