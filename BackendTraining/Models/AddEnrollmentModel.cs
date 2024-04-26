namespace GymAppTraining.Api.Models
{
    public class AddEnrollmentModel
    {
        public string UserId { get; set; }
        public string TrainingId { get; set; }

#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
        public AddEnrollmentModel() { }
#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
    }
}
