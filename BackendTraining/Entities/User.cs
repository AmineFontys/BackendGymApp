using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GymApp.Business.Entities
{
    public class User
    {
        public Guid Id { get; private set; }

        public string? FirstName { get; private set; }

        public string? SurName { get; private set; }

        public DateTime Birthdate { get; private set; }

        public bool IsMale { get; private set; }

        public string? PhoneNumber { get; private set; }

        public string? Email { get; private set; }

        public string? PasswordHash { get; private set; }

        public UserRole Role { get; private set; }


        public enum UserRole
        {
            Admin,
            Trainer,
            Member,

        }
    }
}
