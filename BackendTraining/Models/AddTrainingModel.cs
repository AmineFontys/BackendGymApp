namespace GymAppTraining.Api.Models
{
    public class AddTrainingModel
    {
        public Guid TrainerId { get; set; }
        public Guid TrainingScheduleId { get; set; }
        public DateTime Time { get; set; }
        public uint MaxParticipants { get; set; }
    }
}
