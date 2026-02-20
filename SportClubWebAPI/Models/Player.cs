namespace SportClubWebAPI.Models
{
    public class Player
    {
        public int Id { get; set; }

        public string FirstName { get; set; } = string.Empty;

        public string LastName { get; set; } = string.Empty;

        public DateTime DateOfBirth { get; set; }

        public string Email { get; set; } = string.Empty;

        public string PhoneNumber { get; set; } = string.Empty;

        public int JerseyNumber { get; set; }
        
        public string Position { get; set; } = string.Empty;

        public bool Active { get; set; }
        
        public int TeamId { get; set; }
        
        public Team? Team { get; set; }
    }
}
