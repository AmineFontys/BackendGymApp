namespace GymAppTraining.Api.Models
{
    public class TrainingScheduleModel
    {
        public Guid Id { get; set; }
        public Guid TrainerID { get; set; }
        public ICollection<Guid> ExercisesId { get; set; } = [];
    }
}
