namespace HabitFlow.API.Models
{
    public class Profile
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public string DisplayName { get; set; }
        public string Bio {  get; set; }
        public string AvatarUrl { get; set; }
        public DateTime CreatedAt { get; set; }
        public User User { get; set; }
    }
}
