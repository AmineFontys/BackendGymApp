namespace GymAppTraining.Api.Models
{
    public class TrainingModel
    {
        public Guid Id { get; set; }
        public Guid TrainerId { get; set; }
        public Guid TrainingScheduleId { get; set; }
        public DateTime Time { get; set; }
        public uint MaxParticipants { get; set; }
    }
}
