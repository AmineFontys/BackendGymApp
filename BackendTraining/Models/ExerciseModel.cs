namespace GymAppTraining.Api.Models
{
    public class ExerciseModel
    {
        public Guid ID { get; set; }
        public string Name { get; set; } = string.Empty;
        public string MuscleGroup { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public uint Reps { get; set; }
        public uint DurationRep { get; set; }
        public uint Sets { get; set; }
        public uint Weight { get; set; }
        public uint RestTime { get; set; }
        public uint TotalDuration { get; set; }
    }
}
