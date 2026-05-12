using System.Data;
using System;
namespace HabitFlow.API.Models
{
    public class User
    {
        public int Id { get; set;  }
        public string Username { get; set; }
        public string PasswordHash { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}
