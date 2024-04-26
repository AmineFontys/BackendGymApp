namespace GymAppTraining.Api.Models
{
    public class AddTrainingScheduleModel
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string TrainerId { get; set; }
        public string MemberId { get; set; }
        public string ExerciseId { get; set; }
        public string Date { get; set; }
        public string Time { get; set; }
        public string Duration { get; set; }
        public string Location { get; set; }

#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
        public AddTrainingScheduleModel() { }
#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
    }
}
