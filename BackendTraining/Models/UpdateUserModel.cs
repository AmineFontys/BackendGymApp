﻿namespace GymAppTraining.Api.Models
{
    public class UpdateUserModel
    {
        public Guid Id { get; set; }
        public string? Name { get; set; }
        public string? Email { get; set; }
        public string? Password { get; set; }
    }
}
