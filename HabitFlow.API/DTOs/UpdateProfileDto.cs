using HabitFlow.API.Models;

namespace HabitFlow.API.DTOs
{
    public class UpdateProfileDto
    {
        public string DisplayName { get; set; }
        public string Bio { get; set; }
        public string AvatarUrl { get; set; }
    }
}
