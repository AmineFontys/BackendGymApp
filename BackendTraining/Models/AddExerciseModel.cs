namespace GymAppTraining.Api.Models
{
    public class AddExerciseModel
    {
        public string Name { get; set; }
        public string MuscleGroup { get; set; }
        public string Description { get; set; }
        public uint Reps { get; set; }
        public uint Sets { get; set; }
        public uint Weight { get; set; }
        public uint RestTime { get; set; }
        public uint DurationInSeconds { get; set; }

#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
        public AddExerciseModel() { }
#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
    }
}
