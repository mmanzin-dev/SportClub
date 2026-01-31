namespace SportClub.Models
{
    public class Player
    {
        public int Id {get; set;}

        public string FirstName {get; set;}

        public string LastName {get; set;}

        public DateTime DateOfBirth {get; set;}

        public string Email {get; set;}

        public string PhoneNumber {get; set;}

        public int JerseyNumber {get; set;}

        public string Position {get; set;}

        public bool Active {get; set;}

        public int TeamId {get; set;}
        
        public Team Team {get; set;}
    }
}